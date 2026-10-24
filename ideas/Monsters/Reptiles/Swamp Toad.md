---
type: monster
id: mon_swamp_toad
family: "Reptiles"
rank: "F"
tier: core
tags: [monster, reptiles]
---
# Swamp Toad

![[mon_swamp_toad_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_swamp_toad_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,840 tris · 0.12 × 0.5 × 0.201 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Swamp Toad is a small creature with a low, springy quadruped build, about 0.5 m long. Its scales are smooth and clean, colored in deep blues with a glassy shine. Survivors describe a wide smile and bulging golden eyes. It has big round glossy eyes. It has no ornament at all: simple, readable shapes. It waddles, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 182 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.34 m high × 0.5 m long × 0.07 m wide; prefab scale 1.
- **Physics:** 3.9 kg, gravity ×1.6, poise 20, knockback resistance 0.05, death style `ragdoll_tumble`.
- **Navigation:** speed 5.37 m/s, turn 764°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a wide smile and bulging golden eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Swamp Toad is a **charming reptile** encountered at F rank, around level 8. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a wide smile and bulging golden eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles F|loot_reptile_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Frost Toad|Frost Toad]]

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | F-, F+, F, E, E- | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01246` | Aldmere Swamp Toad Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.42 m | Day | Like a typical Swamp Toad, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_01247` | Aldmere Swamp Toad Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.55 m | Day | Like a typical Swamp Toad, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_01248` | Aldmere Swamp Toad Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Swamp Toad, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_01249` | Aldmere Swamp Toad Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 0.5 m | Day | Like a typical Swamp Toad, but a rare pale form with white skin or fur and red eyes. |
| `pop_01250` | Aldmere Swamp Toad | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.5 m | Day | A typical adult Swamp Toad of this region, with mud-slick, algae-streaked skin. |
| `pop_01251` | Aldmere Swamp Toad Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 0.68 m | Day | Like a typical Swamp Toad, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_01252` | Aldmere Swamp Toad Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.63 m | Day | Like a typical Swamp Toad, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `scale_matte` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
