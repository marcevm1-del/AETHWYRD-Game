---
type: monster
id: mon_vesper_touched_door_mimic
family: "Constructs & Mimics"
rank: "E-"
tier: variant
tags: [monster, constructs-mimics]
---
# Vesper-Touched Door Mimic

![[mon_vesper_touched_door_mimic_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_door_mimic_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (818 tris · 1.969 × 2.12 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

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
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_mimic` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_mimic`.
- **Dimensions:** 2 m high × 2.14 m long × 2.1 m wide; prefab scale 1.
- **Physics:** 264 kg, gravity ×1.2, poise 74, knockback resistance 0.63, death style `collapse_and_melt`.
- **Navigation:** speed 5.92 m/s, turn 354°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** a dungeon door that breathes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chomp\|Chomp]] | melee | 1.6 | 0 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tongue Lash\|Tongue Lash]] | grab | 1.4 | 6 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Disguise\|Disguise]] | stealth | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Door Mimic is a **horror construct** encountered at E- rank, around level 19. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dungeon door that breathes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_mimic`, animation set `anim_mimic`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics E|loot_construct_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 3 | E, F, F+ | 8–26 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | E, D-, E+ | 26–40 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | F+, E, D-, E- | 13–40 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04330` | Whisperwood Vesper-Touched Door Mimic Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E | 26 | 2.2 m | Night | Like a typical Vesper-Touched Door Mimic, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04331` | Aldmere Vesper-Touched Door Mimic Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E | 26 | 2 m | Night | Like a typical Vesper-Touched Door Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_04332` | Great Labyrinth (Floors 1-40) Vesper-Touched Door Mimic Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | F+ | 13 | 1.7 m | Night | Like a typical Vesper-Touched Door Mimic, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04333` | Great Labyrinth (Floors 1-40) Vesper-Touched Door Mimic Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E | 26 | 2 m | Night | Like a typical Vesper-Touched Door Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_04334` | Aldmere Vesper-Touched Door Mimic Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D- | 40 | 2.7 m | Night | Like a typical Vesper-Touched Door Mimic, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04335` | Great Labyrinth (Floors 1-40) Vesper-Touched Door Mimic Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D- | 40 | 2.7 m | Night | Like a typical Vesper-Touched Door Mimic, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04336` | Aldmere Vesper-Touched Door Mimic Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E+ | 32 | 2.5 m | Night | Like a typical Vesper-Touched Door Mimic, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04337` | Whisperwood Vesper-Touched Door Mimic Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F | 8 | 1.4 m | Night | Like a typical Vesper-Touched Door Mimic, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04338` | Aldmere Vesper-Touched Door Mimic Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E | 26 | 2.2 m | Night | Like a typical Vesper-Touched Door Mimic, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04339` | Great Labyrinth (Floors 1-40) Vesper-Touched Door Mimic | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E- | 19 | 2 m | Night | A typical adult Vesper-Touched Door Mimic of this region, with dust-grey coloring and old rune scars. |
| `pop_04340` | Whisperwood Vesper-Touched Door Mimic Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F+ | 13 | 1.7 m | Night | Like a typical Vesper-Touched Door Mimic, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · broken symmetry, mimicry, audio-first reveal
