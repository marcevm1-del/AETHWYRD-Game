"""
World terrain tiles for AETHWYRD, built from Data/World/physical_map.json (docs: 13_Production/world_terrain.md).

With Blender (blend + preview render):
  blender -b --factory-startup -P Tools/blender/build_world_terrain.py -- --suite
  blender -b --factory-startup -P Tools/blender/build_world_terrain.py -- --tile 7,5 --tile 8,5
Without Blender (heightmaps + sidecars only; any Python with numpy):
  python Tools/blender/build_world_terrain.py --no-blend --region reg_aldmere

Addressing (repeatable, combined):  --tile TX,TY   --region reg_id   --bbox X0,Y0,X1,Y1 (km)   --center X,Y (km)   --at-settlement NAME
Size / resolution:                  --tile-km 10 (default)   --res 20 (metres, 10 for close-ups)   --seed 1
Outputs (Art/Blender/WorldTerrain/, gitignored): <name>.blend, <name>_height.png (16-bit) + <name>_height.json, <name>_splat.png,
<name>_top.png (shaded top view), <name>_preview.png (Blender render). --evidence DIR copies the small files for the reports.
--checks runs determinism / seam / peak / road / pad / river checks and writes checks.json (into --evidence or the output dir).
"""
import argparse
import datetime
import json
import math
import os
import shutil
import sys
import time

HERE = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, HERE)

import numpy as np

from ascend_terrain import checks as C
from ascend_terrain import tile as T
from ascend_terrain import dress as DR
from ascend_terrain.field import HeightField
from ascend_terrain.world import World

try:
    import bpy  # noqa: F401
    from ascend_terrain import blend as B
    HAVE_BPY = True
except ImportError:
    HAVE_BPY = False

argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else sys.argv[1:]
ap = argparse.ArgumentParser(prog="build_world_terrain")
ap.add_argument("--repo", default=os.path.abspath(os.path.join(HERE, "..", "..")))
ap.add_argument("--out-dir", default="")
ap.add_argument("--evidence", default="", help="directory for evidence copies (previews, sidecars, checks)")
ap.add_argument("--tile", action="append", default=[])
ap.add_argument("--region", action="append", default=[])
ap.add_argument("--bbox", action="append", default=[])
ap.add_argument("--center", action="append", default=[])
ap.add_argument("--at-settlement", action="append", default=[])
ap.add_argument("--tile-km", type=float, default=10.0)
ap.add_argument("--res", type=int, default=20)
ap.add_argument("--seed", type=int, default=1)
ap.add_argument("--label", default="")
ap.add_argument("--suite", action="store_true", help="the standard test set")
ap.add_argument("--checks", action="store_true")
ap.add_argument("--no-blend", action="store_true")
ap.add_argument("--no-render", action="store_true")
ap.add_argument("--res-render", default="1600x900")
ap.add_argument("--samples", type=int, default=24)
ap.add_argument("--exag", type=float, default=1.0, help="vertical scale of the saved mesh (keep 1)")
ap.add_argument("--preview-exag", type=float, default=0.0, help="vertical exaggeration of the preview picture only (0 = auto, up to 3x on flat tiles)")
ap.add_argument("--only", action="append", default=[], help="with --suite: only these suite names (heartland, heartland_east, aldmere, ironhold, dragonspine, coast, sunscar, closeup)")
ap.add_argument("--no-dress", action="store_true", help="skip the dressing layer (trees, houses, props)")
ap.add_argument("--hash-only", action="store_true", help="print the heightmap hashes and exit")
args = ap.parse_args(argv)

REPO = os.path.abspath(args.repo)
OUT = os.path.abspath(args.out_dir) if args.out_dir else os.path.join(REPO, "Art", "Blender", "WorldTerrain")
EVID = os.path.abspath(args.evidence) if args.evidence else ""
RES = tuple(int(v) for v in args.res_render.lower().split("x"))
do_blend = HAVE_BPY and not args.no_blend
t0 = time.time()
world = World(REPO)
field = HeightField(world, args.seed)
print("world: %d settlements (%s), %d roads (%s), %d peaks, %d rivers (smoothed paths: %s), %d lakes" % (
    len(world.settlements), "physical_map.settlements" if world.has_settlements else "fallback", len(world.roads),
    "physical_map.roads" if world.has_roads else "fallback", len(world.peaks), len(world.rivers), world.has_smooth_rivers, len(world.lakes)))


def pair(s):
    a, b = s.split(",")
    return float(a), float(b)


