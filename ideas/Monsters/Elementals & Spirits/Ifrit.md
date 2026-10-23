---
type: monster
id: mon_ifrit
family: "Elementals & Spirits"
rank: "B"
tier: core
tags: [monster, elementals-spirits]
---
# Ifrit

> The Ifrit is a huge creature with a drifting, half-formed body, about 5 m tall. Its body is rough, scarred and spiked, colored in ember reds fading to soot black. Look for a torso of fire rising from a smoking lamp. It has narrow glowing eyes. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13927 · 265 · 309 · 619 · 575 · 90 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Elemental Burst | magic | 1.4 | 9 s | None | red |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_elemental_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Phantom Ifrit|Phantom Ifrit]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
