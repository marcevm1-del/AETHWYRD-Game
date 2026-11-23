"""
Checks for the starter sword, run in Blender (exit code 1 on any failure):

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/check_weapon.py [-- --fbx <path>]

Imports the exported FBX (what Unity will get) and checks: triangle budget (1,500, art_direction.md section 12),
no ngons, no non-manifold edges, consistent winding, origin at the grip centre, blade along +Z here (= +Y in Unity),
blade length 0.9 to 1.0 m, one material per tone with vertex colour present, no loose vertices.
"""
import os
import sys

import bmesh
import bpy

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.abspath(os.path.join(HERE, "..", ".."))
DEFAULT_FBX = os.path.join(ROOT, "Game", "Assets", "_Game", "Art", "Models", "Weapons", "sword_starter.fbx")
TRI_BUDGET = 1500

fails = []


def ok(cond, msg):
    print(("[CHK] ok   " if cond else "[CHK] FAIL ") + msg, flush=True)
    if not cond:
        fails.append(msg)


def arg(name, default):
    a = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    return a[a.index(name) + 1] if name in a else default


path = arg("--fbx", DEFAULT_FBX)
ok(os.path.isfile(path), "FBX exists: " + path)
if not os.path.isfile(path):
    sys.exit(1)

for o in list(bpy.data.objects):
    bpy.data.objects.remove(o, do_unlink=True)
bpy.ops.import_scene.fbx(filepath=path)
meshes = [o for o in bpy.context.scene.objects if o.type == "MESH"]
ok(len(meshes) == 1, "exactly one mesh object (%d)" % len(meshes))
ob = meshes[0]
me = ob.data

# the importer applies the axis conversion back to Blender Z-up; make sure no stray object transform hides an offset
bpy.context.view_layer.update()
m = ob.matrix_world
ok(all(abs(c) < 1e-4 for c in m.translation), "object transform is at the origin %s" % (tuple(round(c, 4) for c in m.translation),))

bm = bmesh.new()
bm.from_mesh(me)
bm.transform(m)
bm.normal_update()

tris = sum(len(f.verts) - 2 for f in bm.faces)
ok(tris <= TRI_BUDGET, "triangles %d <= %d" % (tris, TRI_BUDGET))
ok(all(len(f.verts) <= 4 for f in bm.faces), "no ngons (max face size %d)" % max(len(f.verts) for f in bm.faces))
ok(all(len(f.verts) == 3 for f in bm.faces), "all faces are triangles")
loose = [v for v in bm.verts if not v.link_faces]
ok(not loose, "no loose vertices (%d)" % len(loose))
bad_edges = [e for e in bm.edges if len(e.link_faces) != 2]
ok(not bad_edges, "no non-manifold edges (%d with face count != 2)" % len(bad_edges))
# winding: with every edge shared by exactly two faces, a consistent shell has opposite edge directions on its two faces
winding_bad = 0
for e in bm.edges:
    if len(e.link_faces) != 2:
        continue
    dirs = []
    for f in e.link_faces:
        for l in f.loops:
            if l.edge == e:
                dirs.append((l.vert.index, l.link_loop_next.vert.index))
    if len(dirs) == 2 and dirs[0] == dirs[1]:
        winding_bad += 1
ok(winding_bad == 0, "consistent winding (%d flipped edges)" % winding_bad)

# normals point outward on every closed shell (signed volume > 0 per island)
seen = set()
vol_bad = 0
islands = 0
for f0 in bm.faces:
    if f0.index in seen:
        continue
    stack, isl = [f0], []
    seen.add(f0.index)
    while stack:
        f = stack.pop()
        isl.append(f)
        for e in f.edges:
            for g in e.link_faces:
                if g.index not in seen:
                    seen.add(g.index)
                    stack.append(g)
    islands += 1
    vol = 0.0
    for f in isl:
        a, b_, c = [v.co for v in f.verts]
        vol += a.dot(b_.cross(c)) / 6.0
    if vol <= 0:
        vol_bad += 1
ok(vol_bad == 0, "%d closed shells, all with outward normals" % islands)

zs = [v.co.z for v in bm.verts]
xs = [v.co.x for v in bm.verts]
ys = [v.co.y for v in bm.verts]
zmin, zmax = min(zs), max(zs)
ok(zmax > 0.9 and abs(max(abs(x) for x in xs)) < 0.2 and abs(max(abs(y) for y in ys)) < 0.1,
   "blade runs along +Z here (+Y in Unity): z %.3f..%.3f, |x| <= %.3f, |y| <= %.3f" % (zmin, zmax, max(abs(x) for x in xs), max(abs(y) for y in ys)))
# grip: vertices of a narrow cylinder around the origin; the origin must sit in the middle of the grip
grip = [v.co for v in bm.verts if abs(v.co.z) <= 0.08 and (v.co.x ** 2 + v.co.y ** 2) ** 0.5 <= 0.021]
ok(len(grip) >= 12, "grip vertices found around the origin (%d)" % len(grip))
if grip:
    gz0, gz1 = min(v.z for v in grip), max(v.z for v in grip)
    ok(abs((gz0 + gz1) / 2.0) < 0.01, "origin at the grip centre (grip z %.3f..%.3f)" % (gz0, gz1))
    cx = sum(v.x for v in grip) / len(grip)
    cy = sum(v.y for v in grip) / len(grip)
    ok(abs(cx) < 0.003 and abs(cy) < 0.003, "grip centred on the axis (%.4f, %.4f)" % (cx, cy))
# blade length: from the guard top to the tip (the guard's crown is the highest non-blade point near z 0.15)
blade_len = zmax - 0.125
ok(0.9 <= blade_len <= 1.0, "blade length %.3f m (0.90 to 1.00)" % blade_len)
ok(1.1 <= (zmax - zmin) <= 1.3, "overall length %.3f m" % (zmax - zmin))

ok(len(me.materials) == 5, "one material per tone (%d)" % len(me.materials))
ok(len(me.color_attributes) >= 1, "vertex colour attribute present (%d)" % len(me.color_attributes))
used = set(p.material_index for p in me.polygons)
ok(len(used) == len(me.materials), "every material is used (%d of %d)" % (len(used), len(me.materials)))

print("[CHK] %s (%d failure(s))" % ("PASS" if not fails else "FAIL", len(fails)), flush=True)
sys.exit(1 if fails else 0)
