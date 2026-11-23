---
type: monster
id: mon_cyclops
family: "Orcs, Ogres & Giants"
rank: "B+"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Cyclops

![[mon_cyclops_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cyclops_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 6.119 × 4.754 × 6.001 m · local file `Game/Assets/_Game/Art/Models/Monsters/Orcs, Ogres & Giants/mon_cyclops.fbx`

> The Cyclops is a huge creature with a giant, barrel-chested humanoid body, about 6 m tall. Its hide is rough, scarred and spiked, colored in sun-brown, with ochre markings. Survivors describe a single huge eye and a hammer made from a millstone. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 6 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 30186 · 490 · 735 · 294 · 490 · 70 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Frostveil\|Frostveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 6 m high × 1.8 m long × 2.52 m wide; prefab scale 1.714.
- **Physics:** 5054.4 kg, gravity ×1.43, poise 293, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 7.96 m/s, turn 155°/s, stopping distance 1.6 m.
- **Attack count:** 5; **signature:** a single huge eye and a hammer made from a millstone.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cyclops is a **menacing giant** encountered at B+ rank, around level 120. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a single huge eye and a hammer made from a millstone. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Frostveil|Frostveil]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants B|loot_orc_giant_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Cyclops|Vesper-Touched Cyclops]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 2 | A-, B- | 96–132 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 2 | B+, A+ | 120–159 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 2 | A-, A | 132–146 | Day & Night |
| [[Regions/Frostveil\|Frostveil]] | 5 | B+, B-, A, A-, B | 96–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01138` | Iron Hold Cyclops Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | A- | 132 | 6.6 m | Day & Night | Like a typical Cyclops, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01139` | Dragon Spine Cyclops | [[Regions/Dragon Spine\|Dragon Spine]] | Adult | B+ | 120 | 6 m | Day & Night | A typical adult Cyclops of this region, with slate-grey coloring and hardened hide. |
| `pop_01140` | Iron Hold Cyclops Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B- | 96 | 4.2 m | Day & Night | Like a typical Cyclops, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01141` | Vharlen Cyclops Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | A- | 132 | 6.6 m | Day & Night | Like a typical Cyclops, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_01142` | Frostveil Cyclops | [[Regions/Frostveil\|Frostveil]] | Adult | B+ | 120 | 6 m | Day & Night | A typical adult Cyclops of this region, with a thick, frost-rimed coat. |
| `pop_01143` | Frostveil Cyclops Runt | [[Regions/Frostveil\|Frostveil]] | Runt | B- | 96 | 4.2 m | Day & Night | Like a typical Cyclops, but smaller and scrappier than usual, with a thick, frost-rimed coat. |
| `pop_01144` | Frostveil Cyclops Alpha | [[Regions/Frostveil\|Frostveil]] | Alpha | A | 146 | 7.5 m | Day & Night | Like a typical Cyclops, but larger and scarred, and others of its kind follow it, with a thick, frost-rimed coat. |
| `pop_01145` | Dragon Spine Cyclops Elderborn | [[Regions/Dragon Spine\|Dragon Spine]] | Elderborn | A+ | 159 | 8.1 m | Day & Night | Like a typical Cyclops, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01146` | Frostveil Cyclops Albino | [[Regions/Frostveil\|Frostveil]] | Albino | A- | 132 | 6 m | Day & Night | Like a typical Cyclops, but a rare pale form with white skin or fur and red eyes. |
| `pop_01147` | Frostveil Cyclops Juvenile | [[Regions/Frostveil\|Frostveil]] | Juvenile | B | 108 | 5.1 m | Day & Night | Like a typical Cyclops, but young, with brighter colors and unworn features, with a thick, frost-rimed coat. |
| `pop_01148` | Vharlen Cyclops Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | A | 146 | 7.5 m | Day & Night | Like a typical Cyclops, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `rock_debris` · palette `#a97863` `#6e4f42` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
