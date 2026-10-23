---
type: monster
id: mon_maze_weaver
family: "Floor-born"
rank: "B"
tier: core
tags: [monster, floor-born]
---
# Maze Weaver

> The Maze Weaver is a large creature with a squat, many-legged arachnid build, about 3 m long. Its stone-like hide is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. It rebuilds corridors behind you. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 3 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12524 · 442 · 354 · 309 · 354 · 135 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Aurumdeep\|Aurumdeep]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Fang Bite | melee | 1.1 | 0 s | None | blue |
| Web Shot | ranged | 0.5 | 8 s | None | blue |
| Ceiling Drop | dash | 1.7 | 12 s | None | red |
| Wall Ambush | dash | 1.4 | 10 s | None | red |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_floorborn_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Floor-born/Elder Maze Weaver|Elder Maze Weaver]]

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `dungeon_stone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
