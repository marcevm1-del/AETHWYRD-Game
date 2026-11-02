"""
Building archetypes: the buildings a settlement needs (13_Production/building_system.md lists them), each written
once and rendered in any regional style. A region can swap an archetype for its own signature building through the
style's `remap` (Mossdeep turns cottages into toadstools, Fanghold turns them into yurts, Hoshizora's temple is a
pagoda).

Every archetype is a function (ctx, p) -> None, where p holds the adjustable parameters (width, depth, floors, ...).
"""
import math

from mathutils import Matrix, Vector

from . import construct as K
from . import ornaments
from .construct import RX, RY, RZ, T, Op

# ================================================================================================================
# Shared pieces


def window_op(c, x, z, kind=None):
    s = c.s
    kind = kind or s.window
    w, h = s.window_w, s.window_h
    shape = {"arched": "arch", "horseshoe": "horseshoe", "round": "round", "porthole": "round", "pointed": "pointed",
             "trapezoid": "trap"}.get(kind, "rect")
    if kind == "slit":
        w, h = 0.34, 1.3
    elif kind in ("round", "porthole"):
        w = h = 0.85
    elif kind in ("arched", "pointed", "horseshoe"):
        h = h + w * 0.5
    elif kind == "lattice":
        w, h = 1.3, 1.25
    return Op(x, z, w, h, shape, False, kind)


def door_op(c, x, kind=None, wide=False):
    s = c.s
    kind = kind or s.door
    w = 1.9 if wide or kind == "double" else 1.15
    h = 2.35
    shape = {"arched": "arch", "round": "round", "pointed": "pointed", "trapezoid": "trap"}.get(kind, "rect")
    if kind == "sliding":
        w = 2.0 if wide else 1.7
        h = 2.3
    if kind == "round":
        w = h = 1.9
    if shape in ("arch", "pointed"):
        h += 0.35
    return Op(x, 0.0, w, h, shape, True, kind)


def layout(c, L, H, ground, door_x=None, door_kind=None, wide=False, shopfront=False, windows=True):
    ops = []
    if door_x is not None:
        ops.append(door_op(c, door_x, door_kind, wide))
    if shopfront:
        sw = min(2.2, (L - 3.0) / 2)
        for x in (door_x - (0.6 + sw / 2 + 0.3) if door_x is not None else -1.4, (door_x or 0) + 0.6 + sw / 2 + 0.3):
            if abs(x) + sw / 2 < L / 2 - 0.3:
                ops.append(Op(x, 0.55, sw, 1.65, "rect", False, "shutter" if c.s.window != "lattice" else "lattice"))
    if not windows:
        return ops
    probe = window_op(c, 0, 0)
    z = 0.95 if c.s.window != "slit" else 1.0
    if probe.h + z > H - 0.3:
        z = max(0.6, H - 0.3 - probe.h)
    for x in K.spread(L, probe.w, 1.15, 0.65):
        if any(abs(x - o.x) < o.w / 2 + probe.w / 2 + 0.35 for o in ops):
            continue
        ops.append(window_op(c, x, z))
    return ops


def faces_of(door_face):
    return ["front", "right", "back", "left"]


def block(c, cx, cy, w, d, floors=1, ridge="x", roof_form=None, door_face="front", door_x=0.0, door_kind=None,
          wide_door=False, shopfront=False, z0=0.0, base=True, wall_key=None, roof_key=None, pitch=None,
          windows=True, no_roof=False, ground_h=None, floor_h=None, jetty=None, chimney=None, open_faces=(),
          lantern=True, cover=None, overhang=None, gable_vent=True, face_windows=None, decorate=True):
    """A rectangular building block: footing, storeys of walls with openings, floor bands, corners and a roof."""
    s = c.s
    zf = K.footing(c, cx, cy, w, d, z0, door_x if door_face == "front" else 0) if base else z0
    fh = floor_h or s.floor_h
    key = wall_key or c.wall_key
    jet = s.jetty if jetty is None else jetty
    z = zf
    dw, dd = w, d
    for i in range(floors):
        H = ground_h if (i == 0 and ground_h) else fh
        dd = d + 2 * jet * i
        construction = (s.ground_walls or s.walls) if i == 0 else s.walls
        for face in ("front", "right", "back", "left"):
            L = dw if face in ("front", "back") else dd
            m = K.face_matrix(cx, cy, dw, dd, z, face)
            if face in open_faces and i == 0:
                open_front(c, m, L, H)
                continue
            dx = door_x if (i == 0 and face == door_face) else None
            win = windows if face_windows is None else (face in face_windows)
            ops = layout(c, L, H, i == 0, dx, door_kind, wide_door, shopfront and i == 0 and face == door_face, win)
            K.build_wall(c, m, L, H, ops, construction, key, i)
            for o in ops:
                if o.door:
                    K.door(c, m, o)
                    if lantern and (s.has("lanterns") or s.has("paper_lanterns")):
                        K.wall_lantern(c, m, o.x + o.w / 2 + 0.45, min(o.h + 0.3, H - 0.4))
                    if s.has("noren") and o.kind != "sliding":
                        pass
                else:
                    K.window(c, m, o, construction)
            if s.has("ivy") and c.chance(0.25):
                K.ivy(c, m, L, H)
            if s.has("vines") and c.chance(0.4):
                K.ivy(c, m, L * 0.6, H)
        corners(c, cx, cy, dw, dd, z, H)
        if i > 0 and jet > 0:
            for side in (-1, 1):  # jetty brackets under the overhang
                for k in range(int(dw / 1.4) + 1):
                    x = cx - dw / 2 + 0.3 + k * (dw - 0.6) / max(1, int(dw / 1.4))
                    c.g.rbox((0.16, jet + 0.3, 0.2), "trim", None, 0.03, c.seg(), (x, cy + side * (d / 2 + jet * (i - 0.5)), z - 0.05))
        z += H
        if i < floors - 1:
            band(c, cx, cy, dw, dd, z)
    top = z
    rise = 0
    if not no_roof:
        if ridge == "x":
            rm, W, D = T(cx, cy, top), dw, dd
        else:
            rm, W, D = T(cx, cy, top) @ RZ(90), dd, dw
        gf = (lambda m, L, Hh: gable(c, m, L, Hh, key, gable_vent)) if (roof_form or s.roof) in ("gable", "turf") else None
        rise = K.roof(c, rm, W, D, roof_form, pitch, cover, roof_key, None, overhang, gf)
        ch = s.chimney if chimney is None else chimney
        if ch != "none" and (roof_form or s.roof) not in ("flat",) and c.chance(0.8 if chimney is None else 1.0):
            sx = cx + (dw / 2 - 1.0) * (1 if c.chance(0.5) else -1) if ridge == "x" else cx + c.rng.uniform(-0.5, 0.5)
            sy = cy + (dd * 0.18 if ridge == "x" else (dd / 2 - 1.0))
            K.chimney(c, sx, sy, top - 0.5, top + rise, ch)
    if decorate and floors > 0:
        ornaments.decorate(c, cx, cy, dw, dd, zf, top, rise, ridge)
    return dict(top=top, rise=rise, zf=zf, w=dw, d=dd)


def gable(c, m, L, H, key, vent=True):
    s = c.s
    construction = s.walls
    clip = lambda z: max(0.0, L / 2 * (1 - z / H))
    if construction in ("ashlar", "rubble", "fitted", "brick", "carved", "rusticated", "log", "board", "clapboard"):
        K.build_wall(c, m, L, H, [], construction, key, 0, clip)
    else:
        K.build_wall(c, m, L, H, [], construction, key, 0, clip)
    if vent and H > 1.4:
        r = min(0.45, H * 0.18)
        zc = H * 0.38
        c.g.lathe([(r, -0.06), (r + 0.1, -0.06), (r + 0.1, 0.06), (r, 0.06), (r, -0.06)], "frame" if construction not in ("ashlar", "rubble", "brick") else "stone~2",
                  m @ T(0, -0.04, zc) @ RX(90), segs=16, cap_bottom=False, cap_top=False)
        c.g.cylinder(r, 0.04, "glass", m @ T(0, -0.02, zc) @ RX(90), segs=16)
        c.g.box((r * 2, 0.03, 0.05), "frame", m, (0, -0.05, zc))
        c.g.box((0.05, 0.03, r * 2), "frame", m, (0, -0.05, zc))


def band(c, cx, cy, w, d, z):
    s = c.s
    if s.band == "none":
        return
    key = {"beam": "trim", "stone": "stone~2", "tile": "accent"}.get(s.band, "trim")
    h = 0.22 if s.band != "tile" else 0.3
    c.g.rbox((w + 0.12, d + 0.12, h), key, None, 0.04, c.seg(), (cx, cy, z))
    if s.band == "tile" and c.hi:
        for face in ("front", "right", "back", "left"):
            L = w if face in ("front", "back") else d
            m = K.face_matrix(cx, cy, w + 0.12, d + 0.12, z, face)
            for k in range(int(L / 0.3)):
                c.g.rbox((0.2, 0.03, 0.2), "accent_b" if k % 2 else "accent~1", m @ T(-L / 2 + 0.15 + k * 0.3, -0.01, 0) @ RY(45), 0.02, 1)


def corners(c, cx, cy, w, d, z, H):
    s, g = c.s, c.g
    kind = s.corner
    pts = [(cx - w / 2, cy - d / 2), (cx + w / 2, cy - d / 2), (cx + w / 2, cy + d / 2), (cx - w / 2, cy + d / 2)]
    if kind == "post" and s.walls in ("timber_frame", "board", "clapboard"):
        for x, y in pts:
            g.rbox((0.24, 0.24, H), "trim", None, 0.04, c.seg(), (x, y, z + H / 2))
    elif kind == "quoin":
        for i, (x, y) in enumerate(pts):
            zz = 0.0
            k = 0
            while zz < H - 0.1:
                long_x = k % 2 == 0
                sx, sy = (0.7, 0.36) if long_x else (0.36, 0.7)
                ox = 0.35 * (1 if x < cx else -1) if long_x else 0
                oy = 0.35 * (1 if y < cy else -1) if not long_x else 0
                g.rbox((sx, sy, 0.3), "stone~2", None, 0.03, c.seg(), (x + ox - (0.04 if x < cx else -0.04), y + oy - (0.04 if y < cy else -0.04), z + zz + 0.16))
                zz += 0.34
                k += 1
    elif kind == "column":
        for x, y in pts:
            g.cylinder(0.2, H, "trim" if s.walls in ("post_panel", "living") else "stone~2", T(x, y, z), segs=14, bevel=0.03)
            g.rbox((0.5, 0.5, 0.18), "stone~2" if s.walls not in ("post_panel", "living") else "trim~1", None, 0.04, c.seg(), (x, y, z + H - 0.09))
    elif kind == "buttress":
        for x, y in pts:
            for k in range(3):
                hh = H * (1 - k * 0.3)
                g.rbox((0.6 - k * 0.12, 0.6 - k * 0.12, hh), "stone%s" % ("" if k else "~3"), None, 0.04, c.seg(),
                       (x + (0.15 if x > cx else -0.15), y + (0.15 if y > cy else -0.15), z + hh / 2))
    if s.has("buttresses") and kind != "buttress":
        for x, y in pts:
            g.rbox((0.7, 0.7, H * 0.7), "stone~1", None, 0.08, c.seg(), (x + (0.2 if x > cx else -0.2), y + (0.2 if y > cy else -0.2), z + H * 0.35))
    if s.has("crystals") and c.chance(0.4):
        x, y = pts[c.rng.randrange(4)]
        crystal_cluster(c, x, y, z if z < 1 else 0.0)


def open_front(c, m, L, H):
    """An open-sided storey (stalls, forges, porches): posts and a beam instead of a wall."""
    g = c.g
    n = max(2, int(L / 2.6) + 1)
    for k in range(n):
        x = -L / 2 + 0.15 + (L - 0.3) * k / (n - 1)
        g.rbox((0.24, 0.24, H), "trim", m, 0.04, c.seg(), (x, 0.1, H / 2))
    g.rbox((L + 0.1, 0.26, 0.3), "trim", m, 0.04, c.seg(), (0, 0.1, H - 0.15))


def crystal_cluster(c, x, y, z):
    for k in range(4):
        h = c.rng.uniform(0.5, 1.3)
        c.g.lathe([(0.0, 0.0), (0.12, 0.1), (0.1, h * 0.8), (0.0, h)], "glow", T(x + c.rng.uniform(-0.3, 0.3), y + c.rng.uniform(-0.3, 0.3), z)
                  @ RX(c.rng.uniform(-25, 25)) @ RY(c.rng.uniform(-25, 25)), segs=6)


def tower(c, cx, cy, size, floors, roof_form=None, floor_h=None, door=True, z0=0.0, base=True, round_=False):
    """A square (or round) tower with the style's tower roof."""
    s = c.s
    rf = roof_form or s.tower_roof
    if not float(floors).is_integer():  # keep the height, in whole storeys
        total = floors * (floor_h or s.floor_h)
        floors = max(1, int(math.ceil(floors)))
        floor_h = total / floors
    floors = int(floors)
    if round_:
        return round_block(c, cx, cy, size / 2, floors, rf if rf in ("cone", "dome", "onion", "cap", "spire") else "cone",
                           floor_h=floor_h, door=door, z0=z0)
    square_form = {"cone": "pyramid", "spire": "spire", "pyramid": "pyramid", "curved": "curved", "dome": "flat_dome",
                   "onion": "flat_onion", "cap": "pyramid"}.get(rf, "pyramid")
    if square_form in ("flat_dome", "flat_onion"):
        info = block(c, cx, cy, size, size, floors, "x", "flat", door_x=0.0 if door else None, z0=z0, base=base,
                     floor_h=floor_h, jetty=0.0, chimney="none")
        top = info["top"] + 0.25
        K.round_roof(c, T(cx, cy, top), size * 0.42, "dome" if square_form == "flat_dome" else "onion", c.roof_key, s.cover)
        return info
    return block(c, cx, cy, size, size, floors, "x", square_form, door_x=0.0 if door else None, z0=z0, base=base,
                 floor_h=floor_h, jetty=0.0, chimney="none", overhang=0.4 if square_form != "curved" else None,
                 cover=s.cover if s.cover not in ("turf",) else "plank")


