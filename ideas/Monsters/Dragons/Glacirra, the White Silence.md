---
type: monster
id: mon_glacirra_the_white_silence
family: "Dragons"
rank: "EX"
tier: core
tags: [monster, dragons, unique]
---
# Glacirra, the White Silence

![[mon_glacirra_the_white_silence_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_glacirra_the_white_silence_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Glacirra, the White Silence is a colossal creature with a vast quadruped dragon frame with cathedral wings, about 80 m long. Its scales are weathered and natural, colored in pale blues and frost-white. Survivors describe wings like frozen waterfalls. It has dark, wary eyes. Its presence is world-scale; the sky changes color when it appears. It stalks low to the ground, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | EX · 300 (300–300) |
| Menace | 2 · Wild |
| Element · weakness | Ice · Fire |
| Size | 80 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 239015 · 1573 · 1452 · 1573 · 1452 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Frostveil\|Frostveil]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 44.8 m high × 80 m long × 112.8 m wide; prefab scale 6.667.
- **Physics:** 3886080 kg, gravity ×1.05, poise 2791, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 15.03 m/s, turn 67°/s, stopping distance 6.8 m.
- **Attack count:** 6; **signature:** wings like frozen waterfalls.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Glacirra, the White Silence is a **wild dragon** encountered at EX rank, around level 300. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** wings like frozen waterfalls. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Frostveil|Frostveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Frostveil\|Frostveil]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01433` | Glacirra, the White Silence | [[Regions/Frostveil\|Frostveil]] | Unique | EX | 300 | 80 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · real-animal silhouette with one fantasy exaggeration
