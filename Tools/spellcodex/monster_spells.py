# -*- coding: utf-8 -*-
"""Which monster species cast which codex spells (PROPOSED).

Rules:
  * A species is a caster if its M.ATK beats its ATK, its family is a magical one, its name says so, or it is unique.
    Non-caster species with an element get one affinity spell.
  * Element decides the discipline (Lightning is the Storm branch of Galecraft, Poison the Blight branch of
    Verdance, Blood falls under Umbral, Void is Forbidden). Elementless casters use Aethercraft, spirits Spiritbond.
  * A spell is never ranked above its caster (same letter or lower); EX species may cast anything.
  * Menu: offence, control, support; uniques add a fourth, Tyrants a fifth (their strongest barrage).
  * Telegraph follows the spell's category (blue: parryable, red: unblockable zone, gold: grab, none: chip or support).
"""
import json, os, re, zlib
from rank_class import RANKS

CASTER_FAMILIES = {"Undead", "Elementals & Spirits", "Yokai-Inspired Spirits", "Shadows", "Aberrations", "Vesperites (Moon Raiders)", "Demons"}
NAME_RE = re.compile(r"Shaman|Mage|Witch|Priest|Warlock|Sorcer|Wisp|Wraith|Lich|Oracle|Seer|Banshee|Spirit|Elemental|Cultist|Necro|Chanter|Hexer|Druid")
ELEM_DISC = {"Fire": ("FLM", None), "Water": ("TID", None), "Wind": ("GAL", None), "Earth": ("STN", None), "Ice": ("FRS", None),
             "Nature": ("VRD", None), "Poison": ("VRD", "Blight"), "Lightning": ("GAL", "Storm"), "Light": ("RAD", None),
             "Dark": ("UMB", None), "Blood": ("UMB", None), "Void": ("FBD", None), "None": ("AET", None)}
TELE = {"Strike": "blue", "Barrage": "red", "Binding": "gold", "Hex": "none", "Ward": "none", "Illusion": "none",
        "Mending": "none", "Empowerment": "none", "Pact": "none", "Sensing": "none", "Mobility": "none", "Utility": "none"}
FALLBACK_CATS = ["Strike", "Barrage", "Binding", "Hex", "Ward", "Illusion", "Sensing", "Empowerment", "Mobility", "Mending", "Utility", "Pact"]
OFFENCE, CONTROL, SUPPORT = ["Strike", "Barrage"], ["Binding", "Hex"], ["Ward", "Illusion", "Mending", "Empowerment"]


def rank_idx(rank):
    letter = rank.rstrip("+-")
    return 99 if letter == "EX" else RANKS.index(letter)


def spell_id(rec):
    return "spl_" + rec["id"].lower().replace("-", "_")


def build(recs, species_path):
    species = json.load(open(species_path, encoding="utf-8"))
    by_disc = {}
    for r in recs:
        by_disc.setdefault(r["disc"], []).append(r)
    rows = []
    for sp in species:
        elem = sp["element"]
        caster = (sp["stats"]["matk"] > sp["stats"]["atk"] or sp["family"] in CASTER_FAMILIES or bool(NAME_RE.search(sp["name"]))
                  or sp.get("isUnique"))
        if not caster and elem == "None":
            continue
        disc, sub = ELEM_DISC[elem]
        if sp["family"] == "Yokai-Inspired Spirits":
            disc, sub = "SPR", None
        if elem == "None" and sp["family"] == "Shadows":
            disc, sub = "UMB", None
        midx = rank_idx(sp["rank"])
        if disc == "FBD" and midx < RANKS.index("SS"):
            disc, sub = "UMB", None        # only Calamity-rank and above touch the Weave directly
        n = 3 if caster else 1
        if sp.get("isUnique"):
            n = 5 if sp.get("isTyrant") else 4
        plan = [OFFENCE, CONTROL, SUPPORT, ["Illusion", "Sensing", "Pact", "Empowerment"], ["Barrage"]][:n]
        if not caster:
            plan = [["Binding", "Hex", "Strike", "Ward"]]
        chosen, used = [], set()
        for slot, cats in enumerate(plan):
            pool = [r for r in by_disc[disc] if r["cat"] in cats and RANKS.index(r["rank"]) <= midx and r["id"] not in used
                    and (sub is None or r["sub"] == sub or disc not in ("GAL", "VRD"))]
            if sub and disc in ("GAL", "VRD"):
                pool = [r for r in pool if r["sub"] == sub]
            if not pool:
                wide = [r for r in by_disc[disc] if RANKS.index(r["rank"]) <= midx and r["id"] not in used
                        and (not sub or r["sub"] == sub or disc not in ("GAL", "VRD"))]
                for cat in FALLBACK_CATS:          # nearest useful category first; Utility and Pact only as a last resort
                    pool = [r for r in wide if r["cat"] == cat]
                    if pool:
                        break
            if not pool:
                pool = [r for r in by_disc["AET"] if r["cat"] in cats and RANKS.index(r["rank"]) <= midx and r["id"] not in used]
            if not pool:
                continue
            top = max(RANKS.index(r["rank"]) for r in pool)
            window = [r for r in pool if RANKS.index(r["rank"]) >= top - 1]
            window.sort(key=lambda r: r["id"])
            pick = window[zlib.crc32((sp["id"] + str(slot)).encode()) % len(window)]
            used.add(pick["id"])
            chosen.append(pick)
        if not chosen:
            continue
        rows.append(dict(id="msp_" + sp["id"].replace("mon_", "", 1), speciesId=sp["id"], role="caster" if caster else "affinity",
                         spellIds=[spell_id(r) for r in chosen], telegraphs=[TELE[r["cat"]] for r in chosen]))
    return rows
