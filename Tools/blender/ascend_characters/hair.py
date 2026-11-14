"""
Hair: one generator, eleven presets. Every style is a scalp cap (offset copy of the top head rings) plus tapered tube
"clumps" that follow curves from a root on the scalp: bangs, side locks, back mass, ponytails, a braid, a bun. The curves
are pushed out of the skull and shoulders, so a style fits every head and body. Long strands are weighted to the extra
HairBack_/HairSide chains so the game can swing them; the cap and bangs follow the Head bone.

A style is a list of groups (see GROUPS below). Same variant and seed = same hair (all randomness is spec.rng).
"""
import math

import numpy as np

from . import body as B
from . import layout as LY
from . import meshio as M
from . import materials as MT
from .spec import hex_lin, rng

SEG = 4    # vertices around a clump tube (a flat, pointed lock)
RINGS = 9  # rings along a clump


def _bez(p0, p1, p2, p3, t):
    t = t[:, None]
    return ((1 - t) ** 3) * p0 + 3 * ((1 - t) ** 2) * t * p1 + 3 * (1 - t) * t * t * p2 + t ** 3 * p3


class Hair:
    def __init__(self, sp, L):
        self.sp, self.L, self.H = sp, L, L.H
        self.rng = rng(sp, "hair")
        H = self.H
        self.cz = 0.935 * H
        self.cy = L.Y0[19] * H + 0.004 * H
        self.rad = np.array([L.head * H, L.BF[19] * H * 0.5 + L.BB[19] * H * 0.5, 0.075 * H])   # skull ellipsoid
        self.mb = B.MB()
        self.col = []        # (t, weight kind) per vertex for colouring
        self.t = []
        self.vol = 1.0
        self.hair_cols = (np.array(hex_lin(sp["hair"]["colour"]["hex"])), np.array(hex_lin(sp["hair"]["colour"]["tip"])))

    # ----- surface helpers -----------------------------------------------------------------------------------
    def root(self, ring, k, off=0.009):
        return self.L.master_ring(ring, off * self.H / 1.78 * self.vol)[k % LY.NR]

    def push_out(self, p):
        """Keeps a point outside the skull ellipsoid and the shoulders."""
        H = self.H
        c = np.array([0.0, self.cy, self.cz])
        q = (p - c) / (self.rad + 0.010 * H * self.vol)
        n = np.linalg.norm(q)
        if n < 1.0 and p[2] > 0.86 * H:
            p = c + (p - c) / max(n, 1e-6)
        if p[2] < 0.86 * H and p[2] > 0.60 * H:        # around the neck and shoulders: stay outside the torso tube
            zf = p[2] / H
            ring = int(np.clip(np.searchsorted(LY.Z, zf) - 1, 0, LY.NECK_BASE))
            a = self.L.A[ring] * H + 0.012 * H
            b = (self.L.BB[ring] if p[1] > 0 else self.L.BF[ring]) * H + 0.012 * H
            e = math.hypot(p[0] / a, (p[1] - self.L.yoff(zf) * H) / b)
            if e < 1.0:
                s = 1.0 / max(e, 1e-6)
                p = np.array([p[0] * s, (p[1] - self.L.yoff(zf) * H) * s + self.L.yoff(zf) * H, p[2]])
        return p

    # ----- geometry --------------------------------------------------------------------------------------------
    def cap(self, i0=20, nape=True, front_k=None, vol=1.0):
        """Scalp cap: rings 17..23 with a hairline (high at the front, lower at the sides and back) and a flat crown."""
        L, mb, H = self.L, self.mb, self.H
        self.vol = vol
        offs = {17: 0.0100, 18: 0.0105, 19: 0.0112, 20: 0.0120, 21: 0.0122, 22: 0.0105, 23: 0.0080}
        cosv = np.cos(LY.TH)
        limit = {17: -0.05, 18: -0.02, 19: 0.10, 20: 0.48, 21: 0.84, 22: 2.0, 23: 2.0}
        lo = 17 if nape else 19
        rings = {}
        for i in range(lo, 24):
            pts = L.master_ring(i, offs[i] * H / 1.78 * vol)
            ids = mb.ring(pts, {"Head": 1.0}, "hair")
            self.t += [0.0] * LY.NR
            rings[i] = (ids, cosv < limit[i])
        for i in range(lo, 23):
            a_, ka = rings[i]
            b_, kb = rings[i + 1]
            for k in range(LY.NR):
                j = (k + 1) % LY.NR
                if ka[k] and ka[j] and kb[k] and kb[j]:
                    mb.F.append((a_[k], a_[j], b_[j], b_[k]))
        ids, _ = rings[23]
        c = mb.pos(ids).mean(0)
        apex = mb.add(np.array([c[0], c[1], H * 1.0 + 0.0035 * H * vol]), {"Head": 1.0}, "hair")
        self.t.append(0.0)
        for k in range(LY.NR):
            mb.F.append((ids[k], ids[(k + 1) % LY.NR], apex))

    def clump(self, rt, end, w0=0.0075, ctrl=(0.35, 0.2), bulge=0.0, wave=0.0, bone="Head", t_col=1.0, up=None, flat=0.62):
        """A tapered tube from root rt to end with a cubic bend. ctrl: how far the first handle leaves the scalp (along the
        outward direction) and how much the second handle drops."""
        mb, H = self.mb, self.H
        c = np.array([0.0, self.cy, self.cz])
        out = rt - c
        out[2] *= 0.4
        out /= np.linalg.norm(out) + 1e-9
        d = end - rt
        ln = np.linalg.norm(d)
        p1 = rt + out * ln * ctrl[0]
        flip = np.array([1.0 if rt[0] >= 0 else -1.0, 0.0, 0.0]) * ln * 0.14 * (1 if int(abs(rt[0]) * 1000) % 2 else -1)
        p2 = end - d / (ln + 1e-9) * ln * 0.30 + np.array([0, 0, -1.0]) * ln * ctrl[1] + flip
        t = np.linspace(0, 1, RINGS)
        path = _bez(rt, p1, p2, end, t)
        path = np.array([self.push_out(p) if i > 0 else p for i, p in enumerate(path)])
        tan = np.gradient(path, axis=0)
        tan /= np.linalg.norm(tan, axis=1, keepdims=True) + 1e-9
        ref = np.array([0.0, 0.0, 1.0]) if up is None else up
        ids = []
        for i in range(RINGS):
            s = t[i]
            side = np.cross(tan[i], ref)
            if np.linalg.norm(side) < 1e-4:
                side = np.cross(tan[i], np.array([1.0, 0, 0]))
            side /= np.linalg.norm(side)
            thick = np.cross(side, tan[i])
            w = w0 * H * (0.55 + 0.45 * math.sin(min(s, 0.3) / 0.3 * math.pi / 2)) * (1 - s) ** 0.8 * (1 + bulge * math.sin(math.pi * s)) * (1 + wave * math.sin(s * 14.0))
            w = max(w, 0.0004 * H)
            ring = []
            for a in (0.0, math.pi / 2, math.pi, 3 * math.pi / 2):
                ring.append(path[i] + side * math.cos(a) * w + thick * math.sin(a) * w * flat)
            wt = self._weights(path[i], bone)
            ids.append(mb.ring(np.array(ring), wt, "hair"))
            self.t += [s * t_col] * SEG
        for a, b in zip(ids, ids[1:]):
            mb.band(a, b)
        c0 = mb.pos(ids[-1]).mean(0)
        mb.F.append(tuple(reversed(ids[-1])))
        mb.F.append(tuple(ids[0]))

    def _weights(self, p, bone):
        H = self.H
        z = p[2] / H
        if bone == "Head":
            return {"Head": 1.0}
        if bone == "Back":
            return B.chain_weights(-z, ["Head", "HairBack_1", "HairBack_2", "HairBack_3"], [-0.925, -0.88, -0.80], 0.035)
        side = "L" if bone == "SideL" else "R"
        return B.chain_weights(-z, ["Head", "HairSide%s_1" % side, "HairSide%s_2" % side], [-0.925, -0.88], 0.035)

    def sphere(self, centre, r, bone="Head", squash=1.0):
        mb = self.mb
        segs, rings = 10, 6
        ids = []
        for i in range(1, rings):
            v = -math.pi / 2 + math.pi * i / rings
            ring = [centre + np.array([math.cos(v) * math.cos(u) * r, math.cos(v) * math.sin(u) * r, math.sin(v) * r * squash])
                    for u in np.linspace(0, 2 * math.pi, segs, endpoint=False)]
            ids.append(mb.ring(np.array(ring), {"Head": 1.0}, "hair"))
            self.t += [0.3] * segs
        for a, b in zip(ids, ids[1:]):
            mb.band(a, b)
        for ring, z in ((ids[0], -1), (ids[-1], 1)):
            apex = mb.add(centre + np.array([0, 0, z * r * squash]), {"Head": 1.0}, "hair")
            self.t.append(0.3)
            for k in range(segs):
                mb.F.append((ring[k], ring[(k + 1) % segs], apex) if z > 0 else (ring[(k + 1) % segs], ring[k], apex))


