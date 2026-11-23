---
type: monster
id: mon_the_colossus_of_sunscar_walker_of_the_dunes
family: "Constructs & Mimics"
rank: "A+"
tier: core
tags: [monster, constructs-mimics, tyrant, unique]
---
# The Colossus of Sunscar, Walker of the Dunes

![[mon_the_colossus_of_sunscar_walker_of_the_dunes_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_the_colossus_of_sunscar_walker_of_the_dunes_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 57.906 × 21.446 × 60.006 m · local file `Game/Assets/_Game/Art/Models/Monsters/Constructs & Mimics/mon_the_colossus_of_sunscar_walker_of_the_dunes.fbx`

> The The Colossus of Sunscar, Walker of the Dunes is a colossal creature with a towering machine-like frame, about 60 m tall. Its surface is weathered and natural, colored in riveted iron, with ochre markings. Guild sketches always show a walking ruin you can climb, with a Valdrisian heart-core. It has alert animal eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It prowls, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | A+ · 159 (146–173) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 60 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 81584 · 646 · 969 · 388 · 646 · 70 |
| XP · gold | 199864 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Sunscar\|Sunscar]] |
| Tyrant | Yes |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Wind. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 60 m high × 18 m long × 25.2 m wide; prefab scale 20.
- **Physics:** 13478400 kg, gravity ×1.32, poise 1800, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 11.64 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** a walking ruin you can climb, with a Valdrisian heart-core.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

The Colossus of Sunscar, Walker of the Dunes is a **wild construct** encountered at A+ rank, around level 159. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a walking ruin you can climb, with a Valdrisian heart-core. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics A|loot_construct_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06733` | The Colossus of Sunscar, Walker of the Dunes | [[Regions/Sunscar\|Sunscar]] | Unique | A+ | 159 | 60 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `rock_debris` · palette `#737c82` `#50585d` `#d1a15a` · real-animal silhouette with one fantasy exaggeration
