"""
Regional ornaments added to a finished block, driven by the style's `extras`: gears and pipes (Gearholm), lightning
rods (Stormreach), prayer flags (Dragon Spine), bunting (Ashira Vale), webs and silk lanterns (Umbravel), nets, buoys
and mooring poles (the coasts and Lirian), pots, textiles, wings, bone ribs, finials and grass tufts.
"""
import math

from mathutils import Matrix

from . import construct as K
from .construct import RX, RY, RZ, T


def decorate(c, cx, cy, w, d, zf, top, rise, ridge="x"):
    s = c.s
    front = K.face_matrix(cx, cy, w, d, zf, "front")
    right = K.face_matrix(cx, cy, w, d, zf, "right")
    H = top - zf
    ridge_z = top + rise
    ends = [(cx - w / 2 + 0.4, cy), (cx + w / 2 - 0.4, cy)] if ridge == "x" else [(cx, cy - d / 2 + 0.4), (cx, cy + d / 2 - 0.4)]
    if s.has("gears") and c.chance(0.8):
        gear(c, front, w / 2 - 1.0, min(H - 1.0, 3.6), c.rng.uniform(0.5, 0.8))
        if c.chance(0.5):
            gear(c, front, w / 2 - 1.9, min(H - 1.6, 3.0), 0.35)
    if s.has("pipes"):
        pipes(c, right, d, H)
    if s.has("lightning_rods") and rise > 0:
        for x, y in ends:
            c.g.cylinder(0.03, 2.2, "metal", T(x, y, ridge_z - 0.1), segs=6)
            c.g.sphere(0.09, "gold", T(x, y, ridge_z + 2.1), segs=8, rings=5)
            c.g.lathe([(0.0, 0.0), (0.03, 0.05), (0.0, 0.45)], "gold", T(x, y, ridge_z + 2.15), segs=6)
    if s.has("finials") and rise > 0 and s.roof in ("gable", "hip", "curved"):
        for x, y in ends:
            K.finial(c, T(x, y, ridge_z), 0.6)
    if s.has("prayer_flags") and rise > 0:
        flag_line(c, (ends[0][0], ends[0][1], ridge_z + 0.2), (cx - w / 2 - 5.0, cy - d / 2 - 2.0, 3.5), True)
    if s.has("bunting"):
        flag_line(c, (cx - w / 2, cy - d / 2 - 0.1, zf + min(H, 3.0) - 0.2), (cx + w / 2, cy - d / 2 - 0.1, zf + min(H, 3.0) - 0.2), False)
    if s.has("webs") and c.chance(0.7):
        webs(c, cx - w / 2, cy - d / 2, top)
    if s.has("silk"):
        for x in (-w / 4, w / 4):
            K.wall_lantern(c, front, x, min(H - 0.6, 2.4))
    if s.has("nets") and c.chance(0.7):
        net(c, right, d, H)
    if s.has("buoys") and c.chance(0.7):
        for k in range(3):
            c.g.cylinder(0.01, 0.6, "trim", right @ T(-d / 4 + k * 0.4, -0.1, 1.5), segs=4)
            c.g.sphere(0.16, "accent" if k % 2 else "wall_a", right @ T(-d / 4 + k * 0.4, -0.15, 1.35), segs=10, rings=6)
    if s.has("mooring_poles") and c.chance(0.6):
        for x in (-w / 3, w / 3):
            for k in range(6):
                c.g.cylinder(0.12, 0.5, "accent" if k % 2 else "wall_a", T(cx + x, cy - d / 2 - 2.4, k * 0.5), segs=10)
            c.g.sphere(0.13, "gold", T(cx + x, cy - d / 2 - 2.4, 3.05), segs=8, rings=5)
    if s.has("pots"):
        for k in range(c.rng.randint(2, 4)):
            x = cx + c.rng.uniform(-w / 2 + 0.4, w / 2 - 0.4)
            pot(c, x, cy - d / 2 - c.rng.uniform(0.4, 0.9), 0.0, c.rng.uniform(0.25, 0.42))
    if s.has("textiles") and c.chance(0.8):
        for k in range(2):
            x = -w / 4 + k * w / 2
            c.g.rbox((1.0, 0.04, 1.4), "cloth_a" if k == 0 else "cloth_b", front @ T(x, -0.18, min(H - 0.5, 2.8) - 0.7) @ RX(-6), 0.02, 1)
            for j in range(4):
                c.g.box((1.0, 0.05, 0.08), "accent" if j % 2 else "cloth_b", front, (x, -0.21, min(H - 0.5, 2.8) - 0.3 - j * 0.3))
    if s.has("wings"):
        for side in (-1, 1):
            for k in range(5):
                c.g.rbox((0.9 - k * 0.12, 0.05, 0.12), "gold", front @ T(side * (0.45 + k * 0.08), -0.12, min(H - 0.4, 3.3) - k * 0.16) @ RY(side * (12 + k * 8)), 0.03, 1)
    if s.has("bone_ribs") and rise > 0:
        bone_ribs(c, cx, cy, w, d, top, rise, ridge)
    if s.has("tufts"):
        for k in range(int((w + d) * 1.2)):
            a = c.rng.uniform(0, 2 * math.pi)
            x = cx + (w / 2 + 0.5) * max(-1, min(1, math.cos(a) * 1.4))
            y = cy + (d / 2 + 0.5) * max(-1, min(1, math.sin(a) * 1.4))
            c.g.inst("tuft|leaf%s" % c.rng.choice(["", "~3", "~4"]), T(x, y, 0) @ RZ(c.rng.uniform(0, 360)))


