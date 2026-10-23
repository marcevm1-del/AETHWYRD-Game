---
type: monster
id: mon_volt_smiling_scarecrow
family: "Constructs & Mimics"
rank: "F+"
tier: variant
tags: [monster, constructs-mimics]
---
# Volt Smiling Scarecrow

> The Volt Smiling Scarecrow is a person-sized creature with an upright humanoid build, about 2 m tall. Its surface is stretched, stitched and constantly shifting, colored in storm violet shot through with electric yellow. Survivors describe a stitched sack face with a painted smile that is never in the same field twice. It has too many eyes, opening one after another. It has no ornament at all: simple, readable shapes. It copies the walk of whatever it hunts, surrounded by crackling arcs that jump across its body. This Lightning-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Smiling Scarecrow\|Smiling Scarecrow]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 5 · Horror |
| Element · weakness | Lightning · Earth |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 670 · 74 · 62 · 50 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Earth. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Rune Pulse | magic | 1.3 | 10 s | None | red |
| Static Arc | magic | 1.5 | 10 s | Lightning | red |

## Loot (`loot_construct_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `stone_metal_runes` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · broken symmetry, mimicry, audio-first reveal
