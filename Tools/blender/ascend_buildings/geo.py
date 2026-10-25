"""
Geometry accumulation for the Ascend building generator.

A `Geo` collects mesh pieces (numpy vertex arrays plus faces, each tagged with a material key) and instance placements
(a part key plus location, rotation and scale). `write_mesh` turns it into one Blender mesh: the pieces become real
faces, and every instance becomes a loose "carrier" vertex whose attributes tell the AB_Instancer geometry-nodes group
which part to put there. Repeated detail (roof tiles, wall stones, planks, leaves) is instanced that way, so a high-poly
building stays small on disk and fast in the viewport.

Conventions (the same as Tools/blender/town_buildings.py): metres, ground at z = 0, the front faces -Y.
"""
import math

import numpy as np
from mathutils import Euler, Matrix, Vector

# ----------------------------------------------------------------------------------------------------------------
# Transforms


def trs(loc=(0, 0, 0), rot=(0, 0, 0), scale=1.0):
    """A 4x4 matrix from a location, an XYZ Euler rotation in degrees and a uniform or per-axis scale."""
    s = (scale, scale, scale) if isinstance(scale, (int, float)) else scale
    m = Matrix.LocRotScale(Vector(loc), Euler([math.radians(a) for a in rot], "XYZ"), Vector(s))
    return m


def np_matrix(m):
    return np.array(m, dtype=np.float64)


def apply(m, v):
    """Transforms an (n, 3) array by a mathutils or numpy 4x4 matrix."""
    a = np_matrix(m) if not isinstance(m, np.ndarray) else m
    return v @ a[:3, :3].T + a[:3, 3]


# ----------------------------------------------------------------------------------------------------------------
# The accumulator


