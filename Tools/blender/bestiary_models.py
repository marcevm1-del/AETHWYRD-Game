"""
Procedural blockout models for every species in Data/Monsters/species.json, built from each species' designRecipe
(baseMesh, parts, material, palette, menaceStyle) and rendered as front / side / back turnarounds plus a labelled sheet.

These are reference blockouts for the bestiary and art direction, not final game art: shapes are composed from
primitives, but every species gets its own silhouette, parts, colours and real size.

Run headless (all species, or a slice for batching):
  blender -b --factory-startup -P Tools/blender/bestiary_models.py
  blender -b --factory-startup -P Tools/blender/bestiary_models.py -- --start 0 --count 120
  blender -b --factory-startup -P Tools/blender/bestiary_models.py -- --ids mon_goblin,mon_forest_wolf
Output: 08_Bestiary/turnarounds/<Family>/<species_id>_{front,side,back,sheet}.jpg
Conventions: the model is built facing -Y (Blender), feet on z = 0, height about 1 unit before scaling.
"""
import json
import math
import os
import random
import sys

import bpy
from mathutils import Vector

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", ".."))
SPECIES = os.path.join(ROOT, "Data", "Monsters", "species.json")
OUT = os.path.join(ROOT, "08_Bestiary", "turnarounds")
VIEWS = [("front", 0.0), ("side", -90.0), ("back", 180.0)]
RES_VIEW, RES_SHEET = (640, 640), (1500, 640)


# ======================================================================== materials
def hex_rgb(h):
    h = h.lstrip("#")
    return tuple(int(h[i:i + 2], 16) / 255.0 for i in (0, 2, 4))


def srgb_to_linear(c):
    return tuple(x / 12.92 if x <= 0.04045 else ((x + 0.055) / 1.055) ** 2.4 for x in c)


MATERIAL_STYLE = {  # roughness, metallic, emission strength, alpha
    "translucent_gel_sss": (0.08, 0.0, 0.0, 0.75), "rough_skin_leather": (0.75, 0.0, 0.0, 1), "fur_short": (0.9, 0, 0, 1),
    "fur_groom": (0.85, 0, 0, 1), "fur_rough": (0.95, 0, 0, 1), "fur_soft": (0.9, 0, 0, 1), "chitin_gloss": (0.2, 0.1, 0, 1),
    "chitin_matte": (0.6, 0.05, 0, 1), "rot_bone": (0.8, 0, 0, 1), "shadow_smoke": (0.9, 0, 0.6, 0.7), "thick_skin": (0.7, 0, 0, 1),
    "short_hide": (0.75, 0, 0, 1), "scale_matte": (0.6, 0.05, 0, 1), "dragon_scale": (0.35, 0.25, 0, 1),
    "stone_metal_runes": (0.55, 0.4, 0, 1), "elemental_emissive": (0.3, 0, 2.5, 0.9), "bark_leaf": (0.9, 0, 0, 1),
    "demon_hide_emissive": (0.5, 0.1, 0.8, 1), "wet_scale": (0.15, 0.1, 0, 1), "feather_groom": (0.85, 0, 0, 1),
    "mixed_hide": (0.8, 0, 0, 1), "scale_gloss": (0.2, 0.2, 0, 1), "horse_coat": (0.6, 0, 0, 1), "old_iron": (0.45, 0.85, 0, 1),
    "rubbery_skin": (0.35, 0, 0, 1), "wet_flesh_unsettling": (0.2, 0, 0, 1), "paper_ink_spirit": (0.95, 0, 0.4, 0.95),
    "dungeon_stone": (0.85, 0.05, 0, 1), "porcelain_red_glow": (0.12, 0, 0, 1), "sand_hide": (0.85, 0, 0, 1),
    "cloth_leather_metal": (0.7, 0.3, 0, 1),
}
_MATS = {}


def mat(key, color, rough=0.6, metal=0.0, emit=0.0, alpha=1.0):
    k = (key, tuple(round(c, 3) for c in color), rough, metal, emit, alpha)
    if k in _MATS:
        return _MATS[k]
    m = bpy.data.materials.new(key)
    m.use_nodes = True
    b = next(n for n in m.node_tree.nodes if n.type == "BSDF_PRINCIPLED")
    lin = srgb_to_linear(color)
    b.inputs["Base Color"].default_value = (*lin, 1)
    b.inputs["Roughness"].default_value = rough
    b.inputs["Metallic"].default_value = metal
    if emit > 0:
        b.inputs["Emission Color"].default_value = (*lin, 1)
        b.inputs["Emission Strength"].default_value = emit
    if alpha < 1:
        b.inputs["Alpha"].default_value = alpha
        try:
            m.surface_render_method = "BLENDED"
        except Exception:
            pass
    m.diffuse_color = (*lin, 1)
    _MATS[k] = m
    return m


class Palette:
    def __init__(self, recipe, element):
        cols = [hex_rgb(c) for c in (recipe.get("palette") or ["#888888", "#555555", "#cccccc"])]
        while len(cols) < 3:
            cols.append(cols[-1])
        style = MATERIAL_STYLE.get(recipe.get("material", ""), (0.7, 0, 0, 1))
        r, me, em, al = style
        self.body = mat("body", cols[0], r, me, em * 0.3, al)
        self.dark = mat("dark", cols[1], min(1, r + 0.1), me)
        self.accent = mat("accent", cols[2], 0.4, me * 0.5)
        glow = cols[2] if recipe.get("material") not in ("porcelain_red_glow",) else (1.0, 0.15, 0.1)
        self.glow = mat("glow", glow, 0.3, 0, 4.0)
        self.eye = mat("eye", (0.05, 0.05, 0.07), 0.2)
        self.eye_glow = mat("eyeglow", (1.0, 0.25, 0.15) if element in ("Fire", "Dark", "Blood", "None") else (0.4, 0.8, 1.0), 0.2, 0, 5.0)
        self.bone = mat("bone", (0.9, 0.86, 0.74), 0.5)
        self.metal = mat("metal", (0.55, 0.57, 0.6), 0.35, 0.85)
        self.cloth = mat("cloth", tuple(c * 0.7 for c in cols[1]), 0.95)
        self.wood = mat("wood", (0.38, 0.25, 0.15), 0.8)
        self.leaf = mat("leaf", (0.3, 0.5, 0.2), 0.8)


# ======================================================================== primitives
def _finish(o, m, smooth=True):
    o.data.materials.append(m)
    if smooth:
        for p in o.data.polygons:
            p.use_smooth = True
    return o


def ell(loc, radii, m, seg=20, rings=12):
    bpy.ops.mesh.primitive_uv_sphere_add(segments=seg, ring_count=rings, radius=1, location=loc)
    o = bpy.context.active_object
    o.scale = radii
    return _finish(o, m)


def cyl(a, b, r, m, r2=None, verts=12):
    a, b = Vector(a), Vector(b)
    d = b - a
    if r2 is None:
        bpy.ops.mesh.primitive_cylinder_add(vertices=verts, radius=r, depth=d.length, location=(a + b) / 2)
    else:
        bpy.ops.mesh.primitive_cone_add(vertices=verts, radius1=r, radius2=r2, depth=d.length, location=(a + b) / 2)
    o = bpy.context.active_object
    o.rotation_euler = Vector((0, 0, 1)).rotation_difference(d.normalized()).to_euler() if d.length > 1e-6 else (0, 0, 0)
    return _finish(o, m)


def cone(a, b, r, m, verts=10):
    return cyl(a, b, r, m, r2=0.0, verts=verts)


def box(loc, size, m, rot=(0, 0, 0)):
    bpy.ops.mesh.primitive_cube_add(size=1, location=loc, rotation=rot)
    o = bpy.context.active_object
    o.scale = size
    return _finish(o, m, smooth=False)


def tor(loc, r, t, m, rot=(0, 0, 0)):
    bpy.ops.mesh.primitive_torus_add(major_radius=r, minor_radius=t, location=loc, rotation=rot, major_segments=24, minor_segments=8)
    return _finish(bpy.context.active_object, m)


def limb(a, b, r, m, joint=True):
    parts = [cyl(a, b, r, m)]
    if joint:
        parts.append(ell(b, (r * 1.15,) * 3, m, 10, 6))
    return parts


