"""Project Ascend — Blender rig builder (Blender 4.x and 5.x; tested with 5.0.1).

Builds a monster armature from Data/Monsters/rigs.json, optionally with graybox proxy
meshes skinned to it (so a rig is animatable and testable in Unity before final art),
and exports a Unity-ready FBX.

Usage (from the project folder):
  blender --background --python Tools/blender/build_rig.py -- --rig small_biped --proxies --export Art/Monsters/rig_small_biped.fbx
  blender --background --python Tools/blender/build_rig.py -- --all --proxies --export-dir Art/Monsters
  Inside Blender: open the Scripting tab, load this file, set ARGS_IN_EDITOR below, press Run.

Options:
  --rig KEY           rig key from rigs.json (blob, small_biped, dragon, ...)
  --all               build every rig (each in its own collection, spaced along X)
  --size METERS       build at this size instead of the rig's refSize (default: refSize).
                      Build at refSize to share one rig + one animation set across many species;
                      Unity scales each species prefab (prefabScale in motion.json).
  --proxies           add graybox meshes for each hurtbox, weighted 100% to its bone
  --export FILE.fbx   export the built rig (single --rig)
  --export-dir DIR    export one FBX per rig (with --all)
  --rigs PATH         path to rigs.json (default: Data/Monsters/rigs.json next to this script's project)

Conventions (must match Unity):
  * Creature faces -Y in Blender, Z up, 1 Blender unit = 1 meter. Scene unit scale 1.0.
  * Export (export_fbx below): Forward -Z, Up Y, Apply Scalings "FBX Units Scale", Apply Transform OFF, no leaf
    bones, primary bone axis Y, secondary X, ALL bones (root and socket bones are needed in Unity), plus the axis fix
    of the "Blender To Unity FBX Exporter" add-on (Angel 'Edy' Garcia, MIT): for the export only, each object's data
    is rotated -90 deg on X and its object rotation +90 deg on X, then put back, so the FBX's root objects are
    written with rotation 0 and scale 1 instead of Blender's usual 90 deg X (checked with ufbx). Blender's own
    "Apply Transform" (bake_space_transform) is labelled "experimental ... known to be broken with
    armatures/animations" by Blender's FBX exporter: never use it for rigs. Exporting by hand: install that add-on
    (File > Export > Unity FBX), or use the settings above without the axis fix (the root objects then carry a
    90 deg X rotation in the file; bone positions and animation read back the same).
    In Unity the creature faces +Z. Set the Generic rig's Root node to "root" for root motion.
  * Bone names come straight from rigs.json (snake_case, _L/_R). Do not rename: Unity's
    prefab builder finds hurtbox, spring and part bones by these names.
"""
import json
import math
import os
import sys

import bpy
from mathutils import Matrix, Vector

ARGS_IN_EDITOR = ["--rig", "small_biped", "--proxies"]  # used when run from the Text Editor

# ----------------------------------------------------------------------------- args
def parse_args():
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else (ARGS_IN_EDITOR if not bpy.app.background else [])
    opts = {"rig": None, "all": False, "size": None, "proxies": False, "export": None, "export_dir": None, "rigs": None}
    i = 0
    while i < len(argv):
        a = argv[i]
        if a == "--rig": opts["rig"] = argv[i + 1]; i += 1
        elif a == "--all": opts["all"] = True
        elif a == "--size": opts["size"] = float(argv[i + 1]); i += 1
        elif a == "--proxies": opts["proxies"] = True
        elif a == "--export": opts["export"] = argv[i + 1]; i += 1
        elif a == "--export-dir": opts["export_dir"] = argv[i + 1]; i += 1
        elif a == "--rigs": opts["rigs"] = argv[i + 1]; i += 1
        else: raise SystemExit(f"Unknown option {a}")
        i += 1
    return opts


def find_rigs_json(explicit):
    if explicit:
        return explicit
    here = os.path.dirname(os.path.abspath(__file__)) if "__file__" in globals() else os.getcwd()
    for base in (here, os.getcwd()):
        for up in ("", "..", os.path.join("..", "..")):
            p = os.path.normpath(os.path.join(base, up, "Data", "Monsters", "rigs.json"))
            if os.path.exists(p):
                return p
    raise SystemExit("rigs.json not found; pass --rigs PATH")

