---
type: monster
id: mon_vesper_touched_faceless_one
family: "Aberrations"
rank: "B-"
tier: variant
tags: [monster, aberrations]
---
# Vesper-Touched Faceless One

> The Vesper-Touched Faceless One is a person-sized creature with an asymmetric body with too many limbs, about 2.2 m tall. Its skin is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Look for a smooth blank face that slowly learns to look like yours. It has no eyes at all, only a wide and patient mouth. Faint runes glow along its body when it fights. It crawls across ceilings, surrounded by warped air, as if space bends around it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Variant of | [[Monsters/Aberrations/Faceless One\|Faceless One]] (corrupted) |
| Rank · level | B- · 96 (86–108) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 2.2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11127 · 493 · 355 · 355 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 6 |
| Habitats | [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Grasp | melee | 1.2 | 0 s | None | blue |
| Unfold | aoe | 1.8 | 12 s | None | red |
| Mimic Voice | debuff | 0 | 18 s | None | none |
| Mimic Lure | debuff | 0 | 16 s | None | none |
| Null Rift | magic | 1.5 | 10 s | Void | red |

## Loot (`loot_aberration_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
