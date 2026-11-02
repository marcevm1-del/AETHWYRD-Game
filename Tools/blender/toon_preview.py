"""
Toon preview mode for contact sheets (design review 2026-10-25 R1; tuned to style guide section 3.1, 2026-11-02).

Approximates the in-game `Ascend/Toon` look inside Blender (EEVEE) so a contact sheet can be used to approve a look:

* two tones per material: Shader-to-RGB of a white diffuse lit by one sun -> constant ramp
  (lit = base colour, shadow = base x (0.58, 0.56, 0.78)), cast shadows included;
* a soft cream rim (0.35) on creatures;
* emissive parts (lamps, windows, embers, glow cracks) shown in their own hue at full value, never added on top of
  the base colour (that clipped to cream/white); Standard view transform, no look, exposure 0;
* ink outlines as an inverted hull (outline colour = local colour x 0.35), sized in pixels at the tile size after
  the camera is fitted; Freestyle is switched on instead if the hull cannot be built;
* a painted-sky world (pale warm horizon -> soft blue) that does not light the subject;
* a lawn disc 3x the subject's bounds, #8CC860 fading to #A8D47A at its rim;
* the camera frames the SUBJECT only (its projected extent fills 1/margin = 83% of the tile's shorter side) and is
  fitted on both the horizontal and the vertical field of view, so tall props are never cropped;
* for creatures, a 1.7 m flat lavender-grey #A9A6C2 human silhouette (head 1/7 of height, shoulders, arms, legs)
  standing behind and to the right of the subject; it may be cropped by the frame.

Everything is built on copies: the subject is baked to a new mesh (building instances realised) and its materials
are copied, so the generators' shared materials and objects are untouched (the originals are only hidden).

One call for sheet builders (does the conversion, renders, and puts the scene back so the .blend can be saved):

    import toon_preview as tp
    tiles = tp.render_tiles(objs, tile_dir, kind="building", tile=(420, 320), yaw=-32, pitch=18, samples=16)
    tp.sheet(tiles, out_png, cols=6, tile=(420, 320))      # tiles = [(png, label)], labels carry the height in m

Lower level:
    tp.setup_world(); made = tp.apply([obj], kind="creature", tile=320); fig = tp.add_scale_figure(obj)
    g = tp.ground_for(made); tp.camera(made, tile=(320, 320))
"""
import math
import os
import time

import bmesh
import bpy
import numpy as np
from mathutils import Vector

from ascend_buildings import preview

PREFIX = "TP_"
SHADOW_TINT = (0.58, 0.56, 0.78)
OUTLINE_MUL = 0.35
OUTLINE_ALPHA_MUL = 0.6  # hull opacity relative to a see-through body (Phantom variants)
RIM_COLOUR = (1.0, 0.97, 0.9)
RIM = {"creature": 0.35, "building": 0.0}
OUTLINE_PX = {"creature": 1.5, "building": 2.0}   # art_direction.md section 3
STEP = 0.1          # lit where N.L (times cast shadow) exceeds this
SUN_ENERGY = math.pi  # a white diffuse facing this sun reads 1.0 through Shader-to-RGB, so the ramp works in N.L
SUN_ROT = (math.radians(48), 0.0, math.radians(32))
MARGIN = 1.2        # camera margin (style guide 3.1): the subject fills 1/1.2 = 83% of the tile's shorter side
LENS = 50.0
PITCH = {"creature": 16.0, "building": 18.0}   # style guide 3.1: pitch 16-28 degrees
FIGURE_HEIGHT = 1.7
FIGURE_HEX = "#A9A6C2"


def lin(c):
    """sRGB (0-1 floats or '#rrggbb') -> linear, for node colours."""
    if isinstance(c, str):
        c = tuple(int(c.lstrip("#")[i:i + 2], 16) / 255.0 for i in (0, 2, 4))
    return tuple(x / 12.92 if x <= 0.04045 else ((x + 0.055) / 1.055) ** 2.4 for x in c[:3])


GRASS = lin("#8CC860")
HAZE = lin("#BFD9A0")       # distant fields, also the world below the horizon
GRASS_RIM = lin("#A8D47A")  # lawn rim (style guide 3.1)
HORIZON = lin("#F6ECD6")    # pale warm
SKY_MID = lin("#CFE8F5")
ZENITH = lin("#6AAEE6")     # soft blue


def _col():
    col = bpy.data.collections.get(PREFIX + "Rig")
    if col is None:
        col = bpy.data.collections.new(PREFIX + "Rig")
    if col.name not in bpy.context.scene.collection.children:
        bpy.context.scene.collection.children.link(col)
    return col


# ----------------------------------------------------------------------------------------------------------------
# World and light


def setup_world(scene=None):
    """Painted-sky world (camera only: it does not light the subject), one sun, Standard colour, EEVEE."""
    sc = scene or bpy.context.scene
    for e in ("BLENDER_EEVEE", "BLENDER_EEVEE_NEXT"):
        try:
            sc.render.engine = e
            break
        except TypeError:
            continue
    try:
        sc.view_settings.view_transform = "Standard"
        sc.view_settings.look = "None"
        sc.view_settings.exposure = 0.0
        sc.view_settings.gamma = 1.0
    except TypeError:
        pass
    for attr, v in (("use_shadows", True), ("use_gtao", False), ("use_bloom", False)):
        try:
            setattr(sc.eevee, attr, v)
        except AttributeError:
            pass
    w = bpy.data.worlds.get(PREFIX + "Sky") or bpy.data.worlds.new(PREFIX + "Sky")
    w.use_nodes = True
    nt = w.node_tree
    for n in list(nt.nodes):
        nt.nodes.remove(n)
    N, L = nt.nodes, nt.links
    out = N.new("ShaderNodeOutputWorld")
    bg = N.new("ShaderNodeBackground")
    tc = N.new("ShaderNodeTexCoord")
    norm = N.new("ShaderNodeVectorMath")
    norm.operation = "NORMALIZE"
    sep = N.new("ShaderNodeSeparateXYZ")
    mr = N.new("ShaderNodeMapRange")
    mr.inputs["From Min"].default_value = -1.0
    mr.inputs["From Max"].default_value = 1.0
    ramp = N.new("ShaderNodeValToRGB")
    els = ramp.color_ramp.elements
    stops = [(0.0, HAZE), (0.497, HAZE), (0.5, HORIZON), (0.56, SKY_MID), (0.8, ZENITH), (1.0, ZENITH)]
    els[0].position, els[0].color = stops[0][0], (*stops[0][1], 1)
    els[1].position, els[1].color = stops[-1][0], (*stops[-1][1], 1)
    for p, c in stops[1:-1]:
        e = els.new(p)
        e.color = (*c, 1)
    lp = N.new("ShaderNodeLightPath")
    L.new(tc.outputs["Generated"], norm.inputs[0])
    L.new(norm.outputs["Vector"], sep.inputs[0])
    L.new(sep.outputs["Z"], mr.inputs["Value"])
    L.new(mr.outputs["Result"], ramp.inputs["Fac"])
    L.new(ramp.outputs["Color"], bg.inputs["Color"])
    L.new(lp.outputs["Is Camera Ray"], bg.inputs["Strength"])  # seen, but lights nothing
    L.new(bg.outputs[0], out.inputs[0])
    sc.world = w
    col = _col()
    sun = bpy.data.objects.get(PREFIX + "Sun")
    if sun is None:
        sun = bpy.data.objects.new(PREFIX + "Sun", bpy.data.lights.new(PREFIX + "Sun", "SUN"))
        col.objects.link(sun)
    sun.data.energy = SUN_ENERGY
    sun.data.color = (1.0, 1.0, 1.0)
    sun.data.angle = math.radians(2)
    sun.rotation_euler = SUN_ROT
    # hide the plain preview rig if it is in the scene
    for nm in ("AB_Sun", "AB_Ground"):
        o = bpy.data.objects.get(nm)
        if o is not None:
            o.hide_render = True
    return sc


