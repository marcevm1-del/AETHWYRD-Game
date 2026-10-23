---
type: monster
id: mon_pixie
family: "Elementals & Spirits"
rank: "E"
tier: core
tags: [monster, elementals-spirits]
---
# Pixie

> The Pixie is a tiny creature with a small winged body, about 0.2 m tall. Its body is smooth and clean, colored in pale jade and cloud white. Its most striking feature is dragonfly wings and a mischievous grin. It has wide curious eyes with star-shaped highlights. Small scars and rough edges mark it as a survivor. It waddles, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 0.2 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 712 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Mossdeep\|Mossdeep]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nip | melee | 0.9 | 0 s | None | blue |
| Dart | dash | 1.1 | 4 s | None | blue |
| Swarm Call | summon | 0 | 20 s | None | none |
| Elemental Burst | magic | 1.4 | 9 s | None | red |
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_elemental_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Elder Pixie|Elder Pixie]]

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `elemental_emissive` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
