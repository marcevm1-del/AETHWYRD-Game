"""Bake the generated terrain tiles into the compact files the Unity world streamer reads.

Source (local, gitignored): Art/Blender/WorldTerrain/world/<name>_height.{png,json} and <name>_splat.png
Output (local, gitignored): Game/Assets/StreamingAssets/World/<name>.tile  and  World/manifest.json

Tile file (little endian):
  char[4] "ATL1" | int32 samples | int32 splatRes | float32 minM | float32 maxM | float32 x0Km | float32 y0Km | float32 sizeKm
  uint16 heights[samples*samples]   raster order, row 0 = NORTH edge, col 0 = WEST edge (as in the PNG)
  uint8  splat[splatRes*splatRes*4] RGBA = vegetation, rock, sand, snow (box-downsampled from the PNG)
Height in metres = minM + value / 65535 * (maxM - minM), the same fixed encoding for every tile.

The manifest lists every tile and the Ring 0 anchor (Brindlewick map position and pad height) read from the sidecars,
so the runtime hard-codes no world number. Usage: python Tools/world/bake_stream_tiles.py [--splat-res 251] [--only x70_y50]
"""
import argparse, glob, json, os, struct, sys
import numpy as np
from PIL import Image

REPO = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", ".."))
ap = argparse.ArgumentParser()
ap.add_argument("--src", default=os.path.join(REPO, "Art", "Blender", "WorldTerrain", "world"))
ap.add_argument("--out", default=os.path.join(REPO, "Game", "Assets", "StreamingAssets", "World"))
ap.add_argument("--splat-res", type=int, default=251)
ap.add_argument("--only", default=None, help="bake one tile name (for tests)")
args = ap.parse_args()
os.makedirs(args.out, exist_ok=True)

manifest = {"format": "ascend-stream-tiles/1", "tileKm": None, "samples": None, "splatRes": args.splat_res, "minM": None, "maxM": None,
            "anchor": None, "tiles": []}
sidecars = sorted(glob.glob(os.path.join(args.src, "x*_y*_s10_r20_height.json")))
if args.only: sidecars = [s for s in sidecars if os.path.basename(s).startswith(args.only + "_")]
if not sidecars:
    sys.exit("no tile sidecars in " + args.src)

total = 0
for sc_path in sidecars:
    sc = json.load(open(sc_path, encoding="utf-8"))
    name = sc["name"]
    t = sc["tile"]
    n = sc["samples"]
    enc = sc["encoding"]
    if enc["bits"] != 16: sys.exit(name + ": expected 16-bit")
    h = np.asarray(Image.open(os.path.join(args.src, sc["files"]["heightmap"])))
    if h.dtype != np.uint16 or h.shape != (n, n): sys.exit("%s: unexpected heightmap %s %s" % (name, h.dtype, h.shape))
    sp_path = os.path.join(args.src, sc["files"]["splat"])
    sr = args.splat_res
    sp = Image.open(sp_path).convert("RGBA").resize((sr, sr), Image.BOX)
    sp = np.asarray(sp, dtype=np.uint8)
    # one fixed encoding for the whole world (seams depend on it)
    for key, val in (("tileKm", t["sizeKm"]), ("samples", n), ("minM", enc["minM"]), ("maxM", enc["maxM"])):
        if manifest[key] is None: manifest[key] = val
        elif manifest[key] != val: sys.exit("%s: %s differs from the other tiles" % (name, key))
    for s in sc.get("settlements") or []:
        if s.get("ring0") and manifest["anchor"] is None and s["name"] == "Brindlewick":
            manifest["anchor"] = {"name": s["name"], "mapKm": s["atKm"], "heightM": s["ring0"]["heightM"], "sizeM": s["ring0"]["sizeM"], "source": os.path.basename(sc_path)}
    fn = name + ".tile"
    with open(os.path.join(args.out, fn), "wb") as f:
        f.write(b"ATL1")
        f.write(struct.pack("<iiffff", n, sr, enc["minM"], enc["maxM"], t["x0Km"], t["y0Km"]))
        f.write(struct.pack("<f", t["sizeKm"]))
        f.write(h.astype("<u2").tobytes())
        f.write(sp.tobytes())
    size = os.path.getsize(os.path.join(args.out, fn))
    total += size
    manifest["tiles"].append({"name": name, "file": fn, "x0Km": t["x0Km"], "y0Km": t["y0Km"], "bytes": size,
                              "minM": sc["stats"]["minM"], "maxM": sc["stats"]["maxM"], "seaFraction": sc["stats"]["seaFraction"]})

manifest["totalBytes"] = total
if not args.only:
    json.dump(manifest, open(os.path.join(args.out, "manifest.json"), "w", encoding="utf-8"), indent=1)
print("baked %d tiles, %.1f MB, anchor %s" % (len(manifest["tiles"]), total / 1e6, manifest["anchor"]))
