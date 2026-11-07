"""
Ascend Buildings: a procedural, regional building generator for AETHWYRD.

In Blender: View3D > Sidebar (N) > Ascend. Add a building at the 3D cursor, then change its archetype, region, size,
floors, seed or detail and it rebuilds in place. "Restyle selection" moves every selected building to another region's
style at once. See 13_Production/building_system.md.

Headless:  blender -b --factory-startup -P Tools/blender/build_building_library.py
"""
bl_info = {
    "name": "Ascend Buildings",
    "author": "AETHWYRD",
    "version": (1, 0, 0),
    "blender": (4, 2, 0),
    "location": "View3D > Sidebar > Ascend",
    "description": "Procedural high-detail buildings in every Aethwyrd regional style",
    "category": "Add Mesh",
}

import importlib

if "generate" in locals():
    from . import geo, parts, styles, blend, construct, ornaments, archetypes, generate as _g  # noqa: F401
    for _m in (geo, parts, styles, blend, construct, ornaments, archetypes, _g):
        importlib.reload(_m)

import bpy
from bpy.props import BoolProperty, EnumProperty, FloatProperty, IntProperty, PointerProperty, StringProperty

from . import archetypes, generate, styles


def _arch_items(self, context):
    return [(k, k.replace("_", " ").title(), "") for k in archetypes.ARCHETYPES]


def _region_items(self, context):
    return [(k, v[0], "%s style" % styles.FAMILIES[v[1]]["label"]) for k, v in styles.REGIONS.items()]


_ARCH_ITEMS = [(k, k.replace("_", " ").title(), "") for k in archetypes.ARCHETYPES]
_REGION_ITEMS = [(k, v[0], styles.FAMILIES[v[1]]["label"]) for k, v in styles.REGIONS.items()]
_DETAIL_ITEMS = [("high", "High", "Bevelled parts, every tile and stone"), ("medium", "Medium", "Fewer segments, bigger bricks")]


def _live_update(self, context):
    if self.lock or not self.live:
        return
    obj = self.id_data
    if obj is None or "ab_archetype" not in obj:
        return
    params = {}
    if self.width > 0:
        params["width"] = self.width
    if self.depth > 0:
        params["depth"] = self.depth
    if self.floors > 0:
        params["floors"] = self.floors
    generate.building(self.archetype, self.region, self.seed, self.detail, params, obj=obj)


class ASCEND_PG_building(bpy.types.PropertyGroup):
    lock: BoolProperty(default=False, options={"HIDDEN", "SKIP_SAVE"})
    live: BoolProperty(name="Live", default=True, description="Rebuild as soon as a setting changes")
    archetype: EnumProperty(name="Building", items=_ARCH_ITEMS, default="house", update=_live_update)
    region: EnumProperty(name="Region", items=_REGION_ITEMS, default="whisperwood", update=_live_update)
    seed: IntProperty(name="Seed", default=1, min=0, update=_live_update)
    detail: EnumProperty(name="Detail", items=_DETAIL_ITEMS, default="high", update=_live_update)
    width: FloatProperty(name="Width", default=0.0, min=0.0, max=60.0, unit="LENGTH", description="0 = the archetype's default", update=_live_update)
    depth: FloatProperty(name="Depth", default=0.0, min=0.0, max=60.0, unit="LENGTH", description="0 = the archetype's default", update=_live_update)
    floors: IntProperty(name="Floors", default=0, min=0, max=8, description="0 = the archetype's default", update=_live_update)


class ASCEND_PG_scene(bpy.types.PropertyGroup):
    archetype: EnumProperty(name="Building", items=_ARCH_ITEMS, default="house")
    region: EnumProperty(name="Region", items=_REGION_ITEMS, default="whisperwood")
    detail: EnumProperty(name="Detail", items=_DETAIL_ITEMS, default="high")
    seed: IntProperty(name="Seed", default=1, min=0)


class ASCEND_OT_add_building(bpy.types.Operator):
    bl_idname = "ascend.add_building"
    bl_label = "Add Building"
    bl_description = "Generate a building at the 3D cursor"
    bl_options = {"REGISTER", "UNDO"}

    def execute(self, context):
        sc = context.scene.ascend_new
        obj = generate.building(sc.archetype, sc.region, sc.seed, sc.detail, {}, collection=context.collection,
                                name="AB_%s_%s" % (sc.region, sc.archetype), location=context.scene.cursor.location.copy())
        for o in context.selected_objects:
            o.select_set(False)
        obj.select_set(True)
        context.view_layer.objects.active = obj
        sc.seed += 1
        self.report({"INFO"}, obj.get("ab_stats", ""))
        return {"FINISHED"}


