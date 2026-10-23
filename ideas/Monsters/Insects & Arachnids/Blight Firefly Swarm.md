---
type: monster
id: mon_blight_firefly_swarm
family: "Insects & Arachnids"
rank: "E+"
tier: variant
tags: [monster, insects-arachnids]
---
# Blight Firefly Swarm

> The Blight Firefly Swarm is a tiny creature with a living carpet of small bodies, each one is about 0.05 m long, but the swarm covers several meters. Its chitin is smooth and clean, colored in bruise purple with sickly green. Guild sketches always show hundreds of soft lantern lights moving together. It has two bright dot eyes. Small scars and rough edges mark it as a survivor. It bounces happily, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Firefly Swarm\|Firefly Swarm]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 1 · Charming |
| Element · weakness | Poison · Light |
| Size | 0.05 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 709 · 110 · 83 · 83 · 83 · 110 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nibble | melee | 0.6 | 0 s | None | none |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Scatter | evade | 0 | 10 s | None | none |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_insect_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `chitin_gloss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · circle-based, soft silhouette
