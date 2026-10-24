---
type: monster
id: mon_cinder_troll
family: "Orcs, Ogres & Giants"
rank: "B-"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Cinder Troll

![[mon_cinder_troll_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cinder_troll_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cinder Troll is a large creature with a towering, heavy-limbed body, about 3.2 m tall. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Look for moss-covered skin that knits itself back together. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It circles its prey, surrounded by heat-shimmer and drifting sparks. Adapted to volcanic lands, it has ash-dark coloring with glowing cracks.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Troll\|Troll]] (regional) |
| Rank · level | B- · 96 (86–108) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 3.2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17685 · 394 · 591 · 236 · 394 · 70 |
| XP · gold | 4462 · 897 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Dragon Spine\|Dragon Spine]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 3.2 m high × 0.96 m long × 1.34 m wide; prefab scale 0.914.
- **Physics:** 589.8 kg, gravity ×1.3, poise 214, knockback resistance 0.87, death style `heavy_fall_dust`.
- **Navigation:** speed 6.32 m/s, turn 212°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** moss-covered skin that knits itself back together.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cinder Troll is a **menacing giant** encountered at B- rank, around level 96. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** moss-covered skin that knits itself back together. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Dragon Spine|Dragon Spine]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants B|loot_orc_giant_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dragon Spine\|Dragon Spine]] | 5 | C+, B, C, B+, B- | 76–120 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 6 | B+, B-, B, C, A- | 76–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04002` | Dragon Spine Cinder Troll Juvenile | [[Regions/Dragon Spine\|Dragon Spine]] | Juvenile | C+ | 86 | 2.72 m | Day & Night | Like a typical Cinder Troll, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04003` | Iron Hold Cinder Troll Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | B+ | 120 | 4 m | Day & Night | Like a typical Cinder Troll, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04004` | Iron Hold Cinder Troll | [[Regions/Iron Hold\|Iron Hold]] | Adult | B- | 96 | 3.2 m | Day & Night | A typical adult Cinder Troll of this region, with slate-grey coloring and hardened hide. |
| `pop_04005` | Iron Hold Cinder Troll Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | B | 108 | 3.2 m | Day & Night | Like a typical Cinder Troll, but a rare pale form with white skin or fur and red eyes. |
| `pop_04006` | Iron Hold Cinder Troll Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | C | 76 | 2.24 m | Day & Night | Like a typical Cinder Troll, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04007` | Iron Hold Cinder Troll Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B | 108 | 3.52 m | Day & Night | Like a typical Cinder Troll, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04008` | Dragon Spine Cinder Troll Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | B | 108 | 3.52 m | Day & Night | Like a typical Cinder Troll, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04009` | Dragon Spine Cinder Troll Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | C | 76 | 2.24 m | Day & Night | Like a typical Cinder Troll, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04010` | Dragon Spine Cinder Troll Alpha | [[Regions/Dragon Spine\|Dragon Spine]] | Alpha | B+ | 120 | 4 m | Day & Night | Like a typical Cinder Troll, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04011` | Iron Hold Cinder Troll Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | A- | 132 | 4.32 m | Day & Night | Like a typical Cinder Troll, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04012` | Dragon Spine Cinder Troll | [[Regions/Dragon Spine\|Dragon Spine]] | Adult | B- | 96 | 3.2 m | Day & Night | A typical adult Cinder Troll of this region, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
