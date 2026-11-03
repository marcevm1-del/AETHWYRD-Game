"""Dressing placement for a terrain tile: trees, houses, landmarks, farms, reeds, rocks, flowers, grass clumps.

A SEPARATE LAYER on top of the height field: nothing here changes a height, the heightmap hash or a seam. It only reads
the built tile (heights, slope, masks, road / pad / river / lake weights), the world data (settlements, roads, rivers)
and writes a `Dressing` of instance lists in world metres. Pure numpy (no Blender), deterministic: every random number
is a lattice hash of world position / index and the seed, so the same tile and seed always give the same placement
(`Dressing.sha256`). Counts are capped (CAPS) by uniform thinning on a hash priority.

Ring 0: the hand-built 200 m field of Brindlewick and Millbrook (settlements with ring0) is kept clear: nothing is placed
within RING0_CLEAR_M of the centre (a square a little bigger than the 200 m field).
Rendering of the lists is in dressmesh.py (needs Blender).
"""
import hashlib
import math

import numpy as np

from . import noise
from .noise import smoothstep
from .world import RING0_SIZE_M
from .tile import snowline_m

RING0_CLEAR_M = RING0_SIZE_M / 2 + 12.0          # half side of the exclusion square round a Ring 0 centre
TREE_THIN_BIG = 0.30         # share of the candidate trees kept on 10 km tiles (same on every tile)
CAPS = {"trees": 9000, "reeds": 1400, "rocks": 600, "boulders": 700, "flowers": 160, "grass": 26000, "houses": 420, "farms": 70}
PALETTE_CITIES = {"Aldmere": 3000.0}
KIT_SIZE = {"city": 58, "town": 30, "village": 15, "hamlet": 6}


def hsh(a, b, salt, seed):
    return noise._hash(np.asarray(a), np.asarray(b), int(seed) * 131 + salt)


class Dressing:
    def __init__(self, spec):
        self.spec = spec
        self.trees = np.zeros((0, 7))          # x, y, z, kind(0 round, 1 conifer, 2 snag), scale, yaw, tint
        self.buildings = []                    # (key, x, y, z, yaw, scale, variant)
        self.props = {}                        # kind -> list of rows [x, y, z, yaw, scale, variant]
        self.walls = []                        # (x0, y0, z0, x1, y1, z1)
        self.fences = []                       # (x0, y0, x1, y1) post-and-rail runs
        self.fields = []                       # (x, y, z, yaw, w, d, variant)
        self.paths = []                        # dict(kind, pts (n,2), width)
        self.deltas = []                       # dict(x, y, dx, dy, halfwidth)
        self.grass = np.zeros((0, 4))          # x, y, z, variant
        self.landmarks = []                    # (name, x, y)
        self.notes = {}

    def add_prop(self, kind, x, y, z, yaw=0.0, scale=1.0, var=0.0):
        self.props.setdefault(kind, []).append([x, y, z, yaw, scale, var])

    def counts(self):
        c = {"trees": int(len(self.trees)), "buildings": len(self.buildings), "walls": len(self.walls), "fields": len(self.fields),
             "fences": len(self.fences), "paths": len(self.paths), "deltas": len(self.deltas), "grassClumps": int(len(self.grass))}
        for k, v in sorted(self.props.items()):
            c[k] = len(v)
        c["byKind"] = {}
        for b in self.buildings:
            c["byKind"][b[0]] = c["byKind"].get(b[0], 0) + 1
        return c

    @property
    def sha256(self):
        h = hashlib.sha256()
        h.update(np.round(self.trees, 3).astype("<f8").tobytes())
        h.update(np.round(self.grass, 3).astype("<f8").tobytes())
        for b in self.buildings:
            h.update(repr((b[0],) + tuple(round(float(v), 3) for v in b[1:])).encode())
        for k in sorted(self.props):
            h.update(k.encode())
            h.update(np.round(np.array(self.props[k], dtype=np.float64), 3).astype("<f8").tobytes())
        h.update(repr([tuple(round(float(v), 3) for v in w) for w in self.walls]).encode())
        h.update(repr([tuple(round(float(v), 3) for v in w) for w in self.fields]).encode())
        h.update(repr([tuple(round(float(v), 2) for v in w) for w in self.fences]).encode())
        h.update(repr([(q["kind"], np.round(q["pts"], 2).tolist()) for q in self.paths]).encode())
        return h.hexdigest()


class Sampler:
    """Bilinear lookups into a built tile's rasters at world coordinates (metres)."""

    def __init__(self, t):
        self.t = t
        s = t.spec
        self.x0, self.y0, self.res, self.n = float(s.x0_m), float(s.y0_m), float(s.res_m), s.n
        self.x1, self.y1 = self.x0 + s.size_m, self.y0 + s.size_m

    def inside(self, X, Y, margin=0.0):
        return (X >= self.x0 + margin) & (X <= self.x1 - margin) & (Y >= self.y0 + margin) & (Y <= self.y1 - margin)

    def at(self, A, X, Y):
        fx = np.clip((np.asarray(X, dtype=np.float64) - self.x0) / self.res, 0, self.n - 1.0001)
        fy = np.clip((np.asarray(Y, dtype=np.float64) - self.y0) / self.res, 0, self.n - 1.0001)
        i, j = np.floor(fx).astype(int), np.floor(fy).astype(int)
        tx, ty = fx - i, fy - j
        return (A[j, i] * (1 - tx) * (1 - ty) + A[j, i + 1] * tx * (1 - ty) + A[j + 1, i] * (1 - tx) * ty + A[j + 1, i + 1] * tx * ty)


def _near_mask(t, points_hw):
    """bool raster: within (halfwidth + margin) of any river point."""
    s = t.spec
    m = np.zeros((s.n, s.n), dtype=bool)
    for P, hw, mar in points_hw:
        for (x, y), w in zip(P, hw):
            r = w + mar
            i0, i1 = int(math.floor((x - r - s.x0_m) / s.res_m)), int(math.ceil((x + r - s.x0_m) / s.res_m))
            j0, j1 = int(math.floor((y - r - s.y0_m) / s.res_m)), int(math.ceil((y + r - s.y0_m) / s.res_m))
            if i1 < 0 or j1 < 0 or i0 >= s.n or j0 >= s.n:
                continue
            i0, j0, i1, j1 = max(i0, 0), max(j0, 0), min(i1, s.n - 1), min(j1, s.n - 1)
            xs = s.x0_m + np.arange(i0, i1 + 1) * s.res_m
            ys = s.y0_m + np.arange(j0, j1 + 1) * s.res_m
            m[j0:j1 + 1, i0:i1 + 1] |= (np.hypot(xs[None, :] - x, ys[:, None] - y) <= r)
    return m


def _box_blur(a, r):
    """Mean over a (2r+1)^2 window (edge padded), separable."""
    k = 2 * r + 1
    p = np.pad(a.astype(np.float64), r, mode="edge")
    c = np.cumsum(np.pad(p, ((0, 0), (1, 0))), axis=1)
    p = (c[:, k:] - c[:, :-k]) / k
    c = np.cumsum(np.pad(p, ((1, 0), (0, 0))), axis=0)
    return (c[k:, :] - c[:-k, :]) / k


class Ctx:
    """Everything the placers need about a tile."""

    def __init__(self, world, field, t, seed):
        self.world, self.field, self.t, self.seed = world, field, t, seed
        self.S = Sampler(t)
        s = t.spec
        self.river_near = _near_mask(t, [(r["P"], r["hw"], 7.0) for r in t.rivers]) if t.rivers else np.zeros((s.n, s.n), dtype=bool)
        self.land = t.h > 2.0
        self.ring0 = [(st["at"][0] * 1000.0, st["at"][1] * 1000.0) for st in world.settlements if st.get("ring0")]
        sea = (t.h < 0.0).astype(np.float64)
        self.shore_r = max(2, int(round(260.0 / s.res_m)))
        self.near_sea = _box_blur(sea, self.shore_r) if sea.any() else np.zeros_like(sea)
        self.paths = []
        self.ridge = t.h - _box_blur(t.h, max(2, int(round(420.0 / s.res_m))))                 # + on convex crests, - in hollows
        self.ripar = _box_blur(self.river_near.astype(np.float64), max(2, int(round(110.0 / s.res_m))))

    def in_ring0(self, X, Y):
        X, Y = np.asarray(X, dtype=np.float64), np.asarray(Y, dtype=np.float64)
        bad = np.zeros(X.shape, dtype=bool)
        for cx, cy in self.ring0:
            bad |= (np.abs(X - cx) <= RING0_CLEAR_M) & (np.abs(Y - cy) <= RING0_CLEAR_M)
        return bad

    def h(self, X, Y):
        return self.S.at(self.t.h, X, Y)

    def ok_ground(self, X, Y, max_slope=0.30, road_max=0.35, margin=8.0):
        S, t = self.S, self.t
        ok = S.inside(X, Y, margin) & ~self.in_ring0(X, Y)
        ok &= S.at(self.land.astype(np.float64), X, Y) > 0.99
        ok &= S.at(t.slope, X, Y) < max_slope
        ok &= S.at(t.road_w, X, Y) < road_max
        ok &= S.at(t.lake_m, X, Y) < 0.2
        ok &= S.at(self.river_near.astype(np.float64), X, Y) < 0.01
        ok &= self.path_clear(X, Y)
        return ok

    def path_clear(self, X, Y, d=6.0):
        ok = np.ones(np.shape(X), dtype=bool)
        for pts in self.paths:
            for a, b in zip(pts[:-1], pts[1:]):
                ab = b - a
                L2 = float(ab @ ab) or 1.0
                tt = np.clip(((X - a[0]) * ab[0] + (Y - a[1]) * ab[1]) / L2, 0, 1)
                ok &= np.hypot(X - (a[0] + tt * ab[0]), Y - (a[1] + tt * ab[1])) > d
        return ok


