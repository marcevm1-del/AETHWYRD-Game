---
type: monster
id: mon_hellhound
family: "Demons"
rank: "D"
tier: core
tags: [monster, demons]
---
# Hellhound

![[mon_hellhound_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hellhound_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,346 tris · 0.578 × 1.5 × 1.305 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Hellhound is a person-sized creature with a heavy, muscular quadruped frame, about 1.5 m long. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Guild sketches always show a dog with a furnace glow inside its ribs. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3845 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Velmark\|Velmark]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 0.98 m high × 1.5 m long × 0.24 m wide; prefab scale 0.375.
- **Physics:** 67.5 kg, gravity ×1.2, poise 56, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 5.46 m/s, turn 261°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** a dog with a furnace glow inside its ribs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Hellfire Brand\|Hellfire Brand]] | magic | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hellhound is a **menacing demon** encountered at D rank, around level 48. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dog with a furnace glow inside its ribs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Velmark|Velmark]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Demons D|loot_demon_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Demons/Mud Hellhound|Mud Hellhound]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 4 | C-, D, D-, D+ | 40–65 | Day & Night |
| [[Regions/Velmark\|Velmark]] | 6 | D+, D, C, C-, D- | 40–76 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 1 | C- | 65–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01824` | Strife Marches Hellhound Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | C- | 65 | 1.88 m | Day & Night | Like a typical Hellhound, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01825` | Velmark Hellhound Albino | [[Regions/Velmark\|Velmark]] | Albino | D+ | 56 | 1.5 m | Day & Night | Like a typical Hellhound, but a rare pale form with white skin or fur and red eyes. |
| `pop_01826` | Velmark Hellhound | [[Regions/Velmark\|Velmark]] | Adult | D | 48 | 1.5 m | Day & Night | A typical adult Hellhound of this region, with soot-stained hide and scavenged scraps. |
| `pop_01827` | Velmark Hellhound Elderborn | [[Regions/Velmark\|Velmark]] | Elderborn | C | 76 | 2.03 m | Day & Night | Like a typical Hellhound, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |
| `pop_01828` | Velmark Hellhound Alpha | [[Regions/Velmark\|Velmark]] | Alpha | C- | 65 | 1.88 m | Day & Night | Like a typical Hellhound, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_01829` | Strife Marches Hellhound | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 1.5 m | Day & Night | A typical adult Hellhound of this region, with dust-grey coloring and old rune scars. |
| `pop_01830` | Velmark Hellhound Scarred | [[Regions/Velmark\|Velmark]] | Scarred | D+ | 56 | 1.65 m | Day & Night | Like a typical Hellhound, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_01831` | Velmark Hellhound Juvenile | [[Regions/Velmark\|Velmark]] | Juvenile | D- | 40 | 1.27 m | Day & Night | Like a typical Hellhound, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_01832` | Strife Marches Hellhound Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D- | 40 | 1.27 m | Day & Night | Like a typical Hellhound, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01833` | Aldmere Hellhound Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 1.88 m | Day & Night | Like a typical Hellhound, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01834` | Strife Marches Hellhound Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | D+ | 56 | 1.65 m | Day & Night | Like a typical Hellhound, but covered in old battle scars, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `demon_hide_emissive` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
