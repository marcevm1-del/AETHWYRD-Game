---
type: monster
id: mon_skinwalker_mimic
family: "Aberrations"
rank: "F"
tier: core
tags: [monster, aberrations]
---
# Skinwalker Mimic

![[mon_skinwalker_mimic_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_skinwalker_mimic_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 2.116 × 2.157 × 1.8 m · local file `Game/Assets/_Game/Art/Models/Monsters/Aberrations/mon_skinwalker_mimic.fbx`

> The Skinwalker Mimic is a person-sized creature with an asymmetric body with too many limbs, about 1.8 m tall. Its skin is stretched, stitched and constantly shifting, colored in mauve, with violet markings. It calls you in your companion's voice. It has too many eyes, opening one after another. It has no ornament at all: simple, readable shapes. It crawls across ceilings, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | F · 8 (3–13) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 321 · 53 · 38 · 38 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 1.8 m high × 1.93 m long × 1.89 m wide; prefab scale 0.9.
- **Physics:** 175 kg, gravity ×1.2, poise 53, knockback resistance 0.6, death style `collapse_and_melt`.
- **Navigation:** speed 7.21 m/s, turn 373°/s, stopping distance 0.94 m.
- **Attack count:** 5; **signature:** it calls you in your companion's voice.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Skinwalker Mimic is a **horror aberration** encountered at F rank, around level 8. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** it calls you in your companion's voice. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations F|loot_aberration_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aberrations/Phantom Skinwalker Mimic|Phantom Skinwalker Mimic]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | F-, E, F+, E- | 3–26 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | F, F+, E, E- | 8–26 | Night |
| [[Regions/Whisperwood\|Whisperwood]] | 2 | F-, E- | 3–19 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02395` | Great Labyrinth (Floors 1-40) Skinwalker Mimic Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 1.26 m | Night | Like a typical Skinwalker Mimic, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_02396` | Aldmere Skinwalker Mimic | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 1.8 m | Night | A typical adult Skinwalker Mimic of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02397` | Aldmere Skinwalker Mimic Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 1.8 m | Night | Like a typical Skinwalker Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_02398` | Great Labyrinth (Floors 1-40) Skinwalker Mimic Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E | 26 | 2.43 m | Night | Like a typical Skinwalker Mimic, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_02399` | Aldmere Skinwalker Mimic Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 2.43 m | Night | Like a typical Skinwalker Mimic, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02400` | Aldmere Skinwalker Mimic Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 2.25 m | Night | Like a typical Skinwalker Mimic, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02401` | Great Labyrinth (Floors 1-40) Skinwalker Mimic Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | F+ | 13 | 1.98 m | Night | Like a typical Skinwalker Mimic, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02402` | Great Labyrinth (Floors 1-40) Skinwalker Mimic Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | F+ | 13 | 1.8 m | Night | Like a typical Skinwalker Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_02403` | Whisperwood Skinwalker Mimic Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 1.53 m | Night | Like a typical Skinwalker Mimic, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02404` | Whisperwood Skinwalker Mimic Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 2.25 m | Night | Like a typical Skinwalker Mimic, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02405` | Great Labyrinth (Floors 1-40) Skinwalker Mimic Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E- | 19 | 2.25 m | Night | Like a typical Skinwalker Mimic, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `shadow_wisps` · palette `#7f6482` `#544257` `#9a86d8` · broken symmetry, mimicry, audio-first reveal
