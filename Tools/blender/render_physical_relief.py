"""
3D relief renders of the physical world map (Data/World/physical_map.json, see 10_World/physical_geography.md).

blender -b --factory-startup -P Tools/blender/render_physical_relief.py -- --repo <repo>
        [--out-dir 10_World/maps] [--exag 5.5] [--blur 1.6] [--step 1] [--res 1920x1080] [--samples 32] [--only whole|heartland]

Builds the 0.5 km elevation grid as a displaced mesh (vertical exaggeration --exag, sea depths compressed further),
coloured per vertex by biome with the palette of physical_map.png (Tools/atlas/build_physical_map.js renderRelief),
plus altitude tints and region borders. Sea level is a translucent water plane at 0; lakes are water quads at their
surface height; rivers are thin blue ribbons along rivers[].path. One soft sun from the north-west. Writes
physical_relief_3d.png (oblique 3/4 view of the continent from the south) and physical_relief_heartland.png (a
closer view of Aldmere and Whisperwood). Deterministic: no random input. --step 2 halves the grid for speed.
Blender units: 1 = 1 km (x east, y north; map y runs south, so y_blender = -y_map).
"""
import argparse
import json
import math
import os
import sys
import time

import bpy
import numpy as np
from mathutils import Vector

argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
ap = argparse.ArgumentParser(prog="render_physical_relief")
ap.add_argument("--repo", required=True)
ap.add_argument("--out-dir", default="")
ap.add_argument("--exag", type=float, default=5.5)
ap.add_argument("--blur", type=float, default=1.6, help="Gaussian smoothing of the displayed heights, in cells")
ap.add_argument("--sea-exag", type=float, default=0.25, help="extra factor on sea depths (keeps coasts gentle)")
ap.add_argument("--step", type=int, default=1)
ap.add_argument("--res", default="1920x1080")
ap.add_argument("--samples", type=int, default=32)
ap.add_argument("--only", default="")
args = ap.parse_args(argv)
REPO = os.path.abspath(args.repo)
OUT = os.path.abspath(args.out_dir) if args.out_dir else os.path.join(REPO, "10_World", "maps")
RES = tuple(int(v) for v in args.res.lower().split("x"))

t0 = time.time()
D = json.load(open(os.path.join(REPO, "Data", "World", "physical_map.json"), encoding="utf-8"))
W, H, CK = D["grid"]["width"], D["grid"]["height"], D["grid"]["cellKm"]
elev = np.array(D["elevation"]["rows"], dtype=np.float64)          # (H, W) metres
biome = np.array([list(r) for r in D["biomes"]["rows"]])           # (H, W) chars
CODES = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"  # = REG_CH in build_physical_map.js
reg_rows = D["regions"]["rows"]
region = np.array([[CODES.find(c) if c != "." else -1 for c in r] for r in reg_rows], dtype=np.int32)
LEGEND = D["regions"]["legend"]
NAMES = {r["id"]: r["name"] for r in D["regionStats"]}
PAD = 120  # cells of sea added round the map (edge-replicated) so the sea runs past the frame


def blur(a, sigma):
    """Separable Gaussian blur with edge padding (deterministic, numpy only)."""
    if sigma <= 0:
        return a.copy()
    r = int(math.ceil(3 * sigma))
    k = np.exp(-0.5 * (np.arange(-r, r + 1) / sigma) ** 2)
    k /= k.sum()
    p = np.pad(a, r, mode="edge")
    p = np.apply_along_axis(lambda v: np.convolve(v, k, mode="valid"), 1, p)
    return np.apply_along_axis(lambda v: np.convolve(v, k, mode="valid"), 0, p)


# Displayed heights: smoothed so ranges read as massifs with ridges rather than cell-sized needles; the coastline
# is kept (land stays >= 2 m, sea <= -2 m).
ELEV = blur(elev, args.blur)
ELEV = np.where(elev >= 0, np.maximum(ELEV, 2.0), np.minimum(ELEV, -2.0))


def z_of(m):
    """Height in Blender units (km x exaggeration); sea depths are compressed a further sea_exag."""
    m = np.asarray(m, dtype=np.float64)
    return np.where(m >= 0, m, m * args.sea_exag) / 1000.0 * args.exag


def lin(c):
    c = np.asarray(c, dtype=np.float64) / 255.0
    return np.where(c <= 0.04045, c / 12.92, ((c + 0.055) / 1.055) ** 2.4)


def smooth(a, b, x):
    t = np.clip((x - a) / (b - a), 0, 1)
    return t * t * (3 - 2 * t)


