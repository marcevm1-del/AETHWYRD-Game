"""
Whisperwood foliage kit (stylized low-poly, owner decision D-03): authored directly at budget, flat colour per face.

Kit (13_Production/art_direction.md section 9 and 12, budgets in art_budgets.md):
  tree_broadleaf_a/b/c  layered clumps of 3-5 lobes, tapered and flared trunk, 5,000-8,000 tris
  tree_pine_a           tall tiered conifer
  bush_a, bush_b        300-1,200 tris
  grass_tuft            cluster of closed triangular-prism blades (no open cards, so every mesh is manifold)
  fern_clump, flower_clump
  rock_mossy_a

Every shell is a closed solid, quads and triangles only. Colour is a vertex-colour layer ("Col", one flat colour per
face) AND a material slot per palette tone (fol_<tone>), so the scene shows the right colours before the Ascend/Toon
shader reads vertex colour. Origin at the base, metres, Z up in Blender (exported Y up, -Z forward, like the buildings).

Run headless:
  blender -b --factory-startup -P Tools/blender/build_foliage_kit.py --python-exit-code 1 -- [--only a,b] [--no-export]
                                                                      [--preview reports/foliage_2026-11-23]
Outputs:
  Game/Assets/_Game/Art/Models/Foliage/<id>.fbx   (Git LFS)
  Art/Generation/staging/foliage/foliage_kit.blend (source, gitignored)
  --preview: contact_sheet.png, silhouette_25pct_grey.png, forest_overview.png, forest_eye_level.png
Check afterwards with Tools/blender/check_foliage_kit.py.
"""
import math
import os
import random
import sys

import bmesh
import bpy
from mathutils import Matrix, Vector

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "..")) if "__file__" in globals() else r"E:/Ideas/Project-Ascend"
FBX_DIR = os.path.join(ROOT, "Game", "Assets", "_Game", "Art", "Models", "Foliage")
BLEND_PATH = os.path.join(ROOT, "Art", "Generation", "staging", "foliage", "foliage_kit.blend")

LIGHT = Vector((-0.4, -0.3, 0.85)).normalized()  # warm key light from upper left, matches the toon rule "lit tops, cool undersides"

# Region palette (art_direction.md section 2 and 9): lit grass #8CC860, shade grass #5E9A4A; leaves a touch deeper, the lit
# top 15 percent lighter and warmer, the under-canopy cool; bark warm brown; rocks a lavender grey (shadows are violet-blue).
TONES = {
    "leaf_lit": "#74B352", "leaf_mid": "#4F9248", "leaf_shade": "#3A7752",
    "bark_light": "#8E6A44", "bark": "#6B4A30", "bark_dark": "#4A3224",
    "needle_lit": "#4F8F5C", "needle_mid": "#37735A", "needle_shade": "#2A5A52",
    "grass_lit": "#8CC860", "grass_shade": "#5E9A4A", "grass_dark": "#497F40",
    "moss": "#86B04A", "moss_dark": "#5E8A40", "rock": "#9A98A6", "rock_dark": "#6E6C80",
    "flower_violet": "#9B8CE8", "flower_cream": "#F4EEDC", "berry": "#D9566B",
}
BUDGET = {  # id: (min tris, max tris)  (tree class 5,000-10,000 and bush class 300-1,200 in art_budgets.md)
    "tree_broadleaf_a": (5000, 8000), "tree_broadleaf_b": (5000, 8000), "tree_broadleaf_c": (5000, 8000),
    "tree_pine_a": (1500, 10000), "bush_a": (300, 1200), "bush_b": (300, 1200),
    "grass_tuft": (100, 1200), "fern_clump": (100, 1200), "flower_clump": (100, 1200), "rock_mossy_a": (100, 1200),
}


def srgb_to_linear(c):
    return c / 12.92 if c <= 0.04045 else ((c + 0.055) / 1.055) ** 2.4


def hex_rgb(h):
    h = h.lstrip("#")
    return tuple(int(h[i:i + 2], 16) / 255.0 for i in (0, 2, 4))


def tone_linear(tone):
    return tuple(srgb_to_linear(c) for c in hex_rgb(TONES[tone]))


_MATS = {}


def material(tone):
    name = "fol_" + tone
    if name in _MATS:
        return _MATS[name]
    mat = bpy.data.materials.get(name) or bpy.data.materials.new(name)
    lin = tone_linear(tone)
    try:
        mat.use_nodes = True
    except Exception:
        pass
    if mat.node_tree:
        bsdf = next((n for n in mat.node_tree.nodes if n.type == "BSDF_PRINCIPLED"), None)
        if bsdf:
            bsdf.inputs["Base Color"].default_value = (*lin, 1.0)
            bsdf.inputs["Roughness"].default_value = 1.0
    mat.diffuse_color = (*lin, 1.0)
    _MATS[name] = mat
    return mat


