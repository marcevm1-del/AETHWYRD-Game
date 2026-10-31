"""
Toon preview mode for contact sheets (design review 2026-10-25, R1).

Approximates the in-game `Ascend/Toon` look inside Blender (EEVEE) so a contact sheet can be used to approve a look:

* two tones per material: Shader-to-RGB of a white diffuse lit by one sun -> constant ramp
  (lit = base colour, shadow = base x (0.58, 0.56, 0.78)), cast shadows included;
* a soft cream rim (0.35) on creatures;
* ink outlines as an inverted hull (outline colour = local colour x 0.35), sized in pixels at the tile size;
  Freestyle is switched on instead if the hull cannot be built;
* a painted-sky world (pale warm horizon -> soft blue) that does not light the subject;
* a light-grass ground disc 3x the subject's bounds, fading into the horizon haze at its rim;
* for creatures, a 1.7 m flat-grey human silhouette standing one body-width to the side.

Everything is built on copies: the subject is baked to a new mesh (building instances realised) and its materials
are copied, so the generators' shared materials and objects are untouched (the originals are only hidden).

    import toon_preview as tp
    tp.setup_world()
    fig = tp.add_scale_figure(obj)                    # creatures only
    group = tp.apply([obj, fig], kind="creature", tile=320)
    ground = tp.ground_for(group)
"""
import math

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
MARGIN = 1.15       # the camera margin the sheet uses (preview.camera)
FIGURE_HEIGHT = 1.7
FIGURE_RADIUS = 0.17
FIGURE_GREY = (0.56, 0.57, 0.6)


def lin(c):
    """sRGB (0-1 floats or '#rrggbb') -> linear, for node colours."""
    if isinstance(c, str):
        c = tuple(int(c.lstrip("#")[i:i + 2], 16) / 255.0 for i in (0, 2, 4))
    return tuple(x / 12.92 if x <= 0.04045 else ((x + 0.055) / 1.055) ** 2.4 for x in c[:3])


GRASS = lin("#8CC860")
HAZE = lin("#BFD9A0")       # distant fields, also the world below the horizon
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
    if glowing:  # keep emissive parts (lamps, cores, glow cracks) bright
        es = N.new("ShaderNodeMath")
        es.operation = "MULTIPLY"
        es.inputs[1].default_value = 0.5
        _feed(nt, estr[0], estr[1], es.inputs[0])
        em, ea, eb, eres = _mix(nt, "MULTIPLY")
        _feed(nt, ecol[0], ecol[1], ea)
        L.new(es.outputs[0], eb)  # float -> grey colour
        add, aa, ab, ares = _mix(nt, "ADD")
        L.new(col, aa)
        L.new(eres, ab)
        col = ares
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


def outline_thickness(objs, kind="creature", tile=320, margin=MARGIN):
    """World-space hull thickness that reads as OUTLINE_PX at the tile size when the camera frames objs."""
    lo, hi = preview.bounds(objs)
    size = (hi - lo).length
    return OUTLINE_PX.get(kind, 1.5) * size * margin / float(tile)


def apply(objs, kind="creature", tile=320, frame=None):
    """Bakes objs to toon copies with inverted-hull outlines. frame: the objects the camera will frame (defaults to
    objs) so the outline is sized in pixels. Returns the new objects (copies + hulls); the originals are hidden
    (pass the returned list to restore() to undo in a live session)."""
    dg = bpy.context.evaluated_depsgraph_get()
    t = outline_thickness(frame or objs, kind, tile)
    toon_cache, ol_cache, made = {}, {}, []
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
        made.append(c)
        try:
            made.append(_hull(c, t, ol_cache))
        except Exception as e:  # fallback: screen-space Freestyle lines
            print("TOON hull failed on %s (%s); using Freestyle" % (o.name, e))
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


