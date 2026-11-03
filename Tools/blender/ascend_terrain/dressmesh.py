"""Blender side of the dressing: turns a Dressing (dress.py) into a few merged, vertex-coloured meshes in the toon preview
look (two-tone ramp + inverted-hull ink outline), all as a layer on top of the terrain.

Buildings are the real Brindlewick kit (town_buildings.BUILDERS: house_*, clock_tower, town_gate, guard_tower, windmill,
barn, farmhouse, ...) read straight from its Part meshes (no Blender objects are created for them); trees, rocks, reeds,
flowers, laundry, fields and the lighthouse are small procedural templates built here. Roofs and plaster get per-house colour
variants. Lamps (the kit's 'lamp' faces) and the lighthouse lamp go to a separate emission mesh so they glow in their own hue.

Everything is built in Blender world coordinates: x = map x, y = -map y, z = ground height * zscale (zscale is the picture-only
vertical stretch; the saved .blend uses 1). `k` scales the dressing for the 10 km pictures (a 7 m tree is 1 px there);
at 1 the dressing is true size.
"""
import math

import bmesh
import bpy
import numpy as np

from .dress import Sampler
from .noise import smoothstep
from .tile import srgb_to_linear

PREFIX = "Dress_"
PATH_COLS = {"cobble": ((0.847, 0.812, 0.737), (0.784, 0.749, 0.671)), "paved": ((0.70, 0.70, 0.74), (0.62, 0.62, 0.67)), "gravel": ((0.90, 0.84, 0.68), (0.84, 0.77, 0.61)), "dirt": ((0.80, 0.68, 0.46), (0.74, 0.62, 0.42))}
_KIT = {}
ROOFS = ["roof_red", "roof_blue", "roof_orange", "roof_green", "roof_teal", "roof_purple"]
PLASTERS = ["plaster", "plaster_warm", "plaster_pink", "plaster_blue", "plaster_mint"]
LEAF_ROUND = (0.34, 0.66, 0.29)       # base sRGB of a round tree; lobes derive from it
LEAF_CONIFER = (0.22, 0.46, 0.34)


def _rgb(h):
    h = h.lstrip("#")
    return tuple(int(h[i:i + 2], 16) / 255.0 for i in (0, 2, 4))


# ----------------------------------------------------------------------------------------------------------------
# Template arithmetic

class Tpl:
    """Mesh template: V (n,3), F (m,3), R role per vertex, colours (nroles,3) sRGB default, shared normals computed on demand."""

    def __init__(self, V, F, R, colours, keys=None):
        self.V = np.asarray(V, dtype=np.float64)
        self.F = np.asarray(F, dtype=np.int64)
        self.R = np.asarray(R, dtype=np.int64)
        self.colours = np.asarray(colours, dtype=np.float64)
        self.keys = keys
        self._N = None

    @property
    def N(self):
        if self._N is None:
            self._N = vertex_normals(self.V, self.F)
        return self._N

    @property
    def height(self):
        return float(self.V[:, 2].max())


def vertex_normals(V, F):
    fn = np.cross(V[F[:, 1]] - V[F[:, 0]], V[F[:, 2]] - V[F[:, 0]])
    N = np.zeros_like(V)
    for k in range(3):
        np.add.at(N, F[:, k], fn)
    L = np.linalg.norm(N, axis=1, keepdims=True)
    return N / np.maximum(L, 1e-12)


def _ico(sub=1):
    p = (1 + 5 ** 0.5) / 2
    V = [(-1, p, 0), (1, p, 0), (-1, -p, 0), (1, -p, 0), (0, -1, p), (0, 1, p), (0, -1, -p), (0, 1, -p), (p, 0, -1), (p, 0, 1), (-p, 0, -1), (-p, 0, 1)]
    F = [(0, 11, 5), (0, 5, 1), (0, 1, 7), (0, 7, 10), (0, 10, 11), (1, 5, 9), (5, 11, 4), (11, 10, 2), (10, 7, 6), (7, 1, 8),
         (3, 9, 4), (3, 4, 2), (3, 2, 6), (3, 6, 8), (3, 8, 9), (4, 9, 5), (2, 4, 11), (6, 2, 10), (8, 6, 7), (9, 8, 1)]
    V = [np.array(v, dtype=np.float64) / np.linalg.norm(v) for v in V]
    for _ in range(sub):
        cache, F2 = {}, []

        def mid(a, b):
            key = (min(a, b), max(a, b))
            if key not in cache:
                m = (V[a] + V[b]) / 2
                V.append(m / np.linalg.norm(m))
                cache[key] = len(V) - 1
            return cache[key]
        for a, b, c in F:
            ab, bc, ca = mid(a, b), mid(b, c), mid(c, a)
            F2 += [(a, ab, ca), (b, bc, ab), (c, ca, bc), (ab, bc, ca)]
        F = F2
    return np.array(V), np.array(F)


ICO0, ICO1 = _ico(0), _ico(1)


def _sphere(c, radii, role, sub=1):
    V, F = ICO1 if sub else ICO0
    return V * np.array(radii) + np.array(c), F, np.full(len(V), role)