class Mesher:
    """Accumulates closed shells in one bmesh: faces carry a tone (material slot and flat vertex colour)."""

    def __init__(self, name):
        self.name = name
        self.bm = bmesh.new()
        self.col = self.bm.loops.layers.float_color.new("Col")
        self.tones = []

    def paint(self, face, tone):
        if tone not in self.tones:
            self.tones.append(tone)
        face.material_index = self.tones.index(tone)
        face.smooth = False
        c = (*tone_linear(tone), 1.0)
        for loop in face.loops:
            loop[self.col] = c

    def face(self, verts, tone):
        f = self.bm.faces.new(verts)
        self.paint(f, tone)
        return f

    def vert(self, co):
        return self.bm.verts.new(co)

    def tris(self):
        return sum(len(f.verts) - 2 for f in self.bm.faces)

    def finish(self):
        bm = self.bm
        minz = min(v.co.z for v in bm.verts)
        for v in bm.verts:  # the base always sits exactly on z = 0
            v.co.z -= minz
        bmesh.ops.recalc_face_normals(bm, faces=bm.faces[:])
        bm.normal_update()
        me = bpy.data.meshes.new(self.name)
        bm.to_mesh(me)
        bm.free()
        for t in self.tones:
            me.materials.append(material(t))
        obj = bpy.data.objects.new(self.name, me)
        bpy.context.scene.collection.objects.link(obj)
        return obj


def tube(m, pts, rx, ry, sides, tone_fn, side_hint=Vector((1, 0, 0)), tip=False, cap_start=True, cap_end=True):
    """A closed tapered tube along pts. rx/ry: per-point radii of the elliptical ring (rx along the lateral axis).
    tone_fn(seg, k, normal) -> tone. tip=True ends in an apex at the last point instead of a ring."""
    n = len(pts)
    rings = []
    last = n - 1 if tip else n
    for i in range(last):
        d = (pts[min(i + 1, n - 1)] - pts[max(i - 1, 0)]).normalized()
        u = side_hint - d * side_hint.dot(d)
        if u.length < 1e-4:
            u = Vector((0, 1, 0)) - d * d.y
        u.normalize()
        v = d.cross(u)
        ring = []
        for k in range(sides):
            a = 2 * math.pi * k / sides
            ring.append(m.vert(pts[i] + u * (math.cos(a) * rx[i]) + v * (math.sin(a) * ry[i])))
        rings.append(ring)
    for i in range(len(rings) - 1):
        for k in range(sides):
            k2 = (k + 1) % sides
            f = m.bm.faces.new((rings[i][k], rings[i][k2], rings[i + 1][k2], rings[i + 1][k]))
            f.normal_update()
            m.paint(f, tone_fn(i, k, f.normal))
    if tip:
        apex = m.vert(pts[-1])
        for k in range(sides):
            k2 = (k + 1) % sides
            f = m.bm.faces.new((rings[-1][k], rings[-1][k2], apex))
            f.normal_update()
            m.paint(f, tone_fn(len(rings) - 1, k, f.normal))
    elif cap_end:
        c = m.vert(pts[-1])
        for k in range(sides):
            m.face((c, rings[-1][k], rings[-1][(k + 1) % sides]), tone_fn(len(rings) - 1, k, Vector((0, 0, 1))))
    if cap_start:
        c = m.vert(pts[0])
        for k in range(sides):
            m.face((c, rings[0][(k + 1) % sides], rings[0][k]), tone_fn(0, k, Vector((0, 0, -1))))


def lobe(m, centre, radii, sub, jitter, rng, tone_fn, squash=0.7):
    """A lumpy icosphere clump. sub 2 = 80 tris, sub 3 = 320 tris (Blender's icosphere subdivisions)."""
    res = bmesh.ops.create_icosphere(m.bm, subdivisions=sub, radius=1.0)
    verts = res["verts"]
    for v in verts:
        n = v.co.normalized()
        j = 1.0 + rng.uniform(-jitter, jitter)
        z = n.z * radii[2] * (1.0 if n.z > 0 else squash)
        v.co = centre + Vector((n.x * radii[0] * j, n.y * radii[1] * j, z * j))
    faces = {f for v in verts for f in v.link_faces}
    for f in faces:
        f.normal_update()
        m.paint(f, tone_fn(f.normal, f.calc_center_median() - centre))


def canopy_tone(bias=0.0):
    def fn(normal, off):
        d = normal.dot(LIGHT) - bias
        if normal.z < -0.25 or d < 0.0:
            return "leaf_shade"
        return "leaf_lit" if d > 0.52 else "leaf_mid"
    return fn


