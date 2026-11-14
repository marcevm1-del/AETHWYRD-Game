"""
Facial shape-key rig and expression set for the human bases (no lip-sync, no visemes).

The face of a generated human (ascend_characters) is thin decals projected onto the head: eyes (sclera, iris, pupil, two highlights,
lash line, lower lid), brows and a mouth line, as three separate objects. The generator ships six shape keys on them (blink_L, blink_R,
brow_up, brow_down, smile, open); this module adds a complete rig of atomic keys next to them and leaves those six untouched:

    eyes   eyes_close_L/R  eyes_happy_L/R (the closed ^ ^ smile)  eyes_wide_L/R  eyes_narrow_L/R (half-lidded)  eyes_look_left/right/up/down
    brows  brow_up_L/R  brow_down_L/R  brow_inner_up_L/R  brow_inner_down_L/R  brow_outer_up_L/R  brow_outer_down_L/R
    mouth  mouth_smile_wide  mouth_frown  mouth_smirk_L/R  mouth_open_small  mouth_open_wide  mouth_o  mouth_pressed  mouth_pout

Every key is built by moving the decal's own 2D layout and projecting it back onto the head surface (the same projection the generator
uses), so a moved vertex stays on the skin and follows any head shape. The patch layout (which vertex is the iris, the upper lash, the
mouth's lower edge) is recovered by running the generator's own Face builder again and asserting that it reproduces the object's
vertices exactly; if the generator changes, `apply` raises instead of guessing. Expressions are weight sets over these keys
(Data/Characters/face_expressions.json); the game blends them, there is no facial animation system here.

L = the character's left (+X), as in the rig contract.
"""
import math

import numpy as np

from ascend_characters import face as F
from ascend_characters import layout as LY
from ascend_characters import meshio as M

EYE_KEYS = ["eyes_close_L", "eyes_close_R", "eyes_happy_L", "eyes_happy_R", "eyes_wide_L", "eyes_wide_R", "eyes_narrow_L", "eyes_narrow_R",
            "eyes_look_left", "eyes_look_right", "eyes_look_up", "eyes_look_down"]
BROW_KEYS = ["brow_%s_%s" % (k, s) for k in ("up", "down", "inner_up", "inner_down", "outer_up", "outer_down") for s in ("L", "R")]
MOUTH_KEYS = ["mouth_smile_wide", "mouth_frown", "mouth_smirk_L", "mouth_smirk_R", "mouth_open_small", "mouth_open_wide", "mouth_o", "mouth_pressed", "mouth_pout"]
LEGACY = {"eyes": ["blink_L", "blink_R"], "brows": ["brow_up", "brow_down"], "mouth": ["smile", "open"]}
ALL_KEYS = {"eyes": EYE_KEYS, "brows": BROW_KEYS, "mouth": MOUTH_KEYS}

HIDE = -0.004          # lift (m) that sinks a decal under the skin: how a closed eye hides its iris


def _idx(P, prefix, side=None):
    return [i for i, t in enumerate(P.tag) if t.startswith(prefix) and (side is None or t.endswith(side))]


