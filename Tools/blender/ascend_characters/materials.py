"""
Materials for characters. Every part uses ONE kind of material: a Principled shader whose base colour is the 'Col'
point attribute (per-vertex colour), the same pipeline as the creatures. Swapping a skin tone, hair colour or outfit
colour is a repaint of the attribute, never a new texture. Material names are the part categories Unity maps to
its toon shader: CH_skin, CH_hair, CH_eyes, CH_cloth, CH_leather, CH_metal, CH_face.
"""
import bpy

CATEGORIES = {   # name -> (roughness, metallic)
    "CH_skin": (0.75, 0.0), "CH_face": (0.65, 0.0), "CH_eyes": (0.25, 0.0), "CH_hair": (0.55, 0.0),
    "CH_cloth": (0.9, 0.0), "CH_leather": (0.8, 0.0), "CH_metal": (0.4, 0.8),
}


def material(name):
    mat = bpy.data.materials.get(name)
    if mat is not None:
        return mat
    rough, metal = CATEGORIES[name]
    mat = bpy.data.materials.new(name)
    mat.use_nodes = True
    nt = mat.node_tree
    for n in list(nt.nodes):
        nt.nodes.remove(n)
    out = nt.nodes.new("ShaderNodeOutputMaterial")
    bsdf = nt.nodes.new("ShaderNodeBsdfPrincipled")
    nt.links.new(bsdf.outputs[0], out.inputs[0])
    attr = nt.nodes.new("ShaderNodeAttribute")
    attr.attribute_name = "Col"
    nt.links.new(attr.outputs["Color"], bsdf.inputs["Base Color"])
    bsdf.inputs["Roughness"].default_value = rough
    bsdf.inputs["Metallic"].default_value = metal
    mat.diffuse_color = (0.8, 0.8, 0.8, 1.0)
    mat["ch_category"] = name
    return mat


def assign(obj, name):
    obj.data.materials.clear()
    obj.data.materials.append(material(name))
