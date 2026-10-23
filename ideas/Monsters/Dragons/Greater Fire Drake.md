---
type: monster
id: mon_greater_fire_drake
family: "Dragons"
rank: "C"
tier: variant
tags: [monster, dragons]
---
# Greater Fire Drake

> The Greater Fire Drake is a large creature with a long-legged predatory quadruped build, about 4.8 m long. Its scales are rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is ember scales and a magma-glowing belly. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Fire Drake\|Fire Drake]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 4.8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11205 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 4 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Zarvan\|Zarvan]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Maul | melee | 1.2 | 0 s | None | blue |
| Pounce | dash | 1.6 | 6 s | None | red |
| Howl | buff | 0 | 18 s | None | none |
| Wing Buffet | aoe | 1.1 | 9 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_draconic_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
