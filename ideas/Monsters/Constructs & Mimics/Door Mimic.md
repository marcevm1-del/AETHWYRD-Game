---
type: monster
id: mon_door_mimic
family: "Constructs & Mimics"
rank: "F"
tier: core
tags: [monster, constructs-mimics]
---
# Door Mimic

![[mon_door_mimic_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_door_mimic_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 2.194 × 2.529 × 2 m · local file `Game/Assets/_Game/Art/Models/Monsters/Constructs & Mimics/mon_door_mimic.fbx`

> The Door Mimic is a person-sized creature with a disguised body pretending to be furniture, about 2 m tall. Its surface is stretched, stitched and constantly shifting, colored in riveted iron. Guild sketches always show a dungeon door that breathes. It has too many eyes, opening one after another. It has no ornament at all: simple, readable shapes. It unfolds into something larger. It has no visible aura; you hear its breathing before you see it.

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
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_mimic` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_mimic`.
- **Dimensions:** 2 m high × 2.14 m long × 2.1 m wide; prefab scale 1.
- **Physics:** 240 kg, gravity ×1.2, poise 62, knockback resistance 0.6, death style `collapse_and_melt`.
- **Navigation:** speed 5.92 m/s, turn 354°/s, stopping distance 1 m.
- **Attack count:** 4; **signature:** a dungeon door that breathes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chomp\|Chomp]] | melee | 1.6 | 0 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tongue Lash\|Tongue Lash]] | grab | 1.4 | 6 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Disguise\|Disguise]] | stealth | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Door Mimic is a **horror construct** encountered at F rank, around level 8. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dungeon door that breathes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_mimic`, animation set `anim_mimic`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics F|loot_construct_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Vesper-Touched Door Mimic|Vesper-Touched Door Mimic]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 3 | F+, E- | 13–19 | Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | F-, F+, E- | 3–19 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | F-, F | 3–8 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01451` | Whisperwood Door Mimic Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 2.2 m | Night | Like a typical Door Mimic, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01452` | Aldmere Door Mimic Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 1.4 m | Night | Like a typical Door Mimic, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01453` | Great Labyrinth (Floors 1-40) Door Mimic Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 1.4 m | Night | Like a typical Door Mimic, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01454` | Whisperwood Door Mimic Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 2 m | Night | Like a typical Door Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_01455` | Aldmere Door Mimic Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 2.2 m | Night | Like a typical Door Mimic, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01456` | Great Labyrinth (Floors 1-40) Door Mimic | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F | 8 | 2 m | Night | A typical adult Door Mimic of this region, with dust-grey coloring and old rune scars. |
| `pop_01457` | Aldmere Door Mimic Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 2.5 m | Night | Like a typical Door Mimic, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01458` | Whisperwood Door Mimic Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 2.5 m | Night | Like a typical Door Mimic, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01459` | Great Labyrinth (Floors 1-40) Door Mimic Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | F- | 3 | 1.7 m | Night | Like a typical Door Mimic, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01460` | Aldmere Door Mimic Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 1.7 m | Night | Like a typical Door Mimic, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01461` | Aldmere Door Mimic Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 2 m | Night | Like a typical Door Mimic, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#6c727a` `#4b5058` `#9aa2ae` · broken symmetry, mimicry, audio-first reveal
