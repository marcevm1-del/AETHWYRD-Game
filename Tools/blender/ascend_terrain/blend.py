"""Blender side: turns TileData into a terrain mesh in the toon preview look (art_direction.md section 3.1), water, dressing, and a
preview render. Needs bpy (run with blender -b). Blender units are metres; a tile object sits at (x0, -(y0+size)) so tiles
placed in one scene line up (Blender y = -map y).

Preview look: painted sky + lawn disc (toon_preview.setup_world), Standard view transform, two-tone ramp with the violet
shadow tint (0.58 0.56 0.78) on every surface, cream rim on rock (0.22), inverted-hull ink on the dressing, outlines of the
tile as a diorama block (earth skirt), water as emission textures with a foam line and a pale shallow ring.
The saved .blend is true scale; only the picture may exaggerate (vertical stretch on flat tiles, dressing size on 10 km tiles).
"""
import math
import os
import time

import numpy as np

import bpy
from mathutils import Vector

import toon_preview as tp

from . import dressmesh as DM
from .dress import Sampler
from .noise import smoothstep
from .tile import srgb_to_linear, write_png

HAZE = (0.749, 0.851, 0.627)


def _hex(h):
    h = h.lstrip("#")
    return tuple(int(h[i:i + 2], 16) / 255.0 for i in (0, 2, 4))


_STATE = {}


def clear():
    for o in list(bpy.data.objects):
        bpy.data.objects.remove(o)
    for blk in (bpy.data.meshes, bpy.data.materials, bpy.data.curves, bpy.data.lights, bpy.data.cameras, bpy.data.worlds, bpy.data.images):
        for x in list(blk):
            blk.remove(x)
    for c in list(bpy.data.collections):
        bpy.data.collections.remove(c)


def material(name, rgb=(1, 1, 1), rough=0.95, alpha=1.0, vcol=None):
    m = bpy.data.materials.new(name)
    m.use_nodes = True
    nt = m.node_tree
    b = next(n for n in nt.nodes if n.type == "BSDF_PRINCIPLED")
    b.inputs["Base Color"].default_value = (*rgb, 1)
    b.inputs["Roughness"].default_value = rough
    if vcol:
        a = nt.nodes.new("ShaderNodeAttribute")
        a.attribute_name = vcol
        nt.links.new(a.outputs["Color"], b.inputs["Base Color"])
    return m


def emission_material(name, vcol="albedo", strength=1.0):
    """Unlit vertex-colour emission: lamps, windows, the lighthouse lamp keep their own hue."""
    m = bpy.data.materials.new(name)
    m.use_nodes = True
    nt = m.node_tree
    for n in list(nt.nodes):
        nt.nodes.remove(n)
    out = nt.nodes.new("ShaderNodeOutputMaterial")
    em = nt.nodes.new("ShaderNodeEmission")
    a = nt.nodes.new("ShaderNodeAttribute")
    a.attribute_name = vcol
    em.inputs["Strength"].default_value = strength
    nt.links.new(a.outputs["Color"], em.inputs["Color"])
    nt.links.new(em.outputs[0], out.inputs["Surface"])
    return m


def water_material(name, img):
    """Emission of an RGBA image: colour = painted water (pale shallow ring, foam line), alpha = coverage."""
    m = bpy.data.materials.new(name)
    m.use_nodes = True
    nt = m.node_tree
    for n in list(nt.nodes):
        nt.nodes.remove(n)
    N, L = nt.nodes, nt.links
    out = N.new("ShaderNodeOutputMaterial")
    tex = N.new("ShaderNodeTexImage")
    tex.image = img
    tex.interpolation = "Linear"
    tex.extension = "EXTEND"
    em = N.new("ShaderNodeEmission")
    tr = N.new("ShaderNodeBsdfTransparent")
    mix = N.new("ShaderNodeMixShader")
    L.new(tex.outputs["Color"], em.inputs["Color"])
    L.new(tex.outputs["Alpha"], mix.inputs["Fac"])
    L.new(tr.outputs[0], mix.inputs[1])
    L.new(em.outputs[0], mix.inputs[2])
    L.new(mix.outputs[0], out.inputs["Surface"])
    try:
        m.surface_render_method = "BLENDED"
    except (AttributeError, TypeError):
        pass
    return m


def _mesh(name, verts, faces):
    me = bpy.data.meshes.new(name)
    me.from_pydata([tuple(v) for v in verts], [], [tuple(f) for f in faces])
    return me


def vcol_mesh(name, V, F, C, coll=None):
    """Mesh from numpy arrays with a POINT linear vertex colour 'albedo' (C is sRGB 0-1)."""
    me = bpy.data.meshes.new(name)
    me.vertices.add(len(V))
    me.vertices.foreach_set("co", np.asarray(V, dtype=np.float32).ravel())
    F = np.asarray(F)
    tris = F.shape[1] == 3
    k = F.shape[1]
    me.loops.add(len(F) * k)
    me.loops.foreach_set("vertex_index", F.astype(np.int32).ravel())
    me.polygons.add(len(F))
    me.polygons.foreach_set("loop_start", (np.arange(len(F)) * k).astype(np.int32))
    me.polygons.foreach_set("use_smooth", np.ones(len(F), dtype=bool))
    me.update(calc_edges=True)
    ca = me.color_attributes.new("albedo", "FLOAT_COLOR", "POINT")
    rgba = np.concatenate([srgb_to_linear(np.clip(C, 0, 1)), np.ones((len(C), 1))], 1).astype(np.float32)
    ca.data.foreach_set("color", rgba.ravel())
    return me


