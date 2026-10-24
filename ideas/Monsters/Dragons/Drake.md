---
type: monster
id: mon_drake
family: "Dragons"
rank: "E"
tier: core
tags: [monster, dragons]
---
# Drake

![[mon_drake_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_drake_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,776 tris · 0.688 × 2 × 1.343 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Drake is a person-sized creature with a powerful four-legged hunter's body, about 2 m long. Its scales are weathered and natural, colored in ember reds fading to soot black. Survivors describe stubby wings and a smoking snout. It has alert animal eyes. Small scars and rough edges mark it as a survivor. It lopes in long strides, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1741 · 137 · 114 · 91 · 103 · 100 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Lirian\|Lirian]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.3 m high × 2 m long × 0.32 m wide; prefab scale 0.5.
- **Physics:** 160 kg, gravity ×1.2, poise 57, knockback resistance 0.88, death style `heavy_fall_dust`.
- **Navigation:** speed 5.46 m/s, turn 226°/s, stopping distance 0.8 m.
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

Drake is a **wild dragon** encountered at E rank, around level 26. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** stubby wings and a smoking snout. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons E|loot_draconic_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Dragons/Elder Drake|Elder Drake]]

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 7 | E-, D-, D, E+, E, F+ | 13–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01341` | Lirian Drake Juvenile | [[Regions/Lirian\|Lirian]] | Juvenile | E- | 19 | 1.7 m | Day & Night | Like a typical Drake, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01342` | Lirian Drake Alpha | [[Regions/Lirian\|Lirian]] | Alpha | D- | 40 | 2.5 m | Day & Night | Like a typical Drake, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01343` | Lirian Drake Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | D | 48 | 2.7 m | Day & Night | Like a typical Drake, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01344` | Lirian Drake Scarred | [[Regions/Lirian\|Lirian]] | Scarred | E+ | 32 | 2.2 m | Day & Night | Like a typical Drake, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01345` | Lirian Drake | [[Regions/Lirian\|Lirian]] | Adult | E | 26 | 2 m | Day & Night | A typical adult Drake of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01346` | Lirian Drake Albino | [[Regions/Lirian\|Lirian]] | Albino | E+ | 32 | 2 m | Day & Night | Like a typical Drake, but a rare pale form with white skin or fur and red eyes. |
| `pop_01347` | Lirian Drake Runt | [[Regions/Lirian\|Lirian]] | Runt | F+ | 13 | 1.4 m | Day & Night | Like a typical Drake, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · real-animal silhouette with one fantasy exaggeration
