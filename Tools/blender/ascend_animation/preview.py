"""Contact sheets of a clip (Workbench, orthographic side view) so poses can be judged by eye."""
import math
import os

import bpy
import numpy as np
from mathutils import Vector

from . import analysis as AN


def _scene_setup(H, view):
    sc = bpy.context.scene
    for nm in ("Cube", "Light", "Camera"):          # the factory-startup objects would hide the character
        o = bpy.data.objects.get(nm)
        if o is not None:
            bpy.data.objects.remove(o)
    try:
        sc.render.engine = "BLENDER_WORKBENCH"
    except TypeError:
        pass
    sc.display.shading.light = "STUDIO"
    sc.display.shading.color_type = "VERTEX" if hasattr(sc.display.shading, "color_type") else "MATERIAL"
    sc.render.resolution_x, sc.render.resolution_y = 300, 420
    sc.render.film_transparent = False
    sc.world = sc.world or bpy.data.worlds.new("w")
    sc.world.color = (0.82, 0.86, 0.9)
    cam = bpy.data.objects.get("PrevCam")
    if cam is None:
        cam = bpy.data.objects.new("PrevCam", bpy.data.cameras.new("PrevCam"))
        sc.collection.objects.link(cam)
    cam.data.type = "ORTHO"
    cam.data.ortho_scale = H * 1.25
    if view == "side":
        cam.location, cam.rotation_euler = (4.0, 0.0, H * 0.5), (math.radians(90), 0, math.radians(90))
    else:
        cam.location, cam.rotation_euler = (0.0, -4.0, H * 0.5), (math.radians(90), 0, 0)
    sc.camera = cam


def sheet(rig, legs, clip, path, count=8, view="side", H=1.75, center=0.5):
    """Render `count` evenly spaced frames of the clip into one PNG (a row)."""
    _scene_setup(H, view)
    sc = bpy.context.scene
    frames = clip.frames()
    n = len(frames) - 1
    tiles = []
    tmp = path + ".tile.png"
    for k in range(count):
        i = int(round(k * n / count)) if clip.loop else int(round(k * n / (count - 1)))
        sc.frame_set(i)          # the clip's baked action is assigned: this shows the real keys
        sc.render.filepath = tmp
        bpy.ops.render.render(write_still=True)
        img = bpy.data.images.load(tmp)
        px = np.array(img.pixels[:], dtype=np.float32).reshape(img.size[1], img.size[0], 4)
        tiles.append(px)
        bpy.data.images.remove(img)
    sheet_px = np.concatenate(tiles, axis=1)
    out = bpy.data.images.new("sheet", sheet_px.shape[1], sheet_px.shape[0])
    out.pixels = sheet_px.ravel().tolist()
    out.filepath_raw = path
    out.file_format = "PNG"
    out.save()
    bpy.data.images.remove(out)
    if os.path.exists(tmp):
        os.remove(tmp)
    return path
