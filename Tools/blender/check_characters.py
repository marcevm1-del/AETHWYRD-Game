"""
Checks for the character generator, run in Blender (exit code 1 on any failure):

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_characters.py [-- --hashes <file>]

1. every variant in Data/Characters/human_library.json generates and passes the rig validator;
2. the same variant generated twice in one process gives the same mesh hash (a second process is compared with --hashes:
   the file is written on the first run and compared on later runs);
3. the validator fails loudly: a renamed bone, an unweighted vertex and a broken parent are each caught;
4. both bases have the same bone set; heights match the spec.
"""
import json
import os
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, HERE)

import bpy  # noqa: E402

from ascend_characters import generate, meshio, skeleton, spec, validate  # noqa: E402


def clear():
    for o in list(bpy.data.objects):
        bpy.data.objects.remove(o, do_unlink=True)


def arg(name):
    a = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    return a[a.index(name) + 1] if name in a else None


fails = []


def ok(cond, msg):
    print(("[CHK] ok   " if cond else "[CHK] FAIL ") + msg, flush=True)
    if not cond:
        fails.append(msg)


hashes = {}
bones = {}
for vid in spec.variant_ids():
    clear()
    ch = generate.character(vid)
    prob = validate.check(ch)
    ok(not prob, "%s validates (%s)" % (vid, "; ".join(prob[:3])))
    h1 = ch["hash"]
    clear()
    h2 = generate.character(vid)["hash"]
    ok(h1 == h2, "%s same seed, same hash in one process (%s)" % (vid, h1))
    hashes[vid] = h1
    bones[vid] = sorted(b.name for b in generate.bpy.data.objects[vid + "_rig"].data.bones)
    ok(bones[vid] == sorted(skeleton.NAMES), "%s has exactly the contract bones" % vid)
    ob = bpy.data.objects[vid + "_body"]
    co = meshio.co(ob)
    ok(abs((co[:, 2].max() - co[:, 2].min()) - ch["spec"]["heightM"]) < 0.015, "%s height %.3f m" % (vid, co[:, 2].max() - co[:, 2].min()))

# a different seed must change the mesh
clear()
a = generate.character({"id": "t", "body": "human_male_base", "seed": 1})["hash"]
clear()
b = generate.character({"id": "t", "body": "human_male_base", "seed": 2})["hash"]
ok(a != b, "a different seed gives a different mesh")

# negative tests: the validator must notice a broken rig
clear()
ch = generate.character("human_male_base", hair=False, outfit=False)
arm = ch["armature"]
bpy.context.view_layer.objects.active = arm
bpy.ops.object.mode_set(mode="EDIT")
arm.data.edit_bones["LeftHand"].name = "LeftPalm"
bpy.ops.object.mode_set(mode="OBJECT")
p = validate.check(ch)
ok(any("LeftPalm" in x or "LeftHand" in x for x in p), "renamed bone is caught (%d problems)" % len(p))
clear()
ch = generate.character("human_male_base", hair=False, outfit=False)
vg = ch["parts"]["body"].vertex_groups["Head"]
vg.remove(list(range(len(ch["parts"]["body"].data.vertices))))
p = validate.check(ch)
ok(any("no weights" in x or "sum to 1" in x for x in p), "stripped weights are caught")
clear()
ch = generate.character("human_male_base", hair=False, outfit=False)
bpy.context.view_layer.objects.active = ch["armature"]
bpy.ops.object.mode_set(mode="EDIT")
ch["armature"].data.edit_bones["LeftLowerArm"].parent = ch["armature"].data.edit_bones["Hips"]
bpy.ops.object.mode_set(mode="OBJECT")
ok(any("parent" in x for x in validate.check(ch)), "broken hierarchy is caught")

hf = arg("--hashes")
if hf:
    if os.path.exists(hf):
        old = json.load(open(hf))
        ok(old == hashes, "hashes equal those of the earlier process")
    else:
        json.dump(hashes, open(hf, "w"), indent=1)
        print("[CHK] wrote", hf)
if fails:
    raise SystemExit("%d check(s) failed" % len(fails))
print("[CHK] all checks passed")
