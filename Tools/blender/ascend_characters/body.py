"""
The body tube: one connected quad mesh built ring by ring (no Blender calls, numpy only).

    crotch -> waist -> chest -> neck -> head   one chain of 18-vertex rings (layout.Z)
    arms     leave the chain through a 3 x 2 face hole on each side and continue as 10-vertex rings
    legs     start from the two halves of the lowest ring (the crotch edge is shared) as 10-vertex rings
    hands    flatten to a 5 x 2 slab whose end face is four quads: each becomes a finger tube; the thumb leaves a side quad
    feet     bend the leg tube forward; the toe end closes with a fan

The same builder makes the clothes: pass offsets (and fewer rings) and it builds the same shape slightly larger, so
every garment fits every variant. Vertices carry bone weights from the moment they are created.
"""
import math

import numpy as np

from . import layout as LY
from .layout import NR, Z


def smooth(t):
    t = min(max(t, 0.0), 1.0)
    return t * t * (3 - 2 * t)


def chain_weights(s, bones, joints, bw):
    """Partition of unity along a chain: bones[i] owns the stretch between joints[i-1] and joints[i], blending over
    +-bw around every joint."""
    lo = [1.0] + [smooth((s - (j - bw)) / (2 * bw)) for j in joints]
    hi = lo[1:] + [0.0]
    out = {}
    for b, l, h in zip(bones, lo, hi):
        w = l * (1 - h)
        if w > 1e-4:
            out[b] = w
    return out


class MB:
    """Vertex/face accumulator with per-vertex weights and a tag."""

    def __init__(self):
        self.V, self.W, self.F, self.T = [], [], [], []

    def add(self, p, w, tag):
        self.V.append((float(p[0]), float(p[1]), float(p[2])))
        self.W.append(w)
        self.T.append(tag)
        return len(self.V) - 1

    def ring(self, pts, ws, tag):
        if isinstance(ws, dict):
            ws = [ws] * len(pts)
        return [self.add(p, w, tag) for p, w in zip(pts, ws)]

    def band(self, A, B, skip=()):
        n = len(A)
        for i in range(n):
            if i in skip:
                continue
            j = (i + 1) % n
            self.F.append((A[i], A[j], B[j], B[i]))

    def arrays(self):
        return np.array(self.V, dtype=np.float64), self.F

    def compact(self):
        """Drops vertices no face uses (the interior of each shoulder hole) and renumbers faces."""
        used = sorted({i for f in self.F for i in f})
        remap = {o: n for n, o in enumerate(used)}
        self.V = [self.V[i] for i in used]
        self.W = [self.W[i] for i in used]
        self.T = [self.T[i] for i in used]
        self.F = [tuple(remap[i] for i in f) for f in self.F]

    def pos(self, ids):
        return np.array([self.V[i] for i in ids])


ARM_PSI = [36, 72, 108, 144, 180, 216, 252, 288, 324, 0]       # m0..m9 (hole loop order)
HAND_PSI = [18, 54, 90, 126, 162, 198, 234, 270, 306, 342]      # T0..T4, B4..B0
LEG_PSI = [288, 324, 0, 36, 72, 108, 144, 180, 216, 252]        # F, l1..l8, B


def _ellipse(psi_deg, rf, ru, p=2.0):
    a = np.radians(np.asarray(psi_deg, float))
    c, s = np.cos(a), np.sin(a)
    r = (np.abs(c / rf) ** p + np.abs(s / ru) ** p) ** (-1.0 / p)
    return r * c, r * s      # (forward component, up component)


