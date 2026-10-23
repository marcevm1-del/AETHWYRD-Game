---
type: monster
id: mon_elder_maze_weaver
family: "Floor-born"
rank: "A"
tier: variant
tags: [monster, floor-born]
---
# Elder Maze Weaver

> The Elder Maze Weaver is a large creature with a squat, many-legged arachnid build, about 4.8 m long. Its stone-like hide is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. It rebuilds corridors behind you. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Maze Weaver\|Maze Weaver]] (elder) |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 4.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22910 · 594 · 475 · 416 · 475 · 135 |
| XP · gold | 8719 · 1611 |
| Ring | 7 |
| Habitats | [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/The Maw\|The Maw]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Fang Bite | melee | 1.1 | 0 s | None | blue |
| Web Shot | ranged | 0.5 | 8 s | None | blue |
| Ceiling Drop | dash | 1.7 | 12 s | None | red |
| Wall Ambush | dash | 1.4 | 10 s | None | red |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_floorborn_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `dungeon_stone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
