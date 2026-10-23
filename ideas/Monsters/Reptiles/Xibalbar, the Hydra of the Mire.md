---
type: monster
id: mon_xibalbar_the_hydra_of_the_mire
family: "Reptiles"
rank: "B+"
tier: core
tags: [monster, reptiles, tyrant, unique]
---
# Xibalbar, the Hydra of the Mire

> The Xibalbar, the Hydra of the Mire is a huge creature with a coiling, legless body, about 10 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Its most striking feature is seven heads, each wearing a feathered mask stolen from a temple. It has eyes that never blink. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 10 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 21293 · 490 · 392 · 343 · 392 · 135 |
| XP · gold | 127464 · 1225 |
| Ring | 6 |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]] |
| Tyrant | Yes |
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

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
