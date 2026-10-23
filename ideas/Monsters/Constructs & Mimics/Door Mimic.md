---
type: monster
id: mon_door_mimic
family: "Constructs & Mimics"
rank: "F"
tier: core
tags: [monster, constructs-mimics]
---
# Door Mimic

> The Door Mimic is a person-sized creature with a disguised body pretending to be furniture, about 2 m tall. Its surface is stretched, stitched and constantly shifting, colored in muted greys and dusty browns. Guild sketches always show a dungeon door that breathes. It has too many eyes, opening one after another. It has no ornament at all: simple, readable shapes. It unfolds into something larger. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | F · 8 (3–13) |
| Menace | 5 · Horror |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 333 · 53 · 38 · 26 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chomp | melee | 1.6 | 0 s | None | red |
| Tongue Lash | grab | 1.4 | 6 s | None | gold |
| Disguise | stealth | 0 | 20 s | None | none |
| Rune Pulse | magic | 1.3 | 10 s | None | red |

## Loot (`loot_construct_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Vesper-Touched Door Mimic|Vesper-Touched Door Mimic]]

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · broken symmetry, mimicry, audio-first reveal
