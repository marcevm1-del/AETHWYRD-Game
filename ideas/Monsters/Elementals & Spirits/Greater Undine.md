---
type: monster
id: mon_greater_undine
family: "Elementals & Spirits"
rank: "C"
tier: variant
tags: [monster, elementals-spirits]
---
# Greater Undine

![[mon_greater_undine_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_undine_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 1.537 × 0.757 × 2.6 m · local file `Game/Assets/_Game/Art/Models/Monsters/Elementals & Spirits/mon_greater_undine.fbx`

> The Greater Undine is a large creature with an upright humanoid build, about 2.6 m tall. Its body is smooth and clean, colored in deep blues with a glassy shine. Its most striking feature is a woman-shaped figure of flowing water. It has two bright dot eyes. Battle-worn plates and trophies hang from its body. It waddles, surrounded by fine mist and droplets that orbit it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Undine\|Undine]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 2.6 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9153 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Lightning. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2.6 m high × 0.78 m long × 0.83 m wide; prefab scale 1.444.
- **Physics:** 239.9 kg, gravity ×1.5, poise 87, knockback resistance 0.39, death style `ragdoll`.
- **Navigation:** speed 4.57 m/s, turn 248°/s, stopping distance 0.84 m.
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

Greater Undine is a **charming elemental** encountered at C rank, around level 76. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a woman-shaped figure of flowing water. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Hoshizora|Hoshizora]], [[Regions/Kitsune Isles|Kitsune Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Kitsune Isles\|Kitsune Isles]] | 7 | C-, B, C+, B-, D+, C | 56–108 | Day |
| [[Regions/Hoshizora\|Hoshizora]] | 4 | C+, C-, B- | 65–96 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04495` | Kitsune Isles Greater Undine Juvenile | [[Regions/Kitsune Isles\|Kitsune Isles]] | Juvenile | C- | 65 | 2.21 m | Day | Like a typical Greater Undine, but young, with brighter colors and unworn features, with a faint translucent shimmer. |
| `pop_04496` | Hoshizora Greater Undine Albino | [[Regions/Hoshizora\|Hoshizora]] | Albino | C+ | 86 | 2.6 m | Day | Like a typical Greater Undine, but a rare pale form with white skin or fur and red eyes. |
| `pop_04497` | Hoshizora Greater Undine Juvenile | [[Regions/Hoshizora\|Hoshizora]] | Juvenile | C- | 65 | 2.21 m | Day | Like a typical Greater Undine, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_04498` | Kitsune Isles Greater Undine Elderborn | [[Regions/Kitsune Isles\|Kitsune Isles]] | Elderborn | B | 108 | 3.51 m | Day | Like a typical Greater Undine, but old and wise, with greying features and a cautious hunting style, with a faint translucent shimmer. |
| `pop_04499` | Kitsune Isles Greater Undine Albino | [[Regions/Kitsune Isles\|Kitsune Isles]] | Albino | C+ | 86 | 2.6 m | Day | Like a typical Greater Undine, but a rare pale form with white skin or fur and red eyes. |
| `pop_04500` | Kitsune Isles Greater Undine Alpha | [[Regions/Kitsune Isles\|Kitsune Isles]] | Alpha | B- | 96 | 3.25 m | Day | Like a typical Greater Undine, but larger and scarred, and others of its kind follow it, with a faint translucent shimmer. |
| `pop_04501` | Kitsune Isles Greater Undine Runt | [[Regions/Kitsune Isles\|Kitsune Isles]] | Runt | D+ | 56 | 1.82 m | Day | Like a typical Greater Undine, but smaller and scrappier than usual, with a faint translucent shimmer. |
| `pop_04502` | Kitsune Isles Greater Undine | [[Regions/Kitsune Isles\|Kitsune Isles]] | Adult | C | 76 | 2.6 m | Day | A typical adult Greater Undine of this region, with a faint translucent shimmer. |
| `pop_04503` | Kitsune Isles Greater Undine Scarred | [[Regions/Kitsune Isles\|Kitsune Isles]] | Scarred | C+ | 86 | 2.86 m | Day | Like a typical Greater Undine, but covered in old battle scars, with a faint translucent shimmer. |
| `pop_04504` | Hoshizora Greater Undine Scarred | [[Regions/Hoshizora\|Hoshizora]] | Scarred | C+ | 86 | 2.86 m | Day | Like a typical Greater Undine, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_04505` | Hoshizora Greater Undine Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | B- | 96 | 3.25 m | Day | Like a typical Greater Undine, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `elemental_emissive` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
