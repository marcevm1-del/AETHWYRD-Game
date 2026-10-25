"""
Creature features: every part in the species designRecipe vocabulary, plus eyes and mouths.

Two phases:
- organic(body, look): soft parts added as metaballs before tessellation, so they melt into the body like sculpted
  clay (ears, tails, manes, extra limbs, tentacles, brows, noses, bubbles).
- hard(ctx): crisp parts built as bevelled meshes after tessellation (eyes, teeth, horns, claws, armour, cloth,
  weapons, wings, growths and so on). Surface details are scattered on the real body surface.
"""
import math

import numpy as np
from mathutils import Matrix, Vector

from ascend_buildings.geo import Geo, trs

from .body import V

# ================================================================================================================
# helpers


def aim(p, d, up=(0, 0, 1)):
    """A 4x4 at p whose local +Z points along d."""
    d = Vector(d).normalized()
    u = Vector(up)
    if abs(d.dot(u)) > 0.95:
        u = Vector((0, 1, 0))
    x = u.cross(d).normalized()
    y = d.cross(x).normalized()
    return Matrix(((x.x, y.x, d.x, p[0]), (x.y, y.y, d.y, p[1]), (x.z, y.z, d.z, p[2]), (0, 0, 0, 1)))


def tube(g, pts, radii, mat, segs=10, cap=True, flat=1.0):
    """Sweeps a circle (squashed by `flat`) along points with per-point radii: horns, claws, whiskers, antennae."""
    pts = [Vector(p) for p in pts]
    n = len(pts)
    if isinstance(radii, (int, float)):
        radii = [radii] * n
    if len(radii) == 2 and n > 2:
        radii = [radii[0] + (radii[1] - radii[0]) * i / (n - 1) for i in range(n)]
    verts, faces = [], []
    tang = [(pts[min(i + 1, n - 1)] - pts[max(i - 1, 0)]).normalized() for i in range(n)]
    ref = Vector((0, 0, 1)) if abs(tang[0].z) < 0.9 else Vector((1, 0, 0))
    x = ref.cross(tang[0]).normalized()
    for i in range(n):
        if i:
            x = (x - tang[i] * x.dot(tang[i])).normalized()  # parallel transport
        y = tang[i].cross(x).normalized()
        for k in range(segs):
            a = 2 * math.pi * k / segs
            off = x * math.cos(a) * radii[i] + y * math.sin(a) * radii[i] * flat
            verts.append(tuple(pts[i] + off))
    for i in range(n - 1):
        for k in range(segs):
            a, b = i * segs + k, i * segs + (k + 1) % segs
            faces.append((a, b, b + segs, a + segs))
    if cap:
        faces.append(tuple(range(segs - 1, -1, -1)))
        if radii[-1] > 1e-5:
            faces.append(tuple(range((n - 1) * segs, n * segs)))
    g.add(verts, faces, mat)


def curve(p0, d0, length, bend, n=8, twist=(0, 0, 1)):
    """Points along a curving horn or tail: starts at p0 heading d0, bending towards `twist` by `bend` radians."""
    pts = [Vector(p0)]
    d = Vector(d0).normalized()
    t = Vector(twist).normalized()
    step = length / n
    for _ in range(n):
        d = (d + t * math.tan(bend / n)).normalized()
        pts.append(pts[-1] + d * step)
    return pts


def mirror(fn, b, *args):
    for s in (-1, 1):
        fn(s, *args)


# ================================================================================================================
# organic phase (metaballs)


def ears(b, head, hr, kind):
    """Ear shapes: pointy (wolves, cats), tall (rabbits), big (foxes, gremlins), round (bears, rats), long (deer),
    side (sheep, minotaurs), small (horses), tuft (owlbears, griffons), goblin (long, swept back)."""
    if not kind or kind == "none":
        return
    for s in (-1, 1):
        if kind == "round":
            b.ball(head + Vector((s * hr * 0.62, hr * 0.15, hr * 0.72)), hr * 0.28)
            continue
        if kind == "goblin":
            base = head + Vector((s * hr * 0.82, hr * 0.12, hr * 0.08))
            tip = base + Vector((s * hr * 1.15, hr * 0.45, hr * 0.38))
            r = (hr * 0.17, hr * 0.12, hr * 0.02)
        elif kind in ("long", "side"):
            base = head + Vector((s * hr * 0.75, hr * 0.15, hr * 0.45))
            tip = base + Vector((s * hr * 0.85, hr * 0.15, hr * (0.15 if kind == "long" else -0.35)))
            r = (hr * 0.2, hr * 0.17, hr * 0.04)
        else:
            L = {"pointy": 0.9, "tall": 1.6, "big": 1.25, "small": 0.55, "tuft": 0.5}.get(kind, 0.9)
            w = {"big": 0.3, "tall": 0.22, "tuft": 0.1}.get(kind, 0.24)
            base = head + Vector((s * hr * 0.55, hr * 0.1, hr * 0.62))
            tip = base + Vector((s * hr * 0.3, hr * 0.2, hr * L))
            r = (hr * w, hr * w * 0.75, hr * 0.03)
        b.chain([base, base.lerp(tip, 0.5), tip], list(r))


