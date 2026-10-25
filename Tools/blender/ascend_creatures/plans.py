"""
Body plans: one function per designRecipe.baseMesh in species.json. Each fills a Body with metaball elements and the
landmarks features attach to. Proportions vary a little per species (seeded), and the menace style bends them: soft
creatures are rounder, spiky ones hunch forward, elongated ones stretch, broken ones go lopsided.
"""
import math

from .body import V


def _j(b, x, amt=0.08):
    """Seeded jitter: x scaled by up to +-amt."""
    return x * (1 + b.rng.uniform(-amt, amt))


def leg(b, hip, knee, foot, r0, r1, foot_size=None):
    b.chain([hip, knee, foot], [r0, (r0 + r1) / 2, r1])
    if foot_size:
        b.ellip(V(foot) + V(0, -foot_size[1] * 0.45, -foot_size[2] * 0.3), foot_size)
    b.hips.append(V(hip))
    b.feet.append(V(foot))


def arm(b, sh, el, hand, r0, r1, fist):
    b.chain([sh, el, hand], [r0, (r0 + r1) / 2, r1])
    b.ball(hand, fist)
    b.shoulders.append(V(sh))
    b.hands.append(V(hand))


# ----------------------------------------------------------------------------------------------------------------


def biped(b, look, build="medium"):
    """Bipeds in three builds, shaped by the species profile (bulk, limb thickness, head, muzzle, hunch, arm reach)."""
    b.kind = "biped"
    P = b.P
    m = look.menace
    hunch = (0.06 if m == "spiky" else 0.0) + P["hunch"]
    st = (1.12 if m == "elongated" else 1.0) * P["arms"]
    lm, bk, hm = P["limb"] * P.get("vbulk", 1.0), P["bulk"] * P.get("vbulk", 1.0), P["head"]
    if build == "small":   # chibi goblins, kobolds, imps: big head, short limbs
        hr = _j(b, 0.2) * hm
        b.head, b.head_r = V(0, -0.02 - hunch, 0.72), hr
        b.ellip((0, -hunch * 0.5, 0.46), (0.15 * bk, 0.12 * bk, 0.15))
        b.ball((0, 0.0, 0.33), 0.125 * bk)
        b.ellip(b.head, (hr, hr * 0.95, hr * 0.92))
        b.chain([(0, -hunch * 0.6, 0.55), b.head], 0.07 * lm)
        for s in (-1, 1):
            leg(b, (s * 0.07, 0, 0.3), (s * 0.085, -0.02, 0.16), (s * 0.09, -0.01, 0.045), 0.06 * lm, 0.045 * lm, (0.06, 0.1, 0.04))
            arm(b, (s * 0.15 * bk, -hunch * 0.5, 0.55), (s * 0.21 * bk, -0.02 - hunch, 0.55 - 0.13 * st), (s * 0.23 * bk, -0.06 - hunch * 1.5, 0.55 - 0.25 * st),
                0.045 * lm, 0.036 * lm, 0.05 * lm)
        b.neck, b.torso_r = V(0, -hunch * 0.5, 0.6), 0.15 * bk
        b.eye_size, b.eye_spread = 0.22, 27
    elif build == "large":  # ogres, trolls, minotaurs: small head, huge shoulders, long arms
        hr = _j(b, 0.1) * hm
        b.head, b.head_r = V(0, -0.1 - hunch, 0.83), hr
        b.ellip((0, -0.02, 0.63), (0.25 * bk, 0.17 * bk, 0.2))
        b.ball((0, -0.05, 0.45), 0.19 * bk)
        b.ellip((0, 0.0, 0.36), (0.17 * bk, 0.13 * bk, 0.1))
        b.ellip(b.head, (hr, hr * 1.05, hr * 0.95))
        b.chain([(0, -0.05, 0.74), b.head], 0.09 * lm)
        for s in (-1, 1):
            leg(b, (s * 0.1 * bk, 0, 0.34), (s * 0.12 * bk, -0.03, 0.19), (s * 0.13 * bk, -0.02, 0.05), 0.095 * lm, 0.07 * lm, (0.085, 0.12, 0.05))
            arm(b, (s * 0.27 * bk, -0.02, 0.73), (s * 0.35 * bk, -0.03 - hunch, 0.73 - 0.23 * st), (s * 0.37 * bk, -0.08 - hunch * 1.5, 0.73 - 0.49 * st),
                0.09 * lm, 0.07 * lm, 0.095 * lm)
            b.ball((s * 0.25 * bk, -0.01, 0.75), 0.11 * lm)   # shoulder mass
        b.neck, b.torso_r = V(0, -0.05, 0.76), 0.24 * bk
        b.eye_size, b.eye_spread = 0.22, 32
    else:  # human-sized
        hr = _j(b, 0.085) * hm
        b.head, b.head_r = V(0, -0.01 - hunch, 0.905 - hunch * 0.5), hr
        b.ellip((0, -hunch * 0.4, 0.67), (0.13 * bk, 0.09 * bk, 0.12))
        b.ellip((0, 0, 0.53), (0.1 * bk, 0.075 * bk, 0.08))
        b.ellip((0, 0.005, 0.45), (0.115 * bk, 0.085 * bk, 0.07))
        if P["thin"]:  # skeletons and scarecrows: a ribcage of hoops over a thin spine
            for k in range(4):
                b.ellip((0, -0.01, 0.6 + k * 0.045), (0.11 * bk, 0.075, 0.016))
        b.ellip(b.head, (hr, hr * 1.05, hr * 1.08))
        b.chain([(0, -hunch * 0.5, 0.77), b.head], 0.042 * lm)
        for s in (-1, 1):
            leg(b, (s * 0.065, 0, 0.44), (s * 0.068, -0.012, 0.245), (s * 0.072, 0.0, 0.05), 0.058 * lm, 0.036 * lm, (0.042, 0.085, 0.032))
            arm(b, (s * 0.165 * bk, -hunch * 0.4, 0.74), (s * 0.21 * bk, 0.01 - hunch, 0.74 - 0.18 * st), (s * 0.225 * bk, -0.03 - hunch * 2, 0.74 - 0.35 * st),
                0.042 * lm, 0.03 * lm, 0.036 * lm)
        b.neck, b.torso_r = V(0, -hunch * 0.4, 0.78), 0.13 * bk
        b.eye_size, b.eye_spread = 0.27, 28
    if P["snout"] > 0:  # beast heads: a muzzle (werewolves, lizardmen, minotaurs, gnolls)
        hr = b.head_r
        b.snout = b.head + V(0, -hr * (0.75 + 0.45 * P["snout"]), -hr * 0.3)
        b.ellip(b.snout, (hr * 0.5, hr * (0.4 + 0.45 * P["snout"]), hr * 0.45))
        b.eye_spread, b.eye_up = 36, 20
    b.spine = [b.neck + V(0, b.torso_r * 0.7, 0), V(0, b.torso_r * 0.75, b.neck.z * 0.65), V(0, b.torso_r * 0.7, b.hips[0].z + 0.02)]
    b.tail_root, b.tail_dir = V(0, b.torso_r * 0.7, b.hips[0].z), V(0, 1, -0.3).normalized()
    b.wing_root = V(0, b.torso_r * 0.8, b.neck.z - 0.08)
    b.mouth = (b.snout + V(0, -b.head_r * 0.35, -b.head_r * 0.15)) if b.snout else b.head + V(0, -b.head_r * 0.92, -b.head_r * 0.42)


