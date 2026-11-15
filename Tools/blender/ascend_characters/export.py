"""
Export one character for Unity: a rigged FBX (build_rig.export_fbx: Unity axis fix, humanoid bones, parts as separate
skinned meshes with shape keys), a GLB for quick viewing, and a sidecar JSON (bone list, parts, materials, shape keys,
swap groups). Output goes under Art/Blender/CharacterLibrary/<variant>/ which is gitignored.
"""
import json
import os

import bpy

from . import meshio as M
from . import skeleton as SK

GROUP = {"body": "body", "eyes": "face", "brows": "face", "mouth": "face", "ears": "face", "hair": "hair",
         "top": "outfit", "bottom": "outfit", "skirt": "outfit", "belt": "outfit", "boots": "outfit", "bracers": "outfit",
         "cloak": "outfit"}


def sidecar(ch):
    arm = ch["armature"]
    sp = ch["spec"]
    parts = []
    for k, o in sorted(ch["parts"].items()):
        me = o.data
        sks = [s.name for s in me.shape_keys.key_blocks if s.name != "Basis"] if me.shape_keys else []
        parts.append(dict(part=k, object=o.name, group=GROUP.get(k, "other"), material=me.materials[0].name if me.materials else None,
                          vertices=len(me.vertices), triangles=M.tri_count(o), shapeKeys=sks,
                          colourAttribute="Col" if me.attributes.get("Col") else None))
    bones = [dict(name=b.name, parent=b.parent.name if b.parent else None, head=[round(v, 5) for v in b.head_local],
                  tail=[round(v, 5) for v in b.tail_local], humanoid=b.name in SK.HUMANOID_NAMES) for b in arm.data.bones]
    return dict(
        id=sp["id"], body=sp["body"]["id"], sex=sp["sex"], seed=sp["seed"], heightM=sp["heightM"], hash=ch["hash"],
        build=sp["build"]["id"], age=sp["age"]["id"], skin=sp["skin"]["id"], hair=dict(style=sp["hair"]["style"], colour=sp["hair"]["colour"]["id"]),
        eyes=sp["eyes"]["id"], outfit=dict(id=sp["outfit"]["id"], parts=sp["outfitParts"]),
        rig=dict(contract="human_v1", armature=arm.name, restPose="T", forward="-Y in Blender, +Z in Unity after the FBX axis fix",
                 humanoidBones=len(SK.HUMANOID_NAMES), extraBones=SK.EXTRA_NAMES, bones=bones),
        parts=parts, materials=sorted({p["material"] for p in parts if p["material"]}),
        unity=dict(avatar="Humanoid", note="Set Rig > Animation Type = Humanoid (Create From This Model); materials map by name to the toon shader; "
                                           "the Col colour attribute is the base colour (vertex colour)."),
    )


def _activate_colours(ch):
    for o in ch["parts"].values():
        me = o.data
        a = me.color_attributes.get("Col")
        if a is not None:
            me.color_attributes.active_color = a
            try:
                me.color_attributes.render_color_index = list(me.color_attributes).index(a)
            except ValueError:
                pass


def export(ch, out_dir, fbx=True, glb=True):
    import sys
    sys.path.insert(0, os.path.dirname(os.path.dirname(os.path.abspath(__file__))))
    import build_rig
    name = ch["spec"]["id"]
    os.makedirs(out_dir, exist_ok=True)
    _activate_colours(ch)
    out = {}
    side = os.path.join(out_dir, name + ".json")
    with open(side, "w", encoding="utf8") as f:
        json.dump(sidecar(ch), f, indent=1)
    out["json"] = side
    if fbx:
        p = os.path.join(out_dir, name + ".fbx")
        build_rig.export_fbx(ch["armature"], ch["collection"], p)
        out["fbx"] = p
    if glb:
        p = os.path.join(out_dir, name + ".glb")
        for o in bpy.context.view_layer.objects:
            o.select_set(False)
        for o in ch["collection"].objects:
            o.select_set(True)
        bpy.context.view_layer.objects.active = ch["armature"]
        props = bpy.ops.export_scene.gltf.get_rna_type().properties
        kw = dict(filepath=p, export_format="GLB", use_selection=True, export_apply=False, export_skins=True, export_morph=True)
        if "export_vertex_color" in props:
            kw["export_vertex_color"] = "ACTIVE" if "ACTIVE" in [i.identifier for i in props["export_vertex_color"].enum_items] else "MATERIAL"
        elif "export_colors" in props:
            kw["export_colors"] = True
        kw = {k: v for k, v in kw.items() if k in props}
        bpy.ops.export_scene.gltf(**kw)
        out["glb"] = p
    return out
