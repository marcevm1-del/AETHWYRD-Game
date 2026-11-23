---
type: monster
id: mon_steppe_fenrir_pup
family: "Beasts"
rank: "B+"
tier: variant
tags: [monster, beasts]
---
# Steppe Fenrir Pup

![[mon_steppe_fenrir_pup_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_steppe_fenrir_pup_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,998 tris · 0.446 × 1.501 × 0.928 m · local file `Game/Assets/_Game/Art/Models/Monsters/Beasts/mon_steppe_fenrir_pup.fbx`

> The Steppe Fenrir Pup is a person-sized creature with a powerful four-legged hunter's body, about 1.5 m long. Its coat is weathered and natural, colored in warm brown, with pale jade markings. Look for frosted fur and breath that freezes the air. It has dark, wary eyes. Faint runes glow along its body when it fights. It prowls, surrounded by swirling leaves and a constant breeze. Adapted to steppe lands, it has wind-burnt coloring and a lean frame.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Frost Fenrir Pup\|Frost Fenrir Pup]] (regional) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 2 · Wild |
| Element · weakness | Wind · Fire |
| Size | 1.5 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 14975 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Bastion\|Bastion]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 0.98 m high × 1.5 m long × 0.24 m wide; prefab scale 0.375.
- **Physics:** 60.8 kg, gravity ×0.96, poise 69, knockback resistance 0.97, death style `heavy_fall_dust`.
- **Navigation:** speed 5.84 m/s, turn 261°/s, stopping distance 0.7 m.
- **Attack count:** 5; **signature:** frosted fur and breath that freezes the air.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rending Bite\|Rending Bite]] | melee | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Steppe Fenrir Pup is a **wild beast** encountered at B+ rank, around level 120. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** frosted fur and breath that freezes the air. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Bastion|Bastion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Beasts B|loot_beast_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Fanghold\|Fanghold]] | 5 | A+, A-, B-, B | 96–159 | Day & Night |
| [[Regions/Bastion\|Bastion]] | 6 | B-, B, B+, A, A+, A- | 96–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06198` | Fanghold Steppe Fenrir Pup Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | A+ | 159 | 2.03 m | Day & Night | Like a typical Steppe Fenrir Pup, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_06199` | Bastion Steppe Fenrir Pup Runt | [[Regions/Bastion\|Bastion]] | Runt | B- | 96 | 1.05 m | Day & Night | Like a typical Steppe Fenrir Pup, but smaller and scrappier than usual, with wind-burnt coloring and a lean frame. |
| `pop_06200` | Fanghold Steppe Fenrir Pup Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | A- | 132 | 1.65 m | Day & Night | Like a typical Steppe Fenrir Pup, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_06201` | Fanghold Steppe Fenrir Pup Runt | [[Regions/Fanghold\|Fanghold]] | Runt | B- | 96 | 1.05 m | Day & Night | Like a typical Steppe Fenrir Pup, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_06202` | Bastion Steppe Fenrir Pup Juvenile | [[Regions/Bastion\|Bastion]] | Juvenile | B | 108 | 1.27 m | Day & Night | Like a typical Steppe Fenrir Pup, but young, with brighter colors and unworn features, with wind-burnt coloring and a lean frame. |
| `pop_06203` | Bastion Steppe Fenrir Pup | [[Regions/Bastion\|Bastion]] | Adult | B+ | 120 | 1.5 m | Day & Night | A typical adult Steppe Fenrir Pup of this region, with wind-burnt coloring and a lean frame. |
| `pop_06204` | Bastion Steppe Fenrir Pup Alpha | [[Regions/Bastion\|Bastion]] | Alpha | A | 146 | 1.88 m | Day & Night | Like a typical Steppe Fenrir Pup, but larger and scarred, and others of its kind follow it, with wind-burnt coloring and a lean frame. |
| `pop_06205` | Bastion Steppe Fenrir Pup Elderborn | [[Regions/Bastion\|Bastion]] | Elderborn | A+ | 159 | 2.03 m | Day & Night | Like a typical Steppe Fenrir Pup, but old and wise, with greying features and a cautious hunting style, with wind-burnt coloring and a lean frame. |
| `pop_06206` | Bastion Steppe Fenrir Pup Albino | [[Regions/Bastion\|Bastion]] | Albino | A- | 132 | 1.5 m | Day & Night | Like a typical Steppe Fenrir Pup, but a rare pale form with white skin or fur and red eyes. |
| `pop_06207` | Fanghold Steppe Fenrir Pup Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | B | 108 | 1.27 m | Day & Night | Like a typical Steppe Fenrir Pup, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_06208` | Fanghold Steppe Fenrir Pup Albino | [[Regions/Fanghold\|Fanghold]] | Albino | A- | 132 | 1.5 m | Day & Night | Like a typical Steppe Fenrir Pup, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `wind_ribbons` · palette `#8b5d47` `#5a3a30` `#8fe0bd` · real-animal silhouette with one fantasy exaggeration