def _greedy(xs, ys, min_d, existing=()):
    """Indices accepted in order so that no two points are closer than min_d (also to `existing` [(x, y), ...])."""
    keep, pts = [], list(existing)
    for k in range(len(xs)):
        p = (xs[k], ys[k])
        if all((p[0] - q[0]) ** 2 + (p[1] - q[1]) ** 2 >= min_d * min_d for q in pts):
            keep.append(k)
            pts.append(p)
    return keep


# ----------------------------------------------------------------------------------------------------------------
# Trees

def place_trees(cx: Ctx, D: Dressing):
    t, S, seed = cx.t, cx.S, cx.seed
    s = t.spec
    C = 36.0 if s.size_m > 3000 else 26.0
    gx0, gx1 = int(math.floor(s.x0_m / C)), int(math.floor((s.x0_m + s.size_m) / C))
    gy0, gy1 = int(math.floor(s.y0_m / C)), int(math.floor((s.y0_m + s.size_m) / C))
    gx, gy = np.meshgrid(np.arange(gx0, gx1 + 1), np.arange(gy0, gy1 + 1))
    gx, gy = gx.ravel(), gy.ravel()
    X = (gx + 0.12 + 0.76 * hsh(gx, gy, 1, seed)) * C
    Y = (gy + 0.12 + 0.76 * hsh(gx, gy, 2, seed)) * C
    inb = S.inside(X, Y, 1.0)
    X, Y, gx, gy = X[inb], Y[inb], gx[inb], gy[inb]
    m = {k: S.at(v, X, Y) for k, v in t.masks.items()}
    h = S.at(t.h, X, Y)
    groves = smoothstep(0.42, 0.72, noise.fbm(X, Y, 520.0, 3, seed + 301))
    clear = 1.0 - 0.92 * smoothstep(0.50, 0.78, noise.fbm(X, Y, 360.0, 2, seed + 302))
    snl = snowline_m(Y / 1000.0)
    treeline = 1.0 - smoothstep(snl - 1000.0, snl - 330.0, h + 70.0 * noise.fbm(X, Y, 700.0, 2, seed + 303))
    # forest stands with soft edges, meadows between them, small clumps inside
    stand = noise.fbm(X, Y, 1150.0, 3, seed + 310)
    standw = smoothstep(-0.16, 0.12, stand)
    clump = 0.30 + 0.70 * smoothstep(-0.45, 0.25, noise.fbm(X, Y, 150.0, 2, seed + 313))
    forestd = 0.95 * (0.04 + 0.96 * standw) * clump * clear
    ridge = S.at(cx.ridge, X, Y)
    ridge_th = 1.0 - 0.55 * smoothstep(3.0, 14.0, ridge)                       # thinner on crests
    ripar = S.at(cx.ripar, X, Y)
    val = S.at(t.valley, X, Y)
    ripar_up = 1.0 + 1.2 * smoothstep(0.05, 0.35, ripar)                       # denser gallery woods beside rivers
    meadow_fp = 1.0 - 0.55 * val * (1.0 - smoothstep(0.05, 0.30, ripar))       # open floodplain meadows away from the bank
    near_town = np.ones_like(X)
    for st_ in cx.world.settlements:
        d_ = np.hypot(X - st_["at"][0] * 1000.0, Y - st_["at"][1] * 1000.0)
        reach_ = st_["flat"] + st_["skirt"]
        near_town = np.minimum(near_town, 0.10 + 0.90 * smoothstep(0.7 * reach_, reach_ + 380.0, d_))
    meadow_single = 0.05 + 0.03 * noise.fbm(X, Y, 90.0, 2, seed + 314)         # scattered single trees out in the meadows
    wood = (np.clip(m["forest"] + m["jungle"], 0, 1) * forestd
            + m["plains"] * (0.78 * standw * groves + meadow_single)
            + m["steppe"] * 0.04 + m["swamp"] * 0.30 * (0.3 + 0.7 * standw) + m["tundra"] * 0.16
            + m["mountain"] * (0.18 + 0.62 * standw) * clear + m["spirit"] * 0.22 + m["demon"] * 0.05 + m["volcanic"] * 0.02)
    dens = np.minimum(1.0, wood * ridge_th * ripar_up * meadow_fp * near_town * treeline)
    dens = dens * (1.0 - m["desert"]) * (1.0 - smoothstep(0.15, 0.5, m["beach"]))
    ok = S.at(t.h, X, Y) > 3.0
    ok &= S.at(t.slope, X, Y) < 0.95
    ok &= S.at(t.road_w, X, Y) < 0.04
    ok &= S.at(t.pad_w, X, Y) < 0.02
    ok &= S.at(t.lake_m, X, Y) < 0.15
    ok &= S.at(cx.river_near.astype(np.float64), X, Y) < 0.01
    ok &= ~cx.in_ring0(X, Y)
    ok &= hsh(gx, gy, 3, seed) < dens
    for (fx_, fy_, fz_, fyaw, fw, fd, _fv) in D.fields:                         # no trees on cleared fields and pastures
        cs, sn = math.cos(fyaw), math.sin(fyaw)
        u = (X - fx_) * cs + (Y - fy_) * sn
        v = -(X - fx_) * sn + (Y - fy_) * cs
        ok &= ~((np.abs(u) < fw / 2 + 4.0) & (np.abs(v) < fd / 2 + 4.0))
    X, Y, h, gx, gy = X[ok], Y[ok], h[ok], gx[ok], gy[ok]
    m = {k: v[ok] for k, v in m.items()}
    n = len(X)
    cold = smoothstep(46000.0, 34000.0, Y) + smoothstep(450.0, 1100.0, h) + m["tundra"] + 0.6 * m["mountain"]
    r4 = hsh(gx, gy, 4, seed)
    patch = noise.fbm(X, Y, 640.0, 2, seed + 311)                               # mixed species: conifer stands against broadleaf stands
    conifer = r4 < np.clip(cold, 0, 1) * 0.85 + 0.12 * m["forest"] + 0.75 * smoothstep(0.10, 0.34, patch) - 0.55 * smoothstep(-0.5, -0.2, -patch) * (1.0 - np.clip(cold, 0, 1))
    snag = hsh(gx, gy, 5, seed) < (0.03 + 0.04 * m["swamp"] + 0.25 * np.clip(m["volcanic"] + m["demon"], 0, 1))
    kind = np.where(snag, 2, np.where(conifer, 1, 0))
    scale = 0.78 + 0.62 * hsh(gx, gy, 6, seed) ** 1.3
    yaw = hsh(gx, gy, 7, seed) * 2 * math.pi
    tint = np.clip(0.55 * hsh(gx, gy, 8, seed) + 0.45 * (0.5 + 0.5 * noise.fbm(X, Y, 380.0, 2, seed + 312)), 0, 1)
    pri = hsh(gx, gy, 9, seed)
    # thinning is a WORLD constant (by tile size only), never a function of this tile's count: a count-based cap gave a density step at tile joins
    thin = 1.0 if s.size_m <= 3000 else TREE_THIN_BIG
    keep = pri < thin
    if thin < 1.0:
        scale = scale * 1.15                            # thinned: the rest grow a little to keep the cover
    z = S.at(t.h, X, Y)
    D.trees = np.stack([X, Y, z, kind, scale, yaw, tint], 1)[keep]
    D.notes["treeCandidates"] = int(n)


# ----------------------------------------------------------------------------------------------------------------
# Settlements

def _road_pts_near(cx_: Ctx, x, y, r_lo, r_hi):
    """Points of road centrelines (world metres, with tangent) whose distance to (x, y) is in [r_lo, r_hi]."""
    out = []
    for pl in cx_.field.road_lines_in(cx_.t.spec.bbox_m):
        P = pl.P
        d = np.hypot(P[:, 0] - x, P[:, 1] - y)
        for i in np.nonzero((d >= r_lo) & (d <= r_hi))[0]:
            a, b = P[max(0, i - 1)], P[min(len(P) - 1, i + 1)]
            tg = (b - a) / (np.hypot(*(b - a)) or 1.0)
            out.append((float(d[i]), float(P[i, 0]), float(P[i, 1]), float(tg[0]), float(tg[1])))
    return out


def _face_centre(x, y, cx_, cy_):
    dx, dy = cx_ - x, cy_ - y
    L = math.hypot(dx, dy) or 1.0
    return math.atan2(dx / L, -dy / L)          # local -Y (the door side of the kit) points at the centre