# ======================================================================== anatomy
class Body:
    """The built body plus named anchors that parts attach to (all in model space, front = -Y)."""

    def __init__(self):
        self.objs = []
        self.head = Vector((0, 0, 1))      # head centre
        self.head_r = 0.15                  # head radius
        self.face = Vector((0, -0.15, 1))   # front of the face
        self.back = Vector((0, 0.05, 0.7))  # top of the back
        self.back_len = 0.3                 # length of the back line (for rows of plates)
        self.back_dir = Vector((0, 1, 0))   # direction the back line runs (quads: head→tail; bipeds: down the spine)
        self.chest = Vector((0, -0.1, 0.6))
        self.waist = Vector((0, 0, 0.45))
        self.tail_root = Vector((0, 0.2, 0.4))
        self.hands = []                     # hand positions
        self.shoulders = []
        self.feet = []
        self.neck = Vector((0, 0, 0.85))
        self.legged = True
        self.top = 1.0

    def add(self, *objs):
        for o in objs:
            if isinstance(o, list):
                self.objs.extend(o)
            else:
                self.objs.append(o)


def eyes(b, P, n=2, spread=0.45, glow=False, size=0.18):
    m = P.eye_glow if glow else P.eye
    r = b.head_r
    for i in range(n):
        x = (i - (n - 1) / 2) * spread * r * (2 / max(1, n - 1)) if n > 1 else 0
        b.add(ell((b.face.x + x, b.face.y + r * 0.05, b.head.z + r * 0.15), (r * size, r * size * 0.5, r * size * 1.1), m, 10, 6))


def base_blob(P, rng):
    b = Body()
    body = ell((0, 0, 0.42), (0.5, 0.5, 0.42), P.body, 28, 16)
    b.add(body)
    b.head, b.head_r, b.face = Vector((0, 0, 0.55)), 0.42, Vector((0, -0.48, 0.5))
    b.back, b.back_len, b.chest, b.waist = Vector((0, 0.1, 0.84)), 0.4, Vector((0, -0.2, 0.4)), Vector((0, 0, 0.3))
    b.tail_root, b.neck, b.top, b.legged = Vector((0, 0.45, 0.25)), Vector((0, 0, 0.8)), 0.85, False
    eyes(b, P, 2, 0.5, size=0.16)
    return b


def base_biped(P, rng, kind):
    # small = big head, short limbs; medium = human-ish; large = hulking, small head, long arms
    h = {"small": (0.30, 0.17, 0.5), "medium": (0.42, 0.12, 0.55), "large": (0.5, 0.09, 0.62)}[kind]
    leg_len, head_r, torso_z = h
    b = Body()
    width = {"small": 0.16, "medium": 0.18, "large": 0.27}[kind]
    hip_z = leg_len
    torso_top = torso_z + (0.25 if kind != "large" else 0.3)
    for s in (-1, 1):
        foot = Vector((s * width * 0.55, -0.02, 0.03))
        b.add(limb((s * width * 0.55, 0, hip_z), (s * width * 0.6, 0, 0.06), width * 0.28, P.body))
        b.add(ell(foot + Vector((0, -0.04, 0)), (width * 0.3, width * 0.5, 0.035), P.dark, 10, 6))
        b.feet.append(foot)
    b.add(ell((0, 0, (hip_z + torso_top) / 2 + 0.02), (width * 1.15, width * 0.8, (torso_top - hip_z) / 2 + 0.06), P.body))
    sh_z = torso_top - 0.03
    arm = {"small": 0.3, "medium": 0.4, "large": 0.55}[kind]
    for s in (-1, 1):
        sh = Vector((s * width * 1.2, 0, sh_z))
        hand = Vector((s * (width * 1.45), -0.05, max(0.12, sh_z - arm)))
        b.add(limb(sh, hand, width * (0.22 if kind != "large" else 0.3), P.body))
        b.add(ell(hand, (width * 0.25,) * 3, P.body, 10, 6))
        b.shoulders.append(sh)
        b.hands.append(hand)
    b.head_r = head_r
    b.head = Vector((0, -0.02, torso_top + head_r * 0.9))
    b.add(ell(b.head, (head_r, head_r * 0.95, head_r), P.body))
    b.face = b.head + Vector((0, -head_r * 0.95, 0))
    b.neck = Vector((0, 0, torso_top))
    b.back = Vector((0, width * 0.8, (hip_z + torso_top) / 2 + 0.05))
    b.back_len = (torso_top - hip_z) * 0.8
    b.back_dir = Vector((0, 0, -1))
    b.chest = Vector((0, -width * 0.8, (hip_z + torso_top) / 2 + 0.05))
    b.waist = Vector((0, 0, hip_z + 0.02))
    b.tail_root = Vector((0, width * 0.7, hip_z + 0.03))
    b.top = b.head.z + head_r
    eyes(b, P, 2)
    return b


def base_quad(P, rng, kind):
    big = kind == "large"
    L = 0.9 if big else 0.7     # body length
    H = 0.62 if big else 0.42   # body height (top of back)
    leg = H * 0.55
    b = Body()
    b.add(ell((0, 0, leg + H * 0.22), (0.2 if big else 0.17, L / 2, H * 0.25), P.body))
    for sx in (-1, 1):
        for sy in (-1, 1):
            top = Vector((sx * 0.12, sy * L * 0.32, leg + 0.05))
            foot = Vector((sx * 0.13, sy * L * 0.34, 0.03))
            b.add(cyl(top, foot, 0.045 if big else 0.035, P.body, r2=0.028 if big else 0.022))
            b.add(ell(foot, (0.05, 0.07, 0.03), P.dark, 8, 6))
            b.feet.append(foot)
    neck_base = Vector((0, -L * 0.42, leg + H * 0.3))
    b.head_r = 0.13 if big else 0.11
    b.head = Vector((0, -L * 0.58, leg + H * 0.55))
    b.add(cyl(neck_base, b.head, 0.08 if big else 0.06, P.body))
    b.add(ell(b.head, (b.head_r * 0.85, b.head_r * 1.15, b.head_r * 0.85), P.body))
    b.add(ell(b.head + Vector((0, -b.head_r * 1.0, -b.head_r * 0.25)), (b.head_r * 0.5, b.head_r * 0.6, b.head_r * 0.4), P.body))  # snout
    b.face = b.head + Vector((0, -b.head_r * 1.15, 0))
    b.neck = neck_base
    b.back = Vector((0, 0, leg + H * 0.45))
    b.back_len = L * 0.8
    b.chest = Vector((0, -L * 0.42, leg + H * 0.1))
    b.waist = Vector((0, L * 0.1, leg + H * 0.2))
    b.tail_root = Vector((0, L * 0.5, leg + H * 0.3))
    b.hands = [b.feet[0], b.feet[2]] if len(b.feet) >= 3 else b.feet
    b.top = b.head.z + b.head_r
    eyes(b, P, 2, 0.6, size=0.16)
    return b


def base_insect(P, rng, legs):
    b = Body()
    z = 0.28
    b.head_r = 0.11
    b.head = Vector((0, -0.4, z + 0.05))
    b.add(ell(b.head, (0.1, 0.1, 0.09), P.body))
    b.add(ell((0, -0.2, z), (0.13, 0.14, 0.11), P.body))                # thorax
    b.add(ell((0, 0.18, z + 0.04), (0.2, 0.3, 0.16), P.dark if legs == 8 else P.body))  # abdomen
    pairs = legs // 2
    for i in range(pairs):
        y = -0.3 + i * (0.3 / max(1, pairs - 1)) if pairs > 1 else -0.2
        for s in (-1, 1):
            knee = Vector((s * 0.32, y - 0.02, z + 0.18))
            foot = Vector((s * 0.48, y + (i - pairs / 2) * 0.05, 0.02))
            b.add(limb((s * 0.08, y, z), knee, 0.02, P.dark))
            b.add(cyl(knee, foot, 0.018, P.dark, r2=0.006))
            b.feet.append(foot)
    b.face = b.head + Vector((0, -0.1, 0))
    b.back, b.back_len = Vector((0, 0.1, z + 0.2)), 0.45
    b.chest, b.waist, b.tail_root = Vector((0, -0.3, z)), Vector((0, 0, z)), Vector((0, 0.48, z + 0.05))
    b.neck = Vector((0, -0.3, z + 0.08))
    b.hands = [b.feet[0], b.feet[1]]
    b.top = z + 0.22
    eyes(b, P, 2 if legs == 6 else 4, 0.7, glow=legs == 8, size=0.22)
    return b


