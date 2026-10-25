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
    key = c.rng.choice(["cloth_a", "cloth_b", "accent"])
    g.patch(canopy, 12, 4, key, None, 0.04)
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
    K.chimney(c, -1.5, d / 2 - 0.7, zf, info["top"] + info["rise"], "forge")
    # anvil, quench barrel, tool rack
    g.rbox((0.5, 0.45, 0.55), "stone_dark", None, 0.04, 1, (1.2, -0.6, zf + 0.28))
    g.lathe([(0.0, 0.0), (0.22, 0.0), (0.22, 0.25), (0.45, 0.32), (0.5, 0.45), (0.0, 0.45)], "metal", T(1.2, -0.6, zf + 0.55) @ RZ(90) @ Matrix.Diagonal((1.5, 0.6, 1, 1)), segs=8)
    g.lathe([(0.0, 0.0), (0.4, 0.0), (0.45, 0.4), (0.4, 0.8), (0.0, 0.75)], "wood_light~1", T(2.4, 0.4, zf), segs=16)
    g.cylinder(0.38, 0.05, "glass", T(2.4, 0.4, zf + 0.72), segs=16)
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
    round_block(c, 0, 0, p.get("radius", 2.6), p.get("floors", 2), "cone", floor_h=3.2)


def mill(c, p):
    s = c.s
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


# ================================================================================================================
# Civic, learning and faith


def guild_hall(c, p):
    w, d = p.get("width", 14.0), p.get("depth", 10.0)
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
    info = block(c, 0, 0, size, size, floors, "x", "flat", door_x=0.0, jetty=0.0, chimney="none")
    lookout(c, 0, 0, size, info["top"] + 0.3)
    if c.s.has("banners"):
        K.banner(c, K.face_matrix(0, 0, size, size, info["zf"], "front"), 0.0, info["top"] - info["zf"] - 0.4, 2.2, 0.8)


def gatehouse(c, p):
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
    construction = s.walls if s.walls not in ("post_panel", "stalk", "timber_frame", "adobe", "plaster") else "rubble"
    if s.walls == "adobe":
        construction = "adobe"
    for face_y, rot in ((-0.6, 0), (0.6, 180)):
        K.build_wall(c, T(0, face_y, 0) @ RZ(rot), L, H, [], construction, c.wall_key if construction == "adobe" else "stone")
    g.rbox((L, 1.2, 0.2), "stone~3" if construction != "adobe" else c.wall_key, None, 0.04, c.seg(), (0, 0, H))
    for k in range(int(L / 0.9)):
        if k % 2 == 0:
            g.rbox((0.6, 0.4, 0.6), "stone~2" if construction != "adobe" else c.wall_key, None, 0.04, c.seg(), (-L / 2 + 0.45 + k * 0.9, -0.4, H + 0.4))


def barracks(c, p):
    w, d = p.get("width", 11.0), p.get("depth", 7.0)
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
    g.cylinder(r - 0.1, 0.05, "glass", T(0, 0, 0.6), segs=24)
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
    g = c.g
    r = p.get("radius", 2.4)
    g.lathe([(0.0, 0.0), (r, 0.0), (r + 0.1, 0.1), (r + 0.1, 0.6), (r - 0.25, 0.65), (r - 0.25, 0.4), (0.0, 0.4)], "stone~2", T(0, 0, 0), segs=40)
    g.cylinder(r - 0.25, 0.05, "glass", T(0, 0, 0.5), segs=40)
    g.lathe([(0.35, 0.0), (0.25, 0.8), (0.3, 1.2), (1.0, 1.35), (1.05, 1.55), (0.85, 1.55), (0.2, 1.45), (0.15, 2.2), (0.3, 2.4), (0.0, 2.6)], "stone", T(0, 0, 0.4), segs=28)
    g.cylinder(0.85, 0.04, "glass", T(0, 0, 1.92), segs=28)
    finial_like = c.s.family in ("garden", "celestial", "desert")
    g.sphere(0.25, "gold" if finial_like else "glow", T(0, 0, 3.15), segs=12, rings=8)


def lamp_post(c, p):
    g = c.g
    g.lathe([(0.18, 0.0), (0.14, 0.3), (0.07, 0.4), (0.06, 3.0), (0.09, 3.1), (0.0, 3.15)], "metal", T(0, 0, 0), segs=10)
    g.rbox((0.06, 0.6, 0.06), "metal", None, 0.015, 1, (0, -0.28, 3.0))
    K.wall_lantern(c, T(0, 0.0, 0.0), 0.0, 2.55)


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
    out = list(CORE)
    for extra in SIGNATURES.get(family, []):
        if extra not in out:
            out.append(extra)
    return out
