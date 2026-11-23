"""
Guild Issue Sword (itm_guild_issue_sword): the Swordsman's starter weapon, authored directly at budget (D-03).

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_weapon_sword.py [-- --out <fbx>] [--sheet <dir>]

Design: "Leafblade". A willow-leaf blade (widest a little above the middle, a nod to Whisperwood), a crescent guard whose
tips sweep up toward the blade, a leather grip between two bronze ferrules, a faceted bronze pommel and one small
teal inlay in the guard. Original shapes, no other game's weapon.

Units are metres. Blender is Z-up, so the blade runs along +Z here, which the FBX export (axis_up Y) turns into +Y in
Unity. The origin is the centre of the grip (the hand-hold point). Flat shaded, one fallback material per tone, the
same tone written as vertex colour. Deterministic: no randomness, same bytes on every run.
"""
import math
import os
import sys

import bmesh
import bpy

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.abspath(os.path.join(HERE, "..", ".."))
DEFAULT_OUT = os.path.join(ROOT, "Game", "Assets", "_Game", "Art", "Models", "Weapons", "sword_starter.fbx")

# tone -> sRGB hex. 60% steel (blade), 30% leather + bronze, 10% teal accent (art_direction.md section 2).
# Steel is a cool light grey-blue (value well above the dark town ground); no reserved gameplay colour is used.
TONES = [
    ("steel", "#A8BACB"),
    ("steel_edge", "#D6E0EA"),
    ("leather", "#6A4535"),
    ("bronze", "#B27A3E"),
    ("accent", "#2FB59A"),
]
TONE_INDEX = {name: i for i, (name, _) in enumerate(TONES)}

# Layout along the blade axis (Z), metres
GRIP_HALF = 0.09
GUARD_Z = GRIP_HALF          # guard sits on top of the grip
BLADE_BASE = 0.125
BLADE_LEN = 0.92
BLADE_TIP = BLADE_BASE + BLADE_LEN   # 1.045


def srgb_to_linear(c):
    return c / 12.92 if c <= 0.04045 else ((c + 0.055) / 1.055) ** 2.4


def hex_rgba(h):
    h = h.lstrip("#")
    return tuple(int(h[i:i + 2], 16) / 255.0 for i in (0, 2, 4)) + (1.0,)


class Builder:
    def __init__(self):
        self.bm = bmesh.new()

    def face(self, verts, tone):
        f = self.bm.faces.new(verts)
        f.material_index = TONE_INDEX[tone]
        f.smooth = False
        return f

    def v(self, x, y, z):
        return self.bm.verts.new((x, y, z))

    def ring_loft(self, rings, tone_fn, cap_start=True, cap_end=True):
        """rings: list of rings, each a list of verts (same count). Quads between rings."""
        n = len(rings[0])
        for a in range(len(rings) - 1):
            for i in range(n):
                j = (i + 1) % n
                self.face([rings[a][i], rings[a][j], rings[a + 1][j], rings[a + 1][i]], tone_fn(a, i))
        return rings

    def cap(self, ring, tone, flip=False):
        vs = list(reversed(ring)) if flip else list(ring)
        self.face(vs, tone)


def blade(b):
    # (z, half width, half thickness); a leaf: widest ~58% up, then a long taper to the point.
    stations = [
        (BLADE_BASE, 0.030, 0.0070),
        (BLADE_BASE + 0.10, 0.042, 0.0075),
        (BLADE_BASE + 0.34, 0.056, 0.0085),
        (BLADE_BASE + 0.54, 0.054, 0.0082),
        (BLADE_BASE + 0.74, 0.034, 0.0060),
        (BLADE_BASE + 0.86, 0.016, 0.0040),
    ]
    rings = []
    for z, w, t in stations:
        # hexagonal section: sharp edges L/R, flat faces top and bottom
        rings.append([b.v(-w, 0, z), b.v(-w * 0.38, t, z), b.v(w * 0.38, t, z),
                      b.v(w, 0, z), b.v(w * 0.38, -t, z), b.v(-w * 0.38, -t, z)])

    def tone(a, i):
        # i: 0 = edge between L and TL, 1 = top flat, 2 = TR..R, 3 = R..BR, 4 = bottom flat, 5 = BL..L
        return "steel" if i in (1, 4) else "steel_edge"

    b.ring_loft(rings, tone)
    b.cap(rings[0], "steel", flip=True)     # hidden inside the guard, keeps the shell closed
    tip = b.v(0, 0, BLADE_TIP)
    last = rings[-1]
    for i in range(6):
        b.face([last[i], last[(i + 1) % 6], tip], "steel" if i in (1, 4) else "steel_edge")