def base_swarm(P, rng):
    b = Body()
    for i in range(14):
        p = Vector((rng.uniform(-0.45, 0.45), rng.uniform(-0.35, 0.35), rng.uniform(0.25, 0.95)))
        b.add(ell(p, (0.05, 0.07, 0.04), P.body, 8, 6))
        b.add(ell(p + Vector((0.04, 0, 0.02)), (0.04, 0.012, 0.02), P.accent, 6, 4))
        b.add(ell(p + Vector((-0.04, 0, 0.02)), (0.04, 0.012, 0.02), P.accent, 6, 4))
    b.head, b.head_r, b.face = Vector((0, -0.2, 0.6)), 0.15, Vector((0, -0.35, 0.6))
    b.back, b.chest, b.waist, b.tail_root = Vector((0, 0, 0.95)), Vector((0, -0.2, 0.6)), Vector((0, 0, 0.5)), Vector((0, 0.3, 0.5))
    b.legged, b.top = False, 1.0
    return b


def base_aberrant(P, rng):
    b = Body()
    b.add(ell((0, 0, 0.45), (0.42, 0.38, 0.45), P.body, 24, 14))
    for i in range(6):
        p = Vector((rng.uniform(-0.35, 0.35), rng.uniform(-0.3, 0.2), rng.uniform(0.2, 0.8)))
        b.add(ell(p, (rng.uniform(0.1, 0.2),) * 3, P.dark, 12, 8))
    b.head, b.head_r, b.face = Vector((0.05, -0.1, 0.65)), 0.35, Vector((0.05, -0.42, 0.62))
    for i in range(5):  # eyes everywhere
        p = Vector((rng.uniform(-0.3, 0.3), -0.38 + rng.uniform(0, 0.05), rng.uniform(0.3, 0.8)))
        b.add(ell(p, (0.05, 0.03, 0.05), P.eye_glow, 8, 6))
    b.back, b.chest, b.waist, b.tail_root = Vector((0, 0.1, 0.9)), Vector((0, -0.3, 0.45)), Vector((0, 0, 0.3)), Vector((0, 0.35, 0.3))
    b.legged, b.top = False, 0.9
    return b


def wings(b, P, kind="membrane", span=0.7, at=None, up=0.15):
    at = at or (b.back + Vector((0, 0.02, 0.02)))
    m = P.dark if kind != "feather" else P.body
    for s in (-1, 1):
        root = at + Vector((s * 0.05, 0, 0))
        tip = at + Vector((s * span, 0.1, up + 0.2))
        mid = at + Vector((s * span * 0.55, 0.05, up + 0.32))
        b.add(cyl(root, mid, 0.02, P.dark), cyl(mid, tip, 0.015, P.dark, r2=0.004))
        # the membrane / feather fan as a flattened ellipsoid between root, mid and tip
        c = (root + mid + tip) / 3 + Vector((0, 0, -0.08))
        o = ell(c, (span * 0.48, 0.015, 0.22 if kind != "case" else 0.15), m, 16, 8)
        o.rotation_euler = (0, -s * 0.35, 0)
        b.add(o)


def base_flyer(P, rng):
    b = Body()
    b.add(ell((0, 0, 0.55), (0.11, 0.17, 0.11), P.body))
    b.head, b.head_r = Vector((0, -0.17, 0.6)), 0.08
    b.add(ell(b.head, (0.08,) * 3, P.body))
    b.face = b.head + Vector((0, -0.08, 0))
    b.back, b.back_len, b.chest, b.waist = Vector((0, 0, 0.66)), 0.25, Vector((0, -0.1, 0.5)), Vector((0, 0.05, 0.5))
    b.tail_root, b.neck, b.legged, b.top = Vector((0, 0.17, 0.55)), Vector((0, -0.12, 0.6)), False, 0.9
    wings(b, P, "membrane", 0.55, Vector((0, 0, 0.62)), 0.0)
    eyes(b, P, 2, 0.6, size=0.25)
    return b


def base_serpent(P, rng, length=1.6, rise=True):
    b = Body()
    pts = []
    n = 16
    for i in range(n):
        t = i / (n - 1)
        x = 0.18 * math.sin(t * math.pi * 2.2)
        y = -length * 0.35 + t * length
        z = 0.1 + (0.55 * (1 - t) ** 3 if rise else 0)
        pts.append(Vector((x, y, z)))
    for i, p in enumerate(pts):
        r = 0.1 * (1 - i / n * 0.7)
        b.add(ell(p, (r, r * 1.1, r), P.body, 12, 8))
    b.head_r = 0.13
    b.head = pts[0] + Vector((0, -0.08, 0.04))
    b.add(ell(b.head, (0.1, 0.15, 0.08), P.body))
    b.face = b.head + Vector((0, -0.15, 0))
    b.back, b.back_len = Vector((0, 0.2, 0.22)), length * 0.6
    b.chest, b.waist, b.tail_root, b.neck = pts[2], pts[5], pts[-3], pts[1]
    b.legged, b.top = False, b.head.z + 0.1
    eyes(b, P, 2, 0.8, glow=True, size=0.2)
    return b


def base_naga(P, rng):
    b = base_serpent(P, rng, 1.4, rise=False)
    # a humanoid torso rising from the front coil
    base = b.chest + Vector((0, -0.05, 0.1))
    torso_top = base + Vector((0, 0, 0.45))
    b.add(ell((base + torso_top) / 2, (0.14, 0.1, 0.25), P.body))
    for s in (-1, 1):
        sh = torso_top + Vector((s * 0.15, 0, -0.03))
        hand = sh + Vector((s * 0.12, -0.12, -0.32))
        b.add(limb(sh, hand, 0.035, P.body))
        b.shoulders.append(sh)
        b.hands.append(hand)
    b.head_r = 0.1
    b.head = torso_top + Vector((0, 0, 0.12))
    b.add(ell(b.head, (0.1, 0.1, 0.11), P.body))
    b.face = b.head + Vector((0, -0.1, 0))
    b.neck, b.back = torso_top, torso_top + Vector((0, 0.08, -0.05))
    b.top = b.head.z + 0.11
    eyes(b, P, 2)
    return b


def base_dragon(P, rng, wyvern=False):
    b = base_quad(P, rng, "large") if not wyvern else base_biped(P, rng, "large")
    # long neck and head pushed forward/up, wings, long tail
    wings(b, P, "membrane", 1.0, b.back + Vector((0, -0.05, 0.05)), 0.25)
    tail(b, P, "thin", 0.9)
    horns(b, P, "swept")
    return b


def base_floating(P, rng):
    b = Body()
    z = 0.55
    b.add(ell((0, 0, z), (0.24, 0.24, 0.26), P.body, 24, 14))
    b.add(cone((0, 0, z - 0.15), (0, 0.05, 0.08), 0.22, P.body))  # trailing shroud
    b.head, b.head_r, b.face = Vector((0, 0, z + 0.05)), 0.24, Vector((0, -0.24, z + 0.05))
    b.back, b.chest, b.waist, b.tail_root = Vector((0, 0.1, z + 0.2)), Vector((0, -0.2, z)), Vector((0, 0, z - 0.1)), Vector((0, 0.2, z - 0.1))
    b.neck, b.legged, b.top = Vector((0, 0, z + 0.2)), False, z + 0.3
    eyes(b, P, 2, 0.5, glow=True, size=0.2)
    return b


def base_fish(P, rng):
    b = Body()
    z = 0.4
    b.add(ell((0, 0, z), (0.14, 0.42, 0.22), P.body))
    b.add(cone((0, 0.38, z), (0, 0.62, z), 0.18, P.dark))  # tail fin as a flattened cone
    b.objs[-1].scale.x = 0.2
    b.head, b.head_r, b.face = Vector((0, -0.3, z + 0.04)), 0.18, Vector((0, -0.42, z + 0.03))
    b.back, b.back_len, b.chest, b.waist = Vector((0, 0, z + 0.22)), 0.6, Vector((0, -0.2, z - 0.1)), Vector((0, 0, z))
    b.tail_root, b.neck, b.legged, b.top = Vector((0, 0.4, z)), Vector((0, -0.25, z + 0.1)), False, z + 0.25
    eyes(b, P, 2, 1.2, size=0.18)
    return b


