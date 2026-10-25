"""Project Ascend: rig a procedural creature (ascend_creatures) to its shared monster rig (Blender 5.x, headless).

    blender -b --factory-startup -P Tools/blender/rig_creature.py                               # the four Ring 0 monsters
    blender -b --factory-startup -P Tools/blender/rig_creature.py -- --ids mon_goblin,mon_forest_wolf
    blender -b --factory-startup -P Tools/blender/rig_creature.py -- --ids mon_forest_wolf --rig quad_large
    options: --detail high|medium|low   --sheet PNG   --no-sheet   --no-save   --out DIR

For each species it:
  1. generates the creature with ascend_creatures.generate.creature() and keeps the Body landmarks of that build
     (head, head_r, neck, spine, shoulders, hands, hips, feet, tail_root, tail_dir, eye points, mouth, snout);
  2. resolves the rig: the species' rigKey in Data/Monsters/motion.json (what Unity uses), else its rigId;
  3. places every rigs.json bone from those landmarks, at the creature's real size (the same scale
     generate.creature applies: sizeMeters / largest body extent), keeping the rigs.json names, parents, deform
     flags, spring settings, IK controls and bone collections (build_rig.build_armature does the armature);
  4. skins the mesh: bone-heat weights on a decimated copy of the skin (fallback: distance weights for anything
     heat leaves unweighted), copied to the full skin by nearest neighbours, at most 4 bones per vertex; each hard
     part (eye, horn, tooth, claw, weapon, plate) is rigid and follows the skin it touches;
  5. adds the rig's blend shapes that are cheap to make procedurally (squash, stretch, puff, blinks, mouth shapes);
  6. keys two FK test poses as Actions (test_telegraph, test_idle; IK muted inside them), saves
     Art/Blender/Rigged/<species_id>.blend in the rest pose, and renders rest / telegraph / idle tiles into one
     contact sheet (default 13_Production/screenshots/rigged_ring0.png, rows in --ids order).
Coordinates: the creature faces -Y, Z up, _L = +X (the creature's left), as in rigs.json and build_rig.py.
"""
import json
import math
import os
import sys
import tempfile
import time

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(os.path.dirname(HERE))
if HERE not in sys.path:
    sys.path.insert(0, HERE)

import bpy  # noqa: E402
import numpy as np  # noqa: E402
from mathutils import Quaternion, Vector, kdtree  # noqa: E402

import build_rig  # noqa: E402
from ascend_buildings import preview  # noqa: E402
from ascend_creatures import features, generate  # noqa: E402

RING0 = ["mon_blue_slime", "mon_goblin", "mon_horned_rabbit", "mon_forest_wolf"]
PROXY_FACES = 14000
SMOOTH_PASSES = 4


def arg(name, default=None):
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    if name in argv:
        i = argv.index(name)
        return argv[i + 1] if i + 1 < len(argv) and not argv[i + 1].startswith("--") else True
    return default


def V(*a):
    return Vector(a[0]) if len(a) == 1 else Vector(a)


# ----------------------------------------------------------------------------------------------------------- data
def load_rigs():
    with open(os.path.join(ROOT, "Data", "Monsters", "rigs.json"), encoding="utf8") as f:
        return {r["key"]: r for r in json.load(f)["rigs"]}


def rig_key_for(species_id, species):
    try:
        with open(os.path.join(ROOT, "Data", "Monsters", "motion.json"), encoding="utf8") as f:
            for e in json.load(f)["species"]:
                if e["speciesId"] == species_id:
                    return e["rigKey"], "motion.json"
    except (OSError, KeyError):
        pass
    rid = species.get("rigId") or ""
    return (rid[4:] if rid.startswith("rig_") else rid), "species.json"


def generate_with_body(species_id, detail):
    """generate.creature() plus the build() result it used (the Body landmarks), from one build."""
    cache = {}
    orig = generate.build

    def wrapped(*a, **k):
        cache["r"] = orig(*a, **k)
        return cache["r"]

    generate.build = wrapped
    try:
        obj = generate.creature(species_id, detail=detail)
    finally:
        generate.build = orig
    r = cache["r"]
    ext = r["verts"].max(0) - r["verts"].min(0)
    size = float(r["species"].get("sizeMeters") or 1.0)
    scale = size / max(1e-6, float(ext.max()))  # exactly as generate.creature scales
    if r["body"].kind == "swarm":
        scale = size / 0.12
    return obj, r, scale, size


# --------------------------------------------------------------------------------------------- bone placement
def sim(a0, a1, c0, c1):
    """Similarity transform taking template points a0, a1 onto creature points c0, c1."""
    a0, a1, c0, c1 = V(a0), V(a1), V(c0), V(c1)
    da, dc = a1 - a0, c1 - c0
    s = dc.length / max(da.length, 1e-6)
    q = da.rotation_difference(dc) if da.length > 1e-6 and dc.length > 1e-6 else Quaternion()
    return lambda p: c0 + q @ ((V(p) - a0) * s)


def bbox_map(tmpl, verts):
    """Fallback: per-axis scale of the template's bone box onto the creature's body box."""
    pts = np.array([b["head"] for b in tmpl] + [b["tail"] for b in tmpl], dtype=float)
    tlo, thi = pts.min(0), pts.max(0)
    clo, chi = verts.min(0), verts.max(0)
    s = (chi - clo) / np.maximum(thi - tlo, 1e-6)
    return lambda p: V(tuple(clo + (np.array(p) - tlo) * s))


def polyline_split(pts, n):
    """n+1 points spaced evenly by arc length along a polyline."""
    pts = [V(p) for p in pts]
    seg = [(pts[i + 1] - pts[i]).length for i in range(len(pts) - 1)]
    total = sum(seg) or 1e-6
    out, i, acc = [], 0, 0.0
    for k in range(n + 1):
        t = total * k / n
        while i < len(seg) - 1 and acc + seg[i] < t:
            acc += seg[i]
            i += 1
        f = (t - acc) / max(seg[i], 1e-9)
        out.append(pts[i].lerp(pts[i + 1], min(1.0, max(0.0, f))))
    return out


