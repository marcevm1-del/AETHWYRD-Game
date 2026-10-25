"""
Bakes the high-poly procedural sources down to game-weight meshes for Unity (budgets: 13_Production/art_budgets.md).

    blender -b --factory-startup -P Tools/blender/bake_to_game.py -- \
        --creatures mon_blue_slime,mon_goblin --buildings house:whisperwood,inn:whisperwood[:seed]
    (add --sheet 13_Production/screenshots/game_ready_ring0.png for a before/after contact sheet,
     --out <dir> to export elsewhere, --no-export to only measure)

For every asset it writes Art/Blender/GameReady/<kind>/<id>_LOD0.fbx, _LOD1.fbx, _LOD2.fbx and _COL.fbx, and
records the numbers in Art/Blender/GameReady/report.json.

How each kind is reduced:
  - Buildings (ascend_buildings, realized with generate.set_realize): every tile, brick and plank is its own
    piece, so a straight decimate would tear the roof apart. Instead the realized mesh is voxel-remeshed into one
    watertight shell, planar faces are dissolved, faces nothing outside can see (the hollow interior behind closed
    walls, the underside of the footing) are removed, and quadric collapse takes it to the LOD0 budget; LOD1 and
    LOD2 collapse from the previous level. The flat-colour material slots are then carried back from the source by
    nearest-face lookup (a 4-sample majority per face) and slots with the same colour are merged.
  - Creatures (ascend_creatures): the metaball body is already one clean shell, so quadric collapse runs directly.
    The painted per-vertex colour (attribute "Col") and the hard parts' material slots survive the collapse; Col is
    exported as the FBX vertex colour.
  - Collider (_COL): the convex hull of LOD2, collapsed to at most 250 triangles (under Unity's 255-triangle
    convex MeshCollider limit) and re-hulled so it stays convex.
Normal maps are not baked yet (see art_budgets.md, "Next steps").
"""
import json
import math
import os
import sys
import time
from collections import Counter

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(os.path.dirname(HERE))
sys.path.insert(0, HERE)

import bmesh  # noqa: E402
import bpy  # noqa: E402
import numpy as np  # noqa: E402
from mathutils import Matrix, Vector  # noqa: E402
from mathutils.bvhtree import BVHTree  # noqa: E402

# ----------------------------------------------------------------------------------------------------------------
# Budgets (keep in step with 13_Production/art_budgets.md): (LOD0, LOD1, LOD2) triangles, max material slots

BUILDING_BUDGETS = {
    "small": ((1500, 600, 200), 4),
    "medium": ((8000, 3000, 1000), 8),
    "large": ((15000, 6000, 2000), 10),
    "landmark": ((30000, 12000, 4000), 12),
}
CREATURE_BUDGETS = {
    "trash_small": ((3000, 1200, 400), 6),
    "trash": ((6000, 2400, 800), 6),
    "elite": ((10000, 4000, 1200), 8),
    "boss": ((25000, 10000, 3000), 10),
    "giant": ((40000, 15000, 5000), 10),
}
COLLIDER_MAX_TRIS = 250
NEAR_TONE = 0.07  # sRGB distance under which two slot colours count as one tone

BUILDING_CLASS = {}
for _cls, _names in {
    "small": "well lamp_post market_stall shrine fountain tent torii_gate wall_segment",
    "medium": "cottage house townhouse shop smithy stable granary stilt_house yurt mushroom_house mushroom_shop "
              "tree_house adobe_tower longhouse bridge paifang_gate",
    "large": "inn tavern manor barn warehouse mill library bathhouse barracks longhouse_hall temple yurt_large "
             "tent_large mushroom_cluster mushroom_tower watchtower gatehouse",
    "landmark": "guild_hall town_hall pagoda lighthouse stepped_pyramid domed_hall adobe_mosque_hall",
}.items():
    for _n in _names.split():
        BUILDING_CLASS[_n] = _cls


