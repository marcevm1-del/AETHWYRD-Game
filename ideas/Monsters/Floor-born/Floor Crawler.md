---
type: monster
id: mon_floor_crawler
family: "Floor-born"
rank: "F"
tier: core
tags: [monster, floor-born]
---
# Floor Crawler

> The Floor Crawler is a small creature with a low, springy quadruped build, about 0.8 m long. Its stone-like hide is rough, scarred and spiked, colored in muted greys and dusty browns. Its most striking feature is stone-colored skin that matches the walls it was born from. It has burning slit pupils. It has no ornament at all: simple, readable shapes. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Rank · level | F · 8 (3–13) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 0.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 209 · 42 · 34 · 21 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Charge | dash | 1.3 | 5 s | None | blue |
| Leap | dash | 1.2 | 6 s | None | blue |
| Wall Ambush | dash | 1.4 | 10 s | None | red |

## Loot (`loot_floorborn_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Floor-born/Thunder Floor Crawler|Thunder Floor Crawler]]

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `dungeon_stone` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
