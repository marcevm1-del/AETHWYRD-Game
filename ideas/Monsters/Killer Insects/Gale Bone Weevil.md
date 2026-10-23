---
type: monster
id: mon_gale_bone_weevil
family: "Killer Insects"
rank: "C+"
tier: variant
tags: [monster, killer-insects]
---
# Gale Bone Weevil

> The Gale Bone Weevil is a small creature with a six-legged armored body, about 1 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in pale jade and cloud white. Look for a shell made from the bones it eats. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Bone Weevil\|Bone Weevil]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Wind · Fire |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10133 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Mandible Crush | melee | 1.1 | 0 s | None | blue |
| Burrow Ambush | dash | 1.5 | 10 s | None | red |
| Acid Spray | ranged | 1 | 6 s | None | blue |
| Swarm Bite | aoe | 0.9 | 6 s | None | red |
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_killer_insect_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · elongated, irregular silhouette; still-then-sudden timing
