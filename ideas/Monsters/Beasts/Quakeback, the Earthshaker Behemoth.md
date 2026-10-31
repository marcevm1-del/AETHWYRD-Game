---
type: monster
id: mon_quakeback_the_earthshaker_behemoth
family: "Beasts"
rank: "S+"
tier: core
tags: [monster, beasts, tyrant, unique]
---
# Quakeback, the Earthshaker Behemoth

![[mon_quakeback_the_earthshaker_behemoth_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_quakeback_the_earthshaker_behemoth_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,794 tris · 5.156 × 20 × 11.631 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Quakeback, the Earthshaker Behemoth is a colossal creature with a long-legged predatory quadruped build, about 20 m long. Its coat is rough, scarred and spiked, colored in ash-grey, with ochre markings. Survivors describe a back of shifting tectonic plates that sets off the hourly quakes. It has burning slit pupils. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 20 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 72511 · 986 · 822 · 658 · 740 · 100 |
| XP · gold | 295379 · 2553 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Quaking Lands\|Quaking Lands]] |
| Tyrant | Yes |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 13 m high × 20 m long × 3.2 m wide; prefab scale 5.
- **Physics:** 208000 kg, gravity ×1.32, poise 342, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 16.68 m/s, turn 72°/s, stopping distance 4.4 m.
- **Attack count:** 5; **signature:** a back of shifting tectonic plates that sets off the hourly quakes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Quakeback, the Earthshaker Behemoth is a **menacing beast** encountered at S+ rank, around level 203. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a back of shifting tectonic plates that sets off the hourly quakes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Quaking Lands|Quaking Lands]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts S|loot_beast_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Quaking Lands\|Quaking Lands]] | 1 | S+ | 203–203 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06753` | Quakeback, the Earthshaker Behemoth | [[Regions/Quaking Lands\|Quaking Lands]] | Unique | S+ | 203 | 20 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `rock_debris` · palette `#8f8d88` `#5e5c58` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
