"""
Builds the combat clip sets (one per weapon family) on the human base rig and exports them for Unity.

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_combat_clips.py
    ... -- --families blade_1h,bow --out <dir> --no-export --no-manifest --previews <dir>

Attack clip lengths and animation events come from Data/Combat/combat_tuning.json `attackTiming` (startup + active + recovery per
hit weight); the manifest records the windows and a hash of that block so `npm run build` notices when the tuning changes
and the clips have to be rebuilt. Output (gitignored): Art/Blender/AnimationLibrary/Combat/<family>.fbx (armature only, one
take per clip). Committed: Data/Characters/combat_clips.json.
"""
import argparse
import hashlib
import json
import os
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, HERE)
ROOT = os.path.dirname(os.path.dirname(HERE))
if os.environ.get("ASCEND_CHARACTERS_DIR"):
    sys.path.insert(0, os.environ["ASCEND_CHARACTERS_DIR"])

import bpy  # noqa: E402

try:
    from ascend_characters import generate  # noqa: E402
except ImportError as e:      # pragma: no cover
    sys.stderr.write("ascend_characters not found (%s); merge claude/humans-base or set ASCEND_CHARACTERS_DIR\n" % e)
    raise SystemExit(2)

from ascend_animation import analysis as AN  # noqa: E402
from ascend_animation import combat as CB  # noqa: E402
from ascend_animation import pose_params as PP  # noqa: E402
from ascend_animation import posing as PO  # noqa: E402
import build_locomotion_clips as BL  # noqa: E402  (bake helper)


def parse():
    a = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    p = argparse.ArgumentParser()
    p.add_argument("--body", default="human_male_base")
    p.add_argument("--also", default="human_female_base")
    p.add_argument("--families", default="")
    p.add_argument("--out", default=os.path.join(ROOT, "Art", "Blender", "AnimationLibrary", "Combat"))
    p.add_argument("--manifest", default=os.path.join(ROOT, "Data", "Characters", "combat_clips.json"))
    p.add_argument("--tuning", default=os.path.join(ROOT, "Data", "Combat", "combat_tuning.json"))
    p.add_argument("--previews", default="")
    p.add_argument("--no-export", action="store_true")
    p.add_argument("--no-manifest", action="store_true")
    return p.parse_args(a)


def tuning_hash(tuning):
    return hashlib.sha1(json.dumps(tuning["attackTiming"], sort_keys=True, ensure_ascii=False).encode()).hexdigest()[:12]


def export_family(arm, family, out_dir):
    import build_rig
    os.makedirs(out_dir, exist_ok=True)
    col = bpy.data.collections.new("AnimExport_" + family)
    bpy.context.scene.collection.children.link(col)
    col.objects.link(arm)
    path = os.path.join(out_dir, family + ".fbx")
    build_rig.export_fbx(arm, col, path)
    bpy.context.scene.collection.children.unlink(col)
    bpy.data.collections.remove(col)
    return path


def clip_row(c, metrics, family, action_name):
    row = dict(name=c.name, action=action_name, motion=c.motion, weight=c.weight, loop=c.loop, fps=c.fps, frames=metrics["frames"],
               seconds=metrics["seconds"], notes=c.notes, hash=metrics["hash"], metrics={k: v for k, v in metrics.items() if k not in ("frames", "fps", "seconds", "hash")})
    if hasattr(c, "events"):
        row["windows"] = dict(startupSec=c.startup, activeSec=c.active, recoverySec=c.recovery)
        row["events"] = c.events
    return row


