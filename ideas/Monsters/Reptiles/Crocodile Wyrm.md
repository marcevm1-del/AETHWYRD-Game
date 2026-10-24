---
type: monster
id: mon_crocodile_wyrm
family: "Reptiles"
rank: "C+"
tier: core
tags: [monster, reptiles]
---
# Crocodile Wyrm

> The Crocodile Wyrm is a huge creature with a long, sinuous serpentine body, about 7 m long. Its scales are rough, scarred and spiked, colored in deep blues with a glassy shine. Survivors describe a back of armored ridges like a sunken log. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 7 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11689 · 354 · 283 · 248 · 283 · 135 |
| XP · gold | 3743 · 769 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Stormreach\|Stormreach]], [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.28 m high × 7 m long × 0.7 m wide; prefab scale 1.75.
- **Physics:** 828.3 kg, gravity ×1.2, poise 184, knockback resistance 0.49, death style `limp_chain`.
- **Navigation:** speed 8.12 m/s, turn 113°/s, stopping distance 0.65 m.
- **Attack count:** 5; **signature:** a back of armored ridges like a sunken log.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Crocodile Wyrm is a **menacing reptile** encountered at C+ rank, around level 86. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a back of armored ridges like a sunken log. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Lumbaya|Lumbaya]], [[Regions/Stormreach|Stormreach]], [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles C|loot_reptile_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Gale Crocodile Wyrm|Gale Crocodile Wyrm]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 3 | B, C+, B- | 86–108 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 3 | B, B-, C | 76–108 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 2 | B, B+ | 108–120 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 2 | C-, C+ | 65–86 | Day & Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 1 | B | 108–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01297` | Xochitl Mire Crocodile Wyrm Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | B | 108 | 8.75 m | Day & Night | Like a typical Crocodile Wyrm, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_01298` | Stormreach Crocodile Wyrm Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | B | 108 | 8.75 m | Day & Night | Like a typical Crocodile Wyrm, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01299` | Lumbaya Crocodile Wyrm Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | B | 108 | 8.75 m | Day & Night | Like a typical Crocodile Wyrm, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_01300` | Xochitl Mire Crocodile Wyrm | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | C+ | 86 | 7 m | Day & Night | A typical adult Crocodile Wyrm of this region, with mud-slick, algae-streaked skin. |
| `pop_01301` | Kitsune Isles Crocodile Wyrm Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | C- | 65 | 4.9 m | Day & Night | Like a typical Crocodile Wyrm, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01302` | Lumbaya Crocodile Wyrm Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | B+ | 120 | 9.45 m | Day & Night | Like a typical Crocodile Wyrm, but old and wise, with greying features and a cautious hunting style, with vivid tropical markings. |
| `pop_01303` | Goldmere Coast Crocodile Wyrm Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | B | 108 | 8.75 m | Day & Night | Like a typical Crocodile Wyrm, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_01304` | Kitsune Isles Crocodile Wyrm | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | C+ | 86 | 7 m | Day & Night | A typical adult Crocodile Wyrm of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01305` | Stormreach Crocodile Wyrm Scarred | [[Regions/Stormreach\|Stormreach]] | Scarred | B- | 96 | 7.7 m | Day & Night | Like a typical Crocodile Wyrm, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01306` | Stormreach Crocodile Wyrm Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | C | 76 | 5.95 m | Day & Night | Like a typical Crocodile Wyrm, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01307` | Xochitl Mire Crocodile Wyrm Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | B- | 96 | 7 m | Day & Night | Like a typical Crocodile Wyrm, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
