"""
Builds one human from a variant (see spec.py):

    from ascend_characters import generate
    ch = generate.character("human_female_base")                       # an id from Data/Characters/human_library.json
    ch = generate.character({"body": "human_male_base", "seed": 7, "heightM": 1.8, "build": "sturdy", ...})
    ch["parts"]      {"body", "eyes", "brows", "mouth", "ears", "hair", "top", "bottom", ...} mesh objects (separate, swappable)
    ch["armature"]   the humanoid armature, all parts skinned to it, in the T-pose
    ch["hash"]       hash of every part's vertices: the same spec always gives the same hash

Parts are objects named <id>_<part>. Colours are per-vertex ('Col'); materials are the CH_* categories.
"""
import time

import bmesh
import bpy
import numpy as np

from . import body as B
from . import face as F
from . import layout as LY
from . import materials as MT
from . import meshio as M
from . import rig as R
from . import spec as S
from .spec import hex_lin


def paint_skin(obj, L, skin, blush):
    """Per-vertex skin colour with a soft blush on the cheeks, nose tip, ears and joints (position rules only)."""
    co = M.co(obj)
    H = L.H
    base = np.array(hex_lin(skin["hex"]))
    bl = np.array(hex_lin(skin["blush"]))
    m = np.zeros(len(co))
    zc = LY.Z[LY.EYE_RING] * H
    for sx in (1, -1):
        d = np.sqrt(((co[:, 0] - sx * 0.032 * H) / (0.022 * H)) ** 2 + ((co[:, 2] - (zc - 0.016 * H)) / (0.016 * H)) ** 2)
        m = np.maximum(m, np.clip(1 - d, 0, 1) * 0.55 * (co[:, 1] < -0.02 * H))
    d = np.sqrt(((co[:, 0]) / (0.010 * H)) ** 2 + ((co[:, 2] - (LY.Z[18] * H - 0.002 * H)) / (0.008 * H)) ** 2)
    m = np.maximum(m, np.clip(1 - d, 0, 1) * 0.45 * (co[:, 1] < -0.03 * H))
    arm = L.arm()
    for sx in (1, -1):    # elbows and knees, knuckles and the toe end
        for (x, y, z, r, k) in ((arm["elbow"] * sx, arm["y"], arm["z"], 0.03 * H, 0.22), (L.leg()["knee"][0] * sx, -0.003 * H, 0.285 * H, 0.035 * H, 0.2),
                                (arm["end"] * sx, arm["y"], arm["z"], 0.05 * H, 0.18)):
            d = np.linalg.norm(co - np.array([x, y, z]), axis=1) / r
            m = np.maximum(m, np.clip(1 - d, 0, 1) * k)
    col = base[None, :] * (1 - m[:, None]) + bl[None, :] * m[:, None]
    # a slightly lighter belly of the forearms and a subtle cooler tone in the neck hollow keep the toon bands readable
    M.set_colours(obj, col)


def _shape_keys(obj, keys):
    """keys: {name: displacement array (n,3)} added relative to the basis."""
    obj.shape_key_add(name="Basis", from_mix=False)
    base = M.co(obj)
    for name, d in keys.items():
        sk = obj.shape_key_add(name=name, from_mix=False)
        sk.value = 0.0
        sk.data.foreach_set("co", (base + d).astype(np.float32).ravel())


def _decal_object(name, V, Fc, cols, group, material, weights_bone="Head", collection=None):
    o = M.make_object(name, V, Fc, [{weights_bone: 1.0}] * len(V), collection)
    M.set_colours(o, cols)
    MT.assign(o, material)
    return o


def _eye_keys(P, H, ew, eh):
    n = len(P.uv)
    keys = {}
    for side, nm in (("L", "blink_L"), ("R", "blink_R")):
        d = np.zeros((n, 3))
        for i, t in enumerate(P.tag):
            if t.endswith(side) and not t.startswith(("lower",)):
                d[i, 2] = -eh * 0.40
            elif t.endswith(side):
                d[i, 2] = -eh * 0.10
        keys[nm] = d
    return keys


