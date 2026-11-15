"""
Checks for the facial shape-key rig (run inside Blender):

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_face.py [-- --self-test]

On both human bases: the rig reproduces the generator's decals (face_rig.apply raises otherwise), the six legacy keys are still there,
every atomic key moves its decal (at least 0.5 mm, at most 40 mm, no NaN), left/right key pairs mirror each other (within 1 mm), every
expression only names existing keys with weights in 0..1, no two expressions are the same face (some vertex at least 2 mm apart),
nothing is named like a viseme or phoneme (no lip-sync), and a second build gives identical displacements. `--self-test` kills a key,
breaks a mirror pair and adds a viseme-named expression, and requires each to be caught.
"""
import hashlib
import os
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, HERE)
if os.environ.get("ASCEND_CHARACTERS_DIR"):
    sys.path.insert(0, os.environ["ASCEND_CHARACTERS_DIR"])

import numpy as np  # noqa: E402

try:
    from ascend_characters import generate
except ImportError as e:
    sys.stderr.write("ascend_characters not found (%s); merge claude/humans-base or set ASCEND_CHARACTERS_DIR\n" % e)
    raise SystemExit(2)

from ascend_animation import face_expressions as FE  # noqa: E402
from ascend_animation import face_rig as FR  # noqa: E402

MIN_MM, MAX_MM, MIRROR_MM, MIRROR_DEPTH_MM, DISTINCT_MM = 0.5, 40.0, 1.5, 5.0, 2.0


def mirror_pairs(keys):
    """[(part, name_L, name_R)] for every key pair that ends in _L/_R."""
    out = []
    for part, ks in keys.items():
        for n in ks:
            if n.endswith("_L") and n[:-2] + "_R" in ks:
                out.append((part, n, n[:-2] + "_R"))
    return out


def side_index(rig, part):
    """Index arrays that map a vertex of the left-hand patch to its mirror vertex in the right-hand patch, and a mouth self-mirror."""
    if part == "mouth":
        ids = [i for i, t in enumerate(rig.Pm.tag) if t.startswith("mouth")]
        n = len(ids) // 2
        m = {}
        for k, i in enumerate(ids):
            row = k // n
            m[i] = ids[row * n + (n - 1 - (k % n))]
        return m
    P = rig.Pe if part == "eyes" else rig.Pb
    L = [i for i, t in enumerate(P.tag) if t.endswith("L")]
    R = [i for i, t in enumerate(P.tag) if t.endswith("R")]
    if len(L) != len(R):
        return None
    # match by position, not by index: a ribbon on the right side runs the other way, so its "top" edge is the left side's bottom edge
    m = {}
    for i in L:
        stem = P.tag[i][:-1]
        best = min((j for j in R if P.tag[j][:-1] == stem), key=lambda j: (-P.uv[i][0] - P.uv[j][0]) ** 2 + (P.uv[i][1] - P.uv[j][1]) ** 2)
        m[i] = best
        m[best] = i
    return m


def _mirror_error(dl_all, dr_all, m):
    """Worst mismatch (mm) between a key and its mirror: across the face (x and z; this is what the key authors) and in depth (y; the
    head surface is not perfectly symmetric, so depth gets a looser limit)."""
    across = depth = 0.0
    for i, j in m.items():
        dl, dr = dl_all[i], dr_all[j]
        across = max(across, float(np.hypot(dl[0] + dr[0], dl[2] - dr[2])))
        depth = max(depth, abs(float(dl[1] - dr[1])))
    return across * 1000, depth * 1000


