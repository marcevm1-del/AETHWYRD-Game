---
type: monster
id: mon_faceless_one
family: "Aberrations"
rank: "C"
tier: core
tags: [monster, aberrations]
---
# Faceless One

> The Faceless One is a person-sized creature with a shape that keeps rearranging itself, about 2.2 m tall. Its skin is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Look for a smooth blank face that slowly learns to look like yours. It has too many eyes, opening one after another. Battle-worn plates and trophies hang from its body. It crawls across ceilings, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | C · 76 (65–86) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 2.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7861 · 393 · 283 · 283 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Hollow Sea\|Hollow Sea]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Grasp | melee | 1.2 | 0 s | None | blue |
| Unfold | aoe | 1.8 | 12 s | None | red |
| Mimic Voice | debuff | 0 | 18 s | None | none |
| Mimic Lure | debuff | 0 | 16 s | None | none |
| Null Rift | magic | 1.5 | 10 s | Void | red |

## Loot (`loot_aberration_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aberrations/Vesper-Touched Faceless One|Vesper-Touched Faceless One]]

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
