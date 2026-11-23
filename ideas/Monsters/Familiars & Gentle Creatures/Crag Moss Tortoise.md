---
type: monster
id: mon_crag_moss_tortoise
family: "Familiars & Gentle Creatures"
rank: "F+"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Crag Moss Tortoise

![[mon_crag_moss_tortoise_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_crag_moss_tortoise_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.416 × 0.8 × 0.298 m · local file `Game/Assets/_Game/Art/Models/Monsters/Familiars & Gentle Creatures/mon_crag_moss_tortoise.fbx`

> The Crag Moss Tortoise is a small creature with a low, springy quadruped build, about 0.8 m long. Its coat is smooth and clean, colored in pastel pink, with ochre markings. Survivors describe herbs and flowers growing on its shell. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by pebbles that tremble and float near it. Adapted to mountain lands, it has slate-grey coloring and hardened hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Moss Tortoise\|Moss Tortoise]] (regional) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Earth · Wind |
| Size | 0.8 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 382 · 62 · 50 · 43 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Wind. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.54 m high × 0.8 m long × 0.11 m wide; prefab scale 1.6.
- **Physics:** 20 kg, gravity ×1.76, poise 25, knockback resistance 0.2, death style `ragdoll_tumble`.
- **Navigation:** speed 5.94 m/s, turn 604°/s, stopping distance 0.53 m.
- **Attack count:** 5; **signature:** herbs and flowers growing on its shell.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crag Moss Tortoise is a **charming familiar** encountered at F+ rank, around level 13. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** herbs and flowers growing on its shell. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures F|loot_familiar_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 6 | F, E-, F-, E, E+ | 3–32 | Day |
| [[Regions/Aldmere\|Aldmere]] | 5 | E-, E, F-, E+ | 3–32 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05659` | Whisperwood Crag Moss Tortoise Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F | 8 | 0.68 m | Day | Like a typical Crag Moss Tortoise, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05660` | Whisperwood Crag Moss Tortoise Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E- | 19 | 0.88 m | Day | Like a typical Crag Moss Tortoise, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05661` | Aldmere Crag Moss Tortoise Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E- | 19 | 0.88 m | Day | Like a typical Crag Moss Tortoise, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05662` | Whisperwood Crag Moss Tortoise Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E- | 19 | 0.8 m | Day | Like a typical Crag Moss Tortoise, but a rare pale form with white skin or fur and red eyes. |
| `pop_05663` | Aldmere Crag Moss Tortoise Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 1 m | Day | Like a typical Crag Moss Tortoise, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05664` | Aldmere Crag Moss Tortoise Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 0.8 m | Day | Like a typical Crag Moss Tortoise, but a rare pale form with white skin or fur and red eyes. |
| `pop_05665` | Aldmere Crag Moss Tortoise Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.56 m | Day | Like a typical Crag Moss Tortoise, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05666` | Whisperwood Crag Moss Tortoise Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.56 m | Day | Like a typical Crag Moss Tortoise, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05667` | Whisperwood Crag Moss Tortoise Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E | 26 | 1 m | Day | Like a typical Crag Moss Tortoise, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05668` | Whisperwood Crag Moss Tortoise Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E+ | 32 | 1.08 m | Day | Like a typical Crag Moss Tortoise, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05669` | Aldmere Crag Moss Tortoise Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 1.08 m | Day | Like a typical Crag Moss Tortoise, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `rock_debris` · palette `#f5c1d8` `#af8699` `#d1a15a` · circle-based, soft silhouette
