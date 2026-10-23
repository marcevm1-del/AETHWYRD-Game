---
type: monster
id: mon_mud_doll
family: "Constructs & Mimics"
rank: "F"
tier: core
tags: [monster, constructs-mimics]
---
# Mud Doll

> The Mud Doll is a small creature with a scrawny biped with long arms and bowed legs, about 0.8 m tall. Its surface is smooth and clean, colored in ochre, clay and mossy stone. Look for a child's clay figure with thumbprint eyes. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Earth · Wind |
| Size | 0.8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 209 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Rune Pulse | magic | 1.3 | 10 s | None | red |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_construct_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Greater Mud Doll|Greater Mud Doll]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `stone_metal_runes` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · circle-based, soft silhouette
