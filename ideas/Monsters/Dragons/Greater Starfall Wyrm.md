---
type: monster
id: mon_greater_starfall_wyrm
family: "Dragons"
rank: "EX"
tier: variant
tags: [monster, dragons, unique]
---
# Greater Starfall Wyrm

![[mon_greater_starfall_wyrm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_starfall_wyrm_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,240 tris · 93.574 × 96 × 58.625 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Starfall Wyrm is a colossal creature with an ancient, serpentine dragon body, about 96 m long. Its scales are rough, scarred and spiked, colored in emerald, with gold markings. Look for scales flecked with fallen starmetal that glitter like a night sky. It has narrow glowing eyes. Its presence is world-scale; the sky changes color when it appears. It charges without hesitation, surrounded by soft radiance and floating motes of light. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Starfall Wyrm\|Starfall Wyrm]] (elder) |
| Rank · level | EX · 300 (300–300) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 96 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 245833 · 1573 · 1452 · 1573 · 1452 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 53.76 m high × 96 m long × 135.36 m wide; prefab scale 8.
- **Physics:** 5799444.5 kg, gravity ×0.9, poise 3058, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 22.97 m/s, turn 61°/s, stopping distance 8.08 m.
- **Attack count:** 6; **signature:** scales flecked with fallen starmetal that glitter like a night sky.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Starfall Wyrm is a **menacing dragon** encountered at EX rank, around level 300. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** scales flecked with fallen starmetal that glitter like a night sky. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Nox Dominion\|Nox Dominion]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04318` | Greater Starfall Wyrm | [[Regions/Nox Dominion\|Nox Dominion]] | Unique | EX | 300 | 96 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `holy_motes` · palette `#3d803e` `#2b562a` `#ffd166` · triangle-based silhouette, sharp asymmetric spikes
