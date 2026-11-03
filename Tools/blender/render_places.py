"""Render a terrain preview of every town (physical_map.json settlements) and every area (regions.json map.at).

Each place is one build_world_terrain.py run (a 10 km tile centred on it, rendered with the toon preview);
several run at once. Writes places_manifest.json next to the renders for the live view (reports/live_view.html).

Usage: python Tools/blender/render_places.py [--workers 3] [--only towns|areas] [--tile-km 10] [-- extra args]
"""
import argparse
import concurrent.futures as cf
import glob
import json
import os
import re
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
ap.add_argument("--workers", type=int, default=3)
ap.add_argument("--only", default="towns,areas")
ap.add_argument("--tile-km", type=float, default=10.0)
ap.add_argument("--out-dir", default=os.path.join(REPO, "Art", "Blender", "WorldTerrain", "places"))
args = ap.parse_args(argv)
OUT = os.path.abspath(args.out_dir)
LOGS = os.path.join(OUT, "logs")
os.makedirs(LOGS, exist_ok=True)


def slug(s):
    return re.sub(r"[^a-z0-9]+", "_", s.lower()).strip("_")


pm = json.load(open(os.path.join(REPO, "Data", "World", "physical_map.json"), encoding="utf-8"))
regions = json.load(open(os.path.join(REPO, "Data", "World", "regions.json"), encoding="utf-8"))
jobs = []
if "towns" in args.only:
    for s in pm.get("settlements", []):
        jobs.append({"kind": "town", "name": s["name"], "region": s["region"], "label": "town_" + slug(s["name"]),
                     "args": ["--center", "%g,%g" % (s["x"], s["y"])]})
if "areas" in args.only:
    for r in regions:
        at = (r.get("map") or {}).get("at")
        if at:
            jobs.append({"kind": "area", "name": r["name"], "region": r["id"], "label": "area_" + slug(r["id"]),
                         "args": ["--center", "%g,%g" % (at[0], at[1])]})


def run(job):
    cmd = [BLENDER, "-b", "--factory-startup", "-P", BUILD, "--", "--repo", REPO, "--out-dir", OUT,
           "--tile-km", str(args.tile_km), "--label", job["label"]] + job["args"] + extra
    t0 = time.time()
    with open(os.path.join(LOGS, job["label"] + ".log"), "w", encoding="utf-8") as log:
        code = subprocess.call(cmd, stdout=log, stderr=subprocess.STDOUT, cwd=REPO)
    return job, code, time.time() - t0


def write_manifest():
    items = []
    for j in jobs:
        prev = sorted(glob.glob(os.path.join(OUT, j["label"] + "_x*_preview.png")))
        if prev:
            items.append({"kind": j["kind"], "name": j["name"], "region": j["region"],
                          "path": os.path.relpath(prev[-1], REPO).replace("\\", "/")})
    with open(os.path.join(OUT, "places_manifest.json"), "w", encoding="utf-8") as f:
        json.dump({"updated": time.strftime("%Y-%m-%d %H:%M:%S"), "total": len(jobs), "items": items}, f, indent=1)
    return len(items)


print("%d places (%d workers)" % (len(jobs), args.workers), flush=True)
fails = 0
with cf.ThreadPoolExecutor(max_workers=args.workers) as ex:
    for f in cf.as_completed([ex.submit(run, j) for j in jobs]):
        job, code, secs = f.result()
        fails += code != 0
        n = write_manifest()
        print("[%s] %s %s in %.0f s (%d/%d rendered)" % ("OK" if code == 0 else "FAIL", job["kind"], job["name"], secs, n, len(jobs)), flush=True)
print("done: %d rendered, %d failed" % (write_manifest(), fails))
sys.exit(1 if fails else 0)