def _houses(cx: Ctx, D: Dressing, st, kinds, n, r_in, r_out, min_d, salt, scale_rng=(0.95, 1.2), tangential=False, extra_ok=None):
    seed = cx.seed
    cxm, cym = st["at"][0] * 1000.0, st["at"][1] * 1000.0
    M = n * 16
    idx = np.arange(M)
    key = int(round(cxm / 7.0)) * 977 + int(round(cym / 7.0)) + salt
    ang = hsh(idx, key, 11, seed) * 2 * math.pi
    rad = r_in + (r_out - r_in) * np.sqrt(hsh(idx, key, 12, seed))
    X, Y = cxm + rad * np.cos(ang), cym + rad * np.sin(ang)
    ok = cx.ok_ground(X, Y, max_slope=0.22, road_max=0.30, margin=10.0)
    if extra_ok is not None:
        ok &= extra_ok(X, Y)
    sel = np.nonzero(ok)[0]
    existing = [(b[1], b[2]) for b in D.buildings]
    acc = _greedy(X[sel], Y[sel], min_d, existing)[:n]
    for a in acc:
        k = sel[a]
        r1 = float(hsh(k, key, 13, seed))
        kk = kinds[min(int(r1 * len(kinds)), len(kinds) - 1)]
        base = _face_centre(X[k], Y[k], cxm, cym)
        yaw = base + (math.pi / 2 if tangential and hsh(k, key, 14, seed) < 0.5 else 0.0) + (float(hsh(k, key, 15, seed)) - 0.5) * 0.35
        sc = scale_rng[0] + (scale_rng[1] - scale_rng[0]) * float(hsh(k, key, 16, seed))
        D.buildings.append((kk, float(X[k]), float(Y[k]), float(cx.h(X[k], Y[k])), yaw, sc, float(hsh(k, key, 17, seed))))


def _house_kinds(size):
    if size == "hamlet":
        return ["house_cottage"] * 3 + ["cottage_round"]
    if size == "village":
        return ["house_cottage"] * 4 + ["house_house"] * 2 + ["cottage_round", "house_tall"]
    return ["house_cottage"] * 3 + ["house_house"] * 3 + ["house_tall"] * 2 + ["row_house", "cottage_round"]


def _lamps_along(cx: Ctx, D: Dressing, pts, gap=13.0, side=3.4, salt=0):
    P = np.asarray(pts, dtype=np.float64)
    seg = np.hypot(*np.diff(P, axis=0).T)
    L = float(seg.sum())
    s = np.arange(gap * 0.5, L, gap)
    cum = np.concatenate([[0], np.cumsum(seg)])
    for k, sv in enumerate(s):
        i = min(int(np.searchsorted(cum, sv) - 1), len(seg) - 1)
        tt = (sv - cum[i]) / (seg[i] or 1.0)
        p = P[i] + (P[i + 1] - P[i]) * tt
        d = (P[i + 1] - P[i]) / (seg[i] or 1.0)
        sg = 1 if k % 2 == 0 else -1
        x, y = p[0] - d[1] * side * sg, p[1] + d[0] * side * sg
        if not cx.in_ring0(x, y):
            D.buildings.append(("lamp_post", float(x), float(y), float(cx.h(x, y)), 0.0, 1.0, 0.0))


def place_settlements(cx: Ctx, D: Dressing):
    t, S = cx.t, cx.S
    s = t.spec
    seed = cx.seed
    for st in cx.world.settlements:
        cxm, cym = st["at"][0] * 1000.0, st["at"][1] * 1000.0
        reach = st["flat"] + st["skirt"]
        if not (s.x0_m - reach < cxm < s.x0_m + s.size_m + reach and s.y0_m - reach < cym < s.y0_m + s.size_m + reach):
            continue
        size = st["size"]
        name = st["name"]
        nm = name.lower()
        n = int(KIT_SIZE.get(size, 12))
        if "farm" in nm or "steads" in nm:
            _farms(cx, D, st, 3 if "farm" in nm else 2)
            continue
        if nm == "brindlewick":
            _brindlewick(cx, D, st)
            _town_fields(cx, D, st, 6)
            continue
        if size == "city":
            _walled(cx, D, st)
            _town_fields(cx, D, st, 9)
            continue
        if st.get("ring0"):                              # Millbrook: same clearing rules as Brindlewick, a smaller kit
            r_in = RING0_CLEAR_M * 1.2
            _houses(cx, D, st, _house_kinds("town"), n, r_in, st["flat"] + 0.35 * st["skirt"], 14.0, 31, tangential=True)
            _houses(cx, D, st, _house_kinds("village"), 6, st["flat"], st["flat"] + st["skirt"], 22.0, 32)
            continue
        r_out = st["flat"] + 0.3 * st["skirt"]
        _houses(cx, D, st, _house_kinds(size), n, 14.0, r_out, 13.0 if size != "hamlet" else 15.0, 33, tangential=True)
        if size in ("town", "village") and cx.ok_ground(np.array([cxm]), np.array([cym]))[0]:
            D.buildings.append(("well", cxm, cym, float(cx.h(cxm, cym)), 0.0, 1.0, 0.0))
        if size == "town":
            D.buildings.append(("guard_tower", cxm + 24.0, cym - 26.0, float(cx.h(cxm + 24.0, cym - 26.0)), 0.5, 1.15, 0.0)) if cx.ok_ground(np.array([cxm + 24.0]), np.array([cym - 26.0]))[0] else None
        _flowers(cx, D, st, 8)
        _town_fields(cx, D, st, {"town": 7, "village": 5}.get(size, 3))


def _town_fields(cx: Ctx, D: Dressing, st, n):
    """Fields and pastures in a ring round a settlement, plus a footpath to the nearest road: the town sits in worked land."""
    seed = cx.seed
    cxm, cym = st["at"][0] * 1000.0, st["at"][1] * 1000.0
    r0 = st["flat"] + 0.5 * st["skirt"]
    key = int(round(cxm / 9.0)) * 31 + int(round(cym / 9.0))
    idx = np.arange(n * 14)
    ang = hsh(idx, key, 301, seed) * 2 * math.pi
    rad = r0 + 40.0 + 330.0 * np.sqrt(hsh(idx, key, 302, seed))
    X, Y = cxm + rad * np.cos(ang), cym + rad * np.sin(ang)
    ok = cx.ok_ground(X, Y, max_slope=0.10, road_max=0.12, margin=30.0)
    got = 0
    existing = [(f[0], f[1]) for f in D.fields] + [(b[1], b[2]) for b in D.buildings]
    for k in np.nonzero(ok)[0]:
        if got >= n:
            break
        x, y = float(X[k]), float(Y[k])
        if any((x - qx) ** 2 + (y - qy) ** 2 < 62.0 ** 2 for qx, qy in existing):
            continue
        if float(cx.S.at(cx.t.masks["desert"], x, y)) > 0.2 or float(cx.S.at(cx.t.masks["mountain"], x, y)) > 0.4 or float(cx.S.at(cx.t.masks["volcanic"], x, y)) > 0.3:
            continue
        yaw = math.atan2(cym - y, cxm - x) + math.pi / 2 + (float(hsh(k, key, 303, seed)) - 0.5) * 0.5
        w_, d_ = 52.0 + 36.0 * float(hsh(k, key, 304, seed)), 34.0 + 26.0 * float(hsh(k, key, 305, seed))
        cs, sn = math.cos(yaw), math.sin(yaw)
        cor_x = np.array([x + w_ / 2 * cs - d_ / 2 * sn, x - w_ / 2 * cs - d_ / 2 * sn, x + w_ / 2 * cs + d_ / 2 * sn, x - w_ / 2 * cs + d_ / 2 * sn])
        cor_y = np.array([y + w_ / 2 * sn + d_ / 2 * cs, y - w_ / 2 * sn + d_ / 2 * cs, y + w_ / 2 * sn - d_ / 2 * cs, y - w_ / 2 * sn - d_ / 2 * cs])
        if not cx.ok_ground(cor_x, cor_y, max_slope=0.12, road_max=0.12, margin=14.0).all():
            continue
        D.fields.append((x, y, float(cx.h(x, y)), yaw, w_, d_, float((1, 3, 0, 1, 2)[int(hsh(k, key, 306, seed) * 5) % 5])))
        existing.append((x, y))
        got += 1
    # a footpath to the nearest road
    best = None
    for pl in cx.field.road_lines_in(cx.t.spec.bbox_m):
        d = np.hypot(pl.P[:, 0] - cxm, pl.P[:, 1] - cym)
        j = int(np.argmin(d))
        if d[j] > r0 + 40.0 and d[j] < r0 + 900.0 and (best is None or d[j] < best[0]):
            best = (float(d[j]), float(pl.P[j, 0]), float(pl.P[j, 1]))
    if best is not None and not st.get("ring0"):
        ux, uy = best[1] - cxm, best[2] - cym
        L = math.hypot(ux, uy)
        pts = []
        for i in range(9):
            u = i / 8.0
            wob = math.sin(u * math.pi * 2.0 + key) * 7.0 * math.sin(u * math.pi)
            pts.append((cxm + ux * (0.12 + 0.88 * u) - uy / L * wob, cym + uy * (0.12 + 0.88 * u) + ux / L * wob))
        pts = np.array(pts)
        if cx.S.inside(pts[:, 0], pts[:, 1], 6.0).all() and cx.path_clear(pts[:, 0], pts[:, 1], 3.0).all():
            D.paths.append(dict(kind="dirt", pts=pts, width=2.8))
            cx.paths.append(pts)


