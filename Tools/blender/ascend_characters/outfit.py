"""
The Rank-F adventurer outfit as separate, swappable parts: top (tunic with short sleeves), bottom (trousers or leggings),
skirt (female cut), belt (with buckle and pouch), boots, bracers, cloak. Built with the body's own Builder at an outward
offset, so every garment fits every height, build and age, and carries the same bone weights. Colours come from the
variant's outfit colourway. Garments are single-sided shells (the toon outline closes their silhouette).
"""
import math

import numpy as np

from . import body as B
from . import layout as LY
from . import meshio as M
from .spec import hex_lin


def _cut(mb, keep_face):
    """Drops faces for which keep_face(vertex coords) is False, then unused vertices."""
    mb.F = [f for f in mb.F if keep_face(np.array([mb.V[i] for i in f]))]
    mb.compact()


def _finish(name, mb, body, col, colours, material, levels=1):
    from . import materials as MT
    V, Fc = mb.arrays()
    o = M.make_object(name, V, Fc, mb.W, col)
    M.subdivide(o, levels)
    M.set_colours(o, colours(M.co(o)))
    MT.assign(o, material)
    M.orient_outward(o, body)
    return o


def _lin(h):
    return np.array(hex_lin(h))


def _paint(base, *rows):
    """base colour, then (mask function, colour) rows; later rows win."""
    def f(co):
        c = np.tile(base, (len(co), 1))
        for mask_fn, colr in rows:
            c[mask_fn(co)] = colr
        return c
    return f


def build(sp, L, body, col):
    H = L.H
    k = H / 1.78
    cols = sp["outfitColours"]
    prim, sec, trim, leather, cloakc = (_lin(cols[n]) for n in ("primary", "secondary", "trim", "leather", "cloak"))
    dark = leather * 0.7
    name = sp["id"]
    parts = {}
    want = sp["outfitParts"]

    if "top" in want:
        def off(kind, i):
            if kind == "master":
                return {0: 0.020, 1: 0.016, 2: 0.012, 3: 0.011, 4: 0.012, 5: 0.011, 6: 0.009, 7: 0.008, 8: 0.007}.get(i, 0.006 if i < 12 else 0.004) * k
            return (0.007 + 0.0035 * i) * k
        b = B.Builder(L, off)
        b.master(0, 13, holes=(True, True))
        for s in (1, -1):
            b.arm(s, upto=3)
        B.finish_weights(b.mb, L)
        b.mb.compact()
        cuff_x = L.arm()["shoulder"] + 0.105 * H
        parts["top"] = _finish(name + "_top", b.mb, body, col,
                               _paint(prim, (lambda c: c[:, 2] < 0.505 * H, trim), (lambda c: c[:, 2] > 0.826 * H, trim),
                                      (lambda c: np.abs(c[:, 0]) > cuff_x - 0.016 * H, trim)), "CH_cloth")
    if "bottom" in want:
        tight = L.female

        def off(kind, i):
            if kind == "master":
                return 0.004 if tight else 0.007
            return (0.003 if tight else 0.008 - 0.0004 * i) * k
        b = B.Builder(L, off)
        b.master(0, 4, holes=(False, False))
        for s in (1, -1):
            b.leg(s, upto=11)
        B.finish_weights(b.mb, L)
        b.mb.compact()
        colr = sec * 0.55 if tight else sec
        parts["bottom"] = _finish(name + "_bottom", b.mb, body, col,
                                  _paint(colr, (lambda c: c[:, 2] > 0.585 * H, trim * 0.6 + colr * 0.4)), "CH_cloth")
    if "skirt" in want:
        parts["skirt"] = _skirt(sp, L, body, col, sec, trim)
    if "belt" in want:
        parts["belt"] = _belt(sp, L, body, col, leather)
    if "boots" in want:
        b = B.Builder(L, lambda kind, i: {"leg": 0.0065, "foot": 0.0055}.get(kind, 0.0) * k)
        b.master(0, 0)
        for s in (1, -1):
            lg = b.leg(s, upto=11)
            b.foot(s, lg)
        zc = 0.255 * H
        _cut(b.mb, lambda p: p[:, 2].max() <= zc)
        b.mb.V = [(x, y, max(z, 0.0)) for x, y, z in b.mb.V]
        B.finish_weights(b.mb, L)
        parts["boots"] = _finish(name + "_boots", b.mb, body, col,
                                 _paint(leather, (lambda c: c[:, 2] > zc - 0.03 * H, trim * 0.75 + leather * 0.25),
                                        (lambda c: c[:, 2] < 0.009 * H, dark)), "CH_leather")
    if "bracers" in want:
        b = B.Builder(L, lambda kind, i: 0.0065 * k)
        b.master(0, 13, holes=(True, True))
        A = L.arm()
        x1, x2 = A["elbow"] + 0.03 * H, A["wrist"] - 0.012 * H
        for s in (1, -1):
            b.arm(s)
        _cut(b.mb, lambda p: np.abs(p[:, 0]).min() >= x1 and np.abs(p[:, 0]).max() <= x2)
        B.finish_weights(b.mb, L)
        parts["bracers"] = _finish(name + "_bracers", b.mb, body, col,
                                   _paint(leather, (lambda c: np.abs(np.abs(c[:, 0]) - (x1 + x2) / 2) < 0.012 * H, trim * 0.7 + leather * 0.3)), "CH_leather")
    if "cloak" in want:
        parts["cloak"] = _cloak(sp, L, body, col, cloakc, trim)
    return parts