# ----------------------------------------------------------------------------------------------------------------
# Materials per scene

def make_mats(rim):
    tp.RIM["terrain"] = rim
    base = material("TerrainBase", vcol="albedo")
    mats = {
        "terrain": tp.toon_material(base, "terrain"),
        "toon": tp.toon_material(material("DressBase", vcol="albedo"), "dress"),
        "ink": tp.outline_material(material("InkBase", vcol="albedo")),
        "glow": emission_material("Glow"),
    }
    mats["decal"] = mats["toon"]
    return mats


# ----------------------------------------------------------------------------------------------------------------
# Terrain, skirt, ground disc

def add_terrain(t, exag, mats):
    s = t.spec
    n = s.n
    jj, ii = np.meshgrid(np.arange(n), np.arange(n), indexing="ij")
    x = ii * float(s.res_m)
    y = (n - 1 - jj) * float(s.res_m)
    verts = np.stack([x, y, t.h * exag], -1).reshape(-1, 3).astype(np.float32)
    idx = np.arange(n * n).reshape(n, n)
    q = np.stack([idx[1:, :-1], idx[1:, 1:], idx[:-1, 1:], idx[:-1, :-1]], -1).reshape(-1, 4)   # counter-clockwise seen from above
    me = bpy.data.meshes.new("Terrain_" + s.name)
    me.vertices.add(len(verts))
    me.vertices.foreach_set("co", verts.ravel())
    me.loops.add(len(q) * 4)
    me.loops.foreach_set("vertex_index", q.astype(np.int32).ravel())
    me.polygons.add(len(q))
    me.polygons.foreach_set("loop_start", (np.arange(len(q)) * 4).astype(np.int32))
    me.polygons.foreach_set("use_smooth", np.ones(len(q), dtype=bool))
    me.update(calc_edges=True)
    ca = me.color_attributes.new("albedo", "FLOAT_COLOR", "POINT")
    rgba = np.concatenate([srgb_to_linear(t.albedo).reshape(-1, 3), np.ones((n * n, 1))], 1).astype(np.float32)
    ca.data.foreach_set("color", rgba.ravel())
    cs = me.color_attributes.new("splat", "FLOAT_COLOR", "POINT")        # R veg, G rock, B sand, A snow
    cs.data.foreach_set("color", t.splat.reshape(-1, 4).astype(np.float32).ravel())
    me.materials.append(mats["terrain"])
    o = bpy.data.objects.new("Terrain_" + s.name, me)
    o.location = (s.x0_m, -(s.y0_m + s.size_m), 0.0)
    bpy.context.scene.collection.objects.link(o)
    o["tile_name"] = s.name
    o["tile_x0_km"], o["tile_y0_km"], o["tile_size_km"], o["resolution_m"] = s.x0_km, s.y0_km, s.size_m / 1000.0, s.res_m
    o["height_sha256"] = t.sha256
    return o


def base_level(t):
    """Height of the diorama block's underside: sea level on coastal tiles, else a little under the lowest ground."""
    if (t.h < 0).any():
        return 0.0
    rng = float(t.h.max() - t.h.min())
    return float(t.h.min()) - max(6.0, 0.03 * rng)


def add_skirt(t, exag, mats, z0):
    """Earth sides of the tile: horizontal strata bands (same absolute heights on every side) under a turf strip, only where
    there is ground above sea level (a coastal tile has no skirt on its sea sides)."""
    s = t.spec
    n = s.n
    res = float(s.res_m)
    edges = [t.h[0, :], t.h[:, -1], t.h[-1, ::-1], t.h[::-1, 0]]
    pos = [lambda i: (i * res, (n - 1) * res), lambda i: ((n - 1) * res, (n - 1 - i) * res), lambda i: ((n - 1 - i) * res, 0.0), lambda i: (0.0, i * res)]
    earth = [np.array(_hex(c)) for c in ("#8A6A4A", "#7A5B40", "#9B7C58", "#6F5239", "#A58A6A", "#6B5A52", "#B09474", "#5E4A44")]
    turf = np.array(_hex("#7CB45A"))
    zmax = float(max(e.max() for e in edges))
    nb = int(np.clip(math.ceil((zmax - z0) / 40.0), 3, 14))
    rs = np.random.RandomState(int(abs(hash(s.name)) % 1000) if False else 5)
    th = rs.uniform(0.45, 1.8, nb)                         # uneven layer thickness, wavy and slanting boundaries, colours not in a cycle
    levels = z0 + (zmax - z0) * np.concatenate([[0], np.cumsum(th)]) / th.sum()
    thick = np.diff(levels)
    pick = rs.randint(0, len(earth), nb)
    for i in range(1, nb):
        if pick[i] == pick[i - 1]:
            pick[i] = (pick[i] + 3) % len(earth)
    wph = rs.uniform(0, 6.28, (nb + 1, 2))

    def lv(k, px, py):
        if k == 0 or k == nb:
            return levels[k]
        lim = 0.42 * min(thick[k - 1], thick[k])
        w = math.sin(px * 0.0021 + wph[k, 0]) * 0.6 + math.sin(py * 0.0034 + px * 0.0011 + wph[k, 1]) * 0.4
        return levels[k] + lim * w
    V, F, C = [], [], []

    def quad(xa, ya, xb, yb, za0, za1, zb0, zb1, col):
        b = len(V)
        V.extend([(xa, ya, za0 * exag), (xb, yb, zb0 * exag), (xb, yb, zb1 * exag), (xa, ya, za1 * exag)])
        F.append((b, b + 1, b + 2, b + 3))
        C.extend([col] * 4)
    for e, pf in zip(edges, pos):
        for i in range(n - 1):
            ha, hb = max(float(e[i]), z0), max(float(e[i + 1]), z0)
            if max(float(e[i]), float(e[i + 1])) < 0.3 and z0 >= 0.0:
                continue
            (xa, ya), (xb, yb) = pf(i), pf(i + 1)
            ta, tb = ha - min(2.5, (ha - z0) * 0.5), hb - min(2.5, (hb - z0) * 0.5)
            for k in range(nb):
                a0, a1 = min(max(lv(k, xa, ya), z0), ta), min(max(lv(k + 1, xa, ya), z0), ta)
                b0, b1 = min(max(lv(k, xb, yb), z0), tb), min(max(lv(k + 1, xb, yb), z0), tb)
                if a1 - a0 < 1e-6 and b1 - b0 < 1e-6:
                    continue
                quad(xa, ya, xb, yb, a0, a1, b0, b1, earth[pick[k]])
            quad(xa, ya, xb, yb, ta, ha, tb, hb, turf)
    if not F:
        return None
    me = vcol_mesh("Skirt_" + s.name, np.array(V), np.array(F), np.array(C))
    me.polygons.foreach_set("use_smooth", np.zeros(len(F), dtype=bool))
    me.materials.append(mats["terrain"])
    o = bpy.data.objects.new("Skirt_" + s.name, me)
    o.location = (s.x0_m, -(s.y0_m + s.size_m), 0.0)
    bpy.context.scene.collection.objects.link(o)
    return o


