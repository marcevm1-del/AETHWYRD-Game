---
type: monster
id: mon_dunewhale_thalassa
family: "Sandborne"
rank: "EX"
tier: core
tags: [monster, sandborne, unique]
---
# Dunewhale Thalassa

![[mon_dunewhale_thalassa_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dunewhale_thalassa_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dunewhale Thalassa is a colossal creature with a long, finned body, about 900 m long. Its sand-scoured hide is smooth and clean, colored in ochre, clay and mossy stone. Look for a whale of stone and sand carrying a town on its back. It has wide curious eyes with star-shaped highlights. Its presence is world-scale; the sky changes color when it appears. It hops in little bursts, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | EX · 300 (300–300) |
| Menace | 1 · Charming |
| Element · weakness | Earth · Wind |
| Size | 900 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 163889 · 1513 · 1089 · 1089 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Dunewhale Drift\|Dunewhale Drift]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 360 m high × 900 m long × 324 m wide; prefab scale 600.
- **Physics:** 21797100000 kg, gravity ×1.1, poise 2508487, knockback resistance 0.72, death style `float_belly_up`.
- **Navigation:** speed 60 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** a whale of stone and sand carrying a town on its back.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Sand Burrow\|Sand Burrow]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dunewhale Thalassa is a **charming desert beast** encountered at EX rank, around level 300. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a whale of stone and sand carrying a town on its back. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dunewhale Drift|Dunewhale Drift]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Sandborne EX|loot_sandborne_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dunewhale Drift\|Dunewhale Drift]] | 1 | EX | 300–300 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02717` | Dunewhale Thalassa | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Unique | EX | 300 | 900 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `sand_hide` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · circle-based, soft silhouette
