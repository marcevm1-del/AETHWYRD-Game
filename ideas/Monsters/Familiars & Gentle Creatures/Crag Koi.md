---
type: monster
id: mon_crag_koi
family: "Familiars & Gentle Creatures"
rank: "F+"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Crag Koi

> The Crag Koi is a small creature with a long, finned body, about 0.5 m long. Its coat is smooth and clean, colored in ochre, clay and mossy stone. Survivors describe scales that shimmer every color. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by pebbles that tremble and float near it. Adapted to mountain lands, it has slate-grey coloring and hardened hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Rainbow Koi\|Rainbow Koi]] (regional) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Earth · Wind |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 392 · 78 · 56 · 56 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Wind. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Breach Lunge | dash | 1.7 | 9 s | None | red |
| Thrash | aoe | 1.3 | 8 s | None | red |
| Playful Nudge | melee | 0.5 | 6 s | None | none |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_familiar_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `fur_soft` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · circle-based, soft silhouette
