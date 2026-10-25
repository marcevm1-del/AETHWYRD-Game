"""
Imports the third-party CC0 packs (extracted into Art/ThirdParty/, see 13_Production/third_party_assets.md) into a
Blender asset library: one .blend per pack in Art/Blender/AssetLibrary_CC0/, every model marked as an asset with its
licence, author and a rendered preview, under the catalog "CC0/<pack>". Contact sheets go to
13_Production/screenshots/cc0/.

    blender -b --factory-startup -P Tools/blender/import_cc0_packs.py [-- --packs kenney_retro_fantasy,nobiax_rocks]

Only packs whose licence is confirmed CC0 are listed here. Nothing from the packs is executed (the ruins pack ships
Torque engine scripts; they are ignored).
"""
import glob
import os
import re
import sys
import uuid

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(os.path.dirname(HERE))
sys.path.insert(0, HERE)

import bpy  # noqa: E402

import collada_lite  # noqa: E402
from ascend_buildings import library, preview  # noqa: E402

TP = os.path.join(ROOT, "Art", "ThirdParty")
PACKS = {
    # id: (label, author, glob patterns relative to Art/ThirdParty, importer)
    "kenney_retro_fantasy": ("Kenney Retro Fantasy Kit", "Kenney (kenney.nl)", ["kenney_retro-fantasy-kit/Models/GLB format/*.glb"], "gltf"),
    "nobiax_modular_building": ("Nobiax Modular Building", "Nobiax / Yughues", ["nobiax_nobiax_modular_building/*.FBX"], "fbx"),
    "nobiax_rocks": ("Nobiax Rocks", "Nobiax / Yughues", ["nobiax_rocks/*/*.fbx", "nobiax_rocks/*/*.FBX"], "fbx"),
    "nobiax_bushes": ("Nobiax Bushes", "Nobiax / Yughues", ["nobiax_bushes/*/*.FBX"], "fbx"),
    "nobiax_hedges": ("Nobiax Hedges", "Nobiax / Yughues", ["nobiax_hedges/*/*.FBX"], "fbx"),
    "nobiax_crates": ("Nobiax Wooden Crates", "Nobiax / Yughues", ["nobiax_wooden_crates/*/*.FBX", "nobiax_wooden_crates/*.FBX"], "fbx"),
    "fantasy_ruins": ("3TD Fantasy Ruins", "3D Tree / 3TD (CC0 EULA in the pack)", ["fantasy_ruins/FantasyRuins_Ready/game/art/shapes/Ruins/*/*.dae",
                                                                                 "fantasy_ruins/FantasyRuins_Ready/game/art/shapes/Ruins/*/*.DAE"], "collada"),
}
NAMESPACE = uuid.UUID("0c6b9d12-7d0e-4e8a-9a51-2f1a3f3b2c77")


def arg(name, default=None):
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    if name in argv:
        i = argv.index(name)
        return argv[i + 1] if i + 1 < len(argv) else True
    return default


def import_file(path, kind):
    before = set(bpy.data.objects)
    if kind == "gltf":
        bpy.ops.import_scene.gltf(filepath=path)
    elif kind == "collada":
        return collada_lite.load(path)  # Blender 5 has no COLLADA importer
    elif kind == "fbx":
        try:
            bpy.ops.import_scene.fbx(filepath=path, use_image_search=True)
        except RuntimeError:
            # FBX 6.1 files (older than Blender reads): use the OBJ that ships beside them
            stem = os.path.splitext(path)[0].rstrip(".")  # one pack names a file "rock_05..fbx"
            alt = [p for p in (stem + e for e in (".obj", ".OBJ")) if os.path.exists(p)]
            if not alt:
                raise
            bpy.ops.wm.obj_import(filepath=alt[0])
    return [o for o in bpy.data.objects if o not in before]


HELPERS = ("collision", "los", "bounds", "colmesh", "col-", "col_", "colbox")


def one_object(new, name, lods=False):
    """
    Joins a file's meshes into one object at the origin. Non-mesh helpers and collision/bounds meshes are dropped, and
    with lods=True (Torque exports: Wall200, Wall100, ...) only the highest detail level is kept.
    """
    meshes = [o for o in new if o.type == "MESH" and not o.name.lower().startswith(HELPERS)]
    if lods:
        level = lambda o: int(re.search(r"(\d+)$", o.name.split(".")[0]).group(1)) if re.search(r"(\d{2,})$", o.name.split(".")[0]) else None
        levels = [level(o) for o in meshes if level(o) is not None]
        if levels:
            top = max(levels)
            meshes = [o for o in meshes if level(o) in (None, top)]
    for o in new:
        if o not in meshes:
            bpy.data.objects.remove(o)
    if not meshes:
        return None
    for o in meshes:
        mw = o.matrix_world.copy()
        o.parent = None
        o.matrix_world = mw
    if len(meshes) > 1:
        with bpy.context.temp_override(active_object=meshes[0], selected_editable_objects=meshes, object=meshes[0]):
            bpy.ops.object.join()
    o = meshes[0]
    o.name = name
    with bpy.context.temp_override(active_object=o, selected_editable_objects=[o], object=o):
        bpy.ops.object.transform_apply(location=False, rotation=True, scale=True)
    return o


