---
type: monster
id: mon_rime_hatchling
family: "Dragons"
rank: "F+"
tier: variant
tags: [monster, dragons]
---
# Rime Hatchling

> The Rime Hatchling is a small creature with an ancient, serpentine dragon body, about 0.5 m long. Its scales are smooth and clean, colored in pale blues and frost-white. Look for a too-big head and wings it can't use yet. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by falling snow motes and frosted ground where it steps. Adapted to tundra lands, it has a thick, frost-rimed coat.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Hatchling\|Hatchling]] (regional) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Ice · Fire |
| Size | 0.5 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 588 · 81 · 74 · 81 · 74 · 100 |
| XP · gold | 190 · 57 |
| Ring | 4 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Lirian\|Lirian]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Claw | melee | 1.4 | 0 s | None | blue |
| Breath | aoe | 2.2 | 14 s | None | red |
| Wing Gust | aoe | 1 | 10 s | None | blue |
| Tail Blade | melee | 1.8 | 8 s | None | red |
| Wing Buffet | aoe | 1.1 | 9 s | None | blue |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_draconic_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · circle-based, soft silhouette
