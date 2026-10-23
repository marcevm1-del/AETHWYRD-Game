---
type: monster
id: mon_swamp_toad
family: "Reptiles"
rank: "F"
tier: core
tags: [monster, reptiles]
---
# Swamp Toad

> The Swamp Toad is a small creature with a low, springy quadruped build, about 0.5 m long. Its scales are smooth and clean, colored in deep blues with a glassy shine. Survivors describe a wide smile and bulging golden eyes. It has big round glossy eyes. It has no ornament at all: simple, readable shapes. It waddles, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 182 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Charge | dash | 1.3 | 5 s | None | blue |
| Leap | dash | 1.2 | 6 s | None | blue |
| Tail Lash | aoe | 1.2 | 7 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_reptile_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Frost Toad|Frost Toad]]

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `scale_matte` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
