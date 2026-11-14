"""
Builds the rider pose clips for the ground mounts (Data/Companions/mounts.json families) on the human base rig.

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_rider_clips.py [-- --families horse,bear --no-export --no-manifest --previews <dir>]

The families, their species and the species rigs are read from Data/ (never listed here): a family without a rider style, or a
species whose rig has no saddle anchor, stops the build. Mounted attack clips use the attack windows of Data/Combat/combat_tuning.json
and the hit cap of mounts.json `mountedCombat.maxChainHits`. Output (gitignored): Art/Blender/AnimationLibrary/Riders/<family>.fbx;
committed: Data/Characters/rider_clips.json.
"""
import argparse
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
from ascend_animation import rider as RD  # noqa: E402
from ascend_animation import posing as PO  # noqa: E402
import build_combat_clips as BC  # noqa: E402
import build_locomotion_clips as BL  # noqa: E402

GROUND_CLIPS = ("MountUp", "Dismount", "Stagger")


def load(rel):
    with open(os.path.join(ROOT, rel), encoding="utf8") as f:
        return json.load(f)


def parse():
    a = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    p = argparse.ArgumentParser()
    p.add_argument("--body", default="human_male_base")
    p.add_argument("--also", default="human_female_base")
    p.add_argument("--families", default="")
    p.add_argument("--out", default=os.path.join(ROOT, "Art", "Blender", "AnimationLibrary", "Riders"))
    p.add_argument("--manifest", default=os.path.join(ROOT, "Data", "Characters", "rider_clips.json"))
    p.add_argument("--previews", default="")
    p.add_argument("--no-export", action="store_true")
    p.add_argument("--no-manifest", action="store_true")
    return p.parse_args(a)


def species_rigs(mounts, species):
    """{family: {species id: rig key}} from mounts.json and species.json."""
    rid = {s["id"]: s.get("rigId") for s in species}
    out = {}
    for fam, d in mounts["families"].items():
        out[fam] = {sp: (rid.get(sp) or "").replace("rig_", "") for sp in d["species"]}
    return out