def land_palette(tiles):
    """Ground disc / haze colours that contrast with the tile (never the ground's own hue): warm stone under green tiles,
    dusty blue under sand, pale lavender under mountains."""
    alb = np.concatenate([t.albedo.reshape(-1, 3) for t in tiles]).mean(0)
    rng = max(float(t.h.max() - t.h.min()) for t in tiles)
    sandy = alb[0] > alb[1] * 1.05 and alb[0] > 0.7
    if sandy:
        return [_hex(c) for c in ("#8FA3BA", "#9DB0C4", "#B3C3D2", "#C6D2DC", "#D2DADF")]
    if rng > 600:
        return [_hex(c) for c in ("#D4CCDE", "#DAD3E3", "#E1DCE9", "#E6E2EC", "#E8E5EE")]
    return [_hex(c) for c in ("#D8CDB4", "#DDD3BC", "#E3DBC8", "#E6E0D2", "#E8E4DA")]


def add_plinth(tiles, mats, z0):
    """A dark stratified plinth under the diorama block (a ledge round the tile) so the tile pops off the ground disc."""
    x0 = min(t.spec.x0_m for t in tiles)
    x1 = max(t.spec.x0_m + t.spec.size_m for t in tiles)
    y0 = -max(t.spec.y0_m + t.spec.size_m for t in tiles)
    y1 = -min(t.spec.y0_m for t in tiles)
    size = max(x1 - x0, y1 - y0)
    m, ph = 0.022 * size, 0.022 * size
    x0, x1, y0, y1 = x0 - m, x1 + m, y0 - m, y1 + m
    zt, zb = z0 - 0.3, z0 - 0.3 - ph
    bands = [_hex(c) for c in ("#5A4D66", "#463C55", "#6A5B72", "#3E3550", "#52465F")]
    rng = np.random.RandomState(7)
    cuts = np.sort(rng.uniform(0.15, 0.9, 3))
    levels = [zt] + [zt - c * ph for c in cuts] + [zb]
    V, F, C = [], [], []

    def quad(a, b, za0, za1, zb0, zb1, col):
        k = len(V)
        V.extend([(a[0], a[1], za0), (b[0], b[1], zb0), (b[0], b[1], zb1), (a[0], a[1], za1)])
        F.append((k, k + 1, k + 2, k + 3))
        C.extend([col] * 4)
    corners = [(x0, y0), (x1, y0), (x1, y1), (x0, y1)]
    for e in range(4):
        a, b = corners[e], corners[(e + 1) % 4]
        L = math.hypot(b[0] - a[0], b[1] - a[1])
        n = max(2, int(L / (0.04 * size)))
        for i in range(n):
            pa = (a[0] + (b[0] - a[0]) * i / n, a[1] + (b[1] - a[1]) * i / n)
            pb = (a[0] + (b[0] - a[0]) * (i + 1) / n, a[1] + (b[1] - a[1]) * (i + 1) / n)
            for k in range(4):
                wob = lambda p, kk: 0.06 * ph * math.sin(p[0] * 0.0021 + p[1] * 0.0017 + kk * 2.3) * (kk > 0)
                quad(pa, pb, levels[k] + wob(pa, k), levels[k + 1] + wob(pa, k + 1), levels[k] + wob(pb, k), levels[k + 1] + wob(pb, k + 1), bands[(k * 2 + e) % 5])
    top = [(x0, y0, zt), (x1, y0, zt), (x1, y1, zt), (x0, y1, zt)]
    k = len(V)
    V.extend(top)
    F.append((k, k + 1, k + 2, k + 3))
    C.extend([_hex("#7A6C84")] * 4)
    me = vcol_mesh("Plinth", np.array(V), np.array(F), np.array(C))
    me.polygons.foreach_set("use_smooth", np.zeros(len(F), dtype=bool))
    me.materials.append(mats["toon"])
    o = bpy.data.objects.new("Plinth", me)
    bpy.context.scene.collection.objects.link(o)
    import bmesh
    bm = bmesh.new()
    bm.from_mesh(me)
    bmesh.ops.recalc_face_normals(bm, faces=bm.faces)
    bm.to_mesh(me)
    bm.free()
    return o, ph