def _frustum(r0, r1, h, sides, z0=0.0, role=0, c=(0, 0), top_role=None, cap=True, rot=0.0):
    """Side wall (r0 at z0 to r1 at z0+h) with a bottom cap and a top cap/apex; sharing vertices."""
    a = np.arange(sides) / sides * 2 * math.pi + rot
    V = [(c[0] + r0 * np.cos(a)[i], c[1] + r0 * np.sin(a)[i], z0) for i in range(sides)]
    R = [role] * sides
    if r1 > 1e-6:
        V += [(c[0] + r1 * np.cos(a)[i], c[1] + r1 * np.sin(a)[i], z0 + h) for i in range(sides)]
        R += [role if top_role is None else top_role] * sides
        F = []
        for i in range(sides):
            j = (i + 1) % sides
            F += [(i, j, sides + j), (i, sides + j, sides + i)]
        if cap:
            V.append((c[0], c[1], z0 + h))
            R.append(role if top_role is None else top_role)
            F += [(sides + i, sides + (i + 1) % sides, 2 * sides) for i in range(sides)]
    else:
        V.append((c[0], c[1], z0 + h))
        R.append(role if top_role is None else top_role)
        F = [(i, (i + 1) % sides, sides) for i in range(sides)]
    nb = len(V)
    V.append((c[0], c[1], z0))
    R.append(role)
    F += [((i + 1) % sides, i, nb) for i in range(sides)]
    return np.array(V, dtype=np.float64), np.array(F), np.array(R)


def _box(c, size, role, rot=0.0):
    sx, sy, sz = size[0] / 2, size[1] / 2, size[2] / 2
    V = np.array([(-sx, -sy, -sz), (sx, -sy, -sz), (sx, sy, -sz), (-sx, sy, -sz), (-sx, -sy, sz), (sx, -sy, sz), (sx, sy, sz), (-sx, sy, sz)], dtype=np.float64)
    F = np.array([(0, 2, 1), (0, 3, 2), (4, 5, 6), (4, 6, 7), (0, 1, 5), (0, 5, 4), (1, 2, 6), (1, 6, 5), (2, 3, 7), (2, 7, 6), (3, 0, 4), (3, 4, 7)])
    cs, sn = math.cos(rot), math.sin(rot)
    V = V @ np.array([[cs, sn, 0], [-sn, cs, 0], [0, 0, 1]]) + np.array(c)
    return V, F, np.full(8, role)


def _merge(parts):
    V, F, R, o = [], [], [], 0
    for v, f, r in parts:
        V.append(v)
        F.append(f + o)
        R.append(r)
        o += len(v)
    return np.concatenate(V), np.concatenate(F), np.concatenate(R)


def _tilt(V, c, ax, ay):
    """Rotate about point c by ax (about x) then ay (about y)."""
    ca, sa, cb, sb = math.cos(ax), math.sin(ax), math.cos(ay), math.sin(ay)
    Rx = np.array([[1, 0, 0], [0, ca, -sa], [0, sa, ca]])
    Ry = np.array([[cb, 0, sb], [0, 1, 0], [-sb, 0, cb]])
    return (V - c) @ (Rx.T @ Ry.T) + c


def _tpl_tree_round():
    parts = [_frustum(0.78, 0.46, 0.6, 7, 0.0, 0), _frustum(0.46, 0.30, 2.6, 7, 0.5, 0),
             _sphere((0, 0, 3.3), (2.7, 2.7, 2.1), 1), _sphere((1.0, 0.5, 4.5), (2.1, 2.1, 1.75), 2), _sphere((-0.6, -0.4, 5.6), (1.55, 1.55, 1.35), 3)]
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#7A5538"), (0, 0, 0), (0, 0, 0), (0, 0, 0)])


def _tpl_tree_conifer():
    parts = [_frustum(0.5, 0.28, 1.8, 6, 0.0, 0), _frustum(2.3, 0.0, 3.5, 8, 1.0, 1), _frustum(1.8, 0.0, 3.2, 8, 2.9, 1),
             _frustum(1.25, 0.0, 3.0, 8, 4.6, 2), _frustum(0.7, 0.0, 2.6, 8, 6.1, 3)]
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#6B4A32"), (0, 0, 0), (0, 0, 0), (0, 0, 0)])


def _tpl_snag():
    parts = [_frustum(0.55, 0.35, 0.5, 6, 0.0, 0), _frustum(0.35, 0.1, 5.2, 6, 0.4, 0)]
    for i, (z, a) in enumerate(((3.0, 0.4), (4.0, 2.6), (4.6, 4.3))):
        V, F, R = _frustum(0.1, 0.03, 1.7, 4, 0.0, 0)
        V = _tilt(V, np.zeros(3), 0.0, 0.0)
        V = _tilt(V, np.zeros(3), 1.0, 0.0)
        cs, sn = math.cos(a), math.sin(a)
        V = V @ np.array([[cs, sn, 0], [-sn, cs, 0], [0, 0, 1]]) + np.array([0, 0, z])
        parts.append((V, F, R))
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#6E5C4C")])


def _tpl_rock(sub=0, seedv=0):
    V, F = ICO1 if sub else ICO0
    rng = np.random.RandomState(7 + seedv)
    f = 0.82 + 0.34 * rng.rand(len(V))
    V = V * f[:, None] * np.array([1.0, 0.9, 0.66])
    V[:, 2] -= 0.12
    R = (V[:, 2] > 0.1).astype(int)
    return Tpl(V, F, R, [_rgb("#8C8880"), _rgb("#B2AEA2")])


def _tpl_reed():
    parts = []
    for i, (h, a, lean) in enumerate(((1.5, 0.2, 0.18), (1.9, 1.5, 0.12), (1.2, 2.7, 0.25), (1.7, 3.8, 0.15), (1.35, 5.0, 0.2), (1.1, 6.0, 0.3))):
        V, F, R = _frustum(0.05, 0.0, h, 3, 0.0, 0)
        R = np.where(V[:, 2] > h * 0.5, 1, 0)
        V = _tilt(V, np.zeros(3), lean, 0.0)
        cs, sn = math.cos(a), math.sin(a)
        V = V @ np.array([[cs, sn, 0], [-sn, cs, 0], [0, 0, 1]]) + np.array([0.25 * math.cos(a), 0.25 * math.sin(a), 0])
        parts.append((V, F, R))
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#6E8A3C"), _rgb("#C9B66A")])