# --------------------------------------------------------------------------------------------------------------------
# Presets. Lengths are fractions of height. dirs: (out, down, side, fwd) of the end point relative to the root.

def _group(h, rings, ks, n, length, out, down, side=0.0, fwd=0.0, w0=0.0075, bone="Head", jitter=0.25, **kw):
    H = h.H
    cand = [(r, k) for r in rings for k in ks]
    h.rng.shuffle(cand)
    while len(cand) < n:                       # more strands than roots: reuse roots, the jitter separates them
        extra = [(r, k) for r in rings for k in ks]
        h.rng.shuffle(extra)
        cand += extra
    for r, k in cand[:n]:
        rt = h.root(r, k)
        sgn = 1.0 if rt[0] >= 0 else -1.0
        ln = h.rng.uniform(*length) * H
        j = lambda: 1.0 + (h.rng.random() - 0.5) * 2 * jitter
        c = np.array([0.0, h.cy, h.cz])
        o = rt - c
        o[2] = 0
        o /= np.linalg.norm(o) + 1e-9
        tang = np.array([o[1], -o[0], 0.0])        # around the head
        e = rt + (o * out * j() + np.array([0, 0, -1.0]) * down * j() + tang * side * sgn * 0 + np.array([sgn, 0, 0]) * side * j() +
                  np.array([0, -1.0, 0]) * fwd) * ln
        h.clump(rt, e, w0=w0 * 3.3 * (0.85 + 0.3 * h.rng.random()), bone=bone, **kw)


