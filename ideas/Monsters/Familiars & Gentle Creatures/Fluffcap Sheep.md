---
type: monster
id: mon_fluffcap_sheep
family: "Familiars & Gentle Creatures"
rank: "F"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Fluffcap Sheep

> The Fluffcap Sheep is a small creature with a small, quick four-legged body, about 1 m long. Its coat is smooth and clean, colored in pale jade and cloud white. Its most striking feature is wool so light it floats. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 1 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 224 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
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
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_familiar_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Rime Fluffcap Sheep|Rime Fluffcap Sheep]]

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
