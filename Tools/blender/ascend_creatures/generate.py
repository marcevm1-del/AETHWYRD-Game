"""
Builds one creature from its species entry:

    from ascend_creatures import generate
    obj = generate.creature("mon_goblin")                       # as the bestiary describes it
    obj = generate.creature("mon_goblin", seed=2, overrides={"element": "Fire", "palette": ["#c0392b", "#5b1f1a", "#ffb347"]})

The body is a metaball sculpture (plans.py + the soft features), relaxed and painted per vertex; the hard parts
(features.py) are bevelled meshes. Settings live on the object (ac_* properties) so it can be rebuilt with changes.
"""
import json
import os
import random
import time
import zlib

import bpy
import numpy as np
from mathutils import Matrix

from ascend_buildings import blend as ABblend
from ascend_buildings.geo import Geo

from . import body as B
from . import features, plans
from . import profile as PR
from .looks import Look

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "..", ".."))
_SPECIES = None


def species_list():
    global _SPECIES
    if _SPECIES is None:
        with open(os.path.join(ROOT, "Data", "Monsters", "species.json"), encoding="utf8") as f:
            _SPECIES = {s["id"]: s for s in json.load(f)}
    return _SPECIES


class Palette:
    def __init__(self, pid, colours):
        self.id = pid
        self.colours = colours

    def colour(self, key):
        base, _, tone = key.partition("~")
        c = self.colours.get(base, (1, 0, 1))
        f = {"1": 0.75, "2": 1.2}.get(tone, 1.0)
        return tuple(min(1, x * f) for x in c)


DETAIL_RES = {"high": 0.0075, "medium": 0.012, "low": 0.02}


def build(species_id, seed=0, detail="high", overrides=None):
    sp = species_list()[species_id]
    o = dict(overrides or {})
    o.setdefault("seed", seed)
    look = Look(sp, o)
    rng = random.Random(look.seed)
    body = B.Body(rng)
    text = PR.text_of(sp, species_list())
    vbulk = PR.variant(look, sp)
    if look.base in ("quad_large_base", "quad_small_base", "taur_base"):
        P = PR.quad_profile(text, small=look.base == "quad_small_base")
    else:
        P = PR.biped_profile(text)
    P["vbulk"] = vbulk
    extra = list(P.get("add", ()))
    if P.get("beak"):
        extra.append("beak_hooked")
    if P.get("mane"):
        extra.append("mane")
    if P.get("wings"):
        extra.append("wing_feathers" if P.get("beak") else "wing_membrane")
    for a in extra:
        if a not in look.parts:
            look.parts.append(a)
    body.P = P
    plans.PLANS.get(look.base, plans.PLANS["medium_biped_base"])(body, look)
    if look.eye_count != 2 and body.kind not in ("spider", "swarm"):
        body.eye_count = look.eye_count
    features.organic(body, look)
    # resolve thin limbs: the finest element sets the grid, within a budget
    min_r = min(e[2] * B.SURFACE * (1.0 if e[0] == "CUBE" else min(e[3])) for e in body.els if not e[5])
    _floor = {"high": 0.004, "medium": 0.010, "low": 0.020}.get(detail, 0.004)
    res = max(_floor, min(DETAIL_RES.get(detail, 0.0075), min_r * 0.75))
    verts, faces = B.tessellate(body, res)
    edges = B.edges_of(faces, len(verts))
    verts = B.relax(verts, edges, 2 if detail != "low" else 1)
    normals = B.normals_of(verts, faces)
    if look.bump > 0 and detail != "low":
        verts = B.displace(verts, normals, look.bump, 9.0, look.seed % 100)
        normals = B.normals_of(verts, faces)
    curv = B.curvature(verts, edges, normals)
    colours, glow = B.paint(verts, normals, curv, look, body)
    ctx = features.Ctx(body, look, verts, normals)
    hard = features.hard(ctx)
    return dict(species=sp, look=look, body=body, verts=verts, faces=faces, colours=colours, glow=glow, hard=hard, res=res)


def creature(species_id, seed=0, detail="high", overrides=None, name=None, obj=None, collection=None, location=None):
    t0 = time.time()
    r = build(species_id, seed, detail, overrides)
    sp, look = r["species"], r["look"]
    verts = r["verts"]
    ext = verts.max(0) - verts.min(0)
    hard_ext = ext
    size = float((overrides or {}).get("size") or sp.get("sizeMeters") or 1.0)
    scale = size / max(1e-6, float(max(ext[0], ext[1], ext[2])))
    if r["body"].kind == "swarm":  # a swarm's size is one member's; the cloud is about twelve of them across
        scale = size / 0.12
    g = Geo()
    g.add(verts * scale, r["faces"].tolist(), "skin")
    g.extend(r["hard"], Matrix.Scale(scale, 4))
    name = name or "%s%s" % (species_id, "" if not seed else "_s%d" % seed)
    if obj is None:
        obj = ABblend.ensure_object(name, collection)
    pal = Palette("cr_" + species_id + ("" if not overrides else "_v%d" % (zlib.crc32(json.dumps(overrides, sort_keys=True).encode()) % 10000)), look.palette())
    pal.colours["skin"] = look.main
    nv, nf, _ = ABblend.write(obj, g, pal, None)
    # the skin uses the painted vertex colours
    me = obj.data
    for i, m in enumerate(me.materials):
        if m and m.get("ab_key") == "skin":
            me.materials[i] = B.skin_material(look)
    n_body = len(verts)
    col = np.ones((len(me.vertices), 4), dtype=np.float32)
    col[:n_body, :3] = r["colours"]
    glow = np.zeros(len(me.vertices), dtype=np.float32)
    glow[:n_body] = r["glow"]
    for nm in ("Col", "glow"):
        a = me.attributes.get(nm)
        if a:
            me.attributes.remove(a)
    me.attributes.new("Col", "FLOAT_COLOR", "POINT").data.foreach_set("color", col.ravel())
    me.attributes.new("glow", "FLOAT", "POINT").data.foreach_set("value", glow)
    if location is not None:
        obj.location = location
    obj["ac_species"] = species_id
    obj["ac_name"] = sp["name"]
    obj["ac_family"] = sp["family"]
    obj["ac_seed"] = int(seed)
    obj["ac_detail"] = detail
    obj["ac_overrides"] = json.dumps(overrides or {})
    obj["ac_stats"] = "%d tris-ish (%d faces), %.2f m, %.1fs" % (sum(len(p.vertices) - 2 for p in me.polygons), nf, size, time.time() - t0)
    return obj


def regenerate(obj, **changes):
    sid = changes.pop("species", obj.get("ac_species"))
    seed = changes.pop("seed", obj.get("ac_seed", 0))
    detail = changes.pop("detail", obj.get("ac_detail", "high"))
    ov = json.loads(obj.get("ac_overrides", "{}") or "{}")
    ov.update(changes.pop("overrides", {}))
    return creature(sid, seed, detail, ov or None, obj=obj)
