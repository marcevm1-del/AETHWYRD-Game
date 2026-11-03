"""Loads Data/World/physical_map.json (+ regions.json) defensively into numpy arrays and feature lists.

Optional keys the world-designer may add are used when present: `settlements`, `roads`, and smoothed river paths
(`smoothPath` / `pathSmooth` / `smooth` on a river). Otherwise: settlements come from regions.json map.places plus
the endpoints of corridors[].legs[], roads from the land legs, rivers from rivers[].path (corner-cut here).
All positions are map units = km, x east, y south (rows of the grid run south).
"""
import json
import math
import os

import numpy as np

CODES = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"

# Settlement pad sizes in metres: (flat radius, skirt width). Brindlewick leaves room for the hand-built 200 m
# Ring 0 field (half-diagonal 141 m) so its flat radius is 160 m.
PAD_DEFAULT = {"city": (130.0, 130.0), "town": (80.0, 100.0), "village": (50.0, 70.0), "hamlet": (30.0, 50.0)}
BRINDLEWICK_FLAT_M = 160.0
KIND_SIZE = {"capital": "city", "city": "city", "town": "town", "port": "town", "fortress": "town", "market": "town",
             "fort": "village", "camp": "village", "monastery": "village", "village": "village", "farmland": "village",
             "eyrie": "village", "hamlet": "hamlet", "farmstead": "hamlet", "inn": "hamlet", "shrine": "hamlet", "glade": "hamlet"}
RING0_SIZE_M = 200.0


def _list(x):
    if x is None:
        return []
    if isinstance(x, dict):
        for k in ("items", "list", "features", "entries"):
            if isinstance(x.get(k), list):
                return x[k]
        return [dict(v, id=k) if isinstance(v, dict) else {"id": k, "at": v} for k, v in x.items()]
    return list(x)


def _xy(e):
    for k in ("at", "pos", "position", "xy", "point"):
        v = e.get(k)
        if isinstance(v, (list, tuple)) and len(v) >= 2:
            return float(v[0]), float(v[1])
    if "x" in e and "y" in e:
        return float(e["x"]), float(e["y"])
    return None


def chaikin(pts, n=2):
    pts = [tuple(p) for p in pts]
    for _ in range(n):
        if len(pts) < 3:
            break
        out = [pts[0]]
        for a, b in zip(pts, pts[1:]):
            out.append((a[0] * 0.75 + b[0] * 0.25, a[1] * 0.75 + b[1] * 0.25))
            out.append((a[0] * 0.25 + b[0] * 0.75, a[1] * 0.25 + b[1] * 0.75))
        out.append(pts[-1])
        pts = out
    return pts


def gaussian_blur(a, sigma):
    if sigma <= 0:
        return a.copy()
    r = int(math.ceil(3 * sigma))
    k = np.exp(-0.5 * (np.arange(-r, r + 1) / sigma) ** 2)
    k /= k.sum()
    p = np.pad(a, r, mode="edge")
    p = np.apply_along_axis(lambda v: np.convolve(v, k, mode="valid"), 1, p)
    return np.apply_along_axis(lambda v: np.convolve(v, k, mode="valid"), 0, p)


