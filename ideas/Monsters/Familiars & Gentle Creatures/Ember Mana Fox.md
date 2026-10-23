---
type: monster
id: mon_ember_mana_fox
family: "Familiars & Gentle Creatures"
rank: "E+"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Ember Mana Fox

> The Ember Mana Fox is a small creature with a compact quadruped frame, about 0.6 m long. Its coat is smooth and clean, colored in ember reds fading to soot black. Its most striking feature is ears that twitch toward magic. It has two bright dot eyes. Small scars and rough edges mark it as a survivor. It waddles, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Mana Fox\|Mana Fox]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 1 · Charming |
| Element · weakness | Fire · Water |
| Size | 0.6 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1228 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Fanghold\|Fanghold]] |
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

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · circle-based, soft silhouette
