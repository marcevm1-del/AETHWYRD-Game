"""
Renders a contact sheet of creatures or buildings, in the toon preview (default) or the plain preview rig.

blender -b --factory-startup -P Tools/blender/render_toon_sheet.py -- --repo <repo> --out <sheet.png>
        (--creatures id,id,.. | --buildings region:type,type,..[;region:type,..])
        [--plain] [--detail medium] [--tile 320] [--cols 4] [--yaw -35] [--pitch <deg>] [--seed 0]
        [--tiles <dir>] [--glow-report <json>]

Toon mode (style guide 3.1): toon_preview.render_tiles() - two-tone + rim, hue-keeping emission under the Standard
view transform, inverted-hull outlines, painted sky, lawn disc, camera framed on the subject only (vertical fit,
margin 1.2), 1.7 m lavender-grey figure behind and right of each creature. Plain mode (geometry debugging only):
ascend_buildings.preview.setup() as the existing sheets use it. Every tile gets a label band with the subject's
height in metres. --glow-report renders an ID mask per tile and writes the saturation/hue of every glowing material
(acceptance: saturation >= 50%, hue within 15 degrees of the key). Tiles are kept in --tiles (default <out>_tiles).
"""
import argparse
import json
import os
import sys
import time

argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
ap = argparse.ArgumentParser(prog="render_toon_sheet")
ap.add_argument("--repo", required=True)
ap.add_argument("--out", required=True)
ap.add_argument("--plain", action="store_true")
ap.add_argument("--creatures", default="")
ap.add_argument("--buildings", default="")
ap.add_argument("--detail", default="medium")
ap.add_argument("--tile", type=int, default=320)
ap.add_argument("--cols", type=int, default=4)
ap.add_argument("--yaw", type=float, default=-35.0)
ap.add_argument("--pitch", type=float, default=None)
ap.add_argument("--seed", type=int, default=0)
ap.add_argument("--samples", type=int, default=12)
ap.add_argument("--tiles", default="")
ap.add_argument("--glow-report", default="")
args = ap.parse_args(argv)
if bool(args.creatures) == bool(args.buildings):
    ap.error("give exactly one of --creatures or --buildings")
sys.path.insert(0, os.path.join(os.path.abspath(args.repo), "Tools", "blender"))

import bpy  # noqa: E402

from ascend_buildings import library as blib, preview  # noqa: E402
import toon_preview as tp  # noqa: E402

kind = "creature" if args.creatures else "building"
TS = args.tile
pitch = args.pitch if args.pitch is not None else tp.PITCH[kind]

blib.clear_scene()
col = bpy.data.collections.new("Sheet")
bpy.context.scene.collection.children.link(col)
subjects = []
t0 = time.time()
if kind == "creature":
    import ascend_creatures
    from ascend_creatures import generate as cgen
    ascend_creatures.register()
    for sid in [s for s in args.creatures.split(",") if s]:
        try:
            o = cgen.creature(sid, args.seed, args.detail, collection=col)
        except Exception as e:
            print("FAILED", sid, e)
            continue
        o.location.x = len(subjects) * 60.0
        subjects.append(o)
else:
    from ascend_buildings import generate as bgen
    for chunk in [c for c in args.buildings.split(";") if c]:
        region, types = chunk.split(":")
        for t in [x for x in types.split(",") if x]:
            try:
                o = bgen.building(t, region, args.seed or 1, args.detail, collection=col,
                                  name="AB_%s_%s" % (region, t))
            except Exception as e:
                print("FAILED", region, t, e)
                continue
            o.location.x = len(subjects) * 200.0
            subjects.append(o)
print("GENERATED %d %ss in %.1fs" % (len(subjects), kind, time.time() - t0))

tmp = args.tiles or os.path.splitext(args.out)[0] + "_tiles"
os.makedirs(tmp, exist_ok=True)
t1 = time.time()
if args.plain:
    preview.setup(ground=True)
    tiles = []
    for o in subjects:
        for x in subjects:
            x.hide_render = x is not o
        home = o.location.copy()  # the plain rig's ground is a 400 m disc at the origin: shoot every subject there
        o.location = (0.0, 0.0, home.z)
        bpy.context.view_layer.update()
        p = os.path.join(tmp, o.name + ".png")
        preview.camera([o], yaw=args.yaw, pitch=pitch, margin=tp.MARGIN, aspect=1.0)
        t = time.time()
        preview.render(p, (TS, TS), args.samples)
        lo, hi = preview.bounds([o])
        tiles.append((p, tp.label_for(o.name, hi.z - lo.z)))
        o.location = home
        print("TILE %s %.1fs" % (o.name, time.time() - t))
else:
    tiles = tp.render_tiles(subjects, tmp, kind=kind, tile=(TS, TS), yaw=args.yaw, pitch=pitch,
                            samples=args.samples, glow_report=bool(args.glow_report), restore_scene=False)
dt = time.time() - t1
os.makedirs(os.path.dirname(os.path.abspath(args.out)), exist_ok=True)
tp.sheet(tiles, args.out, cols=args.cols, tile=(TS, TS))
if args.glow_report:
    rep = {os.path.splitext(os.path.basename(t[0]))[0]: t[2] for t in tiles if len(t) > 2}
    with open(args.glow_report, "w") as f:
        json.dump(rep, f, indent=1)
    for name, recs in rep.items():
        for r in recs:
            print("GLOW %-24s %-28s key %s (h %5.1f s %3.0f%%)  px %5d  hue %5.1f  sat %3.0f%%  pass %3.0f%%" % (
                name, r["material"], r.get("key", "-"), r.get("key_hue", -1), 100 * r.get("key_sat", 0),
                r["pixels"], r.get("hue", -1), 100 * r.get("sat", 0), 100 * r.get("pass", 0)))
print("SHEET %s %d tiles, %.1fs per tile (%s)" % (args.out, len(tiles), dt / max(1, len(tiles)),
                                                   "plain" if args.plain else "toon"))