def add_disc(t, mats, z0, radius_mult=3.0, ocean=False, pal=None):
    """Lawn disc 3x the subject: #8CC860 fading to #A8D47A at the rim and on to the haze at the horizon."""
    s = t.spec
    cx, cy = s.x0_m + s.size_m / 2, -(s.y0_m + s.size_m / 2)
    R = s.size_m * 25.0
    rings = [s.size_m * 0.6, s.size_m * 0.9, s.size_m * 1.4, s.size_m * 3.0, R]
    cols = [_hex("#8CC860"), _hex("#98CF6A"), _hex("#A8D47A"), tuple(np.array(_hex("#A8D47A")) * 0.5 + np.array(HAZE) * 0.5), HAZE]
    if pal is not None and not ocean:
        cols = list(pal)
    if ocean:           # a coastal tile stands in the sea: the same disc, painted as deep water fading to the horizon haze
        cols = [_hex("#3E97C2"), _hex("#3E97C2"), _hex("#4A9FC8"), _hex("#7DB8CF"), _hex("#B6D8D8")]
    seg = 64
    V, F, C = [(cx, cy, z0)], [], [cols[0]]
    for r, c in zip(rings, cols):
        for i in range(seg):
            a = i / seg * 2 * math.pi
            V.append((cx + r * math.cos(a), cy + r * math.sin(a), z0))
            C.append(c)
    for i in range(seg):
        F.append((0, 1 + i, 1 + (i + 1) % seg))
    for k in range(len(rings) - 1):
        a0, a1 = 1 + k * seg, 1 + (k + 1) * seg
        for i in range(seg):
            j = (i + 1) % seg
            F.append((a0 + i, a1 + i, a1 + j))
            F.append((a0 + i, a1 + j, a0 + j))
    me = vcol_mesh("Disc", np.array(V), np.array(F), np.array(C))
    me.materials.append(mats["terrain"])
    me.polygons.foreach_set("use_smooth", np.zeros(len(F), dtype=bool))
    o = bpy.data.objects.new("Disc", me)
    # faces were wound counter-clockwise seen from below for some of them: make every face point up
    bpy.context.scene.collection.objects.link(o)
    import bmesh
    bm = bmesh.new()
    bm.from_mesh(me)
    bmesh.ops.recalc_face_normals(bm, faces=bm.faces)
    for f in bm.faces:
        if f.normal.z < 0:
            f.normal_flip()
    bm.to_mesh(me)
    bm.free()
    return o


# ----------------------------------------------------------------------------------------------------------------
# Water: textured planes (soft edges, foam line, pale shallow ring)

def upsample(A, f):
    A = A.astype(np.float32)
    if f == 1:
        return A
    n, m = A.shape
    xi = np.arange((m - 1) * f + 1, dtype=np.float32) / f
    yi = np.arange((n - 1) * f + 1, dtype=np.float32) / f
    x0 = np.clip(np.floor(xi).astype(int), 0, m - 2)
    y0 = np.clip(np.floor(yi).astype(int), 0, n - 2)
    tx, ty = xi - x0, yi - y0
    R = A[:, x0] * (1 - tx)[None, :] + A[:, x0 + 1] * tx[None, :]
    return R[y0, :] * (1 - ty)[:, None] + R[y0 + 1, :] * ty[:, None]


def _ramp(d, stops):
    xs = np.array([s[0] for s in stops], dtype=np.float32)
    out = np.zeros(d.shape + (3,), dtype=np.float32)
    for c in range(3):
        out[..., c] = np.interp(d, xs, [s[1][c] for s in stops])
    return out


SEA_STOPS = [(0.0, _hex("#F6FFFB")), (0.35, _hex("#E4FAF1")), (1.0, _hex("#BDF0DE")), (4.0, _hex("#92E0D3")), (14.0, _hex("#63C5CF")),
             (60.0, _hex("#47A7C9")), (250.0, _hex("#3687BC")), (900.0, _hex("#2B69A3"))]
LAKE_STOPS = [(0.0, _hex("#F2FDFB")), (0.25, _hex("#D8F5EC")), (0.9, _hex("#B0E8DB")), (3.0, _hex("#84D6D2")), (12.0, _hex("#5BB8CF")), (60.0, _hex("#3F95C0"))]


def _quad(name, x0, y0, x1, y1, z, mat, loc):
    me = _mesh(name, [(x0, y0, z), (x1, y0, z), (x1, y1, z), (x0, y1, z)], [(0, 1, 2, 3)])
    uv = me.uv_layers.new(name="UVMap")
    for li, (u, v) in enumerate(((0, 0), (1, 0), (1, 1), (0, 1))):
        uv.data[li].uv = (u, v)
    me.materials.append(mat)
    o = bpy.data.objects.new(name, me)
    o.location = loc
    bpy.context.scene.collection.objects.link(o)
    return o


