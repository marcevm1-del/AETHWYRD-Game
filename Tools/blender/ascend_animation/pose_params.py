"""
One flat parameter dict describes a whole-body pose of the human_v1 rig; `build_pose` turns it into bone deltas.
Every clip (gaits sampled per frame, key-posed clips interpolated) produces these dicts, so there is one place that
knows how the skeleton moves.

Parameters (degrees and metres; missing keys take DEFAULTS):
  pelvis   hz (m, up from rest), hf (m, forward), hp (pitch, + leans forward), hr (roll, + tips top left), hyaw (+ turns left)
  spine    sl (total forward lean over Spine/Chest/UpperChest), sr (total roll), sy (total yaw)
  head     hl (extra head lean added to the self-levelling), hhy (head yaw), hhr (head roll)
  arms     l_lower/r_lower (deg down from the T-pose), l_fwd/r_fwd (forward swing), l_twist/r_twist, l_el/r_el (elbow flex),
           l_wr/r_wr (wrist flex), l_curl/r_curl (finger curl), l_sh/r_sh (shoulder shrug, deg up)
  legs IK  l_du/r_du (ankle forward of its rest position, m), l_z/r_z (ankle height above ground, m; default = rest),
           l_dx/r_dx unused, l_pitch/r_pitch (foot pitch from flat, + toe up), l_toe/r_toe (toe bend relative to the foot, + up)
  legs FK  fk=1 switches on l_th/r_th (thigh flexion forward), l_kn/r_kn (knee flexion), l_an/r_an (ankle, + toe up)
"""
import math

from mathutils import Quaternion, Vector

from . import posing as P

DEFAULTS = dict(
    hz=0.0, hf=0.0, hp=0.0, hr=0.0, hyaw=0.0,
    sl=0.0, sr=0.0, sy=0.0, hl=0.0, hhy=0.0, hhr=0.0, level=0.85,
    l_lower=78.0, r_lower=78.0, l_fwd=0.0, r_fwd=0.0, l_twist=0.0, r_twist=0.0, l_el=10.0, r_el=10.0,
    l_wr=0.0, r_wr=0.0, l_curl=22.0, r_curl=22.0, l_sh=0.0, r_sh=0.0,
    l_du=0.0, r_du=0.0, l_z=None, r_z=None, l_pitch=0.0, r_pitch=0.0, l_toe=0.0, r_toe=0.0,
    fk=0.0, l_th=0.0, r_th=0.0, l_kn=0.0, r_kn=0.0, l_an=0.0, r_an=0.0,
)

FINGER_CURL = {"Thumb": (0.35, 0.45, 0.45), "Index": (0.55, 0.9, 0.55), "Middle": (0.6, 1.0, 0.6),
               "Ring": (0.65, 1.0, 0.6), "Little": (0.7, 1.05, 0.65)}


class LegGeometry:
    """Rest-pose leg lengths and angles in the sagittal plane (u = forward = -Y, v = up = Z)."""

    def __init__(self, rig, side):
        self.side = side
        hip, knee, ank = rig.head(side + "UpperLeg"), rig.head(side + "LowerLeg"), rig.head(side + "Foot")
        ball, toe = rig.tail(side + "Foot"), rig.tail(side + "Toes")
        self.hip, self.ank0, self.ball0 = hip.copy(), ank.copy(), ball.copy()
        self.L1 = math.hypot(knee.y - hip.y, knee.z - hip.z)
        self.L2 = math.hypot(ank.y - knee.y, ank.z - knee.z)
        self.rho1 = rig.sagittal_angle(side + "UpperLeg")
        self.rho2 = rig.sagittal_angle(side + "LowerLeg")
        self.rho3 = rig.sagittal_angle(side + "Foot")
        self.rho4 = rig.sagittal_angle(side + "Toes")
        self.az0 = ank.z
        self.reach = self.L1 + self.L2
        # foot vectors in (u, v): ankle -> ball
        self.foot_u = -(ball.y - ank.y)
        self.foot_v = ball.z - ank.z
        self.toe_len = (toe - ball).length


def ik_sagittal(g, hu, hv, tu, tv):
    """Two-bone IK in the sagittal plane. (hu, hv) hip joint, (tu, tv) ankle target. Returns the world angles of the thigh and
    shin (0 = hanging straight down, + forward, degrees) and the reach actually used (0..1 of full extension)."""
    du, dv = tu - hu, tv - hv
    D = math.hypot(du, dv)
    Dmax = (g.L1 + g.L2) * 0.9995
    Dmin = abs(g.L1 - g.L2) + 1e-3
    Dc = min(max(D, Dmin), Dmax)
    psi = math.atan2(du, -dv)
    c1 = (g.L1 ** 2 + Dc ** 2 - g.L2 ** 2) / (2 * g.L1 * Dc)
    c2 = (g.L2 ** 2 + Dc ** 2 - g.L1 ** 2) / (2 * g.L2 * Dc)
    d1 = math.acos(max(-1.0, min(1.0, c1)))
    d2 = math.acos(max(-1.0, min(1.0, c2)))
    return math.degrees(psi + d1), math.degrees(psi - d2), Dc / (g.L1 + g.L2)


