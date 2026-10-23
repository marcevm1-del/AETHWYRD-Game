---
type: monster
id: mon_smiling_scarecrow
family: "Constructs & Mimics"
rank: "F"
tier: core
tags: [monster, constructs-mimics]
---
# Smiling Scarecrow

> The Smiling Scarecrow is a person-sized creature with a broad-shouldered humanoid build, about 2 m tall. Its surface is stretched, stitched and constantly shifting, colored in muted greys and dusty browns. Look for a stitched sack face with a painted smile that is never in the same field twice. It has a human-like face in the wrong place. It has no ornament at all: simple, readable shapes. It crawls across ceilings. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | F · 8 (3–13) |
| Menace | 5 · Horror |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 366 · 50 · 42 · 24 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Rune Pulse | magic | 1.3 | 10 s | None | red |

## Loot (`loot_construct_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Volt Smiling Scarecrow|Volt Smiling Scarecrow]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · broken symmetry, mimicry, audio-first reveal
