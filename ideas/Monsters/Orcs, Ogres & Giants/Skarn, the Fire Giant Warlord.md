---
type: monster
id: mon_skarn_the_fire_giant_warlord
family: "Orcs, Ogres & Giants"
rank: "A+"
tier: core
tags: [monster, orcs-ogres-giants, tyrant, unique]
---
# Skarn, the Fire Giant Warlord

![[mon_skarn_the_fire_giant_warlord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_skarn_the_fire_giant_warlord_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Skarn, the Fire Giant Warlord is a huge creature with a towering, heavy-limbed body, about 9.5 m tall. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe a forge-hammer the size of a house and a beard of living flame. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 9.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 52632 · 646 · 969 · 388 · 646 · 70 |
| XP · gold | 199864 · 1815 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]] |
| Tyrant | Yes |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 9.5 m high × 2.85 m long × 3.99 m wide; prefab scale 2.714.
- **Physics:** 15432.8 kg, gravity ×1.3, poise 464, knockback resistance 0.9, death style `heavy_fall_dust`.
- **Navigation:** speed 11.97 m/s, turn 123°/s, stopping distance 2.3 m.
- **Attack count:** 5; **signature:** a forge-hammer the size of a house and a beard of living flame.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Skarn, the Fire Giant Warlord is a **menacing giant** encountered at A+ rank, around level 159. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a forge-hammer the size of a house and a beard of living flame. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants A|loot_orc_giant_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (1)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06722` | Skarn, the Fire Giant Warlord | [[Regions/Iron Hold\|Iron Hold]] | Unique | A+ | 159 | 9.5 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
