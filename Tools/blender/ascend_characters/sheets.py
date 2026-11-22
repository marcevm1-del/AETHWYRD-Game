"""Turnaround sheets for characters in the toon preview standard (art_direction.md 3.1): front, side, back, three-quarter,
plus a T-pose tile and a close-up of the face. Built on copies, so the character objects stay untouched."""
import math
import os

import bpy

import toon_preview as tp

from . import rig as R

# The frontal key keeps the face clear but flattens the form, so the rim does the separating instead.
tp.RIM.setdefault("character", 0.36)
tp.OUTLINE_PX.setdefault("character", 2.0)
tp.PITCH.setdefault("character", 6.0)
# Skin in the creature shadow tone reads bruised: characters get a lighter, warmer shade.
tp.SHADOW_BY_KIND.setdefault("character", (0.76, 0.72, 0.80))
# Dark skin collapsed into a mask under a plain multiply shadow (2026-11-22, human_male_sturdy_dark): the
# darker the base, the smaller the lit-to-shadow gap. This lifts the shadow towards white in proportion to
# how dark the surface is, which leaves light skin where it was.
tp.SHADOW_LIFT_BY_KIND.setdefault("character", 0.55)
# High and almost frontal, a little to the character's right: the fringe then shades the brow, not the whole face.
tp.SUN_BY_KIND.setdefault("character", (math.radians(58), 0.0, math.radians(14)))


def joined_copy(ch, name, skip=()):
    """One mesh object holding every part as currently posed (armature applied)."""
    dg = bpy.context.evaluated_depsgraph_get()
    copies = []
    for k, o in sorted(ch["parts"].items()):
        if k in skip or o.hide_render:
            continue
        ev = o.evaluated_get(dg)
        me = bpy.data.meshes.new_from_object(ev, preserve_all_data_layers=True, depsgraph=dg)
        c = bpy.data.objects.new("%s_%s" % (name, k), me)
        bpy.context.scene.collection.objects.link(c)
        c.matrix_world = o.matrix_world.copy()
        copies.append(c)
    for o in bpy.context.view_layer.objects:
        o.select_set(False)
    for c in copies:
        c.select_set(True)
    bpy.context.view_layer.objects.active = copies[0]
    with bpy.context.temp_override(active_object=copies[0], selected_editable_objects=copies, selected_objects=copies):
        bpy.ops.object.join()
    j = bpy.context.view_layer.objects.active
    j.name = name
    return j


def label(ch, view):
    return "%s %s  %.2f m" % (ch["spec"]["id"].replace("human_", "").replace("_", " "), view, ch["spec"]["heightM"])


def _head_only(j, zmin):
    import bmesh
    bm = bmesh.new()
    bm.from_mesh(j.data)
    bmesh.ops.delete(bm, geom=[v for v in bm.verts if v.co.z < zmin], context="VERTS")
    bm.to_mesh(j.data)
    bm.free()


def _tile(ch, out_dir, view, yaw, pose, tile, pitch=None, head=False):
    arm = ch["armature"]
    (R.pose_test if pose == "test" else R.pose_rest)(arm)
    bpy.context.view_layer.update()
    j = joined_copy(ch, "SHEET_%s_%s" % (ch["spec"]["id"], view))
    if head:
        _head_only(j, 0.84 * ch["spec"]["heightM"])
    hidden = [o for o in bpy.context.scene.objects if o is not j and not o.hide_render and o.type == "MESH"]
    for o in hidden:
        o.hide_render = True
    try:
        t = tp.render_tiles([j], os.path.join(out_dir, "_tiles"), kind="character", tile=tile, yaw=yaw, pitch=pitch,
                            samples=10, figure=False)[0]
    finally:
        for o in hidden:
            o.hide_render = False
        me = j.data
        bpy.data.objects.remove(j, do_unlink=True)
        bpy.data.meshes.remove(me)
        R.pose_rest(arm)
    return (t[0], label(ch, view))


def turnaround(ch, out_png, tile=(360, 600)):
    """Front, side, back, three-quarter (relaxed pose) and the T-pose. Returns the PNG path."""
    d = os.path.dirname(out_png)
    os.makedirs(d, exist_ok=True)
    tiles = []
    for view, yaw in (("front", 0), ("side", 90), ("back", 180), ("three-quarter", -35)):
        p = _tile(ch, d, view, yaw, "test", tile)
        # tp names every tile after the object; keep a copy per view
        dst = os.path.join(d, "_tiles", "%s_%s.png" % (ch["spec"]["id"], view))
        os.replace(p[0], dst)
        tiles.append((dst, p[1]))
    p = _tile(ch, d, "T-pose", 0, "rest", tile)
    dst = os.path.join(d, "_tiles", "%s_tpose.png" % ch["spec"]["id"])
    os.replace(p[0], dst)
    tiles.append((dst, p[1]))
    for view, yaw in (("face", 0), ("face three-quarter", -30)):
        p = _tile(ch, d, view, yaw, "rest", (tile[0], tile[0]), pitch=2.0, head=True)
        dst = os.path.join(d, "_tiles", "%s_%s.png" % (ch["spec"]["id"], view.replace(" ", "_")))
        os.replace(p[0], dst)
        tiles.append((dst, p[1]))
    tp.sheet(tiles[:5], out_png, cols=5, tile=tile)
    faces = [tiles[5], tiles[6]]
    tp.sheet(faces, out_png.replace(".png", "_face.png"), cols=2, tile=(tile[0], tile[0]))
    return out_png


def key_image(ch, out_png, tile=(640, 960), yaw=-28):
    """One large three-quarter portrait in the relaxed pose (the image kept in 13_Production)."""
    d = os.path.dirname(out_png)
    os.makedirs(d, exist_ok=True)
    p = _tile(ch, d, "key", yaw, "test", tile, pitch=4.0)
    os.replace(p[0], out_png)
    return out_png