# ----------------------------------------------------------------------------------------------------------------
# Materials


def _principled(nt):
    out = next((n for n in nt.nodes if n.type == "OUTPUT_MATERIAL" and n.is_active_output), None) or \
        next((n for n in nt.nodes if n.type == "OUTPUT_MATERIAL"), None)
    if out is not None and out.inputs[0].is_linked:
        n = out.inputs[0].links[0].from_node
        if n.type == "BSDF_PRINCIPLED":
            return n
    return next((n for n in nt.nodes if n.type == "BSDF_PRINCIPLED"), None)


def _source(bsdf, name, default):
    """(socket or None, constant) for a Principled input: the linked socket if there is one, else its value."""
    if bsdf is None or name not in bsdf.inputs:
        return None, default
    s = bsdf.inputs[name]
    if s.is_linked:
        return s.links[0].from_socket, default
    v = s.default_value
    try:
        return None, tuple(v)
    except TypeError:
        return None, v


def _feed(nt, socket_or_none, value, target):
    if socket_or_none is not None:
        nt.links.new(socket_or_none, target)
    else:
        target.default_value = value


def _mix(nt, blend, a=None, b=None, fac=1.0):
    m = nt.nodes.new("ShaderNodeMix")
    m.data_type = "RGBA"
    m.blend_type = blend
    m.inputs["Factor"].default_value = fac
    return m, m.inputs[6], m.inputs[7], m.outputs[2]


def _strip(mat):
    """Copies mat; returns (copy, base, emission colour, emission strength, alpha) with the Principled removed."""
    m = mat.copy()
    if not m.use_nodes or m.node_tree is None:
        m.use_nodes = True
    nt = m.node_tree
    b = _principled(nt)
    dc = tuple(mat.diffuse_color[:3]) + (1.0,)
    base = _source(b, "Base Color", dc)
    ecol = _source(b, "Emission Color", (0, 0, 0, 1))
    estr = _source(b, "Emission Strength", 0.0)
    alpha = _source(b, "Alpha", 1.0)
    for n in [n for n in nt.nodes if n.type in ("OUTPUT_MATERIAL", "BSDF_PRINCIPLED")]:
        nt.nodes.remove(n)
    return m, base, ecol, estr, alpha


