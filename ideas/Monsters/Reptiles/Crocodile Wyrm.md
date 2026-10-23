---
type: monster
id: mon_crocodile_wyrm
family: "Reptiles"
rank: "C+"
tier: core
tags: [monster, reptiles]
---
# Crocodile Wyrm

> The Crocodile Wyrm is a huge creature with a long, sinuous serpentine body, about 7 m long. Its scales are rough, scarred and spiked, colored in deep blues with a glassy shine. Survivors describe a back of armored ridges like a sunken log. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 7 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11689 · 354 · 283 · 248 · 283 · 135 |
| XP · gold | 3743 · 769 |
| Ring | 5 |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Stormreach\|Stormreach]], [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Tail Lash | aoe | 1.2 | 7 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_reptile_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Gale Crocodile Wyrm|Gale Crocodile Wyrm]]

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