class Geo:
    def __init__(self):
        self.verts = []      # numpy (n, 3) chunks
        self.faces = []      # per chunk: list of index tuples, local to the chunk
        self.mats = []       # per chunk: material key
        self.instances = []  # (part key, location, euler radians, scale)

    # Mesh pieces -----------------------------------------------------------------------------------------------

    def add(self, verts, faces, mat, m=None):
        v = np.asarray(verts, dtype=np.float64).reshape(-1, 3)
        if m is not None:
            v = apply(m, v)
        self.verts.append(v)
        self.faces.append(faces)
        self.mats.append(mat)

    def rbox(self, size, mat, m=None, r=0.04, seg=1, center=(0, 0, 0)):
        """A box with rounded edges (radius r, seg steps per edge), centred on `center` in its local frame."""
        v, f = rounded_box(size, r, seg)
        v = v + np.asarray(center, dtype=np.float64)
        self.add(v, f, mat, m)

    def box(self, size, mat, m=None, center=(0, 0, 0)):
        """A sharp box (for hidden or very small pieces)."""
        sx, sy, sz = (s / 2 for s in size)
        cx, cy, cz = center
        v = [(cx + x * sx, cy + y * sy, cz + z * sz) for z in (-1, 1) for y in (-1, 1) for x in (-1, 1)]
        f = [(0, 2, 3, 1), (4, 5, 7, 6), (0, 1, 5, 4), (2, 6, 7, 3), (0, 4, 6, 2), (1, 3, 7, 5)]
        self.add(v, f, mat, m)

    def lathe(self, profile, mat, m=None, segs=16, cap_bottom=True, cap_top=True, phase=0.0):
        v, f = lathe(profile, segs, cap_bottom, cap_top, phase)
        self.add(v, f, mat, m)

    def cylinder(self, r, h, mat, m=None, segs=16, r_top=None, bevel=0.0, z0=0.0, caps=True):
        """A cylinder standing on z0 (in its local frame), optionally with soft rounded rims."""
        rt = r if r_top is None else r_top
        if bevel > 0:
            b = min(bevel, r * 0.5, rt * 0.5, h * 0.3)
            prof = [(r - b, z0), (r - b * 0.3, z0 + b * 0.3), (r, z0 + b), (rt, z0 + h - b), (rt - b * 0.3, z0 + h - b * 0.3),
                    (rt - b, z0 + h)]
        else:
            prof = [(r, z0), (rt, z0 + h)]
        self.lathe(prof, mat, m, segs, caps, caps)

    def sphere(self, r, mat, m=None, segs=12, rings=8, squash=1.0):
        prof = [(r * math.sin(math.pi * i / rings), -r * squash * math.cos(math.pi * i / rings)) for i in range(rings + 1)]
        self.lathe(prof, mat, m, segs, False, False)

    def prism(self, poly, z0, z1, mat, m=None):
        """Extrudes a counter-clockwise 2D polygon (x, y) from z0 to z1."""
        n = len(poly)
        v = [(x, y, z0) for x, y in poly] + [(x, y, z1) for x, y in poly]
        f = [tuple(range(n - 1, -1, -1)), tuple(range(n, 2 * n))]
        f += [(i, (i + 1) % n, n + (i + 1) % n, n + i) for i in range(n)]
        self.add(v, f, mat, m)

    def slab_poly(self, poly, thick, mat, m=None):
        """A polygon in the local XZ plane (x, z pairs, counter-clockwise seen from -Y) given depth along Y."""
        self.prism(poly, -thick / 2, thick / 2, mat, (m or Matrix.Identity(4)) @ ROT_XZ)

    def patch(self, fn, nu, nv, mat, m=None, thick=0.0):
        """A parametric surface fn(u, v) -> (x, y, z) over [0, 1]^2, optionally thickened downward along its normal."""
        us = np.linspace(0, 1, nu + 1)
        vs = np.linspace(0, 1, nv + 1)
        top = np.array([[fn(u, v) for u in us] for v in vs], dtype=np.float64)  # (nv+1, nu+1, 3)
        idx = lambda i, j: i * (nu + 1) + j
        faces = [(idx(i, j), idx(i, j + 1), idx(i + 1, j + 1), idx(i + 1, j)) for i in range(nv) for j in range(nu)]
        verts = top.reshape(-1, 3)
        if thick > 0:
            du = np.gradient(top, axis=1)
            dv = np.gradient(top, axis=0)
            nrm = np.cross(du, dv)
            nrm /= np.linalg.norm(nrm, axis=2, keepdims=True) + 1e-12
            bot = (top - nrm * thick).reshape(-1, 3)
            off = len(verts)
            verts = np.concatenate([verts, bot])
            faces += [(off + c, off + b, off + a, off + d) for a, b, c, d in faces[: nu * nv]]
            for j in range(nu):  # v = 0 and v = 1 edges
                faces.append((idx(0, j + 1), idx(0, j), off + idx(0, j), off + idx(0, j + 1)))
                faces.append((idx(nv, j), idx(nv, j + 1), off + idx(nv, j + 1), off + idx(nv, j)))
            for i in range(nv):  # u = 0 and u = 1 edges
                faces.append((idx(i, 0), idx(i + 1, 0), off + idx(i + 1, 0), off + idx(i, 0)))
                faces.append((idx(i + 1, nu), idx(i, nu), off + idx(i, nu), off + idx(i + 1, nu)))
        self.add(verts, faces, mat, m)

    # Instances --------------------------------------------------------------------------------------------------

    def inst(self, part, m):
        """Places a shared part (see parts.py) with the transform m (mathutils 4x4)."""
        loc, rot, sca = m.decompose()
        e = rot.to_euler("XYZ")
        self.instances.append((part, tuple(loc), (e.x, e.y, e.z), tuple(sca)))

    def extend(self, other, m=None):
        """Adds another Geo's pieces and instances, optionally transformed."""
        for v, f, k in zip(other.verts, other.faces, other.mats):
            self.add(v, f, k, m)
        for part, loc, rot, sca in other.instances:
            if m is None:
                self.instances.append((part, loc, rot, sca))
            else:
                mm = m @ Matrix.LocRotScale(Vector(loc), Euler(rot, "XYZ"), Vector(sca))
                self.inst(part, mm)

    def face_count(self):
        return sum(len(f) for f in self.faces)