def organic(b, look):
    parts = set(look.parts)
    hr, tr = b.head_r, b.torso_r
    rng = b.rng
    # brows: angry for spiky creatures
    if look.menace == "spiky" and b.eye_count and b.kind not in ("blob", "swarm", "mimic"):
        for p, d, r in b.eye_points():
            b.ellip(p + d * 0.2 * hr + Vector((0, 0, r * 1.15)), (r * 1.1, r * 0.55, r * 0.35))
    if b.kind == "biped" and b.eye_count and "mask" not in parts:  # a little nose
        f = b.face.normalized()
        b.ellip(b.head + f * hr * 0.92 + Vector((0, 0, -hr * 0.12)), (hr * 0.13, hr * 0.12, hr * 0.12))
    if look.family in ("Goblinoids", "Kobolds", "Gremlins", "Demons") and b.kind == "biped" and not parts & {"ears_long", "ears_tall"}:
        parts.add("ears_long")
    if "nose_hooked" in parts:
        f = b.face.normalized()
        b.chain([b.head + f * hr * 0.9, b.head + f * hr * 1.25 + Vector((0, 0, -hr * 0.25))], [hr * 0.16, hr * 0.08])
    ear = b.P.get("ears")
    if "ears_tall" in parts:
        ear = "tall"
    elif "ears_long" in parts and not ear:
        ear = "goblin"
    for head in [b.head] + list(getattr(b, "extra_heads", [])):
        ears(b, head, hr, ear)
    if parts & {"mane", "hair_mane", "hair_bristles", "fur_tufts"}:
        n = 14 if "mane" in parts or "hair_mane" in parts else 8
        for k in range(n):
            a = math.pi * (0.15 + 0.7 * k / max(1, n - 1))
            p = b.neck + Vector((math.cos(a) * tr * 0.9, tr * 0.55 + rng.uniform(-0.02, 0.02), math.sin(a) * tr * 0.55 + hr * 0.3))
            b.ball(p, tr * rng.uniform(0.25, 0.38))
    tails = [p for p in look.parts if p.startswith("tail") or p in ("stinger", "rattle_tail")]
    tail_len = b.P.get("tail", 1.0)
    if b.P.get("tail") is True:
        tail_len = 1.0
    want_tail = tails or (b.kind in ("quad", "bird") and tail_len) or (b.kind == "biped" and b.P.get("tail") is True)
    for ti in range(int(b.P.get("tails", 1)) if want_tail and b.tail_root is not None else 0):
        kind = tails[0] if tails else ("tail_bushy" if look.style.startswith("fur") and b.kind == "quad" else "tail")
        L = {"tail_thin": 0.45, "stinger": 0.4, "tail_plumes": 0.25}.get(kind, 0.38) * (1.4 if b.kind in ("biped",) else 1.0)
        L *= float(tail_len) if not isinstance(tail_len, bool) else 1.0
        if L < 0.05:
            break
        fan = (ti - (b.P.get("tails", 1) - 1) / 2) * 0.35
        td = (b.tail_dir + Vector((fan, 0, abs(fan) * 0.3))).normalized()
        r0 = tr * (0.3 if kind != "tail_thin" else 0.15)
        up = 0.9 if kind in ("stinger",) and b.kind == "spider" else (0.6 if b.kind == "quad" else 0.2)
        pts = curve(b.tail_root, td, L, up, 7, (0, 0, 1))
        if kind == "tail_bushy" and b.torso_r < 0.17 and b.kind == "quad" and b.head_r > 0.13:  # a puff, rabbit-style
            b.ball(b.tail_root + td * r0 * 0.6, r0 * 1.2)
            pts = [b.tail_root, b.tail_root + td * r0]
        elif kind == "tail_bushy":
            b.chain(pts, [r0 * 0.8, r0 * 1.4])
            b.ball(pts[-1], r0 * 1.3)
        else:
            b.chain(pts, [r0, r0 * 0.25])
            if kind == "tail_club":
                b.ball(pts[-1], r0 * 1.5)
        b.tail_tip, b.tail_tip_dir = pts[-1], (pts[-1] - pts[-2]).normalized()
    if parts & {"extra_arms", "multiple_arms", "branch_arms", "vine_whips", "root_tendrils", "tentacles"} and b.shoulders:
        n = 4 if "multiple_arms" in parts or "tentacles" in parts else 2
        for k in range(n):
            s = -1 if k % 2 else 1
            sh = b.shoulders[0 if s < 0 else -1] + Vector((0, 0.02, -0.08 - 0.06 * (k // 2)))
            out = Vector((s * 0.6, -0.4, -0.25 - 0.2 * (k // 2))).normalized()
            pts = curve(sh, out, tr * 2.2, rng.uniform(0.5, 1.4), 6, (0, -0.3, -1))
            b.chain(pts, [tr * 0.22, tr * 0.05])
    if b.kind == "serpent" and look.family in ("Insects & Arachnids", "Killer Insects"):  # centipede legs
        for p in b.spine[1:-1] + [b.spine[-1]]:
            for s in (-1, 1):
                q = Vector(p) + Vector((0, 0, -0.06))
                b.chain([q + Vector((s * 0.05, 0, 0)), q + Vector((s * 0.15, -0.02, 0.0)), q + Vector((s * 0.2, -0.03, -q.z + 0.01))], [0.018, 0.008])
    if "surface_bubbles" in parts:
        for k in range(10):
            p = b.head + Vector((rng.uniform(-1, 1), rng.uniform(-1, 1), rng.uniform(-0.3, 1))).normalized() * b.torso_r * 0.85
            b.ball(p, b.torso_r * rng.uniform(0.08, 0.16))
    if "tongue" in parts and b.mouth is not None:
        f = b.face.normalized()
        b.chain([b.mouth, b.mouth + f * hr * 0.4 + Vector((0, 0, -hr * 0.3)), b.mouth + f * hr * 0.6 + Vector((0, 0, -hr * 0.6))], [hr * 0.14, hr * 0.08])
    if "humanoid_torso" in parts and b.kind not in ("taur", "naga", "biped"):
        b.chain([b.neck, b.neck + Vector((0, -0.05, 0.25))], [tr * 0.6, tr * 0.5])
    if "cap" in parts:  # mushroom folk: the head becomes a cap
        b.ellip(b.head + Vector((0, 0, hr * 0.55)), (hr * 1.9, hr * 1.9, hr * 0.9))


# ================================================================================================================
# hard phase (meshes)


class Ctx:
    def __init__(self, body, look, verts, normals):
        self.b = body
        self.look = look
        self.g = Geo()
        self.v = verts
        self.n = normals
        self.rng = body.rng

    def surface(self, pred, count):
        """Random body-surface points (and normals) whose position/normal satisfy pred(p, n)."""
        idx = [i for i in range(0, len(self.v), max(1, len(self.v) // 4000)) if pred(self.v[i], self.n[i])]
        if not idx:
            return []
        pick = [idx[self.rng.randrange(len(idx))] for _ in range(count)]
        return [(Vector(self.v[i]), Vector(self.n[i])) for i in pick]


def eyes(c):
    b, look, g = c.b, c.look, c.g
    if not b.eye_count:
        return
    style = look.eye_style
    if b.kind in ("spider", "insect") and style == "anime":
        style = "beady"
    pts = list(b.eye_points())
    main_head = b.head
    for h in getattr(b, "extra_heads", []):  # Cerberus' other heads get eyes too
        b.head = h
        pts += b.eye_points()
    b.head = main_head
    for p, d, r in pts:
        p = p - d * r * 0.2  # sit the eye into its socket
        m = aim(p, d)
        if style == "dot":  # slimes: glossy black ovals with a sparkle
            g.sphere(r * 1.0, "eye_dark", m @ trs((0, 0, r * 0.35), (0, 0, 0), (0.75, 1.0, 0.45)), segs=16, rings=10)
            g.sphere(r * 0.28, "highlight", m @ trs((-r * 0.25, r * 0.35, r * 0.8)), segs=8, rings=6)
            continue
        if style == "beady":
            g.sphere(r, "eye_dark", m, segs=16, rings=10)
            g.sphere(r * 0.25, "highlight", m @ trs((-r * 0.35, r * 0.35, r * 0.85)), segs=8, rings=6)
            continue
        # anime eye: white, iris, pupil and two sparkles; glowing irises for menacing styles
        g.sphere(r, "eye_white", m, segs=20, rings=12)
        iris = "glow" if style in ("glow",) else "iris"
        # every layer sits proud of the one under it: white (r), iris (front 1.035r), pupil (1.06r), sparkles
        g.sphere(r * 0.7, iris, m @ trs((0, 0, r * 0.72), (0, 0, 0), (1, 1, 0.45)), segs=18, rings=10)
        if style == "slit":
            g.sphere(r * 0.6, "eye_dark", m @ trs((0, 0, r * 0.8), (0, 0, 0), (0.22, 1, 0.55)), segs=12, rings=8)
        else:
            g.sphere(r * 0.4, "eye_dark", m @ trs((0, 0, r * 0.8), (0, 0, 0), (1, 1, 0.65)), segs=14, rings=8)
        g.sphere(r * 0.17, "highlight", m @ trs((-r * 0.26, r * 0.28, r * 0.97)), segs=8, rings=6)
        g.sphere(r * 0.08, "highlight", m @ trs((r * 0.24, -r * 0.24, r * 1.0)), segs=6, rings=4)


def teeth_row(c, centre, width, size, count, mat="teeth", down=True, curve_=0.0):
    f = c.b.face.normalized()
    side = f.cross(Vector((0, 0, 1))).normalized()
    for k in range(count):
        t = (k - (count - 1) / 2) / max(1, count - 1)
        p = centre + side * t * width - f * (abs(t) ** 2) * width * curve_
        d = Vector((0, 0, -1 if down else 1))
        c.g.lathe([(size * 0.32, 0), (size * 0.22, size * 0.6), (0, size)], mat, aim(p, d), segs=6)


def mouth(c):
    b, parts = c.b, set(c.look.parts)
    if b.mouth is None:
        return
    hr = b.head_r
    f = b.face.normalized()
    m0 = Vector(b.mouth)
    if parts & {"beak", "beak_hooked"} or b.kind == "bird":
        hooked = "beak_hooked" in parts
        tip = m0 + f * hr * (0.9 if not hooked else 0.75) + Vector((0, 0, -hr * (0.05 if not hooked else 0.3)))
        tube(c.g, curve(m0 - f * hr * 0.1, f, hr * 0.85, 0.7 if hooked else 0.15, 6, (0, 0, -1)), [hr * 0.32, hr * 0.02], "gold" if c.look.main[0] < 0.6 else "horn", 12, flat=0.8)
        return
    if "mandibles" in parts or b.kind in ("insect", "spider"):
        side = f.cross(Vector((0, 0, 1))).normalized()
        for s in (-1, 1):
            pts = curve(m0 + side * s * hr * 0.25, f + side * s * 0.4, hr * 0.7, 1.0, 6, -side * s)
            tube(c.g, pts, [hr * 0.12, hr * 0.02], "claw", 8)
        return
    if "petal_jaws" in parts:
        for k in range(5):
            a = 2 * math.pi * k / 5
            d = (f + Vector((math.cos(a), 0, math.sin(a))) * 0.8).normalized()
            c.g.lathe([(0, 0), (hr * 0.35, hr * 0.3), (0, hr * 0.8)], "petal", aim(m0, d) @ trs((0, 0, 0), (0, 0, 0), (1, 0.25, 1)), segs=10)
        teeth_row(c, m0 + f * hr * 0.1, hr * 0.4, hr * 0.18, 6)
        return
    big = parts & {"fangs_long", "tusks", "teeth_rows", "teeth_ring", "hinge_jaw"}
    if c.look.menace in ("spiky", "broken", "elongated") or big or "fangs" in parts:
        teeth_row(c, m0 + f * hr * 0.06, hr * 0.5, hr * 0.14, 7, curve_=0.4)
    if "fangs" in parts or "fangs_long" in parts:
        side = f.cross(Vector((0, 0, 1))).normalized()
        L = hr * (0.35 if "fangs_long" in parts else 0.22)
        for s in (-1, 1):
            c.g.lathe([(L * 0.3, 0), (L * 0.18, L * 0.6), (0, L)], "teeth", aim(m0 + side * s * hr * 0.18 + f * hr * 0.05, (0, 0, -1)), segs=8)
    if "tusks" in parts:
        side = f.cross(Vector((0, 0, 1))).normalized()
        for s in (-1, 1):
            pts = curve(m0 + side * s * hr * 0.3, f * 0.3 + Vector((0, 0, 1)), hr * 0.9, 0.8, 8, f + side * s * 0.4)
            tube(c.g, pts, [hr * 0.14, hr * 0.02], "bone", 10)
    if "teeth_ring" in parts or "teeth_rows" in parts:
        for k in range(14):
            a = 2 * math.pi * k / 14
            side = f.cross(Vector((0, 0, 1))).normalized()
            p = m0 + f * hr * 0.05 + (side * math.cos(a) + Vector((0, 0, 1)) * math.sin(a)) * hr * 0.35
            c.g.lathe([(hr * 0.06, 0), (0, hr * 0.18)], "teeth", aim(p, -(side * math.cos(a) + Vector((0, 0, 1)) * math.sin(a))), segs=6)


def horns(c):
    b, parts, g = c.b, set(c.look.parts), c.g
    hr = b.head_r
    top = b.head + Vector((0, 0, hr * 0.75))
    mat = "bone" if c.look.style in ("rot_bone", "dragon_scale") else "horn"
    if "horn_single" in parts:
        p = b.head + b.face.normalized() * hr * 0.6 + Vector((0, 0, hr * 0.55))
        pts = curve(p, b.face.normalized() * 0.5 + Vector((0, 0, 1)), hr * 1.4, 0.4, 10, (0, 0, 1))
        tube(g, pts, [hr * 0.17, hr * 0.01], mat, 12)
        for k in range(1, 8):  # spiral grooves
            q = pts[k]
            g.lathe([(hr * 0.17 * (1 - k / 10) + 0.002, -0.004), (hr * 0.17 * (1 - k / 10) + 0.006, 0), (hr * 0.17 * (1 - k / 10) + 0.002, 0.004)],
                    "claw", aim(q, (pts[k + 1] - pts[k])), segs=10, cap_bottom=False, cap_top=False)
    if parts & {"horns", "horns_swept", "horns_small"} or (b.kind == "dragon" and not parts & {"horn_single", "horn_crown", "antlers"}):
        L = hr * (1.5 if "horns_swept" in parts else 0.6 if "horns_small" in parts else 1.1)
        for s in (-1, 1):
            p = top + Vector((s * hr * 0.45, hr * 0.1, -hr * 0.1))
            if "horns_swept" in parts or b.kind == "dragon":
                d, tw, bend = Vector((s * 0.2, 0.7, 0.6)), (s * 0.2, 1, -0.6), 0.9
            else:
                d, tw, bend = Vector((s * 0.8, 0.0, 0.6)), (0, -0.4, 1), 1.3
            tube(g, curve(p, d, L, bend, 10, tw), [hr * 0.19, hr * 0.01], mat, 12)
    if "horn_crown" in parts:
        for k in range(5):
            a = math.pi * (0.15 + 0.7 * k / 4)
            p = b.head + Vector((math.cos(a) * hr * 0.7, math.sin(a) * hr * 0.15, hr * 0.6 + math.sin(a) * hr * 0.2))
            tube(g, curve(p, (math.cos(a) * 0.4, 0.1, 1), hr * (0.5 + 0.3 * math.sin(a)), 0.2, 5), [hr * 0.09, hr * 0.005], mat, 8)
    if "antlers" in parts:
        for s in (-1, 1):
            p = top + Vector((s * hr * 0.4, hr * 0.1, -hr * 0.05))
            main = curve(p, (s * 0.6, 0.3, 1), hr * 2.2, 0.8, 10, (s * 0.3, 1, 0))
            tube(g, main, [hr * 0.12, hr * 0.03], "wood" if c.look.style == "bark_leaf" else "bone", 10)
            for k in (3, 5, 7):
                tine = curve(main[k], (s * 0.2, -0.6, 1), hr * 0.7, 0.4, 5, (0, 0, 1))
                tube(g, tine, [hr * 0.07, hr * 0.01], "wood" if c.look.style == "bark_leaf" else "bone", 8)


def claws(c):
    b, parts, g = c.b, set(c.look.parts), c.g
    want = parts & {"claws", "talons"} or b.kind in ("dragon", "bird") or c.look.menace == "spiky" and b.kind in ("quad", "biped")
    if not want:
        return
    f = b.face.normalized()
    pts = list(b.feet) + (list(b.hands) if b.kind == "biped" else [])
    for p in pts:
        r = b.torso_r * 0.12
        for k in (-1, 0, 1):
            side = f.cross(Vector((0, 0, 1))).normalized()
            base = p + f * r * 2.4 + side * k * r * 1.1 + Vector((0, 0, r * 0.3))
            tube(g, curve(base, f + Vector((0, 0, 0.2)), r * 2.2, 1.2, 5, (0, 0, -1)), [r * 0.55, r * 0.03], "claw", 8)


def plates(c, kind):
    """Plates or spikes along the spine; armour plates on chest and shoulders."""
    b, g, rng = c.b, c.g, c.rng
    spiky = kind in ("spine_plates", "scale_ridges", "joint_spikes", "leg_spikes", "carapace_ridges")
    mat = {"bark_plates": "wood", "armored_back": "dark", "scales_armored": "dark", "carapace_ridges": "dark"}.get(kind, "dark")
    spine = b.spine
    if len(spine) < 2:
        return
    n = 9
    for k in range(n):
        t = (k + 0.5) / n
        seg = t * (len(spine) - 1)
        i = min(int(seg), len(spine) - 2)
        p = spine[i].lerp(spine[i + 1], seg - i)
        hit = c.surface(lambda v, nn, p=p: (Vector(v) - p).length < b.torso_r * 0.6 and nn[2] > 0.3, 1)
        if not hit:
            continue
        q, nn = hit[0]
        s = b.torso_r * (0.45 if not spiky else 0.35) * (1 - abs(t - 0.4) * 0.6)
        if spiky:
            g.lathe([(s * 0.45, 0), (s * 0.3, s * 0.5), (0, s * 1.3)], mat, aim(q - nn * s * 0.1, nn + Vector((0, 0.5, 0))), segs=6)
        else:
            g.rbox((s * 1.6, s * 1.2, s * 0.25), mat, aim(q + nn * s * 0.05, nn), s * 0.1, 2)


def armour(c, kind):
    b, g = c.b, c.g
    mat = {"crude_armor": "rust", "barding": "metal", "plate_armor": "metal", "armor_plates": "metal"}.get(kind, "metal")
    if b.shoulders:
        for sh in b.shoulders:
            out = (sh - Vector((0, sh.y, b.neck.z * 0.7))).normalized()
            g.sphere(b.torso_r * 0.42, mat, aim(sh + out * b.torso_r * 0.12 + Vector((0, 0, b.torso_r * 0.12)), out) @ trs((0, 0, 0), (0, 0, 0), (1, 1, 0.55)), segs=16, rings=8)
            if kind == "crude_armor":
                g.lathe([(b.torso_r * 0.08, 0), (0, b.torso_r * 0.3)], "metal_dark", aim(sh + Vector((0, 0, b.torso_r * 0.3)), out + Vector((0, 0, 1))), segs=6)
    for p, nn in c.surface(lambda v, n: n[1] < -0.55 and b.hips and v[2] > b.hips[0].z + 0.05 and v[2] < b.neck.z, 5 if kind != "crude_armor" else 3):
        s = b.torso_r * (0.5 if kind != "crude_armor" else 0.6)
        g.rbox((s, s * 0.8, s * 0.08), mat, aim(p + nn * 0.01, nn), s * 0.06, 2)
        for dx in (-0.4, 0.4):  # rivets
            g.sphere(s * 0.05, "metal_dark", aim(p + nn * s * 0.07, nn) @ trs((dx * s, dx * s * 0.6, 0)), segs=6, rings=4)


def belt(c, kind):
    b, g = c.b, c.g
    if not b.hips:
        return
    z = b.hips[0].z + b.torso_r * 0.2
    r = b.torso_r * (0.82 if b.kind == "biped" else 1.0)
    g.lathe([(r, -0.025), (r * 1.06, -0.02), (r * 1.06, 0.02), (r, 0.025), (r, -0.025)], "leather", T3(0, 0.005, z), segs=36, cap_bottom=False, cap_top=False)
    g.rbox((r * 0.3, r * 0.08, r * 0.25), "gold", None, r * 0.03, 2, (0, -r * 1.05, z))
    if kind in ("chains", "chain_belt"):
        for k in range(10):
            a = math.pi * (1.2 + 0.6 * k / 9)
            p = Vector((math.cos(a) * r * 1.08, math.sin(a) * r * 1.08, z - 0.03 - 0.04 * math.sin(math.pi * k / 9)))
            g.lathe([(r * 0.05, -r * 0.012), (r * 0.065, 0), (r * 0.05, r * 0.012), (r * 0.035, 0), (r * 0.05, -r * 0.012)], "metal",
                    aim(p, (math.cos(a + 1.57 * (k % 2)), math.sin(a), 0.3 * (k % 2))), segs=10, cap_bottom=False, cap_top=False)


def T3(x, y, z):
    return Matrix.Translation((x, y, z))


def cloth(c, kind):
    """Cloaks, shrouds, hoods and loincloths as draped surfaces with a ragged hem."""
    b, g, rng = c.b, c.g, c.rng
    tr = b.torso_r
    tattered = kind in ("tattered_shroud", "tattered_cape")
    mat = "cloth" if kind != "loincloth" else "leather"
    if kind in ("cloak", "tattered_shroud", "tattered_cape"):
        top = b.neck.z - 0.02
        bottom = max(0.03, (b.feet[0].z if b.feet else 0.0) + (0.12 if b.legged else 0.0))
        r0, r1 = tr * 1.05, tr * 1.8

        def fn(u, v):
            a = math.pi * (0.1 + 0.8 * u)  # behind the body, from one shoulder round to the other
            z = top - (top - bottom) * v
            r = r0 + (r1 - r0) * v + 0.02 * math.sin(u * 23 + v * 3)
            hem = 0.0
            if tattered and v > 0.85:
                hem = 0.06 * abs(math.sin(u * 40)) * (v - 0.85) / 0.15
            return (math.cos(a) * r, b.neck.y + math.sin(a) * r + 0.02, z + hem)
        g.patch(fn, 28, 14, mat, None, 0.012)
        for s in (-1, 1):
            g.sphere(tr * 0.12, "gold", T3(s * tr * 0.7, b.neck.y - tr * 0.4, top), segs=10, rings=6)
    if kind == "hood":
        hr = b.head_r

        def fn(u, v):
            a = math.pi * (-0.15 + 1.3 * u)
            ph = math.pi * 0.5 * v
            r = hr * 1.18
            return (b.head.x + math.cos(a) * r * math.cos(ph) * 1.0, b.head.y + math.sin(a) * r * math.cos(ph) + hr * 0.1,
                    b.head.z + r * math.sin(ph) * 1.1 - hr * 0.1)
        g.patch(fn, 20, 10, "cloth", None, 0.015)
    if kind == "loincloth" and b.hips:
        z = b.hips[0].z + tr * 0.15
        for side in (-1, 1):
            def fn(u, v, side=side):
                return ((u - 0.5) * tr * 1.2, side * tr * 0.92 + side * v * 0.04, z - v * tr * 1.6)
            g.patch(fn, 6, 6, mat, None, 0.012)


def mask(c, kind):
    b, g = c.b, c.g
    hr = b.head_r
    f = b.face.normalized()
    m = aim(b.head + f * hr * 0.82, f)

    def fn(u, v):  # an oval mask curved round the face
        e = (v - 0.5) * 2.0
        a = (u - 0.5) * 2.2 * math.sqrt(max(0.05, 1 - e * e * 0.85))
        return (math.sin(a) * hr * 0.75, e * hr * 0.9, math.cos(a) * hr * 0.25 - e * e * hr * 0.12)
    key = {"human_mask": "eye_white", "mask_face": "bone", "empty_visor": "metal", "face_decal": "accent"}.get(kind, "bone")
    if kind == "face_decal":
        for s in (-1, 1):
            g.rbox((hr * 0.12, hr * 0.5, hr * 0.02), "accent", m @ trs((s * hr * 0.4, -hr * 0.2, hr * 0.17), (0, 0, s * 10)), hr * 0.01, 1)
        return
    g.patch(fn, 14, 12, key, m @ trs((0, 0, hr * 0.02)), hr * 0.06)
    for s in (-1, 1):  # eye holes painted dark, glowing for empty visors
        g.sphere(hr * 0.13, "glow" if kind == "empty_visor" else "eye_dark", m @ trs((s * hr * 0.32, hr * 0.15, hr * 0.3), (0, 0, 0), (1.3, 0.8, 0.3)), segs=10, rings=6)


def wings(c, kind):
    b, g = c.b, c.g
    root = b.wing_root or (b.spine[0] if b.spine else b.neck)
    span = max(0.45, b.torso_r * 4.0) if b.kind not in ("bat",) else 0.55
    feather = kind == "wing_feathers" or b.kind == "bird"
    if kind == "wing_cases":  # beetle elytra over the back
        for s in (-1, 1):
            def fn(u, v, s=s):
                a = math.pi * 0.5 * u
                return (s * math.sin(a) * b.torso_r * 1.05, root.y + v * b.torso_r * 2.8, root.z + math.cos(a) * b.torso_r * 0.6 - v * 0.06)
            g.patch(fn, 10, 12, "dark", None, 0.015)
        return
    span = getattr(b, "wing_span", None) or span
    for s in (-1, 1):
        sh = root + Vector((s * b.torso_r * 0.5, 0.02, 0.02))
        if feather:
            elbow = sh + Vector((s * span * 0.45, span * 0.12, span * 0.35))
            tip = elbow + Vector((s * span * 0.6, span * 0.25, -span * 0.05))
            tube(g, [sh, elbow], [b.torso_r * 0.12, b.torso_r * 0.08], "feather", 10)
            tube(g, [elbow, tip], [b.torso_r * 0.08, b.torso_r * 0.02], "feather", 10)
            for k in range(9):  # primaries and secondaries
                t = k / 8
                base = elbow.lerp(tip, t) if t > 0.3 else sh.lerp(elbow, t / 0.3)
                L = span * (0.32 + 0.25 * t)
                d = Vector((s * 0.25 * t, 0.55, -1)).normalized()
                g.sphere(0.5, "feather_tip" if k > 5 else "feather", aim(base + d * L * 0.5, d) @ trs((0, 0, 0), (0, 0, 0), (span * 0.07, span * 0.018, L * 0.55)), segs=8, rings=6)
            continue
        # a bat/dragon wing: arm up and out, a wrist, four fingers fanning back and down, a scalloped membrane
        elbow = sh + Vector((s * span * 0.3, span * 0.05, span * 0.32))
        wrist = elbow + Vector((s * span * 0.32, -span * 0.08, span * 0.12))
        r0 = b.torso_r * (0.16 if b.kind == "dragon" else 0.12)
        tube(g, [sh, elbow, wrist], [r0, r0 * 0.6], "main", 12)
        g.lathe([(r0 * 0.4, 0), (0, r0 * 2.2)], "claw", aim(wrist, (s * 0.3, -0.6, 0.8)), segs=6)  # thumb claw
        fingers = []
        for k, (out, back, down) in enumerate(((0.42, 0.05, 0.02), (0.36, 0.3, -0.22), (0.24, 0.48, -0.42), (0.1, 0.55, -0.55))):
            tipf = wrist + Vector((s * span * out, span * back, span * down))
            fingers.append(tipf)
            tube(g, [wrist, wrist.lerp(tipf, 0.5) + Vector((0, 0, span * 0.03)), tipf], [r0 * 0.45, r0 * 0.1], "main", 8)
        trail = sh + Vector((s * span * 0.05, span * 0.42, -span * 0.12))  # where the membrane meets the flank
        edge = [elbow, wrist] + fingers + [trail]
        verts, faces = [tuple(sh)], []
        for i in range(len(edge) - 1):  # scallop each span between finger tips inward a little
            a, z = edge[i], edge[i + 1]
            for t in (0.0, 0.33, 0.66):
                q = a.lerp(z, t)
                if i >= 2 and t > 0:
                    q = q.lerp(wrist, 0.12 * math.sin(math.pi * t))
                verts.append(tuple(q))
        verts.append(tuple(edge[-1]))
        n = len(verts)
        for i in range(1, n - 1):
            faces.append((0, i, i + 1) if s > 0 else (0, i + 1, i))
        g.add(verts, faces, "membrane")
        g.add(verts, [tuple(reversed(x)) for x in faces], "membrane")


def growths(c, kind):
    b, g, rng = c.b, c.g, c.rng
    mat = {"stone_growths": "stone", "crystal_growths": "crystal", "moss_cover": "moss", "thorns": "wood",
           "spore_pods": "spore", "glowing_spots": "glow", "glowing_knots": "glow", "scar_decals": "dark"}[kind]
    n = {"moss_cover": 26, "scar_decals": 6, "glowing_spots": 18}.get(kind, 10)
    for p, nn in c.surface(lambda v, n: n[2] > -0.1, n):
        s = b.torso_r * rng.uniform(0.12, 0.3)
        if kind == "crystal_growths":
            for k in range(3):
                d = (nn + Vector((rng.uniform(-0.5, 0.5), rng.uniform(-0.5, 0.5), rng.uniform(0, 0.5)))).normalized()
                g.lathe([(0, 0), (s * 0.3, s * 0.2), (s * 0.28, s * 1.4), (0, s * 1.9)], mat, aim(p - nn * s * 0.2, d), segs=6)
        elif kind in ("stone_growths",):
            g.rbox((s, s * 0.9, s * 0.7), mat, aim(p, nn) @ trs((0, 0, 0), (rng.uniform(0, 40), rng.uniform(0, 40), rng.uniform(0, 90))), s * 0.15, 2)
        elif kind == "thorns":
            g.lathe([(s * 0.18, 0), (0, s * 0.9)], mat, aim(p - nn * 0.005, nn + Vector((0, 0.4, 0))), segs=6)
        elif kind == "moss_cover":
            g.sphere(s * 0.8, mat, aim(p, nn) @ trs((0, 0, 0), (0, 0, 0), (1, 1, 0.35)), segs=8, rings=5)
        elif kind == "spore_pods":
            g.sphere(s * 0.6, mat, aim(p + nn * s * 0.3, nn), segs=10, rings=6)
        elif kind == "scar_decals":
            g.rbox((s * 1.2, s * 0.08, s * 0.03), mat, aim(p + nn * 0.002, nn) @ trs((0, 0, 0), (0, 0, rng.uniform(0, 180))), s * 0.01, 1)
        else:
            g.sphere(s * 0.35, mat, aim(p, nn) @ trs((0, 0, 0), (0, 0, 0), (1, 1, 0.4)), segs=8, rings=5)


def weapon(c, kind):
    b, g = c.b, c.g
    if not b.hands:
        return
    h = b.hands[-1]
    s = b.torso_r * (5.5 if b.kind != "golem" else 3.5)
    if kind == "club_socket":
        club = aim(h + Vector((0, -0.01, -s * 0.15)), (0.1, -0.4, 1))
        g.lathe([(0.0, 0.0), (s * 0.035, 0.0), (s * 0.04, s * 0.3), (s * 0.09, s * 0.65), (s * 0.08, s * 0.8), (0.0, s * 0.82)], "wood", club, segs=12)
        for k in range(6):  # iron studs round the club head
            g.lathe([(s * 0.012, 0), (0, s * 0.06)], "metal_dark", club @ trs((0, 0, s * (0.6 + 0.1 * (k % 2))), (0, 0, k * 60)) @ trs((s * 0.085, 0, 0), (0, 90, 0)), segs=5)
    elif kind == "lance":
        tube(g, [h + Vector((0, s * 0.4, -s * 0.2)), h + Vector((0, -s * 0.9, s * 0.15))], [s * 0.022, s * 0.018], "wood", 10)
        g.lathe([(s * 0.04, 0), (0, s * 0.25)], "metal", aim(h + Vector((0, -s * 0.9, s * 0.15)), (0, -1, 0.15)), segs=8)
    else:  # sword
        m = aim(h, (0.0, -0.35, 1))
        g.rbox((s * 0.06, s * 0.015, s * 0.7), "metal", m, s * 0.006, 2, (0, 0, s * 0.42))
        g.lathe([(s * 0.03, 0), (0, s * 0.08)], "metal", m @ trs((0, 0, s * 0.77)), segs=4)
        g.rbox((s * 0.2, s * 0.04, s * 0.03), "gold", m, s * 0.01, 2, (0, 0, s * 0.06))
        g.cylinder(s * 0.018, s * 0.13, "leather", m @ trs((0, 0, -s * 0.08)), segs=8)
        g.sphere(s * 0.025, "gold", m @ trs((0, 0, -s * 0.09)), segs=8, rings=5)


def head_details(c, kind):
    b, g, rng = c.b, c.g, c.rng
    hr = b.head_r
    f = b.face.normalized()
    side = f.cross(Vector((0, 0, 1))).normalized()
    if kind in ("whiskers", "whiskers_long"):
        L = hr * (1.0 if kind == "whiskers" else 2.0)
        base = (b.snout or b.head + f * hr * 0.8)
        for s in (-1, 1):
            for k in range(3):
                p = base + side * s * hr * 0.25 + Vector((0, 0, (k - 1) * hr * 0.06))
                tube(g, curve(p, side * s + Vector((0, 0, (k - 1) * 0.15)) - f * 0.3, L, 0.4, 6, (0, 0, -1)), [hr * 0.012, hr * 0.003], "eye_dark", 4)
    elif kind == "antennae":
        for s in (-1, 1):
            p = b.head + Vector((s * hr * 0.35, 0, hr * 0.7))
            pts = curve(p, f + Vector((s * 0.4, 0, 1.4)), hr * 2.0, 1.0, 8, f)
            tube(g, pts, [hr * 0.05, hr * 0.02], "dark", 6)
            g.sphere(hr * 0.09, "accent", T3(*pts[-1]), segs=8, rings=5)
    elif kind in ("crest", "neck_frill", "fins", "fins_sail", "gills"):
        if kind == "crest":
            for k in range(5):
                p = b.head + Vector((0, hr * (0.4 - k * 0.25), hr * 0.85 - k * hr * 0.05))
                g.lathe([(hr * 0.12, 0), (0, hr * (0.5 - 0.06 * k))], "accent", aim(p, (0, 0.6, 1)) @ trs((0, 0, 0), (0, 0, 0), (0.3, 1, 1)), segs=8)
        elif kind == "neck_frill":
            def fn(u, v):
                a = math.pi * (-0.1 + 1.2 * u)
                r = hr * (0.9 + v * 1.0) + 0.02 * math.sin(u * 30) * v
                return (math.cos(a) * r, b.neck.y + hr * 0.4 + v * hr * 0.4, b.head.z - hr * 0.3 + math.sin(a) * r * 0.8)
            g.patch(fn, 24, 5, "accent", None, 0.01)
        elif kind in ("fins", "fins_sail"):
            sp = b.spine
            if len(sp) >= 2:
                h_ = b.torso_r * (2.2 if kind == "fins_sail" else 1.0)

                def fn(u, v):
                    q = sp[0].lerp(sp[-1], u)
                    return (q.x, q.y, q.z - 0.01 + v * h_ * math.sin(math.pi * u) + 0.01 * math.sin(u * 40) * v)
                g.patch(fn, 20, 4, "accent", None, 0.008)
            if b.kind == "fish":  # the tail fin
                t = b.tail_root
                g.slab_poly([(0, 0), (-0.14, 0.18), (0.0, 0.08), (0.14, 0.18)][::1], 0.012, "accent", aim(t, (0, 1, 0)) @ trs((0, 0, 0), (0, 90, 0)))
        else:
            for s in (-1, 1):
                for k in range(3):
                    p = b.head + side * s * hr * 0.9 + Vector((0, hr * (0.2 + k * 0.15), -hr * 0.2))
                    g.rbox((hr * 0.02, hr * 0.05, hr * 0.4), "dark", aim(p, side * s), hr * 0.01, 1)
    elif kind == "lure":
        p = b.head + Vector((0, 0, hr * 0.9))
        pts = curve(p, f + Vector((0, 0, 1.5)), hr * 1.6, 1.4, 8, f + Vector((0, 0, -1)))
        tube(g, pts, [hr * 0.04, hr * 0.015], "dark", 6)
        g.sphere(hr * 0.16, "glow", T3(*pts[-1]), segs=12, rings=8)
    elif kind in ("eye_clusters", "eye_cluster"):
        for k in range(6):
            p, nn = c.surface(lambda v, n: n[1] < -0.2 and v[2] > b.head.z - b.head_r, 1)[0] if c.surface(lambda v, n: n[1] < -0.2 and v[2] > b.head.z - b.head_r, 1) else (b.head, f)
            r = hr * rng.uniform(0.08, 0.16)
            g.sphere(r, "eye_white", aim(p, nn), segs=12, rings=8)
            g.sphere(r * 0.55, "glow", aim(p, nn) @ trs((0, 0, r * 0.6), (0, 0, 0), (1, 1, 0.5)), segs=10, rings=6)


def trinkets(c, kind):
    b, g, rng = c.b, c.g, c.rng
    if kind in ("crown_slot", "crown"):
        hr = b.head_r
        top = b.head + Vector((0, 0, hr * (0.88 if b.kind != "blob" else 0.9)))
        r = hr * (0.45 if b.kind != "blob" else 0.32)
        g.lathe([(r, 0), (r * 1.05, r * 0.3), (r, r * 0.32), (r * 0.95, 0.0)], "gold", T3(*top), segs=24, cap_bottom=False, cap_top=False)
        for k in range(5):
            a = 2 * math.pi * k / 5
            g.lathe([(r * 0.18, 0), (0, r * 0.45)], "gold", T3(top.x + math.cos(a) * r, top.y + math.sin(a) * r, top.z + r * 0.25), segs=5)
            g.sphere(r * 0.08, "gem", T3(top.x + math.cos(a) * r * 1.03, top.y + math.sin(a) * r * 1.03, top.z + r * 0.15), segs=8, rings=5)
    elif kind in ("bone_trinkets", "jewelry"):
        z = b.neck.z - b.torso_r * 0.15
        r = b.torso_r * 0.75
        for k in range(9):
            a = math.pi * (1.15 + 0.7 * k / 8)
            p = Vector((math.cos(a) * r, b.neck.y + math.sin(a) * r * 0.9, z - 0.03 * math.sin(math.pi * k / 8)))
            if kind == "jewelry":
                g.sphere(b.torso_r * 0.06, "gold" if k % 3 else "gem", T3(*p), segs=8, rings=5)
            else:
                g.lathe([(b.torso_r * 0.03, 0), (0, b.torso_r * 0.2)], "bone", aim(p, (0, -0.3, -1)), segs=5)
    elif kind in ("lantern_core", "inner_core", "rune_core", "swarm_core", "glowing_throat", "ink_sac"):
        p = b.neck + Vector((0, -b.torso_r * 0.75, -b.torso_r * 0.4)) if b.kind not in ("blob", "ghost", "horror") else b.head + Vector((0, -b.head_r * 0.6, -b.head_r * 0.1))
        if kind == "ink_sac":
            p = (b.spine[-1] if b.spine else b.head) + Vector((0, b.torso_r * 0.2, 0))
        r = b.torso_r * 0.28
        if kind == "lantern_core":
            g.rbox((r * 1.4, r * 1.4, r * 1.8), "metal_dark", T3(*p), r * 0.15, 2)
            g.sphere(r * 0.7, "glow", T3(*p), segs=14, rings=8)
        else:
            g.sphere(r, "glow" if kind != "ink_sac" else "ink", T3(*p), segs=16, rings=10)
            if kind == "rune_core":
                for k in range(6):
                    g.rbox((r * 0.15, r * 0.03, r * 0.4), "glow", T3(*p) @ trs((0, 0, 0), (0, 0, k * 60)) @ trs((r * 1.4, 0, 0)), r * 0.02, 1)
    elif kind == "drip_trail":
        for k in range(7):
            a = rng.uniform(0, 2 * math.pi)
            r = b.torso_r * rng.uniform(0.85, 1.05)
            g.sphere(b.torso_r * rng.uniform(0.05, 0.1), "main", T3(math.cos(a) * r, math.sin(a) * r, 0.02), segs=10, rings=6, squash=0.5)
    elif kind == "trailing_wisps":
        for k in range(4):
            p = b.tail_root + Vector((rng.uniform(-0.1, 0.1), 0, rng.uniform(-0.05, 0.1)))
            pts = curve(p, b.tail_dir + Vector((0, 0, 0.3)), 0.35, rng.uniform(-1, 1), 8, (rng.uniform(-1, 1), 0, 1))
            tube(g, pts, [b.torso_r * 0.12, 0.002], "glow", 8)
    elif kind == "web_spinneret":
        p = b.tail_root
        g.lathe([(b.torso_r * 0.12, 0), (b.torso_r * 0.05, b.torso_r * 0.2), (0, b.torso_r * 0.22)], "dark", aim(p, b.tail_dir), segs=8)
        for k in range(4):
            tube(g, [p, p + Vector((rng.uniform(-0.2, 0.2), 0.3, -p.z))], 0.003, "eye_white", 4, cap=False)
    elif kind == "gear_joints":
        for q in list(b.shoulders) + list(b.hips):
            g.cylinder(b.torso_r * 0.22, b.torso_r * 0.06, "gold", aim(q, (q.x or 0.01, 0, 0)), segs=16)
            for k in range(10):
                g.rbox((b.torso_r * 0.06, b.torso_r * 0.05, b.torso_r * 0.06), "gold", aim(q, (q.x or 0.01, 0, 0)) @ trs((0, 0, b.torso_r * 0.03), (0, 0, k * 36)) @ trs((b.torso_r * 0.24, 0, 0)), 0.002, 1)
    elif kind == "flame_neck":
        for k in range(6):
            p = b.neck + Vector((rng.uniform(-0.05, 0.05), b.torso_r * 0.3, rng.uniform(0, 0.05)))
            g.lathe([(b.torso_r * 0.15, 0), (b.torso_r * 0.1, b.torso_r * 0.3), (0, b.torso_r * rng.uniform(0.6, 0.9))], "glow", aim(p, (rng.uniform(-0.3, 0.3), 0.3, 1)), segs=8)
    elif kind == "head_carried" and b.hands:
        h = b.hands[0]
        g.sphere(0.075, "main", T3(h.x, h.y - 0.04, h.z + 0.06), segs=20, rings=12)
        for s in (-1, 1):
            g.sphere(0.014, "glow", T3(h.x + s * 0.025, h.y - 0.11, h.z + 0.08), segs=8, rings=5)


def mimic_box(c):
    b, g = c.b, c.g
    w, d, h = 0.62, 0.44, 0.3
    g.rbox((w, d, h * 0.55), "wood", None, 0.02, 2, (0, 0, h * 0.28))
    lid = trs((0, d / 2, h * 0.55), (-48, 0, 0))
    g.rbox((w, d, h * 0.35), "wood", lid, 0.02, 2, (0, -d / 2, h * 0.17))
    for x in (-w / 2 + 0.03, w / 2 - 0.03):
        g.rbox((0.04, d + 0.01, h * 0.57), "gold", None, 0.008, 2, (x, 0, h * 0.28))
        g.rbox((0.04, d + 0.01, h * 0.37), "gold", lid, 0.008, 2, (x, -d / 2, h * 0.17))
    g.rbox((0.08, 0.03, 0.1), "gold", None, 0.01, 2, (0, -d / 2 - 0.01, h * 0.5))
    teeth_lip = [(-w / 2 + 0.05 + k * (w - 0.1) / 9) for k in range(10)]
    for x in teeth_lip:
        g.lathe([(0.018, 0), (0, 0.06)], "teeth", T3(x, -d / 2 + 0.04, h * 0.55), segs=6)
        g.lathe([(0.018, 0), (0, 0.06)], "teeth", lid @ trs((x, -d + 0.04, 0.0), (180, 0, 0)), segs=6)


def swarm_wings(c):
    for p in getattr(c.b, "units", []):
        for s in (-1, 1):
            c.g.sphere(0.5, "membrane", T3(p.x + s * 0.045, p.y + 0.01, p.z + 0.035) @ trs((0, 0, 0), (0, s * 20, 0), (0.05, 0.025, 0.006)), segs=8, rings=5)
        c.g.sphere(0.008, "glow", T3(p.x - 0.012, p.y - 0.085, p.z + 0.02), segs=6, rings=4)
        c.g.sphere(0.008, "glow", T3(p.x + 0.012, p.y - 0.085, p.z + 0.02), segs=6, rings=4)


# ================================================================================================================


def hard(c):
    b, parts = c.b, list(dict.fromkeys(c.look.parts))
    eyes(c)
    mouth(c)
    horns(c)
    claws(c)
    if b.kind == "mimic":
        mimic_box(c)
    if b.kind == "swarm":
        swarm_wings(c)
    if (b.kind in ("bird", "bat", "dragon") or b.P.get("wings")) and not any(p in parts for p in ("wing_cases", "wing_membrane", "wing_feathers", "membrane_wings")):
        wings(c, "wing_feathers" if b.kind == "bird" else "wing_membrane")
    for p in parts:
        if p in ("armored_back", "scales_armored", "spine_plates", "carapace_ridges", "scale_ridges", "bark_plates", "joint_spikes", "leg_spikes"):
            plates(c, p)
        elif p in ("armor_plates", "plate_armor", "crude_armor", "barding"):
            armour(c, p)
        elif p in ("chains", "chain_belt"):
            belt(c, p)
        elif p in ("cloak", "tattered_shroud", "tattered_cape", "hood", "loincloth"):
            cloth(c, p)
        elif p in ("mask", "mask_face", "human_mask", "empty_visor", "face_decal"):
            mask(c, p)
        elif p in ("wing_cases", "wing_membrane", "wing_feathers", "membrane_wings"):
            wings(c, p)
        elif p in ("stone_growths", "crystal_growths", "moss_cover", "thorns", "spore_pods", "glowing_spots", "glowing_knots", "scar_decals"):
            growths(c, p)
        elif p in ("weapon_socket", "club_socket", "lance"):
            weapon(c, p)
        elif p in ("whiskers", "whiskers_long", "antennae", "crest", "neck_frill", "fins", "fins_sail", "gills", "lure", "eye_clusters", "eye_cluster"):
            head_details(c, p)
        elif p in ("crown_slot", "crown", "bone_trinkets", "jewelry", "lantern_core", "inner_core", "rune_core", "swarm_core",
                   "glowing_throat", "ink_sac", "drip_trail", "trailing_wisps", "web_spinneret", "gear_joints", "flame_neck", "head_carried"):
            trinkets(c, p)
        elif p in ("stinger", "rattle_tail", "tail_spike", "tail_blade", "tail_plumes") and getattr(b, "tail_tip", None) is not None:
            tip, d = b.tail_tip, b.tail_tip_dir
            r = b.torso_r * 0.2
            if p == "stinger":
                c.g.lathe([(r * 0.8, 0), (r * 0.5, r * 1.2), (0, r * 2.6)], "claw", aim(tip, d), segs=10)
            elif p == "rattle_tail":
                for k in range(4):
                    c.g.sphere(r * (0.9 - k * 0.12), "bone", aim(tip + d * r * 0.7 * k, d) @ trs((0, 0, 0), (0, 0, 0), (1, 1, 0.6)), segs=10, rings=6)
            elif p == "tail_spike":
                for k in range(4):
                    a = k * 90
                    c.g.lathe([(r * 0.3, 0), (0, r * 1.5)], "bone", aim(tip, d) @ trs((0, 0, 0), (0, 0, a)) @ trs((0, 0, 0), (70, 0, 0)), segs=6)
            elif p == "tail_blade":
                c.g.slab_poly([(0, 0), (r * 1.6, r * 0.8), (0, r * 4), (-r * 1.6, r * 0.8)], r * 0.25, "metal", aim(tip, d) @ trs((0, 0, 0), (90, 0, 0)))
            else:
                for k in range(5):
                    dd = (d + Vector(((k - 2) * 0.3, 0, 0.2))).normalized()
                    c.g.sphere(0.5, "feather", aim(tip + dd * r * 2.5, dd) @ trs((0, 0, 0), (0, 0, 0), (r * 0.8, r * 0.2, r * 3)), segs=8, rings=6)
    return c.g
