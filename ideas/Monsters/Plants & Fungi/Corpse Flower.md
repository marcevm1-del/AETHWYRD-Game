---
type: monster
id: mon_corpse_flower
family: "Plants & Fungi"
rank: "B"
tier: core
tags: [monster, plants-fungi]
---
# Corpse Flower

> The Corpse Flower is a large creature with a rooted plant body, about 4 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a rotting bloom the size of a cart. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 4 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12965 · 265 · 309 · 619 · 575 · 90 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Aurumdeep\|Aurumdeep]] |
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

## Loot (`loot_plant_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Blaze Corpse Flower|Blaze Corpse Flower]]

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