ROT_XZ = Matrix.Rotation(math.radians(90), 4, "X")  # local XY polygon -> XZ plane, extruded along -Y..+Y


# ----------------------------------------------------------------------------------------------------------------
# Rounded box


_RBOX_CACHE = {}


def _rbox_template(seg):
    """Integer grid coordinates of the cube surface and its quads (outward winding), cached per seg."""
    if seg in _RBOX_CACHE:
        return _RBOX_CACHE[seg]
    n = 2 * (seg + 1)
    index = {}
    coords = []

    def vid(i, j, k):
        key = (i, j, k)
        if key not in index:
            index[key] = len(coords)
            coords.append(key)
        return index[key]

    faces = []
    last = n - 1
    for a in range(last):
        for b in range(last):
            # +X / -X over (y, z)
            faces.append((vid(last, a, b), vid(last, a + 1, b), vid(last, a + 1, b + 1), vid(last, a, b + 1)))
            faces.append((vid(0, a, b + 1), vid(0, a + 1, b + 1), vid(0, a + 1, b), vid(0, a, b)))
            # +Y / -Y over (z, x)
            faces.append((vid(b, last, a), vid(b, last, a + 1), vid(b + 1, last, a + 1), vid(b + 1, last, a)))
            faces.append((vid(b + 1, 0, a), vid(b + 1, 0, a + 1), vid(b, 0, a + 1), vid(b, 0, a)))
            # +Z / -Z over (x, y)
            faces.append((vid(a, b, last), vid(a + 1, b, last), vid(a + 1, b + 1, last), vid(a, b + 1, last)))
            faces.append((vid(a, b + 1, 0), vid(a + 1, b + 1, 0), vid(a + 1, b, 0), vid(a, b, 0)))
    t = (np.array(coords, dtype=np.int64), faces)
    _RBOX_CACHE[seg] = t
    return t


def rounded_box(size, r, seg=1):
    """Vertices and faces of a box of the given size, centred at the origin, with edges rounded to radius r."""
    grid, faces = _rbox_template(seg)
    half = np.asarray(size, dtype=np.float64) / 2
    r = max(1e-4, min(r, half.min() * 0.95))
    inner = half - r
    # Per axis: seg+1 values from -half to -inner (uniform angle along the rounded edge), then mirrored.
    ang = np.array([math.tan(math.pi / 4 * t / seg) for t in range(seg, -1, -1)])
    vals = []
    for ax in range(3):
        lo = -(inner[ax] + r * ang)
        vals.append(np.concatenate([lo, -lo[::-1]]))
    p = np.stack([vals[0][grid[:, 0]], vals[1][grid[:, 1]], vals[2][grid[:, 2]]], axis=1)
    c = np.clip(p, -inner, inner)
    d = p - c
    ln = np.linalg.norm(d, axis=1, keepdims=True)
    out = np.where(ln > 1e-9, c + d / np.maximum(ln, 1e-9) * r, p)
    return out, faces


# ----------------------------------------------------------------------------------------------------------------
# Lathe (cylinders, cones, domes, onion domes, columns, pots, yurts)


