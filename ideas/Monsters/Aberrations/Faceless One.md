---
type: monster
id: mon_faceless_one
family: "Aberrations"
rank: "C"
tier: core
tags: [monster, aberrations]
---
# Faceless One

![[mon_faceless_one_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_faceless_one_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,532 tris · 2.021 × 2.11 × 2.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Faceless One is a person-sized creature with a shape that keeps rearranging itself, about 2.2 m tall. Its skin is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Look for a smooth blank face that slowly learns to look like yours. It has too many eyes, opening one after another. Battle-worn plates and trophies hang from its body. It crawls across ceilings, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | C · 76 (65–86) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 2.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7861 · 393 · 283 · 283 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Hollow Sea\|Hollow Sea]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 2.2 m high × 2.36 m long × 2.31 m wide; prefab scale 1.1.
- **Physics:** 319.4 kg, gravity ×0.84, poise 105, knockback resistance 0.69, death style `collapse_and_melt`.
- **Navigation:** speed 7.59 m/s, turn 337°/s, stopping distance 1.06 m.
- **Attack count:** 5; **signature:** a smooth blank face that slowly learns to look like yours.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Faceless One is a **horror aberration** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a smooth blank face that slowly learns to look like yours. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Hollow Sea|Hollow Sea]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations C|loot_aberration_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aberrations/Vesper-Touched Faceless One|Vesper-Touched Faceless One]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 4 | B-, C, C-, D+ | 56–96 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | B-, C+ | 86–96 | Night |
| [[Regions/Hollow Sea\|Hollow Sea]] | 3 | D+, C+, B- | 56–96 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 2 | C, C+ | 76–86 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02417` | Umbravel Faceless One Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | B- | 96 | 2.75 m | Night | Like a typical Faceless One, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_02418` | Great Labyrinth (Floors 1-40) Faceless One Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B- | 96 | 2.75 m | Night | Like a typical Faceless One, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_02419` | Umbravel Faceless One | [[Regions/Umbravel\|Umbravel]] | Adult | C | 76 | 2.2 m | Night | A typical adult Faceless One of this region, with bioluminescent spots along its body. |
| `pop_02420` | Hollow Sea Faceless One Runt | [[Regions/Hollow Sea\|Hollow Sea]] | Runt | D+ | 56 | 1.54 m | Night | Like a typical Faceless One, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_02421` | Hollow Sea Faceless One Albino | [[Regions/Hollow Sea\|Hollow Sea]] | Albino | C+ | 86 | 2.2 m | Night | Like a typical Faceless One, but a rare pale form with white skin or fur and red eyes. |
| `pop_02422` | Great Labyrinth (Floors 41-90) Faceless One | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C | 76 | 2.2 m | Night | A typical adult Faceless One of this region, with dust-grey coloring and old rune scars. |
| `pop_02423` | Great Labyrinth (Floors 1-40) Faceless One Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C+ | 86 | 2.42 m | Night | Like a typical Faceless One, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02424` | Umbravel Faceless One Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | C- | 65 | 1.87 m | Night | Like a typical Faceless One, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_02425` | Great Labyrinth (Floors 41-90) Faceless One Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C+ | 86 | 2.42 m | Night | Like a typical Faceless One, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02426` | Umbravel Faceless One Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D+ | 56 | 1.54 m | Night | Like a typical Faceless One, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_02427` | Hollow Sea Faceless One Alpha | [[Regions/Hollow Sea\|Hollow Sea]] | Alpha | B- | 96 | 2.75 m | Night | Like a typical Faceless One, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
