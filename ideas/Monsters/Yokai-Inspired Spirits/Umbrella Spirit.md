---
type: monster
id: mon_umbrella_spirit
family: "Yokai-Inspired Spirits"
rank: "F"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Umbrella Spirit

> The Umbrella Spirit is a small creature with a small, compact humanoid body, about 0.8 m tall. Its form is smooth and clean, colored in deep blues with a glassy shine. Survivors describe a one-eyed paper umbrella hopping on one leg. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It bounces happily, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.8 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 209 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Lightning. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.8 m high × 0.24 m long × 0.32 m wide; prefab scale 0.727.
- **Physics:** 8.6 kg, gravity ×1.5, poise 26, knockback resistance 0.15, death style `ragdoll_crumple`.
- **Navigation:** speed 3.52 m/s, turn 470°/s, stopping distance 0.56 m.
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

Umbrella Spirit is a **charming spirit** encountered at F rank, around level 8. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a one-eyed paper umbrella hopping on one leg. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits F|loot_yokai_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched Umbrella Spirit|Vesper-Touched Umbrella Spirit]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 3 | F+, E- | 13–19 | Day |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 5 | F-, E-, F+, E | 3–26 | Day |
| [[Regions/Shen-Lu\|Shen-Lu]] | 3 | F, E-, E | 8–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02450` | Hoshizora Umbrella Spirit Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | F+ | 13 | 0.8 m | Day | Like a typical Umbrella Spirit, but a rare pale form with white skin or fur and red eyes. |
| `pop_02451` | Kitsune Isles Umbrella Spirit Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | F- | 3 | 0.68 m | Day | Like a typical Umbrella Spirit, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02452` | Kitsune Isles Umbrella Spirit Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | E- | 19 | 1 m | Day | Like a typical Umbrella Spirit, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02453` | Shen-Lu Umbrella Spirit | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | F | 8 | 0.8 m | Day | A typical adult Umbrella Spirit of this region, with slate-grey coloring and hardened hide. |
| `pop_02454` | Kitsune Isles Umbrella Spirit Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | F+ | 13 | 0.8 m | Day | Like a typical Umbrella Spirit, but a rare pale form with white skin or fur and red eyes. |
| `pop_02455` | Hoshizora Umbrella Spirit Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | E- | 19 | 1 m | Day | Like a typical Umbrella Spirit, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02456` | Kitsune Isles Umbrella Spirit Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | F+ | 13 | 0.88 m | Day | Like a typical Umbrella Spirit, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02457` | Kitsune Isles Umbrella Spirit Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | E | 26 | 1.08 m | Day | Like a typical Umbrella Spirit, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02458` | Hoshizora Umbrella Spirit Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | F+ | 13 | 0.88 m | Day | Like a typical Umbrella Spirit, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02459` | Shen-Lu Umbrella Spirit Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | E- | 19 | 1 m | Day | Like a typical Umbrella Spirit, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02460` | Shen-Lu Umbrella Spirit Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | E | 26 | 1.08 m | Day | Like a typical Umbrella Spirit, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `paper_ink_spirit` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
