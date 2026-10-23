---
type: monster
id: mon_meadow_goblin
family: "Goblinoids"
rank: "F"
tier: variant
tags: [monster, goblinoids]
---
# Meadow Goblin

> The Meadow Goblin is a small creature with a small, compact humanoid body, about 1 m tall. Its skin is rough, scarred and spiked, colored in pale jade and cloud white. Guild sketches always show a grin of needle teeth under a stolen tin helmet. It has eyes that catch torchlight like coins. It has no ornament at all: simple, readable shapes. It charges without hesitation, surrounded by swirling leaves and a constant breeze. Adapted to plains lands, it has golden, grass-toned coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin\|Goblin]] (regional) |
| Rank · level | F · 8 (3–13) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 1 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 224 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_goblinoid_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
