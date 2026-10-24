---
type: monster
id: mon_cinder_drake
family: "Dragons"
rank: "D+"
tier: variant
tags: [monster, dragons]
---
# Cinder Drake

![[mon_cinder_drake_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cinder_drake_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,146 tris · 0.68 × 3 × 1.347 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cinder Drake is a large creature with a powerful four-legged hunter's body, about 3 m long. Its scales are rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe blue-white scales with frost on every edge. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. Adapted to volcanic lands, it has ash-dark coloring with glowing cracks.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Frost Drake\|Frost Drake]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6111 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 540 kg, gravity ×1.2, poise 79, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 6.32 m/s, turn 185°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** blue-white scales with frost on every edge.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cinder Drake is a **menacing dragon** encountered at D+ rank, around level 56. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** blue-white scales with frost on every edge. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons D|loot_draconic_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 6 | D-, D+, C-, C+, D | 40–86 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 5 | D, D+, C, D-, C- | 40–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04252` | Iron Hold Cinder Drake Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 2.1 m | Day & Night | Like a typical Cinder Drake, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04253` | Hoshizora Cinder Drake Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D | 48 | 2.55 m | Day & Night | Like a typical Cinder Drake, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04254` | Iron Hold Cinder Drake | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 3 m | Day & Night | A typical adult Cinder Drake of this region, with slate-grey coloring and hardened hide. |
| `pop_04255` | Hoshizora Cinder Drake | [[Regions/Hoshizora\|Hoshizora]] | Adult | D+ | 56 | 3 m | Day & Night | A typical adult Cinder Drake of this region, with slate-grey coloring and hardened hide. |
| `pop_04256` | Iron Hold Cinder Drake Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | C- | 65 | 3 m | Day & Night | Like a typical Cinder Drake, but a rare pale form with white skin or fur and red eyes. |
| `pop_04257` | Hoshizora Cinder Drake Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C | 76 | 3.75 m | Day & Night | Like a typical Cinder Drake, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04258` | Hoshizora Cinder Drake Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D- | 40 | 2.1 m | Day & Night | Like a typical Cinder Drake, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04259` | Iron Hold Cinder Drake Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 4.05 m | Day & Night | Like a typical Cinder Drake, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04260` | Iron Hold Cinder Drake Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D | 48 | 2.55 m | Day & Night | Like a typical Cinder Drake, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04261` | Hoshizora Cinder Drake Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C- | 65 | 3 m | Day & Night | Like a typical Cinder Drake, but a rare pale form with white skin or fur and red eyes. |
| `pop_04262` | Iron Hold Cinder Drake Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C- | 65 | 3.3 m | Day & Night | Like a typical Cinder Drake, but covered in old battle scars, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