def _skirt(sp, L, body, col, sec, trim):
    H = L.H
    mb = B.MB()
    zs = [0.598, 0.565, 0.515, 0.455, 0.395, 0.345]
    fl = [0.10, 0.22, 0.42, 0.62, 0.80, 0.92]
    base = L.master_ring(2)
    cy = L.master_ring(3)[:, 1].mean()
    rings = []
    for z, f in zip(zs, fl):
        wob = 1.0 + 0.04 * f * np.sin(np.arange(LY.NR) * 2 * math.pi * 3 / LY.NR)
        p = base.copy()
        p[:, 0] = base[:, 0] * (1 + f) * wob + np.sign(base[:, 0]) * 0.01 * H
        p[:, 1] = cy + (base[:, 1] - cy) * (1 + f * 0.9) * wob
        p[:, 2] = z * H
        ws = []
        for q in p:
            side = "Left" if q[0] > 0 else "Right"
            t = B.smooth((0.575 - z) / 0.22) * min(abs(q[0]) / (0.07 * H), 1.0)
            w = {"Hips": 1 - t * 0.85}
            if t > 0.01:
                w[side + "UpperLeg"] = t * 0.85
            ws.append(w)
        rings.append(mb.ring(p, ws, "skirt"))
    for a, b_ in zip(rings, rings[1:]):
        mb.band(a, b_)
    return _finish(sp["id"] + "_skirt", mb, body, col,
                   _paint(sec, (lambda c_: c_[:, 2] < 0.375 * H, trim * 0.8 + sec * 0.2)), "CH_cloth")


def _box(mb, centre, size, w):
    cx, cy, cz = centre
    sx, sy, sz = (s / 2 for s in size)
    ids = []
    for z in (-1, 1):
        for y in (-1, 1):
            for x in (-1, 1):
                ids.append(mb.add((cx + x * sx, cy + y * sy, cz + z * sz), w, "belt"))
    for f in ((0, 1, 3, 2), (4, 6, 7, 5), (0, 4, 5, 1), (2, 3, 7, 6), (0, 2, 6, 4), (1, 5, 7, 3)):
        mb.F.append(tuple(ids[i] for i in f))


def _belt(sp, L, body, col, leather):
    H = L.H
    mb = B.MB()
    rings = []
    off = 0.013 * H / 1.78
    for z in (0.589, 0.601, 0.613):
        pts = L.master_ring(4, off).copy()
        pts[:, 2] = z * H
        rings.append(mb.ring(pts, {"Spine": 0.6, "Hips": 0.4}, "belt"))
    for a, b_ in zip(rings, rings[1:]):
        mb.band(a, b_)
    mid = L.master_ring(4, off)
    front_y = mid[0, 1]
    _box(mb, (0, front_y - 0.006 * H, 0.601 * H), (0.026 * H, 0.010 * H, 0.030 * H), {"Spine": 0.6, "Hips": 0.4})
    px = mid[:, 0].max()
    _box(mb, (px + 0.004 * H, front_y * 0.35, 0.570 * H), (0.020 * H, 0.034 * H, 0.050 * H), {"Hips": 1.0})
    gold = _lin("#D9AE4A")

    def paint(co):
        c = np.tile(leather, (len(co), 1))
        c[(np.abs(co[:, 0]) < 0.016 * H) & (co[:, 1] < front_y - 0.002 * H)] = gold
        c[(co[:, 0] > px - 0.002 * H) & (co[:, 2] < 0.598 * H)] = leather * 0.8
        return c
    return _finish(sp["id"] + "_belt", mb, body, col, paint, "CH_leather", levels=0)


def _cloak(sp, L, body, col, cloakc, trim):
    H = L.H
    mb = B.MB()
    zs = [0.822, 0.795, 0.75, 0.70, 0.64, 0.58, 0.52, 0.46, 0.40, 0.34, 0.285]
    n = 15
    th = np.linspace(math.radians(76), math.radians(284), n)
    rows = []
    for z in zs:
        ri = int(np.clip(np.searchsorted(LY.Z, z) - 1, 0, LY.NECK_BASE))
        a, bk = L.A[ri] * H, L.BB[ri] * H
        drape = max(0.0, (0.76 - z) / 0.5)
        pts = []
        for t in th:
            rx = a + (0.016 + 0.040 * drape) * H
            ry = bk + (0.020 + 0.075 * drape) * H
            wave = 1.0 + 0.05 * drape * math.sin(t * 5.0)
            pts.append((math.sin(t) * rx * wave, L.yoff(z) * H - math.cos(t) * ry * wave, z * H))
        w = B.chain_weights(-z, ["UpperChest", "CloakBack_1", "CloakBack_2", "CloakBack_3"], [-0.745, -0.60, -0.46], 0.05)
        rows.append(mb.ring(np.array(pts), w, "cloak"))
    for a, b_ in zip(rows, rows[1:]):
        for j in range(n - 1):
            mb.F.append((a[j], a[j + 1], b_[j + 1], b_[j]))

    def paint(co):
        c = np.tile(cloakc, (len(co), 1))
        c[co[:, 2] < 0.31 * H] = trim * 0.8 + cloakc * 0.2
        c[co[:, 2] > 0.81 * H] = trim * 0.7 + cloakc * 0.3
        return c
    return _finish(sp["id"] + "_cloak", mb, body, col, paint, "CH_cloth", levels=1)
