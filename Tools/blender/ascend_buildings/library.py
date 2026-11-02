"""
The building library: every archetype a region needs, generated into one .blend per region and marked as Blender
assets (catalog "Ascend Buildings/<Family>/<Region>", tagged with region, family and archetype, with a rendered
preview), plus a contact sheet for the vault.

Each library file keeps the generator settings on every building, so with the add-on enabled any asset dragged into a
scene can still be rebuilt, resized or restyled for another region.
"""
import os
import uuid

import bpy

from . import archetypes, generate, preview, styles

CATS_FILE = "blender_assets.cats.txt"
NAMESPACE = uuid.UUID("6f1d3c3e-6a52-4c1f-9f0e-5f0b2f7a1a10")


def catalog_id(path):
    return str(uuid.uuid5(NAMESPACE, path))


def catalog_path(region):
    name, fam, _ = styles.REGIONS[region]
    return "Ascend Buildings/%s/%s" % (styles.FAMILIES[fam]["label"].split(" (")[0], name)


def write_catalogs(folder):
    lines = ["# This is an Asset Catalog Definition file for Blender.", "#", "# Written by Tools/blender/ascend_buildings/library.py",
             "", "VERSION 1", ""]
    seen = set()
    for rid in styles.REGIONS:
        p = catalog_path(rid)
        parts = p.split("/")
        for i in range(1, len(parts) + 1):
            sub = "/".join(parts[:i])
            if sub in seen:
                continue
            seen.add(sub)
            lines.append("%s:%s:%s" % (catalog_id(sub), sub, sub.replace("/", "-")))
    os.makedirs(folder, exist_ok=True)
    with open(os.path.join(folder, CATS_FILE), "w", encoding="utf8") as f:
        f.write("\n".join(lines) + "\n")


def clear_scene():
    for o in list(bpy.data.objects):
        bpy.data.objects.remove(o)
    for col in list(bpy.data.collections):
        bpy.data.collections.remove(col)
    for block in (bpy.data.meshes, bpy.data.materials, bpy.data.node_groups, bpy.data.images):
        for x in list(block):
            if x.users == 0:
                block.remove(x)


def build_region(region, out_dir, sheet_dir=None, seed=1, detail="high", previews=True, extra_seeds=0, toon=True):
    """Generates the region's catalogue into out_dir/<region>.blend. Returns (path, [objects])."""
    name, fam, _ = styles.REGIONS[region]
    col = bpy.data.collections.new("Buildings_%s" % region)
    bpy.context.scene.collection.children.link(col)
    items = archetypes.catalogue(fam)
    objs = []
    x = 0.0
    row_y = 0.0
    row_depth = 0.0
    cat = catalog_id(catalog_path(region))
    for i, a in enumerate(items):
        for s in range(1 + extra_seeds):
            o = generate.building(a, region, seed + s, detail, collection=col,
                                  name="%s_%s%s" % (region, a, "" if s == 0 else "_v%d" % (s + 1)))
            lo, hi = preview.bounds([o])
            w, d = hi.x - lo.x, hi.y - lo.y
            if x + w > 150:
                x = 0.0
                row_y -= row_depth + 8.0
                row_depth = 0.0
            o.location = (x - lo.x, row_y - hi.y, 0)
            x += w + 8.0
            row_depth = max(row_depth, d)
            o.asset_mark()
            ad = o.asset_data
            ad.catalog_id = cat
            ad.description = "%s %s in the %s style. Rebuild, resize or restyle it in the Ascend sidebar." % (
                name, a.replace("_", " "), styles.FAMILIES[fam]["label"])
            try:
                ad.author = "Project Ascend (procedural)"
            except AttributeError:
                pass
            for tag in (region, fam, a, o.get("ab_built_as", a)):
                if tag not in ad.tags:
                    ad.tags.new(tag)
            objs.append(o)
    os.makedirs(out_dir, exist_ok=True)
    tiles = []
    if toon:
        try:
            import toon_preview as tp                # Tools/blender on sys.path (the build scripts set it)
        except ImportError:
            print("[AB] toon_preview not importable; using the plain preview")
            toon = False
    if (previews or sheet_dir) and toon:
        # The toon preview is the standard for sheets (style guide 3.1); it restores the scene so the .blend saves clean.
        tmp_dir = os.path.join(out_dir, "_previews", region)
        os.makedirs(tmp_dir, exist_ok=True)
        toon_tiles = tp.render_tiles(objs, tmp_dir, kind="building", tile=(420, 320), yaw=-32, samples=16)
        if previews:
            for o, t in zip(objs, toon_tiles):
                try:
                    with bpy.context.temp_override(id=o):
                        bpy.ops.ed.lib_id_load_custom_preview(filepath=t[0])
                except Exception as e:  # previews are a convenience; the assets work without them
                    print("[AB] preview failed for", o.name, e)
        if sheet_dir:
            os.makedirs(sheet_dir, exist_ok=True)
            tp.sheet(toon_tiles, os.path.join(sheet_dir, "%s.png" % region), cols=6, tile=(420, 320))
    elif previews or sheet_dir:                      # --plain: the old grey preview, for geometry debugging
        preview.setup(ground=True)
        tmp_dir = os.path.join(out_dir, "_previews", region)
        os.makedirs(tmp_dir, exist_ok=True)
        for o in objs:
            p = os.path.join(tmp_dir, o.name + ".png")
            for other in objs:
                other.hide_render = other is not o
            preview.camera([o], yaw=-32, pitch=18, margin=1.2, aspect=320 / 420)  # vertical fit (review N2)
            preview.render(p, (420, 320), 16)
            tiles.append(p)
            if previews:
                try:
                    with bpy.context.temp_override(id=o):
                        bpy.ops.ed.lib_id_load_custom_preview(filepath=p)
                except Exception as e:  # previews are a convenience; the assets work without them
                    print("[AB] preview failed for", o.name, e)
        for o in objs:
            o.hide_render = False
        if sheet_dir:
            os.makedirs(sheet_dir, exist_ok=True)
            tile_sheet(tiles, os.path.join(sheet_dir, "%s.png" % region), cols=6, tile=(420, 320))
    path = os.path.join(out_dir, "%s.blend" % region)
    bpy.ops.wm.save_as_mainfile(filepath=path, compress=True, copy=True)
    return path, objs


def tile_sheet(paths, out, cols=6, tile=(420, 320)):
    import numpy as np

    rows = (len(paths) + cols - 1) // cols
    sheet = np.ones((rows * tile[1], cols * tile[0], 4), dtype=np.float32)
    for i, p in enumerate(paths):
        img = bpy.data.images.load(p, check_existing=False)
        px = np.array(img.pixels[:], dtype=np.float32).reshape(img.size[1], img.size[0], 4)
        bpy.data.images.remove(img)
        r, c = divmod(i, cols)
        y0 = (rows - 1 - r) * tile[1]
        sheet[y0:y0 + tile[1], c * tile[0]:(c + 1) * tile[0]] = px[: tile[1], : tile[0]]
    im = bpy.data.images.new("AB_Sheet", cols * tile[0], rows * tile[1], alpha=False)
    im.pixels[:] = sheet.ravel()
    im.filepath_raw = out
    im.file_format = "PNG"
    im.save()
    bpy.data.images.remove(im)
    return out


def representative_regions():
    """One region per family (the first listed), which is enough to cover every style."""
    out = {}
    for rid, (_, fam, _) in styles.REGIONS.items():
        out.setdefault(fam, rid)
    return list(out.values())
