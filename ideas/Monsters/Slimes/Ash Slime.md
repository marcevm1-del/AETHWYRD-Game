---
type: monster
id: mon_ash_slime
family: "Slimes"
rank: "E+"
tier: variant
tags: [monster, slimes]
---
# Ash Slime

![[mon_ash_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ash_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,544 tris · 0.389 × 0.389 × 0.3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ash Slime is a tiny creature with a wobbling mound of translucent gel, about 0.3 m tall. Its gel is smooth and clean, colored in ember reds fading to soot black. Its most striking feature is a cluster of soap-bright spheres that split apart when hit. It has big round glossy eyes. Small scars and rough edges mark it as a survivor. It bounces happily, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Bubble Slime\|Bubble Slime]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 1 · Charming |
| Element · weakness | Fire · Water |
| Size | 0.3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 852 · 110 · 83 · 83 · 83 · 110 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.3 m high × 0.28 m long × 0.27 m wide; prefab scale 0.6.
- **Physics:** 14.2 kg, gravity ×1.6, poise 22, knockback resistance 0.13, death style `splat_dissolve`.
- **Navigation:** speed 2.67 m/s, turn 657°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** a cluster of soap-bright spheres that split apart when hit.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ash Slime is a **charming ooze** encountered at E+ rank, around level 32. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a cluster of soap-bright spheres that split apart when hit. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes E|loot_slime_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | D+, E, E-, D-, E+ | 19–56 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 3 | E, E+, D+ | 26–56 | Day |
| [[Regions/Aldmere\|Aldmere]] | 3 | D-, E+, E- | 19–40 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05791` | Great Labyrinth (Floors 1-40) Ash Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D+ | 56 | 0.41 m | Day | Like a typical Ash Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05792` | Whisperwood Ash Slime Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E | 26 | 0.26 m | Day | Like a typical Ash Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05793` | Aldmere Ash Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.3 m | Day | Like a typical Ash Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05794` | Great Labyrinth (Floors 1-40) Ash Slime Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 0.26 m | Day | Like a typical Ash Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05795` | Aldmere Ash Slime | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 0.3 m | Day | A typical adult Ash Slime of this region, with golden, grass-toned coloring. |
| `pop_05796` | Whisperwood Ash Slime | [[Regions/Whisperwood\|Whisperwood]] | Adult | E+ | 32 | 0.3 m | Day | A typical adult Ash Slime of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05797` | Whisperwood Ash Slime Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D+ | 56 | 0.41 m | Day | Like a typical Ash Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05798` | Great Labyrinth (Floors 1-40) Ash Slime Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E- | 19 | 0.21 m | Day | Like a typical Ash Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05799` | Great Labyrinth (Floors 1-40) Ash Slime Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 0.33 m | Day | Like a typical Ash Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05800` | Great Labyrinth (Floors 1-40) Ash Slime | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E+ | 32 | 0.3 m | Day | A typical adult Ash Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05801` | Aldmere Ash Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.21 m | Day | Like a typical Ash Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · circle-based, soft silhouette
