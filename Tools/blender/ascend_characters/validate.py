"""
Rig and weight validator. A variant that breaks the rig contract fails loudly (non-zero exit with --python-exit-code 1).

    problems = validate.check(character)       # list of strings, empty when fine
    validate.assert_ok(character)               # raises RuntimeError listing every problem
"""
import numpy as np

from . import meshio as M
from . import skeleton as SK
from . import spec as S


def check(ch):
    """ch: the dict returned by generate.character (keys: spec, armature, parts)."""
    out = []
    arm = ch["armature"]
    sp = ch["spec"]
    lib = S.library()["rig"]
    names = [b.name for b in arm.data.bones]
    out += SK.check_names(names)
    if sorted(lib["requiredBones"]) != sorted(SK.HUMANOID_NAMES) or sorted(lib["extraBones"]) != sorted(SK.EXTRA_NAMES):
        out.append("Data/Characters/human_library.json rig lists differ from skeleton.py")
    for b in arm.data.bones:
        want = SK.PARENT.get(b.name)
        have = b.parent.name if b.parent else None
        if b.name in SK.PARENT and want != have:
            out.append("bone %s has parent %s, expected %s" % (b.name, have, want))
        if b.length < 1e-3:
            out.append("bone %s is shorter than 1 mm" % b.name)
    for n in SK.HUMANOID_NAMES:
        if n.startswith("Left") and n in arm.data.bones and SK.mirror(n) in arm.data.bones:
            a, c = arm.data.bones[n], arm.data.bones[SK.mirror(n)]
            if (abs(a.head_local.x + c.head_local.x) > 2e-3 or abs(a.head_local.y - c.head_local.y) > 2e-3 or abs(a.head_local.z - c.head_local.z) > 2e-3
                    or abs(a.tail_local.x + c.tail_local.x) > 2e-3 or abs(a.tail_local.z - c.tail_local.z) > 2e-3):
                out.append("%s and %s are not mirror images" % (n, SK.mirror(n)))
    bone_set = set(names)
    for pname, o in ch["parts"].items():
        if o.type != "MESH":
            continue
        md = o.modifiers.get("Armature")
        if md is None or md.object is not arm:
            out.append("%s is not skinned to the armature" % pname)
        wl = M.get_weights(o)
        stray = {g.name for g in o.vertex_groups} - bone_set
        if stray:
            out.append("%s has vertex groups that are not bones: %s" % (pname, sorted(stray)[:5]))
        n_bad = n_sum = n_inf = 0
        for w in wl:
            if not w:
                n_bad += 1
                continue
            if len(w) > SK.MAX_INFLUENCES:
                n_inf += 1
            if abs(sum(w.values()) - 1.0) > 0.01:
                n_sum += 1
        if n_bad:
            out.append("%s: %d vertices have no weights" % (pname, n_bad))
        if n_inf:
            out.append("%s: %d vertices have more than %d influences" % (pname, n_inf, SK.MAX_INFLUENCES))
        if n_sum:
            out.append("%s: %d vertices whose weights do not sum to 1" % (pname, n_sum))
    body = ch["parts"]["body"]
    cnt = {}
    for w in M.get_weights(body):
        for g, v in w.items():
            if v > 0.05:
                cnt[g] = cnt.get(g, 0) + 1
    for n in SK.HUMANOID_NAMES:
        if cnt.get(n, 0) < 4:
            out.append("body has fewer than 4 vertices weighted on humanoid bone %s" % n)
    for pname, o in ch["parts"].items():
        a = M.co(o)
        if not np.isfinite(a).all():
            out.append("%s has non-finite coordinates" % pname)
        if len(a) == 0 or len(o.data.polygons) == 0:
            out.append("%s is empty" % pname)
        if M.edge_report(o)["loose"]:
            out.append("%s has loose vertices" % pname)
    if (arm.location.length > 1e-6 or any(abs(s - 1.0) > 1e-6 for s in arm.scale) or any(abs(r) > 1e-6 for r in arm.rotation_euler)):
        out.append("the armature object is moved, rotated or scaled")
    rep = M.edge_report(body)
    if rep["open"] or rep["nonmanifold"] or rep["loose"]:
        out.append("body topology: %s" % rep)
    co = M.co(body)
    h = co[:, 2].max() - co[:, 2].min()
    if abs(h - sp["heightM"]) > 0.015:
        out.append("body is %.3f m tall, spec says %.2f m" % (h, sp["heightM"]))
    if co[:, 2].min() < -0.005:
        out.append("feet sink %.1f cm below the ground" % (-co[:, 2].min() * 100))
    return out


def assert_ok(ch):
    p = check(ch)
    if p:
        raise RuntimeError("rig validation failed for %s:\n  %s" % (ch["spec"]["id"], "\n  ".join(p)))
    return True
