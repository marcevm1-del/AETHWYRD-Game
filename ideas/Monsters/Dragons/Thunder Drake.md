---
type: monster
id: mon_thunder_drake
family: "Dragons"
rank: "D"
tier: core
tags: [monster, dragons]
---
# Thunder Drake

![[mon_thunder_drake_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_thunder_drake_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,794 tris · 1.032 × 3 × 2.015 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Thunder Drake is a large creature with a long-legged predatory quadruped build, about 3 m long. Its scales are rough, scarred and spiked, colored in iron-grey, with electric-yellow markings. Its most striking feature is horns that work like lightning rods. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It charges without hesitation, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4870 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Lirian\|Lirian]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Earth. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 540 kg, gravity ×1.2, poise 79, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 6.5 m/s, turn 185°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** horns that work like lightning rods.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thunder Drake is a **menacing dragon** encountered at D rank, around level 48. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** horns that work like lightning rods. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons D|loot_draconic_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Dragons/Ancient Thunder Drake|Ancient Thunder Drake]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | D, C, D+, D-, E+ | 32–76 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | D, C | 48–76 | Day & Night |
| [[Regions/Lirian\|Lirian]] | 4 | D+, E+, C, D | 32–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01370` | Hoshizora Thunder Drake | [[Regions/Hoshizora\|Hoshizora]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Thunder Drake of this region, with slate-grey coloring and hardened hide. |
| `pop_01371` | Iron Hold Thunder Drake | [[Regions/Iron Hold\|Iron Hold]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Thunder Drake of this region, with slate-grey coloring and hardened hide. |
| `pop_01372` | Iron Hold Thunder Drake Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C | 76 | 4.05 m | Day & Night | Like a typical Thunder Drake, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01373` | Hoshizora Thunder Drake Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C | 76 | 4.05 m | Day & Night | Like a typical Thunder Drake, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01374` | Hoshizora Thunder Drake Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 3.3 m | Day & Night | Like a typical Thunder Drake, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01375` | Lirian Thunder Drake Scarred | [[Regions/Lirian\|Lirian]] | Scarred | D+ | 56 | 3.3 m | Day & Night | Like a typical Thunder Drake, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01376` | Hoshizora Thunder Drake Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 2.55 m | Day & Night | Like a typical Thunder Drake, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01377` | Hoshizora Thunder Drake Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E+ | 32 | 2.1 m | Day & Night | Like a typical Thunder Drake, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01378` | Lirian Thunder Drake Runt | [[Regions/Lirian\|Lirian]] | Runt | E+ | 32 | 2.1 m | Day & Night | Like a typical Thunder Drake, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01379` | Lirian Thunder Drake Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | C | 76 | 4.05 m | Day & Night | Like a typical Thunder Drake, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01380` | Lirian Thunder Drake | [[Regions/Lirian\|Lirian]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Thunder Drake of this region, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `arc_sparks` · palette `#747785` `#51535e` `#ffe14d` · triangle-based silhouette, sharp asymmetric spikes
