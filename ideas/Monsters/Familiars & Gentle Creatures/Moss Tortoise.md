---
type: monster
id: mon_moss_tortoise
family: "Familiars & Gentle Creatures"
rank: "F"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Moss Tortoise

> The Moss Tortoise is a small creature with a compact quadruped frame, about 0.8 m long. Its coat is smooth and clean, colored in leaf greens over bark brown. Its most striking feature is herbs and flowers growing on its shell. It has big round glossy eyes. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Nature · Fire |
| Size | 0.8 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 209 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.54 m high × 0.8 m long × 0.11 m wide; prefab scale 1.6.
- **Physics:** 15.4 kg, gravity ×1.6, poise 25, knockback resistance 0.05, death style `ragdoll_tumble`.
- **Navigation:** speed 6.45 m/s, turn 604°/s, stopping distance 0.53 m.
- **Attack count:** 5; **signature:** herbs and flowers growing on its shell.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Moss Tortoise is a **charming familiar** encountered at F rank, around level 8. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** herbs and flowers growing on its shell. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures F|loot_familiar_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Crag Moss Tortoise|Crag Moss Tortoise]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | F+, F-, F, E | 3–26 | Day |
| [[Regions/Aldmere\|Aldmere]] | 6 | F-, E, F+, F | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02818` | Whisperwood Moss Tortoise Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 0.8 m | Day | Like a typical Moss Tortoise, but a rare pale form with white skin or fur and red eyes. |
| `pop_02819` | Whisperwood Moss Tortoise Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.68 m | Day | Like a typical Moss Tortoise, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02820` | Aldmere Moss Tortoise Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.68 m | Day | Like a typical Moss Tortoise, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02821` | Aldmere Moss Tortoise Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 1.08 m | Day | Like a typical Moss Tortoise, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02822` | Whisperwood Moss Tortoise | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.8 m | Day | A typical adult Moss Tortoise of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02823` | Whisperwood Moss Tortoise Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 1.08 m | Day | Like a typical Moss Tortoise, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02824` | Aldmere Moss Tortoise Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 0.8 m | Day | Like a typical Moss Tortoise, but a rare pale form with white skin or fur and red eyes. |
| `pop_02825` | Aldmere Moss Tortoise Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.56 m | Day | Like a typical Moss Tortoise, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02826` | Aldmere Moss Tortoise | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.8 m | Day | A typical adult Moss Tortoise of this region, with golden, grass-toned coloring. |
| `pop_02827` | Aldmere Moss Tortoise Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.88 m | Day | Like a typical Moss Tortoise, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02828` | Whisperwood Moss Tortoise Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.56 m | Day | Like a typical Moss Tortoise, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · circle-based, soft silhouette
