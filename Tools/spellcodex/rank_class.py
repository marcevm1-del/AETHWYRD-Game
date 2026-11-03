# -*- coding: utf-8 -*-
"""Spell rank, tier, level, chant, element and class access.

Rules (PROPOSED, built on Canon):
  * Rank ladder and level bands: Canon section 2 / 03_Rank_System/ranks.md.
  * Spell tier and chant time by rank band: 05_Skills_Magic/skills_and_magic.md section 3.
  * Forbidden magic (Space, Time, Void) is SS and above (skills_and_magic.md).
  * Divine tier is SSS, reached only by the rare top rites of the Divine discipline.
  * Rank inside a discipline is the spell's complexity percentile (see score()).
"""
import zlib

RANKS = ["F", "E", "D", "C", "B", "A", "S", "SS", "SSS"]
BAND_START = {"F": 1, "E": 16, "D": 36, "C": 61, "B": 91, "A": 126, "S": 166, "SS": 211, "SSS": 261}
TIER = {"F": "Basic", "E": "Basic", "D": "Intermediate", "C": "Intermediate", "B": "Advanced", "A": "Advanced",
        "S": "Grand", "SS": "Forbidden", "SSS": "Divine"}
CHANT = {"Basic": 0.5, "Intermediate": 1.5, "Advanced": 3.0, "Grand": 5.0, "Forbidden": 8.0, "Divine": None}
# class tier needed to learn (proposal; follows the promotion table: D->C needs Advanced, A->S Expert, SS->SSS Master)
MIN_CLASS_TIER = {"F": "base", "E": "base", "D": "base", "C": "advanced", "B": "advanced", "A": "advanced",
                  "S": "expert", "SS": "expert", "SSS": "master"}

CAT_BASE = {"Utility": 0, "Mending": 1, "Strike": 1, "Mobility": 1, "Sensing": 1, "Empowerment": 2, "Hex": 2,
            "Binding": 2, "Ward": 2, "Illusion": 2, "Barrage": 3, "Pact": 2}
FORM_ADJ = {"Standard": 0, "Signature": 0,
            "Needlepoint": 0, "Grounded Form": 0, "Sweeping Arc": 1, "Twin Cast": 1, "Rising Form": 1, "Spiral Form": 2, "Echo Form": 2,
            "Gentle Call": 0, "Urgent Call": 1, "Guiding Path": 1, "Warning Sign": 1, "Shared Guard": 2, "Resonant Echo": 2, "Parting Form": 2,
            "Quiet Prayer": 0, "Vigil Form": 1, "Pilgrim Form": 1, "Public Prayer": 2, "Sanctuary Form": 2, "Oathbound Form": 3, "Last-Rite Form": 3,
            "Space: Needle Fold": 0, "Void: Thin Edge": 0, "Time: Single Echo": 1, "Space: Wide Fold": 2, "Time: Delayed Echo": 2,
            "Void: Quiet Field": 2, "Fracture Form": 3}
BIG = {"Cascade", "Tempest", "Leviathan", "Covenant", "Procession", "Cloister", "Bastion", "Aegis", "Chorus", "Tide", "Whorl", "Comet",
       "Wildfire", "Dragon", "Furnace", "Breaker", "Cyclone", "Obsidian", "Sanctuary", "Choir", "Phoenix", "Prism", "Beacon", "Quarry",
       "Blue", "Mountain", "Storm", "Solar", "Magma", "Hellfire", "Judgement", "Dawn", "Hearth", "Oathfire"}
SMALL = {"Dart", "Needle", "Spark", "Whisper", "Glimmer", "Step", "Thread", "Lantern", "Sign", "Mark", "Chime", "Glyph", "Cairn", "Hush",
         "Salve", "Dance", "Stride", "Gaze", "Grace", "Blessing", "Lullaby", "Mossbridge", "Foamstep", "Cloudstep"}
ADJ_UP = {"Storm", "Mountain", "Iron", "Crown", "Luminous", "Prismatic", "Umbral", "Vigil", "Warden", "Riven", "Far", "Beacon"}
ADJ_DOWN = {"Gentle", "Whisper", "Glimmer", "Quiet", "Near", "Hidden", "Measured"}


def score(rec):
    s = CAT_BASE[rec["cat"]] * 2 + FORM_ADJ.get(rec["form"], 0)
    words = set(rec["name"].replace("—", " ").replace("'s", "").split())
    if words & BIG:
        s += 2
    if words & SMALL:
        s -= 2
    if rec["src"] == 3:
        a = rec["name"].split()[0]
        s += 1 if a in ADJ_UP else (-1 if a in ADJ_DOWN else 0)
    return s


