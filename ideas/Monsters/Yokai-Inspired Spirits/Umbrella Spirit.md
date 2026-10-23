---
type: monster
id: mon_umbrella_spirit
family: "Yokai-Inspired Spirits"
rank: "F"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Umbrella Spirit

> The Umbrella Spirit is a small creature with a small, compact humanoid body, about 0.8 m tall. Its form is smooth and clean, colored in deep blues with a glassy shine. Survivors describe a one-eyed paper umbrella hopping on one leg. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.8 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 209 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 5 |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Lightning. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Spirit Flame | magic | 1.2 | 8 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_yokai_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched Umbrella Spirit|Vesper-Touched Umbrella Spirit]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `paper_ink_spirit` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
