"""
Builds the regional building libraries headlessly.

    blender -b --factory-startup -P Tools/blender/build_building_library.py                # one region per style family
    blender -b --factory-startup -P Tools/blender/build_building_library.py -- --all       # all 48 regions
    blender -b --factory-startup -P Tools/blender/build_building_library.py -- --regions lirian,frostveil
    (add --detail medium, --seed 3, --variants 2, --no-sheets as needed)

Output: Art/Blender/BuildingLibrary/<region>.blend (Blender assets, catalog file alongside) and contact sheets in
13_Production/screenshots/buildings/<region>.png.
"""
import os
import sys
import time

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(os.path.dirname(HERE))
sys.path.insert(0, HERE)

import bpy  # noqa: E402

import ascend_buildings  # noqa: E402
from ascend_buildings import library, styles  # noqa: E402


def arg(name, default=None):
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    if name in argv:
        i = argv.index(name)
        return argv[i + 1] if i + 1 < len(argv) and not argv[i + 1].startswith("--") else True
    return default


def main():
    ascend_buildings.register()
    out_dir = os.path.join(ROOT, "Art", "Blender", "BuildingLibrary")
    sheet_dir = None if arg("--no-sheets") else os.path.join(ROOT, "13_Production", "screenshots", "buildings")
    if arg("--all"):
        regions = list(styles.REGIONS)
    elif arg("--regions"):
        regions = arg("--regions").split(",")
    else:
        regions = library.representative_regions()
    library.write_catalogs(out_dir)
    for rid in regions:
        t = time.time()
        library.clear_scene()
        path, objs = library.build_region(rid, out_dir, sheet_dir, seed=int(arg("--seed", 1)), detail=arg("--detail", "high"),
                                          extra_seeds=int(arg("--variants", 1)) - 1)
        mb = os.path.getsize(path) / 1e6
        print("[AB] %-20s %2d buildings  %6.1f MB  %5.1fs  %s" % (rid, len(objs), mb, time.time() - t, path))


main()
