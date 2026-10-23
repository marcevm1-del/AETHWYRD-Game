---
type: monster
id: mon_rime_fluffcap_sheep
family: "Familiars & Gentle Creatures"
rank: "F+"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Rime Fluffcap Sheep

> The Rime Fluffcap Sheep is a small creature with a low, springy quadruped build, about 1 m long. Its coat is smooth and clean, colored in pale blues and frost-white. Survivors describe wool so light it floats. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by falling snow motes and frosted ground where it steps. Adapted to tundra lands, it has a thick, frost-rimed coat.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Fluffcap Sheep\|Fluffcap Sheep]] (regional) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Ice · Fire |
| Size | 1 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 410 · 62 · 50 · 43 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Charge | dash | 1.3 | 5 s | None | blue |
| Leap | dash | 1.2 | 6 s | None | blue |
| Playful Nudge | melee | 0.5 | 6 s | None | none |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_familiar_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · circle-based, soft silhouette
