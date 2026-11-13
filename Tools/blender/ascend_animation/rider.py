"""
Rider poses for the ground mounts (Data/Companions/mounts.json `families`): the human rig seated on a mount, in a seat frame.

The clips animate the rider only. The rider armature is placed so that its Hips bone sits on the mount's saddle anchor (a bone
of the mount rig plus an offset, see RIGS_ANCHOR and the manifest), then the clip's Hips offset (hx, hz in metres, relative to
that seat) moves the rider: small when seated, large for MountUp, Dismount and Stagger, which start or end on the ground
beside the mount (hz = standing hip height minus the seat height of the family). The mount's own body motion carries the rider
rigidly; the clip adds only what a rider does on top of it: pelvis absorption, torso counter-lean, the hands on the reins or
the harness, a weapon swing.

Cycle clips are one mount gait cycle long so the game can drive their normalised time with the mount's gait phase.
"""
import math

from . import clips as CL
from . import combat as CB
from . import gait as G
from . import pose_params as PP

TWO_PI = 2 * math.pi
HIPS_STAND_NAME = "Hips"

# Mount rigs the families use (rigs.json keys) and the bone on each that the rider's Hips are attached to, with the seat offset in
# the mount rig's own normalised units (reference dimension = 1.0, +Y backward, Z up). Rider and mount are scaled separately, so the
# game converts the offset with the mount's size; the numbers here are placeholders for the art session to calibrate on the models.
RIGS_ANCHOR = {
    "quad_large": dict(bone="spine_02", offset=[0.0, 0.03, 0.09]),
    "hexapod": dict(bone="thorax", offset=[0.0, 0.05, 0.10]),
}

# per family: how the rider sits and holds on. seatHeightM = height of the saddle above the ground for a typical mount of the family
# (placeholder: the real value comes from the species size; used only for the ground-to-saddle clips).
STYLE = {
    "horse": dict(seat=1.30, ab=26, th=58, kn=74, an=-8, hp=2, sl=3, level=0.9,
                  L=dict(lower=64, fwd=40, el=84, curl=40), R=dict(lower=64, fwd=40, el=84, curl=40),
                  bob=dict(walk=0.012, trot=0.030, gallop=0.020), pitch=dict(walk=1.5, trot=3.0, gallop=7.0), lean=dict(walk=1, trot=4, gallop=14)),
    "wolf": dict(seat=0.95, ab=22, th=64, kn=84, an=-10, hp=6, sl=10, level=0.9,
                 L=dict(lower=56, fwd=62, el=70, curl=75), R=dict(lower=56, fwd=62, el=70, curl=75),
                 bob=dict(walk=0.014, trot=0.034, gallop=0.040), pitch=dict(walk=2.0, trot=4.0, gallop=9.0), lean=dict(walk=4, trot=9, gallop=20)),
    "bear": dict(seat=1.35, ab=40, th=50, kn=60, an=-6, hp=0, sl=-2, level=0.95,
                 L=dict(lower=50, fwd=52, el=62, curl=70), R=dict(lower=50, fwd=52, el=62, curl=70),
                 bob=dict(walk=0.020, trot=0.034, gallop=0.034), pitch=dict(walk=1.0, trot=2.0, gallop=4.0), lean=dict(walk=0, trot=3, gallop=8), sway=5.0),
    "desert_beast": dict(seat=1.10, ab=34, th=54, kn=68, an=-8, hp=1, sl=2, level=0.9,
                         L=dict(lower=60, fwd=36, el=88, curl=60), R=dict(lower=58, fwd=50, el=70, curl=40),
                         bob=dict(walk=0.014, trot=0.030, gallop=0.026), pitch=dict(walk=2.0, trot=3.5, gallop=6.0), lean=dict(walk=1, trot=4, gallop=11), sway=3.0),
    "large_ground_monster": dict(seat=1.90, ab=44, th=48, kn=56, an=-4, hp=-2, sl=-4, level=1.0,
                                 L=dict(lower=34, fwd=70, el=50, curl=75), R=dict(lower=34, fwd=70, el=50, curl=75),
                                 bob=dict(walk=0.024, trot=0.036, gallop=0.036), pitch=dict(walk=1.0, trot=2.0, gallop=4.0), lean=dict(walk=0, trot=2, gallop=6), sway=6.0),
}
CYCLE = dict(Walk=1.1, Trot=0.7, Gallop=0.5)       # seconds of one mount gait cycle (30 fps frames: 33, 21, 15)


