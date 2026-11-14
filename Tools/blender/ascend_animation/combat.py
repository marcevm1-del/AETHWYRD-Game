"""
Combat clip sets per weapon family, driven by the attack-chain windows in Data/Combat/combat_tuning.json (`attackTiming`).

Every attack clip is exactly startup + active + recovery long, with the four animation events on exact frames:

    frame 0 ........ StartupEnd/ActiveBegin ........ ActiveEnd ........ RecoveryEnd
    ready -> wind-up (telegraph) -> contact pose on the first active frame -> follow-through -> back to ready

so the game can play the clip at 1.0 and the pose on the first active frame is the pose the hit is judged on (AttackChain:
"the hit lands on the first active frame"). The fps is chosen so every window is a whole number of frames (50 for the
current tuning); if no fps up to 240 fits, the build stops instead of rounding (a clip that disagrees with its window is
worse than no clip).

A family is a weapon grip plus a list of motions; a motion is three poses (wind-up, contact, follow-through) written for a
right-handed grip and scaled by the hit weight. Poses are pose_params dicts (the weapon hand is the right hand; the game
parents the weapon to RightHand, or both hands for two-handed families).
"""
import math

from . import clips as CL
from . import pose_params as PP

SCALE = {"light": 0.85, "medium": 1.0, "heavy": 1.2, "launch": 1.05}
HEAVY_WEIGHTS = ("heavy", "ultimate")

# keys that swap sides / change sign when a motion is mirrored to the left hand
_SWAP = ("lower", "fwd", "twist", "el", "wr", "curl", "sh", "du", "z", "pitch", "toe", "th", "kn", "an")
_NEG = ("hyaw", "sy", "sr", "hr", "hhy", "hhr")


def mirror(p):
    out = {}
    for k, v in p.items():
        if k[:2] in ("l_", "r_") and k[2:] in _SWAP:
            out[("r_" if k[0] == "l" else "l_") + k[2:]] = v
        elif k in _NEG:
            out[k] = -v
        else:
            out[k] = v
    return out


def scaled(p, k):
    """Scale the amplitude of the angle parameters by k (not heights, feet or finger curl)."""
    out = {}
    for n, v in p.items():
        if n in ("sy", "hyaw", "sl", "hp", "sr", "hr") or n.endswith(("_fwd", "_twist")):
            out[n] = v * k
        else:
            out[n] = v
    return out