def write_catalogs(folder):
    lines = ["# This is an Asset Catalog Definition file for Blender.", "", "VERSION 1", ""]
    lines.append("%s:CC0:CC0" % uuid.uuid5(NAMESPACE, "CC0"))
    for pid, (label, *_rest) in PACKS.items():
        lines.append("%s:CC0/%s:CC0-%s" % (uuid.uuid5(NAMESPACE, pid), label, label))
    os.makedirs(folder, exist_ok=True)
    with open(os.path.join(folder, library.CATS_FILE), "w", encoding="utf8") as f:
        f.write("\n".join(lines) + "\n")


def main():
    out_dir = os.path.join(ROOT, "Art", "Blender", "AssetLibrary_CC0")
    sheet_dir = os.path.join(ROOT, "13_Production", "screenshots", "cc0")
    write_catalogs(out_dir)
    wanted = arg("--packs")
    for pid, (label, author, patterns, kind) in PACKS.items():
        if wanted and pid not in wanted.split(","):
            continue
        library.clear_scene()
        files = sorted({f for p in patterns for f in glob.glob(os.path.join(TP, p))})
        if not files:
            print("[CC0] %s: no files (extract the pack into Art/ThirdParty first)" % pid)
            continue
        col = bpy.data.collections.new("CC0_%s" % pid)
        bpy.context.scene.collection.children.link(col)
        objs, failed = [], 0
        x, y, row_h = 0.0, 0.0, 0.0
        for f in files:
            name = "%s_%s" % (pid, os.path.splitext(os.path.basename(f))[0].replace(" ", "_").lower())
            try:
                o = one_object(import_file(f, kind), name, lods=(kind == "collada"))
            except Exception as e:
                print("[CC0] %s: %s failed (%s)" % (pid, os.path.basename(f), str(e).splitlines()[0][:120]))
                failed += 1
                continue
            if o is None:
                continue
            for c in list(o.users_collection):
                c.objects.unlink(o)
            col.objects.link(o)
            lo, hi = preview.bounds([o])
            w, d = hi.x - lo.x, hi.y - lo.y
            if x + w > 60:
                x, y, row_h = 0.0, y - row_h - 2.0, 0.0
            o.location.x += x - lo.x
            o.location.y += y - hi.y
            o.location.z -= lo.z
            x += w + 2.0
            row_h = max(row_h, d)
            o.asset_mark()
            ad = o.asset_data
            ad.catalog_id = str(uuid.uuid5(NAMESPACE, pid))
            ad.description = "%s from %s. Licence CC0 1.0 (no attribution required)." % (os.path.basename(f), label)
            for attr, val in (("author", author), ("license", "CC0-1.0"), ("copyright", "Public domain (CC0 1.0)")):
                try:
                    setattr(ad, attr, val)
                except AttributeError:
                    pass
            for tag in ("cc0", pid):
                ad.tags.new(tag)
            objs.append(o)
        if not objs:
            print("[CC0] %s: nothing imported (%d failed)" % (pid, failed))
            continue
        preview.setup(ground=True)
        tiles = []
        tmp = os.path.join(out_dir, "_previews", pid)
        os.makedirs(tmp, exist_ok=True)
        for o in objs:
            p = os.path.join(tmp, o.name + ".png")
            for other in objs:
                other.hide_render = other is not o
            preview.camera([o], yaw=-32, pitch=20, margin=1.25)
            preview.render(p, (320, 240), 8)
            tiles.append(p)
            try:
                with bpy.context.temp_override(id=o):
                    bpy.ops.ed.lib_id_load_custom_preview(filepath=p)
            except Exception:
                pass
        for o in objs:
            o.hide_render = False
        os.makedirs(sheet_dir, exist_ok=True)
        library.tile_sheet(tiles, os.path.join(sheet_dir, "%s.png" % pid), cols=8, tile=(320, 240))
        path = os.path.join(out_dir, "%s.blend" % pid)
        bpy.ops.file.pack_all() if arg("--pack-textures") else None
        bpy.ops.wm.save_as_mainfile(filepath=path, compress=True, copy=True, relative_remap=True)
        print("[CC0] %-24s %3d assets (%d failed)  %6.1f MB" % (pid, len(objs), failed, os.path.getsize(path) / 1e6))


main()