def round_block(c, cx, cy, r, floors=1, roof_form="cone", floor_h=None, door=True, z0=0.0, wall=None, windows=True):
    """A round building: footing ring, curved wall (masonry rings, felt, stalk or plaster), openings and roof."""
    s, g = c.s, c.g
    fh = floor_h or s.floor_h
    construction = wall or s.walls
    z = z0
    if s.base not in ("none", "stilts") and construction not in ("stalk", "felt"):
        h = 0.5
        g.cylinder(r + 0.25, h, "stone~3", T(cx, cy, z0), segs=32, bevel=0.06)
        z += h
    H = fh * floors
    if construction in ("ashlar", "rubble", "fitted", "brick", "carved"):
        g.cylinder(r - 0.06, H, "mortar", T(cx, cy, z), segs=32)
        ch = 0.34 if construction != "brick" else 0.087
        zz, row = 0.0, 0
        part = {"ashlar": "ashlar_a", "brick": "brick", "fitted": "boulder_a"}.get(construction, "stone_a")
        nominal = {"ashlar_a": 0.6, "brick": 0.24, "boulder_a": 0.55}.get(part, 0.5)
        hn = {"ashlar_a": 0.32, "brick": 0.075, "boulder_a": 0.38}.get(part, 0.3)
        door_a = -90.0
        while zz < H - 0.05:
            n = max(6, int(2 * math.pi * r / nominal))
            for k in range(n):
                a = 360.0 * (k + (0.5 if row % 2 else 0)) / n
                if door and zz < 2.6 and abs(((a - door_a + 180) % 360) - 180) < 32:
                    continue
                arc = 2 * math.pi * r / n
                g.inst("%s|stone%s" % (part, c.rng.choice(["", "~3", "~4", "~1"])),
                       T(cx, cy, z + zz) @ RZ(a) @ T(r, 0, 0) @ RZ(90) @ T(0, -0.02, 0.01) @ Matrix.Diagonal(((arc - 0.02) / nominal, 1, (ch - 0.02) / hn, 1)))
            zz += ch
            row += 1
    elif construction == "felt":
        g.cylinder(r, H, "accent", T(cx, cy, z), segs=32, bevel=0.05)
        for zb in (0.35, H - 0.25):
            g.cylinder(r + 0.03, 0.12, "cloth_a", T(cx, cy, z + zb), segs=32, bevel=0.02)
        for k in range(24):  # lattice wall slats showing at the bottom
            a = 360 * k / 24
            g.rbox((0.05, 0.05, 0.3), "trim", T(cx, cy, z) @ RZ(a) @ T(r + 0.02, 0, 0.15), 0.01, 1)
    elif construction == "stalk":
        prof = [(r * 0.98, 0.0), (r * 1.06, H * 0.25), (r * 1.02, H * 0.65), (r * 0.92, H)]
        g.lathe(prof, c.wall_key, T(cx, cy, z), segs=32, cap_bottom=True, cap_top=True)
        for k in range(10):  # gill lines and texture bumps
            a = c.rng.uniform(0, 360)
            zz = c.rng.uniform(0.2, H * 0.9)
            g.sphere(0.12, c.wall_key + "~3", T(cx, cy, z + zz) @ RZ(a) @ T(r * 1.02, 0, 0), segs=6, rings=4, squash=0.6)
    elif construction == "log":
        zz = 0.0
        while zz < H:
            g.cylinder(r + 0.12, 0.26, c.wall_key + c.rng.choice(["", "~3", "~4"]), T(cx, cy, z + zz), segs=28, bevel=0.1)
            zz += 0.26
    else:
        g.cylinder(r, H, c.wall_key, T(cx, cy, z), segs=32, bevel=0.04)
        if construction == "timber_frame":
            for k in range(8):
                a = 360 * k / 8 + 22.5
                g.rbox((0.18, 0.12, H), "trim", T(cx, cy, z) @ RZ(a) @ T(r + 0.02, 0, H / 2) @ RZ(90), 0.03, c.seg())
            g.cylinder(r + 0.06, 0.18, "trim", T(cx, cy, z + H - 0.18), segs=32, bevel=0.03)
    # openings (surface-mounted on the curve)
    if door:
        m = T(cx, cy, z) @ RZ(-90) @ T(r + (0.08 if construction == "stalk" else 0.02), 0, 0) @ RZ(90)
        o = K.Op(0, 0.0, 1.3 if construction != "felt" else 1.0, 2.0 if construction != "felt" else 1.5,
                 "round" if s.door == "round" else ("arch" if s.door in ("arched", "round") else "rect"), True,
                 s.door if s.door != "sliding" else "plank")
        if o.shape == "round":
            o.w = o.h = 1.7
        c.g.slab_poly(o.outline(), 0.1, "trim_dark", m @ T(0, 0.02, 0))
        K.door(c, m @ T(0, -0.12, 0), o)
    if windows:
        for i in range(floors):
            for a in ((-30, 30, 150, 210) if i == 0 else (0, 90, 180, 270)):
                if i == 0 and door and abs(a + 90) < 40:
                    continue
                m = T(cx, cy, z + i * fh) @ RZ(a) @ T(r + (0.06 if construction == "stalk" else 0.0), 0, 0) @ RZ(90)
                o = window_op(c, 0, 0.95)
                if construction == "felt":
                    continue
                c.g.slab_poly(o.outline(), 0.06, "glass", m @ T(0, -0.04, 0))
                K.frame_along(c, m, o.outline(), 0.1, 0.14, "frame" if construction not in ("ashlar", "rubble", "brick") else "stone~2", -0.08)
    top = z + H
    rr = r + (0.25 if construction == "stalk" else 0.0)
    rise = 0.0
    if roof_form:
        if roof_form == "spire":
            K.roof(c, T(cx, cy, top), r * 2, r * 2, "spire")
            rise = r * 3
        else:
            rise = K.round_roof(c, T(cx, cy, top), rr if roof_form != "cap" else r * 1.25, roof_form, c.roof_key,
                                c.s.cover if roof_form == "cone" else c.s.cover)
    return dict(top=top, rise=rise, zf=z, w=2 * r, d=2 * r)


def place_sign(c, cx, cy, d, z, x, icon):
    m = K.face_matrix(cx, cy, 0, d, z, "front")
    K.sign(c, m, x, z * 0 + 2.9, icon)


# ================================================================================================================
# Homes


def cottage(c, p):
    w, d = p.get("width", 6.6), p.get("depth", 5.4)
    block(c, 0, 0, w, d, p.get("floors", 1), door_x=c.rng.choice([-0.8, 0.0, 0.8]))


def house(c, p):
    w, d = p.get("width", 8.0), p.get("depth", 6.4)
    block(c, 0, 0, w, d, p.get("floors", 2), door_x=c.rng.choice([-1.2, 0.0, 1.2]))


def townhouse(c, p):
    w, d = p.get("width", 5.6), p.get("depth", 7.6)
    block(c, 0, 0, w, d, p.get("floors", 3), ridge="y", door_x=-0.9, jetty=0.0)
    if c.s.has("balconies") or c.s.family in ("storybook", "lagoon", "whitestone"):
        balcony(c, 0, -d / 2, c.s.base_h + c.s.floor_h + 0.1, w * 0.6)


def stilt_house(c, p):
    s = c.s
    old = s.base
    s.base = "stilts"
    try:
        block(c, 0, 0, p.get("width", 7.0), p.get("depth", 5.6), p.get("floors", 1), door_x=0.0)
    finally:
        s.base = old


def manor(c, p):
    w, d = p.get("width", 12.0), p.get("depth", 8.5)
    fl = p.get("floors", 2)
    info = block(c, 0, 0, w, d, fl, door_x=0.0, wide_door=True, roof_form="hip" if c.s.roof == "gable" else None)
    for side in (-1, 1):
        block(c, side * (w / 2 + 2.6), 1.0, 5.2, 7.0, max(1, fl - 1), ridge="y", door_x=None, chimney="none")
    if c.s.family in ("storybook", "whitestone", "gothic"):
        tower(c, w / 2 - 0.5, -d / 2 + 0.5, 3.0, fl + 1, round_=True)
    balcony(c, 0, -d / 2, info["zf"] + c.s.floor_h + 0.1, 3.0)


def longhouse(c, p):
    w, d = p.get("width", 16.0), p.get("depth", 7.0)
    block(c, 0, 0, w, d, 1, ridge="x", door_face="right", door_x=0.0, ground_h=p.get("wall_h", 2.6), pitch=48, gable_vent=False)
    # a porch at the gable door
    porch(c, w / 2 + 1.0, 0, 2.0, 3.6, c.s.base_h, axis="y")


def longhouse_hall(c, p):
    longhouse(c, dict(p, width=p.get("width", 22.0), depth=p.get("depth", 9.0), wall_h=3.0))
    sign(c, 0.0, -4.5, c.s.base_h, "tankard")


def balcony(c, cx, cy, z, w):
    g = c.g
    g.rbox((w, 1.1, 0.16), "trim", None, 0.03, c.seg(), (cx, cy - 0.55, z))
    rail_key = "metal" if c.s.family in ("lagoon", "clockwork", "whitestone", "gothic") else "trim"
    g.rbox((w, 0.08, 0.08), rail_key, None, 0.02, 1, (cx, cy - 1.06, z + 0.95))
    for k in range(int(w / 0.18) + 1):
        g.box((0.04, 0.04, 0.9), rail_key, None, (cx - w / 2 + k * w / int(w / 0.18), cy - 1.06, z + 0.5))
    for side in (-1, 1):
        g.rbox((0.12, 0.9, 0.14), "trim", T(cx + side * (w / 2 - 0.2), cy - 0.45, z - 0.35) @ RX(-35), 0.02, 1)
    if c.s.has("flower_boxes"):
        K.flower_box(c, T(cx, cy - 1.0, z + 1.0), 0, 0, w * 0.8)


def porch(c, cx, cy, w, d, z, axis="x"):
    g = c.g
    g.rbox((w, d, 0.16), "wood_light", None, 0.03, c.seg(), (cx, cy, z + 0.08))
    for sx in (-1, 1):
        for sy in (-1, 1):
            g.rbox((0.18, 0.18, 2.5), "trim", None, 0.03, c.seg(), (cx + sx * (w / 2 - 0.15), cy + sy * (d / 2 - 0.15), z + 1.33))
    m = T(cx, cy, z + 2.6) @ (RZ(90) if axis == "y" else Matrix.Identity(4))
    K.roof(c, m, d if axis == "y" else w, w if axis == "y" else d, "gable" if c.s.roof != "flat" else "flat", pitch=30, overhang=0.2)


# ================================================================================================================
# Trade


ICONS = ["bread", "potion", "sword", "cup", "book", "hammer", "coin", "star"]


def sign(c, x, y, z, icon):
    K.sign(c, T(x, y, z), 0.0, 3.0, icon)


def shop(c, p):
    w, d = p.get("width", 7.2), p.get("depth", 6.2)
    info = block(c, 0, 0, w, d, p.get("floors", 2), door_x=0.0, shopfront=True)
    icon = p.get("icon") or c.rng.choice(ICONS)
    sign(c, w / 2 - 0.4, -d / 2, info["zf"], icon)
    if c.s.has("awnings") or c.s.family in ("storybook", "lagoon", "desert", "garden"):
        K.awning(c, K.face_matrix(0, 0, w, d, info["zf"], "front"), 0.0, 2.75, w - 0.6)
    crates(c, -w / 2 + 0.6, -d / 2 - 0.9, info["zf"] - c.s.base_h if c.s.base != "stilts" else info["zf"])


def inn(c, p):
    w, d = p.get("width", 12.5), p.get("depth", 9.0)
    info = block(c, 0, 0, w, d, p.get("floors", 3), door_x=-1.5, wide_door=True)
    block(c, w / 2 + 3.0, 1.0, 6.0, 6.5, 2, ridge="y", door_x=None, chimney="stone" if c.s.chimney != "none" else "none")
    porch(c, -1.5, -d / 2 - 1.2, 4.0, 2.2, info["zf"] - 0.0)
    sign(c, 1.2, -d / 2, info["zf"], "tankard")
    for k in range(2):
        bench(c, 2.4 + k * 2.2, -d / 2 - 1.6, 0 if c.s.base == "stilts" else info["zf"] - c.s.base_h)


def tavern(c, p):
    w, d = p.get("width", 10.0), p.get("depth", 8.0)
    if c.s.has("banners"):
        c.notes.append("own_banners")  # this archetype hangs its own front banner: no facade_banners on top of it
    info = block(c, 0, 0, w, d, p.get("floors", 2), door_x=0.0, wide_door=True)
    sign(c, w / 2 - 0.4, -d / 2, info["zf"], "cup")
    for k in range(3):
        bench(c, -3.2 + k * 3.2, -d / 2 - 2.2, 0.0)
    K.banner(c, K.face_matrix(0, 0, w, d, info["zf"], "front"), -w / 2 + 1.0, 2.9 + c.s.floor_h, 1.6, 0.6) if c.s.has("banners") else None


def warehouse(c, p):
    w, d = p.get("width", 12.0), p.get("depth", 9.0)
    info = block(c, 0, 0, w, d, p.get("floors", 2), ridge="y", door_x=0.0, wide_door=True, chimney="none")
    # hoist beam over a loft door
    z = info["zf"] + info["top"] - info["zf"]
    c.g.rbox((0.22, 1.6, 0.22), "trim", None, 0.03, c.seg(), (0, -d / 2 - 0.7, z - 0.2))
    c.g.cylinder(0.02, 1.6, "metal", T(0, -d / 2 - 1.4, z - 1.8), segs=6)
    crates(c, 2.5, -d / 2 - 1.2, 0.0)
    crates(c, -2.8, -d / 2 - 1.0, 0.0)


def market_stall(c, p):
    g = c.g
    w, d = p.get("width", 3.2), p.get("depth", 2.2)
    for sx in (-1, 1):
        for sy in (-1, 1):
            g.rbox((0.12, 0.12, 2.4 if sy < 0 else 2.0), "trim", None, 0.02, c.seg(), (sx * (w / 2 - 0.1), sy * (d / 2 - 0.1), 1.2 if sy < 0 else 1.0))
    g.rbox((w, d * 0.45, 0.9), "wood_light", None, 0.03, c.seg(), (0, -d / 2 + d * 0.25, 0.45))
    canopy = lambda u, v: (lerp(-w / 2 - 0.2, w / 2 + 0.2, u), lerp(-d / 2 - 0.4, d / 2 + 0.1, v), lerp(2.25, 2.05, v) + 0.12 * math.sin(math.pi * u * 4) * (1 - v) * 0.3)
    g.patch(canopy, 12, 4, "cloth_a", None, 0.04)  # always the family's canopy cloth; the posts are trim (review B1)
    for k in range(5):
        x = -w / 2 + 0.3 + k * (w - 0.6) / 4
        g.sphere(0.13, c.rng.choice(["flower_a", "flower_c", "accent_b", "leaf"]), T(x, -d / 2 + 0.35, 0.98), segs=8, rings=5)
        g.rbox((0.4, 0.3, 0.16), "wood_light~3", None, 0.02, 1, (x, -d / 2 + 0.6, 0.98))


def lerp(a, b, t):
    return a + (b - a) * t


def bench(c, x, y, z):
    g = c.g
    g.rbox((1.6, 0.4, 0.08), "wood_light", None, 0.02, c.seg(), (x, y, z + 0.45))
    for sx in (-0.65, 0.65):
        g.rbox((0.08, 0.36, 0.45), "trim", None, 0.02, 1, (x + sx, y, z + 0.22))


def crates(c, x, y, z):
    g = c.g
    for k in range(c.rng.randint(2, 4)):
        s = c.rng.uniform(0.45, 0.65)
        px, py = x + c.rng.uniform(-0.5, 0.5), y + c.rng.uniform(-0.3, 0.3)
        g.rbox((s, s, s), "wood_light%s" % c.rng.choice(["", "~3", "~4"]), T(px, py, z + s / 2 + (0.0 if k < 2 else 0.6)) @ RZ(c.rng.uniform(-20, 20)), 0.03, c.seg())
        g.rbox((s + 0.02, 0.06, s * 0.15), "trim", T(px, py, z + s / 2 + (0.0 if k < 2 else 0.6)) @ RZ(c.rng.uniform(-20, 20)), 0.01, 1)
    if c.chance(0.7):
        g.lathe([(0.0, 0.0), (0.3, 0.0), (0.36, 0.4), (0.3, 0.8), (0.0, 0.8)], "wood_light~1", T(x + 0.9, y, z), segs=14)


# ================================================================================================================
# Craft, farm and mills


