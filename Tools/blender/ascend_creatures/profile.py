"""
Species profiles: the silhouette a body plan takes for a particular species, read from keywords in its name and
description (a variant uses its base species' name, so a Phantom Wild Boar is still a boar). Without profiles every
quadruped would be the same wolf; with them a boar is low and heavy with a long snout, an elk is all legs and neck, a
salamander sprawls, a sabretooth has a short muzzle and a long tail.

Also the variant treatments (variantKind in species.json): elder, ancient, spirit (Phantom), corrupted
(Vesper-Touched), elemental and regional.
"""

QUAD = dict(L=1.0, leg=1.0, neck=1.0, head=1.0, snout=1.0, bulk=1.0, tail=1.0, ears="pointy", low=False, shell=False,
            mane=False, heads=1, tails=1, wings=False, beak=False, wool=False, add=())
BIPED = dict(bulk=1.0, limb=1.0, head=1.0, snout=0.0, ears=None, tail=False, hunch=0.0, arms=1.0, thin=False, add=())

QUAD_RULES = [
    (("cerberus",), dict(heads=3, bulk=1.25)),
    (("fenrir", "garm"), dict(bulk=1.25, head=1.1, mane=True)),
    (("wolf", "hound", "dog", "warg", "jackal"), dict()),
    (("boar", "hog", "swine"), dict(bulk=1.45, leg=0.7, snout=1.5, tail=0.3, ears="round", add=("tusks",))),
    (("owlbear",), dict(bulk=1.6, leg=0.8, head=1.25, snout=0.4, beak=True, tail=0.2, ears="tuft")),
    (("bear",), dict(bulk=1.6, leg=0.8, head=1.2, snout=0.8, tail=0.2, ears="round")),
    (("behemoth", "mammoth", "rhino", "bison", "ox"), dict(bulk=1.8, leg=0.85, head=1.2, snout=0.9, tail=0.3, ears="round", add=("horns",))),
    (("elk", "deer", "stag", "antelope", "gazelle", "ibex"), dict(leg=1.4, neck=1.7, bulk=0.9, head=0.85, snout=1.2, tail=0.2, ears="long")),
    (("griffon", "hippogriff"), dict(beak=True, wings=True, leg=1.05, ears="tuft", tail=1.2)),
    (("manticore",), dict(wings=True, mane=True, snout=0.55, head=1.15, tail=1.4, add=("stinger",))),
    (("sphinx",), dict(wings=True, mane=True, snout=0.45, head=1.1, tail=1.3)),
    (("chimera",), dict(wings=True, mane=True, heads=2, snout=0.6, tail=1.4, add=("horns",))),
    (("nue",), dict(snout=0.55, head=1.15, tail=1.6, ears="round")),
    (("sabretooth", "sabre", "lion", "tiger", "panther", "lynx", "leopard", "cat", "kitten"),
     dict(L=1.15, leg=0.95, head=1.15, snout=0.5, tail=1.5, ears="pointy")),
    (("unicorn", "qilin", "kirin"), dict(leg=1.5, neck=1.9, snout=1.6, L=1.1, tail=1.3, mane=True, ears="small", add=("horn_single",))),
    (("horse", "steed", "mare", "stallion", "pegasus"), dict(leg=1.5, neck=1.9, snout=1.6, L=1.1, tail=1.3, mane=True, ears="small")),
    (("lizard", "salamander", "basilisk", "skink", "gecko", "drake", "croc", "gator"),
     dict(low=True, leg=0.55, L=1.35, tail=2.2, snout=1.4, neck=0.6, ears="none")),
    (("vixen", "fox"), dict(bulk=0.85, snout=1.35, ears="big", tail=1.6)),
]
QUAD_SMALL_RULES = [
    (("toad", "frog"), dict(low=True, leg=0.6, tail=0.0, snout=0.3, head=1.3, ears="none", L=0.9, bulk=1.25)),
    (("tortoise", "turtle"), dict(shell=True, low=True, leg=0.55, tail=0.3, neck=0.8, snout=0.6, ears="none")),
    (("sheep", "lamb"), dict(wool=True, bulk=1.25, snout=0.9, ears="side", tail=0.3)),
    (("mole",), dict(snout=1.5, ears="none", tail=0.3, bulk=1.15, leg=0.7)),
    (("kitten", "cat"), dict(snout=0.5, ears="pointy", tail=1.6)),
    (("fox",), dict(snout=1.4, ears="big", tail=1.7)),
    (("skink", "crawler", "lizard"), dict(low=True, leg=0.55, L=1.3, tail=2.0, snout=1.3, ears="none")),
    (("rabbit", "hare", "jackalope"), dict(ears="tall", tail=0.3)),
]
BIPED_RULES = [
    (("skeleton", "bone"), dict(thin=True, limb=0.5, bulk=0.65)),
    (("zombie", "ghoul", "hollow mourner", "mourner"), dict(hunch=0.08, arms=1.1)),
    (("werewolf", "moon beast", "fenrir-blooded", "blood vesper", "skinchanger", "bramble beast"),
     dict(snout=1.2, ears="tall", tail=True, bulk=1.25, hunch=0.05)),
    (("wererat",), dict(snout=1.1, ears="round", tail=True, hunch=0.05)),
    (("werebear",), dict(snout=0.8, ears="round", bulk=1.6, limb=1.4)),
    (("gnoll",), dict(snout=1.0, ears="round", hunch=0.06, tail=True)),
    (("lizardman", "sahuagin", "kobold"), dict(snout=1.1, tail=True, ears="none")),
    (("minotaur", "taurgrim"), dict(snout=0.9, ears="side", tail=True, add=("horns",))),
    (("satyr",), dict(ears="side", tail=True, add=("horns_small",))),
    (("orc",), dict(bulk=1.3, limb=1.2, add=("tusks",))),
    (("troll",), dict(arms=1.25, hunch=0.07, add=("nose_hooked",))),
    (("cyclops",), dict(head=1.2)),
    (("giant", "titan", "colossus"), dict(bulk=1.2, head=0.85)),
    (("oni", "kijin", "demon", "div"), dict(add=("horns",))),
    (("gremlin", "imp"), dict(ears="big", tail=True)),
    (("gnome",), dict(head=1.1, add=("nose_hooked",))),
    (("scarecrow", "living armor", "mud doll"), dict(thin=True, limb=0.7)),
    (("vampire", "cultist", "bandit", "mage", "knight", "inquisitor", "hero", "archer", "slaver", "highwayman", "blade", "baron", "lord"),
     dict(bulk=0.92, limb=0.9)),
]


