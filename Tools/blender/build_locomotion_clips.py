"""
Builds the humanoid locomotion clips (Idle, Walk, Run, Sprint, JumpStart, Fall, Land, LandHard, Dodge) on the human base
rig and exports them for Unity.

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_locomotion_clips.py
    ... -- --body human_male_base --clips Walk,Run --out <dir> --no-export --manifest <json> --previews <dir>

Needs the human generator (Tools/blender/ascend_characters, branch claude/humans-base) and fails loudly without it.
Output (gitignored): Art/Blender/AnimationLibrary/HumanLocomotion/<Clip>.fbx, armature only, Humanoid bone names,
Unity axis fix (build_rig.export_fbx). The manifest Data/Characters/locomotion_clips.json is committed.
"""
import argparse
import json
import os
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, HERE)
ROOT = os.path.dirname(os.path.dirname(HERE))

if os.environ.get("ASCEND_CHARACTERS_DIR"):      # a folder that holds the ascend_characters package (before it is merged here)
    sys.path.insert(0, os.environ["ASCEND_CHARACTERS_DIR"])

import bpy  # noqa: E402

try:
    from ascend_characters import generate  # noqa: E402
except ImportError as e:      # pragma: no cover
    sys.stderr.write("ascend_characters not found (%s). The human base rig lives on branch claude/humans-base; merge it first.\n" % e)
    raise SystemExit(2)

from ascend_animation import analysis as AN  # noqa: E402
from ascend_animation import clips as CL  # noqa: E402
from ascend_animation import pose_params as PP  # noqa: E402
from ascend_animation import posing as PO  # noqa: E402

STATE = {"Idle": "Locomotion tree @ 0", "Walk": "Locomotion tree @ 2.2", "Run": "Locomotion tree @ 6.5", "Sprint": "Locomotion tree @ 9.5",
         "JumpStart": "JumpStart", "Fall": "Fall", "Land": "Land", "LandHard": "(optional second Land state)", "Dodge": "Dodge"}


def args():
    a = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    p = argparse.ArgumentParser()
    p.add_argument("--body", default="human_male_base")
    p.add_argument("--clips", default="")
    p.add_argument("--out", default=os.path.join(ROOT, "Art", "Blender", "AnimationLibrary", "HumanLocomotion"))
    p.add_argument("--manifest", default=os.path.join(ROOT, "Data", "Characters", "locomotion_clips.json"))
    p.add_argument("--previews", default="", help="folder for contact sheets (side view) of each clip")
    p.add_argument("--no-export", action="store_true")
    p.add_argument("--no-manifest", action="store_true")
    p.add_argument("--also", default="human_female_base", help="extra body to analyse (the clips must work on every human)")
    return p.parse_args(a)


def legs_of(rig):
    return {"Left": PP.LegGeometry(rig, "Left"), "Right": PP.LegGeometry(rig, "Right")}


def bake(rig, legs, clip):
    """Key every frame of the clip into a new action on the rig. Returns the action."""
    bpy.context.preferences.edit.keyframe_new_interpolation_type = "LINEAR"
    obj = rig.obj
    if obj.animation_data is None:
        obj.animation_data_create()
    act = bpy.data.actions.new(clip.name)
    act.use_fake_user = True
    obj.animation_data.action = act
    sc = bpy.context.scene
    sc.render.fps, sc.render.fps_base = clip.fps, 1.0
    sc.frame_start, sc.frame_end = 0, clip.n
    rig.reset()
    for i, f in enumerate(clip.frames()):
        AN.pose_frame(rig, legs, f)
        bpy.context.view_layer.update()
        rig.key(i)
    act["ascend_clip"] = clip.name
    return act


def export(arm, clip_name, out_dir, action):
    sys.path.insert(0, HERE)
    import build_rig
    os.makedirs(out_dir, exist_ok=True)
    col = bpy.data.collections.new("AnimExport_" + clip_name)
    bpy.context.scene.collection.children.link(col)
    col.objects.link(arm)
    arm.animation_data.action = action
    path = os.path.join(out_dir, clip_name + ".fbx")
    build_rig.export_fbx(arm, col, path)
    bpy.context.scene.collection.children.unlink(col)
    bpy.data.collections.remove(col)
    return path


