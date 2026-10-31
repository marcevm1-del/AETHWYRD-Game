---
type: monster
id: mon_hatchling
family: "Dragons"
rank: "F"
tier: core
tags: [monster, dragons]
---
# Hatchling

![[mon_hatchling_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hatchling_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,650 tris · 0.487 × 0.5 × 0.269 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Hatchling is a small creature with an ancient, serpentine dragon body, about 0.5 m long. Its scales are smooth and clean, colored in crimson, with ember-orange markings. Look for a too-big head and wings it can't use yet. It has big round glossy eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Fire · Water |
| Size | 0.5 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 322 · 55 · 50 · 55 · 50 · 100 |
| XP · gold | 92 · 31 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Lirian\|Lirian]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 0.28 m high × 0.5 m long × 0.71 m wide; prefab scale 0.042.
- **Physics:** 0.9 kg, gravity ×1, poise 179, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 1.22 m/s, turn 849°/s, stopping distance 0.5 m.
- **Attack count:** 6; **signature:** a too-big head and wings it can't use yet.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hatchling is a **charming dragon** encountered at F rank, around level 8. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a too-big head and wings it can't use yet. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons F|loot_draconic_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Dragons/Rime Hatchling|Rime Hatchling]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 4 | F-, E, F+ | 3–26 | Day |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | F+, F-, E- | 3–19 | Day |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | F, F+ | 8–13 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01330` | Lirian Hatchling Runt | [[Regions/Lirian\|Lirian]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Hatchling, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01331` | Hoshizora Hatchling Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | F+ | 13 | 0.55 m | Day | Like a typical Hatchling, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01332` | Lirian Hatchling Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | E | 26 | 0.68 m | Day | Like a typical Hatchling, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01333` | Lirian Hatchling Juvenile | [[Regions/Lirian\|Lirian]] | Juvenile | F- | 3 | 0.42 m | Day | Like a typical Hatchling, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01334` | Hoshizora Hatchling Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Hatchling, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01335` | Hoshizora Hatchling Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | E- | 19 | 0.63 m | Day | Like a typical Hatchling, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01336` | Lirian Hatchling Scarred | [[Regions/Lirian\|Lirian]] | Scarred | F+ | 13 | 0.55 m | Day | Like a typical Hatchling, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01337` | Iron Hold Hatchling | [[Regions/Iron Hold\|Iron Hold]] | Adult | F | 8 | 0.5 m | Day | A typical adult Hatchling of this region, with slate-grey coloring and hardened hide. |
| `pop_01338` | Iron Hold Hatchling Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | F+ | 13 | 0.55 m | Day | Like a typical Hatchling, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01339` | Iron Hold Hatchling Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | F+ | 13 | 0.5 m | Day | Like a typical Hatchling, but a rare pale form with white skin or fur and red eyes. |
| `pop_01340` | Hoshizora Hatchling Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | F+ | 13 | 0.5 m | Day | Like a typical Hatchling, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#b4362f` `#702825` `#ff7a3d` · circle-based, soft silhouette
