"""
Checks the exported Whisperwood foliage kit by re-importing each FBX in Game/Assets/_Game/Art/Models/Foliage:
triangle count inside budget, no ngons (faces over 4 verts), no non-manifold edges, no loose geometry, a vertex-colour
layer, fol_* materials, base at z=0 and the right height range. Exits non-zero on any failure.

  blender -b --factory-startup -P Tools/blender/check_foliage_kit.py --python-exit-code 1
"""
import os
import sys

import bmesh
import bpy

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "..")) if "__file__" in globals() else r"E:/Ideas/Project-Ascend"
FBX_DIR = os.path.join(ROOT, "Game", "Assets", "_Game", "Art", "Models", "Foliage")
sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))

# id: (min tris, max tris, min height m, max height m)
SPEC = {
    "tree_broadleaf_a": (5000, 8000, 6.0, 12.0), "tree_broadleaf_b": (5000, 8000, 6.0, 12.0), "tree_broadleaf_c": (5000, 8000, 6.0, 12.0),
    "tree_pine_a": (1500, 10000, 8.0, 14.0),
    "bush_a": (300, 1200, 0.5, 1.6), "bush_b": (300, 1200, 0.5, 1.6),
    "grass_tuft": (100, 1200, 0.3, 1.0), "fern_clump": (100, 1200, 0.15, 1.0),
    "flower_clump": (100, 1200, 0.3, 1.0), "rock_mossy_a": (100, 1200, 0.5, 2.0),
}


def main():
    failures = []
    for name, (lo_t, hi_t, lo_h, hi_h) in SPEC.items():
        path = os.path.join(FBX_DIR, name + ".fbx")
        if not os.path.exists(path):
            failures.append(f"{name}: FBX missing")
            continue
        bpy.ops.wm.read_factory_settings(use_empty=True)
        bpy.ops.import_scene.fbx(filepath=path)
        meshes = [o for o in bpy.context.scene.objects if o.type == "MESH"]
        if len(meshes) != 1:
            failures.append(f"{name}: expected 1 mesh object, found {len(meshes)}")
            continue
        o = meshes[0]
        bm = bmesh.new()
        bm.from_mesh(o.data)
        tris = sum(len(f.verts) - 2 for f in bm.faces)
        ngons = sum(1 for f in bm.faces if len(f.verts) > 4)
        nonman = sum(1 for e in bm.edges if len(e.link_faces) != 2)
        loose = sum(1 for v in bm.verts if not v.link_faces)
        zs = [(o.matrix_world @ v.co).z for v in bm.verts]
        height = max(zs) - min(zs)
        base = min(zs)
        bm.free()
        has_col = len(o.data.color_attributes) > 0
        mats = [m.name for m in o.data.materials if m]
        errs = []
        if not lo_t <= tris <= hi_t:
            errs.append(f"tris {tris} outside {lo_t}-{hi_t}")
        if ngons:
            errs.append(f"{ngons} ngons")
        if nonman:
            errs.append(f"{nonman} non-manifold edges")
        if loose:
            errs.append(f"{loose} loose verts")
        if not has_col:
            errs.append("no vertex colour layer")
        if not mats or not all(n.startswith("fol_") for n in mats):
            errs.append(f"materials {mats}")
        if abs(base) > 0.05:
            errs.append(f"base at z={base:.3f}, not 0")
        if not lo_h <= height <= hi_h:
            errs.append(f"height {height:.2f} outside {lo_h}-{hi_h}")
        print(f"[check] {name}: {tris} tris, {ngons} ngons, {nonman} non-manifold, {height:.2f} m, base {base:.3f}, {len(mats)} materials, colour={has_col} -> {'FAIL ' + '; '.join(errs) if errs else 'ok'}")
        failures += [f"{name}: {e}" for e in errs]
    if failures:
        print("[check] FAILED:\n  " + "\n  ".join(failures))
        sys.exit(1)
    print("[check] all foliage assets pass")


main()
