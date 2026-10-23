---
type: monster
id: mon_ash_blade_mantis
family: "Insects & Arachnids"
rank: "C-"
tier: variant
tags: [monster, insects-arachnids]
---
# Ash Blade Mantis

> The Ash Blade Mantis is a person-sized creature with a six-legged armored body, about 2 m long. Its chitin is rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe forearms shaped like curved scythes. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Blade Mantis\|Blade Mantis]] (elemental) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8447 · 270 · 405 · 162 · 270 · 70 |
| XP · gold | 2395 · 521 |
| Ring | 4 |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Mandible Crush | melee | 1.1 | 0 s | None | blue |
| Burrow Ambush | dash | 1.5 | 10 s | None | red |
| Acid Spray | ranged | 1 | 6 s | None | blue |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_insect_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
