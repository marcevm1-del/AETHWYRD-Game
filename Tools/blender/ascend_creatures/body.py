"""
Creature bodies as metaballs: smooth-unioned balls, ellipsoids and tapered chains give the soft, sculpted look of a
clay maquette. `Body` collects the elements plus anatomical landmarks (head, eyes, mouth, shoulders, hands, feet,
spine, tail) that the features in features.py attach to. `tessellate` turns the elements into a dense mesh, relaxes it
and paints it: belly and back tones, the species pattern, darkened creases and a glow mask for emissive hides.

Conventions: built in normalised units (the creature is about 1 unit at its largest), facing -Y, standing on z = 0.
"""
import math

import bpy
import numpy as np
from mathutils import Vector, noise

SURFACE = 0.575  # a lone metaball's surface sits at this fraction of its radius (threshold 0.6, stiffness 2)


def V(*a):
    return Vector(a[0]) if len(a) == 1 else Vector(a)


class Body:
    def __init__(self, rng):
        self.rng = rng
        self.els = []          # (type, co, radius, size, rot_euler, negative)
        # landmarks
        self.head = V(0, 0, 0.7)
        self.head_r = 0.2
        self.face = V(0, -1, 0)          # the direction the face looks
        self.eye_spread = 35.0           # degrees either side of the face direction
        self.eye_up = 12.0               # degrees above it
        self.eye_size = 0.32             # eye radius as a fraction of head_r
        self.eye_out = 0.86              # eye centre distance from the head centre, as a fraction of head_r
        self.eye_count = 2
        self.mouth = None                # point on the face for teeth / beaks
        self.snout = None
        self.neck = V(0, 0, 0.6)
        self.spine = []                  # neck -> tail root, along the back surface
        self.shoulders, self.hands, self.hips, self.feet = [], [], [], []
        self.tail_root, self.tail_dir = None, V(0, 1, 0)
        self.wing_root = None
        self.torso_r = 0.15
        self.legged = True
        self.kind = "biped"
        self.P = {}                      # the species profile (profile.py)
        self.extra_heads = []

    # elements -----------------------------------------------------------------------------------------------------

    def ball(self, p, r, neg=False):
        self.els.append(("BALL", V(p), r / SURFACE, (1, 1, 1), (0, 0, 0), neg))

    def ellip(self, p, radii, rot=(0, 0, 0), neg=False):
        m = max(radii)
        self.els.append(("ELLIPSOID", V(p), m / SURFACE, tuple(x / m for x in radii), rot, neg))

    def cube(self, p, half, rot=(0, 0, 0)):
        """A rounded block with the given half extents (cube metaballs take absolute sizes plus a rounding radius)."""
        rho = min(half) * 0.4
        self.els.append(("CUBE", V(p), rho / SURFACE, tuple(max(1e-3, h - rho) for h in half), rot, False))

    def chain(self, pts, radii, density=0.45):
        """Balls along a polyline with radii interpolated along it: tapered limbs, necks and tails."""
        pts = [V(p) for p in pts]
        if not isinstance(radii, (list, tuple)):
            radii = [radii] * len(pts)
        if len(radii) == 2 and len(pts) > 2:
            total = sum((pts[i + 1] - pts[i]).length for i in range(len(pts) - 1))
            acc, rr = 0.0, [radii[0]]
            for i in range(len(pts) - 1):
                acc += (pts[i + 1] - pts[i]).length
                rr.append(radii[0] + (radii[1] - radii[0]) * acc / max(total, 1e-6))
            radii = rr
        for i in range(len(pts) - 1):
            a, b = pts[i], pts[i + 1]
            ra, rb = radii[i], radii[i + 1]
            ln = (b - a).length
            n = max(1, int(ln / (min(ra, rb) * density)))
            for k in range(n + (1 if i == len(pts) - 2 else 0)):
                t = k / n
                self.ball(a.lerp(b, t), ra + (rb - ra) * t)

    # landmarks helpers --------------------------------------------------------------------------------------------

    def eye_points(self):
        """Centre, outward normal and radius for each eye on the head surface."""
        out = []
        f = self.face.normalized()
        side = f.cross(V(0, 0, 1)).normalized()
        if side.length < 0.1:
            side = V(1, 0, 0)
        n = self.eye_count
        r = self.head_r * self.eye_size
        spreads = [0.0] if n == 1 else [(-1 + 2 * i / (n - 1)) * self.eye_spread for i in range(n)]
        for i, a in enumerate(spreads):
            up = self.eye_up + (8 if n > 2 and i % 2 else 0)
            d = f.copy()
            d.rotate(_axis_rot(V(0, 0, 1), math.radians(a)))
            d = (d + V(0, 0, math.tan(math.radians(up)))).normalized()
            p = self.head + d * self.head_r * self.eye_out
            out.append((p, d, r))
        return out


