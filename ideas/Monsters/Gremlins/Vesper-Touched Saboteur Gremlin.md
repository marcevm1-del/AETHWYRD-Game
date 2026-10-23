---
type: monster
id: mon_vesper_touched_saboteur_gremlin
family: "Gremlins"
rank: "D-"
tier: variant
tags: [monster, gremlins]
---
# Vesper-Touched Saboteur Gremlin

> The Vesper-Touched Saboteur Gremlin is a small creature with a scrawny biped with long arms and bowed legs, about 0.7 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in storm violet shot through with electric yellow. Its most striking feature is goggles and a bag of stolen bolts. It has pale, pupil-less eyes. A distinctive marking runs along its back. It glides without moving its legs, surrounded by crackling arcs that jump across its body. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Variant of | [[Monsters/Gremlins/Saboteur Gremlin\|Saboteur Gremlin]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Lightning · Earth |
| Size | 0.7 m |
| Behaviour | Skittish (skittish_flee+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1777 · 170 · 136 · 119 · 136 · 135 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Habitats | [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]] |
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

## Loot (`loot_gremlin_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · elongated, irregular silhouette; still-then-sudden timing