def _brindlewick(cx: Ctx, D: Dressing, st):
    seed = cx.seed
    cxm, cym = st["at"][0] * 1000.0, st["at"][1] * 1000.0
    # the main road in: the gate stands where it crosses ~215 m, a cobbled path runs from there to the edge of the Ring 0 field
    rp = _road_pts_near(cx, cxm, cym, 205.0, 225.0)
    if rp:
        rp.sort(key=lambda r: abs(r[0] - 215.0))
        _, gx_, gy_, tx, ty = rp[0]
    else:
        gx_, gy_ = cxm - 150.0, cym + 150.0
        tx, ty = 0.7071, -0.7071
    gate_yaw = math.atan2(tx, -ty)
    D.buildings.append(("town_gate", gx_, gy_, float(cx.h(gx_, gy_)), gate_yaw, 1.1, 0.0))
    ex = float(np.clip(gx_ - cxm, -RING0_CLEAR_M, RING0_CLEAR_M))
    ey = float(np.clip(gy_ - cym, -RING0_CLEAR_M, RING0_CLEAR_M))
    end = np.array([cxm + ex, cym + ey])
    a = np.array([gx_, gy_]) - np.array([tx, ty]) * 9.0
    n = 9
    pts = []
    for i in range(n):
        u = i / (n - 1)
        p = a + (end - a) * u
        wob = math.sin(u * math.pi * 2.0) * 5.0 * (1 - u)
        pts.append((p[0] - ty * wob, p[1] + tx * wob))
    pts = np.array(pts)
    D.paths.append(dict(kind="cobble", pts=pts, width=4.6))
    cx.paths.append(pts)
    _lamps_along(cx, D, pts, gap=13.0, side=3.2)
    # skyline anchor: the clock tower just outside the Ring 0 field, east side
    ctx_, cty_ = cxm + RING0_CLEAR_M + 22.0, cym - 14.0
    D.buildings.append(("clock_tower", ctx_, cty_, float(cx.h(ctx_, cty_)), _face_centre(ctx_, cty_, cxm, cym), 1.15, 0.0))
    D.landmarks.append(("Brindlewick clock tower", ctx_, cty_))
    kinds = ["house_house"] * 4 + ["house_tall"] * 3 + ["house_cottage"] * 2 + ["row_house", "manor"]
    _houses(cx, D, st, kinds, 16, RING0_CLEAR_M * 1.18, st["flat"] + 0.8 * st["skirt"], 21.0, 41, scale_rng=(1.18, 1.42), tangential=True)
    _houses(cx, D, st, ["house_cottage"] * 3 + ["cottage_round"], 7, st["flat"], st["flat"] + st["skirt"] + 40.0, 26.0, 42, scale_rng=(1.0, 1.2))
    near = [b for b in D.buildings if b[0].startswith(("house", "row", "manor", "cottage")) and math.hypot(b[1] - cxm, b[2] - cym) < st["flat"] + st["skirt"] + 60]
    for i, b in enumerate(near):
        r = float(hsh(i, 5, 51, seed))
        bx, by = b[1] - math.sin(b[4]) * 9.0 * b[5], b[2] + math.cos(b[4]) * 9.0 * b[5]      # behind the house
        if not cx.ok_ground(np.array([bx]), np.array([by]), max_slope=0.25)[0]:
            continue
        if r < 0.35:
            D.add_prop("laundry", bx, by, float(cx.h(bx, by)), b[4] + math.pi / 2, 1.0, r)
        elif r < 0.75:
            D.add_prop("barrel" if r < 0.55 else "crate", bx + 2.0, by + 1.5, float(cx.h(bx + 2.0, by + 1.5)), r * 6.0, 1.0, r)
    _flowers(cx, D, st, 14)
    _street_props(cx, D, gx_, gy_, np.array([tx, ty]))


def _street_props(cx: Ctx, D: Dressing, gx_, gy_, tg):
    """The road outside the gate, which the street camera looks along: lanterns, flower boxes, a cart with crates, fences, tufts, stones."""
    seed = cx.seed
    out = -np.array([cx.world.settlement("Brindlewick")["at"][0] * 1000.0 - gx_, cx.world.settlement("Brindlewick")["at"][1] * 1000.0 - gy_])
    out = out / (np.hypot(*out) or 1.0)                      # unit vector away from the town
    side = np.array([-out[1], out[0]])

    def put(kind, x, y, yaw=0.0, sc=1.0, var=0.0, **kw):
        if cx.ok_ground(np.array([x]), np.array([y]), max_slope=0.4, road_max=1.02, margin=4.0)[0]:
            if kind == "lamp_post":
                D.buildings.append(("lamp_post", float(x), float(y), float(cx.h(x, y)), 0.0, 1.0, 0.0))
            else:
                D.add_prop(kind, float(x), float(y), float(cx.h(x, y)), yaw, sc, var)
            return True
        return False
    yaw_r = math.atan2(out[1], out[0])
    for i, u in enumerate(np.arange(10.0, 118.0, 12.0)):          # lanterns on both sides, alternating
        sg = 1 if i % 2 == 0 else -1
        c = np.array([gx_, gy_]) + out * u + side * 12.5 * sg
        put("lamp_post", c[0], c[1])
        if i % 2 == 1:
            c2 = np.array([gx_, gy_]) + out * (u + 3.0) - side * 14.5 * sg
            put("planter", c2[0], c2[1], yaw_r + math.pi / 2 * (1 if sg > 0 else -1), 1.0, float(hsh(i, 1, 211, seed)))
    for sg in (-1, 1):                                          # flower boxes at the gate foot
        c = np.array([gx_, gy_]) + out * 6.0 + side * 9.0 * sg
        put("planter", c[0], c[1], yaw_r + math.pi / 2, 1.0, 0.3 + 0.2 * sg)
    c = np.array([gx_, gy_]) + out * 34.0 + side * 15.0               # a cart parked by the road with crates and barrels
    if put("cart", c[0], c[1], -yaw_r + 0.2, 1.0, 0.0):
        for q, kd in enumerate(("barrel", "crate", "barrel", "crate")):
            c3 = c + out * (3.0 + 1.3 * q) + side * (1.5 + 0.7 * (q % 2))
            put(kd, c3[0], c3[1], q * 1.9, 1.0, float(q) / 4.0)
    for sg in (-1, 1):                                          # post-and-rail fences along both verges
        a0, a1 = 22.0, 52.0
        for u0, u1 in ((a0, a0 + 13.0), (a0 + 17.0, a1 + 20.0), (a1 + 28.0, a1 + 62.0)):
            pa = np.array([gx_, gy_]) + out * u0 + side * 18.5 * sg
            pb = np.array([gx_, gy_]) + out * u1 + side * 18.5 * sg
            if cx.ok_ground(np.array([pa[0], pb[0]]), np.array([pa[1], pb[1]]), max_slope=0.4, road_max=1.02, margin=4.0).all():
                D.fences.append((float(pa[0]), float(pa[1]), float(pb[0]), float(pb[1])))
    for k in range(420):                                        # tufts and flowers over the bare dirt and verges
        a = float(hsh(k, 2, 212, seed)) * 2 * math.pi
        r = 5.0 + 95.0 * float(hsh(k, 3, 213, seed)) ** 0.8
        c = np.array([gx_, gy_]) + out * 55.0 + r * np.array([math.cos(a), math.sin(a)])
        if k % 4 == 0:
            put("flower", c[0], c[1], 0.0, 1.0, float(hsh(k, 4, 214, seed)))
        else:
            put("tuft", c[0], c[1], float(hsh(k, 5, 215, seed)) * 6.28, 0.8 + 1.2 * float(hsh(k, 6, 216, seed)), float(hsh(k, 7, 217, seed)))
    for k in range(14):                                         # stepping stones beside the road
        c = np.array([gx_, gy_]) + out * (14.0 + 7.5 * k) + side * (4.2 if k % 2 else -4.2)
        put("slab", c[0], c[1], k * 0.9, 1.0, 0.0)


