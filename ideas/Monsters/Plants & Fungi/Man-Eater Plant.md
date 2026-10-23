---
type: monster
id: mon_man_eater_plant
family: "Plants & Fungi"
rank: "D"
tier: core
tags: [monster, plants-fungi]
---
# Man-Eater Plant

> The Man-Eater Plant is a large creature with a rooted plant body, about 2.5 m tall. Its bark and leaves are rough, scarred and spiked, colored in leaf greens over bark brown. Guild sketches always show a flower with jaws made of petals. It has narrow glowing eyes. A distinctive marking runs along its back. It charges without hesitation, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 2.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3330 · 121 · 141 · 283 · 263 · 90 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
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

## Variants

- [[Monsters/Plants & Fungi/Vine Man-Eater Plant|Vine Man-Eater Plant]]

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
