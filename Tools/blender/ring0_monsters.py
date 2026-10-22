"""
Ring 0 monster models (Blue Slime, Goblin, Horned Rabbit), built procedurally from their
bestiary descriptions (Data/Monsters/species.json → signature / design recipe).

Run headless (no add-on needed):
  blender -b --factory-startup -P Tools/blender/ring0_monsters.py
Outputs:
  Game/Assets/_Game/Art/Models/Monsters/<Name>.fbx   (Unity: -Z forward, Y up, transforms applied)
  Art/Blender/ring0_monsters.blend                    (source)
  13_Production/screenshots/ring0_monsters_blender.png (preview render)
Conventions: metres, feet on the ground at the origin, creature faces -Y in Blender (+Z in Unity).
"""
import math
import os

import bpy
import bmesh
from mathutils import Vector

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", ".."))
FBX_DIR = os.path.join(ROOT, "Game", "Assets", "_Game", "Art", "Models", "Monsters")
BLEND_PATH = os.path.join(ROOT, "Art", "Blender", "ring0_monsters.blend")
PREVIEW_PATH = os.path.join(ROOT, "13_Production", "screenshots", "ring0_monsters_blender.png")


# ---------------------------------------------------------------- helpers
def reset_scene():
    bpy.ops.wm.read_factory_settings(use_empty=True)


def material(name, color, roughness=0.5, metallic=0.0, emission=None, emission_strength=0.0):
    m = bpy.data.materials.get(name) or bpy.data.materials.new(name)
    m.use_nodes = True
    bsdf = next(n for n in m.node_tree.nodes if n.type == "BSDF_PRINCIPLED")
    bsdf.inputs["Base Color"].default_value = (*color, 1.0)
    bsdf.inputs["Roughness"].default_value = roughness
    bsdf.inputs["Metallic"].default_value = metallic
    if emission is not None:
        bsdf.inputs["Emission Color"].default_value = (*emission, 1.0)
        bsdf.inputs["Emission Strength"].default_value = emission_strength
    m.diffuse_color = (*color, 1.0)  # viewport colour
    return m


def finish(obj, mat, smooth=True):
    obj.data.materials.clear()
    obj.data.materials.append(mat)
    for p in obj.data.polygons:
        p.use_smooth = smooth
    return obj


def sphere(name, loc, scale, mat, segments=24, rings=16, smooth=True):
    bpy.ops.mesh.primitive_uv_sphere_add(segments=segments, ring_count=rings, radius=1.0, location=loc)
    o = bpy.context.active_object
    o.name = name
    o.scale = scale
    return finish(o, mat, smooth)


def cylinder(name, loc, radius, depth, mat, rot=(0, 0, 0), verts=16, smooth=True):
    bpy.ops.mesh.primitive_cylinder_add(vertices=verts, radius=radius, depth=depth, location=loc, rotation=rot)
    o = bpy.context.active_object
    o.name = name
    return finish(o, mat, smooth)


def cone(name, loc, r1, depth, mat, rot=(0, 0, 0), r2=0.0, verts=16, smooth=True):
    bpy.ops.mesh.primitive_cone_add(vertices=verts, radius1=r1, radius2=r2, depth=depth, location=loc, rotation=rot)
    o = bpy.context.active_object
    o.name = name
    return finish(o, mat, smooth)


def cube(name, loc, scale, mat, rot=(0, 0, 0)):
    bpy.ops.mesh.primitive_cube_add(size=1.0, location=loc, rotation=rot)
    o = bpy.context.active_object
    o.name = name
    o.scale = scale
    return finish(o, mat, smooth=False)


def join(name, parts):
    bpy.ops.object.select_all(action="DESELECT")
    for p in parts:
        p.select_set(True)
    bpy.context.view_layer.objects.active = parts[0]
    bpy.ops.object.join()
    o = bpy.context.active_object
    o.name = name
    o.data.name = name
    bpy.ops.object.transform_apply(location=False, rotation=True, scale=True)
    # Origin at the feet (world origin), so the model stands on the ground in Unity.
    bpy.context.scene.cursor.location = (0, 0, 0)
    bpy.ops.object.origin_set(type="ORIGIN_CURSOR")
    return o


def apply_modifiers(o):
    bpy.ops.object.select_all(action="DESELECT")
    o.select_set(True)
    bpy.context.view_layer.objects.active = o
    for m in list(o.modifiers):
        bpy.ops.object.modifier_apply(modifier=m.name)


