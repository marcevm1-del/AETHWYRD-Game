---
type: monster
id: mon_labyrinth_hound
family: "Floor-born"
rank: "D"
tier: core
tags: [monster, floor-born]
---
# Labyrinth Hound

> The Labyrinth Hound is a person-sized creature with a heavy, muscular quadruped frame, about 1.4 m long. Its stone-like hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe a brick-patterned hide. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1.4 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3756 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Maul | melee | 1.2 | 0 s | None | blue |
| Pounce | dash | 1.6 | 6 s | None | red |
| Howl | buff | 0 | 18 s | None | none |
| Wall Ambush | dash | 1.4 | 10 s | None | red |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_floorborn_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Floor-born/Ruin Hound|Ruin Hound]]

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dungeon_stone` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