class ASCEND_OT_regenerate(bpy.types.Operator):
    bl_idname = "ascend.regenerate"
    bl_label = "Rebuild"
    bl_description = "Rebuild the selected buildings from their settings"
    bl_options = {"REGISTER", "UNDO"}

    new_seed: BoolProperty(name="New seed", default=False)

    def execute(self, context):
        n = 0
        for o in context.selected_objects:
            if "ab_archetype" in o:
                changes = {"seed": int(o.get("ab_seed", 1)) + 1} if self.new_seed else {}
                generate.regenerate(o, **changes)
                n += 1
        self.report({"INFO"}, "Rebuilt %d building(s)" % n)
        return {"FINISHED"}


class ASCEND_OT_restyle(bpy.types.Operator):
    bl_idname = "ascend.restyle"
    bl_label = "Restyle Selection"
    bl_description = "Rebuild every selected building in another region's style"
    bl_options = {"REGISTER", "UNDO"}

    region: EnumProperty(name="Region", items=_REGION_ITEMS)

    def invoke(self, context, event):
        return context.window_manager.invoke_props_dialog(self)

    def execute(self, context):
        n = 0
        for o in context.selected_objects:
            if "ab_archetype" in o:
                generate.restyle(o, self.region)
                n += 1
        self.report({"INFO"}, "Restyled %d building(s) as %s" % (n, styles.REGIONS[self.region][0]))
        return {"FINISHED"}


class ASCEND_OT_realize(bpy.types.Operator):
    bl_idname = "ascend.realize"
    bl_label = "Realize Parts"
    bl_description = "Turn the instanced tiles and stones into real geometry (for export), or back into instances"
    bl_options = {"REGISTER", "UNDO"}

    on: BoolProperty(name="Realize", default=True)

    def execute(self, context):
        generate.set_realize([o for o in context.selected_objects if "ab_archetype" in o], self.on)
        return {"FINISHED"}


class ASCEND_PT_panel(bpy.types.Panel):
    bl_label = "Ascend Buildings"
    bl_space_type = "VIEW_3D"
    bl_region_type = "UI"
    bl_category = "Ascend"

    def draw(self, context):
        layout = self.layout
        sc = context.scene.ascend_new
        box = layout.box()
        box.label(text="New building", icon="HOME")
        box.prop(sc, "archetype")
        box.prop(sc, "region")
        row = box.row()
        row.prop(sc, "detail", text="")
        row.prop(sc, "seed")
        box.operator("ascend.add_building", icon="ADD")
        obj = context.active_object
        if obj is not None and "ab_archetype" in obj:
            s = obj.ascend_building
            box = layout.box()
            box.label(text=obj.name, icon="MESH_DATA")
            box.prop(s, "live")
            box.prop(s, "archetype")
            box.prop(s, "region")
            box.label(text=styles.FAMILIES[obj.get("ab_family", "storybook")]["label"])
            col = box.column(align=True)
            col.prop(s, "width")
            col.prop(s, "depth")
            col.prop(s, "floors")
            row = box.row()
            row.prop(s, "detail", text="")
            row.prop(s, "seed")
            row = box.row(align=True)
            row.operator("ascend.regenerate", icon="FILE_REFRESH").new_seed = False
            row.operator("ascend.regenerate", text="Reroll", icon="MOD_NOISE").new_seed = True
            box.label(text=obj.get("ab_stats", ""))
        layout.operator("ascend.restyle", icon="WORLD")
        row = layout.row(align=True)
        row.operator("ascend.realize", text="Realize").on = True
        row.operator("ascend.realize", text="Instance").on = False


CLASSES = (ASCEND_PG_building, ASCEND_PG_scene, ASCEND_OT_add_building, ASCEND_OT_regenerate, ASCEND_OT_restyle,
           ASCEND_OT_realize, ASCEND_PT_panel)


def register():
    for cls in CLASSES:
        try:
            bpy.utils.register_class(cls)
        except ValueError:
            bpy.utils.unregister_class(cls)
            bpy.utils.register_class(cls)
    bpy.types.Object.ascend_building = PointerProperty(type=ASCEND_PG_building)
    bpy.types.Scene.ascend_new = PointerProperty(type=ASCEND_PG_scene)


def unregister():
    del bpy.types.Scene.ascend_new
    del bpy.types.Object.ascend_building
    for cls in reversed(CLASSES):
        bpy.utils.unregister_class(cls)