def _walled(cx: Ctx, D: Dressing, st):
    """A city: wall ring with towers and a gate, a centre tower, houses inside, a few cottages outside."""
    seed = cx.seed
    cxm, cym = st["at"][0] * 1000.0, st["at"][1] * 1000.0
    R = st["flat"] + 40.0
    N = 18
    rp = _road_pts_near(cx, cxm, cym, R - 25.0, R + 25.0)
    gate_i = None
    if rp:
        rp.sort(key=lambda r: abs(r[0] - R))
        ga = math.atan2(rp[0][2] - cym, rp[0][1] - cxm)
        gate_i = int(round((ga % (2 * math.pi)) / (2 * math.pi) * N)) % N
    verts = []
    for i in range(N):
        a = i / N * 2 * math.pi + 0.07
        verts.append((cxm + R * math.cos(a), cym + R * math.sin(a)))
    for i in range(N):
        x, y = verts[i]
        if S_in(cx, x, y):
            if i == gate_i:
                D.buildings.append(("town_gate", x, y, float(cx.h(x, y)), math.atan2(cxm - x, -(cym - y)), 1.35, 0.0))
            else:
                D.buildings.append(("guard_tower", x, y, float(cx.h(x, y)), 0.0, 1.0, 0.0))
        x2, y2 = verts[(i + 1) % N]
        if gate_i is not None and (i == gate_i or (i + 1) % N == gate_i):
            continue
        if S_in(cx, x, y) and S_in(cx, x2, y2) and not cx.in_ring0(np.array([x]), np.array([y]))[0]:
            D.walls.append((x, y, float(cx.h(x, y)), x2, y2, float(cx.h(x2, y2))))
    mt = (cxm + 22.0, cym - 18.0)
    D.buildings.append(("mage_tower", mt[0], mt[1], float(cx.h(*mt)), 0.4, 1.5, 0.0))
    D.landmarks.append((st["name"] + " tower", mt[0], mt[1]))
    D.buildings.append(("manor", cxm - 36.0, cym + 14.0, float(cx.h(cxm - 36.0, cym + 14.0)), _face_centre(cxm - 36.0, cym + 14.0, cxm, cym), 1.3, 0.2))
    # streets: an avenue from the gate to the centre, four radial lanes and a ring lane, all paved; houses line them, with yards behind
    ga0 = math.atan2(rp[0][2] - cym, rp[0][1] - cxm) if rp else 0.6
    lanes = []
    for k in range(5):
        a = ga0 + k * 2 * math.pi / 5 + (0.0 if k == 0 else 0.22)
        pts = np.array([(cxm + (14.0 + u * (R - 26.0)) * math.cos(a), cym + (14.0 + u * (R - 26.0)) * math.sin(a)) for u in np.linspace(0, 1, 14)])
        lanes.append(pts)
    ring = np.array([(cxm + 0.56 * R * math.cos(t_), cym + 0.56 * R * math.sin(t_)) for t_ in np.linspace(0, 2 * math.pi, 31)])
    lanes.append(ring)
    for k, pts in enumerate(lanes):
        D.paths.append(dict(kind="paved", pts=pts, width=6.5 if k == 0 else 4.6))
        cx.paths.append(pts)
    kinds = _house_kinds("city")
    for k, pts in enumerate(lanes):
        _street_houses(cx, D, st, pts, kinds, 8.8 + 1.5 * (k == 0), 14.5, 600 + k, yards=True)
    _houses(cx, D, st, kinds, 40, 20.0, R - 14.0, 12.5, 61, tangential=True)          # fill: denser core
    _houses(cx, D, st, ["house_cottage", "house_cottage", "cottage_round", "farmhouse"], 7, R + 22.0, R + 110.0, 28.0, 62)
    _flowers(cx, D, st, 12)


def _street_houses(cx: Ctx, D: Dressing, st, pts, kinds, off, gap, salt, yards=False, min_d=11.5):
    """Houses on both sides of a street polyline, doors to the street; optionally a fenced garden behind each."""
    seed = cx.seed
    cxm, cym = st["at"][0] * 1000.0, st["at"][1] * 1000.0
    P = np.asarray(pts, dtype=np.float64)
    seg = np.hypot(*np.diff(P, axis=0).T)
    cum = np.concatenate([[0], np.cumsum(seg)])
    n = 0
    for i, sv in enumerate(np.arange(gap * 0.6, cum[-1] - 4.0, gap)):
        j = min(int(np.searchsorted(cum, sv) - 1), len(seg) - 1)
        tt = (sv - cum[j]) / (seg[j] or 1.0)
        p = P[j] + (P[j + 1] - P[j]) * tt
        d = (P[j + 1] - P[j]) / (seg[j] or 1.0)
        for sg in (-1, 1):
            r = float(hsh(i * 2 + (sg > 0), salt, 201, seed))
            x, y = p[0] - d[1] * off * sg, p[1] + d[0] * off * sg
            if math.hypot(x - cxm, y - cym) < 16.0:
                continue
            if not cx.ok_ground(np.array([x]), np.array([y]), max_slope=0.22, road_max=0.30, margin=10.0)[0]:
                continue
            if any((b[1] - x) ** 2 + (b[2] - y) ** 2 < min_d * min_d for b in D.buildings):
                continue
            kk = kinds[min(int(r * len(kinds)), len(kinds) - 1)]
            yaw = _face_centre(x, y, p[0], p[1])
            sc = 0.95 + 0.25 * float(hsh(i, salt + sg, 202, seed))
            D.buildings.append((kk, float(x), float(y), float(cx.h(x, y)), yaw, sc, float(hsh(i, salt + sg, 203, seed))))
            n += 1
            bx, by = -d[1] * sg, d[0] * sg              # unit vector from the street to the house
            if yards and r < 0.8:
                yx, yy = x + bx * (6.2 * sc + 6.0), y + by * (6.2 * sc + 6.0)
                ext = np.array([yx, yx + d[0] * 5.0, yx - d[0] * 5.0, yx + bx * 4.5])
                eyt = np.array([yy, yy + d[1] * 5.0, yy - d[1] * 5.0, yy + by * 4.5])
                if cx.ok_ground(ext, eyt, max_slope=0.25, road_max=0.2, margin=8.0).all():
                    c0 = np.array([yx - d[0] * 5.0 - bx * 4.5, yy - d[1] * 5.0 - by * 4.5])
                    c1 = np.array([yx + d[0] * 5.0 - bx * 4.5, yy + d[1] * 5.0 - by * 4.5])
                    c2 = np.array([yx + d[0] * 5.0 + bx * 4.5, yy + d[1] * 5.0 + by * 4.5])
                    c3 = np.array([yx - d[0] * 5.0 + bx * 4.5, yy - d[1] * 5.0 + by * 4.5])
                    D.fields.append((yx, yy, float(cx.h(yx, yy)), math.atan2(d[1], d[0]), 7.5, 6.0, 1.0 + 2.0 * (r > 0.4)))
                    for a_, b_ in ((c0, c1), (c1, c2), (c2, c3), (c3, c0)):
                        D.fences.append((float(a_[0]), float(a_[1]), float(b_[0]), float(b_[1])))
            if r > 0.45:
                fx, fy = x - bx * 6.5 * sc + d[0] * 3.2, y - by * 6.5 * sc + d[1] * 3.2        # a flower box by the door, on the street side
                if cx.ok_ground(np.array([fx]), np.array([fy]), max_slope=0.3, road_max=0.5)[0]:
                    D.add_prop("planter", float(fx), float(fy), float(cx.h(fx, fy)), math.atan2(d[1], d[0]), 1.0, r)
    return n


def S_in(cx: Ctx, x, y):
    return bool(cx.S.inside(np.array([x]), np.array([y]), 2.0)[0])


def _farms(cx: Ctx, D: Dressing, st, count):
    seed = cx.seed
    cxm, cym = st["at"][0] * 1000.0, st["at"][1] * 1000.0
    for k in range(count):
        a = hsh(k, 3, 71, seed) * 2 * math.pi
        r = 60.0 + 200.0 * hsh(k, 4, 72, seed)
        _farm_at(cx, D, cxm + r * math.cos(a), cym + r * math.sin(a), float(hsh(k, 5, 73, seed)) * 6.28, k)


def _farm_at(cx: Ctx, D: Dressing, x, y, yaw, k):
    xs = np.array([x, x + 26 * math.cos(yaw), x - 30 * math.sin(yaw)])
    ys = np.array([y, y + 26 * math.sin(yaw), y + 30 * math.cos(yaw)])
    if not cx.ok_ground(xs, ys, max_slope=0.14, road_max=0.2).all():
        return False
    if float(cx.S.at(cx.t.masks["desert"], x, y)) > 0.3 or float(cx.S.at(cx.t.masks["mountain"], x, y)) > 0.5 or float(cx.S.at(cx.t.masks["volcanic"], x, y)) > 0.4:
        return False                                     # no green patchwork fields in dunes, on mountains or on lava ground
    D.buildings.append(("farmhouse", x, y, float(cx.h(x, y)), yaw, 1.0, 0.1))
    D.buildings.append(("barn", float(xs[1]), float(ys[1]), float(cx.h(xs[1], ys[1])), yaw + math.pi / 2, 1.0, 0.3))
    if k % 2 == 0:
        D.buildings.append(("granary_silo", x + 14 * math.cos(yaw + 2.2), y + 14 * math.sin(yaw + 2.2), float(cx.h(x, y)), 0.0, 1.0, 0.0))
    # patchwork fields beside the farm
    for j in range(3):
        fx = x + (52.0 + 46.0 * j) * math.cos(yaw + 1.57) * (1 if j % 2 == 0 else 0.6) - 25 * math.cos(yaw)
        fy = y + (52.0 + 46.0 * j) * math.sin(yaw + 1.57) * (1 if j % 2 == 0 else 0.6) - 25 * math.sin(yaw)
        c = np.array([fx, fy])
        ex = np.array([fx + 20 * math.cos(yaw), fx - 20 * math.cos(yaw), fx + 20 * math.sin(yaw), fx - 20 * math.sin(yaw)])
        ey = np.array([fy + 20 * math.sin(yaw), fy - 20 * math.sin(yaw), fy - 20 * math.cos(yaw), fy + 20 * math.cos(yaw)])
        if cx.ok_ground(np.append(ex, fx), np.append(ey, fy), max_slope=0.12, road_max=0.12).all():
            D.fields.append((fx, fy, float(cx.h(fx, fy)), yaw, 44.0 + 14 * (j % 2), 34.0, float((k * 3 + j) % 4)))
    return True


