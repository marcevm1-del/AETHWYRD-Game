---
type: monster
id: mon_core_sentinel
family: "Floor-born"
rank: "C"
tier: core
tags: [monster, floor-born]
---
# Core Sentinel

> The Core Sentinel is a large creature with a blocky construct body, about 2.5 m tall. Its stone-like hide is rough, scarred and spiked, colored in warm gold and pearl white. Survivors describe a dungeon-core crystal for a heart. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 2.5 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11496 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Habitats | [[Regions/Umbravel\|Umbravel]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Dark. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slam | melee | 1.4 | 0 s | None | blue |
| Ground Pound | aoe | 1.8 | 10 s | None | red |
| Guard Stance | buff | 0 | 15 s | None | none |
| Wall Ambush | dash | 1.4 | 10 s | None | red |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_floorborn_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Floor-born/Greater Core Sentinel|Greater Core Sentinel]]

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `dungeon_stone` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
