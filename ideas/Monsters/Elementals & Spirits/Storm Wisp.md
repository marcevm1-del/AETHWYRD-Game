---
type: monster
id: mon_storm_wisp
family: "Elementals & Spirits"
rank: "F+"
tier: variant
tags: [monster, elementals-spirits]
---
# Storm Wisp

> The Storm Wisp is a tiny creature with a floating, cloth-like shape, about 0.3 m tall. Its body is smooth and clean, colored in storm violet shot through with electric yellow. Survivors describe a floating ball of soft light. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by crackling arcs that jump across its body. This Lightning-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Wisp\|Wisp]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Lightning · Earth |
| Size | 0.3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 278 · 37 · 43 · 87 · 81 · 90 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Habitats | [[Regions/Whisperwood\|Whisperwood]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Earth. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Elemental Burst | magic | 1.4 | 9 s | None | red |
| Static Arc | magic | 1.5 | 10 s | Lightning | red |

## Loot (`loot_elemental_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · circle-based, soft silhouette