def base_mimic(P, rng):
    b = Body()
    b.add(box((0, 0, 0.22), (0.6, 0.42, 0.42), P.wood))
    lid = box((0, 0.05, 0.5), (0.62, 0.44, 0.14), P.wood, rot=(math.radians(-25), 0, 0))
    b.add(lid, box((0, 0, 0.22), (0.62, 0.44, 0.06), P.metal), box((0, -0.215, 0.32), (0.1, 0.02, 0.12), P.metal))
    for i in range(7):
        x = -0.24 + i * 0.08
        b.add(cone((x, -0.2, 0.43), (x, -0.22, 0.35), 0.025, P.bone, 6))
    b.add(ell((0, -0.25, 0.42), (0.08, 0.2, 0.03), mat("tongue", (0.75, 0.2, 0.3), 0.3)))
    b.head, b.head_r, b.face = Vector((0, -0.1, 0.45)), 0.3, Vector((0, -0.24, 0.45))
    b.back, b.chest, b.waist, b.tail_root = Vector((0, 0.1, 0.6)), Vector((0, -0.2, 0.25)), Vector((0, 0, 0.2)), Vector((0, 0.22, 0.2))
    b.legged, b.top = False, 0.65
    b.add(ell((0.12, -0.21, 0.5), (0.04, 0.02, 0.03), P.eye_glow, 8, 6), ell((-0.12, -0.21, 0.5), (0.04, 0.02, 0.03), P.eye_glow, 8, 6))
    return b


def base_golem(P, rng):
    b = Body()
    b.add(box((0, 0, 0.62), (0.55, 0.36, 0.5), P.body))           # torso block
    for s in (-1, 1):
        b.add(box((s * 0.17, 0, 0.2), (0.18, 0.2, 0.4), P.body))     # legs
        b.feet.append(Vector((s * 0.17, 0, 0.02)))
        sh = Vector((s * 0.38, 0, 0.8))
        b.add(box(sh, (0.22, 0.22, 0.2), P.dark))                    # pauldron
        hand = Vector((s * 0.42, -0.05, 0.3))
        b.add(box((s * 0.42, -0.02, 0.55), (0.17, 0.17, 0.42), P.body), box(hand, (0.22, 0.22, 0.2), P.body))
        b.shoulders.append(sh)
        b.hands.append(hand)
    b.head_r = 0.12
    b.head = Vector((0, -0.04, 0.98))
    b.add(box(b.head, (0.2, 0.2, 0.18), P.body))
    b.face = b.head + Vector((0, -0.1, 0))
    b.back, b.back_len, b.chest = Vector((0, 0.18, 0.85)), 0.45, Vector((0, -0.18, 0.65))
    b.waist, b.tail_root, b.neck, b.top = Vector((0, 0, 0.38)), Vector((0, 0.18, 0.4)), Vector((0, 0, 0.88)), 1.08
    b.add(box(b.face + Vector((0, 0, 0.02)), (0.14, 0.01, 0.03), P.glow))  # visor glow
    return b


def base_plant(P, rng, walker=True):
    b = Body()
    if walker:
        b.add(cyl((0, 0, 0.15), (0, 0, 0.85), 0.16, P.wood, r2=0.11))
        for s in (-1, 1):
            b.add(cyl((s * 0.08, 0, 0.2), (s * 0.22, 0.02, 0.0), 0.06, P.wood, r2=0.03))  # root legs
            b.feet.append(Vector((s * 0.22, 0.02, 0.0)))
            sh = Vector((s * 0.12, 0, 0.7))
            hand = Vector((s * 0.42, -0.08, 0.5))
            b.add(cyl(sh, hand, 0.04, P.wood, r2=0.015))
            b.shoulders.append(sh)
            b.hands.append(hand)
        for i in range(5):
            b.add(ell((rng.uniform(-0.2, 0.2), rng.uniform(-0.1, 0.15), 0.95 + rng.uniform(0, 0.15)), (0.18, 0.16, 0.12), P.leaf, 12, 8))
        b.head, b.head_r = Vector((0, -0.05, 0.7)), 0.15
    else:
        b.add(cyl((0, 0, 0.0), (0, 0, 0.45), 0.05, P.leaf))
        b.head, b.head_r = Vector((0, 0, 0.58)), 0.18
        b.add(ell(b.head, (0.18, 0.18, 0.16), P.body))
        for i in range(5):
            a = i / 5 * math.tau
            o = ell((math.cos(a) * 0.18, math.sin(a) * 0.18, 0.08), (0.16, 0.06, 0.02), P.leaf, 10, 6)
            o.rotation_euler = (0, 0, a)
            b.add(o)
        b.legged = False
    b.face = b.head + Vector((0, -b.head_r, 0))
    b.back, b.back_len, b.chest, b.waist = b.head + Vector((0, 0.1, 0.1)), 0.3, b.head + Vector((0, -0.1, -0.1)), Vector((0, 0, 0.35))
    b.tail_root, b.neck, b.top = Vector((0, 0.15, 0.3)), b.head + Vector((0, 0, 0.1)), b.head.z + 0.3
    eyes(b, P, 2, 0.5, glow=True, size=0.15)
    return b


def base_cephalopod(P, rng):
    b = Body()
    z = 0.55
    b.add(ell((0, 0.05, z + 0.12), (0.22, 0.26, 0.3), P.body))
    for i in range(8):
        a = i / 8 * math.tau
        start = Vector((math.cos(a) * 0.12, math.sin(a) * 0.12 - 0.05, z - 0.12))
        mid = Vector((math.cos(a) * 0.35, math.sin(a) * 0.35, 0.18))
        end = Vector((math.cos(a) * 0.5, math.sin(a) * 0.52, 0.03))
        b.add(cyl(start, mid, 0.045, P.body, r2=0.03), cyl(mid, end, 0.03, P.body, r2=0.008))
    b.head, b.head_r, b.face = Vector((0, -0.1, z)), 0.2, Vector((0, -0.24, z))
    b.back, b.chest, b.waist, b.tail_root = Vector((0, 0.1, z + 0.4)), Vector((0, -0.2, z)), Vector((0, 0, z - 0.1)), Vector((0, 0.2, z))
    b.neck, b.legged, b.top = Vector((0, 0, z + 0.2)), False, z + 0.42
    eyes(b, P, 2, 0.8, size=0.22)
    return b


def base_avian(P, rng):
    b = Body()
    leg = 0.3
    b.add(ell((0, 0.02, leg + 0.2), (0.17, 0.25, 0.2), P.body))
    for s in (-1, 1):
        b.add(limb((s * 0.07, 0.02, leg + 0.05), (s * 0.08, 0, 0.04), 0.022, P.dark))
        b.feet.append(Vector((s * 0.08, 0, 0.02)))
        b.add(ell((s * 0.08, -0.04, 0.02), (0.05, 0.08, 0.015), P.dark, 8, 6))
        o = ell((s * 0.16, 0.06, leg + 0.24), (0.04, 0.22, 0.12), P.dark, 12, 6)  # folded wing
        b.add(o)
    b.head_r = 0.11
    b.head = Vector((0, -0.2, leg + 0.45))
    b.add(cyl((0, -0.12, leg + 0.3), b.head, 0.07, P.body), ell(b.head, (0.1, 0.11, 0.1), P.body))
    b.add(cone(b.head + Vector((0, -0.08, -0.01)), b.head + Vector((0, -0.2, -0.04)), 0.035, P.accent))  # beak
    b.face = b.head + Vector((0, -0.1, 0))
    b.back, b.back_len, b.chest = Vector((0, 0.05, leg + 0.38)), 0.4, Vector((0, -0.18, leg + 0.18))
    b.waist, b.tail_root, b.neck, b.top = Vector((0, 0.05, leg + 0.1)), Vector((0, 0.24, leg + 0.25)), Vector((0, -0.14, leg + 0.35)), b.head.z + 0.11
    b.add(ell(b.tail_root + Vector((0, 0.1, 0.02)), (0.1, 0.14, 0.02), P.dark, 10, 6))
    eyes(b, P, 2, 1.1, size=0.2)
    return b