def main():
    a = parse()
    with open(a.tuning, encoding="utf8") as f:
        tuning = json.load(f)
    win = CB.windows_from_tuning(tuning)
    fps = CB.pick_fps(win)
    if fps is None:
        raise SystemExit("no fps up to 240 makes every attack window a whole number of frames: %s" % win)
    want = [x for x in a.families.split(",") if x]
    fams = [f for f in CB.FAMILIES if not want or f in want]
    if want and len(fams) != len(want):
        raise SystemExit("unknown family; have " + ", ".join(CB.FAMILIES))
    ch = generate.character(a.body)
    arm = ch["armature"]
    rig = PO.Rig(arm)
    legs = BL.legs_of(rig)
    other = None
    if a.also and a.also != a.body:
        ch2 = generate.character(a.also)
        rig2 = PO.Rig(ch2["armature"])
        other = (rig2, BL.legs_of(rig2))
    rows = []
    for fam in fams:
        clips = CB.build_family(rig, legs, fam, win, fps)
        acts, crow = [], []
        for c in clips:
            name = "Cmb_%s_%s" % (fam, c.name)
            c0 = c.name
            c.name = name                                  # the action (take) is named family + clip; the manifest keeps both
            act = BL.bake(rig, legs, c)
            m = AN.analyze(rig, legs, c)
            m["bakeErrorM"] = round(AN.verify_bake(rig, legs, c, act), 5)
            if m["bakeErrorM"] > 1e-3:
                raise SystemExit("%s: baked action does not reproduce the pose (%.4f m)" % (name, m["bakeErrorM"]))
            if hasattr(c, "events"):
                m.update(AN.combat_metrics(rig, legs, c))
            r = clip_row(c, m, fam, name)
            r["name"] = c0
            crow.append(r)
            acts.append(act)
            if a.previews and (c0 in ("Hit1", "Launcher", "Slam", "HeavyRelease")):
                from ascend_animation import preview
                os.makedirs(a.previews, exist_ok=True)
                preview.sheet(rig, legs, c, os.path.join(a.previews, "%s_%s.png" % (fam, c0)), count=8, H=ch["spec"]["heightM"])
            arm.animation_data.action = None
        # cross-check on the other body: same clips must pose any human without going under the floor
        cross = []
        if other:
            for c2 in CB.build_family(other[0], other[1], fam, win, fps):
                m2 = AN.analyze(other[0], other[1], c2)
                cross.append(dict(name=c2.name, minBoneZ=m2["minBoneZ"], hash=m2["hash"]))
        entry = dict(id=fam, weapons=CB.FAMILIES[fam]["weapons"], twoHanded=bool(CB.FAMILIES[fam].get("two_hand")), dualWield=bool(CB.FAMILIES[fam].get("dual")),
                     hitCount=len(CB.FAMILIES[fam]["hits"]), clips=crow, crossCheck=cross)
        if not a.no_export:
            entry["file"] = os.path.relpath(export_family(arm, fam, a.out), ROOT).replace("\\", "/")
        for act in acts:
            bpy.data.actions.remove(act)
        rows.append(entry)
        print("family %-13s %2d clips  windows ok  worst contact reach %.2f m  min telegraph %.2f m" % (
            fam, len(crow), min(r["metrics"].get("contactReachM", 9) for r in crow if "events" in r),
            min(r["metrics"].get("telegraphM", 9) for r in crow if "events" in r)))
    if not a.no_manifest and not want:
        wm = {w: f for f, d in CB.FAMILIES.items() for w in d["weapons"]}
        doc = dict(schema="combat_clips/1", rigContract="human_v1", source="Tools/blender/build_combat_clips.py", authoredOn=a.body,
                   tuning=dict(file="Data/Combat/combat_tuning.json", block="attackTiming", hash=tuning_hash(tuning),
                               windows={k: dict(startupSec=v[0], activeSec=v[1], recoverySec=v[2]) for k, v in win.items()}),
                   fps=fps, weaponToFamily=wm,
                   hitRule="A chain's hit i (0-based) plays <family>_Hit<i+1>; when a chain is longer than the family's hitCount the extra hits repeat from Hit2 (hit i -> Hit(2 + (i-1) % (hitCount-1))) so a 17-hit flurry loops its middle hits; hits are weighted light, light, ..., medium and the windows come from the weight (Special: HeavyRelease/Riposte/Slam use heavy, Launcher launch, SkillCast medium)",
                   families=rows)
        os.makedirs(os.path.dirname(a.manifest), exist_ok=True)
        with open(a.manifest, "w", encoding="utf8") as f:
            json.dump(doc, f, indent=1)
            f.write("\n")
        print("manifest:", a.manifest)


if __name__ == "__main__":
    main()
