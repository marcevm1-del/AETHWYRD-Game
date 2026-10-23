---
type: monster
id: mon_lizardman
family: "Reptiles"
rank: "D"
tier: core
tags: [monster, reptiles]
---
# Lizardman

> The Lizardman is a person-sized creature with a lean humanoid frame, about 2 m tall. Its scales are weathered and natural, colored in deep blues with a glassy shine. Survivors describe a proud crest and a coral-tipped spear. It has dark, wary eyes. A distinctive marking runs along its back. It stalks low to the ground, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4242 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Tail Lash | aoe | 1.2 | 7 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_reptile_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Ancient Lizardman|Ancient Lizardman]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `scale_matte` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