def headless(b, look):
    biped(b, look, "medium")
    # remove the head: drop every element above the neck
    b.els = [e for e in b.els if e[1].z < b.neck.z + 0.03]
    b.ball(b.neck + V(0, 0, 0.02), 0.05)
    b.head = b.neck + V(0, 0, 0.03)
    b.head_r = 0.05
    b.snout = None
    b.eye_count = 0


def quad(b, look, build="large"):
    """Quadrupeds shaped by the species profile: a boar, an elk, a bear, a sabretooth and a salamander differ in body
    length, leg length, neck, head, muzzle, bulk, stance and tail."""
    b.kind = "quad"
    P = b.P
    small = build == "small"
    L, legf, bulk = P["L"], P["leg"], P["bulk"] * P.get("vbulk", 1.0)
    low = P["low"]
    if not small and look.style in ("thick_skin", "fur_rough", "mixed_hide"):
        bulk *= 1.12
    lg = (0.17 if small else 0.33) * legf * (0.6 if low else 1.0)
    br = (0.15 if small else 0.14) * bulk
    zc = lg + br * 0.85
    yc, yh = -0.2 * L, 0.24 * L
    b.ball((0, yc, zc + 0.01), br * 1.05)
    b.ellip((0, (yc + yh) / 2, zc), (br * 0.95, (yh - yc) / 2 + br * 0.35, br * 0.9))
    b.ball((0, yh, zc + 0.02), br * (1.1 if small else 0.95))
    if P["shell"]:
        b.ellip((0, (yc + yh) / 2, zc + br * 0.45), (br * 1.55, (yh - yc) / 2 + br * 1.0, br * 1.15))
    if P["wool"]:
        for k in range(16):
            a = b.rng.uniform(0, math.pi)
            y = b.rng.uniform(yc - br * 0.3, yh + br * 0.3)
            b.ball((math.cos(a) * br * 0.95, y, zc + math.sin(a) * br * 0.8), br * b.rng.uniform(0.38, 0.5))
    # neck and head
    nl = 0.12 * P["neck"]
    neck0 = V(0, yc - br * 0.55, zc + br * 0.35)
    hr = (0.15 if small else 0.1) * P["head"]
    if low:
        head = neck0 + V(0, -nl - hr * 0.8, hr * 0.15)
    else:
        head = neck0 + V(0, -nl * 0.75 - hr * 0.5, nl * 0.95 + hr * 0.45)
    b.head, b.head_r = head, hr
    b.chain([neck0, head], [br * 0.68, hr * 0.8])
    b.ellip(head, (hr * 0.95, hr * 1.05, hr * 0.9))
    sn = P["snout"]
    if sn > 0.05:
        b.snout = head + V(0, -hr * (0.55 + 0.5 * sn), -hr * (0.25 if not low else 0.1))
        b.ellip(b.snout, (hr * 0.5 * (1.15 if low else 1.0), hr * (0.35 + 0.42 * sn), hr * 0.45 * (0.8 if low else 1.0)))
    else:
        b.snout = None
    heads = [head]
    for k in range(1, int(P["heads"])):  # Cerberus and chimeras: more heads on more necks
        s = -1 if k % 2 else 1
        h2 = head + V(s * hr * 2.1, hr * 0.4, -hr * 0.2)
        b.chain([neck0 + V(s * br * 0.4, 0, 0), h2], [br * 0.55, hr * 0.75])
        b.ellip(h2, (hr * 0.9, hr, hr * 0.85))
        if sn > 0.05:
            b.ellip(h2 + V(0, -hr * (0.55 + 0.5 * sn), -hr * 0.25), (hr * 0.45, hr * (0.35 + 0.42 * sn), hr * 0.4))
        heads.append(h2)
    b.extra_heads = heads[1:]
    # legs
    splay = br * 0.9 if low else 0.0
    fx, hx = br * 0.55, br * 0.6
    r0, r1 = br * 0.43, br * 0.24
    for s in (-1, 1):
        fy = yc - br * 0.15
        leg(b, (s * fx, fy, zc - br * 0.35), (s * (fx + splay), fy - 0.01, lg * 0.55 + (0.03 if low else 0)), (s * (fx + splay * 1.3), fy - 0.03, 0.035),
            r0, r1, (r1 * 1.25, r1 * 1.7, r1 * 0.85))
        hy = yh + br * 0.1
        if small and P["ears"] == "tall":  # rabbits: big haunches, long hind feet
            b.ellip((s * hx, hy, zc - br * 0.3), (br * 0.55, br * 0.85, br * 0.8))
            b.ellip((s * hx, hy - br * 0.45, 0.03), (br * 0.32, br * 0.85, br * 0.22))
            b.feet.append(V(s * hx, hy - br * 0.45, 0.03))
        else:
            leg(b, (s * hx, hy, zc - br * 0.3), (s * (hx + splay), hy + 0.06 * legf, lg * 0.5), (s * (hx + splay * 1.3), hy + 0.01, 0.035),
                r0 * 1.12, r1, (r1 * 1.25, r1 * 1.7, r1 * 0.85))
    b.torso_r, b.neck = br, neck0 + V(0, -nl * 0.4, nl * 0.4)
    b.eye_size, b.eye_spread, b.eye_up = (0.3 if small else 0.24), (46 if small else 40), (15 if not low else 30)
    b.spine = [neck0 + V(0, 0, br * 0.5), V(0, yc, zc + br * 0.9), V(0, (yc + yh) / 2, zc + br * 0.85), V(0, yh, zc + br * 0.9)]
    b.tail_root = V(0, yh + br * 0.8, zc + br * 0.25)
    b.face = V(0, -1, -0.05).normalized()
    b.tail_dir = V(0, 1, 0.15 if not low else -0.1).normalized()
    b.wing_root = b.spine[1] + V(0, 0, 0.02)
    b.mouth = (b.snout or b.head) + V(0, -b.head_r * 0.5, -b.head_r * 0.25)
    b.hands = [b.feet[0], b.feet[1]]


