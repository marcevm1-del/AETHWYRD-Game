"""
Front / side / back turnaround sheets for every monster model in the game (the FBX files Unity uses).

Run headless:
  blender -b --factory-startup -P Tools/blender/turnarounds.py
For each Game/Assets/_Game/Art/Models/Monsters/<Name>.fbx it writes, in 08_Bestiary/turnarounds/:
  <Name>_front.png, <Name>_side.png, <Name>_back.png   (orthographic, same scale, ground line at the bottom)
  <Name>_sheet.png                                     (all three side by side, labelled, with a height scale bar)
Models face -Y in Blender (+Z in Unity) after import, so "front" looks at the face.
"""
import math
import os

import bpy
from mathutils import Vector

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", ".."))
MODELS = os.path.join(ROOT, "Game", "Assets", "_Game", "Art", "Models", "Monsters")
OUT = os.path.join(ROOT, "08_Bestiary", "turnarounds")
VIEWS = [("front", 0.0), ("side", -90.0), ("back", 180.0)]  # model yaw so the camera sees that view


def reset():
    bpy.ops.wm.read_factory_settings(use_empty=True)


def setup_scene(res_x, res_y):
    scene = bpy.context.scene
    engines = [i.identifier for i in bpy.types.RenderSettings.bl_rna.properties["engine"].enum_items]
    for e in ("BLENDER_EEVEE_NEXT", "BLENDER_EEVEE", "BLENDER_WORKBENCH"):
        if e in engines:
            scene.render.engine = e
            break
    scene.render.resolution_x, scene.render.resolution_y = res_x, res_y
    scene.render.film_transparent = False
    world = bpy.data.worlds.new("Studio")
    scene.world = world
    world.use_nodes = True
    bg = next(n for n in world.node_tree.nodes if n.type == "BACKGROUND")
    bg.inputs["Color"].default_value = (0.86, 0.88, 0.9, 1.0)
    bg.inputs["Strength"].default_value = 1.0
    # Key + fill + rim, the same for every monster so sheets compare fairly.
    for name, rot, energy in (("Key", (50, 0, 35), 3.5), ("Fill", (60, 0, -60), 1.2), ("Rim", (35, 0, 180), 2.0)):
        bpy.ops.object.light_add(type="SUN")
        light = bpy.context.active_object
        light.name = name
        light.rotation_euler = tuple(math.radians(a) for a in rot)
        light.data.energy = energy
    return scene


def ortho_camera(center_x, center_z, ortho_scale):
    bpy.ops.object.camera_add(location=(center_x, -20.0, center_z), rotation=(math.radians(90), 0, 0))
    cam = bpy.context.active_object
    cam.data.type = "ORTHO"
    cam.data.ortho_scale = ortho_scale
    bpy.context.scene.camera = cam
    return cam


def import_model(path):
    before = set(bpy.data.objects)
    bpy.ops.import_scene.fbx(filepath=path)
    objs = [o for o in bpy.data.objects if o not in before and o.type == "MESH"]
    bpy.ops.object.select_all(action="DESELECT")
    for o in objs:
        o.select_set(True)
    bpy.context.view_layer.objects.active = objs[0]
    if len(objs) > 1:
        bpy.ops.object.join()
    model = bpy.context.active_object
    bpy.ops.object.transform_apply(location=False, rotation=True, scale=True)
    return model


def bounds(obj):
    pts = [obj.matrix_world @ Vector(c) for c in obj.bound_box]
    lo = Vector((min(p.x for p in pts), min(p.y for p in pts), min(p.z for p in pts)))
    hi = Vector((max(p.x for p in pts), max(p.y for p in pts), max(p.z for p in pts)))
    return lo, hi