def creature_class(sp):
    size = float(sp.get("sizeMeters") or 1.0)
    if size >= 8.0:
        return "giant"
    if (sp.get("bossHpMult") or 1) > 1 or sp.get("isUnique"):
        return "boss"
    if sp.get("variantKind") in ("elder", "ancient"):
        return "elite"
    return "trash_small" if size < 0.8 else "trash"


# ----------------------------------------------------------------------------------------------------------------
# Mesh helpers

def tris(obj):
    me = obj.data
    me.calc_loop_triangles()
    return len(me.loop_triangles)


def collection():
    col = bpy.data.collections.get("GameReady")
    if col is None:
        col = bpy.data.collections.new("GameReady")
        bpy.context.scene.collection.children.link(col)
    return col


def apply_modifier(obj, mod):
    dg = bpy.context.evaluated_depsgraph_get()
    me = bpy.data.meshes.new_from_object(obj.evaluated_get(dg), preserve_all_data_layers=True, depsgraph=dg)
    old = obj.data
    obj.modifiers.remove(mod)
    obj.data = me
    if old.users == 0:
        bpy.data.meshes.remove(old)


def duplicate(obj, name):
    o = obj.copy()
    o.data = obj.data.copy()
    o.name = name
    o.data.name = name
    for m in list(o.modifiers):
        o.modifiers.remove(m)
    collection().objects.link(o)
    return o


def mesh_object(name, me):
    o = bpy.data.objects.new(name, me)
    collection().objects.link(o)
    return o


def remesh(obj, voxel):
    m = obj.modifiers.new("vox", "REMESH")
    m.mode = "VOXEL"
    m.voxel_size = voxel
    m.adaptivity = 0.0
    m.use_smooth_shade = False
    apply_modifier(obj, m)


def smooth(obj, iterations=6, factor=0.5):
    """Irons out the voxelised tile and stone bumps, which two-tone cel shading would turn into shadow blotches.
    (The plain smooth modifier: Laplacian smooth's linear solve takes minutes on a half-million-triangle shell.)"""
    m = obj.modifiers.new("smooth", "SMOOTH")
    m.iterations = iterations
    m.factor = factor
    apply_modifier(obj, m)


def weighted_normals(obj, sharp_deg=40.0):
    """Face-area weighted custom normals: big flat faces set the shading, so the small faces left by collapsed
    tile steps don't mottle a roof under cel shading. Edges sharper than sharp_deg stay split."""
    me = obj.data
    me.polygons.foreach_set("use_smooth", [True] * len(me.polygons))
    try:
        me.set_sharp_from_angle(angle=math.radians(sharp_deg))
    except AttributeError:
        pass
    m = obj.modifiers.new("wn", "WEIGHTED_NORMAL")
    m.mode = "FACE_AREA"
    m.weight = 100
    m.keep_sharp = True
    apply_modifier(obj, m)


def dissolve_planar(obj, deg=1.0):
    m = obj.modifiers.new("planar", "DECIMATE")
    m.decimate_type = "DISSOLVE"
    m.angle_limit = math.radians(deg)
    apply_modifier(obj, m)


def decimate_to(obj, target):
    for _ in range(4):
        t = tris(obj)
        if t <= target * 1.01:
            return t
        m = obj.modifiers.new("collapse", "DECIMATE")
        m.decimate_type = "COLLAPSE"
        m.ratio = max(1e-4, target / t * (0.995 if _ else 1.0))
        m.use_collapse_triangulate = True
        apply_modifier(obj, m)
    return tris(obj)


def triangulate(obj):
    m = obj.modifiers.new("tri", "TRIANGULATE")
    apply_modifier(obj, m)


def fib_dirs(n):
    g = math.pi * (3 - math.sqrt(5))
    out = []
    for i in range(n):
        z = 1 - 2 * (i + 0.5) / n
        r = math.sqrt(max(0.0, 1 - z * z))
        out.append(Vector((math.cos(g * i) * r, math.sin(g * i) * r, z)))
    return out


