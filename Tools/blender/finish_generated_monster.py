"""
Finishes one AI-generated monster in the live Blender session and exports it for Unity.

Usage inside Blender (the MCP pass does this after each generate_3d):
  exec(open(r"E:/Ideas/Project-Ascend/Tools/blender/finish_generated_monster.py").read())
  finish("<object name>", "<species_id>")

Steps: join the generated parts → name after the species → scale to the real size in species.json (height for
"tall" creatures, length for "long" ones) → feet on z = 0 at the origin, centred → limit triangles to a budget by
size → export FBX (Unity axes, embedded textures) to Game/Assets/_Game/Art/Models/Monsters/<Family>/<id>.fbx (the FBX is the
source; no per-species .blend, to keep storage sane). Facing is checked by eye after import (front = -Y) and fixed with
`turn(degrees)` before finishing if needed.
"""
import json
import os
import re

import bpy
from mathutils import Vector

ASCEND_ROOT = r"E:/Ideas/Project-Ascend"
_SPECIES = None


def _species(sid):
    global _SPECIES
    if _SPECIES is None:
        with open(os.path.join(ASCEND_ROOT, "Data", "Monsters", "species.json"), encoding="utf-8") as f:
            _SPECIES = {s["id"]: s for s in json.load(f)}
    return _SPECIES[sid]


def _budget(size_m):
    """Triangle budget by size (game-ready blockout-to-final range)."""
    if size_m < 0.6: return 6000
    if size_m < 2.5: return 12000
    if size_m < 8: return 20000
    return 30000


def _bounds(objs):
    pts = [o.matrix_world @ Vector(c) for o in objs for c in o.bound_box]
    lo = Vector((min(p.x for p in pts), min(p.y for p in pts), min(p.z for p in pts)))
    hi = Vector((max(p.x for p in pts), max(p.y for p in pts), max(p.z for p in pts)))
    return lo, hi


def turn(obj_name, degrees):
    """Rotate a model about Z so it faces -Y (front) before finishing."""
    import math
    o = bpy.data.objects[obj_name]
    o.rotation_euler.z += math.radians(degrees)
    bpy.context.view_layer.update()


REGISTRY = os.path.join(ASCEND_ROOT, "Art", "Generation", "monster_models.json")


def record(species_id, entry):
    """Adds or updates one species in the model registry (committed to GitHub; the FBX itself stays local)."""
    data = {"version": 1, "note": "Generated monster models. The FBX files are local-only (gitignored); this file is the record.", "models": {}}
    if os.path.exists(REGISTRY):
        with open(REGISTRY, encoding="utf-8") as f:
            data = json.load(f)
    data["models"][species_id] = entry
    data["count"] = len(data["models"])
    os.makedirs(os.path.dirname(REGISTRY), exist_ok=True)
    with open(REGISTRY, "w", encoding="utf-8") as f:
        json.dump(data, f, indent=1, sort_keys=True)
        f.write("\n")


def finish(obj_name, species_id, provider="", notes=""):
    import datetime
    s = _species(species_id)
    root = bpy.data.objects[obj_name]
    meshes = [o for o in [root, *root.children_recursive] if o.type == "MESH"]
    bpy.ops.object.select_all(action="DESELECT")
    for o in meshes:
        o.select_set(True)
    bpy.context.view_layer.objects.active = meshes[0]
    if len(meshes) > 1:
        bpy.ops.object.join()
    model = bpy.context.active_object
    model.parent = None
    model.name = model.data.name = species_id
    bpy.ops.object.transform_apply(location=True, rotation=True, scale=True)

    # Scale to the real size: "tall" creatures by height, "long" ones by length (the look text says which).
    size = float(s.get("sizeMeters") or 1.0)
    lo, hi = _bounds([model])
    long_ = bool(re.search(r"about [\d.,]+ ?m long", s.get("look", "")))
    measured = (hi.y - lo.y) if long_ else (hi.z - lo.z)
    if measured <= 0:
        measured = max(hi.x - lo.x, hi.y - lo.y, hi.z - lo.z)
    k = size / measured
    model.scale = (k, k, k)
    bpy.ops.object.transform_apply(scale=True)

    # Feet on the ground, centred, origin at the feet.
    lo, hi = _bounds([model])
    model.location -= Vector(((lo.x + hi.x) / 2, (lo.y + hi.y) / 2, lo.z))
    bpy.ops.object.transform_apply(location=True)
    bpy.context.scene.cursor.location = (0, 0, 0)
    bpy.ops.object.origin_set(type="ORIGIN_CURSOR")

    # Triangle budget.
    tris = sum(len(p.vertices) - 2 for p in model.data.polygons)
    budget = _budget(size)
    if tris > budget:
        dec = model.modifiers.new("Budget", "DECIMATE")
        dec.ratio = budget / tris
        bpy.ops.object.modifier_apply(modifier=dec.name)
    tris_after = sum(len(p.vertices) - 2 for p in model.data.polygons)

    family = s.get("family", "Other").replace("/", "-")
    fbx_dir = os.path.join(ASCEND_ROOT, "Game", "Assets", "_Game", "Art", "Models", "Monsters", family)
    os.makedirs(fbx_dir, exist_ok=True)
    fbx = os.path.join(fbx_dir, f"{species_id}.fbx")
    bpy.ops.object.select_all(action="DESELECT")
    model.select_set(True)
    bpy.context.view_layer.objects.active = model
    bpy.ops.export_scene.fbx(filepath=fbx, use_selection=True, object_types={"MESH"}, axis_forward="-Z", axis_up="Y",
                             apply_scale_options="FBX_SCALE_UNITS", bake_space_transform=True, mesh_smooth_type="FACE",
                             path_mode="COPY", embed_textures=True)
    lo, hi = _bounds([model])
    record(species_id, {
        "status": "generated", "provider": provider, "date": datetime.date.today().isoformat(),
        "trisSource": tris, "tris": tris_after, "budget": budget,
        "sizeM": [round(hi.x - lo.x, 3), round(hi.y - lo.y, 3), round(hi.z - lo.z, 3)],
        "fbx": os.path.relpath(fbx, ASCEND_ROOT).replace("\\", "/"), "fbxBytes": os.path.getsize(fbx), "notes": notes,
    })
    print(f"[Ascend] {species_id}: {tris}→{tris_after} tris · {hi.x - lo.x:.2f}×{hi.y - lo.y:.2f}×{hi.z - lo.z:.2f} m · {os.path.relpath(fbx, ASCEND_ROOT)}")
    return model
