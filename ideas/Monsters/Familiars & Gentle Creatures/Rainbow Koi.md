---
type: monster
id: mon_rainbow_koi
family: "Familiars & Gentle Creatures"
rank: "F"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Rainbow Koi

> The Rainbow Koi is a small creature with a streamlined aquatic body, about 0.5 m long. Its coat is smooth and clean, colored in deep blues with a glassy shine. Guild sketches always show scales that shimmer every color. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 214 · 53 · 38 · 38 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Lightning. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Breach Lunge | dash | 1.7 | 9 s | None | red |
| Thrash | aoe | 1.3 | 8 s | None | red |
| Playful Nudge | melee | 0.5 | 6 s | None | none |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_familiar_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Crag Koi|Crag Koi]]

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `fur_soft` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