def ear_kind(r):
    b, look = r["body"], r["look"]
    parts = set(look.parts)
    if look.family in ("Goblinoids", "Kobolds", "Gremlins", "Demons") and b.kind == "biped" and not parts & {"ears_long", "ears_tall"}:
        parts.add("ears_long")
    ear = b.P.get("ears")
    if "ears_tall" in parts:
        ear = "tall"
    elif "ears_long" in parts and not ear:
        ear = "goblin"
    return ear


def ear_points(head, hr, kind, s):
    """Base, middle and tip of one ear, as features.ears() builds it."""
    if not kind or kind == "none":
        return None
    if kind == "round":
        base = head + V(s * hr * 0.5, hr * 0.12, hr * 0.6)
        tip = base + V(s * hr * 0.2, hr * 0.05, hr * 0.35)
    elif kind == "goblin":
        base = head + V(s * hr * 0.82, hr * 0.12, hr * 0.08)
        tip = base + V(s * hr * 1.15, hr * 0.45, hr * 0.38)
    elif kind in ("long", "side"):
        base = head + V(s * hr * 0.75, hr * 0.15, hr * 0.45)
        tip = base + V(s * hr * 0.85, hr * 0.15, hr * (0.15 if kind == "long" else -0.35))
    else:
        L = {"pointy": 0.9, "tall": 1.6, "big": 1.25, "small": 0.55, "tuft": 0.5}.get(kind, 0.9)
        base = head + V(s * hr * 0.55, hr * 0.1, hr * 0.62)
        tip = base + V(s * hr * 0.3, hr * 0.2, hr * L)
    return [base, base.lerp(tip, 0.5), tip]


def tail_points(r):
    """The tail's centre line, as features.organic() builds it (None when the creature has no tail)."""
    b, look = r["body"], r["look"]
    if b.tail_root is None:
        return None
    tails = [p for p in look.parts if p.startswith("tail") or p in ("stinger", "rattle_tail")]
    tail_len = b.P.get("tail", 1.0)
    if tail_len is True:
        tail_len = 1.0
    if not (tails or (b.kind in ("quad", "bird") and tail_len) or (b.kind == "biped" and b.P.get("tail") is True)):
        return None
    kind = tails[0] if tails else ("tail_bushy" if look.style.startswith("fur") and b.kind == "quad" else "tail")
    L = {"tail_thin": 0.45, "stinger": 0.4, "tail_plumes": 0.25}.get(kind, 0.38) * (1.4 if b.kind == "biped" else 1.0)
    L *= float(tail_len) if not isinstance(tail_len, bool) else 1.0
    if L < 0.05:
        return None
    td = b.tail_dir.normalized()
    r0 = b.torso_r * (0.3 if kind != "tail_thin" else 0.15)
    if kind == "tail_bushy" and b.torso_r < 0.17 and b.kind == "quad" and b.head_r > 0.13:  # rabbit puff
        return [b.tail_root, b.tail_root + td * r0 * 2.0]
    return features.curve(b.tail_root, td, L, 0.6 if b.kind == "quad" else 0.2, 7, (0, 0, 1))