# ----------------------------------------------------------------------------- build
def ensure_object_mode():
    if bpy.context.object and bpy.context.object.mode != "OBJECT":
        bpy.ops.object.mode_set(mode="OBJECT")


def new_collection(name):
    col = bpy.data.collections.get(name) or bpy.data.collections.new(name)
    if col.name not in bpy.context.scene.collection.children:
        bpy.context.scene.collection.children.link(col)
    return col


def build_armature(rig, size, offset_x=0.0):
    ensure_object_mode()
    name = f"rig_{rig['key']}"
    col = new_collection(name)
    arm = bpy.data.armatures.new(name)
    arm.display_type = "OCTAHEDRAL"
    obj = bpy.data.objects.new(name, arm)
    obj.location.x = offset_x
    col.objects.link(obj)
    obj.show_in_front = True
    bpy.context.view_layer.objects.active = obj
    obj.select_set(True)

    # custom properties read back by tools / visible in Unity via FBX user props
    obj["ascend_rig"] = rig["key"]
    obj["ascend_ref_size"] = rig["refSize"]
    obj["ascend_build_size"] = size
    obj["ascend_avatar"] = rig["unityAvatar"]

    bpy.ops.object.mode_set(mode="EDIT")
    eb = arm.edit_bones
    by_name = {}
    for b in rig["bones"]:
        bone = eb.new(b["name"])
        head = Vector(b["head"]) * size
        tail = Vector(b["tail"]) * size
        if (tail - head).length < 1e-4:
            tail = head + Vector((0, 0, 0.01 * size))
        bone.head, bone.tail = head, tail
        bone.roll = 0.0
        bone.use_deform = bool(b.get("deform", True))
        by_name[b["name"]] = bone
    for b in rig["bones"]:
        if b.get("parent"):
            child, parent = by_name[b["name"]], by_name[b["parent"]]
            child.parent = parent
            child.use_connect = (child.head - parent.tail).length < 1e-4 * max(size, 1)

    # IK control bones (non-deform), one per two-bone/three-bone limb chain
    ik_targets = {}
    for chain in rig.get("ikChains", []):
        if chain.get("type") in ("spline_follow_head", "sine_wave", "fabrik_reach", "aim") or chain.get("procedural"):
            continue  # solved procedurally in Unity (see monster_motion_bible.md §6)
        tip = by_name.get(chain["tip"])
        if not tip:
            continue
        ctrl = eb.new(f"ik_{chain['name']}")
        ctrl.head = tip.tail.copy()
        ctrl.tail = tip.tail + Vector((0, 0.1 * size, 0))
        ctrl.parent = by_name.get("root")
        ctrl.use_deform = False
        ik_targets[chain["name"]] = ctrl.name
        if chain.get("pole"):
            pole = eb.new(f"pole_{chain['name']}")
            mid = tip.parent.head if tip.parent else tip.head
            push = Vector((0, -0.5 * size, 0)) if "forward" in chain["pole"] else Vector((0, 0.5 * size, 0))
            pole.head = mid + push
            pole.tail = pole.head + Vector((0, 0, 0.05 * size))
            pole.parent = by_name.get("root")
            pole.use_deform = False
            ik_targets[chain["name"] + "__pole"] = pole.name
    bpy.ops.object.mode_set(mode="POSE")

    for chain in rig.get("ikChains", []):
        tgt = ik_targets.get(chain["name"])
        if not tgt:
            continue
        pb = obj.pose.bones.get(chain["tip"])
        c = pb.constraints.new("IK")
        c.target = obj
        c.subtarget = tgt
        c.chain_count = int(chain.get("chainLength", 2))
        pole = ik_targets.get(chain["name"] + "__pole")
        if pole:
            c.pole_target = obj
            c.pole_subtarget = pole
            c.pole_angle = math.radians(-90)

    spring_roots = {s["root"]: s for s in rig.get("springChains", [])}
    for b in rig["bones"]:
        pb = obj.pose.bones[b["name"]]
        if b.get("spring") or b["name"] in spring_roots:
            pb["ascend_spring"] = 1
    for s in rig.get("springChains", []):
        pb = obj.pose.bones.get(s["root"])
        if pb:
            pb["spring_stiffness"] = s["stiffness"]
            pb["spring_damping"] = s["damping"]
            pb["spring_gravity"] = s["gravity"]
            pb["spring_length"] = s["length"]
    bpy.ops.object.mode_set(mode="OBJECT")

    # bone collections (Blender 4.0+): Deform / Controls / Springs / Sockets
    if hasattr(arm, "collections"):
        cols = {n: (arm.collections.get(n) or arm.collections.new(n)) for n in ("Deform", "Controls", "Springs", "Sockets")}
        for bone in arm.bones:
            if bone.name.startswith(("ik_", "pole_")):
                cols["Controls"].assign(bone)
            elif not bone.use_deform:
                cols["Sockets"].assign(bone)
            elif bone.get("ascend_spring") or obj.pose.bones[bone.name].get("ascend_spring"):
                cols["Springs"].assign(bone)
            else:
                cols["Deform"].assign(bone)
    return obj, col


