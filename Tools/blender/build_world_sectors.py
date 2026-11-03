"""Build the whole world terrain faster by splitting it into sectors and running one Blender worker per sector.

Every tile is a pure function of world position and seed (see ascend_terrain/tile.py), so a tile built by a
sector worker is byte-identical to the same tile built alone: splitting only changes the wall-clock time.
After the build this script proves it:
  1. seams: every shared edge between neighbouring tiles (inside a sector and across sector borders) differs by 0;
  2. reference: tiles on the sector borders are rebuilt in one separate --hash-only process and their heightmap
     SHA-256 must match the sector build;
  3. overview: the tiles' splat maps are stitched into one picture of the whole map.

Usage (plain Python 3 with numpy + Pillow; Blender is launched per sector):
  python Tools/blender/build_world_sectors.py [--sectors 3x2] [--workers 6] [--render] [--verify-only] [-- extra args]
Extra args after "--" go to every build_world_terrain.py worker (for example --no-dress or --res 10).
"""
import argparse
import concurrent.futures as cf
import glob
import hashlib
import json
import os
import subprocess
import sys
import time

REPO = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", ".."))
BLENDER = os.environ.get("ASCEND_BLENDER", "E:/SteamLibrary/steamapps/common/Blender/blender.exe")
BUILD = os.path.join(REPO, "Tools", "blender", "build_world_terrain.py")

argv = sys.argv[1:]
extra = []
if "--" in argv:
    i = argv.index("--")
    argv, extra = argv[:i], argv[i + 1:]
ap = argparse.ArgumentParser()
ap.add_argument("--sectors", default="3x2", help="columns x rows of sectors")
ap.add_argument("--workers", type=int, default=6, help="Blender processes at once")
ap.add_argument("--tile-km", type=float, default=10.0)
ap.add_argument("--res", type=int, default=20)
ap.add_argument("--out-dir", default=os.path.join(REPO, "Art", "Blender", "WorldTerrain", "world"))
ap.add_argument("--render", action="store_true", help="also render a preview per tile (slow, GPU)")
ap.add_argument("--verify-only", action="store_true")
args = ap.parse_args(argv)

grid = json.load(open(os.path.join(REPO, "Data", "World", "physical_map.json"), encoding="utf-8"))["grid"]
W_KM, H_KM = grid["mapUnits"]
NX = int(round(W_KM / args.tile_km))
NY = int(round(H_KM / args.tile_km))
SX, SY = (int(v) for v in args.sectors.lower().split("x"))
OUT = os.path.abspath(args.out_dir)
LOGS = os.path.join(OUT, "logs")
os.makedirs(LOGS, exist_ok=True)


