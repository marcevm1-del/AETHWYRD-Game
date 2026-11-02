"""
A preview rig for looking at buildings: a warm sun, a pale sky, a ground disc, Standard colour management (so the
palette reads as painted, anime-bright colour) and an orthographic or perspective camera framed on given objects.
"""
import math

import bpy
from mathutils import Vector

RIG = "AB_Rig"


def _col():
    col = bpy.data.collections.get(RIG)
    if col is None:
        col = bpy.data.collections.new(RIG)
    if col.name not in bpy.context.scene.collection.children:
        bpy.context.scene.collection.children.link(col)
    return col


def setup(scene=None, ground=True, engine=None):
    sc = scene or bpy.context.scene
    col = _col()
    try:
        sc.view_settings.view_transform = "Standard"
        sc.view_settings.look = "None"
        sc.view_settings.exposure = -0.5
    except TypeError:
        pass
    eng = engine or "BLENDER_EEVEE"
    for e in (eng, "BLENDER_EEVEE_NEXT", "BLENDER_EEVEE", "BLENDER_WORKBENCH"):
        try:
            sc.render.engine = e
            break
        except TypeError:
            continue
    world = bpy.data.worlds.get("AB_Sky") or bpy.data.worlds.new("AB_Sky")
    world.use_nodes = True
    bg = next(n for n in world.node_tree.nodes if n.type == "BACKGROUND")
    bg.inputs["Color"].default_value = (0.62, 0.78, 0.95, 1.0)
    bg.inputs["Strength"].default_value = 0.65
    sc.world = world
    sun = bpy.data.objects.get("AB_Sun")
    if sun is None:
        ld = bpy.data.lights.new("AB_Sun", "SUN")
        sun = bpy.data.objects.new("AB_Sun", ld)
        col.objects.link(sun)
    sun.data.energy = 2.3
    sun.data.color = (1.0, 0.95, 0.86)
    sun.data.angle = math.radians(3)
    sun.rotation_euler = (math.radians(48), 0, math.radians(32))
    if ground:
        g = bpy.data.objects.get("AB_Ground")
        if g is None:
            me = bpy.data.meshes.new("AB_Ground")
            n = 48
            verts = [(0, 0, -0.02)] + [(400 * math.cos(2 * math.pi * k / n), 400 * math.sin(2 * math.pi * k / n), -0.02) for k in range(n)]
            faces = [(0, k + 1, (k + 1) % n + 1) for k in range(n)]
            me.from_pydata(verts, [], faces)
            mat = bpy.data.materials.get("AB_GroundMat") or bpy.data.materials.new("AB_GroundMat")
            mat.use_nodes = True
            b = next(x for x in mat.node_tree.nodes if x.type == "BSDF_PRINCIPLED")
            b.inputs["Base Color"].default_value = (0.42, 0.58, 0.30, 1)
            b.inputs["Roughness"].default_value = 1.0
            me.materials.append(mat)
            g = bpy.data.objects.new("AB_Ground", me)
            col.objects.link(g)
    try:
        sc.eevee.use_shadows = True
    except AttributeError:
        pass
    return sc


def bounds(objs):
    import bpy as _b
    dg = _b.context.evaluated_depsgraph_get()
    lo = Vector((1e9, 1e9, 1e9))
    hi = Vector((-1e9, -1e9, -1e9))
    for o in objs:
        ev = o.evaluated_get(dg)
        for c in ev.bound_box:
            w = o.matrix_world @ Vector(c)
            lo = Vector(map(min, lo, w))
            hi = Vector(map(max, hi, w))
    return lo, hi


def camera(objs, yaw=-35.0, pitch=28.0, ortho=False, margin=1.15, lens=50.0, aspect=None):
    """Frames objs: the bounds diagonal (times margin) fits the frame's SHORTER side (review N2), so tall, thin props
    are not cropped on landscape tiles. aspect = height / width of the image it will render (default: the scene's
    render resolution; pass it when the resolution is set after framing, as the sheet builders do)."""
    sc = bpy.context.scene
    if aspect is None:
        aspect = sc.render.resolution_y / max(1, sc.render.resolution_x)
    short = min(aspect, 1.0 / aspect)  # the shorter side over the longer one (Blender's sensor spans the longer side)
    col = _col()
    cam = bpy.data.objects.get("AB_Cam")
    if cam is None:
        cam = bpy.data.objects.new("AB_Cam", bpy.data.cameras.new("AB_Cam"))
        col.objects.link(cam)
    lo, hi = bounds(objs)
    centre = (lo + hi) / 2
    size = (hi - lo).length
    d = Vector((math.sin(math.radians(yaw)) * math.cos(math.radians(pitch)),
                -math.cos(math.radians(yaw)) * math.cos(math.radians(pitch)),
                math.sin(math.radians(pitch))))
    cam.data.lens = lens
    cam.data.sensor_fit = "AUTO"
    cam.data.sensor_width = 36.0
    if ortho:
        cam.data.type = "ORTHO"
        cam.data.ortho_scale = size * margin / short
        cam.location = centre + d * size * 2
    else:
        cam.data.type = "PERSP"
        fov = 2 * math.atan(18 * short / lens)  # the field of view across the shorter side
        cam.location = centre + d * (size * margin / 2 / math.tan(fov / 2))
    cam.data.clip_end = 5000
    cam.rotation_euler = (-d).to_track_quat("-Z", "Y").to_euler()
    sc.camera = cam
    return cam


def contact_sheet(objs, path, cols=4, tile=(640, 480), yaw=-32.0, pitch=16.0, samples=16, labels=None):
    """Renders each object framed on its own (the others hidden) and tiles the shots into one PNG."""
    import os
    import tempfile

    import numpy as np

    sc = bpy.context.scene
    rows = (len(objs) + cols - 1) // cols
    sheet = np.ones((rows * tile[1], cols * tile[0], 4), dtype=np.float32)
    hidden = {o.name: o.hide_render for o in objs}
    tmp = os.path.join(tempfile.gettempdir(), "ab_tile.png")
    for i, o in enumerate(objs):
        for other in objs:
            other.hide_render = other is not o
        camera([o], yaw=yaw, pitch=pitch, margin=1.2, aspect=tile[1] / tile[0])
        render(tmp, tile, samples)
        img = bpy.data.images.load(tmp, check_existing=False)
        px = np.array(img.pixels[:], dtype=np.float32).reshape(tile[1], tile[0], 4)
        bpy.data.images.remove(img)
        r, c = divmod(i, cols)
        y0 = (rows - 1 - r) * tile[1]
        sheet[y0:y0 + tile[1], c * tile[0]:(c + 1) * tile[0]] = px
    for o in objs:
        o.hide_render = hidden[o.name]
    out = bpy.data.images.new("AB_Sheet", cols * tile[0], rows * tile[1], alpha=False)
    out.pixels[:] = sheet.ravel()
    out.filepath_raw = path
    out.file_format = "PNG"
    out.save()
    bpy.data.images.remove(out)
    return path


def render(path, res=(1600, 1000), samples=32):
    sc = bpy.context.scene
    sc.render.resolution_x, sc.render.resolution_y = res
    sc.render.resolution_percentage = 100
    sc.render.image_settings.file_format = "PNG"
    try:
        sc.eevee.taa_render_samples = samples
    except AttributeError:
        pass
    sc.render.filepath = path
    bpy.ops.render.render(write_still=True)
    return path