def hexapod(b, look, pairs=3):
    b.kind = "insect"
    z = 0.3
    b.ellip((0, -0.15, z), (0.12, 0.13, 0.1))
    b.ellip((0, 0.24, z + 0.04), (0.17, 0.27, 0.14), rot=(-10, 0, 0))
    b.ball((0, -0.02, z), 0.07)
    hr = _j(b, 0.1)
    b.head, b.head_r = V(0, -0.35, z + 0.02), hr
    b.ellip(b.head, (hr, hr * 0.9, hr * 0.9))
    ys = [-0.22 + i * (0.16 / max(1, pairs - 1)) for i in range(pairs)]
    for i, y in enumerate(ys):
        spread = (i - (pairs - 1) / 2) * 0.12
        for s in (-1, 1):
            b.chain([(s * 0.1, y, z - 0.02), (s * 0.3, y + spread * 0.5, z + 0.16), (s * 0.44, y + spread, 0.01)], [0.032, 0.022, 0.013])
            b.feet.append(V(s * 0.44, y + spread, 0.01))
    b.torso_r, b.neck = 0.12, V(0, -0.26, z + 0.03)
    b.eye_size, b.eye_spread, b.eye_up = 0.42, 55, 10
    b.spine = [V(0, -0.15, z + 0.1), V(0, 0.1, z + 0.17), V(0, 0.38, z + 0.14)]
    b.tail_root, b.tail_dir = V(0, 0.5, z + 0.04), V(0, 1, 0)
    b.wing_root = V(0, -0.08, z + 0.12)
    b.mouth = b.head + V(0, -hr * 0.9, -hr * 0.3)
    b.hands = b.feet[:2]