def toon_material(mat, kind="creature"):
    """A two-tone (plus rim on creatures) emission copy of mat."""
    m, base, ecol, estr, alpha = _strip(mat)
    m.name = PREFIX + mat.name
    nt = m.node_tree
    N, L = nt.nodes, nt.links
    out = N.new("ShaderNodeOutputMaterial")
    diff = N.new("ShaderNodeBsdfDiffuse")
    diff.inputs["Color"].default_value = (1, 1, 1, 1)
    s2r = N.new("ShaderNodeShaderToRGB")
    bw = N.new("ShaderNodeRGBToBW")
    ramp = N.new("ShaderNodeValToRGB")
    ramp.color_ramp.interpolation = "CONSTANT"
    e0, e1 = ramp.color_ramp.elements
    e0.position, e0.color = 0.0, (*SHADOW_TINT, 1)
    e1.position, e1.color = STEP, (1, 1, 1, 1)
    L.new(diff.outputs[0], s2r.inputs[0])
    L.new(s2r.outputs["Color"], bw.inputs[0])
    L.new(bw.outputs[0], ramp.inputs["Fac"])
    mul, a, b, res = _mix(nt, "MULTIPLY")
    _feed(nt, base[0], base[1], a)
    L.new(ramp.outputs["Color"], b)
    col = res
    rim = RIM.get(kind, 0.0)
    if rim > 0:
        lw = N.new("ShaderNodeLayerWeight")
        lw.inputs["Blend"].default_value = 0.5
        rr = N.new("ShaderNodeMapRange")
        rr.interpolation_type = "SMOOTHSTEP"
        rr.inputs["From Min"].default_value = 0.55
        rr.inputs["From Max"].default_value = 0.8
        lit = N.new("ShaderNodeMath")
        lit.operation = "GREATER_THAN"
        lit.inputs[1].default_value = STEP
        side = N.new("ShaderNodeMapRange")       # full rim on the lit side, a third in shadow
        side.inputs["To Min"].default_value = rim * 0.35
        side.inputs["To Max"].default_value = rim
        k = N.new("ShaderNodeMath")
        k.operation = "MULTIPLY"
        L.new(lw.outputs["Facing"], rr.inputs["Value"])
        L.new(bw.outputs[0], lit.inputs[0])
        L.new(lit.outputs[0], side.inputs["Value"])
        L.new(rr.outputs["Result"], k.inputs[0])
        L.new(side.outputs["Result"], k.inputs[1])
        mx = N.new("ShaderNodeMix")
        mx.data_type = "RGBA"
        mx.blend_type = "MIX"
        L.new(k.outputs[0], mx.inputs["Factor"])
        L.new(col, mx.inputs[6])
        mx.inputs[7].default_value = (*RIM_COLOUR, 1)
        col = mx.outputs[2]
    glowing = ecol[0] is not None or estr[0] is not None or (estr[1] or 0) > 0
    if glowing:  # keep emissive parts (lamps, cores, glow cracks) bright, in their own hue
        # Hue-preserving glow (review N3/B3): the shaded colour is MIXED towards the emission colour scaled so its
        # brightest channel is 1, by factor clamp(strength). The old base + emission*0.5 ADD pushed two channels
        # past 1, which the display clips, so #FF8C26 read cream and violet read white. Strength >= 1 shows the
        # key at full value; below 1 (Phantom 0.6, faint glow cracks) it is a partial glow.
        if ecol[0] is None:
            c = tuple(ecol[1][:3])
            k = max(c) if max(c) > 1e-6 else 1.0
            gsock, gval = None, (c[0] / k, c[1] / k, c[2] / k, 1.0)
            if max(c) > 1e-6:
                m["tp_glow_key"] = [c[0], c[1], c[2]]
        else:
            sep = N.new("ShaderNodeSeparateColor")
            L.new(ecol[0], sep.inputs[0])
            m1 = N.new("ShaderNodeMath")
            m1.operation = "MAXIMUM"
            m2 = N.new("ShaderNodeMath")
            m2.operation = "MAXIMUM"
            m3 = N.new("ShaderNodeMath")
            m3.operation = "MAXIMUM"
            m3.inputs[1].default_value = 1e-4
            inv = N.new("ShaderNodeMath")
            inv.operation = "DIVIDE"
            inv.inputs[0].default_value = 1.0
            sc_ = N.new("ShaderNodeVectorMath")
            sc_.operation = "SCALE"
            L.new(sep.outputs[0], m1.inputs[0])
            L.new(sep.outputs[1], m1.inputs[1])
            L.new(m1.outputs[0], m2.inputs[0])
            L.new(sep.outputs[2], m2.inputs[1])
            L.new(m2.outputs[0], m3.inputs[0])
            L.new(m3.outputs[0], inv.inputs[1])
            L.new(ecol[0], sc_.inputs[0])
            L.new(inv.outputs[0], sc_.inputs["Scale"])
            gsock, gval = sc_.outputs[0], None
        w = N.new("ShaderNodeMath")
        w.operation = "MULTIPLY"
        w.use_clamp = True
        w.inputs[1].default_value = 1.0
        _feed(nt, estr[0], estr[1], w.inputs[0])
        gm, ga, gb, gres = _mix(nt, "MIX")
        L.new(w.outputs[0], gm.inputs["Factor"])
        L.new(col, ga)
        _feed(nt, gsock, gval, gb)
        col = gres
        m["tp_glow"] = True
    emit = N.new("ShaderNodeEmission")
    emit.inputs["Strength"].default_value = 1.0
    L.new(col, emit.inputs["Color"])
    shader = emit.outputs[0]
    if alpha[0] is not None or (alpha[1] if alpha[1] is not None else 1.0) < 1.0:
        tr = N.new("ShaderNodeBsdfTransparent")
        ms = N.new("ShaderNodeMixShader")
        _feed(nt, alpha[0], alpha[1], ms.inputs["Fac"])
        L.new(tr.outputs[0], ms.inputs[1])
        L.new(shader, ms.inputs[2])
        shader = ms.outputs[0]
    L.new(shader, out.inputs["Surface"])
    m["tp_kind"] = kind
    return m


def outline_material(mat):
    """Backface-culled emission copy of mat in its local colour x 0.35 (vertex colours included)."""
    m, base, _e, _s, alpha = _strip(mat)
    m.name = PREFIX + "ol_" + mat.name
    nt = m.node_tree
    N, L = nt.nodes, nt.links
    out = N.new("ShaderNodeOutputMaterial")
    mul, a, b, res = _mix(nt, "MULTIPLY")
    _feed(nt, base[0], base[1], a)
    b.default_value = (OUTLINE_MUL, OUTLINE_MUL, OUTLINE_MUL, 1)
    emit = N.new("ShaderNodeEmission")
    L.new(res, emit.inputs["Color"])
    shader = emit.outputs[0]
    # See-through materials (Phantom variants): an opaque hull would show its far wall through the body and make
    # the ghost read solid, so the hull fades with the body (x OUTLINE_ALPHA_MUL) and is blended, not dithered.
    see_through = alpha[0] is not None or (alpha[1] if alpha[1] is not None else 1.0) < 1.0
    if see_through:
        k = N.new("ShaderNodeMath")
        k.operation = "MULTIPLY"
        k.inputs[1].default_value = OUTLINE_ALPHA_MUL
        _feed(nt, alpha[0], alpha[1], k.inputs[0])
        tr = N.new("ShaderNodeBsdfTransparent")
        ms = N.new("ShaderNodeMixShader")
        L.new(k.outputs[0], ms.inputs["Fac"])
        L.new(tr.outputs[0], ms.inputs[1])
        L.new(shader, ms.inputs[2])
        shader = ms.outputs[0]
    L.new(shader, out.inputs["Surface"])
    m.use_backface_culling = True
    for attr in ("use_backface_culling_shadow",):
        if hasattr(m, attr):
            setattr(m, attr, True)
    try:
        m.surface_render_method = "BLENDED" if see_through else "DITHERED"
    except (AttributeError, TypeError):
        pass
    return m


def _flat_material(name, rgb):
    mat = bpy.data.materials.get(name) or bpy.data.materials.new(name)
    mat.use_nodes = True
    b = _principled(mat.node_tree)
    b.inputs["Base Color"].default_value = (*rgb, 1)
    mat.diffuse_color = (*rgb, 1)
    return mat


# ----------------------------------------------------------------------------------------------------------------
# Baking, hull, apply


def _realize_state(o):
    """The AB_Instancer 'Realize' input of a library building (None when o has no instancer)."""
    md = o.modifiers.get("AB_Instancer")
    if md is None or md.node_group is None:
        return None
    ident = next((i.identifier for i in md.node_group.interface.items_tree if getattr(i, "name", "") == "Realize"),
                 None)
    if ident is None:
        return None
    props = getattr(md, "properties", None)
    if props is not None and hasattr(props, "inputs"):
        return bool(getattr(props.inputs, ident).value)
    return bool(md.get(ident, False))