class Builder:
    def __init__(self, L, off=None, mb=None):
        """off(kind, index) -> outward offset in metres for ring `index` of `kind` (master, arm, leg, foot, hand...)."""
        self.L = L
        self.mb = mb or MB()
        self.off = off or (lambda kind, i: 0.0)
        self.rings = {}

    # ----- weights -------------------------------------------------------------------------------------------
    def torso_w(self, zf):
        return chain_weights(zf, ["Hips", "Spine", "Chest", "UpperChest", "Neck", "Head"],
                             [0.565, 0.625, 0.695, 0.816, 0.866], 0.016)

    # ----- the master chain -----------------------------------------------------------------------------------
    def master(self, i0, i1, holes=(True, True), dz=None):
        L, mb = self.L, self.mb
        ids = {}
        for i in range(i0, i1 + 1):
            pts = L.master_ring(i, self.off("master", i), 0.0 if dz is None else dz.get(i, 0.0))
            ids[i] = mb.ring(pts, self.torso_w(Z[i]), "torso")
        for i in range(i0, i1):
            skip = ()
            if i in (8, 9):
                s = []
                if holes[0]:
                    s += [3, 4, 5]
                if holes[1]:
                    s += [12, 13, 14]
                skip = tuple(s)
            mb.band(ids[i], ids[i + 1], skip)
        self.rings["master"] = ids
        return ids

    def cap_top(self, ring, tag="torso"):
        """Close the head: one small ring and a fan to the pole."""
        L, mb = self.L, self.mb
        pts = mb.pos(ring)
        c = pts.mean(0)
        top = c + (pts - c) * 0.42 + np.array([0, 0, 0.0030 * L.H])
        r2 = mb.ring(top, {"Head": 1.0}, tag)
        mb.band(ring, r2)
        apex = mb.add(np.array([c[0], c[1], L.H]), {"Head": 1.0}, tag)
        for i in range(NR):
            mb.F.append((r2[i], r2[(i + 1) % NR], apex))
        return apex

    def hole_loop(self, side):
        """The 10 ring-vertex ids around a shoulder hole in arm order m0..m9 (side +1 left, -1 right)."""
        m = self.rings["master"]
        K = (lambda k: k) if side > 0 else (lambda k: (NR - k) % NR)
        cols = [3, 4, 5, 6]
        loop = [m[10][K(k)] for k in cols] + [m[9][K(6)]] + [m[8][K(k)] for k in reversed(cols)] + [m[9][K(3)]]
        return loop

    # ----- arms -------------------------------------------------------------------------------------------------
    ARM_S = [0.030, 0.065, 0.105, 0.148, 0.165, 0.190, 0.230, 0.270, 0.300]
    ARM_RF = [0.038, 0.036, 0.0335, 0.029, 0.0285, 0.0285, 0.027, 0.0235, 0.0188]
    ARM_RU = [0.041, 0.038, 0.034, 0.030, 0.029, 0.030, 0.0275, 0.0235, 0.0150]

    def arm_w(self, s):
        """s: distance from the shoulder joint in fractions of H."""
        L = self.L
        el, wr = L.ua, L.ua + L.fa
        w = chain_weights(s, ["UpperArm", "LowerArm", "Hand"], [el, wr], 0.020)
        return w

    def arm(self, side, upto=None):
        """Builds the arm for side (+1/-1) from the hole to ring index `upto` (default: the wrist). Returns ring ids."""
        L, mb = self.L, self.mb
        H = L.H
        A = L.arm()
        sj, y, z = A["shoulder"], A["y"], A["z"]
        loop = self.hole_loop(side)
        prefix = "Left" if side > 0 else "Right"
        wmap = lambda w: {(prefix + k): v for k, v in w.items()}
        rings = [loop]
        prev = loop
        n = len(self.ARM_S) if upto is None else upto
        scale = L.limb ** 0.5 * 1.08
        for r in range(n):
            s = self.ARM_S[r]
            x = side * (sj + s * H)
            rf = self.ARM_RF[r] * H * scale + self.off("arm", r)
            ru = self.ARM_RU[r] * H * scale + self.off("arm", r)
            f, u = _ellipse(ARM_PSI, rf, ru, 2.2)
            pts = np.stack([np.full(10, x), y - f, z + u], axis=1)
            ids = mb.ring(pts, wmap(self.arm_w(s)), "arm")
            mb.band(prev, ids)
            rings.append(ids)
            prev = ids
        self.rings["arm%d" % side] = rings
        return rings

    # ----- hands ------------------------------------------------------------------------------------------------
    def hand(self, side, wrist_ring, fingers=True):
        L, mb = self.L, self.mb
        H = L.H
        h = L.hand()
        prefix = "Left" if side > 0 else "Right"
        wr = h["wrist"]
        pw, pt, palm = h["width"], h["thick"], h["palm"]
        yc, zc = h["y"], h["z"]
        t_vals = [0.22, 0.50, 0.78, 1.0]
        # rectangle targets T0..T4 / B4..B0
        rect = []
        ys = [yc - pw / 2 + i * pw / 4 for i in range(5)]
        for i in range(5):
            rect.append((ys[i], zc + pt / 2))
        for i in range(4, -1, -1):
            rect.append((ys[i], zc - pt / 2))
        rf0, ru0 = self.ARM_RF[-1] * H * (L.limb ** 0.5), self.ARM_RU[-1] * H * (L.limb ** 0.5)
        hand_rings = []
        # relabel: hand vertex j follows arm vertex (j - 1) mod 10
        prev = [wrist_ring[(j - 1) % 10] for j in range(10)]
        for ti, t in enumerate(t_vals):
            x = side * (wr + palm * t)
            rf = (rf0 + (pw / 2 * 1.05 - rf0) * t ** 0.7) + self.off("hand", ti)
            ru = (ru0 + (pt / 2 * 1.05 - ru0) * t ** 0.7) + self.off("hand", ti)
            f, u = _ellipse(HAND_PSI, rf, ru, 2.0)
            k = smooth(t) ** 1.2
            pts = []
            for j in range(10):
                ey, ez = yc - f[j], zc + u[j]
                ry, rz = rect[j]
                pts.append((x, ey + (ry - ey) * k, ez + (rz - ez) * k))
            w = {prefix + "Hand": 1.0}
            if t < 0.3:
                w = {prefix + "Hand": 0.7 + t, prefix + "LowerArm": 0.3 - t}
            ids = mb.ring(np.array(pts), w, "hand")
            mb.band(prev, ids)
            hand_rings.append(ids)
            prev = ids
        self.rings["hand%d" % side] = hand_rings
        if not fingers:
            return hand_rings
        end = hand_rings[-1]
        # thumb: remove the side quad between the first two palm rings at the front edge (j9, j0)
        p1, p2 = hand_rings[0], hand_rings[1]
        thumb_face = (p1[9], p1[0], p2[0], p2[9])
        for fi, fc in enumerate(mb.F):
            if len(fc) == 4 and set(fc) == set(thumb_face):
                mb.F.pop(fi)
                break
        self._thumb(side, prefix, thumb_face)
        for i, name in enumerate(("Index", "Middle", "Ring", "Little")):
            self._finger(side, prefix, name, h["fingers"][name], [end[i], end[i + 1], end[8 - i], end[9 - i]])
        return hand_rings

    def _extrude(self, base, centre_path, scales, wlist, tag, offset=0.0):
        """Repeats the base ring along centre_path (list of xyz), scaled about its centre by `scales`. Returns ring ids."""
        mb = self.mb
        p0 = mb.pos(base)
        c0 = p0.mean(0)
        prev = base
        out = [base]
        for c, sc, w in zip(centre_path, scales, wlist):
            p = c + (p0 - c0) * sc
            if offset:
                d = p - c
                p = p + d / (np.linalg.norm(d, axis=1, keepdims=True) + 1e-9) * offset
            ids = mb.ring(p, w, tag)
            mb.band(prev, ids)
            prev = ids
            out.append(ids)
        return out

    def _finger(self, side, prefix, name, fd, base):
        L, mb = self.L, self.mb
        d = L.finger_dir(fd) * np.array([side, 1, 1])
        p0 = mb.pos(base)
        c0 = p0.mean(0)
        length = fd["length"]
        fr = [0.23, 0.46, 0.76, 0.93, 1.0]
        sc = [0.90, 0.80, 0.70, 0.60, 0.36]
        def w_at(f):
            bones = [prefix + name + s for s in ("Proximal", "Intermediate", "Distal")]
            return chain_weights(f, bones, [0.46, 0.76], 0.07)
        wl = [w_at(f) for f in fr]
        path = [c0 + d * length * f for f in fr]
        self._extrude(base, path, sc, wl, "hand", self.off("finger", 0))
        # the root ring belongs mostly to the hand: blend it with the proximal bone
        for v in base:
            mb.W[v] = {prefix + "Hand": 0.55, prefix + name + "Proximal": 0.45}
        end = mb.F[-1]
        self._cap_last(len(mb.V) - 4)

    def _cap_last(self, start):
        self.mb.F.append((start, start + 1, start + 2, start + 3))

    def _thumb(self, side, prefix, face):
        L, mb = self.L, self.mb
        h = L.hand()
        d = L.thumb_dir() * np.array([side, 1, 1])
        base = list(face)
        c0 = mb.pos(base).mean(0)
        tl = h["thumb_len"]
        fr = [0.20, 0.42, 0.72, 0.90, 1.0]
        sc = [0.95, 0.85, 0.74, 0.62, 0.40]
        bones = [prefix + "Thumb" + s for s in ("Proximal", "Intermediate", "Distal")]
        wl = [chain_weights(f, bones, [0.42, 0.72], 0.07) for f in fr]
        path = [c0 + d * tl * f for f in fr]
        self._extrude(base, path, sc, wl, "hand", self.off("finger", 0))
        for v in base:
            mb.W[v] = {prefix + "Hand": 0.6, prefix + "ThumbProximal": 0.4}
        self._cap_last(len(mb.V) - 4)

    # ----- legs and feet ---------------------------------------------------------------------------------------
    LEG_Z = [0.440, 0.400, 0.360, 0.325, 0.285, 0.250, 0.215, 0.175, 0.130, 0.090, 0.060, 0.045]

    def leg_loop(self, side):
        m = self.rings["master"][0]
        if side > 0:
            return [m[k] for k in range(0, 10)]
        return [m[0]] + [m[NR - k] for k in range(1, 9)] + [m[9]]

    def leg_w(self, zf):
        L = self.L
        knee, ankle = 0.285, 0.045
        w = chain_weights(-zf, ["UpperLeg", "LowerLeg", "Foot"], [-knee, -ankle], 0.022)
        hw = 0.5 * smooth((zf - 0.40) / 0.07)
        if hw > 0:
            w = {k: v * (1 - hw) for k, v in w.items()}
            w["Hips"] = hw
        return w

    def leg(self, side, upto=None):
        L, mb = self.L, self.mb
        H = L.H
        lg = L.leg()
        hx, kx, ax = lg["hip"][0], lg["knee"][0], lg["ankle"][0]
        T, C, A = L.thigh, L.calf, L.ankle
        lat = [T, .965 * T, .89 * T, .79 * T, .69 * T, .97 * C, C, .88 * C, .73 * C, A * 1.20, A * 1.07, A]
        fwd = [v * f for v, f in zip(lat, (1.10, 1.08, 1.07, 1.05, 1.07, 1.0, 1.03, 1.0, 1.0, 1.1, 1.12, 1.14))]
        cy = [0, 0, 0, 0, 0.001, 0.003, 0.004, 0.003, 0.002, 0.001, 0, 0]
        prefix = "Left" if side > 0 else "Right"
        wmap = lambda w: {(prefix + k) if k != "Hips" else k: v for k, v in w.items()}
        loop = self.leg_loop(side)
        prev = loop
        rings = [loop]
        n = len(self.LEG_Z) if upto is None else upto
        for r in range(n):
            zf = self.LEG_Z[r]
            t = (self.hip_to(zf))
            if zf > 0.285:
                x = hx + (kx - hx) * (0.520 - zf) / (0.520 - 0.285)
                y = lg["hip"][1] + (lg["knee"][1] - lg["hip"][1]) * (0.520 - zf) / (0.235)
            else:
                x = kx + (ax - kx) * (0.285 - zf) / (0.285 - 0.045)
                y = lg["knee"][1] + (lg["ankle"][1] - lg["knee"][1]) * (0.285 - zf) / 0.240
            rl = lat[r] * H + self.off("leg", r)
            rfw = fwd[r] * H + self.off("leg", r)
            f, o = _ellipse(LEG_PSI, rfw, rl, 2.2)
            pts = np.stack([side * x + side * o, y + cy[r] * H - f, np.full(10, zf * H)], axis=1)
            ids = mb.ring(pts, wmap(self.leg_w(zf)), "leg")
            mb.band(prev, ids)
            rings.append(ids)
            prev = ids
        self.rings["leg%d" % side] = rings
        return rings

    def hip_to(self, zf):
        return zf

    FOOT = [  # centre y, centre z (fractions of H, scaled by foot length ratio in y), beta deg, rho_lat, rho_2 (H)
        (0.000, 0.045, 0, 1.0, 1.0),
        (0.003, 0.030, 20, 1.05, 1.10),
        (-0.006, 0.0225, 50, 1.10, 1.05),
        (-0.030, 0.0185, 80, 1.20, 0.86),
        (-0.060, 0.0170, 90, 1.36, 0.75),
        (-0.085, 0.0140, 90, 1.34, 0.62),
        (-0.104, 0.0115, 90, 1.10, 0.50),
    ]

    def foot(self, side, leg_rings):
        L, mb = self.L, self.mb
        H = L.H
        lg = L.leg()
        ax, ay = lg["ankle"][0], lg["ankle"][1]
        prefix = "Left" if side > 0 else "Right"
        fs = L.foot_len / 0.14
        A0 = L.ankle
        prev = leg_rings[-1]
        ids_all = []
        n = len(self.FOOT)
        for r in range(1, n):
            cy, cz, beta, kl, k2 = self.FOOT[r]
            b = math.radians(beta)
            rl = max(A0, 0.0205 * 0.9) * H * kl * (1.0 if r < 4 else fs ** 0.5) + self.off("foot", r)
            r2 = 0.0225 * H * k2 * (L.ankle / 0.0205) ** 0.5 + self.off("foot", r)
            e2 = np.array([0.0, -math.cos(b), math.sin(b)])
            psi = np.radians(LEG_PSI)
            cyy = ay + cy * H * (fs if r >= 3 else 1.0)
            c = np.array([side * ax, cyy, cz * H])
            pts = [c + e2 * (r2 * math.cos(p)) + np.array([side, 0, 0]) * (rl * math.sin(p)) for p in psi]
            fb = smooth((r - 3.0) / 2.0)
            w = {prefix + "Foot": 1 - 0.0, }
            if r >= 3:
                w = {prefix + "Foot": 1 - fb, prefix + "Toes": fb}
            ids = mb.ring(np.array(pts), w, "foot")
            mb.band(prev, ids)
            prev = ids
            ids_all.append(ids)
        pts = mb.pos(prev)
        c = pts.mean(0)
        apex = mb.add(c + np.array([0, -0.004 * H, 0.0]), {prefix + "Toes": 1.0}, "foot")
        for i in range(10):
            mb.F.append((prev[i], prev[(i + 1) % 10], apex))
        self.rings["foot%d" % side] = ids_all
        return ids_all


