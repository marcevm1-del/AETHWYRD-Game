---
type: monster
id: mon_saboteur_gremlin
family: "Gremlins"
rank: "E"
tier: core
tags: [monster, gremlins]
---
# Saboteur Gremlin

> The Saboteur Gremlin is a small creature with a hunched, wiry humanoid frame, about 0.7 m tall. Its skin is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Guild sketches always show goggles and a bag of stolen bolts. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 0.7 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 953 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
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

## Loot (`loot_gremlin_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Gremlins/Vesper-Touched Saboteur Gremlin|Vesper-Touched Saboteur Gremlin]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
