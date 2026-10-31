---
type: monster
id: mon_pixie
family: "Elementals & Spirits"
rank: "E"
tier: core
tags: [monster, elementals-spirits]
---
# Pixie

![[mon_pixie_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_pixie_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,364 tris · 0.351 × 0.134 × 0.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Pixie is a tiny creature with a small winged body, about 0.2 m tall. Its body is smooth and clean, colored in pale jade and cloud white. Its most striking feature is dragonfly wings and a mischievous grin. It has wide curious eyes with star-shaped highlights. Small scars and rough edges mark it as a survivor. It waddles, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 0.2 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 712 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_flyer_small` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Mossdeep\|Mossdeep]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (override); animation set `anim_flyer_small`.
- **Dimensions:** 0.2 m high × 0.06 m long × 0.13 m wide; prefab scale 0.2.
- **Physics:** 0.5 kg, gravity ×0, poise 4, knockback resistance 0.03, death style `dissolve_into_motes`.
- **Navigation:** speed 2.24 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Pixie is a **charming elemental** encountered at E rank, around level 26. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** dragonfly wings and a mischievous grin. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Mossdeep|Mossdeep]], [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits E|loot_elemental_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Elder Pixie|Elder Pixie]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 3 | D-, E, F+ | 13–40 | Day |
| [[Regions/Sylvaran\|Sylvaran]] | 2 | E+, E | 26–32 | Day |
| [[Regions/Mossdeep\|Mossdeep]] | 4 | F+, E-, E+, E | 13–32 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 2 | D, E | 26–48 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01595` | Aldmere Pixie Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 0.25 m | Day | Like a typical Pixie, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_01596` | Sylvaran Pixie Scarred | [[Regions/Sylvaran\|Sylvaran]] | Scarred | E+ | 32 | 0.22 m | Day | Like a typical Pixie, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01597` | Mossdeep Pixie Runt | [[Regions/Mossdeep\|Mossdeep]] | Runt | F+ | 13 | 0.14 m | Day | Like a typical Pixie, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01598` | Mossdeep Pixie Juvenile | [[Regions/Mossdeep\|Mossdeep]] | Juvenile | E- | 19 | 0.17 m | Day | Like a typical Pixie, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_01599` | Mossdeep Pixie Scarred | [[Regions/Mossdeep\|Mossdeep]] | Scarred | E+ | 32 | 0.22 m | Day | Like a typical Pixie, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_01600` | Whisperwood Pixie Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 0.27 m | Day | Like a typical Pixie, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_01601` | Aldmere Pixie | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 0.2 m | Day | A typical adult Pixie of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01602` | Sylvaran Pixie | [[Regions/Sylvaran\|Sylvaran]] | Adult | E | 26 | 0.2 m | Day | A typical adult Pixie of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01603` | Whisperwood Pixie | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 0.2 m | Day | A typical adult Pixie of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_01604` | Aldmere Pixie Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.14 m | Day | Like a typical Pixie, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_01605` | Mossdeep Pixie | [[Regions/Mossdeep\|Mossdeep]] | Adult | E | 26 | 0.2 m | Day | A typical adult Pixie of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `elemental_emissive` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
