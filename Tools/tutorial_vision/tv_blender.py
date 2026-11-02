"""Tutorial Vision, Blender side: build a node material from a JSON spec written after watching a tutorial, render a
preview, and dump an existing material back to the same spec format for comparison.

Headless (works anywhere Blender runs):
    blender -b --factory-startup -P Tools/tutorial_vision/tv_blender.py -- --spec spec.json --render out.png [--shape sphere|cube|monkey]
        [--size 512] [--light 400] [--view Standard|Filmic|AgX] [--world r,g,b]   (match the tutorial's look before comparing)
    blender -b file.blend -P Tools/tutorial_vision/tv_blender.py -- --dump MaterialName --out spec.json

Live (the Blender MCP `execute_blender_code` tool, in the user's open Blender): exec this file's text, then call
    build_material(spec) / dump_material(bpy.data.materials["Name"]) / assign(obj, mat)

Spec format:
    {"name": "Owl Body",
     "nodes": {"bsdf": {"type": "ShaderNodeBsdfPrincipled", "location": [0, 0],
                        "inputs": {"Base Color": {"hsv": [0.077, 0.481, 0.533]}, "Roughness": 0.4}},
               "out":  {"type": "ShaderNodeOutputMaterial", "location": [300, 0]}},
     "links": [["bsdf", "BSDF", "out", "Surface"]],
     "source": {"video": "...", "frames": ["0:17.2", "0:23.5"], "blender": "2.90.2"}}
Colours: [r, g, b(, a)] in scene-linear, {"hsv": [h, s, v]} or {"hex": "#rrggbb"} as shown in Blender's colour
picker (display space; converted to linear). Older tutorials' socket names are mapped to the current ones.
"""
import colorsys
import json
import math
import os
import sys

import bpy

# Blender 2.8-3.x Principled BSDF names -> 4.x/5.x
SOCKET_ALIASES = {
    "Subsurface": "Subsurface Weight", "Specular": "Specular IOR Level", "Specular Tint": "Specular Tint",
    "Transmission": "Transmission Weight", "Clearcoat": "Coat Weight", "Clearcoat Roughness": "Coat Roughness",
    "Clearcoat Normal": "Coat Normal", "Sheen": "Sheen Weight", "Emission": "Emission Color",
    "Subsurface Color": None, "Sheen Tint": None,   # removed or changed meaning: reported, not applied
}


def srgb_to_linear(c):
    return c / 12.92 if c <= 0.04045 else ((c + 0.055) / 1.055) ** 2.4


def colour(v):
    if isinstance(v, dict):
        if "hsv" in v:
            r, g, b = colorsys.hsv_to_rgb(*v["hsv"][:3])
        elif "hex" in v:
            h = v["hex"].lstrip("#")
            r, g, b = (int(h[i:i + 2], 16) / 255 for i in (0, 2, 4))
        else:
            raise ValueError("colour needs hsv, hex or a list: %r" % v)
        return [srgb_to_linear(r), srgb_to_linear(g), srgb_to_linear(b), v.get("a", 1.0)]
    v = list(v)
    return v + [1.0] if len(v) == 3 else v


def find_input(node, name, notes):
    if name in node.inputs:
        return node.inputs[name]
    alt = SOCKET_ALIASES.get(name, name)
    if alt is None:
        notes.append("'%s' on %s has no direct equivalent in Blender %s: skipped" % (name, node.name, bpy.app.version_string))
        return None
    if alt in node.inputs:
        notes.append("'%s' -> '%s' (renamed since the tutorial's Blender)" % (name, alt))
        return node.inputs[alt]
    notes.append("input '%s' not found on %s" % (name, node.bl_idname))
    return None


def build_material(spec):
    """Create (or rebuild) a material from a spec; returns (material, notes)."""
    notes = []
    mat = bpy.data.materials.get(spec["name"]) or bpy.data.materials.new(spec["name"])
    mat.use_nodes = True
    nt = mat.node_tree
    nt.nodes.clear()
    made = {}
    for key, n in spec["nodes"].items():
        node = nt.nodes.new(n["type"])
        node.name = node.label = key
        node.location = n.get("location", (0, 0))
        for attr, val in n.get("props", {}).items():   # e.g. {"blend_type": "MULTIPLY", "data_type": "FLOAT"}
            setattr(node, attr, val)
        for name, val in n.get("inputs", {}).items():
            sock = find_input(node, name, notes)
            if sock is None or not hasattr(sock, "default_value"):
                continue
            dv = sock.default_value
            if isinstance(val, dict) or (isinstance(val, list) and len(val) in (3, 4) and hasattr(dv, "__len__") and len(dv) == 4):
                sock.default_value = colour(val)
            else:
                sock.default_value = val
        if n.get("ramp"):                              # [[pos, [r,g,b,a]], ...] for ColorRamp
            els = node.color_ramp.elements
            while len(els) > 1:
                els.remove(els[-1])
            for i, (pos, col) in enumerate(n["ramp"]):
                e = els[0] if i == 0 else els.new(pos)
                e.position, e.color = pos, colour(col)
        made[key] = node
    for a, out, b, inp in spec.get("links", []):
        so = made[a].outputs.get(out) or made[a].outputs[int(out) if str(out).isdigit() else 0]
        si = find_input(made[b], inp, notes)
        if si is not None:
            nt.links.new(so, si)
    return mat, notes