def finish_weights(mb, L):
    """Blend torso vertices into the arm and leg bones around the shoulders and hips, then normalise to 4 influences."""
    H = L.H
    hole_x = L.hole_x()
    hx = L.leg()["hip"][0]
    hz = L.hip_z * H
    for i, (p, w, tag) in enumerate(zip(mb.V, mb.W, mb.T)):
        if tag != "torso":
            continue
        x, z = p[0], p[2]
        side = "Left" if x > 0 else "Right"
        ax = abs(x)
        pa = min(max((ax - (hole_x - 0.040 * H)) / (0.045 * H), 0.0), 1.0)
        v = smooth((z - 0.70 * H) / (0.04 * H)) * (1 - smooth((z - 0.815 * H) / (0.02 * H)))
        wa = 0.85 * pa * v
        if wa > 0:
            w = {k: val * (1 - wa) for k, val in w.items()}
            w[side + "UpperArm"] = w.get(side + "UpperArm", 0) + wa * 0.62
            w[side + "Shoulder"] = w.get(side + "Shoulder", 0) + wa * 0.38
        q = min(max(((hz + 0.03 * H) - z) / (0.06 * H), 0.0), 1.0)
        wl = 0.75 * q * min(ax / (0.9 * hx), 1.0)
        if wl > 0:
            w = {k: val * (1 - wl) for k, val in w.items()}
            w[side + "UpperLeg"] = w.get(side + "UpperLeg", 0) + wl
        mb.W[i] = w
    for i, w in enumerate(mb.W):
        top = sorted(w.items(), key=lambda kv: -kv[1])[:4]
        tot = sum(v for _, v in top) or 1.0
        mb.W[i] = {k: v / tot for k, v in top}


def build_body(L):
    """The naked body. Returns the MB (vertices, faces, weights, tags) and the Builder (ring ids)."""
    b = Builder(L)
    b.master(0, LY.N_MASTER - 1)
    b.cap_top(b.rings["master"][LY.N_MASTER - 1])
    for side in (1, -1):
        arm = b.arm(side)
        b.hand(side, arm[-1])
        leg = b.leg(side)
        b.foot(side, leg)
    finish_weights(b.mb, L)
    b.mb.compact()
    return b