# ---------------------------------------------------------------------------------------------------------------------
# motions: (windup, contact, follow-through), right-handed, degrees; hz/hf in metres. `ready` is the family stance.
MOTIONS = {
    "slash_h": (dict(sy=-52, hyaw=-18, sl=2, r_lower=28, r_fwd=-8, r_el=70, l_fwd=36, l_lower=70, l_el=70, hz=-0.08),
                dict(sy=22, hyaw=12, sl=5, r_lower=70, r_fwd=78, r_el=22, l_fwd=20, l_lower=76, l_el=60, hz=-0.07, hf=0.06),
                dict(sy=52, hyaw=22, sl=6, r_lower=84, r_fwd=70, r_el=30, l_fwd=14, l_lower=80, l_el=50, hz=-0.08, hf=0.10)),
    "slash_back": (dict(sy=52, hyaw=20, sl=2, r_lower=70, r_fwd=60, r_el=60, l_fwd=20, l_lower=75, l_el=60, hz=-0.08),
                   dict(sy=-24, hyaw=-12, sl=5, r_lower=28, r_fwd=30, r_el=24, l_fwd=36, l_lower=70, l_el=70, hz=-0.07, hf=0.06),
                   dict(sy=-54, hyaw=-22, sl=6, r_lower=20, r_fwd=14, r_el=30, l_fwd=40, l_lower=66, l_el=70, hz=-0.08, hf=0.10)),
    "slash_diag": (dict(sy=-30, hyaw=-14, sl=-8, hp=-2, r_lower=48, r_fwd=150, r_el=70, l_fwd=30, l_lower=70, l_el=70, hz=-0.07),
                   dict(sy=14, hyaw=10, sl=14, r_lower=62, r_fwd=84, r_el=22, l_fwd=24, l_lower=72, l_el=64, hz=-0.10, hf=0.08),
                   dict(sy=40, hyaw=20, sl=24, r_lower=70, r_fwd=38, r_el=28, l_fwd=18, l_lower=74, l_el=60, hz=-0.12, hf=0.12)),
    "thrust": (dict(sy=-30, hyaw=-12, sl=2, hf=-0.08, r_lower=62, r_fwd=44, r_el=135, l_fwd=26, l_lower=70, l_el=80, hz=-0.10, l_du=0.12, r_du=-0.22),
               dict(sy=16, hyaw=8, sl=8, hf=0.16, r_lower=76, r_fwd=88, r_el=10, l_fwd=26, l_lower=72, l_el=70, hz=-0.12, l_du=0.30, r_du=-0.22),
               dict(sy=20, hyaw=10, sl=10, hf=0.20, r_lower=78, r_fwd=88, r_el=6, l_fwd=26, l_lower=72, l_el=70, hz=-0.13, l_du=0.34, r_du=-0.22)),
    "chop": (dict(sy=-8, sl=-14, hp=-4, r_lower=60, r_fwd=172, r_el=60, l_fwd=160, l_lower=60, l_el=70, hz=-0.04),
             dict(sy=4, sl=22, hp=6, r_lower=70, r_fwd=96, r_el=24, l_fwd=92, l_lower=70, l_el=40, hz=-0.16, hf=0.08),
             dict(sy=4, sl=34, hp=8, r_lower=74, r_fwd=58, r_el=20, l_fwd=54, l_lower=74, l_el=30, hz=-0.22, hf=0.10)),
    "upswing": (dict(sy=-14, sl=16, hp=4, r_lower=70, r_fwd=-24, r_el=40, l_fwd=0, l_lower=76, l_el=50, hz=-0.20),
                dict(sy=6, sl=-4, hp=-4, r_lower=62, r_fwd=88, r_el=16, l_fwd=30, l_lower=68, l_el=70, hz=-0.02),
                dict(sy=10, sl=-14, hp=-6, r_lower=56, r_fwd=165, r_el=14, l_fwd=60, l_lower=62, l_el=70, hz=0.04, heel=24)),
    "slam": (dict(sl=-12, hp=-4, r_lower=60, r_fwd=170, r_el=50, l_fwd=165, l_lower=60, l_el=50, hz=0.02, l_z="air", r_z="air", l_du=0.05, r_du=-0.05),
             dict(sl=34, hp=8, r_lower=72, r_fwd=70, r_el=30, l_fwd=70, l_lower=72, l_el=34, hz=-0.12, l_du=0.12, r_du=-0.12),
             dict(sl=38, hp=10, r_lower=74, r_fwd=46, r_el=24, l_fwd=46, l_lower=74, l_el=28, hz=-0.26, l_du=0.14, r_du=-0.14)),
    "parry": (dict(sy=30, hyaw=14, sl=0, r_lower=40, r_fwd=60, r_el=100, l_fwd=40, l_lower=60, l_el=80, hz=-0.10, r_du=-0.20),
              dict(sy=-18, hyaw=-8, sl=8, hf=0.14, r_lower=76, r_fwd=88, r_el=10, l_fwd=30, l_lower=70, l_el=70, hz=-0.12, l_du=0.30, r_du=-0.22),
              dict(sy=-22, hyaw=-10, sl=10, hf=0.18, r_lower=78, r_fwd=88, r_el=6, l_fwd=30, l_lower=70, l_el=70, hz=-0.13, l_du=0.34, r_du=-0.22)),
    "jab": (dict(sy=-12, hyaw=-6, sl=2, r_lower=66, r_fwd=52, r_el=125, l_fwd=62, l_lower=64, l_el=110, hz=-0.08),
            dict(sy=14, hyaw=10, sl=6, hf=0.07, r_lower=80, r_fwd=88, r_el=6, l_fwd=54, l_lower=64, l_el=112, hz=-0.09, l_du=0.24),
            dict(sy=16, hyaw=12, sl=7, hf=0.09, r_lower=80, r_fwd=88, r_el=8, l_fwd=54, l_lower=64, l_el=112, hz=-0.09, l_du=0.26)),
    "kick": (dict(sy=14, sl=6, hp=0, hz=-0.12, r_du=-0.10, r_z="kick_back", r_th=0, l_fwd=50, l_lower=64, l_el=100, r_fwd=-10, r_lower=70, r_el=90),
             dict(sy=-12, sl=-6, hz=-0.06, r_du=0.52, r_z="kick_hi", r_pitch=10, l_fwd=30, l_lower=70, l_el=100, r_fwd=60, r_lower=60, r_el=90),
             dict(sy=-14, sl=-8, hz=-0.06, r_du=0.60, r_z="kick_hi2", r_pitch=14, l_fwd=26, l_lower=72, l_el=100, r_fwd=60, r_lower=60, r_el=90)),
    "shoot": (dict(sy=-34, hyaw=-14, sl=0, l_fwd=88, l_lower=88, l_el=6, r_fwd=76, r_lower=56, r_el=92, hz=-0.07, l_du=0.08, r_du=-0.16),
              dict(sy=-34, hyaw=-14, sl=0, l_fwd=90, l_lower=88, l_el=6, r_fwd=58, r_lower=48, r_el=160, hz=-0.07, l_du=0.08, r_du=-0.16),
              dict(sy=-30, hyaw=-12, sl=0, l_fwd=90, l_lower=88, l_el=6, r_fwd=28, r_lower=62, r_el=104, hz=-0.07, l_du=0.08, r_du=-0.16)),
    "cast": (dict(sy=-14, sl=-4, r_lower=60, r_fwd=30, r_el=100, l_fwd=26, l_lower=64, l_el=100, hz=-0.08, hhy=0),
             dict(sy=8, sl=8, r_lower=84, r_fwd=96, r_el=12, l_fwd=94, l_lower=84, l_el=14, hz=-0.10, hf=0.05),
             dict(sy=10, sl=10, r_lower=70, r_fwd=86, r_el=14, l_fwd=88, l_lower=74, l_el=16, hz=-0.10, hf=0.07)),
    "lash": (dict(sy=-34, hyaw=-12, sl=0, r_lower=24, r_fwd=-18, r_el=80, l_fwd=40, l_lower=62, l_el=80, hz=-0.07),
             dict(sy=18, hyaw=10, sl=6, r_lower=78, r_fwd=92, r_el=18, l_fwd=20, l_lower=76, l_el=64, hz=-0.08, hf=0.05),
             dict(sy=38, hyaw=16, sl=8, r_lower=80, r_fwd=78, r_el=40, l_fwd=14, l_lower=78, l_el=56, hz=-0.08, hf=0.08)),
    "strike_down": (dict(sy=-10, sl=-10, r_lower=64, r_fwd=130, r_el=70, l_fwd=100, l_lower=70, l_el=90, hz=-0.06),
                    dict(sy=6, sl=14, r_lower=72, r_fwd=80, r_el=40, l_fwd=84, l_lower=72, l_el=84, hz=-0.10, hf=0.05),
                    dict(sy=8, sl=20, r_lower=74, r_fwd=56, r_el=40, l_fwd=80, l_lower=74, l_el=84, hz=-0.12, hf=0.07)),
}

