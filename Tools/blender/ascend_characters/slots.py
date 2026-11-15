"""
Colour-slot masks, so the game can recolour a character without new meshes or textures.

Every part is painted per vertex (the 'Col' attribute) from the variant's palette. This module records, for each vertex, which
customization colour slot that paint came from (Data/Characters/customization.json "colourSlots", plus skin) and how much
lighter or darker than the slot's reference colour it was painted. Unity's Ascend/ToonCharacter shader rebuilds the colour as

    colour = lerp(slot[A], slot[B], t) * shade        (slot 0 = keep the painted colour)

with the slot colours set per renderer at runtime, so shading detail (lighter belly, trim bands, the hair's root-to-tip
gradient and its highlight band) survives any recolour.

Stored as two extra UV maps, after a placeholder first map so the indices are fixed:
    UV0 "UVMap"  (0, 0)            placeholder; the characters have no textures
    UV1 "Slots"  (A + 32 * B, t)   slot indices, and the blend from A to B
    UV2 "Shade"  (shade, 0)        luminance of the painted colour over the luminance of its reference
The import post-processor in Unity writes the smoothed outline normal into UV3.

Classification is by nearest reference colour among the slots a part may use, compared on chromaticity first so a darker or
lighter shade of a colour still finds it. encode() returns the reconstruction error per part, which check_characters.py
reports: a large error means a part was painted with a colour that no slot explains.
"""
import json
import os

import numpy as np

from .spec import hex_lin

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "..", ".."))
PACK = 32
KEEP = 0


def slot_order():
    """The slot ids in the order Unity indexes them: 1..N from customization.json, then skin."""
    path = os.path.join(ROOT, "Data", "Characters", "customization.json")
    with open(path, encoding="utf-8") as f:
        ids = [s["id"] for s in json.load(f)["colourSlots"]]
    return ids + ["skin"]


def _lum(c):
    c = np.asarray(c, dtype=np.float64)
    return c[..., 0] * 0.2126 + c[..., 1] * 0.7152 + c[..., 2] * 0.0722


def _chroma(c):
    c = np.asarray(c, dtype=np.float64)
    s = c.sum(axis=-1, keepdims=True)
    return c / np.maximum(s, 1e-6)


def references(sp, part):
    """(slot id, linear colour) pairs a part may have been painted with, from the variant's own palette."""
    lin = lambda h: np.array(hex_lin(h))
    o = sp["outfitColours"]
    hair = sp["hair"]["colour"]
    skin, blush = lin(sp["skin"]["hex"]), lin(sp["skin"]["blush"])
    leather_slot = {"belt": "cloth_accent", "bracers": "gloves"}.get(part, "footwear")
    cloth = [("cloth_primary", lin(o["primary"])), ("cloth_secondary", lin(o["secondary"])), ("cloth_trim", lin(o["trim"])),
             (leather_slot, lin(o["leather"])), ("cloth_trim" if part == "cloak" else "cloth_primary", lin(o["cloak"]))]
    if part in ("body", "ears", "mouth"):
        return [("skin", skin), ("skin", blush)]
    if part == "eyes":
        return [("eye_iris", lin(sp["eyes"]["hex"])), ("hair_base", lin(hair["hex"]) * 0.45)]
    if part == "brows":
        return [("hair_base", lin(hair["hex"]))]
    if part == "hair":
        return [("hair_base", lin(hair["hex"])), ("hair_tip", lin(hair["tip"]))]
    return cloth


def classify(colours, refs, max_chroma=0.08, max_log_lum=1.2):
    """Per vertex: (index into refs, or -1 to keep the painted colour; shade). Chromaticity decides, luminance becomes the
    shade. A vertex no reference explains (chromaticity too far, or more than about 3x lighter or darker) keeps its paint:
    the sclera, the eye highlights, and any detail painted outside the palette."""
    C = np.asarray(colours, dtype=np.float64)
    R = np.array([r for _, r in refs])
    dc = np.linalg.norm(_chroma(C)[:, None, :] - _chroma(R)[None, :, :], axis=-1)
    dl = np.abs(np.log((_lum(C)[:, None] + 1e-3) / (_lum(R)[None, :] + 1e-3)))
    d = dc + 0.15 * dl                                   # a dark colour has unstable chromaticity: luminance breaks near-ties
    k = d.argmin(axis=1)
    idx = np.arange(len(C))
    shade = _lum(C) / np.maximum(_lum(R[k]), 1e-6)
    k = np.where((dc[idx, k] > max_chroma) | (dl[idx, k] > max_log_lum), -1, k)
    return k, np.clip(shade, 0.0, 4.0)


def encode(parts, sp):
    """Writes the UV maps on every part and returns {part: {"slots": {...}, "kept": n, "error": mean abs error}}."""
    order = slot_order()
    report = {}
    for name, obj in parts.items():
        me = obj.data
        a = me.attributes.get("Col")
        n = len(me.vertices)
        if a is None or n == 0:
            continue
        col = np.zeros(n * 4, dtype=np.float32)
        a.data.foreach_get("color", col)
        col = col.reshape(n, 4)[:, :3].astype(np.float64)
        refs = references(sp, name)
        A = np.zeros(n, dtype=np.int32)
        B = np.zeros(n, dtype=np.int32)
        t = np.zeros(n)
        shade = np.ones(n)
        rebuilt = col.copy()
        if name == "hair":
            # one gradient from root colour to tip colour: project the paint onto that line
            root, tip = refs[0][1], refs[1][1]
            dvec = tip - root
            tt = np.clip(((col - root) @ dvec) / max(float(dvec @ dvec), 1e-9), 0.0, 1.0)
            base = root[None, :] * (1 - tt[:, None]) + tip[None, :] * tt[:, None]
            A[:], B[:] = order.index("hair_base") + 1, order.index("hair_tip") + 1
            t = tt
            shade = np.clip(_lum(col) / np.maximum(_lum(base), 1e-6), 0.0, 4.0)
            rebuilt = base * shade[:, None]
        else:
            k, sh = classify(col, refs)
            for i in range(n):
                if k[i] < 0:
                    continue
                s = order.index(refs[k[i]][0]) + 1
                A[i] = B[i] = s
                shade[i] = sh[i]
                rebuilt[i] = refs[k[i]][1] * sh[i]
        _write_uv(me, A, B, t, shade)
        used = {}
        for i in range(n):
            key = order[A[i] - 1] if A[i] else "kept"
            used[key] = used.get(key, 0) + 1
        report[name] = dict(slots=used, kept=int((A == KEEP).sum()), error=round(float(np.abs(rebuilt - col).mean()), 4))
    return report


def _write_uv(me, A, B, t, shade):
    for nm in ("UVMap", "Slots", "Shade"):
        if me.uv_layers.get(nm) is None:
            me.uv_layers.new(name=nm)
    loops = np.zeros(len(me.loops), dtype=np.int64)
    me.loops.foreach_get("vertex_index", loops)
    zero = np.zeros(len(loops) * 2, dtype=np.float32)
    me.uv_layers["UVMap"].data.foreach_set("uv", zero)
    s = np.stack([(A + PACK * B)[loops].astype(np.float32), t[loops].astype(np.float32)], axis=1).ravel()
    me.uv_layers["Slots"].data.foreach_set("uv", s)
    h = np.stack([shade[loops].astype(np.float32), np.zeros(len(loops), dtype=np.float32)], axis=1).ravel()
    me.uv_layers["Shade"].data.foreach_set("uv", h)
