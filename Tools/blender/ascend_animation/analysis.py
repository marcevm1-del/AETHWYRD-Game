"""Measurements on a posed clip (run inside Blender): loop closure, ground contact, foot slide, penetration, reach, hash."""
import hashlib
import math

import bpy
from mathutils import Vector

from . import pose_params as PP


def pose_frame(rig, legs, params):
    pose, off, info = PP.build_pose(rig, legs, params)
    rig.apply(pose, off)
    return info


def _heel_world(rig, legs, side):
    g = legs[side]
    pb = rig.obj.pose.bones[side + "Foot"]
    rest = Vector((0.0, 0.045, -g.az0))                  # ankle -> heel point in rest armature axes
    local = rig.bones[side + "Foot"]["Rinv"] @ rest
    return pb.head + pb.matrix.to_3x3() @ local


def foot_points(rig, legs, side):
    pbs = rig.obj.pose.bones
    return dict(heel=_heel_world(rig, legs, side), ball=pbs[side + "Foot"].tail.copy(), toe=pbs[side + "Toes"].tail.copy(),
                ankle=pbs[side + "Foot"].head.copy())


def analyze(rig, legs, clip, speed=None, contact_z=0.012):
    """Pose every frame of `clip` and measure. Returns a metrics dict (JSON-safe)."""
    ad = rig.obj.animation_data
    saved_action = ad.action if ad else None
    if ad:
        ad.action = None                 # measure the pose we set, not whatever the baked action evaluates to
    try:
        return _analyze(rig, legs, clip, speed, contact_z)
    finally:
        if ad:
            ad.action = saved_action


def verify_bake(rig, legs, clip, action):
    """Max distance (m) between the pose built from the clip's parameters and the pose Blender evaluates from the baked action."""
    ad = rig.obj.animation_data
    ad.action = None
    want = []
    for f in clip.frames():
        pose_frame(rig, legs, f)
        bpy.context.view_layer.update()
        want.append({b.name: b.matrix.translation.copy() for b in rig.obj.pose.bones})
    ad.action = action
    err = 0.0
    sc = bpy.context.scene
    for i, w in enumerate(want):
        sc.frame_set(i)
        for b in rig.obj.pose.bones:
            err = max(err, (b.matrix.translation - w[b.name]).length)
    return err


def _analyze(rig, legs, clip, speed, contact_z):
    frames = clip.frames()
    fps = clip.fps
    n = len(frames)
    low = {"Left": [], "Right": []}
    ys = {"Left": [], "Right": []}
    reach_clamped = 0
    hz = []
    lowest = 9.0
    qh = hashlib.sha1()
    first = None
    for i, f in enumerate(frames):
        info = pose_frame(rig, legs, f)
        bpy.context.view_layer.update()
        reach_clamped += sum(1 for v in info.values() if v >= 0.9995)
        for side in ("Left", "Right"):
            pts = foot_points(rig, legs, side)
            k = min(("heel", "ball", "toe"), key=lambda a: pts[a].z)
            low[side].append(pts[k].z)
            ys[side].append(pts[k].y)
        for b in rig.obj.pose.bones:
            if not b.name.startswith(("Hair", "Cloak")):
                lowest = min(lowest, b.head.z, b.tail.z)
        hz.append(rig.obj.pose.bones["Hips"].head.z)
        loc = rig.obj.pose.bones["Hips"].location
        qh.update(("L%.4f,%.4f,%.4f;" % (loc.x, loc.y, loc.z)).encode())
        for b in rig.obj.pose.bones:
            q = b.rotation_quaternion
            qh.update(("%.4f,%.4f,%.4f,%.4f;" % (q.w, q.x, q.y, q.z)).replace("-0.0000", "0.0000").encode())
        if i == 0:
            first = {b.name: b.matrix.copy() for b in rig.obj.pose.bones}
    if clip.loop:       # the pose one full cycle later (t = 1.0) must equal the first pose: the stored last frame copies frame 0 by construction
        pose_frame(rig, legs, clip.at(1.0))
        bpy.context.view_layer.update()
    last = {b.name: b.matrix.copy() for b in rig.obj.pose.bones}
    # loop closure: frame 0 against the last frame (same pose for a loop)
    loop_err = max((first[k].translation - last[k].translation).length for k in first)
    out = dict(frames=n - 1, fps=fps, seconds=round((n - 1) / fps, 4), loopClosureM=round(loop_err, 5) if clip.loop else None,
               hipsMinZ=round(min(hz), 4), hipsMaxZ=round(max(hz), 4), reachClamped=reach_clamped,
               minFootZ=round(min(min(low["Left"]), min(low["Right"])), 4), minBoneZ=round(lowest, 4), hash=qh.hexdigest()[:12])
    if speed:
        slide = []
        contact = 0
        for side in ("Left", "Right"):
            for i in range(n - 1):
                if low[side][i] < contact_z and low[side][i + 1] < contact_z:
                    contact += 1
                    slide.append(abs((ys[side][i + 1] - ys[side][i]) * fps - speed))
        out["footContactFrames"] = contact
        out["footSlideMaxMps"] = round(max(slide), 3) if slide else None
        out["footSlideMeanMps"] = round(sum(slide) / len(slide), 3) if slide else None
        out["footSlideMeanPct"] = round(100 * sum(slide) / len(slide) / speed, 1) if slide else None
    return out
