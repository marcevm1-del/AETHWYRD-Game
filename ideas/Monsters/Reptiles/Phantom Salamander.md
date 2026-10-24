---
type: monster
id: mon_phantom_salamander
family: "Reptiles"
rank: "C-"
tier: variant
tags: [monster, reptiles]
---
# Phantom Salamander

![[mon_phantom_salamander_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_salamander_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,824 tris · 0.552 × 1.6 × 1.758 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Salamander is a person-sized creature with a powerful four-legged hunter's body, about 1.6 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Guild sketches always show a tail that burns like a torch. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Salamander\|Salamander]] (spirit) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 1.6 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6149 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.04 m high × 1.6 m long × 0.26 m wide; prefab scale 0.4.
- **Physics:** 77.8 kg, gravity ×1.08, poise 64, knockback resistance 0.94, death style `heavy_fall_dust`.
- **Navigation:** speed 5.12 m/s, turn 253°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** a tail that burns like a torch.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Salamander is a **dread reptile** encountered at C- rank, around level 65. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a tail that burns like a torch. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles C|loot_reptile_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 4 | D, B-, C, C- | 48–96 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 3 | D, C, B- | 48–96 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | D+, D, C-, C | 48–76 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04164` | Kitsune Isles Phantom Salamander Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | D | 48 | 1.12 m | Night | Like a typical Phantom Salamander, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04165` | Lumbaya Phantom Salamander Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | D | 48 | 1.12 m | Night | Like a typical Phantom Salamander, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_04166` | Hoshizora Phantom Salamander Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D+ | 56 | 1.36 m | Night | Like a typical Phantom Salamander, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04167` | Hoshizora Phantom Salamander Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D | 48 | 1.12 m | Night | Like a typical Phantom Salamander, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04168` | Hoshizora Phantom Salamander | [[Regions/Hoshizora\|Hoshizora]] | Adult | C- | 65 | 1.6 m | Night | A typical adult Phantom Salamander of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04169` | Kitsune Isles Phantom Salamander Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | B- | 96 | 2.16 m | Night | Like a typical Phantom Salamander, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04170` | Hoshizora Phantom Salamander Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C | 76 | 1.6 m | Night | Like a typical Phantom Salamander, but a rare pale form with white skin or fur and red eyes. |
| `pop_04171` | Kitsune Isles Phantom Salamander Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | C | 76 | 1.6 m | Night | Like a typical Phantom Salamander, but a rare pale form with white skin or fur and red eyes. |
| `pop_04172` | Lumbaya Phantom Salamander Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | C | 76 | 1.6 m | Night | Like a typical Phantom Salamander, but a rare pale form with white skin or fur and red eyes. |
| `pop_04173` | Kitsune Isles Phantom Salamander | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | C- | 65 | 1.6 m | Night | A typical adult Phantom Salamander of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04174` | Lumbaya Phantom Salamander Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | B- | 96 | 2.16 m | Night | Like a typical Phantom Salamander, but old and wise, with greying features and a cautious hunting style, with vivid tropical markings. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `scale_matte` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
