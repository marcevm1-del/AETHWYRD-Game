---
type: monster
id: mon_mud_doll
family: "Constructs & Mimics"
rank: "F"
tier: core
tags: [monster, constructs-mimics]
---
# Mud Doll

![[mon_mud_doll_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mud_doll_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,994 tris · 0.459 × 0.363 × 0.8 m · local file `Game/Assets/_Game/Art/Models/Monsters/Constructs & Mimics/mon_mud_doll.fbx`

> The Mud Doll is a small creature with a scrawny biped with long arms and bowed legs, about 0.8 m tall. Its surface is smooth and clean, colored in bronze, with ochre markings. Look for a child's clay figure with thumbprint eyes. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by pebbles that tremble and float near it.

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
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.8 m high × 0.24 m long × 0.32 m wide; prefab scale 0.727.
- **Physics:** 10.6 kg, gravity ×1.65, poise 26, knockback resistance 0.3, death style `ragdoll_crumple`.
- **Navigation:** speed 3.41 m/s, turn 470°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** a child's clay figure with thumbprint eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Mud Doll is a **charming construct** encountered at F rank, around level 8. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a child's clay figure with thumbprint eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics F|loot_construct_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Greater Mud Doll|Greater Mud Doll]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | F, F- | 3–8 | Day |
| [[Regions/Aldmere\|Aldmere]] | 5 | E, F, F-, F+ | 3–26 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 4 | F-, F, E- | 3–19 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01440` | Great Labyrinth (Floors 1-40) Mud Doll | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F | 8 | 0.8 m | Day | A typical adult Mud Doll of this region, with dust-grey coloring and old rune scars. |
| `pop_01441` | Aldmere Mud Doll Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 1.08 m | Day | Like a typical Mud Doll, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01442` | Aldmere Mud Doll | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.8 m | Day | A typical adult Mud Doll of this region, with dust-grey coloring and old rune scars. |
| `pop_01443` | Whisperwood Mud Doll Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.56 m | Day | Like a typical Mud Doll, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01444` | Whisperwood Mud Doll Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.68 m | Day | Like a typical Mud Doll, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01445` | Aldmere Mud Doll Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.56 m | Day | Like a typical Mud Doll, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01446` | Whisperwood Mud Doll | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.8 m | Day | A typical adult Mud Doll of this region, with dust-grey coloring and old rune scars. |
| `pop_01447` | Great Labyrinth (Floors 1-40) Mud Doll Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 0.56 m | Day | Like a typical Mud Doll, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01448` | Aldmere Mud Doll Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.88 m | Day | Like a typical Mud Doll, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01449` | Whisperwood Mud Doll Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 1 m | Day | Like a typical Mud Doll, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01450` | Aldmere Mud Doll Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 0.8 m | Day | Like a typical Mud Doll, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `stone_metal_runes` · VFX `rock_debris` · palette `#9d7e45` `#63502d` `#d1a15a` · circle-based, soft silhouette
