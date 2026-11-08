"""Blender plumbing shared by the character modules: MB -> mesh object, vertex groups, subdivision, colour attributes."""
import bmesh
import bpy
import numpy as np


def make_object(name, V, F, weights=None, collection=None, recalc=True, smooth=True):
    """Creates a mesh object from vertex positions V (n,3), faces F (index tuples) and optional per-vertex weight dicts."""
    me = bpy.data.meshes.new(name)
    bm = bmesh.new()
    verts = [bm.verts.new(tuple(v)) for v in V]
    bm.verts.ensure_lookup_table()
    seen = set()
    for f in F:
        key = tuple(sorted(f))
        if key in seen or len(set(f)) != len(f):
            continue
        seen.add(key)
        try:
            bm.faces.new([verts[i] for i in f])
        except ValueError:
            pass
    bm.edges.ensure_lookup_table()
    if recalc:
        bmesh.ops.recalc_face_normals(bm, faces=bm.faces[:])
    bm.to_mesh(me)
    bm.free()
    if smooth:
        me.shade_smooth()
    obj = bpy.data.objects.new(name, me)
    (collection or bpy.context.scene.collection).objects.link(obj)
    if weights is not None:
        set_weights(obj, weights)
    return obj


def set_weights(obj, weights):
    """weights: list (per vertex) of {bone name: weight}."""
    groups = {}
    for i, w in enumerate(weights):
        for b, v in w.items():
            groups.setdefault(b, []).append((i, v))
    for b in sorted(groups):
        vg = obj.vertex_groups.get(b) or obj.vertex_groups.new(name=b)
        for i, v in groups[b]:
            vg.add([i], float(v), "REPLACE")


def get_weights(obj):
    """Per-vertex {bone name: weight} from the vertex groups."""
    names = {g.index: g.name for g in obj.vertex_groups}
    return [{names[g.group]: g.weight for g in v.groups if g.weight > 1e-6} for v in obj.data.vertices]


def subdivide(obj, levels=1):
    """Applies a Catmull-Clark subdivision (vertex groups interpolate)."""
    if levels <= 0:
        return obj
    md = obj.modifiers.new("Subsurf", "SUBSURF")
    md.levels = levels
    md.render_levels = levels
    md.quality = 3
    md.use_limit_surface = False
    with bpy.context.temp_override(object=obj, active_object=obj, selected_objects=[obj], selected_editable_objects=[obj]):
        bpy.ops.object.modifier_apply(modifier=md.name)
    obj.data.shade_smooth()
    return obj


def co(obj):
    n = len(obj.data.vertices)
    a = np.empty(n * 3, dtype=np.float32)
    obj.data.vertices.foreach_get("co", a)
    return a.reshape(n, 3).astype(np.float64)


def set_co(obj, a):
    obj.data.vertices.foreach_set("co", np.asarray(a, dtype=np.float32).ravel())
    obj.data.update()


def set_colours(obj, rgb):
    """Per-vertex linear colours (n,3) as the 'Col' point attribute the toon materials read."""
    me = obj.data
    n = len(me.vertices)
    col = np.ones((n, 4), dtype=np.float32)
    col[:, :3] = rgb
    a = me.attributes.get("Col")
    if a is not None:
        me.attributes.remove(a)
    me.attributes.new("Col", "FLOAT_COLOR", "POINT").data.foreach_set("color", col.ravel())


def normals(obj):
    n = len(obj.data.vertices)
    a = np.empty(n * 3, dtype=np.float32)
    obj.data.vertex_normals.foreach_get("vector", a)
    return a.reshape(n, 3).astype(np.float64)


def edge_report(obj):
    """(open edges, non-manifold edges, loose verts) of a mesh object, for the topology report."""
    bm = bmesh.new()
    bm.from_mesh(obj.data)
    open_e = sum(1 for e in bm.edges if len(e.link_faces) == 1)
    bad = sum(1 for e in bm.edges if len(e.link_faces) > 2)
    loose = sum(1 for v in bm.verts if not v.link_edges)
    quads = sum(1 for f in bm.faces if len(f.verts) == 4)
    tris = sum(1 for f in bm.faces if len(f.verts) == 3)
    ngons = len(bm.faces) - quads - tris
    bm.free()
    return dict(open=open_e, nonmanifold=bad, loose=loose, quads=quads, tris=tris, ngons=ngons)


def tri_count(obj):
    return sum(len(p.vertices) - 2 for p in obj.data.polygons)
