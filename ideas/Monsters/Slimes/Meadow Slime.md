---
type: monster
id: mon_meadow_slime
family: "Slimes"
rank: "F"
tier: variant
tags: [monster, slimes]
---
# Meadow Slime

> The Meadow Slime is a tiny creature with a teardrop-shaped jelly body, about 0.4 m tall. Its gel is smooth and clean, colored in pale jade and cloud white. Survivors describe a teardrop body with a glossy highlight and two dot eyes. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It waddles, surrounded by swirling leaves and a constant breeze. Adapted to plains lands, it has golden, grass-toned coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Blue Slime\|Blue Slime]] (regional) |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 0.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 142 · 34 · 25 · 25 · 25 · 110 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_slime_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
