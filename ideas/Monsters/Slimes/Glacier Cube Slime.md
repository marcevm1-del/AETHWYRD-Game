---
type: monster
id: mon_glacier_cube_slime
family: "Slimes"
rank: "D+"
tier: variant
tags: [monster, slimes]
---
# Glacier Cube Slime

> The Glacier Cube Slime is a small creature with a dome-shaped gelatinous body, about 0.8 m tall. Its gel is weathered and natural, colored in pale blues and frost-white. Survivors describe a perfectly cubic body with swallowed debris visible inside. It has amber predator eyes. A distinctive marking runs along its back. It stalks low to the ground, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Cube Slime\|Cube Slime]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 2 · Wild |
| Element · weakness | Ice · Fire |
| Size | 0.8 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2499 · 187 · 140 · 140 · 140 · 110 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_slime_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · real-animal silhouette with one fantasy exaggeration
