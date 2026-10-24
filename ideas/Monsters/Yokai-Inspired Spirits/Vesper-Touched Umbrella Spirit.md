---
type: monster
id: mon_vesper_touched_umbrella_spirit
family: "Yokai-Inspired Spirits"
rank: "E-"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Vesper-Touched Umbrella Spirit

![[mon_vesper_touched_umbrella_spirit_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_umbrella_spirit_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,122 tris · 0.396 × 0.388 × 0.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Umbrella Spirit is a small creature with a hunched, wiry humanoid frame, about 0.8 m tall. Its form is weathered and natural, colored in deep blues with a glassy shine. Survivors describe a one-eyed paper umbrella hopping on one leg. It has amber predator eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by fine mist and droplets that orbit it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Umbrella Spirit\|Umbrella Spirit]] (corrupted) |
| Rank · level | E- · 19 (13–26) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 0.8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 638 · 86 · 69 · 60 · 69 · 135 |
| XP · gold | 342 · 96 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.8 m high × 0.24 m long × 0.32 m wide; prefab scale 0.727.
- **Physics:** 8.6 kg, gravity ×1.5, poise 29, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 4.12 m/s, turn 470°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** a one-eyed paper umbrella hopping on one leg.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Umbrella Spirit is a **wild spirit** encountered at E- rank, around level 19. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a one-eyed paper umbrella hopping on one leg. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits E|loot_yokai_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 4 | E, F+, E-, E+ | 13–32 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 7 | E-, E, F, F+, E+, D- | 8–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05301` | Hoshizora Vesper-Touched Umbrella Spirit Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | E | 26 | 0.88 m | Day & Night | Like a typical Vesper-Touched Umbrella Spirit, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05302` | Kitsune Isles Vesper-Touched Umbrella Spirit | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | E- | 19 | 0.8 m | Day & Night | A typical adult Vesper-Touched Umbrella Spirit of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_05303` | Kitsune Isles Vesper-Touched Umbrella Spirit Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | E | 26 | 0.8 m | Day & Night | Like a typical Vesper-Touched Umbrella Spirit, but a rare pale form with white skin or fur and red eyes. |
| `pop_05304` | Kitsune Isles Vesper-Touched Umbrella Spirit Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | F | 8 | 0.56 m | Day & Night | Like a typical Vesper-Touched Umbrella Spirit, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_05305` | Kitsune Isles Vesper-Touched Umbrella Spirit Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | F+ | 13 | 0.68 m | Day & Night | Like a typical Vesper-Touched Umbrella Spirit, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_05306` | Kitsune Isles Vesper-Touched Umbrella Spirit Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | E+ | 32 | 1 m | Day & Night | Like a typical Vesper-Touched Umbrella Spirit, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_05307` | Hoshizora Vesper-Touched Umbrella Spirit Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | F+ | 13 | 0.68 m | Day & Night | Like a typical Vesper-Touched Umbrella Spirit, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05308` | Hoshizora Vesper-Touched Umbrella Spirit | [[Regions/Hoshizora\|Hoshizora]] | Adult | E- | 19 | 0.8 m | Day & Night | A typical adult Vesper-Touched Umbrella Spirit of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05309` | Kitsune Isles Vesper-Touched Umbrella Spirit Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | D- | 40 | 1.08 m | Day & Night | Like a typical Vesper-Touched Umbrella Spirit, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_05310` | Kitsune Isles Vesper-Touched Umbrella Spirit Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | E | 26 | 0.88 m | Day & Night | Like a typical Vesper-Touched Umbrella Spirit, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_05311` | Hoshizora Vesper-Touched Umbrella Spirit Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | E+ | 32 | 1 m | Day & Night | Like a typical Vesper-Touched Umbrella Spirit, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `paper_ink_spirit` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
