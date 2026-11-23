---
type: monster
id: mon_titan_of_the_first_age
family: "Constructs & Mimics"
rank: "EX"
tier: core
tags: [monster, constructs-mimics, unique]
---
# Titan of the First Age

![[mon_titan_of_the_first_age_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_titan_of_the_first_age_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 478.646 × 183.461 × 500.016 m · local file `Game/Assets/_Game/Art/Models/Monsters/Constructs & Mimics/mon_titan_of_the_first_age.fbx`

> The Titan of the First Age is a colossal creature with a blocky construct body, about 500 m tall. Its surface is rough, scarred and spiked, colored in weathered stone, with ochre markings. Its most striking feature is a walking continent of machinery and stone. It has narrow glowing eyes. Its presence is world-scale; the sky changes color when it appears. It charges without hesitation, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | EX · 300 (300–300) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 500 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 229444 · 1210 · 1815 · 726 · 1210 · 70 |
| XP · gold | 551660 · 4409 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 500 m high × 150 m long × 210 m wide; prefab scale 166.667.
- **Physics:** 7800000000 kg, gravity ×1.32, poise 6978, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 39.22 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** a walking continent of machinery and stone.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Titan of the First Age is a **menacing construct** encountered at EX rank, around level 300. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a walking continent of machinery and stone. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sky Archipelago|Sky Archipelago]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics EX|loot_construct_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
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
| `pop_01572` | Titan of the First Age | [[Regions/Sky Archipelago\|Sky Archipelago]] | Unique | EX | 300 | 500 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `rock_debris` · palette `#8b8a84` `#5b5a55` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
