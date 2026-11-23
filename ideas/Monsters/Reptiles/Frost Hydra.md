---
type: monster
id: mon_frost_hydra
family: "Reptiles"
rank: "A-"
tier: variant
tags: [monster, reptiles]
---
# Frost Hydra

![[mon_frost_hydra_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_frost_hydra_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 3.42 × 9 × 4.849 m · local file `Game/Assets/_Game/Art/Models/Monsters/Reptiles/mon_frost_hydra.fbx`

> The Frost Hydra is a huge creature with a long, sinuous serpentine body, about 9 m long. Its scales are rough, scarred and spiked, colored in teal-grey, with frost-blue markings. Guild sketches always show five heads on long necks, each with its own temper. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Hydra\|Hydra]] (elemental) |
| Rank · level | A- · 132 (120–146) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 9 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 23828 · 538 · 430 · 377 · 430 · 135 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/serpent\|serpent]] · `anim_serpent` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Stormreach\|Stormreach]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/serpent|serpent]] (rigId); animation set `anim_serpent`.
- **Dimensions:** 0.36 m high × 9 m long × 0.9 m wide; prefab scale 2.25.
- **Physics:** 1844.4 kg, gravity ×1.26, poise 333, knockback resistance 0.55, death style `limp_chain`.
- **Navigation:** speed 7.32 m/s, turn 100°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** five heads on long necks, each with its own temper.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Strike\|Strike]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tail Sweep\|Tail Sweep]] | aoe | 1.2 | 7 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Lash\|Tail Lash]] | aoe | 1.2 | 7 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Frost Hydra is a **menacing reptile** encountered at A- rank, around level 132. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** five heads on long necks, each with its own temper. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Stormreach|Stormreach]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_serpent`, animation set `anim_serpent`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Reptiles A|loot_reptile_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 5 | B+, A, B, S- | 108–173 | Day & Night |
| [[Regions/Stormreach\|Stormreach]] | 4 | B, A, S- | 108–173 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 2 | A, B+ | 120–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04197` | Zarvan Frost Hydra Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | B+ | 120 | 7.65 m | Day & Night | Like a typical Frost Hydra, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_04198` | Stormreach Frost Hydra Runt | [[Regions/Stormreach\|Stormreach]] | Runt | B | 108 | 6.3 m | Day & Night | Like a typical Frost Hydra, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_04199` | Zarvan Frost Hydra Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | A | 146 | 9.9 m | Day & Night | Like a typical Frost Hydra, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_04200` | Stormreach Frost Hydra Albino | [[Regions/Stormreach\|Stormreach]] | Albino | A | 146 | 9 m | Day & Night | Like a typical Frost Hydra, but a rare pale form with white skin or fur and red eyes. |
| `pop_04201` | Stormreach Frost Hydra Scarred | [[Regions/Stormreach\|Stormreach]] | Scarred | A | 146 | 9.9 m | Day & Night | Like a typical Frost Hydra, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04202` | Zarvan Frost Hydra Runt | [[Regions/Zarvan\|Zarvan]] | Runt | B | 108 | 6.3 m | Day & Night | Like a typical Frost Hydra, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_04203` | Zarvan Frost Hydra Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | S- | 173 | 12.15 m | Day & Night | Like a typical Frost Hydra, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_04204` | Zarvan Frost Hydra Albino | [[Regions/Zarvan\|Zarvan]] | Albino | A | 146 | 9 m | Day & Night | Like a typical Frost Hydra, but a rare pale form with white skin or fur and red eyes. |
| `pop_04205` | Hoshizora Frost Hydra Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | A | 146 | 9.9 m | Day & Night | Like a typical Frost Hydra, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04206` | Stormreach Frost Hydra Elderborn | [[Regions/Stormreach\|Stormreach]] | Elderborn | S- | 173 | 12.15 m | Day & Night | Like a typical Frost Hydra, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04207` | Hoshizora Frost Hydra Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | B+ | 120 | 7.65 m | Day & Night | Like a typical Frost Hydra, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `frost_trail_snow` · palette `#4e6680` `#37475a` `#9fdcff` · triangle-based silhouette, sharp asymmetric spikes