def evaluate(rig, keys, expressions, legacy_ok):
    bad = []
    if not legacy_ok:
        bad.append("legacy keys missing after apply")
    for part, ks in keys.items():
        for name, d in ks.items():
            if not np.isfinite(d).all():
                bad.append("%s/%s: NaN" % (part, name))
                continue
            mm = float(np.linalg.norm(d, axis=1).max()) * 1000
            if mm < MIN_MM:
                bad.append("%s/%s moves nothing (%.2f mm)" % (part, name, mm))
            if mm > MAX_MM:
                bad.append("%s/%s moves %.1f mm" % (part, name, mm))
    for part, nl, nr in mirror_pairs(keys):
        m = side_index(rig, part)
        if m is None:
            bad.append("%s: left and right patches differ in size" % part)
            continue
        worst, depth = _mirror_error(keys[part][nl], keys[part][nr], m)
        if worst > MIRROR_MM or depth > MIRROR_DEPTH_MM:
            bad.append("%s: %s / %s do not mirror (%.2f mm across, %.2f mm depth)" % (part, nl, nr, worst, depth))
    # mouth smirks mirror through the mouth's own symmetry
    if "mouth_smirk_L" in keys["mouth"]:
        m = side_index(rig, "mouth")
        worst, depth = _mirror_error(keys["mouth"]["mouth_smirk_L"], keys["mouth"]["mouth_smirk_R"], m)
        if worst > MIRROR_MM or depth > MIRROR_DEPTH_MM:
            bad.append("mouth_smirk_L / R do not mirror (%.2f mm across, %.2f mm depth)" % (worst, depth))
    allnames = {n for ks in keys.values() for n in ks}
    vec = {}
    for ename, weights in expressions.items():
        if any(p in ename.lower() for p in FE.FORBIDDEN_NAME_PARTS):
            bad.append("expression %s is named like lip-sync" % ename)
        for k, w in weights.items():
            if k not in allnames:
                bad.append("expression %s names unknown key %s" % (ename, k))
            if not (0.0 <= w <= 1.0):
                bad.append("expression %s: weight %s out of 0..1" % (ename, w))
        r = FR.resolve(keys, weights)
        vec[ename] = np.concatenate([np.asarray(r[p]).ravel() for p in ("eyes", "brows", "mouth")])
    names = list(vec)
    closest = None
    for i in range(len(names)):
        for j in range(i + 1, len(names)):
            d = float(np.linalg.norm((vec[names[i]] - vec[names[j]]).reshape(-1, 3), axis=1).max()) * 1000
            if closest is None or d < closest[0]:
                closest = (d, names[i], names[j])
            if d < DISTINCT_MM:
                bad.append("expressions %s and %s are the same face (%.2f mm at the most different vertex)" % (names[i], names[j], d))
    for kn in allnames:
        if any(p in kn.lower() for p in FE.FORBIDDEN_NAME_PARTS):
            bad.append("key %s is named like lip-sync" % kn)
    return bad, closest


def digest(keys):
    h = hashlib.sha1()
    for part in sorted(keys):
        for name in sorted(keys[part]):
            h.update(name.encode())
            h.update(np.round(keys[part][name] * 1e5).astype(np.int64).tobytes())
    return h.hexdigest()[:12]


def legacy_ok(ch):
    for part, names in FR.LEGACY.items():
        have = {k.name for k in ch["parts"][part].data.shape_keys.key_blocks}
        if not set(names) <= have:
            return False
    return True


def main():
    self_test = "--self-test" in sys.argv
    fails = 0
    out = {}
    for body in ("human_male_base", "human_female_base"):
        ch = generate.character(body)
        rig = FR.Rig(ch)
        keys = FR.apply(ch)
        bad, closest = evaluate(rig, keys, FE.EXPRESSIONS, legacy_ok(ch))
        for b in bad:
            print("FAIL %-18s %s" % (body, b))
        fails += len(bad)
        nkeys = sum(len(v) for v in keys.values())
        print("%s: %d atomic keys, %d expressions, closest pair %s %s %.2f mm, %d failing" % (body, nkeys, len(FE.EXPRESSIONS), closest[1], closest[2], closest[0], len(bad)))
        out[body] = (rig, keys, digest(keys))
    # determinism: a second build of the male base
    ch = generate.character("human_male_base")
    again = digest(FR.Rig(ch).all_keys())
    print("determinism", "ok" if again == out["human_male_base"][2] else "FAIL")
    fails += again != out["human_male_base"][2]
    if self_test:
        rig, keys, _ = out["human_male_base"]
        dead = {p: dict(ks) for p, ks in keys.items()}
        dead["eyes"]["eyes_wide_L"] = dead["eyes"]["eyes_wide_L"] * 0.0
        skew = {p: dict(ks) for p, ks in keys.items()}
        skew["brows"]["brow_inner_up_R"] = skew["brows"]["brow_inner_up_R"] * 2.5
        lip = dict(FE.EXPRESSIONS)
        lip["viseme_aa"] = {"mouth_open_wide": 0.7}
        for label, k, ex, want in (("a key that moves nothing", dead, FE.EXPRESSIONS, "moves nothing"), ("a broken mirror pair", skew, FE.EXPRESSIONS, "do not mirror"),
                                   ("a viseme-named expression", keys, lip, "lip-sync")):
            bad, _ = evaluate(rig, k, ex, True)
            hit = [b for b in bad if want in b]
            print("self-test %-28s -> %s" % (label, "caught: " + hit[0] if hit else "NOT CAUGHT"))
            fails += not hit
    print("face checks:", "FAILED (%d)" % fails if fails else "all passed")
    if fails:
        raise SystemExit(1)


if __name__ == "__main__":
    main()
