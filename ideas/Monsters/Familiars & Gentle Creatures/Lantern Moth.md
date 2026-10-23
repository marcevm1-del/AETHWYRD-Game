---
type: monster
id: mon_lantern_moth
family: "Familiars & Gentle Creatures"
rank: "F"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Lantern Moth

> The Lantern Moth is a tiny creature with a small winged body, about 0.3 m tall. Its coat is smooth and clean, colored in warm gold and pearl white. Survivors describe wings that glow like paper lanterns. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It waddles, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 161 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nip | melee | 0.9 | 0 s | None | blue |
| Dart | dash | 1.1 | 4 s | None | blue |
| Swarm Call | summon | 0 | 20 s | None | none |
| Playful Nudge | melee | 0.5 | 6 s | None | none |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_familiar_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Elder Lantern Moth|Elder Lantern Moth]]

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `fur_soft` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
