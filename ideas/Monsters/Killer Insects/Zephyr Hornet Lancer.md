---
type: monster
id: mon_zephyr_hornet_lancer
family: "Killer Insects"
rank: "D+"
tier: variant
tags: [monster, killer-insects]
---
# Zephyr Hornet Lancer

> The Zephyr Hornet Lancer is a person-sized creature with a tiny, darting winged build, about 1.2 m tall. Its chitin is rough, scarred and spiked, colored in pale jade and cloud white. Its most striking feature is a lance-like stinger and humming armored wings. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Hornet Lancer\|Hornet Lancer]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 1.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3458 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nip | melee | 0.9 | 0 s | None | blue |
| Dart | dash | 1.1 | 4 s | None | blue |
| Swarm Call | summon | 0 | 20 s | None | none |
| Swarm Bite | aoe | 0.9 | 6 s | None | red |
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_killer_insect_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `chitin_matte` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