# ---------------------------------------------------------------------------------------------------------------- trees
def trunk(m, rng, height, r0, lean, sway, name_tone=True, rings=7):
    pts, rx = [], []
    for i in range(rings):
        t = i / (rings - 1)
        pts.append(Vector((lean * t * t, sway * math.sin(t * math.pi * 0.9), height * t)))
        flare = 1.0 + 1.3 * max(0.0, 1.0 - t / 0.14) ** 2
        rx.append(r0 * (1.0 - 0.5 * t) * flare)
    tone = lambda seg, k, n: "bark_dark" if seg == 0 else ("bark_light" if k % 4 == 0 else "bark")
    tube(m, pts, rx, rx, 8, tone, side_hint=Vector((1, 0, 0)))
    return pts


def build_broadleaf(name, seed, trunk_h, trunk_r, lean, sway, layers, lobe_r, max_tris, roots=0, droop=0.0):
    rng = random.Random(seed)
    m = Mesher(name)
    spine = trunk(m, rng, trunk_h, trunk_r, lean, sway)
    top = spine[-1]
    clumps = []
    for li, (z, ring_r, count, clump_r) in enumerate(layers):
        a0 = rng.uniform(0, math.tau)
        for ci in range(count):
            a = a0 + ci * math.tau / count + li * 0.95 + rng.uniform(-0.25, 0.25)
            centre = Vector((top.x + math.cos(a) * ring_r, top.y + math.sin(a) * ring_r, z))
            clumps.append((li, centre, clump_r))
    # lobe plan: 3-5 lobes per clump; the budget trims the smallest back from 320 to 80 tris
    plan = []
    for li, centre, clump_r in clumps:
        for _ in range(rng.choice((3, 4, 4, 5))):
            off = Vector((rng.uniform(-1, 1), rng.uniform(-1, 1), rng.uniform(-0.5, 0.7))) * clump_r * 0.85
            s = lobe_r * rng.uniform(0.78, 1.22)
            plan.append([li, centre + off - Vector((0, 0, droop * s)) * (1 if li == 0 else 0), s, 3])
    cost = lambda: sum(320 if p[3] == 3 else 80 for p in plan) + m.tris()
    for p in sorted(plan, key=lambda p: p[2]):
        if cost() <= max_tris:
            break
        p[3] = 2
    for li, centre, s, sub in plan:
        lobe(m, centre, (s, s, s * 0.82), sub, 0.13, rng, canopy_tone(bias=0.14 * (len(layers) - 1 - li) / max(1, len(layers) - 1) * -1.0 + 0.1 * (0 if li else 1)))
    # branches from the trunk into the lowest clumps
    low = [c for c in clumps if c[0] == 0]
    for i, (li, centre, clump_r) in enumerate(low[:3]):
        start = Vector((spine[4].x, spine[4].y, trunk_h * 0.62))
        end = Vector((centre.x * 0.62 + spine[4].x * 0.38, centre.y * 0.62 + spine[4].y * 0.38, centre.z - 0.2))
        mid = (start + end) * 0.5 + Vector((0, 0, 0.25))
        bark = lambda seg, k, n: "bark"
        tube(m, [start, mid, end], [0.17, 0.12, 0.07], [0.17, 0.12, 0.07], 6, bark, side_hint=Vector((0, 0, 1)))
    for i in range(roots):
        a = math.tau * i / roots + rng.uniform(-0.3, 0.3)
        d = Vector((math.cos(a), math.sin(a), 0))
        pts = [d * (trunk_r * 0.5) + Vector((0, 0, trunk_r * 2.2)), d * (trunk_r * 1.9) + Vector((0, 0, trunk_r * 0.9)), d * (trunk_r * 3.2) + Vector((0, 0, trunk_r * 0.25))]
        root_tone = lambda seg, k, n: "bark_dark"
        tube(m, pts, [trunk_r * 0.55, trunk_r * 0.45, trunk_r * 0.22], [trunk_r * 0.55, trunk_r * 0.45, trunk_r * 0.22], 6, root_tone, side_hint=Vector((0, 0, 1)))
    return m.finish()


