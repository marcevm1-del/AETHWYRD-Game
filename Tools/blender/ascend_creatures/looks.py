"""
A creature's look, read from its species entry (Data/Monsters/species.json → designRecipe): palette, surface style,
skin pattern, eye style and element accents. Everything here can be overridden per object (see generate.py).
"""
import random
import zlib

# material -> (roughness, metallic, emission, alpha), pattern, belly, cavity, displacement
STYLE = {
    "translucent_gel_sss": ((0.12, 0.0, 0.0, 1.0), "none", False, 0.15, 0.0),
    "rough_skin_leather": ((0.75, 0.0, 0.0, 1), "patches", True, 0.45, 0.006),
    "fur_short": ((0.9, 0, 0, 1), "stripes", True, 0.35, 0.004),
    "fur_groom": ((0.85, 0, 0, 1), "patches", True, 0.35, 0.004),
    "fur_rough": ((0.95, 0, 0, 1), "patches", True, 0.4, 0.007),
    "fur_soft": ((0.9, 0, 0, 1), "none", True, 0.25, 0.002),
    "chitin_gloss": ((0.2, 0.1, 0, 1), "rings", False, 0.5, 0.0),
    "chitin_matte": ((0.6, 0.05, 0, 1), "rings", False, 0.5, 0.0),
    "rot_bone": ((0.8, 0, 0, 1), "patches", False, 0.6, 0.008),
    "shadow_smoke": ((0.9, 0, 0.6, 0.85), "none", False, 0.2, 0.0),
    "thick_skin": ((0.7, 0, 0, 1), "patches", True, 0.5, 0.006),
    "short_hide": ((0.75, 0, 0, 1), "spots", True, 0.35, 0.003),
    "scale_matte": ((0.6, 0.05, 0, 1), "cells", True, 0.45, 0.0),
    "dragon_scale": ((0.35, 0.25, 0, 1), "cells", True, 0.5, 0.0),
    "stone_metal_runes": ((0.55, 0.4, 0, 1), "patches", False, 0.6, 0.012),
    "elemental_emissive": ((0.3, 0, 2.5, 0.92), "none", False, 0.2, 0.0),
    "bark_leaf": ((0.9, 0, 0, 1), "stripes", False, 0.6, 0.012),
    "demon_hide_emissive": ((0.5, 0.1, 0.8, 1), "patches", True, 0.5, 0.004),
    "wet_scale": ((0.15, 0.1, 0, 1), "cells", True, 0.4, 0.0),
    "feather_groom": ((0.85, 0, 0, 1), "patches", True, 0.3, 0.003),
    "mixed_hide": ((0.8, 0, 0, 1), "patches", True, 0.4, 0.004),
    "scale_gloss": ((0.2, 0.2, 0, 1), "cells", True, 0.4, 0.0),
    "horse_coat": ((0.6, 0, 0, 1), "none", True, 0.3, 0.002),
    "old_iron": ((0.45, 0.85, 0, 1), "patches", False, 0.6, 0.006),
    "rubbery_skin": ((0.35, 0, 0, 1), "spots", True, 0.35, 0.0),
    "wet_flesh_unsettling": ((0.2, 0, 0, 1), "patches", False, 0.55, 0.008),
    "paper_ink_spirit": ((0.95, 0, 0.4, 0.95), "none", False, 0.25, 0.0),
    "dungeon_stone": ((0.85, 0.05, 0, 1), "patches", False, 0.65, 0.014),
    "porcelain_red_glow": ((0.12, 0, 0, 1), "none", False, 0.3, 0.0),
    "sand_hide": ((0.85, 0, 0, 1), "stripes", True, 0.4, 0.004),
    "cloth_leather_metal": ((0.7, 0.3, 0, 1), "none", True, 0.4, 0.003),
}

ELEMENT_GLOW = {
    "Fire": (1.0, 0.42, 0.1), "Ice": (0.55, 0.85, 1.0), "Lightning": (1.0, 0.92, 0.35), "Water": (0.35, 0.75, 1.0),
    "Earth": (0.95, 0.7, 0.3), "Wind": (0.6, 1.0, 0.8), "Nature": (0.55, 1.0, 0.35), "Light": (1.0, 0.95, 0.7),
    "Dark": (0.65, 0.35, 1.0), "Poison": (0.6, 1.0, 0.2), "Blood": (1.0, 0.15, 0.15), "Void": (0.55, 0.3, 1.0),
    "None": (1.0, 0.8, 0.4),
}


def hex_lin(h):
    h = h.lstrip("#")
    c = tuple(int(h[i:i + 2], 16) / 255 for i in (0, 2, 4))
    return tuple(x / 12.92 if x <= 0.04045 else ((x + 0.055) / 1.055) ** 2.4 for x in c)


