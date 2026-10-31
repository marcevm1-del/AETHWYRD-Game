---
type: monster
id: mon_elder_pixie
family: "Elementals & Spirits"
rank: "D"
tier: variant
tags: [monster, elementals-spirits]
---
# Elder Pixie

![[mon_elder_pixie_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_pixie_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,492 tris · 0.511 × 0.417 × 0.3 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Pixie is a tiny creature with a small winged body, about 0.3 m tall. Its body is smooth and clean, colored in pale jade and cloud white. Its most striking feature is dragonfly wings and a mischievous grin. It has wide curious eyes with star-shaped highlights. A distinctive marking runs along its back. It waddles, surrounded by swirling leaves and a constant breeze. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Pixie\|Pixie]] (elder) |
| Rank · level | D · 48 (40–56) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 0.3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1869 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/spirit_float\|spirit_float]] · `anim_flyer_small` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/spirit_float|spirit_float]] (override (base species)); animation set `anim_flyer_small`.
- **Dimensions:** 0.3 m high × 0.09 m long × 0.19 m wide; prefab scale 0.3.
- **Physics:** 0.5 kg, gravity ×0, poise 5, knockback resistance 0.06, death style `dissolve_into_motes`.
- **Navigation:** speed 2.89 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** dragonfly wings and a mischievous grin.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Elemental Burst\|Elemental Burst]] | magic | 1.4 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Elder Pixie is a **charming elemental** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** dragonfly wings and a mischievous grin. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Elementals & Spirits D|loot_elemental_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 6 | D, D-, C-, D+, E+ | 32–65 | Day |
| [[Regions/Hoshizora\|Hoshizora]] | 5 | C-, E+, D+, D-, D | 32–65 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04473` | Iron Hold Elder Pixie | [[Regions/Iron Hold\|Iron Hold]] | Adult | D | 48 | 0.3 m | Day | A typical adult Elder Pixie of this region, with slate-grey coloring and hardened hide. |
| `pop_04474` | Hoshizora Elder Pixie Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | C- | 65 | 0.38 m | Day | Like a typical Elder Pixie, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_04475` | Iron Hold Elder Pixie Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | D- | 40 | 0.26 m | Day | Like a typical Elder Pixie, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04476` | Hoshizora Elder Pixie Runt | [[Regions/Hoshizora\|Hoshizora]] | Runt | E+ | 32 | 0.21 m | Day | Like a typical Elder Pixie, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_04477` | Iron Hold Elder Pixie Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C- | 65 | 0.38 m | Day | Like a typical Elder Pixie, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04478` | Iron Hold Elder Pixie Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | D+ | 56 | 0.3 m | Day | Like a typical Elder Pixie, but a rare pale form with white skin or fur and red eyes. |
| `pop_04479` | Iron Hold Elder Pixie Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | E+ | 32 | 0.21 m | Day | Like a typical Elder Pixie, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_04480` | Hoshizora Elder Pixie Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | D+ | 56 | 0.33 m | Day | Like a typical Elder Pixie, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04481` | Hoshizora Elder Pixie Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | D- | 40 | 0.26 m | Day | Like a typical Elder Pixie, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04482` | Hoshizora Elder Pixie | [[Regions/Hoshizora\|Hoshizora]] | Adult | D | 48 | 0.3 m | Day | A typical adult Elder Pixie of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_04483` | Iron Hold Elder Pixie Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | D+ | 56 | 0.33 m | Day | Like a typical Elder Pixie, but covered in old battle scars, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `elemental_emissive` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
