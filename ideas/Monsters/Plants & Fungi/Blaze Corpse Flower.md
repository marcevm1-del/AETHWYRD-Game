---
type: monster
id: mon_blaze_corpse_flower
family: "Plants & Fungi"
rank: "B+"
tier: variant
tags: [monster, plants-fungi]
---
# Blaze Corpse Flower

> The Blaze Corpse Flower is a large creature with a huge bulbous flower on a thick stalk, about 4 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in ember reds fading to soot black. Survivors describe a rotting bloom the size of a cart. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It glides without moving its legs, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Corpse Flower\|Corpse Flower]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15171 · 294 · 343 · 686 · 637 · 90 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Xochitl Mire\|Xochitl Mire]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Vine Lash | melee | 1.1 | 0 s | None | blue |
| Snap Jaw | grab | 1.7 | 9 s | None | gold |
| Spore Burst | aoe | 1 | 10 s | None | blue |
| Root Bind | grab | 1 | 11 s | None | gold |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_plant_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · elongated, irregular silhouette; still-then-sudden timing
