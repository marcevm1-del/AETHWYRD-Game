"""
The readable anime face: eyes (sclera, iris, pupil, two highlights, lash line), brows, mouth and ears.

The head itself is smooth (a nose wedge and a chin come from the rings in layout.py). Everything else is built as thin
decal patches that are PROJECTED onto the head surface, so they follow every variant's head shape and sit a fixed
distance above it. Eyes, brows and mouth are separate objects with shape keys (blink, brow up/down, smile, open), so a
later facial system or a texture swap can drive them. No facial animation is built here.

All dimensions come from the Layout (eye width as a share of face width, eye height ratio, age and sex).
"""
import math

import numpy as np
from mathutils import Vector
from mathutils.bvhtree import BVHTree

from . import layout as LY
from . import meshio as M
from .spec import hex_lin


class Surface:
    """Casts rays at the head from the front to find the skin under a (x, z) position."""

    def __init__(self, obj):
        import bpy
        dg = bpy.context.evaluated_depsgraph_get()
        self.tree = BVHTree.FromObject(obj, dg)

    def hit(self, x, z, y_from=-1.0):
        r = self.tree.ray_cast(Vector((x, y_from, z)), Vector((0, 1, 0)), 3.0)
        if r[0] is None:
            return None, None
        return np.array(r[0]), np.array(r[1])

    def project(self, x, z, lift):
        p, n = self.hit(x, z)
        if p is None:
            return np.array([x, -0.05, z])
        return p + n * lift


class Patch:
    """Vertices and faces in a local 2D layout, projected to the face when baked."""

    def __init__(self):
        self.uv, self.F, self.col, self.lift, self.tag = [], [], [], [], []

    def add(self, pts, col, lift, tag=""):
        base = len(self.uv)
        for p in pts:
            self.uv.append(p)
            self.col.append(col)
            self.lift.append(lift)
            self.tag.append(tag)
        return base

    def disc(self, outline, col, lift, rings=3, tag=""):
        """Centre vertex plus `rings` scaled copies of the closed outline (n,2). Returns first vertex index."""
        n = len(outline)
        c = outline.mean(0)
        base = self.add([c], col, lift, tag)
        ring_ids = []
        for r in range(1, rings + 1):
            s = r / rings
            ids = list(range(len(self.uv), len(self.uv) + n))
            self.add([c + (p - c) * s for p in outline], col, lift, tag)
            ring_ids.append(ids)
        for j in range(n):
            self.F.append((base, ring_ids[0][j], ring_ids[0][(j + 1) % n]))
        for r in range(1, rings):
            for j in range(n):
                k = (j + 1) % n
                self.F.append((ring_ids[r - 1][j], ring_ids[r][j], ring_ids[r][k], ring_ids[r - 1][k]))
        return base

    def ribbon(self, centre, width, col, lift, tag=""):
        """A strip along the polyline `centre` (n,2) with per-point width (n,)."""
        c = np.asarray(centre, float)
        n = len(c)
        d = np.gradient(c, axis=0)
        nrm = np.stack([-d[:, 1], d[:, 0]], axis=1)
        nrm /= (np.linalg.norm(nrm, axis=1, keepdims=True) + 1e-9)
        w = np.asarray(width, float)[:, None]
        top = c + nrm * w / 2
        bot = c - nrm * w / 2
        base = self.add(list(top) + list(bot), col, lift, tag)
        for i in range(n - 1):
            self.F.append((base + i, base + i + 1, base + n + i + 1, base + n + i))
        return base, n


def _almond(a, b, tilt_deg, outer_sign, samples=20, upper=1.0, lower=0.62):
    """Eye outline (samples,2) in local coords centred on the eye: u along the width (+ = outer corner), v up."""
    th = np.linspace(0, 2 * math.pi, samples, endpoint=False)
    u = np.cos(th) * a
    s = np.sin(th)
    v = np.where(s >= 0, b * upper * np.abs(s) ** 0.85, -b * lower * np.abs(s))
    v = v * (1.0 + 0.10 * np.where(s >= 0, -np.cos(th), 0.0))   # the upper lid peaks towards the inner third
    vv = v + u * math.sin(math.radians(tilt_deg))               # outer corner up
    return np.stack([u * outer_sign, vv], axis=1)