def _bake(o, dg):
    """A new object holding o's evaluated mesh (building instances realised), at o's transform. The instancer's
    Realize switch is put back afterwards. o itself is hidden (render and viewport) so the toon copy replaces it;
    its previous hide state is stored on the copy (tp_src, tp_src_hide_render, tp_src_hide_viewport), see restore()."""
    ABblend, was = None, _realize_state(o)
    if was is not None and not was:
        try:
            from ascend_buildings import blend as ABblend
            ABblend.set_realize(o, True)
        except Exception:
            ABblend = None
    dg.update()
    ev = o.evaluated_get(dg)
    me = bpy.data.meshes.new_from_object(ev, preserve_all_data_layers=True, depsgraph=dg)
    if ABblend is not None:
        ABblend.set_realize(o, False)
    me.name = PREFIX + o.name
    t = bpy.data.objects.new(PREFIX + o.name, me)
    t.matrix_world = o.matrix_world.copy()
    for c in o.users_collection:
        c.objects.link(t)
    t["tp_src"] = o.name
    t["tp_src_hide_render"] = bool(o.hide_render)
    t["tp_src_hide_viewport"] = bool(o.hide_viewport)
    o.hide_render = True
    o.hide_viewport = True
    return t


def restore(made):
    """Undoes apply() for a live session: unhides the originals and deletes the toon copies and hulls in made."""
    for t in made:
        src = bpy.data.objects.get(t.get("tp_src", "")) if "tp_src_hide_render" in t else None
        if src is not None:
            src.hide_render = bool(t["tp_src_hide_render"])
            src.hide_viewport = bool(t["tp_src_hide_viewport"])
    for t in made:
        me = t.data
        bpy.data.objects.remove(t, do_unlink=True)
        if me is not None and me.users == 0:
            bpy.data.meshes.remove(me)


def _hull(src, thickness, cache):
    me = src.data.copy()
    me.name = PREFIX + "hull_" + src.name
    bm = bmesh.new()
    bm.from_mesh(me)
    bmesh.ops.remove_doubles(bm, verts=bm.verts, dist=max(1e-5, thickness * 0.02))
    bm.to_mesh(me)
    bm.free()
    n = len(me.vertices)
    co = np.empty(n * 3, dtype=np.float32)
    me.vertices.foreach_get("co", co)
    nor = np.empty(n * 3, dtype=np.float32)
    me.vertex_normals.foreach_get("vector", nor)
    # thickness is in world units; undo the object's scale
    s = max(1e-6, sum(src.matrix_world.to_scale()) / 3.0)
    me.vertices.foreach_set("co", co + nor * (thickness / s))
    me.flip_normals()
    for i, m in enumerate(me.materials):
        if m is None:
            continue
        key = m.get("tp_src", m.name)
        if key not in cache:
            orig = bpy.data.materials.get(key) or m
            cache[key] = outline_material(orig)
        me.materials[i] = cache[key]
    me.update()
    h = bpy.data.objects.new(me.name, me)
    h.matrix_world = src.matrix_world.copy()
    for c in src.users_collection:
        c.objects.link(h)
    for attr in ("visible_shadow",):
        if hasattr(h, attr):
            setattr(h, attr, False)
    h["tp_hull"] = True
    return h


def _world_points(objs, cap=250000):
    """World-space vertex positions of objs (evaluated), as an (n, 3) array; strided down to about cap points."""
    dg = bpy.context.evaluated_depsgraph_get()
    out = []
    for o in objs:
        if o.type != "MESH":
            continue
        ev = o.evaluated_get(dg)
        try:
            me = ev.to_mesh()
        except RuntimeError:
            continue
        n = len(me.vertices)
        if n:
            co = np.empty(n * 3, dtype=np.float64)
            me.vertices.foreach_get("co", co)
            m = np.array(o.matrix_world)
            out.append(co.reshape(-1, 3) @ m[:3, :3].T + m[:3, 3])
        ev.to_mesh_clear()
    if not out:
        lo, hi = preview.bounds(objs)
        return np.array([[x, y, z] for x in (lo.x, hi.x) for y in (lo.y, hi.y) for z in (lo.z, hi.z)])
    p = np.concatenate(out)
    if len(p) > cap:
        p = p[:: int(math.ceil(len(p) / cap))]
    return p


def _tile_wh(tile):
    return (tile, tile) if isinstance(tile, (int, float)) else (int(tile[0]), int(tile[1]))


def _view(yaw, pitch):
    """(d, right, up): d points from the subject to the camera."""
    d = Vector((math.sin(math.radians(yaw)) * math.cos(math.radians(pitch)),
                -math.cos(math.radians(yaw)) * math.cos(math.radians(pitch)),
                math.sin(math.radians(pitch))))
    rot = (-d).to_track_quat("-Z", "Y")
    return d, rot @ Vector((1, 0, 0)), rot @ Vector((0, 1, 0))


def fit(objs, yaw=-35.0, pitch=16.0, tile=320, margin=MARGIN, lens=LENS):
    """Perspective fit of objs: returns (aim, distance, tan_half_h, tan_half_v, fill). Every vertex lies inside the
    frame shrunk by margin on BOTH axes (vertical fit included, review N2), and the projected extent is centred.
    fill = the subject's larger projected extent as a fraction of the tile's shorter side."""
    w, h = _tile_wh(tile)
    t = 18.0 / lens  # sensor_fit AUTO, 36 mm across the larger tile dimension
    th, tv = (t, t * h / w) if w >= h else (t * w / h, t)
    P = _world_points(objs)
    d, r, u = _view(yaw, pitch)
    d, r, u = (np.array(v[:]) for v in (d, r, u))
    aim = P.min(0) * 0.5 + P.max(0) * 0.5
    D = 1.0
    for _ in range(8):
        q = P - aim
        x, y, z = q @ r, q @ u, q @ d
        D = float(np.max(np.maximum(np.abs(x) * margin / th, np.abs(y) * margin / tv) + z))
        depth = np.maximum(D - z, 1e-6)
        sx, sy = x / depth / th, y / depth / tv
        cx, cy = (sx.max() + sx.min()) / 2, (sy.max() + sy.min()) / 2
        if abs(cx) < 1e-4 and abs(cy) < 1e-4:
            break
        aim = aim + r * cx * th * D + u * cy * tv * D
    q = P - aim
    x, y, z = q @ r, q @ u, q @ d
    depth = np.maximum(D - z, 1e-6)
    sx, sy = x / depth / th, y / depth / tv
    ext_w = (sx.max() - sx.min()) / 2 * w   # projected extent in pixels
    ext_h = (sy.max() - sy.min()) / 2 * h
    return Vector(aim), D, th, tv, max(ext_w, ext_h) / float(min(w, h))