# the ready pose of each family (a combat stance; the lower body is a staggered stance with the feet planted)
BASE_READY = dict(hz=-0.07, hp=3, sl=3, hyaw=-6, sy=-8, l_du=0.17, r_du=-0.17, r_lower=60, r_fwd=44, r_el=92, l_lower=66, l_fwd=34, l_el=84, level=0.9)

# family: weapon types (item weaponType and class weapon-list names), motions for hit 1..n, specials, grip details
FAMILIES = {
    "blade_1h": dict(weapons=["sword", "1h_sword", "short_sword", "katana", "shield", "tower_shield"],
                     hits=["slash_h", "slash_back", "slash_diag", "slash_h"], heavy="chop", riposte="parry", launcher="upswing", slam="slam", skill="cast", ready=dict()),
    "blade_2h": dict(weapons=["greatsword"], two_hand=True, hits=["slash_diag", "slash_back", "slash_h", "chop"], heavy="chop", riposte="parry", launcher="upswing",
                     slam="slam", skill="cast", ready=dict(hz=-0.10, sl=5, l_fwd=44, l_lower=62, l_el=92)),
    "dual_blades": dict(weapons=["daggers", "dual_swords", "ritual_dagger", "short_sword_pair"], dual=True, hits=["slash_h", "slash_back", "slash_h", "slash_diag"],
                        heavy="slash_diag", riposte="thrust", launcher="upswing", slam="slam", skill="cast", ready=dict(hz=-0.12, sl=7, l_fwd=44, l_lower=60, l_el=92)),
    "blunt_1h": dict(weapons=["mace", "hammer", "wrench", "censer"], hits=["slash_diag", "slash_h", "chop"], heavy="chop", riposte="parry", launcher="upswing",
                     slam="slam", skill="cast", ready=dict()),
    "polearm": dict(weapons=["spear", "lance", "halberd", "glaive", "naginata", "trident", "bo_staff"], two_hand=True, hits=["thrust", "thrust", "slash_h", "thrust"],
                    heavy="chop", riposte="parry", launcher="upswing", slam="slam", skill="cast", ready=dict(l_fwd=50, l_lower=64, l_el=96)),
    "staff_caster": dict(weapons=["staff", "wand", "grimoire", "orb", "holy_tome", "bone_staff", "tool_staff", "tome"], hits=["cast", "cast", "cast"], heavy="cast",
                         riposte="cast", launcher="upswing", slam="slam", skill="cast", ready=dict(hz=-0.05, sl=2, hyaw=0, sy=0)),
    "bow": dict(weapons=["shortbow", "longbow", "crossbow", "throwing_knives", "throwables"], hits=["shoot", "shoot", "shoot"], heavy="shoot", riposte="shoot", launcher="shoot",
                slam="shoot", skill="shoot", ready=dict(sy=-30, hyaw=-10, l_fwd=60, l_lower=76, l_el=40, r_fwd=34, r_el=100)),
    "unarmed": dict(weapons=["fists", "knuckles", "gauntlets", "greaves"], hits=["jab", "jab", "jab", "jab", "kick"], alt=True, heavy="chop", riposte="jab",
                    launcher="upswing", slam="slam", skill="cast", ready=dict(hz=-0.08, r_fwd=56, r_el=112, l_fwd=62, l_el=112, l_lower=66)),
    "whip": dict(weapons=["whip", "rod", "bell", "flute_tamer"], hits=["lash", "lash", "slash_h"], heavy="slash_diag", riposte="lash", launcher="upswing", slam="slam",
                 skill="cast", ready=dict()),
    "instrument": dict(weapons=["lute", "flute", "harp", "war_drum", "violin_blade", "violin"], hits=["strike_down", "slash_h", "strike_down"], heavy="chop", riposte="cast",
                       launcher="upswing", slam="slam", skill="cast", ready=dict(hz=-0.05, sl=2, hyaw=0, sy=0, l_fwd=62, l_lower=66, l_el=100, r_fwd=50, r_el=100)),
}

