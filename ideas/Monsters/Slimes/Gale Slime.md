---
type: monster
id: mon_gale_slime
family: "Slimes"
rank: "F+"
tier: variant
tags: [monster, slimes]
---
# Gale Slime

> The Gale Slime is a tiny creature with a wobbling mound of translucent gel, about 0.4 m tall. Its gel is smooth and clean, colored in pale jade and cloud white. Its most striking feature is fallen leaves suspended inside its jelly. It has big round glossy eyes. It has no ornament at all: simple, readable shapes. It waddles, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Green Slime\|Green Slime]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 259 · 50 · 37 · 37 · 37 · 110 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
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
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_slime_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