def smithy(c, p):
    w, d = p.get("width", 8.0), p.get("depth", 6.5)
    info = block(c, 0, 0, w, d, 1, door_x=None, open_faces=("front",), chimney="none", ground_h=3.2)
    zf = info["zf"]
    g = c.g
    # forge hearth and its chimney against the back wall
    g.rbox((2.2, 1.6, 1.0), "stone~3", None, 0.06, c.seg(), (-1.5, d / 2 - 1.2, zf + 0.5))
    g.rbox((1.4, 0.9, 0.12), "lamp", None, 0.03, 1, (-1.5, d / 2 - 1.2, zf + 1.02))
    if c.s.forge_mouth:  # review B3 (Iron Hold): a lit forge mouth, a 1.2 x 0.8 m glow in the hearth facing the open bay
        # a second, brick-built forge against the back wall, mid-bay, so the mouth shows between the posts
        # (low and well inside the bay: the eaves hide the back wall above about 1 m at the sheet camera's pitch)
        fx, fy = 0.3, d / 2 - 1.9
        g.rbox((1.8, 0.9, 1.15), "stone~3", None, 0.06, c.seg(), (fx, fy, zf + 0.575))
        g.rbox((1.6, 0.08, 1.0), "stone_dark", None, 0.03, 1, (fx, fy - 0.47, zf + 0.5))  # dark surround
        g.box((1.2, 0.03, 0.8), "ember", None, (fx, fy - 0.53, zf + 0.5))
        g.rbox((2.0, 1.0, 0.14), "stone~1", None, 0.04, 1, (fx, fy, zf + 1.2))
    K.chimney(c, -1.5, d / 2 - 0.7, zf, info["top"] + info["rise"], "forge")
    # anvil, quench barrel, tool rack
    g.rbox((0.5, 0.45, 0.55), "stone_dark", None, 0.04, 1, (1.2, -0.6, zf + 0.28))
    g.lathe([(0.0, 0.0), (0.22, 0.0), (0.22, 0.25), (0.45, 0.32), (0.5, 0.45), (0.0, 0.45)], "metal", T(1.2, -0.6, zf + 0.55) @ RZ(90) @ Matrix.Diagonal((1.5, 0.6, 1, 1)), segs=8)
    g.lathe([(0.0, 0.0), (0.4, 0.0), (0.45, 0.4), (0.4, 0.8), (0.0, 0.75)], "wood_light~1", T(2.4, 0.4, zf), segs=16)
    g.cylinder(0.38, 0.05, "water", T(2.4, 0.4, zf + 0.72), segs=16)
    for k in range(4):
        g.rbox((0.05, 0.05, 0.9), "metal~2", None, 0.01, 1, (-w / 2 + 0.8 + k * 0.25, d / 2 - 0.35, zf + 1.5))


def barn(c, p):
    w, d = p.get("width", 9.0), p.get("depth", 12.0)
    info = block(c, 0, 0, w, d, 1, ridge="y", door_x=0.0, wide_door=True, ground_h=4.0, chimney="none", pitch=48)
    hay(c, w / 2 + 1.2, -d / 2 + 1.5, 0.0)


def hay(c, x, y, z):
    for k in range(3):
        c.g.cylinder(0.55, 1.0, "thatch%s" % c.rng.choice(["", "~3"]), T(x + (k % 2) * 0.4, y + k * 1.1, z + 0.55) @ RX(90), segs=16, bevel=0.15)


def stable(c, p):
    w, d = p.get("width", 12.0), p.get("depth", 6.0)
    info = block(c, 0, 0, w, d, 1, door_x=None, open_faces=("front",), chimney="none", ground_h=3.0, pitch=38)
    zf = info["zf"]
    n = int(w / 3.0)
    for k in range(n):  # stall dividers and half doors
        x = -w / 2 + (k + 0.5) * w / n
        c.g.rbox((0.12, d * 0.7, 1.4), "trim", None, 0.03, c.seg(), (x - w / n / 2 + 0.1, 0, zf + 0.7))
        c.g.rbox(((w / n) * 0.8, 0.08, 1.1), "door", None, 0.03, c.seg(), (x, -d / 2 + 0.3, zf + 0.6))
    hay(c, -w / 2 - 1.2, 0, 0.0)
    c.g.rbox((2.2, 0.6, 0.6), "wood_light~1", None, 0.04, 1, (w / 2 + 1.4, -d / 2 + 1.0, 0.3))  # trough


def granary(c, p):
    form = GRANARY_FORMS.get(c.s.family)
    if form:  # review B1: the family's own grain store; the round tower stays the default
        return form(c, p)
    round_block(c, 0, 0, p.get("radius", 2.6), p.get("floors", 2), "cone", floor_h=3.2)


def _prof_r(prof, z):
    """The radius of a lathe profile [(r, z), ...] (z rising) at height z."""
    for (r0, z0), (r1, z1) in zip(prof, prof[1:]):
        if z0 <= z <= z1 and z1 > z0:
            return r0 + (r1 - r0) * (z - z0) / (z1 - z0)
    return prof[-1][0]


def beehive_granary(c, p):
    """Desert (Sunscar, Zaruma): three beehive mud domes, 2.5-3.5 m, in the wall plaster, with a top hatch, a wooden
    plug, climbing pegs and a ladder against the tallest."""
    g = c.g
    domes = ((-1.5, 0.4, 1.45, 3.5), (1.35, 0.85, 1.2, 2.9), (0.1, -1.45, 1.05, 2.5))
    for k, (x, y, r, h) in enumerate(domes):
        prof = [(r, 0.0), (r * 1.03, h * 0.18), (r * 0.97, h * 0.42), (r * 0.8, h * 0.66), (r * 0.52, h * 0.86),
                (r * 0.2, h * 0.97), (0.0, h)]
        g.cylinder(r + 0.14, 0.24, "wall_a~3", T(x, y, 0), segs=28, bevel=0.08)  # mud footing ring
        g.lathe(prof, "wall_a" if k != 1 else "wall_a~4", T(x, y, 0.2), segs=28)
        g.lathe([(r * 0.2 + 0.06, h * 0.95), (r * 0.2 + 0.08, h * 1.0), (0.0, h + 0.08)], "wall_a~3", T(x, y, 0.2), segs=16)
        # the filling hatch facing the camera side, a wooden plug and a mud lip
        a = math.radians(-120 + 25 * k)
        zh = h * 0.72
        rr = _prof_r(prof, zh)
        hm = T(x, y, 0.2) @ RZ(math.degrees(a) + 90) @ T(0, -rr + 0.05, zh)
        g.rbox((0.62, 0.2, 0.55), "wall_a~3", hm, 0.12, c.seg())
        g.rbox((0.42, 0.16, 0.38), "trim", hm @ T(0, -0.06, 0), 0.05, 1)
        g.rbox((0.48, 0.04, 0.06), "trim_dark", hm @ T(0, -0.15, 0.06), 0.01, 1)
        if k == 0:  # wooden climbing pegs up the tallest dome
            for j in range(4):
                zp = 0.6 + j * 0.55
                rp = _prof_r(prof, zp)
                g.cylinder(0.05, 0.5, "trim", T(x, y, 0.2) @ RZ(math.degrees(a) + 90 + 30) @ T(0, -rp + 0.15, zp) @ RX(90), segs=6)
    # a pole ladder leaning on the tallest dome
    lx, ly = -1.5 + 1.75 * math.cos(math.radians(-150)), 0.4 + 1.75 * math.sin(math.radians(-150))
    lm = T(lx, ly, 0) @ RZ(-60) @ RX(-12)  # leaning in towards the dome
    for sx in (-0.22, 0.22):
        g.cylinder(0.05, 2.9, "trim", lm @ T(sx, 0, 0), segs=6)
    for j in range(6):
        g.cylinder(0.035, 0.5, "wood_light", lm @ T(-0.25, 0, 0.35 + j * 0.45) @ RY(90), segs=6)
    for x, y in ((1.2, -0.6), (1.75, -0.2)):  # grain sacks
        g.sphere(0.3, "cloth_b~3", T(x, y, 0.26), segs=10, rings=6, squash=0.8)


def basalt_silo(c, p):
    """Dwarven (Iron Hold, Dragon Spine): a squat basalt silo under a copper cone (#B87333, never thatch), bronze bands,
    lit slit windows and a lantern by the door."""
    g, s = c.g, c.s
    r, H = p.get("radius", 3.0), 3.6
    info = round_block(c, 0, 0, r, 1, None, floor_h=H, wall="ashlar", windows=False)
    z0, top = info["zf"], info["top"]
    for zb in (z0 + 0.25, top - 0.25):  # bronze bands
        g.cylinder(r + 0.06, 0.4, "trim", T(0, 0, zb - 0.2), segs=32, bevel=0.04)
    glass = getattr(s, "window_glass", "glass")
    for a in (-150, -35, 150):  # slit windows (lit in Iron Hold), clear of the door at -90
        m = T(0, 0, z0) @ RZ(a) @ T(r, 0, 0) @ RZ(90)
        g.rbox((0.42, 0.2, 1.25), "stone_dark", m, 0.03, 1, (0, -0.02, H * 0.55))
        g.box((0.2, 0.06, 1.0), glass, m, (0, -0.11, H * 0.55))
    dm = T(0, 0, z0) @ RZ(-90) @ T(r + 0.02, 0, 0) @ RZ(90)
    K.wall_lantern(c, dm @ T(0, 0.14, 0), 1.05, 2.35)
    # the squat copper cone with standing seams, a copper drip ring and a finial
    R, h = r + 0.45, (r + 0.45) * 0.62
    g.lathe([(R - 0.05, -0.25), (0.05, h - 0.12)], "roof_under", T(0, 0, top), segs=28)
    g.lathe([(R, -0.3), (R, -0.16), (0.1, h), (0.0, h)], "roof_copper", T(0, 0, top), segs=32)
    g.cylinder(R + 0.04, 0.12, "roof_copper~1", T(0, 0, top - 0.3), segs=32, bevel=0.03)
    p0, p1 = (R, -0.16), (0.14, h - 0.05)
    ln = math.hypot(p1[0] - p0[0], p1[1] - p0[1])
    tilt = math.degrees(math.atan2(p1[0] - p0[0], p1[1] - p0[1]))
    for k in range(20 if c.hi else 12):
        g.rbox((0.06, 0.06, ln), "roof_copper~3", T(0, 0, top) @ RZ(k * 360 / (20 if c.hi else 12)) @
               T((p0[0] + p1[0]) / 2 + 0.03, 0, (p0[1] + p1[1]) / 2) @ RY(tilt), 0.015, 1)
    g.cylinder(0.22, 0.25, "roof_copper~1", T(0, 0, top + h - 0.1), segs=12, bevel=0.05)
    g.lathe([(0.0, 0.0), (0.09, 0.05), (0.0, 0.7)], "roof_copper", T(0, 0, top + h + 0.15), segs=8)


def kura(c, p):
    """A raised kura storehouse (Hoshizora's granary): white plaster over a dark namako-tiled base, a tile gable roof."""
    g = c.g
    w, d, H = p.get("width", 6.0), p.get("depth", 4.6), p.get("height", 5.0)
    zb = 0.8
    g.rbox((w + 0.5, d + 0.5, zb), "stone~1", None, 0.05, c.seg(), (0, 0, zb / 2))  # raised stone base
    g.rbox((w, d, H), "wall_a", None, 0.03, c.seg(), (0, 0, zb + H / 2))  # white plaster body
    wains = 1.6
    for face in ("front", "right", "back", "left"):
        L = w if face in ("front", "back") else d
        m = K.face_matrix(0, 0, w, d, zb, face)
        if c.hi:  # namako: dark tiles set diagonally in raised white plaster joints
            g.rbox((L + 0.08, 0.06, wains), "wall_a~3", m, 0.01, 1, (0, -0.03, wains / 2))
            for j in range(int((wains - 0.3) / 0.25) + 1):
                z = 0.2 + j * 0.25
                off = 0.25 if j % 2 else 0.0
                x = -L / 2 + 0.25 + off
                while x < L / 2 - 0.2:
                    g.rbox((0.3, 0.04, 0.3), "trim_dark", m @ T(x, -0.07, z) @ RY(45), 0.01, 1)
                    x += 0.5
        else:
            g.rbox((L + 0.08, 0.06, wains), "trim_dark", m, 0.01, 1, (0, -0.03, wains / 2))
        g.rbox((L + 0.14, 0.12, 0.14), "trim_dark", m, 0.02, 1, (0, -0.04, wains + 0.07))
        zw = H * 0.72  # small barred upper windows with a thick plaster shutter
        for x in ((-L / 4, L / 4) if face in ("front", "back") else (0.0,)):
            g.rbox((1.0, 0.14, 1.0), "wall_a~3", m, 0.04, c.seg(), (x, -0.07, zw))
            g.rbox((0.7, 0.04, 0.7), "trim_dark", m, 0.01, 1, (x, -0.15, zw))
            for k in range(3):
                g.rbox((0.04, 0.04, 0.7), "metal", m, 0.01, 1, (x - 0.2 + k * 0.2, -0.17, zw))
            g.rbox((0.78, 0.16, 0.78), "wall_a~4", m, 0.04, c.seg(), (x + 0.92, -0.16, zw))
    g.rbox((w + 0.2, d + 0.2, 0.3), "wall_a~3", None, 0.04, c.seg(), (0, 0, zb + H - 0.15))  # plaster cornice
    dx = w * 0.18  # the heavy stepped door, a little tile hood and stone steps
    m = K.face_matrix(0, 0, w, d, zb, "front")
    g.rbox((1.9, 0.3, 2.75), "wall_a~3", m, 0.04, c.seg(), (dx, -0.15, 1.375))
    g.rbox((1.55, 0.2, 2.45), "trim_dark", m, 0.03, 1, (dx, -0.32, 1.225))
    g.rbox((1.25, 0.1, 2.2), "door", m, 0.02, 1, (dx, -0.44, 1.1))
    for k in range(3):
        g.rbox((1.27, 0.04, 0.08), "metal", m, 0.01, 1, (dx, -0.5, 0.4 + k * 0.75))
    g.rbox((2.4, 1.0, 0.12), "roof_a", m @ T(dx, -0.6, 3.05) @ RX(-16), 0.03, 1)
    for k in range(3):
        g.rbox((1.8, 0.45, 0.27 * (3 - k)), "stone~3", None, 0.03, 1, (dx, -d / 2 - 0.45 - 0.42 * k, 0.135 * (3 - k)))

    def gable_fill(fm, L, rise):
        g.slab_poly([(-L / 2, 0), (L / 2, 0), (0, rise)], 0.28, "wall_a", fm @ T(0, 0.14, 0))
        g.cylinder(0.32, 0.06, "trim_dark", fm @ T(0, -0.03, rise * 0.42) @ RX(90), segs=16)  # house crest

    K.roof(c, T(0, 0, zb + H), w, d, "gable", 30, "barrel", "roof_a", None, 0.6, gable_fill)


def mill(c, p):
    s = c.s
    form = MILL_FORMS.get(s.family)
    if form:  # review B1: the family's own mill instead of the sail windmill
        return form(c, p)
    watery = s.family in ("fenland", "lagoon", "coastal", "hoshizora", "jungle", "elven", "shenlu", "haneul")
    if p.get("water", watery):
        info = block(c, 0, 0, 7.0, 6.0, 2, door_x=-1.0, ridge="x")
        zf = info["zf"]
        wheel(c, 3.9, 0.0, zf + 1.6, 2.6)
    else:
        info = round_block(c, 0, 0, 2.8, 3, "cone", floor_h=3.0)
        sails(c, 0, -3.1, info["top"] - 0.4)


def wheel(c, x, y, z, r):
    g = c.g
    m = T(x, y, z) @ RY(90)
    g.lathe([(r - 0.15, -0.3), (r, -0.3), (r, 0.3), (r - 0.15, 0.3), (r - 0.15, -0.3)], "trim", m, segs=32, cap_bottom=False, cap_top=False)
    g.cylinder(0.35, 0.9, "trim~1", m @ T(0, 0, -0.45), segs=12, bevel=0.05)
    for k in range(16):
        a = 360 * k / 16
        g.rbox((0.12, 0.6, 0.5), "wood_light", m @ RZ(a) @ T(r - 0.05, 0, 0), 0.03, 1)
        if k % 2 == 0:
            g.rbox((r * 2 - 0.2, 0.1, 0.1), "trim", m @ RZ(a), 0.02, 1)


def sails(c, x, y, z):
    g = c.g
    hub = T(x, y, z) @ RX(90)
    g.cylinder(0.3, 0.6, "trim", hub, segs=12, bevel=0.06)
    for k in range(4):
        m = T(x, y - 0.3, z) @ RY(45 + 90 * k)
        g.rbox((0.16, 0.12, 6.2), "trim", m @ T(0, 0, 3.2), 0.03, c.seg())
        for j in range(8):
            g.rbox((0.04, 0.04, 0.04), "trim", m @ T(0.6, 0, 1.0 + j * 0.7), 0.01, 1)
        g.rbox((1.1, 0.04, 5.0), "accent" if c.s.family != "storybook" else "wall_a", m @ T(0.62, 0.05, 3.6), 0.01, 1)


