"""The world height field: a pure function of world position (metres), so tiles of any size or resolution that share a
point agree on its height exactly.

Stages, in order (each only depends on the ones before it):
  base    bicubic (Catmull-Rom) upsampling of the 0.5 km grid, flat beaches, gentle sea shelf
  detail  deterministic noise: ridges + gullies in ranges, soft hills in lowlands, dunes in deserts
  peaks   gaussian corrections so named summits sit on their listed height
  pads    flattened settlement pads (Brindlewick's keeps a flat 200 m Ring 0 square)
  roads   graded road beds: slope-limited profile, terrain blended to it
  lakes   flat lake surfaces with basins
  rivers  carved channels with a monotone water level, bridged where a road crosses
Coordinates: X, Y are world metres (x east, y south), float arrays of equal shape.
"""
import copy
import hashlib
import inspect
import math
import os
import time

import numpy as np

from . import noise
from . import erosion as ERO
from .noise import smoothstep
from .world import World, chaikin

ROAD_MAX_GRADE = 0.15          # the contract
ROAD_TARGET_GRADE = 0.115      # what the profile limiter aims for (margin for blending)
ROAD_CORE_M = 10.0             # road bed half-width at full weight
ROAD_SHOULDER_M = 32.0
PEAK_SIGMA_M = 900.0            # only a small final correction now: the summits come from the raised crest networks
PEAK_NO_DETAIL_M = 260.0
CREST_SIGMA_M = 1250.0
REL_AMP = 280.0
ROAD_REROUTE_CUTFILL_M = 30.0   # beyond this the authored road is re-routed (switchbacks)
ROAD_MAX_CUTFILL_M = 150.0
ROUTE_SMOOTH_PASSES = 0
SPACING = 20.0                 # resample spacing of road and river polylines


def lerp(a, b, t):
    return a + (b - a) * t


def _pav_nonincreasing(y):
    """Isotonic (non-increasing) regression by pooling adjacent violators: the closest monotone profile to y."""
    vals, cnt = [], []
    for v in np.asarray(y, dtype=np.float64):
        vals.append(float(v))
        cnt.append(1)
        while len(vals) > 1 and vals[-2] < vals[-1]:
            v2, c2 = vals.pop(), cnt.pop()
            vals[-1] = (vals[-1] * cnt[-1] + v2 * c2) / (cnt[-1] + c2)
            cnt[-1] += c2
    return np.repeat(vals, cnt)


class PolyLine:
    """A polyline (metres) resampled to ~SPACING with per-vertex values; nearest-point queries on arbitrary points."""

    def __init__(self, pts_m, vals=None, spacing=SPACING):
        d = np.hypot(*np.diff(pts_m, axis=0).T)
        s = np.concatenate([[0.0], np.cumsum(d)])
        n = max(2, int(round(s[-1] / spacing)) + 1)
        self.s = np.linspace(0.0, s[-1], n)
        self.P = np.stack([np.interp(self.s, s, pts_m[:, 0]), np.interp(self.s, s, pts_m[:, 1])], 1)
        self.length = float(s[-1])
        self.bbox = (self.P[:, 0].min(), self.P[:, 1].min(), self.P[:, 0].max(), self.P[:, 1].max())
        self.vals = None

    def set_vals(self, vals):
        self.vals = np.asarray(vals, dtype=np.float64).reshape(len(self.P), -1)

    def intersects(self, bb, reach):
        return not (self.bbox[2] + reach < bb[0] or self.bbox[0] - reach > bb[2] or self.bbox[3] + reach < bb[1] or self.bbox[1] - reach > bb[3])

    def query(self, X, Y, reach):
        """-> (dist (N,), vals (N,k)); dist is inf for points farther than `reach`."""
        N = len(X)
        k = self.vals.shape[1]
        dmin = np.full(N, np.inf)
        out = np.zeros((N, k))
        inb = (X >= self.bbox[0] - reach) & (X <= self.bbox[2] + reach) & (Y >= self.bbox[1] - reach) & (Y <= self.bbox[3] + reach)
        idx = np.nonzero(inb)[0]
        if len(idx) == 0:
            return dmin, out
        Xs, Ys = X[idx], Y[idx]
        B = 256.0
        bx = np.floor(Xs / B).astype(np.int64)
        by = np.floor(Ys / B).astype(np.int64)
        bx0, by0 = bx.min(), by.min()
        ny = int(by.max() - by0 + 1)
        key = (bx - bx0) * ny + (by - by0)
        order = np.argsort(key, kind="stable")
        ks = key[order]
        uk, start = np.unique(ks, return_index=True)
        end = np.append(start[1:], len(ks))
        lut = {int(a): (int(s), int(e)) for a, s, e in zip(uk, start, end)}
        A, Bp = self.P[:-1], self.P[1:]
        lo = np.minimum(A, Bp) - reach
        hi = np.maximum(A, Bp) + reach
        keep = np.nonzero((hi[:, 0] >= Xs.min()) & (lo[:, 0] <= Xs.max()) & (hi[:, 1] >= Ys.min()) & (lo[:, 1] <= Ys.max()))[0]
        dsub = np.full(len(idx), np.inf)
        osub = np.zeros((len(idx), k))
        for i in keep:
            a, b = A[i], Bp[i]
            ix0 = int(math.floor(lo[i, 0] / B)) - int(bx0)
            ix1 = int(math.floor(hi[i, 0] / B)) - int(bx0)
            iy0 = int(math.floor(lo[i, 1] / B)) - int(by0)
            iy1 = int(math.floor(hi[i, 1] / B)) - int(by0)
            parts = []
            for gx in range(max(ix0, 0), ix1 + 1):
                for gy in range(max(iy0, 0), min(iy1, ny - 1) + 1):
                    r = lut.get(gx * ny + gy)
                    if r is not None:
                        parts.append(order[r[0]:r[1]])
            if not parts:
                continue
            c = parts[0] if len(parts) == 1 else np.concatenate(parts)
            ab = b - a
            L2 = float(ab @ ab)
            px, py = Xs[c] - a[0], Ys[c] - a[1]
            t = np.clip((px * ab[0] + py * ab[1]) / L2, 0.0, 1.0) if L2 > 0 else np.zeros(len(c))
            d = np.hypot(px - t * ab[0], py - t * ab[1])
            better = d < dsub[c]
            if better.any():
                cc, tt = c[better], t[better]
                dsub[cc] = d[better]
                osub[cc] = self.vals[i] + (self.vals[i + 1] - self.vals[i]) * tt[:, None]
        ok = dsub <= reach
        dmin[idx[ok]] = dsub[ok]
        out[idx[ok]] = osub[ok]
        return dmin, out