def resolve():
    specs = []
    for s in args.tile:
        tx, ty = pair(s)
        specs.append(T.tile_at(tx, ty, args.tile_km, args.res, args.label))
    for r in args.region:
        bb = world.region_bbox(r)
        specs += [TS for TS in T.tiles_for_bbox(*bb, size_km=args.tile_km, res_m=args.res, world=world)]
    for b in args.bbox:
        x0, y0, x1, y1 = (float(v) for v in b.split(","))
        specs += T.tiles_for_bbox(x0, y0, x1, y1, args.tile_km, args.res, world)
    for c in args.center:
        specs.append(T.tile_centered(*pair(c), size_km=args.tile_km, res_m=args.res, label=args.label))
    for nm in args.at_settlement:
        st = world.settlement(nm)
        if st is None:
            raise SystemExit("unknown settlement " + nm)
        specs.append(T.tile_centered(*st["at"], size_km=args.tile_km, res_m=args.res, label=args.label or nm.lower().replace(" ", "_")))
    return specs


def suite():
    """name -> spec. Heartland and its east neighbour are the seam pair."""
    def at(name):
        return world.settlement(name)["at"]
    S = {}
    S["heartland"] = T.tile_centered(*at("Brindlewick"), label="heartland")
    S["heartland_east"] = S["heartland"].neighbour(1, 0, "heartland_east")
    S["aldmere"] = T.tile_centered(*at("Aldmere"), label="aldmere")
    S["ironhold"] = T.tile_centered(66.5, 38.0, label="ironhold_mountain")
    S["dragonspine"] = T.tile_centered(88.0, 28.0, label="dragonspine_mountain")
    S["coast"] = T.tile_at(3, 8, label="coast_southwest")
    S["sunscar"] = T.tile_centered(70.0, 82.0, label="sunscar_desert")
    S["closeup"] = T.TileSpec(int(round(at("Brindlewick")[0] * 1000 / 10)) * 10 - 1000, int(round(at("Brindlewick")[1] * 1000 / 10)) * 10 - 1000,
                              2000, 10, "brindlewick_closeup")
    return S


DRESSED = {}


def view_params(t):
    """Camera for the preview: mountains from a lower angle, close-ups a little higher and tighter."""
    s = t.spec
    rng = float(t.h.max() - t.h.min())
    if s.size_m <= 3000:
        return dict(yaw=-32.0, pitch=19.0, lens=21.0)
    if rng > 600:
        return dict(yaw=-30.0, pitch=16.0, lens=21.0)
    return dict(yaw=-30.0, pitch=18.0, lens=21.0)


