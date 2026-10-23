---
type: monster
id: mon_hydra
family: "Reptiles"
rank: "B+"
tier: core
tags: [monster, reptiles]
---
# Hydra

> The Hydra is a huge creature with a coiling, legless body, about 9 m long. Its scales are rough, scarred and spiked, colored in bruise purple with sickly green. Guild sketches always show five heads on long necks, each with its own temper. It has narrow glowing eyes. Faint runes glow along its body when it fights. It circles its prey, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 9 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20668 · 490 · 392 · 343 · 392 · 135 |
| XP · gold | 6373 · 1225 |
| Ring | 3 |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Lirian\|Lirian]], [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Tail Lash | aoe | 1.2 | 7 s | None | blue |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_reptile_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Reptiles/Frost Hydra|Frost Hydra]]

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