def octopod(b, look):
    b.kind = "spider"
    z = 0.26
    b.ellip((0, -0.12, z), (0.15, 0.16, 0.11))
    b.ball((0, 0.23, z + 0.08), 0.21)
    hr = 0.11
    b.head, b.head_r = V(0, -0.25, z + 0.03), hr
    b.ellip(b.head, (hr, hr * 0.8, hr * 0.8))
    for i, y in enumerate((-0.22, -0.14, -0.06, 0.02)):
        spread = (i - 1.5) * 0.16
        for s in (-1, 1):
            knee = (s * 0.36, y + spread * 0.6, z + 0.24)
            b.chain([(s * 0.11, y, z), knee, (s * 0.58, y + spread * 1.6, 0.01)], [0.035, 0.025, 0.012])
            b.feet.append(V(s * 0.58, y + spread * 1.6, 0.01))
    b.torso_r, b.neck = 0.15, V(0, -0.2, z + 0.05)
    b.eye_count = max(look.eye_count, 8) if look.eye_count != 2 else 8
    b.eye_size, b.eye_spread, b.eye_up = 0.18, 45, 25
    b.spine = [V(0, -0.12, z + 0.1), V(0, 0.15, z + 0.27), V(0, 0.38, z + 0.2)]
    b.tail_root, b.tail_dir = V(0, 0.42, z + 0.1), V(0, 1, 0.4).normalized()
    b.mouth = b.head + V(0, -hr * 0.85, -hr * 0.3)
    b.hands = b.feet[:2]


def serpent(b, look):
    b.kind = "serpent"
    pts = []
    for k in range(12):
        t = k / 11
        y = 0.55 - t * 0.9
        pts.append((0.14 * math.sin(t * math.pi * 2.2), y, 0.07 + (0.0 if t < 0.75 else (t - 0.75) * 1.4)))
    b.chain(pts, [0.02, 0.085])
    hr = 0.1
    b.head, b.head_r = V(pts[-1]) + V(0, -0.1, 0.06), hr
    b.chain([pts[-1], b.head], 0.08)
    b.ellip(b.head, (hr * 0.9, hr * 1.3, hr * 0.75))
    b.snout = b.head + V(0, -hr * 1.1, -0.02)
    b.face = V(0, -1, -0.1).normalized()
    b.legged = False
    b.torso_r, b.neck = 0.085, V(pts[-2])
    b.eye_size, b.eye_spread, b.eye_up = 0.26, 50, 25
    b.spine = [V(p) + V(0, 0, 0.07) for p in reversed(pts[::3])]
    b.tail_root, b.tail_dir = V(pts[0]), V(0, 1, 0)
    b.mouth = b.head + V(0, -hr * 1.2, -hr * 0.3)


def naga(b, look):
    b.kind = "naga"
    coil = []
    for k in range(14):
        a = k / 13 * math.pi * 1.6
        coil.append((0.22 * math.cos(a) * (1 - k / 30), 0.12 + 0.22 * math.sin(a), 0.07 + k * 0.006))
    b.chain(coil, [0.03, 0.11])
    b.chain([coil[-1], (0, -0.15, 0.3), (0, -0.2, 0.48)], [0.11, 0.1])
    b.ellip((0, -0.2, 0.62), (0.13, 0.09, 0.12))
    hr = 0.085
    b.head, b.head_r = V(0, -0.21, 0.84), hr
    b.ellip(b.head, (hr, hr * 1.05, hr * 1.08))
    b.chain([(0, -0.2, 0.72), b.head], 0.042)
    for s in (-1, 1):
        arm(b, (s * 0.16, -0.2, 0.69), (s * 0.21, -0.22, 0.52), (s * 0.22, -0.27, 0.38), 0.04, 0.03, 0.035)
    b.torso_r, b.neck = 0.13, V(0, -0.2, 0.74)
    b.legged = False
    b.eye_size, b.eye_spread = 0.27, 28
    b.spine = [V(0, -0.12, 0.72), V(0, -0.1, 0.5), V(0, 0.0, 0.25)]
    b.tail_root, b.tail_dir = V(coil[0]), V(1, 0, 0)
    b.mouth = b.head + V(0, -hr * 0.92, -hr * 0.42)