def gear(c, m, x, z, r):
    g = c.g
    mm = m @ T(x, -0.1, z) @ RX(90)
    g.cylinder(r, 0.12, "metal", mm, segs=28, bevel=0.03)
    g.cylinder(r * 0.3, 0.2, "metal~1", mm @ T(0, 0, -0.04), segs=16, bevel=0.03)
    n = max(8, int(r * 22))
    for k in range(n):
        g.rbox((0.12, 0.12, 0.14), "metal", mm @ RZ(360 * k / n) @ T(r + 0.04, 0, 0.06), 0.02, 1)
    for k in range(4):
        g.rbox((r * 1.6, 0.08, 0.1), "metal~1", mm @ RZ(45 * k) @ T(0, 0, 0.1), 0.02, 1)


def pipes(c, m, L, H):
    g = c.g
    for k, x in enumerate((-L / 2 + 0.6, -L / 2 + 1.0)):
        g.cylinder(0.09, H + 0.6, "metal~1" if k else "roof_b", m @ T(x, -0.22, 0), segs=12, bevel=0.02)
        for zz in (0.8, H * 0.5, H - 0.2):
            g.rbox((0.3, 0.3, 0.08), "metal", m, 0.02, 1, (x, -0.2, zz))
        g.sphere(0.13, "metal", m @ T(x, -0.22, H + 0.6), segs=10, rings=6)
        g.cylinder(0.09, 0.8, "metal~1" if k else "roof_b", m @ T(x, -0.22, H + 0.6) @ RX(-90) @ T(0, 0, -0.8), segs=12)
    g.sphere(0.35, "metal~2", m @ T(-L / 2 + 0.8, -0.45, 0.6), segs=14, rings=8)  # a boiler drum


