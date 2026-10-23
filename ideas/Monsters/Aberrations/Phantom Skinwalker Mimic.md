---
type: monster
id: mon_phantom_skinwalker_mimic
family: "Aberrations"
rank: "F+"
tier: variant
tags: [monster, aberrations]
---
# Phantom Skinwalker Mimic

> The Phantom Skinwalker Mimic is a person-sized creature with a tall, impossibly thin frame, about 1.8 m tall. Its skin is stretched, stitched and constantly shifting, colored in warm gold and pearl white. It calls you in your companion's voice. It has a human-like face in the wrong place. It has no ornament at all: simple, readable shapes. It copies the walk of whatever it hunts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Variant of | [[Monsters/Aberrations/Skinwalker Mimic\|Skinwalker Mimic]] (spirit) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 587 · 78 · 56 · 56 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Aldmere\|Aldmere]] |
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

## Loot (`loot_aberration_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · broken symmetry, mimicry, audio-first reveal