def base_taur(P, rng):
    b = base_quad(P, rng, "large")
    # remove the animal head/neck (the last 3 objects before eyes are neck, head, snout); add a humanoid torso
    for o in b.objs[-5:]:
        bpy.data.objects.remove(o, do_unlink=True)
    b.objs = b.objs[:-5]
    base = Vector((0, -0.33, 0.6))
    torso_top = base + Vector((0, 0, 0.42))
    b.add(ell((base + torso_top) / 2, (0.15, 0.11, 0.24), P.body))
    for s in (-1, 1):
        sh = torso_top + Vector((s * 0.16, 0, -0.03))
        hand = sh + Vector((s * 0.1, -0.15, -0.32))
        b.add(limb(sh, hand, 0.035, P.body))
        b.shoulders.append(sh)
        b.hands.append(hand)
    b.head_r = 0.1
    b.head = torso_top + Vector((0, 0, 0.12))
    b.add(ell(b.head, (0.1, 0.1, 0.11), P.body))
    b.face, b.neck, b.top = b.head + Vector((0, -0.1, 0)), torso_top, b.head.z + 0.11
    eyes(b, P, 2)
    return b


def base_headless(P, rng):
    b = base_biped(P, rng, "medium")
    # remove the head and its eyes (last 3 objects), leave a smoking neck stump
    for o in b.objs[-3:]:
        bpy.data.objects.remove(o, do_unlink=True)
    b.objs = b.objs[:-3]
    b.add(ell(b.neck + Vector((0, 0, 0.02)), (0.06, 0.06, 0.03), P.glow, 10, 6))
    b.top = b.neck.z + 0.05
    return b


BASES = {
    "blob_base": base_blob, "small_biped_base": lambda P, r: base_biped(P, r, "small"),
    "medium_biped_base": lambda P, r: base_biped(P, r, "medium"), "large_biped_base": lambda P, r: base_biped(P, r, "large"),
    "quad_small_base": lambda P, r: base_quad(P, r, "small"), "quad_large_base": lambda P, r: base_quad(P, r, "large"),
    "hexapod_base": lambda P, r: base_insect(P, r, 6), "octopod_base": lambda P, r: base_insect(P, r, 8),
    "swarm_base": base_swarm, "aberrant_base": base_aberrant, "flyer_small_base": base_flyer,
    "serpent_base": base_serpent, "wyvern_base": lambda P, r: base_dragon(P, r, wyvern=True), "floating_base": base_floating,
    "dragon_base": base_dragon, "fish_base": base_fish, "mimic_base": base_mimic, "golem_base": base_golem,
    "plant_walker_base": lambda P, r: base_plant(P, r, True), "plant_rooted_base": lambda P, r: base_plant(P, r, False),
    "naga_base": base_naga, "cephalopod_base": base_cephalopod, "avian_base": base_avian, "taur_base": base_taur,
    "headless_base": base_headless,
}


# ======================================================================== parts
def horns(b, P, kind="pair"):
    h, r = b.head, b.head_r
    if kind == "single":
        b.add(cone(h + Vector((0, -r * 0.4, r * 0.8)), h + Vector((0, -r * 0.9, r * 2.0)), r * 0.18, P.bone))
        return
    if kind == "crown":
        for i in range(5):
            a = (i / 4 - 0.5) * 1.6
            base = h + Vector((math.sin(a) * r * 0.7, math.cos(a) * r * 0.1, r * 0.85))
            b.add(cone(base, base + Vector((math.sin(a) * r * 0.4, 0, r * 0.7)), r * 0.1, P.bone, 6))
        return
    for s in (-1, 1):
        base = h + Vector((s * r * 0.55, 0, r * 0.75))
        if kind == "swept":
            tip = base + Vector((s * r * 0.4, r * 1.3, r * 0.5))
        elif kind == "small":
            tip = base + Vector((s * r * 0.15, 0, r * 0.45))
        elif kind == "antlers":
            mid = base + Vector((s * r * 0.5, r * 0.1, r * 1.0))
            b.add(cyl(base, mid, r * 0.07, P.bone))
            for k in range(3):
                b.add(cone(mid + Vector((0, -r * 0.1 * k, r * 0.15 * k)), mid + Vector((s * r * (0.3 + 0.2 * k), -r * 0.2, r * (0.5 + 0.2 * k))), r * 0.05, P.bone, 6))
            continue
        else:
            tip = base + Vector((s * r * 0.5, -r * 0.2, r * 1.0))
        b.add(cone(base, tip, r * 0.16, P.bone))


def tail(b, P, kind="plain", length=0.5):
    root = b.tail_root
    d = Vector((0, 1, -0.25)).normalized()
    pts = [root + d * length * t + Vector((0, 0, -0.05 * math.sin(t * math.pi))) for t in (0, 0.5, 1)]
    thick = {"thin": 0.025, "bushy": 0.06, "club": 0.05, "plumes": 0.03}.get(kind, 0.04)
    b.add(cyl(pts[0], pts[1], thick, P.body), cyl(pts[1], pts[2], thick * 0.8, P.body, r2=thick * 0.3))
    tip = pts[2]
    if kind == "club":
        b.add(ell(tip, (0.08, 0.1, 0.08), P.dark))
    elif kind == "bushy":
        b.add(ell((pts[1] + tip) / 2, (0.08, 0.2, 0.08), P.body))
    elif kind in ("blade", "spike", "stinger"):
        b.add(cone(tip, tip + Vector((0, 0.12, 0.06 if kind == "stinger" else 0)), 0.04, P.bone))
    elif kind == "rattle":
        for k in range(3):
            b.add(ell(tip + Vector((0, 0.03 * k, 0)), (0.03, 0.025, 0.03), P.bone, 8, 6))
    elif kind == "plumes":
        for k in (-1, 0, 1):
            b.add(cone(tip, tip + Vector((k * 0.08, 0.2, 0.1)), 0.03, P.accent))


def weapon(b, P, kind="sword"):
    if not b.hands:
        return
    hand = b.hands[-1]
    if kind == "club":
        b.add(cyl(hand + Vector((0, 0, -0.05)), hand + Vector((0, -0.05, 0.35)), 0.02, P.wood, r2=0.05))
    elif kind == "lance":
        b.add(cyl(hand + Vector((0, 0.2, 0)), hand + Vector((0, -0.8, 0.15)), 0.015, P.wood), cone(hand + Vector((0, -0.8, 0.15)), hand + Vector((0, -0.95, 0.18)), 0.03, P.metal))
    else:
        b.add(box(hand + Vector((0, -0.18, 0.02)), (0.015, 0.32, 0.05), P.metal), box(hand + Vector((0, -0.01, 0.02)), (0.08, 0.02, 0.02), P.dark))


def cloak(b, P, tattered=False):
    top = b.neck + Vector((0, 0.06, 0))
    bottom_z = 0.05 if b.legged else max(0.05, b.waist.z - 0.2)
    o = cone(top + Vector((0, 0.04, -(top.z - bottom_z))), top, max(0.2, b.head_r * 1.6), P.cloth if not tattered else P.dark, 14)
    o.scale.y = 0.45
    b.add(o)


def plates(b, P, n=4, m=None, spiky=False):
    m = m or P.dark
    for i in range(n):
        t = i / max(1, n - 1)
        p = b.back + b.back_dir * ((t - 0.5) * b.back_len)
        out = Vector((0, 0.12, 0.03)) if b.back_dir.z != 0 else Vector((0, 0.03, 0.12))
        if spiky:
            b.add(cone(p, p + out, 0.05, m, 6))
        else:
            o = ell(p, (0.09, 0.07, 0.035), m, 10, 6)
            b.add(o)


def mane(b, P):
    for i in range(10):
        a = i / 10 * math.tau
        p = b.neck + Vector((math.cos(a) * b.head_r * 1.1, math.sin(a) * b.head_r * 0.8 + 0.03, b.head_r * 0.3))
        b.add(cone(p, p + Vector((math.cos(a) * 0.06, math.sin(a) * 0.04 + 0.05, -0.08)), 0.045, P.dark, 6))


def ears(b, P, tall=False):
    r = b.head_r
    for s in (-1, 1):
        base = b.head + Vector((s * r * 0.6, 0, r * 0.6))
        tip = base + Vector((s * r * (0.6 if not tall else 0.2), r * 0.1, r * (0.5 if not tall else 1.4)))
        b.add(cone(base, tip, r * 0.25, P.body, 8))


