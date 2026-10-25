"""
The generator's entry point: build one building for an archetype, a region and a seed, into a Blender object.

    from ascend_buildings import generate
    obj = generate.building("inn", "lirian", seed=3)

The settings are stored on the object (custom properties ab_*), so `regenerate(obj)` rebuilds it after an edit and
`restyle(obj, region)` moves it to another region's style.
"""
import json
import time
import zlib

import bpy

from . import archetypes, blend, parts, styles
from .construct import Ctx

DETAILS = ("high", "medium")


def build_geo(archetype, region="whisperwood", seed=1, detail="high", params=None, family=None, overrides=None):
    style = styles.resolve(region, family, overrides)
    actual = style.remap.get(archetype, archetype)
    fn = archetypes.ARCHETYPES[actual]
    # mix the archetype into the seed, so one seed still gives every building type its own colours
    c = Ctx(style, int(seed) * 7919 + zlib.crc32(archetype.encode()) % 7919, detail)
    fn(c, dict(params or {}))
    return c, style, actual


def building(archetype, region="whisperwood", seed=1, detail="high", params=None, name=None, obj=None,
             collection=None, location=None, family=None, overrides=None):
    t0 = time.time()
    c, style, actual = build_geo(archetype, region, seed, detail, params, family, overrides)
    name = name or "AB_%s_%s_%d" % (style.region, archetype, seed)
    if obj is None:
        obj = blend.ensure_object(name, collection)
    reg = blend.PartRegistry(parts.build, style.palette)
    verts, faces, inst = blend.write(obj, c.g, style.palette, reg)
    if location is not None:
        obj.location = location
    obj["ab_archetype"] = archetype
    obj["ab_built_as"] = actual
    obj["ab_region"] = region or ""
    obj["ab_family"] = style.family
    obj["ab_seed"] = int(seed)
    obj["ab_detail"] = detail
    obj["ab_params"] = json.dumps(params or {})
    obj["ab_stats"] = "%d faces, %d instanced parts, %.1fs" % (faces, inst, time.time() - t0)
    if hasattr(obj, "ascend_building"):
        s = obj.ascend_building
        s.lock = True
        try:
            s.archetype, s.region, s.seed, s.detail = archetype, region, int(seed), detail
            p = params or {}
            s.width = p.get("width", 0.0)
            s.depth = p.get("depth", 0.0)
            s.floors = p.get("floors", 0)
        finally:
            s.lock = False
    return obj


def settings_of(obj):
    return dict(archetype=obj.get("ab_archetype", "house"), region=obj.get("ab_region", "whisperwood") or "whisperwood",
                seed=int(obj.get("ab_seed", 1)), detail=obj.get("ab_detail", "high"),
                params=json.loads(obj.get("ab_params", "{}") or "{}"))


def regenerate(obj, **changes):
    st = settings_of(obj)
    params = dict(st["params"], **changes.pop("params", {}))
    st.update(changes)
    st["params"] = {k: v for k, v in params.items() if v}
    return building(st["archetype"], st["region"], st["seed"], st["detail"], st["params"], obj=obj)


def restyle(obj, region):
    return regenerate(obj, region=region)


def set_realize(objs, on):
    for o in objs:
        blend.set_realize(o, on)
