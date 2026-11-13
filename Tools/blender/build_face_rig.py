"""
Adds the facial shape-key rig to the human bases, writes the expression manifest and (optionally) a contact sheet and the FBX.

    blender -b --factory-startup --python-exit-code 1 -P Tools/blender/build_face_rig.py [-- --bodies human_male_base,human_female_base --sheets <dir> --no-export --no-manifest]

Output: Data/Characters/face_expressions.json (committed: every key per part, the legacy keys, the expressions, the blink data, measured
displacements) and, gitignored, Art/Blender/AnimationLibrary/Faces/<body>/<body>.fbx from the character exporter with the new keys in it.
"""
import argparse
import json
import math
import os
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
sys.path.insert(0, HERE)
ROOT = os.path.dirname(os.path.dirname(HERE))
if os.environ.get("ASCEND_CHARACTERS_DIR"):
    sys.path.insert(0, os.environ["ASCEND_CHARACTERS_DIR"])

import bpy  # noqa: E402
import numpy as np  # noqa: E402

try:
    from ascend_characters import generate  # noqa: E402
    from ascend_characters import export as EX  # noqa: E402
    from ascend_characters import layout as LY  # noqa: E402
except ImportError as e:      # pragma: no cover
    sys.stderr.write("ascend_characters not found (%s); merge claude/humans-base or set ASCEND_CHARACTERS_DIR\n" % e)
    raise SystemExit(2)

from ascend_animation import face_expressions as FE  # noqa: E402
from ascend_animation import face_rig as FR  # noqa: E402
import check_face as CF  # noqa: E402


def parse():
    a = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []
    p = argparse.ArgumentParser()
    p.add_argument("--bodies", default="human_male_base,human_female_base")
    p.add_argument("--out", default=os.path.join(ROOT, "Art", "Blender", "AnimationLibrary", "Faces"))
    p.add_argument("--manifest", default=os.path.join(ROOT, "Data", "Characters", "face_expressions.json"))
    p.add_argument("--sheets", default="")
    p.add_argument("--no-export", action="store_true")
    p.add_argument("--no-manifest", action="store_true")
    return p.parse_args(a)


def sheet(ch, expressions, path, cols=6, size=(230, 250)):
    """Front view of the face for every expression (hair hidden so the brows read), one PNG grid."""
    sc = bpy.context.scene
    for nm in ("Cube", "Light", "Camera"):
        o = bpy.data.objects.get(nm)
        if o is not None:
            bpy.data.objects.remove(o)
    try:
        sc.render.engine = "BLENDER_WORKBENCH"
    except TypeError:
        pass
    sc.display.shading.light = "STUDIO"
    sc.display.shading.color_type = "VERTEX"
    sc.render.resolution_x, sc.render.resolution_y = size
    sc.world = sc.world or bpy.data.worlds.new("w")
    sc.world.color = (0.82, 0.86, 0.9)
    H = ch["spec"]["heightM"]
    ez = LY.Z[LY.EYE_RING] * H
    cam = bpy.data.objects.new("FaceCam", bpy.data.cameras.new("FaceCam"))
    sc.collection.objects.link(cam)
    cam.data.type = "ORTHO"
    cam.data.ortho_scale = 0.27
    cam.location = (0.0, -2.0, ez - 0.035)
    cam.rotation_euler = (math.radians(90), 0, 0)
    sc.camera = cam
    for k, o in ch["parts"].items():
        if k in ("hair", "top", "cloak"):
            o.hide_render = True
    tiles = []
    tmp = path + ".tile.png"
    names = list(expressions)
    for n in names:
        FR.set_expression(ch, expressions[n])
        bpy.context.view_layer.update()
        sc.render.filepath = tmp
        bpy.ops.render.render(write_still=True)
        img = bpy.data.images.load(tmp)
        tiles.append(np.array(img.pixels[:], dtype=np.float32).reshape(img.size[1], img.size[0], 4))
        bpy.data.images.remove(img)
    while len(tiles) % cols:
        tiles.append(np.ones_like(tiles[0]))
    rows = [np.concatenate(tiles[i:i + cols], axis=1) for i in range(0, len(tiles), cols)]
    grid = np.concatenate(rows[::-1], axis=0)           # Blender images are bottom-up: keep the first row on top
    out = bpy.data.images.new("sheet", grid.shape[1], grid.shape[0])
    out.pixels = grid.ravel().tolist()
    out.filepath_raw = path
    out.file_format = "PNG"
    out.save()
    bpy.data.images.remove(out)
    if os.path.exists(tmp):
        os.remove(tmp)
    FR.set_expression(ch, {})
    for o in ch["parts"].values():
        o.hide_render = False
    return names


