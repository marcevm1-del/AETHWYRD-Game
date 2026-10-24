---
type: monster
id: mon_frost_drake
family: "Dragons"
rank: "D"
tier: core
tags: [monster, dragons]
---
# Frost Drake

![[mon_frost_drake_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_frost_drake_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,942 tris · 1.157 × 3 × 2.61 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Frost Drake is a large creature with a long-legged predatory quadruped build, about 3 m long. Its scales are rough, scarred and spiked, colored in pale blues and frost-white. Guild sketches always show blue-white scales with frost on every edge. It has narrow glowing eyes. A distinctive marking runs along its back. It charges without hesitation, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4870 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Lirian\|Lirian]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 594 kg, gravity ×1.26, poise 79, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 6.15 m/s, turn 185°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** blue-white scales with frost on every edge.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Frost Drake is a **menacing dragon** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** blue-white scales with frost on every edge. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons D|loot_draconic_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Dragons/Cinder Drake|Cinder Drake]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 2 | C, C- | 65–76 | Day & Night |
| [[Regions/Lirian\|Lirian]] | 3 | C-, D-, D+ | 40–65 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | D+, E+, C | 32–76 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 3 | D, D+, C | 48–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01359` | Iron Hold Frost Drake Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C | 76 | 4.05 m | Day & Night | Like a typical Frost Drake, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01360` | Lirian Frost Drake Alpha | [[Regions/Lirian\|Lirian]] | Alpha | C- | 65 | 3.75 m | Day & Night | Like a typical Frost Drake, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01361` | Hoshizora Frost Drake Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 3.3 m | Day & Night | Like a typical Frost Drake, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01362` | Lirian Frost Drake Juvenile | [[Regions/Lirian\|Lirian]] | Juvenile | D- | 40 | 2.55 m | Day & Night | Like a typical Frost Drake, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01363` | Iron Hold Frost Drake Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C- | 65 | 3.75 m | Day & Night | Like a typical Frost Drake, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01364` | Kitsune Isles Frost Drake | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Frost Drake of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01365` | Kitsune Isles Frost Drake Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | D+ | 56 | 3.3 m | Day & Night | Like a typical Frost Drake, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01366` | Hoshizora Frost Drake Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E+ | 32 | 2.1 m | Day & Night | Like a typical Frost Drake, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01367` | Lirian Frost Drake Albino | [[Regions/Lirian\|Lirian]] | Albino | D+ | 56 | 3 m | Day & Night | Like a typical Frost Drake, but a rare pale form with white skin or fur and red eyes. |
| `pop_01368` | Hoshizora Frost Drake Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C | 76 | 4.05 m | Day & Night | Like a typical Frost Drake, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01369` | Kitsune Isles Frost Drake Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C | 76 | 4.05 m | Day & Night | Like a typical Frost Drake, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