def _load_rgba(rgb, alpha, path):
    img8 = np.concatenate([np.clip(rgb * 255 + 0.5, 0, 255).astype(np.uint8), np.clip(alpha * 255 + 0.5, 0, 255).astype(np.uint8)[..., None]], -1)
    write_png(path, img8, level=3)
    img = bpy.data.images.load(path)
    img.colorspace_settings.name = "sRGB"
    try:
        img.alpha_mode = "STRAIGHT"
    except TypeError:
        pass
    return img


DELTA_WATER = _hex("#7FB3D0")


def delta_fields(X, Y, dl):
    """Soft fields of a river mouth in world metres: (sand fan, distributary channels, foam rim, sediment plume), each 0..1."""
    from . import noise
    vx, vy = X - dl["x"], Y - dl["y"]
    al = vx * dl["dx"] + vy * dl["dy"]
    ac = -vx * dl["dy"] + vy * dl["dx"]
    r = np.hypot(al, ac)
    ang = np.arctan2(ac, np.maximum(al, 1e-3))
    ph = (dl["x"] * 0.013 + dl["y"] * 0.007) % 6.28
    Rf = (300.0 + 40.0 * noise.fbm(X, Y, 180.0, 2, 411)) * (1.0 + 0.14 * np.sin(ang * 7.0 + ph))
    half = 0.95 * (0.35 + 0.65 * np.clip(r / 300.0, 0, 1))
    side = 1.0 - smoothstep(0.72, 1.0, np.abs(ang) / half)
    fan = (1.0 - smoothstep(0.80 * Rf, Rf, r)) * side * smoothstep(-60.0, 0.0, al)
    chan = np.zeros_like(fan)
    wch0 = max(14.0, dl["hw"] * 1.7)
    for k, a in enumerate((-0.52, 0.0, 0.52)):
        lat = ac - (al * math.tan(a) + 16.0 * np.sin(al * 0.017 + k * 2.1 + ph))
        wch = wch0 * (1.25 - 0.9 * np.clip(al / 360.0, 0, 1)) * (1.0 if a == 0.0 else 0.62)
        c = (1.0 - smoothstep(0.55 * wch, 1.25 * wch, np.abs(lat))) * smoothstep(-200.0, -60.0, al) * (1.0 - smoothstep(0.8, 1.0, al / (0.95 * Rf)))
        chan = np.maximum(chan, c)
    foam = np.exp(-((r - Rf) / 16.0) ** 2) * side * smoothstep(-20.0, 40.0, al) * 0.9
    plume = smoothstep(-60.0, 60.0, al) * (1 - smoothstep(0.0, 700.0, al)) * (1 - smoothstep(0.0, 1.0, np.abs(ac) / (140.0 + 0.55 * np.maximum(al, 0))))
    return fan.astype(np.float32), chan.astype(np.float32), foam.astype(np.float32), plume.astype(np.float32)


def paint_deltas(t, deltas):
    """Land half of the mouth in the terrain albedo: the sand fan merges into the beach colour, channels are pale desaturated water."""
    if not deltas:
        return
    for dl in deltas:
        fan, chan, foam, plume = delta_fields(t.X, t.Y, dl)
        land = smoothstep(-0.3, 0.6, t.h) * (1 - smoothstep(5.0, 9.0, t.h))
        sand = np.array(_hex("#E6D6A4"))
        w = (fan * land)[..., None] * 0.9
        t.albedo = t.albedo * (1 - w) + sand * w
        wc = (chan * land)[..., None] * 0.85
        t.albedo = t.albedo * (1 - wc) + np.array(DELTA_WATER) * wc


def add_sea(t, outdir, deltas=()):
    """The sea as one big textured plane at 0 m: opaque over the tile (land hides it), soft-edged beyond the tile where the
    coast continues, so there is no slab edge. Painted depth ramp, foam line, a second faint foam line, sediment at river mouths."""
    s = t.spec
    if not (t.h < 0).any():
        return None
    res = float(s.res_m)
    ext = 0.8 * s.size_m
    pad = int(round(ext / res))
    fac = 2 if s.size_m > 4000 else 4
    Hp = np.pad(t.h.astype(np.float32), pad, mode="edge")
    Hu = upsample(Hp, fac)
    N = Hu.shape[0]
    px = res / fac
    inside = np.zeros(Hu.shape, dtype=bool)
    i0, i1 = pad * fac, (pad + s.n - 1) * fac
    inside[i0:i1 + 1, i0:i1 + 1] = True
    ar = np.arange(N, dtype=np.float32)
    dx = np.maximum(np.maximum(i0 - ar, ar - i1), 0)
    dist = np.hypot(dx[None, :], dx[:, None]) * px
    d = -Hu
    d = np.where(inside, d, np.maximum(d, 3.0 + 0.02 * dist))        # beyond the tile: never land stripes or foam, a pale-to-deep ramp
    rgb = _ramp(np.maximum(d, 0), SEA_STOPS)
    line2 = smoothstep(1.4, 1.7, d) * (1 - smoothstep(1.9, 2.2, d)) * 0.55
    rgb = rgb + (1 - rgb) * line2[..., None]
    for dl in deltas:                       # river mouth: a lobed sand fan with soft channels and foam, painted into the sea texture
        gx = (dl["x"] - s.x0_m + pad * res) / px
        gy = (dl["y"] - s.y0_m + pad * res) / px
        R = 720.0 / px
        j0, j1 = int(max(gy - R, 0)), int(min(gy + R, N))
        i0, i1 = int(max(gx - R, 0)), int(min(gx + R, N))
        jj, ii = np.mgrid[j0:j1, i0:i1]
        WX = s.x0_m + (ii - pad * fac) * px
        WY = s.y0_m + (jj - pad * fac) * px
        fan, chan, foam, plume = delta_fields(WX, WY, dl)
        dd = d[j0:j1, i0:i1]
        water = (dd > 0)
        shallow = smoothstep(14.0, 4.0, dd)
        sub = rgb[j0:j1, i0:i1]
        pl = (plume * water)[..., None]
        sub = sub * (1 - 0.30 * pl) + np.array(_hex("#A9D1D8"), dtype=np.float32) * 0.30 * pl
        wf = (fan * shallow * water)[..., None]
        sub = sub * (1 - 0.92 * wf) + np.array(_hex("#E6D6A4"), dtype=np.float32) * 0.92 * wf
        wc = (chan * fan * water)[..., None]
        sub = sub * (1 - 0.8 * wc) + np.array(_hex("#8CC2DC"), dtype=np.float32) * 0.8 * wc
        wfo = (foam * water)[..., None]
        sub = sub + (1 - sub) * 0.75 * wfo
        rgb[j0:j1, i0:i1] = sub
    fade = 0.25 * ext / px                       # the outer quarter of the extension blends into the ocean disc: no visible plane edge
    edge = np.minimum(np.minimum(ar[None, :], N - 1 - ar[None, :]), np.minimum(ar[:, None], N - 1 - ar[:, None]))
    alpha = smoothstep(0.0, fade, edge).astype(np.float32)
    img = _load_rgba(rgb, alpha, os.path.join(outdir, s.name + "_sea.png"))
    S = s.size_m
    o = _quad("Sea_" + s.name, -ext, -ext, S + ext, S + ext, 0.0, water_material("Sea", img), (s.x0_m, -(s.y0_m + s.size_m), 0.0))
    return o