ALL = list(range(LY.NR))
FRONT = [-2, -1, 0, 1, 2]
BACK = [6, 7, 8, 9, 10, 11, 12]
SIDEL = [3, 4, 5, 6]
SIDER = [12, 13, 14, 15]
NOFRONT = [k for k in ALL if k not in (-3 % 18, -2 % 18, -1 % 18, 0, 1, 2, 3)]
TOP = [22, 23]


def style_crop(h):
    h.cap(20, nape=True, vol=1.45)
    _group(h, [20, 21, 22, 23], NOFRONT, 64, (0.045, 0.072), 0.70, 0.95, w0=0.0082, ctrl=(0.25, 0.05))
    _group(h, [21, 22], SIDEL + SIDER, 16, (0.050, 0.070), 0.30, 1.05, w0=0.0078, ctrl=(0.18, 0.15))
    _group(h, [21, 22, 23], FRONT, 22, (0.048, 0.066), 0.16, 1.05, side=0.38, fwd=0.42, w0=0.0078, ctrl=(0.30, 0.0))


def style_swept_fringe(h):
    h.cap(20, nape=True, vol=0.95)
    _group(h, [22], FRONT, 9, (0.040, 0.058), 0.35, 0.75, side=0.6, fwd=0.5, w0=0.0085, ctrl=(0.45, 0.1))
    _group(h, TOP, NOFRONT, 34, (0.060, 0.090), 0.5, 1.0, w0=0.0080)