# which hit weight each hit of a family's reference chain has (4 hits: light, light, light, medium; the Swordsman Slash Chain). Families
# with fewer or more hits keep the last hit medium.
def chain_weights(n):
    return ["light"] * (n - 1) + ["medium"]


def windows_from_tuning(tuning):
    """{weight: (startup, active, recovery)} seconds from combat_tuning.json attackTiming."""
    t = tuning["attackTiming"]
    return {w: (t[w]["startupSec"], t[w]["activeSec"], t[w]["recoverySec"]) for w in ("light", "medium", "heavy", "launch")}


def pick_fps(win):
    """Smallest fps (30, 50, 60, 100, 120, 240) at which every window is a whole number of frames; None if none is."""
    for fps in (30, 50, 60, 100, 120, 200, 240):
        if all(abs(x * fps - round(x * fps)) < 1e-6 for w in win.values() for x in w):
            return fps
    return None


class CombatClip(CL.Clip):
    """One attack: ready -> wind-up -> contact (first active frame) -> follow-through -> ready."""
    loop = False

    def __init__(self, rig, legs, family, name, weight, motion, win, fps, hand="right", two_hand=False, dual=False):
        self.rig, self.legs = rig, legs
        self.family, self.name, self.weight, self.motion = family, name, weight, motion
        self.fps = fps
        s, a, r = win
        self.startup, self.active, self.recovery = s, a, r
        self.seconds = s + a + r
        self.az0 = legs["Left"].az0
        self.hand, self.two_hand, self.dual = hand, two_hand, dual
        self.notes = "%s: %s (%s), startup %.2f / active %.2f / recovery %.2f s" % (family, motion, weight, s, a, r)
        self.windup_t = max(1.0 / fps, s * 0.62)

    @property
    def events(self):
        n = self.n
        f = lambda sec: int(round(sec * self.fps))
        return dict(StartupEnd=f(self.startup), ActiveBegin=f(self.startup), ActiveEnd=f(self.startup + self.active), RecoveryEnd=n)

    def _resolve(self, p):
        q = dict(p)
        if q.get("heel"):                       # both heels up on the ball of the foot: lift the ankles so the toes stay on the floor
            deg = q.pop("heel")
            du, z = CL._heel_raise(self.legs["Left"], deg)
            for k in ("l_", "r_"):
                q[k + "du"] = q.get(k + "du", 0.0) + du
                q[k + "z"] = z
                q[k + "pitch"] = -deg
                q[k + "toe"] = deg * 0.9
        air = self.az0 + 0.14
        for k in ("l_z", "r_z"):
            v = q.get(k)
            if v == "air":
                q[k] = air
            elif v == "kick_back":
                q[k] = self.az0 + 0.10
            elif v == "kick_hi":
                q[k] = self.az0 + 0.55
            elif v == "kick_hi2":
                q[k] = self.az0 + 0.62
        return q

    def _poses(self):
        fam = FAMILIES[self.family]
        k = SCALE.get(self.weight, 1.0)
        ready = dict(BASE_READY)
        ready.update(fam["ready"])
        wind, contact, follow = (self._resolve(scaled(p, k)) for p in MOTIONS[self.motion])
        poses = []
        for p in (wind, contact, follow):
            q = dict(ready)
            q.update(p)
            poses.append(q)
        ready = self._resolve(ready)
        if self.hand == "left":
            ready = mirror(ready)
            poses = [mirror(p) for p in poses]
        if self.two_hand:     # both hands on the weapon: the off hand follows the weapon hand with a hand-width offset
            for q in [ready] + poses:
                side = "r_" if self.hand == "right" else "l_"
                off = "l_" if side == "r_" else "r_"
                q[off + "fwd"] = q.get(side + "fwd", 44) - 6
                q[off + "lower"] = q.get(side + "lower", 60) - 4
                q[off + "el"] = q.get(side + "el", 92) + 10
        if self.dual:         # off hand carries the second blade: it follows the weapon hand's motion half a beat later
            for q, mm in zip(poses, (mirror(poses[2]), mirror(poses[0]), mirror(poses[1]))):
                for key in ("l_fwd", "l_lower", "l_el"):
                    q[key] = mm.get(key, q.get(key))
        return ready, poses

    def at(self, t):
        ready, (wind, contact, follow) = self._poses()
        S, A, R = self.startup, self.active, self.recovery
        T = self.seconds
        sec = t * T
        keys = [(0.0, ready), (self.windup_t / T, wind), (S / T, contact), ((S + A) / T, follow),
                ((S + A + R * 0.55) / T, dict(ready, hz=ready["hz"] * 0.9)), (1.0, ready)]
        return CL.keyed(keys, self.az0, sec / T, False)