def add_lakes(t, outdir):
    s = t.spec
    res = float(s.res_m)
    n = s.n
    out = []
    surfaces = sorted(set(round(float(v), 2) for v in t.lake_s[t.lake_m > 0.35]))
    for k, S in enumerate(surfaces):
        sel = (t.lake_m > 0.3) & (np.abs(t.lake_s - S) < 0.01)
        js, is_ = np.nonzero(sel)
        if len(js) == 0:
            continue
        j0, j1 = max(js.min() - 4, 0), min(js.max() + 5, n)
        i0, i1 = max(is_.min() - 4, 0), min(is_.max() + 5, n)
        f = 4
        Hh = upsample(t.h[j0:j1, i0:i1], f)
        Lm = upsample(t.lake_m[j0:j1, i0:i1], f)
        Ls = upsample(t.lake_s[j0:j1, i0:i1], f)
        d = S - Hh
        cover = smoothstep(-0.05, 0.35, d) * smoothstep(0.2, 0.36, Lm) * (np.abs(Ls - S) < 0.6)
        if cover.max() < 0.1:
            continue
        rgb = _ramp(np.maximum(d, 0), LAKE_STOPS)
        img = _load_rgba(rgb, cover, os.path.join(outdir, "%s_lake%d.png" % (s.name, k)))
        x0, x1 = i0 * res, (i1 - 1) * res
        y_hi, y_lo = (n - 1 - j0) * res, (n - 1 - (j1 - 1)) * res
        out.append(_quad("Lake_%g_%s" % (S, s.name), x0, y_lo, x1, y_hi, S + 0.03, water_material("Lake", img), (s.x0_m, -(s.y0_m + s.size_m), 0.0)))
    return out


def add_rivers(t, mats, widen=1.0, deltas=()):
    s = t.spec
    if not t.rivers:
        return None
    verts, faces = [], []
    cols_all = []
    ymax = s.y0_m + s.size_m
    for r in t.rivers:
        inb = (r["P"][:, 0] >= s.x0_m) & (r["P"][:, 0] <= s.x0_m + s.size_m) & (r["P"][:, 1] >= s.y0_m) & (r["P"][:, 1] <= ymax)
        if inb.sum() < 2:
            continue
        P, ws, hw = r["P"][inb], r["ws"][inb], r["hw"][inb] * widen
        for dl in deltas:                   # stop the ribbon short of the mouth: the painted channel continues it, so it never ends in a square
            keep = np.hypot(P[:, 0] - dl["x"], P[:, 1] - dl["y"]) > 70.0
            if keep.sum() >= 2 and not keep.all():
                P, ws, hw = P[keep], ws[keep], hw[keep]
        colk = np.tile(np.array(_hex("#62B8D8")), (len(P), 1))
        sink = np.zeros(len(P))
        for dl in deltas:                   # flare and desaturate towards a mouth so the river opens into the fan instead of ending square
            dm = np.hypot(P[:, 0] - dl["x"], P[:, 1] - dl["y"])
            if dm.min() > 40.0:
                continue
            u = 1.0 - smoothstep(0.0, 380.0, dm)
            sink = np.maximum(sink, 2.6 * (1.0 - smoothstep(60.0, 330.0, dm)) ** 2)      # dips under the bank near the mouth: the ribbon fades out instead of stopping square
            hw = hw * (1.0 + 1.1 * u ** 2)
            colk = colk + (np.array(DELTA_WATER)[None, :] - colk) * smoothstep(0.0, 0.8, u)[:, None]
            colk = colk + (np.array(_hex("#A8C8CC"))[None, :] - colk) * smoothstep(0.82, 1.0, u)[:, None]
        cols_all.append(np.repeat(colk, 2, axis=0))
        for k in range(len(P)):
            a, b = P[max(0, k - 1)], P[min(len(P) - 1, k + 1)]
            d = b - a
            L = math.hypot(*d) or 1.0
            nx, ny = -d[1] / L, d[0] / L
            for sg in (-1, 1):
                px, py = P[k, 0] + sg * nx * hw[k], P[k, 1] + sg * ny * hw[k]
                verts.append((px - s.x0_m, ymax - py, ws[k] + 0.14 - sink[k]))
            if k:
                b0 = len(verts) - 4
                faces.append((b0, b0 + 1, b0 + 3, b0 + 2))
    if not faces:
        return None
    C = np.concatenate(cols_all) if cols_all else np.tile(np.array(_hex("#62B8D8")), (len(verts), 1))
    assert len(C) == len(verts)
    me = vcol_mesh("Rivers_" + s.name, np.array(verts), np.array(faces), C)
    me.materials.append(mats["decal"])
    o = bpy.data.objects.new("Rivers_" + s.name, me)
    o.location = (s.x0_m, -(s.y0_m + s.size_m), 0.0)
    bpy.context.scene.collection.objects.link(o)
    return o


