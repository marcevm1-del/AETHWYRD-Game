---
type: monster
id: mon_frost_toad
family: "Reptiles"
rank: "F+"
tier: variant
tags: [monster, reptiles]
---
# Frost Toad

> The Frost Toad is a small creature with a low, springy quadruped build, about 0.5 m long. Its scales are smooth and clean, colored in pale blues and frost-white. Look for a wide smile and bulging golden eyes. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Swamp Toad\|Swamp Toad]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Ice · Fire |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 333 · 62 · 50 · 43 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Charge | dash | 1.3 | 5 s | None | blue |
| Leap | dash | 1.2 | 6 s | None | blue |
| Tail Lash | aoe | 1.2 | 7 s | None | blue |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_reptile_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `scale_matte` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · circle-based, soft silhouette