def style_spiky(h):
    h.cap(20, nape=True, vol=0.9)
    _group(h, TOP, ALL, 30, (0.050, 0.085), 0.9, -0.55, w0=0.0090, ctrl=(0.55, -0.15), bulge=0.25)
    _group(h, [22], FRONT, 7, (0.030, 0.045), 0.3, 0.8, side=0.5, fwd=0.55, w0=0.0080)
    _group(h, TOP, SIDEL + SIDER + BACK, 14, (0.060, 0.090), 0.7, 0.9, w0=0.0075)


def _gather(h, n, centre, spread, length, bone="Back", w0=0.0090, rings=(22, 23), ks=None, drop=0.9):
    """Strands from the head that meet at one point (a tie) and hang from it."""
    H = h.H
    cand = [(r, k) for r in rings for k in (ks or NOFRONT)]
    h.rng.shuffle(cand)
    for r, k in cand[:n]:
        rt = h.root(r, k)
        ln = h.rng.uniform(*length) * H
        tie = np.array(centre) * H + np.array([h.rng.uniform(-1, 1) * spread, h.rng.uniform(-1, 1) * spread * 0.5, 0.0]) * H
        e = tie + np.array([0, 0.012 * H, -ln * drop])
        h.clump(rt, e, w0=w0, bone=bone, ctrl=(0.15, 0.1))


def style_tied_back(h):
    h.cap(20, nape=True, vol=0.9)
    _gather(h, 26, (0.0, 0.066, 0.925), 0.010, (0.075, 0.095), w0=0.0095)
    _group(h, [22], FRONT, 6, (0.028, 0.038), 0.2, 0.9, side=0.35, fwd=0.35, w0=0.0075)
    _group(h, [22], SIDEL + SIDER, 8, (0.045, 0.060), 0.4, 0.9, w0=0.0075)


def style_long_shaggy(h):
    h.cap(20, nape=True, vol=1.0)
    _group(h, TOP, NOFRONT, 44, (0.20, 0.27), 0.55, 1.0, w0=0.0100, bone="Back", ctrl=(0.3, 0.2), jitter=0.3)
    _group(h, [22], FRONT, 9, (0.032, 0.046), 0.2, 0.85, side=0.5, fwd=0.4, w0=0.0085)


def style_bob(h):
    h.cap(20, nape=True, vol=1.50)
    _group(h, [20, 21, 22, 23], NOFRONT, 78, (0.115, 0.145), 0.42, 1.0, side=-0.06, w0=0.0105, bone="Back",
           ctrl=(0.30, 0.10), jitter=0.12)
    _group(h, [21, 22], SIDEL + SIDER, 20, (0.100, 0.130), 0.26, 1.05, w0=0.0098, bone="Back", ctrl=(0.16, 0.12))
    _group(h, [21, 22, 23], FRONT, 24, (0.046, 0.062), 0.14, 1.05, side=0.28, fwd=0.34, w0=0.0088, ctrl=(0.28, 0.0))


def style_long_loose(h):
    h.cap(20, nape=True, vol=1.0)
    _group(h, TOP, NOFRONT, 54, (0.280, 0.340), 0.45, 1.0, w0=0.0100, bone="Back", ctrl=(0.3, 0.25), jitter=0.18)
    _group(h, [22], FRONT, 9, (0.034, 0.050), 0.25, 0.85, side=0.5, fwd=0.35, w0=0.0085)
    _group(h, [22], SIDEL, 6, (0.17, 0.21), 0.5, 1.0, w0=0.0090, bone="SideL")
    _group(h, [22], SIDER, 6, (0.17, 0.21), 0.5, 1.0, w0=0.0090, bone="SideR")


def style_high_ponytail(h):
    h.cap(20, nape=False, vol=0.95)
    _gather(h, 24, (0.0, 0.040, 1.012), 0.008, (0.24, 0.30), w0=0.0105, drop=0.85)
    _group(h, [22], FRONT, 8, (0.028, 0.040), 0.15, 0.9, side=0.4, fwd=0.4, w0=0.0080)
    _group(h, [22], SIDEL, 4, (0.08, 0.10), 0.4, 1.0, w0=0.0080, bone="SideL")
    _group(h, [22], SIDER, 4, (0.08, 0.10), 0.4, 1.0, w0=0.0080, bone="SideR")


