---
type: monster
id: mon_cinder_drake
family: "Dragons"
rank: "D+"
tier: variant
tags: [monster, dragons]
---
# Cinder Drake

> The Cinder Drake is a large creature with a powerful four-legged hunter's body, about 3 m long. Its scales are rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe blue-white scales with frost on every edge. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. Adapted to volcanic lands, it has ash-dark coloring with glowing cracks.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Frost Drake\|Frost Drake]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6111 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Maul | melee | 1.2 | 0 s | None | blue |
| Pounce | dash | 1.6 | 6 s | None | red |
| Howl | buff | 0 | 18 s | None | none |
| Wing Buffet | aoe | 1.1 | 9 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_draconic_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