def add_proxy(obj, col, hb, size, rig_key):
    """Graybox mesh for one hurtbox, 100% weighted to its bone."""
    bone = obj.data.bones.get(hb["bone"])
    if not bone:
        return None
    head = obj.matrix_world @ bone.head_local
    tail = obj.matrix_world @ bone.tail_local
    mid = (head + tail) / 2
    r = max(0.01, hb.get("radius", 0.05) * size)
    shape = hb.get("shape", "sphere")
    if shape == "capsule":
        h = max(r * 2, hb.get("height", 0.2) * size)
        bpy.ops.mesh.primitive_cylinder_add(vertices=12, radius=r, depth=h, location=mid)
        m = bpy.context.active_object
        direction = (tail - head)
        if direction.length > 1e-5:
            m.rotation_mode = "QUATERNION"
            m.rotation_quaternion = Vector((0, 0, 1)).rotation_difference(direction.normalized())
    elif shape == "box":
        bpy.ops.mesh.primitive_cube_add(size=1, location=mid)
        m = bpy.context.active_object
        sx, sy, sz = (v * size for v in hb.get("size", [0.2, 0.2, 0.2]))
        m.scale = (sx, sy, sz)
    else:
        center = Vector(hb.get("center", [0, 0, 0])) * size
        bpy.ops.mesh.primitive_uv_sphere_add(segments=16, ring_count=8, radius=r, location=head + center)
        m = bpy.context.active_object
    m.name = f"proxy_{rig_key}_{hb['bone']}"
    for c in list(m.users_collection):
        c.objects.unlink(m)
    col.objects.link(m)
    bpy.ops.object.select_all(action="DESELECT")
    m.select_set(True)
    bpy.context.view_layer.objects.active = m
    bpy.ops.object.transform_apply(location=True, rotation=True, scale=True)  # vertices in world space ...
    m.data.transform(obj.matrix_world.inverted())  # ... then in the armature's space
    vg = m.vertex_groups.new(name=hb["bone"])
    vg.add([v.index for v in m.data.vertices], 1.0, "REPLACE")
    mod = m.modifiers.new("Armature", "ARMATURE")
    mod.object = obj
    m.parent = obj
    m.matrix_parent_inverse.identity()
    m.matrix_basis.identity()  # same transform as the armature: an unambiguous bind pose for Unity
    return m


def _select_only(objs, active):
    bpy.ops.object.select_all(action="DESELECT")
    for o in objs:
        o.select_set(True)
    bpy.context.view_layer.objects.active = active


def _apply_rotation(ob):
    _select_only([ob], ob)
    bpy.ops.object.transform_apply(location=False, rotation=True, scale=False)


def _axis_fix(ob):
    """Axis fix of "Blender To Unity FBX Exporter" (Angel 'Edy' Garcia, MIT licence): rotate the object's data -90 deg
    on X, give the object +90 deg on X (the look is unchanged), then do the same for its children."""
    if ob.parent:  # work with the real local transform
        mw = ob.matrix_world.copy()
        ob.matrix_parent_inverse.identity()
        ob.matrix_basis = ob.parent.matrix_world.inverted() @ mw
    orig = ob.matrix_local.copy()
    ob.matrix_local = Matrix.Rotation(math.radians(-90.0), 4, "X")
    _apply_rotation(ob)
    ob.matrix_local = orig @ Matrix.Rotation(math.radians(90.0), 4, "X")
    for c in ob.children:
        _axis_fix(c)