def seated(style, rig_hips_z, **over):
    """The seated base pose of a family (the Idle stance), FK legs astride."""
    s = style
    q = dict(fk=1.0, hz=0.0, hp=s["hp"], sl=s["sl"], level=s["level"],
             l_ab=s["ab"], r_ab=s["ab"], l_th=s["th"], r_th=s["th"], l_kn=s["kn"], r_kn=s["kn"], l_an=s["an"], r_an=s["an"])
    for side, k in (("L", "l_"), ("R", "r_")):
        a = s[side]
        q[k + "lower"], q[k + "fwd"], q[k + "el"], q[k + "curl"] = a["lower"], a["fwd"], a["el"], a["curl"]
    q.update(over)
    return q


class RiderClip(CL.Clip):
    loop = True
    fps = 30

    def __init__(self, rig, legs, fam, name, seconds, fn):
        self.rig, self.legs, self.fam = rig, legs, fam
        self.style = STYLE[fam]
        self.name, self.seconds = name, seconds
        self.az0 = legs["Left"].az0
        self.hips_z = rig.hips_rest.z
        self.fn = fn
        self.weight = self.motion = None

    def at(self, t):
        return self.fn(self, t)


def _idle(c, t):
    s = c.style
    b = math.sin(TWO_PI * t)
    q = seated(s, c.hips_z)
    q.update(hz=-0.004 * (0.5 + 0.5 * b), sl=s["sl"] + 0.8 * b, hr=0.8 * math.sin(TWO_PI * t + 1.0), hhy=3 * math.sin(TWO_PI * t + 2.0),
             l_fwd=q["l_fwd"] + 1.2 * math.sin(TWO_PI * t + 0.5), r_fwd=q["r_fwd"] - 1.2 * math.sin(TWO_PI * t + 0.5))
    return q


def _gait(gait, beats):
    def fn(c, t):
        s = c.style
        ph = TWO_PI * t
        q = seated(s, c.hips_z)
        bob = s["bob"][gait]
        pit = s["pitch"][gait]
        lean = s["lean"][gait]
        # the pelvis absorbs the mount's stride: down/up `beats` times a cycle, pitching with the gait; the torso leans into the speed
        q["hz"] = -bob * (0.5 + 0.5 * math.cos(beats * ph))
        q["hp"] = s["hp"] + pit * 0.5 * math.sin(beats * ph + 0.6)
        q["sl"] = s["sl"] + lean * 0.7 - 0.6 * pit * math.sin(beats * ph + 0.6)
        q["hl"] = -lean * 0.15
        sway = s.get("sway", 2.0) * (1.0 if gait != "gallop" else 0.5)
        q["hr"] = sway * math.sin(ph)
        q["sr"] = -0.6 * sway * math.sin(ph)
        q["hhr"] = 0.4 * sway * math.sin(ph)
        for k in ("l_", "r_"):
            q[k + "fwd"] += 3 * math.sin(beats * ph + 1.0) + lean * 0.4
            q[k + "el"] += 4 * math.sin(beats * ph + 2.0)
        q["l_fwd"] += 1.5 * math.sin(ph)
        q["r_fwd"] -= 1.5 * math.sin(ph)
        return q
    return fn


