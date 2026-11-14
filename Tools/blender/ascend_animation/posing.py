"""
Pose layer for the Ascend human rig (contract `human_v1`: Unity HumanBodyBones names, T-pose rest, facing -Y,
Left = +X, up = +Z; see 13_Production/character_system.md).

A pose is {bone: delta quaternion} where each delta is the rotation of that bone relative to its parent, written in
the armature's rest axes (so "swing the thigh forward" is one rotation about the lateral axis, whatever the roll of the
bone). `Rig.apply` converts the deltas to Blender's per-bone local rotations: L = Rb^-1 d Rb (Rb = rest orientation).
The hips also take a world-axis offset in metres.

Rotation helpers (all in degrees, rest axes):
    fwd_down(a)  bones that hang down (legs, lowered arms): positive swings the bone forward
    lean(a)      bones that point up (spine, neck, head, whole body): positive tips the top forward
    roll(a)      positive tips the top to the character's left (+X)
    yaw(a)       positive turns the character to the left
"""
import math

from mathutils import Matrix, Quaternion, Vector

FORWARD = Vector((0.0, -1.0, 0.0))
UP = Vector((0.0, 0.0, 1.0))


def _q(axis, deg):
    return Quaternion(Vector(axis), math.radians(deg))


def fwd_down(a):
    return _q((1, 0, 0), -a)


def lean(a):
    return _q((1, 0, 0), a)


def roll(a):
    return _q((0, 1, 0), a)       # Ry(+a) takes +Z toward +X: positive tips the top to the character's left


def yaw(a):
    return _q((0, 0, 1), a)


def twist_x(a):
    return _q((1, 0, 0), a)


def arm_q(sx, lower, fwd=0.0, twist=0.0):
    """Upper arm. sx = +1 left / -1 right. `lower` degrees down from the T-pose, then `fwd` forward swing of the hanging
    arm (about the lateral axis), `twist` rolls it about its own axis first."""
    q = _q((0, 1, 0), sx * lower)
    if twist:
        q = q @ _q((1, 0, 0), sx * twist)
    return _q((1, 0, 0), -fwd) @ q


def elbow_q(sx, flex):
    return _q((0, 0, 1), -sx * flex)


def finger_q(sx, curl):
    return _q((0, 1, 0), sx * curl)


class Rig:
    """Wraps an armature object that follows the human_v1 contract."""

    def __init__(self, arm_obj):
        import bpy
        self.obj = arm_obj
        self.bpy = bpy
        self.bones = {}
        for b in arm_obj.data.bones:
            Rb = b.matrix_local.to_3x3()
            self.bones[b.name] = dict(
                Rb=Rb, Rinv=Rb.inverted(), head=Vector(b.head_local), tail=Vector(b.tail_local),
                parent=b.parent.name if b.parent else None)
        for pb in arm_obj.pose.bones:
            pb.rotation_mode = "QUATERNION"
        self.hips_rest = Vector(self.bones["Hips"]["head"])
        self._prev = {}

    # ---- rest geometry helpers --------------------------------------------------------------------------
    def head(self, n):
        return self.bones[n]["head"]

    def tail(self, n):
        return self.bones[n]["tail"]

    def length(self, n):
        return (self.tail(n) - self.head(n)).length

    def sagittal_angle(self, n):
        """Angle of the bone's rest direction in the sagittal plane: 0 = straight down, +90 = forward (degrees)."""
        d = self.tail(n) - self.head(n)
        return math.degrees(math.atan2(-d.y, -d.z))

    # ---- posing ----------------------------------------------------------------------------------------
    def reset(self):
        self._prev = {}
        for pb in self.obj.pose.bones:
            pb.location = (0, 0, 0)
            pb.rotation_quaternion = (1, 0, 0, 0)
            pb.scale = (1, 1, 1)

    def apply(self, pose, hips_offset=(0.0, 0.0, 0.0)):
        """pose: {bone: Quaternion delta}. Bones not listed stay at rest."""
        pbs = self.obj.pose.bones
        for n, pb in pbs.items():
            d = pose.get(n)
            if d is None:
                q = Quaternion((1, 0, 0, 0))
            else:
                m = self.bones[n]["Rinv"] @ d.to_matrix() @ self.bones[n]["Rb"]
                q = m.to_quaternion()
            prev = self._prev.get(n)
            if prev is not None and q.dot(prev) < 0:      # keep the sign continuous so Blender never interpolates the long way
                q.negate()
            self._prev[n] = q.copy()
            pb.rotation_quaternion = q
            pb.location = (0, 0, 0)
        off = Vector(hips_offset)
        pbs["Hips"].location = self.bones["Hips"]["Rinv"] @ off

    def key(self, frame):
        for pb in self.obj.pose.bones:
            pb.keyframe_insert("rotation_quaternion", frame=frame, group=pb.name)
        self.obj.pose.bones["Hips"].keyframe_insert("location", frame=frame, group="Hips")
