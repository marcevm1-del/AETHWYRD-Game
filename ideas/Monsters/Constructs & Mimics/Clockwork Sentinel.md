---
type: monster
id: mon_clockwork_sentinel
family: "Constructs & Mimics"
rank: "C"
tier: core
tags: [monster, constructs-mimics]
---
# Clockwork Sentinel

> The Clockwork Sentinel is a large creature with a heavy, hand-built humanoid shell, about 2.5 m tall. Its surface is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Guild sketches always show brass gears visible through its ribs. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 2.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11496 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Lirian\|Lirian]], [[Regions/Gearholm\|Gearholm]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Haneul\|Haneul]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slam | melee | 1.4 | 0 s | None | blue |
| Ground Pound | aoe | 1.8 | 10 s | None | red |
| Guard Stance | buff | 0 | 15 s | None | none |
| Rune Pulse | magic | 1.3 | 10 s | None | red |
| Static Arc | magic | 1.5 | 10 s | Lightning | red |

## Loot (`loot_construct_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Dusk Clockwork Sentinel|Dusk Clockwork Sentinel]]

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