def rank_from_score(sc):
    for rk, top in (("F", 0), ("E", 2), ("D", 4), ("C", 5), ("B", 6), ("A", 7)):
        if sc <= top:
            return rk
    return "S"


def assign_ranks(recs):
    """Absolute complexity thresholds (score <= 0 F, 1-2 E, 3-4 D, 5 C, 6 B, 7 A, 8+ S), so the same kind of
    spell gets the same rank in every discipline. Forbidden is all SS; the five most complex Divine rites are SSS."""
    for r in recs:
        r["rank"] = "SS" if r["disc"] == "FBD" else rank_from_score(score(r))
    div = [r for r in recs if r["disc"] == "DIV" and r["form"] in ("Oathbound Form", "Last-Rite Form", "Sanctuary Form", "Public Prayer")]
    div.sort(key=lambda r: (score(r), zlib.crc32(r["id"].encode())))
    for r in div[-5:]:
        r["rank"] = "SSS"
    for r in recs:
        rk = r["rank"]
        r["tier"] = TIER[rk]
        r["minLevel"] = BAND_START[rk]
        r["chant"] = CHANT[r["tier"]]
        r["minClassTier"] = MIN_CLASS_TIER[rk]


# ----------------------------------------------------------------------------- element
def element_for(rec):
    d, sub = rec["disc"], rec["sub"]
    n = rec["name"]
    if d == "FLM": return "Fire"
    if d == "TID": return "Water"
    if d == "STN": return "Earth"
    if d == "FRS": return "Ice"
    if d == "RAD": return "Light"
    if d == "UMB": return "Dark"
    if d == "FBD": return "Void"
    if d == "GAL": return "Lightning" if rec.get("sub") == "Storm" else "Wind"
    if d == "VRD": return "Poison" if rec.get("sub") == "Blight" else "Nature"
    return "None"


STORM_WORDS = ("Thunder", "Tempest", "Storm", "Spark", "Lark")
BLIGHT_WORDS = ("Thorn", "Briar", "Sap", "Pollen", "Bramble", "Seedshot")


def retag_subs(recs):
    """Lightning becomes the Storm branch of Galecraft; Poison the Blight branch of Verdance (proposal)."""
    for r in recs:
        if r["disc"] == "GAL" and any(w in r["name"] for w in STORM_WORDS):
            r["sub"] = "Storm"
        if r["disc"] == "VRD" and any(w in r["name"] for w in BLIGHT_WORDS):
            r["sub"] = "Blight"
    for r in recs:
        r["element"] = element_for(r)


# ----------------------------------------------------------------------------- class access
ADV = {
    "cls_swordsman": "Blademaster, Berserker", "cls_guardian": "Paladin, Fortress Knight", "cls_mage": "Elementalist, Spellweaver",
    "cls_cleric": "Priest, Templar", "cls_rogue": "Assassin, Phantom Thief", "cls_ranger": "Sniper, Beastwarden",
    "cls_tamer": "Summoner, Beast Lord", "cls_artisan": "Blacksmith, Alchemist", "cls_lancer": "Dragoon, Spear Saint",
    "cls_martial_artist": "Battle Monk, Brawler", "cls_bard": "Skald, Diva", "cls_occultist": "Warlock, Necromancer",
}
CLS = {k.split("_", 1)[1]: k for k in ADV}
ALLC = None


def _except(*cats):
    return ("except", set(cats))


