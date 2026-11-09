"""
Cyclic gaits (walk, run, sprint) as pose-parameter dicts per phase.

Feet are planted in the ground frame: during stance the ankle moves backward relative to the pelvis at exactly the
design speed, so there is no foot slide at that speed. Heel strike pivots about the heel, toe-off about the ball. The
pelvis height is derived from the leg reach (the hip never asks for a leg longer than the real one), so the bob follows
from the stride instead of being tuned by eye. Arms swing against the legs; shoulders counter-rotate the pelvis.
"""
import math

from . import pose_params as PP

TWO_PI = 2.0 * math.pi


def smoother(q):
    q = min(max(q, 0.0), 1.0)
    return q * q * q * (q * (q * 6 - 15) + 10)


def smooth(q):
    q = min(max(q, 0.0), 1.0)
    return q * q * (3 - 2 * q)


GAITS = {
    # T cycle seconds, v design speed m/s, s stance fraction, lift = swing foot clearance (m), peak = where in the swing the foot is highest
    "walk": dict(T=0.9, v=2.2, s=0.60, lift=0.075, peak=0.5, heel=14.0, toeoff=22.0, fh=0.12, ft=0.30, lean=2.0, arm=20.0, arm_c=0.0, el0=14.0, el1=14.0,
                 pelvis_yaw=5.0, shoulder_yaw=7.0, pelvis_roll=2.2, spine_roll=1.5, soft=0.012, flight_rise=0.0, curl=24.0, head_bob=0.0),
    "run": dict(T=0.6, v=6.5, s=0.30, lift=0.26, peak=0.45, heel=6.0, toeoff=30.0, fh=0.08, ft=0.30, lean=9.0, arm=38.0, arm_c=4.0, el0=88.0, el1=14.0,
                pelvis_yaw=7.0, shoulder_yaw=11.0, pelvis_roll=2.5, spine_roll=2.0, soft=0.02, flight_rise=0.07, curl=60.0, head_bob=0.0),
    "sprint": dict(T=0.5, v=9.5, s=0.25, lift=0.32, peak=0.45, heel=2.0, toeoff=36.0, fh=0.05, ft=0.35, lean=19.0, arm=52.0, arm_c=6.0, el0=92.0, el1=12.0,
                   pelvis_yaw=9.0, shoulder_yaw=14.0, pelvis_roll=2.0, spine_roll=2.0, soft=0.025, flight_rise=0.09, curl=70.0, head_bob=0.0),
}


