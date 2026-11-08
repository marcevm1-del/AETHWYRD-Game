"""
One source of truth for a character's measurements: ring heights and widths of the body tube, limb centre lines,
hand and foot geometry, and every joint position the rig uses. Body, clothes, hair and rig all read this, so a
taller, sturdier or older variant changes everywhere at once.

Units: metres, +Z up, the character faces -Y, +X is the character's LEFT. Tables are in fractions of height H.
"""
import math

import numpy as np

# master chain: crotch -> neck -> head. The shoulder holes use rings 8, 9, 10.
Z = [0.470, 0.500, 0.530, 0.565, 0.600, 0.640, 0.680, 0.715, 0.745, 0.770, 0.795, 0.810, 0.822, 0.838, 0.852,
     0.862, 0.875, 0.890, 0.912, 0.934, 0.954, 0.972, 0.987, 0.996]
N_MASTER = len(Z)
HOLE_ROWS = (8, 9, 10)
HOLE_COLS = (3, 4, 5, 6)   # ring vertices (of 18) on the left; the right side uses 18 - k
NECK_BASE, CHIN, EYE_RING = 12, 15, 19
NR = 18                    # vertices per master ring

TH = np.arange(NR) * (2 * math.pi / NR)   # 0 = front (-Y), increasing towards +X (the character's left)


def cr(xs, ys, x):
    """Cubic Hermite through (xs, ys) with Catmull-Rom tangents; clamps outside."""
    xs = np.asarray(xs, float)
    ys = np.asarray(ys, float)
    x = float(np.clip(x, xs[0], xs[-1]))
    i = int(np.clip(np.searchsorted(xs, x) - 1, 0, len(xs) - 2))
    h = xs[i + 1] - xs[i]
    t = (x - xs[i]) / h

    def tang(j):
        a, b = max(j - 1, 0), min(j + 1, len(xs) - 1)
        return (ys[b] - ys[a]) / (xs[b] - xs[a])
    m0, m1 = tang(i) * h, tang(i + 1) * h
    t2, t3 = t * t, t * t * t
    return float((2 * t3 - 3 * t2 + 1) * ys[i] + (t3 - 2 * t2 + t) * m0 + (-2 * t3 + 3 * t2) * ys[i + 1] + (t3 - t2) * m1)


def lerp(a, b, t):
    return a + (b - a) * t