def taur(b, look):
    quad(b, look, "large")
    b.kind = "taur"
    b.extra_heads = []
    # replace the beast's head and neck with a human torso
    b.els = [e for e in b.els if not (e[1].y < -0.36 and e[1].z > 0.5)]
    b.chain([(0, -0.26, 0.5), (0, -0.3, 0.66)], [0.14, 0.11])
    b.ellip((0, -0.31, 0.77), (0.13, 0.09, 0.11))
    hr = 0.08
    b.head, b.head_r = V(0, -0.32, 1.0), hr
    b.ellip(b.head, (hr, hr * 1.05, hr * 1.08))
    b.chain([(0, -0.32, 0.87), b.head], 0.04)
    b.shoulders, b.hands = [], []
    for s in (-1, 1):
        arm(b, (s * 0.16, -0.31, 0.84), (s * 0.21, -0.32, 0.67), (s * 0.22, -0.37, 0.52), 0.04, 0.03, 0.035)
    b.face = V(0, -1, 0)
    b.neck = V(0, -0.31, 0.88)
    b.snout = None
    b.eye_size, b.eye_spread, b.eye_up = 0.27, 28, 12
    b.mouth = b.head + V(0, -hr * 0.92, -hr * 0.42)


def avian(b, look):
    b.kind = "bird"
    b.ellip((0, 0.02, 0.45), (0.15, 0.23, 0.16), rot=(-15, 0, 0))
    b.ball((0, -0.12, 0.5), 0.13)
    hr = _j(b, 0.1)
    b.head, b.head_r = V(0, -0.24, 0.72), hr
    b.chain([(0, -0.15, 0.55), (0, -0.22, 0.66)], [0.09, 0.075])
    b.ball(b.head, hr)
    b.snout = b.head + V(0, -hr * 0.95, -0.01)
    for s in (-1, 1):
        b.chain([(s * 0.06, 0.03, 0.34), (s * 0.07, 0.02, 0.17), (s * 0.07, -0.02, 0.02)], [0.03, 0.02, 0.015])
        b.feet.append(V(s * 0.07, -0.02, 0.02))
    b.torso_r, b.neck = 0.15, V(0, -0.2, 0.62)
    b.eye_size, b.eye_spread, b.eye_up = 0.27, 60, 15
    b.spine = [V(0, -0.15, 0.62), V(0, 0.02, 0.6), V(0, 0.2, 0.52)]
    b.tail_root, b.tail_dir = V(0, 0.24, 0.44), V(0, 1, -0.2).normalized()
    b.wing_root = V(0, -0.02, 0.56)
    b.mouth = b.snout
    b.hands = b.feet


def flyer_small(b, look):
    b.kind = "bat"
    b.ellip((0, 0.02, 0.48), (0.1, 0.09, 0.13))
    hr = _j(b, 0.11)
    b.head, b.head_r = V(0, -0.04, 0.66), hr
    b.ball(b.head, hr)
    for s in (-1, 1):
        b.chain([(s * 0.05, 0.03, 0.38), (s * 0.06, 0.04, 0.28)], [0.025, 0.018])
        b.feet.append(V(s * 0.06, 0.04, 0.28))
    b.torso_r, b.neck = 0.1, V(0, 0, 0.58)
    b.legged = False
    b.eye_size, b.eye_spread, b.eye_up = 0.3, 34, 8
    b.spine = [V(0, 0.07, 0.58), V(0, 0.09, 0.45)]
    b.tail_root, b.tail_dir = V(0, 0.08, 0.38), V(0, 1, -0.5).normalized()
    b.wing_root = V(0, 0.05, 0.53)
    b.mouth = b.head + V(0, -hr * 0.92, -hr * 0.4)
    b.hands = b.feet