class Gait:
    def __init__(self, rig, legs, name, **override):
        self.rig, self.legs, self.name = rig, legs, name
        self.p = dict(GAITS[name])
        self.p.update(override)
        p = self.p
        self.T, self.v, self.s = p["T"], p["v"], p["s"]
        g = legs["Left"]
        self.sweep = self.v * self.s * self.T          # metres the pelvis travels over one stance
        self.heel_off = (-0.045, -g.az0)               # heel point relative to the ankle (u, v)
        self._height_curve()

    # ---- foot trajectories (u forward of rest ankle position, z above ground, foot pitch) -------------------
    def _stance(self, t, g):
        """t in [0, s). Returns (du, z, pitch deg, toe bend deg, planted flag)."""
        p, s = self.p, self.s
        gr = t / s
        a = self.sweep / 2.0
        # mid-stance ankle sits under the hip, slightly behind it when leaning forward
        u0 = -0.02
        fu = u0 + a - 2 * a * gr          # flat-foot ankle position (u, relative to rest)
        fz = g.az0
        heel_u, heel_v = self.heel_off
        if gr < p["fh"]:
            th = math.radians(p["heel"]) * (1 - smooth(gr / p["fh"]))
            c, sn = math.cos(th), math.sin(th)
            ru, rv = -heel_u, -heel_v                     # heel -> ankle
            hu, hv = fu + heel_u, fz + heel_v            # heel point (planted)
            return (hu + c * ru - sn * rv) - 0.0, hv + sn * ru + c * rv, math.degrees(th), 0.0, True
        if gr > 1 - p["ft"]:
            q = (gr - (1 - p["ft"])) / p["ft"]
            th = -math.radians(p["toeoff"]) * smooth(q)
            c, sn = math.cos(th), math.sin(th)
            bu, bv = fu + g.foot_u, fz + g.foot_v        # ball point (planted)
            ru, rv = -g.foot_u, -g.foot_v                # ball -> ankle
            return bu + c * ru - sn * rv, bv + sn * ru + c * rv, math.degrees(th), -math.degrees(th) * 0.9, True
        return fu, fz, 0.0, 0.0, True

    def foot(self, t, g):
        """Foot state at leg phase t in [0, 1): (du, z, pitch, toe, planted)."""
        p, s = self.p, self.s
        t = t % 1.0
        if t < s:
            return self._stance(t, g)
        e = self._stance(s - 1e-6, g)
        b = self._stance(0.0, g)
        q = (t - s) / (1 - s)
        m = smoother(q)
        du = e[0] + (b[0] - e[0]) * m
        base_z = e[1] + (b[1] - e[1]) * m
        # the lift peaks at `peak` of the swing: warp q so the sine peaks there
        w = q ** (math.log(0.5) / math.log(max(1e-3, p["peak"])))
        z = base_z + p["lift"] * math.sin(math.pi * w)
        pitch = e[2] + (b[2] - e[2]) * m
        # toe-down during the lift-off, toe-up late in the swing so the heel strikes first
        pitch += -10.0 * math.sin(math.pi * min(1.0, q * 1.3)) + 6.0 * smooth((q - 0.5) / 0.3) * (1 - smooth((q - 0.85) / 0.15))
        return du, z, pitch, max(0.0, -pitch) * 0.0, False

    # ---- pelvis height from the reach of the stance legs --------------------------------------------------------
    def _height_curve(self, N=360):
        legs, p = self.legs, self.p
        gl = legs["Left"]
        k = 0.975
        cand = [None] * N
        for i in range(N):
            ph = i / N
            for off in (0.0, 0.5):
                t = (ph + off) % 1.0
                if t < self.s:
                    du, z, pitch, toe, pl = self._stance(t, gl)
                    # hip joint u relative to the rest ankle u: hip sits above the rest ankle (u offset hu0)
                    hu = -(gl.hip.y) - (-(gl.ank0.y))
                    dd = du - hu
                    r = (k * gl.reach) ** 2 - dd * dd
                    h = z + math.sqrt(max(r, 0.0))
                    cand[i] = h if cand[i] is None else min(cand[i], h)
        finite = [i for i in range(N) if cand[i] is not None]
        if not finite:
            raise ValueError("gait has no stance")
        # fill the flight gaps: linear between neighbours plus a ballistic rise
        out = list(cand)
        i = 0
        while i < N:
            if out[i] is None:
                j = i
                while cand[j % N] is None:
                    j += 1
                a, b = cand[(i - 1) % N], cand[j % N]
                n = j - i + 1
                for m in range(i, j):
                    f = (m - i + 1) / n
                    out[m % N] = a + (b - a) * f + p["flight_rise"] * 4 * f * (1 - f)
                i = j
            else:
                i += 1
        # smooth (periodic), then never exceed the reach limit
        w = max(2, int(N * 0.06))
        sm = []
        for i in range(N):
            acc = 0.0
            for d in range(-w, w + 1):
                wt = 0.5 + 0.5 * math.cos(math.pi * d / (w + 1))
                acc += out[(i + d) % N] * wt
            sm.append(acc)
        norm = sum(0.5 + 0.5 * math.cos(math.pi * d / (w + 1)) for d in range(-w, w + 1))
        sm = [x / norm for x in sm]
        self.hcurve = [min(sm[i], cand[i]) - p["soft"] if cand[i] is not None else sm[i] - p["soft"] for i in range(N)]
        self.N = N
        # hip joint rest height, to turn the hip height into a pelvis offset
        self.hj0 = gl.hip.z

    def hip_height(self, ph):
        x = (ph % 1.0) * self.N
        i = int(x) % self.N
        f = x - int(x)
        return self.hcurve[i] * (1 - f) + self.hcurve[(i + 1) % self.N] * f

    # ---- the whole body ---------------------------------------------------------------------------------------------
    def params(self, ph):
        p, legs = self.p, self.legs
        out = {}
        for side, off, k in (("Left", 0.0, "l_"), ("Right", 0.5, "r_")):
            du, z, pitch, toe, planted = self.foot((ph + off) % 1.0, legs[side])
            out[k + "du"], out[k + "z"], out[k + "pitch"] = du, z, pitch
            if planted and pitch < 0:
                out[k + "toe"] = -pitch * 0.95          # toes stay flat on the ground while the heel lifts
            elif planted:
                out[k + "toe"] = 0.0
            else:
                out[k + "toe"] = 8.0 * math.sin(math.pi * ((((ph + off) % 1.0) - self.s) / (1 - self.s)))
        # pelvis height from the reach curve (hip joint height -> pelvis offset)
        out["hz"] = self.hip_height(ph) - self.hj0
        cl = math.cos(TWO_PI * ph)
        lean = p["lean"]
        out["hp"] = lean * 0.45
        out["sl"] = lean * 0.55
        out["hl"] = lean * 0.15
        wl = math.sin(math.pi * ((ph % 1.0) / self.s)) if (ph % 1.0) < self.s else 0.0
        wr = math.sin(math.pi * (((ph + 0.5) % 1.0) / self.s)) if ((ph + 0.5) % 1.0) < self.s else 0.0
        out["hr"] = -p["pelvis_roll"] * (wl - wr)
        out["sr"] = p["spine_roll"] * (wl - wr)
        out["hyaw"] = -p["pelvis_yaw"] * cl
        out["sy"] = (p["pelvis_yaw"] + p["shoulder_yaw"]) * cl
        for side, off, k in (("Left", 0.0, "l_"), ("Right", 0.5, "r_")):
            c = math.cos(TWO_PI * (ph + off))
            fwd = p["arm_c"] - p["arm"] * c           # forward when the same-side leg is back
            out[k + "fwd"] = fwd
            out[k + "el"] = p["el0"] + p["el1"] * max(0.0, fwd) / max(1.0, p["arm"])
            out[k + "lower"] = 78.0 if self.name == "walk" else 72.0
            out[k + "curl"] = p["curl"]
        out["hhy"] = 0.0
        return out