def main():
    a = args()
    want = [c for c in a.clips.split(",") if c]
    ch = generate.character(a.body)
    arm = ch["armature"]
    rig = PO.Rig(arm)
    legs = legs_of(rig)
    clips = [c for c in CL.all_clips(rig, legs) if not want or c.name in want]
    if want and len(clips) != len(want):
        raise SystemExit("unknown clip in --clips; have " + ", ".join(c.name for c in CL.all_clips(rig, legs)))
    rows = []
    for c in clips:
        act = bake(rig, legs, c)
        m = AN.analyze(rig, legs, c, speed=getattr(c, "design_speed", None))
        m["bakeErrorM"] = round(AN.verify_bake(rig, legs, c, act), 5)
        if m["bakeErrorM"] > 1e-3:
            raise SystemExit("clip %s: the baked action does not reproduce the pose (error %.4f m)" % (c.name, m["bakeErrorM"]))
        row = dict(name=c.name, state=STATE[c.name], loop=c.loop, fps=c.fps, frames=m["frames"], seconds=m["seconds"], rootMotion=False,
                   designSpeedMps=getattr(c, "design_speed", None), strideM=round(getattr(c, "stride_m", 0.0), 3) or None, notes=c.notes, metrics=m)
        if not a.no_export:
            row["file"] = os.path.relpath(export(arm, c.name, a.out, act), ROOT).replace("\\", "/")
        rows.append(row)
        if a.previews:
            from ascend_animation import preview
            os.makedirs(a.previews, exist_ok=True)
            preview.sheet(rig, legs, c, os.path.join(a.previews, c.name + "_side.png"), count=8, H=ch["spec"]["heightM"])
        print("clip %-9s %3d f @ %d fps  loop=%s  %s" % (c.name, m["frames"], c.fps, c.loop, json.dumps({k: v for k, v in m.items() if k not in ("frames", "fps", "seconds")})))
        arm.animation_data.action = None      # export bakes every action in the file: keep one clip per FBX
        bpy.data.actions.remove(act)
    # the same clips must pose any human cleanly: measure on the other body too
    other = []
    if a.also and a.also != a.body:
        ch2 = generate.character(a.also)
        rig2 = PO.Rig(ch2["armature"])
        legs2 = legs_of(rig2)
        for c in [x for x in CL.all_clips(rig2, legs2) if not want or x.name in want]:
            m = AN.analyze(rig2, legs2, c, speed=getattr(c, "design_speed", None))
            other.append(dict(name=c.name, body=a.also, metrics=m))
            print("also %-9s %s: slideMean %s%%  minFootZ %s  loopClosure %s" % (c.name, a.also, m.get("footSlideMeanPct"), m["minFootZ"], m["loopClosureM"]))
    if not a.no_manifest and not want:
        doc = dict(schema="locomotion_clips/1", rigContract="human_v1", source="Tools/blender/build_locomotion_clips.py", authoredOn=a.body,
                   convention="Humanoid, in place, Blender -Y forward (Unity +Z after the FBX axis fix), feet on y=0, 30 fps (Dodge 50 fps so 0.42 s is exactly 21 frames)",
                   clips=[{k: v for k, v in r.items() if k != "file"} for r in rows],
                   crossCheck=[dict(name=o["name"], body=o["body"], footSlideMeanPct=o["metrics"].get("footSlideMeanPct"), minFootZ=o["metrics"]["minFootZ"],
                                    hash=o["metrics"]["hash"]) for o in other])
        os.makedirs(os.path.dirname(a.manifest), exist_ok=True)
        with open(a.manifest, "w", encoding="utf8") as f:
            json.dump(doc, f, indent=1)
            f.write("\n")
        print("manifest:", a.manifest)


if __name__ == "__main__":
    main()
