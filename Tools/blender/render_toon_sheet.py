"""
Renders a contact sheet of creatures or buildings, in the toon preview (default) or the plain preview rig.

blender -b --factory-startup -P Tools/blender/render_toon_sheet.py -- --repo <repo> --out <sheet.png>
        (--creatures id,id,.. | --buildings region:type,type,..[;region:type,..])
        [--plain] [--detail medium] [--tile 320] [--cols 4] [--yaw -35] [--seed 0] [--tiles <dir>]

Toon mode: toon_preview.py (two-tone + rim, inverted-hull outlines, painted sky, 3x ground disc, 1.7 m figure
beside each creature). Plain mode: ascend_buildings.preview.setup() as the existing sheets use it.
Tiles are written to --tiles (default <out>_tiles next to the sheet) and kept.
"""
import argparse
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
ap.add_argument("--seed", type=int, default=0)
ap.add_argument("--samples", type=int, default=12)
ap.add_argument("--tiles", default="")
args = ap.parse_args(argv)
if bool(args.creatures) == bool(args.buildings):
    ap.error("give exactly one of --creatures or --buildings")
sys.path.insert(0, os.path.join(os.path.abspath(args.repo), "Tools", "blender"))

import bpy  # noqa: E402

from ascend_buildings import library as blib, preview  # noqa: E402

kind = "creature" if args.creatures else "building"
pitch, margin = (14.0, 1.15) if kind == "creature" else (16.0, 1.2)
TS = args.tile

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

groups = []  # (name, [render objects], [framed objects])
if args.plain:
    preview.setup(ground=True)
    for o in subjects:
        groups.append((o.name, [o], [o]))
else:
    import toon_preview as tp
    tp.setup_world()
    t1 = time.time()
    for o in subjects:
        frame = [o]
        if kind == "creature":
            frame.append(tp.add_scale_figure(o, yaw=args.yaw))
        made = tp.apply(frame, kind=kind, tile=TS, frame=frame)
        g = tp.ground_for(made)
        groups.append((o.name, made + [g], made))
    print("TOON converted in %.1fs" % (time.time() - t1))

everything = [x for _, objs, _ in groups for x in objs]
tiles = []
tmp = args.tiles or os.path.splitext(args.out)[0] + "_tiles"
os.makedirs(tmp, exist_ok=True)
times = []
for name, objs, frame in groups:
    keep = set(x.name for x in objs)
    for x in everything:
        x.hide_render = x.name not in keep
    p = os.path.join(tmp, name + ".png")
    home = None
    if args.plain:  # the plain rig's ground is a 400 m disc at the origin: shoot every subject there
        home = objs[0].location.copy()
        objs[0].location = (0.0, 0.0, home.z)
        bpy.context.view_layer.update()
    preview.camera(frame, yaw=args.yaw, pitch=pitch, margin=margin)
    t = time.time()
    preview.render(p, (TS, TS), args.samples)
    if home is not None:
        objs[0].location = home
    times.append(time.time() - t)
    print("TILE %s %.1fs" % (name, times[-1]))
    tiles.append(p)
os.makedirs(os.path.dirname(os.path.abspath(args.out)), exist_ok=True)
blib.tile_sheet(tiles, args.out, cols=min(args.cols, len(tiles)), tile=(TS, TS))
print("SHEET %s %d tiles, %.1fs per tile (%s)" % (args.out, len(tiles), sum(times) / max(1, len(times)),
                                                   "plain" if args.plain else "toon"))