def _tpl_flower():
    parts = [_sphere((0, 0, 0.0), (1.2, 1.2, 0.35), 1, 0)]
    rng = np.random.RandomState(3)
    for i in range(8):
        a, r = rng.rand() * 6.28, 0.9 * rng.rand() ** 0.5
        parts.append(_sphere((r * math.cos(a), r * math.sin(a), 0.38 + 0.12 * rng.rand()), (0.14, 0.14, 0.12), 0, 0))
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#FFD54A"), _rgb("#5FA447")])


def _tpl_laundry():
    parts = [_frustum(0.07, 0.06, 2.3, 4, 0.0, 0, (-2.2, 0)), _frustum(0.07, 0.06, 2.3, 4, 0.0, 0, (2.2, 0)), _box((0, 0, 2.15), (4.4, 0.03, 0.03), 1)]
    for i, x in enumerate((-1.5, -0.5, 0.55, 1.55)):
        parts.append(_box((x, 0, 1.6 + 0.1 * (i % 2)), (0.7, 0.04, 0.95 - 0.15 * (i % 2)), 2 + i))
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#6B4A32"), _rgb("#C9BFA8"), _rgb("#F4EEDD"), _rgb("#5B8FD8"), _rgb("#E8564A"), _rgb("#F7C6D6")])


def _tpl_barrel():
    V, F, R = _merge([_frustum(0.4, 0.4, 0.95, 8, 0.0, 0), _frustum(0.43, 0.43, 0.08, 8, 0.2, 1), _frustum(0.43, 0.43, 0.08, 8, 0.67, 1)])
    return Tpl(V, F, R, [_rgb("#9A6A3E"), _rgb("#4A4A52")])


def _tpl_crate():
    V, F, R = _box((0, 0, 0.4), (0.8, 0.8, 0.8), 0)
    V2, F2, R2 = _box((0.5, 0.6, 0.28), (0.55, 0.55, 0.55), 0)
    V, F, R = _merge([(V, F, R), (V2, F2, R2)])
    return Tpl(V, F, R, [_rgb("#A87C4A")])


def _tpl_butte():
    parts = [_frustum(15.0, 12.0, 9.0, 9, -2.0, 0), _frustum(12.0, 9.5, 8.0, 9, 7.0, 1, rot=0.3), _frustum(9.5, 8.2, 6.5, 9, 15.0, 2, rot=0.6), _frustum(8.2, 6.0, 2.2, 9, 21.5, 3, rot=0.2)]
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#C98F5A"), _rgb("#B7774A"), _rgb("#D7A56E"), _rgb("#A5683E")])


def _tpl_lighthouse():
    parts = [_frustum(3.4, 2.5, 7.0, 10, 0.0, 0), _frustum(2.5, 2.3, 4.0, 10, 7.0, 1), _frustum(2.3, 2.1, 4.0, 10, 11.0, 0), _frustum(2.1, 1.9, 3.0, 10, 15.0, 1),
             _frustum(3.2, 3.2, 0.7, 10, 18.0, 2), _frustum(1.9, 1.7, 0.4, 10, 17.9, 2), _frustum(2.2, 0.0, 2.6, 10, 21.6, 1, top_role=1),
             _frustum(3.9, 3.9, 1.0, 8, 0.0, 3)]
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#F2EEE4"), _rgb("#D9453A"), _rgb("#4A4650"), _rgb("#A8A296")])


def _tpl_lamp_glass():
    V, F, R = _frustum(1.5, 1.5, 2.6, 10, 18.7, 0)
    return Tpl(V, F, R, [_rgb("#FFD25A")])


def _tpl_grass():
    parts = []
    rng = np.random.RandomState(11)
    for i in range(5):
        a = rng.rand() * 6.28
        w = 0.05
        h = 0.34 + 0.3 * rng.rand()
        bend = (0.08 + 0.12 * rng.rand())
        base = np.array([0.1 * math.cos(a) * rng.rand(), 0.1 * math.sin(a) * rng.rand(), 0.0])
        dx, dy = math.cos(a + 1.57), math.sin(a + 1.57)
        tip = base + np.array([math.cos(a) * bend, math.sin(a) * bend, h])
        V = np.array([base + (w * dx, w * dy, 0), base - (w * dx, w * dy, 0), tip])
        parts.append((V, np.array([(0, 1, 2)]), np.array([0, 0, 1])))
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#6FB04E"), _rgb("#B4E27C")])


def _tpl_cart():
    parts = [_box((0, 0, 0.75), (2.6, 1.3, 0.3), 0), _box((0, 0.62, 1.05), (2.6, 0.08, 0.5), 0), _box((0, -0.62, 1.05), (2.6, 0.08, 0.5), 0),
             _box((-1.25, 0, 1.05), (0.08, 1.3, 0.5), 0), _box((1.25, 0, 1.05), (0.08, 1.3, 0.5), 0),
             _box((0.9, 0.78, 0.5), (1.0, 0.12, 1.0), 1), _box((0.9, -0.78, 0.5), (1.0, 0.12, 1.0), 1), _box((0.9, 0.78, 0.5), (0.7, 0.14, 0.7), 4), _box((0.9, -0.78, 0.5), (0.7, 0.14, 0.7), 4),
             _box((-2.2, 0, 0.7), (1.8, 0.07, 0.07), 0), _sphere((0, 0, 1.45), (1.1, 0.55, 0.45), 2, 1), _sphere((-0.5, 0.1, 1.7), (0.6, 0.4, 0.3), 3, 1),
             _box((-1.6, 0.5, 0.95), (0.5, 0.5, 0.5), 5)]
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#9A6A3E"), _rgb("#5A3E2A"), _rgb("#E3C66E"), _rgb("#F0D98A"), _rgb("#B59468"), _rgb("#C98A4A")])