def strip_hidden(obj, rays=48, ground=0.12):
    """Deletes faces no ray from outside can reach: the shell's hollow interior behind closed walls, and the
    downward faces at ground level. Interior faces seen through a window or door stay."""
    bm = bmesh.new()
    bm.from_mesh(obj.data)
    bvh = BVHTree.FromBMesh(bm)
    lo = Vector([min(v.co[i] for v in bm.verts) for i in range(3)])
    hi = Vector([max(v.co[i] for v in bm.verts) for i in range(3)])
    far = (hi - lo).length * 2 + 1
    dirs = fib_dirs(rays)
    kill = []
    for f in bm.faces:
        n = f.normal
        c = f.calc_center_median()
        if n.length < 0.5:
            continue
        if n.z < -0.7 and c.z < lo.z + ground:
            kill.append(f)
            continue
        o = c + n * 0.01
        seen = False
        for d in dirs:
            if d.dot(n) < 0.08:
                continue
            if bvh.ray_cast(o, d, far)[0] is None:
                seen = True
                break
        if not seen:
            kill.append(f)
    bmesh.ops.delete(bm, geom=kill, context="FACES_ONLY")
    bmesh.ops.delete(bm, geom=[v for v in bm.verts if not v.link_faces], context="VERTS")
    bm.to_mesh(obj.data)
    bm.free()
    return len(kill)


class FaceLookup:
    """Nearest source face -> material index, for carrying material slots onto a remeshed LOD."""

    def __init__(self, src):
        me = src.data
        me.calc_loop_triangles()
        n = len(me.loop_triangles)
        co = np.empty(len(me.vertices) * 3, dtype=np.float32)
        me.vertices.foreach_get("co", co)
        tv = np.empty(n * 3, dtype=np.int32)
        me.loop_triangles.foreach_get("vertices", tv)
        tp = np.empty(n, dtype=np.int32)
        me.loop_triangles.foreach_get("polygon_index", tp)
        mi = np.empty(len(me.polygons), dtype=np.int32)
        me.polygons.foreach_get("material_index", mi)
        self.mat_of_tri = mi[tp]
        self.bvh = BVHTree.FromPolygons(co.reshape(-1, 3).tolist(), tv.reshape(-1, 3).tolist(), all_triangles=True)
        self.materials = list(me.materials)

    def transfer(self, obj):
        me = obj.data
        me.materials.clear()
        for m in self.materials:
            me.materials.append(m)
        idx = np.zeros(len(me.polygons), dtype=np.int32)
        verts = me.vertices
        for p in me.polygons:
            c = p.center
            vs = [verts[v].co for v in p.vertices[:3]]
            pts = [c] + [c.lerp(v, 0.66) for v in vs] + [c.lerp((vs[k] + vs[(k + 1) % 3]) / 2, 0.66) for k in range(3)]
            votes = Counter()
            for q in pts:
                hit = self.bvh.find_nearest(q)
                if hit[2] is not None:
                    votes[int(self.mat_of_tri[hit[2]])] += 1
            if votes:
                idx[p.index] = votes.most_common(1)[0][0]
        me.polygons.foreach_set("material_index", idx)
        me.update()


def material_key(m):
    if m is None:
        return ("none",)
    if m.node_tree and any(n.type == "ATTRIBUTE" for n in m.node_tree.nodes):
        return ("attr", m.name)  # the creature skin: painted per vertex, never merged with a flat colour
    emit = 0.0
    if m.node_tree:
        b = next((n for n in m.node_tree.nodes if n.type == "BSDF_PRINCIPLED"), None)
        if b is not None and "Emission Strength" in b.inputs:
            emit = b.inputs["Emission Strength"].default_value
    return tuple(round(c * 64) for c in m.diffuse_color[:3]) + (emit > 0,)