def build_pine(name, seed, height, tiers, base_r, sides):
    rng = random.Random(seed)
    m = Mesher(name)
    pts = [Vector((0, 0, height * t)) for t in (0.0, 0.1, 0.4, 0.7, 0.97)]
    rx = [0.38, 0.27, 0.2, 0.13, 0.04]
    tube(m, pts, rx, rx, 7, lambda seg, k, n: "bark_dark" if seg == 0 else "bark")
    for i in range(tiers):
        t = i / (tiers - 1)
        z0 = 1.5 + t * (height - 3.7)
        r = base_r * (1.0 - t) ** 0.85 + 0.32
        h = 1.55 + (1.0 - t) * 0.95
        spin = i * 0.55 + rng.uniform(-0.1, 0.1)
        npts = sides * 2
        B, M = [], []
        for j in range(npts):
            a = spin + math.tau * j / npts
            rr = r * (1.0 if j % 2 == 0 else 0.7) * rng.uniform(0.92, 1.06)
            B.append(m.vert(Vector((math.cos(a) * rr, math.sin(a) * rr, z0 - (0.2 if j % 2 == 0 else 0.0)))))
            rm = r * 0.52 * (1.0 if j % 2 == 0 else 0.85)
            M.append(m.vert(Vector((math.cos(a) * rm, math.sin(a) * rm, z0 + h * 0.5))))
        apex = m.vert(Vector((0, 0, z0 + h)))
        centre = m.vert(Vector((0, 0, z0 + h * 0.18)))

        def needle_tone(nrm, up):
            d = nrm.dot(LIGHT)
            if not up or d < 0.0:
                return "needle_shade"
            return "needle_lit" if d > 0.5 else "needle_mid"

        for j in range(npts):
            j2 = (j + 1) % npts
            f = m.bm.faces.new((B[j], B[j2], M[j2], M[j])); f.normal_update(); m.paint(f, needle_tone(f.normal, True))
            f = m.bm.faces.new((M[j], M[j2], apex)); f.normal_update(); m.paint(f, needle_tone(f.normal, True))
            m.face((centre, B[j2], B[j]), "needle_shade")
    return m.finish()


def build_bush(name, seed, lobes, spread, max_tris, berries=0):
    rng = random.Random(seed)
    m = Mesher(name)
    for i, (r, sub) in enumerate(lobes):
        a = math.tau * i / len(lobes) + rng.uniform(-0.3, 0.3)
        d = spread * (0.0 if i == 0 else rng.uniform(0.7, 1.0))
        c = Vector((math.cos(a) * d, math.sin(a) * d, r * 0.72))
        lobe(m, c, (r, r, r * 0.85), sub, 0.14, rng, canopy_tone(0.05), squash=0.4)
    for _ in range(berries):
        a = rng.uniform(0, math.tau)
        d = spread * rng.uniform(0.5, 1.3)
        c = Vector((math.cos(a) * d, math.sin(a) * d, rng.uniform(0.55, 0.9)))
        lobe(m, c, (0.07, 0.07, 0.07), 1, 0.05, rng, lambda n, o: "berry")
    return m.finish()


# --------------------------------------------------------------------------------------------------- grass, fern, rock
def blade(m, base, azimuth, height, width, lean, tone_fn, rng, sides=3, thick=0.4, ncurve=3):
    d = Vector((math.cos(azimuth), math.sin(azimuth), 0))
    pts, rx, ry = [], [], []
    for i in range(ncurve + 1):
        t = i / ncurve
        pts.append(base + d * (lean * height * t * t) + Vector((0, 0, height * (1.0 - 0.25 * lean * t * t) * t)))
    for i in range(ncurve):
        t = i / ncurve
        w = width * (1.0 - 0.65 * t)
        rx.append(w)
        ry.append(w * thick)
    rx.append(0.0); ry.append(0.0)
    side = Vector((-d.y, d.x, 0))
    tube(m, pts, rx, ry, sides, tone_fn, side_hint=side, tip=True)


def build_grass_tuft(name, seed):
    rng = random.Random(seed)
    m = Mesher(name)
    tone = lambda seg, k, n: ("grass_dark", "grass_shade", "grass_lit")[min(seg, 2)]
    for i in range(30):
        a = rng.uniform(0, math.tau)
        rr = 0.26 * math.sqrt(rng.random())
        base = Vector((math.cos(a) * rr, math.sin(a) * rr, 0))
        out = math.atan2(base.y, base.x) + rng.uniform(-0.5, 0.5)
        blade(m, base, out, rng.uniform(0.32, 0.72), rng.uniform(0.032, 0.048), rng.uniform(0.15, 0.55), tone, rng)
    return m.finish()


