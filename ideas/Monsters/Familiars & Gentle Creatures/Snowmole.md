---
type: monster
id: mon_snowmole
family: "Familiars & Gentle Creatures"
rank: "E"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Snowmole

> The Snowmole is a tiny creature with a small, quick four-legged body, about 0.4 m long. Its coat is smooth and clean, colored in pale blues and frost-white. Survivors describe a white nose and shovel-like paws. It has big round glossy eyes. Small scars and rough edges mark it as a survivor. It hops in little bursts, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Ice · Fire |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 819 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Sylvaran\|Sylvaran]], [[Regions/Lirian\|Lirian]] |
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

## Loot (`loot_familiar_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Sky Snowmole|Sky Snowmole]]

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · circle-based, soft silhouette