class ChargeLoop(CL.Clip):
    """Held wind-up of the heavy attack, looping while the button is held."""
    loop = True

    def __init__(self, rig, legs, family, fps):
        self.rig, self.legs, self.family = rig, legs, family
        self.name, self.fps, self.seconds = "Charge", fps, 1.0
        self.az0 = legs["Left"].az0
        self.notes = family + ": held heavy wind-up, shakes slightly more as the charge fills"
        self.weight, self.motion = "heavy", FAMILIES[family]["heavy"]
        self.two_hand = bool(FAMILIES[family].get("two_hand"))

    def at(self, t):
        fam = FAMILIES[self.family]
        base = dict(BASE_READY)
        base.update(fam["ready"])
        wind = self._pose = dict(base)
        wind.update(scaled(MOTIONS[fam["heavy"]][0], SCALE["heavy"]))
        wind = CombatClip._resolve(self, wind)
        if self.two_hand:
            wind["l_fwd"], wind["l_lower"], wind["l_el"] = wind.get("r_fwd", 44) - 6, wind.get("r_lower", 60) - 4, wind.get("r_el", 92) + 10
        s = math.sin(2 * math.pi * t * 2)
        b = math.sin(2 * math.pi * t)
        wind["hz"] = wind.get("hz", -0.1) - 0.02 - 0.012 * (0.5 + 0.5 * b)
        wind["sl"] = wind.get("sl", 0) + 1.5 * b
        wind["r_fwd"] = wind.get("r_fwd", 0) + 1.8 * s
        wind["hr"] = 1.2 * s
        return wind