def place_bones(rig, r):
    """Returns {bone: (head, tail)} in the creature's normalised body units, plus notes."""
    b = r["body"]
    tmpl = rig["bones"]
    T = {x["name"]: (V(x["head"]), V(x["tail"])) for x in tmpl}
    parent = {x["name"]: x.get("parent") for x in tmpl}
    pos, notes = {}, []
    maps = {}

    def put(name, h, t):
        if name in T:
            pos[name] = (V(h), V(t))

    def chain(names, pts):
        names = [n for n in names if n in T]
        if not names:
            return
        ps = polyline_split(pts, len(names)) if len(pts) != len(names) + 1 else [V(p) for p in pts]
        for i, n in enumerate(names):
            put(n, ps[i], ps[i + 1])

    def side_of(points, s):
        return [p for p in points if (p.x > 0) == (s > 0)]

    hr = b.head_r
    eyes = list(b.eye_points()) if b.eye_count else []
    head_tip = None
    key = rig["key"]
    generic = bbox_map(tmpl, r["verts"])

    if b.kind == "blob" and key == "blob":
        top = float(r["verts"][:, 2].max())
        rad = float(np.abs(r["verts"][:, :2]).max())
        put("root", (0, 0, 0), (0, -0.15, 0))
        put("core", (0, 0, 0.05), (0, 0, top * 0.48))
        put("crown", (0, 0, top * 0.48), (0, 0.03, top * 0.97))
        put("inner_item", (0, 0, top * 0.33), (0, 0, top * 0.44))
        for n, d in (("lobe_front", (0, -1, 0)), ("lobe_back", (0, 1, 0)), ("lobe_L", (1, 0, 0)), ("lobe_R", (-1, 0, 0))):
            d = V(d)
            put(n, d * rad * 0.2 + V(0, 0, top * 0.28), d * rad * 0.88 + V(0, 0, top * 0.18))
        m = V(b.mouth)
        put("mouth", m + V(0, 0.09, 0.02), m + V(0, -0.02, -0.01))
        maps["*"] = generic
    elif b.kind == "biped" and b.hips and b.shoulders:
        hips = [V(p) for p in b.hips]
        hip_c = (hips[0] + hips[1]) / 2
        neck = V(b.neck)
        head = V(b.head)
        head_base = neck.lerp(head, 0.45)
        head_top = head + V(0, 0, hr)
        torso = sim(T["pelvis"][0], T["neck"][0] if "neck" in T else T["chest"][1], hip_c + V(0, 0, 0.02), neck)
        for n in ("pelvis", "spine_01", "spine_02", "spine_03", "chest"):
            maps[n] = torso
        if "neck" in T:
            put("neck", neck, head_base)
        put("head", head_base, head_top)
        head_tip = head_top
        maps["head"] = sim(T["head"][0], T["head"][1], head_base, head_top)
        for s, sfx in ((1, "_L"), (-1, "_R")):
            hip = side_of(hips, s)[0]
            foot = side_of([V(p) for p in b.feet], s)[0]
            leg = sim(T["thigh" + sfx][0], T["foot" + sfx][0], hip, foot)
            for n in ("thigh", "calf", "foot", "toe"):
                maps[n + sfx] = leg
            sh = side_of([V(p) for p in b.shoulders], s)[0]
            hand = side_of([V(p) for p in b.hands], s)[0]
            hand_t = (T["hand" + sfx][0] + T["hand" + sfx][1]) / 2
            arm = sim(T["upperarm" + sfx][0], hand_t, sh, hand)
            for n in ("upperarm", "forearm", "hand", "thumb_01", "fingers_01", "weapon"):
                maps[n + sfx] = arm
            if "clavicle" + sfx in T:
                put("clavicle" + sfx, V(sh.x * 0.15, sh.y, sh.z + 0.01), sh)
        if b.hands:  # generate puts the weapon in hands[-1]
            wh = V(b.hands[-1])
            sfx = "_L" if wh.x > 0 else "_R"
            if "weapon" + sfx in T:
                put("weapon" + sfx, wh, wh + V(0, -0.35, 1).normalized() * hr * 0.6)
                notes.append("weapon mesh is in hand%s (generator puts it in hands[-1])" % sfx)
    elif b.kind == "quad":
        br = b.torso_r
        sp = [V(p) for p in b.spine]
        zc = sp[1].z - br * 0.9
        yc, yh = sp[1].y, sp[3].y
        neck0 = V(0, yc - br * 0.55, zc + br * 0.35)
        head = V(b.head)
        head_base = head + (neck0 - head).normalized() * hr * 0.55
        if b.snout is not None:
            sn = b.P.get("snout", 0)
            head_tip = V(b.snout) + V(0, -hr * (0.35 + 0.42 * sn), 0)
        else:
            head_tip = head + b.face.normalized() * hr
        pelvis0 = V(0, yh + br * 0.45, zc + br * 0.1)
        torso = sim(T["pelvis"][0], T["chest"][1], pelvis0, neck0)
        for n in ("pelvis", "spine_01", "spine_02", "chest", "belly"):
            maps[n] = torso
        necks = [n for n in ("neck_01", "neck_02", "neck_03") if n in T]
        chain(necks, [neck0, head_base])
        put("head", head_base, head_tip)
        maps["head"] = sim(T["head"][0], T["head"][1], head_base, head_tip)
        if "mane_01" in T:
            chain(["mane_01", "mane_02"], [neck0.lerp(head_base, 0.4) + V(0, 0, br * 0.55), sp[1] + V(0, 0, -br * 0.12)])
        legf, low = b.P.get("leg", 1.0), b.P.get("low", False)
        small = key == "quad_small" or br >= 0.149 and hr >= 0.149
        lg = zc - br * 0.85
        feet = [V(p) for p in b.feet]
        mid_y = (yc + yh) / 2
        for s, sfx in ((1, "_L"), (-1, "_R")):
            fs = side_of(feet, s)
            front = min(fs, key=lambda p: p.y)
            hind = max(fs, key=lambda p: p.y)
            hips_s = side_of([V(p) for p in b.hips], s)
            fh = min(hips_s, key=lambda p: p.y)
            # front leg: scapula, upperarm (hip -> elbow), forearm, front_foot, front_toe
            elbow = V(front.x, fh.y - 0.01, lg * 0.55 + (0.03 if low else 0))
            wrist = elbow.lerp(front, 0.78)
            toe_f = V(front.x, front.y - br * 0.55, 0.006)
            put("scapula" + sfx, V(s * abs(fh.x) * 0.4, fh.y + br * 0.1, zc + br * 0.45), fh)
            put("upperarm" + sfx, fh, elbow)
            put("forearm" + sfx, elbow, wrist)
            put("front_foot" + sfx, wrist, front)
            put("front_toe" + sfx, front, toe_f)
            hind_hips = [p for p in hips_s if p.y > mid_y]
            if hind_hips:  # hind leg as the generator built it: hip -> knee -> foot
                hh = hind_hips[0]
                knee = V(hind.x, hh.y + 0.06 * legf, lg * 0.5)
                hock = knee.lerp(hind, 0.7)
                put("thigh" + sfx, hh, knee)
                put("calf" + sfx, knee, hock)
                put("hind_foot" + sfx, hock, hind)
                put("hind_toe" + sfx, hind, V(hind.x, hind.y - br * 0.55, 0.006))
            else:  # rabbits: a haunch and a long hind foot flat on the ground
                hy = hind.y + br * 0.45
                hh = V(hind.x, hy, zc - br * 0.15)
                knee = V(hind.x, hy - br * 0.4, zc - br * 0.95)
                heel = V(hind.x, hind.y + br * 0.75, 0.045)
                ball = V(hind.x, hind.y - br * 0.25, 0.028)
                put("thigh" + sfx, hh, knee)
                put("calf" + sfx, knee, heel)
                put("hind_foot" + sfx, heel, ball)
                put("hind_toe" + sfx, ball, V(hind.x, hind.y - br * 0.8, 0.016))
                notes.append("rabbit hind legs: haunch + flat hind foot")
        if "tusk_L" in T and b.mouth is not None:
            for s, sfx in ((1, "_L"), (-1, "_R")):
                m = V(b.mouth) + V(s * hr * 0.3, 0, 0)
                put("tusk" + sfx, m, m + V(s * hr * 0.25, -hr * 0.4, hr * 0.5))
        maps["*"] = torso
    else:
        notes.append("no landmark placement for kind=%s rig=%s: template box-fitted to the body" % (b.kind, key))
        maps["*"] = generic

    # shared: tail, ears, eyes, jaw, root
    tp = tail_points(r)
    tails = [n for n in ("tail_01", "tail_02", "tail_03", "tail_04", "tail_05") if n in T]
    if tails:
        if tp:
            chain(tails, tp)
        elif b.tail_root is not None:
            chain(tails, [V(b.tail_root), V(b.tail_root) + b.tail_dir.normalized() * b.torso_r * 0.6])
            notes.append("no tail mesh: tail bones are a stub")
    ek = ear_kind(r)
    for s, sfx in ((1, "_L"), (-1, "_R")):
        ep = ear_points(V(b.head), hr, ek, s)
        if ep and "ear_01" + sfx in T:
            chain(["ear_01" + sfx, "ear_02" + sfx], ep)
    for p, d, er in eyes[:2]:
        sfx = "_L" if p.x > 0 else "_R"
        put("eye" + sfx, p, p + d * max(er * 1.2, hr * 0.12))
    if "jaw" in T and b.mouth is not None:
        put("jaw", V(b.head) + V(0, -hr * 0.1, -hr * 0.35), V(b.mouth) + V(0, 0, -hr * 0.05))
    put("root", (0, 0, 0), (0, -0.15, 0))

    # every bone not placed yet: its own map, else its nearest mapped ancestor's, else the default
    for x in tmpl:
        n = x["name"]
        if n in pos:
            continue
        m, p = None, n
        while p and m is None:
            m = maps.get(p)
            p = parent.get(p)
        m = m or maps.get("*", generic)
        pos[n] = (m(T[n][0]), m(T[n][1]))
    # keep template connections: a child that starts at its parent's tail still does
    for x in tmpl:
        n, pa = x["name"], x.get("parent")
        if pa and (T[n][0] - T[pa][1]).length < 1e-4:
            pos[n] = (pos[pa][1].copy(), pos[n][1])
    for n, (h, t) in pos.items():
        if (t - h).length < 1e-4:
            pos[n] = (h, h + V(0, 0, 0.01))
    for n in pos:  # nothing below the ground
        h, t = pos[n]
        pos[n] = (V(h.x, h.y, max(h.z, 0.0)), V(t.x, t.y, max(t.z, 0.0)))
    return pos, notes