def _tree(ob):
    out = [ob]
    for c in ob.children:
        out += _tree(c)
    return out


def export_fbx(obj, col, path):
    """Export the rig and its proxies. The scene is left exactly as it was (the axis fix is undone after export),
    so exporting twice gives the same file."""
    ensure_object_mode()
    os.makedirs(os.path.dirname(os.path.abspath(path)), exist_ok=True)
    roots = [o for o in col.objects if o.parent is None or o.parent.name not in col.objects]
    objs = [o for r in roots for o in _tree(r)]
    saved = {o.name: (o.matrix_parent_inverse.copy(), o.matrix_basis.copy()) for o in objs}
    for o in objs:
        if o.type == "MESH" and o.data.users > 1:
            o.data = o.data.copy()  # transform_apply refuses shared mesh data
    try:
        for r in roots:
            _axis_fix(r)
        bpy.context.view_layer.update()
        _select_only(list(col.objects), obj)
        bpy.ops.export_scene.fbx(
            filepath=path,
            use_selection=True,
            object_types={"ARMATURE", "MESH"},
            apply_unit_scale=True,
            apply_scale_options="FBX_SCALE_UNITS",
            axis_forward="-Z",
            axis_up="Y",
            bake_space_transform=False,  # "Apply Transform": experimental, broken with armatures/animations
            use_armature_deform_only=False,  # keep root (root motion), weapon/eye sockets (hitbox & look-at bones)
            add_leaf_bones=False,
            primary_bone_axis="Y",
            secondary_bone_axis="X",
            bake_anim=True,
            bake_anim_use_all_actions=True,
            bake_anim_force_startend_keying=True,
            mesh_smooth_type="FACE",
            use_custom_props=True,
        )
    finally:
        for o in objs:  # undo the data rotation of every object ...
            o.matrix_parent_inverse.identity()
            o.matrix_basis = Matrix.Rotation(math.radians(90.0), 4, "X")
            _apply_rotation(o)
        for o in objs:  # ... then put every transform back as it was
            o.matrix_parent_inverse, o.matrix_basis = saved[o.name]
        bpy.context.view_layer.update()
        _select_only(list(col.objects), obj)
    print(f"[ascend] exported {path}")


def export_at_origin(obj, col, path):
    """Export with the rig at the world origin (rigs built with --all are spaced along X)."""
    saved = obj.location.copy()
    obj.location = (0.0, 0.0, 0.0)
    bpy.context.view_layer.update()
    try:
        export_fbx(obj, col, path)
    finally:
        obj.location = saved
        bpy.context.view_layer.update()


def main():
    opts = parse_args()
    with open(find_rigs_json(opts["rigs"]), encoding="utf-8") as f:
        data = json.load(f)
    rigs = {r["key"]: r for r in data["rigs"]}
    keys = list(rigs) if opts["all"] else [opts["rig"]]
    if not keys or keys == [None]:
        raise SystemExit("Pass --rig KEY or --all. Keys: " + ", ".join(rigs))
    bpy.context.scene.unit_settings.system = "METRIC"
    bpy.context.scene.unit_settings.scale_length = 1.0
    bpy.context.scene.render.fps = data.get("fps", 30)
    x = 0.0
    for key in keys:
        if key not in rigs:
            raise SystemExit(f"Unknown rig {key}. Keys: " + ", ".join(rigs))
        rig = rigs[key]
        size = opts["size"] or rig["refSize"]
        obj, col = build_armature(rig, size, offset_x=x)
        if opts["proxies"]:
            for hb in rig.get("hurtboxes", []):
                add_proxy(obj, col, hb, size, key)
        print(f"[ascend] built rig_{key}: {len(rig['bones'])} bones at {size} m")
        if opts["export"] and not opts["all"]:
            export_at_origin(obj, col, opts["export"])
        if opts["export_dir"]:
            export_at_origin(obj, col, os.path.join(opts["export_dir"], f"rig_{key}.fbx"))
        x += size * 2.5


if __name__ == "__main__":
    main()
