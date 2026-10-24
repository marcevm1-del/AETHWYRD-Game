---
type: monster
id: mon_centaur_scout
family: "Centaurs & Taurs"
rank: "C"
tier: core
tags: [monster, centaurs-taurs]
---
# Centaur Scout

![[mon_centaur_scout_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_centaur_scout_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,928 tris · 1.149 × 2.438 × 2.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Centaur Scout is a person-sized creature with a powerful taur build, about 2.4 m tall. Its coat is weathered and natural, colored in pale jade and cloud white. Guild sketches always show a horsebow and a braided mane. It has alert animal eyes. Battle-worn plates and trophies hang from its body. It lopes in long strides, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Centaurs & Taurs|Centaurs & Taurs]] · Beastfolk |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Wind · Fire |
| Size | 2.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8908 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/taur\|taur]] · `anim_taur` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Ashira Vale\|Ashira Vale]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Steppe Epic |
| Trope | Proud nomadic centaur tribes |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/taur|taur]] (rigId); animation set `anim_taur`.
- **Dimensions:** 2.52 m high × 2.4 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 248.8 kg, gravity ×1.04, poise 91, knockback resistance 0.69, death style `ragdoll_slide`.
- **Navigation:** speed 8.35 m/s, turn 232°/s, stopping distance 0.78 m.
- **Attack count:** 5; **signature:** a horsebow and a braided mane.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Spear Thrust\|Spear Thrust]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Trample\|Trample]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Volley\|Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Lance Charge\|Lance Charge]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Centaur Scout is a **wild beastfolk** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a horsebow and a braided mane. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Ashira Vale|Ashira Vale]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_taur`, animation set `anim_taur`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Centaurs & Taurs C|loot_centaur_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horsehair\|Horsehair]] | 60% | 1–3 |
| [[Items/Painted Barding\|Painted Barding]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Centaurs & Taurs/Shade Centaur Scout|Shade Centaur Scout]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zaruma\|Zaruma]] | 3 | B-, C+, C- | 65–96 | Day & Night |
| [[Regions/Ashira Vale\|Ashira Vale]] | 3 | C, D+, B- | 56–96 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | C+, C-, B-, C | 65–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02285` | Zaruma Centaur Scout Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | B- | 96 | 3 m | Day & Night | Like a typical Centaur Scout, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02286` | Zaruma Centaur Scout Albino | [[Regions/Zaruma\|Zaruma]] | Albino | C+ | 86 | 2.4 m | Day & Night | Like a typical Centaur Scout, but a rare pale form with white skin or fur and red eyes. |
| `pop_02287` | Ashira Vale Centaur Scout | [[Regions/Ashira Vale\|Ashira Vale]] | Adult | C | 76 | 2.4 m | Day & Night | A typical adult Centaur Scout of this region, with golden, grass-toned coloring. |
| `pop_02288` | Zaruma Centaur Scout Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | C- | 65 | 2.04 m | Day & Night | Like a typical Centaur Scout, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02289` | Strife Marches Centaur Scout Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C+ | 86 | 2.4 m | Day & Night | Like a typical Centaur Scout, but a rare pale form with white skin or fur and red eyes. |
| `pop_02290` | Strife Marches Centaur Scout Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C- | 65 | 2.04 m | Day & Night | Like a typical Centaur Scout, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02291` | Ashira Vale Centaur Scout Runt | [[Regions/Ashira Vale\|Ashira Vale]] | Runt | D+ | 56 | 1.68 m | Day & Night | Like a typical Centaur Scout, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02292` | Strife Marches Centaur Scout Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B- | 96 | 3 m | Day & Night | Like a typical Centaur Scout, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02293` | Ashira Vale Centaur Scout Alpha | [[Regions/Ashira Vale\|Ashira Vale]] | Alpha | B- | 96 | 3 m | Day & Night | Like a typical Centaur Scout, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02294` | Strife Marches Centaur Scout Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | C+ | 86 | 2.64 m | Day & Night | Like a typical Centaur Scout, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02295` | Strife Marches Centaur Scout | [[Regions/Strife Marches\|Strife Marches]] | Adult | C | 76 | 2.4 m | Day & Night | A typical adult Centaur Scout of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_taur` · mesh `taur_base` · material `horse_coat` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · real-animal silhouette with one fantasy exaggeration