def merge_materials(obj):
    """Drops unused slots and merges slots of the same flat colour."""
    me = obj.data
    if not me.materials:
        return 0
    idx = np.empty(len(me.polygons), dtype=np.int32)
    me.polygons.foreach_get("material_index", idx)
    mats = list(me.materials)
    keys, new, remap = {}, [], {}
    for i in sorted(set(idx.tolist())):
        if i >= len(mats):
            i = len(mats) - 1
        k = material_key(mats[i])
        if k not in keys:
            keys[k] = len(new)
            new.append(mats[i])
        remap[i] = keys[k]
    lut = np.array([remap.get(i, 0) for i in range(max(len(mats), int(idx.max()) + 1))], dtype=np.int32)
    me.materials.clear()
    for m in new:
        me.materials.append(m)
    me.polygons.foreach_set("material_index", lut[idx])
    me.update()
    return len(new)


def srgb(c):
    return np.power(np.clip(np.asarray(c, dtype=np.float64), 0, 1), 1 / 2.2)


def merge_to_budget(obj, max_slots):
    """Folds the smallest-area slot into the slot nearest in colour until the asset fits its slot budget. The skin
    (painted) slot is never folded; glowing slots only fold into glowing ones. The exact colours stay in "Col"."""
    me = obj.data
    mats = list(me.materials)
    mi = np.empty(len(me.polygons), dtype=np.int32)
    me.polygons.foreach_get("material_index", mi)
    ar = np.empty(len(me.polygons), dtype=np.float32)
    me.polygons.foreach_get("area", ar)
    area = {i: float(ar[mi == i].sum()) for i in range(len(mats))}
    keys = [material_key(m) for m in mats]
    col = [srgb(flat_colour(m)) for m in mats]
    alive = set(range(len(mats)))
    target = {i: i for i in alive}
    while True:
        # cheapest fold first: a small slot close in colour to another; small but distinct colours (blue
        # shutters, a red sign) outlive near-duplicate tones of a large surface
        best = None
        for i in alive:
            if keys[i][0] == "attr":
                continue
            glow = keys[i][-1] is True
            for j in alive:
                if j == i or keys[j][0] == "attr" or (keys[j][-1] is True) != glow:
                    continue
                dist = math.sqrt(float(((col[i] - col[j]) ** 2).sum()))
                cost = area[i] * dist if dist >= NEAR_TONE else -1.0 / (1e-6 + dist)
                if best is None or cost < best[0]:
                    best = (cost, i, j, dist)
        # near-duplicate tones (tile and plank shade variants) always fold: on a collapsed LOD they only show as
        # triangle-shaped patches; otherwise fold until the slot budget is met
        moved = best is not None and (len(alive) > max_slots or best[3] < NEAR_TONE)
        if moved:
            _, i, j, _d = best
            alive.discard(i)
            area[j] += area[i]
            for k, v in target.items():
                if v == i:
                    target[k] = j
        if not moved:
            break
    order = sorted(alive)
    slot = {j: n for n, j in enumerate(order)}
    lut = np.array([slot[target[i]] for i in range(len(mats))], dtype=np.int32)
    me.materials.clear()
    for j in order:
        me.materials.append(mats[j])
    me.polygons.foreach_set("material_index", lut[np.clip(mi, 0, len(mats) - 1)])
    me.update()
    return len(order)


def flat_colour(m):
    """The colour a slot shows: its Principled base colour (the viewport colour as a fallback)."""
    if m is None:
        return (1.0, 1.0, 1.0)
    b = next((n for n in m.node_tree.nodes if n.type == "BSDF_PRINCIPLED"), None) if m.node_tree else None
    if b is not None and not b.inputs["Base Color"].is_linked:
        return tuple(b.inputs["Base Color"].default_value[:3])
    return tuple(m.diffuse_color[:3])


