---
type: monster
id: mon_elder_drake
family: "Dragons"
rank: "D"
tier: variant
tags: [monster, dragons]
---
# Elder Drake

![[mon_elder_drake_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_drake_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,328 tris · 1.234 × 3.2 × 2.784 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Drake is a large creature with a heavy, muscular quadruped frame, about 3.2 m long. Its scales are weathered and natural, colored in sapphire, with ember-orange markings. Survivors describe stubby wings and a smoking snout. It has dark, wary eyes. A distinctive marking runs along its back. It prowls, surrounded by heat-shimmer and drifting sparks. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Drake\|Drake]] (elder) |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 3.2 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4976 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.08 m high × 3.2 m long × 0.51 m wide; prefab scale 0.8.
- **Physics:** 655.4 kg, gravity ×1.2, poise 81, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 6.22 m/s, turn 179°/s, stopping distance 1.04 m.
- **Attack count:** 5; **signature:** stubby wings and a smoking snout.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Drake is a **wild dragon** encountered at D rank, around level 48. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** stubby wings and a smoking snout. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Iron Hold\|Iron Hold]] | 5 | C-, E+, C, D, D+ | 32–76 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 2 | C, D- | 40–76 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 4 | D, C, D-, C- | 40–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04230` | Iron Hold Elder Drake Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C- | 65 | 4 m | Day & Night | Like a typical Elder Drake, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04231` | Hoshizora Elder Drake Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C | 76 | 4.32 m | Day & Night | Like a typical Elder Drake, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04232` | Iron Hold Elder Drake Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | E+ | 32 | 2.24 m | Day & Night | Like a typical Elder Drake, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04233` | Hoshizora Elder Drake Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 2.72 m | Day & Night | Like a typical Elder Drake, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04234` | Kitsune Isles Elder Drake | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D | 48 | 3.2 m | Day & Night | A typical adult Elder Drake of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04235` | Kitsune Isles Elder Drake Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C | 76 | 4.32 m | Day & Night | Like a typical Elder Drake, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04236` | Kitsune Isles Elder Drake Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | D- | 40 | 2.72 m | Day & Night | Like a typical Elder Drake, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04237` | Iron Hold Elder Drake Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C | 76 | 4.32 m | Day & Night | Like a typical Elder Drake, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04238` | Kitsune Isles Elder Drake Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C- | 65 | 4 m | Day & Night | Like a typical Elder Drake, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04239` | Iron Hold Elder Drake | [[Regions/Iron Hold\|Iron Hold]] | Adult | D | 48 | 3.2 m | Day & Night | A typical adult Elder Drake of this region, with slate-grey coloring and hardened hide. |
| `pop_04240` | Iron Hold Elder Drake Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | D+ | 56 | 3.2 m | Day & Night | Like a typical Elder Drake, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#2b7986` `#22535c` `#ff7a3d` · real-animal silhouette with one fantasy exaggeration
