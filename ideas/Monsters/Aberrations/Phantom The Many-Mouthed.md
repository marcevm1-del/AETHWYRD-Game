---
type: monster
id: mon_phantom_the_many_mouthed
family: "Aberrations"
rank: "B+"
tier: variant
tags: [monster, aberrations]
---
# Phantom The Many-Mouthed

> The Phantom The Many-Mouthed is a large creature with a shape that keeps rearranging itself, about 4 m tall. Its skin is stretched, stitched and constantly shifting, colored in warm gold and pearl white. Look for mouths opening along its arms, all whispering. It has no eyes at all, only a wide and patient mouth. Faint runes glow along its body when it fights. It copies the walk of whatever it hunts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Variant of | [[Monsters/Aberrations/The Many-Mouthed\|The Many-Mouthed]] (spirit) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18964 · 613 · 441 · 441 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Everdusk\|Everdusk]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Grasp | melee | 1.2 | 0 s | None | blue |
| Unfold | aoe | 1.8 | 12 s | None | red |
| Mimic Voice | debuff | 0 | 18 s | None | none |
| Mimic Lure | debuff | 0 | 16 s | None | none |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_aberration_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · broken symmetry, mimicry, audio-first reveal