class Masks:
    """Lazy bilinear sampling of the soft biome masks at the sample positions."""

    def __init__(self, world, fx, fy):
        self.w = world
        self.x0 = np.floor(fx).astype(np.int64)
        self.y0 = np.floor(fy).astype(np.int64)
        self.tx = fx - self.x0
        self.ty = fy - self.y0
        W, H = world.W, world.H
        self.xa, self.xb = np.clip(self.x0, 0, W - 1), np.clip(self.x0 + 1, 0, W - 1)
        self.ya, self.yb = np.clip(self.y0, 0, H - 1), np.clip(self.y0 + 1, 0, H - 1)
        self.cache = {}

    def grid(self, G):
        a = G[self.ya, self.xa]
        b = G[self.ya, self.xb]
        c = G[self.yb, self.xa]
        d = G[self.yb, self.xb]
        top = a + (b - a) * self.tx
        bot = c + (d - c) * self.tx
        return top + (bot - top) * self.ty

    def __getitem__(self, name):
        if name not in self.cache:
            self.cache[name] = self.grid(self.w.masks[self.w.mask_index[name]])
        return self.cache[name]


def catmull(G, fx, fy):
    W, H = G.shape[1], G.shape[0]
    x0 = np.floor(fx).astype(np.int64)
    y0 = np.floor(fy).astype(np.int64)
    tx, ty = fx - x0, fy - y0

    def wts(t):
        t2, t3 = t * t, t * t * t
        return (-0.5 * t3 + t2 - 0.5 * t, 1.5 * t3 - 2.5 * t2 + 1.0, -1.5 * t3 + 2.0 * t2 + 0.5 * t, 0.5 * t3 - 0.5 * t2)

    wx, wy = wts(tx), wts(ty)
    out = np.zeros_like(fx)
    for j in range(4):
        yy = np.clip(y0 + j - 1, 0, H - 1)
        row = 0.0
        for i in range(4):
            xx = np.clip(x0 + i - 1, 0, W - 1)
            row = row + wx[i] * G[yy, xx]
        out += wy[j] * row
    return out


class Eval:
    """Result of evaluating the field at a set of points."""
    __slots__ = ("h", "pad_w", "road_w", "lake_m", "lake_s", "river_w", "masks", "slope_h", "wv")