def _tpl_planter():
    parts = [_box((0, 0, 0.3), (1.7, 0.5, 0.5), 0), _box((0, 0, 0.58), (1.55, 0.4, 0.1), 1)]
    rng = np.random.RandomState(5)
    for i in range(7):
        parts.append(_sphere((-0.7 + i * 0.23, 0.05 * (rng.rand() - 0.5), 0.78 + 0.1 * rng.rand()), (0.16, 0.16, 0.14), 2 + i % 3, 0))
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#8A5A34"), _rgb("#4F8C3E"), _rgb("#FFF4E0"), _rgb("#FF8FB5"), _rgb("#FFD54A")])


def _tpl_tuft():
    parts = []
    rng = np.random.RandomState(21)
    for i in range(9):
        a = rng.rand() * 6.28
        w = 0.07
        h = 0.55 + 0.55 * rng.rand()
        bend = 0.1 + 0.2 * rng.rand()
        base = np.array([0.18 * math.cos(a) * rng.rand(), 0.18 * math.sin(a) * rng.rand(), 0.0])
        dx, dy = math.cos(a + 1.57), math.sin(a + 1.57)
        tip = base + np.array([math.cos(a) * bend, math.sin(a) * bend, h])
        V = np.array([base + (w * dx, w * dy, 0), base - (w * dx, w * dy, 0), tip])
        parts.append((V, np.array([(0, 1, 2)]), np.array([0, 0, 1])))
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#5FA447"), _rgb("#A9DC6E")])


def _tpl_wagon():
    parts = [_box((0, 0, 1.0), (4.2, 1.9, 0.35), 0), _box((1.3, 1.0, 0.7), (1.3, 0.16, 1.3), 1), _box((1.3, -1.0, 0.7), (1.3, 0.16, 1.3), 1),
             _box((-1.3, 1.0, 0.7), (1.3, 0.16, 1.3), 1), _box((-1.3, -1.0, 0.7), (1.3, 0.16, 1.3), 1),
             _sphere((0, 0, 1.4), (2.0, 1.0, 1.15), 2, 1), _box((0, 0, 1.35), (1.8, 2.0, 0.5), 3), _box((2.9, 0, 0.85), (1.6, 0.1, 0.1), 0)]
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#8A6038"), _rgb("#4F3A2A"), _rgb("#F0E6D1"), _rgb("#248CA8")])


def _tpl_tent():
    parts = [_frustum(3.0, 3.1, 0.9, 6, 0.0, 1), _frustum(3.1, 0.25, 3.0, 6, 0.9, 0, top_role=0), _box((0, -2.5, 1.0), (1.4, 0.2, 1.8), 2)]
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#F0E6D1"), _rgb("#248CA8"), _rgb("#6B4A32")])


def _tpl_fence():
    parts = [_box((-1.15, 0, 0.5), (0.14, 0.14, 1.0), 0), _box((1.15, 0, 0.5), (0.14, 0.14, 1.0), 0), _box((0, 0, 0.78), (2.4, 0.08, 0.12), 1), _box((0, 0, 0.42), (2.4, 0.08, 0.12), 1)]
    V, F, R = _merge(parts)
    return Tpl(V, F, R, [_rgb("#7A5636"), _rgb("#B58B5A")])


def _tpl_slab():
    V, F, R = _merge([_box((0, 0, 0.1), (1.4, 1.0, 0.2), 0, rot=0.3)])
    return Tpl(V, F, R, [_rgb("#BDB6A8")])


TEMPLATES = {}


def templates():
    if not TEMPLATES:
        TEMPLATES.update(tree_round=_tpl_tree_round(), tree_conifer=_tpl_tree_conifer(), snag=_tpl_snag(), rock=_tpl_rock(0), boulder=_tpl_rock(1, 2),
                         reed=_tpl_reed(), flower=_tpl_flower(), laundry=_tpl_laundry(), barrel=_tpl_barrel(), crate=_tpl_crate(),
                         butte=_tpl_butte(), lighthouse=_tpl_lighthouse(), lamp_glass=_tpl_lamp_glass(), grass=_tpl_grass(),
                         cart=_tpl_cart(), planter=_tpl_planter(), tuft=_tpl_tuft(), wagon=_tpl_wagon(), tent=_tpl_tent(), fence=_tpl_fence(), slab=_tpl_slab())
    return TEMPLATES


# ----------------------------------------------------------------------------------------------------------------
# The Brindlewick kit

def kit(key):
    """-> (body Tpl, glow Tpl or None) for a town_buildings.BUILDERS key; unshared vertices, flat colour roles."""
    if key in _KIT:
        return _KIT[key]
    import town_buildings as TB
    part = TB.BUILDERS[key]()
    bm = part.bm
    bmesh.ops.triangulate(bm, faces=bm.faces[:])
    keys = list(part.keys)
    V, R, Rg = [], [], []
    for f in bm.faces:
        k = keys[f.material_index] if f.material_index < len(keys) else keys[0]
        for v in f.verts:
            V.append(tuple(v.co))
        R += [keys.index(k)] * 3
    bm.free()
    V = np.array(V, dtype=np.float64).reshape(-1, 3)
    R = np.array(R, dtype=np.int64)
    F = np.arange(len(V)).reshape(-1, 3)
    glow_keys = {i for i, k in enumerate(keys) if TB.PALETTE.get(k, ((0, 0, 0), 0, 0))[2] > 0}
    cols = [TB.PALETTE[k][0] for k in keys]
    isg = np.array([R[3 * i] in glow_keys for i in range(len(F))])
    body = Tpl(V.reshape(-1, 3)[np.repeat(~isg, 3)], np.arange(int((~isg).sum()) * 3).reshape(-1, 3), R[np.repeat(~isg, 3)], cols, keys)
    glow = Tpl(V[np.repeat(isg, 3)], np.arange(int(isg.sum()) * 3).reshape(-1, 3), R[np.repeat(isg, 3)], cols, keys) if isg.any() else None
    _KIT[key] = (body, glow)
    return _KIT[key]