# ----------------------------------------------------------------------------------------------------------------
# Scene

def preview_zscale(tiles, zscale=0.0):
    if zscale > 0:
        return zscale
    rng = max(float(t.h.max() - max(t.h.min(), 0.0)) for t in tiles)
    return float(np.clip(1000.0 / max(rng, 1.0), 1.5, 3.5))


def dress_factors(tiles):
    """(k, kb): picture-only size of trees/rocks and of buildings. 1 on close-ups, up to 5 / 6 on 10 km tiles (a 7 m tree is a pixel)."""
    km = max(t.spec.size_m for t in tiles) / 1000.0
    k = float(np.clip((km - 1.5) * 0.6, 1.0, 5.0)) if km > 3.0 else (1.8 if km > 1.5 else 1.0)
    return k, k * 1.2 if km > 3.0 else k * 1.4


def build_scene(tiles, exag=1.0, outdir=".", dressings=None, zs=1.0, k=1.0, kb=1.0, res=(1600, 900), sun_az=None):
    """tiles: list of TileData (1 or 2). dressings: list of Dressing (same order) or None."""
    clear()
    sc = bpy.context.scene
    sea_tile = any((t.h < 0).mean() > 0.03 for t in tiles)
    haze0 = tp.HAZE
    pal = None
    if sea_tile:
        tp.HAZE = tp.lin("#B6D8D8")              # a coastal tile: the world below the horizon is sea haze, not lawn haze
    else:
        pal = land_palette(tiles)
        tp.HAZE = tp.lin("#%02X%02X%02X" % tuple(int(v * 255 + 0.5) for v in pal[-1]))
    tp.setup_world(sc)
    tp.HAZE = haze0
    sun = bpy.data.objects.get(tp.PREFIX + "Sun")
    to_ground = Vector((0.85, 0.5, -0.95)).normalized()      # light travels from the west-south-west, fairly high: lit side faces the camera
    sun.rotation_euler = to_ground.to_track_quat("-Z", "Y").to_euler()
    mountainous = max(float(t.h.max() - t.h.min()) for t in tiles) > 600.0
    mats = make_mats(0.22 if mountainous else 0.0)
    km = max(t.spec.size_m for t in tiles)
    pxm = km * 1.35 / res[0]
    coll = bpy.data.collections.new("Dressing")
    sc.collection.children.link(coll)
    objs = []
    z0 = min(base_level(t) for t in tiles)
    for i, t in enumerate(tiles):
        dl = dressings[i].deltas if dressings else ()
        if dl and not getattr(t, "_delta_painted", False):
            paint_deltas(t, dl)
            t._delta_painted = True
        objs.append(add_terrain(t, exag, mats))
        add_skirt(t, exag, mats, z0)
        add_sea(t, outdir, dl)
        add_lakes(t, outdir)
        add_rivers(t, mats, widen=1.0 + 0.3 * (k - 1.0), deltas=dl)
    zd = z0 - 0.4
    if pal is not None:
        _, ph = add_plinth(tiles, mats, z0)
        zd = z0 - 0.3 - ph - 0.1
        _STATE["plinth"] = ph
    else:
        _STATE["plinth"] = 0.0
    add_disc(tiles[0], dict(mats, terrain=mats["toon"]), zd, ocean=sea_tile, pal=pal)
    _STATE.update(mats=mats, coll=coll, pxm=pxm)
    stats = {}
    if dressings:
        for t, D in zip(tiles, dressings):
            _, st = DM.build(D, t, mats, coll, zs=zs, k=k, kb=kb, pxm=pxm)
            stats[t.spec.name] = st
    return sc, objs, stats


def rebuild_dressing(dressings, tiles, zs, k, kb):
    """Replace the dressing objects (e.g. true-scale for the saved .blend, or a close camera)."""
    remove_dressing()
    for o in [o for o in bpy.data.objects if o.name.startswith("Rivers_")]:          # rivers back to their true width
        bpy.data.objects.remove(o)
    for t, D in zip(tiles, dressings):
        add_rivers(t, _STATE["mats"], widen=1.0 + 0.3 * (k - 1.0), deltas=D.deltas if D else ())
    st = {}
    for t, D in zip(tiles, dressings):
        _, st[t.spec.name] = DM.build(D, t, _STATE["mats"], _STATE["coll"], zs=zs, k=k, kb=kb, pxm=_STATE["pxm"] * 0.02 if (k == 1.0 and kb == 1.0 and zs == 1.0) else _STATE["pxm"])
    return st