def flag_line(c, a, b, prayer):
    g = c.g
    ax, ay, az = a
    bx, by, bz = b
    n = int(math.dist(a, b) / 0.45)
    if prayer:
        g.cylinder(0.06, bz + 0.6, "trim", T(bx, by, 0), segs=8)
    cols = ["cloth_a", "cloth_b", "accent", "flower_c", "flower_d"]
    for k in range(1, n):
        t = k / n
        x, y = ax + (bx - ax) * t, ay + (by - ay) * t
        z = az + (bz - az) * t - math.sin(math.pi * t) * 0.6
        yaw = math.degrees(math.atan2(by - ay, bx - ax))
        if prayer:
            g.rbox((0.3, 0.02, 0.26), cols[k % len(cols)], T(x, y, z - 0.15) @ RZ(yaw), 0.01, 1)
        else:
            g.slab_poly([(-0.15, 0.0), (0.0, -0.3), (0.15, 0.0)], 0.02, cols[k % len(cols)], T(x, y, z) @ RZ(yaw))
    seg = int(n)
    for k in range(seg):
        t0, t1 = k / seg, (k + 1) / seg
        p0 = (ax + (bx - ax) * t0, ay + (by - ay) * t0, az + (bz - az) * t0 - math.sin(math.pi * t0) * 0.6)
        p1 = (ax + (bx - ax) * t1, ay + (by - ay) * t1, az + (bz - az) * t1 - math.sin(math.pi * t1) * 0.6)
        ln = math.dist(p0, p1)
        yaw = math.degrees(math.atan2(p1[1] - p0[1], p1[0] - p0[0]))
        pitch = math.degrees(math.asin(max(-1, min(1, (p1[2] - p0[2]) / max(ln, 1e-6)))))
        g.box((ln, 0.015, 0.015), "trim", T(*[(u + v) / 2 for u, v in zip(p0, p1)]) @ RZ(yaw) @ RY(-pitch))


def webs(c, x, y, z):
    g = c.g
    for k in range(7):
        a = math.radians(200 + k * 12)
        ln = c.rng.uniform(1.0, 2.2)
        g.cylinder(0.012, ln, "snow", T(x, y, z) @ RZ(math.degrees(a)) @ RY(90 + c.rng.uniform(10, 50)), segs=4)
    for k in range(3):
        g.lathe([(0.3 + k * 0.35, -0.01), (0.31 + k * 0.35, 0.0), (0.3 + k * 0.35, 0.01)], "snow", T(x, y, z - 0.3 - k * 0.1) @ RX(70), segs=8, cap_bottom=False, cap_top=False)


def net(c, m, L, H):
    g = c.g
    x0, w, h, z0 = -L / 4, 2.0, 1.6, 0.7
    for k in range(11):
        g.box((0.015, 0.02, h), "wall_a~1", m, (x0 - w / 2 + k * w / 10, -0.12, z0 + h / 2))
    for k in range(9):
        g.box((w, 0.02, 0.015), "wall_a~1", m, (x0, -0.12, z0 + k * h / 8))
    for k in range(4):
        g.sphere(0.07, "accent_b", m @ T(x0 - w / 2 + k * w / 3, -0.14, z0 + h), segs=8, rings=5)


def pot(c, x, y, z, s):
    c.g.lathe([(0.0, 0.0), (s * 0.6, 0.0), (s, s * 0.6), (s * 0.9, s * 1.2), (s * 0.55, s * 1.45), (s * 0.6, s * 1.6), (s * 0.45, s * 1.6)],
              c.rng.choice(["roof_b", "accent", "wall_d"]), T(x, y, z), segs=16, cap_top=False)


def bone_ribs(c, cx, cy, w, d, top, rise, ridge):
    g = c.g
    span = (d if ridge == "x" else w) / 2 + 0.8
    for k in range(3):
        off = (k - 1) * (w if ridge == "x" else d) * 0.3
        for j in range(12):
            a0, a1 = math.pi * j / 12, math.pi * (j + 1) / 12
            p0 = (span * math.cos(a0), (rise + 1.2) * math.sin(a0))
            p1 = (span * math.cos(a1), (rise + 1.2) * math.sin(a1))
            ln = math.dist(p0, p1)
            ang = math.degrees(math.atan2(p1[1] - p0[1], p1[0] - p0[0]))
            mid = ((p0[0] + p1[0]) / 2, (p0[1] + p1[1]) / 2)
            if ridge == "x":
                m = T(cx + off, cy + mid[0], top + mid[1]) @ RX(-ang) @ RZ(90)
            else:
                m = T(cx + mid[0], cy + off, top + mid[1]) @ RY(-ang)
            g.rbox((ln + 0.08, 0.28, 0.28), "trim", m, 0.12, 2)