def write_colour(obj):
    """Writes each face's slot colour into the corner colour attribute "Col" (linear float), keeping painted
    per-vertex colour where the slot already reads "Col" (the creature skin). With it every LOD can also be drawn
    with one vertex-coloured material, which is how the draw-call budget is met (art_budgets.md)."""
    me = obj.data
    nl = len(me.loops)
    old = me.color_attributes.get("Col")
    painted = None
    if old is not None:
        if old.domain == "POINT":
            pv = np.empty(len(me.vertices) * 4, dtype=np.float32)
            old.data.foreach_get("color", pv)
            lv = np.empty(nl, dtype=np.int32)
            me.loops.foreach_get("vertex_index", lv)
            painted = pv.reshape(-1, 4)[lv]
        else:
            painted = np.empty(nl * 4, dtype=np.float32)
            old.data.foreach_get("color", painted)
            painted = painted.reshape(-1, 4)
        me.color_attributes.remove(old)
    keep = [material_key(m)[0] == "attr" for m in me.materials]
    cols = np.array([flat_colour(m) + (1.0,) for m in me.materials] or [(1, 1, 1, 1)], dtype=np.float32)
    mi = np.empty(len(me.polygons), dtype=np.int32)
    me.polygons.foreach_get("material_index", mi)
    ls = np.empty(len(me.polygons), dtype=np.int32)
    me.polygons.foreach_get("loop_total", ls)
    loop_mat = np.repeat(np.clip(mi, 0, len(cols) - 1), ls)
    out = cols[loop_mat]
    if painted is not None and any(keep):
        km = np.array(keep + [False] * (len(cols) - len(keep)))[loop_mat]
        out[km] = painted[km]
    ca = me.color_attributes.new("Col", "FLOAT_COLOR", "CORNER")
    ca.data.foreach_set("color", out.ravel())
    me.color_attributes.active_color = ca
    try:
        me.color_attributes.render_color_index = me.color_attributes.active_color_index
    except AttributeError:
        pass


def shade(obj, smooth, sharp_deg=40.0):
    me = obj.data
    me.polygons.foreach_set("use_smooth", [smooth] * len(me.polygons))
    if smooth and sharp_deg:
        try:
            me.set_sharp_from_angle(angle=math.radians(sharp_deg))
        except AttributeError:
            pass
    me.update()


def collider(obj, name, max_tris=COLLIDER_MAX_TRIS):
    def hull(points):
        bm = bmesh.new()
        for p in points:
            bm.verts.new(p)
        bmesh.ops.convex_hull(bm, input=bm.verts[:])
        bmesh.ops.delete(bm, geom=[v for v in bm.verts if not v.link_faces], context="VERTS")
        bmesh.ops.triangulate(bm, faces=bm.faces[:])
        me = bpy.data.meshes.new(name)
        bm.to_mesh(me)
        bm.free()
        return me

    o = mesh_object(name, hull([v.co.copy() for v in obj.data.vertices]))
    if tris(o) > max_tris:
        decimate_to(o, max_tris * 0.9)
        old = o.data
        o.data = hull([v.co.copy() for v in old.vertices])
        bpy.data.meshes.remove(old)
    o.data.name = name
    return o


def bottom_centre(obj):
    co = np.empty(len(obj.data.vertices) * 3, dtype=np.float32)
    obj.data.vertices.foreach_get("co", co)
    co = co.reshape(-1, 3)
    lo, hi = co.min(0), co.max(0)
    obj.data.transform(Matrix.Translation(Vector((-(lo[0] + hi[0]) / 2, -(lo[1] + hi[1]) / 2, -lo[2]))))
    obj.data.update()


def bake_transform(obj):
    obj.data.transform(obj.matrix_world)
    obj.matrix_world = Matrix.Identity(4)


def dims(obj):
    co = np.empty(len(obj.data.vertices) * 3, dtype=np.float32)
    obj.data.vertices.foreach_get("co", co)
    co = co.reshape(-1, 3)
    return (co.max(0) - co.min(0)).tolist()


# ----------------------------------------------------------------------------------------------------------------
# Sources

