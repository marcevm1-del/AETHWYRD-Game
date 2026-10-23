---
type: monster
id: mon_mycelia_the_spore_lord
family: "Plants & Fungi"
rank: "B+"
tier: core
tags: [monster, plants-fungi, tyrant, unique]
---
# Mycelia, the Spore Lord

> The Mycelia, the Spore Lord is a huge creature with a tall, tree-like walking frame, about 5 m tall. Its bark and leaves are patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Look for a crown of glowing fungus fed by the World Tree's Blight. It has eyes that never blink. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 5 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20372 · 613 · 441 · 441 · 441 · 100 |
| XP · gold | 127464 · 1225 |
| Ring | 3 |
| Habitats | [[Regions/Sylvaran\|Sylvaran]] |
| Tyrant | Yes |
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

## Loot (`loot_plant_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