def build_rig_for(rig, pos, scale, size):
    """build_rig.build_armature with our positions (it multiplies by size, so pass positions / size)."""
    bones = []
    for x in rig["bones"]:
        y = dict(x)
        h, t = pos[x["name"]]
        y["head"] = list(h * (scale / size))
        y["tail"] = list(t * (scale / size))
        bones.append(y)
    rr = dict(rig)
    rr["bones"] = bones
    arm, col = build_rig.build_armature(rr, size)
    arm["ascend_build_size"] = size
    arm["ascend_rigged_from"] = "Tools/blender/rig_creature.py"
    return arm, col


# --------------------------------------------------------------------------------------------------- skinning
def mesh_co(me):
    a = np.empty(len(me.vertices) * 3, dtype=np.float64)
    me.vertices.foreach_get("co", a)
    return a.reshape(-1, 3)


def deform_bones(arm):
    return [bn for bn in arm.data.bones if bn.use_deform]


def seg_dist(P, bones):
    """Distance from each point to each bone segment (armature space = world space here)."""
    D = np.empty((len(P), len(bones)))
    for j, bn in enumerate(bones):
        a, c = np.array(bn.head_local), np.array(bn.tail_local)
        ab = c - a
        t = np.clip(((P - a) @ ab) / max(ab @ ab, 1e-12), 0, 1)
        D[:, j] = np.linalg.norm(P - (a + t[:, None] * ab), axis=1)
    return D


def distance_weights(P, bones):
    D = seg_dist(P, bones)
    W = 1.0 / np.maximum(D, 1e-4) ** 4
    keep = np.argsort(-W, axis=1)[:, :2]
    M = np.zeros_like(W)
    rows = np.arange(len(P))[:, None]
    M[rows, keep] = W[rows, keep]
    return M / M.sum(1, keepdims=True)


def heat_weights(arm, skin_co, faces, size):
    """Bone heat on a decimated copy of the skin. Returns (proxy points, weights [n, bones], unweighted count)."""
    me = bpy.data.meshes.new("skin_proxy")
    me.vertices.add(len(skin_co))
    me.vertices.foreach_set("co", skin_co.astype(np.float32).ravel())
    nf = len(faces)
    me.loops.add(nf * 3)
    me.loops.foreach_set("vertex_index", faces.astype(np.int32).ravel())
    me.polygons.add(nf)
    me.polygons.foreach_set("loop_start", np.arange(0, nf * 3, 3, dtype=np.int32))
    me.update(calc_edges=True)
    proxy = bpy.data.objects.new("skin_proxy", me)
    bpy.context.scene.collection.objects.link(proxy)
    dec = proxy.modifiers.new("dec", "DECIMATE")
    dec.ratio = min(1.0, PROXY_FACES / max(1, nf))
    build_rig._select_only([proxy], proxy)
    bpy.ops.object.modifier_apply(modifier=dec.name)
    # heat weighting is unreliable on very small meshes: weight at about 1.5 m, then put the scale back
    k = 1.5 / max(size, 1e-3)
    arm.scale = (k, k, k)
    proxy.scale = (k, k, k)
    bpy.context.view_layer.update()
    bones = deform_bones(arm)
    ok = True
    try:
        build_rig._select_only([proxy, arm], arm)
        bpy.ops.object.parent_set(type="ARMATURE_AUTO")
    except RuntimeError as e:
        print("[rig] heat weighting failed:", e)
        ok = False
    arm.scale = (1, 1, 1)
    proxy.parent = None
    proxy.scale = (1, 1, 1)
    bpy.context.view_layer.update()
    P = mesh_co(proxy.data)
    W = np.zeros((len(P), len(bones)))
    if ok:
        idx = {proxy.vertex_groups[bn.name].index: j for j, bn in enumerate(bones) if bn.name in proxy.vertex_groups}
        for v in proxy.data.vertices:
            for g in v.groups:
                j = idx.get(g.group)
                if j is not None:
                    W[v.index, j] = g.weight
    empty = W.sum(1) < 1e-6
    if empty.any():
        W[empty] = distance_weights(P[empty], bones)
    # a few Laplacian passes soften the joints (heat weights crease sharply on chibi proportions)
    e = np.empty(len(proxy.data.edges) * 2, dtype=np.int64)
    proxy.data.edges.foreach_get("vertices", e)
    e = e.reshape(-1, 2)
    deg = np.bincount(e.ravel(), minlength=len(P)).astype(float)[:, None]
    for _ in range(SMOOTH_PASSES):
        acc = np.zeros_like(W)
        np.add.at(acc, e[:, 0], W[e[:, 1]])
        np.add.at(acc, e[:, 1], W[e[:, 0]])
        W = np.where(deg > 0, 0.5 * W + 0.5 * acc / np.maximum(deg, 1), W)
    bpy.data.objects.remove(proxy)
    bpy.data.meshes.remove(me)
    return P, W, int(empty.sum()), ok