class World:
    def __init__(self, repo):
        self.repo = os.path.abspath(repo)
        D = json.load(open(os.path.join(self.repo, "Data", "World", "physical_map.json"), encoding="utf-8"))
        self.D = D
        self.W, self.H, self.ck = D["grid"]["width"], D["grid"]["height"], D["grid"]["cellKm"]
        self.width_km, self.height_km = self.W * self.ck, self.H * self.ck
        self.elev_raw = np.array(D["elevation"]["rows"], dtype=np.float64)
        self.biome = np.array([list(r) for r in D["biomes"]["rows"]])
        self.legend = D["regions"]["legend"]
        self.region = np.array([[CODES.find(c) if c != "." else -1 for c in r] for r in D["regions"]["rows"]], dtype=np.int32)
        self.names = {r["id"]: r["name"] for r in D["regionStats"]}
        self.has_settlements = bool(D.get("settlements"))
        self.has_roads = bool(D.get("roads"))
        self.has_smooth_rivers = any(any(k in r for k in ("smoothPath", "pathSmooth", "smooth")) for r in D["rivers"])
        self._grids()
        self.peaks = self._peaks()
        self.lakes = self._lakes()
        self.rivers = self._rivers()
        self.settlements = self._settlements()
        self.roads = self._roads()

    # -- grids -------------------------------------------------------------------------------------------------
    def _grids(self):
        e = self.elev_raw
        sm = gaussian_blur(e, 0.9)
        # keep the coastline: land stays >= 2 m, sea <= -2 m (as the relief renders do)
        self.elev = np.where(e >= 0, np.maximum(sm, 2.0), np.minimum(sm, -2.0))
        b = self.biome
        groups = {
            "mountain": "man", "volcanic": "v", "snow": "n", "desert": "d", "beach": "b", "swamp": "w", "forest": "f",
            "plains": "p", "steppe": "s", "jungle": "j", "tundra": "t", "spirit": "i", "demon": "x", "lake": "l", "sea": "~",
        }
        self.mask_names = sorted(groups)
        stack = []
        for name in self.mask_names:
            m = np.isin(b, list(groups[name])).astype(np.float64)
            if name == "sea":
                m = np.maximum(m, (self.elev_raw < 0).astype(np.float64))
            stack.append(gaussian_blur(m, 0.8))
        self.masks = np.stack(stack)               # (K, H, W)
        self.mask_index = {n: i for i, n in enumerate(self.mask_names)}
        self.lake_label = np.full((self.H, self.W), -1, dtype=np.int32)

    # -- features ----------------------------------------------------------------------------------------------
    def _peaks(self):
        out = []
        for r in self.D["ranges"]:
            for p in r.get("peaks", []):
                out.append(dict(at=(float(p["at"][0]), float(p["at"][1])), m=float(p["m"]), name=p.get("name"), range=r["id"]))
        out.sort(key=lambda p: (-p["m"], p["at"]))
        return out

    def _lakes(self):
        Ls = sorted(self.D["lakes"], key=lambda l: l["id"])
        js, is_ = np.nonzero(self.biome == "l")
        for j, i in zip(js, is_):
            mx, my = (i + 0.5) * self.ck, (j + 0.5) * self.ck
            k = min(range(len(Ls)), key=lambda q: (Ls[q]["at"][0] - mx) ** 2 + (Ls[q]["at"][1] - my) ** 2)
            self.lake_label[j, i] = k
        out = []
        for k, l in enumerate(Ls):
            ind = gaussian_blur((self.lake_label == k).astype(np.float64), 0.7)
            js2, is2 = np.nonzero(ind > 0.04)
            if len(js2) == 0:
                continue
            bbox = ((is2.min() - 1) * self.ck, (js2.min() - 1) * self.ck, (is2.max() + 2) * self.ck, (js2.max() + 2) * self.ck)
            out.append(dict(id=l["id"], at=tuple(l["at"]), surface=float(l["surfaceM"]), depth=float(l.get("maxDepthM", 10)),
                            field=ind, bbox=bbox, region=l.get("region")))
        return out

    def _rivers(self):
        out = []
        for r in sorted(self.D["rivers"], key=lambda r: str(r.get("id", ""))):
            raw = None
            for k in ("smoothPath", "pathSmooth", "smooth"):
                if isinstance(r.get(k), list) and len(r[k]) > 1:
                    raw = r[k]
                    break
            smoothed = raw is not None
            src = [(q[0], q[1]) for q in (raw if smoothed else r["path"])]
            pts = chaikin(src, 0 if smoothed else 3)
            ordv = qv = None
            if smoothed and all(len(q) >= 5 for q in raw):      # x, y, elevation, discharge index, stream order
                qv = np.array([q[3] for q in raw], dtype=np.float64)
                ordv = np.array([q[4] for q in raw], dtype=np.float64)
            out.append(dict(id=r.get("id"), name=r.get("name"), flow=float(r.get("flowIndex", 50)), order=float(r.get("order", 2)),
                            into=(r.get("mouth") or {}).get("into"), mouth=(r.get("mouth") or {}).get("at"),
                            q=qv, ord=ordv, pts=np.array(pts, dtype=np.float64), smoothed=smoothed))
        return out

    def _settlements(self):
        res, seen = [], set()

        def add(name, at, size, src):
            key = name.lower()
            if key in seen or at is None:
                return None
            seen.add(key)
            flat, skirt = PAD_DEFAULT.get(size, PAD_DEFAULT["village"])
            ring0 = key == "brindlewick"
            if ring0:
                flat, skirt = BRINDLEWICK_FLAT_M, 140.0
            res.append(dict(name=name, at=(float(at[0]), float(at[1])), size=size, flat=flat, skirt=skirt, source=src, ring0=ring0))
            return res[-1]

        for e in _list(self.D.get("settlements")):
            at = _xy(e)
            nm = str(e.get("name") or e.get("id") or "settlement")
            size = str(e.get("size") or e.get("kind") or e.get("class") or e.get("tier") or "village").lower()
            size = KIND_SIZE.get(size, size if size in PAD_DEFAULT else "village")
            s = add(nm, at, size, "physical_map.settlements")
            flat = e.get("padRadiusM") or e.get("padM")
            if s and flat:
                s["flat"] = float(flat)
            if s and e.get("ring0"):
                s["ring0"] = True
                s["flat"], s["skirt"] = max(s["flat"], BRINDLEWICK_FLAT_M), max(s["skirt"], 140.0)
        try:
            R = json.load(open(os.path.join(self.repo, "Data", "World", "regions.json"), encoding="utf-8"))
            for r in R:
                for nm, at in ((r.get("map") or {}).get("places") or {}).items():
                    add(nm, at, "village", "regions.json map.places")
        except (OSError, ValueError):
            pass
        ends = {}
        for c in self.D["corridors"]:
            for lg in c["legs"]:
                p = lg.get("path")
                if lg.get("by") == "land" and p:
                    ends.setdefault(lg["from"], []).append(p[0])
                    ends.setdefault(lg["to"], []).append(p[-1])
        for nm in sorted(ends):
            v = ends[nm]
            at = (sum(q[0] for q in v) / len(v), sum(q[1] for q in v) / len(v))
            if not any(nm.lower() in s["name"].lower() or s["name"].lower() in nm.lower() for s in res):
                add(nm, at, "town", "corridor leg endpoint")
        return res

    def _roads(self):
        out = []
        for e in _list(self.D.get("roads")):
            p = e.get("path") or e.get("points") or e.get("polyline")
            if p and len(p) > 1:
                p = [(q[0], q[1]) for q in p]
                out.append(dict(id=str(e.get("id") or e.get("name") or "road%d" % len(out)), pts=np.array(chaikin(p, 0 if len(p) > 40 else 2), dtype=np.float64),
                                cls=str(e.get("class") or e.get("kind") or "road"), source="physical_map.roads"))
        if out:
            return out
        for c in self.D["corridors"]:
            for lg in c["legs"]:
                p = lg.get("path")
                if lg.get("by") == "land" and p and len(p) > 1:
                    out.append(dict(id="%s:%s>%s" % (c["id"], lg["from"], lg["to"]), pts=np.array(chaikin(p, 2), dtype=np.float64),
                                    cls="road", source="corridors.legs"))
        return out

    def settlement(self, name):
        for s in self.settlements:
            if s["name"].lower() == name.lower():
                return s
        return None

    def region_bbox(self, rid):
        k = self.legend.index(rid)
        js, is_ = np.nonzero(self.region == k)
        return (is_.min() * self.ck, js.min() * self.ck, (is_.max() + 1) * self.ck, (js.max() + 1) * self.ck)
