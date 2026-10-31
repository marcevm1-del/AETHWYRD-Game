"""
The construction engine: walls with openings, wall constructions, footings, floor bands, corners, roofs and their
coverings, windows, doors, chimneys and ornaments, all driven by a Style (styles.py).

Face frames: each wall face has a local frame whose origin is the face's centre at the bottom of the storey. Local X
runs along the wall (left to right seen from outside), local -Y points outward and the wall's thickness runs into +Y,
local Z is up. Openings and wall pieces are laid out in that frame.

Roof frames: a roof is built with its ridge along local X; a block whose ridge runs along Y is rotated 90 degrees.
"""
import math
import random

from mathutils import Matrix, Vector

from .geo import Geo, trs

FACE_ANGLE = {"front": 0, "right": 90, "back": 180, "left": 270}
WALL_T = 0.28


def T(x, y, z):
    return Matrix.Translation((x, y, z))


def RZ(deg):
    return Matrix.Rotation(math.radians(deg), 4, "Z")


def RX(deg):
    return Matrix.Rotation(math.radians(deg), 4, "X")


def RY(deg):
    return Matrix.Rotation(math.radians(deg), 4, "Y")


def lerp(a, b, t):
    return a + (b - a) * t


class Ctx:
    """One building being generated: the style, the geometry, a seeded random source and the chosen colours."""

    def __init__(self, style, seed=1, detail="high"):
        self.s = style
        self.g = Geo()
        self.seed = seed
        self.rng = random.Random(seed)
        self.detail = detail
        self.hi = detail == "high"
        self.wall_key = self.rng.choice(list(style.wall_keys))
        self.roof_key = self.rng.choice(list(style.roof_keys))
        self.notes = []
        mix = getattr(style, "cover_mix", None)  # e.g. Whisperwood: thatch on 1 roof in 3 (style is per building)
        if mix and self.rng.random() < mix[2]:
            style.cover, self.roof_key = mix[0], mix[1]
            if len(mix) > 3:
                style.ridge = mix[3]

    def seg(self):
        return 2 if self.hi else 1

    def chance(self, p):
        return self.rng.random() < p


# ================================================================================================================
# Openings


