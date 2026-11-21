"""
Builds the creature libraries headlessly: one .blend per bestiary family, every species marked as a Blender asset
(catalog "Ascend Creatures/<Family>", tagged with family, element, rank and body plan, rendered preview), plus a
contact sheet per family.

    blender -b --factory-startup -P Tools/blender/build_creature_library.py                       # all 680 species
    blender -b --factory-startup -P Tools/blender/build_creature_library.py -- --families slimes,orcs_ogres_giants  (names or slugs)
    blender -b --factory-startup -P Tools/blender/build_creature_library.py -- --ids mon_goblin,mon_forest_wolf
    (add --detail medium, --no-sheets as needed; --plain for the old grey preview instead of the toon sheet)

Output: Art/Blender/CreatureLibrary/<family>.blend (not in git) and 13_Production/screenshots/creatures/<family>.png.
"""
import os
import re
import sys
import time
import uuid

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(os.path.dirname(HERE))
sys.path.insert(0, HERE)

import bpy  # noqa: E402

import ascend_creatures  # noqa: E402
from ascend_buildings import library as blib, preview  # noqa: E402
from ascend_creatures import generate  # noqa: E402

NS = uuid.UUID("3b1f6a1e-5c1d-4f7b-9a0e-7d2c41e0b8aa")


def arg(name, default=None):
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    if name in argv:
        i = argv.index(name)
        return argv[i + 1] if i + 1 < len(argv) and not argv[i + 1].startswith("--") else True
    return default


def slug(s):
    return re.sub(r"[^a-z0-9]+", "_", s.lower()).strip("_")


def main():
    ascend_creatures.register()
    # --out lets a run write somewhere else; without it, the library lands beside the repo as before.
    out_dir = arg("--out") or os.path.join(ROOT, "Art", "Blender", "CreatureLibrary")
    sheet_dir = None if arg("--no-sheets") else os.path.join(ROOT, "13_Production", "screenshots", "creatures")
    detail = arg("--detail", "high")
    species = list(generate.species_list().values())
    fams = {}
    for s in species:
        fams.setdefault(s["family"], []).append(s)
    lines = ["# This is an Asset Catalog Definition file for Blender.", "", "VERSION 1", "",
             "%s:Ascend Creatures:Ascend Creatures" % uuid.uuid5(NS, "root")]
    for f in sorted(fams):
        lines.append("%s:Ascend Creatures/%s:Ascend Creatures-%s" % (uuid.uuid5(NS, f), f, slug(f)))
    os.makedirs(out_dir, exist_ok=True)
    with open(os.path.join(out_dir, "blender_assets.cats.txt"), "w", encoding="utf8") as fh:
        fh.write("\n".join(lines) + "\n")
    want_f = arg("--families")
    want_i = arg("--ids")
    for fam in sorted(fams):
        items = fams[fam]
        if want_f and fam not in want_f.split(",") and slug(fam) not in want_f.split(","):  # names or slugs
            continue
        if want_i:
            items = [s for s in items if s["id"] in want_i.split(",")]
            if not items:
                continue
        t = time.time()
        blib.clear_scene()
        col = bpy.data.collections.new("Creatures_%s" % slug(fam))
        bpy.context.scene.collection.children.link(col)
        objs, failed = [], []
        x, y, row_d = 0.0, 0.0, 0.0
        for s in sorted(items, key=lambda s: (s.get("sizeMeters", 1), s["name"])):
            try:
                o = generate.creature(s["id"], 0, detail, collection=col)
            except Exception as e:  # keep going; report at the end
                failed.append("%s (%s)" % (s["id"], str(e).splitlines()[0][:80]))
                continue
            lo, hi = preview.bounds([o])
            w, d = hi.x - lo.x, hi.y - lo.y
            if x + w > max(40.0, w):
                x, y, row_d = 0.0, y - row_d - 2.0, 0.0
            o.location = (x - lo.x, y - hi.y, -lo.z)
            x += w + 1.5
            row_d = max(row_d, d)
            o.asset_mark()
            ad = o.asset_data
            ad.catalog_id = str(uuid.uuid5(NS, fam))
            ad.description = "%s (%s, %s, %.2f m). %s" % (s["name"], s.get("rank", ""), s.get("element", ""), s.get("sizeMeters", 1), s.get("signature", ""))
            try:
                ad.author = "AETHWYRD (procedural)"
            except AttributeError:
                pass
            for tag in (slug(fam), s.get("element", "None").lower(), s.get("rank", "").lower(), s["designRecipe"]["baseMesh"], s.get("tier", "")):
                if tag:
                    ad.tags.new(tag)
            objs.append(o)
        tiles = []
        if objs and not arg("--plain"):
            # The toon preview is the standard for sheets (style guide 3.1); it restores the scene for the save.
            import toon_preview as tp
            pdir = os.path.join(out_dir, "_previews", slug(fam))
            os.makedirs(pdir, exist_ok=True)
            toon_tiles = tp.render_tiles(objs, pdir, kind="creature", tile=(320, 320), yaw=-35, samples=12)
            for o, tt in zip(objs, toon_tiles):
                try:
                    with bpy.context.temp_override(id=o):
                        bpy.ops.ed.lib_id_load_custom_preview(filepath=tt[0])
                except Exception:
                    pass
            if sheet_dir:
                os.makedirs(sheet_dir, exist_ok=True)
                tp.sheet(toon_tiles, os.path.join(sheet_dir, "%s.png" % slug(fam)), cols=8, tile=(320, 320))
        elif objs:                                       # --plain: the old grey preview, for geometry debugging
            preview.setup(ground=True)
            pdir = os.path.join(out_dir, "_previews", slug(fam))
            os.makedirs(pdir, exist_ok=True)
            for o in objs:
                p = os.path.join(pdir, o.name + ".png")
                for other in objs:
                    other.hide_render = other is not o
                preview.camera([o], yaw=-35, pitch=14, margin=1.15, aspect=1.0)
                preview.render(p, (320, 320), 12)
                tiles.append(p)
                try:
                    with bpy.context.temp_override(id=o):
                        bpy.ops.ed.lib_id_load_custom_preview(filepath=p)
                except Exception:
                    pass
            for o in objs:
                o.hide_render = False
            if sheet_dir:
                os.makedirs(sheet_dir, exist_ok=True)
                blib.tile_sheet(tiles, os.path.join(sheet_dir, "%s.png" % slug(fam)), cols=8, tile=(320, 320))
        # A non-high build is an LOD: it gets its own file so it can never overwrite the source library.
        suffix = "" if detail == "high" else "_" + detail
        path = os.path.join(out_dir, "%s%s.blend" % (slug(fam), suffix))
        bpy.ops.wm.save_as_mainfile(filepath=path, compress=True, copy=True)
        print("[AC] %-28s %3d creatures  %6.1f MB  %5.0fs%s" % (fam, len(objs), os.path.getsize(path) / 1e6, time.time() - t,
                                                              ("  FAILED: " + "; ".join(failed)) if failed else ""))


main()
