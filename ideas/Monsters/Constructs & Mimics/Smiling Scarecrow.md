---
type: monster
id: mon_smiling_scarecrow
family: "Constructs & Mimics"
rank: "F"
tier: core
tags: [monster, constructs-mimics]
---
# Smiling Scarecrow

![[mon_smiling_scarecrow_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_smiling_scarecrow_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,472 tris · 1.063 × 0.907 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Smiling Scarecrow is a person-sized creature with a broad-shouldered humanoid build, about 2 m tall. Its surface is stretched, stitched and constantly shifting, colored in bronze. Look for a stitched sack face with a painted smile that is never in the same field twice. It has a human-like face in the wrong place. It has no ornament at all: simple, readable shapes. It crawls across ceilings. It has no visible aura; you hear its breathing before you see it.

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
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (override); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 36.4 kg, gravity ×1.5, poise 53, knockback resistance 0.3, death style `ragdoll`.
- **Navigation:** speed 4.68 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 4; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Smiling Scarecrow is a **horror construct** encountered at F rank, around level 8. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stitched sack face with a painted smile that is never in the same field twice. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics F|loot_construct_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Volt Smiling Scarecrow|Volt Smiling Scarecrow]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | F+, E, F-, F, E- | 3–26 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 4 | F, F+, F- | 3–13 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01462` | Aldmere Smiling Scarecrow Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 2 m | Night | Like a typical Smiling Scarecrow, but a rare pale form with white skin or fur and red eyes. |
| `pop_01463` | Aldmere Smiling Scarecrow Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 2.7 m | Night | Like a typical Smiling Scarecrow, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01464` | Aldmere Smiling Scarecrow Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 1.4 m | Night | Like a typical Smiling Scarecrow, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01465` | Aldmere Smiling Scarecrow Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 2.2 m | Night | Like a typical Smiling Scarecrow, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01466` | Aldmere Smiling Scarecrow | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 2 m | Night | A typical adult Smiling Scarecrow of this region, with dust-grey coloring and old rune scars. |
| `pop_01467` | Whisperwood Smiling Scarecrow | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 2 m | Night | A typical adult Smiling Scarecrow of this region, with dust-grey coloring and old rune scars. |
| `pop_01468` | Whisperwood Smiling Scarecrow Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 2.2 m | Night | Like a typical Smiling Scarecrow, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01469` | Whisperwood Smiling Scarecrow Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 1.7 m | Night | Like a typical Smiling Scarecrow, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01470` | Aldmere Smiling Scarecrow Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 2.5 m | Night | Like a typical Smiling Scarecrow, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01471` | Aldmere Smiling Scarecrow Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 1.7 m | Night | Like a typical Smiling Scarecrow, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01472` | Whisperwood Smiling Scarecrow Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 2 m | Night | Like a typical Smiling Scarecrow, but a rare pale form with white skin or fur and red eyes. |

## Contracts and story encounters

- [[Quests/Night of the Smiling Scarecrow|Night of the Smiling Scarecrow]] — rank E, in [[Regions/Aldmere|Aldmere]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#9e6946` `#64432d` `#f4ae6b` · broken symmetry, mimicry, audio-first reveal