def style_side_braid(h):
    h.cap(20, nape=True, vol=1.0)
    H = h.H
    _group(h, [22], FRONT, 9, (0.032, 0.048), 0.2, 0.9, side=0.5, fwd=0.4, w0=0.0085)
    _group(h, TOP, BACK + SIDER, 24, (0.10, 0.13), 0.5, 1.0, w0=0.0095, bone="Back")
    for dx, dy in ((0.0, 0.0), (0.004, 0.003), (-0.004, 0.003)):     # the braid: three fat strands over the left shoulder
        rt = h.root(22, 5)
        e = np.array([0.075 * H + dx * H, -0.012 * H + dy * H, 0.700 * H])
        h.clump(rt, e, w0=0.0105, bulge=0.15, wave=0.28, bone="SideL", ctrl=(0.45, 0.05))


def style_short_flick(h):
    h.cap(20, nape=True, vol=0.95)
    _group(h, TOP, NOFRONT, 40, (0.050, 0.075), 0.95, 0.75, w0=0.0090, ctrl=(0.35, -0.1), bulge=0.2)
    _group(h, [22], FRONT, 9, (0.032, 0.046), 0.25, 0.8, side=0.45, fwd=0.45, w0=0.0080)


def style_bun_fringe(h):
    h.cap(20, nape=True, vol=0.95)
    H = h.H
    h.sphere(np.array([0.0, h.cy + 0.040 * H, 1.012 * H]), 0.030 * H, squash=0.85)
    _gather(h, 16, (0.0, 0.040, 0.995), 0.006, (0.02, 0.03), w0=0.010, drop=0.2)
    _group(h, [22], FRONT, 11, (0.030, 0.042), 0.15, 0.95, side=0.35, fwd=0.35, w0=0.0085)
    _group(h, [22], SIDEL + SIDER, 8, (0.05, 0.07), 0.4, 1.0, w0=0.0080)


STYLES = {"crop": style_crop, "swept_fringe": style_swept_fringe, "spiky": style_spiky, "tied_back": style_tied_back,
          "long_shaggy": style_long_shaggy, "bob": style_bob, "long_loose": style_long_loose,
          "high_ponytail": style_high_ponytail, "side_braid": style_side_braid, "short_flick": style_short_flick,
          "bun_fringe": style_bun_fringe}


def build(sp, L, body, col):
    h = Hair(sp, L)
    STYLES[sp["hair"]["style"]](h)
    mb = h.mb
    used = sorted({i for f in mb.F for i in f})
    remap = {a: n for n, a in enumerate(used)}
    h.t = [h.t[i] for i in used]
    mb.V, mb.W = [mb.V[i] for i in used], [mb.W[i] for i in used]
    mb.F = [tuple(remap[i] for i in f) for f in mb.F]
    V, Fc = mb.arrays()
    o = M.make_object(sp["id"] + "_hair", V, Fc, mb.W, col, smooth=True)
    M.subdivide(o, 0)
    co = M.co(o)
    root, tip = h.hair_cols
    t = np.array(h.t)
    if sp["age"]["id"] == "older" and sp["hair"]["colour"]["id"] not in ("silver", "snow"):
        grey = np.array(hex_lin("#C9CDD6"))
        root, tip = root * 0.55 + grey * 0.45, tip * 0.5 + grey * 0.5
    c = root[None, :] * (1 - t[:, None] * 0.75) + tip[None, :] * (t[:, None] * 0.75)
    H = L.H
    band = np.exp(-((co[:, 2] - 0.968 * H) / (0.008 * H)) ** 2) * (np.linalg.norm(co[:, :2] - np.array([0, L.Y0[19] * H]), axis=1) > 0.03 * H)
    band *= 0.55
    c = c * (1 - band[:, None]) + (tip * 1.12)[None, :] * band[:, None]
    M.set_colours(o, np.clip(c, 0, 1))
    MT.assign(o, "CH_hair")
    M.orient_outward(o, body)
    return {"hair": o}
