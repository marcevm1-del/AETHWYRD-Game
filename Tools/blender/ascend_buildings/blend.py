"""
Blender plumbing for the building generator: palette materials, the shared parts collection, the AB_Instancer
geometry-nodes group and writing a generated building into an object.

Materials are named AB_<palette>_<key>. Every building in a region shares them, so tinting a material recolours that
key across the whole region. Parts (a roof tile, a wall stone, a plank) are objects named p<seq>_<key> in the AB_Parts
collection. Buildings instance them through carrier vertices, and they are numbered so that adding new parts never
renumbers old ones.
"""
import bpy

from . import geo

PARTS_COLLECTION = "AB_Parts"
INSTANCER = "AB_Instancer"
GLOW_KEYS = ("lamp", "magic", "rune", "ember", "crystal", "glow")


# ----------------------------------------------------------------------------------------------------------------
# Materials


def material(palette_id, key, colour):
    name = "AB_%s_%s" % (palette_id, key)
    mat = bpy.data.materials.get(name)
    if mat is None:
        mat = bpy.data.materials.new(name)
        mat.use_nodes = True
    rgb = tuple(colour[:3])
    nodes = mat.node_tree.nodes
    bsdf = next((n for n in nodes if n.type == "BSDF_PRINCIPLED"), None)
    if bsdf is None:
        bsdf = nodes.new("ShaderNodeBsdfPrincipled")
        out = next(n for n in nodes if n.type == "OUTPUT_MATERIAL")
        mat.node_tree.links.new(bsdf.outputs[0], out.inputs[0])
    bsdf.inputs["Base Color"].default_value = (*rgb, 1.0)
    glossy = key.startswith(("glass", "metal", "gold", "copper", "brass", "iron", "glaze"))
    bsdf.inputs["Roughness"].default_value = 0.35 if glossy else 0.8
    if "Metallic" in bsdf.inputs:
        bsdf.inputs["Metallic"].default_value = 0.7 if key.startswith(("gold", "copper", "brass")) else 0.0
    glow = any(k in key for k in GLOW_KEYS)
    for nm in ("Emission Color", "Emission"):
        if nm in bsdf.inputs:
            bsdf.inputs[nm].default_value = (*rgb, 1.0) if glow else (0, 0, 0, 1)
            break
    if "Emission Strength" in bsdf.inputs:
        bsdf.inputs["Emission Strength"].default_value = 3.0 if glow else 0.0
    mat.diffuse_color = (*rgb, 1.0)
    mat["ab_key"] = key
    mat["ab_palette"] = palette_id
    return mat


# ----------------------------------------------------------------------------------------------------------------
# Parts


def parts_collection():
    col = bpy.data.collections.get(PARTS_COLLECTION)
    if col is None:
        col = bpy.data.collections.new(PARTS_COLLECTION)
    if col.name not in bpy.context.scene.collection.children:
        try:
            bpy.context.scene.collection.children.link(col)
        except RuntimeError:
            pass
    # Keep the parts out of sight; geometry nodes still reads them.
    for vl in bpy.context.scene.view_layers:
        lc = _find_layer_collection(vl.layer_collection, col.name)
        if lc is not None:
            lc.exclude = True
    return col


def _find_layer_collection(lc, name):
    if lc.collection.name == name:
        return lc
    for c in lc.children:
        r = _find_layer_collection(c, name)
        if r is not None:
            return r
    return None


class PartRegistry:
    """Looks parts up by key, creating any that are missing, and reports their index in name order."""

    def __init__(self, builder, palette):
        self.col = parts_collection()
        self.builder = builder        # callable(key) -> Geo
        self.palette = palette        # Palette (styles.py) used for part materials
        self.by_key = {o.get("ab_part"): o for o in self.col.objects if o.get("ab_part")}
        self._order = None

    def obj(self, key):
        full = "%s/%s" % (self.palette.id, key)  # the same shape in another region's palette is another part
        o = self.by_key.get(full)
        if o is not None:
            return o
        seq = 1 + max([int(x.name[1:5]) for x in self.col.objects if x.name[:1] == "p" and x.name[1:5].isdigit()] or [-1])
        g = self.builder(key)
        name = ("p%04d_%s_%s" % (seq, self.palette.id, key.replace("|", "_")))[:60]
        me = bpy.data.meshes.new(name)
        o = bpy.data.objects.new(me.name, me)
        o["ab_part"] = full
        self.col.objects.link(o)
        write(o, g, self.palette, None)
        self.by_key[full] = o
        self._order = None
        return o

    def index(self, key):
        o = self.obj(key)
        if self._order is None:
            self._order = {x.name: i for i, x in enumerate(sorted(self.col.objects, key=lambda x: x.name))}
        return self._order[o.name]


# ----------------------------------------------------------------------------------------------------------------
# The instancer


