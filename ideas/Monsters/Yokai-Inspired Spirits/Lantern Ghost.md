---
type: monster
id: mon_lantern_ghost
family: "Yokai-Inspired Spirits"
rank: "E"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Lantern Ghost

![[mon_lantern_ghost_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_lantern_ghost_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,646 tris · 0.555 × 0.464 × 0.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Lantern Ghost is a small creature with a floating, cloth-like shape, about 0.6 m tall. Its form is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is a paper lantern with a torn mouth. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 0.6 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 857 · 68 · 80 · 160 · 148 · 90 |
| XP · gold | 559 · 147 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_floating` |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (rigId); animation set `anim_floating`.
- **Dimensions:** 0.6 m high × 0.18 m long × 0.38 m wide; prefab scale 0.6.
- **Physics:** 0.5 kg, gravity ×0, poise 6, knockback resistance 0.03, death style `dissolve_into_motes`.
- **Navigation:** speed 4.4 m/s, turn 900°/s, stopping distance 0.55 m.
- **Attack count:** 5; **signature:** a paper lantern with a torn mouth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chill Touch\|Chill Touch]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Phase Lunge\|Phase Lunge]] | dash | 1.3 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wail\|Wail]] | aoe | 1.2 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Lantern Ghost is a **menacing spirit** encountered at E rank, around level 26. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a paper lantern with a torn mouth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_floating`, animation set `anim_floating`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits E|loot_yokai_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Phantom Lantern Ghost|Phantom Lantern Ghost]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 6 | D-, E+, E-, D, F+ | 13–48 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 3 | E+, D, E | 26–48 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 2 | E+, E- | 19–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02461` | Hoshizora Lantern Ghost Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | D- | 40 | 0.75 m | Day & Night | Like a typical Lantern Ghost, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02462` | Kitsune Isles Lantern Ghost Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | E+ | 32 | 0.6 m | Day & Night | Like a typical Lantern Ghost, but a rare pale form with white skin or fur and red eyes. |
| `pop_02463` | Kitsune Isles Lantern Ghost Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | D | 48 | 0.81 m | Day & Night | Like a typical Lantern Ghost, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02464` | Hoshizora Lantern Ghost Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | E+ | 32 | 0.66 m | Day & Night | Like a typical Lantern Ghost, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02465` | Shen-Lu Lantern Ghost Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | E+ | 32 | 0.66 m | Day & Night | Like a typical Lantern Ghost, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02466` | Shen-Lu Lantern Ghost Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | E- | 19 | 0.51 m | Day & Night | Like a typical Lantern Ghost, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02467` | Hoshizora Lantern Ghost Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | E- | 19 | 0.51 m | Day & Night | Like a typical Lantern Ghost, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02468` | Kitsune Isles Lantern Ghost | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | E | 26 | 0.6 m | Day & Night | A typical adult Lantern Ghost of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02469` | Hoshizora Lantern Ghost Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | D | 48 | 0.81 m | Day & Night | Like a typical Lantern Ghost, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02470` | Hoshizora Lantern Ghost Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | F+ | 13 | 0.42 m | Day & Night | Like a typical Lantern Ghost, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02471` | Hoshizora Lantern Ghost Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | E+ | 32 | 0.6 m | Day & Night | Like a typical Lantern Ghost, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `paper_ink_spirit` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
