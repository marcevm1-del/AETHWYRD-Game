---
type: monster
id: mon_cloud_mimic
family: "Constructs & Mimics"
rank: "D+"
tier: variant
tags: [monster, constructs-mimics]
---
# Cloud Mimic

> The Cloud Mimic is a small creature with a hollow shell posing as an everyday object, about 1 m tall. Its surface is stretched, stitched and constantly shifting, colored in pale jade and cloud white. Survivors describe a treasure chest with a tongue and a ring of teeth. It has no eyes at all, only a wide and patient mouth. A distinctive marking runs along its back. It unfolds into something larger, surrounded by swirling leaves and a constant breeze. Adapted to sky lands, it has cloud-pale coloring and lighter bones.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Mimic\|Mimic]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 5 · Horror |
| Element · weakness | Wind · Fire |
| Size | 1 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3832 · 293 · 211 · 211 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Velmark\|Velmark]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chomp | melee | 1.6 | 0 s | None | red |
| Tongue Lash | grab | 1.4 | 6 s | None | gold |
| Disguise | stealth | 0 | 20 s | None | none |
| Rune Pulse | magic | 1.3 | 10 s | None | red |
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_construct_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · broken symmetry, mimicry, audio-first reveal