def lathe(profile, segs=16, cap_bottom=True, cap_top=True, phase=0.0):
    """Revolves (radius, z) profile points about Z. A zero radius becomes a single pole vertex."""
    verts = []
    rings = []
    angs = [phase + 2 * math.pi * j / segs for j in range(segs)]
    for r, z in profile:
        if r <= 1e-6:
            rings.append([len(verts)])
            verts.append((0.0, 0.0, z))
        else:
            ring = []
            for a in angs:
                ring.append(len(verts))
                verts.append((r * math.cos(a), r * math.sin(a), z))
            rings.append(ring)
    faces = []
    for i in range(len(rings) - 1):
        a, b = rings[i], rings[i + 1]
        for j in range(segs):
            j1 = (j + 1) % segs
            if len(a) == 1 and len(b) == 1:
                continue
            if len(a) == 1:
                faces.append((a[0], b[j1], b[j]))
            elif len(b) == 1:
                faces.append((a[j], a[j1], b[0]))
            else:
                faces.append((a[j], a[j1], b[j1], b[j]))
    if cap_bottom and len(rings[0]) > 1:
        faces.append(tuple(reversed(rings[0])))
    if cap_top and len(rings[-1]) > 1:
        faces.append(tuple(rings[-1]))
    return np.array(verts, dtype=np.float64), faces


# ----------------------------------------------------------------------------------------------------------------
# Writing to Blender


def write_mesh(geo, me, mat_index, part_index):
    """
    Replaces mesh `me` with the Geo: real faces plus one loose carrier vertex per instance, with the attributes the
    AB_Instancer group reads (is_inst, inst_index, inst_rot, inst_scale). `mat_index(key)` returns a material slot;
    `part_index(part)` returns the part's index in the parts collection (sorted by name).
    """
    import bpy  # noqa: F401  (only needed inside Blender)

    vs = [v for v in geo.verts]
    nv = sum(len(v) for v in vs)
    loops = []
    starts = []
    mats = []
    off = 0
    nl = 0
    for v, faces, key in zip(geo.verts, geo.faces, geo.mats):
        mi = mat_index(key)
        for f in faces:
            starts.append(nl)
            loops.extend(off + i for i in f)
            nl += len(f)
            mats.append(mi)
        off += len(v)
    inst = geo.instances
    V = np.concatenate(vs) if vs else np.zeros((0, 3))
    if inst:
        V = np.concatenate([V, np.array([i[1] for i in inst], dtype=np.float64)])
    me.clear_geometry()
    me.vertices.add(len(V))
    me.vertices.foreach_set("co", V.astype(np.float32).ravel())
    me.loops.add(len(loops))
    me.loops.foreach_set("vertex_index", np.array(loops, dtype=np.int32))
    me.polygons.add(len(starts))
    me.polygons.foreach_set("loop_start", np.array(starts, dtype=np.int32))
    me.polygons.foreach_set("material_index", np.array(mats, dtype=np.int32))
    me.update(calc_edges=True)
    me.polygons.foreach_set("use_smooth", np.ones(len(starts), dtype=bool))
    try:
        me.set_sharp_from_angle(angle=math.radians(36))
    except AttributeError:
        pass
    for name in ("is_inst", "inst_index", "inst_rot", "inst_scale"):
        a = me.attributes.get(name)
        if a:
            me.attributes.remove(a)
    total = len(V)
    flag = np.zeros(total, dtype=bool)
    idx = np.zeros(total, dtype=np.int32)
    rot = np.zeros((total, 3), dtype=np.float32)
    sca = np.ones((total, 3), dtype=np.float32)
    if inst:
        flag[nv:] = True
        idx[nv:] = [part_index(i[0]) for i in inst]
        rot[nv:] = [i[2] for i in inst]
        sca[nv:] = [i[3] for i in inst]
    me.attributes.new("is_inst", "BOOLEAN", "POINT").data.foreach_set("value", flag)
    me.attributes.new("inst_index", "INT", "POINT").data.foreach_set("value", idx)
    me.attributes.new("inst_rot", "FLOAT_VECTOR", "POINT").data.foreach_set("vector", rot.ravel())
    me.attributes.new("inst_scale", "FLOAT_VECTOR", "POINT").data.foreach_set("vector", sca.ravel())
    me.update()
    return nv, len(starts), len(inst)
