"""
The humanoid locomotion clip set: Idle, Walk, Run, Sprint, JumpStart, Fall, Land, LandHard, Dodge.
Names, loop flags, lengths and speeds follow 13_Production/animation_clips_required.md (Player.controller states).

Cyclic clips are procedural (gait.py / sinusoids). The rest are key poses interpolated with a monotone cubic
(no overshoot). Every frame is a pose-parameter dict (pose_params.py); `Clip.frames()` returns N+1 of them for a loop
(the last equals the first) or N+1 for a one-shot.
"""
import math

from . import gait as G
from . import pose_params as PP

TWO_PI = 2 * math.pi


def pchip(xs, ys, x, periodic=False, period=1.0):
    """Monotone cubic (Fritsch-Carlson) through (xs, ys), evaluated at x. xs ascending."""
    n = len(xs)
    if periodic:
        xs = [xs[-1] - period - 0.0] + list(xs) + [xs[0] + period]
        ys = [ys[-1]] + list(ys) + [ys[0]]
        n = len(xs)
        x = x % period
    if x <= xs[0]:
        return ys[0]
    if x >= xs[-1]:
        return ys[-1]
    h = [xs[i + 1] - xs[i] for i in range(n - 1)]
    d = [(ys[i + 1] - ys[i]) / h[i] for i in range(n - 1)]
    m = [0.0] * n
    m[0], m[-1] = d[0], d[-1]
    for i in range(1, n - 1):
        m[i] = 0.0 if d[i - 1] * d[i] <= 0 else 2 * d[i - 1] * d[i] / (d[i - 1] + d[i])
    i = max(j for j in range(n - 1) if xs[j] <= x)
    t = (x - xs[i]) / h[i]
    h00, h10, h01, h11 = 2 * t ** 3 - 3 * t ** 2 + 1, t ** 3 - 2 * t ** 2 + t, -2 * t ** 3 + 3 * t ** 2, t ** 3 - t ** 2
    return h00 * ys[i] + h10 * h[i] * m[i] + h01 * ys[i + 1] + h11 * h[i] * m[i + 1]


class Clip:
    name = ""
    fps = 30
    seconds = 1.0
    loop = False
    root_motion = False
    notes = ""

    @property
    def n(self):
        return max(1, int(round(self.seconds * self.fps)))

    def at(self, t):          # t in [0, 1] of the clip
        raise NotImplementedError

    def frames(self):
        n = self.n
        out = []
        for i in range(n + 1):
            out.append(self.at((i / n) if not (self.loop and i == n) else 0.0))
        return out


def keyed(keys, az0, t, loop=False):
    """keys: [(t, {param: value})] sorted by t; params not given take DEFAULTS (ankle heights = az0)."""
    names = set()
    for _, d in keys:
        names |= set(d)
    out = {}
    for nme in names:
        xs = [k[0] for k in keys]
        base = PP.DEFAULTS.get(nme, 0.0)
        if base is None:
            base = az0
        ys = [d.get(nme, base) if d.get(nme, base) is not None else az0 for _, d in keys]
        out[nme] = pchip(xs, ys, t, periodic=loop)
    return out


# --------------------------------------------------------------------------------------------------------------------
class GaitClip(Clip):
    loop = True

    def __init__(self, rig, legs, name, seconds, **kw):
        self.name = name.capitalize()
        self.seconds = seconds
        self.gait = G.Gait(rig, legs, name, **kw)
        self.design_speed = self.gait.v
        self.stride_m = self.gait.v * self.gait.T
        self.notes = "stride %.2f m per cycle at %.1f m/s, stance %.0f%%" % (self.stride_m, self.gait.v, self.gait.s * 100)

    def at(self, t):
        return self.gait.params(t)


class Idle(Clip):
    name, seconds, loop = "Idle", 3.0, True
    notes = "breathing, one slow weight shift, a glance"

    def __init__(self, rig, legs):
        self.az0 = legs["Left"].az0

    def at(self, t):
        b = math.sin(TWO_PI * t)
        b2 = math.sin(TWO_PI * t * 2)
        w = math.sin(TWO_PI * t)
        return dict(
            hz=-0.014 - 0.003 * (1 - math.cos(TWO_PI * t)) / 2, hr=1.3 * w, sr=-0.9 * w, hyaw=0.8 * math.sin(TWO_PI * t + 1.0),
            sl=-0.4 + 0.9 * b2 * 0.0 + 0.9 * (0.5 + 0.5 * b), hhy=3.0 * math.sin(TWO_PI * t + 2.0), hl=0.8 * b,
            l_sh=0.7 * (0.5 + 0.5 * b), r_sh=0.7 * (0.5 + 0.5 * b), l_lower=80 + 1.0 * b, r_lower=80 + 1.0 * b,
            l_fwd=2 + 1.2 * math.sin(TWO_PI * t + 0.6), r_fwd=2 - 1.2 * math.sin(TWO_PI * t + 0.6), l_el=9 + 1.5 * b, r_el=9 + 1.5 * b,
            l_curl=24 + 2 * b2, r_curl=24 + 2 * b2,
            l_du=0.0, r_du=0.0, l_pitch=0.0, r_pitch=0.0,
        )