# Family mills (review B1). The sail windmill stays the default; these families build their own form instead, and
# MILL_DROPPED families leave the mill out of their catalogue.


def flume(c, x, y0, y1, z):
    """A wooden trough on posts, running along Y at height z, carrying water to the top of a wheel."""
    g = c.g
    L, yc = abs(y1 - y0), (y0 + y1) / 2
    g.rbox((0.8, L, 0.1), "trim", None, 0.02, c.seg(), (x, yc, z))
    for sx in (-1, 1):
        g.rbox((0.08, L, 0.4), "trim~3", None, 0.02, 1, (x + sx * 0.38, yc, z + 0.2))
    g.rbox((0.62, L, 0.04), "water", None, 0.01, 1, (x, yc, z + 0.12))
    n = max(2, int(L / 2.2) + 1)
    for k in range(n):
        y = min(y0, y1) + 0.4 + (L - 0.8) * k / (n - 1)
        for sx in (-1, 1):
            g.rbox((0.16, 0.16, z), "trim", None, 0.03, 1, (x + sx * 0.36, y, z / 2))


def wind_catcher(c, p):
    """Desert and garden mill: a low flat-roofed mill house beside a wind-catcher tower slotted at the top."""
    g, s = c.g, c.s
    w, d = p.get("width", 7.0), p.get("depth", 5.5)
    info = block(c, 0, 0, w, d, 1, "x", "flat", door_x=-1.2, wide_door=True, chimney="none", ground_h=3.4)
    tx, ty, ts = w / 2 + 1.5, 0.6, 3.0
    tw = block(c, tx, ty, ts, ts, 3, "x", "flat", door_x=None, chimney="none", jetty=0.0, floor_h=3.0, windows=False,
               decorate=False)
    key = c.wall_key if s.walls in ("adobe", "plaster") else "stone"
    z0, hh = tw["top"] + 0.3, 2.4
    g.rbox((ts - 0.5, ts - 0.5, hh), "trim_dark", None, 0.02, 1, (tx, ty, z0 + hh / 2))  # the shaft inside the slots
    for face in ("front", "right", "back", "left"):
        m = K.face_matrix(tx, ty, ts, ts, z0, face)
        n = 6
        for k in range(n + 1):  # vertical fins between the wind slots
            g.rbox((0.2, 0.42, hh), key, m, 0.04, c.seg(), (-ts / 2 + 0.1 + (ts - 0.2) * k / n, 0.21, hh / 2))
        if s.family == "garden":  # turquoise tile band under the cap
            g.rbox((ts + 0.08, 0.06, 0.28), "accent", m, 0.02, 1, (0, -0.02, hh + 0.05))
    g.rbox((ts + 0.3, ts + 0.3, 0.4), key, None, 0.08, c.seg(), (tx, ty, z0 + hh + 0.4))
    g.rbox((ts - 0.3, ts - 0.3, 0.3), key + "~3" if "~" not in key else key, None, 0.08, c.seg(), (tx, ty, z0 + hh + 0.75))
    if s.has("vigas"):  # wooden tie beams through the vent head
        for k in range(3):
            g.cylinder(0.07, ts + 0.8, "trim", T(tx - ts / 2 - 0.4, ty - 0.8 + k * 0.8, z0 + 0.4) @ RY(90), segs=8)
    # a millstone leaning by the door and grain sacks
    zf = info["zf"]
    g.cylinder(0.75, 0.25, "stone~3", T(-w / 2 + 0.6, -d / 2 - 0.5, zf + 0.75) @ RX(90) @ RY(8), segs=20, bevel=0.04)
    g.cylinder(0.14, 0.27, "stone~1", T(-w / 2 + 0.6, -d / 2 - 0.5, zf + 0.75) @ RX(90) @ RY(8), segs=10)
    for k, (x, y) in enumerate(((0.8, -d / 2 - 0.6), (1.4, -d / 2 - 0.5), (1.1, -d / 2 - 0.55))):
        g.sphere(0.32, "cloth_b~3", T(x, y, zf + 0.28 + (0.45 if k == 2 else 0.0)), segs=10, rings=6, squash=0.8)


def watermill(c, p):
    """Nordic mill: a two-storey mill house with an overshot wheel fed by a flume."""
    info = block(c, 0, 0, 7.0, 6.0, 2, door_x=-1.0, ridge="x")
    zf = info["zf"]
    wheel(c, -3.9, 0.0, zf + 1.6, 2.6)  # on the west gable, where the library camera sees it
    flume(c, -3.9, 0.2, 7.0, zf + 1.6 + 2.6 + 0.25)


def water_forge(c, p):
    """Dwarven mill: a basalt forge hall whose water wheel drives a trip hammer; a forge chimney and a glowing hearth."""
    g = c.g
    w, d = p.get("width", 8.0), p.get("depth", 6.5)
    info = block(c, 0, 0, w, d, 2, door_x=-1.4, wide_door=True, chimney="none")
    zf, top = info["zf"], info["top"]
    wheel(c, -w / 2 - 0.5, 0.0, zf + 1.8, 2.6)  # on the west gable, where the library camera sees it
    flume(c, -w / 2 - 0.5, 0.2, 7.2, zf + 1.8 + 2.6 + 0.25)
    g.cylinder(0.18, 1.2, "metal", T(-w / 2 - 0.7, 0, zf + 1.8) @ RY(90), segs=10)  # axle into the hall
    K.chimney(c, w / 2 - 1.4, d / 2 - 1.2, top - 0.5, top + info["rise"], "forge")
    m = K.face_matrix(0, 0, w, d, zf, "front")  # the hearth mouth glowing through the front wall
    g.rbox((1.9, 0.3, 1.5), "stone~1", m, 0.05, c.seg(), (1.8, -0.15, 0.95))
    g.rbox((1.3, 0.1, 0.8), "ember", m, 0.02, 1, (1.8, -0.32, 0.9))
    for k in range(4):
        g.rbox((0.05, 0.05, 0.8), "metal", m, 0.01, 1, (1.35 + k * 0.3, -0.4, 0.9))
    g.rbox((0.55, 0.45, 0.55), "stone_dark", None, 0.04, 1, (w / 2 - 0.9, -d / 2 - 1.0, zf + 0.28))  # anvil block
    g.lathe([(0.0, 0.0), (0.22, 0.0), (0.22, 0.25), (0.45, 0.32), (0.5, 0.45), (0.0, 0.45)], "metal",
            T(w / 2 - 0.9, -d / 2 - 1.0, zf + 0.55) @ RZ(90) @ Matrix.Diagonal((1.5, 0.6, 1, 1)), segs=8)


MILL_FORMS = {"desert": wind_catcher, "garden": wind_catcher, "nordic": watermill, "dwarven": water_forge}
# Families where no mill form fits: their catalogue leaves the mill out (a direct build still gives the windmill).
MILL_DROPPED = ("clockwork", "gothic")


# ================================================================================================================
# Civic, learning and faith


def guild_hall(c, p):
    w, d = p.get("width", 14.0), p.get("depth", 10.0)
    c.notes.append("own_banners")
    info = block(c, 0, 0, w, d, p.get("floors", 2), door_x=0.0, wide_door=True)
    t = tower(c, 0, d / 2 + 1.6, 4.2, info["top"] / c.s.floor_h + 1.3, door=False, base=False, z0=info["zf"])
    if c.s.has("banners") or True:
        m = K.face_matrix(0, 0, w, d, info["zf"], "front")
        for x in (-w / 2 + 1.2, w / 2 - 1.2):
            K.banner(c, m, x, info["top"] - info["zf"] - 0.5, 2.6, 0.9)
    sign(c, 2.2, -d / 2, info["zf"], "star")


def town_hall(c, p):
    w, d = p.get("width", 13.0), p.get("depth", 9.0)
    info = block(c, 0, 0, w, d, p.get("floors", 2), door_x=0.0, wide_door=True, roof_form="hip" if c.s.roof in ("gable", "turf") else None)
    tw = 3.6
    t = tower(c, 0, -d / 2 - tw / 2 + 0.2, tw, 4, door=False, z0=0.0)
    clock(c, 0, -d / 2 - tw - 0.02 + 0.2, t["top"] - 1.6)


def clock(c, x, y, z):
    g = c.g
    m = T(x, y, z) @ RX(90)
    g.cylinder(0.85, 0.12, "stone~2", m, segs=32, bevel=0.03)
    g.cylinder(0.7, 0.14, "wall_a", m, segs=32)
    for k in range(12):
        g.box((0.05, 0.02, 0.15), "metal", T(x, y - 0.08, z) @ RY(30 * k) @ T(0, 0, 0.58))
    g.box((0.05, 0.02, 0.45), "metal", T(x, y - 0.1, z) @ RY(20) @ T(0, 0, 0.2))
    g.box((0.05, 0.02, 0.32), "metal", T(x, y - 0.1, z) @ RY(110) @ T(0, 0, 0.14))


def library(c, p):
    w, d = p.get("width", 10.5), p.get("depth", 9.0)
    info = block(c, 0, 0, w, d, p.get("floors", 2), ridge="y", door_x=0.0, wide_door=True)
    tower(c, w / 2 + 1.2, d / 2 - 1.6, 3.0, 3, round_=True, door=False)
    sign(c, 1.4, -d / 2, info["zf"], "book")


def bathhouse(c, p):
    w, d = p.get("width", 11.0), p.get("depth", 8.0)
    info = block(c, 0, 0, w, d, 1, door_x=0.0, wide_door=True, ground_h=3.6, chimney="none")
    for x in (-w / 2 + 1.5, w / 2 - 1.5):
        K.chimney(c, x, d / 4, info["top"] - 0.5, info["top"] + info["rise"], "stone" if c.s.chimney == "none" else c.s.chimney)
    if c.s.roof in ("gable", "hip", "curved"):  # a small cupola vent on the ridge
        tower(c, 0, 0, 1.6, 0.35, "pyramid" if c.s.roof != "curved" else "curved", floor_h=1.0, door=False, z0=info["top"] + info["rise"] - 0.8, base=False)


def temple(c, p):
    w, d = p.get("width", 9.0), p.get("depth", 15.0)
    info = block(c, 0, 0, w, d, 1, ridge="y", door_x=0.0, wide_door=True, ground_h=p.get("nave_h", 5.6), chimney="none")
    tower(c, 0, -d / 2 - 2.0, 4.0, 3.2, door=True)
    # a rose window over the door is part of the gable vent; add side buttresses for masonry styles
    if c.s.walls in ("ashlar", "rubble", "brick", "timber_frame"):
        for side in (-1, 1):
            for k in range(3):
                y = -d / 2 + 3 + k * 4.5
                c.g.rbox((0.8, 0.7, 3.4), "stone~3", None, 0.06, c.seg(), (side * (w / 2 + 0.35), y, info["zf"] + 1.7))


def shrine(c, p):
    g = c.g
    s = c.s
    w = p.get("width", 3.2)
    z = K.footing(c, 0, 0, w, w, 0.0, 0.0) if s.base != "stilts" else 0.4
    for sx in (-1, 1):
        for sy in (-1, 1):
            g.cylinder(0.14, 2.4, "trim", T(sx * (w / 2 - 0.2), sy * (w / 2 - 0.2), z), segs=12, bevel=0.03)
    g.rbox((w - 0.6, w * 0.4, 1.1), "stone~2", None, 0.05, c.seg(), (0, w * 0.1, z + 0.55))
    g.rbox((0.6, 0.4, 0.8), "stone", None, 0.05, c.seg(), (0, w * 0.1, z + 1.5))
    g.sphere(0.2, "glow", T(0, w * 0.1, z + 2.05), segs=10, rings=6)
    K.roof(c, T(0, 0, z + 2.4), w + 0.4, w + 0.4, "hip" if s.roof in ("gable", "flat", "turf") else s.roof, pitch=max(30, s.pitch - 10), overhang=0.4)
    for side in (-1, 1):
        K.wall_lantern(c, T(side * (w / 2 + 0.25), -w / 2 - 0.2, z), 0, 1.6)


# ================================================================================================================
# Defence


def watchtower(c, p):
    size = p.get("width", 4.6)
    floors = p.get("floors", 3)
    info = tower(c, 0, 0, size, floors, roof_form="none_", door=True)
    return info


def lookout(c, cx, cy, size, z):
    g = c.g
    g.rbox((size + 1.2, size + 1.2, 0.24), "trim", None, 0.04, c.seg(), (cx, cy, z))
    for sx in (-1, 1):
        for sy in (-1, 1):
            g.rbox((0.22, 0.22, 2.4), "trim", None, 0.04, c.seg(), (cx + sx * (size / 2 + 0.45), cy + sy * (size / 2 + 0.45), z + 1.2))
    for face in ("front", "right", "back", "left"):
        m = K.face_matrix(cx, cy, size + 0.9, size + 0.9, z, face)
        g.rbox((size + 0.9, 0.1, 0.12), "trim", m, 0.02, 1, (0, 0, 1.0))
        for k in range(int(size / 0.5)):
            g.rbox((0.08, 0.06, 1.0), "trim~3", m, 0.01, 1, (-size / 2 + k * 0.5, 0.02, 0.5))
    K.roof(c, T(cx, cy, z + 2.4), size + 1.0, size + 1.0, "pyramid" if c.s.roof != "curved" else "curved", pitch=40, overhang=0.4,
           cover=c.s.cover if c.s.cover not in ("turf", "plaster", "glaze", "slab") else "shingle")


def watchtower_full(c, p):
    size = p.get("width", 4.4)
    floors = p.get("floors", 3)
    if c.s.has("banners"):
        c.notes.append("own_banners")
    info = block(c, 0, 0, size, size, floors, "x", "flat", door_x=0.0, jetty=0.0, chimney="none")
    lookout(c, 0, 0, size, info["top"] + 0.3)
    if c.s.has("banners"):
        K.banner(c, K.face_matrix(0, 0, size, size, info["zf"], "front"), 0.0, info["top"] - info["zf"] - 0.4, 2.2, 0.8)


def gatehouse(c, p):
    if c.s.has("banners"):
        c.notes.append("own_banners")  # the gate hangs its own banner: no facade_banners on the towers under it
    span = p.get("width", 4.5)
    tw = 4.2
    floors = p.get("floors", 3)
    for side in (-1, 1):
        tr = {"cone": "pyramid", "pyramid": "pyramid", "spire": "spire", "curved": "curved"}.get(c.s.tower_roof, "flat")
        if c.s.roof == "flat" or c.s.parapet:
            tr = "flat"
        info = block(c, side * (span / 2 + tw / 2), 0, tw, tw, floors, "x", tr,
                     door_x=None, jetty=0.0, chimney="none", face_windows=("front", "back"), overhang=0.35,
                     cover=c.s.cover if c.s.cover not in ("turf", "plaster", "glaze", "slab", "canvas") else "shingle")
    z = info["top"]
    zf = info["zf"]
    g = c.g
    # the arch and walkway between the towers
    m = T(0, -tw / 2, zf)
    H = z - zf
    arch = K.Op(0, 0.0, span, 3.8 + span / 2, "arch", True, "plank")
    for face_y, rot in ((-tw / 2, 0), (tw / 2, 180)):
        mm = T(0, face_y, zf) @ RZ(rot)
        K.build_wall(c, mm, span + 0.02, H - 0.2, [arch], c.s.walls if c.s.walls not in ("post_panel", "living", "stalk") else "plaster", c.wall_key)
        K.frame_along(c, mm, arch.outline(), 0.3, 0.4, "stone~2", -0.1)
    g.rbox((span + 0.1, tw, 0.4), "stone~3", None, 0.04, c.seg(), (0, 0, z - 0.4))
    # portcullis teeth
    for k in range(int(span / 0.35)):
        g.rbox((0.08, 0.08, 1.2), "metal", None, 0.02, 1, (-span / 2 + 0.2 + k * 0.35, -tw / 2 + 0.25, zf + arch.h - 0.6))
    if c.s.has("banners"):
        for side in (-1, 1):
            K.banner(c, T(side * (span / 2 + tw / 2), -tw / 2, zf), 0, H - 0.6, 2.4, 1.0)