def _axis_rot(axis, ang):
    from mathutils import Quaternion
    return Quaternion(axis, ang)


# ----------------------------------------------------------------------------------------------------------------
# Tessellation


def tessellate(body, resolution=0.012, scene=None):
    """Polygonises the body's metaballs. Returns (verts (n,3), triangles (m,3))."""
    sc = scene or bpy.context.scene
    mb = bpy.data.metaballs.new("AC_tmp")
    mb.resolution = mb.render_resolution = resolution
    mb.threshold = 0.6
    for typ, co, r, size, rot, neg in body.els:
        e = mb.elements.new(type=typ)
        e.co = co
        e.radius = r
        e.stiffness = 2.0
        e.use_negative = neg
        if typ != "BALL":
            e.size_x, e.size_y, e.size_z = size
            from mathutils import Euler
            e.rotation = Euler([math.radians(x) for x in rot]).to_quaternion()
    ob = bpy.data.objects.new("AC_tmp", mb)
    sc.collection.objects.link(ob)
    dg = bpy.context.evaluated_depsgraph_get()
    ev = ob.evaluated_get(dg)
    me = ev.to_mesh()
    nv = len(me.vertices)
    verts = np.empty(nv * 3, dtype=np.float64)
    me.vertices.foreach_get("co", verts)
    verts = verts.reshape(-1, 3)
    me.calc_loop_triangles()
    faces = np.empty(len(me.loop_triangles) * 3, dtype=np.int64)
    me.loop_triangles.foreach_get("vertices", faces)
    faces = faces.reshape(-1, 3)
    ev.to_mesh_clear()
    bpy.data.objects.remove(ob)
    bpy.data.metaballs.remove(mb)
    return verts, faces


def edges_of(tris, nv=None):
    e = np.concatenate([tris[:, [0, 1]], tris[:, [1, 2]], tris[:, [2, 0]]])
    e.sort(1)
    return np.unique(e, axis=0)


def relax(verts, edges, iters=2, w=0.5):
    """Laplacian smoothing that evens out the metaball facets without shrinking the forms much."""
    v = verts.copy()
    nv = len(v)
    deg = np.bincount(edges.ravel(), minlength=nv).astype(np.float64)
    deg[deg == 0] = 1
    for _ in range(iters):
        acc = np.zeros_like(v)
        np.add.at(acc, edges[:, 0], v[edges[:, 1]])
        np.add.at(acc, edges[:, 1], v[edges[:, 0]])
        lap = acc / deg[:, None] - v
        v = v + lap * w
        acc = np.zeros_like(v)  # inflate step (Taubin) to keep volume
        np.add.at(acc, edges[:, 0], v[edges[:, 1]])
        np.add.at(acc, edges[:, 1], v[edges[:, 0]])
        v = v - (acc / deg[:, None] - v) * (w * 0.53)
    return v


def fan_tris(faces):
    tris = []
    for f in faces:  # metaball faces are quads and triangles
        for i in range(1, len(f) - 1):
            tris.append((f[0], f[i], f[i + 1]))
    return np.array(tris, dtype=np.int64)


