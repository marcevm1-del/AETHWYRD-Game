---
type: monster
id: mon_ancient_giant_lizard
family: "Reptiles"
rank: "D"
tier: variant
tags: [monster, reptiles]
---
# Ancient Giant Lizard

![[mon_ancient_giant_lizard_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_giant_lizard_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Giant Lizard is a large creature with a powerful four-legged hunter's body, about 3 m long. Its scales are weathered and natural, colored in ochre, clay and mossy stone. Look for sun-baked scales and a frilled neck. It has dark, wary eyes. A distinctive marking runs along its back. It prowls, surrounded by pebbles that tremble and float near it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Giant Lizard\|Giant Lizard]] (ancient) |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4870 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Xochitl Mire\|Xochitl Mire]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Wind. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 1.95 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 702 kg, gravity ×1.32, poise 79, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 5.57 m/s, turn 185°/s, stopping distance 1 m.
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

Ancient Giant Lizard is a **wild reptile** encountered at D rank, around level 48. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** sun-baked scales and a frilled neck. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Xochitl Mire|Xochitl Mire]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles D|loot_reptile_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 7 | C, D, C-, D+, E+, D- | 32–76 | Day & Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 4 | D-, E+, D+, D | 32–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04142` | Hoshizora Ancient Giant Lizard Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C | 76 | 4.05 m | Day & Night | Like a typical Ancient Giant Lizard, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04143` | Xochitl Mire Ancient Giant Lizard Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | D- | 40 | 2.55 m | Day & Night | Like a typical Ancient Giant Lizard, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_04144` | Hoshizora Ancient Giant Lizard | [[Regions/Hoshizora\|Hoshizora]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Ancient Giant Lizard of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04145` | Xochitl Mire Ancient Giant Lizard Runt | [[Regions/Xochitl Mire\|Xochitl Mire]] | Runt | E+ | 32 | 2.1 m | Day & Night | Like a typical Ancient Giant Lizard, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_04146` | Hoshizora Ancient Giant Lizard Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C- | 65 | 3.75 m | Day & Night | Like a typical Ancient Giant Lizard, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04147` | Hoshizora Ancient Giant Lizard Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D+ | 56 | 3 m | Day & Night | Like a typical Ancient Giant Lizard, but a rare pale form with white skin or fur and red eyes. |
| `pop_04148` | Hoshizora Ancient Giant Lizard Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E+ | 32 | 2.1 m | Day & Night | Like a typical Ancient Giant Lizard, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04149` | Hoshizora Ancient Giant Lizard Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 3.3 m | Day & Night | Like a typical Ancient Giant Lizard, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04150` | Xochitl Mire Ancient Giant Lizard Scarred | [[Regions/Xochitl Mire\|Xochitl Mire]] | Scarred | D+ | 56 | 3.3 m | Day & Night | Like a typical Ancient Giant Lizard, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_04151` | Xochitl Mire Ancient Giant Lizard | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | D | 48 | 3 m | Day & Night | A typical adult Ancient Giant Lizard of this region, with mud-slick, algae-streaked skin. |
| `pop_04152` | Hoshizora Ancient Giant Lizard Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 2.55 m | Day & Night | Like a typical Ancient Giant Lizard, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `scale_matte` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
