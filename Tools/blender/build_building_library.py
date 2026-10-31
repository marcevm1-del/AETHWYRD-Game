"""
Builds the regional building libraries headlessly.

    blender -b --factory-startup -P Tools/blender/build_building_library.py                # one region per style family
    blender -b --factory-startup -P Tools/blender/build_building_library.py -- --all       # all 48 regions
    blender -b --factory-startup -P Tools/blender/build_building_library.py -- --regions lirian,frostveil
    (add --detail medium, --seed 3, --variants 2, --no-sheets as needed)
    ... -- --regions mossdeep --types smithy,barn,gatehouse --sheet-dir <dir> --out-dir <dir>   # a quick look-dev pass

    --types a,b,c     build only these archetypes (core names; regional remaps still apply) instead of the full catalogue
    --sheet-dir <dir> where the contact sheets go (default 13_Production/screenshots/buildings)
    --out-dir <dir>   where the .blend libraries and preview tiles go (default Art/Blender/BuildingLibrary)
    --no-blend        do not keep the .blend (it and the preview tiles are written to a temp folder and deleted)

Output: Art/Blender/BuildingLibrary/<region>.blend (Blender assets, catalog file alongside) and contact sheets in
13_Production/screenshots/buildings/<region>.png.
"""
import os
import shutil
import sys
import tempfile
import time

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(os.path.dirname(HERE))
sys.path.insert(0, HERE)

import bpy  # noqa: E402

import ascend_buildings  # noqa: E402
from ascend_buildings import archetypes, library, styles  # noqa: E402


def arg(name, default=None):
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    if name in argv:
        i = argv.index(name)
        return argv[i + 1] if i + 1 < len(argv) and not argv[i + 1].startswith("--") else True
    return default


def main():
    ascend_buildings.register()
    no_blend = bool(arg("--no-blend"))
    out_dir = tempfile.mkdtemp(prefix="ab_lib_") if no_blend else os.path.abspath(
        arg("--out-dir") or os.path.join(ROOT, "Art", "Blender", "BuildingLibrary"))
    sheet_dir = None if arg("--no-sheets") else os.path.abspath(
        arg("--sheet-dir") or os.path.join(ROOT, "13_Production", "screenshots", "buildings"))
    types = arg("--types")
    if types:  # build only the named archetypes; the default run keeps the family's whole catalogue
        names = [t.strip() for t in types.split(",") if t.strip()]
        unknown = [t for t in names if t not in archetypes.ARCHETYPES]
        if unknown:
            raise SystemExit("[AB] unknown archetypes: %s" % ", ".join(unknown))
        library.archetypes.catalogue = lambda family, _n=names: list(_n)
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
        print("[AB] %-20s %2d buildings  %6.1f MB  %5.1fs  %s" % (rid, len(objs), mb, time.time() - t, path), flush=True)
    if no_blend:
        shutil.rmtree(out_dir, ignore_errors=True)


main()
