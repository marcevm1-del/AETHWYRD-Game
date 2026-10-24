---
type: monster
id: mon_hydra
family: "Reptiles"
rank: "B+"
tier: core
tags: [monster, reptiles]
---
# Hydra

![[mon_hydra_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hydra_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,976 tris · 2.047 × 9 × 3.783 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Hydra is a huge creature with a coiling, legless body, about 9 m long. Its scales are rough, scarred and spiked, colored in bruise purple with sickly green. Guild sketches always show five heads on long necks, each with its own temper. It has narrow glowing eyes. Faint runes glow along its body when it fights. It circles its prey, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 9 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20668 · 490 · 392 · 343 · 392 · 135 |
| XP · gold | 6373 · 1225 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Lirian\|Lirian]], [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.36 m high × 9 m long × 0.9 m wide; prefab scale 2.25.
- **Physics:** 1676.7 kg, gravity ×1.2, poise 295, knockback resistance 0.52, death style `limp_chain`.
- **Navigation:** speed 7.71 m/s, turn 100°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** five heads on long necks, each with its own temper.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hydra is a **menacing reptile** encountered at B+ rank, around level 120. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** five heads on long necks, each with its own temper. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Lumbaya|Lumbaya]], [[Regions/Lirian|Lirian]], [[Regions/Goldmere Coast|Goldmere Coast]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles B|loot_reptile_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Reptiles/Frost Hydra|Frost Hydra]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 4 | A, B+, A+, A- | 120–159 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 4 | A-, B-, A, A+ | 96–159 | Day & Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 2 | B+, A- | 120–132 | Day & Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 1 | A | 146–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01308` | Lirian Hydra Alpha | [[Regions/Lirian\|Lirian]] | Alpha | A | 146 | 11.25 m | Day & Night | Like a typical Hydra, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01309` | Lumbaya Hydra Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | A- | 132 | 9.9 m | Day & Night | Like a typical Hydra, but covered in old battle scars, with vivid tropical markings. |
| `pop_01310` | Goldmere Coast Hydra | [[Regions/Goldmere Coast\|Goldmere Coast]] | Adult | B+ | 120 | 9 m | Day & Night | A typical adult Hydra of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01311` | Lumbaya Hydra Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | B- | 96 | 6.3 m | Day & Night | Like a typical Hydra, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_01312` | Lumbaya Hydra Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | A | 146 | 11.25 m | Day & Night | Like a typical Hydra, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_01313` | Lumbaya Hydra Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | A+ | 159 | 12.15 m | Day & Night | Like a typical Hydra, but old and wise, with greying features and a cautious hunting style, with vivid tropical markings. |
| `pop_01314` | Lirian Hydra | [[Regions/Lirian\|Lirian]] | Adult | B+ | 120 | 9 m | Day & Night | A typical adult Hydra of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01315` | Goldmere Coast Hydra Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | A- | 132 | 9.9 m | Day & Night | Like a typical Hydra, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01316` | Xochitl Mire Hydra Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | A | 146 | 11.25 m | Day & Night | Like a typical Hydra, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_01317` | Lirian Hydra Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | A+ | 159 | 12.15 m | Day & Night | Like a typical Hydra, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01318` | Lirian Hydra Scarred | [[Regions/Lirian\|Lirian]] | Scarred | A- | 132 | 9.9 m | Day & Night | Like a typical Hydra, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