def _flowers(cx: Ctx, D: Dressing, st, n):
    seed = cx.seed
    cxm, cym = st["at"][0] * 1000.0, st["at"][1] * 1000.0
    idx = np.arange(n * 6)
    key = int(round(cxm / 5.0)) + 3 * int(round(cym / 5.0))
    ang = hsh(idx, key, 81, seed) * 2 * math.pi
    rad = (RING0_CLEAR_M + 10 if st.get("ring0") else 16.0) + 150.0 * hsh(idx, key, 82, seed)
    X, Y = cxm + rad * np.cos(ang), cym + rad * np.sin(ang)
    ok = cx.ok_ground(X, Y, max_slope=0.2, road_max=0.1)
    for k in np.nonzero(ok)[0][:n]:
        D.add_prop("flower", float(X[k]), float(Y[k]), float(cx.h(X[k], Y[k])), 0.0, 1.0, float(hsh(k, key, 83, seed)))


# ----------------------------------------------------------------------------------------------------------------
# Along roads and rivers

def place_outliers(cx: Ctx, D: Dressing):
    """Cottages, farms, mills and shrines beside the roads, away from settlements."""
    seed, t = cx.seed, cx.t
    s = t.spec
    sets = [(st["at"][0] * 1000.0, st["at"][1] * 1000.0, st["flat"] + st["skirt"] + 90.0) for st in cx.world.settlements]
    farms = 0
    for pl in cx.field.road_lines_in(s.bbox_m):
        P = pl.P
        idsalt = sum(ord(c) for c in str(pl.id))
        step = 34
        for i in range(8, len(P) - 8, step):
            r = float(hsh(i, idsalt, 91, seed))
            if r > 0.62:
                continue
            a, b = P[i - 2], P[i + 2]
            tg = (b - a) / (np.hypot(*(b - a)) or 1.0)
            side = 1 if hsh(i, idsalt, 92, seed) < 0.5 else -1
            off = 42.0 + 55.0 * float(hsh(i, idsalt, 93, seed))
            x, y = P[i, 0] - tg[1] * off * side, P[i, 1] + tg[0] * off * side
            if any(math.hypot(x - sx, y - sy) < sr for sx, sy, sr in sets):
                continue
            if not cx.ok_ground(np.array([x]), np.array([y]), max_slope=0.18, margin=40.0)[0]:
                continue
            yaw = _face_centre(x, y, P[i, 0], P[i, 1])
            q = float(hsh(i, idsalt, 94, seed))
            if q < 0.34 and farms < CAPS["farms"]:
                if _farm_at(cx, D, x, y, yaw, farms):
                    farms += 1
            elif q < 0.46 and float(cx.h(x, y)) > 5:
                D.buildings.append(("windmill", x, y, float(cx.h(x, y)), yaw, 1.0, 0.0))
            elif q < 0.58:
                D.buildings.append(("roadside_shrine", P[i, 0] - tg[1] * 6.0 * side, P[i, 1] + tg[0] * 6.0 * side,
                                    float(cx.h(P[i, 0] - tg[1] * 6.0 * side, P[i, 1] + tg[0] * 6.0 * side)), yaw, 1.0, 0.0))
            else:
                D.buildings.append((("house_cottage", "house_house", "cottage_round")[int(q * 7) % 3], x, y, float(cx.h(x, y)), yaw, 1.0 + 0.2 * q, q))
                if q > 0.8:
                    D.add_prop("barrel", x + 6.0, y + 3.0, float(cx.h(x + 6.0, y + 3.0)), 0.0, 1.0, q)
    D.notes["farms"] = farms
    # a water mill on a bigger river
    best = []
    for r in t.rivers:
        for i in range(10, len(r["P"]) - 10, 40):
            if r["hw"][i] > 6.0:
                best.append((float(hsh(i, int(r["flow"]), 95, seed)), r, i))
    best.sort(key=lambda z: z[0])
    placed = 0
    for _, r, i in best:
        if placed >= 2:
            break
        P = r["P"]
        a, b = P[i - 2], P[i + 2]
        tg = (b - a) / (np.hypot(*(b - a)) or 1.0)
        off = r["hw"][i] + 12.0
        x, y = P[i, 0] - tg[1] * off, P[i, 1] + tg[0] * off
        if cx.ok_ground(np.array([x]), np.array([y]), max_slope=0.2, margin=40.0)[0] and not any(math.hypot(x - sx, y - sy) < sr for sx, sy, sr in sets):
            D.buildings.append(("watermill", x, y, float(cx.h(x, y)), _face_centre(x, y, P[i, 0], P[i, 1]), 1.0, 0.0))
            placed += 1


def place_water_dressing(cx: Ctx, D: Dressing):
    """Reeds and rocks along the rivers; deltas where a river reaches the sea."""
    t, S, seed = cx.t, cx.S, cx.seed
    rows_reed, rows_rock = [], []
    for ri, r in enumerate(t.rivers):
        P, hw = r["P"], r["hw"]
        for i in range(2, len(P) - 2, 3):
            a, b = P[i - 2], P[i + 2]
            tg = (b - a) / (np.hypot(*(b - a)) or 1.0)
            for sg in (-1, 1):
                u = float(hsh(i * 2 + (sg > 0), ri + 7, 101, seed))
                if u < 0.42:
                    off = hw[i] + 1.2 + 3.5 * float(hsh(i, ri + sg, 102, seed))
                    rows_reed.append((P[i, 0] - tg[1] * off * sg, P[i, 1] + tg[0] * off * sg, float(hsh(i, ri + sg, 103, seed)), 0.5 + float(hsh(i, ri, 104 + sg, seed))))
                elif u < 0.56:
                    off = hw[i] + 1.5 + 7.0 * float(hsh(i, ri + sg, 105, seed))
                    rows_rock.append((P[i, 0] - tg[1] * off * sg, P[i, 1] + tg[0] * off * sg, float(hsh(i, ri + sg, 106, seed)), 0.5 + 1.4 * float(hsh(i, ri, 107 + sg, seed))))
    for rows, kind, cap in ((rows_reed, "reed", CAPS["reeds"]), (rows_rock, "rock", CAPS["rocks"])):
        if not rows:
            continue
        A = np.array(rows)
        ok = S.inside(A[:, 0], A[:, 1], 2.0) & ~cx.in_ring0(A[:, 0], A[:, 1]) & (S.at(t.h, A[:, 0], A[:, 1]) > 1.0) & (S.at(t.pad_w, A[:, 0], A[:, 1]) < 0.4) & (S.at(t.road_w, A[:, 0], A[:, 1]) < 0.4)
        A = A[ok]
        if len(A) > cap:
            sel = np.argsort(hsh(np.arange(len(A)), len(A), 108, seed))[:cap]
            A = A[np.sort(sel)]
        for x, y, v, sc in A:
            D.add_prop(kind, float(x), float(y), float(cx.h(x, y)), v * 6.28, float(sc), v)
    # river mouths
    for r in t.rivers:
        P = r["P"]
        if len(P) < 4:
            continue
        ex, ey = P[-1]
        if not S.inside(np.array([ex]), np.array([ey]), 60.0)[0]:
            continue
        if float(S.at(t.h, ex, ey)) < 2.5 and float(S.at(cx.near_sea, ex, ey)) > 0.04:
            # the delta fans towards the sea: up the gradient of the smoothed sea mask (not along the last river segment, which can run parallel to the shore)
            j0, i0 = int(round((ey - t.spec.y0_m) / t.spec.res_m)), int(round((ex - t.spec.x0_m) / t.spec.res_m))
            ns = cx.near_sea
            jm, jp = min(max(j0 - 3, 0), t.spec.n - 1), min(max(j0 + 3, 0), t.spec.n - 1)
            im, ip = min(max(i0 - 3, 0), t.spec.n - 1), min(max(i0 + 3, 0), t.spec.n - 1)
            gx_, gy_ = float(ns[j0, ip] - ns[j0, im]), float(ns[jp, i0] - ns[jm, i0])
            d = np.array([gx_, gy_]) if math.hypot(gx_, gy_) > 1e-6 else (P[-1] - P[-4])
            d = d / (np.hypot(*d) or 1.0)
            D.deltas.append(dict(x=float(ex), y=float(ey), dx=float(d[0]), dy=float(d[1]), hw=float(r["hw"][-1]), name=r["name"]))