def camera(objs, yaw=-35.0, pitch=16.0, tile=320, margin=MARGIN, lens=LENS):
    """Places the scene camera (AB_Cam, shared with preview.camera) framed on objs only. Returns (cam, fill)."""
    sc = bpy.context.scene
    aim, D, th, tv, fill = fit(objs, yaw, pitch, tile, margin, lens)
    cam = bpy.data.objects.get("AB_Cam")
    if cam is None:
        cam = bpy.data.objects.new("AB_Cam", bpy.data.cameras.new("AB_Cam"))
        _col().objects.link(cam)
    d, _r, _u = _view(yaw, pitch)
    cam.data.type = "PERSP"
    cam.data.lens = lens
    cam.data.sensor_width = 36.0
    cam.data.sensor_fit = "AUTO"
    cam.data.shift_x = cam.data.shift_y = 0.0
    cam.data.clip_start = max(0.01, D * 0.01)
    cam.data.clip_end = max(5000.0, D * 20)
    cam.location = aim + d * D
    cam.rotation_euler = (-d).to_track_quat("-Z", "Y").to_euler()
    sc.camera = cam
    return cam, fill


def outline_thickness(objs, kind="creature", tile=320, margin=MARGIN, yaw=-35.0, pitch=None):
    """World-space hull thickness that reads as OUTLINE_PX at the tile size once camera() frames objs."""
    w, h = _tile_wh(tile)
    pitch = PITCH.get(kind, 16.0) if pitch is None else pitch
    aim, D, th, tv, _f = fit(objs, yaw, pitch, (w, h), margin)
    return OUTLINE_PX.get(kind, 1.5) * (2 * th * D) / float(w)


def apply(objs, kind="creature", tile=320, frame=None, yaw=-35.0, pitch=None, margin=MARGIN):
    """Bakes objs to toon copies with inverted-hull outlines. frame: the objects the camera will frame (defaults to
    the baked copies), used to size the outline in pixels. Returns the new objects (copies + hulls); the originals
    are hidden (pass the returned list to restore() to undo)."""
    dg = bpy.context.evaluated_depsgraph_get()
    toon_cache, ol_cache, copies = {}, {}, []
    for o in objs:
        if o.type != "MESH":
            continue
        c = _bake(o, dg)
        for i, m in enumerate(c.data.materials):
            if m is None:
                continue
            if m.name not in toon_cache:
                tm = toon_material(m, kind)
                tm["tp_src"] = m.name
                toon_cache[m.name] = tm
            c.data.materials[i] = toon_cache[m.name]
        copies.append(c)
    bpy.context.view_layer.update()
    t = outline_thickness(frame or copies, kind, tile, margin, yaw, pitch) if copies else 0.01
    made = list(copies)
    for c in copies:
        try:
            made.append(_hull(c, t, ol_cache))
        except Exception as e:  # fallback: screen-space Freestyle lines
            print("TOON hull failed on %s (%s); using Freestyle" % (c.name, e))
            enable_freestyle(OUTLINE_PX.get(kind, 1.5))
    return made


def enable_freestyle(px=1.5, scene=None):
    sc = scene or bpy.context.scene
    sc.render.use_freestyle = True
    sc.render.line_thickness_mode = "ABSOLUTE"
    sc.render.line_thickness = px
    vl = bpy.context.view_layer
    vl.use_freestyle = True
    fs = vl.freestyle_settings
    ls = fs.linesets[0] if fs.linesets else fs.linesets.new("TP_Lines")
    ls.select_by_visibility = True
    ls.select_silhouette = True
    ls.select_border = True
    ls.select_crease = False
    ls.linestyle.color = (0.12, 0.09, 0.1)
    ls.linestyle.thickness = px


# ----------------------------------------------------------------------------------------------------------------
# Scale figure and ground


def _figure_mesh(name, h=FIGURE_HEIGHT):
    """A simple human silhouette h tall, facing -Y, feet at z=0: head 1/7 of h, neck, shoulders, torso, hips,
    arms hanging clear of the torso, two legs and feet. Built from overlapping primitives (it is flat-shaded)."""
    s = h / 1.7
    bm = bmesh.new()

    def ellipsoid(c, rad, segs=16, rings=10):
        res = bmesh.ops.create_uvsphere(bm, u_segments=segs, v_segments=rings, radius=1.0)
        for v in res["verts"]:
            v.co = Vector((c[0] + v.co.x * rad[0], c[1] + v.co.y * rad[1], c[2] + v.co.z * rad[2])) * s

    def limb(p0, p1, r0, r1, flat=1.0, segs=12):
        p0, p1 = Vector(p0), Vector(p1)
        axis = p1 - p0
        res = bmesh.ops.create_cone(bm, cap_ends=True, cap_tris=False, segments=segs, radius1=r0, radius2=r1,
                                    depth=axis.length)
        q = Vector((0, 0, 1)).rotation_difference(axis.normalized())
        mid = (p0 + p1) / 2
        for v in res["verts"]:
            co = Vector((v.co.x, v.co.y * flat, v.co.z))
            v.co = (q @ co + mid) * s

    head_h = 1.7 / 7.0                                        # 0.243 m
    ellipsoid((0, 0, 1.7 - head_h / 2), (0.082, 0.095, head_h / 2))
    limb((0, 0, 1.38), (0, 0, 1.50), 0.05, 0.045)             # neck
    limb((0, 0, 0.90), (0, 0, 1.40), 0.15, 0.20, flat=0.58)   # torso, widening to the shoulders
    ellipsoid((0, 0, 1.38), (0.205, 0.11, 0.06))              # shoulder line
    ellipsoid((0, 0, 0.90), (0.155, 0.10, 0.10))              # hips
    for sx in (-1, 1):
        limb((sx * 0.21, 0, 1.38), (sx * 0.245, 0, 1.08), 0.052, 0.043)   # upper arm
        limb((sx * 0.245, 0, 1.08), (sx * 0.265, 0, 0.80), 0.043, 0.034)  # forearm
        ellipsoid((sx * 0.268, 0, 0.75), (0.034, 0.045, 0.06))           # hand
        limb((sx * 0.085, 0, 0.90), (sx * 0.095, 0, 0.47), 0.075, 0.057)  # thigh
        limb((sx * 0.095, 0, 0.47), (sx * 0.10, 0, 0.07), 0.057, 0.042)   # shin
        ellipsoid((sx * 0.10, -0.045, 0.04), (0.048, 0.11, 0.04))         # foot
    me = bpy.data.meshes.new(name)
    bm.to_mesh(me)
    bm.free()
    for p in me.polygons:
        p.use_smooth = True
    return me


