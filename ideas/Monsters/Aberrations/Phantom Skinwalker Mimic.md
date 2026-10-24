---
type: monster
id: mon_phantom_skinwalker_mimic
family: "Aberrations"
rank: "F+"
tier: variant
tags: [monster, aberrations]
---
# Phantom Skinwalker Mimic

![[mon_phantom_skinwalker_mimic_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_skinwalker_mimic_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,676 tris · 1.836 × 1.726 × 1.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Skinwalker Mimic is a person-sized creature with a tall, impossibly thin frame, about 1.8 m tall. Its skin is stretched, stitched and constantly shifting, colored in warm gold and pearl white. It calls you in your companion's voice. It has a human-like face in the wrong place. It has no ornament at all: simple, readable shapes. It copies the walk of whatever it hunts, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Variant of | [[Monsters/Aberrations/Skinwalker Mimic\|Skinwalker Mimic]] (spirit) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 587 · 78 · 56 · 56 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 1.8 m high × 1.93 m long × 1.89 m wide; prefab scale 0.9.
- **Physics:** 166.2 kg, gravity ×1.08, poise 52, knockback resistance 0.6, death style `collapse_and_melt`.
- **Navigation:** speed 6.86 m/s, turn 373°/s, stopping distance 0.94 m.
- **Attack count:** 5; **signature:** it calls you in your companion's voice.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Mimic Lure\|Mimic Lure]] | debuff | 0 | 16 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Skinwalker Mimic is a **horror aberration** encountered at F+ rank, around level 13. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** it calls you in your companion's voice. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aberrations F|loot_aberration_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 2 | E-, F | 8–19 | Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | E, F+, F-, E-, F | 3–26 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | E, E-, F- | 3–26 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05246` | Whisperwood Phantom Skinwalker Mimic Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E- | 19 | 1.98 m | Night | Like a typical Phantom Skinwalker Mimic, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05247` | Aldmere Phantom Skinwalker Mimic Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 2.25 m | Night | Like a typical Phantom Skinwalker Mimic, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05248` | Great Labyrinth (Floors 1-40) Phantom Skinwalker Mimic Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E | 26 | 2.25 m | Night | Like a typical Phantom Skinwalker Mimic, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_05249` | Aldmere Phantom Skinwalker Mimic | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 1.8 m | Night | A typical adult Phantom Skinwalker Mimic of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05250` | Great Labyrinth (Floors 1-40) Phantom Skinwalker Mimic Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E- | 19 | 1.98 m | Night | Like a typical Phantom Skinwalker Mimic, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_05251` | Great Labyrinth (Floors 1-40) Phantom Skinwalker Mimic Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E- | 19 | 1.8 m | Night | Like a typical Phantom Skinwalker Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_05252` | Whisperwood Phantom Skinwalker Mimic Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F | 8 | 1.53 m | Night | Like a typical Phantom Skinwalker Mimic, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05253` | Aldmere Phantom Skinwalker Mimic Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 1.26 m | Night | Like a typical Phantom Skinwalker Mimic, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05254` | Aldmere Phantom Skinwalker Mimic Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 1.8 m | Night | Like a typical Phantom Skinwalker Mimic, but a rare pale form with white skin or fur and red eyes. |
| `pop_05255` | Great Labyrinth (Floors 1-40) Phantom Skinwalker Mimic Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 1.26 m | Night | Like a typical Phantom Skinwalker Mimic, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_05256` | Aldmere Phantom Skinwalker Mimic Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 1.53 m | Night | Like a typical Phantom Skinwalker Mimic, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `wet_flesh_unsettling` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · broken symmetry, mimicry, audio-first reveal
