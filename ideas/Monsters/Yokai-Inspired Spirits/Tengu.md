---
type: monster
id: mon_tengu
family: "Yokai-Inspired Spirits"
rank: "C"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Tengu

![[mon_tengu_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_tengu_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.908 × 1.657 × 2.001 m · local file `Game/Assets/_Game/Art/Models/Monsters/Yokai-Inspired Spirits/mon_tengu.fbx`

> The Tengu is a person-sized creature with a broad-winged bird frame, about 2 m tall. Its form is weathered and natural, colored in indigo, with pale jade markings. Look for crow wings, a long red mask and a feather fan. It has alert animal eyes. Battle-worn plates and trophies hang from its body. It prowls, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Wind · Fire |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6467 · 314 · 251 · 220 · 251 · 135 |
| XP · gold | 3073 · 648 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/avian\|avian]] · `anim_avian` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Haneul\|Haneul]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/avian|avian]] (rigId); animation set `anim_avian`.
- **Dimensions:** 0.92 m high × 2 m long × 3.44 m wide; prefab scale 3.333.
- **Physics:** 100.8 kg, gravity ×0.8, poise 122, knockback resistance 0.14, death style `tumble_feathers_burst`.
- **Navigation:** speed 4.56 m/s, turn 424°/s, stopping distance 0.8 m.
- **Attack count:** 5; **signature:** crow wings, a long red mask and a feather fan.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Peck\|Peck]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swoop\|Swoop]] | dash | 1.4 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Screech\|Screech]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Tengu is a **wild spirit** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** crow wings, a long red mask and a feather fan. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]], [[Regions/Haneul|Haneul]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_avian`, animation set `anim_avian`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits C|loot_yokai_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched Tengu|Vesper-Touched Tengu]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 5 | C-, B-, C+, D+ | 56–96 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 3 | C+, B, C- | 65–108 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 2 | C+, D+ | 56–86 | Day & Night |
| [[Regions/Haneul\|Haneul]] | 1 | D+ | 56–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02505` | Hoshizora Tengu Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | C- | 65 | 1.7 m | Day & Night | Like a typical Tengu, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02506` | Hoshizora Tengu Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B- | 96 | 2.5 m | Day & Night | Like a typical Tengu, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02507` | Hoshizora Tengu Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C+ | 86 | 2 m | Day & Night | Like a typical Tengu, but a rare pale form with white skin or fur and red eyes. |
| `pop_02508` | Shen-Lu Tengu Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | C+ | 86 | 2 m | Day & Night | Like a typical Tengu, but a rare pale form with white skin or fur and red eyes. |
| `pop_02509` | Hoshizora Tengu Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C+ | 86 | 2.2 m | Day & Night | Like a typical Tengu, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_02510` | Kitsune Isles Tengu Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | C+ | 86 | 2 m | Day & Night | Like a typical Tengu, but a rare pale form with white skin or fur and red eyes. |
| `pop_02511` | Kitsune Isles Tengu Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | D+ | 56 | 1.4 m | Day & Night | Like a typical Tengu, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_02512` | Haneul Tengu Runt | [[Regions/Haneul\|Haneul]] | Runt | D+ | 56 | 1.4 m | Day & Night | Like a typical Tengu, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_02513` | Shen-Lu Tengu Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | B | 108 | 2.7 m | Day & Night | Like a typical Tengu, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_02514` | Hoshizora Tengu Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | D+ | 56 | 1.4 m | Day & Night | Like a typical Tengu, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02515` | Shen-Lu Tengu Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | C- | 65 | 1.7 m | Day & Night | Like a typical Tengu, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `paper_ink_spirit` · VFX `wind_ribbons` · palette `#444d6f` `#31364f` `#8fe0bd` · real-animal silhouette with one fantasy exaggeration