def _figure_material():
    """Flat (unlit) lavender-grey #A9A6C2: a silhouette, not a character."""
    name = PREFIX + "FigureFlat"
    mat = bpy.data.materials.get(name)
    if mat is not None:
        return mat
    mat = bpy.data.materials.new(name)
    mat.use_nodes = True
    nt = mat.node_tree
    for n in list(nt.nodes):
        nt.nodes.remove(n)
    out = nt.nodes.new("ShaderNodeOutputMaterial")
    em = nt.nodes.new("ShaderNodeEmission")
    em.inputs["Color"].default_value = (*lin(FIGURE_HEX), 1)
    em.inputs["Strength"].default_value = 1.0
    nt.links.new(em.outputs[0], out.inputs["Surface"])
    mat.diffuse_color = (*lin(FIGURE_HEX), 1)
    return mat


def _extent_along(objs, centre, axis):
    """How far the objects' vertices reach from centre along a horizontal axis."""
    P = _world_points(objs)
    a = np.array([axis.x, axis.y, 0.0])
    return float(((P - np.array([centre.x, centre.y, 0.0])) @ a).max())


def add_scale_figure(obj, yaw=-35.0, gap=None):
    """A 1.7 m flat lavender-grey human silhouette standing behind and to the right of obj (as the camera at yaw
    sees it), facing the camera. It is not framed: on small creatures only a leg or an arm shows at the tile edge.
    obj may be one object or a list (e.g. the toon copies from apply())."""
    objs = obj if isinstance(obj, (list, tuple)) else [obj]
    objs = [o for o in objs if not o.get("tp_hull")]
    lo, hi = preview.bounds(objs)
    centre = (lo + hi) / 2
    right = Vector((math.cos(math.radians(yaw)), math.sin(math.radians(yaw)), 0.0))
    back = Vector((-math.sin(math.radians(yaw)), math.cos(math.radians(yaw)), 0.0))
    ext_r = _extent_along(objs, centre, right)
    ext_b = _extent_along(objs, centre, back)
    gap = 0.1 * max(0.3, ext_r) if gap is None else gap
    fig = bpy.data.objects.new(PREFIX + "Figure_" + objs[0].name, _figure_mesh(PREFIX + "Figure"))
    fig.data.materials.append(_figure_material())
    # its inner arm sits about at the subject's right edge, half a body-depth behind it
    pos = Vector((centre.x, centre.y, 0.0)) + right * (ext_r + gap + 0.2) + back * (0.5 * max(ext_b, 0.0) + 0.15)
    fig.location = (pos.x, pos.y, min(0.0, lo.z))
    fig.rotation_euler = (0.0, 0.0, math.radians(yaw))
    for c in objs[0].users_collection:
        c.objects.link(fig)
    fig["tp_figure"] = True
    return fig


def ground_for(objs, scale=3.0, min_radius=4.0):
    """A lawn disc with radius 3x the subjects' bounds: #8CC860, fading to #A8D47A at the rim (style guide 3.1)."""
    objs = [o for o in objs if not o.get("tp_figure")]
    lo, hi = preview.bounds(objs)
    r = max(min_radius, scale * max(hi.x - lo.x, hi.y - lo.y))
    n = 96
    me = bpy.data.meshes.new(PREFIX + "Ground")
    verts = [(0, 0, 0)] + [(r * math.cos(2 * math.pi * k / n), r * math.sin(2 * math.pi * k / n), 0) for k in range(n)]
    me.from_pydata(verts, [], [(0, k + 1, (k + 1) % n + 1) for k in range(n)])
    mat = bpy.data.materials.new(PREFIX + "GroundSrc")
    mat.use_nodes = True
    nt = mat.node_tree
    b = _principled(nt)
    tc = nt.nodes.new("ShaderNodeTexCoord")
    ln = nt.nodes.new("ShaderNodeVectorMath")
    ln.operation = "LENGTH"
    mr = nt.nodes.new("ShaderNodeMapRange")
    mr.interpolation_type = "SMOOTHSTEP"
    mr.inputs["From Min"].default_value = r * 0.35
    mr.inputs["From Max"].default_value = r * 0.98
    mx = nt.nodes.new("ShaderNodeMix")
    mx.data_type = "RGBA"
    mx.inputs[6].default_value = (*GRASS, 1)
    mx.inputs[7].default_value = (*GRASS_RIM, 1)
    nt.links.new(tc.outputs["Object"], ln.inputs[0])
    nt.links.new(ln.outputs["Value"], mr.inputs["Value"])
    nt.links.new(mr.outputs["Result"], mx.inputs["Factor"])
    nt.links.new(mx.outputs[2], b.inputs["Base Color"])
    me.materials.append(toon_material(mat, "building"))
    bpy.data.materials.remove(mat)
    g = bpy.data.objects.new(PREFIX + "Ground", me)
    g.location = ((lo.x + hi.x) / 2, (lo.y + hi.y) / 2, min(0.0, lo.z) - 0.005)
    _col().objects.link(g)
    g["tp_ground"] = True
    return g


# ----------------------------------------------------------------------------------------------------------------
# Glow check (style guide 3.1: a lit pixel keeps saturation >= 50% and its hue within 15 degrees of its key)

MASK_COLOURS = [(1, 0, 0), (0, 1, 0), (0, 0, 1), (1, 1, 0), (0, 1, 1), (1, 0, 1)]


def _emit_mat(name, rgb):
    mat = bpy.data.materials.get(name) or bpy.data.materials.new(name)
    mat.use_nodes = True
    nt = mat.node_tree
    for n in list(nt.nodes):
        nt.nodes.remove(n)
    out = nt.nodes.new("ShaderNodeOutputMaterial")
    em = nt.nodes.new("ShaderNodeEmission")
    em.inputs["Color"].default_value = (*rgb, 1)
    nt.links.new(em.outputs[0], out.inputs["Surface"])
    return mat


def _srgb(c):
    return tuple(12.92 * x if x <= 0.0031308 else 1.055 * x ** (1 / 2.4) - 0.055 for x in (min(1.0, max(0.0, v)) for v in c))


def _hsv(rgb):
    """rgb (n, 3) in 0-1 -> hue degrees, saturation 0-1 (HSV)."""
    mx, mn = rgb.max(1), rgb.min(1)
    dl = np.maximum(mx - mn, 1e-9)
    r, g, b = rgb[:, 0], rgb[:, 1], rgb[:, 2]
    h = np.where(mx == r, ((g - b) / dl) % 6, np.where(mx == g, (b - r) / dl + 2, (r - g) / dl + 4)) * 60.0
    s = np.where(mx > 1e-9, (mx - mn) / np.maximum(mx, 1e-9), 0.0)
    return h, s


def _load_px(path):
    img = bpy.data.images.load(path, check_existing=False)
    px = np.array(img.pixels[:], dtype=np.float32).reshape(img.size[1], img.size[0], 4)[:, :, :3]
    bpy.data.images.remove(img)
    return px