def wall_segment(c, p):
    L = p.get("width", 10.0)
    H = p.get("height", 4.5)
    s, g = c.s, c.g
    if s.walls in ("log", "board", "living", "clapboard") or s.family in ("fenland", "steppe", "coastal", "nordic"):
        n = int(L / 0.42)
        for k in range(n):  # a palisade of sharpened logs with a walkway behind
            x = -L / 2 + (k + 0.5) * L / n
            h = H + c.rng.uniform(-0.3, 0.3)
            g.lathe([(0.2, 0.0), (0.21, h - 0.6), (0.0, h)], "trim%s" % c.rng.choice(["", "~3", "~4"]), T(x, 0, 0), segs=8)
        g.rbox((L, 0.2, 0.25), "trim~1", None, 0.04, 1, (0, 0.25, H * 0.35))
        g.rbox((L, 1.3, 0.16), "wood_light", None, 0.03, c.seg(), (0, 1.0, H - 1.3))
        for k in range(int(L / 2.5) + 1):
            g.rbox((0.18, 0.18, H - 1.2), "trim", None, 0.03, 1, (-L / 2 + k * L / int(L / 2.5), 1.55, (H - 1.2) / 2))
        return
    if s.family == "desert":
        return adobe_wall(c, L, H)
    if s.family == "garden":
        return banded_brick_wall(c, L, H)
    if s.family == "hoshizora":
        return plaster_wall(c, L, H)
    construction = s.walls if s.walls not in ("post_panel", "stalk", "timber_frame", "adobe", "plaster") else "rubble"
    if s.walls == "adobe":
        construction = "adobe"
    for face_y, rot in ((-0.6, 0), (0.6, 180)):
        K.build_wall(c, T(0, face_y, 0) @ RZ(rot), L, H, [], construction, c.wall_key if construction == "adobe" else "stone")
    g.rbox((L, 1.2, 0.2), "stone~3" if construction != "adobe" else c.wall_key, None, 0.04, c.seg(), (0, 0, H))
    for k in range(int(L / 0.9)):
        if k % 2 == 0:
            g.rbox((0.6, 0.4, 0.6), "stone~2" if construction != "adobe" else c.wall_key, None, 0.04, c.seg(), (-L / 2 + 0.45 + k * 0.9, -0.4, H + 0.4))


def adobe_wall(c, L, H):
    """Sunscar: a battered mud-brick wall with rounded merlons, viga ends, round end buttresses and drain spouts."""
    g, key = c.g, c.wall_key
    tb, tt = 1.7, 0.95
    g.slab_poly([(-tb / 2, 0), (tb / 2, 0), (tt / 2, H), (-tt / 2, H)], L, key, RZ(90))  # tapering section
    g.rbox((L, tt + 0.16, 0.22), key + "~4", None, 0.08, c.seg(), (0, 0, H + 0.11))
    n = int(L / 1.1)
    for k in range(n):  # rounded merlons along the outer edge
        g.rbox((0.62, 0.4, 0.75), key, None, 0.2, c.seg(), (-L / 2 + 0.75 + k * (L - 1.5) / max(1, n - 1), -tt / 2 + 0.2, H + 0.55))
    zv = H - 0.75
    yv = -(tt / 2 + (tb - tt) / 2 * (0.75 / H))
    for k in range(int(L / 1.4)):  # viga ends and a few clay drain spouts
        x = -L / 2 + 1.0 + k * 1.4
        g.cylinder(0.08, 0.5, "trim", T(x, yv + 0.1, zv) @ RX(90), segs=8)
        if k % 3 == 1:
            g.cylinder(0.09, 0.6, "accent", T(x + 0.7, yv + 0.1, H - 0.1) @ RX(100), segs=8)
    for sx in (-1, 1):  # round buttress towers at the ends
        g.cylinder(1.05, H + 0.9, key + "~3", T(sx * L / 2, 0, 0), segs=24, r_top=0.85, bevel=0.1)
        g.sphere(0.85, key + "~3", T(sx * L / 2, 0, H + 0.9), segs=20, rings=8, squash=0.35)


def plaster_wall(c, L, H):
    """Hoshizora: a white plaster wall (#F2EDE0) on a 0.8 m stone base, under a small tiled coping roof (#3D4757)."""
    g = c.g
    zb, t = 0.8, 0.56
    for face_y, rot in ((-0.42, 0), (0.42, 180)):  # dressed stone base, both faces
        K.build_wall(c, T(0, face_y, 0) @ RZ(rot), L, zb, [], "ashlar", "stone")
    g.rbox((L, 0.84, zb - 0.04), "stone~3", None, 0.03, 1, (0, 0, (zb - 0.04) / 2))
    g.rbox((L + 0.04, 0.9, 0.08), "stone~2", None, 0.03, 1, (0, 0, zb))
    g.rbox((L, t, H - zb), "wall_a", None, 0.04, c.seg(), (0, 0, zb + (H - zb) / 2))  # white plaster body
    for face_y in (-t / 2, t / 2):  # a dark timber rail under the coping
        g.rbox((L + 0.02, 0.06, 0.2), "trim_dark", None, 0.02, 1, (0, face_y + (0.02 if face_y > 0 else -0.02), H - 0.24))
    for k in range(int(L / 2.5) + 1):  # thin plaster pilasters every 2.5 m
        x = -L / 2 + 0.2 + k * (L - 0.4) / max(1, int(L / 2.5))
        g.rbox((0.22, t + 0.08, H - zb - 0.3), "wall_a~3", None, 0.03, 1, (x, 0, zb + (H - zb - 0.3) / 2))

    def gable_fill(fm, D, rise):
        g.slab_poly([(-D / 2, 0), (D / 2, 0), (0, rise)], 0.12, "wall_a", fm @ T(0, 0.06, 0))

    K.roof(c, T(0, 0, H), L, t, "gable", 30, "barrel", "roof_a", "tile", 0.32, gable_fill)


def banded_brick_wall(c, L, H):
    """Zarvan: an ochre brick wall with turquoise tile bands and stepped, turquoise-capped merlons."""
    g = c.g
    for face_y, rot in ((-0.6, 0), (0.6, 180)):
        K.build_wall(c, T(0, face_y, 0) @ RZ(rot), L, H, [], "brick", "stone")
        m = T(0, face_y, 0) @ RZ(rot)
        for zb in (H * 0.5, H - 0.4):  # glazed tile bands with a diamond pattern
            g.rbox((L, 0.06, 0.32), "accent", m, 0.02, 1, (0, -0.03, zb))
            if c.hi:
                for k in range(int(L / 0.32)):
                    g.rbox((0.17, 0.03, 0.17), "accent_b" if k % 2 else "roof_b", m @ T(-L / 2 + 0.16 + k * 0.32, -0.07, zb) @ RY(45), 0.01, 1)
    g.rbox((L, 1.3, 0.2), "stone~3", None, 0.04, c.seg(), (0, 0, H))
    for k in range(int(L / 0.9)):
        if k % 2 == 0:
            x = -L / 2 + 0.45 + k * 0.9
            g.rbox((0.6, 0.4, 0.5), "stone~2", None, 0.04, c.seg(), (x, -0.4, H + 0.35))
            g.lathe([(0.0, 0.0), (0.36, 0.0), (0.0, 0.4)], "accent", T(x, -0.4, H + 0.6), segs=4, phase=math.pi / 4)


def barracks(c, p):
    w, d = p.get("width", 11.0), p.get("depth", 7.0)
    c.notes.append("own_banners")
    info = block(c, 0, 0, w, d, 2, door_x=0.0, wide_door=True)
    rack(c, w / 2 + 0.8, -d / 2 + 1.0, 0.0)
    if True:
        m = K.face_matrix(0, 0, w, d, info["zf"], "front")
        K.banner(c, m, -w / 2 + 1.0, info["top"] - info["zf"] - 0.4, 2.2, 0.8)


def rack(c, x, y, z):
    g = c.g
    for sx in (-0.8, 0.8):
        g.rbox((0.12, 0.12, 1.7), "trim", None, 0.02, 1, (x + sx, y, z + 0.85))
    g.rbox((1.8, 0.12, 0.12), "trim", None, 0.02, 1, (x, y, z + 1.5))
    for k in range(5):
        g.rbox((0.04, 0.04, 1.6), "metal~2", T(x - 0.6 + k * 0.3, y - 0.12, z + 0.85) @ RX(12), 0.01, 1)


# ================================================================================================================
# Infrastructure


def well(c, p):
    g = c.g
    r = p.get("radius", 1.0)
    round_block(c, 0, 0, r, 1, None, floor_h=0.85, door=False, windows=False,
                wall=c.s.walls if c.s.walls in ("ashlar", "rubble", "brick", "fitted") else "rubble")
    g.cylinder(r - 0.1, 0.05, "water", T(0, 0, 0.6), segs=24)
    for sx in (-1, 1):
        g.rbox((0.16, 0.16, 2.3), "trim", None, 0.03, c.seg(), (sx * (r + 0.05), 0, 1.15))
    g.cylinder(0.08, 2.3, "trim", T(-r - 0.1, 0, 1.9) @ RY(90), segs=10)
    g.lathe([(0.0, 0.0), (0.2, 0.0), (0.24, 0.3), (0.0, 0.3)], "wood_light", T(0, 0, 1.1), segs=12)
    g.cylinder(0.01, 0.75, "trim", T(0, 0, 1.4), segs=4)
    K.roof(c, T(0, 0, 2.3), 2 * r + 0.4, 1.4, "gable", pitch=40, overhang=0.25)


def bridge(c, p):
    g = c.g
    L = p.get("width", 9.0)
    W = p.get("depth", 3.2)
    s = c.s
    if s.walls in ("log", "board", "clapboard", "living") or s.family in ("fenland", "coastal", "nordic", "steppe"):
        for k in range(int(L / 0.3)):
            x = -L / 2 + 0.15 + k * 0.3
            z = 1.2 + 0.5 * math.cos(math.pi * x / L)
            g.inst("plank_a|wood_light%s" % c.rng.choice(["", "~3", "~4"]), T(x, -W / 2, z) @ RX(-90) @ Matrix.Diagonal((1.4, 1, W, 1)))
        for x in (-L / 2 + 0.5, 0, L / 2 - 0.5):
            for y in (-W / 2, W / 2):
                g.cylinder(0.15, 2.4, "trim", T(x, y, -0.6), segs=10, bevel=0.03)
        return
    rise = 1.6
    span = L * 0.55
    prof = [(-L / 2, 0)]
    for k in range(13):
        a = math.pi * k / 12
        prof.append((-span / 2 + span * k / 12, 0.0 if k in (0, 12) else rise * math.sin(a) - 0.0))
    poly = [(-L / 2, -0.1), (-span / 2, -0.1)] + [(span / 2 * math.cos(math.pi - math.pi * k / 12), rise * math.sin(math.pi * k / 12)) for k in range(13)]
    poly += [(span / 2, -0.1), (L / 2, -0.1), (L / 2, 1.2), (span / 2, rise + 0.6), (0, rise + 0.8), (-span / 2, rise + 0.6), (-L / 2, 1.2)]
    # deck profile (outer), then the arch cut-out drawn as a separate spandrel fill
    outer = [(-L / 2, -0.1), (L / 2, -0.1), (L / 2, 1.2), (span / 2, rise + 0.6), (0, rise + 0.8), (-span / 2, rise + 0.6), (-L / 2, 1.2)]
    arch = [(span / 2 * math.cos(math.pi * k / 12), rise * math.sin(math.pi * k / 12)) for k in range(13)]
    for side in (-1, 1):
        y = side * (W / 2 - 0.3)
        left = [(-L / 2, -0.1), (-span / 2, -0.1)] + list(reversed(arch))[1:] + [(0, rise + 0.8), (-span / 2, rise + 0.6), (-L / 2, 1.2)]
        right = [(0, rise), (0, rise + 0.8)][::-1]
        g.slab_poly([(-L / 2, -0.1), (-span / 2, -0.1)] + [(span / 2 * math.cos(math.pi - math.pi * k / 24), rise * math.sin(math.pi * k / 24)) for k in range(1, 13)] + [(0, rise + 0.8), (-span / 2, rise + 0.6), (-L / 2, 1.2)],
                    0.6, "stone%s" % ("" if side < 0 else "~3"), T(0, y, 0))
        g.slab_poly([(0, rise)] + [(span / 2 * math.cos(math.pi / 2 - math.pi / 2 * k / 12), rise * math.sin(math.pi / 2 - math.pi / 2 * k / 12)) for k in range(1, 13)]
                    + [(span / 2, -0.1), (L / 2, -0.1), (L / 2, 1.2), (span / 2, rise + 0.6), (0, rise + 0.8)],
                    0.6, "stone%s" % ("~3" if side < 0 else ""), T(0, y, 0))
    # deck and parapets
    zt = lambda x: 1.2 + (rise + 0.8 - 1.2) * (1 - (abs(x) / (L / 2)) ** 1.6)
    for k in range(24):  # deck and parapet segments, each tilted to follow the hump
        x0 = -L / 2 + L * k / 24
        x1 = x0 + L / 24
        z0, z1 = zt(x0), zt(x1)
        ang = math.degrees(math.atan2(z1 - z0, x1 - x0))
        ln = math.hypot(x1 - x0, z1 - z0) + 0.02
        mid = T((x0 + x1) / 2, 0, (z0 + z1) / 2) @ RY(-ang)
        g.rbox((ln, W - 0.4, 0.2), "stone~2", mid, 0.03, 1)
        for side in (-1, 1):
            g.rbox((ln, 0.35, 0.6), "stone", mid @ T(0, side * (W / 2 - 0.18), 0.4), 0.04, 1)


def fountain(c, p):
    form = FOUNTAIN_FORMS.get(c.s.family)
    if form:  # review B1: Hoshizora's stone water basin, the nordic well-house; the tiered fountain stays the default
        return form(c, p)
    g = c.g
    r = p.get("radius", 2.4)
    # review B1: the basin in the family's masonry; adobe families use their wall plaster (other families keep stone)
    basin, column = ("stone~2", "stone") if c.s.walls != "adobe" else (c.wall_key + "~4", c.wall_key)
    g.lathe([(0.0, 0.0), (r, 0.0), (r + 0.1, 0.1), (r + 0.1, 0.6), (r - 0.25, 0.65), (r - 0.25, 0.4), (0.0, 0.4)], basin, T(0, 0, 0), segs=40)
    if c.s.family == "garden":  # a turquoise tile rim
        g.lathe([(r + 0.12, 0.0), (r + 0.16, 0.0), (r + 0.16, 0.18), (r - 0.27, 0.18), (r - 0.27, 0.0)], "accent", T(0, 0, 0.56), segs=40,
                cap_bottom=False, cap_top=False)
    g.cylinder(r - 0.25, 0.05, "water", T(0, 0, 0.5), segs=40)
    g.lathe([(0.35, 0.0), (0.25, 0.8), (0.3, 1.2), (1.0, 1.35), (1.05, 1.55), (0.85, 1.55), (0.2, 1.45), (0.15, 2.2), (0.3, 2.4), (0.0, 2.6)], column, T(0, 0, 0.4), segs=28)
    g.cylinder(0.85, 0.04, "water", T(0, 0, 1.92), segs=28)
    finial_like = c.s.family in ("garden", "celestial", "desert")
    g.sphere(0.25, "gold" if finial_like else "glow", T(0, 0, 3.15), segs=12, rings=8)