def _capsule(bm, r, z0, z1, segs=16, rings=10):
    """A capsule of radius r from z0 to z1 (bottom to top) added to bm."""
    res = bmesh.ops.create_uvsphere(bm, u_segments=segs, v_segments=rings, radius=r)
    mid = (z1 - z0) - 2 * r
    for v in res["verts"]:
        v.co.z += (z0 + r) + (mid if v.co.z > 1e-6 else 0.0)


def _extent_along(obj, centre, right):
    """How far obj's evaluated vertices reach from centre along the (horizontal) right vector."""
    dg = bpy.context.evaluated_depsgraph_get()
    ev = obj.evaluated_get(dg)
    try:
        me = ev.to_mesh()
        n = len(me.vertices)
        co = np.empty(n * 3, dtype=np.float64)
        me.vertices.foreach_get("co", co)
        ev.to_mesh_clear()
        m = np.array(obj.matrix_world)
        w = co.reshape(-1, 3) @ m[:3, :3].T + m[:3, 3]
        r = np.array([right.x, right.y, 0.0])
        return float(((w - np.array([centre.x, centre.y, 0.0])) @ r).max()) if n else 0.0
    except Exception:
        lo, hi = preview.bounds([obj])
        return max((Vector((x, y, 0)) - Vector((centre.x, centre.y, 0))).dot(right)
                   for x in (lo.x, hi.x) for y in (lo.y, hi.y))


def add_scale_figure(obj, yaw=-35.0, gap=0.45):
    """A 1.7 m flat-grey human silhouette standing a body-width beside obj, on the camera's right."""
    lo, hi = preview.bounds([obj])
    centre = (lo + hi) / 2
    right = Vector((math.cos(math.radians(yaw)), math.sin(math.radians(yaw)), 0.0))
    ext = _extent_along(obj, centre, right)
    me = bpy.data.meshes.new(PREFIX + "Figure")
    bm = bmesh.new()
    head_r = 0.125
    _capsule(bm, FIGURE_RADIUS, 0.0, FIGURE_HEIGHT - 2 * head_r - 0.03)
    hs = bmesh.ops.create_uvsphere(bm, u_segments=16, v_segments=10, radius=head_r)
    for v in hs["verts"]:
        v.co.z += FIGURE_HEIGHT - head_r
    bm.to_mesh(me)
    bm.free()
    for p in me.polygons:
        p.use_smooth = True
    me.materials.append(_flat_material(PREFIX + "FigureGrey", lin(FIGURE_GREY)))
    fig = bpy.data.objects.new(PREFIX + "Figure_" + obj.name, me)
    pos = Vector((centre.x, centre.y, 0.0)) + right * (ext + gap + FIGURE_RADIUS)
    fig.location = (pos.x, pos.y, min(0.0, lo.z))
    for c in obj.users_collection:
        c.objects.link(fig)
    fig["tp_figure"] = True
    return fig


def ground_for(objs, scale=3.0, min_radius=4.0):
    """A light-grass disc with radius 3x the subjects' bounds, fading into the horizon haze at its rim."""
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
    mr.inputs["From Min"].default_value = r * 0.55
    mr.inputs["From Max"].default_value = r * 0.97
    mx = nt.nodes.new("ShaderNodeMix")
    mx.data_type = "RGBA"
    mx.inputs[6].default_value = (*GRASS, 1)
    mx.inputs[7].default_value = (*HAZE, 1)
    nt.links.new(tc.outputs["Object"], ln.inputs[0])
    nt.links.new(ln.outputs["Value"], mr.inputs["Value"])
    nt.links.new(mr.outputs["Result"], mx.inputs["Factor"])
    nt.links.new(mx.outputs[2], b.inputs["Base Color"])
    me.materials.append(toon_material(mat, "building"))
    bpy.data.materials.remove(mat)
    g = bpy.data.objects.new(PREFIX + "Ground", me)
    g.location = ((lo.x + hi.x) / 2, (lo.y + hi.y) / 2, min(0.0, lo.z) - 0.005)
    _col().objects.link(g)
    return g
