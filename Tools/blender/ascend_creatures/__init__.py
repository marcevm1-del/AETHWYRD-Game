"""
Ascend Creatures: procedural, high-poly creatures for every species in Data/Monsters/species.json.

In Blender: View3D > Sidebar (N) > Ascend > Creatures. Add a species at the 3D cursor, then change its seed, size,
element, pattern, detail or colours and it rebuilds in place. Needs the ascend_buildings package beside it (shared
mesh helpers). See 13_Production/creature_system.md.
"""
bl_info = {
    "name": "Ascend Creatures",
    "author": "AETHWYRD",
    "version": (1, 0, 0),
    "blender": (4, 2, 0),
    "location": "View3D > Sidebar > Ascend",
    "description": "Procedural high-poly creatures for every Aethwyrd species",
    "category": "Add Mesh",
}

import os
import sys

_here = os.path.dirname(os.path.abspath(__file__))
if os.path.dirname(_here) not in sys.path:  # ascend_buildings lives beside this package
    sys.path.append(os.path.dirname(_here))

import bpy
from bpy.props import BoolProperty, EnumProperty, FloatProperty, FloatVectorProperty, IntProperty, PointerProperty, StringProperty

from . import generate
from .looks import ELEMENT_GLOW, STYLE

_ITEMS = None


def _species_items(self, context):
    global _ITEMS
    if _ITEMS is None:
        sp = sorted(generate.species_list().values(), key=lambda s: (s["family"], s["name"]))
        _ITEMS = [(s["id"], s["name"], "%s · %s · %.2f m" % (s["family"], s["rank"] if "rank" in s else "", s["sizeMeters"])) for s in sp]
    return _ITEMS


_ELEMENTS = [("", "As described", "")] + [(e, e, "") for e in ELEMENT_GLOW]
_PATTERNS = [("", "As described", ""), ("none", "Plain", ""), ("spots", "Spots", ""), ("stripes", "Stripes", ""),
             ("cells", "Scales", ""), ("patches", "Patches", ""), ("rings", "Rings", "")]
_DETAIL = [("high", "High", "About 0.75 cm grid at 1 m"), ("medium", "Medium", ""), ("low", "Low", "")]


def _to_hex(c):
    lin = [max(0.0, min(1.0, x)) for x in c]
    srgb = [12.92 * x if x <= 0.0031308 else 1.055 * x ** (1 / 2.4) - 0.055 for x in lin]
    return "#%02x%02x%02x" % tuple(int(round(x * 255)) for x in srgb)


def _rebuild(self, context):
    obj = self.id_data
    if self.lock or not self.live or obj is None or "ac_species" not in obj:
        return
    ov = {}
    if self.size > 0:
        ov["size"] = self.size
    if self.element:
        ov["element"] = self.element
    if self.pattern:
        ov["pattern"] = self.pattern
    if self.use_colours:
        ov["palette"] = [_to_hex(self.main), _to_hex(self.dark), _to_hex(self.accent)]
    generate.creature(self.species, self.seed, self.detail, ov or None, obj=obj)


class ASCEND_PG_creature(bpy.types.PropertyGroup):
    lock: BoolProperty(default=False, options={"HIDDEN", "SKIP_SAVE"})
    live: BoolProperty(name="Live", default=True)
    species: EnumProperty(name="Species", items=_species_items, update=_rebuild)
    seed: IntProperty(name="Seed", default=0, min=0, update=_rebuild)
    detail: EnumProperty(name="Detail", items=_DETAIL, default="high", update=_rebuild)
    size: FloatProperty(name="Size (m)", default=0.0, min=0.0, description="0 = the bestiary size", update=_rebuild)
    element: EnumProperty(name="Element", items=_ELEMENTS, update=_rebuild)
    pattern: EnumProperty(name="Pattern", items=_PATTERNS, update=_rebuild)
    use_colours: BoolProperty(name="Own colours", default=False, update=_rebuild)
    main: FloatVectorProperty(name="Main", subtype="COLOR", default=(0.4, 0.4, 0.45), min=0, max=1, update=_rebuild)
    dark: FloatVectorProperty(name="Dark", subtype="COLOR", default=(0.15, 0.15, 0.18), min=0, max=1, update=_rebuild)
    accent: FloatVectorProperty(name="Accent", subtype="COLOR", default=(0.8, 0.75, 0.6), min=0, max=1, update=_rebuild)


