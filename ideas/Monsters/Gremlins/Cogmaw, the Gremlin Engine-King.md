---
type: monster
id: mon_cogmaw_the_gremlin_engine_king
family: "Gremlins"
rank: "A"
tier: core
tags: [monster, gremlins, tyrant, unique]
---
# Cogmaw, the Gremlin Engine-King

> The Cogmaw, the Gremlin Engine-King is a large creature with a small, compact humanoid body, about 3 m tall. Its skin is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Look for a throne bolted onto a walking furnace that eats machines. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 3 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 19643 · 594 · 475 · 416 · 475 · 135 |
| XP · gold | 174387 · 1611 |
| Ring | 7 |
| Habitats | [[Regions/Gearholm\|Gearholm]] |
| Tyrant | Yes |
| Genre | Steampunk Mischief |
| Trope | Machine-breaking pests |

**Field note:** Weak to Earth. Flees when hurt. Snares or ranged attacks work best.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Wrench Sabotage | debuff | 0 | 14 s | None | none |
| Static Arc | magic | 1.5 | 10 s | Lightning | red |

## Loot (`loot_gremlin_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
