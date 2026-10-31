---
type: monster
id: mon_zahhar_king_of_the_divs
family: "Orcs, Ogres & Giants"
rank: "A+"
tier: core
tags: [monster, orcs-ogres-giants, tyrant, unique]
---
# Zahhar, King of the Divs

![[mon_zahhar_king_of_the_divs_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_zahhar_king_of_the_divs_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,238 tris · 6.871 × 4.156 × 8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Zahhar, King of the Divs is a huge creature with a towering, heavy-limbed body, about 8 m tall. Its hide is rough, scarred and spiked, colored in olive-green, with violet markings. Survivors describe horns of black iron and a throne carried by lesser divs. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 50095 · 646 · 969 · 388 · 646 · 70 |
| XP · gold | 199864 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Zarvan\|Zarvan]] |
| Tyrant | Yes |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 8 m high × 2.4 m long × 3.36 m wide; prefab scale 2.286.
- **Physics:** 9216 kg, gravity ×1.3, poise 426, knockback resistance 0.9, death style `heavy_fall_dust`.
- **Navigation:** speed 10.99 m/s, turn 134°/s, stopping distance 2 m.
- **Attack count:** 5; **signature:** horns of black iron and a throne carried by lesser divs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Zahhar, King of the Divs is a **menacing giant** encountered at A+ rank, around level 159. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** horns of black iron and a throne carried by lesser divs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Zarvan\|Zarvan]] | 1 | A+ | 159–159 | Story |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06735` | Zahhar, King of the Divs | [[Regions/Zarvan\|Zarvan]] | Unique | A+ | 159 | 8 m | Story | Unique being; see the species entry. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `shadow_wisps` · palette `#738848` `#4d5b31` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
