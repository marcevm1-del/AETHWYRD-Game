---
type: monster
id: mon_frost_drake
family: "Dragons"
rank: "D"
tier: core
tags: [monster, dragons]
---
# Frost Drake

> The Frost Drake is a large creature with a long-legged predatory quadruped build, about 3 m long. Its scales are rough, scarred and spiked, colored in pale blues and frost-white. Guild sketches always show blue-white scales with frost on every edge. It has narrow glowing eyes. A distinctive marking runs along its back. It charges without hesitation, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4870 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Lirian\|Lirian]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Maul | melee | 1.2 | 0 s | None | blue |
| Pounce | dash | 1.6 | 6 s | None | red |
| Howl | buff | 0 | 18 s | None | none |
| Wing Buffet | aoe | 1.1 | 9 s | None | blue |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_draconic_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Dragons/Cinder Drake|Cinder Drake]]

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
