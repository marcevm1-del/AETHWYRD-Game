---
type: monster
id: mon_gale_crocodile_wyrm
family: "Reptiles"
rank: "B-"
tier: variant
tags: [monster, reptiles]
---
# Gale Crocodile Wyrm

![[mon_gale_crocodile_wyrm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gale_crocodile_wyrm_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 1.866 × 7 × 2.731 m · local file `Game/Assets/_Game/Art/Models/Monsters/Reptiles/mon_gale_crocodile_wyrm.fbx`

> The Gale Crocodile Wyrm is a huge creature with a massive snake-like frame, about 7 m long. Its scales are rough, scarred and spiked, colored in green, with pale jade markings. Survivors describe a back of armored ridges like a sunken log. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It circles its prey, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Crocodile Wyrm\|Crocodile Wyrm]] (elemental) |
| Rank · level | B- · 96 (86–108) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 7 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13769 · 394 · 315 · 276 · 315 · 135 |
| XP · gold | 4462 · 897 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Zarvan\|Zarvan]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.28 m high × 7 m long × 0.7 m wide; prefab scale 1.75.
- **Physics:** 710 kg, gravity ×0.96, poise 193, knockback resistance 0.52, death style `limp_chain`.
- **Navigation:** speed 7.58 m/s, turn 113°/s, stopping distance 0.65 m.
- **Attack count:** 5; **signature:** a back of armored ridges like a sunken log.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gale Crocodile Wyrm is a **menacing reptile** encountered at B- rank, around level 96. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a back of armored ridges like a sunken log. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Zarvan|Zarvan]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles B|loot_reptile_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zaruma\|Zaruma]] | 4 | B+, B, C, A- | 76–132 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 4 | B-, B+, C, C+ | 76–120 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | B, B-, C | 76–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04186` | Zaruma Gale Crocodile Wyrm Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | B+ | 120 | 8.75 m | Day & Night | Like a typical Gale Crocodile Wyrm, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_04187` | Zarvan Gale Crocodile Wyrm | [[Regions/Zarvan\|Zarvan]] | Adult | B- | 96 | 7 m | Day & Night | A typical adult Gale Crocodile Wyrm of this region, with sun-bleached, sand-scoured coloring. |
| `pop_04188` | Zarvan Gale Crocodile Wyrm Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | B+ | 120 | 8.75 m | Day & Night | Like a typical Gale Crocodile Wyrm, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_04189` | Zaruma Gale Crocodile Wyrm Albino | [[Regions/Zaruma\|Zaruma]] | Albino | B | 108 | 7 m | Day & Night | Like a typical Gale Crocodile Wyrm, but a rare pale form with white skin or fur and red eyes. |
| `pop_04190` | Zarvan Gale Crocodile Wyrm Runt | [[Regions/Zarvan\|Zarvan]] | Runt | C | 76 | 4.9 m | Day & Night | Like a typical Gale Crocodile Wyrm, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_04191` | Hoshizora Gale Crocodile Wyrm Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | B | 108 | 7 m | Day & Night | Like a typical Gale Crocodile Wyrm, but a rare pale form with white skin or fur and red eyes. |
| `pop_04192` | Hoshizora Gale Crocodile Wyrm | [[Regions/Hoshizora\|Hoshizora]] | Adult | B- | 96 | 7 m | Day & Night | A typical adult Gale Crocodile Wyrm of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04193` | Zarvan Gale Crocodile Wyrm Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | C+ | 86 | 5.95 m | Day & Night | Like a typical Gale Crocodile Wyrm, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_04194` | Zaruma Gale Crocodile Wyrm Runt | [[Regions/Zaruma\|Zaruma]] | Runt | C | 76 | 4.9 m | Day & Night | Like a typical Gale Crocodile Wyrm, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_04195` | Hoshizora Gale Crocodile Wyrm Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | C | 76 | 4.9 m | Day & Night | Like a typical Gale Crocodile Wyrm, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04196` | Zaruma Gale Crocodile Wyrm Elderborn | [[Regions/Zaruma\|Zaruma]] | Elderborn | A- | 132 | 9.45 m | Day & Night | Like a typical Gale Crocodile Wyrm, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `wind_ribbons` · palette `#678d4b` `#445f32` `#8fe0bd` · triangle-based silhouette, sharp asymmetric spikes
