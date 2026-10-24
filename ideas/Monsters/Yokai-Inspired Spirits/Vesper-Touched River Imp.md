---
type: monster
id: mon_vesper_touched_river_imp
family: "Yokai-Inspired Spirits"
rank: "D-"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Vesper-Touched River Imp

> The Vesper-Touched River Imp is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its form is rough, scarred and spiked, colored in deep blues with a glassy shine. Look for a dish-like hollow on its head full of water. It has burning slit pupils. A distinctive marking runs along its back. It circles its prey, surrounded by fine mist and droplets that orbit it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/River Imp\|River Imp]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 1 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1986 · 170 · 136 · 119 · 136 · 135 |
| XP · gold | 1106 · 265 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Lightning. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16.8 kg, gravity ×1.5, poise 37, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 4.6 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a dish-like hollow on its head full of water.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched River Imp is a **menacing spirit** encountered at D- rank, around level 40. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dish-like hollow on its head full of water. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits D|loot_yokai_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 5 | E+, E, D-, D, D+ | 26–56 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 6 | D, E+, D-, E, C- | 26–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05323` | Kitsune Isles Vesper-Touched River Imp Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | E+ | 32 | 0.85 m | Day & Night | Like a typical Vesper-Touched River Imp, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_05324` | Kitsune Isles Vesper-Touched River Imp Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | E | 26 | 0.7 m | Day & Night | Like a typical Vesper-Touched River Imp, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_05325` | Kitsune Isles Vesper-Touched River Imp | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D- | 40 | 1 m | Day & Night | A typical adult Vesper-Touched River Imp of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_05326` | Hoshizora Vesper-Touched River Imp Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D | 48 | 1 m | Day & Night | Like a typical Vesper-Touched River Imp, but a rare pale form with white skin or fur and red eyes. |
| `pop_05327` | Hoshizora Vesper-Touched River Imp Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | E+ | 32 | 0.85 m | Day & Night | Like a typical Vesper-Touched River Imp, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05328` | Hoshizora Vesper-Touched River Imp | [[Regions/Hoshizora\|Hoshizora]] | Adult | D- | 40 | 1 m | Day & Night | A typical adult Vesper-Touched River Imp of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05329` | Kitsune Isles Vesper-Touched River Imp Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | D | 48 | 1 m | Day & Night | Like a typical Vesper-Touched River Imp, but a rare pale form with white skin or fur and red eyes. |
| `pop_05330` | Hoshizora Vesper-Touched River Imp Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E | 26 | 0.7 m | Day & Night | Like a typical Vesper-Touched River Imp, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05331` | Kitsune Isles Vesper-Touched River Imp Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | D+ | 56 | 1.25 m | Day & Night | Like a typical Vesper-Touched River Imp, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_05332` | Hoshizora Vesper-Touched River Imp Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C- | 65 | 1.35 m | Day & Night | Like a typical Vesper-Touched River Imp, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05333` | Hoshizora Vesper-Touched River Imp Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D | 48 | 1.1 m | Day & Night | Like a typical Vesper-Touched River Imp, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `paper_ink_spirit` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
