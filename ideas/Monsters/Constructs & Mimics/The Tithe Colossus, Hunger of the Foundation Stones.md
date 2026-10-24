---
type: monster
id: mon_the_tithe_colossus_hunger_of_the_foundation_stones
family: "Constructs & Mimics"
rank: "B+"
tier: core
tags: [monster, constructs-mimics, tyrant, unique]
---
# The Tithe Colossus, Hunger of the Foundation Stones

![[mon_the_tithe_colossus_hunger_of_the_foundation_stones_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_the_tithe_colossus_hunger_of_the_foundation_stones_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (406 tris · 6.935 × 4.602 × 7 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The The Tithe Colossus, Hunger of the Foundation Stones is a huge creature with a heavy, hand-built humanoid shell, about 7 m tall. Its surface is rough, scarred and spiked, colored in warm gold and pearl white. Look for a Foundation Stone that woke up hungry for the nobles' mana. It has narrow glowing eyes. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 7 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 31630 · 490 · 735 · 294 · 490 · 70 |
| XP · gold | 127464 · 1225 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Velmark\|Velmark]] |
| Tyrant | Yes |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Dark. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 7 m high × 2.1 m long × 2.94 m wide; prefab scale 2.333.
- **Physics:** 15640.8 kg, gravity ×1.08, poise 562, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 4.54 m/s, turn 76°/s, stopping distance 1.94 m.
- **Attack count:** 5; **signature:** a Foundation Stone that woke up hungry for the nobles' mana.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

The Tithe Colossus, Hunger of the Foundation Stones is a **menacing construct** encountered at B+ rank, around level 120. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a Foundation Stone that woke up hungry for the nobles' mana. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Velmark|Velmark]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics B|loot_construct_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Velmark\|Velmark]] | 1 | B+ | 120–120 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06725` | The Tithe Colossus, Hunger of the Foundation Stones | [[Regions/Velmark\|Velmark]] | Unique | B+ | 120 | 7 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
