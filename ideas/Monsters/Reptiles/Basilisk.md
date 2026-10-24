---
type: monster
id: mon_basilisk
family: "Reptiles"
rank: "C"
tier: core
tags: [monster, reptiles]
---
# Basilisk

![[mon_basilisk_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_basilisk_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,188 tris · 0.823 × 4 × 2.269 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Basilisk is a large creature with a powerful four-legged hunter's body, about 4 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in ochre, clay and mossy stone. Its most striking feature is a crown of horns and eyes that petrify. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10566 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Stormreach\|Stormreach]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 2.6 m high × 4 m long × 0.64 m wide; prefab scale 1.
- **Physics:** 1664 kg, gravity ×1.32, poise 102, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 6.77 m/s, turn 160°/s, stopping distance 1.2 m.
- **Attack count:** 5; **signature:** a crown of horns and eyes that petrify.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Basilisk is a **dread reptile** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of horns and eyes that petrify. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zaruma|Zaruma]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Stormreach|Stormreach]], [[Regions/Sunscar|Sunscar]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles C|loot_reptile_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Greater Basilisk|Greater Basilisk]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 3 | C-, C+, B | 65–108 | Night |
| [[Regions/Stormreach\|Stormreach]] | 4 | C+, C-, D+, C | 56–86 | Night |
| [[Regions/Hoshizora\|Hoshizora]] | 2 | B, C+ | 86–108 | Night |
| [[Regions/Zaruma\|Zaruma]] | 2 | C, D+ | 56–76 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01286` | Sunscar Basilisk Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | C- | 65 | 3.4 m | Night | Like a typical Basilisk, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_01287` | Stormreach Basilisk Scarred | [[Regions/Stormreach\|Stormreach]] | Scarred | C+ | 86 | 4.4 m | Night | Like a typical Basilisk, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01288` | Sunscar Basilisk Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | C+ | 86 | 4.4 m | Night | Like a typical Basilisk, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_01289` | Stormreach Basilisk Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | C- | 65 | 3.4 m | Night | Like a typical Basilisk, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01290` | Stormreach Basilisk Runt | [[Regions/Stormreach\|Stormreach]] | Runt | D+ | 56 | 2.8 m | Night | Like a typical Basilisk, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01291` | Hoshizora Basilisk Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B | 108 | 5.4 m | Night | Like a typical Basilisk, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01292` | Zaruma Basilisk | [[Regions/Zaruma\|Zaruma]] | Adult | C | 76 | 4 m | Night | A typical adult Basilisk of this region, with sun-bleached, sand-scoured coloring. |
| `pop_01293` | Zaruma Basilisk Runt | [[Regions/Zaruma\|Zaruma]] | Runt | D+ | 56 | 2.8 m | Night | Like a typical Basilisk, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_01294` | Hoshizora Basilisk Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C+ | 86 | 4 m | Night | Like a typical Basilisk, but a rare pale form with white skin or fur and red eyes. |
| `pop_01295` | Sunscar Basilisk Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | B | 108 | 5.4 m | Night | Like a typical Basilisk, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_01296` | Stormreach Basilisk | [[Regions/Stormreach\|Stormreach]] | Adult | C | 76 | 4 m | Night | A typical adult Basilisk of this region, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `scale_matte` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · elongated, irregular silhouette; still-then-sudden timing