def glow_check(visible, beauty_png, res, mask_png):
    """Renders an ID mask of the glowing materials of the visible toon objects (one flat colour per glow material)
    and measures the beauty render's pixels inside each mask (eroded by 1 px). Returns a list of dicts:
    material, key (sRGB hex of the material's emission colour), pixels, hue, sat (medians), pass (fraction of
    pixels with sat >= 0.5 and hue within 15 deg of the key)."""
    sc = bpy.context.scene
    glow = {}
    for o in visible:
        if o.type != "MESH":
            continue
        for m in o.data.materials:
            if m is not None and m.get("tp_glow") and m.name not in glow and len(glow) < len(MASK_COLOURS):
                glow[m.name] = MASK_COLOURS[len(glow)]
    if not glow:
        return []
    black = _emit_mat(PREFIX + "MaskOff", (0, 0, 0))
    hull_black = _emit_mat(PREFIX + "MaskHull", (0, 0, 0))
    hull_black.use_backface_culling = True  # like the outline materials: the hull is an inverted shell
    masks = {k: _emit_mat(PREFIX + "Mask%d" % i, c) for i, (k, c) in enumerate(glow.items())}
    saved = []
    for o in visible:
        if o.type != "MESH":
            continue
        mats = list(o.data.materials)
        saved.append((o, mats))
        for i, m in enumerate(mats):
            off = hull_black if o.get("tp_hull") else black
            o.data.materials[i] = masks.get(m.name, off) if m is not None else off
    world, samples = sc.world, sc.eevee.taa_render_samples
    sc.world = None
    try:
        preview.render(mask_png, res, 1)
    finally:
        sc.world = world
        sc.eevee.taa_render_samples = samples
        for o, mats in saved:
            for i, m in enumerate(mats):
                o.data.materials[i] = m
    mk, bt = _load_px(mask_png), _load_px(beauty_png)
    out = []
    for name, c in glow.items():
        sel = np.all(np.abs(mk - np.array(c, dtype=np.float32)) < 0.2, axis=2)
        core = sel.copy()
        core[1:, :] &= sel[:-1, :]
        core[:-1, :] &= sel[1:, :]
        core[:, 1:] &= sel[:, :-1]
        core[:, :-1] &= sel[:, 1:]
        mat = bpy.data.materials.get(name)
        key = mat.get("tp_glow_key") if mat is not None else None
        rec = {"material": name.replace(PREFIX, "", 1), "pixels": int(core.sum())}
        if key is not None:
            ks = np.array([_srgb(key)])
            kh, kss = _hsv(ks)
            rec["key"] = "#%02X%02X%02X" % tuple(int(round(v * 255)) for v in ks[0])
            rec["key_hue"], rec["key_sat"] = float(kh[0]), float(kss[0])
        if rec["pixels"]:
            h, s = _hsv(bt[core].astype(np.float64))
            rec["hue"] = float(np.degrees(np.angle(np.mean(np.exp(1j * np.radians(h))))) % 360)
            rec["sat"] = float(np.median(s))
            if key is not None:
                dh = np.abs((h - rec["key_hue"] + 180) % 360 - 180)
                rec["pass"] = float(np.mean((s >= 0.5) & (dh <= 15)))
        out.append(rec)
    return out


# ----------------------------------------------------------------------------------------------------------------
# Tiles and sheets


def _height(objs):
    lo, hi = preview.bounds([o for o in objs if not o.get("tp_hull") and not o.get("tp_figure")])
    return hi.z - lo.z


def label_for(name, height):
    n = name[len(PREFIX):] if name.startswith(PREFIX) else name
    for p in ("mon_", "AB_"):
        if n.startswith(p):
            n = n[len(p):]
    return "%s %.2f m" % (n.replace("_", " "), height) if height < 10 else "%s %.1f m" % (n.replace("_", " "), height)


def render_tiles(objs, tile_dir, kind="creature", tile=(320, 320), yaw=-35.0, pitch=None, samples=12,
                 figure=None, margin=MARGIN, glow_report=False, restore_scene=True, log=print):
    """Renders each object of objs on its own in the toon preview, to tile_dir/<name>.png.
    figure: add the 1.7 m scale figure (default: creatures only). Returns [(png path, label)] where the label
    carries the subject's height in metres. With glow_report, each tile with glowing materials is also measured
    (glow_check) and the records are stored as tiles' third element. restore_scene puts the scene back afterwards
    (originals visible, toon objects deleted, world/colour settings restored) so a library .blend can be saved."""
    sc = bpy.context.scene
    w, h = _tile_wh(tile)
    pitch = PITCH.get(kind, 16.0) if pitch is None else pitch
    figure = (kind == "creature") if figure is None else figure
    state = _scene_state(sc)
    setup_world(sc)
    os.makedirs(tile_dir, exist_ok=True)
    groups, made_all = [], []
    for o in objs:
        made = apply([o], kind=kind, tile=(w, h), yaw=yaw, pitch=pitch, margin=margin)
        subj = [x for x in made if not x.get("tp_hull")]
        extra = []
        if figure and subj:
            extra.append(add_scale_figure(subj, yaw=yaw))
        if subj:
            extra.append(ground_for(subj))
        groups.append((o.name, made + extra, subj))
        made_all += made + extra
    others = [x for x in objs]
    out = []
    for name, vis, subj in groups:
        keep = set(x.name for x in vis)
        for x in made_all + others:
            x.hide_render = x.name not in keep
        p = os.path.join(tile_dir, name + ".png")
        cam, fill = camera(subj, yaw, pitch, (w, h), margin)
        t0 = time.time()
        preview.render(p, (w, h), samples)
        lab = label_for(name, _height(subj))
        rec = (p, lab)
        if glow_report:
            rec = (p, lab, glow_check(vis, p, (w, h), os.path.join(tile_dir, "_mask_" + name + ".png")))
        log("TILE %s %.1fs fill %.0f%% '%s'" % (name, time.time() - t0, fill * 100, lab))
        out.append(rec)
    if restore_scene:
        for x in made_all:
            if x.get("tp_figure") or x.get("tp_ground"):
                me = x.data
                bpy.data.objects.remove(x, do_unlink=True)
                if me.users == 0:
                    bpy.data.meshes.remove(me)
        restore([x for x in made_all if x.name in bpy.data.objects])
        _restore_state(sc, state)
    return out


def _scene_state(sc):
    vs = sc.view_settings
    return dict(world=sc.world, engine=sc.render.engine, vt=vs.view_transform, look=vs.look, exp=vs.exposure,
                gamma=vs.gamma, camera=sc.camera)


