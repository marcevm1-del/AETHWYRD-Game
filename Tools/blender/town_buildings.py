"""
Brindlewick's buildings (Ring 0), built procedurally in a warm storybook style: stone footings, cream plaster with
dark timber framing, stepped shingle or thatch roofs, shuttered windows with a lamp-lit glow, chimneys, signs and
banners. One mesh per building (several materials), ready for Unity.

Run headless (all, or a few):
  blender -b --factory-startup -P Tools/blender/town_buildings.py
  blender -b --factory-startup -P Tools/blender/town_buildings.py -- --only guild_hall,well
Inside a live Blender session (the MCP pass):
  exec(open(r"E:/Ideas/Project-Ascend/Tools/blender/town_buildings.py").read()); build_all(export=False)
Outputs:
  Game/Assets/_Game/Art/Models/Buildings/<id>.fbx   (Unity: -Z forward, Y up, transforms applied)
  Art/Blender/town_buildings.blend                  (source)
  13_Production/screenshots/town_buildings_blender.png (preview render)
Conventions: metres; ground at z = 0; centred on the origin; the front (door) faces -Y in Blender, +Z in Unity.
"""
import math
import os
import sys

import bmesh
import bpy
from mathutils import Matrix, Vector

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "..")) if "__file__" in globals() else r"E:/Ideas/Project-Ascend"
FBX_DIR = os.path.join(ROOT, "Game", "Assets", "_Game", "Art", "Models", "Buildings")
BLEND_PATH = os.path.join(ROOT, "Art", "Blender", "town_buildings.blend")
PREVIEW_PATH = os.path.join(ROOT, "13_Production", "screenshots", "town_buildings_blender.png")

# sRGB colours (converted to linear for Blender); roughness; emission strength.
PALETTE = {
    "plaster": ((0.92, 0.87, 0.76), 0.9, 0), "plaster_warm": ((0.94, 0.82, 0.64), 0.9, 0),
    "timber": ((0.33, 0.22, 0.14), 0.8, 0), "timber_light": ((0.50, 0.35, 0.21), 0.8, 0),
    "stone": ((0.62, 0.60, 0.56), 0.95, 0), "stone_dark": ((0.44, 0.42, 0.40), 0.95, 0),
    "roof_blue": ((0.25, 0.42, 0.52), 0.7, 0), "roof_red": ((0.66, 0.32, 0.22), 0.75, 0),
    "roof_green": ((0.32, 0.46, 0.33), 0.75, 0), "thatch": ((0.76, 0.61, 0.34), 1.0, 0), "slate": ((0.30, 0.32, 0.37), 0.6, 0),
    "door": ((0.42, 0.26, 0.15), 0.7, 0), "glass": ((0.47, 0.55, 0.60), 0.15, 0), "lamp": ((1.0, 0.84, 0.52), 0.3, 1.5),
    "iron": ((0.20, 0.20, 0.22), 0.5, 0),
    "canvas": ((0.90, 0.85, 0.72), 0.95, 0), "cloth_red": ((0.72, 0.22, 0.18), 0.9, 0), "cloth_blue": ((0.22, 0.38, 0.66), 0.9, 0),
    "cloth_green": ((0.30, 0.52, 0.32), 0.9, 0), "dirt": ((0.56, 0.46, 0.33), 1.0, 0), "cobble": ((0.63, 0.61, 0.57), 0.95, 0),
    "hide": ((0.56, 0.43, 0.30), 0.9, 0), "bone": ((0.90, 0.86, 0.74), 0.7, 0), "apple": ((0.80, 0.18, 0.15), 0.5, 0),
    "orange": ((0.95, 0.58, 0.16), 0.5, 0), "sett": ((0.71, 0.65, 0.56), 0.95, 0), "sett_dark": ((0.57, 0.52, 0.45), 0.95, 0), "ember": ((1.0, 0.45, 0.12), 0.6, 4.0), "straw": ((0.85, 0.72, 0.42), 1.0, 0),
    "banner_blue": ((0.17, 0.32, 0.62), 0.8, 0), "banner_red": ((0.62, 0.16, 0.14), 0.8, 0), "gold": ((0.88, 0.68, 0.28), 0.35, 0),
    "coal": ((1.0, 0.38, 0.08), 0.6, 3.0), "rune": ((0.45, 0.85, 1.0), 0.3, 2.5), "rope": ((0.64, 0.53, 0.36), 0.9, 0),
    "water": ((0.22, 0.38, 0.48), 0.1, 0), "moss": ((0.36, 0.46, 0.27), 1.0, 0), "hay": ((0.86, 0.72, 0.40), 1.0, 0),
    "white": ((0.95, 0.94, 0.90), 0.8, 0),
}


def srgb_to_linear(c):
    return tuple(x / 12.92 if x <= 0.04045 else ((x + 0.055) / 1.055) ** 2.4 for x in c)


def material(key):
    name = "Town_" + key
    m = bpy.data.materials.get(name)
    if m:
        return m
    color, rough, emit = PALETTE[key]
    m = bpy.data.materials.new(name)
    m.use_nodes = True
    bsdf = next(n for n in m.node_tree.nodes if n.type == "BSDF_PRINCIPLED")
    lin = srgb_to_linear(color)
    bsdf.inputs["Base Color"].default_value = (*lin, 1.0)
    bsdf.inputs["Roughness"].default_value = rough
    if emit:
        bsdf.inputs["Emission Color"].default_value = (*lin, 1.0)
        bsdf.inputs["Emission Strength"].default_value = emit
    m.diffuse_color = (*lin, 1.0)
    return m