def normals_of(verts, faces, tris=None):
    t = np.asarray(faces) if tris is None else tris
    fn = np.cross(verts[t[:, 1]] - verts[t[:, 0]], verts[t[:, 2]] - verts[t[:, 0]])
    n = np.zeros_like(verts)
    for k in range(3):
        np.add.at(n, t[:, k], fn)
    ln = np.linalg.norm(n, axis=1, keepdims=True)
    return n / np.maximum(ln, 1e-12)


def vnoise(pts, scale, seed, kind="noise"):
    """mathutils noise over many points, over an array of points."""
    if kind == "voronoi":  # distance to the nearest cell border: scale outlines
        out = np.empty(len(pts))
        for i, p in enumerate(pts):
            d, _ = noise.voronoi(V(*(p * scale + seed)), distance_metric="DISTANCE", exponent=2.5)
            out[i] = d[1] - d[0]
        return out
    fn = noise.cell if kind == "cell" else noise.noise
    return np.array([fn(V(*(p * scale + seed))) for p in pts])


def curvature(verts, edges, normals):
    """Positive in creases (concave), negative on ridges, from the Laplacian along the normal."""
    nv = len(verts)
    deg = np.bincount(edges.ravel(), minlength=nv).astype(np.float64)
    deg[deg == 0] = 1
    acc = np.zeros_like(verts)
    np.add.at(acc, edges[:, 0], verts[edges[:, 1]])
    np.add.at(acc, edges[:, 1], verts[edges[:, 0]])
    lap = acc / deg[:, None] - verts
    return (lap * normals).sum(1)


def displace(verts, normals, amount, scale, seed):
    if amount <= 0:
        return verts
    off = vnoise(verts, scale, seed)
    return verts + normals * (off * amount)[:, None]


# ----------------------------------------------------------------------------------------------------------------
# Painting


def smooth(t, a, b):
    x = np.clip((t - a) / (b - a), 0, 1)
    return x * x * (3 - 2 * x)


def paint(verts, normals, curv, look, body):
    """Per-vertex colour (linear RGB) and glow mask from the look's palette and pattern."""
    main, dark, accent = (np.array(c) for c in (look.main, look.dark, look.accent))
    belly_c = np.clip(main * 0.7 + accent * 0.15 + 0.12, 0, 1) if look.belly else main  # lighter body tone, a touch of accent
    nz = normals[:, 2]
    z = verts[:, 2]
    zmin, zmax = z.min(), z.max()
    h = (z - zmin) / max(1e-6, zmax - zmin)
    col = np.tile(main, (len(verts), 1))
    # underside and chest lighter, top of the back darker
    belly = smooth(-nz, 0.1, 0.7) * (0.35 + 0.65 * (1 - h)) if look.belly else np.zeros(len(verts))
    if body.kind in ("biped",):
        belly = np.maximum(belly, smooth(-normals[:, 1], 0.55, 0.95) * smooth(h, 0.25, 0.4) * (1 - smooth(h, 0.62, 0.75)) * 0.8)
    col = col * (1 - belly[:, None]) + belly_c * belly[:, None]
    back = smooth(nz, 0.45, 0.95) * smooth(h, 0.35, 0.8) * look.back_dark
    col = col * (1 - back[:, None]) + dark * back[:, None]
    # species pattern
    s = look.seed % 97
    if look.pattern in ("spots", "stripes", "cells", "patches", "rings"):
        sc = look.pattern_scale
        if look.pattern == "stripes":
            vals = np.sin(verts[:, 1] * sc * 6.0 + vnoise(verts, sc, s) * 2.5)
        elif look.pattern == "cells":
            vals = vnoise(verts, sc * 2.2, s, "voronoi")
        elif look.pattern == "rings":
            vals = np.sin(verts[:, 2] * sc * 7.0 + vnoise(verts, sc, s))
        elif look.pattern == "spots":
            vals = vnoise(verts, sc * 2.6, s)
        else:
            vals = vnoise(verts, sc * 0.6, s)
        if look.pattern == "spots":  # many small spots, never a hole-sized blob
            m = smooth(vals, 0.42, 0.5) * 0.75
        elif look.pattern == "stripes":
            m = smooth(vals, 0.55, 0.75) * (1 - belly)
        elif look.pattern == "cells":
            m = (1 - smooth(vals, 0.02, 0.09)) * 0.6
        elif look.pattern == "rings":
            m = smooth(vals, 0.6, 0.8)
        else:
            m = smooth(vals, 0.1, 0.35) * 0.4
        tgt = dark if look.pattern != "spots" else (accent if look.spot_light else dark)
        col = col * (1 - m[:, None]) + tgt * m[:, None]
    # creases darker (a baked cavity), ridges a touch lighter
    k = np.clip(curv / (np.std(curv) * 4.0 + 1e-9), -1, 1)
    col = col * (1 - np.clip(k, 0, 1)[:, None] * look.cavity * 0.6) * (1 + np.clip(-k, 0, 1)[:, None] * 0.08)
    # gel: brighter towards the crown
    if look.gel:
        col = col * (0.75 + 0.45 * h[:, None])
    glow = np.zeros(len(verts))
    if look.glow_cracks:
        g = np.abs(vnoise(verts, 9.0, s))
        glow = (1 - smooth(g, 0.03, 0.09)) * smooth(h, 0.05, 0.3)
        col = col * (1 - glow[:, None]) + accent * glow[:, None]
    return np.clip(col, 0, 1), glow