ALD_SLATES = [(0.30, 0.34, 0.44), (0.36, 0.40, 0.52), (0.26, 0.30, 0.40), (0.42, 0.46, 0.57)]
ALD_ROYAL, ALD_GOLD = (0.16, 0.31, 0.78), (0.96, 0.76, 0.30)
ALD_WALLS = ["plaster", "plaster_blue", "stone", "plaster", "plaster_blue"]


def _aldmere_cols(tpl, var):
    """art_direction 2.2: one accent per district. Aldmere = slate roofs, cool stone and plaster walls, royal blue and gold accents only."""
    import town_buildings as TB
    cols = tpl.colours.copy()
    v = var - 10.0
    v1, v2, v3 = (v * 7.31) % 1.0, (v * 3.77 + 0.31) % 1.0, (v * 5.13 + 0.17) % 1.0
    for i, k in enumerate(tpl.keys):
        if k.startswith("roof_") or k in ("slate", "thatch", "straw", "hay"):
            cols[i] = np.array(ALD_ROYAL if v3 < 0.10 else ALD_SLATES[int(v1 * 4) % 4])
        elif k.startswith("plaster"):
            cols[i] = TB.PALETTE[ALD_WALLS[int(v2 * 5) % 5]][0]
        elif k in ("orange", "apple", "ember", "cloth_yellow", "flower_yellow", "flower_red", "magic"):
            cols[i] = np.array(ALD_GOLD)
        elif k in ("cloth_red", "banner_red", "cloth_green", "cloth_purple", "cloth_blue", "banner_blue", "flower_pink", "flower_blue"):
            cols[i] = np.array(ALD_ROYAL)
        elif k == "door" and v3 > 0.55:
            cols[i] = np.array(ALD_ROYAL if v3 < 0.8 else ALD_GOLD)
    return cols


def kit_colours(tpl, var):
    """Per-instance colour table for a kit template: roofs and plaster take a variant (variant >= 10: the Aldmere palette)."""
    if var >= 10.0 and tpl.keys:
        return _aldmere_cols(tpl, var)
    cols = tpl.colours.copy()
    import town_buildings as TB
    v1, v2 = (var * 7.31) % 1.0, (var * 3.77 + 0.31) % 1.0
    for i, k in enumerate(tpl.keys):
        if k.startswith("roof_"):
            cols[i] = TB.PALETTE[ROOFS[int(v1 * len(ROOFS)) % len(ROOFS)]][0]
        elif k.startswith("plaster"):
            cols[i] = TB.PALETTE[PLASTERS[int(v2 * len(PLASTERS)) % len(PLASTERS)]][0]
    return cols


# ----------------------------------------------------------------------------------------------------------------
# Accumulation

class Acc:
    def __init__(self):
        self.V, self.F, self.C, self.o = [], [], [], 0

    def add(self, V, F, C):
        self.V.append(V)
        self.F.append(F + self.o)
        self.C.append(C)
        self.o += len(V)

    def arrays(self):
        if not self.V:
            return np.zeros((0, 3)), np.zeros((0, 3), dtype=np.int64), np.zeros((0, 3))
        return np.concatenate(self.V), np.concatenate(self.F), np.concatenate(self.C)

    def __len__(self):
        return self.o


def emit(acc, tpl, pos, yaw, scale, tables):
    """Instance tpl n times. pos (n,3) Blender world, yaw (n) about +Z, scale (n), tables (n, nroles, 3) sRGB or None."""
    pos, yaw, scale = np.atleast_2d(pos).astype(np.float64), np.atleast_1d(yaw), np.atleast_1d(scale)
    tables = None if tables is None else np.asarray(tables, dtype=np.float64)
    n, nv = len(pos), len(tpl.V)
    c, s = np.cos(yaw), np.sin(yaw)
    Vx = tpl.V[None, :, 0] * scale[:, None]
    Vy = tpl.V[None, :, 1] * scale[:, None]
    Vz = tpl.V[None, :, 2] * scale[:, None]
    X = Vx * c[:, None] - Vy * s[:, None] + pos[:, 0:1]
    Y = Vx * s[:, None] + Vy * c[:, None] + pos[:, 1:2]
    Z = Vz + pos[:, 2:3]
    V = np.stack([X, Y, Z], -1).reshape(-1, 3)
    F = (tpl.F[None] + (np.arange(n) * nv)[:, None, None]).reshape(-1, 3)
    if tables is None:
        tables = np.broadcast_to(tpl.colours[None], (n,) + tpl.colours.shape)
    C = np.take_along_axis(np.asarray(tables, dtype=np.float64), np.broadcast_to(tpl.R[None, :, None], (n, nv, 1)), axis=1) \
        if tables.shape[1] > tpl.R.max() else None
    acc.add(V, F, C.reshape(-1, 3))


def _tint(base, t, lit=1.0, warm=0.0, cool=0.0):
    c = np.array(base) * (0.93 + 0.14 * t[:, None])
    c = c * lit + np.array([warm, warm * 0.5, -warm * 0.5]) - np.array([cool * 0.4, cool * 0.1, -cool * 0.2])
    return np.clip(c, 0, 1)


def tree_tables(kind, tint):
    """(n, 4, 3) role colours: trunk, low lobe (cool, in shade), middle, top lobe (15 % lighter, warmer)."""
    n = len(tint)
    out = np.zeros((n, 4, 3))
    if kind == "round":
        b = _tint(LEAF_ROUND, tint)
        hue = (tint[:, None] - 0.5) * np.array([0.06, -0.02, 0.0])          # a little yellow/blue spread between trees
        b = np.clip(b + hue, 0, 1)
        out[:, 0] = _rgb("#7A5538")
        out[:, 1] = np.clip(b * np.array([0.84, 0.94, 0.98]), 0, 1)
        out[:, 2] = b
        out[:, 3] = np.clip(b * 1.15 + np.array([0.035, 0.02, -0.02]), 0, 1)
    else:
        b = _tint(LEAF_CONIFER, tint)
        out[:, 0] = _rgb("#6B4A32")
        out[:, 1] = np.clip(b * np.array([0.86, 0.95, 1.0]), 0, 1)
        out[:, 2] = b
        out[:, 3] = np.clip(b * 1.15 + np.array([0.03, 0.025, -0.01]), 0, 1)
    return out