class Ready(CL.Clip):
    """Combat stance loop (the Combat layer's idle: weapon drawn)."""
    loop = True

    def __init__(self, rig, legs, family, fps):
        self.rig, self.legs, self.family = rig, legs, family
        self.name, self.fps, self.seconds = "Ready", fps, 2.0
        self.az0 = legs["Left"].az0
        self.notes = family + ": weapon-drawn stance, breathing"
        self.weight = self.motion = None

    def at(self, t):
        fam = FAMILIES[self.family]
        q = dict(BASE_READY)
        q.update(fam["ready"])
        b = math.sin(2 * math.pi * t)
        q["hz"] = q["hz"] - 0.006 * (0.5 + 0.5 * b)
        q["sl"] = q["sl"] + 0.8 * b
        q["r_fwd"] = q["r_fwd"] + 1.5 * math.sin(2 * math.pi * t + 0.8)
        if fam.get("two_hand"):
            q["l_fwd"], q["l_lower"], q["l_el"] = q["r_fwd"] - 6, q["r_lower"] - 4, q["r_el"] + 10
        return q


def build_family(rig, legs, family, win, fps):
    """Every clip of one weapon family, in controller order."""
    fam = FAMILIES[family]
    out = [Ready(rig, legs, family, fps)]
    hits = fam["hits"]
    weights = chain_weights(len(hits))
    for i, (m, w) in enumerate(zip(hits, weights)):
        hand = "left" if (fam.get("alt") and i % 2 == 1 and m == "jab") else "right"
        out.append(CombatClip(rig, legs, family, "Hit%d" % (i + 1), w, m, win[w], fps, hand=hand, two_hand=bool(fam.get("two_hand")), dual=bool(fam.get("dual"))))
    out.append(ChargeLoop(rig, legs, family, fps))
    specials = [("HeavyRelease", "heavy", fam["heavy"]), ("Riposte", "heavy", fam["riposte"]), ("Launcher", "launch", fam["launcher"]),
                ("Slam", "heavy", fam["slam"]), ("SkillCast", "medium", fam["skill"])]
    for name, w, m in specials:
        out.append(CombatClip(rig, legs, family, name, w, m, win[w], fps, two_hand=bool(fam.get("two_hand")), dual=False))
    return out
