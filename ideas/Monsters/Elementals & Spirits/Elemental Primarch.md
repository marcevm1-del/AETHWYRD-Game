---
type: monster
id: mon_elemental_primarch
family: "Elementals & Spirits"
rank: "EX"
tier: core
tags: [monster, elementals-spirits, unique]
---
# Elemental Primarch

![[mon_elemental_primarch_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elemental_primarch_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,886 tris · 36.975 × 34.222 × 40 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elemental Primarch is a colossal creature with a bodiless, glowing form, about 40 m tall. Its body is rough, scarred and spiked, colored in starless black with faint violet edges. Its most striking feature is four elements orbiting a void core. It has burning slit pupils. Its presence is world-scale; the sky changes color when it appears. It circles its prey, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | EX · 300 (300–300) |
| Menace | 3 · Menacing |
| Element · weakness | Void · Light |
| Size | 40 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 110916 · 726 · 847 · 1694 · 1573 · 90 |
| XP · gold | 551660 · 4409 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Root of the World\|Root of the World]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 40 m high × 12 m long × 25.6 m wide; prefab scale 40.
- **Physics:** 6400 kg, gravity ×0, poise 3350, knockback resistance 0.27, death style `dissolve_into_motes`.
- **Navigation:** speed 34.22 m/s, turn 114°/s, stopping distance 10.4 m.
- **Attack count:** 5; **signature:** four elements orbiting a void core.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elemental Primarch is a **menacing elemental** encountered at EX rank, around level 300. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** four elements orbiting a void core. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Root of the World|Root of the World]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits EX|loot_elemental_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Root of the World\|Root of the World]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01690` | Elemental Primarch | [[Regions/Root of the World\|Root of the World]] | Unique | EX | 300 | 40 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `void_distortion` · palette `#1b1b40` `#3d2c8d` `#c9c9ff` · triangle-based silhouette, sharp asymmetric spikes