def place_rocks(cx: Ctx, D: Dressing):
    """Boulders on mountain slopes, shore rocks on beaches, buttes in the desert, a lighthouse on a headland."""
    t, S, seed = cx.t, cx.S, cx.seed
    s = t.spec
    C = 110.0
    gx, gy = np.meshgrid(np.arange(int(s.x0_m // C), int((s.x0_m + s.size_m) // C) + 1), np.arange(int(s.y0_m // C), int((s.y0_m + s.size_m) // C) + 1))
    gx, gy = gx.ravel(), gy.ravel()
    X = (gx + 0.1 + 0.8 * hsh(gx, gy, 111, seed)) * C
    Y = (gy + 0.1 + 0.8 * hsh(gx, gy, 112, seed)) * C
    inb = S.inside(X, Y, 8.0)
    X, Y, gx, gy = X[inb], Y[inb], gx[inb], gy[inb]
    mt = S.at(t.masks["mountain"], X, Y)
    sl = S.at(t.slope, X, Y)
    beach = S.at(t.masks["beach"], X, Y)
    h = S.at(t.h, X, Y)
    p = np.where(mt > 0.35, 0.08 * smoothstep(0.25, 0.6, sl), 0.0) + np.where((beach > 0.4) & (h < 8.0) & (h > 1.0), 0.18, 0.0) \
        + 0.004 * S.at(t.masks["plains"], X, Y) + 0.03 * S.at(t.masks["volcanic"], X, Y)
    ok = (hsh(gx, gy, 113, seed) < p) & (h > 1.0) & (S.at(t.road_w, X, Y) < 0.05) & (S.at(t.pad_w, X, Y) < 0.05) & ~cx.in_ring0(X, Y) \
        & (S.at(t.lake_m, X, Y) < 0.1) & (S.at(cx.river_near.astype(np.float64), X, Y) < 0.01)
    idx = np.nonzero(ok)[0]
    if len(idx) > CAPS["boulders"]:
        idx = np.sort(idx[np.argsort(hsh(gx[idx], gy[idx], 114, seed))[:CAPS["boulders"]]])
    for k in idx:
        big = mt[k] > 0.35
        sc = (2.5 + 5.5 * float(hsh(gx[k], gy[k], 115, seed)) ** 2) if big else (0.9 + 1.2 * float(hsh(gx[k], gy[k], 115, seed)))
        D.add_prop("boulder" if big else "rock", float(X[k]), float(Y[k]), float(h[k]), float(hsh(gx[k], gy[k], 116, seed)) * 6.28, sc, float(hsh(gx[k], gy[k], 117, seed)))
    # desert: a rock or two (sandstone buttes) on the flat, in 3 km cells
    des = S.at(t.masks["desert"], np.array([s.x0_m + s.size_m / 2.0]), np.array([s.y0_m + s.size_m / 2.0]))[0]
    if t.masks["desert"].mean() > 0.3:
        C2 = 2500.0
        cells = [(i, j) for i in range(int(s.x0_m // C2), int((s.x0_m + s.size_m) // C2) + 1) for j in range(int(s.y0_m // C2), int((s.y0_m + s.size_m) // C2) + 1)]
        got = 0
        for i, j in sorted(cells, key=lambda c: float(hsh(c[0], c[1], 118, seed))):
            x = (i + 0.2 + 0.6 * float(hsh(i, j, 119, seed))) * C2
            y = (j + 0.2 + 0.6 * float(hsh(i, j, 120, seed))) * C2
            if cx.ok_ground(np.array([x]), np.array([y]), max_slope=0.2, margin=200.0)[0] and S.at(t.masks["desert"], x, y) > 0.8:
                D.add_prop("butte", x, y, float(cx.h(x, y)) - 0.5, float(hsh(i, j, 121, seed)) * 6.28, 1.0 + 0.4 * float(hsh(i, j, 122, seed)), float(hsh(i, j, 123, seed)))
                got += 1
            if got >= 3:
                break
        for k in range(14):                                   # a few loose rocks on the sand
            x = s.x0_m + 400.0 + (s.size_m - 800.0) * float(hsh(k, 1, 124, seed))
            y = s.y0_m + 400.0 + (s.size_m - 800.0) * float(hsh(k, 2, 125, seed))
            if cx.ok_ground(np.array([x]), np.array([y]), max_slope=0.25)[0]:
                D.add_prop("rock", x, y, float(cx.h(x, y)), k * 1.7, 1.0 + 1.5 * float(hsh(k, 3, 126, seed)), float(hsh(k, 4, 127, seed)))
    # desert: a caravan camp beside a road (the district accent, turquoise canvas on adobe sand)
    if t.masks["desert"].mean() > 0.3:
        _caravan(cx, D)
    # coast: lighthouse on the highest headland near the sea
    if (t.h < 0).mean() > 0.03:
        score = np.where((cx.near_sea > 0.10) & (t.h > 6.0) & (t.h < 140.0) & (t.slope < 0.35) & (t.pad_w < 0.01) & (t.road_w < 0.02) & ~cx.river_near, t.h + 20.0 * cx.near_sea, -1e9)
        # keep clear of the tile border
        score[:12, :] = -1e9
        score[-12:, :] = -1e9
        score[:, :12] = -1e9
        score[:, -12:] = -1e9
        j, i = np.unravel_index(int(np.argmax(score)), score.shape)
        if score[j, i] > -1e8:
            x, y = s.x0_m + i * s.res_m, s.y0_m + j * s.res_m
            sea_dir = np.array([0.0, 0.0])
            # face the sea: towards the lowest nearby sample
            win = t.h[max(0, j - 14):j + 15, max(0, i - 14):i + 15]
            jj, ii = np.unravel_index(int(np.argmin(win)), win.shape)
            sea_dir = np.array([ii + max(0, i - 14) - i, jj + max(0, j - 14) - j], dtype=float)
            D.add_prop("lighthouse", float(x), float(y), float(t.h[j, i]), math.atan2(sea_dir[1], sea_dir[0]), 1.0, 0.0)
            D.landmarks.append(("coast lighthouse", float(x), float(y)))
            kx, ky = x - 34.0, y + 22.0
            if cx.ok_ground(np.array([kx]), np.array([ky]), max_slope=0.3)[0]:
                D.buildings.append(("house_cottage", kx, ky, float(cx.h(kx, ky)), _face_centre(kx, ky, x, y), 1.0, 0.4))
            _coast_path(cx, D, x, y, kx, ky, math.atan2(sea_dir[1], sea_dir[0]))
        # shore rocks
        for k in range(40):
            x = s.x0_m + s.size_m * float(hsh(k, 7, 128, seed))
            y = s.y0_m + s.size_m * float(hsh(k, 8, 129, seed))
            hh = float(S.at(t.h, x, y))
            if 0.5 < hh < 4.0 and float(S.at(cx.near_sea, x, y)) > 0.12 and cx.ok_ground(np.array([x]), np.array([y]), max_slope=0.4)[0]:
                D.add_prop("rock", x, y, hh, k * 2.3, 0.8 + 1.6 * float(hsh(k, 9, 130, seed)), float(hsh(k, 10, 131, seed)))


def _caravan(cx: Ctx, D: Dressing):
    """Three wagons, two tents and a fire ring on flat sand near a road. Landmark 'Sunscar caravan'."""
    t, S, seed = cx.t, cx.S, cx.seed
    s = t.spec
    cand = []
    for pl in cx.field.road_lines_in(s.bbox_m):
        P = pl.P
        for f in (0.35, 0.5, 0.65, 0.25, 0.75):
            i = int(len(P) * f)
            if 3 < i < len(P) - 3:
                a, b = P[i - 3], P[i + 3]
                tg = (b - a) / (np.hypot(*(b - a)) or 1.0)
                for off in (70.0, -70.0, 110.0, -110.0):
                    cand.append((P[i, 0] - tg[1] * off, P[i, 1] + tg[0] * off, tg))
    cand.append((s.x0_m + 0.42 * s.size_m, s.y0_m + 0.5 * s.size_m, np.array([1.0, 0.0])))
    for x, y, tg in cand:
        pts_x = np.array([x, x + 30, x - 30, x, x])
        pts_y = np.array([y, y, y, y + 30, y - 30])
        if not cx.ok_ground(pts_x, pts_y, max_slope=0.16, road_max=0.2, margin=200.0).all():
            continue
        yaw = math.atan2(tg[1], tg[0])
        for k in range(3):
            a = yaw + (k - 1) * 0.95
            wx, wy = x + 16.0 * math.cos(a + math.pi / 2), y + 16.0 * math.sin(a + math.pi / 2)
            D.add_prop("wagon", wx, wy, float(cx.h(wx, wy)), -(a), 1.0, 0.0)
        for k in range(2):
            tx_, ty_ = x - 14.0 + 28.0 * k, y - 15.0
            D.add_prop("tent", tx_, ty_, float(cx.h(tx_, ty_)), -(yaw + 1.2 * k), 1.0, 0.0)
        for q in range(5):
            bx, by = x + 3.0 * math.cos(q * 1.26), y + 3.0 * math.sin(q * 1.26)
            D.add_prop("rock", bx, by, float(cx.h(bx, by)), q * 1.3, 0.5, 0.2 * q)
        D.landmarks.append(("Sunscar caravan", float(x), float(y)))
        return


def _coast_path(cx: Ctx, D: Dressing, lx, ly, kx, ky, ang):
    """A gravel path from the keeper's cottage and one from the landward side up to the lighthouse, with stepping stones and edge rocks:
    the detail picture's foreground (the camera stands landward of the tower, see build_world_terrain)."""
    seed = cx.seed
    ox, oy = -math.cos(ang) + 0.55, -math.sin(ang) - 0.35
    n_ = math.hypot(ox, oy)
    ox, oy = ox / n_, oy / n_
    pts = []
    for i in range(12):
        u = i / 11.0
        d = 8.0 + 175.0 * u
        wob = 9.0 * math.sin(u * 5.0) * u
        pts.append((lx + ox * d - oy * wob, ly + oy * d + ox * wob))
    pts = np.array(pts)[::-1]
    if cx.S.inside(pts[:, 0], pts[:, 1], 6.0).all() and (cx.S.at(cx.t.h, pts[:, 0], pts[:, 1]) > 1.0).all():
        D.paths.append(dict(kind="gravel", pts=pts, width=3.6))
        cx.paths.append(pts)
        for k in range(1, 11):
            for sg in (-1, 1):
                px, py = pts[k]
                tgx, tgy = pts[k][0] - pts[k - 1][0], pts[k][1] - pts[k - 1][1]
                L = math.hypot(tgx, tgy) or 1.0
                rx, ry = px - tgy / L * 3.4 * sg + (float(hsh(k, sg, 221, seed)) - 0.5) * 3.0, py + tgx / L * 3.4 * sg
                if cx.ok_ground(np.array([rx]), np.array([ry]), max_slope=0.5, road_max=1.0, margin=4.0)[0] and float(hsh(k, sg + 3, 222, seed)) < 0.7:
                    D.add_prop("rock", float(rx), float(ry), float(cx.h(rx, ry)), k * 1.1, 0.6 + 0.8 * float(hsh(k, sg, 223, seed)), float(hsh(k, sg, 224, seed)))
    c = np.array([[kx, ky], [lx - 8.0 * math.cos(ang), ly - 8.0 * math.sin(ang)]])
    cp = np.array([(kx + (c[1][0] - kx) * u, ky + (c[1][1] - ky) * u) for u in np.linspace(0, 1, 6)])
    if cx.S.inside(cp[:, 0], cp[:, 1], 6.0).all():
        D.paths.append(dict(kind="gravel", pts=cp, width=2.6))
        cx.paths.append(cp)
    for k in range(60):                                          # tufts of grass and flowers on the foreground
        a = float(hsh(k, 9, 225, seed)) * 6.28
        r = 12.0 + 120.0 * float(hsh(k, 10, 226, seed))
        x = lx + ox * (40.0 + 70.0 * float(hsh(k, 11, 227, seed))) + r * math.cos(a) * 0.5
        y = ly + oy * (40.0 + 70.0 * float(hsh(k, 11, 227, seed))) + r * math.sin(a) * 0.5
        if cx.ok_ground(np.array([x]), np.array([y]), max_slope=0.3, road_max=0.3, margin=6.0)[0] and float(cx.h(x, y)) > 1.5:
            D.add_prop("tuft" if k % 3 else "flower", float(x), float(y), float(cx.h(x, y)), a, 1.0 + 0.8 * float(hsh(k, 12, 228, seed)), float(hsh(k, 13, 229, seed)))


def place_grass(cx: Ctx, D: Dressing, focus, radius=110.0, step=1.2):
    """Grass clumps (cards) close in; only for close-up tiles. Skips Ring 0, roads, paths, dirt patches and water."""
    seed, S, t = cx.seed, cx.S, cx.t
    fx, fy = focus
    g = np.arange(-radius, radius + 1e-6, step)
    gx, gy = np.meshgrid(g, g)
    gx, gy = gx.ravel(), gy.ravel()
    ii, jj = np.round((fx + gx) / step).astype(np.int64), np.round((fy + gy) / step).astype(np.int64)
    X = (ii + 0.5 * (hsh(ii, jj, 141, seed) - 0.5) * 2) * step
    Y = (jj + 0.5 * (hsh(ii, jj, 142, seed) - 0.5) * 2) * step
    inr = (np.hypot(X - fx, Y - fy) < radius)
    ok = inr & cx.ok_ground(X, Y, max_slope=0.5, road_max=0.75, margin=3.0)
    ok &= S.at(t.pad_w, X, Y) < 0.9
    sh, dirt = _tone(X, Y)
    dens = np.clip(1.0 - dirt * 0.5, 0.55, 1) * (0.9 + 0.1 * (1 - sh)) * (1.0 - 0.55 * S.at(t.road_w, X, Y))
    ok &= hsh(ii, jj, 143, seed) < dens * (0.55 + 0.45 * (1.0 - np.hypot(X - fx, Y - fy) / radius))
    idx = np.nonzero(ok)[0]
    if len(idx) > CAPS["grass"]:
        idx = np.sort(idx[np.argsort(hsh(ii[idx], jj[idx], 144, seed))[:CAPS["grass"]]])
    z = S.at(t.h, X[idx], Y[idx])
    D.grass = np.stack([X[idx], Y[idx], z, hsh(ii[idx], jj[idx], 145, seed)], 1)


def _tone(X, Y):
    from .tile import tone_fields
    return tone_fields(X, Y)


# ----------------------------------------------------------------------------------------------------------------

def place(world, field, t, seed=1, grass_focus=None):
    """The whole dressing of one built tile (needs t.masks, so build the tile with its surface)."""
    cx = Ctx(world, field, t, seed)
    D = Dressing(t.spec)
    place_settlements(cx, D)            # first: paths and houses claim ground before the scatter
    place_outliers(cx, D)
    place_water_dressing(cx, D)
    place_rocks(cx, D)
    place_trees(cx, D)
    if t.spec.size_m <= 3000:
        if grass_focus is None and D.paths:
            pp = D.paths[0]["pts"]
            dv = pp[0] - pp[-1]
            dv = dv / (np.hypot(*dv) or 1.0)
            D.notes["streetCamera"] = [float(pp[0][0] + dv[0] * 62.0), float(pp[0][1] + dv[1] * 62.0)]
            grass_focus = (float(pp[0][0] + dv[0] * 25.0), float(pp[0][1] + dv[1] * 25.0))
        if grass_focus is None:
            st = world.settlement("Brindlewick")
            grass_focus = (st["at"][0] * 1000.0 + 150.0, st["at"][1] * 1000.0 + 120.0) if st else (t.spec.x0_m + t.spec.size_m / 2, t.spec.y0_m + t.spec.size_m / 2)
        place_grass(cx, D, grass_focus)
    for k in ("reed", "rock", "boulder", "flower"):
        D.notes.setdefault("capped", {})[k] = len(D.props.get(k, []))
    # district palette (art_direction 2.2: one accent per district): every house within 3 km of Aldmere takes the Aldmere palette (variant >= 10)
    for cname, rad in PALETTE_CITIES.items():
        st = world.settlement(cname)
        if st:
            qx, qy = st["at"][0] * 1000.0, st["at"][1] * 1000.0
            D.buildings = [((b[0], b[1], b[2], b[3], b[4], b[5], (b[6] % 1.0) + 10.0) if (b[0] != "lamp_post" and math.hypot(b[1] - qx, b[2] - qy) < rad) else b) for b in D.buildings]
    # the hard rule, checked here as well as in checks.py: nothing inside a Ring 0 field
    for (cx_, cy_) in cx.ring0:
        pts = []
        pts += [(b[1], b[2]) for b in D.buildings]
        pts += [(p[0], p[1]) for v in D.props.values() for p in v]
        pts += [(a[0], a[1]) for a in D.trees] + [(a[0], a[1]) for a in D.grass]
        pts += [(f[0], f[1]) for f in D.fields] + [(f[0], f[1]) for f in D.fences] + [(f[2], f[3]) for f in D.fences]
        for x, y in pts:
            assert not (abs(x - cx_) < RING0_SIZE_M / 2 + 4.0 and abs(y - cy_) < RING0_SIZE_M / 2 + 4.0), "dressing inside Ring 0"
    return D


def ring0_violations(D: Dressing, world):
    """Count dressing items inside the 200 m Ring 0 fields (must be 0). Fields (patch rectangles) count by centre."""
    n = 0
    for st in world.settlements:
        if not st.get("ring0"):
            continue
        cx_, cy_ = st["at"][0] * 1000.0, st["at"][1] * 1000.0
        half = RING0_SIZE_M / 2
        pts = [(b[1], b[2]) for b in D.buildings] + [(p[0], p[1]) for v in D.props.values() for p in v] + [(a[0], a[1]) for a in D.trees] \
            + [(a[0], a[1]) for a in D.grass] + [(f[0], f[1]) for f in D.fields] + [(w[0], w[1]) for w in D.walls] + [(f[0], f[1]) for f in D.fences] + [(f[2], f[3]) for f in D.fences]
        n += sum(1 for x, y in pts if abs(x - cx_) < half and abs(y - cy_) < half)
        for pth in D.paths:
            n += int(sum(1 for x, y in pth["pts"] if abs(x - cx_) < half and abs(y - cy_) < half))
    return n