def stone_basin(c, p):
    """Hoshizora: a low carved stone water basin fed by a wooden spout on a post, with a ladle and river stones."""
    g = c.g
    bw, bd, bh, t = 2.6, 1.5, 0.62, 0.22
    g.rbox((bw, bd, 0.2), "stone~3", None, 0.05, 1, (0, 0, 0.1))
    for sy in (-1, 1):
        g.rbox((bw, t, bh), "stone~2", None, 0.07, c.seg(), (0, sy * (bd - t) / 2, bh / 2))
    for sx in (-1, 1):
        g.rbox((t, bd - 2 * t + 0.02, bh), "stone~2", None, 0.07, c.seg(), (sx * (bw - t) / 2, 0, bh / 2))
    g.box((bw - 2 * t + 0.02, bd - 2 * t + 0.02, 0.04), "water", None, (0, 0, bh - 0.12))
    px, py = bw / 2 - 0.55, bd / 2 + 0.2  # the spout post behind the basin
    g.rbox((0.3, 0.3, 0.25), "stone~1", None, 0.04, 1, (px, py, 0.125))
    g.rbox((0.18, 0.18, 1.45), "trim", None, 0.03, c.seg(), (px, py, 0.25 + 0.725))
    g.rbox((0.24, 0.24, 0.06), "trim_dark", None, 0.02, 1, (px, py, 1.72))
    g.cylinder(0.06, 1.0, "wood_light", T(px, py + 0.05, 1.3) @ RX(98), segs=10)  # the wooden spout
    for k in range(3):
        t = 0.15 + k * 0.3  # binding collars along the spout
        g.cylinder(0.068, 0.04, "trim", T(px, py + 0.05 - 0.99 * t, 1.3 - 0.14 * t) @ RX(98), segs=10)
    ys = py + 0.05 - 0.98
    g.cylinder(0.03, 1.3 - 0.13 - (bh - 0.12), "water", T(px, ys, bh - 0.1), segs=8)  # the falling stream
    g.cylinder(0.12, 0.03, "water~2", T(px, ys, bh - 0.1), segs=12)
    # a bamboo-handled ladle across the rim
    g.cylinder(0.025, 0.9, "wood_light", T(-0.5, -bd / 2 + t / 2, bh + 0.03) @ RY(90) @ RX(0), segs=6)
    g.cylinder(0.09, 0.09, "wood_light~1", T(0.45, -bd / 2 + t / 2, bh - 0.02), segs=10)
    for x, y, r_ in ((-bw / 2 - 0.35, -0.3, 0.3), (-bw / 2 - 0.2, 0.45, 0.22), (bw / 2 + 0.3, -0.4, 0.26), (0.2, -bd / 2 - 0.55, 0.42)):
        g.sphere(r_, "stone~3", T(x, y, 0.0), segs=12, rings=6, squash=0.45)


def well_house(c, p):
    """Nordic (Frostveil, Whitewater Reach): a covered well-house, a log crib under a turf roof on two posts, with a
    windlass and bucket."""
    g, s = c.g, c.s
    hs, logr = 0.9, 0.13
    for j in range(5):  # the log crib, courses alternating along x and y
        z = logr + j * 0.2
        key = c.wall_key + ("~3" if j % 2 else "")
        for sgn in (-1, 1):
            if j % 2 == 0:
                g.cylinder(logr, 2 * hs + 0.5, key, T(-hs - 0.25, sgn * hs, z) @ RY(90), segs=10, bevel=0.03)
            else:
                g.cylinder(logr, 2 * hs + 0.5, key, T(sgn * hs, -hs - 0.25, z) @ RX(-90), segs=10, bevel=0.03)
    g.box((2 * hs, 2 * hs, 0.04), "water", None, (0, 0, 0.62))
    PX, PH = hs + 0.45, 2.35
    for sx in (-1, 1):  # two posts with top plates carrying the eaves, and braces
        g.rbox((0.22, 0.22, PH), "trim", None, 0.03, c.seg(), (sx * PX, 0, PH / 2))
        g.rbox((0.22, 2.3, 0.22), "trim", None, 0.03, 1, (sx * PX, 0, PH - 0.11))
        for sy in (-1, 1):
            g.rbox((0.12, 0.7, 0.12), "trim~3", T(sx * PX, sy * 0.38, PH - 0.42) @ RX(sy * 45), 0.02, 1)
    g.cylinder(0.12, 2 * PX, "wood_light", T(-PX, 0, 1.45) @ RY(90), segs=12)  # windlass
    g.rbox((0.08, 0.08, 0.45), "metal", None, 0.02, 1, (PX + 0.15, 0, 1.25))
    g.rbox((0.3, 0.08, 0.08), "metal", None, 0.02, 1, (PX + 0.15, 0.1, 1.04))
    g.cylinder(0.015, 0.35, "trim_dark", T(0, -0.12, 1.08), segs=4)
    g.lathe([(0.0, 0.0), (0.18, 0.0), (0.22, 0.32), (0.0, 0.32)], "wood_light~1", T(0, -0.12, 0.76), segs=12)
    g.cylinder(0.225, 0.04, "metal", T(0, -0.12, 0.98), segs=12)

    def gable_fill(fm, D, rise):
        g.slab_poly([(-D / 2, 0), (D / 2, 0), (0, rise)], 0.1, c.wall_key + "~3", fm @ T(0, 0.05, 0))

    K.roof(c, T(0, 0, PH), 2 * PX + 0.3, 2.3, "gable", 40, "turf", "roof_a", "board", 0.3, gable_fill)


FOUNTAIN_FORMS = {"hoshizora": stone_basin, "nordic": well_house}
GRANARY_FORMS = {"desert": beehive_granary, "dwarven": basalt_silo}


def lamp_post(c, p):
    form = LAMP_FORMS.get(c.s.family)
    if form:  # review B1: the family's own street lamp; the iron lamp below stays the default
        return form(c, p)
    g = c.g
    g.lathe([(0.18, 0.0), (0.14, 0.3), (0.07, 0.4), (0.06, 3.0), (0.09, 3.1), (0.0, 3.15)], "metal", T(0, 0, 0), segs=10)
    g.rbox((0.06, 0.6, 0.06), "metal", None, 0.015, 1, (0, -0.28, 3.0))
    K.wall_lantern(c, T(0, 0.0, 0.0), 0.0, 2.55)


def paper_lamp_post(c, p):
    """Hoshizora, Shen-Lu, Haneul: a round paper lantern hung from the arm of a wooden post on a stone foot."""
    g = c.g
    g.rbox((0.34, 0.34, 0.45), "stone~3", None, 0.05, c.seg(), (0, 0, 0.225))
    g.rbox((0.17, 0.17, 3.0), "trim", None, 0.03, c.seg(), (0, 0, 1.95))
    g.rbox((0.32, 0.32, 0.08), "trim_dark", None, 0.02, 1, (0, 0, 3.49))
    g.rbox((0.12, 1.0, 0.13), "trim", None, 0.03, 1, (0, -0.42, 3.05))
    g.rbox((0.08, 0.5, 0.08), "trim", T(0, -0.2, 2.75) @ RX(45), 0.02, 1)  # brace
    x, y, z = 0, -0.8, 2.3
    g.cylinder(0.012, 0.42, "trim_dark", T(x, y, z + 0.6), segs=4)
    g.lathe([(0.0, -0.36), (0.15, -0.34), (0.26, -0.2), (0.29, 0.0), (0.26, 0.2), (0.15, 0.34), (0.0, 0.36)], "lamp",
            T(x, y, z + 0.25), segs=16)
    for zz in (0.57, -0.15):
        g.cylinder(0.15, 0.08, "trim_dark", T(x, y, z + zz), segs=12, bevel=0.02)
    g.box((0.04, 0.04, 0.3), "accent", None, (x, y, z - 0.3))  # tassel


def gas_lamp_post(c, p):
    """Gearholm: a brass gas lamp, a collared post with a lamplighter's bar under a six-sided glowing lantern."""
    g = c.g
    g.lathe([(0.28, 0.0), (0.28, 0.14), (0.2, 0.22), (0.17, 0.7), (0.22, 0.8), (0.09, 0.95), (0.07, 3.0), (0.12, 3.08),
             (0.12, 3.16), (0.0, 3.16)], "metal", T(0, 0, 0), segs=12)
    for z in (1.4, 2.4):
        g.cylinder(0.1, 0.08, "metal~1", T(0, 0, z), segs=12, bevel=0.02)
    g.rbox((0.8, 0.06, 0.06), "metal", None, 0.015, 1, (0, 0, 2.78))  # lamplighter's ladder bar
    z = 3.18
    g.lathe([(0.0, 0.0), (0.13, 0.0), (0.22, 0.55), (0.0, 0.55)], "lamp", T(0, 0, z), segs=6)
    tilt = math.degrees(math.atan2(0.09, 0.55))
    for k in range(6):
        g.rbox((0.04, 0.04, 0.58), "metal", T(0, 0, z) @ RZ(60 * k) @ T(0.18, 0, 0.275) @ RY(tilt), 0.01, 1)
    g.lathe([(0.0, 0.0), (0.32, 0.0), (0.3, 0.05), (0.12, 0.24), (0.05, 0.32), (0.0, 0.42)], "metal", T(0, 0, z + 0.55), segs=6)
    g.sphere(0.06, "metal~2", T(0, 0, z + 1.0), segs=8, rings=5)


def coal_basket_post(c, p):
    """Iron Hold: an iron basket of glowing forge-coal on a bronze-banded pole over a basalt block."""
    g = c.g
    g.rbox((0.55, 0.55, 0.45), "stone~1", None, 0.05, c.seg(), (0, 0, 0.225))
    g.cylinder(0.1, 2.6, "metal", T(0, 0, 0.45), segs=10)
    for z in (1.1, 2.3):
        g.cylinder(0.14, 0.12, "trim", T(0, 0, z), segs=12, bevel=0.02)
    z0 = 3.0
    g.cylinder(0.14, 0.08, "metal", T(0, 0, z0 - 0.05), segs=10)
    for k in range(8):  # the bars of the basket, flaring out
        g.rbox((0.045, 0.045, 0.6), "metal", T(0, 0, z0) @ RZ(45 * k) @ T(0.12, 0, 0) @ RY(35) @ T(0, 0, 0.3), 0.01, 1)
    g.lathe([(0.44, 0.0), (0.5, 0.0), (0.5, 0.07), (0.44, 0.07), (0.44, 0.0)], "metal", T(0, 0, z0 + 0.46), segs=20,
            cap_bottom=False, cap_top=False)
    g.sphere(0.4, "ember", T(0, 0, z0 + 0.38), segs=12, rings=6, squash=0.55)
    for x, y in ((0.18, 0.1), (-0.15, 0.16), (0.02, -0.2), (-0.2, -0.08)):
        g.sphere(0.11, "stone_dark", T(x, y, z0 + 0.5), segs=6, rings=4, squash=0.8)


def silk_lamp_post(c, p):
    """Umbravel: two warm silk lanterns hung from a black iron crook post."""
    g = c.g
    g.lathe([(0.2, 0.0), (0.16, 0.25), (0.07, 0.35), (0.06, 3.3), (0.0, 3.35)], "metal", T(0, 0, 0), segs=10)
    g.lathe([(0.0, 0.0), (0.06, 0.05), (0.0, 0.45)], "metal", T(0, 0, 3.3), segs=4)  # spike finial
    for rot in (0, 180):
        ornaments.silk_lantern(c, RZ(rot), 0.0, 2.65)
        g.rbox((0.04, 0.04, 0.4), "metal", RZ(rot) @ T(0, -0.18, 2.88) @ RX(-40), 0.01, 1)  # scroll brace


def fen_lamp_post(c, p):
    """Greymoor: a green fen lamp in an iron cage, hung from a crooked pole bound with rope over a mud foot."""
    g = c.g
    P = RY(4)
    g.cylinder(0.36, 0.14, "stone~1", T(0, 0, 0), segs=12, bevel=0.05)
    g.cylinder(0.11, 3.4, "trim", P, segs=8, r_top=0.08)
    for z in (0.9, 1.05):
        g.cylinder(0.125, 0.08, "trim~4", P @ T(0, 0, z), segs=8)
    g.rbox((0.09, 0.8, 0.09), "trim", P @ T(0, -0.32, 3.2), 0.02, 1)
    x, y, z = 3.2 * math.sin(math.radians(4)), -0.65, 2.7
    g.cylinder(0.012, 0.45, "metal", T(x, y, z + 0.3), segs=4)
    g.sphere(0.17, "lamp", T(x, y, z), segs=12, rings=8)
    for k in range(4):
        g.rbox((0.03, 0.03, 0.46), "metal", T(x, y, z) @ RZ(45 + 90 * k) @ T(0.2, 0, 0), 0.01, 1)
    g.lathe([(0.0, 0.0), (0.24, 0.0), (0.0, 0.16)], "metal", T(x, y, z + 0.22), segs=8)
    g.cylinder(0.16, 0.05, "metal", T(x, y, z - 0.25), segs=8)
    for a in (20, 140, 260):
        g.inst("tuft|leaf~3", T(0.32 * math.cos(math.radians(a)), 0.32 * math.sin(math.radians(a)), 0) @ RZ(a))


def brass_lantern_post(c, p):
    """Desert (Sunscar, Zaruma): a pierced-brass lantern (0.45 m) on a 2.4 m adobe pillar with a rounded cap."""
    g, key = c.g, c.wall_key
    g.rbox((0.72, 0.72, 0.3), key + "~3", None, 0.1, c.seg(), (0, 0, 0.15))
    g.rbox((0.48, 0.48, 2.0), key, None, 0.1, c.seg(), (0, 0, 1.25))
    g.rbox((0.56, 0.56, 0.12), key + "~4", None, 0.05, 1, (0, 0, 2.2))
    g.sphere(0.28, key, T(0, 0, 2.25), segs=16, rings=8, squash=0.55)  # the rounded cap, up to 2.4 m
    g.rbox((0.22, 0.06, 0.36), "trim_dark", None, 0.04, 1, (0, -0.24, 1.55))  # a small niche
    z = 2.38
    g.cylinder(0.15, 0.05, "gold~1", T(0, 0, z), segs=12, bevel=0.015)
    g.lathe([(0.0, 0.0), (0.1, 0.0), (0.15, 0.1), (0.15, 0.22), (0.1, 0.31), (0.0, 0.31)], "lamp", T(0, 0, z + 0.04), segs=12)
    for k in range(8):  # the pierced shell: brass ribs and bands with the glow between
        g.rbox((0.035, 0.035, 0.3), "gold~1", T(0, 0, z + 0.04) @ RZ(45 * k) @ T(0.155, 0, 0.155), 0.008, 1)
    for zz in (0.1, 0.24):
        g.lathe([(0.158, 0.0), (0.168, 0.0), (0.168, 0.03), (0.158, 0.03)], "gold~1", T(0, 0, z + zz), segs=16,
                cap_bottom=False, cap_top=False)
    g.lathe([(0.0, 0.0), (0.18, 0.0), (0.16, 0.05), (0.09, 0.1), (0.035, 0.14), (0.0, 0.16)], "gold~1", T(0, 0, z + 0.34), segs=12)
    g.sphere(0.035, "gold", T(0, 0, z + 0.52), segs=8, rings=5)
    g.cylinder(0.01, 0.04, "gold", T(0, 0, z + 0.48), segs=4)


