---
type: monster
id: mon_salamander
family: "Reptiles"
rank: "D+"
tier: core
tags: [monster, reptiles]
---
# Salamander

> The Salamander is a person-sized creature with a powerful four-legged hunter's body, about 1.6 m long. Its scales are rough, scarred and spiked, colored in ember reds fading to soot black. Guild sketches always show a tail that burns like a torch. It has narrow glowing eyes. A distinctive marking runs along its back. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1.6 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4933 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Maul | melee | 1.2 | 0 s | None | blue |
| Pounce | dash | 1.6 | 6 s | None | red |
| Howl | buff | 0 | 18 s | None | none |
| Tail Lash | aoe | 1.2 | 7 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_reptile_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Phantom Salamander|Phantom Salamander]]

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `scale_matte` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
