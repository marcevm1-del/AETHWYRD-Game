---
type: monster
id: mon_lizardman
family: "Reptiles"
rank: "D"
tier: core
tags: [monster, reptiles]
---
# Lizardman

![[mon_lizardman_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_lizardman_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,550 tris · 1.178 × 1.939 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Lizardman is a person-sized creature with a lean humanoid frame, about 2 m tall. Its scales are weathered and natural, colored in sand-coloured, with sea-blue markings. Survivors describe a proud crest and a coral-tipped spear. It has dark, wary eyes. A distinctive marking runs along its back. It stalks low to the ground, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4242 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lirian\|Lirian]], [[Regions/Aldmere\|Aldmere]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 109.2 kg, gravity ×1.5, poise 69, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 5.45 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 5; **signature:** a proud crest and a coral-tipped spear.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Lizardman is a **wild reptile** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a proud crest and a coral-tipped spear. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Lirian|Lirian]], [[Regions/Aldmere|Aldmere]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles D|loot_reptile_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Ancient Lizardman|Ancient Lizardman]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 4 | C, D+, E+, C- | 32–76 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | C-, D- | 40–65 | Day & Night |
| [[Regions/Lirian\|Lirian]] | 3 | C, D+, D- | 40–76 | Day & Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 2 | D-, D | 40–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01264` | Kitsune Isles Lizardman Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C | 76 | 2.7 m | Day & Night | Like a typical Lizardman, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01265` | Aldmere Lizardman Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 2.5 m | Day & Night | Like a typical Lizardman, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_01266` | Lirian Lizardman Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | C | 76 | 2.7 m | Day & Night | Like a typical Lizardman, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01267` | Xochitl Mire Lizardman Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | D- | 40 | 1.7 m | Day & Night | Like a typical Lizardman, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_01268` | Aldmere Lizardman Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 1.7 m | Day & Night | Like a typical Lizardman, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_01269` | Kitsune Isles Lizardman Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | D+ | 56 | 2 m | Day & Night | Like a typical Lizardman, but a rare pale form with white skin or fur and red eyes. |
| `pop_01270` | Lirian Lizardman Albino | [[Regions/Lirian\|Lirian]] | Albino | D+ | 56 | 2 m | Day & Night | Like a typical Lizardman, but a rare pale form with white skin or fur and red eyes. |
| `pop_01271` | Kitsune Isles Lizardman Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | E+ | 32 | 1.4 m | Day & Night | Like a typical Lizardman, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01272` | Xochitl Mire Lizardman | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | D | 48 | 2 m | Day & Night | A typical adult Lizardman of this region, with mud-slick, algae-streaked skin. |
| `pop_01273` | Kitsune Isles Lizardman Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C- | 65 | 2.5 m | Day & Night | Like a typical Lizardman, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01274` | Lirian Lizardman Juvenile | [[Regions/Lirian\|Lirian]] | Juvenile | D- | 40 | 1.7 m | Day & Night | Like a typical Lizardman, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `scale_matte` · VFX `mist_droplets` · palette `#9a8d4d` `#665c32` `#4fa8e8` · real-animal silhouette with one fantasy exaggeration