def main():
    a = parse()
    mounts = load("Data/Companions/mounts.json")
    tuning = load("Data/Combat/combat_tuning.json")
    sp = load("Data/Monsters/species.json")
    sp = sp if isinstance(sp, list) else sp.get("species", sp)
    fam_species = species_rigs(mounts, sp)
    missing = [f for f in mounts["families"] if f not in RD.STYLE]
    if missing:
        raise SystemExit("mount families without a rider style in ascend_animation/rider.py: %s" % missing)
    for f, d in fam_species.items():
        for s_id, rg in d.items():
            if rg not in RD.RIGS_ANCHOR:
                raise SystemExit("species %s (family %s) uses rig %r, which has no saddle anchor in rider.RIGS_ANCHOR" % (s_id, f, rg))
    if mounts["mountedCombat"]["maxChainHits"] != 3:
        raise SystemExit("mountedCombat.maxChainHits is %s but the rider set authors 3 hits" % mounts["mountedCombat"]["maxChainHits"])
    win = CB.windows_from_tuning(tuning)
    fps = CB.pick_fps(win)
    if fps is None:
        raise SystemExit("no fps makes every attack window whole frames")
    want = [x for x in a.families.split(",") if x]
    fams = [f for f in mounts["families"] if not want or f in want]
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
        clips = RD.build_family(rig, legs, fam, win, fps)
        idle0 = AN.snapshot(rig, legs, clips[0].frames()[0])
        acts, crow = [], []
        for c in clips:
            short = c.name
            c.name = "Rid_%s_%s" % (fam, short)
            act = BL.bake(rig, legs, c)
            m = AN.analyze(rig, legs, c)
            m["bakeErrorM"] = round(AN.verify_bake(rig, legs, c, act), 5)
            if m["bakeErrorM"] > 1e-3:
                raise SystemExit("%s: bake drift %.4f" % (c.name, m["bakeErrorM"]))
            m.update(AN.rider_metrics(rig, legs, c, idle0))
            if hasattr(c, "events"):
                m.update(AN.combat_metrics(rig, legs, c))
            row = dict(name=short, action=c.name, loop=c.loop, fps=c.fps, frames=m["frames"], seconds=m["seconds"], hash=m["hash"], notes=getattr(c, "notes", ""),
                       metrics={k: v for k, v in m.items() if k not in ("frames", "fps", "seconds", "hash")})
            if short in RD.CYCLE:
                row["cycleSec"] = RD.CYCLE[short]
                row["drivenByMountGaitPhase"] = True
            if hasattr(c, "events"):
                row["weight"] = c.weight
                row["motion"] = c.motion
                row["windows"] = dict(startupSec=c.startup, activeSec=c.active, recoverySec=c.recovery)
                row["events"] = c.events
            crow.append(row)
            acts.append(act)
            if a.previews and short in ("Gallop", "MountUp", "Stagger", "Hit1"):
                from ascend_animation import preview
                os.makedirs(a.previews, exist_ok=True)
                preview.sheet(rig, legs, c, os.path.join(a.previews, "%s_%s.png" % (fam, short)), count=8, H=ch["spec"]["heightM"])
            arm.animation_data.action = None
        cross = []
        if other:
            ic = RD.build_family(other[0], other[1], fam, win, fps)
            idle2 = AN.snapshot(other[0], other[1], ic[0].frames()[0])
            for c2 in ic:
                m2 = AN.analyze(other[0], other[1], c2)
                m2.update(AN.rider_metrics(other[0], other[1], c2, idle2))
                cross.append(dict(name=c2.name, kneeSpreadMinM=m2["kneeSpreadMinM"], startFromIdleM=m2["startFromIdleM"], endFromIdleM=m2["endFromIdleM"], hash=m2["hash"]))
        st = RD.STYLE[fam]
        entry = dict(id=fam, label=mounts["families"][fam].get("label"), species=fam_species[fam],
                     seatHeightM=st["seat"], seatHeightPlaceholder=True, seat=dict(thighSpreadDeg=st["ab"], thighFlexDeg=st["th"], kneeFlexDeg=st["kn"]),
                     clips=crow, crossCheck=cross)
        if not a.no_export:
            entry["file"] = os.path.relpath(BC.export_family(arm, fam, a.out), ROOT).replace("\\", "/")
        for act in acts:
            bpy.data.actions.remove(act)
        rows.append(entry)
        seated_rows = [r for r in crow if r["name"] not in GROUND_CLIPS]
        print("family %-22s %2d clips  knee spread min %.2f m  max start-from-idle %.3f" % (
            fam, len(crow), min(r["metrics"]["kneeSpreadMinM"] for r in seated_rows),
            max(r["metrics"]["startFromIdleM"] for r in seated_rows if r["name"] != "Idle")))
    if not a.no_manifest and not want:
        doc = dict(schema="rider_clips/1", rigContract="human_v1", source="Tools/blender/build_rider_clips.py", authoredOn=a.body,
                   mountsFile="Data/Companions/mounts.json", fps=30, hipsRestZ=round(rig.hips_rest.z, 4), attackFps=fps,
                   tuning=dict(file="Data/Combat/combat_tuning.json", block="attackTiming", hash=BC.tuning_hash(tuning)),
                   mountedCombatMaxChainHits=mounts["mountedCombat"]["maxChainHits"],
                   anchors=RD.RIGS_ANCHOR,
                   placement="Place the rider armature so its Hips bone sits on the saddle anchor (the mount rig bone plus the offset, in the mount rig normalised units times the mount size). Clips move the Hips by (hx, hz) metres from there. MountUp, Dismount and Stagger start or end on the ground beside the mount (standing hip height minus seatHeightM). Cycle clips are one mount gait cycle (Walk 1.1 s, Trot 0.7 s, Gallop 0.5 s): drive their normalised time from the mount gait phase. Seat offsets and heights are placeholders until calibrated on the mount models.",
                   families=rows)
        os.makedirs(os.path.dirname(a.manifest), exist_ok=True)
        with open(a.manifest, "w", encoding="utf8") as f:
            json.dump(doc, f, indent=1)
            f.write("\n")
        print("manifest:", a.manifest)


if __name__ == "__main__":
    main()