class Face:
    def __init__(self, L, surf, eye_hex, brow_hex, lash_hex, skin_hex, lip_hex):
        self.L, self.surf = L, surf
        H = L.H
        self.H = H
        self.face_w = 2 * L.head * H
        self.ew = L.eye_w * self.face_w * L.eye_scale          # eye width
        self.eh = self.ew * L.eye_hr                            # eye height
        self.cz = LY.Z[LY.EYE_RING] * H + 0.001 * H
        self.cx = self.ew * 1.0                                 # centre-to-centre = 2 eye widths ("one eye-width apart")
        self.eye, self.brow, self.lash = hex_lin(eye_hex), hex_lin(brow_hex), hex_lin(lash_hex)
        self.lip = hex_lin(lip_hex)
        self.skin = hex_lin(skin_hex)

    # ----- eyes ----------------------------------------------------------------------------------------------
    def eyes(self):
        L = self.L
        P = Patch()
        a, b = self.ew / 2, self.eh / 2
        tilt = 7.0 if L.female else 5.0
        sides = {}
        for sx, name in ((1, "L"), (-1, "R")):
            cx = sx * self.cx
            out = _almond(a, b, tilt, sx)
            cen = np.array([cx, self.cz])
            pts = out + cen
            # sclera (white, a little blue-grey in the corners so it never reads as a hole)
            s0 = len(P.uv)
            P.disc(pts, (0.93, 0.93, 0.96), 0.0010, 3, "sclera" + name)
            # iris: an ellipse clipped to the lid outline
            ri_x, ri_y = a * 0.62, b * 0.92
            th = np.linspace(0, 2 * math.pi, 20, endpoint=False)
            ix = np.cos(th) * ri_x
            iy = np.sin(th) * ri_y + b * 0.06
            top = np.max(out[:, 1]) * 0.97
            bot = np.min(out[:, 1]) * 0.93
            iy = np.clip(iy, bot, top - 0.0)
            iris = np.stack([ix * sx * 1.0, iy], axis=1) + cen + np.array([-sx * a * 0.02, 0])
            P.disc(iris, self.eye, 0.0016, 3, "iris" + name)
            # darker lower half of the iris (a painted gradient: lower ring a lighter, upper a deeper tone)
            pup = np.stack([np.cos(th) * ri_x * 0.36 * sx, np.sin(th) * ri_y * 0.40 + b * 0.04], axis=1) + cen
            P.disc(pup, (0.05, 0.04, 0.07), 0.0021, 2, "pupil" + name)
            # two highlights: upper-outer large, lower-inner small
            h1 = np.stack([np.cos(th) * a * 0.17 * sx, np.sin(th) * b * 0.28], axis=1) + cen + np.array([sx * a * 0.20, b * 0.34])
            h2 = np.stack([np.cos(th) * a * 0.08 * sx, np.sin(th) * b * 0.13], axis=1) + cen + np.array([-sx * a * 0.22, -b * 0.30])
            P.disc(h1, (1.0, 1.0, 1.0), 0.0026, 2, "hi1" + name)
            P.disc(h2, (1.0, 1.0, 1.0), 0.0026, 1, "hi2" + name)
            # upper lash line: thick at the outer corner, dark and coloured from the hair hue
            n = 14
            tt = np.linspace(0, 1, n)           # inner -> outer
            ang = math.pi - tt * math.pi * 0.90
            lx = np.cos(ang) * a * 1.02
            ly = b * np.abs(np.sin(ang)) ** 0.85 * 1.02
            ly = ly * (1.0 + 0.10 * (-np.cos(ang)))
            t_ = math.radians(tilt)
            ly = ly + lx * math.sin(t_)
            wid = b * (0.10 + 0.16 * tt ** 1.5)
            if L.female:
                wid = wid * 1.15
            cl = np.stack([lx * sx, ly], axis=1) + cen
            if L.female:   # a small flick at the outer corner
                cl = np.vstack([cl, cl[-1] + np.array([sx * a * 0.18, b * 0.16])])
                wid = np.concatenate([wid, [wid[-1] * 0.25]])
            P.ribbon(cl, wid, self.lash, 0.0031, "lash" + name)
            # a fine lower lid line
            ang2 = np.linspace(math.pi * 0.90, math.pi * 0.10, 8)
            lx2 = np.cos(ang2) * a * 0.92
            ly2 = -b * 0.62 * np.abs(np.sin(ang2)) + lx2 * math.sin(t_) - b * 0.04
            P.ribbon(np.stack([lx2 * sx, ly2], axis=1) + cen, np.full(8, b * 0.05), self.lash, 0.0027, "lower" + name)
        return P

    # ----- brows ----------------------------------------------------------------------------------------------
    def brows(self):
        L = self.L
        P = Patch()
        a, b = self.ew / 2, self.eh / 2
        for sx, name in ((1, "L"), (-1, "R")):
            n = 9
            t = np.linspace(0, 1, n)    # inner -> outer
            u = sx * (self.cx - a * 1.0 + t * (a * 2.25))
            arch = 0.30 * b * np.sin(t * math.pi * 0.85)
            v = self.cz + b * 1.55 + arch - L.brow_drop * self.H - (0.0 if L.female else b * 0.12) + (t ** 2) * b * (-0.30)
            w = self.ew * (0.16 - 0.08 * t ** 1.5) * (1.1 if not L.female else 0.9)
            P.ribbon(np.stack([u, v], axis=1), w, self.brow, 0.0022, "brow" + name)
        return P

    # ----- mouth --------------------------------------------------------------------------------------------
    def mouth(self):
        L = self.L
        P = Patch()
        half = self.ew * 0.55
        n = 9
        t = np.linspace(-1, 1, n)
        cz = LY.Z[17] * self.H - 0.0035 * self.H
        x = t * half
        z = cz + 0.0026 * self.H * (t ** 2)      # a soft smile: the corners lift
        w = 0.0022 * self.H * (1.0 - 0.5 * np.abs(t) ** 2)
        P.ribbon(np.stack([x, z], axis=1), w, self.lip, 0.0018, "mouth")
        # lower lip: a softer, lighter band under the mouth line so the mouth has a body and catches the light
        lo_w = np.full(n, 0.0030 * self.H) * (1.0 - 0.55 * np.abs(t) ** 1.6)
        lo_c = tuple(min(1.0, c * 1.12 + 0.03) for c in self.lip)
        P.ribbon(np.stack([x * 0.92, z - 0.0034 * self.H + 0.0012 * self.H * (t ** 2)], axis=1), lo_w, lo_c, 0.0015, "lip_lower")
        # a small nose tick under the nose tip
        nz = LY.Z[18] * self.H - 0.0075 * self.H
        nt = np.linspace(-1, 1, 5)
        P.ribbon(np.stack([nt * 0.0055 * self.H, nz - 0.0012 * self.H * (1 - nt ** 2)], axis=1), np.full(5, 0.0013 * self.H), tuple(c * 0.55 for c in self.skin), 0.0016, "nose")
        return P, half, cz