# ----------------------------------------------------------------------------------------------------------------
# Blender objects

def _srgb_lin(C):
    return srgb_to_linear(np.clip(C, 0, 1))


def _weld_normals(V, N):
    key = np.round(V * 50.0).astype(np.int64)
    _, inv = np.unique(key, axis=0, return_inverse=True)
    inv = inv.reshape(-1)
    acc = np.zeros((inv.max() + 1, 3))
    np.add.at(acc, inv, N)
    L = np.linalg.norm(acc, axis=1, keepdims=True)
    return (acc / np.maximum(L, 1e-12))[inv]


def make_mesh(name, V, F, C, smooth, mat, coll, outline_mat=None, thick=0.0, normals=None):
    objs = []
    if len(F) == 0:
        return objs

    def build(nm, V_, F_, C_, mt, sm):
        me = bpy.data.meshes.new(nm)
        me.vertices.add(len(V_))
        me.vertices.foreach_set("co", V_.astype(np.float32).ravel())
        me.loops.add(len(F_) * 3)
        me.loops.foreach_set("vertex_index", F_.astype(np.int32).ravel())
        me.polygons.add(len(F_))
        me.polygons.foreach_set("loop_start", (np.arange(len(F_)) * 3).astype(np.int32))
        me.polygons.foreach_set("use_smooth", np.full(len(F_), bool(sm)))
        me.update(calc_edges=True)
        ca = me.color_attributes.new("albedo", "FLOAT_COLOR", "POINT")
        rgba = np.concatenate([_srgb_lin(C_), np.ones((len(C_), 1))], 1).astype(np.float32)
        ca.data.foreach_set("color", rgba.ravel())
        me.materials.append(mt)
        o = bpy.data.objects.new(nm, me)
        coll.objects.link(o)
        return o
    objs.append(build(PREFIX + name, V, F, C, mat, smooth))
    if outline_mat is not None and thick > 0:
        N = normals if normals is not None else vertex_normals(V, F)
        Nw = _weld_normals(V, N)
        objs.append(build(PREFIX + name + "_ink", V + Nw * thick, F[:, ::-1].copy(), C, outline_mat, smooth))
    return objs


# ----------------------------------------------------------------------------------------------------------------
# Ground decals: fields, paths, delta fans, grass, ribbons

def _quads_to_tris(Q):
    return np.concatenate([Q[:, [0, 1, 2]], Q[:, [0, 2, 3]]])


def ground_strip(S, t, zs, pts, width, col_a, col_b, lift=0.12, seg=6.0, floor=False):
    """A ribbon on the ground along pts (map metres) -> V, F, C (Blender world), unshared quads, two alternating tones."""
    pts = np.asarray(pts, dtype=np.float64)
    seg_len = np.hypot(*np.diff(pts, axis=0).T)
    s = np.concatenate([[0], np.cumsum(seg_len)])
    n = max(2, int(s[-1] / seg) + 1)
    u = np.linspace(0, s[-1], n)
    x, y = np.interp(u, s, pts[:, 0]), np.interp(u, s, pts[:, 1])
    dx, dy = np.gradient(x), np.gradient(y)
    L = np.hypot(dx, dy)
    L[L == 0] = 1
    nx, ny = -dy / L, dx / L
    V, F, C = [], [], []
    for i in range(n - 1):
        q = []
        for (xx, yy, ox, oy) in ((x[i], y[i], nx[i], ny[i]), (x[i + 1], y[i + 1], nx[i + 1], ny[i + 1])):
            for sg in (-1, 1):
                px, py = xx + sg * ox * width / 2, yy + sg * oy * width / 2
                q.append((px, -py, ((max(float(S.at(t.h, px, py)), 0.0) if floor else float(S.at(t.h, px, py))) + lift) * zs))
        b = len(V)
        V += [q[0], q[1], q[3], q[2]]
        F.append((b, b + 1, b + 2))
        F.append((b, b + 2, b + 3))
        C += [col_a if i % 2 == 0 else col_b] * 4
    return np.array(V), np.array(F), np.array(C)


def ground_patch(S, t, zs, cx, cy, yaw, w, d, cols, lift=0.12, nu=9, nv=7, stripes=True):
    """A rectangle draped over the terrain (field): unshared quads in alternating furrow tones."""
    us = np.linspace(-w / 2, w / 2, nu)
    vs = np.linspace(-d / 2, d / 2, nv)
    cs, sn = math.cos(yaw), math.sin(yaw)

    def P(u, v):
        x = cx + u * cs - v * sn
        y = cy + u * sn + v * cs
        return (x, -y, (float(S.at(t.h, x, y)) + lift) * zs)
    V, F, C = [], [], []
    for i in range(nu - 1):
        for j in range(nv - 1):
            b = len(V)
            V += [P(us[i], vs[j]), P(us[i + 1], vs[j]), P(us[i + 1], vs[j + 1]), P(us[i], vs[j + 1])]
            F += [(b, b + 1, b + 2), (b, b + 2, b + 3)]
            C += [cols[(j if stripes else 0) % len(cols)]] * 4
    return np.array(V), np.array(F), np.array(C)


# ----------------------------------------------------------------------------------------------------------------

