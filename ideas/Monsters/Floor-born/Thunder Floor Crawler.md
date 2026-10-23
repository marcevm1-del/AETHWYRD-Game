---
type: monster
id: mon_thunder_floor_crawler
family: "Floor-born"
rank: "F+"
tier: variant
tags: [monster, floor-born]
---
# Thunder Floor Crawler

> The Thunder Floor Crawler is a small creature with a low, springy quadruped build, about 0.8 m long. Its stone-like hide is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Survivors describe stone-colored skin that matches the walls it was born from. It has narrow glowing eyes. It has no ornament at all: simple, readable shapes. It charges without hesitation, surrounded by crackling arcs that jump across its body. This Lightning-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Floor Crawler\|Floor Crawler]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 0.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 382 · 62 · 50 · 43 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Earth. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Charge | dash | 1.3 | 5 s | None | blue |
| Leap | dash | 1.2 | 6 s | None | blue |
| Wall Ambush | dash | 1.4 | 10 s | None | red |
| Static Arc | magic | 1.5 | 10 s | Lightning | red |

## Loot (`loot_floorborn_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `dungeon_stone` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