def mask(b, P, kind="mask"):
    r = b.head_r
    m = P.bone if kind in ("mask", "human_mask", "mask_face") else P.dark
    o = ell(b.face + Vector((0, -r * 0.02, r * 0.05)), (r * 0.75, r * 0.15, r * 0.8), m, 14, 8)
    b.add(o)
    if kind == "empty_visor":
        b.add(box(b.face + Vector((0, -r * 0.16, r * 0.15)), (r * 0.9, 0.01, r * 0.12), P.eye))
    else:
        for s in (-1, 1):
            b.add(ell(b.face + Vector((s * r * 0.3, -r * 0.16, r * 0.2)), (r * 0.14, r * 0.04, r * 0.1), P.eye_glow, 8, 6))


def mouth_parts(b, P, kind):
    r = b.head_r
    f = b.face + Vector((0, 0, -r * 0.4))
    if kind in ("tusks", "fangs_long"):
        for s in (-1, 1):
            tip = f + Vector((s * r * 0.4, -r * 0.3, r * (0.5 if kind == "tusks" else -0.5)))
            b.add(cone(f + Vector((s * r * 0.3, 0, 0)), tip, r * 0.12, P.bone, 6))
    elif kind == "mandibles":
        for s in (-1, 1):
            b.add(cone(f + Vector((s * r * 0.3, 0, 0)), f + Vector((s * r * 0.1, -r * 0.8, -r * 0.1)), r * 0.13, P.dark, 6))
    else:  # fangs, teeth rows / ring, hinge jaw, petal jaws
        for i in range(5):
            x = (i - 2) * r * 0.16
            b.add(cone(f + Vector((x, -r * 0.05, r * 0.05)), f + Vector((x, -r * 0.08, -r * 0.2)), r * 0.05, P.bone, 5))


def growths(b, P, m, n=5, spiky=True, rng=None):
    rng = rng or random.Random(1)
    for i in range(n):
        p = b.back + b.back_dir * (rng.uniform(-0.5, 0.5) * b.back_len) + Vector((rng.uniform(-0.12, 0.12), 0, 0))
        out = Vector((0, rng.uniform(0.08, 0.16), rng.uniform(-0.03, 0.03))) if b.back_dir.z != 0 else Vector((rng.uniform(-0.05, 0.05), rng.uniform(-0.03, 0.03), rng.uniform(0.08, 0.16)))
        if spiky:
            b.add(cone(p, p + out, 0.04, m, 6))
        else:
            b.add(ell(p, (0.05, 0.05, 0.04), m, 8, 6))


def core(b, P):
    b.add(ell(b.chest + Vector((0, -0.03, 0)), (0.07, 0.04, 0.07), P.glow, 12, 8))


