"""The humanoid armature (Unity HumanBodyBones names), skinning setup and poses. Bone positions come from layout.joints()."""
import math

import bpy
from mathutils import Matrix, Vector

from . import skeleton as SK


def build_armature(L, name, collection=None):
    J = L.joints()
    arm = bpy.data.armatures.new(name)
    arm.display_type = "OCTAHEDRAL"
    obj = bpy.data.objects.new(name, arm)
    (collection or bpy.context.scene.collection).objects.link(obj)
    obj.show_in_front = True
    bpy.context.view_layer.objects.active = obj
    obj.select_set(True)
    obj["ascend_rig"] = "human_v1"
    obj["ascend_height_m"] = L.H
    bpy.ops.object.mode_set(mode="EDIT")
    eb = arm.edit_bones
    for n, parent in SK.ALL:
        h, t = J[n]
        b = eb.new(n)
        b.head, b.tail = Vector(h), Vector(t)
        if (b.tail - b.head).length < 1e-3:
            b.tail = b.head + Vector((0, 0, 0.01))
        b.roll = 0.0
        if parent:
            b.parent = eb[parent]
    bpy.ops.object.mode_set(mode="OBJECT")
    if hasattr(arm, "collections"):
        hum = arm.collections.new("Humanoid")
        ext = arm.collections.new("Extras")
        for b in arm.bones:
            (ext if b.name in SK.EXTRA_NAMES else hum).assign(b)
    return obj


def attach(arm_obj, mesh_obj):
    mesh_obj.parent = arm_obj
    mesh_obj.matrix_parent_inverse.identity()
    md = mesh_obj.modifiers.get("Armature") or mesh_obj.modifiers.new("Armature", "ARMATURE")
    md.object = arm_obj


def _rot(arm_obj, bone, axis, deg):
    pb = arm_obj.pose.bones[bone]
    M = pb.matrix.copy()
    head = M.translation.copy()
    R = Matrix.Translation(head) @ Matrix.Rotation(math.radians(deg), 4, axis) @ Matrix.Translation(-head)
    pb.matrix = R @ M
    bpy.context.view_layer.update()


def pose_rest(arm_obj):
    for pb in arm_obj.pose.bones:
        pb.location = (0, 0, 0)
        pb.rotation_mode = "QUATERNION"
        pb.rotation_quaternion = (1, 0, 0, 0)
        pb.scale = (1, 1, 1)
    bpy.context.view_layer.update()


# Relaxed stance used for turnarounds: arms down and a little forward, one knee soft, head turned slightly.
TEST_POSE = [
    ("LeftUpperArm", "Y", 62), ("RightUpperArm", "Y", -62),
    ("LeftLowerArm", "Z", -18), ("RightLowerArm", "Z", 18),
    ("LeftUpperLeg", "X", -12), ("LeftLowerLeg", "X", 16), ("RightUpperLeg", "X", 4),
    ("Spine", "Z", -3), ("Head", "Z", 8),
]


def pose_test(arm_obj, pose=TEST_POSE):
    pose_rest(arm_obj)
    for bone, axis, deg in pose:
        _rot(arm_obj, bone, axis, deg)
    # relax the fingers a little so the hands read as hands, not as planks
    for side in ("Left", "Right"):
        for f in ("Index", "Middle", "Ring", "Little"):
            for seg, d in (("Proximal", 14), ("Intermediate", 22), ("Distal", 12)):
                _rot(arm_obj, side + f + seg, "Z", (-d if side == "Left" else d))
