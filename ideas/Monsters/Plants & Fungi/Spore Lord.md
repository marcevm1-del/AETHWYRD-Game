---
type: monster
id: mon_spore_lord
family: "Plants & Fungi"
rank: "C"
tier: core
tags: [monster, plants-fungi]
---
# Spore Lord

> The Spore Lord is a large creature with a walking body of bark and root, about 3 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe a mushroom crown and a cloak of mycelium. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8733 · 393 · 283 · 283 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Branch Sweep | melee | 1.1 | 0 s | None | blue |
| Root Slam | aoe | 1.5 | 9 s | None | red |
| Regrow | heal | 0 | 20 s | None | none |
| Root Bind | grab | 1 | 11 s | None | gold |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_plant_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Bog Spore Lord|Bog Spore Lord]]

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
