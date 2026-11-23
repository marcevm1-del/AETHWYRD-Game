---
type: monster
id: mon_fox_spirit
family: "Yokai-Inspired Spirits"
rank: "D"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Fox Spirit

![[mon_fox_spirit_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_fox_spirit_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.304 × 1 × 0.717 m · local file `Game/Assets/_Game/Art/Models/Monsters/Yokai-Inspired Spirits/mon_fox_spirit.fbx`

> The Fox Spirit is a small creature with a low, springy quadruped build, about 1 m long. Its form is weathered and natural, colored in indigo, with ember-orange markings. Look for three tails tipped with blue flame. It has alert animal eyes. A distinctive marking runs along its back. It lopes in long strides, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2595 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.68 m high × 1 m long × 0.14 m wide; prefab scale 2.
- **Physics:** 30 kg, gravity ×1.6, poise 37, knockback resistance 0.11, death style `ragdoll_tumble`.
- **Navigation:** speed 9.75 m/s, turn 540°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** three tails tipped with blue flame.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Fox Spirit is a **wild spirit** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** three tails tipped with blue flame. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits D|loot_yokai_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Greater Fox Spirit|Greater Fox Spirit]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 6 | E+, C-, D+, C, D- | 32–76 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 5 | D+, C, D, D-, C- | 40–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02494` | Kitsune Isles Fox Spirit Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | E+ | 32 | 0.7 m | Day & Night | Like a typical Fox Spirit, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02495` | Kitsune Isles Fox Spirit Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Fox Spirit, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02496` | Kitsune Isles Fox Spirit Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | D+ | 56 | 1.1 m | Day & Night | Like a typical Fox Spirit, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02497` | Hoshizora Fox Spirit Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 1.1 m | Day & Night | Like a typical Fox Spirit, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02498` | Kitsune Isles Fox Spirit Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C | 76 | 1.35 m | Day & Night | Like a typical Fox Spirit, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02499` | Hoshizora Fox Spirit Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C | 76 | 1.35 m | Day & Night | Like a typical Fox Spirit, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02500` | Kitsune Isles Fox Spirit Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | D+ | 56 | 1 m | Day & Night | Like a typical Fox Spirit, but a rare pale form with white skin or fur and red eyes. |
| `pop_02501` | Hoshizora Fox Spirit | [[Regions/Hoshizora\|Hoshizora]] | Adult | D | 48 | 1 m | Day & Night | A typical adult Fox Spirit of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_02502` | Kitsune Isles Fox Spirit Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Fox Spirit, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02503` | Hoshizora Fox Spirit Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Fox Spirit, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02504` | Hoshizora Fox Spirit Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Fox Spirit, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `paper_ink_spirit` · VFX `embers_heat_haze` · palette `#4d627f` `#384559` `#ff7a3d` · real-animal silhouette with one fantasy exaggeration