def build(D, t, mats, coll, zs=1.0, k=1.0, kb=1.0, pxm=1.0):
    """Create the dressing objects. mats = dict(toon=, ink=, glow=, decal=). Returns the objects and a stats dict."""
    T = templates()
    S = Sampler(t)
    objs, stats = [], {}
    bl = lambda x, y, z: np.stack([x, -np.asarray(y), np.asarray(z) * zs], -1)

    def ink(size):
        return float(max(min(pxm * 1.1, 0.14 * size), 0.012 * size))

    # --- trees (one smooth mesh)
    acc = Acc()
    tr = D.trees
    for kind_i, tpl_key, tabk in ((0, "tree_round", "round"), (1, "tree_conifer", "conifer"), (2, "snag", None)):
        m = tr[:, 3] == kind_i
        if not m.any():
            continue
        A = tr[m]
        pos = bl(A[:, 0], A[:, 1], A[:, 2] - 0.15)
        tpl = T[tpl_key]
        if tabk:
            tables = tree_tables(tabk, A[:, 6])
        else:
            tables = np.broadcast_to(tpl.colours[None], (len(A), 1, 3)) * (0.85 + 0.3 * A[:, 6])[:, None, None]
        emit(acc, tpl, pos, np.pi - A[:, 5], A[:, 4] * k, tables)
    V, F, C = acc.arrays()
    if len(F):
        objs += make_mesh("trees", V, F, C, True, mats["toon"], coll, mats["ink"], ink(6.0 * k))
    stats["treeTris"] = int(len(F))

    # --- buildings (flat, kit) + glow
    accb, accg = Acc(), Acc()
    by = {}
    for b in D.buildings:
        by.setdefault(b[0], []).append(b)
    for key, lst in by.items():
        body, glow = kit(key)
        A = np.array([[b[1], b[2], b[3], b[4], b[5], b[6]] for b in lst])
        pos = bl(A[:, 0], A[:, 1], A[:, 2] - 0.4 * A[:, 4])
        pos[:, 2] -= 0.0
        yaw = np.pi - A[:, 3]
        sc = A[:, 4] * kb
        tables = np.stack([kit_colours(body, v) for v in A[:, 5]])
        emit(accb, body, pos, yaw, sc, tables)
        if glow is not None:
            tg = np.stack([glow.colours for _ in A[:, 5]])
            emit(accg, glow, pos, yaw, sc, tg)
    # walls
    accb_fence = accb
    for (fx0, fy0, fx1, fy1) in getattr(D, "fences", []):
        L = math.hypot(fx1 - fx0, fy1 - fy0)
        nseg = max(1, int(round(L / (2.4 * kb))))
        for q in range(nseg):
            u = (q + 0.5) / nseg
            px, py = fx0 + (fx1 - fx0) * u, fy0 + (fy1 - fy0) * u
            emit(accb_fence, T["fence"], bl(np.array([px]), np.array([py]), np.array([float(S.at(t.h, px, py)) - 0.1])), np.array([math.atan2(-(fy1 - fy0), fx1 - fx0)]),
                 np.array([kb * L / nseg / 2.4]), None)
    for (x0, y0, z0, x1, y1, z1) in D.walls:
        _wall(accb, bl, x0, y0, z0, x1, y1, z1, kb)
    V, F, C = accb.arrays()
    if len(F):
        objs += make_mesh("buildings", V, F, C, False, mats["toon"], coll, mats["ink"], ink(10.0 * kb))
    V, F, C = accg.arrays()
    stats["buildingTris"] = int(len(F))
    glow_acc = accg

    # --- props
    accp = Acc()
    kmap = {"cart": kb, "planter": kb, "tuft": max(1.0, k * 0.8), "wagon": min(kb, 5.5), "tent": min(kb, 5.5), "slab": k, "reed": k, "rock": k, "boulder": k, "flower": max(1.0, k * 0.8), "laundry": kb, "barrel": kb, "crate": kb,
            "butte": min(kb, 2.0), "lighthouse": kb}
    for kind, rows in D.props.items():
        if kind not in T:
            continue
        A = np.array(rows)
        tpl = T[kind]
        pos = bl(A[:, 0], A[:, 1], A[:, 2] - 0.1)
        sc = A[:, 4] * kmap.get(kind, k)
        yaw = np.pi - A[:, 3]
        if kind == "flower":
            pal = np.array([_rgb(c) for c in ("#FFF4E0", "#FFD54A", "#FF8FB5", "#7FA6FF", "#FF6A5A")])
            tables = np.stack([np.stack([pal[int(v * 5) % 5], tpl.colours[1]]) for v in A[:, 5]])
        elif kind in ("rock", "boulder"):
            tables = np.stack([tpl.colours * (0.88 + 0.24 * v) for v in A[:, 5]])
            if t.masks["desert"].mean() > 0.3:
                tables = tables * np.array([1.12, 0.98, 0.8])[None, None]
            tables = np.clip(tables, 0, 1)
        else:
            tables = np.broadcast_to(tpl.colours[None], (len(A),) + tpl.colours.shape)
        emit(accp, tpl, pos, yaw, sc, np.asarray(tables))
        if kind == "lighthouse":
            emit(glow_acc, T["lamp_glass"], pos, yaw, sc, np.broadcast_to(T["lamp_glass"].colours[None], (len(A), 1, 3)))
    V, F, C = accp.arrays()
    if len(F):
        objs += make_mesh("props", V, F, C, False, mats["toon"], coll, mats["ink"], ink(2.0 * k))
    stats["propTris"] = int(len(F))
    V, F, C = glow_acc.arrays()
    if len(F):
        objs += make_mesh("glow", V, F, C, False, mats["glow"], coll)

    # --- ground decals: paths, fields, delta fans
    accd = Acc()
    for p in D.paths:
        v, f, c = ground_strip(S, t, zs, p["pts"], p["width"] * (1.0 + 0.5 * (kb - 1) / 5), *PATH_COLS.get(p["kind"], PATH_COLS["cobble"]), lift=0.14)
        accd.add(v, f, c)
    fcols = [(_rgb("#D9C46A"), _rgb("#C9B25A")), (_rgb("#9CCB5C"), _rgb("#86B84C")), (_rgb("#B98A5C"), _rgb("#A7794E")), (_rgb("#7AB04F"), _rgb("#68A044"))]
    for (x, y, z, yaw, w, d, var) in D.fields:
        v, f, c = ground_patch(S, t, zs, x, y, yaw, w * (1.0 + 0.25 * (k - 1)), d * (1.0 + 0.25 * (k - 1)), fcols[int(var) % 4], lift=0.1)
        accd.add(v, f, c)
    # river mouths are painted into the terrain albedo and the sea texture (blend.py), not built as geometry
    V, F, C = accd.arrays()
    if len(F):
        objs += make_mesh("decals", V, F, C, False, mats["decal"], coll)

    # --- grass clumps
    if len(D.grass):
        g = D.grass
        accg2 = Acc()
        tpl = T["grass"]
        sc = 0.8 + 0.7 * g[:, 3]
        yaw = g[:, 3] * 6.28 * 7
        tables = np.stack([tpl.colours * (0.9 + 0.2 * v) for v in g[:, 3]])
        emit(accg2, tpl, bl(g[:, 0], g[:, 1], g[:, 2] - 0.02), yaw, sc, np.clip(tables, 0, 1))
        V, F, C = accg2.arrays()
        objs += make_mesh("grass", V, F, C, False, mats["toon"], coll)
        stats["grassTris"] = int(len(F))
    return objs, stats