def source_building(arch, region, seed):
    from ascend_buildings import generate
    gen = generate.building(arch, region, seed=seed, collection=collection())
    generate.set_realize([gen], True)
    dg = bpy.context.evaluated_depsgraph_get()
    me = bpy.data.meshes.new_from_object(gen.evaluated_get(dg), preserve_all_data_layers=True, depsgraph=dg)
    me.transform(gen.matrix_world)
    built_as = gen.get("ab_built_as", arch)
    bpy.data.objects.remove(gen)
    src = mesh_object("%s_%s_HIGH" % (region, arch), me)
    return src, built_as


def source_creature(sid, seed):
    from ascend_creatures import generate
    gen = generate.creature(sid, seed=seed, collection=collection())
    bake_transform(gen)
    gen.name = "%s_HIGH" % sid
    for m in list(gen.modifiers):
        gen.modifiers.remove(m)
    bottom_centre(gen)
    return gen, generate.species_list()[sid]


# ----------------------------------------------------------------------------------------------------------------
# Bake

def bake_building(arch, region, seed):
    t0 = time.time()
    src, built_as = source_building(arch, region, seed)
    aid = "%s_%s" % (region, arch) + ("" if seed == 1 else "_s%d" % seed)
    cls = BUILDING_CLASS.get(built_as, BUILDING_CLASS.get(arch, "medium"))
    (b0, b1, b2), max_mats = BUILDING_BUDGETS[cls]
    src_tris = tris(src)
    size = dims(src)
    voxel = min(0.08, max(0.03, max(size) / 220.0))
    print("[bake] %s: source %d tris, %.1fx%.1fx%.1f m, class %s, voxel %.3f m" % (aid, src_tris, *size, cls, voxel))
    base = duplicate(src, aid + "_LOD0")
    remesh(base, voxel)
    print("[bake]   remesh -> %d tris (%.1fs)" % (tris(base), time.time() - t0))
    smooth(base)
    dissolve_planar(base, 1.0)
    decimate_to(base, b0 * 3)
    removed = strip_hidden(base)
    print("[bake]   stripped %d hidden faces -> %d tris" % (removed, tris(base)))
    decimate_to(base, b0)
    lods = [base]
    for i, b in ((1, b1), (2, b2)):
        o = duplicate(lods[-1], "%s_LOD%d" % (aid, i))
        decimate_to(o, b)
        lods.append(o)
    look = FaceLookup(src)
    mats = []
    for o in lods:
        triangulate(o)
        look.transfer(o)
        merge_materials(o)
        write_colour(o)
        mats.append(merge_to_budget(o, max_mats))
        weighted_normals(o, 40.0)
    shade(src, False, 0)
    col = collider(lods[2], aid + "_COL")
    return finish("buildings", aid, cls, src, lods, col, (b0, b1, b2), max_mats, mats, src_tris, t0,
                  {"archetype": arch, "builtAs": built_as, "region": region, "seed": seed, "voxelM": voxel})


def bake_creature(sid, seed):
    t0 = time.time()
    src, sp = source_creature(sid, seed)
    aid = sid + ("" if not seed else "_s%d" % seed)
    cls = creature_class(sp)
    (b0, b1, b2), max_mats = CREATURE_BUDGETS[cls]
    src_tris = tris(src)
    print("[bake] %s: source %d tris, %.2f m, class %s" % (aid, src_tris, max(dims(src)), cls))
    lods = []
    prev = src
    for i, b in enumerate((b0, b1, b2)):
        o = duplicate(prev, "%s_LOD%d" % (aid, i))
        decimate_to(o, b)
        triangulate(o)
        lods.append(o)
        prev = o
    for o in lods:
        merge_materials(o)
    kept = all(o.data.color_attributes.get("Col") is not None for o in lods)  # the painted skin survived the collapse
    mats = []
    for o in lods:
        write_colour(o)
        mats.append(merge_to_budget(o, max_mats))
    col = collider(lods[2], aid + "_COL", 96)
    return finish("creatures", aid, cls, src, lods, col, (b0, b1, b2), max_mats, mats, src_tris, t0,
                  {"species": sid, "seed": seed, "sizeM": sp.get("sizeMeters"),
                   "keptVertexColour": kept})


