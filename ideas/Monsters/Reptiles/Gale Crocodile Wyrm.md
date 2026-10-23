---
type: monster
id: mon_gale_crocodile_wyrm
family: "Reptiles"
rank: "B-"
tier: variant
tags: [monster, reptiles]
---
# Gale Crocodile Wyrm

> The Gale Crocodile Wyrm is a huge creature with a massive snake-like frame, about 7 m long. Its scales are rough, scarred and spiked, colored in pale jade and cloud white. Survivors describe a back of armored ridges like a sunken log. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It circles its prey, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Crocodile Wyrm\|Crocodile Wyrm]] (elemental) |
| Rank · level | B- · 96 (86–108) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 7 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13769 · 394 · 315 · 276 · 315 · 135 |
| XP · gold | 4462 · 897 |
| Ring | 6 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Zarvan\|Zarvan]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Tail Lash | aoe | 1.2 | 7 s | None | blue |
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_reptile_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
