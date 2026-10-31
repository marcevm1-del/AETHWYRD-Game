---
type: monster
id: mon_nythraxa_the_duskwyrm
family: "Dragons"
rank: "EX"
tier: core
tags: [monster, dragons, unique]
---
# Nythraxa, the Duskwyrm

![[mon_nythraxa_the_duskwyrm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_nythraxa_the_duskwyrm_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,706 tris · 146.209 × 150 × 91.601 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Nythraxa, the Duskwyrm is a colossal creature with an ancient, serpentine dragon body, about 150 m long. Its scales are weathered and natural, colored in crimson, with violet markings. Survivors describe a body of dusk-colored mist and silver eyes. It has dark, wary eyes. Its presence is world-scale; the sky changes color when it appears. It prowls, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | EX · 300 (300–300) |
| Menace | 2 · Wild |
| Element · weakness | Dark · Light |
| Size | 150 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 245833 · 1573 · 1452 · 1573 · 1452 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 84 m high × 150 m long × 211.5 m wide; prefab scale 12.5.
- **Physics:** 23287500 kg, gravity ×1, poise 3822, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 28.71 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 6; **signature:** a body of dusk-colored mist and silver eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Nythraxa, the Duskwyrm is a **wild dragon** encountered at EX rank, around level 300. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body of dusk-colored mist and silver eyes. Watch for its tell and leave a response window before committing to a long combo.

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
| `pop_01438` | Nythraxa, the Duskwyrm | [[Regions/Sky Archipelago\|Sky Archipelago]] | Unique | EX | 300 | 150 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `shadow_wisps` · palette `#b1332e` `#6f2624` `#9a86d8` · real-animal silhouette with one fantasy exaggeration
