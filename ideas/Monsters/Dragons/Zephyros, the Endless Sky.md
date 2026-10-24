---
type: monster
id: mon_zephyros_the_endless_sky
family: "Dragons"
rank: "EX"
tier: core
tags: [monster, dragons, unique]
---
# Zephyros, the Endless Sky

![[mon_zephyros_the_endless_sky_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_zephyros_the_endless_sky_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Zephyros, the Endless Sky is a colossal creature with a vast quadruped dragon frame with cathedral wings, about 90 m long. Its scales are weathered and natural, colored in pale jade and cloud white. Guild sketches always show a body made half of clouds. It has dark, wary eyes. Its presence is world-scale; the sky changes color when it appears. It stalks low to the ground, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | EX · 300 (300–300) |
| Menace | 2 · Wild |
| Element · weakness | Wind · Fire |
| Size | 90 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 244324 · 1573 · 1452 · 1573 · 1452 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Stormreach\|Stormreach]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 50.4 m high × 90 m long × 126.9 m wide; prefab scale 7.5.
- **Physics:** 4527090 kg, gravity ×0.8, poise 2960, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 20.8 m/s, turn 63°/s, stopping distance 7.6 m.
- **Attack count:** 6; **signature:** a body made half of clouds.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Zephyros, the Endless Sky is a **wild dragon** encountered at EX rank, around level 300. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body made half of clouds. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Stormreach|Stormreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Stormreach\|Stormreach]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01434` | Zephyros, the Endless Sky | [[Regions/Stormreach\|Stormreach]] | Unique | EX | 300 | 90 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · real-animal silhouette with one fantasy exaggeration
