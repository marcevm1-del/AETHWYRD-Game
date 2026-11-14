"""
Checks for the rider pose clips (run inside Blender):

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_riders.py [-- --self-test]

For every mount family in Data/Companions/mounts.json (read here), on both human bases: the rider straddles (knees at least 0.30 m
apart in every seated clip), the pelvis moves no more than 8 cm while seated, cycle clips close their loops, every seated clip
starts from the seated Idle pose (blends cleanly), MountUp ends and Dismount/Stagger begin on that pose, MountUp starts and Dismount
ends standing on the ground beside the mount (hips at standing height minus the family seat height), mounted attacks are exactly
the combat_tuning.json windows with the events on exact frames and mountedCombat.maxChainHits hits, and a second build gives the
same hashes. `--self-test` closes the thighs, lifts the MountUp end pose and lengthens an attack window, and requires each to be caught.
"""
import json
import os
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(os.path.dirname(HERE))
sys.path.insert(0, HERE)
if os.environ.get("ASCEND_CHARACTERS_DIR"):
    sys.path.insert(0, os.environ["ASCEND_CHARACTERS_DIR"])

try:
    from ascend_characters import generate
except ImportError as e:
    sys.stderr.write("ascend_characters not found (%s); merge claude/humans-base or set ASCEND_CHARACTERS_DIR\n" % e)
    raise SystemExit(2)

from ascend_animation import analysis as AN  # noqa: E402
from ascend_animation import combat as CB  # noqa: E402
from ascend_animation import pose_params as PP  # noqa: E402
from ascend_animation import posing as PO  # noqa: E402
from ascend_animation import rider as RD  # noqa: E402

with open(os.path.join(ROOT, "Data", "Combat", "combat_tuning.json"), encoding="utf8") as f:
    TUNING = json.load(f)
with open(os.path.join(ROOT, "Data", "Companions", "mounts.json"), encoding="utf8") as f:
    MOUNTS = json.load(f)
TRUE_WIN = CB.windows_from_tuning(TUNING)
GROUND = ("MountUp", "Dismount", "Stagger")
CYCLE = ("Idle", "Walk", "Trot", "Gallop")
ATTACK_WEIGHT = {"Hit1": "light", "Hit2": "light", "Hit3": "medium", "Skill": "medium"}
SEATED_TOL = 0.12      # m, a seated clip's first and last pose against the seated Idle pose
JOIN_TOL = 0.03        # m, where one clip hands over to another (MountUp end, Dismount/Stagger start, attack ends)


def verdicts(rig, fam, c, m):
    bad = []
    n = c.name.split("_")[-1]
    if n not in GROUND:
        if m["kneeSpreadMinM"] < 0.30:
            bad.append("knees only %.2f m apart (not astride)" % m["kneeSpreadMinM"])
        if m["hipsTravelM"] > 0.08:
            bad.append("pelvis moves %.3f m while seated" % m["hipsTravelM"])
        if m["startFromIdleM"] > SEATED_TOL or m["endFromIdleM"] > SEATED_TOL:
            bad.append("starts/ends %.3f/%.3f m from the seated Idle pose" % (m["startFromIdleM"], m["endFromIdleM"]))
    if n in CYCLE and (not c.loop or m["loopClosureM"] > 1e-3):
        bad.append("loop does not close")
    if n in ATTACK_WEIGHT:
        s, a, r = TRUE_WIN[ATTACK_WEIGHT[n]]
        if abs(c.seconds - (s + a + r)) > 1e-9 or m["frames"] != round((s + a + r) * c.fps):
            bad.append("length %d f is not the %s windows (%.2f s)" % (m["frames"], ATTACK_WEIGHT[n], s + a + r))
        ev = c.events
        if (ev["ActiveBegin"], ev["ActiveEnd"], ev["RecoveryEnd"]) != (round(s * c.fps), round((s + a) * c.fps), m["frames"]):
            bad.append("events do not match the windows")
        if m["handTravelM"] < 0.15:
            bad.append("wind-up to contact moves only %.2f m" % m["handTravelM"])
        if m["startFromIdleM"] > JOIN_TOL or m["endFromIdleM"] > JOIN_TOL:
            bad.append("an attack must start and end in the seated pose (%.3f/%.3f m)" % (m["startFromIdleM"], m["endFromIdleM"]))
    stand = rig.hips_rest.z - RD.STYLE[fam]["seat"]
    if n == "MountUp":
        if m["endFromIdleM"] > JOIN_TOL:
            bad.append("MountUp ends %.3f m from the seated pose" % m["endFromIdleM"])
        if abs(m["startHipsDzM"] - stand) > 0.02:
            bad.append("MountUp starts with the hips %.3f m from standing height on the ground (%.3f)" % (m["startHipsDzM"] - stand, stand))
    if n == "Dismount":
        if m["startFromIdleM"] > JOIN_TOL:
            bad.append("Dismount starts %.3f m from the seated pose" % m["startFromIdleM"])
        if abs(m["endHipsDzM"] - stand) > 0.02:
            bad.append("Dismount ends with the hips %.3f m from standing height on the ground (%.3f)" % (m["endHipsDzM"] - stand, stand))
    if n == "Stagger" and m["startFromIdleM"] > JOIN_TOL:
        bad.append("Stagger starts %.3f m from the seated pose" % m["startFromIdleM"])
    if m.get("bakeErrorM", 0) > 1e-3:
        bad.append("bake drift")
    return bad


