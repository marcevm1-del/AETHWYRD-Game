---
type: monster
id: mon_ilyanthe_the_moon_harvester
family: "Vesperites (Moon Raiders)"
rank: "S"
tier: core
tags: [monster, vesperites-moon-raiders, tyrant, unique]
---
# Ilyanthe, the Moon Harvester

![[mon_ilyanthe_the_moon_harvester_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ilyanthe_the_moon_harvester_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,660 tris · 6.178 × 5.739 × 6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ilyanthe, the Moon Harvester is a huge creature with a bodiless, glowing form, about 6 m tall. Its porcelain shell is stretched, stitched and constantly shifting, colored in arterial crimson and dried-blood brown. Its most striking feature is a lantern cage of red glass holding the stolen souls of the gem-folk. It has too many eyes, opening one after another. Its regal silhouette is crowned by a halo-like ring of aura. It copies the walk of whatever it hunts, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Vesperites (Moon Raiders)|Vesperites (Moon Raiders)]] · Lunar Raider |
| Rank · level | S · 188 (173–203) |
| Menace | 5 · Horror |
| Element · weakness | Blood · Light |
| Size | 6 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 33741 · 457 · 533 · 1067 · 991 · 90 |
| XP · gold | 261258 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Lustrine Shores\|Lustrine Shores]] |
| Tyrant | Yes |
| Genre | Cosmic Fantasy |
| Trope | Serene moon-raiders harvesting gem people (Land of the Lustrous) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 6 m high × 1.8 m long × 3.84 m wide; prefab scale 6.
- **Physics:** 23.8 kg, gravity ×0, poise 150, knockback resistance 0.18, death style `dissolve_into_motes`.
- **Navigation:** speed 15.35 m/s, turn 294°/s, stopping distance 1.9 m.
- **Attack count:** 5; **signature:** a lantern cage of red glass holding the stolen souls of the gem-folk.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Moonglass Shard\|Moonglass Shard]] | ranged | 1.3 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ilyanthe, the Moon Harvester is a **horror lunar raider** encountered at S rank, around level 188. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lantern cage of red glass holding the stolen souls of the gem-folk. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lustrine Shores|Lustrine Shores]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Vesperites (Moon Raiders) S|loot_vesperite_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Vesper Glass\|Vesper Glass]] | 60% | 1–3 |
| [[Items/Captured Soul-Light\|Captured Soul-Light]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lustrine Shores\|Lustrine Shores]] | 1 | S | 188–188 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06752` | Ilyanthe, the Moon Harvester | [[Regions/Lustrine Shores\|Lustrine Shores]] | Unique | S | 188 | 6 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `porcelain_red_glow` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · broken symmetry, mimicry, audio-first reveal