def glazed_lantern_post(c, p):
    """Garden (Zarvan): a turquoise-glazed lantern on a slim ochre brick column, 2.6 m, with turquoise bands."""
    g = c.g
    g.rbox((0.56, 0.56, 0.35), "stone~3", None, 0.05, c.seg(), (0, 0, 0.175))
    g.cylinder(0.15, 1.95, "wall_a", T(0, 0, 0.35), segs=12)  # slim brick shaft
    if c.hi:
        for j in range(int(1.95 / 0.18)):
            g.cylinder(0.153, 0.02, "mortar", T(0, 0, 0.35 + 0.09 + j * 0.18), segs=12, caps=False)
    for zz in (0.9, 2.05):
        g.cylinder(0.165, 0.1, "accent", T(0, 0, 0.35 + zz - 0.05), segs=12, bevel=0.02)
    g.rbox((0.42, 0.42, 0.14), "wall_a~3", None, 0.03, 1, (0, 0, 2.37))
    g.rbox((0.48, 0.48, 0.09), "accent", None, 0.03, 1, (0, 0, 2.555))  # turquoise tile cap at 2.6 m
    z = 2.6
    g.lathe([(0.0, 0.0), (0.11, 0.0), (0.15, 0.12), (0.15, 0.26), (0.0, 0.28)], "lamp", T(0, 0, z), segs=12)
    for k in range(6):  # glazed pointed-arch frame
        g.rbox((0.06, 0.06, 0.34), "accent", T(0, 0, z) @ RZ(60 * k + 30) @ T(0.16, 0, 0.17), 0.015, 1)
    g.lathe([(0.0, 0.0), (0.22, 0.0), (0.2, 0.06), (0.13, 0.16), (0.05, 0.27), (0.0, 0.32)], "roof_a", T(0, 0, z + 0.32), segs=12)
    g.lathe([(0.0, 0.0), (0.04, 0.04), (0.0, 0.18)], "gold", T(0, 0, z + 0.62), segs=6)


def hooded_lantern_post(c, p):
    """Nordic (Frostveil, Whitewater Reach): an iron lantern under a small shingle hood on a 2.5 m log post."""
    g, s = c.g, c.s
    g.cylinder(0.3, 0.2, "stone~1", T(0, 0, 0), segs=10, bevel=0.06)
    g.cylinder(0.14, 2.3, c.wall_key, T(0, 0, 0.2), segs=10, r_top=0.12)  # the log post, 2.5 m
    g.cylinder(0.125, 0.05, c.wall_key + "~3", T(0, 0, 1.2), segs=10)
    g.rbox((0.44, 0.44, 0.07), "trim", None, 0.02, 1, (0, 0, 2.53))
    z = 2.57  # the iron lantern: corner bars, top and bottom plates and the glow between
    g.rbox((0.3, 0.3, 0.05), "metal", None, 0.015, 1, (0, 0, z + 0.025))
    g.rbox((0.21, 0.21, 0.3), "lamp", None, 0.02, 1, (0, 0, z + 0.2))
    for sx in (-1, 1):
        for sy in (-1, 1):
            g.rbox((0.04, 0.04, 0.32), "metal", None, 0.01, 1, (sx * 0.12, sy * 0.12, z + 0.2))
    g.lathe([(0.17, 0.0), (0.0, 0.1)], "metal", T(0, 0, z + 0.36), segs=4, phase=math.pi / 4)
    for sx in (-1, 1):  # two uprights carry the hood
        g.rbox((0.05, 0.05, 0.58), "trim", None, 0.01, 1, (sx * 0.2, 0, z + 0.29))
    zh, pitch, half = z + 0.6, 38.0, 0.34
    for sy in (-1, 1):  # shingle hood: a little gable along x
        hm = T(0, sy * half / 2 * math.cos(math.radians(pitch)), zh + 0.13 - half / 2 * math.sin(math.radians(pitch))) @ RX(-sy * pitch)
        g.rbox((0.66, half + 0.04, 0.04), "trim~1", hm, 0.01, 1)
        if c.hi:
            for j in range(3):
                for k in range(5):
                    g.rbox((0.13, 0.15, 0.025), "wood_light%s" % ("~3" if (j + k) % 2 else ""), hm @ T(-0.26 + k * 0.13 + (0.065 if j % 2 else 0) * (1 if k < 4 else 0), sy * (half / 2 - 0.06 - j * 0.11), 0.03 + 0.012 * j), 0.005, 1)
    g.rbox((0.7, 0.07, 0.06), "trim", None, 0.01, 1, (0, 0, zh + 0.14))
    if s.snow:
        g.rbox((0.62, 0.34, 0.05), "snow", None, 0.02, 1, (0, 0, zh + 0.18))


LAMP_FORMS = {"hoshizora": paper_lamp_post, "shenlu": paper_lamp_post, "haneul": paper_lamp_post,
              "clockwork": gas_lamp_post, "dwarven": coal_basket_post, "gothic": silk_lamp_post, "fenland": fen_lamp_post,
              "desert": brass_lantern_post, "garden": glazed_lantern_post, "nordic": hooded_lantern_post}


# ================================================================================================================
# Regional signature buildings


def yurt(c, p, r=None):
    r = r or p.get("radius", 3.0)
    info = round_block(c, 0, 0, r, 1, "yurt", floor_h=1.7, wall="felt")
    c.g.lathe([(0.0, 0.0), (0.12, 0.0), (0.12, 2.6), (0.0, 2.6)], "trim", T(r + 1.2, -1.0, 0), segs=8)
    K.banner(c, T(r + 1.2, -1.0, 0), 0.0, 2.5, 1.0, 0.45)


def yurt_large(c, p):
    yurt(c, p, p.get("radius", 4.2))


def _cap_colour(c):
    c.roof_key = c.rng.choice(["roof_a", "roof_a", "roof_b", "roof_c"])


def mushroom_house(c, p):
    r = p.get("radius", 2.4)
    _cap_colour(c)
    info = round_block(c, 0, 0, r, 1, "cap", floor_h=p.get("height", 3.0), wall="stalk")
    K.chimney(c, r * 0.5, r * 0.4, info["top"], info["top"] + info["rise"] * 0.8, "pipe")
    for k in range(5):
        a = c.rng.uniform(0, 2 * math.pi)
        c.g.inst("tuft|leaf%s" % c.rng.choice(["", "~3"]), T((r + 0.4) * math.cos(a), (r + 0.4) * math.sin(a), 0))
        c.g.inst("flower|flower_%s" % c.rng.choice("abcd"), T((r + 0.5) * math.cos(a + 0.2), (r + 0.5) * math.sin(a + 0.2), 0.15))


def mushroom_tower(c, p):
    r = p.get("radius", 2.2)
    _cap_colour(c)
    info = round_block(c, 0, 0, r, p.get("floors", 2), "cap", floor_h=3.0, wall="stalk")
    # a second, smaller toadstool growing out of the side
    _cap_colour(c)
    round_block(c, r + 1.0, 0.8, 1.1, 1, "cap", floor_h=2.0, wall="stalk", door=False, windows=False)


def mushroom_shop(c, p):
    r = p.get("radius", 2.6)
    mushroom_house(c, dict(p, radius=r))
    # a sign on its own post beside the door, and goods out front
    c.g.cylinder(0.08, 2.9, "trim", T(1.9, -r - 0.9, 0), segs=8, bevel=0.02)
    K.sign(c, T(1.9, -r - 0.3, 0), 0.0, 2.2, p.get("icon") or c.rng.choice(ICONS))
    crates(c, -2.2, -r - 0.8, 0.0)


def mushroom_cluster(c, p):
    """An inn or hall: one big toadstool with two smaller ones grown against it."""
    r = p.get("radius", 3.4)
    _cap_colour(c)
    info = round_block(c, 0, 0, r, 2, "cap", floor_h=3.0, wall="stalk")
    for (x, y, rr, h) in ((r + 1.2, 1.0, 1.6, 2.4), (-r - 0.9, 1.6, 1.3, 2.0)):
        _cap_colour(c)
        round_block(c, x, y, rr, 1, "cap", floor_h=h, wall="stalk", door=False)
    K.sign(c, T(0, -r, 0), 1.9, 2.9, "tankard")
    for k in range(3):
        bench(c, -2.4 + k * 2.4, -r - 2.0, 0.0)


# Mossdeep's working buildings (review B2): toadstool or leaf-thatch forms instead of plain plaster boxes.


def _stalk_post(c, x, y, h, r=0.16):
    """A bulging stalk-coloured post (circle language for Mossdeep sheds)."""
    c.g.lathe([(r * 1.3, 0.0), (r * 1.15, h * 0.2), (r * 0.95, h * 0.7), (r * 1.1, h)], "wall_a~3", T(x, y, 0), segs=12)


def _ember_hearth(c, x, y, z=0.0):
    g = c.g
    g.rbox((1.8, 1.2, 0.9), "stone~3", None, 0.08, c.seg(), (x, y, z + 0.45))
    g.rbox((1.3, 0.8, 0.1), "ember", None, 0.03, 1, (x, y, z + 0.92))
    for k in range(4):
        g.sphere(c.rng.uniform(0.1, 0.16), "ember~2", T(x - 0.4 + k * 0.27, y + c.rng.uniform(-0.2, 0.2), z + 0.98), segs=8, rings=5, squash=0.7)


def mushroom_smithy(c, p):
    """A toadstool forge: a squat red-capped workshop, a stone chimney through the cap, an open leaf-thatch forge."""
    r = p.get("radius", 2.5)
    c.roof_key = "roof_a"
    info = round_block(c, 0, 0, r, 1, "cap", floor_h=p.get("height", 3.0), wall="stalk")
    K.chimney(c, -r * 0.45, r * 0.45, 0.0, info["top"] + info["rise"] + 0.4, "forge")
    # the open forge under a leaf-thatch lean-to on stalk posts
    fx, fy, fw, fd = r + 1.9, -0.6, 3.6, 3.0
    for sx in (-1, 1):
        for sy in (-1, 1):
            _stalk_post(c, fx + sx * (fw / 2 - 0.2), fy + sy * (fd / 2 - 0.2), 2.5)
    K.roof(c, T(fx, fy, 2.5), fw, fd, "curved", pitch=34, cover="leaf", key="leaf", overhang=0.35)
    _ember_hearth(c, fx + 0.6, fy + 0.7)
    g = c.g
    g.rbox((0.5, 0.45, 0.55), "stone_dark", None, 0.04, 1, (fx - 0.6, fy - 0.5, 0.28))
    g.lathe([(0.0, 0.0), (0.22, 0.0), (0.22, 0.25), (0.45, 0.32), (0.5, 0.45), (0.0, 0.45)], "metal",
            T(fx - 0.6, fy - 0.5, 0.55) @ RZ(90) @ Matrix.Diagonal((1.5, 0.6, 1, 1)), segs=8)
    g.lathe([(0.0, 0.0), (0.4, 0.0), (0.45, 0.4), (0.4, 0.8), (0.0, 0.75)], "wood_light~1", T(fx + fw / 2 + 0.6, fy - 1.0, 0), segs=16)
    g.cylinder(0.38, 0.05, "water", T(fx + fw / 2 + 0.6, fy - 1.0, 0.72), segs=16)
    K.sign(c, T(r * 0.7, -r - 0.2, 0), 0.0, 2.4, "hammer")


def mushroom_barn(c, p):
    """A broad, squat brown toadstool barn with a little toadstool silo and hay."""
    r = p.get("radius", 3.7)
    c.roof_key = "roof_b"
    round_block(c, 0, 0, r, 1, "cap", floor_h=p.get("height", 3.4), wall="stalk")
    _cap_colour(c)
    round_block(c, r + 1.7, 1.4, 1.35, 2, "cap", floor_h=2.3, wall="stalk", door=False, windows=False)
    hay(c, -r - 1.3, -1.6, 0.0)
    for k in range(4):
        a = c.rng.uniform(0, 2 * math.pi)
        c.g.inst("tuft|leaf%s" % c.rng.choice(["", "~3"]), T((r + 0.4) * math.cos(a), (r + 0.4) * math.sin(a), 0))


def mushroom_stable(c, p):
    """A leaf-thatched open stable on stalk posts, with stalls, a trough and a toadstool tack room at one end."""
    w, d = p.get("width", 10.0), p.get("depth", 4.6)
    g = c.g
    g.rbox((w, d, 0.2), "wood_light~3", None, 0.04, c.seg(), (0, 0, 0.1))
    n = 4
    for k in range(n + 1):
        x = -w / 2 + 0.25 + k * (w - 0.5) / n
        for y in (-d / 2 + 0.25, d / 2 - 0.25):
            _stalk_post(c, x, y, 2.6)
        g.rbox((0.12, d * 0.7, 1.3), "trim", None, 0.03, c.seg(), (x, 0.2, 0.85))
    for k in range(n):
        x = -w / 2 + 0.25 + (k + 0.5) * (w - 0.5) / n
        g.rbox(((w - 0.5) / n * 0.8, 0.08, 1.0), "door", None, 0.03, c.seg(), (x, -d / 2 + 0.35, 0.7))
    g.rbox((w, 0.12, 0.2), "trim", None, 0.03, c.seg(), (0, d / 2 - 0.25, 1.5))
    K.roof(c, T(0, 0, 2.6), w + 0.2, d, "curved", pitch=40, cover="leaf", key="leaf", overhang=0.55)
    _cap_colour(c)
    round_block(c, w / 2 + 1.6, 0.4, 1.4, 1, "cap", floor_h=2.4, wall="stalk", windows=False)
    hay(c, -w / 2 - 1.2, 0.0, 0.0)
    g.rbox((2.2, 0.6, 0.6), "wood_light~1", None, 0.04, 1, (-1.0, -d / 2 - 0.8, 0.3))  # trough


def mushroom_gate(c, p):
    """A gate of two toadstool towers joined by a bent root arch hung with lanterns and vines."""
    span = p.get("width", 4.6)
    r = 1.7
    g = c.g
    for side in (-1, 1):
        _cap_colour(c)
        round_block(c, side * (span / 2 + r - 0.2), 0, r, p.get("floors", 2), "cap", floor_h=3.0, wall="stalk", door=False)
        K.wall_lantern(c, T(side * (span / 2 + 0.25), -1.25, 0), 0.0, 2.3)
    # the root arch: a thick, slightly knotted bough bent over the road
    R = span / 2 + 0.2
    zc = 3.4
    n = 14
    for k in range(n):
        a0, a1 = math.pi * k / n, math.pi * (k + 1) / n
        p0 = (R * math.cos(a0), zc + R * 0.9 * math.sin(a0))
        p1 = (R * math.cos(a1), zc + R * 0.9 * math.sin(a1))
        ln = math.dist(p0, p1)
        ang = math.degrees(math.atan2(p1[1] - p0[1], p1[0] - p0[0]))
        th = 0.8 + 0.12 * math.sin(k * 1.7)
        g.rbox((ln + 0.14, 0.85, th), "trim%s" % c.rng.choice(["", "~3", "~4"]), T((p0[0] + p1[0]) / 2, 0, (p0[1] + p1[1]) / 2) @ RY(-ang), 0.18, c.seg())
        if k % 2 == 0:
            g.inst("ivy|leaf%s" % c.rng.choice(["", "~3"]), T((p0[0] + p1[0]) / 2, -0.32, (p0[1] + p1[1]) / 2 - 0.2))
            g.inst("ivy|leaf%s" % c.rng.choice(["", "~3"]), T((p0[0] + p1[0]) / 2, 0.32, (p0[1] + p1[1]) / 2 - 0.2) @ RZ(180))
    K.round_roof(c, T(0, 0, zc + R * 0.9 + 0.2), 0.55, "cap", "roof_a", c.s.cover)  # a small toadstool on the keystone
    g.cylinder(0.12, 0.3, "wall_a", T(0, 0, zc + R * 0.9), segs=10)
    g.cylinder(0.015, 0.7, "trim", T(0, 0, zc + R * 0.9 - 0.95), segs=4)  # a lantern hung from the arch
    g.lathe([(0.0, -0.2), (0.12, -0.16), (0.16, 0.0), (0.12, 0.16), (0.0, 0.2)], "lamp", T(0, 0, zc + R * 0.9 - 1.15), segs=10)


