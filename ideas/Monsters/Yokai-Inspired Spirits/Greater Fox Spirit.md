---
type: monster
id: mon_greater_fox_spirit
family: "Yokai-Inspired Spirits"
rank: "C"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Greater Fox Spirit

![[mon_greater_fox_spirit_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_fox_spirit_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,998 tris · 0.532 × 1.601 × 1.148 m · local file `Game/Assets/_Game/Art/Models/Monsters/Yokai-Inspired Spirits/mon_greater_fox_spirit.fbx`

> The Greater Fox Spirit is a person-sized creature with a compact quadruped frame, about 1.6 m long. Its form is weathered and natural, colored in indigo, with ember-orange markings. Look for three tails tipped with blue flame. It has amber predator eyes. Battle-worn plates and trophies hang from its body. It stalks low to the ground, surrounded by heat-shimmer and drifting sparks. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Fox Spirit\|Fox Spirit]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 1.6 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5992 · 314 · 251 · 220 · 251 · 135 |
| XP · gold | 3073 · 648 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 1.09 m high × 1.6 m long × 0.22 m wide; prefab scale 3.2.
- **Physics:** 122.9 kg, gravity ×1.6, poise 52, knockback resistance 0.14, death style `ragdoll_tumble`.
- **Navigation:** speed 12.33 m/s, turn 427°/s, stopping distance 0.66 m.
- **Attack count:** 5; **signature:** three tails tipped with blue flame.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Spirit Flame\|Spirit Flame]] | magic | 1.2 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Fox Spirit is a **wild spirit** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** three tails tipped with blue flame. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Yokai-Inspired Spirits C|loot_yokai_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Shen-Lu\|Shen-Lu]] | 5 | C+, B, B-, D+ | 56–108 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 6 | C, C-, C+, B-, B | 65–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05345` | Shen-Lu Greater Fox Spirit Scarred | [[Regions/Shen-Lu\|Shen-Lu]] | Scarred | C+ | 86 | 1.76 m | Day & Night | Like a typical Greater Fox Spirit, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_05346` | Hoshizora Greater Fox Spirit | [[Regions/Hoshizora\|Hoshizora]] | Adult | C | 76 | 1.6 m | Day & Night | A typical adult Greater Fox Spirit of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05347` | Hoshizora Greater Fox Spirit Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | C- | 65 | 1.36 m | Day & Night | Like a typical Greater Fox Spirit, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05348` | Shen-Lu Greater Fox Spirit Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | C+ | 86 | 1.6 m | Day & Night | Like a typical Greater Fox Spirit, but a rare pale form with white skin or fur and red eyes. |
| `pop_05349` | Shen-Lu Greater Fox Spirit Elderborn | [[Regions/Shen-Lu\|Shen-Lu]] | Elderborn | B | 108 | 2.16 m | Day & Night | Like a typical Greater Fox Spirit, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_05350` | Hoshizora Greater Fox Spirit Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C+ | 86 | 1.6 m | Day & Night | Like a typical Greater Fox Spirit, but a rare pale form with white skin or fur and red eyes. |
| `pop_05351` | Hoshizora Greater Fox Spirit Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C+ | 86 | 1.76 m | Day & Night | Like a typical Greater Fox Spirit, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05352` | Shen-Lu Greater Fox Spirit Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | B- | 96 | 2 m | Day & Night | Like a typical Greater Fox Spirit, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_05353` | Hoshizora Greater Fox Spirit Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B- | 96 | 2 m | Day & Night | Like a typical Greater Fox Spirit, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05354` | Hoshizora Greater Fox Spirit Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B | 108 | 2.16 m | Day & Night | Like a typical Greater Fox Spirit, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05355` | Shen-Lu Greater Fox Spirit Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | D+ | 56 | 1.12 m | Day & Night | Like a typical Greater Fox Spirit, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `paper_ink_spirit` · VFX `embers_heat_haze` · palette `#445271` `#32394f` `#ff7a3d` · real-animal silhouette with one fantasy exaggeration