class Layout:
    def __init__(self, spec):
        from . import spec as S
        b = spec["body"]
        bd, ag = spec["build"], spec["age"]
        self.spec = spec
        self.sex = spec["sex"]
        self.H = H = spec["heightM"]
        r = S.rng(spec, "proportions")
        j = lambda: 1.0 + (r.random() - 0.5) * 0.024      # +-1.2 % per measurement, seeded
        g, sh, wa, li = bd["girth"], bd["shoulders"], bd["waist"], bd["limbs"]
        # the body is scaled around the 1.78 m / 1.66 m reference so a short person is a smaller person, not a squat one
        self.shoulder = b["shoulderHalf"] * sh * j()
        self.chest = b["chestHalf"] * g * j()
        self.waist = b["waistHalf"] * wa * j()
        self.hip = b["hipHalf"] * g * j()
        self.depth = b["chestDepth"] * (0.5 + 0.5 * g) * j()
        self.neck = b["neckHalf"] * (0.6 + 0.4 * g) * j()
        self.head = b["headHalf"] * ag["headScale"] * j()
        self.jaw = ag["jaw"]
        self.eye_scale = ag["eyeScale"]
        self.brow_drop = ag["browDrop"]
        self.stoop = ag["stoop"]
        self.limb = li
        self.hip_z = b["hipJointZ"]
        self.ua, self.fa, self.hl = b["upperArmLen"] * j(), b["foreArmLen"] * j(), b["handLen"] * j()
        self.thigh = b["thighHalf"] * li * j()
        self.calf = b["calfHalf"] * li * j()
        self.ankle = b["ankleHalf"] * (0.5 + 0.5 * li) * j()
        self.foot_len = b["footLen"] * j()
        self.eye_w = b["eyeWidth"]
        self.eye_hr = b["eyeHeightRatio"]
        self.female = self.sex == "female"
        self.ears_scale = float(spec.get("ears", 1.0))
        self._tables()

    # --- unit helpers --------------------------------------------------------------------------------------------
    def m(self, f):
        return f * self.H

    def yoff(self, zf):
        """Forward lean of the upper body (older variants stoop a little); negative = towards the front."""
        return -self.stoop * float(np.clip((zf - 0.55) / 0.45, 0, 1)) ** 1.5

    # --- the master chain ----------------------------------------------------------------------------------------
    def _tables(self):
        sh, ch, wa, hi, D, nk, hd = self.shoulder, self.chest, self.waist, self.hip, self.depth, self.neck, self.head
        f = self.female
        a = [hi * 0.88, hi * 0.985, hi, lerp(hi, wa, 0.55), wa, wa * 1.035, lerp(wa, ch, 0.70), ch, ch * 1.03, sh * 0.995,
             sh * 0.985, lerp(nk, sh, 0.50), nk * 1.35, nk * 1.10, nk]
        bf = [D * v for v in (0.82, 0.88, 0.90, 0.86, 0.82, 0.86, 0.94, 1.0, 1.0, 0.97, 0.92, 0.78, 0.68)]
        bb = [D * v for v in (1.02, 1.10, 1.14, 1.02, 0.92, 0.92, 0.94, 0.96, 0.96, 0.94, 0.92, 0.80, 0.70)]
        if f:   # modest: a softer chest and pelvis, never an exaggeration
            bf[7] *= 1.07
            bf[8] *= 1.05
            bb[1] *= 1.03
            bb[2] *= 1.04
        bf += [nk * 0.95, nk * 0.98]
        bb += [nk * 1.05, nk * 1.05]
        # head: fractions of the half-width / depth at each ring (chin to crown)
        hs = hd / 0.0495
        jw = self.jaw
        ha = [hd * v for v in (0.60 * jw, 0.80 * jw, 0.92 * jw, 0.985, 1.0, 1.0, 0.975, 0.80, 0.52)]
        hbf = [0.046, 0.049, 0.050, 0.0505, 0.0505, 0.0515, 0.049, 0.040, 0.026]
        hbb = [0.032, 0.040, 0.048, 0.054, 0.058, 0.060, 0.059, 0.050, 0.034]
        # ring 15 is the chin underside (narrow, jutting forward), the rest follow Z[15:]
        a += ha
        bf += [v * hs for v in hbf]
        bb += [v * hs for v in hbb]
        self.A, self.BF, self.BB = a, bf, bb
        self.P = [2.4, 2.4, 2.4, 2.3, 2.2, 2.3, 2.4, 2.4, 2.4, 2.4, 2.3, 2.1, 2.0, 2.0, 2.0,
                  2.0, 2.1, 2.3, 2.45, 2.45, 2.4, 2.2, 2.0, 2.0]
        assert len(self.A) == len(self.BF) == len(self.BB) == len(self.P) == N_MASTER, (len(self.A), N_MASTER)
        yo = [0.0] * 13 + [-0.002, -0.003] + [-0.004] * 9
        self.Y0 = yo

    def master_ring(self, i, off=0.0, dz=0.0):
        """Points (18, 3) of master ring i, with an optional outward offset and vertical shift (metres)."""
        H = self.H
        zf = Z[i]
        a, bf, bb, p = self.A[i] * H, self.BF[i] * H, self.BB[i] * H, self.P[i]
        s, c = np.sin(TH), np.cos(TH)
        b = np.where(c >= 0, bf, bb)
        a_, b_ = a + off, b + off
        rad = (np.abs(s / a_) ** p + np.abs(c / b_) ** p) ** (-1.0 / p)
        y0 = (self.Y0[i] + self.yoff(zf)) * H
        pts = np.stack([rad * s, y0 - rad * c, np.full(NR, zf * H + dz)], axis=1)
        if i >= CHIN - 2:
            pts = self._face_shape(i, pts)
        return pts

    def _face_shape(self, i, pts):
        """Chin, mouth, nose and brow relief on the front of the head rings (k = 0, +-1, +-2)."""
        H = self.H
        k = lambda n: (n % NR)
        bump = {15: (0.002, 0.0), 16: (0.005, 0.0), 17: (0.003, 0.0006), 18: (0.0125, 0.0045), 19: (0.0042, 0.001),
                20: (0.0, 0.0)}.get(i)
        if bump:
            pts = pts.copy()
            pts[k(0), 1] -= bump[0] * H
            for n in (1, -1):
                pts[k(n), 1] -= bump[1] * H
        return pts

    # --- limbs -----------------------------------------------------------------------------------------------
    def hole_x(self):
        """Half-width of the torso at the shoulder-hole rows (the arm leaves from here)."""
        return self.A[9] * self.H

    def arm(self):
        H = self.H
        y = self.yoff(0.77) * H
        z = Z[9] * H
        x0 = self.hole_x()
        # joint centres along +X (left); the right arm mirrors
        sj = x0 - 0.012 * H            # shoulder joint
        elbow = sj + self.ua * H
        wrist = elbow + self.fa * H
        return dict(y=y, z=z, shoulder=sj, elbow=elbow, wrist=wrist, root=x0, end=wrist + self.hl * H)

    def leg(self):
        H = self.H
        hx = self.hip * 0.60 * H
        return dict(hip=(hx, 0.0, self.hip_z * H), knee=(hx - 0.004 * H, -0.003 * H, 0.285 * H),
                    ankle=(hx - 0.008 * H, 0.0, 0.045 * H))

    def hand(self):
        """Hand geometry of the LEFT hand (the right mirrors in x). Palm down, fingers along +X, thumb to the front."""
        H = self.H
        arm = self.arm()
        hl = self.hl * H
        palm = hl * 0.54
        width = hl * 0.60
        thick = hl * 0.20
        wrist = arm["wrist"]
        lens = {"Index": 0.43, "Middle": 0.46, "Ring": 0.43, "Little": 0.34}
        splay = {"Index": -4.0, "Middle": 0.0, "Ring": 3.0, "Little": 9.0}   # degrees, + towards the back
        fingers = {}
        for n, name in enumerate(("Index", "Middle", "Ring", "Little")):
            fingers[name] = dict(y=arm["y"] + (-1.5 + n) * width / 4, x=wrist + palm, length=lens[name] * hl, splay=splay[name])
        return dict(wrist=wrist, palm=palm, width=width, thick=thick, y=arm["y"], z=arm["z"], fingers=fingers,
                    thumb_len=0.40 * hl)

    def foot(self):
        H = self.H
        fl = self.foot_len * H
        lg = self.leg()
        return dict(heel=0.030 * H * fl / (0.14 * H), len=fl, ankle=lg["ankle"], ball=-0.62 * fl + 0.030 * H, toe=-fl + 0.030 * H)

    # --- joint positions for the rig -----------------------------------------------------------------------------
    def joints(self):
        """{bone name: (head xyz, tail xyz)} in metres in the T-pose rest pose."""
        H = self.H
        J = {}
        yo = lambda zf: self.yoff(zf) * H
        def P(x, zf, y=None):
            return np.array([x, yo(zf) if y is None else y, zf * H])
        J["Hips"] = (P(0, self.hip_z + 0.005), P(0, 0.565))
        J["Spine"] = (P(0, 0.565), P(0, 0.625))
        J["Chest"] = (P(0, 0.625), P(0, 0.695))
        J["UpperChest"] = (P(0, 0.695), P(0, 0.790))
        J["Neck"] = (P(0, 0.790), P(0, 0.853))
        J["Head"] = (P(0, 0.853), P(0, 1.0))
        arm = self.arm()
        hnd = self.hand()
        for side, sx in (("Left", 1.0), ("Right", -1.0)):
            ay, az = arm["y"], arm["z"]
            J[side + "Shoulder"] = (np.array([sx * 0.012 * H, ay, az + 0.020 * H]), np.array([sx * arm["shoulder"], ay, az]))
            J[side + "UpperArm"] = (np.array([sx * arm["shoulder"], ay, az]), np.array([sx * arm["elbow"], ay, az]))
            J[side + "LowerArm"] = (np.array([sx * arm["elbow"], ay, az]), np.array([sx * arm["wrist"], ay, az]))
            J[side + "Hand"] = (np.array([sx * arm["wrist"], ay, az]), np.array([sx * (arm["wrist"] + hnd["palm"]), ay, az]))
            for name, fd in hnd["fingers"].items():
                self._finger_joints(J, side, sx, name, fd, az)
            self._thumb_joints(J, side, sx, hnd, az)
            lg = self.leg()
            h, k, a = (np.array([sx * lg["hip"][0], lg["hip"][1], lg["hip"][2]]), np.array([sx * lg["knee"][0], lg["knee"][1], lg["knee"][2]]),
                       np.array([sx * lg["ankle"][0], lg["ankle"][1], lg["ankle"][2]]))
            ft = self.foot()
            ball = np.array([a[0], ft["ball"], 0.017 * H])
            toe = np.array([a[0], ft["toe"], 0.012 * H])
            J[side + "UpperLeg"] = (h, k)
            J[side + "LowerLeg"] = (k, a)
            J[side + "Foot"] = (a, ball)
            J[side + "Toes"] = (ball, toe)
        # extra chains: hair and cloak (positions on the head and back, fixed so every variant shares them)
        hz = 0.965 * H
        J["HairBack_1"] = (np.array([0, 0.052 * H, hz]), np.array([0, 0.060 * H, hz - 0.045 * H]))
        J["HairBack_2"] = (J["HairBack_1"][1], np.array([0, 0.064 * H, hz - 0.095 * H]))
        J["HairBack_3"] = (J["HairBack_2"][1], np.array([0, 0.066 * H, hz - 0.150 * H]))
        for side, sx, nm in (("L", 1.0, "HairSideL"), ("R", -1.0, "HairSideR")):
            J[nm + "_1"] = (np.array([sx * 0.046 * H, -0.010 * H, 0.945 * H]), np.array([sx * 0.050 * H, -0.004 * H, 0.905 * H]))
            J[nm + "_2"] = (J[nm + "_1"][1], np.array([sx * 0.052 * H, 0.0, 0.865 * H]))
        cz = 0.80 * H
        J["CloakBack_1"] = (np.array([0, 0.058 * H, cz]), np.array([0, 0.066 * H, cz - 0.11 * H]))
        J["CloakBack_2"] = (J["CloakBack_1"][1], np.array([0, 0.072 * H, cz - 0.22 * H]))
        J["CloakBack_3"] = (J["CloakBack_2"][1], np.array([0, 0.078 * H, cz - 0.33 * H]))
        return J

    # finger bones: three segments along the finger's direction (splay), thumb angled forward
    def finger_dir(self, fd):
        a = math.radians(fd["splay"])
        return np.array([math.cos(a), math.sin(a), 0.0])

    def _finger_joints(self, J, side, sx, name, fd, az):
        d = self.finger_dir(fd) * np.array([sx, 1, 1])
        p = np.array([sx * fd["x"], fd["y"], az])
        for seg, ratio in zip(("Proximal", "Intermediate", "Distal"), (0.46, 0.30, 0.24)):
            q = p + d * fd["length"] * ratio
            J[side + name + seg] = (p.copy(), q)
            p = q

    def thumb_dir(self):
        a = math.radians(38.0)       # from forward (-Y) towards +X, drooping a little
        d = np.array([math.sin(a), -math.cos(a), -0.18])
        return d / np.linalg.norm(d)

    def thumb_root(self):
        hnd = self.hand()
        return np.array([hnd["wrist"] + hnd["palm"] * 0.34, hnd["y"] - hnd["width"] / 2, hnd["z"]])

    def _thumb_joints(self, J, side, sx, hnd, az):
        d = self.thumb_dir() * np.array([sx, 1, 1])
        r0 = self.thumb_root() * np.array([sx, 1, 1])
        p = r0.copy()
        for seg, ratio in zip(("Proximal", "Intermediate", "Distal"), (0.42, 0.30, 0.28)):
            q = p + d * hnd["thumb_len"] * ratio
            J[side + "Thumb" + seg] = (p.copy(), q)
            p = q
