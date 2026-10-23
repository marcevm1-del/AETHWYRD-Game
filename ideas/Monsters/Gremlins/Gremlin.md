---
type: monster
id: mon_gremlin
family: "Gremlins"
rank: "F"
tier: core
tags: [monster, gremlins]
---
# Gremlin

> The Gremlin is a small creature with a scrawny biped with long arms and bowed legs, about 0.6 m tall. Its skin is weathered and natural, colored in storm violet shot through with electric yellow. Its most striking feature is bat ears, a wrench and a laugh like a squeaky hinge. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It prowls, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Lightning · Earth |
| Size | 0.6 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 192 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
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

## Loot (`loot_gremlin_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Gremlins/Ancient Gremlin|Ancient Gremlin]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · real-animal silhouette with one fantasy exaggeration