def write_tile(t, render_it=True):
    s = t.spec
    os.makedirs(OUT, exist_ok=True)
    base = os.path.join(OUT, s.name)
    files = {"heightmap": s.name + "_height.png", "sidecar": s.name + "_height.json", "splat": s.name + "_splat.png", "top": s.name + "_top.png"}
    T.write_png(base + "_height.png", t.u16)
    back = T.read_png16(base + "_height.png")
    assert np.array_equal(back, t.u16), "PNG round trip failed"
    T.write_png(base + "_splat.png", (np.clip(t.splat, 0, 1) * 255 + 0.5).astype(np.uint8))
    T.write_png(base + "_top.png", np.repeat(np.repeat(T.hillshade_rgb(t), 2, 0), 2, 1) if s.n < 700 else T.hillshade_rgb(t))
    out = {"name": s.name, "hash": t.sha256, "min": float(t.h.min()), "max": float(t.h.max())}
    D = None
    if not args.no_dress:
        D = DR.place(world, field, t, args.seed)
        DRESSED[s.name] = D
        out["dressing"] = {"sha256": D.sha256, "counts": D.counts(), "ring0Violations": DR.ring0_violations(D, world)}
        print("    dressing %s  %s" % (D.sha256[:16], {k: v for k, v in D.counts().items() if k != "byKind"}))
    if do_blend:
        zs = B.preview_zscale([t], args.preview_exag)
        k, kb = B.dress_factors([t])
        sc, objs, _st = B.build_scene([t], args.exag, OUT, [D] if D else None, zs, k, kb, RES)
        if render_it and not args.no_render:
            files["preview"] = s.name + "_preview.png"
            out["renderSeconds"] = round(B.render(sc, [t], base + "_preview.png", RES, args.samples, zs=zs, **view_params(t)), 1)
            out["previewZScale"] = zs
            out["previewDressingScale"] = {"trees": k, "buildings": kb}
        if D is not None and s.size_m <= 3000 and render_it and not args.no_render and D.paths:
            # a human-height look at the gate, the lamp path and the clock tower, true scale (no exaggeration of anything)
            B.rebuild_dressing([D], [t], 1.0, 1.0, 1.0)
            pp = D.paths[0]["pts"]
            cx_, cy_ = float(pp[-1][0]), float(pp[-1][1])
            sx_, sy_ = D.notes["streetCamera"]
            sampler = DR.Sampler(t)
            gz = float(sampler.at(t.h, sx_, sy_)) + 4.0
            tz = float(sampler.at(t.h, cx_, cy_)) + 9.0
            files["street"] = s.name + "_street.png"
            B.render(sc, [t], base + "_street.png", RES, args.samples, zs=1.0, cam=((sx_, -sy_, gz), (cx_ + 45.0, -(cy_ - 20.0), tz), 26.0))
        if D is not None and s.size_m > 3000 and render_it and not args.no_render:
            lms = [l for l in D.landmarks if "clock" not in l[0]]
            if lms:                          # a close look at the tile's landmark (city tower and wall, lighthouse) at true scale
                name, lx, ly = lms[0]
                sampler = DR.Sampler(t)
                if "lighthouse" in name:
                    ang = D.props["lighthouse"][0][3]
                    ox, oy, dist, up = -math.cos(ang), -math.sin(ang), 150.0, 36.0
                    ox, oy = ox + 0.55, oy - 0.35
                else:
                    ox, oy, dist, up = -0.62, 0.78, 300.0, 120.0
                n_ = math.hypot(ox, oy)
                cxp, cyp = lx + ox / n_ * dist, ly + oy / n_ * dist
                B.rebuild_dressing([D], [t], 1.0, 1.0, 1.0)
                files["detail"] = s.name + "_detail.png"
                B.render(sc, [t], base + "_detail.png", RES, args.samples, zs=1.0,
                         cam=((cxp, -cyp, float(sampler.at(t.h, cxp, cyp)) + up), (lx, -ly, float(sampler.at(t.h, lx, ly)) + (14.0 if "lighthouse" in name else 6.0)), 28.0))
        if D is not None and D.deltas and render_it and not args.no_render:
            dl = D.deltas[0]                 # the river mouth: fan, channels and plume, seen from the land side
            sampler = DR.Sampler(t)
            cxp, cyp = dl["x"] - dl["dx"] * 330.0 + dl["dy"] * 120.0, dl["y"] - dl["dy"] * 330.0 - dl["dx"] * 120.0
            B.rebuild_dressing([D], [t], 1.0, 1.0, 1.0)
            files["delta"] = s.name + "_delta.png"
            B.render(sc, [t], base + "_delta.png", RES, args.samples, zs=1.0,
                     cam=((cxp, -cyp, float(max(sampler.at(t.h, cxp, cyp), 0.0)) + 55.0), (dl["x"] + dl["dx"] * 120.0, -(dl["y"] + dl["dy"] * 120.0), 0.0), 24.0))
        if D is not None:
            B.rebuild_dressing([D], [t], 1.0, 1.0, 1.0)                 # the saved .blend is true scale
        files["blend"] = s.name + ".blend"
        B.save_blend(base + ".blend")
    extra = {"roadReports": {pl.id: field.road_stats.get(pl.id) for pl in field.road_lines_in(s.bbox_m)}}
    if D is not None:
        extra["dressing"] = {"layer": "separate from the heightmap: it reads heights, never writes them", "sha256": D.sha256, "counts": D.counts(),
                             "ring0Violations": out["dressing"]["ring0Violations"], "landmarks": [{"name": n, "xKm": round(x / 1000, 4), "yKm": round(y / 1000, 4)} for n, x, y in D.landmarks]}
    T.save_json(base + "_height.json", T.sidecar(world, field, t, files, extra))
    print("  %-44s %6.1f..%6.1f m  sha %s" % (s.name, t.h.min(), t.h.max(), t.sha256[:16]))
    return out


def copy_evidence(names):
    if not EVID:
        return
    os.makedirs(EVID, exist_ok=True)
    for n in names:
        for suf in ("_preview.png", "_street.png", "_detail.png", "_delta.png", "_top.png", "_height.json"):
            p = os.path.join(OUT, n + suf)
            if os.path.exists(p):
                shutil.copy2(p, os.path.join(EVID, n + suf))


results = {}
if args.suite:
    S = suite()
    specs = [v for k_, v in S.items() if not args.only or k_ in args.only]
else:
    specs = resolve()
    S = {}
if not specs and not args.checks:
    ap.error("nothing to build: give --tile / --region / --bbox / --center / --at-settlement / --suite")
seen, uniq = set(), []
for s in specs:
    if s.name not in seen:
        seen.add(s.name)
        uniq.append(s)
specs = uniq

built = {}
print("building %d tile(s)" % len(specs))
for s in specs:
    t = T.build_tile(field, s)
    built[s.name] = t
    if args.hash_only:
        print("%s %s" % (s.name, t.sha256))
        continue
    results[s.name] = write_tile(t)