class Rig:
    """Builds the key displacement arrays of one character without touching the scene."""

    def __init__(self, ch):
        import bpy
        self.ch = ch
        sp = ch["spec"]
        self.L = LY.Layout(sp)
        self.H = self.L.H
        self.body = ch["parts"]["body"]
        self.surf = F.Surface(self.body)
        # the generator's own Face (colours do not matter for geometry)
        self.fc = F.Face(self.L, self.surf, "#808080", "#404040", "#202020", "#c0a080", "#a06060")
        self.Pe, self.Pb = self.fc.eyes(), self.fc.brows()
        self.Pm = self.fc.mouth()[0]
        self.obj = {"eyes": ch["parts"]["eyes"], "brows": ch["parts"]["brows"], "mouth": ch["parts"]["mouth"]}
        for part, P in (("eyes", self.Pe), ("brows", self.Pb), ("mouth", self.Pm)):
            V, _, _ = F.bake(P, self.surf)
            base = M.co(self.obj[part])
            if len(V) != len(base) or float(np.abs(np.asarray(V) - base).max()) > 1e-5:
                raise RuntimeError("the face generator no longer reproduces the %s decal (%d vs %d vertices): update face_rig.py" % (part, len(V), len(base)))
            self.base = getattr(self, "base", {})
            self.base[part] = base
        self.a, self.b = self.fc.ew / 2, self.fc.eh / 2

    # ---- helpers ----------------------------------------------------------------------------------------------
    def _disp(self, P, part, new_uv, new_lift):
        """Displacement (n,3) from moving the listed vertices {i: (u, v)} (lifts {i: lift}) and re-projecting onto the head."""
        n = len(P.uv)
        d = np.zeros((n, 3))
        for i, (u, v) in new_uv.items():
            p = self.surf.project(u, v, new_lift.get(i, P.lift[i]))
            d[i] = p - self.base[part][i]
        return d

    def _eye_center(self, side):
        sx = 1 if side == "L" else -1
        return np.array([sx * self.fc.cx, self.fc.cz])

    # ---- eyes ----------------------------------------------------------------------------------------------------
    def _lash_pairs(self, tag):
        ids = [i for i, t in enumerate(self.Pe.tag) if t == tag]
        n = len(ids) // 2
        return [(ids[i], ids[i + n]) for i in range(n)]

    def eye_key(self, name):
        P, a, b, H = self.Pe, self.a, self.b, self.H
        uv = {}
        lift = {}
        if name.startswith(("eyes_close_", "eyes_happy_")):
            kind, side = name.split("_")[1], name[-1]
            cen = self._eye_center(side)
            for i, t in enumerate(P.tag):
                if t.endswith(side) and not t.startswith("lash"):
                    uv[i] = tuple(P.uv[i])
                    lift[i] = HIDE
            for top, bot in self._lash_pairs("lash" + side):
                ct = (np.array(P.uv[top]) + np.array(P.uv[bot])) / 2
                du = min(1.0, abs(ct[0] - cen[0]) / a)
                if kind == "close":
                    vt = cen[1] - 0.25 * b - 0.22 * b * (1 - du ** 2)          # a gentle U: the calm closed eye
                    k = 0.65
                else:
                    vt = cen[1] - 0.15 * b + 0.55 * b * (1 - du ** 2)          # an arch ^: the happy closed eye
                    k = 0.85
                for i in (top, bot):
                    uv[i] = (P.uv[i][0], vt + (P.uv[i][1] - ct[1]) * k)
            return self._disp(P, "eyes", uv, lift)
        if name.startswith("eyes_wide_"):
            side = name[-1]
            cen = self._eye_center(side)
            for i, t in enumerate(P.tag):
                if t.endswith(side) and not t.startswith("lower"):
                    uv[i] = (cen[0] + (P.uv[i][0] - cen[0]) * 1.04, cen[1] + (P.uv[i][1] - cen[1]) * 1.18)
            return self._disp(P, "eyes", uv, lift)
        if name.startswith("eyes_narrow_"):
            side = name[-1]
            cen = self._eye_center(side)
            y1 = cen[1] - 0.05 * b
            for i, t in enumerate(P.tag):
                if t.endswith(side) and not t.startswith("lower") and P.uv[i][1] > y1:
                    uv[i] = (P.uv[i][0], y1 + (P.uv[i][1] - y1) * 0.5)
            return self._disp(P, "eyes", uv, lift)
        if name.startswith("eyes_look_"):
            dx, dz = {"left": (0.18 * a, 0.0), "right": (-0.18 * a, 0.0), "up": (0.0, 0.13 * b), "down": (0.0, -0.13 * b)}[name.split("_")[2]]
            for i, t in enumerate(P.tag):
                if t.startswith(("iris", "pupil", "hi1", "hi2")):
                    uv[i] = (P.uv[i][0] + dx, P.uv[i][1] + dz)
            return self._disp(P, "eyes", uv, lift)
        raise KeyError(name)

    # ---- brows ----------------------------------------------------------------------------------------------------
    def brow_key(self, name):
        P, H = self.Pb, self.H
        kind, side = name[len("brow_"):-2], name[-1]
        ids = _idx(P, "brow", side)
        n = len(ids) // 2
        uv = {}
        for k, i in enumerate(ids):
            t = (k % n) / (n - 1)                          # inner (0) -> outer (1)
            dv = {"up": 0.0065 * H, "down": -0.0050 * H, "inner_up": 0.0075 * H * (1 - t) ** 1.2, "inner_down": -0.0065 * H * (1 - t) ** 1.2,
                  "outer_up": 0.0065 * H * t ** 1.2, "outer_down": -0.0060 * H * t ** 1.2}[kind]
            du = 0.0
            if kind == "inner_down":                       # the inner ends draw together when the brows knit
                du = -np.sign(P.uv[i][0]) * 0.0025 * H * (1 - t)
            uv[i] = (P.uv[i][0] + du, P.uv[i][1] + dv)
        return self._disp(P, "brows", uv, {})

    # ---- mouth ----------------------------------------------------------------------------------------------------
    def mouth_key(self, name):
        P, H = self.Pm, self.H
        ids = _idx(P, "mouth")
        n = len(ids) // 2                                  # top edge then bottom edge, left (-x) to right (+x)... t runs -1 .. 1 along +x
        uv = {}
        for k, i in enumerate(ids):
            t = -1 + 2 * (k % n) / (n - 1)
            bottom = k >= n
            u, v = P.uv[i]
            w = 1 - t * t
            if name == "mouth_smile_wide":
                u, v = u * 1.16, v + 0.0065 * H * t * t
            elif name == "mouth_frown":
                u, v = u * 0.94, v - 0.0058 * H * t * t
            elif name in ("mouth_smirk_L", "mouth_smirk_R"):
                s = t if name.endswith("L") else -t          # +x is the character's left
                up = max(s, 0.0) ** 1.5
                v += 0.0070 * H * up - 0.0014 * H * max(-s, 0.0) ** 1.5
                u *= 1.0 + 0.06 * max(s, 0.0)
            elif name == "mouth_open_small":
                v += (-0.0075 * H * w) if bottom else 0.0008 * H * w
            elif name == "mouth_open_wide":
                u *= 1.04
                v += (-0.0200 * H * w ** 0.7) if bottom else 0.0020 * H * w
            elif name == "mouth_o":
                u *= 0.48
                v += (-0.0140 * H * w) if bottom else 0.0022 * H * w
            elif name == "mouth_pressed":
                u *= 0.90
                v += (0.0012 * H * w if bottom else 0.0) - 0.0010 * H * t * t
            elif name == "mouth_pout":
                u *= 0.58
                v += -0.0030 * H * t * t + ((-0.0035 * H * w) if bottom else 0.0)
            else:
                raise KeyError(name)
            uv[i] = (u, v)
        return self._disp(P, "mouth", uv, {})

    def key(self, part, name):
        return {"eyes": self.eye_key, "brows": self.brow_key, "mouth": self.mouth_key}[part](name)

    def all_keys(self):
        return {part: {name: self.key(part, name) for name in names} for part, names in ALL_KEYS.items()}


