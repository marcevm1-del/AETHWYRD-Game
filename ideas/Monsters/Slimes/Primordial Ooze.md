---
type: monster
id: mon_primordial_ooze
family: "Slimes"
rank: "EX"
tier: core
tags: [monster, slimes, unique]
---
# Primordial Ooze

![[mon_primordial_ooze_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_primordial_ooze_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,940 tris · 41.168 × 41.634 × 40 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Primordial Ooze is a colossal creature with a dome-shaped gelatinous body, about 40 m tall. Its gel is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Its most striking feature is an ocean-sized mass that shows the faces of everything it has eaten. It has no eyes at all, only a wide and patient mouth. Its presence is world-scale; the sky changes color when it appears. It unfolds into something larger, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | EX · 300 (300–300) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 40 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 97052 · 968 · 726 · 726 · 726 · 110 |
| XP · gold | 551660 · 4409 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 40 m high × 37.2 m long × 36 m wide; prefab scale 80.
- **Physics:** 33600000 kg, gravity ×1.12, poise 604, knockback resistance 0.37, death style `splat_dissolve`.
- **Navigation:** speed 34.22 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** an ocean-sized mass that shows the faces of everything it has eaten.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Primordial Ooze is a **horror ooze** encountered at EX rank, around level 300. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** an ocean-sized mass that shows the faces of everything it has eaten. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes EX|loot_slime_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00155` | Primordial Ooze | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Unique | EX | 300 | 40 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `void_distortion` · palette `#1b1b40` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