REPORT = []


def finish(kind, aid, cls, src, lods, col, budget, max_mats, mats, src_tris, t0, extra):
    row = {"kind": kind, "id": aid, "class": cls, "sourceTris": src_tris,
           "tris": [tris(o) for o in lods], "budget": list(budget), "materials": mats, "maxMaterials": max_mats,
           "colliderTris": tris(col), "sizeM": [round(x, 2) for x in dims(lods[0])], "seconds": 0, "files": {}}
    row.update(extra)
    row["trisOK"] = all(t <= b * 1.02 for t, b in zip(row["tris"], budget))
    row["slotsOK"] = max(mats) <= max_mats
    if OUT:
        d = os.path.join(OUT, kind)
        os.makedirs(d, exist_ok=True)
        for o, suffix in list(zip(lods, ("LOD0", "LOD1", "LOD2"))) + [(col, "COL")]:
            path = os.path.join(d, "%s_%s.fbx" % (aid, suffix))
            export(o, path, suffix != "COL")
            row["files"][suffix] = rel(path)
            row.setdefault("bytes", 0)
            row["bytes"] += os.path.getsize(path)
    row["seconds"] = round(time.time() - t0, 1)
    print("[bake]   %s %s tris %s (budget %s), materials %s (max %d), collider %d, %.1fs" % (
        aid, cls, row["tris"], list(budget), mats, max_mats, row["colliderTris"], row["seconds"]))
    REPORT.append(row)
    return src, lods, col, row


def rel(path):
    try:
        return os.path.relpath(path, ROOT).replace("\\", "/")
    except ValueError:  # another drive
        return path.replace("\\", "/")


def export(obj, path, colours):
    for o in bpy.context.view_layer.objects:
        o.select_set(False)
    obj.hide_set(False)
    obj.select_set(True)
    bpy.context.view_layer.objects.active = obj
    bpy.ops.export_scene.fbx(filepath=path, use_selection=True, object_types={"MESH"}, axis_forward="-Z", axis_up="Y",
                             apply_unit_scale=True, apply_scale_options="FBX_SCALE_UNITS", bake_space_transform=True,
                             mesh_smooth_type="FACE", use_mesh_modifiers=True, colors_type="SRGB" if colours else "NONE",
                             path_mode="AUTO", add_leaf_bones=False)


# ----------------------------------------------------------------------------------------------------------------
# Contact sheet: one row per asset (source, LOD0, LOD1, LOD2), each tile labelled

def label(cam, text):
    cu = bpy.data.curves.new("GR_label", "FONT")
    cu.body = text
    cu.size = 0.036
    ob = bpy.data.objects.new("GR_label", cu)
    collection().objects.link(ob)
    mat = bpy.data.materials.get("GR_label") or bpy.data.materials.new("GR_label")
    if mat.node_tree is None:
        mat.use_nodes = True
    nt = mat.node_tree
    for n in list(nt.nodes):
        nt.nodes.remove(n)
    em = nt.nodes.new("ShaderNodeEmission")
    em.inputs["Color"].default_value = (0.02, 0.02, 0.03, 1)
    out = nt.nodes.new("ShaderNodeOutputMaterial")
    nt.links.new(em.outputs[0], out.inputs[0])
    cu.materials.append(mat)
    ob.parent = cam
    ob.location = (-0.345, 0.225, -1.0)
    ob.visible_shadow = False
    return ob


