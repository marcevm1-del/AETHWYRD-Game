---
type: monster
id: mon_elder_primeval_titan_kin
family: "Orcs, Ogres & Giants"
rank: "EX"
tier: variant
tags: [monster, orcs-ogres-giants, unique]
---
# Elder Primeval Titan-Kin

![[mon_elder_primeval_titan_kin_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_primeval_titan_kin_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 81.967 × 50.053 × 64.007 m · local file `Game/Assets/_Game/Art/Models/Monsters/Orcs, Ogres & Giants/mon_elder_primeval_titan_kin.fbx`

> The Elder Primeval Titan-Kin is a colossal creature with a giant, barrel-chested humanoid body, about 64 m tall. Its hide is rough, scarred and spiked, colored in olive-green, with ochre markings. Survivors describe a body of living bedrock wearing fragments of Titan armor. It has narrow glowing eyes. Its presence is world-scale; the sky changes color when it appears. It strides with heavy steps, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Primeval Titan-Kin\|Primeval Titan-Kin]] (elder) |
| Rank · level | EX · 300 (300–300) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 64 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 213715 · 1210 · 1815 · 726 · 1210 · 70 |
| XP · gold | 551660 · 4409 |
| Ring | 9 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 64 m high × 19.2 m long × 26.88 m wide; prefab scale 18.286.
- **Physics:** 6134169.6 kg, gravity ×1.43, poise 1618, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 27.22 m/s, turn 60°/s, stopping distance 12.4 m.
- **Attack count:** 5; **signature:** a body of living bedrock wearing fragments of Titan armor.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Primeval Titan-Kin is a **menacing giant** encountered at EX rank, around level 300. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a body of living bedrock wearing fragments of Titan armor. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants EX|loot_orc_giant_ex]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
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
| `pop_04079` | Elder Primeval Titan-Kin | [[Regions/Nox Dominion\|Nox Dominion]] | Unique | EX | 300 | 64 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `rock_debris` · palette `#668345` `#45582f` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
