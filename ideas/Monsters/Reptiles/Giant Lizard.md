---
type: monster
id: mon_giant_lizard
family: "Reptiles"
rank: "E"
tier: core
tags: [monster, reptiles]
---
# Giant Lizard

> The Giant Lizard is a person-sized creature with a powerful four-legged hunter's body, about 2 m long. Its scales are weathered and natural, colored in ochre, clay and mossy stone. Survivors describe sun-baked scales and a frilled neck. It has alert animal eyes. Small scars and rough edges mark it as a survivor. It lopes in long strides, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 2 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1741 · 137 · 114 · 91 · 103 · 100 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Greymoor\|Greymoor]], [[Regions/Aldmere\|Aldmere]], [[Regions/Lirian\|Lirian]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Wind. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.3 m high × 2 m long × 0.32 m wide; prefab scale 0.5.
- **Physics:** 208 kg, gravity ×1.32, poise 57, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 4.54 m/s, turn 226°/s, stopping distance 0.8 m.
- **Attack count:** 5; **signature:** sun-baked scales and a frilled neck.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Giant Lizard is a **wild reptile** encountered at E rank, around level 26. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** sun-baked scales and a frilled neck. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Greymoor|Greymoor]], [[Regions/Aldmere|Aldmere]], [[Regions/Lirian|Lirian]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles E|loot_reptile_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Ancient Giant Lizard|Ancient Giant Lizard]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lirian\|Lirian]] | 5 | E+, F+, E, D | 13–48 | Day & Night |
| [[Regions/Greymoor\|Greymoor]] | 2 | E+, D- | 32–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | E+, E-, E, D- | 19–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01253` | Lirian Giant Lizard Scarred | [[Regions/Lirian\|Lirian]] | Scarred | E+ | 32 | 2.2 m | Day & Night | Like a typical Giant Lizard, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01254` | Greymoor Giant Lizard Albino | [[Regions/Greymoor\|Greymoor]] | Albino | E+ | 32 | 2 m | Day & Night | Like a typical Giant Lizard, but a rare pale form with white skin or fur and red eyes. |
| `pop_01255` | Aldmere Giant Lizard Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 2.2 m | Day & Night | Like a typical Giant Lizard, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_01256` | Aldmere Giant Lizard Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 1.7 m | Day & Night | Like a typical Giant Lizard, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_01257` | Lirian Giant Lizard Albino | [[Regions/Lirian\|Lirian]] | Albino | E+ | 32 | 2 m | Day & Night | Like a typical Giant Lizard, but a rare pale form with white skin or fur and red eyes. |
| `pop_01258` | Lirian Giant Lizard Runt | [[Regions/Lirian\|Lirian]] | Runt | F+ | 13 | 1.4 m | Day & Night | Like a typical Giant Lizard, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01259` | Aldmere Giant Lizard | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 2 m | Day & Night | A typical adult Giant Lizard of this region, with mud-slick, algae-streaked skin. |
| `pop_01260` | Lirian Giant Lizard | [[Regions/Lirian\|Lirian]] | Adult | E | 26 | 2 m | Day & Night | A typical adult Giant Lizard of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_01261` | Aldmere Giant Lizard Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 2.5 m | Day & Night | Like a typical Giant Lizard, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_01262` | Lirian Giant Lizard Elderborn | [[Regions/Lirian\|Lirian]] | Elderborn | D | 48 | 2.7 m | Day & Night | Like a typical Giant Lizard, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01263` | Greymoor Giant Lizard Alpha | [[Regions/Greymoor\|Greymoor]] | Alpha | D- | 40 | 2.5 m | Day & Night | Like a typical Giant Lizard, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `scale_matte` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
