---
type: monster
id: mon_leviathan
family: "Aquatic"
rank: "EX"
tier: core
tags: [monster, aquatic, unique]
---
# Leviathan

![[mon_leviathan_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_leviathan_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Leviathan is a colossal creature with a heavy-jawed fish frame, about 600 m long. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Look for a body so vast it moves the horizon. It has eyes that catch torchlight like coins. Its presence is world-scale; the sky changes color when it appears. It strides with heavy steps, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | EX · 300 (300–300) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 600 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 163889 · 1513 · 1089 · 1089 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 240 m high × 600 m long × 216 m wide; prefab scale 400.
- **Physics:** 5216400000 kg, gravity ×1, poise 1241691, knockback resistance 0.57, death style `float_belly_up`.
- **Navigation:** speed 60 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** a body so vast it moves the horizon.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Leviathan is a **menacing aquatic** encountered at EX rank, around level 300. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body so vast it moves the horizon. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Goldmere Coast|Goldmere Coast]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic EX|loot_aquatic_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02051` | Leviathan | [[Regions/Goldmere Coast\|Goldmere Coast]] | Unique | EX | 300 | 600 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
