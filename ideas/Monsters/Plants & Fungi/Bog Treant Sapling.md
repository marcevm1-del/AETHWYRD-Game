---
type: monster
id: mon_bog_treant_sapling
family: "Plants & Fungi"
rank: "D+"
tier: variant
tags: [monster, plants-fungi]
---
# Bog Treant Sapling

> The Bog Treant Sapling is a person-sized creature with a walking body of bark and root, about 2 m tall. Its bark and leaves are smooth and clean, colored in bruise purple with sickly green. Guild sketches always show a young tree with a sleepy face. It has wide curious eyes with star-shaped highlights. A distinctive marking runs along its back. It hops in little bursts, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Treant Sapling\|Treant Sapling]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 1 · Charming |
| Element · weakness | Poison · Light |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4840 · 293 · 211 · 211 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Branch Sweep | melee | 1.1 | 0 s | None | blue |
| Root Slam | aoe | 1.5 | 9 s | None | red |
| Regrow | heal | 0 | 20 s | None | none |
| Root Bind | grab | 1 | 11 s | None | gold |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_plant_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · circle-based, soft silhouette
