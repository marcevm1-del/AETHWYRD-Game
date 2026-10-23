---
type: monster
id: mon_frost_puffcap_mushroom
family: "Plants & Fungi"
rank: "F+"
tier: variant
tags: [monster, plants-fungi]
---
# Frost Puffcap Mushroom

> The Frost Puffcap Mushroom is a small creature with a mushroom-capped walking body, about 0.5 m tall. Its bark and leaves are smooth and clean, colored in pale blues and frost-white. Its most striking feature is a spotted cap that sneezes giggle-spores. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Puffcap Mushroom\|Puffcap Mushroom]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Ice · Fire |
| Size | 0.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 392 · 78 · 56 · 56 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
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
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_plant_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · circle-based, soft silhouette