def build_fern(name, seed, fronds=11):
    rng = random.Random(seed)
    m = Mesher(name)
    tone = lambda seg, k, n: ("leaf_shade", "grass_shade", "grass_shade", "grass_lit", "grass_lit")[min(seg // 2, 4)]
    for i in range(fronds):
        phi = math.tau * i / fronds + rng.uniform(-0.2, 0.2)
        length = rng.uniform(0.62, 0.95)
        d = Vector((math.cos(phi), math.sin(phi), 0))
        steps = 9
        pts, rx, ry = [], [], []
        p = Vector((d.x * 0.03, d.y * 0.03, 0.03))
        pts.append(p.copy())
        for s in range(steps):
            t = (s + 0.5) / steps
            ang = math.radians(60 - 95 * t)
            p = p + (d * math.cos(ang) + Vector((0, 0, math.sin(ang)))) * (length / steps)
            pts.append(p.copy())
        for s in range(steps):
            t = s / steps
            w = 0.15 * math.sin(math.pi * (0.12 + 0.85 * t)) ** 0.7 * (1.0 if s % 2 == 0 else 0.62)
            rx.append(max(w, 0.012))
            ry.append(0.011)
        rx.append(0.0); ry.append(0.0)
        tube(m, pts, rx, ry, 4, tone, side_hint=Vector((-d.y, d.x, 0)), tip=True)
    return m.finish()


def build_flowers(name, seed, count=7):
    rng = random.Random(seed)
    m = Mesher(name)
    stem_tone = lambda seg, k, n: "grass_shade"
    for i in range(count):
        a = rng.uniform(0, math.tau)
        rr = 0.22 * math.sqrt(rng.random())
        base = Vector((math.cos(a) * rr, math.sin(a) * rr, 0))
        h = rng.uniform(0.3, 0.55)
        lean = Vector((math.cos(a), math.sin(a), 0)) * rng.uniform(0.02, 0.1)
        pts = [base, base + lean * 0.4 + Vector((0, 0, h * 0.5)), base + lean + Vector((0, 0, h))]
        tube(m, pts, [0.014, 0.011, 0.01], [0.014, 0.011, 0.01], 3, stem_tone, side_hint=Vector((0, 0, 1)), cap_end=True)
        head = pts[-1]
        for p in range(5):
            pa = math.tau * p / 5 + rng.uniform(-0.1, 0.1)
            pd = Vector((math.cos(pa) * 0.8, math.sin(pa) * 0.8, 0.45)).normalized()
            tube(m, [head, head + pd * 0.04, head + pd * 0.095], [0.026, 0.036, 0.0], [0.01, 0.012, 0.0], 4,
                 lambda seg, k, n: "flower_violet", side_hint=Vector((-pd.y, pd.x, 0)), tip=True)
        lobe(m, head + Vector((0, 0, 0.012)), (0.03, 0.03, 0.03), 1, 0.0, rng, lambda n, o: "flower_cream")
    tone = lambda seg, k, n: ("grass_dark", "grass_shade", "grass_lit")[min(seg, 2)]
    for i in range(6):
        a = math.tau * i / 6 + rng.uniform(-0.3, 0.3)
        rr = 0.12 * math.sqrt(rng.random())
        blade(m, Vector((math.cos(a) * rr, math.sin(a) * rr, 0)), a, rng.uniform(0.2, 0.34), 0.045, rng.uniform(0.5, 0.9), tone, rng)
    return m.finish()


def build_rock(name, seed):
    rng = random.Random(seed)
    m = Mesher(name)

    def rock_tone(n, off):
        if n.z > 0.5:
            return "moss"
        if n.z > 0.18:
            return "moss_dark"
        if n.z < -0.1 or n.dot(LIGHT) < -0.1:
            return "rock_dark"
        return "rock"

    for centre, radii, sub in ((Vector((0, 0, 0.5)), (0.95, 0.78, 0.62), 3), (Vector((0.95, 0.35, 0.24)), (0.42, 0.36, 0.3), 2), (Vector((-0.62, -0.78, 0.2)), (0.3, 0.27, 0.22), 2)):
        res = bmesh.ops.create_icosphere(m.bm, subdivisions=sub, radius=1.0)
        verts = res["verts"]
        for v in verts:
            n = v.co.normalized()
            j = 1.0 + rng.uniform(-0.2, 0.2)
            v.co = centre + Vector((n.x * radii[0] * j, n.y * radii[1] * j, n.z * radii[2] * j))
            if v.co.z < 0.04:
                v.co.z = 0.0
        faces = {f for v in verts for f in v.link_faces}
        for f in faces:
            f.normal_update()
            m.paint(f, rock_tone(f.normal, Vector()))
    return m.finish()


# ------------------------------------------------------------------------------------------------------------ the kit
def make_kit(only=None):
    specs = {
        "tree_broadleaf_a": lambda: build_broadleaf("tree_broadleaf_a", 11, 3.4, 0.34, 0.25, 0.2,
                                                    [(3.5, 1.9, 2, 1.1), (4.9, 1.3, 2, 1.0), (6.0, 0.35, 1, 1.0)], 1.25, 6300),
        "tree_broadleaf_b": lambda: build_broadleaf("tree_broadleaf_b", 23, 4.4, 0.3, -0.35, -0.3,
                                                    [(4.4, 1.7, 3, 0.95), (5.9, 1.2, 2, 0.95), (7.2, 0.3, 1, 0.9)], 1.15, 6800),
        "tree_broadleaf_c": lambda: build_broadleaf("tree_broadleaf_c", 37, 3.0, 0.42, 0.1, 0.35,
                                                    [(2.9, 2.5, 3, 1.15), (4.3, 1.8, 3, 1.1), (5.5, 0.9, 2, 1.0), (6.5, 0.0, 1, 0.9)], 1.2, 7800, roots=4, droop=0.35),
        "tree_pine_a": lambda: build_pine("tree_pine_a", 5, 11.0, 14, 2.3, 13),
        "bush_a": lambda: build_bush("bush_a", 3, [(0.55, 3), (0.38, 2), (0.34, 2), (0.36, 2), (0.3, 2)], 0.5, 1200),
        "bush_b": lambda: build_bush("bush_b", 8, [(0.42, 3), (0.35, 2), (0.33, 2), (0.3, 2), (0.3, 2), (0.28, 2)], 0.62, 1200, berries=7),
        "grass_tuft": lambda: build_grass_tuft("grass_tuft", 2),
        "fern_clump": lambda: build_fern("fern_clump", 4),
        "flower_clump": lambda: build_flowers("flower_clump", 6),
        "rock_mossy_a": lambda: build_rock("rock_mossy_a", 9),
    }
    objs = {}
    for name, fn in specs.items():
        if only and name not in only:
            continue
        objs[name] = fn()
    return objs


def tri_count(obj):
    return sum(len(p.vertices) - 2 for p in obj.data.polygons)


def export_fbx(obj):
    os.makedirs(FBX_DIR, exist_ok=True)
    bpy.ops.object.select_all(action="DESELECT")
    obj.select_set(True)
    bpy.context.view_layer.objects.active = obj
    path = os.path.join(FBX_DIR, f"{obj.name}.fbx")
    bpy.ops.export_scene.fbx(filepath=path, use_selection=True, object_types={"MESH"}, axis_forward="-Z", axis_up="Y",
                             apply_scale_options="FBX_SCALE_UNITS", bake_space_transform=True, mesh_smooth_type="FACE",
                             colors_type="SRGB", path_mode="AUTO")
    return path


# --------------------------------------------------------------------------------------------------------- previews
def _bbox(objs):
    pts = [o.matrix_world @ Vector(c) for o in objs for c in o.bound_box]
    lo = Vector((min(p.x for p in pts), min(p.y for p in pts), min(p.z for p in pts)))
    hi = Vector((max(p.x for p in pts), max(p.y for p in pts), max(p.z for p in pts)))
    return lo, hi


def _ground(radius, centre=Vector((0, 0, 0)), tone="grass_lit"):
    bm = bmesh.new()
    bmesh.ops.create_circle(bm, cap_ends=True, radius=radius, segments=48)
    me = bpy.data.meshes.new("ground")
    bm.to_mesh(me)
    bm.free()
    me.materials.append(material(tone))
    o = bpy.data.objects.new("ground", me)
    o.location = centre
    bpy.context.scene.collection.objects.link(o)
    return o


def _human():
    """A 1.7 m flat lavender-grey scale silhouette (art_direction.md section 3.1)."""
    bm = bmesh.new()
    def box(cx, cy, cz, sx, sy, sz):
        res = bmesh.ops.create_cube(bm, size=1.0)
        for v in res["verts"]:
            v.co = Vector((cx + v.co.x * sx, cy + v.co.y * sy, cz + v.co.z * sz))
    box(-0.09, 0, 0.42, 0.14, 0.12, 0.84)
    box(0.09, 0, 0.42, 0.14, 0.12, 0.84)
    box(0, 0, 1.12, 0.42, 0.18, 0.56)
    res = bmesh.ops.create_icosphere(bm, subdivisions=2, radius=0.12)
    for v in res["verts"]:
        v.co += Vector((0, 0, 1.58))
    me = bpy.data.meshes.new("human")
    bm.to_mesh(me)
    bm.free()
    mat = bpy.data.materials.new("human_ref")
    mat.diffuse_color = (*[srgb_to_linear(c) for c in hex_rgb("#A9A6C2")], 1.0)
    me.materials.append(mat)
    o = bpy.data.objects.new("human", me)
    bpy.context.scene.collection.objects.link(o)
    return o


def _setup_render(width, height):
    sc = bpy.context.scene
    sc.render.engine = "BLENDER_WORKBENCH"
    sc.render.resolution_x, sc.render.resolution_y = width, height
    sc.render.resolution_percentage = 100
    sc.render.film_transparent = False
    sc.view_settings.view_transform = "Standard"
    sc.view_settings.look = "None"
    sh = sc.display.shading
    sh.light = "STUDIO"
    sh.color_type = "MATERIAL"
    sh.show_object_outline = True
    sh.object_outline_color = (0.12, 0.09, 0.06)
    sh.show_cavity = False
    sh.show_shadows = False
    world = bpy.data.worlds.new("sky")
    world.color = tuple(srgb_to_linear(c) for c in hex_rgb("#BFE3F2"))
    sc.world = world
    cam = bpy.data.objects.new("cam", bpy.data.cameras.new("cam"))
    cam.data.lens = 50
    bpy.context.scene.collection.objects.link(cam)
    sc.camera = cam
    return cam


def _aim(cam, eye, target):
    cam.location = eye
    cam.rotation_euler = (target - eye).to_track_quat("-Z", "Y").to_euler()


def _render(path):
    bpy.context.scene.render.filepath = path
    bpy.ops.render.render(write_still=True)


def _read(path):
    import numpy as np
    img = bpy.data.images.load(path)
    w, h = img.size
    arr = np.empty(w * h * 4, dtype=np.float32)
    img.pixels.foreach_get(arr)
    bpy.data.images.remove(img)
    return arr.reshape(h, w, 4)


def _write(arr, path):
    h, w = arr.shape[:2]
    img = bpy.data.images.new("out", w, h, alpha=False)
    img.pixels.foreach_set(arr.astype("float32").reshape(-1))
    img.filepath_raw = path
    img.file_format = "PNG"
    img.save()
    bpy.data.images.remove(img)


def render_previews(objs, out_dir):
    import numpy as np
    os.makedirs(out_dir, exist_ok=True)
    cam = _setup_render(512, 512)
    ink = bpy.data.materials.new("ink")
    ink.diffuse_color = (*[srgb_to_linear(c) for c in hex_rgb("#3A2A1C")], 1.0)
    human = _human()
    ground = _ground(1.0)
    tiles = []
    names = list(objs.keys())
    for name in names:
        o = objs[name]
        for other in objs.values():
            other.hide_render = other is not o
        lo, hi = _bbox([o])
        size = hi - lo
        centre = (lo + hi) * 0.5
        radius = max(size.length * 0.5, 0.3)
        fov = 2 * math.atan(18 / 50)
        dist = radius / math.sin(fov / 2) * 1.12
        yaw, pitch = math.radians(-35), math.radians(22)
        eye = centre + Vector((math.sin(yaw) * math.cos(pitch), -math.cos(yaw) * math.cos(pitch), math.sin(pitch))) * dist
        _aim(cam, eye, centre)
        ground.scale = (radius * 3.0, radius * 3.0, 1.0)
        right = Vector((math.cos(yaw), math.sin(yaw), 0))
        human.location = Vector((centre.x, centre.y, 0)) + right * radius * 1.05 + Vector((-right.y, right.x, 0)) * radius * 0.9
        label = bpy.data.curves.new("lbl", "FONT")
        label.body = f"{name}  {tri_count(o)} tris  {size.z:.1f} m tall"
        half = dist * math.tan(fov / 2)
        label.size = half * 0.075
        lo_obj = bpy.data.objects.new("lbl", label)
        lo_obj.data.materials.append(ink)
        bpy.context.scene.collection.objects.link(lo_obj)
        lo_obj.parent = cam
        lo_obj.location = (-half * 0.94, -half * 0.9, -dist)
        path = os.path.join(out_dir, f"_tile_{name}.png")
        _render(path)
        tiles.append(_read(path))
        os.remove(path)
        bpy.data.objects.remove(lo_obj)
    for other in objs.values():
        other.hide_render = False
    cols = 5
    rows = (len(tiles) + cols - 1) // cols
    sheet = np.ones((rows * 512, cols * 512, 4), dtype=np.float32)
    for i, t in enumerate(tiles):
        r, c = divmod(i, cols)
        y0 = (rows - 1 - r) * 512  # image rows run bottom to top
        sheet[y0:y0 + 512, c * 512:(c + 1) * 512] = t
    _write(sheet, os.path.join(out_dir, "contact_sheet.png"))
    small = []
    for t in tiles:
        g = t[..., :3] @ np.array([0.2126, 0.7152, 0.0722], dtype=np.float32)
        g = g.reshape(128, 4, 128, 4).mean(axis=(1, 3))
        small.append(np.dstack([g, g, g, np.ones_like(g)]))
    grey = np.ones((rows * 128, cols * 128, 4), dtype=np.float32)
    for i, t in enumerate(small):
        r, c = divmod(i, cols)
        grey[(rows - 1 - r) * 128:(rows - r) * 128, c * 128:(c + 1) * 128] = t
    _write(grey, os.path.join(out_dir, "silhouette_25pct_grey.png"))
    # forest scatter
    for o in (human, ground):
        o.hide_render = True
    for o in objs.values():
        o.hide_render = True
    scatter_scene(objs)
    sc = bpy.context.scene
    sc.render.resolution_x, sc.render.resolution_y = 1280, 720
    _aim(cam, Vector((-17, -21, 15)), Vector((0, 1, 2.2)))
    _render(os.path.join(out_dir, "forest_overview.png"))
    cam.data.lens = 28
    _aim(cam, Vector((0, -17, 1.9)), Vector((0, 0, 2.4)))
    _render(os.path.join(out_dir, "forest_eye_level.png"))


def scatter_scene(objs):
    """A 36 x 36 m patch: the three-tone ground and the kit placed the way the scene builder will."""
    rng = random.Random(77)
    sc = bpy.context.scene
    ground = _ground(26.0)
    ground.name = "forest_floor"
    for i in range(18):
        a = rng.uniform(0, math.tau); d = rng.uniform(2, 16)
        g = _ground(rng.uniform(2.5, 5), Vector((math.cos(a) * d, math.sin(a) * d, 0.01)), "grass_shade")
    for i in range(10):
        a = rng.uniform(0, math.tau); d = rng.uniform(2, 16)
        g = _ground(rng.uniform(2, 3.5), Vector((math.cos(a) * d, math.sin(a) * d, 0.02)), "grass_lit")
    placed = []

    def put(name, x, y, scale, yaw=None):
        o = bpy.data.objects.new(name, objs[name].data)
        o.location = (x, y, 0.03)
        o.rotation_euler = (0, 0, rng.uniform(0, math.tau) if yaw is None else yaw)
        o.scale = (scale,) * 3
        sc.collection.objects.link(o)
        placed.append((x, y))

    trees = ["tree_broadleaf_a", "tree_broadleaf_b", "tree_broadleaf_c", "tree_pine_a"]
    treepos = []
    tries = 0
    while len(treepos) < 22 and tries < 500:
        tries += 1
        x, y = rng.uniform(-17, 17), rng.uniform(-14, 18)
        if abs(x) < 2.2 and y < 6:
            continue
        if any(math.hypot(x - a, y - b) < 4.2 for a, b in treepos):
            continue
        treepos.append((x, y))
        put(rng.choice(trees), x, y, rng.uniform(0.85, 1.25))
    def free(x, y, r):
        return all(math.hypot(x - a, y - b) > r for a, b in treepos)
    for name, n, r, sc_rng in (("bush_a", 14, 1.7, (0.85, 1.3)), ("bush_b", 10, 1.7, (0.85, 1.25)), ("rock_mossy_a", 5, 1.8, (0.7, 1.3)),
                               ("fern_clump", 16, 1.2, (0.9, 1.4))):
        k = 0
        while k < n:
            x, y = rng.uniform(-19, 19), rng.uniform(-14, 19)
            if abs(x) < 1.6 or not free(x, y, r):
                continue
            put(name, x, y, rng.uniform(*sc_rng)); k += 1
    for i in range(110):
        x, y = rng.uniform(-19, 19), rng.uniform(-15, 19)
        if abs(x) < 1.0:
            continue
        put("grass_tuft", x, y, rng.uniform(0.9, 1.7))
    for cx, cy in ((-7, -4), (9, 3), (3, 12)):
        for i in range(5):
            put("flower_clump", cx + rng.uniform(-1.5, 1.5), cy + rng.uniform(-1.5, 1.5), rng.uniform(0.9, 1.3))


def main():
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    only = None
    if "--only" in argv:
        only = set(argv[argv.index("--only") + 1].split(","))
    export = "--no-export" not in argv
    preview = argv[argv.index("--preview") + 1] if "--preview" in argv else None
    bpy.ops.wm.read_factory_settings(use_empty=True)
    objs = make_kit(only)
    for name, o in objs.items():
        lo, hi = _bbox([o])
        lo_b, hi_b = (hi - lo), None
        print(f"[Ascend] {name}: {tri_count(o)} tris, {len(o.data.materials)} materials, {hi.z - lo.z:.2f} m tall, width {max(hi.x - lo.x, hi.y - lo.y):.2f} m")
    if export:
        for name, o in objs.items():
            print("[Ascend] exported", export_fbx(o))
    if preview:
        render_previews(objs, os.path.join(ROOT, preview) if not os.path.isabs(preview) else preview)
    os.makedirs(os.path.dirname(BLEND_PATH), exist_ok=True)
    bpy.ops.wm.save_as_mainfile(filepath=BLEND_PATH)


if __name__ == "__main__" or "bpy" in sys.modules:
    main()
