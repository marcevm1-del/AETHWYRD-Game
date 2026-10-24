---
type: monster
id: mon_river_imp
family: "Yokai-Inspired Spirits"
rank: "E"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# River Imp

![[mon_river_imp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_river_imp_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The River Imp is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its form is weathered and natural, colored in deep blues with a glassy shine. Look for a dish-like hollow on its head full of water. It has amber predator eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 1 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1065 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Haneul\|Haneul]], [[Regions/Everdusk\|Everdusk]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16.8 kg, gravity ×1.5, poise 33, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 4.61 m/s, turn 420°/s, stopping distance 0.6 m.
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

River Imp is a **wild spirit** encountered at E rank, around level 26. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dish-like hollow on its head full of water. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Haneul|Haneul]], [[Regions/Everdusk|Everdusk]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits E|loot_yokai_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched River Imp|Vesper-Touched River Imp]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 1 | E | 26–26 | Day & Night |
| [[Regions/Haneul\|Haneul]] | 4 | D-, E-, E+, E | 19–40 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 2 | E-, E | 19–26 | Day & Night |
| [[Regions/Everdusk\|Everdusk]] | 3 | D, E+, E- | 19–48 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 1 | E+ | 32–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02472` | Shen-Lu River Imp | [[Regions/Shen-Lu\|Shen-Lu]] | Adult | E | 26 | 1 m | Day & Night | A typical adult River Imp of this region, with slate-grey coloring and hardened hide. |
| `pop_02473` | Haneul River Imp Alpha | [[Regions/Haneul\|Haneul]] | Alpha | D- | 40 | 1.25 m | Day & Night | Like a typical River Imp, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_02474` | Kitsune Isles River Imp Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | E- | 19 | 0.85 m | Day & Night | Like a typical River Imp, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02475` | Haneul River Imp Juvenile | [[Regions/Haneul\|Haneul]] | Juvenile | E- | 19 | 0.85 m | Day & Night | Like a typical River Imp, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_02476` | Haneul River Imp Scarred | [[Regions/Haneul\|Haneul]] | Scarred | E+ | 32 | 1.1 m | Day & Night | Like a typical River Imp, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_02477` | Everdusk River Imp Elderborn | [[Regions/Everdusk\|Everdusk]] | Elderborn | D | 48 | 1.35 m | Day & Night | Like a typical River Imp, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02478` | Haneul River Imp | [[Regions/Haneul\|Haneul]] | Adult | E | 26 | 1 m | Day & Night | A typical adult River Imp of this region, with slate-grey coloring and hardened hide. |
| `pop_02479` | Kitsune Isles River Imp | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | E | 26 | 1 m | Day & Night | A typical adult River Imp of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02480` | Everdusk River Imp Albino | [[Regions/Everdusk\|Everdusk]] | Albino | E+ | 32 | 1 m | Day & Night | Like a typical River Imp, but a rare pale form with white skin or fur and red eyes. |
| `pop_02481` | Hoshizora River Imp Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | E+ | 32 | 1 m | Day & Night | Like a typical River Imp, but a rare pale form with white skin or fur and red eyes. |
| `pop_02482` | Everdusk River Imp Juvenile | [[Regions/Everdusk\|Everdusk]] | Juvenile | E- | 19 | 0.85 m | Day & Night | Like a typical River Imp, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `paper_ink_spirit` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
