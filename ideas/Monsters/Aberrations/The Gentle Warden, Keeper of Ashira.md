---
type: monster
id: mon_the_gentle_warden_keeper_of_ashira
family: "Aberrations"
rank: "B+"
tier: core
tags: [monster, aberrations, tyrant, unique]
---
# The Gentle Warden, Keeper of Ashira

> The The Gentle Warden, Keeper of Ashira is a person-sized creature with a shape that keeps rearranging itself, about 2.1 m tall. Its skin is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Survivors describe a smiling elder with a face too smooth, who tests the village children. It has too many eyes, opening one after another. Faint runes glow along its body when it fights. It copies the walk of whatever it hunts, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | B+ · 120 (108–132) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 2.1 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15274 · 613 · 441 · 441 · 441 · 100 |
| XP · gold | 127464 · 1225 |
| Ring | 6 |
| Habitats | [[Regions/Ashira Vale\|Ashira Vale]] |
| Tyrant | Yes |
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