def _heel_raise(g, th):
    """Ankle (du, z) offsets when the foot pitches heel-up by th degrees about the ball (ball stays planted)."""
    a = math.radians(th)
    ru, rv = -g.foot_u, -g.foot_v          # ball -> ankle
    c, s = math.cos(-a), math.sin(-a)
    return (c * ru - s * rv) - ru, g.az0 + (s * ru + c * rv) - rv


class Keyed(Clip):
    def __init__(self, rig, legs):
        self.az0 = legs["Left"].az0
        self.g = legs["Left"]

    def at(self, t):
        return keyed(self.keys(), self.az0, t, self.loop)


class JumpStart(Keyed):
    name, seconds, loop = "JumpStart", 14 / 30.0, False
    notes = "crouch, drive up on the toes, leave the ground; the clip ends airborne and hands over to Fall"

    def keys(self):
        g = self.g
        du2, z2 = _heel_raise(g, 28)
        du3, z3 = _heel_raise(g, 42)
        stand = dict(hz=-0.014, l_lower=80, r_lower=80, l_fwd=2, r_fwd=2, l_el=9, r_el=9, sl=0.5)
        crouch = dict(hz=-0.21, hp=16, sl=13, hl=6, l_fwd=-38, r_fwd=-38, l_lower=70, r_lower=70, l_el=28, r_el=28, l_curl=30, r_curl=30)
        drive = dict(hz=-0.01, hp=-2, sl=-6, hl=-2, l_fwd=62, r_fwd=62, l_lower=58, r_lower=58, l_el=20, r_el=20,
                     l_du=du2, r_du=du2, l_z=z2, r_z=z2, l_pitch=-28, r_pitch=-28, l_toe=26, r_toe=26)
        leave = dict(hz=0.015, hp=-3, sl=-8, hl=-3, l_fwd=88, r_fwd=88, l_lower=44, r_lower=44, l_el=18, r_el=18,
                     l_du=du3, r_du=du3 - 0.04, l_z=z3 + 0.07, r_z=z3 + 0.04, l_pitch=-40, r_pitch=-36, l_toe=14, r_toe=14)
        return [(0.0, stand), (0.42, crouch), (0.72, drive), (1.0, leave)]


class Fall(Keyed):
    name, seconds, loop = "Fall", 0.8, True
    notes = "airborne loop: arms out, legs trailing, a small flutter"

    def at(self, t):
        s = math.sin(TWO_PI * t)
        c = math.cos(TWO_PI * t)
        g = self.g
        return dict(
            hz=0.0, hp=3, sl=-3 + 1.2 * s, hr=2.0 * s, hl=-2, l_lower=36 + 4 * s, r_lower=36 - 4 * s, l_fwd=14 + 6 * c, r_fwd=14 - 6 * c,
            l_el=24 + 4 * s, r_el=24 - 4 * s, l_curl=38, r_curl=38,
            l_du=0.07 + 0.05 * s, r_du=-0.04 - 0.05 * s, l_z=self.az0 + 0.20 + 0.03 * c, r_z=self.az0 + 0.26 - 0.03 * c,
            l_pitch=-24 + 4 * s, r_pitch=-30 - 4 * s,
        )


class Land(Keyed):
    name, seconds, loop = "Land", 11 / 30.0, False
    notes = "soft landing: absorb with the knees and hips, spring back to the idle stance"
    depth = 0.20
    hip = 14
    lower = 62

    def keys(self):
        d, h = self.depth, self.hip
        air = dict(hz=0.0, hp=3, sl=-3, l_lower=36, r_lower=36, l_fwd=14, r_fwd=14, l_el=24, r_el=24, l_curl=38, r_curl=38,
                   l_du=0.05, r_du=-0.03, l_z=self.az0 + 0.06, r_z=self.az0 + 0.08, l_pitch=-20, r_pitch=-24)
        absorb = dict(hz=-d, hp=h, sl=h * 0.85, hl=5, l_lower=self.lower, r_lower=self.lower, l_fwd=26, r_fwd=26, l_el=22, r_el=22, l_curl=30, r_curl=30,
                      l_du=0.02, r_du=-0.02, l_pitch=0, r_pitch=0)
        rise = dict(hz=-d * 0.35, hp=h * 0.35, sl=h * 0.3, l_lower=74, r_lower=74, l_fwd=8, r_fwd=8, l_el=14, r_el=14)
        stand = dict(hz=-0.014, l_lower=80, r_lower=80, l_fwd=2, r_fwd=2, l_el=9, r_el=9, sl=0.5)
        return [(0.0, air), (0.3, absorb), (0.62, rise), (1.0, stand)]