def extra_limbs(b, P, n=2, m=None):
    m = m or P.body
    for i in range(n):
        s = -1 if i % 2 == 0 else 1
        sh = b.chest + Vector((s * 0.15, 0.05, -0.05 - 0.07 * (i // 2)))
        hand = sh + Vector((s * 0.25, -0.12, -0.15))
        b.add(limb(sh, hand, 0.025, m))


def accessories(b, P, part, rng):
    """Small one-off parts."""
    r = b.head_r
    if part in ("crown", "crown_slot"):
        b.add(tor(b.head + Vector((0, 0, r * 0.85)), r * 0.6, r * 0.08, mat("gold", (0.95, 0.75, 0.25), 0.3, 0.9)))
    elif part == "hood":
        o = ell(b.head + Vector((0, r * 0.15, r * 0.15)), (r * 1.25, r * 1.2, r * 1.25), P.cloth, 14, 8)
        b.add(o)
    elif part in ("loincloth", "chain_belt", "chains"):
        m = P.cloth if part == "loincloth" else P.metal
        b.add(tor(b.waist, max(0.12, r * 1.2), 0.025, m, rot=(0, 0, 0)))
        if part == "loincloth":
            b.add(box(b.waist + Vector((0, -0.1, -0.08)), (0.16, 0.02, 0.16), P.cloth))
    elif part in ("bone_trinkets", "jewelry"):
        for i in range(5):
            a = (i / 4 - 0.5) * 2
            b.add(ell(b.neck + Vector((math.sin(a) * r, -abs(math.cos(a)) * r * 0.9, -r * 0.3)), (0.018,) * 3, P.bone if part == "bone_trinkets" else P.accent, 6, 4))
    elif part == "antennae":
        for s in (-1, 1):
            base = b.head + Vector((s * r * 0.3, -r * 0.3, r * 0.6))
            b.add(cyl(base, base + Vector((s * r * 0.6, -r * 1.2, r * 1.2)), 0.008, P.dark))
    elif part in ("nose_hooked", "beak", "beak_hooked"):
        b.add(cone(b.face + Vector((0, 0, -r * 0.05)), b.face + Vector((0, -r * 0.7, -r * (0.35 if part != "beak" else 0.1))), r * 0.18, P.accent if part != "nose_hooked" else P.body, 8))
    elif part in ("crest", "neck_frill", "fins", "fins_sail", "gills"):
        o = ell(b.head + Vector((0, r * 0.3, r * 0.6)) if part == "crest" else b.back, (0.015, r * 1.5 if part != "fins_sail" else b.back_len * 0.6, r * 0.9), P.accent, 12, 8)
        b.add(o)
    elif part in ("whiskers", "whiskers_long"):
        L = r * (1.2 if part == "whiskers" else 2.2)
        for s in (-1, 1):
            for k in (-1, 1):
                p = b.face + Vector((s * r * 0.2, 0, -r * 0.1))
                b.add(cyl(p, p + Vector((s * L, -r * 0.2, k * r * 0.15)), 0.004, P.dark))
    elif part in ("eye_clusters", "eye_cluster"):
        for i in range(4):
            b.add(ell(b.face + Vector((rng.uniform(-r, r) * 0.6, -0.01, rng.uniform(0.1, 0.6) * r)), (r * 0.08,) * 3, P.eye_glow, 6, 4))
    elif part in ("joint_spikes", "leg_spikes"):
        for p in (b.shoulders + b.hands + b.feet)[:6]:
            b.add(cone(p, p + Vector((0, 0.03, 0.08)), 0.025, P.bone, 5))
    elif part == "web_spinneret":
        b.add(cone(b.tail_root, b.tail_root + Vector((0, 0.08, -0.03)), 0.04, P.dark, 6))
    elif part == "cap":
        o = ell(b.head + Vector((0, 0, r * 0.7)), (r * 1.8, r * 1.8, r * 0.8), P.accent, 20, 10)
        b.add(o)
        for i in range(5):
            a = i / 5 * math.tau
            b.add(ell(b.head + Vector((math.cos(a) * r, math.sin(a) * r, r * 1.2)), (r * 0.15,) * 3, mat("spot", (0.95, 0.95, 0.9), 0.6), 6, 4))
    elif part == "lure":
        tip = b.head + Vector((0, -r * 1.6, r * 1.4))
        b.add(cyl(b.head + Vector((0, -r * 0.3, r * 0.9)), tip, 0.008, P.dark), ell(tip, (0.04,) * 3, P.glow, 8, 6))
    elif part == "gear_joints":
        for p in (b.shoulders + b.feet)[:4]:
            b.add(tor(p, 0.05, 0.015, P.metal, rot=(0, math.pi / 2, 0)))
    elif part in ("mouth_clusters", "tongue"):
        b.add(ell(b.face + Vector((0, -0.01, -r * 0.4)), (r * 0.25, r * 0.15, r * 0.08), mat("maw", (0.55, 0.12, 0.15), 0.3), 10, 6))
    elif part == "ink_sac":
        b.add(ell(b.tail_root + Vector((0, 0.05, 0.05)), (0.08, 0.1, 0.08), P.dark, 10, 6))
    elif part == "flame_neck":
        b.add(cone(b.neck, b.neck + Vector((0, 0.02, 0.18)), 0.06, P.glow, 8))
    elif part == "head_carried" and b.hands:
        b.add(ell(b.hands[0] + Vector((0, -0.05, 0.08)), (0.09, 0.09, 0.1), P.body, 12, 8))
    elif part == "mount":
        b.add(ell(b.back + Vector((0, 0, 0.18)), (0.08, 0.08, 0.2), P.cloth, 10, 6))
    elif part in ("spore_pods", "glowing_spots", "surface_bubbles", "drip_trail", "scale_patterns", "suckers", "glowing_knots"):
        m = P.glow if part in ("glowing_spots", "glowing_knots") else P.accent
        for i in range(7):
            p = b.back + Vector((rng.uniform(-0.15, 0.15), rng.uniform(-0.4, 0.4) * max(0.2, b.back_len), rng.uniform(-0.15, 0.03)))
            b.add(ell(p, (0.025,) * 3, m, 6, 4))
    elif part == "trailing_wisps":
        for i in range(3):
            p = b.waist + Vector((rng.uniform(-0.1, 0.1), 0.1 + i * 0.08, -0.05 * i))
            b.add(ell(p, (0.04, 0.12, 0.03), P.glow, 8, 6))
    elif part == "scar_decals" or part == "face_decal":
        b.add(box(b.face + Vector((r * 0.2, -0.005, r * 0.25)), (0.01, 0.005, r * 0.7), P.accent, rot=(0, 0.4, 0)))
    elif part in ("claws", "talons"):
        for p in (b.hands + b.feet)[:4]:
            for k in (-1, 0, 1):
                b.add(cone(p + Vector((k * 0.02, -0.02, 0)), p + Vector((k * 0.03, -0.08, -0.02)), 0.012, P.bone, 5))
    elif part in ("fur_tufts", "hair_bristles", "hair_mane"):
        for i in range(6):
            p = b.back + Vector((rng.uniform(-0.1, 0.1), rng.uniform(-0.5, 0.5) * b.back_len, 0))
            b.add(cone(p, p + Vector((0, 0.04, 0.07)), 0.025, P.dark, 5))
    elif part == "humanoid_torso" and not b.shoulders:
        top = b.back + Vector((0, -0.1, 0.4))
        b.add(ell((b.back + top) / 2, (0.12, 0.09, 0.2), P.body), ell(top + Vector((0, 0, 0.1)), (0.09,) * 3, P.body))


# Part name → builder (groups the 118 recipe parts into shape families)
def build_parts(b, P, parts, rng):
    done = set()
    for part in parts:
        if part in done:
            continue
        done.add(part)
        if part in ("horns",):
            horns(b, P, "pair")
        elif part in ("horns_swept",):
            horns(b, P, "swept")
        elif part in ("horns_small",):
            horns(b, P, "small")
        elif part in ("horn_crown",):
            horns(b, P, "crown")
        elif part in ("horn_single",):
            horns(b, P, "single")
        elif part == "antlers":
            horns(b, P, "antlers")
        elif part in ("tail", "tail_thin", "tail_bushy", "tail_club", "tail_blade", "tail_spike", "rattle_tail", "tail_plumes", "stinger"):
            kind = {"tail": "plain", "tail_thin": "thin", "tail_bushy": "bushy", "tail_club": "club", "tail_blade": "blade",
                    "tail_spike": "spike", "rattle_tail": "rattle", "tail_plumes": "plumes", "stinger": "stinger"}[part]
            tail(b, P, kind)
        elif part in ("weapon_socket", "club_socket", "lance"):
            weapon(b, P, {"weapon_socket": "sword", "club_socket": "club", "lance": "lance"}[part])
        elif part in ("cloak", "tattered_shroud", "tattered_cape"):
            cloak(b, P, tattered=part != "cloak")
        elif part in ("mask", "mask_face", "human_mask", "empty_visor"):
            mask(b, P, part)
        elif part in ("armor_plates", "plate_armor", "crude_armor", "barding"):
            plates(b, P, 4, P.metal if part != "crude_armor" else P.dark)
            if b.shoulders:
                for sh in b.shoulders:
                    b.add(ell(sh + Vector((0, 0, 0.03)), (0.07, 0.07, 0.05), P.metal, 10, 6))
        elif part in ("armored_back", "scales_armored", "spine_plates", "carapace_ridges", "scale_ridges", "bark_plates"):
            plates(b, P, 5, P.dark, spiky=part in ("spine_plates", "scale_ridges"))
        elif part in ("mane",):
            mane(b, P)
        elif part in ("ears_long", "ears_tall"):
            ears(b, P, tall=part == "ears_tall")
        elif part in ("fangs", "fangs_long", "tusks", "teeth_rows", "teeth_ring", "mandibles", "hinge_jaw", "petal_jaws"):
            mouth_parts(b, P, part)
        elif part in ("stone_growths", "crystal_growths", "moss_cover", "thorns"):
            m = {"stone_growths": P.dark, "crystal_growths": P.glow, "moss_cover": P.leaf, "thorns": P.wood}[part]
            growths(b, P, m, 6, spiky=part != "moss_cover", rng=rng)
        elif part in ("lantern_core", "inner_core", "rune_core", "swarm_core", "glowing_throat"):
            core(b, P)
        elif part in ("wing_cases", "wing_membrane", "wing_feathers", "membrane_wings"):
            wings(b, P, {"wing_cases": "case", "wing_feathers": "feather"}.get(part, "membrane"), 0.55)
        elif part in ("extra_arms", "multiple_arms"):
            extra_limbs(b, P, 2 if part == "extra_arms" else 4)
        elif part in ("branch_arms", "vine_whips", "root_tendrils", "tentacles"):
            extra_limbs(b, P, 2, P.wood if part == "branch_arms" else P.leaf if part != "tentacles" else P.body)
        else:
            accessories(b, P, part, rng)


MENACE = {
    "circle-based, soft silhouette": "soft",
    "real-animal silhouette with one fantasy exaggeration": "animal",
    "triangle-based silhouette, sharp asymmetric spikes": "spiky",
    "elongated, irregular silhouette; still-then-sudden timing": "elongated",
    "broken symmetry, mimicry, audio-first reveal": "broken",
}


def menace_pass(b, P, style, rng):
    if style == "spiky":
        for p in (b.shoulders or [b.back])[:2]:
            b.add(cone(p + Vector((0, 0.02, 0.03)), p + Vector((rng.uniform(-0.05, 0.05), 0.04, 0.14)), 0.03, P.bone, 5))
        plates(b, P, 3, P.dark, spiky=True)


def build_species(s):
    rng = random.Random(s["id"])
    recipe = s.get("designRecipe", {})
    P = Palette(recipe, s.get("element", "None"))
    base = BASES.get(recipe.get("baseMesh"), BASES["medium_biped_base"])
    b = base(P, rng)
    build_parts(b, P, recipe.get("parts", []), rng)
    style = MENACE.get(recipe.get("menaceStyle", ""), "animal")
    menace_pass(b, P, style, rng)
    # join into one object
    objs = [o for o in b.objs if o.name in bpy.data.objects]
    bpy.ops.object.select_all(action="DESELECT")
    for o in objs:
        o.select_set(True)
    bpy.context.view_layer.objects.active = objs[0]
    bpy.ops.object.join()
    model = bpy.context.active_object
    model.name = s["id"]
    bpy.ops.object.transform_apply(location=False, rotation=True, scale=True)
    if style == "elongated":
        model.scale = (0.85, 0.95, 1.2)
    elif style == "broken":
        model.rotation_euler = (0, math.radians(6), math.radians(4))
    elif style == "soft":
        model.scale = (1.08, 1.08, 0.95)
    bpy.ops.object.transform_apply(location=False, rotation=True, scale=True)
    return model


# ======================================================================== rendering (shares the turnaround layout)
def reset():
    bpy.ops.wm.read_factory_settings(use_empty=True)
    _MATS.clear()


def studio(res):
    scene = bpy.context.scene
    engines = [i.identifier for i in bpy.types.RenderSettings.bl_rna.properties["engine"].enum_items]
    for e in ("BLENDER_EEVEE_NEXT", "BLENDER_EEVEE", "BLENDER_WORKBENCH"):
        if e in engines:
            scene.render.engine = e
            break
    scene.render.resolution_x, scene.render.resolution_y = res
    scene.render.image_settings.file_format = "JPEG"
    scene.render.image_settings.quality = 88
    world = bpy.data.worlds.new("Studio")
    scene.world = world
    world.use_nodes = True
    bg = next(n for n in world.node_tree.nodes if n.type == "BACKGROUND")
    bg.inputs["Color"].default_value = (0.86, 0.88, 0.9, 1.0)
    for name, rot, energy in (("Key", (50, 0, 35), 3.5), ("Fill", (60, 0, -60), 1.2), ("Rim", (35, 0, 180), 2.0)):
        bpy.ops.object.light_add(type="SUN")
        light = bpy.context.active_object
        light.rotation_euler = tuple(math.radians(a) for a in rot)
        light.data.energy = energy


def camera(cx, cz, scale):
    for o in [o for o in bpy.data.objects if o.type == "CAMERA"]:
        bpy.data.objects.remove(o)
    bpy.ops.object.camera_add(location=(cx, -50.0, cz), rotation=(math.radians(90), 0, 0))
    cam = bpy.context.active_object
    cam.data.type = "ORTHO"
    cam.data.ortho_scale = scale
    cam.data.clip_end = 200
    bpy.context.scene.camera = cam


def label(body, loc, size, color=(0.15, 0.17, 0.2)):
    bpy.ops.object.text_add(location=loc, rotation=(math.radians(90), 0, 0))
    t = bpy.context.active_object
    t.data.body = body
    t.data.size = size
    t.data.align_x = "CENTER"
    t.data.materials.append(mat("label", color, 1.0, 0, 1.0))
    t.visible_shadow = False  # otherwise the title prints faintly onto the models


def ground(span):
    bpy.ops.mesh.primitive_plane_add(size=1, location=(0, 0.5, -0.002))
    g = bpy.context.active_object
    g.scale = (span * 8, 1, 1)
    g.data.materials.append(mat("ground", (0.62, 0.66, 0.7), 0.9))


def bbox(o):
    pts = [o.matrix_world @ Vector(c) for c in o.bound_box]
    return (Vector((min(p.x for p in pts), min(p.y for p in pts), min(p.z for p in pts))),
            Vector((max(p.x for p in pts), max(p.y for p in pts), max(p.z for p in pts))))


def fmt_size(m):
    return f"{m * 100:.0f} cm" if m < 1 else f"{m:.1f} m" if m < 100 else f"{m:,.0f} m"


def render(path):
    bpy.context.scene.render.filepath = path
    bpy.ops.render.render(write_still=True)


def render_species(s):
    reset()
    studio(RES_VIEW)
    model = build_species(s)
    lo, hi = bbox(model)
    model.location -= Vector(((lo.x + hi.x) / 2, (lo.y + hi.y) / 2, lo.z))  # centred, feet on the ground
    lo, hi = bbox(model)
    h = hi.z - lo.z
    span = max(hi.x - lo.x, hi.y - lo.y, h)
    real = float(s.get("sizeMeters") or 1.0)
    ground(span)
    folder = os.path.join(OUT, s.get("family", "Other").replace("/", "-"))
    os.makedirs(folder, exist_ok=True)

    camera(0, h / 2 + span * 0.08, span * 1.35)
    for view, yaw in VIEWS:
        model.rotation_euler = (0, 0, math.radians(yaw))
        render(os.path.join(folder, f"{s['id']}_{view}.jpg"))

    gap = span * 1.25
    for i, (view, yaw) in enumerate(VIEWS):
        c = model if i == 0 else model.copy()
        if i:
            bpy.context.collection.objects.link(c)
        c.rotation_euler = (0, 0, math.radians(yaw))
        c.location.x = (i - 1) * gap
        label(view.upper(), (c.location.x, -1, -span * 0.16), span * 0.09)
    label(f"{s['name']}   ·   {s.get('family', '')} · Rank {s.get('rank', '?')} · {s.get('element', 'None')}", (0, -1, h + span * 0.2), span * 0.085)
    label(f"Real size {fmt_size(real)}  ·  {s.get('designRecipe', {}).get('baseMesh', '')}  ·  blockout reference", (0, -1, h + span * 0.08), span * 0.055, (0.35, 0.38, 0.42))
    bpy.context.scene.render.resolution_x, bpy.context.scene.render.resolution_y = RES_SHEET
    camera(0, h / 2 + span * 0.06, gap * 3.4)
    render(os.path.join(folder, f"{s['id']}_sheet.jpg"))


MODELS = os.path.join(ROOT, "Game", "Assets", "_Game", "Art", "Models", "Monsters")
REGISTRY = os.path.join(ROOT, "Art", "Generation", "monster_models.json")
HAND_BUILT = {"mon_blue_slime", "mon_goblin", "mon_horned_rabbit"}  # Ring 0 models from ring0_monsters.py win


def export_species(s, registry):
    """Exports the blockout as a Unity FBX at real size (local-only, like generated models) unless a better model exists."""
    if s["id"] in HAND_BUILT or registry.get(s["id"], {}).get("status") == "generated":
        return None
    reset()
    model = build_species(s)
    lo, hi = bbox(model)
    long_ = " m long" in s.get("look", "")
    measured = (hi.y - lo.y) if long_ else (hi.z - lo.z)
    k = float(s.get("sizeMeters") or 1.0) / max(1e-4, measured)
    model.scale = (k, k, k)
    bpy.ops.object.transform_apply(scale=True)
    lo, hi = bbox(model)
    model.location -= Vector(((lo.x + hi.x) / 2, (lo.y + hi.y) / 2, lo.z))
    bpy.ops.object.transform_apply(location=True)
    bpy.context.scene.cursor.location = (0, 0, 0)
    bpy.ops.object.origin_set(type="ORIGIN_CURSOR")
    folder = os.path.join(MODELS, s.get("family", "Other").replace("/", "-"))
    os.makedirs(folder, exist_ok=True)
    fbx = os.path.join(folder, f"{s['id']}.fbx")
    bpy.ops.object.select_all(action="DESELECT")
    model.select_set(True)
    bpy.context.view_layer.objects.active = model
    bpy.ops.export_scene.fbx(filepath=fbx, use_selection=True, object_types={"MESH"}, axis_forward="-Z", axis_up="Y",
                             apply_scale_options="FBX_SCALE_UNITS", bake_space_transform=True, mesh_smooth_type="FACE")
    lo, hi = bbox(model)
    return {"status": "blockout", "provider": "procedural (bestiary_models.py)",
            "tris": sum(len(p.vertices) - 2 for p in model.data.polygons),
            "sizeM": [round(hi.x - lo.x, 3), round(hi.y - lo.y, 3), round(hi.z - lo.z, 3)],
            "fbx": os.path.relpath(fbx, ROOT).replace("\\", "/"), "fbxBytes": os.path.getsize(fbx)}


def args():
    a = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    opts = {"start": 0, "count": None, "ids": None, "export": False}
    for i, k in enumerate(a):
        if k == "--start": opts["start"] = int(a[i + 1])
        if k == "--count": opts["count"] = int(a[i + 1])
        if k == "--ids": opts["ids"] = set(a[i + 1].split(","))
        if k == "--export": opts["export"] = True  # write Unity FBX blockouts instead of rendering images
    return opts


def main():
    with open(SPECIES, encoding="utf-8") as f:
        species = json.load(f)
    o = args()
    if o["ids"]:
        species = [s for s in species if s["id"] in o["ids"]]
    else:
        species = species[o["start"]: o["start"] + o["count"] if o["count"] else None]
    ok = fail = 0
    if o["export"]:
        reg = {"version": 1, "note": "Monster models. FBX files are local-only (gitignored); this file is the record.", "models": {}}
        if os.path.exists(REGISTRY):
            with open(REGISTRY, encoding="utf-8") as f:
                reg = json.load(f)
        for s in species:
            try:
                entry = export_species(s, reg["models"])
                if entry:
                    reg["models"][s["id"]] = entry
                ok += 1
            except Exception as e:
                fail += 1
                print(f"[Ascend] FAILED {s['id']}: {e!r}", flush=True)
        reg["count"] = len(reg["models"])
        os.makedirs(os.path.dirname(REGISTRY), exist_ok=True)
        with open(REGISTRY, "w", encoding="utf-8") as f:
            json.dump(reg, f, indent=1, sort_keys=True)
            f.write("\n")
        print(f"[Ascend] export done: {ok} ok, {fail} failed, registry {reg['count']} models", flush=True)
        return
    for s in species:
        try:
            render_species(s)
            ok += 1
            print(f"[Ascend] {ok + fail}/{len(species)} {s['id']}", flush=True)
        except Exception as e:  # one bad recipe must not stop the batch
            fail += 1
            print(f"[Ascend] FAILED {s['id']}: {e!r}", flush=True)
    print(f"[Ascend] done: {ok} rendered, {fail} failed", flush=True)


main()
