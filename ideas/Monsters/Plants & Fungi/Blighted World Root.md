---
type: monster
id: mon_blighted_world_root
family: "Plants & Fungi"
rank: "EX"
tier: core
tags: [monster, plants-fungi, unique]
---
# Blighted World Root

> The Blighted World Root is a colossal creature with a huge bulbous flower on a thick stalk, about 300 m tall. Its bark and leaves are stretched, stitched and constantly shifting, colored in ink black with bruised violet. Guild sketches always show black roots that pulse like veins. It has no eyes at all, only a wide and patient mouth. Its presence is world-scale; the sky changes color when it appears. It unfolds into something larger, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | EX · 300 (300–300) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 300 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 131111 · 726 · 847 · 1694 · 1573 · 90 |
| XP · gold | 551660 · 4409 |
| Ring | 3 |
| Habitats | [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Vine Lash | melee | 1.1 | 0 s | None | blue |
| Snap Jaw | grab | 1.7 | 9 s | None | gold |
| Spore Burst | aoe | 1 | 10 s | None | blue |
| Root Bind | grab | 1 | 11 s | None | gold |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_plant_ex`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