class LandHard(Land):
    name, seconds = "LandHard", 21 / 30.0
    notes = "heavy landing from a long fall: deep crouch, one hand reaching down, a slow rise (not wired in the controller yet)"
    depth = 0.38
    hip = 30
    lower = 50

    def keys(self):
        k = super().keys()
        air, absorb, rise, stand = (x[1] for x in k)
        absorb = dict(absorb, l_fwd=44, r_fwd=30, sl=24, hl=10)
        hold = dict(absorb, hz=-self.depth * 0.95, hp=self.hip * 0.9)
        rise = dict(hz=-0.12, hp=8, sl=7, l_lower=72, r_lower=72, l_fwd=10, r_fwd=10)
        return [(0.0, air), (0.18, absorb), (0.42, hold), (0.76, rise), (1.0, stand)]


class Dodge(Keyed):
    """Forward roll. 0.42 s exactly (combat_tuning.json dodge.durationSec): 21 frames at 50 fps."""
    name, seconds, fps, loop = "Dodge", 0.42, 50, False
    notes = "forward roll in place (the motor moves 4.2 m); a full 360 degree pitch of the pelvis, curled up, out into a run stance"

    def __init__(self, rig, legs):
        super().__init__(rig, legs)
        self.rig, self.legs = rig, legs

    def frames(self):
        """The roll is rigid-body-like, so lift the pelvis wherever any bone would dip under the floor (exact: FK, no IK)."""
        from . import analysis as AN
        import bpy
        base = super().frames()
        ad = self.rig.obj.animation_data
        saved = ad.action if ad else None
        if ad:
            ad.action = None
        try:
            deficit = []
            for f in base:
                AN.pose_frame(self.rig, self.legs, f)
                bpy.context.view_layer.update()
                low = min(min(b.head.z, b.tail.z) for b in self.rig.obj.pose.bones if not b.name.startswith(("Hair", "Cloak")))
                deficit.append(max(0.0, 0.012 - low))
        finally:
            if ad:
                ad.action = saved
        n = len(base)
        sm = [max(deficit[i], 0.8 * deficit[max(0, i - 1)], 0.8 * deficit[min(n - 1, i + 1)]) for i in range(n)]
        return [dict(f, hz=f.get("hz", 0.0) + sm[i]) for i, f in enumerate(base)]

    def at(self, t):
        # the roll angle: starts after the duck, finishes before the stand-up
        roll = 360.0 * G.smoother((t - 0.20) / 0.62)
        k = keyed(self.keys(), self.az0, t, False)
        k["hp"] = k.get("hp", 0.0) + roll
        k["fk"] = 1.0
        k["level"] = 0.0
        return k

    def keys(self):
        ready = dict(hz=-0.06, hp=14, sl=10, hl=-6, l_th=24, r_th=24, l_kn=40, r_kn=40, l_an=-8, r_an=-8, l_lower=64, r_lower=64, l_fwd=22, r_fwd=22, l_el=40, r_el=40)
        tuck = dict(hz=-0.40, hp=20, sl=84, hl=34, l_th=112, r_th=112, l_kn=136, r_kn=136, l_an=-26, r_an=-26, l_lower=36, r_lower=36, l_fwd=58, r_fwd=58, l_el=92, r_el=92,
                    l_curl=60, r_curl=60)
        out = dict(hz=-0.12, hp=10, sl=14, hl=-4, l_th=36, r_th=-8, l_kn=62, r_kn=24, l_an=-10, r_an=-4, l_lower=70, r_lower=70, l_fwd=-26, r_fwd=34, l_el=84, r_el=84)
        return [(0.0, ready), (0.16, dict(ready, hz=-0.30, sl=38, hl=10, l_th=66, r_th=66, l_kn=90, r_kn=90)), (0.30, tuck), (0.66, tuck), (0.84, dict(out, hz=-0.16)), (1.0, out)]


def all_clips(rig, legs):
    return [Idle(rig, legs), GaitClip(rig, legs, "walk", 0.9), GaitClip(rig, legs, "run", 0.6), GaitClip(rig, legs, "sprint", 0.5),
            JumpStart(rig, legs), Fall(rig, legs), Land(rig, legs), LandHard(rig, legs), Dodge(rig, legs)]