# ---------------------------------------------------------------------------------------------------------------
# Palette (physical_map.png, Tools/atlas/build_physical_map.js renderRelief), sRGB 0-255
TINT = {"p": (196, 196, 140), "f": (128, 158, 104), "w": (140, 150, 112), "s": (214, 196, 140),
        "m": (176, 160, 132), "v": (150, 112, 96), "t": (222, 226, 220), "d": (232, 206, 150),
        "j": (110, 150, 98), "i": (150, 156, 180), "x": (150, 92, 96),
        "a": (200, 178, 132), "n": (246, 246, 240), "b": (226, 210, 166), "l": (120, 160, 176), "~": (120, 160, 176)}
RIVER = (63, 120, 150)      # #3f7896
SEA_SHALLOW, SEA_DEEP = (170, 196, 186), (92, 128, 140)


def colours():
    col = np.zeros((H, W, 3))
    for k, v in TINT.items():
        col[biome == k] = v
    land = elev >= 0
    hi1 = smooth(600, 1800, elev)[..., None] * 0.6
    hi2 = smooth(1800, 3000, elev)[..., None] * 0.7
    keep = np.isin(biome, ["n", "t"])[..., None]           # snow and tundra keep their own white
    col = np.where(keep, col, col + (np.array((200, 178, 132)) - col) * hi1)
    col = np.where(keep, col, col + (np.array((168, 156, 142)) - col) * hi2)
    t = (smooth(0, 1, -elev / 1700) ** 0.6)[..., None]
    sea = np.array(SEA_SHALLOW) + (np.array(SEA_DEEP) - np.array(SEA_SHALLOW)) * t
    col = np.where((~land | (biome == "~"))[..., None], sea, col)
    # region borders (land on both sides): a light darkening, as on the 2D map
    border = np.zeros((H, W), dtype=bool)
    for dy, dx in ((0, 1), (1, 0)):
        a, b = region[: H - dy, : W - dx], region[dy:, dx:]
        diff = (a != b) & (a >= 0) & (b >= 0)
        border[: H - dy, : W - dx] |= diff
    col[border] *= 0.82
    return lin(col)


# ---------------------------------------------------------------------------------------------------------------
# Scene

def clear():
    for o in list(bpy.data.objects):
        bpy.data.objects.remove(o)
    for blk in (bpy.data.meshes, bpy.data.materials, bpy.data.curves, bpy.data.lights, bpy.data.cameras):
        for x in list(blk):
            blk.remove(x)


def material(name, rgb, rough=0.9, alpha=1.0, vcol=None, emission=0.0):
    m = bpy.data.materials.new(name)
    m.use_nodes = True
    nt = m.node_tree
    b = next(n for n in nt.nodes if n.type == "BSDF_PRINCIPLED")
    b.inputs["Base Color"].default_value = (*rgb, 1)
    b.inputs["Roughness"].default_value = rough
    if "Specular IOR Level" in b.inputs:
        b.inputs["Specular IOR Level"].default_value = 0.15 if alpha == 1.0 else 0.6
    if vcol:
        a = nt.nodes.new("ShaderNodeAttribute")
        a.attribute_name = vcol
        nt.links.new(a.outputs["Color"], b.inputs["Base Color"])
    if emission > 0:
        b.inputs["Emission Color"].default_value = (*rgb, 1)
        b.inputs["Emission Strength"].default_value = emission
    if alpha < 1.0:
        b.inputs["Alpha"].default_value = alpha
        try:
            m.surface_render_method = "BLENDED"
        except (AttributeError, TypeError):
            pass
    return m


def obj(name, verts, faces, mat):
    me = bpy.data.meshes.new(name)
    me.from_pydata([tuple(v) for v in verts], [], [tuple(f) for f in faces])
    me.materials.append(mat)
    o = bpy.data.objects.new(name, me)
    bpy.context.scene.collection.objects.link(o)
    return o


def xy(mx, my):
    """map units (km, y south) -> Blender x, y."""
    return mx, -my


