---
type: monster
id: mon_vesper_touched_door_mimic
family: "Constructs & Mimics"
rank: "E-"
tier: variant
tags: [monster, constructs-mimics]
---
# Vesper-Touched Door Mimic

> The Vesper-Touched Door Mimic is a person-sized creature with a disguised body pretending to be furniture, about 2 m tall. Its surface is stretched, stitched and constantly shifting, colored in arterial crimson and dried-blood brown. Guild sketches always show a dungeon door that breathes. It has no eyes at all, only a wide and patient mouth. Small scars and rough edges mark it as a survivor. It copies the walk of whatever it hunts, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Door Mimic\|Door Mimic]] (corrupted) |
| Rank · level | E- · 19 (13–26) |
| Menace | 5 · Horror |
| Element · weakness | Blood · Light |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1017 · 108 · 77 · 77 · 77 · 100 |
| XP · gold | 342 · 96 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chomp | melee | 1.6 | 0 s | None | red |
| Tongue Lash | grab | 1.4 | 6 s | None | gold |
| Disguise | stealth | 0 | 20 s | None | none |
| Rune Pulse | magic | 1.3 | 10 s | None | red |
| Blood Lance | magic | 1.5 | 10 s | Blood | red |

## Loot (`loot_construct_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · broken symmetry, mimicry, audio-first reveal