# discipline -> [(class key, categories, 'P' primary / 'S' secondary via spellbook)]
ACCESS = {
    "AET": [("mage", ALLC, "P"), ("artisan", {"Utility", "Ward", "Binding", "Sensing", "Empowerment"}, "P"), ("guardian", {"Ward", "Binding"}, "S"),
            ("lancer", {"Mobility"}, "S"), ("rogue", {"Mobility", "Sensing", "Utility"}, "S"), ("bard", {"Empowerment"}, "S")],
    "FLM": [("mage", _except("Pact", "Mending"), "P"), ("swordsman", {"Empowerment", "Strike", "Mobility"}, "S"), ("artisan", {"Utility", "Barrage"}, "S"),
            ("martial_artist", {"Strike", "Empowerment"}, "P"), ("lancer", {"Strike"}, "S")],
    "TID": [("mage", _except("Pact"), "P"), ("cleric", {"Mending", "Ward", "Utility"}, "S"), ("ranger", {"Sensing", "Mobility", "Utility"}, "S"),
            ("bard", {"Illusion"}, "S")],
    "GAL": [("mage", _except("Pact", "Mending"), "P"), ("swordsman", {"Strike", "Mobility", "Barrage"}, "P"),
            ("ranger", {"Strike", "Mobility", "Sensing", "Utility", "Ward"}, "P"), ("rogue", {"Mobility", "Hex", "Illusion", "Utility"}, "P"),
            ("bard", {"Utility", "Empowerment", "Hex", "Illusion"}, "P"), ("lancer", {"Mobility", "Strike"}, "S"),
            ("martial_artist", {"Strike", "Mobility", "Barrage"}, "P")],
    "STN": [("mage", _except("Pact", "Mending"), "P"), ("guardian", {"Ward", "Binding", "Strike", "Utility", "Hex"}, "P"),
            ("artisan", {"Utility", "Ward", "Pact", "Sensing"}, "P"), ("martial_artist", {"Strike"}, "S")],
    "FRS": [("mage", _except("Pact", "Mending"), "P"), ("guardian", {"Ward"}, "S"), ("ranger", {"Binding", "Mobility"}, "S")],
    "VRD": [("ranger", {"Binding", "Sensing", "Barrage", "Illusion", "Mobility", "Utility"}, "P"),
            ("cleric", {"Mending", "Ward", "Empowerment"}, "P"), ("tamer", {"Binding", "Sensing", "Pact"}, "P"),
            ("mage", _except("Pact"), "S"), ("artisan", {"Utility", "Mending"}, "S")],
    "RAD": [("cleric", _except("Pact"), "P"), ("guardian", {"Ward", "Empowerment", "Strike", "Mending"}, "P"),
            ("lancer", {"Strike", "Mobility", "Barrage"}, "P"), ("mage", _except("Pact"), "S"), ("bard", {"Empowerment", "Illusion", "Hex"}, "S")],
    "UMB": [("occultist", _except("Mending"), "P"), ("rogue", {"Illusion", "Mobility", "Sensing", "Utility", "Hex", "Binding", "Strike"}, "P"),
            ("mage", {"Strike", "Hex", "Binding", "Illusion"}, "S")],
    "SPR": [("tamer", ALLC, "P"), ("cleric", {"Pact", "Sensing", "Ward", "Mending"}, "S"), ("ranger", {"Pact", "Sensing", "Mobility"}, "S"),
            ("bard", {"Pact", "Empowerment"}, "S"), ("occultist", {"Pact"}, "S")],
    "DIV": [("cleric", ALLC, "P"), ("guardian", {"Ward", "Empowerment", "Mending", "Strike"}, "S"), ("martial_artist", {"Empowerment"}, "P"),
            ("bard", {"Mending", "Empowerment"}, "S")],
    "FBD": [("mage", ALLC, "P"), ("occultist", {"Strike", "Hex", "Binding", "Illusion"}, "P"), ("rogue", {"Mobility", "Illusion"}, "S")],
}


# Gap fixes: every discipline and category pair has at least one learner.
for _d in ("FLM", "TID", "GAL", "STN", "FRS", "RAD"):
    ACCESS[_d].append(("tamer", {"Pact"}, "S"))
for _d in ("FLM", "STN", "FRS"):
    ACCESS[_d].append(("cleric", {"Mending"}, "S"))
ACCESS["GAL"].append(("bard", {"Mending"}, "S"))
ACCESS["UMB"].append(("occultist", {"Mending"}, "S"))
ACCESS["RAD"].append(("cleric", {"Pact"}, "S"))
ACCESS["FBD"] = [("mage", ALLC, "P"), ("occultist", ALLC, "P"), ("rogue", {"Mobility", "Illusion"}, "S")]


def _ok(cats, cat):
    if cats is None:
        return True
    if isinstance(cats, tuple):
        return cat not in cats[1]
    return cat in cats


def class_access(rec):
    prim, sec = [], []
    for ck, cats, kind in ACCESS[rec["disc"]]:
        if not _ok(cats, rec["cat"]):
            continue
        if rec["disc"] == "FBD" and ck == "mage" and rec["sub"] == "Void":
            continue          # Void is the Occultist's and the Void Walker's domain
        if rec["disc"] == "FBD" and ck == "occultist" and rec["sub"] != "Void" and rec["cat"] not in ("Hex", "Binding"):
            continue
        (prim if kind == "P" else sec).append(CLS[ck])
    if not prim and sec:
        prim, sec = sec[:1], sec[1:]
    return prim, sec