def build_pose(rig, legs, p):
    """p: parameter dict (see module docstring). Returns (pose {bone: Quaternion}, hips_offset (x, y, z), info)."""
    q = dict(DEFAULTS)
    q.update(p)
    pose = {}
    info = {}
    # ---- pelvis ----
    D = P.yaw(q["hyaw"]) @ P.roll(q["hr"]) @ P.lean(q["hp"])
    pose["Hips"] = D
    hips_off = Vector((0.0, -q["hf"], q["hz"]))
    # ---- spine and head ----
    pose["Spine"] = P.lean(q["sl"] * 0.30) @ P.roll(q["sr"] * 0.30) @ P.yaw(q["sy"] * 0.30)
    pose["Chest"] = P.lean(q["sl"] * 0.35) @ P.roll(q["sr"] * 0.35) @ P.yaw(q["sy"] * 0.35)
    pose["UpperChest"] = P.lean(q["sl"] * 0.35) @ P.roll(q["sr"] * 0.35) @ P.yaw(q["sy"] * 0.35)
    comp = -(q["hp"] + q["sl"]) * q["level"] + q["hl"]
    pose["Neck"] = P.lean(comp * 0.4) @ P.roll(q["hhr"] * 0.4 - (q["hr"] + q["sr"]) * 0.4) @ P.yaw(q["hhy"] * 0.4 - (q["hyaw"] + q["sy"]) * 0.4)
    pose["Head"] = P.lean(comp * 0.6) @ P.roll(q["hhr"] * 0.6 - (q["hr"] + q["sr"]) * 0.4) @ P.yaw(q["hhy"] * 0.6 - (q["hyaw"] + q["sy"]) * 0.4)
    # ---- arms ----
    for sd, sx in (("Left", 1.0), ("Right", -1.0)):
        k = "l_" if sd == "Left" else "r_"
        pose[sd + "Shoulder"] = P._q((0, 1, 0), -sx * q[k + "sh"])
        pose[sd + "UpperArm"] = P.arm_q(sx, q[k + "lower"], q[k + "fwd"], q[k + "twist"])
        pose[sd + "LowerArm"] = P.elbow_q(sx, q[k + "el"])
        pose[sd + "Hand"] = P._q((0, 0, 1), -sx * q[k + "wr"])
        for f, (a, b, c) in FINGER_CURL.items():
            cu = q[k + "curl"]
            pose[sd + f + "Proximal"] = P.finger_q(sx, cu * a)
            pose[sd + f + "Intermediate"] = P.finger_q(sx, cu * b)
            pose[sd + f + "Distal"] = P.finger_q(sx, cu * c)
    # ---- legs ----
    for sd in ("Left", "Right"):
        k = "l_" if sd == "Left" else "r_"
        g = legs[sd]
        if q["fk"]:
            a1, kn, an = q[k + "th"], q[k + "kn"], q[k + "an"]
            pose[sd + "UpperLeg"] = P.fwd_down(a1)
            pose[sd + "LowerLeg"] = P.fwd_down(-kn)
            pose[sd + "Foot"] = P.fwd_down(an)
            pose[sd + "Toes"] = P.fwd_down(q[k + "toe"])
            continue
        # hip joint in world space (the pelvis rotates about the Hips head)
        hh = rig.head("Hips")
        J = hh + hips_off + D @ (g.hip - hh)
        tz = g.az0 if q[k + "z"] is None else q[k + "z"]
        tu = -(g.ank0.y) + q[k + "du"]
        t1, t2, used = ik_sagittal(g, -J.y, J.z, tu, tz)
        info[sd + "_reach"] = used
        P1 = P.fwd_down(t1 - g.rho1)
        P2 = P.fwd_down(t2 - g.rho2)
        P3 = P.fwd_down(q[k + "pitch"])
        # toe bend: the toes stay as the foot dictates unless l_toe adds a bend (planted toes while the heel lifts)
        P4 = P.fwd_down(q[k + "pitch"] + q[k + "toe"])
        pose[sd + "UpperLeg"] = D.inverted() @ P1
        pose[sd + "LowerLeg"] = P1.inverted() @ P2
        pose[sd + "Foot"] = P2.inverted() @ P3
        pose[sd + "Toes"] = P3.inverted() @ P4
    return pose, hips_off, info