def dragon(b, look, wyvern=False):
    """Dragons and wyverns: a heavy low body, a forward S-neck, a big horned wedge head and a long tapering tail."""
    b.kind = "dragon"
    if wyvern:  # two legs, the wings are its arms
        b.ellip((0, 0.0, 0.46), (0.15, 0.27, 0.15), rot=(-18, 0, 0))
        b.ball((0, -0.16, 0.52), 0.14)
        for s in (-1, 1):
            leg(b, (s * 0.11, 0.1, 0.4), (s * 0.15, -0.02, 0.24), (s * 0.13, 0.04, 0.04), 0.1, 0.045, (0.06, 0.1, 0.035))
        neck = [(0, -0.22, 0.58), (0, -0.36, 0.7), (0, -0.5, 0.74)]
        z0 = 0.46
    else:
        b.ball((0, -0.17, 0.38), 0.16)
        b.ellip((0, 0.04, 0.38), (0.15, 0.25, 0.14))
        b.ball((0, 0.24, 0.4), 0.14)
        for s in (-1, 1):
            leg(b, (s * 0.1, -0.2, 0.33), (s * 0.15, -0.24, 0.16), (s * 0.14, -0.27, 0.035), 0.08, 0.045, (0.06, 0.08, 0.035))
            leg(b, (s * 0.11, 0.26, 0.36), (s * 0.15, 0.34, 0.19), (s * 0.14, 0.28, 0.035), 0.095, 0.045, (0.06, 0.08, 0.035))
        neck = [(0, -0.28, 0.45), (0, -0.42, 0.56), (0, -0.56, 0.6)]
        z0 = 0.4
    b.chain(neck, [0.11, 0.07])
    hr = 0.1
    b.head, b.head_r = V(neck[-1]) + V(0, -0.07, 0.03), hr
    b.ellip(b.head, (hr * 0.95, hr * 1.15, hr * 0.85))
    b.snout = b.head + V(0, -hr * 1.3, -hr * 0.22)
    b.ellip(b.snout, (hr * 0.62, hr * 1.0, hr * 0.5))
    b.ellip(b.head + V(0, -hr * 0.35, hr * 0.45), (hr * 0.7, hr * 0.6, hr * 0.25))  # brow ridge
    tail = [(0, 0.34, z0 + 0.02), (0.04, 0.55, z0 - 0.08), (0.12, 0.74, z0 - 0.2), (0.16, 0.92, z0 - 0.3), (0.1, 1.08, z0 - 0.34)]
    b.chain(tail, [0.1, 0.012])
    b.torso_r, b.neck = 0.15, V(neck[1])
    b.face = V(0, -1, -0.05).normalized()
    b.eye_size, b.eye_spread, b.eye_up = 0.2, 40, 26
    b.spine = [V(neck[1]) + V(0, 0, 0.08), V(0, -0.12, z0 + 0.15), V(0, 0.08, z0 + 0.15), V(0, 0.28, z0 + 0.13), V(0.04, 0.55, z0 + 0.03),
               V(0.12, 0.74, z0 - 0.12)]
    b.tail_root, b.tail_dir = V(tail[-1]), V(-0.2, 1, -0.1).normalized()
    b.wing_root = V(0, -0.12, z0 + 0.15)
    b.wing_span = 1.15 if not wyvern else 1.3
    b.mouth = b.snout + V(0, -hr * 0.7, -hr * 0.2)
    b.hands = b.feet[:2]


def floating(b, look):
    b.kind = "ghost"
    hr = _j(b, 0.21)
    b.head, b.head_r = V(0, 0, 0.66), hr
    b.ball(b.head, hr)
    b.chain([(0, 0.0, 0.52), (0, 0.04, 0.36), (0.03, 0.1, 0.22), (0.07, 0.16, 0.12)], [0.17, 0.02])
    for s in (-1, 1):
        arm(b, (s * 0.17, -0.02, 0.55), (s * 0.25, -0.07, 0.48), (s * 0.29, -0.11, 0.42), 0.05, 0.03, 0.04)
    b.legged = False
    b.torso_r, b.neck = 0.17, V(0, 0, 0.5)
    b.eye_size, b.eye_spread, b.eye_up = 0.28, 26, 5
    b.spine = [V(0, 0.16, 0.7), V(0, 0.14, 0.5)]
    b.tail_root, b.tail_dir = V(0.07, 0.16, 0.12), V(0, 1, -0.3).normalized()
    b.wing_root = V(0, 0.16, 0.6)
    b.mouth = b.head + V(0, -hr * 0.93, -hr * 0.35)


def fish(b, look):
    b.kind = "fish"
    b.ellip((0, 0.0, 0.42), (0.1, 0.32, 0.17))
    b.ball((0, -0.18, 0.43), 0.13)
    b.chain([(0, 0.25, 0.42), (0, 0.4, 0.42)], [0.08, 0.03])
    hr = 0.12
    b.head, b.head_r = V(0, -0.22, 0.45), hr
    b.legged = False
    b.torso_r, b.neck = 0.12, V(0, -0.15, 0.45)
    b.eye_size, b.eye_spread, b.eye_up = 0.28, 62, 10
    b.spine = [V(0, -0.15, 0.6), V(0, 0.05, 0.6), V(0, 0.25, 0.52)]
    b.tail_root, b.tail_dir = V(0, 0.42, 0.42), V(0, 1, 0)
    b.mouth = b.head + V(0, -hr * 1.0, -hr * 0.3)