class HeightField:
    RELAX = 1.0          # strength of the mountain relief relaxation (talus feet, rounded lips)
    HILLS = 1.0          # strength of the rolling hills
    def __init__(self, world: World, seed=1, roads=True, rivers=True, pads=True, lakes=True):
        self.w = world
        self.seed = int(seed)
        self.use = dict(roads=roads, rivers=rivers, pads=pads, lakes=lakes)
        self.peak_delta = []
        self._pad_h = {}
        self._roads = None
        self._rivers = None
        self.road_stats = {}
        self._eros = None
        self._ridge_a = None
        self._crests = None
        self._init_peaks()
        self._init_pads()

    # -- helpers ------------------------------------------------------------------------------------------------
    def _fxy(self, X, Y):
        ck = self.w.ck * 1000.0
        return X / ck - 0.5, Y / ck - 0.5

    @staticmethod
    def _bbox(X, Y):
        return float(X.min()), float(Y.min()), float(X.max()), float(Y.max())

    # -- stages -------------------------------------------------------------------------------------------------
    def stage_base(self, X, Y, M):
        fx, fy = self._fxy(X, Y)
        h0 = catmull(self.w.elev, fx, fy)
        beachw = smoothstep(0.15, 0.6, M["beach"])
        flat = 0.05 * np.clip(h0, 0, 60) + 0.4 * smoothstep(0, 3, h0)
        land = np.where(h0 > 0, lerp(h0, flat, beachw), h0)
        d = -h0
        shelf = d * (0.25 + 0.75 * smoothstep(0, 150, d))
        return np.where(h0 < 0, -shelf, land)

    def stage_detail(self, X, Y, h, M):
        """Everything here is a per-point function of world position (no tile-wide branches: those broke tile joins)."""
        s = self.seed
        mt = np.clip(np.maximum.reduce([M["mountain"], M["volcanic"] * 0.8, smoothstep(600, 1500, h) * 0.9]), 0, 1)
        out = np.zeros_like(h)
        # mountains: the eroded global relief (crest networks, valleys, spurs) plus slope-aware 20 m detail
        dl, slp = self._eros_sample(X, Y)
        out += dl
        im = np.nonzero(mt > 1e-4)[0]
        if len(im):
            Xm, Ym = X[im], Y[im]
            det = noise.fbm(Xm, Ym, 240.0, 4, s + 60, ridged=True)
            gul = noise.fbm(Xm, Ym, 120.0, 3, s + 61, ridged=True)
            rug = smoothstep(0.10, 0.5, slp[im])                              # rugged on steep ground, smooth on talus and floors
            out[im] += mt[im] * rug * (16.0 * (det - 0.33) - 8.0 * gul ** 5)
        beach = smoothstep(0.15, 0.6, M["beach"])
        deser = smoothstep(0.35, 0.8, M["desert"])
        low = (1.0 - mt) * (1.0 - beach) * (1.0 - deser)
        amp = 2.5 + 2.0 * (M["forest"] + M["jungle"]) - 1.5 * M["swamp"]
        out += low * (amp * noise.fbm(X, Y, 380.0, 4, s + 3) + 0.7 * noise.value(X, Y, 45.0, s + 4))
        # rolling hills, low ridges and shallow dry valleys (domain warped; small on floodplains and beaches, larger in uplands)
        hl = (1.0 - smoothstep(0.05, 0.5, mt)) * (1.0 - smoothstep(700.0, 1400.0, h)) * (1.0 - beach) * (1.0 - deser) * (1.0 - 0.75 * M["swamp"]) * smoothstep(2.0, 14.0, h)
        wv, trough = self._valley(X, Y)
        il = np.nonzero(hl > 1e-4)[0]
        if len(il):
            Xl, Yl = X[il], Y[il]
            upl = smoothstep(25.0, 380.0, h[il])
            wx = 420.0 * noise.fbm(Xl, Yl, 3000.0, 2, s + 20)
            wy = 420.0 * noise.fbm(Xl + 7000.0, Yl - 3000.0, 3000.0, 2, s + 21)
            roll = noise.fbm(Xl + wx, Yl + wy, 2600.0, 4, s + 22)
            rid = noise.fbm(Xl + wx, Yl + wy, 3600.0, 3, s + 23, ridged=True)
            grv = noise.fbm(Xl + 0.7 * wx, Yl + 0.7 * wy, 1500.0, 3, s + 24, ridged=True)
            hills = (5.0 + 24.0 * upl) * 1.5 * roll + (4.0 + 12.0 * upl) * (rid - 0.35) - (3.0 + 9.0 * upl) * grv ** 5
            out[il] += self.HILLS * hl[il] * hills * (1.0 - wv[il])
        out += -trough * (1.0 - 0.6 * mt)
        out = np.where(h + out < 1.4, np.maximum(out, np.minimum(0.0, 1.4 - h) * smoothstep(1.0, 3.0, h)), out)
        deser_on = np.nonzero(deser > 1e-4)[0]
        if len(deser_on):
            Xs0, Ys0, X, Y = X, Y, X[deser_on], Y[deser_on]
            res_d = self._desert(X, Y, deser[deser_on])
            out[deser_on] += res_d
            X, Y = Xs0, Ys0
        out *= smoothstep(1.0, 6.0, h)
        if self.w.peaks:
            out *= 1.0 - self._peak_gauss(X, Y, PEAK_NO_DETAIL_M, 2.0)
        return out

    def _desert(self, X, Y, deser):
        s = self.seed
        out = np.zeros_like(X)
        if True:
            th = math.radians(35.0)
            c35, s35 = math.cos(th), math.sin(th)
            u = X * c35 + Y * s35
            warp = 0.35 * noise.fbm(X, Y, 500.0, 3, s + 5)
            # wind ripples: long and low (260 m, 3.5 m), not the busy 140 m corduroy of the first build
            ph = 2 * math.pi * (u / 260.0 + warp)
            prof = np.sin(ph) + 0.2 * np.sin(2 * ph + 0.6)
            modul = 0.55 + 0.45 * noise.fbm(X, Y, 1300.0, 3, s + 6)
            ph2 = 2 * math.pi * ((X * math.cos(th + 0.5) + Y * math.sin(th + 0.5)) / 650.0 + 0.2 * warp)
            out += deser * (3.5 * modul * prof + 9.0 * np.sin(ph2) * (0.5 + 0.5 * noise.fbm(X, Y, 2500.0, 2, s + 7)))
            # a few large dunes with a slip face: a long gentle windward ramp, a steep lee side, 1,400 m apart, only in patches
            u3 = u / 1400.0 + 0.30 * noise.fbm(X, Y, 1700.0, 3, s + 10) + 0.08 * warp
            fr = u3 - np.floor(u3)
            ramp = np.where(fr < 0.94, (fr / 0.94) ** 1.6, 1.0 - smoothstep(0.94, 1.0, fr))
            few = smoothstep(0.10, 0.50, noise.fbm(X, Y, 3400.0, 2, s + 8) + 0.06)
            out += deser * few * 52.0 * ramp * (0.65 + 0.35 * noise.fbm(X, Y, 1100.0, 2, s + 9))
        return out

    def _relax(self, X, Y):
        """Thermal-erosion-like relaxation of the authored base relief: the mean of the base height on two rings minus the
        base height. Positive at concave feet (talus fills them), negative on convex lips (rounded). Capped at +-110 m."""
        fx, fy = self._fxy(X, Y)
        h0 = catmull(self.w.elev, fx, fy)
        acc = np.zeros_like(h0)
        n = 0
        for r in (1.3, 2.8):
            for dx, dy in ((1, 0), (-1, 0), (0, 1), (0, -1), (0.7071, 0.7071), (-0.7071, 0.7071), (0.7071, -0.7071), (-0.7071, -0.7071)):
                acc += catmull(self.w.elev, fx + dx * r, fy + dy * r)
                n += 1
        return np.clip(0.5 * (acc / n - h0), -110.0, 110.0)

    # -- river valleys ------------------------------------------------------------------------------------------
    def _river_base(self):
        """Every river as a PolyLine with meanders (a pure function of the data and the seed: shared by all tiles) and per-point
        stream order, discharge and valley half-width. Confluence stations are kept straight so tributaries meet their river."""
        if getattr(self, "_rb", None) is not None:
            return self._rb
        out = {}
        raw = {}
        for r in self.w.rivers:
            pl = PolyLine(r["pts"] * 1000.0)
            sr = np.concatenate([[0.0], np.cumsum(np.hypot(*np.diff(r["pts"] * 1000.0, axis=0).T))])
            if r["ord"] is not None:
                od = np.interp(pl.s, sr, r["ord"])
                qv = np.interp(pl.s, sr, r["q"])
            else:
                od = np.full(len(pl.P), r["order"])
                qv = np.linspace(2.0, 2.0 + r["flow"] / 25.0, len(pl.P))
            raw[r["id"]] = (r, pl, od, qv)
        # confluence stations: arc positions on a river where a tributary ends
        stations = {k: [] for k in raw}
        for k, (r, pl, od, qv) in raw.items():
            into = r.get("into")
            if into in raw:
                end = pl.P[-1]
                tgt = raw[into][1]
                j = int(np.argmin(np.hypot(tgt.P[:, 0] - end[0], tgt.P[:, 1] - end[1])))
                stations[into].append(float(tgt.s[j]))
        for k, (r, pl, od, qv) in raw.items():
            L = pl.length
            Lm = np.interp(od, [1, 2, 3, 4], [320.0, 650.0, 1150.0, 1900.0])
            ridx = float(sum(ord(c) for c in str(r["id"])))
            o = np.zeros_like(pl.s)
            for wlk, wgt, sd in ((1.0, 0.65, 31), (0.43, 0.35, 32)):
                u = pl.s / Lm
                iu = np.floor(u)
                fu = u - iu
                fu = fu * fu * (3.0 - 2.0 * fu)
                a = noise._hash(iu, np.full_like(iu, ridx), self.seed + sd) * 2 - 1
                b = noise._hash(iu + 1, np.full_like(iu, ridx), self.seed + sd) * 2 - 1
                o += wgt * (a + (b - a) * fu) * (1.0 if wlk == 1.0 else 0.8)
                Lm = Lm * 0.43
            wm_end = 10.0 + 16.0 * math.log10(1.0 + r["flow"] / 5.0)
            amp = np.clip(3.2 * wm_end * (0.5 + 0.5 * np.clip((od - 1.0) / 3.0, 0, 1)), 12.0, 230.0)
            win = np.minimum(smoothstep(0.0, 420.0, pl.s), smoothstep(0.0, 420.0, L - pl.s))
            for st in stations[k]:
                win = np.minimum(win, smoothstep(60.0, 340.0, np.abs(pl.s - st)))
            off = o * amp * win
            d = np.gradient(pl.P, axis=0)
            nrm = np.stack([-d[:, 1], d[:, 0]], 1) / np.maximum(np.hypot(d[:, 0], d[:, 1]), 1e-9)[:, None]
            P2 = pl.P + nrm * off[:, None]
            pl2 = PolyLine(P2)                                    # re-resample (same point count up to rounding)
            od2 = np.interp(pl2.s * (pl.length / max(pl2.length, 1.0)), pl.s, od)
            qv2 = np.interp(pl2.s * (pl.length / max(pl2.length, 1.0)), pl.s, qv)
            Wv = 38.0 * np.exp(0.80 * (od2 - 1.0))
            pl2.order, pl2.qv, pl2.Wv = od2, qv2, Wv
            pl2.set_vals(np.stack([Wv, od2], 1))
            pl2.id, pl2.name, pl2.flow = r["id"], r["name"], r["flow"]
            out[k] = pl2
        self._rb = out
        return out

    def _valley(self, X, Y):
        """-> (wv, trough): hill damping weight (1 on the floodplain) and trough depth (m) of the river valleys, per point."""
        wv = np.zeros_like(X)
        tr = np.zeros_like(X)
        if not self.use["rivers"]:
            return wv, tr
        bb = self._bbox(X, Y)
        for pl in self._river_base().values():
            reach = float(pl.vals[:, 0].max()) * 1.9 + 20.0
            if not pl.intersects(bb, reach):
                continue
            d, v = pl.query(X, Y, reach)
            ok = np.isfinite(d)
            Wv = np.where(ok, v[:, 0], 1.0)
            dd = np.where(ok, d, reach)
            w = np.where(ok, 1.0 - smoothstep(0.35 * Wv, 1.0 * Wv, dd), 0.0)
            depth = np.where(ok, (2.0 + 0.05 * Wv) * (1.0 - smoothstep(0.15 * Wv, 1.8 * Wv, dd)), 0.0)
            wv = np.maximum(wv, w)
            tr = np.maximum(tr, depth)
        return wv, tr

    def _peak_gauss(self, X, Y, sigma, power=2.0, weights=None, upto=None):
        res = np.zeros_like(X)
        bb = self._bbox(X, Y)
        pk = self.w.peaks if upto is None else self.w.peaks[:upto]
        for k, p in enumerate(pk):
            px, py = p["at"][0] * 1000.0, p["at"][1] * 1000.0
            if px < bb[0] - 8 * sigma or px > bb[2] + 8 * sigma or py < bb[1] - 8 * sigma or py > bb[3] + 8 * sigma:
                continue
            g = np.exp(-(np.hypot(X - px, Y - py) / sigma) ** power)
            if weights is not None:
                res = res + weights[k] * g
            else:
                res = np.maximum(res, g)
        return res

    # -- crest networks, erosion ------------------------------------------------------------------------------
    def _crest_defs(self):
        """One crest polyline per range: the named peaks in order along the range's principal axis (a ridge with saddles);
        a lone peak gets a short crest along the local contour so it is never a stand-alone cone."""
        if self._crests is not None:
            return self._crests
        groups = {}
        for k, p in enumerate(self.w.peaks):
            groups.setdefault(p["range"], []).append(k)
        out = []
        for rid, ks in sorted(groups.items()):
            pts = np.array([[self.w.peaks[k]["at"][0] * 1000.0, self.w.peaks[k]["at"][1] * 1000.0] for k in ks])
            if len(ks) >= 2:
                c = pts - pts.mean(0)
                ax = np.linalg.svd(c, full_matrices=False)[2][0]
                order = np.argsort(c @ ax)
                out.append(dict(P=pts[order], vk=np.array([ks[i] for i in order]), vw=np.ones(len(ks)), dip=np.full(len(ks) - 1, 0.20)))
            else:
                fx, fy = self._fxy(pts[:, 0], pts[:, 1])
                gx = catmull(self.w.elev, fx + 0.5, fy) - catmull(self.w.elev, fx - 0.5, fy)
                gy = catmull(self.w.elev, fx, fy + 0.5) - catmull(self.w.elev, fx, fy - 0.5)
                t = np.array([-float(gy[0]), float(gx[0])])
                t = t / (np.hypot(*t) or 1.0) if np.hypot(*t) > 1e-6 else np.array([0.8, 0.6])
                P = np.array([pts[0] - 2600.0 * t, pts[0], pts[0] + 2600.0 * t])
                out.append(dict(P=P, vk=np.array([ks[0]] * 3), vw=np.array([0.55, 1.0, 0.55]), dip=np.zeros(2)))
        self._crests = out
        return out

    def _peak_ridges(self, X, Y, a):
        """Height added by the raised crest networks (per point, no tile state): a ridged, anisotropic falloff along each crest."""
        out = np.zeros_like(X)
        if a is None or not self.w.peaks:
            return out
        reach = 9.0 * CREST_SIGMA_M
        for c in self._crest_defs():
            P = c["P"]
            lo, hi = P.min(0) - reach, P.max(0) + reach
            idx = np.nonzero((X >= lo[0]) & (X <= hi[0]) & (Y >= lo[1]) & (Y <= hi[1]))[0]
            if len(idx) == 0:
                continue
            Xs, Ys = X[idx], Y[idx]
            dmin = np.full(len(idx), np.inf)
            amp = np.zeros(len(idx))
            for i in range(len(P) - 1):
                A_, B_ = P[i], P[i + 1]
                ab = B_ - A_
                L2 = float(ab @ ab) or 1.0
                t = np.clip(((Xs - A_[0]) * ab[0] + (Ys - A_[1]) * ab[1]) / L2, 0.0, 1.0)
                d = np.hypot(Xs - A_[0] - t * ab[0], Ys - A_[1] - t * ab[1])
                va, vb = a[c["vk"][i]] * c["vw"][i], a[c["vk"][i + 1]] * c["vw"][i + 1]
                ai = (va + (vb - va) * t) * (1.0 - c["dip"][i] * np.sin(math.pi * t))
                better = d < dmin
                dmin = np.where(better, d, dmin)
                amp = np.where(better, ai, amp)
            prof = np.exp(-(np.minimum(dmin, reach) / CREST_SIGMA_M) ** 1.6)
            mod = 0.78 + 0.44 * noise.fbm(Xs, Ys, 900.0, 3, self.seed + 55, ridged=True)
            out[idx] += amp * prof * mod
        return out

    def _pre_erosion(self, X, Y, a=None):
        """The field before erosion: base elevation + warped ridged relief in mountains + raised peak crests. -> (R, h0, mt)."""
        a = self._ridge_a if a is None else a
        s = self.seed
        fx, fy = self._fxy(X, Y)
        h0 = catmull(self.w.elev, fx, fy)
        M = Masks(self.w, fx, fy)
        mt = np.clip(np.maximum.reduce([M["mountain"], M["volcanic"] * 0.8, smoothstep(600, 1500, h0) * 0.9]), 0, 1)
        R = h0.copy()
        im = np.nonzero(mt > 1e-4)[0]
        if len(im):
            Xm, Ym = X[im], Y[im]
            wx = 500.0 * noise.fbm(Xm, Ym, 2600.0, 2, s + 50)
            wy = 500.0 * noise.fbm(Xm + 4000.0, Ym + 9000.0, 2600.0, 2, s + 51)
            ridge = noise.fbm(Xm + wx, Ym + wy, 1500.0, 5, s + 1, ridged=True)
            gul = noise.fbm(Xm, Ym, 300.0, 3, s + 2, ridged=True)
            R[im] += mt[im] * (REL_AMP * (ridge - 0.33) - 25.0 * gul ** 6)
        if a is not None:
            R = R + self._peak_ridges(X, Y, a)
        return R, h0, mt

    def _solve_ridges(self):
        npk = len(self.w.peaks)
        a = np.zeros(npk)
        for sweep in range(6):
            for k, p in enumerate(self.w.peaks):
                X = np.array([p["at"][0] * 1000.0])
                Y = np.array([p["at"][1] * 1000.0])
                base = float(self._pre_erosion(X, Y, a)[0][0])
                unit = np.zeros(npk)
                unit[k] = 1.0
                g = float(self._peak_ridges(X, Y, unit)[0])
                a[k] += (p["m"] - base) / max(g, 0.3)
        self._ridge_a = a

    def _erosion(self, log=print):
        if self._eros is not None:
            return self._eros
        wd = hashlib.sha256(open(os.path.join(self.w.repo, "Data", "World", "physical_map.json"), "rb").read()).hexdigest()
        key = ERO.make_key([wd, self.seed, inspect.getsource(HeightField._pre_erosion), inspect.getsource(HeightField._peak_ridges),
                            inspect.getsource(HeightField._crest_defs), repr((PEAK_SIGMA_M, CREST_SIGMA_M, REL_AMP))])
        path = ERO.cache_path(self.w.repo, key)
        if os.path.exists(path):
            z = np.load(path)
            self._eros = (z["delta"].astype(np.float64), z["slope"].astype(np.float64))
            return self._eros
        t0 = time.time()
        res = ERO.RES
        Nx = int(round(self.w.width_km * 1000.0 / res)) + 1
        Ny = int(round(self.w.height_km * 1000.0 / res)) + 1
        R0 = np.zeros((Ny, Nx), np.float32)
        H0 = np.zeros((Ny, Nx), np.float32)
        MT = np.zeros((Ny, Nx), np.float32)
        xs = np.arange(Nx) * res
        for j0 in range(0, Ny, 60):
            j1 = min(Ny, j0 + 60)
            Xc, Yc = np.meshgrid(xs, np.arange(j0, j1) * res)
            R, h0, mt = self._pre_erosion(Xc.ravel(), Yc.ravel())
            R0[j0:j1], H0[j0:j1], MT[j0:j1] = R.reshape(Xc.shape), h0.reshape(Xc.shape), mt.reshape(Xc.shape)
        log("    erosion: pre-erosion raster %dx%d built (%.0fs)" % (Nx, Ny, time.time() - t0))
        W = smoothstep(0.12, 0.55, MT).astype(np.float32)
        fixed = (H0 <= 0.5) | (R0 <= 0.5)
        fixed[0, :] = fixed[-1, :] = True
        fixed[:, 0] = fixed[:, -1] = True
        W[0, :] = W[-1, :] = 0.0
        W[:, 0] = W[:, -1] = 0.0
        protect = np.ones((Ny, Nx), np.float32)
        yy, xx = np.mgrid[0:Ny, 0:Nx]
        for p in self.w.peaks:                                        # the summit itself is not eroded away
            cx, cy = p["at"][0] * 1000.0 / res, p["at"][1] * 1000.0 / res
            j0, j1, i0, i1 = int(max(cy - 12, 0)), int(min(cy + 13, Ny)), int(max(cx - 12, 0)), int(min(cx + 13, Nx))
            d = np.hypot(xx[j0:j1, i0:i1] - cx, yy[j0:j1, i0:i1] - cy) * res
            protect[j0:j1, i0:i1] *= (1.0 - np.exp(-(d / 420.0) ** 2)).astype(np.float32)
        Rer = ERO.erode(R0, W, fixed, protect, log=log)
        delta = (Rer - H0).astype(np.float32)
        gy_, gx_ = np.gradient(Rer, res)
        slope = np.hypot(gx_, gy_).astype(np.float32)
        np.savez(path, delta=delta, slope=slope)
        log("    erosion: done, cached %s (%.0fs)" % (os.path.basename(path), time.time() - t0))
        self._eros = (delta.astype(np.float64), slope.astype(np.float64))
        return self._eros

    def _eros_sample(self, X, Y):
        delta, slope = self._erosion()
        gx, gy = X / ERO.RES, Y / ERO.RES
        return catmull(delta, gx, gy), np.maximum(catmull(slope, gx, gy), 0.0)

    def _init_peaks(self):
        self._solve_ridges()
        deltas = []
        for k, p in enumerate(self.w.peaks):
            X = np.array([p["at"][0] * 1000.0])
            Y = np.array([p["at"][1] * 1000.0])
            M = Masks(self.w, *self._fxy(X, Y))
            h = self.stage_base(X, Y, M)
            h = h + self.stage_detail(X, Y, h, M)
            if k:
                h = h + self._peak_gauss(X, Y, PEAK_SIGMA_M, 2.0, weights=deltas, upto=k)
            deltas.append(float(p["m"] - h[0]))
        self.peak_delta = deltas

    def stage_peaks(self, X, Y, h):
        if not self.w.peaks:
            return h
        return h + self._peak_gauss(X, Y, PEAK_SIGMA_M, 2.0, weights=self.peak_delta)

    # settlement pads
    def _init_pads(self):
        for s in self.w.settlements:
            cx, cy = s["at"][0] * 1000.0, s["at"][1] * 1000.0
            r = s["flat"] * 0.8
            ang = np.arange(8) * math.pi / 4
            X = np.concatenate([[cx], cx + r * np.cos(ang), cx + 0.5 * r * np.cos(ang)])
            Y = np.concatenate([[cy], cy + r * np.sin(ang), cy + 0.5 * r * np.sin(ang)])
            h = self._upto(X, Y, "peaks")[0]
            self._pad_h[s["name"]] = float(max(np.mean(h), 1.0))

    def pad_height(self, name):
        return self._pad_h[name]

    def stage_pads(self, X, Y, h):
        pw = np.zeros_like(h)
        if not self.use["pads"]:
            return h, pw
        bb = self._bbox(X, Y)
        for s in self.w.settlements:
            cx, cy = s["at"][0] * 1000.0, s["at"][1] * 1000.0
            reach = s["flat"] + s["skirt"]
            if cx < bb[0] - reach or cx > bb[2] + reach or cy < bb[1] - reach or cy > bb[3] + reach:
                continue
            d = np.hypot(X - cx, Y - cy)
            if not s.get("ring0"):                              # the skirt edge follows the land, not a perfect circle (the flat core is untouched)
                d = d + s["skirt"] * 0.45 * noise.fbm(X, Y, 330.0, 2, self.seed + 30) * smoothstep(0.9 * s["flat"], 1.15 * s["flat"], d)
            w = 1.0 - smoothstep(s["flat"], reach, d)
            h = lerp(h, self._pad_h[s["name"]], w)
            pw = np.maximum(pw, w)
        return h, pw

    # roads
    def _profile(self, pl, done=()):
        """Slope-limited road profile for a PolyLine (heights after the pad stage and the roads graded before it).
        The profile merges into settlement pads and earlier road beds, so junctions have no steps. -> (q, h, iterations)."""
        X, Y = pl.P[:, 0], pl.P[:, 1]
        h = self._upto(X, Y, "pads")[0]
        if done:
            h = self._apply_roads(X, Y, h, done)[0]
        n = len(h)
        win = 11
        p = np.convolve(np.pad(h, win // 2, mode="reflect"), np.ones(win) / win, mode="valid") if n > win else h.copy()
        p[0], p[-1] = h[0], h[-1]
        # pins: inside a settlement pad the bed is the pad height; on an earlier road's core it is that road's bed
        hpad, wp = self.stage_pads(X, Y, np.zeros_like(h))
        pin = np.full(n, np.nan)
        m = wp >= 0.999
        pin[m] = hpad[m] / wp[m]
        for o in done:
            if o.intersects(self._bbox(X, Y), ROAD_CORE_M):
                dd, qq = o.query(X, Y, ROAD_CORE_M * 0.6)
                mm = np.isfinite(dd)
                pin[mm] = qq[mm, 0]
        p = np.where(np.isnan(pin), self.stage_pads(X, Y, p)[0], pin)
        ds = pl.length / max(1, n - 1)
        gd = ROAD_TARGET_GRADE * ds
        # exact slope limiting: the smallest and the largest gd-Lipschitz profiles that bound p, averaged (still gd-Lipschitz)
        pinned = ~np.isnan(pin)
        for it in range(4):                                   # re-pin and re-limit: pins stay put, the rest bends to meet them
            lo, hi = p.copy(), p.copy()
            for i in range(1, n):
                lo[i] = max(lo[i], lo[i - 1] - gd)
                hi[i] = min(hi[i], hi[i - 1] + gd)
            for i in range(n - 2, -1, -1):
                lo[i] = max(lo[i], lo[i + 1] - gd)
                hi[i] = min(hi[i], hi[i + 1] + gd)
            q = 0.5 * (lo + hi)
            if not pinned.any():
                break
            p = np.where(pinned, pin, q)
        return np.maximum(q, 0.6), h, it

    def _reroute(self, pts_m, gmax=0.105, step=100.0, margin=4000.0):
        """A* over a 100 m lattice round the authored road: grade-limited moves, so steep stretches become switchbacks."""
        import heapq
        x0 = math.floor((pts_m[:, 0].min() - margin) / step) * step
        y0 = math.floor((pts_m[:, 1].min() - margin) / step) * step
        nx = int((pts_m[:, 0].max() + margin - x0) / step) + 2
        ny = int((pts_m[:, 1].max() + margin - y0) / step) + 2
        gx, gy = np.meshgrid(x0 + np.arange(nx) * step, y0 + np.arange(ny) * step)
        h = self._upto(gx.ravel(), gy.ravel(), "pads")[0].reshape(ny, nx)
        ref = PolyLine(pts_m)
        ref.set_vals(np.zeros(len(ref.P)))
        dev = ref.query(gx.ravel(), gy.ravel(), margin)[0].reshape(ny, nx)
        ok = np.isfinite(dev) & (h > 1.0)
        dev = np.where(ok, dev, 0.0)

        def node(p):
            return int(round((p[1] - y0) / step)), int(round((p[0] - x0) / step))
        (sj, si), (gj, gi) = node(pts_m[0]), node(pts_m[-1])
        if not (ok[sj, si] and ok[gj, gi]):
            return None
        moves = [(dj, di) for dj in range(-2, 3) for di in range(-2, 3) if (dj, di) != (0, 0) and max(abs(dj), abs(di)) == 2 - (abs(dj) == 1 or abs(di) == 1) * 0 and not (abs(dj) == 2 and abs(di) == 2)]
        moves += [(dj, di) for dj in (-1, 0, 1) for di in (-1, 0, 1) if (dj, di) != (0, 0)]
        moves = sorted(set(moves))
        dist = np.full((ny, nx), np.inf)
        prev = np.full((ny, nx, 2), -1, dtype=np.int32)
        dist[sj, sj * 0 + si] = 0.0
        heap = [(math.hypot(gj - sj, gi - si) * step, sj, si)]
        while heap:
            f, j, i = heapq.heappop(heap)
            if (j, i) == (gj, gi):
                break
            dj0 = dist[j, i]
            if f - math.hypot(gj - j, gi - i) * step > dj0 + 1e-6:
                continue
            for mj, mi in moves:
                j2, i2 = j + mj, i + mi
                if j2 < 0 or i2 < 0 or j2 >= ny or i2 >= nx or not ok[j2, i2]:
                    continue
                L = math.hypot(mj, mi) * step
                g = abs(h[j2, i2] - h[j, i]) / L
                if g > gmax:
                    continue
                c = L * (1.0 + 2.0 * (g / gmax) ** 2 + (dev[j2, i2] / 1800.0) ** 2)
                nd = dj0 + c
                if nd < dist[j2, i2]:
                    dist[j2, i2] = nd
                    prev[j2, i2] = (j, i)
                    heapq.heappush(heap, (nd + math.hypot(gj - j2, gi - i2) * step, j2, i2))
        if not np.isfinite(dist[gj, gi]):
            return None
        path, j, i = [], gj, gi
        while (j, i) != (sj, si):
            path.append((x0 + i * step, y0 + j * step))
            j, i = prev[j, i]
        path.append((x0 + si * step, y0 + sj * step))
        path = path[::-1]
        pts = np.array([tuple(pts_m[0])] + path[1:-1] + [tuple(pts_m[-1])])
        # round off lattice zigzags and hairpin tips: a few passes of [1 2 1]/4 with the ends pinned, then corner cutting
        for _ in range(ROUTE_SMOOTH_PASSES):
            pts[1:-1] = 0.25 * pts[:-2] + 0.5 * pts[1:-1] + 0.25 * pts[2:]
        return np.array(chaikin([tuple(q) for q in pts], 2))

    def _road_lines(self):
        if self._roads is not None:
            return self._roads
        lines, stats = [], {}
        if self.use["roads"]:
            for r in self.w.roads:
                pl = PolyLine(r["pts"] * 1000.0)
                q, h, it = self._profile(pl, lines)
                info = dict(rerouted=False, authoredLengthKm=pl.length / 1000.0)
                dev = float(np.abs(q - h).max())
                info["authoredMaxCutFillM"] = dev
                if dev > ROAD_REROUTE_CUTFILL_M:
                    for gm in (0.105, 0.13, 0.17):
                        alt = self._reroute(r["pts"] * 1000.0, gmax=gm, margin=6000.0)
                        if alt is None:
                            continue
                        pl2 = PolyLine(alt)
                        q2, h2, it2 = self._profile(pl2, lines)
                        dev2 = float(np.abs(q2 - h2).max())
                        if dev2 < dev:
                            pl, q, h, it, info["rerouted"], dev = pl2, q2, h2, it2, True, dev2
                        if dev <= ROAD_REROUTE_CUTFILL_M:
                            break
                    if dev > ROAD_MAX_CUTFILL_M:                       # cannot be graded: keep close to the ground, report it
                        q = np.clip(q, h - ROAD_MAX_CUTFILL_M, h + ROAD_MAX_CUTFILL_M)
                        info["graded"] = False
                pl.set_vals(q)
                pl.id = r["id"]
                lines.append(pl)
                ds = pl.length / max(1, len(q) - 1)
                info.update(lengthKm=pl.length / 1000.0, profileMaxGrade=float(np.abs(np.diff(q)).max() / ds), iterations=it,
                            maxCutFillM=float(np.abs(q - h).max()), naturalMaxGrade=float(np.abs(np.diff(h)).max() / ds))
                stats[r["id"]] = info
        self._roads = lines
        self.road_stats = stats
        return lines

    def _apply_roads(self, X, Y, h, lines, clip=True):
        """Blend the terrain to the road beds of `lines` (in order). With clip, a later road does not reshape the footprint
        of an earlier one (its weight is reduced by the earlier weights), so each road keeps its own bed."""
        rw = np.zeros_like(h)
        bb = self._bbox(X, Y)
        reach = ROAD_CORE_M + ROAD_SHOULDER_M
        for pl in lines:
            if not pl.intersects(bb, reach):
                continue
            d, q = pl.query(X.ravel(), Y.ravel(), reach)
            d = d.reshape(h.shape)
            ok = np.isfinite(d)
            w = np.where(ok, 1.0 - smoothstep(ROAD_CORE_M, reach, np.where(ok, d, reach)), 0.0)
            weff = w * (1.0 - rw) if clip else w
            h = lerp(h, q[:, 0].reshape(h.shape), weff)
            rw = np.maximum(rw, w)
        return h, rw

    def stage_roads(self, X, Y, h, pw):
        if not self.use["roads"]:
            return h, np.zeros_like(h)
        return self._apply_roads(X, Y, h, self._road_lines())

    # lakes
    def stage_lakes(self, X, Y, h, rw=None, pw=None):
        lm = np.zeros_like(h)
        ls = np.zeros_like(h)
        if not self.use["lakes"]:
            return h, lm, ls
        bb = self._bbox(X, Y)
        for L in self.w.lakes:
            b = L["bbox"]
            if b[0] * 1000 > bb[2] or b[2] * 1000 < bb[0] or b[1] * 1000 > bb[3] or b[3] * 1000 < bb[1]:
                continue
            fx_, fy_ = self._fxy(X, Y)
            m = np.clip(catmull(L["field"], fx_, fy_), 0.0, 1.0)          # bicubic: no 0.5 km diamond facets on the rim
            S, D = L["surface"], L["depth"]
            wgt = smoothstep(0.20, 0.52, m)
            if rw is not None:
                wgt = wgt * (1.0 - smoothstep(0.3, 0.9, rw)) * (1.0 - pw)
            T = S + 0.5 - 1.1 * smoothstep(0.40, 0.62, m) - min(D, 40.0) * 0.6 * smoothstep(0.55, 0.95, m)
            h = lerp(h, T, wgt)
            upd = m > lm
            ls = np.where(upd, S, ls)
            lm = np.maximum(lm, m)
        return h, lm, ls

    # rivers
    def _river_lines(self):
        if self._rivers is not None:
            return self._rivers
        lines = []
        if self.use["rivers"]:
            for k, pl in self._river_base().items():
                h = self._upto(pl.P[:, 0], pl.P[:, 1], "lakes")[0]
                land = h > 0.3
                if not land.any():
                    continue
                last = len(h) if land.all() else int(np.argmax(~land))
                if last < 3:
                    continue
                keep = slice(0, last)
                order, qv, Wv = pl.order[keep], pl.qv[keep], pl.Wv[keep]
                pl = _trim(copy.copy(pl), last)
                h = h[keep]
                win = 15
                pad = np.pad(h, win // 2, mode="edge")
                sm = np.convolve(pad, np.ones(win) / win, mode="valid")
                ws = _pav_nonincreasing(sm) - 0.4                     # follows the ground, never rises downstream
                w2 = 25                                                # PAV is piecewise constant (stair steps): smooth it
                ws = np.convolve(np.pad(ws, w2 // 2, mode="edge"), np.ones(w2) / w2, mode="valid")
                ws = np.maximum(ws, 0.25)
                wm = 10.0 + 16.0 * math.log10(1.0 + pl.flow / 5.0)
                qn = np.clip(qv / max(float(qv.max()), 1e-6), 0.0, 1.0)
                fade = smoothstep(0.0, 700.0, pl.s) if order[0] < 1.5 else smoothstep(0.0, 120.0, pl.s)   # small creeks fade in at their source
                hw = 0.5 * wm * (0.22 + 0.78 * qn ** 0.6) * (0.35 + 0.65 * fade)
                hw = np.maximum(hw, 0.8)
                dep = 0.6 + 0.05 * (2 * hw)
                pl.set_vals(np.stack([ws, hw, dep, fade, Wv], 1))
                lines.append(pl)
        self._rivers = lines
        return lines

    def stage_rivers(self, X, Y, h, rw_road, pw, lm):
        cw = np.zeros_like(h)
        if not self.use["rivers"]:
            return h, cw
        bb = self._bbox(X, Y)
        for pl in self._river_lines():
            hwmax = float(pl.vals[:, 1].max())
            reach = max(hwmax * 4.0 + 90.0, float(pl.vals[:, 4].max()) * 0.62 + 20.0)
            if not pl.intersects(bb, reach):
                continue
            d, v = pl.query(X.ravel(), Y.ravel(), reach)
            d = d.reshape(h.shape)
            ws, hw, dep = (v[:, 0].reshape(h.shape), v[:, 1].reshape(h.shape), v[:, 2].reshape(h.shape))
            fadev, Wv = v[:, 3].reshape(h.shape), np.maximum(v[:, 4].reshape(h.shape), 1.0)
            ok = np.isfinite(d)
            fl = (1.0 - smoothstep(0.25 * Wv, 0.62 * Wv, np.where(ok, d, 1e9))) * 0.85 * np.where(fadev > 0.5, 1.0, fadev * 2.0)
            gfl = (1.0 - smoothstep(0.3, 0.9, rw_road)) * (1.0 - pw) * (1.0 - smoothstep(0.1, 0.4, lm)) * smoothstep(0.3, 3.0, h)
            h = np.where(ok, lerp(h, ws + 0.9 + 0.012 * np.where(ok, d, 0.0), fl * gfl), h)       # a level floodplain either side of the channel
            bankw = 3.0 * hw + 80.0                                   # >= 4 samples at 20 m: no cliff beside the channel
            inside = d < hw
            bed = ws - dep * (1.0 - (np.where(ok, d, 0.0) / np.maximum(hw, 1e-6)) ** 2)
            tgt = np.where(inside, bed, ws + 0.6 * smoothstep(hw, hw + 24.0, d))   # bank rises 0.6 m over 24 m
            w = np.where(inside, 1.0, 1.0 - smoothstep(hw + 0.15 * bankw, hw + bankw, d)) * np.where(fadev > 0.5, 1.0, fadev * 2.0)
            guard = (1.0 - smoothstep(0.3, 0.9, rw_road)) * (1.0 - pw) * (1.0 - smoothstep(0.1, 0.4, lm)) * smoothstep(0.3, 3.0, h)
            w = np.where(ok, w * guard, 0.0)
            h = lerp(h, tgt, w)
            cw = np.maximum(cw, np.where(inside & ok, guard, 0.0))
        return h, cw

    # -- driver ------------------------------------------------------------------------------------------------
    def _upto(self, X, Y, stage):
        """Heights up to and including `stage` (peaks | pads); used while building profiles."""
        X = np.asarray(X, dtype=np.float64)
        Y = np.asarray(Y, dtype=np.float64)
        M = Masks(self.w, *self._fxy(X, Y))
        h = self.stage_base(X, Y, M)
        h = h + self.stage_detail(X, Y, h, M)
        h = self.stage_peaks(X, Y, h)
        pw = np.zeros_like(h)
        if stage in ("pads", "lakes"):
            h, pw = self.stage_pads(X, Y, h)
        if stage == "lakes":
            h, rw = self.stage_roads(X, Y, h, pw)
            h, lm, ls = self.stage_lakes(X, Y, h, rw, pw)
        return h, pw

    def evaluate(self, X, Y):
        X = np.asarray(X, dtype=np.float64)
        Y = np.asarray(Y, dtype=np.float64)
        shape = X.shape
        X, Y = X.ravel(), Y.ravel()
        M = Masks(self.w, *self._fxy(X, Y))
        h = self.stage_base(X, Y, M)
        h = h + self.stage_detail(X, Y, h, M)
        h = self.stage_peaks(X, Y, h)
        h, pw = self.stage_pads(X, Y, h)
        h, rw = self.stage_roads(X, Y, h, pw)
        h, lm, ls = self.stage_lakes(X, Y, h, rw, pw)
        h, cw = self.stage_rivers(X, Y, h, rw, pw, lm)
        e = Eval()
        e.h, e.pad_w, e.road_w, e.lake_m, e.lake_s, e.river_w, e.masks = (a.reshape(shape) for a in (h, pw, rw, lm, ls, cw, h))
        wx = 240.0 * noise.fbm(X, Y, 900.0, 3, self.seed + 40) + 60.0 * noise.fbm(X, Y, 170.0, 2, self.seed + 41)
        wy = 240.0 * noise.fbm(X, Y, 900.0, 3, self.seed + 42) + 60.0 * noise.fbm(X, Y, 170.0, 2, self.seed + 43)
        e.masks = Masks(self.w, *self._fxy(X + wx, Y + wy))          # soft, noisy ecotones for colour and dressing (heights use the plain masks)
        return e

    def heights(self, X, Y):
        return self.evaluate(X, Y).h

    def river_features(self, bb_m):
        """Rivers clipped to a bbox (metres): dicts with points (n,2), water level, half width."""
        out = []
        for pl in self._river_lines():
            m = (pl.P[:, 0] >= bb_m[0] - 80) & (pl.P[:, 0] <= bb_m[2] + 80) & (pl.P[:, 1] >= bb_m[1] - 80) & (pl.P[:, 1] <= bb_m[3] + 80)
            if m.sum() < 2:
                continue
            idx = np.nonzero(m)[0]
            # split into contiguous runs
            runs = np.split(idx, np.nonzero(np.diff(idx) > 1)[0] + 1)
            for run in runs:
                if len(run) >= 2:
                    out.append(dict(id=pl.id, name=pl.name, flow=pl.flow, P=pl.P[run], ws=pl.vals[run, 0], hw=pl.vals[run, 1]))
        return out

    def road_lines_in(self, bb_m):
        reach = ROAD_CORE_M + ROAD_SHOULDER_M
        return [pl for pl in self._road_lines() if pl.intersects(bb_m, reach)]


def _trim(pl, last):
    pl.P = pl.P[:last]
    pl.s = pl.s[:last]
    pl.length = float(pl.s[-1])
    pl.bbox = (pl.P[:, 0].min(), pl.P[:, 1].min(), pl.P[:, 0].max(), pl.P[:, 1].max())
    return pl