def hedge_wall(c, p):
    """A hedge wall on a bed of roots, sprouting little toadstools (Mossdeep's wall segment)."""
    L = p.get("width", 10.0)
    H = p.get("height", 2.4)
    g = c.g
    g.rbox((L, 1.2, H), "leaf~1", None, 0.45, c.seg(), (0, 0, H / 2 + 0.2))
    for side in (-1, 1):  # leafy bumps on both faces and the top
        for i in range(int(L / 0.5)):
            for j in range(int(H / 0.5)):
                x = -L / 2 + 0.25 + i * 0.5 + c.rng.uniform(-0.1, 0.1)
                z = 0.4 + j * 0.5 + c.rng.uniform(-0.1, 0.1)
                g.inst("bush|leaf%s" % c.rng.choice(["", "~3", "~4"]), T(x, side * 0.6, z) @ RZ(c.rng.uniform(0, 360)) @ Matrix.Diagonal((0.9, 0.9, 0.9, 1)))
                if c.chance(0.08):
                    g.inst("flower|flower_%s" % c.rng.choice("abcd"), T(x, side * 0.72, z + 0.1))
    for i in range(int(L / 0.5)):
        g.inst("bush|leaf%s" % c.rng.choice(["", "~3"]), T(-L / 2 + 0.25 + i * 0.5, c.rng.uniform(-0.3, 0.3), H + 0.15) @ Matrix.Diagonal((1.0, 1.0, 0.8, 1)))
    for side in (-1, 1):  # gnarled roots along the foot
        x = -L / 2
        while x < L / 2 - 0.5:
            ln = min(c.rng.uniform(1.2, 2.4), L / 2 - x)
            g.cylinder(c.rng.uniform(0.16, 0.26), ln, "trim%s" % c.rng.choice(["", "~3"]), T(x, side * 0.62, 0.2) @ RY(90) @ RX(c.rng.uniform(-6, 6)), segs=10, bevel=0.06)
            x += ln * 0.8
    for k in range(int(L / 3.0)):  # little toadstools growing at the foot
        x = -L / 2 + 1.5 + k * 3.0 + c.rng.uniform(-0.5, 0.5)
        y = c.rng.choice((-1, 1)) * 0.95
        h = c.rng.uniform(0.35, 0.7)
        g.lathe([(0.1, 0.0), (0.12, h * 0.5), (0.08, h)], "wall_a", T(x, y, 0), segs=10)
        K.round_roof(c, T(x, y, h), c.rng.uniform(0.22, 0.34), "cap", c.rng.choice(["roof_a", "roof_c", "roof_b"]), c.s.cover)


# Desert and garden civic buildings (review B2): the dome goes on the temple and the bathhouse, not on every roof.


def _civic_dome(c, x, y, z, r):
    K.round_roof(c, T(x, y, z), r, "onion" if c.s.tower_roof == "onion" else "dome", c.roof_key, c.s.cover)


def domed_temple(c, p):
    w, d = p.get("width", 10.0), p.get("depth", 14.0)
    info = block(c, 0, 0, w, d, 1, ridge="y", door_x=0.0, wide_door=True, ground_h=p.get("nave_h", 5.6), chimney="none",
                 door_kind="pointed" if c.s.door == "pointed" else "arched")
    _civic_dome(c, 0, 1.0, info["top"] + 0.25, min(w, d) * 0.36)
    tower(c, w / 2 + 0.9, -d / 2 + 0.9, 2.4, 5.5, door=False, round_=True)  # a minaret


def domed_bathhouse(c, p):
    w, d = p.get("width", 11.0), p.get("depth", 8.0)
    info = block(c, 0, 0, w, d, 1, door_x=0.0, wide_door=True, ground_h=3.6, chimney="none")
    _civic_dome(c, -w * 0.18, 0, info["top"] + 0.25, d * 0.32)
    _civic_dome(c, w * 0.32, 0, info["top"] + 0.25, d * 0.16)


def pagoda(c, p):
    tiers = p.get("floors", 4)
    size = p.get("width", 7.0)
    z = 0.0
    s = c.s
    for i in range(tiers):
        w = size * (1 - i * 0.16)
        info = block(c, 0, 0, w, w, 1, "x", "curved", door_x=0.0 if i == 0 else None, z0=z, base=(i == 0),
                     ground_h=3.0 if i == 0 else 2.2, jetty=0.0, chimney="none", pitch=30, lantern=(i == 0))
        z = info["top"] + 0.5
    K.finial(c, T(0, 0, z + 0.4), 2.2)
    for k in range(7):
        c.g.lathe([(0.0, 0.0), (0.3, 0.05), (0.0, 0.12)], "gold", T(0, 0, z + 0.6 + k * 0.28), segs=12)


def torii_gate(c, p):
    g = c.g
    span = p.get("width", 5.0)
    H = p.get("height", 5.0)
    for sx in (-1, 1):
        g.lathe([(0.3, 0.0), (0.26, 0.05), (0.24, H), (0.0, H)], "trim", T(sx * span / 2, 0, 0), segs=16)
        g.cylinder(0.34, 0.6, "trim_dark", T(sx * span / 2, 0, 0), segs=16, bevel=0.04)
    g.rbox((span + 0.8, 0.4, 0.35), "trim", None, 0.05, c.seg(), (0, 0, H - 1.0))
    top = lambda u, v: (lerp(-span / 2 - 1.4, span / 2 + 1.4, u), lerp(-0.3, 0.3, v), H + 0.15 + 0.35 * (2 * abs(u - 0.5)) ** 2.2)
    g.patch(top, 24, 2, "trim", None, 0.35)
    g.patch(lambda u, v: (lerp(-span / 2 - 1.5, span / 2 + 1.5, u), lerp(-0.36, 0.36, v), H + 0.55 + 0.38 * (2 * abs(u - 0.5)) ** 2.2), 24, 2, "trim_dark", None, 0.12)
    g.rbox((0.3, 0.25, 0.8), "trim_dark", None, 0.04, 1, (0, -0.05, H - 0.45))


def paifang_gate(c, p):
    g = c.g
    span = p.get("width", 6.0)
    H = 5.0
    for x in (-span / 2, -span / 6, span / 6, span / 2):
        g.cylinder(0.24, H, "trim", T(x, 0, 0), segs=14, bevel=0.03)
        g.rbox((0.7, 0.7, 0.5), "stone~2", None, 0.06, c.seg(), (x, 0, 0.25))
    g.rbox((span + 0.4, 0.4, 0.5), "accent", None, 0.04, c.seg(), (0, 0, H - 0.6))
    g.rbox((span * 0.3, 0.2, 0.8), "accent_b", None, 0.04, c.seg(), (0, -0.25, H - 1.4))
    K.roof(c, T(0, 0, H), span + 0.6, 1.4, "curved", pitch=30, overhang=0.7)


def lighthouse(c, p):
    r = p.get("radius", 2.4)
    info = round_block(c, 0, 0, r, 5, None, floor_h=3.0, wall="plaster")
    g = c.g
    for k in range(5):  # stripes
        if k % 2:
            g.cylinder(r + 0.02, 3.0, "accent", T(0, 0, info["zf"] + k * 3.0), segs=32)
    z = info["top"]
    g.cylinder(r + 0.6, 0.25, "stone~2", T(0, 0, z), segs=32, bevel=0.05)
    g.cylinder(r * 0.6, 2.0, "glass", T(0, 0, z + 0.25), segs=16)
    g.sphere(r * 0.4, "lamp", T(0, 0, z + 1.25), segs=12, rings=8)
    for k in range(8):
        a = 360 * k / 8
        g.rbox((0.08, 0.08, 2.0), "metal", T(0, 0, z + 1.25) @ RZ(a) @ T(r * 0.6, 0, 0), 0.02, 1)
    K.round_roof(c, T(0, 0, z + 2.25), r * 0.8, "dome", "accent", "plaster")


def stepped_pyramid(c, p):
    g = c.g
    tiers = p.get("floors", 5)
    size = p.get("width", 16.0)
    th = 1.6
    for i in range(tiers):
        w = size * (1 - i * 0.16)
        z = i * th
        g.rbox((w, w, th), "stone%s" % ("" if i % 2 == 0 else "~3"), None, 0.08, c.seg(), (0, 0, z + th / 2))
        m = K.face_matrix(0, 0, w, w, z, "front")
        if c.s.has("painted_bands"):
            g.rbox((w + 0.04, w + 0.04, 0.25), "accent" if i % 2 else "accent_b", None, 0.03, 1, (0, 0, z + th - 0.2))
        for face in ("front", "right", "back", "left"):  # carved panels
            fm = K.face_matrix(0, 0, w, w, z, face)
            for k in range(int(w / 1.6)):
                g.rbox((0.9, 0.12, 0.9), "stone~2", fm, 0.06, 1, (-w / 2 + 0.8 + k * 1.6, -0.02, th / 2))
    # the stair up the front
    for k in range(int(tiers * th / 0.3)):
        y = -size / 2 - 0.2 + k * 0.3 * (size * 0.16 / 2 / th)
        g.rbox((3.0, 0.5, 0.3), "stone~2", None, 0.04, 1, (0, -size / 2 + k * 0.3 * (size * 0.08 / th) - 0.2, k * 0.3 + 0.15))
    top = tiers * th
    w = size * (1 - tiers * 0.16)
    block(c, 0, 0, max(3.5, w - 1.0), max(3.0, w - 1.6), 1, door_x=0.0, z0=top, base=False, ground_h=2.8, chimney="none")


def domed_hall(c, p):
    w, d = p.get("width", 12.0), p.get("depth", 12.0)
    info = block(c, 0, 0, w, d, 1, "x", "flat", door_x=0.0, wide_door=True, ground_h=5.0, chimney="none", door_kind="arched" if c.s.door != "pointed" else "pointed")
    K.round_roof(c, T(0, 0, info["top"] + 0.25), min(w, d) * 0.38, "dome" if c.s.family != "garden" else "onion", c.roof_key, c.s.cover)
    tower(c, w / 2 + 1.2, d / 2 - 1.2, 2.4, 6, door=False, round_=True)


def adobe_tower(c, p):
    size = p.get("width", 4.4)
    info = block(c, 0, 0, size, size, p.get("floors", 4), "x", "flat", door_x=0.0, jetty=0.0, chimney="none")
    for k in range(int(info["top"] / 1.2)):  # torons: wooden stakes sticking out of the mud walls
        for face in ("front", "right", "back", "left"):
            m = K.face_matrix(0, 0, size, size, 0, face)
            for x in (-size / 2 + 0.6, 0.0, size / 2 - 0.6):
                if face == "front" and x == 0.0 and k < 3:
                    continue
                c.g.cylinder(0.06, 0.6, "trim", m @ T(x, 0.1, 1.0 + k * 1.2) @ RX(90), segs=6)


def tent(c, p):
    g = c.g
    w, d = p.get("width", 3.2), p.get("depth", 4.0)
    H = 2.4
    key = c.rng.choice(["cloth_b", "accent", "cloth_a"])
    for side in (-1, 1):
        g.patch(lambda u, v, side=side: (lerp(-d / 2, d / 2, u), side * lerp(w / 2 + 0.3, 0.0, v), lerp(0.0, H, v) - 0.08 * math.sin(math.pi * v)), 8, 6, key, T(0, 0, 0) @ RZ(90), 0.04)
    for y in (-d / 2, d / 2):
        g.cylinder(0.06, H + 0.3, "trim", T(0, y, 0), segs=8)
    g.slab_poly([(-w / 2 - 0.3, 0), (w / 2 + 0.3, 0), (0, H)], 0.04, key + "~3", T(0, d / 2 - 0.02, 0))
    g.slab_poly([(-w / 2, 0), (-0.1, 0), (-0.1, H * 0.9)], 0.04, key + "~3", T(0, -d / 2 + 0.02, 0))


def tent_large(c, p):
    tent(c, dict(p, width=p.get("width", 5.0), depth=p.get("depth", 6.0)))


def tree_house(c, p):
    g = c.g
    h = p.get("height", 6.0)
    g.lathe([(1.6, 0.0), (1.0, 0.6), (0.8, 2.0), (0.75, h), (0.9, h + 1.0), (0.4, h + 4.0), (0.0, h + 5.0)], "trim", T(0, 0, 0), segs=20)
    for k in range(6):  # roots
        a = 60 * k + c.rng.uniform(-15, 15)
        g.lathe([(0.35, 0.0), (0.2, 1.4), (0.0, 1.6)], "trim~1", T(0, 0, 0.2) @ RZ(a) @ RY(70) @ T(0, 0, 0.6), segs=8)
    g.cylinder(4.0, 0.3, "wood_light", T(0, 0, h), segs=36, bevel=0.06)
    round_block(c, 0, 0, 2.6, 1, c.s.round_roof, floor_h=2.8, z0=h + 0.3)
    for k in range(int(h / 0.45)):  # a spiral stair
        a = math.radians(k * 24)
        g.rbox((0.9, 0.35, 0.08), "wood_light", T(0, 0, k * 0.45) @ RZ(math.degrees(a)) @ T(1.25, 0, 0), 0.02, 1)


# ================================================================================================================

ARCHETYPES = {
    # homes
    "cottage": cottage, "house": house, "townhouse": townhouse, "manor": manor, "stilt_house": stilt_house,
    "longhouse": longhouse, "longhouse_hall": longhouse_hall,
    # trade
    "shop": shop, "inn": inn, "tavern": tavern, "warehouse": warehouse, "market_stall": market_stall,
    # craft and farm
    "smithy": smithy, "barn": barn, "stable": stable, "granary": granary, "mill": mill,
    # civic, learning, faith
    "guild_hall": guild_hall, "town_hall": town_hall, "library": library, "bathhouse": bathhouse,
    "temple": temple, "shrine": shrine,
    # defence
    "watchtower": watchtower_full, "gatehouse": gatehouse, "wall_segment": wall_segment, "barracks": barracks,
    # infrastructure
    "well": well, "bridge": bridge, "fountain": fountain, "lamp_post": lamp_post,
    # regional signatures
    "yurt": yurt, "yurt_large": yurt_large, "mushroom_house": mushroom_house, "mushroom_tower": mushroom_tower,
    "mushroom_shop": mushroom_shop, "mushroom_cluster": mushroom_cluster,
    "pagoda": pagoda, "torii_gate": torii_gate, "paifang_gate": paifang_gate, "lighthouse": lighthouse,
    "stepped_pyramid": stepped_pyramid, "domed_hall": domed_hall, "adobe_tower": adobe_tower,
    "adobe_mosque_hall": domed_hall, "tent": tent, "tent_large": tent_large, "tree_house": tree_house,
    "mushroom_smithy": mushroom_smithy, "mushroom_barn": mushroom_barn, "mushroom_stable": mushroom_stable,
    "mushroom_gate": mushroom_gate, "hedge_wall": hedge_wall, "domed_temple": domed_temple,
    "domed_bathhouse": domed_bathhouse, "kura": kura, "wind_catcher": wind_catcher, "watermill": watermill,
    "water_forge": water_forge,
}

# What every settlement may need, in catalogue order (regional remaps swap some of these out).
CORE = ["cottage", "house", "townhouse", "manor", "shop", "inn", "tavern", "warehouse", "market_stall", "smithy",
        "barn", "stable", "granary", "mill", "guild_hall", "town_hall", "library", "bathhouse", "temple", "shrine",
        "watchtower", "gatehouse", "wall_segment", "barracks", "well", "bridge", "fountain", "lamp_post"]

SIGNATURES = {
    "fenland": ["stilt_house"], "steppe": ["yurt", "yurt_large", "tent_large"], "mushroom": ["mushroom_house", "mushroom_tower"],
    "hoshizora": ["pagoda", "torii_gate"], "shenlu": ["pagoda", "paifang_gate"], "haneul": ["torii_gate"],
    "nordic": ["longhouse", "longhouse_hall"], "desert": ["domed_hall", "adobe_tower"], "garden": ["domed_hall"],
    "coastal": ["lighthouse", "stilt_house"], "jungle": ["stepped_pyramid", "stilt_house"], "elven": ["tree_house"],
    "celestial": ["domed_hall"], "ancient": ["stepped_pyramid"],
}


def catalogue(family):
    """The archetypes to build for a family's library: the core set plus its signature buildings."""
    out = [a for a in CORE if not (a == "mill" and family in MILL_DROPPED)]
    for extra in SIGNATURES.get(family, []):
        if extra not in out:
            out.append(extra)
    return out
