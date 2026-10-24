---
type: monster
id: mon_undine
family: "Elementals & Spirits"
rank: "D"
tier: core
tags: [monster, elementals-spirits]
---
# Undine

![[mon_undine_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_undine_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,500 tris · 1.072 × 1.355 × 1.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Undine is a person-sized creature with an upright humanoid build, about 1.6 m tall. Its body is smooth and clean, colored in deep blues with a glassy shine. Guild sketches always show a woman-shaped figure of flowing water. It has big round glossy eyes. A distinctive marking runs along its back. It bounces happily, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | D · 48 (40–56) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 1.6 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3930 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Aldmere\|Aldmere]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 1.6 m high × 0.48 m long × 0.51 m wide; prefab scale 0.889.
- **Physics:** 55.9 kg, gravity ×1.5, poise 61, knockback resistance 0.36, death style `ragdoll`.
- **Navigation:** speed 3.99 m/s, turn 316°/s, stopping distance 0.67 m.
- **Attack count:** 5; **signature:** a woman-shaped figure of flowing water.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Undine is a **charming elemental** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a woman-shaped figure of flowing water. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]], [[Regions/Aldmere|Aldmere]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits D|loot_elemental_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Greater Undine|Greater Undine]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 3 | C, E+, D | 32–76 | Day |
| [[Regions/Aldmere\|Aldmere]] | 3 | C-, D, D+ | 48–65 | Day |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | D+, D-, C, C- | 40–76 | Day |
| [[Regions/Iron Hold\|Iron Hold]] | 1 | D- | 40–40 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01617` | Kitsune Isles Undine Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | C | 76 | 2.16 m | Day | Like a typical Undine, but old and wise, with greying features and a cautious hunting style, with a faint translucent shimmer. |
| `pop_01618` | Aldmere Undine Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C- | 65 | 2 m | Day | Like a typical Undine, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01619` | Hoshizora Undine Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | D+ | 56 | 1.6 m | Day | Like a typical Undine, but a rare pale form with white skin or fur and red eyes. |
| `pop_01620` | Aldmere Undine | [[Regions/Aldmere\|Aldmere]] | Adult | D | 48 | 1.6 m | Day | A typical adult Undine of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01621` | Hoshizora Undine Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 1.36 m | Day | Like a typical Undine, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01622` | Kitsune Isles Undine Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | E+ | 32 | 1.12 m | Day | Like a typical Undine, but smaller and scrappier than usual, with a faint translucent shimmer. |
| `pop_01623` | Hoshizora Undine Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | C | 76 | 2.16 m | Day | Like a typical Undine, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_01624` | Kitsune Isles Undine | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | D | 48 | 1.6 m | Day | A typical adult Undine of this region, with a faint translucent shimmer. |
| `pop_01625` | Aldmere Undine Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 1.76 m | Day | Like a typical Undine, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01626` | Hoshizora Undine Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C- | 65 | 2 m | Day | Like a typical Undine, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01627` | Iron Hold Undine Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D- | 40 | 1.36 m | Day | Like a typical Undine, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `elemental_emissive` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