def cephalopod(b, look):
    b.kind = "squid"
    b.ellip((0, 0.12, 0.66), (0.19, 0.22, 0.28), rot=(-25, 0, 0))
    hr = 0.16
    b.head, b.head_r = V(0, -0.04, 0.42), hr
    b.ball(b.head, hr)
    for k in range(8):
        a = 2 * math.pi * k / 8
        dx, dy = math.cos(a), math.sin(a)
        b.chain([(dx * 0.08, -0.04 + dy * 0.08, 0.32), (dx * 0.22, -0.04 + dy * 0.22, 0.12), (dx * 0.36, -0.04 + dy * 0.36, 0.03),
                 (dx * 0.45 + dy * 0.06, -0.04 + dy * 0.45 - dx * 0.06, 0.07)], [0.055, 0.008])
    b.legged = False
    b.torso_r, b.neck = 0.18, V(0, 0, 0.5)
    b.eye_size, b.eye_spread, b.eye_up = 0.28, 45, 5
    b.spine = [V(0, 0.15, 0.95), V(0, 0.28, 0.7)]
    b.tail_root, b.tail_dir = V(0, 0.3, 0.85), V(0, 1, 0.5).normalized()
    b.mouth = b.head + V(0, -hr * 0.6, -hr * 0.7)


def aberrant(b, look):
    b.kind = "horror"
    b.ellip((0, 0, 0.42), (0.38, 0.34, 0.4))
    for k in range(9):
        p = (b.rng.uniform(-0.32, 0.32), b.rng.uniform(-0.25, 0.25), b.rng.uniform(0.15, 0.78))
        b.ball(p, b.rng.uniform(0.09, 0.2))
    for k in range(4):
        a = b.rng.uniform(0, 2 * math.pi)
        b.chain([(math.cos(a) * 0.3, math.sin(a) * 0.3, 0.2), (math.cos(a) * 0.5, math.sin(a) * 0.5, 0.08),
                 (math.cos(a + 0.4) * 0.6, math.sin(a + 0.4) * 0.6, 0.03)], [0.07, 0.01])
    b.head, b.head_r = V(0, -0.12, 0.62), 0.3
    b.legged = False
    b.eye_count = max(look.eye_count, 5)
    b.eye_size, b.eye_spread, b.eye_up = 0.16, 50, 15
    b.torso_r, b.neck = 0.36, V(0, -0.1, 0.7)
    b.spine = [V(0, 0.1, 0.85), V(0, 0.25, 0.6)]
    b.tail_root, b.tail_dir = V(0, 0.35, 0.3), V(0, 1, 0)
    b.mouth = V(0, -0.38, 0.4)


def golem(b, look):
    b.kind = "golem"
    b.cube((0, 0, 0.6), (0.22, 0.15, 0.2), rot=(0, 0, 3))
    b.cube((0, -0.02, 0.4), (0.15, 0.12, 0.1))
    b.cube((0, -0.03, 0.88), (0.09, 0.08, 0.08))
    for s in (-1, 1):
        b.cube((s * 0.3, 0, 0.72), (0.1, 0.1, 0.09), rot=(0, s * 10, 0))
        b.cube((s * 0.34, -0.02, 0.52), (0.07, 0.07, 0.12))
        b.cube((s * 0.36, -0.05, 0.3), (0.1, 0.1, 0.09))
        b.cube((s * 0.1, 0, 0.22), (0.08, 0.08, 0.12))
        b.cube((s * 0.11, -0.03, 0.05), (0.09, 0.12, 0.05))
        b.shoulders.append(V(s * 0.3, 0, 0.72))
        b.hands.append(V(s * 0.36, -0.05, 0.3))
        b.hips.append(V(s * 0.1, 0, 0.3))
        b.feet.append(V(s * 0.11, -0.03, 0.04))
    b.head, b.head_r = V(0, -0.03, 0.88), 0.09
    b.torso_r, b.neck = 0.2, V(0, 0, 0.8)
    b.eye_size, b.eye_spread, b.eye_up = 0.22, 25, 0
    b.spine = [V(0, 0.15, 0.78), V(0, 0.15, 0.55)]
    b.tail_root, b.tail_dir = V(0, 0.12, 0.35), V(0, 1, 0)
    b.mouth = b.head + V(0, -0.08, -0.04)


def mimic(b, look):
    b.kind = "mimic"
    b.ellip((0, 0.0, 0.28), (0.28, 0.2, 0.15))        # the flesh inside the chest
    b.chain([(0, -0.05, 0.3), (0, -0.25, 0.25), (0.05, -0.38, 0.1)], [0.06, 0.035])  # tongue
    b.head, b.head_r = V(0, -0.05, 0.38), 0.25
    b.legged = False
    b.eye_count = 1 if look.eye_count == 2 else look.eye_count
    b.eye_size, b.eye_spread, b.eye_up = 0.22, 0, 5
    b.torso_r, b.neck = 0.25, V(0, 0, 0.4)
    b.spine = [V(0, 0.12, 0.5)]
    b.tail_root, b.tail_dir = V(0, 0.22, 0.2), V(0, 1, 0)
    b.mouth = V(0, -0.2, 0.36)


