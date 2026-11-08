"""
Builds the human character library headlessly: generates variants from Data/Characters/human_library.json, validates the
rig, renders turnaround sheets in the toon preview, saves a .blend and exports FBX + GLB + sidecar JSON per variant.

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_character_library.py            # all 8 variants
    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_character_library.py -- --ids human_male_base,human_female_base
    options: --keys  --no-sheets  --no-export  --no-blend  --hash-only  --levels 1  --date 2026-11-08  --out <dir>  --reports <dir>
    a JSON variant can be given instead of an id:  --variant '{"body":"human_male_base","seed":7,"build":"sturdy"}'

--python-exit-code 1 matters: without it Blender exits 0 even when this script raises, and a broken rig would pass.
Output: Art/Blender/CharacterLibrary/<id>/ (gitignored), reports/characters_<date>/<id>.png and <id>_face.png,
13_Production/character_male_base.png and character_female_base.png (the two key images).
"""
import json
import os
import shutil
import sys
import time

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(os.path.dirname(HERE))
sys.path.insert(0, HERE)

import bpy  # noqa: E402

from ascend_characters import export as EX, generate, sheets, spec, validate  # noqa: E402


def arg(name, default=None):
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    if name in argv:
        i = argv.index(name)
        return argv[i + 1] if i + 1 < len(argv) and not argv[i + 1].startswith("--") else True
    return default


def clear():
    for o in list(bpy.data.objects):
        bpy.data.objects.remove(o, do_unlink=True)
    for coll in (bpy.data.meshes, bpy.data.armatures, bpy.data.materials, bpy.data.collections):
        for b in list(coll):
            if b.users == 0:
                coll.remove(b)


def main():
    date = arg("--date", time.strftime("%Y-%m-%d"))
    out_root = arg("--out", os.path.join(ROOT, "Art", "Blender", "CharacterLibrary"))
    rep_dir = arg("--reports", os.path.join(ROOT, "reports", "characters_" + date))
    levels = int(arg("--levels", 1)) if isinstance(arg("--levels", 1), (str, int)) and arg("--levels", 1) is not True else 1
    if arg("--variant"):
        todo = [json.loads(arg("--variant"))]
    else:
        ids = arg("--ids")
        todo = ids.split(",") if isinstance(ids, str) else spec.variant_ids()
    failures = []
    for v in todo:
        clear()
        t = time.time()
        ch = generate.character(v, levels=levels, log=print)
        name = ch["spec"]["id"]
        problems = validate.check(ch)
        print("[AC] %-28s hash %s  rig problems: %d  %5.1fs" % (name, ch["hash"], len(problems), time.time() - t), flush=True)
        for p in problems:
            print("[AC]   PROBLEM", p)
        if problems:
            failures.append(name)
            continue
        if arg("--hash-only"):
            continue
        if not arg("--no-sheets"):
            png = os.path.join(rep_dir, name + ".png")
            sheets.turnaround(ch, png)
            if arg("--keys") and name in ("human_male_base", "human_female_base"):
                key = os.path.join(ROOT, "13_Production", "character_%s_base.png" % ch["spec"]["sex"])
                sheets.key_image(ch, key)
                print("[AC] key image", key)
            shutil.rmtree(os.path.join(rep_dir, "_tiles"), ignore_errors=True)
        if not arg("--no-export"):
            files = EX.export(ch, os.path.join(out_root, name))
            print("[AC] exported", {k: os.path.relpath(p, ROOT) for k, p in files.items()}, flush=True)
        if not arg("--no-blend"):
            os.makedirs(os.path.join(out_root, name), exist_ok=True)
            bpy.ops.wm.save_as_mainfile(filepath=os.path.join(out_root, name, name + ".blend"), compress=True, copy=True)
    if failures:
        raise SystemExit("rig validation failed for: " + ", ".join(failures))
    print("[AC] done: %d variants" % len(todo))


main()