# ---------------------------------------------------------------- monsters
def build_blue_slime():
    """'A teardrop body with a glossy highlight and two dot eyes' (F-, 0.4 m, Charming)."""
    jelly = material("Slime_Jelly", (0.22, 0.58, 1.0), roughness=0.08)
    black = material("Slime_Eye", (0.02, 0.02, 0.04), roughness=0.3)
    white = material("Slime_Highlight", (1, 1, 1), roughness=0.1, emission=(1, 1, 1), emission_strength=1.5)

    body = sphere("Body", (0, 0, 0.17), (0.25, 0.25, 0.19), jelly, segments=32, rings=20)
    bpy.ops.object.transform_apply(location=False, rotation=False, scale=True)
    bm = bmesh.new()
    bm.from_mesh(body.data)
    for v in bm.verts:  # flatten the base, pull the crown into a soft teardrop tip
        z = v.co.z
        if z < -0.1:
            v.co.z = -0.1 - (z + 0.1) * 0.25
        t = max(0.0, z / 0.19)
        v.co.z += 0.12 * t ** 3
        v.co.x *= 1.0 - 0.35 * t ** 2
        v.co.y *= 1.0 - 0.35 * t ** 2
    bm.to_mesh(body.data)
    bm.free()
    body.location.z = 0.10 + 0.025 * 0.25  # flattened base sits on the ground

    eyes = [sphere(f"Eye_{s}", (0.075 * s, -0.225, 0.15), (0.028, 0.012, 0.045), black) for s in (-1, 1)]
    shine = sphere("Highlight", (-0.1, -0.19, 0.24), (0.035, 0.01, 0.02), white)
    shine.rotation_euler = (0.5, 0.0, 0.6)
    return join("Blue_Slime", [body, *eyes, shine])


def build_goblin():
    """'A grin of needle teeth under a stolen tin helmet' (F-, 1.0 m, Menacing)."""
    skin = material("Goblin_Skin", (0.34, 0.47, 0.2), roughness=0.7)
    cloth = material("Goblin_Loincloth", (0.36, 0.22, 0.12), roughness=0.9)
    tin = material("Goblin_Helmet", (0.62, 0.64, 0.66), roughness=0.35, metallic=0.8)
    eye = material("Goblin_Eye", (1.0, 0.85, 0.1), roughness=0.4, emission=(1.0, 0.75, 0.05), emission_strength=4.0)
    teeth = material("Goblin_Teeth", (0.95, 0.92, 0.8), roughness=0.5)
    rust = material("Goblin_Dagger", (0.42, 0.28, 0.18), roughness=0.6, metallic=0.5)
    dark = material("Goblin_Mouth", (0.08, 0.02, 0.02), roughness=0.8)

    parts = []
    for s in (-1, 1):  # bowed legs and big feet
        parts.append(cylinder(f"Leg_{s}", (0.08 * s, 0, 0.17), 0.045, 0.32, skin, rot=(0, 0.12 * s, 0)))
        parts.append(sphere(f"Foot_{s}", (0.1 * s, -0.04, 0.025), (0.06, 0.1, 0.03), skin))
    parts.append(sphere("Torso", (0, 0, 0.5), (0.16, 0.12, 0.2), skin))
    parts.append(cylinder("Loincloth", (0, 0, 0.36), 0.15, 0.12, cloth, verts=10, smooth=False))
    for s in (-1, 1):  # long arms
        parts.append(cylinder(f"Arm_{s}", (0.205 * s, -0.02, 0.47), 0.035, 0.34, skin, rot=(0, -0.28 * s, 0)))
        parts.append(sphere(f"Hand_{s}", (0.255 * s, -0.02, 0.3), (0.045, 0.045, 0.05), skin))
    parts.append(sphere("Head", (0, -0.02, 0.8), (0.14, 0.13, 0.13), skin))
    for s in (-1, 1):  # long pointed ears, angled up and out
        parts.append(cone(f"Ear_{s}", (0.2 * s, 0.0, 0.84), 0.045, 0.24, skin, rot=(0, -1.25 * s, 0.25 * s)))
        parts.append(sphere(f"Eye_{s}", (0.055 * s, -0.135, 0.83), (0.025, 0.012, 0.018), eye))
    parts.append(cone("Nose", (0, -0.17, 0.78), 0.028, 0.1, skin, rot=(1.9, 0, 0)))
    parts.append(cube("Mouth", (0, -0.125, 0.725), (0.11, 0.02, 0.025), dark))
    for i in range(-2, 3):  # needle teeth
        parts.append(cone(f"Tooth_{i}", (0.022 * i, -0.135, 0.718), 0.008, 0.03, teeth, rot=(math.pi, 0, 0), verts=6, smooth=False))
    helmet = sphere("Helmet", (0, -0.01, 0.865), (0.15, 0.14, 0.1), tin, segments=20, rings=10)
    bpy.ops.object.mode_set(mode="EDIT")
    bpy.ops.mesh.select_all(action="DESELECT")
    bpy.ops.object.mode_set(mode="OBJECT")
    for v in helmet.data.vertices:  # keep the top half: a too-small tin pot
        v.select = v.co.z < -0.05
    bpy.ops.object.mode_set(mode="EDIT")
    bpy.ops.mesh.delete(type="VERT")
    bpy.ops.object.mode_set(mode="OBJECT")
    helmet.rotation_euler = (0.15, 0.1, 0)
    parts.append(helmet)
    parts.append(cube("Dagger_Blade", (0.255, -0.17, 0.3), (0.008, 0.18, 0.035), rust))
    parts.append(cylinder("Dagger_Grip", (0.255, -0.05, 0.3), 0.013, 0.08, cloth, rot=(math.pi / 2, 0, 0), verts=8))
    return join("Goblin", parts)


