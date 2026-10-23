---
type: monster
id: mon_needle_wasp
family: "Killer Insects"
rank: "E+"
tier: core
tags: [monster, killer-insects]
---
# Needle Wasp

> The Needle Wasp is a tiny creature with a tiny, darting winged build, about 0.3 m tall. Its chitin is rough, scarred and spiked, colored in bruise purple with sickly green. Look for a stinger as long as its body. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 0.3 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1034 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nip | melee | 0.9 | 0 s | None | blue |
| Dart | dash | 1.1 | 4 s | None | blue |
| Swarm Call | summon | 0 | 20 s | None | none |
| Swarm Bite | aoe | 0.9 | 6 s | None | red |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_killer_insect_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Cavern Needle Wasp|Cavern Needle Wasp]]
- [[Monsters/Killer Insects/Greater Needle Wasp|Greater Needle Wasp]]

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
