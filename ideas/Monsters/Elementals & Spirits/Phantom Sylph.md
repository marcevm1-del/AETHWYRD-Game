---
type: monster
id: mon_phantom_sylph
family: "Elementals & Spirits"
rank: "C-"
tier: variant
tags: [monster, elementals-spirits]
---
# Phantom Sylph

![[mon_phantom_sylph_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_phantom_sylph_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,768 tris · 0.884 × 1.454 × 1.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Phantom Sylph is a person-sized creature with a lean humanoid frame, about 1.5 m tall. Its body is weathered and natural, colored in warm gold and pearl white. Look for a translucent dancer of wind and leaves. It has dark, wary eyes. Battle-worn plates and trophies hang from its body. It lopes in long strides, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Sylph\|Sylph]] (spirit) |
| Rank · level | C- · 65 (56–76) |
| Menace | 2 · Wild |
| Element · weakness | Light · Dark |
| Size | 1.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6015 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.5 m high × 0.45 m long × 0.48 m wide; prefab scale 0.833.
- **Physics:** 41.7 kg, gravity ×1.35, poise 66, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 4.07 m/s, turn 327°/s, stopping distance 0.66 m.
- **Attack count:** 5; **signature:** a translucent dancer of wind and leaves.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Sylph is a **wild elemental** encountered at C- rank, around level 65. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a translucent dancer of wind and leaves. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Shen-Lu|Shen-Lu]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits C|loot_elemental_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 5 | C-, B-, D+, C | 56–96 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 5 | C, C+, C-, B- | 65–96 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 1 | C+ | 86–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04506` | Kitsune Isles Phantom Sylph | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | C- | 65 | 1.5 m | Day & Night | A typical adult Phantom Sylph of this region, with a faint translucent shimmer. |
| `pop_04507` | Hoshizora Phantom Sylph Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C | 76 | 1.5 m | Day & Night | Like a typical Phantom Sylph, but a rare pale form with white skin or fur and red eyes. |
| `pop_04508` | Hoshizora Phantom Sylph Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C+ | 86 | 1.88 m | Day & Night | Like a typical Phantom Sylph, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04509` | Shen-Lu Phantom Sylph Alpha | [[Regions/Shen-Lu\|Shen-Lu]] | Alpha | C+ | 86 | 1.88 m | Day & Night | Like a typical Phantom Sylph, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04510` | Hoshizora Phantom Sylph Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C | 76 | 1.65 m | Day & Night | Like a typical Phantom Sylph, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04511` | Kitsune Isles Phantom Sylph Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | B- | 96 | 2.03 m | Day & Night | Like a typical Phantom Sylph, but old and wise, with greying features and a cautious hunting style, with a faint translucent shimmer. |
| `pop_04512` | Kitsune Isles Phantom Sylph Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | D+ | 56 | 1.27 m | Day & Night | Like a typical Phantom Sylph, but young, with brighter colors and unworn features, with a faint translucent shimmer. |
| `pop_04513` | Hoshizora Phantom Sylph | [[Regions/Hoshizora\|Hoshizora]] | Adult | C- | 65 | 1.5 m | Day & Night | A typical adult Phantom Sylph of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04514` | Hoshizora Phantom Sylph Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | B- | 96 | 2.03 m | Day & Night | Like a typical Phantom Sylph, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_04515` | Kitsune Isles Phantom Sylph Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | C | 76 | 1.65 m | Day & Night | Like a typical Phantom Sylph, but covered in old battle scars, with a faint translucent shimmer. |
| `pop_04516` | Kitsune Isles Phantom Sylph Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | C | 76 | 1.5 m | Day & Night | Like a typical Phantom Sylph, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `elemental_emissive` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · real-animal silhouette with one fantasy exaggeration
