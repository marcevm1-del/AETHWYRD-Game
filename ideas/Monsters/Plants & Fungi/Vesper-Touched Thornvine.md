---
type: monster
id: mon_vesper_touched_thornvine
family: "Plants & Fungi"
rank: "D-"
tier: variant
tags: [monster, plants-fungi]
---
# Vesper-Touched Thornvine

> The Vesper-Touched Thornvine is a large creature with a cluster of vines around a central bloom, about 3 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in leaf greens over bark brown. Survivors describe vines covered in hooked thorns. It has eyes set slightly too far apart. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by drifting pollen and tiny blossoms. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Thornvine\|Thornvine]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Nature · Fire |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2711 · 102 · 119 · 238 · 221 · 90 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Vine Lash | melee | 1.1 | 0 s | None | blue |
| Snap Jaw | grab | 1.7 | 9 s | None | gold |
| Spore Burst | aoe | 1 | 10 s | None | blue |
| Root Bind | grab | 1 | 11 s | None | gold |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_plant_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · elongated, irregular silhouette; still-then-sudden timing