def character(variant, collection=None, levels=1, hair=True, outfit=True, log=None):
    t0 = time.time()
    sp = S.resolve(variant)
    L = LY.Layout(sp)
    name = sp["id"]
    col = bpy.data.collections.get(name) or bpy.data.collections.new(name)
    if col.name not in bpy.context.scene.collection.children:
        bpy.context.scene.collection.children.link(col)
    parts = {}

    b = B.build_body(L)
    V, Fc = b.mb.arrays()
    body = M.make_object(name + "_body", V, Fc, b.mb.W, col)
    M.subdivide(body, levels)
    paint_skin(body, L, sp["skin"], sp["skin"]["blush"])
    MT.assign(body, "CH_skin")
    parts["body"] = body

    surf = F.Surface(body)
    hair_c = sp["hair"]["colour"]
    lash = tuple(np.clip(np.array(hex_lin(hair_c["hex"])) * 0.45, 0, 1))
    lash_hex = "#%02x%02x%02x" % tuple(int(255 * (c ** (1 / 2.2))) for c in lash)
    lip = np.array(hex_lin(sp["skin"]["blush"])) * np.array([0.78, 0.55, 0.55])
    lip_hex = "#%02x%02x%02x" % tuple(int(255 * (c ** (1 / 2.2))) for c in lip)
    fc = F.Face(L, surf, sp["eyes"]["hex"], hair_c["hex"], lash_hex, sp["skin"]["hex"], lip_hex)
    P = fc.eyes()
    V, Fe, C = F.bake(P, surf)
    eyes = _decal_object(name + "_eyes", V, Fe, C, "face", "CH_eyes", collection=col)
    _shape_keys(eyes, _eye_keys(P, L.H, fc.ew, fc.eh))
    parts["eyes"] = eyes
    P = fc.brows()
    V, Fb, C = F.bake(P, surf)
    brows = _decal_object(name + "_brows", V, Fb, C, "face", "CH_face", collection=col)
    n = len(P.uv)
    up, dn = np.zeros((n, 3)), np.zeros((n, 3))
    up[:, 2] = 0.006 * L.H
    dn[:, 2] = -0.004 * L.H
    _shape_keys(brows, {"brow_up": up, "brow_down": dn})
    parts["brows"] = brows
    P, half, cz = fc.mouth()
    V, Fm, C = F.bake(P, surf)
    mouth = _decal_object(name + "_mouth", V, Fm, C, "face", "CH_face", collection=col)
    n = len(P.uv)
    k = n // 2
    t = np.linspace(-1, 1, k)
    smile, opn = np.zeros((n, 3)), np.zeros((n, 3))
    smile[:k, 2] = smile[k:, 2] = 0.0042 * L.H * np.abs(t) ** 2
    smile[:k, 0] = smile[k:, 0] = t * 0.004 * L.H
    opn[k:, 2] = -0.012 * L.H * (1 - t ** 2) - 0.001 * L.H
    opn[:k, 2] = 0.0012 * L.H * (1 - t ** 2)
    _shape_keys(mouth, {"smile": smile, "open": opn})
    parts["mouth"] = mouth
    ears_V, ears_F, ears_C = [], [], []
    for sx in (1, -1):
        v, f, c = F.ear_mesh(L, sx, sp["skin"]["hex"], S.rng(sp, "ears"))
        ears_F += [tuple(i + len(ears_V) for i in fi) for fi in f]
        ears_V += list(v)
        ears_C += list(c)
    ears = _decal_object(name + "_ears", np.array(ears_V), ears_F, np.array(ears_C), "face", "CH_skin", collection=col)
    parts["ears"] = ears

    if hair:
        from . import hair as HR
        parts.update(HR.build(sp, L, body, col))
    if outfit:
        from . import outfit as OF
        parts.update(OF.build(sp, L, body, col))

    arm = R.build_armature(L, name + "_rig", col)
    for o in parts.values():
        R.attach(arm, o)
    R.pose_rest(arm)
    h = S.mesh_hash([(k, M.co(o)) for k, o in sorted(parts.items())])
    arm["ch_hash"] = h
    for k, o in parts.items():
        o["ch_part"] = k
        o["ch_variant"] = name
    ch = dict(spec=sp, layout=L, armature=arm, parts=parts, hash=h, collection=col, seconds=time.time() - t0)
    if log:
        log("[AC] %s: %d parts, %d tris, hash %s, %.1fs" % (name, len(parts), sum(M.tri_count(o) for o in parts.values()), h, ch["seconds"]))
    return ch