# ======================================================================== mesh builder
class Part:
    """Collects boxes, prisms and cylinders into one bmesh, one material slot per palette key."""

    def __init__(self, name):
        self.name = name
        self.bm = bmesh.new()
        self.keys = []

    def _mi(self, key):
        if key not in self.keys:
            self.keys.append(key)
        return self.keys.index(key)

    def _tag(self, faces, key):
        mi = self._mi(key)
        for f in faces:
            f.material_index = mi

    def box(self, center, size, key, rz=0.0, rx=0.0, ry=0.0):
        """An axis-aligned box (size x, y, z) rotated by rz/rx/ry degrees about its centre."""
        m = Matrix.Translation(Vector(center)) @ Matrix.Rotation(math.radians(rz), 4, "Z") @ Matrix.Rotation(math.radians(ry), 4, "Y") \
            @ Matrix.Rotation(math.radians(rx), 4, "X") @ Matrix.Diagonal((*size, 1.0))
        res = bmesh.ops.create_cube(self.bm, size=1.0, matrix=m)
        self._tag({f for v in res["verts"] for f in v.link_faces}, key)

    def prism(self, points, depth, key, origin=(0, 0, 0), rz=0.0):
        """A shape drawn in the XZ plane (list of (x, z)) extruded `depth` along Y, centred, then rotated about Z."""
        rot = Matrix.Rotation(math.radians(rz), 4, "Z")
        o = Vector(origin)
        front = [self.bm.verts.new(o + rot @ Vector((x, -depth / 2, z))) for x, z in points]
        back = [self.bm.verts.new(o + rot @ Vector((x, depth / 2, z))) for x, z in points]
        faces = [self.bm.faces.new(front[::-1]), self.bm.faces.new(back)]
        n = len(points)
        for i in range(n):
            j = (i + 1) % n
            faces.append(self.bm.faces.new((front[i], front[j], back[j], back[i])))
        self._tag(faces, key)

    def cylinder(self, center, radius, height, key, segs=12, radius_top=None, rx=0.0, rz=0.0):
        m = Matrix.Translation(Vector(center)) @ Matrix.Rotation(math.radians(rz), 4, "Z") @ Matrix.Rotation(math.radians(rx), 4, "X")
        res = bmesh.ops.create_cone(self.bm, cap_ends=True, cap_tris=False, segments=segs, radius1=radius,
                                    radius2=radius if radius_top is None else radius_top, depth=height, matrix=m)
        self._tag({f for v in res["verts"] for f in v.link_faces}, key)

    def tile(self, center, size, key, rz=0.0):
        """A flat upward-facing quad (size x, y) at height center.z: cheap paving."""
        m = Matrix.Translation(Vector(center)) @ Matrix.Rotation(math.radians(rz), 4, "Z")
        hx, hy = size[0] / 2, size[1] / 2
        vs = [self.bm.verts.new(m @ Vector((x, y, 0))) for x, y in ((-hx, -hy), (hx, -hy), (hx, hy), (-hx, hy))]
        self._tag([self.bm.faces.new(vs)], key)

    def sphere(self, center, radius, key, segs=10, squash=1.0):
        m = Matrix.Translation(Vector(center)) @ Matrix.Diagonal((radius, radius, radius * squash, 1.0))
        res = bmesh.ops.create_uvsphere(self.bm, u_segments=segs, v_segments=max(4, segs // 2), radius=1.0, matrix=m)
        self._tag({f for v in res["verts"] for f in v.link_faces}, key)

    def finish(self, collection=None):
        bmesh.ops.remove_doubles(self.bm, verts=self.bm.verts, dist=1e-4)
        me = bpy.data.meshes.new(self.name)
        self.bm.to_mesh(me)
        self.bm.free()
        for key in self.keys:
            me.materials.append(material(key))
        obj = bpy.data.objects.new(self.name, me)
        (collection or bpy.context.scene.collection).objects.link(obj)
        for p in me.polygons:
            p.use_smooth = False
        return obj


# ======================================================================== building pieces
def gable_roof(p, cx, cy, z0, width, depth, rise, key, overhang=0.45, rows=5, ridge_along_x=True):
    """A stepped-shingle gable roof whose ridge runs along X (or Y), eaves at z0, ridge at z0 + rise."""
    half = depth / 2 + overhang
    slope = math.hypot(half, rise)
    ang = math.degrees(math.atan2(rise, half))
    length = width + 2 * overhang
    for side in (-1, 1):
        for r in range(rows):
            # Each course a board strip from eave (r = 0) to ridge, lapping over the one below (stepped shingles).
            mid = (r + 0.5) / rows
            d = half * (1 - mid)
            zc = z0 + rise * mid + 0.06 + r * 0.014
            yc = side * d
            w_row = slope / rows * 1.18
            if ridge_along_x:
                p.box((cx, cy + yc, zc), (length, w_row, 0.07), key, rx=side * -ang)
            else:
                p.box((cx + yc, cy, zc), (w_row, length, 0.07), key, ry=side * ang)
    # Ridge cap.
    if ridge_along_x:
        p.box((cx, cy, z0 + rise + 0.08), (length + 0.1, 0.32, 0.16), "timber")
    else:
        p.box((cx, cy, z0 + rise + 0.08), (0.32, length + 0.1, 0.16), "timber")


def gable_ends(p, cx, cy, z0, width, depth, rise, key, ridge_along_x=True):
    """The triangular wall under each end of a gable roof."""
    if ridge_along_x:
        for side in (-1, 1):
            p.prism([(-depth / 2, 0), (depth / 2, 0), (0, rise)], 0.2, key, origin=(cx + side * (width / 2 - 0.1), cy, z0), rz=90)
    else:
        for side in (-1, 1):
            p.prism([(-width / 2, 0), (width / 2, 0), (0, rise)], 0.2, key, origin=(cx, cy + side * (depth / 2 - 0.1), z0))


def timber_frame(p, cx, cy, z0, z1, width, depth, studs=1.3, braces=True):
    """Dark beams over a plaster storey: corner posts, sill and head beams, studs and corner braces on every face."""
    t = 0.16
    for sx in (-1, 1):
        for sy in (-1, 1):
            p.box((cx + sx * width / 2, cy + sy * depth / 2, (z0 + z1) / 2), (t + 0.04, t + 0.04, z1 - z0), "timber")
    for face, (ox, oy, length, along_x) in {
        "front": (0, -depth / 2, width, True), "back": (0, depth / 2, width, True),
        "left": (-width / 2, 0, depth, False), "right": (width / 2, 0, depth, False),
    }.items():
        out = 0.03
        px, py = cx + ox + (0 if along_x else (out if ox > 0 else -out)), cy + oy + ((out if oy > 0 else -out) if along_x else 0)
        size_h = (length, t, t) if along_x else (t, length, t)
        p.box((px, py, z0 + t / 2), size_h, "timber")
        p.box((px, py, z1 - t / 2), size_h, "timber")
        n = max(1, int(length / studs))
        for i in range(1, n):
            a = -length / 2 + i * length / n
            p.box((px + (a if along_x else 0), py + (0 if along_x else a), (z0 + z1) / 2), (t * 0.8, t * 0.8, z1 - z0) if along_x else (t * 0.8, t * 0.8, z1 - z0), "timber")
        if braces:
            h = z1 - z0
            for s in (-1, 1):
                a = s * (length / 2 - min(0.7, length / n / 2))
                ang = 38 * s
                if along_x:
                    p.box((px + a, py, (z0 + z1) / 2), (t * 0.7, t * 0.7, h * 0.95), "timber", ry=ang)
                else:
                    p.box((px, py + a, (z0 + z1) / 2), (t * 0.7, t * 0.7, h * 0.95), "timber", rx=-ang)


def window(p, x, y, z, face, w=0.9, h=1.1, shutters=True, glow=True):
    """A window on a wall face ('front' -Y, 'back' +Y, 'left' -X, 'right' +X) centred at (x, y, z)."""
    nx, ny = {"front": (0, -1), "back": (0, 1), "left": (-1, 0), "right": (1, 0)}[face]
    along_x = nx == 0
    depth_axis = (lambda d: (x + nx * d, y + ny * d))
    # Frame, glass, mullion, sill.
    fx, fy = depth_axis(0.06)
    p.box((fx, fy, z), (w + 0.18, 0.1, h + 0.18) if along_x else (0.1, w + 0.18, h + 0.18), "timber")
    gx, gy = depth_axis(0.09)
    p.box((gx, gy, z), (w, 0.06, h) if along_x else (0.06, w, h), "glass" if glow else "iron")
    mx, my = depth_axis(0.13)
    p.box((mx, my, z), (0.06, 0.04, h) if along_x else (0.04, 0.06, h), "timber")
    p.box((mx, my, z), (w, 0.04, 0.06) if along_x else (0.04, w, 0.06), "timber")
    sx_, sy_ = depth_axis(0.16)
    p.box((sx_, sy_, z - h / 2 - 0.08), (w + 0.3, 0.22, 0.08) if along_x else (0.22, w + 0.3, 0.08), "timber_light")
    if shutters:
        for s in (-1, 1):
            off = s * (w / 2 + 0.28)
            cx_, cy_ = depth_axis(0.12)
            if along_x:
                p.box((cx_ + off, cy_ - ny * 0.08, z), (0.5, 0.05, h), "roof_blue" if face in ("front", "back") else "roof_green", rz=s * 25 * -ny)
            else:
                p.box((cx_ - nx * 0.08, cy_ + off, z), (0.05, 0.5, h), "roof_green", rz=s * 25 * nx)


def door(p, x, y, face="front", w=1.3, h=2.2, step=True, awning=None):
    nx, ny = {"front": (0, -1), "back": (0, 1), "left": (-1, 0), "right": (1, 0)}[face]
    along_x = nx == 0
    def at(d): return (x + nx * d, y + ny * d)
    fx, fy = at(0.06)
    p.box((fx, fy, h / 2 + 0.05), (w + 0.3, 0.12, h + 0.2) if along_x else (0.12, w + 0.3, h + 0.2), "timber")
    dx, dy = at(0.1)
    p.box((dx, dy, h / 2), (w, 0.08, h) if along_x else (0.08, w, h), "door")
    # Planks and an iron ring.
    for i in (-1, 1):
        px, py = at(0.15)
        p.box((px + (i * w / 4 if along_x else 0), py + (0 if along_x else i * w / 4), h / 2), (0.05, 0.03, h * 0.95) if along_x else (0.03, 0.05, h * 0.95), "timber")
    rx_, ry_ = at(0.17)
    p.cylinder((rx_ + (w * 0.3 if along_x else 0), ry_ + (0 if along_x else w * 0.3), h * 0.5), 0.07, 0.03, "iron", segs=8, rx=90, rz=0 if along_x else 90)
    if step:
        sx_, sy_ = at(0.45)
        p.box((sx_, sy_, 0.1), (w + 0.8, 0.8, 0.2) if along_x else (0.8, w + 0.8, 0.2), "stone")
    if awning:
        ax, ay = at(0.55)
        p.box((ax, ay, h + 0.45), (w + 1.0, 1.1, 0.08) if along_x else (1.1, w + 1.0, 0.08), awning, rx=(-14 * ny) if along_x else 0, ry=(14 * nx) if not along_x else 0)
        for s in (-1, 1):
            bx, by = at(0.95)
            p.box((bx + (s * (w / 2 + 0.4) if along_x else 0), by + (0 if along_x else s * (w / 2 + 0.4)), h * 0.62), (0.1, 0.1, h * 1.24), "timber")


def chimney(p, x, y, z_base, height, key="stone"):
    p.box((x, y, z_base + height / 2), (0.75, 0.75, height), key)
    p.box((x, y, z_base + height + 0.06), (0.95, 0.95, 0.14), "stone_dark")


def hanging_sign(p, x, y, z, face="front", board="timber_light", emblem="gold"):
    nx, ny = {"front": (0, -1), "back": (0, 1), "left": (-1, 0), "right": (1, 0)}[face]
    arm = 1.1
    # An iron arm out from the wall, the board hanging under it edge-on to the wall (read from the street), an emblem on each side.
    if nx == 0:
        p.box((x, y + ny * arm / 2, z), (0.08, arm, 0.08), "iron")
        p.box((x, y + ny * (arm - 0.45), z - 0.45), (0.08, 0.75, 0.6), board)
        p.cylinder((x, y + ny * (arm - 0.45), z - 0.45), 0.17, 0.14, emblem, segs=12, rx=90, rz=90)
    else:
        p.box((x + nx * arm / 2, y, z), (arm, 0.08, 0.08), "iron")
        p.box((x + nx * (arm - 0.45), y, z - 0.45), (0.75, 0.08, 0.6), board)
        p.cylinder((x + nx * (arm - 0.45), y, z - 0.45), 0.17, 0.14, emblem, segs=12, rx=90)


def lantern(p, x, y, z):
    p.box((x, y, z), (0.22, 0.22, 0.3), "lamp")
    p.box((x, y, z + 0.18), (0.3, 0.3, 0.06), "iron")
    p.box((x, y, z - 0.17), (0.26, 0.26, 0.05), "iron")


def foundation(p, width, depth, height=0.45, key="stone"):
    p.box((0, 0, height / 2), (width + 0.25, depth + 0.25, height), key)


# ======================================================================== buildings
def guild_hall():
    """The Adventurers' Guild: stone ground floor, timber-framed upper floor, blue roof, banners and the guild sign."""
    p = Part("guild_hall")
    W, D, F1, F2 = 10.0, 7.0, 3.4, 3.0
    foundation(p, W, D)
    p.box((0, 0, 0.45 + F1 / 2), (W, D, F1), "stone")
    z1 = 0.45 + F1
    p.box((0, 0, z1 + 0.12), (W + 0.5, D + 0.5, 0.24), "timber")  # jetty
    p.box((0, 0, z1 + 0.24 + F2 / 2), (W + 0.3, D + 0.3, F2), "plaster")
    timber_frame(p, 0, 0, z1 + 0.24, z1 + 0.24 + F2, W + 0.3, D + 0.3)
    z2 = z1 + 0.24 + F2
    gable_ends(p, 0, 0, z2, W + 0.3, D + 0.3, 2.8, "plaster")
    gable_roof(p, 0, 0, z2, W + 0.3, D + 0.3, 2.8, "roof_blue", rows=6)
    chimney(p, 3.2, 1.5, z2, 3.6)
    door(p, 0, -D / 2, w=2.0, h=2.6, awning="roof_blue")
    for x in (-3.4, -1.9, 1.9, 3.4):
        window(p, x, -D / 2, 0.45 + 1.9, "front", w=0.9, h=1.3)
    for x in (-3.5, -1.2, 1.2, 3.5):
        window(p, x, -(D + 0.3) / 2, z1 + 0.24 + 1.5, "front", w=0.9, h=1.1)
    for y in (-1.5, 1.5):
        window(p, -W / 2, y, 0.45 + 1.9, "left", shutters=False)
        window(p, W / 2, y, 0.45 + 1.9, "right", shutters=False)
    # Guild banners either side of the door, and the crossed-swords sign above it.
    for x in (-1.6, 1.6):
        p.box((x, -D / 2 - 0.12, z1 - 0.9), (0.9, 0.04, 1.8), "banner_blue")
        p.box((x, -D / 2 - 0.15, z1 - 0.1), (1.1, 0.08, 0.08), "timber")
        p.prism([(-0.45, 0), (0.45, 0), (0, -0.35)], 0.04, "banner_blue", origin=(x, -D / 2 - 0.12, z1 - 1.8))
    p.box((0, -D / 2 - 0.2, z1 + 0.9), (2.4, 0.12, 0.7), "timber_light")
    for s in (-1, 1):
        p.box((0, -D / 2 - 0.3, z1 + 0.9), (1.6, 0.05, 0.12), "gold", ry=s * 30)
    p.cylinder((0, -D / 2 - 0.32, z1 + 0.9), 0.2, 0.05, "gold", segs=12, rx=90)
    for x in (-W / 2 - 0.1, W / 2 + 0.1):
        lantern(p, x, -D / 2 - 0.25, 2.4)
    return p


def inn():
    """The Sleeping Griffon: two warm plaster floors, red roof, side wing, chimneys, porch and a hanging sign."""
    p = Part("inn_sleeping_griffon")
    W, D = 9.0, 7.0
    foundation(p, W, D)
    p.box((0, 0, 0.45 + 1.6), (W, D, 3.2), "plaster_warm")
    timber_frame(p, 0, 0, 0.45, 3.65, W, D, braces=False)
    p.box((0, 0, 3.65 + 0.1), (W + 0.4, D + 0.4, 0.2), "timber")
    p.box((0, 0, 3.85 + 1.4), (W + 0.2, D + 0.2, 2.8), "plaster_warm")
    timber_frame(p, 0, 0, 3.85, 6.65, W + 0.2, D + 0.2)
    gable_ends(p, 0, 0, 6.65, W + 0.2, D + 0.2, 3.0, "plaster_warm")
    gable_roof(p, 0, 0, 6.65, W + 0.2, D + 0.2, 3.0, "roof_red", rows=6)
    # Side wing (kitchen) with its own lower roof, ridge along Y.
    p.box((W / 2 + 2.0, 1.0, 0.45 + 1.4), (4.0, 5.0, 2.8), "stone")
    gable_ends(p, W / 2 + 2.0, 1.0, 3.25, 4.0, 5.0, 1.6, "plaster_warm", ridge_along_x=False)
    gable_roof(p, W / 2 + 2.0, 1.0, 3.25, 4.0, 5.0, 1.6, "roof_red", rows=4, ridge_along_x=False)
    chimney(p, W / 2 + 2.6, 2.4, 3.25, 2.8)
    chimney(p, -W / 2 + 1.0, 2.0, 6.65, 3.2)
    door(p, -1.0, -D / 2, w=1.6, h=2.4)
    # Porch with posts and a little roof.
    p.box((-1.0, -D / 2 - 1.2, 0.12), (5.0, 2.4, 0.24), "timber_light")
    for x in (-3.2, 1.2):
        p.box((x, -D / 2 - 2.2, 1.6), (0.18, 0.18, 2.9), "timber")
    p.box((-1.0, -D / 2 - 1.25, 3.15), (5.4, 2.7, 0.1), "roof_red", rx=12)
    for x in (2.2, 3.5):
        window(p, x, -D / 2, 2.0, "front")
    for x in (-3.3, -1.0, 1.3, 3.3):
        window(p, x, -(D + 0.2) / 2, 5.2, "front")
    for y in (-1.6, 1.6):
        window(p, -W / 2, y, 2.0, "left")
    hanging_sign(p, 2.6, -D / 2, 3.3, emblem="gold")
    lantern(p, -3.2, -D / 2 - 2.3, 2.6)
    # Barrels by the wall.
    for i, (x, y) in enumerate([(4.0, -4.0), (4.6, -3.4)]):
        p.cylinder((x, y, 0.45), 0.35, 0.9, "timber_light", segs=10)
        p.cylinder((x, y, 0.45), 0.37, 0.08, "iron", segs=10)
    return p


def smithy():
    """Torvald's smithy: a stone back wall, an open timber shed with a slanted roof, the forge, its chimney and an anvil."""
    p = Part("smithy")
    W, D = 5.4, 4.2
    p.box((0, 0, 0.1), (W, D, 0.2), "stone_dark")
    p.box((0, D / 2 - 0.3, 1.6), (W, 0.6, 3.2), "stone")
    for x in (-W / 2 + 0.2, W / 2 - 0.2):
        p.box((x, -D / 2 + 0.2, 1.4), (0.24, 0.24, 2.8), "timber")
    p.box((0, -D / 2 + 0.2, 2.85), (W, 0.25, 0.25), "timber")
    p.box((0, 0.1, 3.2), (W + 0.6, D + 0.8, 0.12), "slate", rx=-9)
    # Forge, coals and the bellows.
    p.box((1.3, 1.0, 0.55), (1.6, 1.4, 0.9), "stone")
    p.box((1.3, 1.0, 1.02), (1.2, 1.0, 0.06), "coal")
    chimney(p, 1.3, 1.55, 0.2, 4.6)
    p.box((0.1, 1.2, 0.7), (0.6, 0.9, 0.4), "door", rz=10)
    # Anvil on a stump, a quench barrel, a rack of tools.
    p.cylinder((-1.0, -0.4, 0.35), 0.38, 0.7, "timber_light", segs=10)
    p.box((-1.0, -0.4, 0.82), (0.7, 0.3, 0.25), "iron")
    p.box((-1.35, -0.4, 0.86), (0.3, 0.18, 0.12), "iron")
    p.cylinder((-2.0, 0.9, 0.4), 0.38, 0.8, "timber_light", segs=10)
    p.cylinder((-2.0, 0.9, 0.78), 0.33, 0.04, "water", segs=10)
    p.box((-1.6, D / 2 - 0.62, 1.8), (1.6, 0.08, 0.1), "timber")
    for i in range(4):
        p.box((-2.2 + i * 0.4, D / 2 - 0.66, 1.45), (0.05, 0.05, 0.7), "iron")
    hanging_sign(p, W / 2 - 0.2, -D / 2 + 0.2, 2.6, face="right", emblem="iron")
    return p


def house(kind):
    """Townhouses: 'cottage' (thatch, one floor), 'house' (two floors, timber frame), 'tall' (three narrow floors)."""
    p = Part("house_" + kind)
    if kind == "cottage":
        W, D = 5.5, 4.5
        foundation(p, W, D, 0.35)
        p.box((0, 0, 0.35 + 1.35), (W, D, 2.7), "plaster")
        timber_frame(p, 0, 0, 0.35, 3.05, W, D, braces=False)
        gable_ends(p, 0, 0, 3.05, W, D, 2.2, "plaster")
        gable_roof(p, 0, 0, 3.05, W, D, 2.2, "thatch", rows=4, overhang=0.6)
        chimney(p, -1.6, 1.0, 3.05, 2.4)
        door(p, 0.6, -D / 2, w=1.2, h=2.1)
        window(p, -1.3, -D / 2, 1.8, "front")
        window(p, W / 2, 0, 1.8, "right")
        p.box((2.3, -D / 2 - 0.25, 0.35), (1.0, 0.4, 0.3), "timber_light")  # flower box
        p.sphere((2.3, -D / 2 - 0.25, 0.6), 0.32, "moss", segs=8, squash=0.6)
    elif kind == "house":
        W, D = 6.5, 5.5
        foundation(p, W, D)
        p.box((0, 0, 0.45 + 1.4), (W, D, 2.8), "stone")
        p.box((0, 0, 3.25 + 0.1), (W + 0.4, D + 0.4, 0.2), "timber")
        p.box((0, 0, 3.45 + 1.3), (W + 0.3, D + 0.3, 2.6), "plaster")
        timber_frame(p, 0, 0, 3.45, 6.05, W + 0.3, D + 0.3)
        gable_ends(p, 0, 0, 6.05, W + 0.3, D + 0.3, 2.6, "plaster")
        gable_roof(p, 0, 0, 6.05, W + 0.3, D + 0.3, 2.6, "roof_blue", rows=5)
        chimney(p, 2.0, 1.2, 6.05, 2.6)
        door(p, -1.4, -D / 2, w=1.3, h=2.3)
        window(p, 1.2, -D / 2, 2.0, "front")
        for x in (-1.6, 1.6):
            window(p, x, -(D + 0.3) / 2, 4.75, "front")
        window(p, W / 2, 0, 2.0, "right")
    else:  # tall
        W, D = 4.8, 4.8
        foundation(p, W, D)
        p.box((0, 0, 0.45 + 1.4), (W, D, 2.8), "stone")
        z = 3.25
        for floor in range(2):
            p.box((0, 0, z + 0.1), (W + 0.3 + floor * 0.2, D + 0.3 + floor * 0.2, 0.2), "timber")
            p.box((0, 0, z + 0.2 + 1.25), (W + 0.2 + floor * 0.2, D + 0.2 + floor * 0.2, 2.5), "plaster_warm")
            timber_frame(p, 0, 0, z + 0.2, z + 2.7, W + 0.2 + floor * 0.2, D + 0.2 + floor * 0.2)
            window(p, 0, -(D + 0.2 + floor * 0.2) / 2, z + 1.5, "front")
            z += 2.7
        gable_ends(p, 0, 0, z, W + 0.4, D + 0.4, 3.2, "plaster_warm", ridge_along_x=False)
        gable_roof(p, 0, 0, z, W + 0.4, D + 0.4, 3.2, "roof_red", rows=5, ridge_along_x=False)
        chimney(p, 1.4, 1.4, z, 3.0)
        door(p, 0, -D / 2, w=1.2, h=2.3)
    return p


def temple():
    """The temple on Temple Hill: a long stone chapel, slate roof, a round window, and a bell tower over the door."""
    p = Part("temple")
    W, D = 6.0, 10.0
    foundation(p, W, D, 0.5)
    p.box((0, 0.6, 0.5 + 2.6), (W, D - 1.2, 5.2), "stone")
    gable_ends(p, 0, 0.6, 5.7, W, D - 1.2, 3.4, "stone", ridge_along_x=False)
    gable_roof(p, 0, 0.6, 5.7, W, D - 1.2, 3.4, "slate", rows=6, ridge_along_x=False)
    # Bell tower at the front.
    p.box((0, -D / 2 + 1.4, 0.5 + 4.6), (3.0, 2.8, 9.2), "stone")
    p.box((0, -D / 2 + 1.4, 9.7 + 0.9), (2.6, 2.4, 1.8), "stone_dark")
    for dx in (-1, 1):
        p.box((dx * 1.0, -D / 2 + 1.4, 10.6), (0.4, 2.5, 1.9), "stone")
    p.cylinder((0, -D / 2 + 1.4, 10.4), 0.45, 0.8, "gold", segs=10, radius_top=0.25)
    p.cylinder((0, -D / 2 + 1.4, 12.4), 2.0, 2.6, "slate", segs=4, radius_top=0.05, rz=45)
    door(p, 0, -D / 2, w=1.6, h=2.8)
    p.cylinder((0, -D / 2 - 0.05, 5.2), 0.75, 0.15, "glass", segs=16, rx=90)
    p.cylinder((0, -D / 2 - 0.1, 5.2), 0.85, 0.1, "stone_dark", segs=16, rx=90)
    for y in (-0.5, 1.8, 4.1):
        for s, face in ((-1, "left"), (1, "right")):
            window(p, s * W / 2, y, 3.0, face, w=0.8, h=2.0, shutters=False)
    # Buttresses.
    for y in (-1.6, 0.7, 3.0, 4.8):
        for s in (-1, 1):
            p.box((s * (W / 2 + 0.25), y, 1.9), (0.5, 0.6, 3.8), "stone_dark", ry=s * -6)
    return p


def orphanage():
    """The Orphanage of the Small Lantern: a wide two-floor house with a porch, a garden fence and its namesake lantern."""
    p = Part("orphanage")
    W, D = 8.0, 6.0
    foundation(p, W, D)
    p.box((0, 0, 0.45 + 1.4), (W, D, 2.8), "plaster")
    timber_frame(p, 0, 0, 0.45, 3.25, W, D, braces=False)
    p.box((0, 0, 3.25 + 0.1), (W + 0.4, D + 0.4, 0.2), "timber")
    p.box((0, 0, 3.45 + 1.3), (W + 0.3, D + 0.3, 2.6), "plaster")
    timber_frame(p, 0, 0, 3.45, 6.05, W + 0.3, D + 0.3)
    gable_ends(p, 0, 0, 6.05, W + 0.3, D + 0.3, 2.8, "plaster")
    gable_roof(p, 0, 0, 6.05, W + 0.3, D + 0.3, 2.8, "roof_green", rows=5)
    chimney(p, -2.6, 1.4, 6.05, 2.6)
    door(p, 0, -D / 2, w=1.5, h=2.3, awning="roof_green")
    for x in (-2.6, 2.6):
        window(p, x, -D / 2, 2.0, "front")
    for x in (-2.8, -0.9, 0.9, 2.8):
        window(p, x, -(D + 0.3) / 2, 4.75, "front")
    # The small lantern: a post by the steps with a big warm lamp.
    p.box((1.4, -D / 2 - 1.1, 1.3), (0.14, 0.14, 2.6), "timber")
    p.box((1.4, -D / 2 - 1.35, 2.5), (0.1, 0.5, 0.1), "iron")
    lantern(p, 1.4, -D / 2 - 1.6, 2.2)
    # A low garden fence.
    for i in range(9):
        x = -W / 2 + i * W / 8
        if abs(x) < 1.2:
            continue
        p.box((x, -D / 2 - 2.2, 0.45), (0.12, 0.12, 0.9), "white")
    for s in (-1, 1):
        p.box((s * (W / 4 + 0.6), -D / 2 - 2.2, 0.65), (W / 2 - 1.2, 0.06, 0.12), "white")
    return p


def town_gate():
    """Brindlewick's north gate: two timber towers on stone feet, a roofed walkway over a 5.6 m opening."""
    p = Part("town_gate")
    for s in (-1, 1):
        x = s * 4.2
        p.box((x, 0, 0.6), (2.6, 2.6, 1.2), "stone")
        p.box((x, 0, 1.2 + 2.6), (2.4, 2.4, 5.2), "timber_light")
        for dx in (-1, 1):
            for dy in (-1, 1):
                p.box((x + dx * 1.15, dy * 1.15, 3.8), (0.2, 0.2, 5.2), "timber")
        p.box((x, 0, 6.5), (2.9, 2.9, 0.25), "timber")
        p.cylinder((x, 0, 7.6), 2.3, 2.0, "roof_blue", segs=4, radius_top=0.05, rz=45)
        window(p, x, -1.2, 4.6, "front", w=0.6, h=0.8, shutters=False)
    # Walkway beam and its little roof.
    p.box((0, 0, 5.4), (8.6, 1.6, 0.5), "timber")
    p.box((0, 0, 4.9), (6.0, 0.3, 0.4), "timber")
    for x in (-2.2, 0, 2.2):
        p.box((x, -0.82, 5.95), (0.12, 0.12, 0.7), "timber")
    p.box((0, -0.82, 6.3), (6.2, 0.12, 0.12), "timber")
    gable_roof(p, 0, 0, 6.4, 6.0, 1.8, 0.9, "roof_blue", rows=3, overhang=0.3)
    p.box((0, -0.86, 4.55), (1.4, 0.08, 0.5), "timber_light")  # name board
    for s in (-1, 1):
        lantern(p, s * 2.85, -1.4, 3.2)
    return p


def palisade(length=8.0):
    """A run of sharpened stakes with two rails, `length` m along X."""
    p = Part("palisade")
    n = int(length / 0.42)
    for i in range(n):
        x = -length / 2 + (i + 0.5) * length / n
        h = 3.2 + ((i * 37) % 7) * 0.08
        p.cylinder((x, 0, h / 2), 0.2, h, "timber_light", segs=6)
        p.cylinder((x, 0, h + 0.25), 0.2, 0.5, "timber_light", segs=6, radius_top=0.02)
    for z in (0.9, 2.4):
        p.box((0, 0.24, z), (length, 0.12, 0.2), "timber")
    return p


def well():
    """Millbrook's old well: a stone ring, two posts, a little roof, the winch and a bucket."""
    p = Part("well")
    for i in range(12):
        a = i / 12 * math.tau
        p.box((math.cos(a) * 1.05, math.sin(a) * 1.05, 0.45), (0.62, 0.38, 0.9), "stone", rz=math.degrees(a) + 90)
    p.cylinder((0, 0, 0.5), 0.9, 0.2, "water", segs=16)
    for s in (-1, 1):
        p.box((s * 1.05, 0, 1.4), (0.16, 0.16, 2.0), "timber")
    p.box((0, 0, 2.0), (2.1, 0.14, 0.14), "timber_light")  # the winch axle
    p.box((0, 0, 1.55), (0.02, 0.02, 0.9), "rope")
    p.cylinder((0, 0, 1.0), 0.18, 0.3, "timber_light", segs=8, radius_top=0.22)
    gable_roof(p, 0, 0, 2.3, 2.3, 1.4, 0.75, "thatch", rows=2, overhang=0.25)
    return p


def watchtower_ruin():
    """The Old Watchtower: a broken stone tower, a fallen section and creeping moss."""
    p = Part("watchtower_ruin")
    p.box((0, 0, 0.4), (4.6, 4.6, 0.8), "stone_dark")
    heights = [(-1, -1, 8.5), (1, -1, 6.8), (1, 1, 7.6), (-1, 1, 5.2)]
    for sx, sy, h in heights:
        p.box((sx * 1.6, sy * 1.6, h / 2), (1.2, 1.2, h), "stone")
    for side, (cx, cy, length, h, along_x) in enumerate([(0, -2.0, 2.0, 6.0, True), (2.0, 0, 2.0, 5.4, False), (0, 2.0, 2.0, 4.2, True), (-2.0, 0, 2.0, 3.6, False)]):
        p.box((cx, cy, h / 2), (length, 0.6, h) if along_x else (0.6, length, h), "stone")
    p.box((0, -2.0, 1.2), (1.1, 0.7, 2.4), "door")  # boarded doorway
    for dz in (0.5, 1.4):
        p.box((0, -2.36, dz + 0.3), (1.3, 0.06, 0.16), "timber", ry=8)
    # Fallen blocks.
    for i, (x, y, r) in enumerate([(3.4, -1.0, 20), (4.1, 0.4, -35), (3.0, 1.6, 60), (-3.3, 2.6, 15)]):
        p.box((x, y, 0.35), (1.0, 0.8, 0.7), "stone", rz=r)
    for x, y, z in [(-1.6, -1.6, 8.5), (1.6, 1.6, 7.6), (2.0, 0, 5.4), (-2.3, 0.8, 0.4)]:
        p.sphere((x, y, z), 0.6, "moss", segs=8, squash=0.45)
    p.box((0, 0, 3.0), (2.8, 2.8, 0.25), "timber_light", rx=6)  # a sagging floor
    return p


def barn():
    """Millbrook's granary barn: red-roofed timber barn with big doors, a hay loft door and hay bales."""
    p = Part("barn")
    W, D = 8.0, 6.5
    foundation(p, W, D, 0.3)
    p.box((0, 0, 0.3 + 2.2), (W, D, 4.4), "timber_light")
    for i in range(int(W / 0.5) + 1):
        x = -W / 2 + i * 0.5
        p.box((x, -D / 2 - 0.03, 2.5), (0.05, 0.05, 4.4), "timber")
    gable_ends(p, 0, 0, 4.7, W, D, 3.0, "timber_light", ridge_along_x=False)
    gable_roof(p, 0, 0, 4.7, W, D, 3.0, "roof_red", rows=6, ridge_along_x=False)
    for s in (-1, 1):
        p.box((s * 1.0, -D / 2 - 0.08, 1.7), (2.0, 0.1, 3.0), "door", rz=0)
        p.box((s * 1.0, -D / 2 - 0.12, 1.7), (2.0, 0.05, 0.12), "timber", ry=s * 55)
    p.box((0, -D / 2 - 0.08, 5.6), (1.2, 0.1, 1.2), "door")
    p.box((0, -D / 2 - 0.9, 6.9), (0.14, 1.8, 0.14), "timber")  # hay hoist
    for i, (x, y) in enumerate([(-4.8, -2.0), (-5.0, -0.8), (-4.9, -1.4)]):
        p.box((x, y, 0.4 + (0.8 if i == 2 else 0)), (1.0, 0.7, 0.8), "hay", rz=i * 12)
    return p


def waystone():
    """A waystone: a rune-cut obelisk on two stone steps, its runes glowing blue."""
    p = Part("waystone")
    p.box((0, 0, 0.15), (2.2, 2.2, 0.3), "stone_dark")
    p.box((0, 0, 0.45), (1.6, 1.6, 0.3), "stone")
    p.cylinder((0, 0, 1.75), 0.55, 2.3, "stone", segs=6, radius_top=0.32)
    p.cylinder((0, 0, 3.05), 0.32, 0.4, "stone", segs=6, radius_top=0.02)
    for i in range(6):
        a = i / 6 * math.tau + math.pi / 6
        r = 0.47
        for k in range(3):
            z = 1.0 + k * 0.6
            rr = r - k * 0.06
            p.box((math.cos(a) * rr, math.sin(a) * rr, z), (0.05, 0.16, 0.32), "rune", rz=math.degrees(a))
    p.sphere((0, 0, 3.4), 0.18, "rune", segs=8)
    return p


# ======================================================================== village life
def market_stall(cloth="cloth_red"):
    """A market stall: four posts, a striped cloth awning, a counter with crates of fruit and a hanging lantern."""
    p = Part("market_stall")
    W, D = 3.0, 2.0
    for sx in (-1, 1):
        for sy in (-1, 1):
            h = 2.6 if sy > 0 else 2.3
            p.box((sx * W / 2, sy * D / 2, h / 2), (0.12, 0.12, h), "timber")
    for i in range(6):  # striped awning, tilted toward the customer
        x = -W / 2 - 0.15 + (i + 0.5) * (W + 0.3) / 6
        p.box((x, 0, 2.5), ((W + 0.3) / 6, D + 0.6, 0.05), cloth if i % 2 == 0 else "canvas", rx=-8)
    p.box((0, -D / 2 + 0.3, 0.9), (W, 0.6, 0.08), "timber_light")  # counter
    p.box((0, -D / 2 + 0.3, 0.45), (W - 0.2, 0.5, 0.86), "timber")
    for i, (x, fruit) in enumerate([(-0.9, "apple"), (0, "orange"), (0.9, "apple")]):
        p.box((x, -D / 2 + 0.3, 1.06), (0.7, 0.45, 0.24), "timber_light")
        for k in range(5):
            p.sphere((x - 0.24 + (k % 3) * 0.24, -D / 2 + 0.22 + (k // 3) * 0.16, 1.22), 0.09, fruit, segs=6)
    for i in range(3):
        p.box((-1.0 + i * 1.0, D / 2 - 0.3, 0.3), (0.55, 0.55, 0.55), "timber_light", rz=i * 9)
    p.box((W / 2 - 0.2, -D / 2 - 0.2, 2.15), (0.04, 0.04, 0.3), "iron")
    lantern(p, W / 2 - 0.2, -D / 2 - 0.2, 1.9)
    return p


def lamp_post():
    """A street lamp: a stone foot, an iron post and a glass lantern under a little iron hood."""
    p = Part("lamp_post")
    p.cylinder((0, 0, 0.2), 0.28, 0.4, "stone", segs=8)
    p.cylinder((0, 0, 1.9), 0.07, 3.1, "iron", segs=8)
    p.box((0.25, 0, 3.35), (0.6, 0.06, 0.06), "iron")
    lantern(p, 0.5, 0, 3.05)
    p.cylinder((0.5, 0, 3.32), 0.22, 0.18, "iron", segs=4, radius_top=0.02, rz=45)
    return p


def windmill():
    """Millbrook's windmill: a tapered eight-sided tower, a conical cap and four lattice sails facing -Y."""
    p = Part("windmill")
    p.cylinder((0, 0, 0.3), 2.8, 0.6, "stone", segs=8)
    p.cylinder((0, 0, 0.6 + 3.6), 2.4, 7.2, "plaster", segs=8, radius_top=1.7)
    for z in (2.5, 5.0):  # timber bands
        p.cylinder((0, 0, z), 2.4 - (z / 7.2) * 0.7 + 0.04, 0.16, "timber", segs=8)
    p.cylinder((0, 0, 7.8 + 1.4), 2.1, 2.8, "roof_red", segs=8, radius_top=0.1)
    door(p, 0, -2.25, w=1.1, h=2.0)
    window(p, 0, -2.0, 4.8, "front", w=0.6, h=0.8, shutters=False)
    # Hub and sails.
    hub = (0, -2.35, 7.6)
    p.cylinder(hub, 0.35, 0.8, "timber", segs=8, rx=90)
    for k in range(4):
        a = k * 90 + 15
        ra = math.radians(a)
        cx, cz = math.cos(ra) * 2.9, math.sin(ra) * 2.9
        p.box((hub[0] + cx, hub[1] - 0.25, hub[2] + cz), (5.6, 0.12, 0.16), "timber", ry=-a)
        # A lattice of slats and a cloth panel along each arm.
        for t in range(5):
            d = 1.2 + t * 0.95
            ox, oz = math.cos(ra) * d, math.sin(ra) * d
            nx_, nz_ = -math.sin(ra) * 0.45, math.cos(ra) * 0.45
            p.box((hub[0] + ox + nx_, hub[1] - 0.3, hub[2] + oz + nz_), (0.06, 0.06, 0.95), "timber_light", ry=-a)
        p.box((hub[0] + math.cos(ra) * 3.1 - math.sin(ra) * 0.45, hub[1] - 0.33, hub[2] + math.sin(ra) * 3.1 + math.cos(ra) * 0.45),
              (4.2, 0.03, 0.8), "canvas", ry=-a)
    return p


def training_dummy():
    """A straw training dummy on a post, a crossbar for arms and a sack head."""
    p = Part("training_dummy")
    p.box((0, 0, 0.1), (0.8, 0.8, 0.2), "timber")
    p.cylinder((0, 0, 1.0), 0.07, 1.8, "timber", segs=6)
    p.cylinder((0, 0, 1.25), 0.32, 0.9, "straw", segs=8, radius_top=0.26)
    p.box((0, 0, 1.55), (1.3, 0.1, 0.1), "timber")
    p.sphere((0, 0, 1.95), 0.22, "canvas", segs=8)
    for z in (1.05, 1.45):
        p.cylinder((0, 0, z), 0.34, 0.05, "rope", segs=8)
    return p


def weapon_rack():
    """A weapon rack: wooden swords, spears and a round shield."""
    p = Part("weapon_rack")
    for x in (-0.9, 0.9):
        p.box((x, 0, 0.8), (0.1, 0.4, 1.6), "timber")
    for z in (0.35, 1.35):
        p.box((0, 0, z), (1.9, 0.12, 0.1), "timber")
    for i in range(4):
        x = -0.6 + i * 0.4
        p.box((x, 0.08, 1.0), (0.06, 0.03, 1.3), "timber_light", ry=6 if i % 2 else -6)
        p.box((x, 0.08, 0.65), (0.22, 0.05, 0.05), "timber")
    p.cylinder((0.0, -0.18, 0.95), 0.35, 0.06, "cloth_blue", segs=12, rx=90)
    p.cylinder((0.0, -0.22, 0.95), 0.1, 0.06, "iron", segs=8, rx=90)
    return p


def archery_target():
    """A straw archery butt on a tilted stand, painted rings facing -Y."""
    p = Part("archery_target")
    for sx in (-1, 1):
        p.box((sx * 0.5, 0.25, 0.75), (0.08, 0.08, 1.6), "timber", rx=-12)
    p.box((0, 0.5, 0.6), (0.08, 0.08, 1.3), "timber", rx=30)
    for r, key in ((0.6, "straw"), (0.45, "white"), (0.3, "cloth_red"), (0.14, "gold")):
        p.cylinder((0, 0.02 - (0.6 - r) * 0.06, 1.05), r, 0.18 + (0.6 - r) * 0.12, key, segs=16, rx=78)
    return p


def tent(cloth="canvas"):
    """An adventurer's A-frame tent with the front flaps tied open (opening faces -Y)."""
    p = Part("tent")
    W, D, H = 2.6, 3.2, 2.0
    # Two cloth slabs, each laid from the ground edge up to the ridge pole.
    slope = math.hypot(W / 2, H)
    ang = math.degrees(math.atan2(H, W / 2))
    for side in (-1, 1):
        p.box((side * W / 4, 0, H / 2), (slope, D, 0.05), cloth, ry=side * ang)
    p.prism([(-W / 2, 0), (W / 2, 0), (0, H)], 0.05, cloth, origin=(0, D / 2, 0))  # back wall
    for side in (-1, 1):  # tied-back flaps
        p.prism([(0, 0), (side * 0.9, 0), (0, H * 0.95)], 0.04, cloth, origin=(side * 0.25, -D / 2 - 0.25, 0), rz=side * 35)
    p.box((0, 0, H + 0.05), (0.08, D + 0.4, 0.08), "timber")
    for y in (-D / 2 - 0.2, D / 2 + 0.2):
        p.box((0, y, H / 2 + 0.05), (0.07, 0.07, H + 0.1), "timber")
    p.box((0, 0.2, 0.08), (W - 0.4, D - 0.6, 0.12), "hide")  # bedroll
    return p


def campfire():
    """A campfire: a ring of stones, crossed logs and glowing embers."""
    p = Part("campfire")
    for i in range(9):
        a = i / 9 * math.tau
        p.sphere((math.cos(a) * 0.75, math.sin(a) * 0.75, 0.12), 0.2, "stone", segs=6, squash=0.7)
    for k in range(3):
        p.cylinder((0, 0, 0.18), 0.08, 1.1, "timber", segs=6, rx=90, rz=k * 60)
    p.sphere((0, 0, 0.18), 0.32, "ember", segs=8, squash=0.45)
    # A log to sit on.
    p.cylinder((0, 1.6, 0.22), 0.22, 1.6, "timber_light", segs=8, rx=90, rz=90)
    return p


def wagon():
    """A merchant's covered wagon: plank bed, four spoked wheels, a canvas hood on hoops and a shaft (faces -Y)."""
    p = Part("wagon")
    L, W = 3.6, 1.8
    p.box((0, 0, 0.95), (W, L, 0.14), "timber_light")
    for sx in (-1, 1):
        p.box((sx * W / 2, 0, 1.25), (0.08, L, 0.5), "timber_light")
    for sy in (-1, 1):
        p.box((0, sy * L / 2, 1.25), (W, 0.08, 0.5), "timber_light")
    for sx in (-1, 1):
        for sy in (-1, 1):
            c = (sx * (W / 2 + 0.12), sy * L * 0.33, 0.55)
            p.cylinder(c, 0.55, 0.1, "timber", segs=14, rx=90, rz=90)
            p.cylinder(c, 0.12, 0.18, "iron", segs=8, rx=90, rz=90)
            for k in range(4):
                p.box(c, (0.05, 1.0, 0.05), "timber_light", rx=k * 45)
    for i in range(5):  # hoops and the canvas hood
        y = -L / 2 + 0.3 + i * (L - 0.6) / 4
        for side in (-1, 1):
            p.box((side * W / 2 * 0.98, y, 1.75), (0.06, 0.06, 1.1), "timber")
    p.cylinder((0, 0, 2.15), W / 2 + 0.05, L - 0.3, "canvas", segs=12, rx=90)
    p.box((0, 0, 1.65), (W + 0.1, L - 0.3, 0.9), "canvas")
    p.box((0, -L / 2 - 0.9, 0.75), (0.1, 1.8, 0.1), "timber", rx=-8)  # shaft
    for i in range(3):
        p.box((-0.4 + i * 0.4, L / 2 + 0.35, 0.3), (0.4, 0.4, 0.4), "timber_light")
    return p


def crates():
    """A pile of crates, barrels and grain sacks for yards and doorsteps."""
    p = Part("crates")
    for (x, y, z, r) in [(0, 0, 0.3, 0), (0.7, 0.1, 0.3, 12), (0.3, 0.05, 0.9, 6)]:
        p.box((x, y, z), (0.6, 0.6, 0.6), "timber_light", rz=r)
    for (x, y) in [(-0.8, 0.2), (-0.7, -0.6)]:
        p.cylinder((x, y, 0.45), 0.33, 0.9, "timber_light", segs=10)
        for z in (0.15, 0.75):
            p.cylinder((x, y, z), 0.35, 0.06, "iron", segs=10)
    for (x, y) in [(0.8, -0.7), (0.2, -0.75)]:
        p.sphere((x, y, 0.28), 0.32, "canvas", segs=8, squash=0.9)
    return p


def plaza(radius=10.0):
    """The cobbled plaza: rings of stone setts in two shades over a dark grout bed, kerb stones round the edge (walkable, flat)."""
    p = Part("plaza")
    p.cylinder((0, 0, 0.015), radius, 0.03, "stone_dark", segs=40)
    p.tile((0, 0, 0.032), (0.9, 0.9), "sett_dark", rz=45)  # the centre stone
    r, ring = 0.9, 0
    while r < radius - 0.45:
        n = max(6, int(math.tau * r / 0.6))
        for i in range(n):
            a = (i + 0.5 * (ring % 2)) / n * math.tau
            key = "sett_dark" if (i * 7 + ring * 3) % 5 == 0 else "sett"
            p.tile((math.cos(a) * r, math.sin(a) * r, 0.032), (0.5, 0.48), key, rz=math.degrees(a))
        r += 0.56
        ring += 1
    for i in range(48):
        a = i / 48 * math.tau
        p.box((math.cos(a) * radius, math.sin(a) * radius, 0.05), (0.5, 1.25, 0.1), "stone_dark", rz=math.degrees(a))
    return p


def road(length=10.0, width=3.6):
    """A dirt road segment along Y with ruts and grassy verges (flat, walkable); scale along Y in Unity for length."""
    p = Part("road")
    p.box((0, 0, 0.015), (width, length, 0.03), "dirt")
    for x in (-0.6, 0.6):
        p.box((x, 0, 0.035), (0.25, length, 0.01), "timber_light")
    for sx in (-1, 1):
        p.box((sx * (width / 2 + 0.15), 0, 0.02), (0.3, length, 0.04), "moss")
    return p


# ======================================================================== the wood: ruins and Grukk's camp
def ruin_column(height=4.0, broken=True):
    p = Part("ruin_column")
    p.box((0, 0, 0.2), (1.3, 1.3, 0.4), "stone_dark")
    p.cylinder((0, 0, 0.4 + height / 2), 0.42, height, "stone", segs=10)
    if broken:
        p.box((0.2, -0.1, 0.4 + height + 0.1), (0.5, 0.6, 0.3), "stone", rz=25, ry=20)
        p.cylinder((1.6, 0.4, 0.4), 0.42, 1.6, "stone", segs=10, rx=90, rz=70)  # a fallen drum
    else:
        p.box((0, 0, 0.4 + height + 0.15), (1.1, 1.1, 0.3), "stone_dark")
    p.sphere((-0.3, 0.3, 0.4 + height * 0.6), 0.35, "moss", segs=8, squash=0.5)
    return p


def ruin_arch():
    """A standing ruined arch of grey stone, mossy, one side cracked lower than the other."""
    p = Part("ruin_arch")
    for sx, h in ((-1, 4.6), (1, 3.9)):
        p.box((sx * 2.0, 0, h / 2), (1.0, 1.0, h), "stone")
    for i in range(7):
        a = math.pi * i / 6
        x, z = math.cos(a) * 2.0, 4.6 + math.sin(a) * 1.4
        if x > 1.2 and i < 2:
            continue  # the broken shoulder
        p.box((x, 0, z), (0.9, 0.95, 0.6), "stone", ry=-math.degrees(a) + 90)
    for x, z in ((-2.0, 4.7), (0.0, 6.1)):
        p.sphere((x, 0.1, z), 0.45, "moss", segs=8, squash=0.45)
    return p


def ruin_mural_wall():
    """The Whisperwood mural: a broken wall with a carved panel (its figures picked out in pale stone)."""
    p = Part("ruin_mural_wall")
    p.box((0, 0, 1.6), (6.0, 0.8, 3.2), "stone")
    p.prism([(-3.0, 3.2), (-1.0, 3.2), (-2.0, 4.0)], 0.8, "stone")
    p.box((0.4, -0.42, 1.7), (3.6, 0.06, 2.0), "stone_dark")
    for i, (x, z, w, h) in enumerate([(-0.8, 1.6, 0.4, 1.1), (0.0, 1.8, 0.35, 1.3), (0.8, 1.5, 0.45, 1.0), (1.6, 1.9, 0.3, 0.9)]):
        p.box((x, -0.47, z), (w, 0.04, h), "bone")
    p.cylinder((0.4, -0.47, 2.45), 0.28, 0.04, "rune", segs=12, rx=90)
    p.sphere((2.6, 0.2, 3.1), 0.5, "moss", segs=8, squash=0.5)
    return p


def goblin_hut():
    """A goblin hut: a round hide tent on bent poles, bone tips, a smoke hole and a hide door flap (faces -Y)."""
    p = Part("goblin_hut")
    p.cylinder((0, 0, 1.3), 2.0, 2.6, "hide", segs=9, radius_top=0.35)
    for i in range(9):
        a = i / 9 * math.tau
        p.cylinder((math.cos(a) * 1.15, math.sin(a) * 1.15, 1.5), 0.06, 3.2, "timber", segs=5)
        p.cylinder((math.cos(a) * 0.3, math.sin(a) * 0.3, 3.05), 0.07, 0.6, "bone", segs=5, radius_top=0.0)
    p.box((0, -1.75, 0.8), (1.0, 0.3, 1.5), "timber")  # door flap opening (dark)
    p.prism([(-0.6, 0), (0.6, 0), (0, 1.7)], 0.06, "hide", origin=(0, -1.95, 0))
    p.sphere((1.3, -1.4, 0.4), 0.4, "bone", segs=6, squash=0.6)  # a skull pile
    return p


def goblin_totem():
    """Grukk's war totem: a tall pole of stacked carved faces, bones, a red rag and horns."""
    p = Part("goblin_totem")
    p.cylinder((0, 0, 0.3), 0.8, 0.6, "stone_dark", segs=8)
    p.cylinder((0, 0, 2.6), 0.28, 4.2, "timber", segs=8)
    for k, z in enumerate((1.6, 2.7, 3.8)):
        p.box((0, -0.05, z), (0.75, 0.6, 0.8), "timber_light")
        p.box((0, -0.36, z + 0.1), (0.5, 0.02, 0.12), "cloth_red")
        p.box((0, -0.36, z - 0.18), (0.36, 0.02, 0.08), "bone")
    for s in (-1, 1):
        p.cylinder((s * 0.55, 0, 4.85), 0.1, 0.9, "bone", segs=6, radius_top=0.0, rx=0, rz=0)
        p.box((s * 0.45, 0, 4.55), (0.4, 0.12, 0.12), "bone", ry=s * 40)
    p.box((0.35, 0, 4.2), (0.05, 0.6, 1.0), "cloth_red", rz=10)
    p.sphere((0, 0, 4.85), 0.3, "bone", segs=8)
    return p


BUILDERS = {
    "guild_hall": guild_hall, "inn_sleeping_griffon": inn, "smithy": smithy,
    "house_cottage": lambda: house("cottage"), "house_house": lambda: house("house"), "house_tall": lambda: house("tall"),
    "temple": temple, "orphanage": orphanage, "town_gate": town_gate, "palisade": palisade,
    "well": well, "watchtower_ruin": watchtower_ruin, "barn": barn, "waystone": waystone,
    "market_stall_red": lambda: market_stall("cloth_red"), "market_stall_blue": lambda: market_stall("cloth_blue"),
    "lamp_post": lamp_post, "windmill": windmill, "training_dummy": training_dummy, "weapon_rack": weapon_rack,
    "archery_target": archery_target, "tent": lambda: tent("canvas"), "tent_green": lambda: tent("cloth_green"),
    "campfire": campfire, "wagon": wagon, "crates": crates, "plaza": plaza, "road": road,
    "ruin_column": ruin_column, "ruin_column_whole": lambda: ruin_column(4.6, broken=False), "ruin_arch": ruin_arch,
    "ruin_mural_wall": ruin_mural_wall, "goblin_hut": goblin_hut, "goblin_totem": goblin_totem,
}


# ======================================================================== export & preview
def export_fbx(obj):
    os.makedirs(FBX_DIR, exist_ok=True)
    bpy.ops.object.select_all(action="DESELECT")
    obj.select_set(True)
    bpy.context.view_layer.objects.active = obj
    path = os.path.join(FBX_DIR, f"{obj.name}.fbx")
    bpy.ops.export_scene.fbx(filepath=path, use_selection=True, object_types={"MESH"}, axis_forward="-Z", axis_up="Y",
                             apply_scale_options="FBX_SCALE_UNITS", bake_space_transform=True, mesh_smooth_type="FACE",
                             path_mode="AUTO")
    tris = sum(len(p.vertices) - 2 for p in obj.data.polygons)
    print(f"[Ascend] Exported {path} ({tris} tris, {len(obj.data.materials)} materials)")


def build_all(only=None, export=True, collection_name="Town_Buildings", spacing=4.0):
    col = bpy.data.collections.get(collection_name)
    if col is None:
        col = bpy.data.collections.new(collection_name)
        bpy.context.scene.collection.children.link(col)
    for o in list(col.objects):
        bpy.data.objects.remove(o, do_unlink=True)
    objs = []
    x = 0.0
    for key, fn in BUILDERS.items():
        if only and key not in only:
            continue
        obj = fn().finish(col)
        obj.name = key
        objs.append(obj)
        if export:
            export_fbx(obj)
    # Lay them out in a row for review (after export, so the FBX stays centred on its origin).
    for obj in objs:
        w = obj.dimensions.x
        obj.location.x = x + w / 2
        x += w + spacing
    return objs


def preview(objs):
    scene = bpy.context.scene
    span = max(o.location.x + o.dimensions.x / 2 for o in objs)
    bpy.ops.mesh.primitive_plane_add(size=1, location=(span / 2, 0, 0))
    ground = bpy.context.active_object
    ground.scale = (span + 20, 30, 1)
    me = ground.data
    m = bpy.data.materials.new("Preview_Ground")
    m.diffuse_color = (*srgb_to_linear((0.47, 0.62, 0.40)), 1)
    m.use_nodes = True
    next(n for n in m.node_tree.nodes if n.type == "BSDF_PRINCIPLED").inputs["Base Color"].default_value = (*srgb_to_linear((0.47, 0.62, 0.40)), 1)
    me.materials.append(m)
    bpy.ops.object.light_add(type="SUN", location=(0, -10, 20))
    sun = bpy.context.active_object
    sun.rotation_euler = (math.radians(50), 0, math.radians(-35))
    sun.data.energy = 3.5
    world = bpy.data.worlds.new("Sky")
    scene.world = world
    world.use_nodes = True
    next(n for n in world.node_tree.nodes if n.type == "BACKGROUND").inputs["Color"].default_value = (0.62, 0.76, 0.95, 1.0)
    # An orthographic three-quarter view wide enough for the whole row.
    bpy.ops.object.camera_add(location=(span / 2, -60, 40))
    cam = bpy.context.active_object
    cam.rotation_euler = (math.radians(62), 0, 0)
    cam.data.type = "ORTHO"
    cam.data.ortho_scale = span * 1.04
    scene.camera = cam
    for e in ("BLENDER_EEVEE_NEXT", "BLENDER_EEVEE", "CYCLES"):
        try:
            scene.render.engine = e
            break
        except TypeError:
            continue
    scene.render.resolution_x, scene.render.resolution_y = 2400, 520
    scene.render.filepath = PREVIEW_PATH
    os.makedirs(os.path.dirname(PREVIEW_PATH), exist_ok=True)
    bpy.ops.render.render(write_still=True)
    print(f"[Ascend] Preview saved: {PREVIEW_PATH}")


def main():
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    only = None
    if "--only" in argv:
        only = set(argv[argv.index("--only") + 1].split(","))
    bpy.ops.wm.read_factory_settings(use_empty=True)
    objs = build_all(only=only, export=True)
    os.makedirs(os.path.dirname(BLEND_PATH), exist_ok=True)
    preview(objs)
    bpy.ops.wm.save_as_mainfile(filepath=BLEND_PATH)
    print(f"[Ascend] Saved {BLEND_PATH}")


if __name__ == "__main__" and bpy.app.background:
    main()
