---
type: monster
id: mon_frost_giant
family: "Orcs, Ogres & Giants"
rank: "A"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Frost Giant

![[mon_frost_giant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_frost_giant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,534 tris · 7.73 × 5.108 × 9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Frost Giant is a huge creature with a massive hunched brute frame, about 9 m tall. Its hide is rough, scarred and spiked, colored in stone-grey, with frost-blue markings. Survivors describe a beard of icicles and armor of glacier ice. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 45625 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Frostveil\|Frostveil]], [[Regions/Quaking Lands\|Quaking Lands]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 9 m high × 2.7 m long × 3.78 m wide; prefab scale 2.571.
- **Physics:** 14434.2 kg, gravity ×1.37, poise 393, knockback resistance 0.9, death style `heavy_fall_dust`.
- **Navigation:** speed 10.21 m/s, turn 127°/s, stopping distance 2.2 m.
- **Attack count:** 5; **signature:** a beard of icicles and armor of glacier ice.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Frost Giant is a **menacing giant** encountered at A rank, around level 146. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a beard of icicles and armor of glacier ice. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Frostveil|Frostveil]], [[Regions/Quaking Lands|Quaking Lands]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants A|loot_orc_giant_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Frost Giant|Vesper-Touched Frost Giant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Frostveil\|Frostveil]] | 2 | S, A | 146–188 | Day & Night |
| [[Regions/Quaking Lands\|Quaking Lands]] | 2 | S, B+ | 120–188 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | A-, A+ | 132–159 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 2 | A+ | 159–159 | Day & Night |
| [[Regions/Dragon Spine\|Dragon Spine]] | 3 | B+, S-, A- | 120–173 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01149` | Frostveil Frost Giant Elderborn | [[Regions/Frostveil\|Frostveil]] | Elderborn | S | 188 | 12.15 m | Day & Night | Like a typical Frost Giant, but old and wise, with greying features and a cautious hunting style, with a thick, frost-rimed coat. |
| `pop_01150` | Quaking Lands Frost Giant Elderborn | [[Regions/Quaking Lands\|Quaking Lands]] | Elderborn | S | 188 | 12.15 m | Day & Night | Like a typical Frost Giant, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01151` | Iron Hold Frost Giant Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | A- | 132 | 7.65 m | Day & Night | Like a typical Frost Giant, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01152` | Vharlen Frost Giant Scarred | [[Regions/Vharlen\|Vharlen]] | Scarred | A+ | 159 | 9.9 m | Day & Night | Like a typical Frost Giant, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_01153` | Quaking Lands Frost Giant Runt | [[Regions/Quaking Lands\|Quaking Lands]] | Runt | B+ | 120 | 6.3 m | Day & Night | Like a typical Frost Giant, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01154` | Dragon Spine Frost Giant Runt | [[Regions/Dragon Spine\|Dragon Spine]] | Runt | B+ | 120 | 6.3 m | Day & Night | Like a typical Frost Giant, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01155` | Dragon Spine Frost Giant Alpha | [[Regions/Dragon Spine\|Dragon Spine]] | Alpha | S- | 173 | 11.25 m | Day & Night | Like a typical Frost Giant, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01156` | Dragon Spine Frost Giant Juvenile | [[Regions/Dragon Spine\|Dragon Spine]] | Juvenile | A- | 132 | 7.65 m | Day & Night | Like a typical Frost Giant, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01157` | Vharlen Frost Giant Albino | [[Regions/Vharlen\|Vharlen]] | Albino | A+ | 159 | 9 m | Day & Night | Like a typical Frost Giant, but a rare pale form with white skin or fur and red eyes. |
| `pop_01158` | Frostveil Frost Giant | [[Regions/Frostveil\|Frostveil]] | Adult | A | 146 | 9 m | Day & Night | A typical adult Frost Giant of this region, with a thick, frost-rimed coat. |
| `pop_01159` | Iron Hold Frost Giant Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | A+ | 159 | 9 m | Day & Night | Like a typical Frost Giant, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `frost_trail_snow` · palette `#7b808b` `#52575f` `#9fdcff` · triangle-based silhouette, sharp asymmetric spikes