def apply(ch):
    """Adds the rig's shape keys to the character's eyes, brows and mouth objects (idempotent per character). Returns {part: {name: displacement (n,3)}}."""
    rig = Rig(ch)
    keys = rig.all_keys()
    for part, ks in keys.items():
        obj = rig.obj[part]
        if obj.data.shape_keys is None:
            obj.shape_key_add(name="Basis", from_mix=False)
        have = {k.name for k in obj.data.shape_keys.key_blocks}
        base = rig.base[part]
        for name, d in ks.items():
            if name in have:
                continue
            sk = obj.shape_key_add(name=name, from_mix=False)
            sk.value = 0.0
            sk.slider_min, sk.slider_max = 0.0, 1.0
            sk.data.foreach_set("co", (base + d).astype(np.float32).ravel())
    return keys


def set_expression(ch, weights):
    """Sets the weights {key name: 0..1} on the character's face objects; every other key goes to 0."""
    for part in ("eyes", "brows", "mouth"):
        for kb in ch["parts"][part].data.shape_keys.key_blocks:
            if kb.name != "Basis":
                kb.value = float(weights.get(kb.name, 0.0))


def resolve(keys, weights):
    """The vertex displacement of an expression: {part: (n,3)} = sum of weight * key."""
    out = {}
    for part, ks in keys.items():
        acc = None
        for name, w in weights.items():
            if name in ks:
                acc = ks[name] * w if acc is None else acc + ks[name] * w
        out[part] = acc if acc is not None else 0.0 * next(iter(ks.values()))
    return out
