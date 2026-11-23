---
type: monster
id: mon_lantern_moth
family: "Familiars & Gentle Creatures"
rank: "F"
tier: core
tags: [monster, familiars-gentle-creatures]
---
# Lantern Moth

![[mon_lantern_moth_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_lantern_moth_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 6,000 tris · 0.613 × 0.29 × 0.3 m · local file `Game/Assets/_Game/Art/Models/Monsters/Familiars & Gentle Creatures/mon_lantern_moth.fbx`

> The Lantern Moth is a tiny creature with a small winged body, about 0.3 m tall. Its coat is smooth and clean, colored in soft cream, with gold markings. Survivors describe wings that glow like paper lanterns. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It waddles, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 161 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/membrane_flyer\|membrane_flyer]] · `anim_flyer_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/membrane_flyer|membrane_flyer]] (override); animation set `anim_flyer_small`.
- **Dimensions:** 0.13 m high × 0.3 m long × 0.6 m wide; prefab scale 0.6.
- **Physics:** 0.5 kg, gravity ×0.72, poise 5, knockback resistance 0.05, death style `flutter_fall`.
- **Navigation:** speed 0.31 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Playful Nudge\|Playful Nudge]] | melee | 0.5 | 6 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Lantern Moth is a **charming familiar** encountered at F rank, around level 8. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** wings that glow like paper lanterns. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Familiars & Gentle Creatures F|loot_familiar_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Familiars & Gentle Creatures/Elder Lantern Moth|Elder Lantern Moth]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E, F-, E-, F+, F | 3–26 | Day |
| [[Regions/Aldmere\|Aldmere]] | 6 | E-, F, F+, F-, E | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02829` | Whisperwood Lantern Moth Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 0.41 m | Day | Like a typical Lantern Moth, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02830` | Whisperwood Lantern Moth Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.26 m | Day | Like a typical Lantern Moth, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02831` | Aldmere Lantern Moth Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.38 m | Day | Like a typical Lantern Moth, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02832` | Aldmere Lantern Moth | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.3 m | Day | A typical adult Lantern Moth of this region, with golden, grass-toned coloring. |
| `pop_02833` | Aldmere Lantern Moth Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.33 m | Day | Like a typical Lantern Moth, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02834` | Whisperwood Lantern Moth Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.38 m | Day | Like a typical Lantern Moth, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02835` | Aldmere Lantern Moth Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.26 m | Day | Like a typical Lantern Moth, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02836` | Aldmere Lantern Moth Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 0.41 m | Day | Like a typical Lantern Moth, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02837` | Whisperwood Lantern Moth Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 0.33 m | Day | Like a typical Lantern Moth, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02838` | Aldmere Lantern Moth Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.21 m | Day | Like a typical Lantern Moth, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02839` | Whisperwood Lantern Moth | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.3 m | Day | A typical adult Lantern Moth of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `fur_soft` · VFX `holy_motes` · palette `#dcc298` `#a08763` `#ffd166` · circle-based, soft silhouette
