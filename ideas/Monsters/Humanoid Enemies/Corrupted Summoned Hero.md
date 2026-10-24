---
type: monster
id: mon_corrupted_summoned_hero
family: "Humanoid Enemies"
rank: "EX"
tier: core
tags: [monster, humanoid-enemies, unique]
---
# Corrupted Summoned Hero

![[mon_corrupted_summoned_hero_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_corrupted_summoned_hero_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Corrupted Summoned Hero is a person-sized creature with an upright humanoid build, about 1.9 m tall. Its clothing and gear are patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Guild sketches always show a Veilborn swallowed by the red moon. It has eyes set slightly too far apart. Its presence is world-scale; the sky changes color when it appears. It moves in jerky stop-motion bursts, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | EX · 300 (300–300) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 1.9 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 63933 · 1452 · 1210 · 968 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.9 m high × 0.57 m long × 0.61 m wide; prefab scale 1.056.
- **Physics:** 98.1 kg, gravity ×1.5, poise 139, knockback resistance 0.57, death style `ragdoll`.
- **Navigation:** speed 5.07 m/s, turn 290°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** a Veilborn swallowed by the red moon.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Feint Strike\|Feint Strike]] | counter | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Corrupted Summoned Hero is a **dread humanoid** encountered at EX rank, around level 300. Its documented behaviour is *Pack* and its AI pattern is *pack_flank+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a Veilborn swallowed by the red moon. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Humanoid Enemies EX|loot_humanoid_enemy_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
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
| `pop_02817` | Corrupted Summoned Hero | [[Regions/Nox Dominion\|Nox Dominion]] | Unique | EX | 300 | 1.9 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
