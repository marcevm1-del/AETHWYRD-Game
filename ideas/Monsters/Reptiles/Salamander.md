---
type: monster
id: mon_salamander
family: "Reptiles"
rank: "D+"
tier: core
tags: [monster, reptiles]
---
# Salamander

![[mon_salamander_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_salamander_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,346 tris · 0.617 × 1.6 × 1.392 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Salamander is a person-sized creature with a powerful four-legged hunter's body, about 1.6 m long. Its scales are rough, scarred and spiked, colored in ember reds fading to soot black. Guild sketches always show a tail that burns like a torch. It has narrow glowing eyes. A distinctive marking runs along its back. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1.6 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4933 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.04 m high × 1.6 m long × 0.26 m wide; prefab scale 0.4.
- **Physics:** 81.9 kg, gravity ×1.2, poise 58, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 5.64 m/s, turn 253°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** a tail that burns like a torch.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Salamander is a **menacing reptile** encountered at D+ rank, around level 56. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a tail that burns like a torch. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Lirian|Lirian]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles D|loot_reptile_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Phantom Salamander|Phantom Salamander]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 4 | C-, D, C+, D- | 40–86 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | C, C-, D- | 40–76 | Day & Night |
| [[Regions/Lirian\|Lirian]] | 4 | D, C-, D- | 40–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01275` | Xochitl Mire Salamander Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | C- | 65 | 1.6 m | Day & Night | Like a typical Salamander, but a rare pale form with white skin or fur and red eyes. |
| `pop_01276` | Aldmere Salamander Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 2 m | Day & Night | Like a typical Salamander, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_01277` | Xochitl Mire Salamander Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | D | 48 | 1.36 m | Day & Night | Like a typical Salamander, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_01278` | Lirian Salamander Juvenile | [[Regions/Lirian\|Lirian]] | Juvenile | D | 48 | 1.36 m | Day & Night | Like a typical Salamander, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01279` | Aldmere Salamander Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 1.6 m | Day & Night | Like a typical Salamander, but a rare pale form with white skin or fur and red eyes. |
| `pop_01280` | Xochitl Mire Salamander Elderborn | [[Regions/Xochitl Mire\|Xochitl Mire]] | Elderborn | C+ | 86 | 2.16 m | Day & Night | Like a typical Salamander, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_01281` | Lirian Salamander Scarred | [[Regions/Lirian\|Lirian]] | Scarred | C- | 65 | 1.76 m | Day & Night | Like a typical Salamander, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01282` | Lirian Salamander Albino | [[Regions/Lirian\|Lirian]] | Albino | C- | 65 | 1.6 m | Day & Night | Like a typical Salamander, but a rare pale form with white skin or fur and red eyes. |
| `pop_01283` | Aldmere Salamander Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 1.12 m | Day & Night | Like a typical Salamander, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_01284` | Lirian Salamander Runt | [[Regions/Lirian\|Lirian]] | Runt | D- | 40 | 1.12 m | Day & Night | Like a typical Salamander, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01285` | Xochitl Mire Salamander Runt | [[Regions/Xochitl Mire\|Xochitl Mire]] | Runt | D- | 40 | 1.12 m | Day & Night | Like a typical Salamander, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `scale_matte` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
