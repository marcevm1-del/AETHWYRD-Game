---
type: monster
id: mon_mandrake
family: "Plants & Fungi"
rank: "F"
tier: core
tags: [monster, plants-fungi]
---
# Mandrake

> The Mandrake is a tiny creature with a tall, tree-like walking frame, about 0.3 m tall. Its bark and leaves are weathered and natural, colored in leaf greens over bark brown. Its most striking feature is a screaming root with a leafy tuft. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It lopes in long strides, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 0.3 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 190 · 53 · 38 · 38 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Branch Sweep | melee | 1.1 | 0 s | None | blue |
| Root Slam | aoe | 1.5 | 9 s | None | red |
| Regrow | heal | 0 | 20 s | None | none |
| Root Bind | grab | 1 | 11 s | None | gold |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_plant_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Ancient Mandrake|Ancient Mandrake]]

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · real-animal silhouette with one fantasy exaggeration
