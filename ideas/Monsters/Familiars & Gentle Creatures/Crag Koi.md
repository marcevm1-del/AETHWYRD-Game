---
type: monster
id: mon_crag_koi
family: "Familiars & Gentle Creatures"
rank: "F+"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Crag Koi

![[mon_crag_koi_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_crag_koi_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (950 tris · 0.198 × 0.5 × 0.212 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Crag Koi is a small creature with a long, finned body, about 0.5 m long. Its coat is smooth and clean, colored in ochre, clay and mossy stone. Survivors describe scales that shimmer every color. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by pebbles that tremble and float near it. Adapted to mountain lands, it has slate-grey coloring and hardened hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Rainbow Koi\|Rainbow Koi]] (regional) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Earth · Wind |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 392 · 78 · 56 · 56 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Wind. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 0.2 m high × 0.5 m long × 0.18 m wide; prefab scale 0.333.
- **Physics:** 3.7 kg, gravity ×1.1, poise 8, knockback resistance 0.45, death style `float_belly_up`.
- **Navigation:** speed 2.34 m/s, turn 566°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** scales that shimmer every color.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crag Koi is a **charming familiar** encountered at F+ rank, around level 13. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** scales that shimmer every color. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

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
| [[Regions/Aldmere\|Aldmere]] | 6 | F+, F, E+, F-, E- | 3–32 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E, F-, F+, F, E- | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05692` | Aldmere Crag Koi | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 0.5 m | Day | A typical adult Crag Koi of this region, with golden, grass-toned coloring. |
| `pop_05693` | Aldmere Crag Koi Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 0.42 m | Day | Like a typical Crag Koi, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05694` | Whisperwood Crag Koi Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E | 26 | 0.63 m | Day | Like a typical Crag Koi, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05695` | Whisperwood Crag Koi Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Crag Koi, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05696` | Aldmere Crag Koi Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 0.68 m | Day | Like a typical Crag Koi, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05697` | Whisperwood Crag Koi | [[Regions/Whisperwood\|Whisperwood]] | Adult | F+ | 13 | 0.5 m | Day | A typical adult Crag Koi of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05698` | Aldmere Crag Koi Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Crag Koi, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05699` | Aldmere Crag Koi Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 0.5 m | Day | Like a typical Crag Koi, but a rare pale form with white skin or fur and red eyes. |
| `pop_05700` | Whisperwood Crag Koi Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F | 8 | 0.42 m | Day | Like a typical Crag Koi, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05701` | Whisperwood Crag Koi Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E- | 19 | 0.5 m | Day | Like a typical Crag Koi, but a rare pale form with white skin or fur and red eyes. |
| `pop_05702` | Aldmere Crag Koi Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E- | 19 | 0.55 m | Day | Like a typical Crag Koi, but covered in old battle scars, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `fur_soft` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · circle-based, soft silhouette
