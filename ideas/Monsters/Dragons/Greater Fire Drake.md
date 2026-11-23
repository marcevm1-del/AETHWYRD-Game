---
type: monster
id: mon_greater_fire_drake
family: "Dragons"
rank: "C"
tier: variant
tags: [monster, dragons]
---
# Greater Fire Drake

![[mon_greater_fire_drake_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_fire_drake_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 19,998 tris · 1.599 × 4.801 × 1.201 m · local file `Game/Assets/_Game/Art/Models/Monsters/Dragons/mon_greater_fire_drake.fbx`

> The Greater Fire Drake is a large creature with a long-legged predatory quadruped build, about 4.8 m long. Its scales are rough, scarred and spiked, colored in sapphire, with ember-orange markings. Its most striking feature is ember scales and a magma-glowing belly. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Fire Drake\|Fire Drake]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 4.8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11205 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Zarvan\|Zarvan]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 3.12 m high × 4.8 m long × 0.77 m wide; prefab scale 1.2.
- **Physics:** 2211.8 kg, gravity ×1.2, poise 111, knockback resistance 0.94, death style `heavy_fall_dust`.
- **Navigation:** speed 8.88 m/s, turn 146°/s, stopping distance 1.36 m.
- **Attack count:** 5; **signature:** ember scales and a magma-glowing belly.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Fire Drake is a **menacing dragon** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** ember scales and a magma-glowing belly. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons C|loot_draconic_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 6 | C, C+, C-, D+, B, B- | 56–108 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 5 | B-, C+, D+, C | 56–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04241` | Iron Hold Greater Fire Drake | [[Regions/Iron Hold\|Iron Hold]] | Adult | C | 76 | 4.8 m | Day & Night | A typical adult Greater Fire Drake of this region, with slate-grey coloring and hardened hide. |
| `pop_04242` | Iron Hold Greater Fire Drake Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C+ | 86 | 5.28 m | Day & Night | Like a typical Greater Fire Drake, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04243` | Iron Hold Greater Fire Drake Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | C- | 65 | 4.08 m | Day & Night | Like a typical Greater Fire Drake, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04244` | Iron Hold Greater Fire Drake Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D+ | 56 | 3.36 m | Day & Night | Like a typical Greater Fire Drake, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04245` | Zarvan Greater Fire Drake Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | B- | 96 | 6 m | Day & Night | Like a typical Greater Fire Drake, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04246` | Zarvan Greater Fire Drake Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | C+ | 86 | 5.28 m | Day & Night | Like a typical Greater Fire Drake, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04247` | Zarvan Greater Fire Drake Runt | [[Regions/Zarvan\|Zarvan]] | Runt | D+ | 56 | 3.36 m | Day & Night | Like a typical Greater Fire Drake, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04248` | Zarvan Greater Fire Drake | [[Regions/Zarvan\|Zarvan]] | Adult | C | 76 | 4.8 m | Day & Night | A typical adult Greater Fire Drake of this region, with slate-grey coloring and hardened hide. |
| `pop_04249` | Iron Hold Greater Fire Drake Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | B | 108 | 6.48 m | Day & Night | Like a typical Greater Fire Drake, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04250` | Iron Hold Greater Fire Drake Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | B- | 96 | 6 m | Day & Night | Like a typical Greater Fire Drake, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04251` | Zarvan Greater Fire Drake Albino | [[Regions/Zarvan\|Zarvan]] | Albino | C+ | 86 | 4.8 m | Day & Night | Like a typical Greater Fire Drake, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#2c6888` `#22485e` `#ff7a3d` · triangle-based silhouette, sharp asymmetric spikes
