---
type: monster
id: mon_frost_toad
family: "Reptiles"
rank: "F+"
tier: variant
tags: [monster, reptiles]
---
# Frost Toad

![[mon_frost_toad_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_frost_toad_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,682 tris · 0.12 × 0.5 × 0.201 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Frost Toad is a small creature with a low, springy quadruped build, about 0.5 m long. Its scales are smooth and clean, colored in pale blues and frost-white. Look for a wide smile and bulging golden eyes. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Swamp Toad\|Swamp Toad]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Ice · Fire |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 333 · 62 · 50 · 43 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.34 m high × 0.5 m long × 0.07 m wide; prefab scale 1.
- **Physics:** 4.1 kg, gravity ×1.68, poise 20, knockback resistance 0.05, death style `ragdoll_tumble`.
- **Navigation:** speed 4.69 m/s, turn 764°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a wide smile and bulging golden eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Frost Toad is a **charming reptile** encountered at F+ rank, around level 13. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

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

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | F-, E-, E+, F+, E, F | 3–32 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04135` | Aldmere Frost Toad Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.35 m | Day | Like a typical Frost Toad, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_04136` | Aldmere Frost Toad Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 0.5 m | Day | Like a typical Frost Toad, but a rare pale form with white skin or fur and red eyes. |
| `pop_04137` | Aldmere Frost Toad Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 0.68 m | Day | Like a typical Frost Toad, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_04138` | Aldmere Frost Toad | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 0.5 m | Day | A typical adult Frost Toad of this region, with mud-slick, algae-streaked skin. |
| `pop_04139` | Aldmere Frost Toad Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E- | 19 | 0.55 m | Day | Like a typical Frost Toad, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_04140` | Aldmere Frost Toad Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 0.63 m | Day | Like a typical Frost Toad, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_04141` | Aldmere Frost Toad Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 0.42 m | Day | Like a typical Frost Toad, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `scale_matte` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · circle-based, soft silhouette
