---
type: monster
id: mon_ember_kitten
family: "Familiars & Gentle Creatures"
rank: "E"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Ember Kitten

> The Ember Kitten is a tiny creature with a small, quick four-legged body, about 0.4 m long. Its coat is smooth and clean, colored in ember reds fading to soot black. Guild sketches always show fur that flickers like candle flame. It has two bright dot eyes. Small scars and rough edges mark it as a survivor. It bounces happily, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Fire · Water |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 819 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Lirian\|Lirian]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Fanghold\|Fanghold]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Charge | dash | 1.3 | 5 s | None | blue |
| Leap | dash | 1.2 | 6 s | None | blue |
| Playful Nudge | melee | 0.5 | 6 s | None | none |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_familiar_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Moss Kitten|Moss Kitten]]

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · circle-based, soft silhouette