def prism_between(b, outline, y0, y1, tone_side, tone_face):
    """Extrude a closed (x, z) outline between y0 and y1; the caps are fanned from the centroid (no ngons)."""
    front = [b.v(x, y0, z) for x, z in outline]
    back = [b.v(x, y1, z) for x, z in outline]
    n = len(outline)
    for i in range(n):
        j = (i + 1) % n
        b.face([front[i], front[j], back[j], back[i]], tone_side)
    cx = sum(p[0] for p in outline) / n
    cz = sum(p[1] for p in outline) / n
    cf = b.v(cx, y0, cz)
    cb = b.v(cx, y1, cz)
    for i in range(n):
        j = (i + 1) % n
        b.face([front[j], front[i], cf], tone_face)
        b.face([back[i], back[j], cb], tone_face)


def guard(b):
    z0 = GUARD_Z
    # crescent: low in the middle, tips sweep up and out to a point (triangle over the circle pommel, section 4.1)
    outline = [
        (0.000, z0 + 0.000),
        (0.045, z0 + 0.004),
        (0.096, z0 + 0.034),
        (0.116, z0 + 0.080),   # tip (upper)
        (0.078, z0 + 0.052),
        (0.032, z0 + 0.034),
        (0.000, z0 + 0.034),
        (-0.032, z0 + 0.034),
        (-0.078, z0 + 0.052),
        (-0.116, z0 + 0.080),
        (-0.096, z0 + 0.034),
        (-0.045, z0 + 0.004),
    ]
    prism_between(b, outline, -0.014, 0.014, "bronze", "bronze")
    # teal inlay: a small diamond proud of the front face (-Y) so it reads from the flat side
    cz = z0 + 0.019
    r = 0.016
    fx = [b.v(0, -0.012, cz + r), b.v(r * 0.75, -0.012, cz), b.v(0, -0.012, cz - r), b.v(-r * 0.75, -0.012, cz)]
    apex = b.v(0, -0.026, cz)
    for i in range(4):
        b.face([fx[(i + 1) % 4], fx[i], apex], "accent")
    # base quad sits inside the guard body and seals the pyramid (closed shell, no hidden open edges)
    b.face([fx[0], fx[1], fx[2], fx[3]], "accent")


def grip(b):
    def ring(z, rx, ry):
        return [b.v(rx * math.cos(a), ry * math.sin(a), z) for a in [k * math.pi / 3.0 for k in range(6)]]

    zs = [(-GRIP_HALF, 0.0155, 0.0150, "bronze"),    # lower ferrule
          (-GRIP_HALF + 0.014, 0.0155, 0.0150, "leather"),
          (-0.03, 0.0185, 0.0170, "leather"),
          (0.03, 0.0185, 0.0170, "leather"),
          (GRIP_HALF - 0.014, 0.0155, 0.0150, "bronze"),
          (GRIP_HALF + 0.001, 0.0155, 0.0150, "bronze")]
    rings = [ring(z, rx, ry) for z, rx, ry, _ in zs]

    def tone(a, i):
        return zs[a][3] if a in (0, 4) else "leather"

    b.ring_loft(rings, tone)
    b.cap(rings[0], "bronze", flip=True)
    b.cap(rings[-1], "bronze")
    # bronze ferrule rings are slightly wider than the wrap
    # (segments 0 and 4 use the bronze tone above)


def pommel(b):
    # faceted bronze ovoid, 3 rings of 8 + poles
    cz = -GRIP_HALF - 0.022
    prof = [(-0.034, 0.000), (-0.027, 0.020), (-0.010, 0.033), (0.010, 0.030), (0.024, 0.017), (0.032, 0.000)]
    rings = []
    for dz, r in prof[1:-1]:
        rings.append([b.v(r * math.cos(k * math.pi / 4.0), r * math.sin(k * math.pi / 4.0), cz + dz) for k in range(8)])
    low = b.v(0, 0, cz + prof[0][0])
    high = b.v(0, 0, cz + prof[-1][0])
    b.ring_loft(rings, lambda a, i: "bronze")
    for i in range(8):
        j = (i + 1) % 8
        b.face([rings[0][j], rings[0][i], low], "bronze")
        b.face([rings[-1][i], rings[-1][j], high], "bronze")