class ASCEND_PG_creature_new(bpy.types.PropertyGroup):
    species: EnumProperty(name="Species", items=_species_items)
    detail: EnumProperty(name="Detail", items=_DETAIL, default="high")


class ASCEND_OT_add_creature(bpy.types.Operator):
    bl_idname = "ascend.add_creature"
    bl_label = "Add Creature"
    bl_options = {"REGISTER", "UNDO"}

    def execute(self, context):
        sc = context.scene.ascend_creature_new
        obj = generate.creature(sc.species, 0, sc.detail, None, collection=context.collection, location=context.scene.cursor.location.copy())
        s = obj.ascend_creature
        s.lock = True
        try:
            s.species, s.detail = sc.species, sc.detail
        finally:
            s.lock = False
        for o in context.selected_objects:
            o.select_set(False)
        obj.select_set(True)
        context.view_layer.objects.active = obj
        self.report({"INFO"}, obj.get("ac_stats", ""))
        return {"FINISHED"}


class ASCEND_OT_reroll_creature(bpy.types.Operator):
    bl_idname = "ascend.reroll_creature"
    bl_label = "Reroll"
    bl_description = "Rebuild the selected creatures with the next seed"
    bl_options = {"REGISTER", "UNDO"}

    def execute(self, context):
        for o in context.selected_objects:
            if "ac_species" in o:
                o.ascend_creature.seed += 1
        return {"FINISHED"}


class ASCEND_PT_creatures(bpy.types.Panel):
    bl_label = "Ascend Creatures"
    bl_space_type = "VIEW_3D"
    bl_region_type = "UI"
    bl_category = "Ascend"

    def draw(self, context):
        lay = self.layout
        sc = context.scene.ascend_creature_new
        box = lay.box()
        box.prop(sc, "species")
        box.prop(sc, "detail")
        box.operator("ascend.add_creature", icon="ADD")
        o = context.active_object
        if o is not None and "ac_species" in o:
            s = o.ascend_creature
            box = lay.box()
            box.label(text="%s (%s)" % (o.get("ac_name", ""), o.get("ac_family", "")))
            box.prop(s, "live")
            box.prop(s, "species")
            row = box.row()
            row.prop(s, "seed")
            row.operator("ascend.reroll_creature", text="", icon="MOD_NOISE")
            box.prop(s, "size")
            box.prop(s, "element")
            box.prop(s, "pattern")
            box.prop(s, "detail")
            box.prop(s, "use_colours")
            if s.use_colours:
                row = box.row()
                row.prop(s, "main", text="")
                row.prop(s, "dark", text="")
                row.prop(s, "accent", text="")
            box.label(text=o.get("ac_stats", ""))


CLASSES = (ASCEND_PG_creature, ASCEND_PG_creature_new, ASCEND_OT_add_creature, ASCEND_OT_reroll_creature, ASCEND_PT_creatures)


def register():
    for cls in CLASSES:
        try:
            bpy.utils.register_class(cls)
        except ValueError:
            bpy.utils.unregister_class(cls)
            bpy.utils.register_class(cls)
    bpy.types.Object.ascend_creature = PointerProperty(type=ASCEND_PG_creature)
    bpy.types.Scene.ascend_creature_new = PointerProperty(type=ASCEND_PG_creature_new)


def unregister():
    del bpy.types.Scene.ascend_creature_new
    del bpy.types.Object.ascend_creature
    for cls in reversed(CLASSES):
        bpy.utils.unregister_class(cls)