def limit4(W):
    if W.shape[1] > 4:
        cut = np.argsort(-W, axis=1)[:, 4:]
        np.put_along_axis(W, cut, 0.0, axis=1)
    s = W.sum(1, keepdims=True)
    return W / np.maximum(s, 1e-9)


def islands(me, start):
    """Connected-component label for every vertex index >= start (hard parts)."""
    n = len(me.vertices)
    e = np.empty(len(me.edges) * 2, dtype=np.int64)
    me.edges.foreach_get("vertices", e)
    e = e.reshape(-1, 2)
    e = e[(e[:, 0] >= start) & (e[:, 1] >= start)]
    lab = np.arange(n)
    while True:
        m = np.minimum(lab[e[:, 0]], lab[e[:, 1]])
        new = lab.copy()
        np.minimum.at(new, e[:, 0], m)
        np.minimum.at(new, e[:, 1], m)
        new = new[new]
        if np.array_equal(new, lab):
            break
        lab = new
    return lab


def skin(obj, arm, r, size):
    me = obj.data
    co = mesh_co(me)
    n_body = len(r["verts"])
    bones = deform_bones(arm)
    t0 = time.time()
    P, Wp, empty, heat_ok = heat_weights(arm, co[:n_body], r["faces"], size)
    t_heat = time.time() - t0
    kd = kdtree.KDTree(len(P))
    for i, p in enumerate(P):
        kd.insert(p, i)
    kd.balance()
    W = np.zeros((len(co), len(bones)))
    for i in range(n_body):  # nearest 3 proxy vertices, inverse-distance blend
        hits = kd.find_n(co[i], 3)
        ws = np.array([1.0 / max(d, 1e-6) for _, _, d in hits])
        W[i] = (ws[:, None] * Wp[[h[1] for h in hits]]).sum(0) / ws.sum()
    W[:n_body] = limit4(W[:n_body])
    # hard parts: each island is rigid, with the weights of the skin vertex it sits closest to
    n_isl = 0
    if len(co) > n_body:
        lab = islands(me, n_body)
        kb = kdtree.KDTree(n_body)
        for i in range(n_body):
            kb.insert(co[i], i)
        kb.balance()
        hard = np.arange(n_body, len(co))
        order = np.argsort(lab[hard], kind="stable")
        labs = lab[hard][order]
        cuts = np.flatnonzero(np.diff(labs)) + 1
        for grp in np.split(hard[order], cuts):
            best, bi = 1e9, 0
            for v in grp[:: max(1, len(grp) // 200)]:
                _, j, d = kb.find(co[v])
                if d < best:
                    best, bi = d, j
            W[grp] = W[bi]
            n_isl += 1
    # write vertex groups, batched by quantised weight
    for vg in list(obj.vertex_groups):
        obj.vertex_groups.remove(vg)
    for j, bn in enumerate(bones):
        col = W[:, j]
        nz = np.flatnonzero(col > 1.0 / 512)
        if not len(nz):
            continue
        vg = obj.vertex_groups.new(name=bn.name)
        q = np.round(col[nz] * 255).astype(int)
        for val in np.unique(q):
            vg.add(nz[q == val].tolist(), float(val) / 255.0, "REPLACE")
    obj.parent = arm
    obj.matrix_parent_inverse.identity()
    mod = obj.modifiers.new("Armature", "ARMATURE")
    mod.object = arm
    unused = [bn.name for j, bn in enumerate(bones) if W[:, j].max() < 0.05]
    return dict(heat_ok=heat_ok, heat_s=round(t_heat, 1), proxy_verts=len(P), heat_unweighted=empty, islands=n_isl,
                weightless_bones=unused, W=W, bones=[bn.name for bn in bones])


# ------------------------------------------------------------------------------------------------ shape keys
def smooth(x):
    x = np.clip(x, 0, 1)
    return x * x * (3 - 2 * x)


def falloff(co, c, R):
    return smooth(1 - np.linalg.norm(co - np.array(c), axis=1) / R)


def add_shape_keys(obj, r, scale, skin_info, rig):
    me = obj.data
    b = r["body"]
    co = mesh_co(me)
    n = len(co)
    wanted = rig.get("blendShapes", [])
    hr = b.head_r * scale
    done = {}
    head = np.array(b.head) * scale
    mouth = np.array(b.mouth if b.mouth is not None else b.head) * scale
    eyes = [(np.array(p) * scale, np.array(d), er * scale) for p, d, er in (b.eye_points() if b.eye_count else [])]
    lab = islands(me, len(r["verts"])) if n > len(r["verts"]) else np.arange(n)
    hard_ids = np.unique(lab[len(r["verts"]):]) if n > len(r["verts"]) else []

    def eye_mask(side):
        m = np.zeros(n, dtype=bool)
        for p, d, er in eyes:
            if (p[0] > 0) != (side > 0):
                continue
            for i in hard_ids:
                vs = lab == i
                c = co[vs].mean(0)
                if np.linalg.norm(c - p) < er * 1.8:
                    m |= vs
        return m, [(p, d, er) for p, d, er in eyes if (p[0] > 0) == (side > 0)]

    def blink(side):
        m, es = eye_mask(side)
        if not m.any() or not es:
            return None
        p, d, er = es[0]
        up = np.array([0.0, 0.0, 1.0]) - d * d[2]
        up /= np.linalg.norm(up)
        out = co.copy()
        c = co[m].mean(0)
        out[m] -= np.outer((co[m] - c) @ up, up) * 0.88
        return out

    def region(c, R, delta, mask=None):
        w = falloff(co, c, R)
        if mask is not None:
            w = w * mask
        return co + w[:, None] * np.array(delta)

    zmid = co[:, 2].max() * 0.5
    below = smooth((mouth[2] - co[:, 2]) / max(hr * 0.3, 1e-6) + 0.5)  # soft, so no shear along the mouth line
    above = 1.0 - below
    lateral = np.clip(np.abs(co[:, 0] - mouth[0]) / max(hr * 0.5, 1e-6), 0, 1)
    for name in wanted:
        out = None
        if name == "squash":
            out = co * np.array([1.35, 1.35, 0.5])
        elif name == "stretch":
            out = co * np.array([0.82, 0.82, 1.5])
        elif name == "puff":
            out = co * 1.15
        elif name == "split_pinch":
            R = max(float(np.abs(co[:, 0]).max()), 1e-6)
            f = np.exp(-(co[:, 0] / (0.3 * R)) ** 2)
            out = co * np.stack([np.ones(n), 1 - 0.45 * f, 1 - 0.25 * f], 1)
        elif name in ("blink_L", "blink_R"):
            out = blink(1 if name.endswith("_L") else -1)
        elif name in ("mouth_open", "roar"):
            w = falloff(co, mouth, hr * (0.7 if name == "mouth_open" else 0.9)) * below
            out = co + w[:, None] * np.array([0, 0.1 * hr, -0.35 * hr])
        elif name in ("smile", "grin"):
            w = falloff(co, mouth, hr * 0.6) * lateral
            out = co + w[:, None] * np.array([0, 0.06 * hr, 0.18 * hr])
        elif name in ("frown", "fear"):
            w = falloff(co, mouth, hr * 0.6) * lateral
            out = co + w[:, None] * np.array([0, 0, -0.16 * hr])
            if name == "fear":  # brows up too
                for p, d, er in eyes:
                    out = out + (falloff(co, p + np.array([0, 0, er * 1.3]), er * 2.2)[:, None] * np.array([0, 0, 0.12 * hr]))
        elif name in ("snarl", "snort"):
            c = mouth + np.array([0, 0.05 * hr, 0.2 * hr])
            out = region(c, hr * 0.55, (0, 0.06 * hr, 0.16 * hr), above)
        elif name == "nose_twitch":
            tip = np.array(b.snout if b.snout is not None else b.head) * scale + np.array([0, -hr * 0.4, 0])
            out = region(tip, hr * 0.45, (0, -0.04 * hr, 0.1 * hr))
        elif name == "ears_back":
            W, names = skin_info["W"], skin_info["bones"]
            out = co.copy()
            for sfx in ("_L", "_R"):
                js = [names.index(x + sfx) for x in ("ear_01", "ear_02") if x + sfx in names]
                if not js:
                    continue
                w = W[:, js].sum(1)
                piv = np.array(obj.parent.data.bones["ear_01" + sfx].head_local)
                q = Quaternion((1, 0, 0), math.radians(-55)).to_matrix()
                rot = (co - piv) @ np.array(q).T + piv
                out = out + w[:, None] * (rot - co)
        if out is None:
            continue
        done[name] = out
    if not done:
        return []
    if not me.shape_keys:
        obj.shape_key_add(name="Basis", from_mix=False)
    for name, out in done.items():
        k = obj.shape_key_add(name=name, from_mix=False)
        k.data.foreach_set("co", out.astype(np.float32).ravel())
    return list(done)


# ------------------------------------------------------------------------------------------------------ poses
POSES = {  # bone: [(world axis, degrees), ...]; "_shapes": {key: value}; FK with IK muted. +X tips a bone forward.
    "blob": {
        "test_telegraph": {"core": [("X", 14)], "crown": [("X", -26)], "lobe_front": [("X", 12)], "lobe_L": [("Y", -12)],
                           "lobe_R": [("Y", 12)], "_shapes": {"squash": 0.6, "frown": 0.8}},
        "test_idle": {"crown": [("Y", 16)], "core": [("Y", -5)], "lobe_back": [("X", 10)], "_shapes": {"stretch": 0.25, "smile": 1.0, "blink_R": 1.0}},
    },
    "small_biped": {
        "test_telegraph": {"spine_01": [("X", 10)], "spine_02": [("X", 12)], "chest": [("Z", 25)], "head": [("X", -12), ("Z", -18)],
                           "upperarm_L": [("X", 50), ("Y", -15)], "forearm_L": [("X", -75)], "hand_L": [("X", -20)],
                           "upperarm_R": [("X", -35), ("Y", 20)], "forearm_R": [("X", -35)],
                           "thigh_L": [("X", 30)], "calf_L": [("X", -45)], "foot_L": [("X", 15)],
                           "thigh_R": [("X", -35)], "calf_R": [("X", -40)], "foot_R": [("X", 20)],
                           "ear_01_L": [("X", -25)], "ear_01_R": [("X", -25)], "jaw": [("X", 14)],
                           "_shapes": {"snarl": 1.0}},
        "test_idle": {"pelvis": [("Y", 6)], "spine_02": [("Y", -6)], "head": [("Y", 12), ("Z", 15)],
                      "upperarm_R": [("X", -10), ("Y", 10)], "forearm_R": [("X", -20)], "upperarm_L": [("X", 8)], "forearm_L": [("X", -30)],
                      "thigh_R": [("X", -8)], "calf_R": [("X", -14)], "ear_01_L": [("Y", 20)], "ear_02_R": [("Z", -20)],
                      "_shapes": {"grin": 1.0, "blink_L": 1.0}},
    },
    "quad_small": {
        "test_telegraph": {"spine_02": [("X", 10)], "chest": [("X", 10)], "neck_01": [("X", 30)], "head": [("X", 12)],
                           "upperarm_L": [("X", -25)], "forearm_L": [("X", 35)], "upperarm_R": [("X", -25)], "forearm_R": [("X", 35)],
                           "thigh_L": [("X", -15)], "thigh_R": [("X", -15)], "ear_01_L": [("X", -55)], "ear_01_R": [("X", -55)],
                           "_shapes": {"mouth_open": 0.5}},
        "test_idle": {"pelvis": [("X", -28)], "thigh_L": [("X", 30)], "thigh_R": [("X", 30)], "neck_01": [("X", 8)], "head": [("X", 10)],
                      "upperarm_L": [("X", 35)], "upperarm_R": [("X", 30)], "forearm_L": [("X", -40)],
                      "ear_01_L": [("Y", 10)], "ear_01_R": [("X", 15)], "_shapes": {"nose_twitch": 1.0}},
    },
    "quad_medium": {
        "test_telegraph": {"spine_02": [("X", 8)], "chest": [("X", 8)], "neck_01": [("X", 18)], "head": [("X", -14)], "jaw": [("X", 22)],
                           "upperarm_L": [("X", -30)], "forearm_L": [("X", 45)], "upperarm_R": [("X", -30)], "forearm_R": [("X", 45)],
                           "thigh_L": [("X", -22)], "calf_L": [("X", 30)], "thigh_R": [("X", -22)], "calf_R": [("X", 30)],
                           "tail_01": [("X", 18)], "_shapes": {"snarl": 1.0, "ears_back": 1.0}},
        "test_idle": {"neck_01": [("X", 30)], "neck_02": [("X", 12)], "head": [("X", 20)], "tail_01": [("X", -12)], "tail_02": [("Z", 15)],
                      "tail_03": [("Z", 15)], "upperarm_L": [("X", 12)], "forearm_L": [("X", -25)], "ear_01_L": [("X", 15)], "ear_01_R": [("X", 15)]},
    },
}
POSES["quad_large"] = POSES["quad_medium"]
POSES["medium_biped"] = POSES["large_biped"] = POSES["small_biped"]


def mesh_world(obj):
    dg = bpy.context.evaluated_depsgraph_get()
    ev = obj.evaluated_get(dg)
    me = ev.to_mesh()
    co = mesh_co(me)
    ev.to_mesh_clear()
    return co


def clear_pose(arm, obj):
    for pb in arm.pose.bones:
        pb.rotation_mode = "QUATERNION"
        pb.rotation_quaternion = (1, 0, 0, 0)
        pb.location = (0, 0, 0)
        for c in pb.constraints:
            if c.type == "IK":
                c.influence = 1.0
    if obj.data.shape_keys:
        for k in obj.data.shape_keys.key_blocks[1:]:
            k.value = 0.0
    bpy.context.view_layer.update()


def apply_pose(arm, obj, spec):
    clear_pose(arm, obj)
    for pb in arm.pose.bones:
        for c in pb.constraints:
            if c.type == "IK":
                c.influence = 0.0
    for name, rots in spec.items():
        if name == "_shapes":
            continue
        pb = arm.pose.bones.get(name)
        if not pb:
            continue
        inv = pb.bone.matrix_local.to_3x3().inverted()
        q = Quaternion()
        for ax, deg in rots:
            w = {"X": V(1, 0, 0), "Y": V(0, 1, 0), "Z": V(0, 0, 1)}[ax]
            q = Quaternion((inv @ w).normalized(), math.radians(deg)) @ q
        pb.rotation_quaternion = q
    if obj.data.shape_keys:
        for k, v in spec.get("_shapes", {}).items():
            kb = obj.data.shape_keys.key_blocks.get(k)
            if kb:
                kb.value = v
    bpy.context.view_layer.update()
    # keep it standing on the ground: move the root so the lowest vertex is back at z = 0
    rest_min = float(obj.get("_rest_min_z", 0.0))
    dz = rest_min - float(mesh_world(obj)[:, 2].min())
    root = arm.pose.bones.get("root")
    if root:
        root.location = root.bone.matrix_local.to_3x3().inverted() @ V(0, 0, dz)
    bpy.context.view_layer.update()


def key_pose(arm, obj, name):
    for pb in arm.pose.bones:
        pb.keyframe_insert("rotation_quaternion", frame=1, group=pb.name)
        pb.keyframe_insert("location", frame=1, group=pb.name)
        for c in pb.constraints:
            if c.type == "IK":
                c.keyframe_insert("influence", frame=1)
    act = arm.animation_data.action
    act.name = name
    act.use_fake_user = True
    arm.animation_data.action = None
    if obj.data.shape_keys:
        sk = obj.data.shape_keys
        for k in sk.key_blocks[1:]:
            k.keyframe_insert("value", frame=1)
        if sk.animation_data and sk.animation_data.action:
            sk.animation_data.action.name = name + "_shapes"
            sk.animation_data.action.use_fake_user = True
            sk.animation_data.action = None


def deformation_check(obj, rest, faces_edges, size):
    co = mesh_world(obj)
    disp = np.linalg.norm(co - rest, axis=1)
    e = faces_edges
    lr = np.linalg.norm(rest[e[:, 0]] - rest[e[:, 1]], axis=1)
    lp = np.linalg.norm(co[e[:, 0]] - co[e[:, 1]], axis=1)
    ratio = lp / np.maximum(lr, 1e-7)
    return dict(max_move=round(float(disp.max() / size), 3), max_edge_stretch=round(float(ratio.max()), 2),
                edges_over_3x=int((ratio > 3).sum()), nan=bool(np.isnan(co).any()))


# ------------------------------------------------------------------------------------------------------- main
def rig_one(sid, rigs, detail, out_dir, save, tiles_dir, rig_override=None):
    bpy.ops.wm.read_factory_settings(use_empty=True)
    t0 = time.time()
    obj, r, scale, size = generate_with_body(sid, detail)
    key, via = (rig_override, "--rig") if rig_override else rig_key_for(sid, r["species"])
    rig = rigs[key]
    pos, notes = place_bones(rig, r)
    arm, col = build_rig_for(rig, pos, scale, size)
    for c in list(obj.users_collection):
        c.objects.unlink(obj)
    col.objects.link(obj)
    col.name = sid
    info = skin(obj, arm, r, size)
    keys = add_shape_keys(obj, r, scale, info, rig)
    rest = mesh_co(obj.data)
    obj["_rest_min_z"] = float(rest[:, 2].min())
    obj["ascend_rig"] = key
    obj["ascend_shape_keys"] = ",".join(keys)
    e = np.empty(len(obj.data.edges) * 2, dtype=np.int64)
    obj.data.edges.foreach_get("vertices", e)
    e = e.reshape(-1, 2)
    checks = {}
    poses = POSES.get(key, {})
    arm.animation_data_create()
    for pname, spec in poses.items():
        apply_pose(arm, obj, spec)
        checks[pname] = deformation_check(obj, rest, e, size)
        key_pose(arm, obj, pname)
    clear_pose(arm, obj)
    path = None
    if save:
        os.makedirs(out_dir, exist_ok=True)
        path = os.path.join(out_dir, sid + ".blend")
        bpy.ops.wm.save_as_mainfile(filepath=path, compress=True, copy=True)
    # tiles: rest, telegraph, idle from one camera
    tiles = []
    if tiles_dir:
        preview.setup()
        bpy.context.scene.render.film_transparent = False
        yaw = -32 if r["body"].kind in ("blob", "biped") else -58
        preview.camera([obj], yaw=yaw, pitch=14, margin=1.45)
        for pname in ["rest"] + list(poses):
            if pname == "rest":
                clear_pose(arm, obj)
            else:
                apply_pose(arm, obj, poses[pname])
            p = os.path.join(tiles_dir, "%s_%s.png" % (sid, pname))
            preview.render(p, TILE, 24)
            tiles.append(p)
        clear_pose(arm, obj)
    rep = dict(species=sid, rig=key, rig_via=via, species_rigId=r["species"].get("rigId"), size_m=size, scale=round(scale, 4),
               bones=len(arm.data.bones), rig_bones=len(rig["bones"]), deform=len(info["bones"]), verts=len(obj.data.vertices),
               heat_ok=info["heat_ok"], heat_s=info["heat_s"], proxy_verts=info["proxy_verts"], heat_unweighted=info["heat_unweighted"],
               rigid_islands=info["islands"], weightless_bones=info["weightless_bones"], shape_keys=keys,
               missing_shape_keys=[k for k in rig.get("blendShapes", []) if k not in keys], checks=checks, notes=notes,
               file=path, file_mb=round(os.path.getsize(path) / 1e6, 1) if path else None, seconds=round(time.time() - t0, 1))
    print("[rig] " + json.dumps(rep))
    return rep, tiles


TILE = (520, 420)


def compose(rows, path):
    cols = max(len(t) for t in rows)
    W, H = TILE
    sheet = np.ones((len(rows) * H, cols * W, 4), dtype=np.float32)
    for ri, tl in enumerate(rows):
        for ci, p in enumerate(tl):
            img = bpy.data.images.load(p, check_existing=False)
            px = np.array(img.pixels[:], dtype=np.float32).reshape(H, W, 4)
            bpy.data.images.remove(img)
            y0 = (len(rows) - 1 - ri) * H
            sheet[y0:y0 + H, ci * W:(ci + 1) * W] = px
    out = bpy.data.images.new("rig_sheet", cols * W, len(rows) * H, alpha=False)
    out.pixels[:] = sheet.ravel()
    out.filepath_raw = path
    out.file_format = "PNG"
    out.save()


def main():
    ids = arg("--ids")
    ids = ids.split(",") if isinstance(ids, str) else RING0
    detail = arg("--detail", "high")
    out_dir = arg("--out", os.path.join(ROOT, "Art", "Blender", "Rigged"))
    sheet = None if arg("--no-sheet") else arg("--sheet", os.path.join(ROOT, "13_Production", "screenshots", "rigged_ring0.png"))
    rig_override = arg("--rig")
    rigs = load_rigs()
    tiles_dir = tempfile.mkdtemp(prefix="ascend_rig_") if sheet else None
    reps, rows = [], []
    for sid in ids:
        rep, tiles = rig_one(sid, rigs, detail, out_dir, not arg("--no-save"), tiles_dir, rig_override)
        reps.append(rep)
        rows.append(tiles)
    if sheet:
        bpy.ops.wm.read_factory_settings(use_empty=True)
        os.makedirs(os.path.dirname(sheet), exist_ok=True)
        compose(rows, sheet)
        print("[rig] contact sheet %s (rows: %s; columns: rest, telegraph, idle)" % (sheet, ", ".join(ids)))
    print("[rig] SUMMARY " + json.dumps(reps))


if __name__ == "__main__":
    main()
