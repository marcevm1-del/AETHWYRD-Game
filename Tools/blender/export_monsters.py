"""Re-export the bestiary to Unity FBX, in batch.

`finish_generated_monster.py` finishes ONE creature that is already in the scene: joins it, scales it to its real
size, stands it on the origin, decimates to the size budget and exports the FBX. It was written to be called by
hand. This drives it across the whole roster, which is what you need after a change to the generator - the models
in `Game/` are exported files and do not improve until they are exported again.

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/export_monsters.py
    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/export_monsters.py -- --limit 10
    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/export_monsters.py -- --ids mon_goblin,mon_mana_fox
    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/export_monsters.py -- --detail low --dry-run

Output goes where finish() puts it: Game/Assets/_Game/Art/Models/Monsters/<Family>/<species_id>.fbx, with each
result recorded in Art/Generation/monster_models.json.

A failure on one species is reported and the run carries on; the count of failures is the exit code, so a clean run
exits 0.
"""
import os
import sys
import time

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(os.path.dirname(HERE))
sys.path.insert(0, HERE)

import bpy  # noqa: E402

import ascend_creatures  # noqa: E402
from ascend_creatures import generate as G  # noqa: E402


def arg(name, default=None):
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    if name in argv:
        i = argv.index(name)
        return argv[i + 1] if i + 1 < len(argv) and not argv[i + 1].startswith("--") else True
    return default


def clear():
    for o in list(bpy.data.objects):
        bpy.data.objects.remove(o, do_unlink=True)


def main():
    try:
        ascend_creatures.register()
    except Exception:
        pass

    # finish_generated_monster.py is written to be exec'd rather than imported, so bring it in the same way.
    ns = {}
    path = os.path.join(HERE, "finish_generated_monster.py")
    with open(path, encoding="utf-8") as fh:
        exec(compile(fh.read(), path, "exec"), ns)
    finish = ns["finish"]

    detail = arg("--detail", "high")
    dry = bool(arg("--dry-run"))
    ids = arg("--ids")
    limit = arg("--limit")

    species = list(G.species_list().keys())
    if ids:
        want = set(str(ids).split(","))
        species = [s for s in species if s in want]
    if limit:
        species = species[: int(limit)]

    print("[export] %d species, detail=%s%s" % (len(species), detail, " (dry run)" if dry else ""))
    t0 = time.time()
    failed = []
    for i, sid in enumerate(species, 1):
        try:
            clear()
            obj = G.creature(sid, 0, detail)
            if dry:
                print("[export] %4d/%d %-34s would export (%d faces)" % (i, len(species), sid, len(obj.data.polygons)))
                continue
            finish(obj.name, sid, provider="ascend_creatures", notes="batch re-export")
        except Exception as exc:  # keep going: one bad species must not cost the whole run
            failed.append((sid, str(exc).splitlines()[0][:120]))
            print("[export] FAILED %s: %s" % (sid, failed[-1][1]), flush=True)
        if i % 25 == 0:
            print("[export] %d/%d, %.0fs elapsed, %d failed" % (i, len(species), time.time() - t0, len(failed)), flush=True)

    print("[export] done: %d of %d in %.0fs, %d failed" % (len(species) - len(failed), len(species), time.time() - t0, len(failed)))
    for sid, why in failed[:20]:
        print("[export]   %s: %s" % (sid, why))
    return len(failed)


raise SystemExit(main())