def text(body, location, size=0.08, color=(0.15, 0.17, 0.2)):
    bpy.ops.object.text_add(location=location, rotation=(math.radians(90), 0, 0))
    t = bpy.context.active_object
    t.data.body = body
    t.data.size = size
    t.data.align_x = "CENTER"
    mat = bpy.data.materials.new("Label")
    mat.use_nodes = True
    bsdf = next(n for n in mat.node_tree.nodes if n.type == "BSDF_PRINCIPLED")
    bsdf.inputs["Base Color"].default_value = (*color, 1.0)
    bsdf.inputs["Emission Color"].default_value = (*color, 1.0)
    bsdf.inputs["Emission Strength"].default_value = 1.0
    t.data.materials.append(mat)
    return t


def ground_line(x0, x1, z):
    bpy.ops.mesh.primitive_plane_add(size=1, location=((x0 + x1) / 2, 0.5, z - 0.002))
    g = bpy.context.active_object
    g.scale = (x1 - x0, 1.0, 1.0)
    mat = bpy.data.materials.new("Ground")
    mat.use_nodes = True
    bsdf = next(n for n in mat.node_tree.nodes if n.type == "BSDF_PRINCIPLED")
    bsdf.inputs["Base Color"].default_value = (0.62, 0.66, 0.7, 1.0)
    g.data.materials.append(mat)
    return g


def render(path):
    bpy.context.scene.render.filepath = path
    bpy.ops.render.render(write_still=True)


def turnaround(fbx):
    name = os.path.splitext(os.path.basename(fbx))[0]
    reset()
    setup_scene(900, 900)
    model = import_model(fbx)
    lo, hi = bounds(model)
    height = hi.z - lo.z
    span = max(hi.x - lo.x, hi.y - lo.y, height)
    model.location.z -= lo.z  # feet on z = 0
    ground_line(-span * 2, span * 2, 0.0)

    # Single views: same camera, the model turns.
    scale = span * 1.35
    ortho_camera(0.0, height / 2 + span * 0.08, scale)
    for view, yaw in VIEWS:
        model.rotation_euler = (0, 0, math.radians(yaw))
        render(os.path.join(OUT, f"{name}_{view}.png"))
        print(f"[Ascend] {name}_{view}.png")

    # Sheet: three copies side by side with labels and a 1 m bar.
    gap = span * 1.25
    copies = []
    for i, (view, yaw) in enumerate(VIEWS):
        c = model if i == 0 else model.copy()
        if i:
            c.data = model.data
            bpy.context.collection.objects.link(c)
        c.rotation_euler = (0, 0, math.radians(yaw))
        c.location.x = (i - 1) * gap
        copies.append(c)
        text(view.upper(), (c.location.x, -0.5, -span * 0.16), size=span * 0.09)
    text(f"{name.replace('_', ' ')}   ·   height {height:.2f} m", (0, -0.5, height + span * 0.18), size=span * 0.1)
    ref = next(r for r in (1.0, 0.5, 0.25, 0.1) if r <= max(0.1, height * 1.3))  # a scale bar that fits the frame
    bpy.ops.mesh.primitive_cube_add(size=1, location=(-1.5 * gap - span * 0.15, 0, ref / 2))
    bar = bpy.context.active_object
    bar.scale = (span * 0.02, span * 0.02, ref)
    text(f"{ref:g} m", (bar.location.x, -0.5, ref + span * 0.05), size=span * 0.07)
    bpy.context.scene.render.resolution_x, bpy.context.scene.render.resolution_y = 1800, 760
    for o in [o for o in bpy.data.objects if o.type == "CAMERA"]:
        bpy.data.objects.remove(o)
    ortho_camera(-span * 0.1, height / 2 + span * 0.05, gap * 3.4)
    render(os.path.join(OUT, f"{name}_sheet.png"))
    print(f"[Ascend] {name}_sheet.png")


def main():
    os.makedirs(OUT, exist_ok=True)
    fbxs = sorted(os.path.join(MODELS, f) for f in os.listdir(MODELS) if f.lower().endswith(".fbx"))
    for f in fbxs:
        turnaround(f)
    print(f"[Ascend] {len(fbxs)} monsters, {len(fbxs) * 4} images in {OUT}")


main()
