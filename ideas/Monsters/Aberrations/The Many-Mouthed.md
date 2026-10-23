---
type: monster
id: mon_the_many_mouthed
family: "Aberrations"
rank: "B"
tier: core
tags: [monster, aberrations]
---
# The Many-Mouthed

> The The Many-Mouthed is a large creature with an asymmetric body with too many limbs, about 4 m tall. Its skin is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Its most striking feature is mouths opening along its arms, all whispering. It has no eyes at all, only a wide and patient mouth. Faint runes glow along its body when it fights. It copies the walk of whatever it hunts, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | B · 108 (96–120) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 4 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16206 · 553 · 398 · 398 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Hollow Sea\|Hollow Sea]], [[Regions/Umbravel\|Umbravel]], [[Regions/Strife Marches\|Strife Marches]] |
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

## Variants

- [[Monsters/Aberrations/Phantom The Many-Mouthed|Phantom The Many-Mouthed]]

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
