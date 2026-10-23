---
type: monster
id: mon_treant_sapling
family: "Plants & Fungi"
rank: "D"
tier: core
tags: [monster, plants-fungi]
---
# Treant Sapling

> The Treant Sapling is a person-sized creature with a mushroom-capped walking body, about 2 m tall. Its bark and leaves are smooth and clean, colored in leaf greens over bark brown. Its most striking feature is a young tree with a sleepy face. It has two bright dot eyes. A distinctive marking runs along its back. It hops in little bursts, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | D · 48 (40–56) |
| Menace | 1 · Charming |
| Element · weakness | Nature · Fire |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3857 · 253 · 182 · 182 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Mossdeep\|Mossdeep]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Branch Sweep | melee | 1.1 | 0 s | None | blue |
| Root Slam | aoe | 1.5 | 9 s | None | red |
| Regrow | heal | 0 | 20 s | None | none |
| Root Bind | grab | 1 | 11 s | None | gold |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_plant_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Bog Treant Sapling|Bog Treant Sapling]]

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · circle-based, soft silhouette