def sector_tiles(sx, sy):
    xs = range(sx * NX // SX, (sx + 1) * NX // SX)
    ys = range(sy * NY // SY, (sy + 1) * NY // SY)
    return [(tx, ty) for ty in ys for tx in xs]


SECTORS = {"s%d%d" % (sx, sy): sector_tiles(sx, sy) for sy in range(SY) for sx in range(SX)}


def tile_args(tiles):
    a = []
    for tx, ty in tiles:
        a += ["--tile", "%d,%d" % (tx, ty)]
    return a


def run_sector(name, tiles):
    cmd = [BLENDER, "-b", "--factory-startup", "-P", BUILD, "--", "--repo", REPO, "--out-dir", OUT,
           "--tile-km", str(args.tile_km), "--res", str(args.res)] + tile_args(tiles) + extra
    if not args.render:
        cmd.append("--no-render")
    t0 = time.time()
    with open(os.path.join(LOGS, name + ".log"), "w", encoding="utf-8") as log:
        code = subprocess.call(cmd, stdout=log, stderr=subprocess.STDOUT, cwd=REPO)
    return name, code, time.time() - t0, len(tiles)


def sidecars():
    """tile (tx, ty) -> sidecar dict, for sidecars that belong to this tile grid."""
    out = {}
    S = args.tile_km
    for p in glob.glob(os.path.join(OUT, "*_height.json")):
        d = json.load(open(p, encoding="utf-8"))
        t = d["tile"]
        if abs(t["sizeKm"] - S) > 1e-6 or d["resolutionM"] != args.res:
            continue
        tx, ty = t["x0Km"] / S, t["y0Km"] / S
        if abs(tx - round(tx)) > 1e-6 or abs(ty - round(ty)) > 1e-6:
            continue
        out[(int(round(tx)), int(round(ty)))] = d
    return out


def load_height(d):
    import numpy as np
    from PIL import Image
    im = Image.open(os.path.join(OUT, d["files"]["heightmap"]))
    return np.array(im, dtype=np.int64)


def verify():
    import numpy as np
    from PIL import Image
    report = {"sectors": {k: len(v) for k, v in SECTORS.items()}, "tiles": NX * NY}
    sc = sidecars()
    missing = [t for t in ((x, y) for y in range(NY) for x in range(NX)) if t not in sc]
    report["missing"] = missing

    # 1. seams across every shared edge; a pair is "cross" when its two tiles are in different sectors
    owner = {t: k for k, v in SECTORS.items() for t in v}
    worst, worst_cross, pairs, cross = 0, 0, 0, 0
    cache = {}

    def H(t):
        if t not in cache:
            cache[t] = load_height(sc[t])
        return cache[t]

    for (tx, ty) in sorted(sc):
        for nb, edge in (((tx + 1, ty), "east"), ((tx, ty + 1), "south")):
            if nb not in sc:
                continue
            a, b = H((tx, ty)), H(nb)
            d = int(np.abs(a[:, -1] - b[:, 0]).max()) if edge == "east" else int(np.abs(a[-1, :] - b[0, :]).max())
            pairs += 1
            worst = max(worst, d)
            if owner.get((tx, ty)) != owner.get(nb):
                cross += 1
                worst_cross = max(worst_cross, d)
        if len(cache) > 40:
            cache.clear()
    report["seams"] = {"pairs": pairs, "crossSectorPairs": cross, "maxDiffUnits": worst, "maxCrossDiffUnits": worst_cross}

    # 2. rebuild sector-border tiles alone in one process (--hash-only) and compare SHA-256
    border = []
    for (tx, ty) in sorted(sc):
        for nb in ((tx + 1, ty), (tx, ty + 1)):
            if nb in sc and owner.get((tx, ty)) != owner.get(nb):
                border += [(tx, ty), nb]
    border = sorted(set(border))[:: max(1, len(set(border)) // 8)][:8]
    ref = {}
    if border:
        cmd = [BLENDER, "-b", "--factory-startup", "-P", BUILD, "--", "--repo", REPO, "--tile-km", str(args.tile_km),
               "--res", str(args.res), "--hash-only"] + tile_args(border)
        out = subprocess.run(cmd, capture_output=True, text=True, cwd=REPO).stdout
        for line in out.splitlines():
            parts = line.strip().split()
            if len(parts) == 2 and len(parts[1]) == 64:
                ref[parts[0]] = parts[1]
    checks = []
    for t in border:
        d = sc[t]
        name = os.path.basename(d["files"]["sidecar"]).replace("_height.json", "")
        checks.append({"tile": t, "sector": owner.get(t), "sectorBuild": d["heightmapSha256"][:16],
                       "aloneBuild": ref.get(name, "")[:16], "same": ref.get(name) == d["heightmapSha256"]})
    report["reference"] = checks

    # 3. overview: a coloured, hillshaded relief stitched from the heightmaps (the same colour ramp for every tile,
    #    so a tile that differed from its neighbours would show as a visible square)
    px = 160
    stops = [(-1800, (24, 52, 92)), (-60, (52, 110, 160)), (0, (120, 180, 205)), (1, (214, 200, 150)),
             (40, (126, 178, 92)), (600, (92, 146, 74)), (1300, (176, 150, 112)), (2200, (150, 136, 150)),
             (2700, (240, 240, 245)), (3400, (255, 255, 255))]
    zs = np.array([s[0] for s in stops], dtype="float64")
    cs = np.array([s[1] for s in stops], dtype="float64")
    canvas = Image.new("RGB", (NX * px, NY * px), (24, 52, 92))
    for (tx, ty), d in sc.items():
        e = d["encoding"]
        h = e["minM"] + load_height(d).astype("float64") / 65535.0 * (e["maxM"] - e["minM"])
        step = max(1, (h.shape[0] - 1) // px)
        h = h[::step, ::step]
        rgb = np.stack([np.interp(h, zs, cs[:, k]) for k in range(3)], -1)
        gy, gx = np.gradient(h, args.res * step)
        shade = np.clip(0.75 + 1.6 * (-gx + gy) / np.sqrt(1 + gx * gx + gy * gy), 0.45, 1.25)
        shade[h <= 0] = 1.0
        im = Image.fromarray(np.clip(rgb * shade[..., None], 0, 255).astype("uint8"))
        canvas.paste(im.resize((px, px)), (tx * px, ty * px))
    ov = os.path.join(OUT, "world_overview.png")
    canvas.save(ov)
    report["overview"] = ov

    # "same map" = every tile built, no seam break across a sector border, border tiles identical when built alone.
    # Seams inside one sector come from one process, so any difference there is a terrain quirk, not the split.
    report["splitUnchanged"] = (not missing and worst_cross == 0 and all(c["same"] for c in checks) and bool(checks))
    report["ok"] = report["splitUnchanged"] and worst == 0
    with open(os.path.join(OUT, "sector_verify.json"), "w", encoding="utf-8") as f:
        json.dump(report, f, indent=1)
    return report


if not args.verify_only:
    print("world %dx%d tiles of %g km, %d sectors (%s), %d workers" % (NX, NY, args.tile_km, len(SECTORS), args.sectors, args.workers))
    t0 = time.time()
    with cf.ThreadPoolExecutor(max_workers=args.workers) as ex:
        futs = [ex.submit(run_sector, k, v) for k, v in SECTORS.items()]
        for f in cf.as_completed(futs):
            name, code, secs, n = f.result()
            print("[%s] sector %s: %d tiles in %.0f s (exit %d)" % ("OK" if code == 0 else "FAIL", name, n, secs, code), flush=True)
    print("all sectors done in %.0f s" % (time.time() - t0), flush=True)

r = verify()
print(json.dumps({k: r[k] for k in ("tiles", "missing", "seams", "reference", "splitUnchanged", "ok")}, indent=1))
print("overview:", r["overview"])
sys.exit(0 if r["ok"] else 1)