def contact_sheet(rows, path, tile=(480, 360)):
    from ascend_buildings import preview
    preview.setup()
    sc = bpy.context.scene
    cols = 4
    sheet = np.ones((len(rows) * tile[1], cols * tile[0], 4), dtype=np.float32)
    tmp = os.path.join(bpy.app.tempdir or os.environ.get("TEMP", "."), "gr_tile.png")
    for r, (objs, labels) in enumerate(rows):
        for c, (o, text) in enumerate(zip(objs, labels)):
            for other in collection().objects:
                other.hide_render = other is not o
            cam = preview.camera([o], yaw=-32.0, pitch=18.0, margin=1.25)
            lab = label(cam, text)
            preview.render(tmp, tile, 16)
            bpy.data.objects.remove(lab)
            img = bpy.data.images.load(tmp, check_existing=False)
            px = np.array(img.pixels[:], dtype=np.float32).reshape(tile[1], tile[0], 4)
            bpy.data.images.remove(img)
            y0 = (len(rows) - 1 - r) * tile[1]
            sheet[y0:y0 + tile[1], c * tile[0]:(c + 1) * tile[0]] = px
    sheet[:, ::tile[0], :3] = 0.2  # thin grid lines between tiles
    sheet[::tile[1], :, :3] = 0.2
    out = bpy.data.images.new("GR_Sheet", cols * tile[0], len(rows) * tile[1], alpha=False)
    out.pixels[:] = sheet.ravel()
    out.filepath_raw = path
    out.file_format = "PNG"
    out.save()
    bpy.data.images.remove(out)
    print("[bake] contact sheet -> %s" % path)


# ----------------------------------------------------------------------------------------------------------------

def arg(name, default=None):
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    if name in argv:
        i = argv.index(name)
        return argv[i + 1] if i + 1 < len(argv) and not argv[i + 1].startswith("--") else True
    return default


OUT = None


def main():
    global OUT
    OUT = None if arg("--no-export") else os.path.abspath(arg("--out") or os.path.join(ROOT, "Art", "Blender", "GameReady"))
    for o in list(bpy.data.objects):
        bpy.data.objects.remove(o)
    rows = []

    def add_row(res):
        src, lods, _col, row = res
        objs = [src] + lods
        labels = ["%s  source  %s tris" % (row["id"], format(row["sourceTris"], ","))]
        labels += ["LOD%d  %s / %s tris  %d mat" % (i, format(t, ","), format(b, ","), m)
                   for i, (t, b, m) in enumerate(zip(row["tris"], row["budget"], row["materials"]))]
        rows.append((objs, labels))

    for sid in [s for s in (arg("--creatures") or "").split(",") if s]:
        sid, _, seed = sid.partition(":")
        add_row(bake_creature(sid, int(seed or 0)))
    for spec in [s for s in (arg("--buildings") or "").split(",") if s]:
        parts = spec.split(":")
        arch, region = parts[0], parts[1] if len(parts) > 1 else "whisperwood"
        add_row(bake_building(arch, region, int(parts[2]) if len(parts) > 2 else 1))
    if OUT:
        os.makedirs(OUT, exist_ok=True)
        rp = os.path.join(OUT, "report.json")
        old = []
        if os.path.exists(rp):
            with open(rp, encoding="utf8") as f:
                old = [r for r in json.load(f) if r["id"] not in {x["id"] for x in REPORT}]
        with open(rp, "w", encoding="utf8") as f:
            json.dump(old + REPORT, f, indent=1)
    sheet = arg("--sheet")
    if sheet and rows:
        contact_sheet(rows, os.path.abspath(sheet))
    print("[bake] done: %d assets" % len(REPORT))
    for r in REPORT:
        print("[bake] %-26s %-11s src %9s  LOD %s  budget %s  mats %s  col %d  %s, %s" % (
            r["id"], r["class"], format(r["sourceTris"], ","), r["tris"], r["budget"], r["materials"],
            r["colliderTris"], "tris OK" if r["trisOK"] else "tris OVER", "slots OK" if r["slotsOK"] else "slots OVER"))


main()