def skin_material(look):
    spirit = getattr(look, "spirit", False)
    name = "AC_skin_%s%s" % (look.style, "_spirit" if spirit else "")
    mat = bpy.data.materials.get(name) or bpy.data.materials.new(name)
    mat.use_nodes = True
    nt = mat.node_tree
    for n in list(nt.nodes):  # rebuild the nodes in place, so creatures already using it keep it
        nt.nodes.remove(n)
    out = nt.nodes.new("ShaderNodeOutputMaterial")
    bsdf = nt.nodes.new("ShaderNodeBsdfPrincipled")
    nt.links.new(bsdf.outputs[0], out.inputs[0])
    attr = nt.nodes.new("ShaderNodeAttribute")
    attr.attribute_name = "Col"
    nt.links.new(attr.outputs["Color"], bsdf.inputs["Base Color"])
    rough, metal, emit, alpha = look.surface
    bsdf.inputs["Roughness"].default_value = rough
    bsdf.inputs["Metallic"].default_value = metal
    if look.gel:
        for nm, v in (("Coat Weight", 1.0), ("Subsurface Weight", 0.25)):
            if nm in bsdf.inputs:
                bsdf.inputs[nm].default_value = v
    if look.glow_cracks or emit > 0:
        g = nt.nodes.new("ShaderNodeAttribute")
        g.attribute_name = "glow"
        mul = nt.nodes.new("ShaderNodeMath")
        mul.operation = "MULTIPLY"
        mul.inputs[1].default_value = 6.0
        nt.links.new(g.outputs["Fac"], mul.inputs[0])
        nt.links.new(attr.outputs["Color"], bsdf.inputs["Emission Color"])
        nt.links.new(mul.outputs[0], bsdf.inputs["Emission Strength"])
    if spirit:  # Phantom variants: see-through, lit from within
        alpha = min(alpha, 0.55)
        nt.links.new(attr.outputs["Color"], bsdf.inputs["Emission Color"])
        bsdf.inputs["Emission Strength"].default_value = 0.6
    if alpha < 1:
        bsdf.inputs["Alpha"].default_value = alpha
        try:
            mat.surface_render_method = "BLENDED"
        except Exception:
            pass
    return mat