def remove_dressing():
    for o in [o for o in bpy.data.objects if o.name.startswith(DM.PREFIX)]:
        bpy.data.objects.remove(o)
    for m in [m for m in bpy.data.meshes if m.name.startswith(DM.PREFIX) and m.users == 0]:
        bpy.data.meshes.remove(m)


def fit_camera(sc, bbox, zr, yaw, pitch, lens, aspect, sky_deg=3.5):
    """Place a camera so the tile box fills the lower part of the frame and a band of painted sky shows above the horizon.
    bbox = (x0, y0, x1, y1) Blender metres, zr = (zmin, zmax). Returns the camera."""
    x0, y0, x1, y1 = bbox
    zmin, zmax = zr
    cen = Vector(((x0 + x1) / 2, (y0 + y1) / 2, (zmin + zmax) / 2))
    d = Vector((math.sin(math.radians(yaw)) * math.cos(math.radians(pitch)), -math.cos(math.radians(yaw)) * math.cos(math.radians(pitch)), math.sin(math.radians(pitch))))
    f = -d
    right = f.cross(Vector((0, 0, 1))).normalized()
    up = right.cross(f).normalized()
    th = 18.0 / lens
    tv = th / aspect
    top_req = math.tan(math.radians(pitch + sky_deg))
    pts = [Vector((x, y, z)) for x in (x0, x1) for y in (y0, y1) for z in (zmin, zmax)]
    D = (x1 - x0) * 0.5
    frame_top = top_req
    for _ in range(600):
        cam = cen + d * D
        us, vs = [], []
        for p in pts:
            r = p - cam
            zf = r.dot(f)
            if zf < 1.0:
                us.append(9.0)
                vs.append(9.0)
                continue
            us.append(r.dot(right) / zf)
            vs.append(r.dot(up) / zf)
        frame_bottom = min(vs) - 0.04 * 2 * tv
        frame_top = frame_bottom + 2 * tv
        if max(map(abs, us)) <= th * 0.95 and frame_top >= top_req:
            break
        D *= 1.01
        if D > (x1 - x0) * 4.0:                      # the sky band does not fit at this angle and lens: drop it rather than shrink the tile to a dot
            return fit_camera(sc, bbox, zr, yaw, pitch, lens, aspect, sky_deg=sky_deg - 2.0 if sky_deg > 2.5 else -90.0) if sky_deg > -80 else None
    shift = (frame_top - tv) / (2 * th)
    camd = bpy.data.cameras.new("Cam")
    cam_o = bpy.data.objects.new("Cam", camd)
    sc.collection.objects.link(cam_o)
    cam_o.location = cen + d * D
    cam_o.rotation_euler = f.to_track_quat("-Z", "Y").to_euler()
    camd.lens = lens
    camd.shift_y = shift
    camd.clip_start, camd.clip_end = 2.0, 400000.0
    sc.camera = cam_o
    return cam_o


def render(sc, tiles, path, res=(1600, 900), samples=24, yaw=-30.0, pitch=22.0, lens=22.0, zs=1.0, cam=None):
    """zs: vertical exaggeration for the picture only (terrain-bound objects are scaled in z; dressing was built stretched).
    cam: optional (location, target, lens) in Blender metres for a free camera instead of the fitted tile view."""
    x0 = min(t.spec.x0_m for t in tiles)
    x1 = max(t.spec.x0_m + t.spec.size_m for t in tiles)
    y0 = min(t.spec.y0_m for t in tiles)
    y1 = max(t.spec.y0_m + t.spec.size_m for t in tiles)
    meshes = [o for o in bpy.data.objects if o.type == "MESH" and not o.name.startswith(DM.PREFIX)]
    for o in meshes:
        o.scale.z = zs
    zmin = min(float(t.h.min()) for t in tiles)
    zmax = max(float(t.h.max()) for t in tiles)
    if cam is None:
        cam_o = fit_camera(sc, (x0, -y1, x1, -y0), ((min(base_level(t) for t in tiles) - _STATE.get("plinth", 0.0) - 1.0) * zs, zmax * zs), yaw, pitch, lens, res[0] / res[1])
    else:
        loc, tgt, ln = cam
        camd = bpy.data.cameras.new("Cam")
        cam_o = bpy.data.objects.new("Cam", camd)
        sc.collection.objects.link(cam_o)
        cam_o.location = Vector(loc)
        cam_o.rotation_euler = (Vector(tgt) - Vector(loc)).to_track_quat("-Z", "Y").to_euler()
        camd.lens = ln
        camd.clip_start, camd.clip_end = 0.3, 400000.0
        sc.camera = cam_o
    sc.render.resolution_x, sc.render.resolution_y = res
    sc.render.resolution_percentage = 100
    sc.render.image_settings.file_format = "PNG"
    try:
        sc.eevee.taa_render_samples = samples
    except AttributeError:
        pass
    sc.view_settings.view_transform = "Standard"
    sc.render.filepath = path
    t0 = time.time()
    bpy.ops.render.render(write_still=True)
    for o in meshes:
        o.scale.z = 1.0
    bpy.data.objects.remove(cam_o)
    return time.time() - t0


def save_blend(path):
    bpy.ops.wm.save_as_mainfile(filepath=path, compress=True)