def _match(rules, text):
    for keys, params in rules:
        if any(k in text for k in keys):
            return params
    return {}


def text_of(species, all_species):
    """Name and description of the species (or its base species for variants), lowercased."""
    base = all_species.get(species.get("baseSpeciesId") or "", species)
    return (" ".join([base.get("name", ""), species.get("name", ""), base.get("look", "")[:160]])).lower()


def quad_profile(text, small=False):
    p = dict(QUAD)
    p.update(_match(QUAD_SMALL_RULES if small else QUAD_RULES, text))
    if "nine-tailed" in text:
        p["tails"] = 9
    return p


def biped_profile(text):
    p = dict(BIPED)
    p.update(_match(BIPED_RULES, text))
    return p


# ----------------------------------------------------------------------------------------------------------------
# variant treatments

ELEMENT_PARTS = {
    "Fire": ("flame_neck", "glowing_spots"), "Ice": ("crystal_growths",), "Earth": ("stone_growths",),
    "Nature": ("moss_cover",), "Lightning": ("glowing_spots",), "Poison": ("spore_pods",), "Water": ("fins",),
    "Wind": ("trailing_wisps",), "Dark": ("trailing_wisps",), "Light": ("glowing_spots",), "Blood": ("scar_decals",),
    "Void": ("eye_clusters",),
}


def variant(look, species):
    """Adjusts a Look for the species' variant kind. Returns a bulk multiplier for the body plan."""
    kind = species.get("variantKind") or ""
    add = []
    bulk = 1.0
    if kind in ("elder", "ancient"):
        bulk = 1.12
        add += ["scar_decals"] + (["moss_cover", "stone_growths"] if kind == "ancient" else ["armored_back"])
    elif kind == "spirit":
        look.spirit = True
        add += ["trailing_wisps"]
    elif kind == "corrupted":
        look.glow_cracks = True
        look.glow = (1.0, 0.18, 0.22)
        add += ["crystal_growths"]
    elif kind == "elemental":
        add += list(ELEMENT_PARTS.get(look.element, ()))
        if look.element in ("Fire", "Lightning"):
            look.glow_cracks = True
    for a in add:
        if a not in look.parts:
            look.parts.append(a)
    return bulk