def build_horned_rabbit():
    """'A single spiral horn and oversized hind feet' (F-, 0.4 m, Wild)."""
    fur = material("Rabbit_Fur", (0.96, 0.94, 0.9), roughness=0.95)
    pink = material("Rabbit_InnerEar", (0.95, 0.66, 0.7), roughness=0.9)
    eye = material("Rabbit_Eye", (0.75, 0.05, 0.08), roughness=0.2)
    horn = material("Rabbit_Horn", (0.93, 0.82, 0.55), roughness=0.35)

    parts = [
        sphere("Body", (0, 0.03, 0.15), (0.13, 0.18, 0.13), fur),
        sphere("Head", (0, -0.15, 0.25), (0.085, 0.09, 0.08), fur),
        sphere("Tail", (0, 0.21, 0.2), (0.045, 0.045, 0.045), fur),
    ]
    for s in (-1, 1):
        parts.append(sphere(f"Ear_{s}", (0.035 * s, -0.11, 0.39), (0.025, 0.015, 0.11), fur))
        parts.append(sphere(f"EarInner_{s}", (0.035 * s, -0.125, 0.39), (0.014, 0.006, 0.085), pink))
        parts.append(sphere(f"HindFoot_{s}", (0.075 * s, 0.06, 0.025), (0.04, 0.11, 0.025), fur))  # oversized
        parts.append(sphere(f"FrontPaw_{s}", (0.05 * s, -0.12, 0.03), (0.022, 0.035, 0.025), fur))
        parts.append(sphere(f"Eye_{s}", (0.05 * s, -0.215, 0.27), (0.014, 0.008, 0.016), eye))
    for p in parts:
        if p.name.startswith("Ear_") or p.name.startswith("EarInner_"):
            p.rotation_euler = (-0.2, 0, 0)
    h = cone("Horn", (0, -0.21, 0.37), 0.022, 0.17, horn, rot=(-0.45, 0, 0), verts=12)
    bpy.ops.object.mode_set(mode="EDIT")
    bpy.ops.mesh.subdivide(number_cuts=8)
    bpy.ops.object.mode_set(mode="OBJECT")
    tw = h.modifiers.new("Spiral", "SIMPLE_DEFORM")
    tw.deform_method = "TWIST"
    tw.angle = math.radians(540)
    tw.deform_axis = "Z"
    apply_modifiers(h)
    parts.append(h)
    return join("Horned_Rabbit", parts)


# ---------------------------------------------------------------- export & preview
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


def preview(objs):
    scene = bpy.context.scene
    xs = [-0.9, 0.0, 0.85]
    for o, x in zip(objs, xs):
        o.location.x = x
    bpy.ops.mesh.primitive_plane_add(size=6, location=(0, 0, 0))
    ground = bpy.context.active_object
    finish(ground, material("Preview_Ground", (0.5, 0.68, 0.45), roughness=0.9), smooth=False)

    bpy.ops.object.light_add(type="SUN", location=(2, -3, 5))
    sun = bpy.context.active_object
    sun.rotation_euler = (math.radians(50), 0, math.radians(30))
    sun.data.energy = 3.5
    world = bpy.data.worlds.new("Sky")
    scene.world = world
    world.use_nodes = True
    bg = next(n for n in world.node_tree.nodes if n.type == "BACKGROUND")
    bg.inputs["Color"].default_value = (0.62, 0.76, 0.95, 1.0)
    bg.inputs["Strength"].default_value = 0.9

    bpy.ops.object.camera_add(location=(0.4, -3.1, 1.25))
    cam = bpy.context.active_object
    direction = Vector((0.0, 0.0, 0.42)) - cam.location
    cam.rotation_euler = direction.to_track_quat("-Z", "Y").to_euler()
    cam.data.lens = 50
    scene.camera = cam

    engines = [i.identifier for i in bpy.types.RenderSettings.bl_rna.properties["engine"].enum_items]
    for e in ("BLENDER_EEVEE_NEXT", "BLENDER_EEVEE", "BLENDER_WORKBENCH"):
        if e in engines:
            scene.render.engine = e
            break
    scene.render.resolution_x, scene.render.resolution_y = 1280, 720
    scene.render.filepath = PREVIEW_PATH
    os.makedirs(os.path.dirname(PREVIEW_PATH), exist_ok=True)
    bpy.ops.render.render(write_still=True)
    print(f"[Ascend] Preview ({scene.render.engine}) saved: {PREVIEW_PATH}")


def main():
    reset_scene()
    monsters = [build_blue_slime(), build_goblin(), build_horned_rabbit()]
    for m in monsters:
        m.location = (0, 0, 0)
        export_fbx(m)
    os.makedirs(os.path.dirname(BLEND_PATH), exist_ok=True)
    preview(monsters)
    bpy.ops.wm.save_as_mainfile(filepath=BLEND_PATH)
    print("[Ascend] Done")


main()
