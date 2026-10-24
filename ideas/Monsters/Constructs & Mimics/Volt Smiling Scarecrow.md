---
type: monster
id: mon_volt_smiling_scarecrow
family: "Constructs & Mimics"
rank: "F+"
tier: variant
tags: [monster, constructs-mimics]
---
# Volt Smiling Scarecrow

![[mon_volt_smiling_scarecrow_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_volt_smiling_scarecrow_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,770 tris · 1.207 × 1.483 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

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
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Earth. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (override (base species)); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 104 kg, gravity ×1.5, poise 53, knockback resistance 0.3, death style `ragdoll`.
- **Navigation:** speed 5.05 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 5; **signature:** a stitched sack face with a painted smile that is never in the same field twice.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Volt Smiling Scarecrow is a **horror construct** encountered at F+ rank, around level 13. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stitched sack face with a painted smile that is never in the same field twice. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics F|loot_construct_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | E, F+, F-, E-, E+ | 3–32 | Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | E-, F+, E, F-, F | 3–26 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04341` | Great Labyrinth (Floors 1-40) Volt Smiling Scarecrow Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E | 26 | 2.5 m | Night | Like a typical Volt Smiling Scarecrow, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04342` | Great Labyrinth (Floors 1-40) Volt Smiling Scarecrow | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F+ | 13 | 2 m | Night | A typical adult Volt Smiling Scarecrow of this region, with dust-grey coloring and old rune scars. |
| `pop_04343` | Aldmere Volt Smiling Scarecrow Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 2 m | Night | Like a typical Volt Smiling Scarecrow, but a rare pale form with white skin or fur and red eyes. |
| `pop_04344` | Great Labyrinth (Floors 1-40) Volt Smiling Scarecrow Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 1.4 m | Night | Like a typical Volt Smiling Scarecrow, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04345` | Aldmere Volt Smiling Scarecrow | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 2 m | Night | A typical adult Volt Smiling Scarecrow of this region, with dust-grey coloring and old rune scars. |
| `pop_04346` | Aldmere Volt Smiling Scarecrow Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 2.5 m | Night | Like a typical Volt Smiling Scarecrow, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04347` | Great Labyrinth (Floors 1-40) Volt Smiling Scarecrow Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E- | 19 | 2.2 m | Night | Like a typical Volt Smiling Scarecrow, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04348` | Aldmere Volt Smiling Scarecrow Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 1.4 m | Night | Like a typical Volt Smiling Scarecrow, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04349` | Great Labyrinth (Floors 1-40) Volt Smiling Scarecrow Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E+ | 32 | 2.7 m | Night | Like a typical Volt Smiling Scarecrow, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04350` | Great Labyrinth (Floors 1-40) Volt Smiling Scarecrow Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E- | 19 | 2 m | Night | Like a typical Volt Smiling Scarecrow, but a rare pale form with white skin or fur and red eyes. |
| `pop_04351` | Aldmere Volt Smiling Scarecrow Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 1.7 m | Night | Like a typical Volt Smiling Scarecrow, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `stone_metal_runes` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · broken symmetry, mimicry, audio-first reveal
