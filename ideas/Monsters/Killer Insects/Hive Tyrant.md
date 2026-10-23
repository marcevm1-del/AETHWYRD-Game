---
type: monster
id: mon_hive_tyrant
family: "Killer Insects"
rank: "A"
tier: core
tags: [monster, killer-insects]
---
# Hive Tyrant

> The Hive Tyrant is a huge creature with a bipedal winged body with wing-arms, about 7 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe a winged queen-killer with a crown of stingers. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 7 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 33309 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/The Maw\|The Maw]], [[Regions/Moraveil\|Moraveil]], [[Regions/Cinderhole\|Cinderhole]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Talon Rake | melee | 1.2 | 0 s | None | blue |
| Dive Bomb | dash | 1.9 | 10 s | None | red |
| Tail Whip | aoe | 1.3 | 6 s | None | red |
| Swarm Bite | aoe | 0.9 | 6 s | None | red |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_killer_insect_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Vine Hive Tyrant|Vine Hive Tyrant]]
- [[Monsters/Killer Insects/Greater Hive Tyrant|Greater Hive Tyrant]]

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