def _restore_state(sc, s):
    sc.world = s["world"]
    try:
        sc.render.engine = s["engine"]
        sc.view_settings.view_transform = s["vt"]
        sc.view_settings.look = s["look"]
    except TypeError:
        pass
    sc.view_settings.exposure = s["exp"]
    sc.view_settings.gamma = s["gamma"]
    sc.camera = s["camera"]
    sun = bpy.data.objects.get(PREFIX + "Sun")
    if sun is not None:
        bpy.data.objects.remove(sun, do_unlink=True)
    for nm in ("AB_Sun", "AB_Ground"):
        o = bpy.data.objects.get(nm)
        if o is not None:
            o.hide_render = False
    col = bpy.data.collections.get(PREFIX + "Rig")
    if col is not None and not col.objects:
        bpy.data.collections.remove(col)


# 5 x 7 bitmap font for tile labels (upper case, digits, ". - : / ( )" and a lower-case "m" for metres)
_FONT = {
    "A": "01110 10001 10001 11111 10001 10001 10001", "B": "11110 10001 10001 11110 10001 10001 11110",
    "C": "01110 10001 10000 10000 10000 10001 01110", "D": "11110 10001 10001 10001 10001 10001 11110",
    "E": "11111 10000 10000 11110 10000 10000 11111", "F": "11111 10000 10000 11110 10000 10000 10000",
    "G": "01110 10001 10000 10111 10001 10001 01111", "H": "10001 10001 10001 11111 10001 10001 10001",
    "I": "01110 00100 00100 00100 00100 00100 01110", "J": "00111 00010 00010 00010 00010 10010 01100",
    "K": "10001 10010 10100 11000 10100 10010 10001", "L": "10000 10000 10000 10000 10000 10000 11111",
    "M": "10001 11011 10101 10101 10001 10001 10001", "N": "10001 10001 11001 10101 10011 10001 10001",
    "O": "01110 10001 10001 10001 10001 10001 01110", "P": "11110 10001 10001 11110 10000 10000 10000",
    "Q": "01110 10001 10001 10001 10101 10010 01101", "R": "11110 10001 10001 11110 10100 10010 10001",
    "S": "01111 10000 10000 01110 00001 00001 11110", "T": "11111 00100 00100 00100 00100 00100 00100",
    "U": "10001 10001 10001 10001 10001 10001 01110", "V": "10001 10001 10001 10001 10001 01010 00100",
    "W": "10001 10001 10001 10101 10101 10101 01010", "X": "10001 10001 01010 00100 01010 10001 10001",
    "Y": "10001 10001 10001 01010 00100 00100 00100", "Z": "11111 00001 00010 00100 01000 10000 11111",
    "0": "01110 10001 10011 10101 11001 10001 01110", "1": "00100 01100 00100 00100 00100 00100 01110",
    "2": "01110 10001 00001 00010 00100 01000 11111", "3": "11111 00010 00100 00010 00001 10001 01110",
    "4": "00010 00110 01010 10010 11111 00010 00010", "5": "11111 10000 11110 00001 00001 10001 01110",
    "6": "00110 01000 10000 11110 10001 10001 01110", "7": "11111 00001 00010 00100 01000 01000 01000",
    "8": "01110 10001 10001 01110 10001 10001 01110", "9": "01110 10001 10001 01111 00001 00010 01100",
    ".": "00000 00000 00000 00000 00000 01100 01100", "-": "00000 00000 00000 11111 00000 00000 00000",
    ":": "00000 01100 01100 00000 01100 01100 00000", "/": "00001 00001 00010 00100 01000 10000 10000",
    "(": "00010 00100 01000 01000 01000 00100 00010", ")": "01000 00100 00010 00010 00010 00100 01000",
    "m": "00000 00000 11010 10101 10101 10101 10101", " ": "00000 00000 00000 00000 00000 00000 00000",
}
LABEL_H = 24
LABEL_BG = lin("#F6ECD6")
LABEL_INK = lin("#3B2A1A")


def _draw_text(band, text, ink):
    """Draws text centred into band (h, w, 3), top row first, at scale 2 (1 if it does not fit)."""
    h, w = band.shape[:2]
    text = "".join(c if c == "m" and (i > 0 and text[i - 1] == " ") and i == len(text) - 1 else c.upper()
                   for i, c in enumerate(text))
    for sc_ in (2, 1):
        adv = 6 * sc_
        if len(text) * adv - sc_ <= w - 8:
            break
    tw = len(text) * adv - sc_
    x0, y0 = max(2, (w - tw) // 2), (h - 7 * sc_) // 2
    for i, ch in enumerate(text):
        g = _FONT.get(ch, _FONT[" "]).split()
        for r, row in enumerate(g):
            for c, bit in enumerate(row):
                if bit == "1":
                    y, x = y0 + r * sc_, x0 + i * adv + c * sc_
                    if x + sc_ <= w:
                        band[y:y + sc_, x:x + sc_] = ink
    return band


def sheet(tiles, out, cols=4, tile=(320, 320)):
    """Tiles [(png, label[, ...])] or [png] into one PNG, with a label band under every labelled tile."""
    w, h = _tile_wh(tile)
    labelled = any(isinstance(t, (list, tuple)) for t in tiles)
    bh = LABEL_H if labelled else 0
    cols = max(1, min(cols, len(tiles)))
    rows = (len(tiles) + cols - 1) // cols
    th = h + bh
    img = np.ones((rows * th, cols * w, 3), dtype=np.float32)  # top row first
    for i, t in enumerate(tiles):
        p, lab = (t[0], t[1]) if isinstance(t, (list, tuple)) else (t, None)
        px = _load_px(p)[::-1]  # Blender stores the bottom row first
        r, c = divmod(i, cols)
        y0, x0 = r * th, c * w
        img[y0:y0 + h, x0:x0 + w] = px[:h, :w]
        if bh:
            band = np.empty((bh, w, 3), dtype=np.float32)
            band[:] = _srgb(LABEL_BG)
            if lab:
                _draw_text(band, lab, np.array(_srgb(LABEL_INK), dtype=np.float32))
            img[y0 + h:y0 + th, x0:x0 + w] = band
    flat = np.concatenate([img[::-1], np.ones(img.shape[:2] + (1,), dtype=np.float32)], axis=2)
    im = bpy.data.images.new(PREFIX + "Sheet", cols * w, rows * th, alpha=False)
    im.pixels[:] = flat.ravel()
    im.filepath_raw = out
    im.file_format = "PNG"
    im.save()
    bpy.data.images.remove(im)
    return out
