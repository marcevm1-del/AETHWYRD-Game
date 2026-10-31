---
type: monster
id: mon_umbrael_the_hollow_star
family: "Dragons"
rank: "EX"
tier: core
tags: [monster, dragons, unique]
---
# Umbrael, the Hollow Star

![[mon_umbrael_the_hollow_star_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_umbrael_the_hollow_star_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,202 tris · 87.212 × 100 × 77.138 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Umbrael, the Hollow Star is a colossal creature with a four-legged, two-winged dragon body, about 100 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in sapphire, with violet-edged markings. Its most striking feature is scales like a night sky full of dying stars. It has eyes set slightly too far apart. Its presence is world-scale; the sky changes color when it appears. It moves in jerky stop-motion bursts, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | EX · 300 (300–300) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 100 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 245833 · 1573 · 1452 · 1573 · 1452 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 56 m high × 100 m long × 141 m wide; prefab scale 8.333.
- **Physics:** 6900000 kg, gravity ×0.7, poise 3121, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 20.3 m/s, turn 60°/s, stopping distance 8.4 m.
- **Attack count:** 6; **signature:** scales like a night sky full of dying stars.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Umbrael, the Hollow Star is a **dread dragon** encountered at EX rank, around level 300. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** scales like a night sky full of dying stars. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons EX|loot_draconic_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01436` | Umbrael, the Hollow Star | [[Regions/Sky Archipelago\|Sky Archipelago]] | Unique | EX | 300 | 100 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `void_distortion` · palette `#2d6d8a` `#234b5f` `#8a7cff` · elongated, irregular silhouette; still-then-sudden timing