class RiderAttack(CB.CombatClip):
    """A mounted swing or cast: the combat motion's upper body only (the legs are on the mount), at 0.7 amplitude (a short, sitting swing)."""

    def __init__(self, rig, legs, fam, name, weight, motion, win, fps):
        super().__init__(rig, legs, "blade_1h", name, weight, motion, win, fps)
        self.fam = fam
        self.style = STYLE[fam]
        self.hips_z = rig.hips_rest.z
        self.notes = "%s rider: %s (%s), startup %.2f / active %.2f / recovery %.2f s" % (fam, motion, weight, win[0], win[1], win[2])

    UPPER = ("sy", "hyaw", "sl", "hp", "hhy", "r_fwd", "r_lower", "r_el", "l_fwd", "l_lower", "l_el")

    def _poses(self):
        base = seated(self.style, self.hips_z)
        k = CB.SCALE.get(self.weight, 1.0) * 0.7
        out = []
        for p in CB.MOTIONS[self.motion]:
            q = dict(base)
            for key in self.UPPER:
                if key in p:
                    v = p[key]
                    if key in ("hyaw", "sy", "sl", "hp"):
                        v = v * k
                    elif key.endswith("_fwd"):
                        v = base[key] + (v - 44) * k
                    elif key.endswith(("_lower", "_el")):
                        v = base[key] + (v - 62) * 0.5 * k
                    q[key] = v if key not in ("sl", "hp") else base[key] + v
            out.append(q)
        return base, out


def _ground_hz(c):
    return c.hips_z - c.style["seat"]


def _mount_up(c, t):
    s = c.style
    gz = _ground_hz(c)
    base = seated(s, c.hips_z)
    keys = [
        (0.00, dict(fk=1, hx=0.62, hz=gz, hyaw=-90, hp=0, sl=4, l_th=0, l_kn=2, r_th=0, r_kn=2, l_ab=2, r_ab=2, l_an=0, r_an=0, l_fwd=80, l_lower=68, l_el=40, r_fwd=70, r_lower=70, r_el=50, level=0.9)),
        (0.28, dict(fk=1, hx=0.50, hz=gz + 0.06, hyaw=-82, hp=6, sl=14, l_th=86, l_kn=88, r_th=2, r_kn=4, l_ab=10, r_ab=2, l_an=-20, r_an=0, l_fwd=96, l_lower=66, l_el=30, r_fwd=88, r_lower=66, r_el=40, level=0.8)),
        (0.54, dict(fk=1, hx=0.28, hz=gz + (-gz) * 0.55, hyaw=-52, hp=10, sl=26, l_th=60, l_kn=70, r_th=-14, r_kn=38, l_ab=20, r_ab=18, l_an=-12, r_an=-10, l_fwd=88, l_lower=60, l_el=44, r_fwd=80, r_lower=58, r_el=50, level=0.7)),
        (0.78, dict(fk=1, hx=0.07, hz=0.10, hyaw=-14, hp=6, sl=14, l_th=s["th"] + 10, l_kn=s["kn"] + 8, r_th=40, r_kn=60, l_ab=s["ab"], r_ab=s["ab"] - 6, l_an=-10, r_an=-8, l_fwd=70, l_lower=62, l_el=60, r_fwd=60, r_lower=62, r_el=70, level=0.85)),
        (1.00, dict(base)),
    ]
    return CL.keyed(keys, c.az0, t)


def _dismount(c, t):
    s = c.style
    gz = _ground_hz(c)
    base = seated(s, c.hips_z)
    keys = [
        (0.00, dict(base)),
        (0.26, dict(fk=1, hx=0.05, hz=0.08, hyaw=-10, hp=4, sl=10, l_th=s["th"] + 4, l_kn=s["kn"], r_th=-18, r_kn=36, l_ab=s["ab"], r_ab=18, l_an=-8, r_an=-8, l_fwd=64, l_lower=62, l_el=70, r_fwd=60, r_lower=62, r_el=70, level=0.85)),
        (0.52, dict(fk=1, hx=0.30, hz=gz * 0.5, hyaw=-48, hp=8, sl=18, l_th=44, l_kn=60, r_th=-10, r_kn=34, l_ab=16, r_ab=14, l_an=-8, r_an=-8, l_fwd=70, l_lower=62, l_el=60, r_fwd=60, r_lower=62, r_el=64, level=0.8)),
        (0.80, dict(fk=1, hx=0.58, hz=gz + 0.05, hyaw=-70, hp=8, sl=14, l_th=14, l_kn=28, r_th=12, r_kn=26, l_ab=6, r_ab=6, l_an=0, r_an=0, l_fwd=30, l_lower=70, l_el=30, r_fwd=24, r_lower=70, r_el=30, level=0.9)),
        (1.00, dict(fk=1, hx=0.62, hz=gz, hyaw=-60, hp=3, sl=3, l_th=3, l_kn=4, r_th=3, r_kn=4, l_ab=2, r_ab=2, l_an=0, r_an=0, l_fwd=6, l_lower=78, l_el=10, r_fwd=6, r_lower=78, r_el=10, level=0.9)),
    ]
    return CL.keyed(keys, c.az0, t)


