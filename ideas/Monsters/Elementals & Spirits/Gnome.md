---
type: monster
id: mon_gnome
family: "Elementals & Spirits"
rank: "D+"
tier: core
tags: [monster, elementals-spirits]
---
# Gnome

![[mon_gnome_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gnome_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.413 × 0.411 × 0.7 m · local file `Game/Assets/_Game/Art/Models/Monsters/Elementals & Spirits/mon_gnome.fbx`

> The Gnome is a small creature with a small, compact humanoid body, about 0.7 m tall. Its body is weathered and natural, colored in ochre, clay and mossy stone. Its most striking feature is a stone-bearded little figure with gem eyes. It has amber predator eyes. A distinctive marking runs along its back. It lopes in long strides, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | D+ · 56 (48–65) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.7 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2913 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Moraveil\|Moraveil]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.7 m high × 0.21 m long × 0.28 m wide; prefab scale 0.636.
- **Physics:** 7.1 kg, gravity ×1.65, poise 31, knockback resistance 0.36, death style `ragdoll_crumple`.
- **Navigation:** speed 3.55 m/s, turn 502°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** a stone-bearded little figure with gem eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gnome is a **wild elemental** encountered at D+ rank, around level 56. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stone-bearded little figure with gem eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Moraveil|Moraveil]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits D|loot_elemental_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Greater Gnome|Greater Gnome]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Hoshizora\|Hoshizora]] | 2 | C-, C+ | 65–86 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 4 | C-, D, D+, D- | 40–65 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | C, C-, C+ | 65–86 | Day & Night |
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 2 | C, C+ | 76–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01639` | Hoshizora Gnome Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C- | 65 | 0.77 m | Day & Night | Like a typical Gnome, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01640` | Moraveil Gnome Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C- | 65 | 0.77 m | Day & Night | Like a typical Gnome, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01641` | Moraveil Gnome Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D | 48 | 0.59 m | Day & Night | Like a typical Gnome, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01642` | Iron Hold Gnome Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C | 76 | 0.88 m | Day & Night | Like a typical Gnome, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01643` | Iron Hold Gnome Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C- | 65 | 0.77 m | Day & Night | Like a typical Gnome, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01644` | Iron Hold Gnome Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 0.94 m | Day & Night | Like a typical Gnome, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_01645` | Kitsune Isles Gnome Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | C | 76 | 0.88 m | Day & Night | Like a typical Gnome, but larger and scarred, and others of its kind follow it, with a faint translucent shimmer. |
| `pop_01646` | Kitsune Isles Gnome Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C+ | 86 | 0.94 m | Day & Night | Like a typical Gnome, but old and wise, with greying features and a cautious hunting style, with a faint translucent shimmer. |
| `pop_01647` | Moraveil Gnome | [[Regions/Moraveil\|Moraveil]] | Adult | D+ | 56 | 0.7 m | Day & Night | A typical adult Gnome of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01648` | Hoshizora Gnome Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C+ | 86 | 0.94 m | Day & Night | Like a typical Gnome, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_01649` | Moraveil Gnome Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D- | 40 | 0.49 m | Day & Night | Like a typical Gnome, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `elemental_emissive` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
