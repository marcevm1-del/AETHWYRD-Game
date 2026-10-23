---
type: monster
id: mon_grin_in_the_walls
family: "Aberrations"
rank: "D"
tier: core
tags: [monster, aberrations]
---
# Grin in the Walls

> The Grin in the Walls is a small creature with a hollow shell posing as an everyday object, about 1 m tall. Its skin is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Only its smile is ever visible. It has too many eyes, opening one after another. A distinctive marking runs along its back. It unfolds into something larger, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | D · 48 (40–56) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 1 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3053 · 253 · 182 · 182 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chomp | melee | 1.6 | 0 s | None | red |
| Tongue Lash | grab | 1.4 | 6 s | None | gold |
| Disguise | stealth | 0 | 20 s | None | none |
| Mimic Lure | debuff | 0 | 16 s | None | none |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_aberration_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aberrations/Storm Grin in the Walls|Storm Grin in the Walls]]

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `wet_flesh_unsettling` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