def terrain():
    s = args.step
    js, is_ = np.arange(0, H + 2 * PAD, s), np.arange(0, W + 2 * PAD, s)
    h, w = len(js), len(is_)
    E = np.pad(ELEV, PAD, mode="edge")[np.ix_(js, is_)]
    C = np.pad(colours(), ((PAD, PAD), (PAD, PAD), (0, 0)), mode="edge")[np.ix_(js, is_)]
    I, J = np.meshgrid(is_ - PAD, js - PAD)
    X, Y = (I + 0.5) * CK, -(J + 0.5) * CK
    verts = np.stack([X, Y, z_of(E)], -1).reshape(-1, 3)
    idx = np.arange(h * w).reshape(h, w)
    q = np.stack([idx[:-1, :-1], idx[1:, :-1], idx[1:, 1:], idx[:-1, 1:]], -1).reshape(-1, 4)
    me = bpy.data.meshes.new("Relief")
    me.vertices.add(len(verts))
    me.vertices.foreach_set("co", verts.astype(np.float32).ravel())
    me.loops.add(len(q) * 4)
    me.loops.foreach_set("vertex_index", q.astype(np.int32).ravel())
    me.polygons.add(len(q))
    me.polygons.foreach_set("loop_start", (np.arange(len(q)) * 4).astype(np.int32))
    me.update(calc_edges=True)
    ca = me.color_attributes.new("biome", "FLOAT_COLOR", "POINT")
    rgba = np.concatenate([C.reshape(-1, 3), np.ones((h * w, 1))], 1).astype(np.float32)
    ca.data.foreach_set("color", rgba.ravel())
    me.polygons.foreach_set("use_smooth", np.ones(len(q), dtype=bool))
    me.materials.append(material("ReliefMat", (1, 1, 1), 0.95, vcol="biome"))
    o = bpy.data.objects.new("Relief", me)
    bpy.context.scene.collection.objects.link(o)
    return o


def sample_top(mx, my):
    """Highest terrain z of the 4 cells around a map point (so a ribbon there sits above the surface)."""
    fi, fj = mx / CK - 0.5, my / CK - 0.5
    i0, j0 = int(np.clip(math.floor(fi), 0, W - 2)), int(np.clip(math.floor(fj), 0, H - 2))
    return float(z_of(max(0.0, ELEV[j0:j0 + 2, i0:i0 + 2].max())))


def chaikin(pts, n=2):
    """Corner-cutting smoothing of a polyline (keeps both ends): the paths run cell to cell."""
    for _ in range(n):
        out = [pts[0]]
        for a, b in zip(pts, pts[1:]):
            out += [a.lerp(b, 0.25), a.lerp(b, 0.75)]
        out.append(pts[-1])
        pts = out
    return pts


def rivers(scale=1.0):
    mat = bpy.data.materials.get("River") or material("River", tuple(lin(RIVER)), 0.25)
    verts, faces = [], []
    for r in D["rivers"]:
        path = chaikin([Vector((p[0], p[1])) for p in r["path"]])
        pts = []
        for a, b in zip(path, path[1:]):  # densify to 0.25 km
            n = max(1, int((b - a).length / 0.25))
            pts += [a.lerp(b, k / n) for k in range(n)]
        pts.append(path[-1])
        if len(pts) < 2:
            continue
        w = (0.10 + 0.07 * math.log10(1 + r.get("flowIndex", 50))) * scale
        L = len(pts)
        for k, p in enumerate(pts):
            t = (pts[min(L - 1, k + 1)] - pts[max(0, k - 1)])
            t = t.normalized() if t.length > 0 else Vector((1, 0))
            nrm = Vector((-t.y, t.x)) * (w * (0.45 + 0.55 * k / (L - 1)) / 2)  # widens downstream
            z = sample_top(p.x, p.y) + 0.03
            for sgn in (-1, 1):
                q = p + nrm * sgn
                verts.append((*xy(q.x, q.y), z))
            if k:
                b0 = len(verts) - 4
                faces.append((b0, b0 + 2, b0 + 3, b0 + 1))
    return obj("Rivers", verts, faces, mat)


def lakes():
    mat = material("Lake", tuple(lin((96, 150, 178))), 0.12)
    L = D["lakes"]
    verts, faces = [], []
    js, is_ = np.nonzero(biome == "l")
    for j, i in zip(js, is_):
        mx, my = (i + 0.5) * CK, (j + 0.5) * CK
        lk = min(L, key=lambda l: (l["at"][0] - mx) ** 2 + (l["at"][1] - my) ** 2)
        z = float(z_of(max(lk["surfaceM"], ELEV[j, i]))) + 0.01
        b = len(verts)
        for dx, dy in ((-0.5, -0.5), (0.5, -0.5), (0.5, 0.5), (-0.5, 0.5)):
            verts.append((*xy(mx + dx * CK * 1.05, my + dy * CK * 1.05), z))
        faces.append((b, b + 3, b + 2, b + 1))
    return obj("Lakes", verts, faces, mat)


