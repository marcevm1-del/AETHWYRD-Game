---
type: monster
id: mon_tide_elder_treant
family: "Plants & Fungi"
rank: "A+"
tier: variant
tags: [monster, plants-fungi]
---
# Tide Elder Treant

> The Tide Elder Treant is a huge creature with a mushroom-capped walking body, about 12 m tall. Its bark and leaves are weathered and natural, colored in deep blues with a glassy shine. Guild sketches always show a moss beard and owls living in its branches. It has dark, wary eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It lopes in long strides, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Elder Treant\|Elder Treant]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 12 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 40104 · 808 · 581 · 581 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 5 |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Branch Sweep | melee | 1.1 | 0 s | None | blue |
| Root Slam | aoe | 1.5 | 9 s | None | red |
| Regrow | heal | 0 | 20 s | None | none |
| Root Bind | grab | 1 | 11 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_plant_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
