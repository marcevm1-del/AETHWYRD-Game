---
type: monster
id: mon_vine_hive_tyrant
family: "Killer Insects"
rank: "A+"
tier: variant
tags: [monster, killer-insects]
---
# Vine Hive Tyrant

> The Vine Hive Tyrant is a huge creature with a sleek flying build, about 7 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in leaf greens over bark brown. Its most striking feature is a winged queen-killer with a crown of stingers. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It glides without moving its legs, surrounded by drifting pollen and tiny blossoms. Adapted to jungle lands, it has vivid tropical markings.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Hive Tyrant\|Hive Tyrant]] (regional) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Nature · Fire |
| Size | 7 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 37838 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Talon Rake | melee | 1.2 | 0 s | None | blue |
| Dive Bomb | dash | 1.9 | 10 s | None | red |
| Tail Whip | aoe | 1.3 | 6 s | None | red |
| Swarm Bite | aoe | 0.9 | 6 s | None | red |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_killer_insect_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `chitin_matte` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · elongated, irregular silhouette; still-then-sudden timing
