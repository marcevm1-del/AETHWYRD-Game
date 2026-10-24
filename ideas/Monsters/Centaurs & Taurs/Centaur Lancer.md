---
type: monster
id: mon_centaur_lancer
family: "Centaurs & Taurs"
rank: "C+"
tier: core
tags: [monster, centaurs-taurs]
---
# Centaur Lancer

![[mon_centaur_lancer_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_centaur_lancer_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,428 tris · 1.244 × 2.642 × 2.6 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Centaur Lancer is a large creature with a powerful taur build, about 2.6 m tall. Its coat is weathered and natural, colored in muted greys and dusty browns. Survivors describe a long lance and painted barding. It has alert animal eyes. Battle-worn plates and trophies hang from its body. It lopes in long strides. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Centaurs & Taurs|Centaurs & Taurs]] · Beastfolk |
| Rank · level | C+ · 86 (76–96) |
| Menace | 2 · Wild |
| Element · weakness | None · Fire |
| Size | 2.6 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11000 · 425 · 354 · 198 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/taur\|taur]] · `anim_taur` |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Fanghold\|Fanghold]], [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Steppe Epic |
| Trope | Proud nomadic centaur tribes |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/taur|taur]] (rigId); animation set `anim_taur`.
- **Dimensions:** 2.73 m high × 2.6 m long × 0.62 m wide; prefab scale 1.083.
- **Physics:** 351.5 kg, gravity ×1.3, poise 107, knockback resistance 0.69, death style `ragdoll_slide`.
- **Navigation:** speed 8.45 m/s, turn 223°/s, stopping distance 0.82 m.
- **Attack count:** 4; **signature:** a long lance and painted barding.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Spear Thrust\|Spear Thrust]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Trample\|Trample]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Volley\|Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Lance Charge\|Lance Charge]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Centaur Lancer is a **wild beastfolk** encountered at C+ rank, around level 86. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a long lance and painted barding. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Strife Marches|Strife Marches]], [[Regions/Fanghold|Fanghold]], [[Regions/Aldmere|Aldmere]], [[Regions/Moraveil|Moraveil]], [[Regions/Zaruma|Zaruma]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_taur`, animation set `anim_taur`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Centaurs & Taurs C|loot_centaur_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horsehair\|Horsehair]] | 60% | 1–3 |
| [[Items/Painted Barding\|Painted Barding]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Centaurs & Taurs/Crag Centaur Lancer|Crag Centaur Lancer]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 2 | C, B | 76–108 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 3 | B-, B+ | 96–120 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 2 | B-, C | 76–96 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 1 | B | 108–108 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | B+, B- | 96–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02296` | Moraveil Centaur Lancer Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | C | 76 | 2.21 m | Day & Night | Like a typical Centaur Lancer, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02297` | Strife Marches Centaur Lancer Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B- | 96 | 2.6 m | Day & Night | Like a typical Centaur Lancer, but a rare pale form with white skin or fur and red eyes. |
| `pop_02298` | Moraveil Centaur Lancer Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | B | 108 | 3.25 m | Day & Night | Like a typical Centaur Lancer, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02299` | Zaruma Centaur Lancer Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | B- | 96 | 2.86 m | Day & Night | Like a typical Centaur Lancer, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02300` | Fanghold Centaur Lancer Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | B | 108 | 3.25 m | Day & Night | Like a typical Centaur Lancer, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02301` | Aldmere Centaur Lancer Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B+ | 120 | 3.51 m | Day & Night | Like a typical Centaur Lancer, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02302` | Strife Marches Centaur Lancer Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B- | 96 | 2.86 m | Day & Night | Like a typical Centaur Lancer, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02303` | Aldmere Centaur Lancer Albino | [[Regions/Aldmere\|Aldmere]] | Albino | B- | 96 | 2.6 m | Day & Night | Like a typical Centaur Lancer, but a rare pale form with white skin or fur and red eyes. |
| `pop_02304` | Zaruma Centaur Lancer Juvenile | [[Regions/Zaruma\|Zaruma]] | Juvenile | C | 76 | 2.21 m | Day & Night | Like a typical Centaur Lancer, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02305` | Aldmere Centaur Lancer Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | B- | 96 | 2.86 m | Day & Night | Like a typical Centaur Lancer, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02306` | Strife Marches Centaur Lancer Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | B+ | 120 | 3.51 m | Day & Night | Like a typical Centaur Lancer, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_taur` · mesh `taur_base` · material `horse_coat` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · real-animal silhouette with one fantasy exaggeration
