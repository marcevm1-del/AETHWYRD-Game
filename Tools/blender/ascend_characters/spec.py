"""
Resolves a variant (an id from Data/Characters/human_library.json or a dict) into one flat, fully numeric spec the
generators read. Pure Python (no bpy), so the same code runs in tests and in Blender.

    from ascend_characters import spec
    s = spec.resolve("human_female_base")
    s = spec.resolve({"body": "human_male_base", "seed": 7, "heightM": 1.8, "build": "sturdy", "age": "older",
                      "skin": "tan", "hair": {"style": "crop", "colour": "silver"}, "eyes": "grey",
                      "outfit": {"id": "rank_f_adventurer_m", "colours": "ochre"}, "cloak": False})

Everything random in a character comes from random.Random(spec["seed"] ...), so a spec always gives the same mesh.
"""
import copy
import hashlib
import json
import os
import random

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "..", ".."))
LIB_PATH = os.path.join(ROOT, "Data", "Characters", "human_library.json")
_LIB = None


def library():
    global _LIB
    if _LIB is None:
        with open(LIB_PATH, encoding="utf8") as f:
            _LIB = json.load(f)
    return _LIB


def _by_id(rows, rid, what):
    for r in rows:
        if r["id"] == rid:
            return r
    raise KeyError("unknown %s '%s' (have: %s)" % (what, rid, ", ".join(r["id"] for r in rows)))


def hex_lin(h):
    """sRGB hex to linear RGB floats (the creature pipeline's conversion)."""
    h = h.lstrip("#")
    c = tuple(int(h[i:i + 2], 16) / 255 for i in (0, 2, 4))
    return tuple(x / 12.92 if x <= 0.04045 else ((x + 0.055) / 1.055) ** 2.4 for x in c)


def variant_ids():
    return [v["id"] for v in library()["variants"]]


def resolve(v):
    """v: a variant id or a (partial) variant dict. Returns the resolved spec dict."""
    lib = library()
    if isinstance(v, str):
        raw = copy.deepcopy(_by_id(lib["variants"], v, "variant"))
    else:
        raw = copy.deepcopy(v)
        if "id" in raw and "body" not in raw:
            raw = {**_by_id(lib["variants"], raw["id"], "variant"), **raw}
    body = _by_id(lib["bodies"], raw["body"], "body")
    lo, hi = body["heightBand"]
    height = float(raw.get("heightM", body["heightM"]))
    if not lo - 1e-9 <= height <= hi + 1e-9:
        raise ValueError("%s: height %.2f m is outside the band %.2f-%.2f for %s" % (raw.get("id", "?"), height, lo, hi, body["id"]))
    build = _by_id(lib["builds"], raw.get("build", "average"), "build")
    age = _by_id(lib["ages"], raw.get("age", "adult"), "age")
    skin = _by_id(lib["palettes"]["skin"], raw.get("skin", "light"), "skin tone")
    hair_in = raw.get("hair", {})
    style = hair_in.get("style", "crop" if body["sex"] == "male" else "bob")
    hstyle = _by_id(lib["hairStyles"], style, "hair style")
    if hstyle["body"] not in (body["sex"], "any"):
        raise ValueError("hair style %s is for %s bodies" % (style, hstyle["body"]))
    hair = _by_id(lib["palettes"]["hair"], hair_in.get("colour", "umber"), "hair colour")
    eyes = _by_id(lib["palettes"]["eyes"], raw.get("eyes", "brown"), "eye colour")
    out_in = raw.get("outfit", {"id": "rank_f_adventurer_m" if body["sex"] == "male" else "rank_f_adventurer_f"})
    outfit = _by_id(lib["outfits"], out_in["id"], "outfit")
    if outfit["body"] != body["sex"]:
        raise ValueError("outfit %s is cut for %s bodies" % (outfit["id"], outfit["body"]))
    cols = _by_id(lib["palettes"]["outfit"], out_in.get("colours", "moss"), "outfit colours")
    parts = [p for p in outfit["parts"] if p != "cloak" or raw.get("cloak", True)]
    return {
        "id": raw.get("id") or "%s_s%d" % (body["id"], int(raw.get("seed", 0))),
        "body": body, "sex": body["sex"], "seed": int(raw.get("seed", 0)), "heightM": height,
        "build": build, "age": age, "skin": skin, "hair": {"style": style, "colour": hair}, "eyes": eyes,
        "outfit": outfit, "outfitColours": cols, "outfitParts": parts, "cloak": "cloak" in parts,
        "ears": float(raw.get("earLength", 1.0)),
    }


def rng(spec, salt=""):
    """A deterministic random.Random for one purpose (the salt keeps hair, face and clothes independent)."""
    return random.Random("%s|%d|%s" % (spec["body"]["id"], spec["seed"], salt))


def mesh_hash(arrays):
    """Stable hash of vertex arrays (rounded to 0.01 mm): the same spec must give the same hash."""
    h = hashlib.sha1()
    for name, a in arrays:
        h.update(name.encode())
        h.update(b"%d;" % len(a))
        h.update(repr([[round(float(x), 5) + 0.0 for x in row] for row in a]).encode())
    return h.hexdigest()[:16]