class Op:
    """An opening in a wall face: centre x, bottom z, width, height, shape and whether it is a door."""

    def __init__(self, x, z, w, h, shape="rect", door=False, kind=None):
        self.x, self.z, self.w, self.h = x, z, w, h
        self.shape = shape
        self.door = door
        self.kind = kind

    @property
    def rect(self):
        return (self.x - self.w / 2, self.x + self.w / 2, self.z, self.z + self.h)

    def spring(self):
        if self.shape in ("arch", "horseshoe"):
            return self.z + self.h - self.w / 2
        if self.shape == "pointed":
            return self.z + self.h - 0.866 * self.w
        return self.z + self.h

    def outline(self, n=10):
        x0, x1, z0, z1 = self.rect
        xc = self.x
        if self.shape in ("arch", "horseshoe"):
            zs = self.spring()
            r = self.w / 2
            pts = [(x0, z0), (x1, z0), (x1, zs)]
            pts += [(xc + r * math.cos(math.pi * k / n), zs + r * math.sin(math.pi * k / n)) for k in range(1, n)]
            pts += [(x0, zs)]
            return pts
        if self.shape == "pointed":
            zs = self.spring()
            w = self.w
            n2 = max(2, n // 2)
            pts = [(x0, z0), (x1, z0), (x1, zs)]
            # right arc: centred on the left spring, 0 -> 60 degrees (ends at the apex)
            pts += [(x0 + w * math.cos(math.radians(60 * k / n2)), zs + w * math.sin(math.radians(60 * k / n2))) for k in range(1, n2 + 1)]
            # left arc: centred on the right spring, 120 -> 180 degrees (ends at the left spring)
            pts += [(x1 + w * math.cos(math.radians(120 + 60 * k / n2)), zs + w * math.sin(math.radians(120 + 60 * k / n2))) for k in range(1, n2 + 1)]
            return pts
        if self.shape == "round":
            r = self.w / 2
            zc = self.z + r
            return [(xc + r * math.cos(2 * math.pi * k / (2 * n)), zc + r * math.sin(2 * math.pi * k / (2 * n)))
                    for k in range(2 * n)]
        if self.shape == "trap":
            i = self.w * 0.13
            return [(x0, z0), (x1, z0), (x1 - i, z1), (x0 + i, z1)]
        return [(x0, z0), (x1, z0), (x1, z1), (x0, z1)]

    def spandrels(self, n=10):
        """Polygons that fill the gap between the rectangular hole and the opening's shape."""
        x0, x1, z0, z1 = self.rect
        xc = self.x
        out = []
        if self.shape in ("arch", "horseshoe"):
            zs, r = self.spring(), self.w / 2
            left = [(x0, zs)] + [(xc + r * math.cos(math.pi - math.pi / 2 * k / n), zs + r * math.sin(math.pi - math.pi / 2 * k / n))
                                 for k in range(1, n + 1)] + [(x0, z1)]
            right = [(xc, z1)] + [(xc + r * math.cos(math.pi / 2 - math.pi / 2 * k / n), zs + r * math.sin(math.pi / 2 - math.pi / 2 * k / n))
                                  for k in range(1, n + 1)] + [(x1, z1)]
            out = [left, right]
        elif self.shape == "pointed":
            zs, w = self.spring(), self.w
            n2 = max(2, n // 2)
            left = [(x1 + w * math.cos(math.radians(180 - 60 * k / n2)), zs + w * math.sin(math.radians(180 - 60 * k / n2))) for k in range(n2 + 1)]
            right = [(x0 + w * math.cos(math.radians(60 - 60 * k / n2)), zs + w * math.sin(math.radians(60 - 60 * k / n2))) for k in range(n2 + 1)]
            out = [left + [(x0, z1)], right + [(x1, z1)]]
        elif self.shape == "round":
            r = self.w / 2
            zc = self.z + r
            q = lambda a0, a1: [(xc + r * math.cos(a0 + (a1 - a0) * k / n), zc + r * math.sin(a0 + (a1 - a0) * k / n))
                                for k in range(n + 1)]
            out = [q(math.pi, math.pi / 2) + [(x0, z1)],
                   q(math.pi / 2, 0) + [(x1, z1)],
                   [(x0, z0)] + q(1.5 * math.pi, math.pi),
                   [(x1, z0)] + q(0, -math.pi / 2)]
        elif self.shape == "trap":
            i = self.w * 0.13
            out = [[(x0, z0), (x0 + i, z1), (x0, z1)], [(x1, z0), (x1, z1), (x1 - i, z1)]]
        return out


def spread(L, w, gap, margin):
    """Centres for as many openings of width w as fit along L with at least `gap` between them."""
    usable = L - 2 * margin
    n = int((usable + gap) // (w + gap))
    if n <= 0:
        return []
    step = usable / n
    return [-usable / 2 + step * (i + 0.5) for i in range(n)]


# ================================================================================================================
# Wall solids


def holes_of(ops):
    return [o.rect for o in ops]


def solid_cells(L, H, holes):
    """Splits the wall rectangle [-L/2, L/2] x [0, H] into grid cells and marks the ones not inside a hole."""
    xs = sorted({-L / 2, L / 2} | {max(-L / 2, min(L / 2, v)) for h in holes for v in h[:2]})
    zs = sorted({0.0, H} | {max(0.0, min(H, v)) for h in holes for v in h[2:]})
    cells = []
    for i in range(len(xs) - 1):
        for j in range(len(zs) - 1):
            cx = (xs[i] + xs[i + 1]) / 2
            cz = (zs[j] + zs[j + 1]) / 2
            inside = any(h[0] < cx < h[1] and h[2] < cz < h[3] for h in holes)
            cells.append((i, j, not inside))
    return xs, zs, cells


def wall_slab(g, L, H, t, holes, mat, m, y0=0.0):
    """A wall slab from y0 to y0 + t with rectangular holes, as one watertight piece with reveals."""
    xs, zs, cells = solid_cells(L, H, holes)
    nx, nz = len(xs), len(zs)
    solid = {(i, j): s for i, j, s in cells}
    verts = []
    for side in (0, 1):
        y = y0 + t * side
        for i in range(nx):
            for j in range(nz):
                verts.append((xs[i], y, zs[j]))
    vid = lambda side, i, j: side * nx * nz + i * nz + j
    faces = []
    for (i, j), s in solid.items():
        if not s:
            continue
        faces.append((vid(0, i, j), vid(0, i + 1, j), vid(0, i + 1, j + 1), vid(0, i, j + 1)))  # front (-Y)
        faces.append((vid(1, i, j + 1), vid(1, i + 1, j + 1), vid(1, i + 1, j), vid(1, i, j)))  # back
        # reveals where a solid cell meets a hole or the outside
        if j == 0 or not solid.get((i, j - 1), False):
            faces.append((vid(0, i, j), vid(1, i, j), vid(1, i + 1, j), vid(0, i + 1, j)))
        if j == nz - 2 or not solid.get((i, j + 1), False):
            faces.append((vid(0, i + 1, j + 1), vid(1, i + 1, j + 1), vid(1, i, j + 1), vid(0, i, j + 1)))
        if i == 0 or not solid.get((i - 1, j), False):
            faces.append((vid(0, i, j + 1), vid(1, i, j + 1), vid(1, i, j), vid(0, i, j)))
        if i == nx - 2 or not solid.get((i + 1, j), False):
            faces.append((vid(0, i + 1, j), vid(1, i + 1, j), vid(1, i + 1, j + 1), vid(0, i + 1, j + 1)))
    g.add(verts, faces, mat, m)


def intervals(x0, x1, z0, z1, holes, pad=0.0):
    """The parts of [x0, x1] not blocked by holes that overlap the band [z0, z1]."""
    segs = [(x0, x1)]
    for h in holes:
        if h[3] <= z0 + 1e-6 or h[2] >= z1 - 1e-6:
            continue
        a, b = h[0] - pad, h[1] + pad
        nxt = []
        for s0, s1 in segs:
            if b <= s0 or a >= s1:
                nxt.append((s0, s1))
            else:
                if a > s0:
                    nxt.append((s0, a))
                if b < s1:
                    nxt.append((b, s1))
        segs = nxt
    return [s for s in segs if s[1] - s[0] > 0.05]


# ================================================================================================================
# Wall constructions. Each fills the rectangle [-L/2, L/2] x [0, H] of a face frame m, leaving the holes open.


def build_wall(c, m, L, H, ops, construction, key, floor_index=0, clip=None):
    """
    Builds one storey of one face. `clip(z)` (optional) returns the half-width available at height z, which turns the
    rectangle into a gable triangle.
    """
    g = c.g
    s = c.s
    holes = holes_of(ops)
    hi = c.hi
    if construction in ("plaster", "adobe", "stalk"):
        t = 0.42 if construction == "adobe" else WALL_T
        if clip is None:
            wall_slab(g, L, H, t, holes, key, m)
        else:
            g.slab_poly([(-L / 2, 0), (L / 2, 0), (0, H)], t, key, m @ T(0, t / 2, 0))
    elif construction == "timber_frame":
        if clip is None:
            wall_slab(g, L, H, WALL_T - 0.05, holes, key, m, y0=0.05)
            timber_frame(c, m, L, H, ops)
        else:
            g.slab_poly([(-L / 2, 0), (L / 2, 0), (0, H)], WALL_T - 0.05, key, m @ T(0, 0.05 + (WALL_T - 0.05) / 2, 0))
            gable_timbers(c, m, L, H)
    elif construction in ("ashlar", "rubble", "fitted", "brick", "carved", "rusticated"):
        masonry(c, m, L, H, holes, construction, key, clip)
    elif construction == "log":
        logs(c, m, L, H, holes, key, clip, floor_index)
    elif construction == "board":
        boards(c, m, L, H, holes, key, clip)
    elif construction == "clapboard":
        clapboards(c, m, L, H, holes, key, clip)
    elif construction == "post_panel":
        if clip is None:
            post_panel(c, m, L, H, ops, key)
        else:
            g.slab_poly([(-L / 2, 0), (L / 2, 0), (0, H)], 0.2, key, m @ T(0, 0.14, 0))
            gable_timbers(c, m, L, H, key_override="trim")
    elif construction == "living":
        if clip is None:
            wall_slab(g, L, H, WALL_T - 0.04, holes, key, m, y0=0.04)
            living_columns(c, m, L, H, ops)
        else:
            g.slab_poly([(-L / 2, 0), (L / 2, 0), (0, H)], 0.22, key, m @ T(0, 0.15, 0))
    else:
        wall_slab(g, L, H, WALL_T, holes, key, m)
    # fill arch / round / trapezoid corners above or around the holes
    if clip is None:
        if construction in ("ashlar", "rubble", "fitted", "brick", "carved", "rusticated"):
            fill_key = "stone~3"
        elif construction in ("log", "board", "clapboard"):
            fill_key = "trim"
        else:
            fill_key = key
        for o in ops:
            for poly in o.spandrels():
                g.slab_poly(poly, 0.24, fill_key, m @ T(0, 0.15, 0))


def timber_frame(c, m, L, H, ops):
    g, k, seg = c.g, "trim", c.seg()
    r = 0.03
    g.rbox((L + 0.02, 0.14, 0.2), k, m, r, seg, (0, 0.03, 0.1))            # sill beam
    g.rbox((L + 0.02, 0.14, 0.18), k, m, r, seg, (0, 0.03, H - 0.09))      # top plate
    posts = {-L / 2 + 0.1, L / 2 - 0.1}
    for o in ops:
        x0, x1, z0, z1 = o.rect
        posts.add(x0 - 0.1)
        posts.add(x1 + 0.1)
        if not o.door:  # rails under and over windows, from post to post
            g.rbox((o.w + 0.2, 0.12, 0.14), k, m, r, seg, (o.x, 0.03, z0 - 0.12))
        g.rbox((o.w + 0.2, 0.12, 0.16), k, m, r, seg, (o.x, 0.03, min(H - 0.18, z1 + 0.1)))
    posts = sorted(p for p in posts if -L / 2 + 0.05 <= p <= L / 2 - 0.05)
    merged = []
    for p in posts:
        if merged and p - merged[-1] < 0.35:
            continue
        merged.append(p)
    for p in merged:
        g.rbox((0.18, 0.14, H - 0.2), k, m, r, seg, (p, 0.03, H / 2))
    # braces in the wide panels between posts
    for a, b in zip(merged, merged[1:]):
        if b - a < 1.0:
            continue
        blocked = any(o.rect[0] < b and o.rect[1] > a for o in ops)
        if blocked:
            continue
        span, rise = b - a - 0.18, H - 0.4
        ang = math.degrees(math.atan2(rise, span))
        ln = math.hypot(span, rise)
        flip = c.chance(0.5)
        g.rbox((ln, 0.12, 0.14), k, m @ T((a + b) / 2, 0.03, H / 2) @ RY(-ang if flip else ang), r, seg)
        if b - a > 2.2 and c.chance(0.6):  # a cross brace
            g.rbox((ln, 0.12, 0.14), k, m @ T((a + b) / 2, 0.035, H / 2) @ RY(ang if flip else -ang), r, seg)


def gable_timbers(c, m, L, H, key_override=None):
    g, k, seg = c.g, key_override or "trim", c.seg()
    g.rbox((0.18, 0.14, H * 0.92), k, m, 0.03, seg, (0, 0.03, H * 0.46))  # king post
    for side in (-1, 1):
        x = side * L / 4
        h = H * 0.5
        g.rbox((0.16, 0.14, h * 0.9), k, m, 0.03, seg, (x, 0.03, h * 0.45))
    g.rbox((L * 0.62, 0.14, 0.16), k, m, 0.03, seg, (0, 0.03, H * 0.42))   # collar beam


def masonry(c, m, L, H, holes, kind, key, clip):
    g = c.g
    mortar = "mortar"
    t = WALL_T
    # backing (mortar) slab, set back so the stones stand proud of it
    if clip is None:
        wall_slab(g, L, H, t - 0.06, holes, mortar, m, y0=0.06)
    else:
        g.slab_poly([(-L / 2, 0), (L / 2, 0), (0, H)], t - 0.06, mortar, m @ T(0, 0.06 + (t - 0.06) / 2, 0))
    stone_key = key if key in ("stone", "wall_a", "wall_b") else "stone"
    if kind == "brick":
        ch, parts, lens = 0.087, ["brick"], (0.24,)
    elif kind == "ashlar" or kind == "rusticated" or kind == "carved":
        ch, parts, lens = 0.34, ["ashlar_a", "ashlar_b"], (0.6, 0.9)
    elif kind == "fitted":
        ch, parts, lens = 0.42, ["boulder_a", "boulder_b", "boulder_c"], (0.55, 0.4, 0.7)
    else:  # rubble
        ch, parts, lens = 0.32, ["stone_a", "stone_b", "stone_c", "stone_d"], (0.5, 0.42, 0.62, 0.36)
    if not c.hi and kind == "brick":
        ch, parts, lens = 0.26, ["ashlar_a"], (0.6,)
    rng = c.rng
    z = 0.0
    row = 0
    while z < H - 0.02:
        h = min(ch * (rng.uniform(0.85, 1.2) if kind in ("rubble", "fitted") else 1.0), H - z)
        if h < 0.06:
            break
        half = L / 2 if clip is None else clip(z + h * 0.5)
        if half < 0.12:
            break
        for a, b in intervals(-half, half, z, z + h, holes):
            x = a + (rng.uniform(0, lens[0] * 0.5) if row % 2 else 0)
            if x > a:
                place_stone(c, m, parts, lens, a, x, z, h, stone_key, kind)
            while x < b - 0.04:
                i = rng.randrange(len(parts))
                ln = lens[i] * rng.uniform(0.8, 1.25)
                if b - x - ln < lens[i] * 0.4:
                    ln = b - x
                place_stone(c, m, parts, lens, x, x + ln, z, h, stone_key, kind, i)
                x += ln
        z += h
        row += 1
    if kind == "carved" and clip is None:  # a carved frieze band at two thirds height
        zb = H * 0.66
        g.rbox((L + 0.06, 0.12, 0.26), "accent", m, 0.03, c.seg(), (0, -0.04, zb))
        for k in range(int(L / 0.6)):
            g.rbox((0.22, 0.08, 0.16), "stone~2", m, 0.03, 1, (-L / 2 + 0.3 + k * 0.6, -0.1, zb))


def place_stone(c, m, parts, lens, x0, x1, z, h, key, kind, i=None):
    rng = c.rng
    if i is None:
        i = rng.randrange(len(parts))
    ln = x1 - x0
    if ln < 0.06:
        return
    gap = 0.012 if kind == "brick" else (0.02 if kind in ("ashlar", "rusticated", "carved") else 0.035)
    nominal = lens[i]
    hn = {"brick": 0.075, "ashlar": 0.32, "rusticated": 0.32, "carved": 0.32, "fitted": 0.38}.get(kind, 0.3)
    sx = max(0.1, (ln - gap) / nominal)
    sz = max(0.1, (h - gap) / hn)
    tone = rng.choice(["", "", "~3", "~4", "~1"] if kind != "brick" else ["", "~3", "~4"])
    if c.s.ruin and c.chance(c.s.ruin * 0.12) and z > 0.6:
        return
    proud = -rng.uniform(0.0, 0.02) - (0.03 if kind == "rusticated" else 0.0)
    rot = rng.uniform(-1.5, 1.5) if kind in ("rubble", "fitted") else 0.0
    c.g.inst("%s|%s%s" % (parts[i], key, tone), m @ T((x0 + x1) / 2, proud, z + gap / 2) @ RY(rot) @ Matrix.Diagonal((sx, 1, sz, 1)))


def logs(c, m, L, H, holes, key, clip, floor_index):
    g = c.g
    g.slab_poly([(-L / 2, 0), (L / 2, 0), (L / 2, H), (-L / 2, H)] if clip is None else [(-L / 2, 0), (L / 2, 0), (0, H)],
                0.12, "trim_dark", m @ T(0, 0.2, 0))
    d = 0.26
    z = 0.0 if floor_index % 2 == 0 else 0.0
    while z < H - 0.05:
        half = L / 2 if clip is None else clip(z + d / 2)
        if half < 0.2:
            break
        for a, b in intervals(-half, half, z, z + d, holes):
            ext = 0.0
            if clip is None:
                if abs(a + L / 2) < 1e-3:
                    a -= 0.28
                if abs(b - L / 2) < 1e-3:
                    b += 0.28
            tone = c.rng.choice(["", "~3", "~4", "~1"])
            g.inst("log|%s%s" % (key, tone), m @ T((a + b) / 2, -0.02, z) @ Matrix.Diagonal((b - a, 1, 1, 1)))
            if clip is None and (a < -L / 2 - 0.1 or b > L / 2 + 0.1):
                for e in ((a,) if a < -L / 2 - 0.1 else ()) + ((b,) if b > L / 2 + 0.1 else ()):
                    g.inst("log_end|wood_light", m @ T(e + (0.005 if e > 0 else -0.005), 0.12, z + 0.14))
        z += d


def boards(c, m, L, H, holes, key, clip):
    g = c.g
    g.slab_poly([(-L / 2, 0), (L / 2, 0), (L / 2, H), (-L / 2, H)] if clip is None else [(-L / 2, 0), (L / 2, 0), (0, H)],
                0.14, "trim_dark", m @ T(0, 0.16, 0))
    x = -L / 2
    rng = c.rng
    while x < L / 2 - 0.05:
        w = rng.choice((0.2, 0.26, 0.16))
        part = {0.2: "plank_a", 0.26: "plank_b", 0.16: "plank_c"}[w]
        xc = x + w / 2
        top = H if clip is None else _gable_height(xc, L, H)
        # vertical solid runs at this x
        runs = [(0.0, top)]
        for h in holes:
            if h[0] - 0.02 < xc < h[1] + 0.02:
                nxt = []
                for z0, z1 in runs:
                    if h[3] <= z0 or h[2] >= z1:
                        nxt.append((z0, z1))
                    else:
                        if h[2] > z0:
                            nxt.append((z0, h[2]))
                        if h[3] < z1:
                            nxt.append((h[3], z1))
                runs = nxt
        tone = rng.choice(["", "~3", "~4", "~1", ""])
        for z0, z1 in runs:
            if z1 - z0 > 0.08:
                g.inst("%s|%s%s" % (part, key, tone), m @ T(xc, rng.uniform(-0.01, 0.01), z0) @ RY(rng.uniform(-0.6, 0.6))
                       @ Matrix.Diagonal((1, 1, z1 - z0, 1)))
        x += w + 0.01
    if clip is None:  # battens at the top and bottom
        for zb in (0.12, H - 0.12):
            g.rbox((L + 0.04, 0.08, 0.14), "trim", m, 0.025, c.seg(), (0, -0.05, zb))


def _gable_height(x, L, H):
    return max(0.0, H * (1 - abs(x) / (L / 2)))


def clapboards(c, m, L, H, holes, key, clip):
    g = c.g
    g.slab_poly([(-L / 2, 0), (L / 2, 0), (L / 2, H), (-L / 2, H)] if clip is None else [(-L / 2, 0), (L / 2, 0), (0, H)],
                0.16, "trim_dark", m @ T(0, 0.16, 0))
    z = 0.0
    while z < H - 0.04:
        half = L / 2 if clip is None else clip(z + 0.1)
        if half < 0.1:
            break
        for a, b in intervals(-half, half, z, z + 0.2, holes):
            g.inst("clapboard|%s%s" % (key, c.rng.choice(["", "~3", "~4"])), m @ T((a + b) / 2, 0.0, z) @ Matrix.Diagonal((b - a, 1, 1, 1)))
        z += 0.19
    if clip is None:  # corner boards
        for x in (-L / 2 + 0.06, L / 2 - 0.06):
            g.rbox((0.14, 0.08, H), "frame", m, 0.02, 1, (x, -0.06, H / 2))


def post_panel(c, m, L, H, ops, key):
    """East Asian post-and-beam: posts, a tie beam and sill rail, white plaster or lattice panels, wooden wainscot."""
    g, seg = c.g, c.seg()
    holes = holes_of(ops)
    wall_slab(g, L, H, 0.2, holes, key, m, y0=0.08)
    wains = 0.7
    for a, b in intervals(-L / 2, L / 2, 0, wains, holes):
        g.rbox((b - a, 0.06, wains), "trim_dark", m, 0.015, 1, ((a + b) / 2, 0.06, wains / 2))
    posts = {-L / 2 + 0.12, L / 2 - 0.12}
    n = max(1, int(L / 1.9))
    for i in range(1, n):
        posts.add(-L / 2 + L * i / n)
    for o in ops:
        posts.add(o.rect[0] - 0.09)
        posts.add(o.rect[1] + 0.09)
    merged = []
    for p in sorted(posts):
        if merged and p - merged[-1] < 0.4:
            continue
        merged.append(p)
    for p in merged:
        g.cylinder(0.12, H, "trim", m @ T(p, 0.02, 0), segs=12, bevel=0.02)
        if c.hi:
            g.cylinder(0.16, 0.12, "stone~2", m @ T(p, 0.02, -0.06), segs=12, bevel=0.03)  # post base stone
    g.rbox((L + 0.1, 0.16, 0.22), "trim_dark" if c.s.has("dancheong") else "trim", m, 0.03, seg, (0, 0.0, H - 0.2))
    g.rbox((L + 0.06, 0.12, 0.14), "trim", m, 0.03, seg, (0, 0.02, wains + 0.07))
    if c.s.has("dancheong"):  # painted bands on the tie beam
        for k in range(int(L / 0.9)):
            g.rbox((0.3, 0.02, 0.12), "accent_b" if k % 2 else "accent", m, 0.01, 1, (-L / 2 + 0.45 + k * 0.9, -0.09, H - 0.2))


def living_columns(c, m, L, H, ops):
    g = c.g
    xs = {-L / 2 + 0.12, L / 2 - 0.12}
    for o in ops:
        xs.add(o.rect[0] - 0.14)
        xs.add(o.rect[1] + 0.14)
    n = max(1, int(L / 1.6))
    for i in range(1, n):
        xs.add(-L / 2 + L * i / n)
    merged = []
    for p in sorted(xs):
        if merged and p - merged[-1] < 0.5:
            continue
        merged.append(p)
    for p in merged:
        lean = c.rng.uniform(-2.5, 2.5)
        prof = [(0.24, 0.0), (0.17, 0.25), (0.13, 0.6), (0.12, H * 0.6), (0.14, H * 0.9), (0.2, H)]
        g.lathe(prof, "trim", m @ T(p, 0.02, 0) @ RY(lean), segs=10, cap_bottom=False)
        if c.s.has("vines") and c.chance(0.5):
            for k in range(4):
                g.inst("ivy|leaf%s" % c.rng.choice(["", "~3"]), m @ T(p + c.rng.uniform(-0.15, 0.15), -0.12, c.rng.uniform(0.3, H)))
    g.rbox((L + 0.1, 0.18, 0.18), "trim", m, 0.06, c.seg(), (0, 0.0, H - 0.08))


# ================================================================================================================
# Windows and doors


def window(c, m, o, construction):
    """Frame, glass, mullions, sill and the style's shutters, surrounds and flower box for one window."""
    g, s, seg = c.g, c.s, c.seg()
    kind = o.kind or s.window
    fw, fd = 0.1, 0.16
    if construction in ("ashlar", "rubble", "fitted", "brick", "carved", "rusticated", "adobe") or kind in ("arched", "pointed"):
        frame_key = "stone~2" if construction != "brick" else "stone~4"
        if kind in ("arched", "horseshoe", "pointed", "slit") or construction == "brick":
            fw, fd = 0.16, 0.2
    else:
        frame_key = "frame"
    if kind in ("lattice",):
        frame_key = "trim"
    outline = o.outline()
    frame_along(c, m, outline, fw, fd, frame_key, -0.03)
    glass_key = getattr(s, "window_glass", "glass")  # "window_glow" lights the panes (dark families)
    if kind == "trapezoid":
        glass_key = "trim_dark"
    g.slab_poly(outline, 0.04, glass_key, m @ T(0, 0.14, 0))
    x0, x1, z0, z1 = o.rect
    zs = o.spring()
    if kind == "lattice":
        for k in range(1, int(o.w / 0.16)):
            g.box((0.03, 0.03, o.h), "trim", m, (x0 + k * o.w / int(o.w / 0.16), 0.11, (z0 + z1) / 2))
        for k in range(1, int(o.h / 0.16)):
            g.box((o.w, 0.03, 0.03), "trim", m, (o.x, 0.11, z0 + k * o.h / int(o.h / 0.16)))
    elif kind in ("shutter", "arched", "pointed", "horseshoe", "plain"):
        g.rbox((0.05, 0.05, zs - z0), "frame" if frame_key != "frame" else "trim", m, 0.015, 1, (o.x, 0.1, (z0 + zs) / 2))
        g.rbox((o.w, 0.05, 0.05), "frame" if frame_key != "frame" else "trim", m, 0.015, 1, (o.x, 0.1, z0 + (zs - z0) * 0.55))
    elif kind == "porthole" or o.shape == "round":
        g.box((o.w * 0.9, 0.03, 0.04), "frame", m, (o.x, 0.1, z0 + o.h / 2))
        g.box((0.04, 0.03, o.h * 0.9), "frame", m, (o.x, 0.1, z0 + o.h / 2))
    # sill
    if o.shape != "round":
        g.rbox((o.w + 0.3, 0.26, 0.08), "stone~2" if frame_key.startswith("stone") else "frame", m, 0.025, seg, (o.x, -0.06, z0 - 0.04))
    # keystone over masonry arches
    if o.shape in ("arch", "horseshoe") and frame_key.startswith("stone"):
        g.rbox((0.2, 0.22, 0.28), "stone~2", m, 0.03, seg, (o.x, -0.06, z1 + 0.04))
    # shutters
    if kind in ("shutter", "arched", "horseshoe") and s.window in ("shutter", "arched", "horseshoe") and o.shape != "round":
        sh_h = (zs - z0) if o.shape != "rect" else o.h
        for side in (-1, 1):
            hinge = o.x + side * (o.w / 2 + 0.06)
            leaf_w = o.w / 2 + 0.04
            phi = c.rng.uniform(140, 172)
            # a leaf modelled along +X from its hinge, swung open outward until it nearly lies on the wall
            mm = m @ T(hinge, -0.06, z0 + sh_h / 2) @ (RZ(180 + phi) if side > 0 else RZ(-phi))
            g.rbox((leaf_w, 0.05, sh_h), "shutter", mm, 0.015, 1, (leaf_w / 2, 0, 0))
            if c.hi:
                for zz in (-sh_h * 0.3, sh_h * 0.3):
                    g.box((leaf_w * 0.9, 0.025, 0.06), "shutter~1", mm, (leaf_w / 2, 0.0, zz))
    # flower box
    if s.has("flower_boxes") and o.shape != "round" and kind not in ("slit", "lattice") and c.chance(0.75):
        flower_box(c, m, o.x, z0 - 0.14, o.w + 0.15)


def frame_along(c, m, outline, fw, fd, key, y):
    g = c.g
    n = len(outline)
    for i in range(n):
        (ax, az), (bx, bz) = outline[i], outline[(i + 1) % n]
        ln = math.hypot(bx - ax, bz - az)
        if ln < 1e-4:
            continue
        ang = math.degrees(math.atan2(bz - az, bx - ax))
        g.rbox((ln + fw * 0.9, fd, fw), key, m @ T((ax + bx) / 2, y, (az + bz) / 2) @ RY(-ang), 0.025, c.seg())


def flower_box(c, m, x, z, w):
    g = c.g
    g.rbox((w, 0.26, 0.22), "wood_light", m, 0.03, c.seg(), (x, -0.2, z - 0.11))
    n = max(3, int(w / 0.16))
    for k in range(n):
        xx = x - w / 2 + 0.08 + k * (w - 0.16) / max(1, n - 1)
        g.inst("bush|leaf%s" % c.rng.choice(["", "~3", "~4"]), m @ T(xx, -0.2, z - 0.02) @ Matrix.Diagonal((0.42, 0.42, 0.42, 1)))
        if c.chance(0.8):
            g.inst("flower|flower_%s" % c.rng.choice("abcd"), m @ T(xx + c.rng.uniform(-0.04, 0.04), -0.26, z + 0.14))


def door(c, m, o):
    g, s, seg = c.g, c.s, c.seg()
    kind = o.kind or s.door
    x0, x1, z0, z1 = o.rect
    outline = o.outline()
    frame_key = "stone~2" if s.walls in ("ashlar", "rubble", "fitted", "brick", "carved", "adobe") else "frame"
    frame_along(c, m, [p for p in outline], 0.14, 0.2, frame_key, -0.04)
    if kind == "sliding":
        for side in (-1, 1):
            xc = o.x + side * o.w / 4
            g.rbox((o.w / 2, 0.06, o.h), "trim", m, 0.015, 1, (xc, 0.08, z0 + o.h / 2))
            g.box((o.w / 2 - 0.12, 0.03, o.h - 0.5), "glass", m, (xc, 0.04, z0 + o.h / 2 + 0.15))
            for k in range(1, 5):
                g.box((0.025, 0.03, o.h - 0.5), "trim", m, (xc - o.w / 4 + k * o.w / 10, 0.03, z0 + o.h / 2 + 0.15))
    elif kind == "curtain":
        g.slab_poly(outline, 0.04, "trim_dark", m @ T(0, 0.16, 0))
        for k in range(3):
            g.rbox((o.w / 3, 0.05, o.h * 0.85), "cloth_a" if k != 1 else "cloth_b", m, 0.02, 1,
                   (x0 + o.w / 6 + k * o.w / 3, -0.02, z0 + o.h * 0.575))
    elif kind == "round":
        g.slab_poly(outline, 0.08, "door", m @ T(0, 0.1, 0))
        g.sphere(0.06, "gold", m @ T(o.x, 0.03, z0 + o.h / 2), segs=8, rings=5)
        for k in range(-2, 3):
            g.box((0.03, 0.03, o.h * 0.8), "door~1", m, (o.x + k * o.w / 6, 0.05, z0 + o.h / 2))
    else:
        g.slab_poly(outline, 0.06, "trim_dark", m @ T(0, 0.17, 0))
        leaves = 2 if kind in ("double", "pointed") or o.w > 1.6 else 1
        nplank = max(3, int(o.w / 0.18))
        for k in range(nplank):
            xx = x0 + (k + 0.5) * o.w / nplank
            top = _top_at(outline, xx, z1)
            g.inst("plank_a|door%s" % c.rng.choice(["", "~3", "~4"]),
                   m @ T(xx, 0.06, z0) @ Matrix.Diagonal((o.w / nplank / 0.2 * 0.98, 1, max(0.2, top - z0 - 0.02), 1)))
        for zz in (z0 + 0.35, z0 + o.h * 0.62):
            g.rbox((o.w * (0.9 if leaves == 1 else 0.44), 0.04, 0.07), "metal", m, 0.012, 1,
                   (o.x - (o.w * 0.24 if leaves == 2 else 0), 0.03, zz))
            if leaves == 2:
                g.rbox((o.w * 0.44, 0.04, 0.07), "metal", m, 0.012, 1, (o.x + o.w * 0.24, 0.03, zz))
        ring_x = o.x + (o.w * 0.3 if leaves == 1 else 0.12)
        g.lathe([(0.05, -0.012), (0.065, 0.0), (0.05, 0.012), (0.035, 0.0), (0.05, -0.012)], "metal",
                m @ T(ring_x, 0.0, z0 + o.h * 0.45) @ RX(90), segs=10, cap_bottom=False, cap_top=False)
    if s.has("cloth_bands"):  # wind-plains: red cloth jambs and a blue lintel band round every door
        for side in (-1, 1):
            g.rbox((0.24, 0.07, o.h + 0.25), "cloth_a", m, 0.02, 1, (o.x + side * (o.w / 2 + 0.24), -0.1, z0 + (o.h + 0.25) / 2))
        g.rbox((o.w + 0.8, 0.08, 0.3), "cloth_b", m, 0.02, 1, (o.x, -0.11, z1 + 0.3))
    if s.has("noren") and kind == "sliding":
        for k in range(3):
            g.rbox((o.w / 3 - 0.02, 0.03, 0.55), "cloth_a", m, 0.01, 1, (x0 + o.w / 6 + k * o.w / 3, -0.06, z1 - 0.3))
    if s.has("runes"):
        for zz in range(int(o.h / 0.4)):
            for side in (-1, 1):
                g.box((0.06, 0.03, 0.18), "glow", m, (o.x + side * (o.w / 2 + 0.2), -0.07, z0 + 0.3 + zz * 0.4))


def _top_at(outline, x, default):
    best = None
    n = len(outline)
    for i in range(n):
        (ax, az), (bx, bz) = outline[i], outline[(i + 1) % n]
        if (ax - x) * (bx - x) <= 0 and abs(bx - ax) > 1e-6:
            z = az + (bz - az) * (x - ax) / (bx - ax)
            if best is None or z > best:
                best = z
    return best if best is not None else default


def wall_lantern(c, m, x, z):
    g = c.g
    g.rbox((0.06, 0.32, 0.06), "metal", m, 0.015, 1, (x, -0.16, z + 0.3))
    if c.s.has("paper_lanterns"):
        g.lathe([(0.0, -0.22), (0.12, -0.18), (0.16, 0.0), (0.12, 0.18), (0.0, 0.22)], "lamp", m @ T(x, -0.3, z + 0.02), segs=10)
    else:
        g.rbox((0.2, 0.2, 0.28), "metal", m, 0.02, 1, (x, -0.32, z))
        g.rbox((0.15, 0.15, 0.2), "lamp", m, 0.02, 1, (x, -0.32, z))
        g.lathe([(0.15, 0.0), (0.0, 0.12)], "metal", m @ T(x, -0.32, z + 0.14), segs=4, phase=math.pi / 4)


# ================================================================================================================
# Roofs. A roof is built in a frame with the ridge along X: W along the ridge, D across it, eaves at z = 0.


class Panel:
    """A roof surface between an eave segment (E0 -> E1) and a ridge segment (R0 -> R1), optionally curved."""

    def __init__(self, E0, E1, R0, R1, sag=0.0, upturn=0.0):
        self.E0, self.E1, self.R0, self.R1 = (Vector(v) for v in (E0, E1, R0, R1))
        self.sag, self.upturn = sag, upturn

    def at(self, u, v):
        e = self.E0.lerp(self.E1, u)
        r = self.R0.lerp(self.R1, u)
        p = e.lerp(r, v)
        if self.sag:
            p.z -= self.sag * math.sin(math.pi * v) * 0.9
        if self.upturn:
            edge = abs(u - 0.5) * 2
            p.z += self.upturn * (edge ** 3) * (1 - v) ** 2
        return p

    def frame(self, u, v):
        p = self.at(u, v)
        du = (self.at(min(1, u + 0.01), v) - self.at(max(0, u - 0.01), v)).normalized()
        dv = (self.at(u, min(1, v + 0.01)) - self.at(u, max(0, v - 0.01))).normalized()
        n = du.cross(dv).normalized()
        dv = n.cross(du).normalized()
        return p, du, dv, n

    def width(self, v):
        return (self.at(1, v) - self.at(0, v)).length

    def length(self, u=0.5):
        return sum((self.at(u, (k + 1) / 12) - self.at(u, k / 12)).length for k in range(12))


def column_runs(panel, xpos, steps=10, margin=0.06):
    """Segments (p, q) of a line running up the panel at offset xpos, clipped where a hip narrows the panel."""
    out = []
    for j in range(steps):
        v0, v1 = j / steps, (j + 1) / steps
        w_a, w_b = panel.width(v0), panel.width(v1)
        if abs(xpos) > w_a / 2 - margin:
            break
        vb = v1
        if abs(xpos) > w_b / 2 - margin:
            vb = v0 + (v1 - v0) * max(0.0, (w_a / 2 - margin - abs(xpos)) / max(1e-6, (w_a - w_b) / 2))
        p = panel.at(0.5 + xpos / w_a, v0)
        q = panel.at(0.5 + xpos / max(panel.width(vb), 1e-6), vb)
        if (q - p).length < 0.05:
            break
        out.append((p, q, v0))
        if vb < v1:
            break
    return out


def run_basis(panel, p, q, v):
    _, du, _, _ = panel.frame(0.5, v)
    dv = (q - p).normalized()
    nn = du.cross(dv).normalized()
    du = dv.cross(nn).normalized()
    return basis(p, du, dv, nn), nn


def basis(p, du, dv, n):
    return Matrix(((du.x, dv.x, n.x, p.x), (du.y, dv.y, n.y, p.y), (du.z, dv.z, n.z, p.z), (0, 0, 0, 1)))


def roof_deck(c, m, panel, key, thick=0.08, nu=8, nv=8, offset=-0.03):
    def fn(u, v):
        p, du, dv, n = panel.frame(u, v)
        q = p + n * offset
        return (q.x, q.y, q.z)
    c.g.patch(fn, nu, nv, key, m, thick)


COVER = {
    # name: (parts, width, exposure, tilt, jitter_rot, tones)
    "tile_flat": (["tile_flat"], 0.30, 0.26, 4.0, 2.0, ["", "~3", "~4"]),
    "shingle": (["shingle_a", "shingle_b", "shingle_c"], None, 0.23, 4.0, 3.0, ["", "~3", "~4", "~1"]),
    "slate": (["slate_a", "slate_b"], None, 0.21, 3.0, 2.5, ["", "~3", "~1", "~4"]),
    "thatch": (["thatch"], 0.42, 0.36, 9.0, 8.0, ["", "~3", "~4"]),
    "leaf": (["leaf_a", "leaf_b"], 0.24, 0.26, 10.0, 14.0, ["", "~3", "~4", "~2"]),
}


def cover_panel(c, m, panel, cover, key, ridge_pad=0.06):
    """Lays the covering on one panel (and a deck under it)."""
    g, rng = c.g, c.rng
    under = "roof_under"
    if cover in ("plaster", "glaze", "slab", "canvas"):
        roof_deck(c, m, panel, key if cover != "slab" else "stone", 0.14 if cover != "canvas" else 0.05, 10, 10, 0.0)
        return
    roof_deck(c, m, panel, under, 0.08)
    if cover == "metal":
        roof_deck(c, m, panel, key, 0.03, 10, 10, 0.02)
        w0 = panel.width(0)
        n = max(2, int(w0 / 0.45))
        for k in range(1, n):
            for p, q, v in column_runs(panel, -w0 / 2 + k * w0 / n, 10, 0.08):
                b, nn = run_basis(panel, p, q, v)
                g.inst("seam|%s~1" % key, m @ T(*(nn * 0.03)) @ b @ Matrix.Diagonal((1, (q - p).length + 0.01, 1, 1)))
        return
    if cover == "turf":
        roof_deck(c, m, panel, "trim~1", 0.1, 8, 8, 0.0)
        roof_deck(c, m, panel, key, 0.2, 10, 10, 0.22)
        L = panel.length()
        for k in range(int(panel.width(0.3) * L * (5 if c.hi else 2))):
            u, v = rng.random(), rng.uniform(0.0, 0.95)
            p, du, dv, nn = panel.frame(u, v)
            if c.s.snow and v > 0.2 and c.chance(0.6):
                continue
            g.inst("tuft|leaf%s" % rng.choice(["", "~3", "~4"]), m @ basis(p + nn * 0.2, du, dv, nn) @ RZ(rng.uniform(0, 360)) @ Matrix.Diagonal((1.4, 1.4, 1.2, 1)))
        return
    if cover == "barrel":
        L = panel.length()
        rows = max(1, int(L / 0.36))
        w0 = panel.width(0)
        cols = max(2, int(w0 / 0.26))
        for k in range(cols):
            u = (k + 0.5) / cols
            for j in range(rows):
                v = j / rows
                if panel.width(v) < 0.2:
                    continue
                # keep columns inside the (possibly narrowing) panel
                uu = 0.5 + (u - 0.5) * 1.0
                p0 = panel.at(0, v)
                p1 = panel.at(1, v)
                wv = (p1 - p0).length
                xpos = (uu - 0.5) * w0
                if abs(xpos) > wv / 2 - 0.1:
                    continue
                uv = 0.5 + xpos / max(wv, 1e-6)
                p, du, dv, nn = panel.frame(uv, v)
                if c.s.ruin and c.chance(c.s.ruin * 0.25):
                    continue
                tone = rng.choice(["", "~3", "~4"])
                g.inst("barrel_pan|%s%s" % (key, tone), m @ basis(p + nn * 0.0, du, dv, nn) @ RX(-2))
                g.inst("barrel_cap|%s%s" % (key, tone), m @ basis(p + du * 0.13 + nn * 0.06, du, dv, nn) @ RX(-2))
                if j == 0 and c.s.curve > 0:
                    g.inst("barrel_end|%s~1" % key, m @ basis(p + du * 0.13 + nn * 0.12 - dv * 0.02, du, dv, nn))
        return
    if cover == "plank":
        w0 = panel.width(0)
        n = max(2, int(w0 / 0.25))
        for k in range(n):
            tone = rng.choice(["", "~3", "~4", "~1"])
            for p, q, v in column_runs(panel, -w0 / 2 + (k + 0.5) * w0 / n):
                b, _ = run_basis(panel, p, q, v)
                g.inst("plank_roof|%s%s" % (key, tone), m @ b @ Matrix.Diagonal((1, (q - p).length + 0.02, 1, 1)))
        return
    parts, width, expo, tilt, jrot, tones = COVER[cover]
    L = panel.length()
    rows = max(1, int(math.ceil(L / expo)))
    for j in range(rows):
        v = j / rows
        wv = panel.width(v)
        if wv < 0.1:
            continue
        x = -wv / 2 + (0.0 if j % 2 == 0 else -(width or 0.23) / 2)
        while x < wv / 2:
            part = rng.choice(parts)
            w = width or {"shingle_a": 0.17, "shingle_b": 0.23, "shingle_c": 0.29, "slate_a": 0.26, "slate_b": 0.32}[part]
            xc = x + w / 2
            x += w + (0.005 if cover in ("shingle", "slate") else 0.0)
            if xc < -wv / 2 + 0.02 or xc > wv / 2 - 0.02:
                continue
            if c.s.ruin and c.chance(c.s.ruin * 0.3):
                continue
            u = 0.5 + xc / wv
            p, du, dv, nn = panel.frame(u, v)
            mm = m @ basis(p + nn * 0.01, du, dv, nn) @ RZ(rng.uniform(-jrot, jrot)) @ RX(tilt + rng.uniform(-1.5, 1.5))
            if cover == "thatch":
                mm = mm @ Matrix.Diagonal((rng.uniform(0.9, 1.2), 1, rng.uniform(0.9, 1.15), 1))
            g.inst("%s|%s%s" % (part, key, rng.choice(tones)), mm)
    if c.s.has("moss") and cover in ("tile_flat", "shingle", "slate", "thatch"):
        for k in range(int(panel.width(0.2) * 3)):
            u, v = rng.random(), rng.uniform(0, 0.6)
            p, du, dv, nn = panel.frame(u, v)
            g.inst("bush|moss%s" % rng.choice(["", "~3"]), m @ basis(p + nn * 0.05, du, dv, nn) @ Matrix.Diagonal((0.6, 0.6, 0.25, 1)))


def snow_on(c, m, panel, cover):
    lift = {"turf": 0.5, "thatch": 0.32, "barrel": 0.3}.get(cover, 0.16)

    def fn(u, v):
        p, du, dv, n = panel.frame(u, 0.04 + v * 0.96)
        q = p + n * (lift + 0.04 * math.sin(u * 17 + v * 5) + 0.03 * math.sin(u * 41))
        return (q.x, q.y, q.z)
    c.g.patch(fn, 14, 8, "snow", m, 0.14)


def roof(c, m, W, D, form=None, pitch=None, cover=None, key=None, ridge=None, overhang=None, gable_fill=None):
    """
    Builds a roof over a W x D rectangle whose eaves are at z = 0 of frame m (ridge along X). Returns the ridge height.
    gable_fill(face_matrix, L, rise) is called for each gable end when the form has gables.
    """
    s = c.s
    form = form or s.roof
    pitch = pitch if pitch is not None else s.pitch
    cover = cover or s.cover
    key = key or c.roof_key
    ridge = ridge or s.ridge
    o = s.overhang if overhang is None else overhang
    og = min(0.45, o)
    rise = D / 2 * math.tan(math.radians(pitch))
    drop = o * math.tan(math.radians(pitch))
    panels = []
    hips = []
    if form in ("gable", "turf"):
        x0, x1 = -W / 2 - og, W / 2 + og
        front = Panel((x0, -D / 2 - o, -drop), (x1, -D / 2 - o, -drop), (x0, 0, rise), (x1, 0, rise))
        back = Panel((x1, D / 2 + o, -drop), (x0, D / 2 + o, -drop), (x1, 0, rise), (x0, 0, rise))
        panels = [front, back]
        if gable_fill:
            gable_fill(m @ T(W / 2, 0, 0) @ RZ(90), D, rise)
            gable_fill(m @ T(-W / 2, 0, 0) @ RZ(270), D, rise)
        if True:
            for x in (x0, x1):  # barge boards along the gable edges
                for side in (-1, 1):
                    a = Vector((x, side * (D / 2 + o), -drop))
                    b = Vector((x, 0, rise))
                    mid = (a + b) / 2
                    ln = (b - a).length
                    ang = math.degrees(math.atan2(b.z - a.z, abs(b.y - a.y)))
                    c.g.rbox((0.08, ln + 0.1, 0.24), "trim", m @ T(mid.x + (0.02 if x > 0 else -0.02), mid.y, mid.z + 0.06)
                             @ RX(ang if side < 0 else -ang), 0.025, c.seg())
        ridge_line = [((x0, 0, rise), (x1, 0, rise))]
    elif form in ("hip", "curved", "pyramid", "spire"):
        if form == "spire":
            rise = max(W, D) * 1.6
        hw = max(0.0, (W - D) / 2)
        sag = 0.0
        up = 0.0
        if form == "curved":
            sag = rise * 0.18 * (0.5 + s.curve)
            up = 0.35 + 0.5 * s.curve
        X, Y = W / 2 + o, D / 2 + o
        E = [(-X, -Y, -drop), (X, -Y, -drop), (X, Y, -drop), (-X, Y, -drop)]
        R = [(-hw, 0, rise), (hw, 0, rise), (hw, 0, rise), (-hw, 0, rise)]
        panels = [Panel(E[0], E[1], R[0], R[1], sag, up), Panel(E[1], E[2], R[1], R[2], sag, up),
                  Panel(E[2], E[3], R[2], R[3], sag, up), Panel(E[3], E[0], R[3], R[0], sag, up)]
        ridge_line = [((-hw, 0, rise), (hw, 0, rise))] if hw > 0.05 else []
        hips = [(E[i], R[i]) for i in range(4)]
    elif form == "flat":
        return flat_roof(c, m, W, D, key, cover)
    elif form in ("dome", "onion", "cone", "cap", "yurt"):
        return round_roof(c, m, max(W, D) / 2, form, key, cover)
    else:
        return roof(c, m, W, D, "gable", pitch, cover, key, ridge, overhang, gable_fill)
    for p in panels:
        cover_panel(c, m, p, cover, key)
        if s.snow:
            snow_on(c, m, p, cover)
    # fascia along the eaves
    for p in panels:
        a, b = p.at(0, 0), p.at(1, 0)
        ln = (b - a).length
        if ln < 0.2:
            continue
        mid = (a + b) / 2
        ang = math.degrees(math.atan2(b.y - a.y, b.x - a.x))
        c.g.rbox((ln, 0.08, 0.2), "trim" if cover != "thatch" else key + "~1", m @ T(mid.x, mid.y, mid.z - 0.08) @ RZ(ang), 0.025, 1)
    ridge_caps(c, m, ridge_line, hips, ridge, key, form, rise)
    return rise


def ridge_caps(c, m, lines, hips, ridge, key, form, rise):
    g = c.g
    if ridge == "none":
        return
    for a, b in lines:
        a, b = Vector(a), Vector(b)
        ln = (b - a).length
        if ridge == "tile":
            n = max(1, int(ln / 0.34))
            for k in range(n + 1):
                p = a.lerp(b, k / max(1, n))
                g.inst("ridge_tile|ridge%s" % c.rng.choice(["", "~3"]), m @ T(p.x - 0.17, p.y, p.z - 0.04))
        elif ridge == "roll":
            g.lathe([(0.0, -ln / 2 - 0.15), (0.2, -ln / 2 - 0.1), (0.24, 0), (0.2, ln / 2 + 0.1), (0.0, ln / 2 + 0.15)], key + "~1",
                    m @ T((a.x + b.x) / 2, a.y, a.z + 0.02) @ RY(90), segs=12)
            for k in range(int(ln / 0.5) + 1):
                g.rbox((0.06, 0.5, 0.06), "trim", m @ T(a.x + k * 0.5, a.y, a.z + 0.2), 0.02, 1)
        elif ridge in ("board", "dragon"):
            for side in (-1, 1):
                g.rbox((ln + 0.3, 0.06, 0.3), "trim", m @ T((a.x + b.x) / 2, side * 0.08, a.z + 0.06) @ RX(side * 40), 0.02, c.seg())
            if ridge == "dragon":
                for x in (a.x - 0.25, b.x + 0.25):
                    sgn = 1 if x > 0 else -1
                    for side in (-1, 1):  # crossed carved boards rising past the ridge
                        g.rbox((0.08, 0.14, 1.1), "trim", m @ T(x, side * 0.12, a.z + 0.35) @ RX(side * 35), 0.03, c.seg())
                        g.sphere(0.12, "accent", m @ T(x, side * 0.42, a.z + 0.78), segs=8, rings=5)
        elif ridge == "raised":
            g.rbox((ln + 0.4, 0.26, 0.36), key + "~1", m, 0.05, c.seg(), ((a.x + b.x) / 2, a.y, a.z + 0.12))
            g.rbox((ln + 0.3, 0.2, 0.12), key + "~3", m, 0.04, c.seg(), ((a.x + b.x) / 2, a.y, a.z + 0.34))
            for x, sgn in ((a.x - 0.2, -1), (b.x + 0.2, 1)):  # upturned ridge ends
                g.rbox((0.4, 0.24, 0.7), key + "~1", m @ T(x, a.y, a.z + 0.4) @ RY(sgn * -18), 0.08, c.seg())
                g.rbox((0.25, 0.2, 0.3), "gold" if c.s.family == "shenlu" else key + "~3", m @ T(x + sgn * 0.12, a.y, a.z + 0.8) @ RY(sgn * -40), 0.06, 1)
    for e, r in hips:
        e, r = Vector(e), Vector(r)
        ln = (r - e).length
        d = (r - e).normalized()
        n = max(1, int(ln / 0.34))
        if ridge in ("tile", "raised"):
            for k in range(n):
                p = e.lerp(r, (k + 0.5) / n)
                yaw = math.degrees(math.atan2(d.y, d.x))
                pitch_a = math.degrees(math.asin(max(-1, min(1, d.z))))
                g.inst("ridge_tile|ridge%s" % c.rng.choice(["", "~3"]), m @ T(p.x, p.y, p.z + 0.02) @ RZ(yaw) @ RY(-pitch_a) @ T(-0.17, 0, 0))
        elif ridge == "roll":
            yaw = math.degrees(math.atan2(d.y, d.x))
            pitch_a = math.degrees(math.asin(max(-1, min(1, d.z))))
            g.lathe([(0.0, 0), (0.16, 0.05), (0.18, ln * 0.5), (0.16, ln - 0.05), (0.0, ln)], key + "~1",
                    m @ T(e.x, e.y, e.z + 0.05) @ RZ(yaw) @ RY(90 - pitch_a), segs=10)


def flat_roof(c, m, W, D, key, cover):
    g, s = c.g, c.s
    deck = key if cover == "plaster" else ("stone~3" if cover == "glaze" else "stone")
    g.rbox((W + 0.1, D + 0.1, 0.25), deck, m, 0.05, c.seg(), (0, 0, 0.12))
    top = 0.25
    if s.parapet:
        ph = 0.6
        for (x, y, w, d) in ((0, -D / 2 + 0.12, W + 0.1, 0.24), (0, D / 2 - 0.12, W + 0.1, 0.24),
                             (-W / 2 + 0.12, 0, 0.24, D + 0.1), (W / 2 - 0.12, 0, 0.24, D + 0.1)):
            wall_key = c.wall_key if s.walls in ("adobe", "plaster", "stalk") else "stone"
            g.rbox((w, d, ph), wall_key, m, 0.06 if s.walls == "adobe" else 0.03, c.seg(), (x, y, top + ph / 2))
            if s.walls in ("ashlar", "brick", "carved") or s.family in ("dwarven", "ancient", "steppe", "whitestone"):
                n = int(max(w, d) / 0.7)  # crenellations
                for k in range(n):
                    if k % 2:
                        continue
                    if w > d:
                        g.rbox((0.42, 0.26, 0.35), wall_key, m, 0.03, 1, (-W / 2 + 0.35 + k * W / n, y, top + ph + 0.17))
                    else:
                        g.rbox((0.26, 0.42, 0.35), wall_key, m, 0.03, 1, (x, -D / 2 + 0.35 + k * D / n, top + ph + 0.17))
        if s.has("vigas"):
            for side in (-1, 1):
                for k in range(int(W / 0.8)):
                    g.cylinder(0.08, 0.5, "trim", m @ T(-W / 2 + 0.4 + k * 0.8, side * (D / 2 + 0.1), -0.25) @ RX(-side * 90), segs=8, bevel=0.02)
        if s.has("domes") and W > 4 and D > 4:
            round_roof(c, m @ T(0, 0, top), min(W, D) * 0.28, "dome" if s.tower_roof != "onion" else "onion", c.roof_key, cover)
    return top + 0.6


def round_roof(c, m, r, form, key, cover):
    """Domes, onion domes, cones, mushroom caps and yurt crowns over a circle of radius r at z = 0."""
    g = c.g
    if form == "dome":
        prof = [(r + 0.1, 0.0)] + [(r * math.cos(math.radians(a)) + 0.05, r * 0.9 * math.sin(math.radians(a))) for a in range(10, 90, 10)] + [(0.0, r * 0.9 + 0.02)]
        g.lathe(prof, key, m, segs=28, cap_bottom=True)
        g.cylinder(r + 0.18, 0.22, "stone~2" if c.s.walls != "adobe" else c.wall_key, m @ T(0, 0, -0.1), segs=28, bevel=0.05)
        finial(c, m @ T(0, 0, r * 0.9), 0.5)
        return r * 0.9
    if form == "onion":
        prof = [(r * 0.85, 0.0), (r * 1.05, r * 0.35), (r * 1.08, r * 0.6), (r * 0.9, r * 0.95), (r * 0.5, r * 1.3),
                (r * 0.18, r * 1.55), (0.0, r * 1.75)]
        g.lathe(prof, key, m, segs=28)
        if c.hi:
            for k in range(12):  # ribs
                a = k * 30
                g.lathe([(0.0, 0.0), (0.03, 0.02), (0.0, 0.04)], key + "~2", m @ RZ(a), segs=4)
        finial(c, m @ T(0, 0, r * 1.75), 0.7)
        return r * 1.75
    if form == "cap":
        prof = [(r * 1.12, -0.08), (r * 1.2, 0.08), (r * 1.14, r * 0.3), (r * 0.92, r * 0.6), (r * 0.55, r * 0.8), (0.0, r * 0.86)]
        g.lathe(prof, key, m, segs=40, cap_bottom=False)
        g.lathe([(0.0, r * 0.12), (r * 0.5, 0.02), (r * 1.12, -0.08)], "wall_a~1", m, segs=40, cap_bottom=False, cap_top=False)
        for k in range(36):  # gills
            g.rbox((r * 0.6, 0.02, 0.06), "wall_a~3", m @ RZ(k * 10) @ T(r * 0.78, 0, 0.0) @ RY(-9), 0.01, 1)
        if c.s.has("spots"):
            # walk the cap's own profile so every spot sits on the surface, facing out
            seg_len = [math.dist(prof[i], prof[i + 1]) for i in range(len(prof) - 1)]
            total = sum(seg_len)
            for k in range(int(r * 10)):
                a = c.rng.uniform(0, 2 * math.pi)
                s_ = c.rng.uniform(0.18, 0.92) * total
                i = 0
                while i < len(seg_len) - 1 and s_ > seg_len[i]:
                    s_ -= seg_len[i]
                    i += 1
                f = s_ / seg_len[i]
                (r0, z0), (r1, z1) = prof[i], prof[i + 1]
                rr, z = r0 + (r1 - r0) * f, z0 + (z1 - z0) * f
                tr, tz = r1 - r0, z1 - z0  # tangent in the (radius, z) plane; the outward normal is (tz, -tr)
                n = Vector((math.cos(a) * tz, math.sin(a) * tz, -tr)).normalized()
                p = Vector((rr * math.cos(a), rr * math.sin(a), z)) + n * 0.01
                q = n.to_track_quat("Z", "Y").to_matrix().to_4x4()
                g.inst("spot|accent", m @ T(*p) @ q @ Matrix.Diagonal((c.rng.uniform(0.32, 0.62),) * 3 + (1,)))
        return r * 0.86
    if form == "yurt":
        prof = [(r + 0.15, 0.0), (r * 0.6, r * 0.32), (r * 0.18, r * 0.5), (r * 0.18, r * 0.56), (0.0, r * 0.58)]
        g.lathe(prof, "accent", m, segs=28)
        for f in (0.35, 0.7):  # rope bands lying on the felt
            rr, zz = (r + 0.15) * (1 - f) + r * 0.6 * f, r * 0.32 * f
            g.lathe([(rr + 0.02, zz - 0.04), (rr + 0.05, zz), (rr + 0.02, zz + 0.04)], "cloth_a", m, segs=28, cap_bottom=False, cap_top=False)
        g.lathe([(r * 0.2, r * 0.52), (r * 0.24, r * 0.56), (r * 0.2, r * 0.62)], "trim", m, segs=16, cap_bottom=False, cap_top=False)
        g.lathe([(r + 0.17, 0.02), (r + 0.18, 0.12), (r * 0.85, r * 0.12)], "cloth_a", m, segs=28, cap_bottom=False, cap_top=False)
        return r * 0.6
    # cone (with tiles laid in rings)
    h = r * 1.5 if c.s.tower_roof != "spire" else r * 3.2
    prof = [(r + 0.35, -0.25), (0.0, h)]
    g.lathe([(r + 0.3, -0.27), (0.05, h - 0.1)], "roof_under", m, segs=24, cap_bottom=True)
    cover_cone(c, m, r + 0.35, h + 0.25, key, cover, -0.25)
    finial(c, m @ T(0, 0, h - 0.1), 0.6)
    return h


def cover_cone(c, m, r, h, key, cover, z0):
    g = c.g
    slant = math.hypot(r, h)
    expo = 0.24
    rows = int(slant / expo)
    for j in range(rows):
        t = j / rows
        rr = r * (1 - t)
        if rr < 0.12:
            break
        z = z0 + h * t
        n = max(4, int(2 * math.pi * rr / 0.26))
        off = 0.5 if j % 2 else 0.0
        for k in range(n):
            a = 2 * math.pi * (k + off) / n
            p = Vector((rr * math.cos(a), rr * math.sin(a), z))
            du = Vector((-math.sin(a), math.cos(a), 0))
            dv = Vector((-math.cos(a) * r, -math.sin(a) * r, h)).normalized()
            nn = du.cross(dv).normalized()
            part = {"shingle": "shingle_b", "slate": "slate_a", "thatch": "thatch", "leaf": "leaf_a"}.get(cover, "tile_flat")
            g.inst("%s|%s%s" % (part, key, c.rng.choice(["", "~3", "~4"])), m @ basis(p + nn * 0.02, du, dv, nn) @ RX(4) @ Matrix.Diagonal((0.9, 1, 1, 1)))


def finial(c, m, h):
    g = c.g
    if c.s.family in ("whitestone", "gothic", "storybook", "clockwork"):
        g.cylinder(0.03, h + 0.4, "metal", m, segs=6)
        g.sphere(0.07, "gold", m @ T(0, 0, h * 0.5), segs=8, rings=5)
        g.box((0.5, 0.02, 0.18), "metal", m, (0.1, 0, h + 0.2))
    elif c.s.family in ("garden", "celestial", "desert"):
        for z, r in ((0.15, 0.12), (0.4, 0.09), (0.62, 0.06)):
            g.sphere(r, "gold", m @ T(0, 0, z), segs=10, rings=6)
        g.cylinder(0.02, h + 0.5, "gold", m, segs=6)
    else:
        g.cylinder(0.04, h, "metal" if c.s.family != "elven" else "trim", m, segs=6)
        g.sphere(0.09, "gold" if c.s.family != "elven" else "glow", m @ T(0, 0, h), segs=8, rings=5)


# ================================================================================================================
# Footings, chimneys and attachments


def footing(c, cx, cy, w, d, z0=0.0, door_x=None):
    """The base under a block. Returns the height of the floor on top of it."""
    s, g = c.s, c.g
    kind = s.base
    h = s.base_h
    if kind == "none":
        return z0
    if kind == "stilts":
        h = s.stilt_h
        nx, ny = max(2, int(w / 2.0) + 1), max(2, int(d / 2.0) + 1)
        for i in range(nx):
            for j in range(ny):
                x = cx - w / 2 + 0.2 + (w - 0.4) * i / (nx - 1)
                y = cy - d / 2 + 0.2 + (d - 0.4) * j / (ny - 1)
                g.cylinder(0.14, h + 0.4, "trim%s" % c.rng.choice(["", "~3", "~1"]), T(x, y, z0 - 0.4) @ RY(c.rng.uniform(-2, 2)), segs=10, bevel=0.03)
        g.rbox((w + 0.6, d + 0.6, 0.2), "trim", None, 0.04, c.seg(), (cx, cy, z0 + h - 0.1))
        # deck boards and a ladder to the door
        for k in range(int((w + 0.6) / 0.25)):
            g.inst("plank_a|wood_light%s" % c.rng.choice(["", "~3", "~4"]), T(cx - w / 2 - 0.3 + 0.125 + k * 0.25, cy - d / 2 - 0.3, z0 + h + 0.045) @ RX(-90) @ Matrix.Diagonal((1.2, 1, d + 0.6, 1)))
        lx = cx + (door_x or 0)
        for k in range(int(h / 0.32)):
            g.rbox((1.0, 0.3, 0.06), "wood_light", None, 0.02, 1, (lx, cy - d / 2 - 0.55 - k * 0.22, z0 + h - 0.18 - k * 0.32))
        for side in (-1, 1):
            ln = math.hypot(h, 0.22 * h / 0.32)
            ang = math.degrees(math.atan2(0.22 * h / 0.32, h))
            g.rbox((0.08, 0.1, ln), "trim", None, 0.02, 1, (lx + side * 0.5, cy - d / 2 - 0.4 - 0.11 * h / 0.32, z0 + h / 2))
        return z0 + h
    if kind in ("platform", "terrace"):
        pad = 0.8 if kind == "platform" else 1.2
        steps = 3 if kind == "platform" else int(h / 0.25)
        if kind == "terrace":
            for k in range(steps):
                hh = h * (1 - k / steps)
                g.rbox((w + pad * 2 - k * 0.5, d + pad * 2 - k * 0.5, h / steps), "stone%s" % ("" if k % 2 else "~3"), None, 0.05, c.seg(),
                       (cx, cy, z0 + h / steps * (k + 0.5)))
        else:
            ring_stones(c, cx, cy, w + pad * 2, d + pad * 2, z0, h)
        # front steps
        sw = 2.2
        for k in range(steps):
            g.rbox((sw, 0.4, h * (k + 1) / steps), "stone~2", None, 0.04, c.seg(),
                   (cx + (door_x or 0), cy - d / 2 - pad - 0.2 - (steps - 1 - k) * 0.4, z0 + h * (k + 1) / steps / 2))
        return z0 + h
    # plinth
    ring_stones(c, cx, cy, w + 0.12, d + 0.12, z0, h)
    for k in range(2):
        g.rbox((1.5 - k * 0.3, 0.42, h * (2 - k) / 2), "stone~2", None, 0.04, c.seg(),
               (cx + (door_x or 0), cy - d / 2 - 0.25 - 0.4 * (1 - k), z0 + h * (2 - k) / 4))
    return z0 + h


def ring_stones(c, cx, cy, w, d, z0, h):
    """A stone footing course around a rectangle, with a filled top."""
    g = c.g
    g.rbox((w - 0.1, d - 0.1, h), "mortar", None, 0.03, 1, (cx, cy, z0 + h / 2))
    for face, L in (("front", w), ("right", d), ("back", w), ("left", d)):
        m = face_matrix(cx, cy, w, d, z0, face)
        masonry_band(c, m, L, h)
    g.rbox((w + 0.04, d + 0.04, 0.08), "stone~2", None, 0.03, c.seg(), (cx, cy, z0 + h - 0.04))


def masonry_band(c, m, L, h):
    rng = c.rng
    x = -L / 2
    while x < L / 2 - 0.05:
        ln = rng.uniform(0.35, 0.7)
        if L / 2 - x - ln < 0.2:
            ln = L / 2 - x
        tone = rng.choice(["", "~3", "~4", "~1"])
        c.g.inst("stone_%s|stone%s" % (rng.choice("abcd"), tone), m @ T(x + ln / 2, -0.02, 0) @ Matrix.Diagonal((ln / 0.5, 1, h / 0.3, 1)))
        x += ln


def face_matrix(cx, cy, w, d, z, face):
    if face == "front":
        return T(cx, cy - d / 2, z)
    if face == "right":
        return T(cx + w / 2, cy, z) @ RZ(90)
    if face == "back":
        return T(cx, cy + d / 2, z) @ RZ(180)
    return T(cx - w / 2, cy, z) @ RZ(270)


def chimney(c, x, y, z0, top, kind=None):
    g, s = c.g, c.s
    kind = kind or s.chimney
    if kind == "none":
        return
    h = top - z0 + 0.8
    if kind in ("stone", "forge"):
        size = 0.75 if kind == "stone" else 1.2
        g.rbox((size, size, h), "mortar", None, 0.04, 1, (x, y, z0 + h / 2))
        m = T(x, y - size / 2, z0)
        for face in range(4):
            mm = T(x, y, z0) @ RZ(90 * face) @ T(0, -size / 2, 0)
            zz = 0.0
            row = 0
            while zz < h - 0.05:
                hh = min(0.28, h - zz)
                xx = -size / 2 + (0.15 if row % 2 else 0)
                if xx > -size / 2:
                    g.inst("stone_d|stone%s" % c.rng.choice(["", "~3", "~4"]), mm @ T((-size / 2 + xx) / 2, -0.01, zz) @ Matrix.Diagonal(((xx + size / 2) / 0.36, 1, hh / 0.28, 1)))
                while xx < size / 2 - 0.05:
                    ln = min(c.rng.uniform(0.3, 0.45), size / 2 - xx)
                    g.inst("stone_d|stone%s" % c.rng.choice(["", "~3", "~4", "~1"]), mm @ T(xx + ln / 2, -0.01, zz) @ Matrix.Diagonal((ln / 0.36, 1, hh / 0.28, 1)))
                    xx += ln
                zz += hh
                row += 1
        g.rbox((size + 0.16, size + 0.16, 0.14), "stone~2", None, 0.03, c.seg(), (x, y, z0 + h + 0.07))
        if kind == "forge" and not getattr(s, "ember_cap", False):  # the plain glowing hearth slab (every region)
            g.rbox((size - 0.3, size - 0.3, 0.1), "lamp", None, 0.02, 1, (x, y, z0 + h + 0.15))
        elif kind == "forge":  # Iron Hold's ember cap: a glowing coal bed, heaped coals and an iron grate over it
            zt = z0 + h + 0.14
            g.rbox((size - 0.24, size - 0.24, 0.14), "ember", None, 0.03, 1, (x, y, zt + 0.07))
            for k in range(6):
                a = 2 * math.pi * k / 6 + 0.4
                rr = (size - 0.5) * 0.32
                g.sphere(c.rng.uniform(0.12, 0.2), "ember" if k % 2 else "ember~2",
                         T(x + rr * math.cos(a), y + rr * math.sin(a), zt + 0.16), segs=8, rings=5, squash=0.7)
            g.sphere(0.22, "ember~2", T(x, y, zt + 0.2), segs=10, rings=6, squash=0.8)
            for k in (-1, 0, 1):
                g.box((size - 0.1, 0.05, 0.05), "metal", None, (x, y + k * (size - 0.4) / 3, zt + 0.36))
            for sx in (-1, 1):
                for sy in (-1, 1):
                    g.box((0.06, 0.06, 0.4), "metal", None, (x + sx * (size / 2 - 0.08), y + sy * (size / 2 - 0.08), zt + 0.18))
        else:
            g.cylinder(0.14, 0.32, "accent", T(x + 0.12, y, z0 + h + 0.14), segs=10, r_top=0.11, bevel=0.03)
    elif kind == "brick":
        g.rbox((0.7, 0.7, h), c.wall_key, None, 0.03, c.seg(), (x, y, z0 + h / 2))
        for k in range(3):
            g.rbox((0.8, 0.8, 0.08), "stone_dark", None, 0.02, 1, (x, y, z0 + h - 0.3 + k * 0.12))
        for dx in (-0.16, 0.16):
            g.cylinder(0.1, 0.4, "metal~2", T(x + dx, y, z0 + h), segs=10, bevel=0.02)
    elif kind == "funnel":
        g.rbox((0.6, 0.6, h), c.wall_key, None, 0.04, c.seg(), (x, y, z0 + h / 2))
        g.lathe([(0.2, 0.0), (0.45, 0.55), (0.45, 0.75), (0.0, 0.8)], "stone~2", T(x, y, z0 + h), segs=14)
    elif kind == "pipe":
        g.cylinder(0.12, h + 0.3, "metal", T(x, y, z0), segs=12, bevel=0.02)
        g.lathe([(0.0, 0.0), (0.26, 0.05), (0.0, 0.2)], "metal", T(x, y, z0 + h + 0.4), segs=12)


def sign(c, m, x, z, icon="star", hanging=True):
    """A hanging sign on a bracket with an icon (bread, potion, sword, star, cup, book, hammer, tankard, coin)."""
    g = c.g
    g.rbox((0.08, 0.9, 0.08), "metal", m, 0.02, 1, (x, -0.45, z + 0.65))
    for side in (-0.3, 0.3):
        g.box((0.02, 0.02, 0.2), "metal", m, (x, -0.45 + side - 0.15, z + 0.55))
    sm = m @ T(x, -0.6, z)
    g.rbox((0.06, 0.75, 0.55), "wood_light", sm, 0.03, c.seg())
    g.rbox((0.07, 0.65, 0.45), "accent", sm, 0.02, 1)
    ic = sm @ T(-0.05, 0, 0) @ RZ(90)
    if icon == "bread":
        g.sphere(0.16, "accent_b", ic, segs=10, rings=6, squash=0.6)
    elif icon == "potion":
        g.sphere(0.13, "glow", ic @ T(0, 0, -0.04), segs=10, rings=6)
        g.cylinder(0.04, 0.14, "glass", ic @ T(0, 0, 0.06), segs=8)
    elif icon == "sword":
        g.box((0.05, 0.02, 0.38), "metal~2", ic)
        g.box((0.2, 0.03, 0.04), "gold", ic, (0, 0, -0.1))
    elif icon == "cup" or icon == "tankard":
        g.cylinder(0.09, 0.18, "accent_b", ic @ T(0, 0, -0.09), segs=10)
    elif icon == "book":
        g.rbox((0.26, 0.04, 0.2), "accent_b", ic, 0.02, 1)
    elif icon == "hammer":
        g.box((0.04, 0.02, 0.3), "wood_light", ic)
        g.box((0.18, 0.03, 0.08), "metal~2", ic, (0, 0, 0.12))
    elif icon == "coin":
        g.cylinder(0.12, 0.03, "gold", ic @ RX(90), segs=14)
    else:
        g.lathe([(0.0, -0.03), (0.15, 0.0), (0.0, 0.03)], "gold", ic @ RX(90), segs=5)


def awning(c, m, x, z, w, depth=1.0):
    g = c.g
    n = max(3, int(w / 0.35))
    for k in range(n):
        key = "cloth_a" if k % 2 == 0 else "cloth_b"
        xx = x - w / 2 + (k + 0.5) * w / n
        g.rbox((w / n + 0.01, depth, 0.04), key, m @ T(xx, -depth / 2 + 0.05, z) @ RX(-18), 0.01, 1)
        g.rbox((w / n * 0.8, 0.03, 0.16), key, m, 0.01, 1, (xx, -depth * 0.97, z - depth * 0.31 - 0.08))
    for side in (-1, 1):
        g.rbox((0.04, depth, 0.04), "metal", m @ T(x + side * w / 2, -depth / 2, z - 0.15) @ RX(-30), 0.01, 1)


def banner(c, m, x, z, h=1.8, w=0.7):
    g = c.g
    sc = getattr(c.s, "banner_scale", 1.0)
    if sc != 1.0:  # bigger banners (Fanghold 2x), never trailing into the ground
        h = min(h * sc, max(h, z - 0.7))
        w = w * sc
    g.rbox((w + 0.2, 0.08, 0.08), "trim", m, 0.02, 1, (x, -0.12, z))
    g.rbox((w, 0.04, h), "cloth_a", m, 0.015, 1, (x, -0.12, z - h / 2))
    g.slab_poly([(x - w / 2, z - h), (x, z - h - 0.3), (x + w / 2, z - h)], 0.04, "cloth_a", m @ T(0, -0.12, 0))
    g.rbox((w * 0.5, 0.05, w * 0.5), "cloth_b", m @ T(x, -0.15, z - h * 0.45) @ RY(45), 0.01, 1)


def ivy(c, m, L, H):
    for k in range(int(L * H * 0.8)):
        x = c.rng.uniform(-L / 2 + 0.2, -L / 2 + L * 0.35) if c.rng.random() < 0.6 else c.rng.uniform(-L / 2, L / 2)
        z = c.rng.uniform(0, H * 0.9) ** 1.0
        c.g.inst("ivy|leaf%s" % c.rng.choice(["", "~3", "~1"]), m @ T(x, -0.06, z))