def plant(b, look, walker=True):
    b.kind = "plant"
    if walker:
        b.chain([(0, 0, 0.22), (0, 0, 0.5), (0, -0.02, 0.72)], [0.14, 0.11])
        for k in range(4):
            a = 2 * math.pi * (k + 0.5) / 4
            b.chain([(0, 0, 0.25), (math.cos(a) * 0.18, math.sin(a) * 0.18, 0.12), (math.cos(a) * 0.3, math.sin(a) * 0.3, 0.02)], [0.07, 0.02])
            b.feet.append(V(math.cos(a) * 0.3, math.sin(a) * 0.3, 0.02))
        for s in (-1, 1):
            arm(b, (s * 0.1, 0, 0.6), (s * 0.27, -0.03, 0.66), (s * 0.36, -0.08, 0.5), 0.05, 0.025, 0.03)
        b.head, b.head_r = V(0, -0.03, 0.72), 0.13
    else:
        b.ellip((0, 0, 0.2), (0.2, 0.2, 0.2))
        b.chain([(0, 0, 0.3), (0, -0.04, 0.5), (0, -0.08, 0.62)], [0.06, 0.05])
        b.head, b.head_r = V(0, -0.1, 0.68), 0.13
        b.ball(b.head, 0.11)
        b.legged = False
    b.torso_r, b.neck = 0.13, V(0, 0, 0.6)
    b.eye_size, b.eye_spread, b.eye_up = 0.28, 30, 5
    b.spine = [V(0, 0.1, 0.65), V(0, 0.12, 0.35)]
    b.tail_root, b.tail_dir = V(0, 0.12, 0.25), V(0, 1, 0)
    b.wing_root = b.head + V(0, 0, 0.08)
    b.mouth = b.head + V(0, -b.head_r * 0.9, -b.head_r * 0.3)


def swarm(b, look):
    b.kind = "swarm"
    b.units = []
    for k in range(13):
        p = V(b.rng.uniform(-0.4, 0.4), b.rng.uniform(-0.32, 0.32), b.rng.uniform(0.25, 0.95))
        b.ellip(p, (0.045, 0.06, 0.04))
        b.ball(p + V(0, -0.055, 0.01), 0.032)
        b.units.append(p)
    b.head, b.head_r = V(0, -0.1, 0.6), 0.05
    b.eye_count = 0
    b.legged = False
    b.torso_r, b.neck = 0.05, V(0, 0, 0.6)
    b.spine = [V(0, 0, 0.9)]
    b.tail_root, b.tail_dir = V(0, 0.3, 0.5), V(0, 1, 0)
    b.mouth = None


def blob(b, look):
    b.kind = "blob"
    soft = look.menace == "soft"
    b.ellip((0, 0, 0.36), (0.48, 0.46, 0.38 if soft else 0.42))
    b.ellip((0, 0.02, 0.62), (0.3, 0.29, 0.25))
    b.ball((0, 0.03, 0.82), 0.09)        # the teardrop crown
    b.ellip((0, 0, 0.07), (0.52, 0.5, 0.08))   # a puddled rim
    b.head, b.head_r = V(0, -0.05, 0.42), 0.46
    b.face = V(0, -1, 0.15).normalized()
    b.legged = False
    b.eye_size, b.eye_spread, b.eye_up = 0.12, 18, 6
    b.torso_r, b.neck = 0.45, V(0, 0, 0.75)
    b.spine = [V(0, 0.2, 0.75)]
    b.tail_root, b.tail_dir = V(0, 0.4, 0.15), V(0, 1, 0)
    b.wing_root = V(0, 0.15, 0.6)
    b.mouth = V(0, -0.47, 0.3)


PLANS = {
    "blob_base": blob,
    "small_biped_base": lambda b, l: biped(b, l, "small"),
    "medium_biped_base": lambda b, l: biped(b, l, "medium"),
    "large_biped_base": lambda b, l: biped(b, l, "large"),
    "quad_small_base": lambda b, l: quad(b, l, "small"),
    "quad_large_base": lambda b, l: quad(b, l, "large"),
    "hexapod_base": hexapod,
    "octopod_base": octopod,
    "serpent_base": serpent,
    "naga_base": naga,
    "taur_base": taur,
    "avian_base": avian,
    "flyer_small_base": flyer_small,
    "dragon_base": dragon,
    "wyvern_base": lambda b, l: dragon(b, l, True),
    "floating_base": floating,
    "fish_base": fish,
    "cephalopod_base": cephalopod,
    "aberrant_base": aberrant,
    "golem_base": golem,
    "mimic_base": mimic,
    "plant_walker_base": lambda b, l: plant(b, l, True),
    "plant_rooted_base": lambda b, l: plant(b, l, False),
    "swarm_base": swarm,
    "headless_base": headless,
}