def build():
    for o in list(bpy.data.objects):
        bpy.data.objects.remove(o, do_unlink=True)
    for m in list(bpy.data.meshes):
        bpy.data.meshes.remove(m)
    for m in list(bpy.data.materials):
        bpy.data.materials.remove(m)

    b = Builder()
    blade(b)
    guard(b)
    grip(b)
    pommel(b)
    bm = b.bm
    bmesh.ops.triangulate(bm, faces=bm.faces[:], quad_method="BEAUTY", ngon_method="BEAUTY")
    bmesh.ops.recalc_face_normals(bm, faces=bm.faces[:])   # per shell consistency is checked by check_weapon.py
    bm.normal_update()

    mesh = bpy.data.meshes.new("sword_starter")
    bm.to_mesh(mesh)
    bm.free()
    obj = bpy.data.objects.new("sword_starter", mesh)
    bpy.context.scene.collection.objects.link(obj)

    # materials: one per tone, plain Principled with the tone's colour (the Unity toon material replaces them on import)
    for name, hexcol in TONES:
        m = bpy.data.materials.new("sword_" + name)
        m.use_nodes = True
        bsdf = next(n for n in m.node_tree.nodes if n.type == "BSDF_PRINCIPLED")
        bsdf.inputs["Base Color"].default_value = hex_rgba(hexcol)
        bsdf.inputs["Roughness"].default_value = 0.8
        mesh.materials.append(m)

    # vertex colour (corner domain, byte colour, sRGB-ish values written as linear so the viewer shows the hex)
    attr = mesh.color_attributes.new("Col", "BYTE_COLOR", "CORNER")
    for poly in mesh.polygons:
        r, g, bl, _ = hex_rgba(TONES[poly.material_index][1])
        col = (srgb_to_linear(r), srgb_to_linear(g), srgb_to_linear(bl), 1.0)
        for li in poly.loop_indices:
            attr.data[li].color = col
    for p in mesh.polygons:
        p.use_smooth = False
    return obj


def export(obj, path):
    os.makedirs(os.path.dirname(path), exist_ok=True)
    bpy.ops.object.select_all(action="DESELECT")
    obj.select_set(True)
    bpy.context.view_layer.objects.active = obj
    bpy.ops.export_scene.fbx(filepath=path, use_selection=True, object_types={"MESH"}, axis_forward="-Z", axis_up="Y",
                             apply_unit_scale=True, apply_scale_options="FBX_SCALE_UNITS", bake_space_transform=True,
                             mesh_smooth_type="FACE", use_mesh_modifiers=True, colors_type="SRGB",
                             path_mode="AUTO", add_leaf_bones=False)


def sheet(obj, outdir):
    """3-view contact sheet (side, front/edge, 3/4) plus a greyscale 25% read; Workbench flat colours."""
    outdir = os.path.abspath(outdir)
    os.makedirs(outdir, exist_ok=True)
    sc = bpy.context.scene
    sc.render.engine = "BLENDER_WORKBENCH"
    sc.display.shading.light = "FLAT"
    sc.display.shading.color_type = "VERTEX"
    sc.display.shading.show_object_outline = True
    sc.display.shading.object_outline_color = (0.12, 0.10, 0.14)
    sc.render.film_transparent = False
    sc.world = bpy.data.worlds.new("w") if sc.world is None else sc.world
    sc.world.color = (0.30, 0.38, 0.30)
    sc.view_settings.view_transform = "Standard"
    sc.render.resolution_x = 520
    sc.render.resolution_y = 1000
    cam_data = bpy.data.cameras.new("cam")
    cam_data.type = "ORTHO"
    cam_data.ortho_scale = 1.35
    cam = bpy.data.objects.new("cam", cam_data)
    sc.collection.objects.link(cam)
    sc.camera = cam
    mid = (0, 0, 0.45)
    views = {"side": (0, -3, 0.45, 90, 0, 0),          # looking along +Y: the flat face
             "edge": (3, 0, 0.45, 90, 0, 90),          # looking along -X: the thin edge
             "three_quarter": (2.1, -2.1, 1.1, 70, 0, 45)}
    paths = []
    for name, (x, y, z, rx, ry, rz) in views.items():
        cam.location = (x, y, z)
        cam.rotation_euler = tuple(math.radians(a) for a in (rx, ry, rz))
        if name == "three_quarter":
            cam_data.ortho_scale = 1.5
        else:
            cam_data.ortho_scale = 1.35
        p = os.path.join(outdir, "sword_%s.png" % name)
        sc.render.filepath = p
        bpy.ops.render.render(write_still=True)
        paths.append(p)
    return paths


def args():
    a = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    o = {"out": DEFAULT_OUT, "sheet": None}
    for k in ("out", "sheet"):
        if "--" + k in a:
            o[k] = a[a.index("--" + k) + 1]
    return o


def main():
    o = args()
    obj = build()
    tris = len(obj.data.polygons)
    lo = [min(v.co[i] for v in obj.data.vertices) for i in range(3)]
    hi = [max(v.co[i] for v in obj.data.vertices) for i in range(3)]
    print("[sword] tris=%d verts=%d size=%.3f x %.3f x %.3f m  z=[%.3f..%.3f]" %
          (tris, len(obj.data.vertices), hi[0] - lo[0], hi[1] - lo[1], hi[2] - lo[2], lo[2], hi[2]))
    export(obj, o["out"])
    print("[sword] exported", o["out"], os.path.getsize(o["out"]), "bytes")
    if o["sheet"]:
        for p in sheet(obj, o["sheet"]):
            print("[sword] rendered", p)


main()
