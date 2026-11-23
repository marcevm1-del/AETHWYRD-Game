---
type: monster
id: mon_shade_centaur_scout
family: "Centaurs & Taurs"
rank: "C+"
tier: variant
tags: [monster, centaurs-taurs]
---
# Shade Centaur Scout

![[mon_shade_centaur_scout_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_shade_centaur_scout_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.146 × 2.661 × 2.4 m · local file `Game/Assets/_Game/Art/Models/Monsters/Centaurs & Taurs/mon_shade_centaur_scout.fbx`

> The Shade Centaur Scout is a person-sized creature with a centauroid body with a humanoid torso on a four-legged base, about 2.4 m tall. Its coat is weathered and natural, colored in chestnut, with violet markings. Look for a horsebow and a braided mane. It has dark, wary eyes. Battle-worn plates and trophies hang from its body. It prowls, surrounded by shadows that lean toward it. This Dark-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Centaurs & Taurs|Centaurs & Taurs]] · Beastfolk |
| Variant of | [[Monsters/Centaurs & Taurs/Centaur Scout\|Centaur Scout]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 2 · Wild |
| Element · weakness | Dark · Light |
| Size | 2.4 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10704 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/taur\|taur]] · `anim_taur` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Steppe Epic |
| Trope | Proud nomadic centaur tribes |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/taur|taur]] (rigId); animation set `anim_taur`.
- **Dimensions:** 2.52 m high × 2.4 m long × 0.58 m wide; prefab scale 1.
- **Physics:** 276.5 kg, gravity ×1.3, poise 94, knockback resistance 0.69, death style `ragdoll_slide`.
- **Navigation:** speed 8.53 m/s, turn 232°/s, stopping distance 0.78 m.
- **Attack count:** 5; **signature:** a horsebow and a braided mane.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Spear Thrust\|Spear Thrust]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Trample\|Trample]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Volley\|Volley]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Lance Charge\|Lance Charge]] | dash | 1.7 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Shade Centaur Scout is a **wild beastfolk** encountered at C+ rank, around level 86. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a horsebow and a braided mane. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_taur`, animation set `anim_taur`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Centaurs & Taurs C|loot_centaur_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horsehair\|Horsehair]] | 60% | 1–3 |
| [[Items/Painted Barding\|Painted Barding]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 5 | C-, B, B+, B- | 65–120 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 6 | C-, B+, C, B-, B | 65–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05136` | Strife Marches Shade Centaur Scout Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C- | 65 | 1.68 m | Day & Night | Like a typical Shade Centaur Scout, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05137` | Moraveil Shade Centaur Scout Runt | [[Regions/Moraveil\|Moraveil]] | Runt | C- | 65 | 1.68 m | Day & Night | Like a typical Shade Centaur Scout, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_05138` | Strife Marches Shade Centaur Scout Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | B | 108 | 3 m | Day & Night | Like a typical Shade Centaur Scout, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05139` | Strife Marches Shade Centaur Scout Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | B+ | 120 | 3.24 m | Day & Night | Like a typical Shade Centaur Scout, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05140` | Moraveil Shade Centaur Scout Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | B+ | 120 | 3.24 m | Day & Night | Like a typical Shade Centaur Scout, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_05141` | Moraveil Shade Centaur Scout Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | C | 76 | 2.04 m | Day & Night | Like a typical Shade Centaur Scout, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05142` | Moraveil Shade Centaur Scout Albino | [[Regions/Moraveil\|Moraveil]] | Albino | B- | 96 | 2.4 m | Day & Night | Like a typical Shade Centaur Scout, but a rare pale form with white skin or fur and red eyes. |
| `pop_05143` | Moraveil Shade Centaur Scout Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | B- | 96 | 2.64 m | Day & Night | Like a typical Shade Centaur Scout, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05144` | Strife Marches Shade Centaur Scout Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B- | 96 | 2.4 m | Day & Night | Like a typical Shade Centaur Scout, but a rare pale form with white skin or fur and red eyes. |
| `pop_05145` | Moraveil Shade Centaur Scout Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | B | 108 | 3 m | Day & Night | Like a typical Shade Centaur Scout, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05146` | Strife Marches Shade Centaur Scout Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B- | 96 | 2.64 m | Day & Night | Like a typical Shade Centaur Scout, but covered in old battle scars, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_taur` · mesh `taur_base` · material `horse_coat` · VFX `shadow_wisps` · palette `#8d6548` `#5b3f31` `#9a86d8` · real-animal silhouette with one fantasy exaggeration
