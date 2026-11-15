"""
Checks for the combat clip sets (run inside Blender):

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_combat.py [-- --self-test] [-- --min-travel 0.2]

Every clip of every weapon family, on both human bases, must: be exactly startup + active + recovery long for its hit weight
(from Data/Combat/combat_tuning.json, read here, not from the clip code), carry its events on the exact frames, have a wind-up
that travels to the contact pose (a readable telegraph), reach forward at contact, stay above the floor, close its loop
(Ready, Charge) and give the same hash twice. `--self-test` breaks a window, a wind-up and a foot height on purpose and
requires each to be caught.
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

MIN_TRAVEL = 0.20          # m, weapon hand from the wind-up pose to the contact pose
MIN_REACH = 0.30           # m, weapon hand in front of the chest at contact
for i, a in enumerate(sys.argv):
    if a == "--min-travel":
        MIN_TRAVEL = float(sys.argv[i + 1])

with open(os.path.join(ROOT, "Data", "Combat", "combat_tuning.json"), encoding="utf8") as f:
    TUNING = json.load(f)
TRUE_WIN = CB.windows_from_tuning(TUNING)
SPECIAL_WEIGHT = {"HeavyRelease": "heavy", "Riposte": "heavy", "Launcher": "launch", "Slam": "heavy", "SkillCast": "medium"}


def verdicts(fam, c, m):
    bad = []
    if hasattr(c, "events"):
        w = SPECIAL_WEIGHT.get(c.name.split("_")[-1])
        if w is None:
            w = CB.chain_weights(len(CB.FAMILIES[fam]["hits"]))[int(c.name.split("Hit")[-1]) - 1]
        s, a, r = TRUE_WIN[w]
        if abs(c.seconds - (s + a + r)) > 1e-9 or m["frames"] != round((s + a + r) * c.fps):
            bad.append("length %d f @ %d fps is not startup+active+recovery of %s (%.2f s)" % (m["frames"], c.fps, w, s + a + r))
        ev = c.events
        if (ev["ActiveBegin"], ev["ActiveEnd"], ev["RecoveryEnd"]) != (round(s * c.fps), round((s + a) * c.fps), m["frames"]):
            bad.append("events %s do not match the windows" % ev)
        if m["handTravelM"] < MIN_TRAVEL:
            bad.append("wind-up to contact moves only %.2f m (no telegraph)" % m["handTravelM"])
        if m["contactReachM"] < MIN_REACH:
            bad.append("reach at contact %.2f m" % m["contactReachM"])
    else:
        if not c.loop or m["loopClosureM"] > 1e-3:
            bad.append("loop does not close")
    if m["minBoneZ"] < -0.02:
        bad.append("a bone goes %.3f m under the floor" % -m["minBoneZ"])
    if m.get("bakeErrorM", 0) > 1e-3:
        bad.append("bake drift")
    return bad


def run_body(body, win, mutate=None):
    ch = generate.character(body)
    rig = PO.Rig(ch["armature"])
    legs = {"Left": PP.LegGeometry(rig, "Left"), "Right": PP.LegGeometry(rig, "Right")}
    fps = CB.pick_fps(win) or 50
    res = {}
    for fam in CB.FAMILIES:
        for c in CB.build_family(rig, legs, fam, win, fps):
            if mutate:
                mutate(fam, c)
            m = AN.analyze(rig, legs, c)
            if hasattr(c, "events"):
                m.update(AN.combat_metrics(rig, legs, c))
            res["%s_%s" % (fam, c.name)] = (fam, c, verdicts(fam, c, m), m)
    return res


def main():
    self_test = "--self-test" in sys.argv
    fails = 0
    hashes = {}
    travel = []
    for body in ("human_male_base", "human_female_base"):
        res = run_body(body, TRUE_WIN)
        bad = {k: v[2] for k, v in res.items() if v[2]}
        for k, b in bad.items():
            print("FAIL %-28s %-18s %s" % (k, body, "; ".join(b)))
        fails += len(bad)
        print("%s: %d clips, %d failing" % (body, len(res), len(bad)))
        hashes[body] = {k: v[3]["hash"] for k, v in res.items()}
        travel += [v[3]["handTravelM"] for v in res.values() if "handTravelM" in v[3]]
    again = {k: v[3]["hash"] for k, v in run_body("human_male_base", TRUE_WIN).items()}
    print("determinism", "ok" if again == hashes["human_male_base"] else "FAIL")
    fails += again != hashes["human_male_base"]
    print("hand travel wind-up -> contact: min %.2f m, max %.2f m (gate %.2f)" % (min(travel), max(travel), MIN_TRAVEL))
    if self_test:
        longer = dict(TRUE_WIN, light=(TRUE_WIN["light"][0], TRUE_WIN["light"][1] * 1.5, TRUE_WIN["light"][2]))
        def no_windup(fam, c):
            if fam == "blade_1h" and c.name == "Hit1":
                orig = c._poses
                def p():
                    ready, (w, k, f) = orig()
                    return ready, (k, k, f)
                c._poses = p
        def sunk(fam, c):
            if fam == "bow" and c.name == "Hit1":
                orig = c.at
                c.at = lambda t, orig=orig: dict(orig(t), l_z=-0.15, r_z=-0.15)
        for label, win, fn, key in (("window changed (tuning drift)", longer, None, "blade_1h_Hit1"), ("no wind-up", TRUE_WIN, no_windup, "blade_1h_Hit1"),
                                    ("feet under floor", TRUE_WIN, sunk, "bow_Hit1")):
            res = run_body("human_male_base", win, fn)
            bad = res[key][2]
            print("self-test %-30s -> %s" % (label, "caught: " + "; ".join(bad) if bad else "NOT CAUGHT"))
            fails += not bad
    print("combat checks:", "FAILED (%d)" % fails if fails else "all passed")
    if fails:
        raise SystemExit(1)


if __name__ == "__main__":
    main()
