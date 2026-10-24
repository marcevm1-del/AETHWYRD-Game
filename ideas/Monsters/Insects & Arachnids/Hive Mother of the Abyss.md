---
type: monster
id: mon_hive_mother_of_the_abyss
family: "Insects & Arachnids"
rank: "EX"
tier: core
tags: [monster, insects-arachnids, unique]
---
# Hive Mother of the Abyss

![[mon_hive_mother_of_the_abyss_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hive_mother_of_the_abyss_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,920 tris · 58.752 × 57.533 × 60 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Hive Mother of the Abyss is a colossal creature with an asymmetric body with too many limbs, about 60 m tall. Its chitin is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Look for a living hive-mountain that sings. It has a human-like face in the wrong place. Its presence is world-scale; the sky changes color when it appears. It crawls across ceilings, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | EX · 300 (300–300) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 60 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 150723 · 1513 · 1089 · 1089 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/The Maw\|The Maw]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 60 m high × 64.32 m long × 63 m wide; prefab scale 30.
- **Physics:** 6480000 kg, gravity ×0.84, poise 32698, knockback resistance 0.87, death style `collapse_and_melt`.
- **Navigation:** speed 39.63 m/s, turn 65°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** a living hive-mountain that sings.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hive Mother of the Abyss is a **horror insectoid** encountered at EX rank, around level 300. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a living hive-mountain that sings. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids EX|loot_insect_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/The Maw\|The Maw]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00729` | Hive Mother of the Abyss | [[Regions/The Maw\|The Maw]] | Unique | EX | 300 | 60 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `chitin_gloss` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