def dump_material(mat):
    """The inverse of build_material: every node, its changed inputs and the links."""
    spec = {"name": mat.name, "nodes": {}, "links": []}
    for n in mat.node_tree.nodes:
        ins = {}
        for s in n.inputs:
            if s.is_linked or not hasattr(s, "default_value"):
                continue
            v = s.default_value
            ins[s.name] = [round(x, 4) for x in v] if hasattr(v, "__len__") else (round(v, 4) if isinstance(v, float) else v)
        spec["nodes"][n.name] = {"type": n.bl_idname, "location": [round(n.location.x), round(n.location.y)], "inputs": ins}
    for l in mat.node_tree.links:
        spec["links"].append([l.from_node.name, l.from_socket.name, l.to_node.name, l.to_socket.name])
    return spec


def assign(obj, mat):
    if obj.data.materials:
        obj.data.materials[0] = mat
    else:
        obj.data.materials.append(mat)


def preview_scene(mat, shape="sphere", size=512, world=(0.42, 0.42, 0.45), key_energy=400.0, view="Standard"):
    """A neutral look-dev scene: the material on a shape, a soft key light and a grey world, like Material Preview."""
    for o in list(bpy.data.objects):
        bpy.data.objects.remove(o, do_unlink=True)
    if shape == "cube":
        bpy.ops.mesh.primitive_cube_add(size=1.6)
        bpy.ops.object.modifier_add(type="BEVEL")
        bpy.context.object.modifiers[-1].width, bpy.context.object.modifiers[-1].segments = 0.12, 4
    elif shape == "monkey":
        bpy.ops.mesh.primitive_monkey_add(size=1.6)
        bpy.ops.object.shade_smooth()
    else:
        bpy.ops.mesh.primitive_uv_sphere_add(radius=0.9, segments=64, ring_count=32)
        bpy.ops.object.shade_smooth()
    obj = bpy.context.object
    obj.rotation_euler = (0, 0, math.radians(-30))
    assign(obj, mat)
    bpy.ops.object.light_add(type="AREA", location=(2.5, -2.5, 3.0))
    key = bpy.context.object
    key.data.energy, key.data.size = key_energy, 3.0
    key.rotation_euler = (math.radians(50), 0, math.radians(45))
    bpy.ops.object.camera_add(location=(0, -4.2, 1.2), rotation=(math.radians(77), 0, 0))
    sc = bpy.context.scene
    sc.camera = bpy.context.object
    w = sc.world or bpy.data.worlds.new("World")
    sc.world = w
    w.use_nodes = True
    w.node_tree.nodes["Background"].inputs[0].default_value = (*world, 1)
    sc.render.engine = "BLENDER_EEVEE_NEXT" if "BLENDER_EEVEE_NEXT" in [e.identifier for e in bpy.types.RenderSettings.bl_rna.properties["engine"].enum_items] else "BLENDER_EEVEE"
    sc.render.resolution_x = sc.render.resolution_y = size
    try:                                              # match the tutorial: Blender 2.8-3.x defaulted to Filmic, 4.x+ to AgX
        sc.view_settings.view_transform = view
    except TypeError:
        print("[tv_blender] view transform %r not available; using Standard" % view)
        sc.view_settings.view_transform = "Standard"
    return obj


def main():
    argv = sys.argv[sys.argv.index("--") + 1:] if "--" in sys.argv else []

    def arg(k, d=None):
        return argv[argv.index(k) + 1] if k in argv else d
    if "--dump" in argv:
        spec = dump_material(bpy.data.materials[arg("--dump")])
        out = arg("--out")
        json.dump(spec, open(out, "w"), indent=1) if out else print(json.dumps(spec, indent=1))
        return
    spec = json.load(open(arg("--spec")))
    mat, notes = build_material(spec)
    for n in notes:
        print("[tv_blender]", n)
    if arg("--render"):
        preview_scene(mat, arg("--shape", "sphere"), int(arg("--size", 512)), key_energy=float(arg("--light", 400)),
                      view=arg("--view", "Standard"), world=tuple(float(x) for x in arg("--world", "0.42,0.42,0.45").split(",")))
        bpy.context.scene.render.filepath = os.path.abspath(arg("--render"))
        bpy.ops.render.render(write_still=True)
        print("[tv_blender] rendered", bpy.context.scene.render.filepath)
    if arg("--save-dump"):
        json.dump(dump_material(mat), open(arg("--save-dump"), "w"), indent=1)


if __name__ == "__main__":
    main()