class Look:
    def __init__(self, species, overrides=None):
        rec = species.get("designRecipe", {})
        o = overrides or {}
        self.seed = zlib.crc32(species["id"].encode()) % 100000 + int(o.get("seed", 0)) * 131
        rng = random.Random(species["id"] + str(o.get("seed", "")))
        pal = list(o.get("palette") or rec.get("palette") or ["#888888", "#555555", "#cccccc"])
        while len(pal) < 3:
            pal.append(pal[-1])
        self.main, self.dark, self.accent = (hex_lin(p) for p in pal[:3])
        self.style = o.get("material") or rec.get("material", "thick_skin")
        st = STYLE.get(self.style, STYLE["thick_skin"])
        self.surface, pattern, self.belly, self.cavity, self.bump = st
        # most patterned hides vary by species: plain, the default pattern, or spots
        self.pattern = o.get("pattern") or (pattern if pattern == "none" else rng.choice([pattern, pattern, "none", "spots"]))
        self.pattern_scale = rng.uniform(4.0, 8.0)
        self.spot_light = rng.random() < 0.5
        self.back_dark = 0.55
        self.gel = self.style == "translucent_gel_sss"
        self.glow_cracks = self.style in ("demon_hide_emissive", "elemental_emissive") or o.get("glow_cracks", False)
        self.element = o.get("element") or species.get("element", "None")
        self.glow = ELEMENT_GLOW.get(self.element, ELEMENT_GLOW["None"])
        menace = rec.get("menaceStyle", "")
        self.menace = ("soft" if menace.startswith("circle") else "spiky" if menace.startswith("triangle") else
                       "elongated" if menace.startswith("elongated") else "broken" if menace.startswith("broken") else "animal")
        self.parts = list(o.get("parts") or rec.get("parts", []))
        # A mask only where the description names one (design review C1): a stray plain mask hides the face and
        # reads as placeholder (or as another studio's character).
        if "mask" not in species.get("look", "").lower() and "mask" not in species.get("signature", "").lower():
            self.parts = [p for p in self.parts if p not in ("mask", "mask_face", "human_mask")]
        self.base = o.get("base") or rec.get("baseMesh", "medium_biped_base")
        look_text = species.get("look", "").lower()
        self.look_text = look_text
        self.name = species.get("name", "")
        self.eye_style = ("dot" if "dot eye" in look_text or self.gel else "slit" if "slit" in look_text else
                          "glow" if any(w in look_text for w in ("burning", "glowing", "glow", "ember")) else
                          "beady" if "beady" in look_text or "wary" in look_text else "anime")
        self.eye_count = 2
        for word, n in (("single eye", 1), ("one eye", 1), ("three eyes", 3), ("four eyes", 4), ("six eyes", 6), ("eight eyes", 8)):
            if word in look_text:
                self.eye_count = n
        self.vfx = rec.get("vfx", "")
        self.family = species.get("family", "")
        self.rank = rec.get("rankOrnament", "F")

    def palette(self):
        """Colours for the hard-surface parts (keys used by features.py)."""
        g = self.glow
        return {
            "main": self.main, "dark": self.dark, "accent": self.accent,
            "bone": (0.82, 0.76, 0.62), "horn": (0.30, 0.26, 0.22), "claw": (0.16, 0.14, 0.13),
            "metal": (0.52, 0.54, 0.58), "metal_dark": (0.22, 0.22, 0.25), "rust": (0.42, 0.22, 0.12),
            "cloth": tuple(c * 0.75 for c in self.dark), "cloth_light": (0.70, 0.62, 0.48), "leather": (0.30, 0.18, 0.10),
            "wood": (0.33, 0.21, 0.12), "leaf": (0.22, 0.45, 0.16), "moss": (0.24, 0.40, 0.12), "stone": (0.42, 0.42, 0.44),
            "eye_white": (0.95, 0.95, 0.93), "eye_dark": (0.02, 0.02, 0.03), "highlight": (1.0, 1.0, 1.0),
            "iris": g if self.eye_style in ("glow", "slit") else tuple(min(1, c * 1.1) for c in self.accent),
            "mouth": (0.25, 0.05, 0.06), "teeth": (0.95, 0.92, 0.84), "tongue": (0.75, 0.25, 0.3),
            "gold": (1.0, 0.72, 0.22), "gem": g, "glow": g, "crystal": g, "membrane": tuple(c * 0.8 for c in self.dark),
            "feather": self.main, "feather_tip": self.dark, "petal": self.accent, "spore": self.accent, "ink": (0.05, 0.05, 0.07),
        }