def main():
    a = parse()
    bodies = [b for b in a.bodies.split(",") if b]
    manifest_keys = None
    metrics = {}
    closest = None
    for body in bodies:
        ch = generate.character(body)
        rig = FR.Rig(ch)
        keys = FR.apply(ch)
        bad, closest = CF.evaluate(rig, keys, FE.EXPRESSIONS, CF.legacy_ok(ch))
        if bad:
            raise SystemExit("face rig failed its own checks on %s:\n  %s" % (body, "\n  ".join(bad)))
        m = {}
        for part, ks in keys.items():
            for name, d in ks.items():
                nrm = np.linalg.norm(d, axis=1)
                m[name] = dict(part=part, maxMm=round(float(nrm.max()) * 1000, 2), movedVertices=int((nrm > 5e-5).sum()))
        metrics[body] = m
        if manifest_keys is None:
            manifest_keys = {part: {n: dict(vertices=len(d)) for n, d in ks.items()} for part, ks in keys.items()}
        sidecar = None
        if not a.no_export:
            od = os.path.join(a.out, body)
            res = EX.export(ch, od, fbx=True, glb=False)
            sidecar = os.path.relpath(res["fbx"], ROOT).replace("\\", "/")
        if a.sheets:
            os.makedirs(a.sheets, exist_ok=True)
            sheet(ch, FE.EXPRESSIONS, os.path.join(a.sheets, body + "_faces.png"))
        print("%s: %d new keys on eyes/brows/mouth; closest expression pair %s / %s %.2f mm%s" % (
            body, sum(len(v) for v in keys.values()), closest[1], closest[2], closest[0], ("; fbx " + sidecar) if sidecar else ""))
    if not a.no_manifest:
        doc = dict(
            schema="face_expressions/1", rigContract="human_v1", source="Tools/blender/build_face_rig.py",
            notes="Facial shape keys on the three face decal objects (eyes, brows, mouth) of every human, built by Tools/blender/ascend_animation/face_rig.py on top of the six keys "
                  "the character generator ships (legacyKeys, kept unchanged). Weights are 0..1 (Unity blend shape weight = 100 x). No visemes and no lip-sync. L means the "
                  "character's left (+X). There is no facial animation system: the game blends the expression weights (transition) and runs the blink data.",
            parts={part: dict(object=part, legacyKeys=FR.LEGACY[part], keys=[dict(name=n, **manifest_keys[part][n], maxMm=metrics[bodies[0]][n]["maxMm"],
                                                                                    movedVertices=metrics[bodies[0]][n]["movedVertices"]) for n in FR.ALL_KEYS[part]]) for part in FR.ALL_KEYS},
            pairs=[dict(part=p, left=l, right=r) for p, l, r in CF.mirror_pairs({part: {n: None for n in names} for part, names in FR.ALL_KEYS.items()})],
            expressions=FE.EXPRESSIONS, blink=FE.BLINK, transition=FE.TRANSITION,
            measured=dict(bodies=bodies, closestExpressionPair=[closest[1], closest[2]], closestMaxVertexMm=round(closest[0], 2)),
        )
        os.makedirs(os.path.dirname(a.manifest), exist_ok=True)
        with open(a.manifest, "w", encoding="utf8") as f:
            json.dump(doc, f, indent=1)
            f.write("\n")
        print("manifest:", a.manifest)


if __name__ == "__main__":
    main()
