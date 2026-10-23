---
type: monster
id: mon_phantom_walking_mushroom
family: "Plants & Fungi"
rank: "F+"
tier: variant
tags: [monster, plants-fungi]
---
# Phantom Walking Mushroom

> The Phantom Walking Mushroom is a small creature with a walking body of bark and root, about 0.6 m tall. Its bark and leaves are weathered and natural, colored in warm gold and pearl white. Guild sketches always show a waddling cap on stubby legs. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It prowls, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Walking Mushroom\|Walking Mushroom]] (spirit) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 0.6 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 412 · 78 · 56 · 56 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Branch Sweep | melee | 1.1 | 0 s | None | blue |
| Root Slam | aoe | 1.5 | 9 s | None | red |
| Regrow | heal | 0 | 20 s | None | none |
| Root Bind | grab | 1 | 11 s | None | gold |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_plant_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · real-animal silhouette with one fantasy exaggeration