if args.hash_only:
    sys.exit(0)

if args.suite and do_blend and not args.no_render and S["heartland"].name in built and S["heartland_east"].name in built:
    a, b = built[S["heartland"].name], built[S["heartland_east"].name]
    Ds = [DRESSED.get(a.spec.name), DRESSED.get(b.spec.name)] if not args.no_dress else None
    zs = B.preview_zscale([a, b], args.preview_exag)
    k, kb = B.dress_factors([a, b])
    sc, _, _st = B.build_scene([a, b], args.exag, OUT, Ds, zs, k, kb, RES)
    pr = os.path.join(OUT, "seam_pair_heartland_preview.png")
    B.render(sc, [a, b], pr, RES, args.samples, yaw=-24.0, pitch=18.0, lens=21.0, zs=zs)
    if Ds:
        B.rebuild_dressing(Ds, [a, b], 1.0, 1.0, 1.0)
    B.save_blend(os.path.join(OUT, "seam_pair_heartland.blend"))
    results["seam_pair"] = {"name": "seam_pair_heartland"}
    if EVID:
        os.makedirs(EVID, exist_ok=True)
        shutil.copy2(pr, os.path.join(EVID, "seam_pair_heartland_preview.png"))

if args.checks:
    ck = {"generated": datetime.datetime.now().isoformat(timespec="seconds"), "seed": args.seed, "bpy": HAVE_BPY,
          "dataSources": {"settlements": "physical_map.settlements" if world.has_settlements else "regions.json places + corridor endpoints",
                          "roads": "physical_map.roads" if world.has_roads else "corridors legs",
                          "riverPaths": "pathSmooth" if world.has_smooth_rivers else "path (corner-cut)"}}
    if args.suite:
        ref = S["heartland"]
    else:
        ref = specs[0] if specs else T.tile_centered(*world.settlement("Brindlewick")["at"], label="heartland")
    ck["determinism"] = [C.determinism(world, ref, args.seed)]
    if args.suite:
        ck["determinism"].append(C.determinism(world, S["ironhold"], args.seed))
    ck["seams"] = C.seams(world, field, ref)
    ck["peaks"] = C.peaks(world, field)
    ck["roads"] = C.roads(world, field)
    ck["pads"] = C.pads(world, field)
    ck["rivers"] = C.rivers(world, field)
    if not args.no_dress:
        ck["dressing"] = [C.dressing(world, field, t, args.seed) for n, t in built.items() if n in (S["heartland"].name, S["aldmere"].name, S["closeup"].name)] if args.suite else             [C.dressing(world, field, t, args.seed) for t in list(built.values())[:2]]
    ck["rasterRoadGrade"] = {n: C.raster_road_grade(t, field) for n, t in built.items()}
    ck["builtTiles"] = {n: {"sha256": t.sha256} for n, t in built.items()}
    ck["ok"] = all([ck["seams"]["ok"], ck["peaks"]["ok"], ck["roads"]["ok"], ck["pads"]["ok"],
                    all(d["sameSeedEqual"] and d["otherSeedDiffers"] for d in ck["determinism"]),
                    all(d["sameSeedEqual"] and d["ring0Violations"] == 0 and d["heightHashUnchanged"] for d in ck.get("dressing", []))])
    d = EVID or OUT
    os.makedirs(d, exist_ok=True)
    T.save_json(os.path.join(d, "checks.json"), ck)
    print("checks: seams ok=%s (east %.3g m, south %.3g m, 10m vs 20m %.3g m), peaks ok=%s (max err %.2f%%, nearest-grid %.2f%%), roads ok=%s (strict %s; known hairpin limitation: %s), pads ok=%s, determinism=%s, dressing=%s -> overall %s" % (
        ck["seams"]["ok"], ck["seams"]["eastFloatMaxDiff"], ck["seams"]["southFloatMaxDiff"], ck["seams"]["res10vs20MaxDiff"],
        ck["peaks"]["ok"], ck["peaks"]["maxErrPct"], ck["peaks"]["maxErrGridPct"], ck["roads"]["ok"], ck["roads"]["strictOk"],
        {k_: "%s/%d over (%.3f%%)" % (k_, v_["samplesOverLimit"], v_["pctOverLimit"]) for k_, v_ in ck["roads"]["knownLimitation"]["roads"].items()}, ck["pads"]["ok"],
        [d_["sameSeedEqual"] for d_ in ck["determinism"]], [(d_["sameSeedEqual"], d_["ring0Violations"], d_["heightHashUnchanged"]) for d_ in ck.get("dressing", [])], ck["ok"]))

copy_evidence([r["name"] for r in results.values()])
print("DONE in %.1fs (blend=%s)" % (time.time() - t0, do_blend))