def instancer_group():
    ng = bpy.data.node_groups.get(INSTANCER)
    if ng is not None:
        return ng
    ng = bpy.data.node_groups.new(INSTANCER, "GeometryNodeTree")
    ng.interface.new_socket("Geometry", in_out="INPUT", socket_type="NodeSocketGeometry")
    r = ng.interface.new_socket("Realize", in_out="INPUT", socket_type="NodeSocketBool")
    r.default_value = False
    ng.interface.new_socket("Geometry", in_out="OUTPUT", socket_type="NodeSocketGeometry")
    N, L = ng.nodes, ng.links
    gi, go = N.new("NodeGroupInput"), N.new("NodeGroupOutput")
    gi.location, go.location = (-900, 0), (700, 0)

    def named(name, dtype, y):
        n = N.new("GeometryNodeInputNamedAttribute")
        n.data_type = dtype
        n.inputs["Name"].default_value = name
        n.location = (-700, y)
        return n

    is_inst = named("is_inst", "BOOLEAN", -150)
    idx = named("inst_index", "INT", -300)
    rot = named("inst_rot", "FLOAT_VECTOR", -450)
    sca = named("inst_scale", "FLOAT_VECTOR", -600)
    sep = N.new("GeometryNodeSeparateGeometry")
    sep.domain = "POINT"
    sep.location = (-450, 0)
    ci = N.new("GeometryNodeCollectionInfo")
    ci.inputs["Separate Children"].default_value = True
    ci.inputs["Reset Children"].default_value = True
    ci.inputs["Collection"].default_value = parts_collection()  # every building shares the one parts collection
    ci.location = (-450, -250)
    iop = N.new("GeometryNodeInstanceOnPoints")
    iop.inputs["Pick Instance"].default_value = True
    iop.location = (-150, -100)
    real = N.new("GeometryNodeRealizeInstances")
    real.location = (100, -200)
    sw = N.new("GeometryNodeSwitch")
    sw.input_type = "GEOMETRY"
    sw.location = (300, -100)
    join = N.new("GeometryNodeJoinGeometry")
    join.location = (500, 0)
    L.new(gi.outputs["Geometry"], sep.inputs["Geometry"])
    L.new(is_inst.outputs["Attribute"], sep.inputs["Selection"])
    L.new(sep.outputs["Selection"], iop.inputs["Points"])
    L.new(ci.outputs[0], iop.inputs["Instance"])
    L.new(idx.outputs["Attribute"], iop.inputs["Instance Index"])
    L.new(rot.outputs["Attribute"], iop.inputs["Rotation"])
    L.new(sca.outputs["Attribute"], iop.inputs["Scale"])
    L.new(iop.outputs[0], real.inputs[0])
    L.new(gi.outputs["Realize"], sw.inputs["Switch"])
    L.new(iop.outputs[0], sw.inputs["False"])
    L.new(real.outputs[0], sw.inputs["True"])
    L.new(sep.outputs["Inverted"], join.inputs[0])
    L.new(sw.outputs[0], join.inputs[0])
    L.new(join.outputs[0], go.inputs[0])
    return ng


# ----------------------------------------------------------------------------------------------------------------
# Writing objects


def write(obj, g, palette, registry):
    """Writes Geo g into obj's mesh, with palette materials and (when there are instances) the instancer."""
    me = obj.data
    keys = []
    for k in g.mats:
        if k not in keys:
            keys.append(k)
    me.materials.clear()
    for k in keys:
        me.materials.append(material(palette.id, k, palette.colour(k)))
    slot = {k: i for i, k in enumerate(keys)}
    part_index = registry.index if registry is not None else (lambda k: 0)
    if registry is not None:
        for part in {i[0] for i in g.instances}:  # create every part first, so the indices are final
            registry.obj(part)
    counts = geo.write_mesh(g, me, slot.__getitem__, part_index)
    md = obj.modifiers.get("AB_Instancer")
    if g.instances and registry is not None:
        if md is None:
            md = obj.modifiers.new("AB_Instancer", "NODES")
        md.node_group = instancer_group()
    elif md is not None:
        obj.modifiers.remove(md)
    return counts


def set_realize(obj, on):
    md = obj.modifiers.get("AB_Instancer")
    if md is None:
        return
    ident = next(i.identifier for i in md.node_group.interface.items_tree if getattr(i, "name", "") == "Realize")
    props = getattr(md, "properties", None)
    if props is not None and hasattr(props, "inputs"):  # Blender 5.x: md.properties.inputs.<socket>.value
        getattr(props.inputs, ident).value = bool(on)
    else:                                                # Blender 4.x: id-properties on the modifier
        md[ident] = bool(on)
    obj.update_tag()


def ensure_object(name, collection=None):
    obj = bpy.data.objects.get(name)
    if obj is None or obj.type != "MESH":
        me = bpy.data.meshes.new(name)
        obj = bpy.data.objects.new(name, me)
        (collection or bpy.context.scene.collection).objects.link(obj)
    return obj