def run_body(body, win, mutate=None):
    ch = generate.character(body)
    rig = PO.Rig(ch["armature"])
    legs = {"Left": PP.LegGeometry(rig, "Left"), "Right": PP.LegGeometry(rig, "Right")}
    fps = CB.pick_fps(win) or 50
    res = {}
    for fam in MOUNTS["families"]:
        clips = RD.build_family(rig, legs, fam, win, fps)
        if sum(1 for c in clips if c.name.startswith("Hit")) != MOUNTS["mountedCombat"]["maxChainHits"]:
            res["%s_hits" % fam] = (fam, None, ["hit count differs from mountedCombat.maxChainHits"], {"hash": ""})
        idle0 = AN.snapshot(rig, legs, clips[0].frames()[0])
        for c in clips:
            if mutate:
                mutate(fam, c)
            m = AN.analyze(rig, legs, c)
            m.update(AN.rider_metrics(rig, legs, c, idle0))
            if hasattr(c, "events"):
                m.update(AN.combat_metrics(rig, legs, c))
            res["%s_%s" % (fam, c.name)] = (fam, c, verdicts(rig, fam, c, m), m)
    return res


def main():
    self_test = "--self-test" in sys.argv
    fails = 0
    hashes = {}
    for body in ("human_male_base", "human_female_base"):
        res = run_body(body, TRUE_WIN)
        bad = {k: v[2] for k, v in res.items() if v[2]}
        for k, b in bad.items():
            print("FAIL %-26s %-18s %s" % (k, body, "; ".join(b)))
        fails += len(bad)
        print("%s: %d clips, %d failing" % (body, len(res), len(bad)))
        hashes[body] = {k: v[3]["hash"] for k, v in res.items()}
    again = {k: v[3]["hash"] for k, v in run_body("human_male_base", TRUE_WIN).items()}
    print("determinism", "ok" if again == hashes["human_male_base"] else "FAIL")
    fails += again != hashes["human_male_base"]
    if self_test:
        longer = dict(TRUE_WIN, light=(TRUE_WIN["light"][0], TRUE_WIN["light"][1] * 1.5, TRUE_WIN["light"][2]))

        def closed_thighs(fam, c):
            if fam == "horse" and c.name.endswith("Idle"):
                orig = c.fn
                c.fn = lambda cc, t, orig=orig: dict(orig(cc, t), l_ab=0, r_ab=0, l_th=0, r_th=0, l_kn=0, r_kn=0)

        def lifted_end(fam, c):
            if fam == "bear" and c.name.endswith("MountUp"):
                orig = c.fn
                c.fn = lambda cc, t, orig=orig: dict(orig(cc, t), hz=orig(cc, t).get("hz", 0.0) + 0.12 * t ** 4)

        for label, win, fn, key in (("thighs closed", TRUE_WIN, closed_thighs, "horse_Idle"), ("MountUp ends off the seat", TRUE_WIN, lifted_end, "bear_MountUp"),
                                    ("window changed (tuning drift)", longer, None, "horse_Hit1")):
            res = run_body("human_male_base", win, fn)
            bad = res[key][2]
            print("self-test %-30s -> %s" % (label, "caught: " + "; ".join(bad) if bad else "NOT CAUGHT"))
            fails += not bad
    print("rider checks:", "FAILED (%d)" % fails if fails else "all passed")
    if fails:
        raise SystemExit(1)


if __name__ == "__main__":
    main()