def sea():
    big = 400.0
    v = [(-big, big, 0), (big, big, 0), (big, -big, 0), (-big, -big, 0)]
    obj("Sea", v, [(0, 3, 2, 1)], material("Sea", tuple(lin((70, 128, 150))), 0.12, alpha=0.55))


def world_and_sun():
    sc = bpy.context.scene
    for e in ("BLENDER_EEVEE", "BLENDER_EEVEE_NEXT"):
        try:
            sc.render.engine = e
            break
        except TypeError:
            continue
    sc.view_settings.view_transform = "Standard"
    sc.view_settings.look = "None"
    sc.view_settings.exposure = 0.0
    w = bpy.data.worlds.new("ReliefSky")
    w.use_nodes = True
    bg = next(n for n in w.node_tree.nodes if n.type == "BACKGROUND")
    bg.inputs["Color"].default_value = (*lin((214, 228, 236)), 1)
    bg.inputs["Strength"].default_value = 0.45
    sc.world = w
    sun = bpy.data.objects.new("Sun", bpy.data.lights.new("Sun", "SUN"))
    sc.collection.objects.link(sun)
    sun.data.energy = 3.4
    sun.data.color = (1.0, 0.97, 0.9)
    sun.data.angle = math.radians(8)  # soft shadows
    to_ground = Vector((1.0, -1.0, -1.5)).normalized()  # light travels from the north-west (x west, y north)
    sun.rotation_euler = to_ground.to_track_quat("-Z", "Y").to_euler()
    try:
        sc.eevee.use_shadows = True
        sc.eevee.shadow_ray_count = 2
    except AttributeError:
        pass
    return sc


PARCHMENT = None


def overlay_labels(cam, labels, px):
    """Region names as a 2D overlay: flat text on a soft parchment card, placed in camera space just in front of the
    lens at the projected position of each anchor, so no peak can hide or clip it. Greedy placement: a label that
    would overlap an earlier one is nudged down, then dropped. px = text height in pixels."""
    from bpy_extras.object_utils import world_to_camera_view
    global PARCHMENT
    if PARCHMENT is None:
        PARCHMENT = material("Parchment", tuple(lin((244, 234, 208))), 1.0, alpha=0.78, emission=1.0)
        for m in (PARCHMENT, INK):  # unlit: emission only
            next(n for n in m.node_tree.nodes if n.type == "BSDF_PRINCIPLED").inputs["Base Color"].default_value = (0, 0, 0, 1)
    sc = bpy.context.scene
    bpy.context.view_layer.update()
    rw, rh = RES
    dist = 1.0                                               # camera-space depth of the overlay
    fr = [v * (dist / -cam.data.view_frame(scene=sc)[0].z) for v in cam.data.view_frame(scene=sc)]
    fw, fh = fr[0].x - fr[2].x, fr[0].y - fr[2].y            # frame size at that depth
    unit = fh / rh                                           # camera-space units per pixel
    boxes, made = [], []
    for text, at in sorted(labels, key=lambda t: -len(t[0])):
        u = world_to_camera_view(sc, cam, Vector(at))
        if u.z <= 0 or not (-0.05 < u.x < 1.05 and -0.05 < u.y < 1.05):
            continue
        cu = bpy.data.curves.new("L_" + text, "FONT")
        cu.body = text
        cu.size = px * unit * 1.35
        cu.align_x, cu.align_y = "CENTER", "CENTER"
        o = bpy.data.objects.new("L_" + text, cu)
        sc.collection.objects.link(o)
        o.data.materials.append(INK)
        bpy.context.view_layer.update()
        tw, th = o.dimensions.x / unit + 14, px * 1.7          # card size in pixels
        x = min(max(u.x * rw, tw / 2 + 6), rw - tw / 2 - 6)
        y = min(max(u.y * rh, th / 2 + 6), rh - th / 2 - 6)
        for _ in range(3):
            b = (x - tw / 2, y - th / 2, x + tw / 2, y + th / 2)
            if not any(b[0] < q[2] and b[2] > q[0] and b[1] < q[3] and b[3] > q[1] for q in boxes):
                break
            y -= th + 2
        else:
            bpy.data.objects.remove(o)
            print("LABEL dropped (overlap):", text)
            continue
        boxes.append(b)
        lx, ly = (x / rw - 0.5) * fw, (y / rh - 0.5) * fh
        o.location = cam.matrix_world @ Vector((lx, ly - th * 0.04 * unit, -dist * 0.999))
        o.rotation_euler = cam.rotation_euler
        bpy.ops.mesh.primitive_plane_add(size=1.0)
        card = bpy.context.active_object
        card.name = "LC_" + text
        card.scale = (tw * unit, th * unit, 1)
        card.location = cam.matrix_world @ Vector((lx, ly, -dist))
        card.rotation_euler = cam.rotation_euler
        card.data.materials.append(PARCHMENT)
        for q in (o, card):
            for attr in ("visible_shadow",):
                if hasattr(q, attr):
                    setattr(q, attr, False)
        made += [o, card]
    return made