def bake(P, surf, skin_cols=None):
    """Projects a Patch onto the head. Returns (V, F, colours)."""
    V = np.array([surf.project(u, v, lift) for (u, v), lift in zip(P.uv, P.lift)])
    return V, P.F, np.array(P.col)


# ----- ears ------------------------------------------------------------------------------------------------------
def ear_mesh(L, side, skin_hex, rng):
    """A small scooped ear on the head's side (side +1 left, -1 right). Returns V, F, colours, weights."""
    H = L.H
    cx = side * (L.head * H * 1.005)
    cz = LY.Z[LY.EYE_RING] * H - 0.004 * H
    cy = 0.004 * H
    length = L.ears_scale
    ry, rz, rx = 0.0140 * H, 0.0265 * H * length, 0.0062 * H
    segs, rings = 12, 7
    V, F, C = [], [], []
    skin = np.array(hex_lin(skin_hex))
    inner = skin * np.array([0.82, 0.62, 0.60])
    for i in range(rings + 1):
        v = -math.pi / 2 + math.pi * i / rings
        for j in range(segs):
            u = 2 * math.pi * j / segs
            cu = math.cos(v) * math.cos(u)
            x = rx * (cu * 0.35 + 0.65 * max(cu, 0.0))
            y = ry * math.cos(v) * math.sin(u)
            z = rz * math.sin(v)
            # flare: the ear stands off the head a little more at the top, and tilts back
            tip = max(0.0, (L.ears_scale - 1.0)) * 0.9
            if z > 0:
                y += z * (0.18 + 0.7 * tip)
                x += z * 0.20 * (1 + tip)
            xo = side * (x + rx * 1.1)
            V.append((cx + xo, cy + y, cz + z))
            C.append(tuple(inner if math.cos(v) * math.cos(u) > 0.55 else skin))
    idx = lambda i, j: i * segs + j % segs
    for i in range(rings):
        for j in range(segs):
            F.append((idx(i, j), idx(i, j + 1), idx(i + 1, j + 1), idx(i + 1, j)))
    return np.array(V), F, np.array(C)
