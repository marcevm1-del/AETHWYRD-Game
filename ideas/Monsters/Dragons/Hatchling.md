---
type: monster
id: mon_hatchling
family: "Dragons"
rank: "F"
tier: core
tags: [monster, dragons]
---
# Hatchling

> The Hatchling is a small creature with an ancient, serpentine dragon body, about 0.5 m long. Its scales are smooth and clean, colored in ember reds fading to soot black. Look for a too-big head and wings it can't use yet. It has big round glossy eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Fire · Water |
| Size | 0.5 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 322 · 55 · 50 · 55 · 50 · 100 |
| XP · gold | 92 · 31 |
| Ring | 3 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Lirian\|Lirian]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Claw | melee | 1.4 | 0 s | None | blue |
| Breath | aoe | 2.2 | 14 s | None | red |
| Wing Gust | aoe | 1 | 10 s | None | blue |
| Tail Blade | melee | 1.8 | 8 s | None | red |
| Wing Buffet | aoe | 1.1 | 9 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_draconic_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Dragons/Rime Hatchling|Rime Hatchling]]

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · circle-based, soft silhouette
