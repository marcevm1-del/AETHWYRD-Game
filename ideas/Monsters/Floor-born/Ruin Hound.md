---
type: monster
id: mon_ruin_hound
family: "Floor-born"
rank: "D+"
tier: variant
tags: [monster, floor-born]
---
# Ruin Hound

> The Ruin Hound is a person-sized creature with a long-legged predatory quadruped build, about 1.4 m long. Its stone-like hide is rough, scarred and spiked, colored in ink black with bruised violet. Look for a brick-patterned hide. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Labyrinth Hound\|Labyrinth Hound]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.4 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4714 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Maul | melee | 1.2 | 0 s | None | blue |
| Pounce | dash | 1.6 | 6 s | None | red |
| Howl | buff | 0 | 18 s | None | none |
| Wall Ambush | dash | 1.4 | 10 s | None | red |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_floorborn_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dungeon_stone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
