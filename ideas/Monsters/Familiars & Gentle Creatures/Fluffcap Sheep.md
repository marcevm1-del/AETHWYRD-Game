---
type: monster
id: mon_fluffcap_sheep
family: "Familiars & Gentle Creatures"
rank: "F"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Fluffcap Sheep

![[mon_fluffcap_sheep_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_fluffcap_sheep_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.418 × 1 × 0.57 m · local file `Game/Assets/_Game/Art/Models/Monsters/Familiars & Gentle Creatures/mon_fluffcap_sheep.fbx`

> The Fluffcap Sheep is a small creature with a small, quick four-legged body, about 1 m long. Its coat is smooth and clean, colored in pastel pink, with pale jade markings. Its most striking feature is wool so light it floats. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 1 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 224 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.68 m high × 1 m long × 0.14 m wide; prefab scale 2.
- **Physics:** 27 kg, gravity ×1.28, poise 28, knockback resistance 0.05, death style `ragdoll_tumble`.
- **Navigation:** speed 7.79 m/s, turn 540°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** wool so light it floats.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Fluffcap Sheep is a **charming familiar** encountered at F rank, around level 8. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** wool so light it floats. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures F|loot_familiar_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Rime Fluffcap Sheep|Rime Fluffcap Sheep]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | E-, F-, F+, E | 3–26 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F-, E, F, F+ | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02840` | Aldmere Fluffcap Sheep Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 1.25 m | Day | Like a typical Fluffcap Sheep, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02841` | Aldmere Fluffcap Sheep Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.85 m | Day | Like a typical Fluffcap Sheep, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02842` | Whisperwood Fluffcap Sheep Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.85 m | Day | Like a typical Fluffcap Sheep, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02843` | Whisperwood Fluffcap Sheep Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 1.35 m | Day | Like a typical Fluffcap Sheep, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02844` | Aldmere Fluffcap Sheep Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 1.1 m | Day | Like a typical Fluffcap Sheep, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02845` | Aldmere Fluffcap Sheep Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.7 m | Day | Like a typical Fluffcap Sheep, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02846` | Whisperwood Fluffcap Sheep Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.7 m | Day | Like a typical Fluffcap Sheep, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02847` | Aldmere Fluffcap Sheep Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 1 m | Day | Like a typical Fluffcap Sheep, but a rare pale form with white skin or fur and red eyes. |
| `pop_02848` | Aldmere Fluffcap Sheep Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 1.35 m | Day | Like a typical Fluffcap Sheep, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02849` | Whisperwood Fluffcap Sheep | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 1 m | Day | A typical adult Fluffcap Sheep of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02850` | Whisperwood Fluffcap Sheep Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 1.1 m | Day | Like a typical Fluffcap Sheep, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `wind_ribbons` · palette `#e0b0c4` `#a07a8b` `#8fe0bd` · circle-based, soft silhouette