def _wall(acc, bl, x0, y0, z0, x1, y1, z1, kb):
    """A stone curtain wall between two ground points: body, walkway cap and merlons."""
    L = math.hypot(x1 - x0, y1 - y0)
    if L < 1:
        return
    a, b = np.array([x0, -y0]), np.array([x1, -y1])
    d = (b - a) / L
    nrm = np.array([-d[1], d[0]])
    th, H = 2.8 * kb, 7.0 * kb
    zlo = min(z0, z1) - 2.5
    zhi = max(z0, z1) + H
    stone, dark = _rgb("#CFC6B4"), _rgb("#9C968C")
    V = []
    for p, z in ((a, z0), (b, z1)):
        for sg in (-1, 1):
            q = p + nrm * sg * th / 2
            V += [(q[0], q[1], zlo), (q[0], q[1], z + H)]
    V = np.array(V)
    # indices: 0 a- lo, 1 a- hi, 2 a+ lo, 3 a+ hi, 4 b- lo, 5 b- hi, 6 b+ lo, 7 b+ hi
    F = np.array([(1, 5, 7), (1, 7, 3), (0, 4, 5), (0, 5, 1), (2, 3, 7), (2, 7, 6), (0, 1, 3), (0, 3, 2), (4, 6, 7), (4, 7, 5)])
    C = np.array([stone] * 8)
    C[[0, 2, 4, 6]] = dark
    acc.add(V, F, C)
    n = max(2, int(L / (2.6 * kb)))
    for i in range(0, n, 2):
        u = (i + 0.5) / n
        p = a + (b - a) * u
        z = z0 + (z1 - z0) * u + H
        for sg in (-1, 1):
            q = p + nrm * sg * (th / 2 - 0.35 * kb)
            Vb, Fb, Rb = _box((q[0], q[1], z + 0.6 * kb), (1.5 * kb, 0.7 * kb, 1.2 * kb), 0, rot=math.atan2(d[1], d[0]))
            acc.add(Vb, Fb, np.array([stone] * 8))


def _delta(acc, S, t, zs, dl, pxm):
    """A river delta: a sandy fan with three channels reaching into the sea."""
    x, y, dx, dy, hw = dl["x"], dl["y"], dl["dx"], dl["dy"], dl["hw"]
    R = 260.0
    n_r, n_a = 6, 11
    V, F, C = [], [], []
    sand, sand2, wet = _rgb("#E6D69F"), _rgb("#EFE2B8"), _rgb("#BFD9A0")
    base = math.atan2(dy, dx)
    P = np.zeros((n_r, n_a, 3))
    for i in range(n_r):
        r = R * i / (n_r - 1) + 6.0
        for j in range(n_a):
            a = base + (j / (n_a - 1) - 0.5) * math.radians(88.0) * (0.35 + 0.65 * i / (n_r - 1))
            px, py = x + r * math.cos(a), y + r * math.sin(a)
            h = float(S.at(t.h, px, py))
            P[i, j] = (px, -py, (max(h, 0.0) + (0.55 if h > 0.6 else 0.16)) * zs)
    for i in range(n_r - 1):
        for j in range(n_a - 1):
            q = [P[i, j], P[i, j + 1], P[i + 1, j + 1], P[i + 1, j]]
            hs = [S.at(t.h, p[0], -p[1]) for p in q]
            if min(hs) < -3.0:                       # leave deeper water bare; shallower shelf becomes sandbar
                continue
            b = len(V)
            V += [tuple(p) for p in q]
            F += [(b, b + 1, b + 2), (b, b + 2, b + 3)]
            C += [sand if i < 3 else sand2] * 4
    if F:
        acc.add(np.array(V), np.array(F), np.array(C))
    water = _rgb("#6EC4DC")
    for ang, ln in ((-0.62, 250.0), (0.0, 300.0), (0.62, 230.0)):
        a = base + ang
        pts = [(x - dx * 40.0, y - dy * 40.0), (x, y), (x + math.cos(a) * ln * 0.5, y + math.sin(a) * ln * 0.5), (x + math.cos(a) * ln, y + math.sin(a) * ln)]
        v, f, c = ground_strip(S, t, zs, np.array(pts), max(8.0, hw * 1.2) * (0.55 if ang else 0.9), water, water, lift=0.75, floor=True)
        acc.add(v, f, c)
