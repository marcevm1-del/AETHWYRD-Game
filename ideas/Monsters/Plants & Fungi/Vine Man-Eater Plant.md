---
type: monster
id: mon_vine_man_eater_plant
family: "Plants & Fungi"
rank: "D+"
tier: variant
tags: [monster, plants-fungi]
---
# Vine Man-Eater Plant

![[mon_vine_man_eater_plant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vine_man_eater_plant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,762 tris · 2.606 × 1.961 × 2.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vine Man-Eater Plant is a large creature with a huge bulbous flower on a thick stalk, about 2.5 m tall. Its bark and leaves are rough, scarred and spiked, colored in moss green and lichen grey. Guild sketches always show a flower with jaws made of petals. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It strides with heavy steps, surrounded by drifting pollen and tiny blossoms. Adapted to jungle lands, it has vivid tropical markings.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Man-Eater Plant\|Man-Eater Plant]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 2.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4179 · 140 · 164 · 328 · 304 · 90 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/plant_rooted\|plant_rooted]] · `anim_plant_rooted` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/plant_rooted|plant_rooted]] (rigId); animation set `anim_plant_rooted`.
- **Dimensions:** 2.5 m high × 1 m long × 3 m wide; prefab scale 1.25.
- **Physics:** 328.1 kg, gravity ×1, poise 100, knockback resistance 1, death style `wilt_collapse`.
- **Navigation:** speed 0.49 m/s, turn 114°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** a flower with jaws made of petals.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Vine Lash\|Vine Lash]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Snap Jaw\|Snap Jaw]] | grab | 1.7 | 9 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Spore Burst\|Spore Burst]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Root Bind\|Root Bind]] | grab | 1 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vine Man-Eater Plant is a **menacing plant** encountered at D+ rank, around level 56. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a flower with jaws made of petals. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_plant_rooted`, animation set `anim_plant_rooted`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Plants & Fungi D|loot_plant_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 4 | C-, D, D+, D- | 40–65 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | D, C-, D-, C | 40–76 | Day & Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 3 | C, D+, C- | 56–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04612` | Strife Marches Vine Man-Eater Plant Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C- | 65 | 2.75 m | Day & Night | Like a typical Vine Man-Eater Plant, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04613` | Strife Marches Vine Man-Eater Plant Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D | 48 | 2.13 m | Day & Night | Like a typical Vine Man-Eater Plant, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04614` | Aldmere Vine Man-Eater Plant Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D | 48 | 2.13 m | Day & Night | Like a typical Vine Man-Eater Plant, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04615` | Strife Marches Vine Man-Eater Plant | [[Regions/Strife Marches\|Strife Marches]] | Adult | D+ | 56 | 2.5 m | Day & Night | A typical adult Vine Man-Eater Plant of this region, with dust-grey coloring and old rune scars. |
| `pop_04616` | Xochitl Mire Vine Man-Eater Plant Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | C | 76 | 3.13 m | Day & Night | Like a typical Vine Man-Eater Plant, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_04617` | Xochitl Mire Vine Man-Eater Plant | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | D+ | 56 | 2.5 m | Day & Night | A typical adult Vine Man-Eater Plant of this region, with mud-slick, algae-streaked skin. |
| `pop_04618` | Aldmere Vine Man-Eater Plant Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 2.5 m | Day & Night | Like a typical Vine Man-Eater Plant, but a rare pale form with white skin or fur and red eyes. |
| `pop_04619` | Xochitl Mire Vine Man-Eater Plant Scarred | [[Regions/Xochitl Mire\|Xochitl Mire]] | Scarred | C- | 65 | 2.75 m | Day & Night | Like a typical Vine Man-Eater Plant, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_04620` | Aldmere Vine Man-Eater Plant Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 1.75 m | Day & Night | Like a typical Vine Man-Eater Plant, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04621` | Aldmere Vine Man-Eater Plant Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 3.13 m | Day & Night | Like a typical Vine Man-Eater Plant, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04622` | Strife Marches Vine Man-Eater Plant Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D- | 40 | 1.75 m | Day & Night | Like a typical Vine Man-Eater Plant, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#7e9648` `#4f5733` `#8fd16a` · triangle-based silhouette, sharp asymmetric spikes