def _stagger(c, t):
    """Thrown from the saddle over the left side: a jolt, an arc, then down on the ground beside the mount, curled on a side."""
    s = c.style
    gz = _ground_hz(c)
    base = seated(s, c.hips_z)
    keys = [
        (0.00, dict(base)),
        (0.18, dict(fk=1, hx=0.0, hz=0.07, hp=-12, sl=-8, hr=6, l_th=s["th"] + 10, r_th=s["th"] + 10, l_kn=s["kn"] - 10, r_kn=s["kn"] - 10, l_ab=s["ab"] + 8, r_ab=s["ab"] + 8,
                    l_fwd=-10, r_fwd=-10, l_lower=30, r_lower=30, l_el=20, r_el=20, level=0.4)),
        (0.50, dict(fk=1, hx=0.55, hz=gz * 0.35, hr=48, hp=-6, sl=18, l_th=70, r_th=60, l_kn=95, r_kn=90, l_ab=14, r_ab=14, l_fwd=52, r_fwd=40, l_lower=40, r_lower=40, l_el=40, r_el=40, level=0.2)),
        (0.78, dict(fk=1, hx=0.80, hz=gz + 0.34, hr=84, hp=4, sl=30, l_th=78, r_th=70, l_kn=110, r_kn=104, l_ab=10, r_ab=10, l_fwd=60, r_fwd=50, l_lower=50, r_lower=50, l_el=70, r_el=70, level=0.0)),
        (1.00, dict(fk=1, hx=0.84, hz=gz + 0.30, hr=86, hp=6, sl=34, l_th=84, r_th=74, l_kn=116, r_kn=108, l_ab=8, r_ab=8, l_fwd=64, r_fwd=54, l_lower=54, r_lower=54, l_el=76, r_el=76, level=0.0)),
    ]
    return CL.keyed(keys, c.az0, t)


def build_family(rig, legs, fam, win, fps):
    """Every rider clip of one mount family: Idle, Walk, Trot, Gallop, Hit1-3, Skill, MountUp, Dismount, Stagger."""
    out = [RiderClip(rig, legs, fam, "Idle", 2.4, _idle), RiderClip(rig, legs, fam, "Walk", CYCLE["Walk"], _gait("walk", 2)),
           RiderClip(rig, legs, fam, "Trot", CYCLE["Trot"], _gait("trot", 2)), RiderClip(rig, legs, fam, "Gallop", CYCLE["Gallop"], _gait("gallop", 1))]
    motions = ["slash_h", "slash_back", "slash_diag"]
    weights = ["light", "light", "medium"]
    for i, (m, w) in enumerate(zip(motions, weights)):
        out.append(RiderAttack(rig, legs, fam, "Hit%d" % (i + 1), w, m, win[w], fps))
    out.append(RiderAttack(rig, legs, fam, "Skill", "medium", "cast", win["medium"], fps))
    for name, secs, fn in (("MountUp", 0.9, _mount_up), ("Dismount", 0.8, _dismount), ("Stagger", 0.8, _stagger)):
        c = RiderClip(rig, legs, fam, name, secs, fn)
        c.loop = False
        out.append(c)
    return out