def shoot(name, target, dist, yaw, pitch, lens, labels, lsize):
    sc = bpy.context.scene
    cam = bpy.data.objects.get("Cam") or bpy.data.objects.new("Cam", bpy.data.cameras.new("Cam"))
    if cam.name not in sc.collection.objects:
        sc.collection.objects.link(cam)
    d = Vector((math.sin(math.radians(yaw)) * math.cos(math.radians(pitch)),
                -math.cos(math.radians(yaw)) * math.cos(math.radians(pitch)), math.sin(math.radians(pitch))))
    cam.location = Vector(target) + d * dist
    cam.rotation_euler = (-d).to_track_quat("-Z", "Y").to_euler()
    cam.data.lens = lens
    cam.data.clip_start, cam.data.clip_end = 0.1, 2000
    sc.camera = cam
    sc.render.resolution_x, sc.render.resolution_y = RES
    sc.render.resolution_percentage = 100
    made = overlay_labels(cam, labels, lsize)
    sc.render.image_settings.file_format = "PNG"
    sc.eevee.taa_render_samples = args.samples
    sc.render.filepath = os.path.join(OUT, name)
    t = time.time()
    bpy.ops.render.render(write_still=True)
    print("RENDER %s %.1fs" % (sc.render.filepath, time.time() - t))
    for o in made:
        bpy.data.objects.remove(o)


def region_info(ids):
    """Centroid (map units) and bounding box of the given regions' cells, plus a label point for each region."""
    out = {}
    for rid in ids:
        k = LEGEND.index(rid)
        js, is_ = np.nonzero(region == k)
        if len(js) == 0:
            continue
        cx, cy = (is_.mean() + 0.5) * CK, (js.mean() + 0.5) * CK
        out[rid] = dict(c=(cx, cy), lo=((is_.min()) * CK, js.min() * CK), hi=((is_.max() + 1) * CK, (js.max() + 1) * CK))
    return out


def label_at(rid, info, lift):
    cx, cy = info["c"]
    i, j = int(cx / CK), int(cy / CK)
    top = ELEV[min(j, H - 1), min(i, W - 1)]
    return (*xy(cx, cy), float(z_of(max(0.0, top))) + lift)


clear()
sc = world_and_sun()
INK = material("Ink", tuple(lin((40, 28, 18))), 1.0, emission=1.0)  # unlit dark-brown labels
terrain()
lakes()
sea()
print("BUILT in %.1fs (grid %dx%d step %d, exag %.0fx)" % (time.time() - t0, W, H, args.step, args.exag))
os.makedirs(OUT, exist_ok=True)
allinfo = region_info([r for r in LEGEND])

if args.only in ("", "whole"):
    riv = rivers(1.0)
    labs = [(NAMES.get(r, r), label_at(r, inf, 0.0)) for r, inf in allinfo.items()]
    shoot("physical_relief_3d.png", (75.0, -50.0, 0.0), 172.0, -12.0, 50.0, 35.0, labs, 17 * RES[1] / 1080)
    bpy.data.objects.remove(riv)
if args.only in ("", "heartland"):
    hi = region_info(["reg_aldmere", "reg_whisperwood"])
    lo = np.min([v["lo"] for v in hi.values()], 0)
    hi_ = np.max([v["hi"] for v in hi.values()], 0)
    c = (lo + hi_) / 2
    span = float(max(hi_[0] - lo[0], hi_[1] - lo[1]))
    near = [r for r, inf in allinfo.items()
            if abs(inf["c"][0] - c[0]) < span * 1.3 and abs(inf["c"][1] - c[1]) < span * 1.0]
    labs = [(NAMES.get(r, r), label_at(r, allinfo[r], 0.0)) for r in near]
    riv = rivers(0.55)
    shoot("physical_relief_heartland.png", (*xy(c[0], c[1]), 2.0), span * 2.3, -25.0, 56.0, 35.0, labs, 22 * RES[1] / 1080)
print("DONE in %.1fs" % (time.time() - t0))
