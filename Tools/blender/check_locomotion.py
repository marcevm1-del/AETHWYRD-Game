"""
Checks for the humanoid locomotion clips (run inside Blender):

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_locomotion.py [-- --self-test]

Every clip is built on both human bases and must: close its loop (loops), keep its feet planted at the design speed
(Walk/Run/Sprint: mean contact slide under 3 %), stay above the floor (no bone lower than -2 cm), reproduce its pose from
the baked action, hit the lengths the controller expects (Dodge exactly 0.42 s), and give the same hash twice.
`--self-test` breaks each guarded property on purpose (a wrong design speed, an open loop, feet under the floor) and requires the
checks to fail: a check that cannot fail proves nothing.
"""
import os
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, HERE)
if os.environ.get("ASCEND_CHARACTERS_DIR"):
    sys.path.insert(0, os.environ["ASCEND_CHARACTERS_DIR"])

import bpy  # noqa: E402

try:
    from ascend_characters import generate  # noqa: E402
except ImportError as e:
    sys.stderr.write("ascend_characters not found (%s); merge claude/humans-base or set ASCEND_CHARACTERS_DIR\n" % e)
    raise SystemExit(2)

from ascend_animation import analysis as AN  # noqa: E402
from ascend_animation import clips as CL  # noqa: E402
from ascend_animation import posing as PO  # noqa: E402
from ascend_animation import pose_params as PP  # noqa: E402

EXPECT = {"Idle": (90, 30, True), "Walk": (27, 30, True), "Run": (18, 30, True), "Sprint": (15, 30, True), "JumpStart": (14, 30, False),
          "Fall": (24, 30, True), "Land": (11, 30, False), "LandHard": (21, 30, False), "Dodge": (21, 50, False)}
GAITS = ("Walk", "Run", "Sprint")


def verdicts(rig, legs, clip, m):
    """Failures (list of strings) for one clip's metrics."""
    bad = []
    frames, fps, loop = EXPECT[clip.name]
    if (m["frames"], m["fps"], clip.loop) != (frames, fps, loop):
        bad.append("shape %s/%s/%s, want %s/%s/%s" % (m["frames"], m["fps"], clip.loop, frames, fps, loop))
    if clip.name == "Dodge" and abs(m["frames"] / m["fps"] - 0.42) > 1e-9:
        bad.append("Dodge is %.4f s, combat_tuning.json says 0.42" % (m["frames"] / m["fps"]))
    if clip.loop and m["loopClosureM"] > 1e-3:
        bad.append("loop does not close (%.4f m)" % m["loopClosureM"])
    if m["minBoneZ"] < -0.02:
        bad.append("a bone goes %.3f m under the floor" % -m["minBoneZ"])
    if clip.name in GAITS:
        if not m.get("footContactFrames"):
            bad.append("no foot contact frames measured")
        elif m["footSlideMeanPct"] > 3.0:
            bad.append("feet slide %.1f %% of the design speed" % m["footSlideMeanPct"])
        if m["reachClamped"] > 12:
            bad.append("%d leg frames were clamped at full extension" % m["reachClamped"])
    if clip.name not in GAITS and clip.name not in ("Fall",) and m["minFootZ"] > 0.03 and clip.name != "JumpStart":
        bad.append("never touches the ground (min foot z %.3f)" % m["minFootZ"])
    if m.get("bakeErrorM", 0.0) > 1e-3:
        bad.append("baked action drifts %.4f m from the pose" % m["bakeErrorM"])
    return bad


def run_body(body, mutate=None):
    ch = generate.character(body)
    rig = PO.Rig(ch["armature"])
    legs = {"Left": PP.LegGeometry(rig, "Left"), "Right": PP.LegGeometry(rig, "Right")}
    out = {}
    for c in CL.all_clips(rig, legs):
        if mutate:
            mutate(c)
        m = AN.analyze(rig, legs, c, speed=getattr(c, "design_speed", None))
        out[c.name] = (c, verdicts(rig, legs, c, m), m)
    return out


def main():
    self_test = "--self-test" in sys.argv
    fails = 0
    first = {}
    for body in ("human_male_base", "human_female_base"):
        res = run_body(body)
        for name, (c, bad, m) in res.items():
            print("%-10s %-18s %s" % (name, body, "ok" if not bad else "FAIL " + "; ".join(bad)))
            fails += bool(bad)
        first[body] = {k: v[2]["hash"] for k, v in res.items()}
    again = {k: v[2]["hash"] for k, v in run_body("human_male_base").items()}
    if again != first["human_male_base"]:
        print("FAIL determinism: a second build gave different hashes")
        fails += 1
    else:
        print("determinism ok (second build identical)")
    if self_test:
        def wrong_speed(c):
            if c.name == "Walk":
                c.design_speed = 3.4                      # feet no longer match the ground
        def open_loop(c):
            if c.name == "Idle":
                orig = c.at
                c.at = lambda t, orig=orig: dict(orig(t), hr=orig(t)["hr"] + 6 * t)
        def sunk(c):                                          # both ankles forced 12 cm into the floor
            if c.name == "Run":
                orig = c.at
                c.at = lambda t, orig=orig: dict(orig(t), l_z=-0.12, r_z=-0.12)
        for label, fn, clip in (("wrong design speed", wrong_speed, "Walk"), ("open loop", open_loop, "Idle"), ("feet under floor", sunk, "Run")):
            res = run_body("human_male_base", mutate=fn)
            caught = bool(res[clip][1])
            print("self-test %-18s -> %s" % (label, "caught: " + "; ".join(res[clip][1]) if caught else "NOT CAUGHT"))
            fails += (not caught)
    print("locomotion checks:", "FAILED (%d)" % fails if fails else "all passed")
    if fails:
        raise SystemExit(1)


if __name__ == "__main__":
    main()
