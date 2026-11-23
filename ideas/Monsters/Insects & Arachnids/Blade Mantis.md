---
type: monster
id: mon_blade_mantis
family: "Insects & Arachnids"
rank: "D+"
tier: core
tags: [monster, insects-arachnids]
---
# Blade Mantis

![[mon_blade_mantis_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blade_mantis_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.821 × 1.999 × 1.031 m · local file `Game/Assets/_Game/Art/Models/Monsters/Insects & Arachnids/mon_blade_mantis.fbx`

> The Blade Mantis is a person-sized creature with a low, wide insectoid build, about 2 m long. Its chitin is rough, scarred and spiked, colored in iridescent green, with pale jade markings. Its most striking feature is forearms shaped like curved scythes. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6776 · 234 · 351 · 140 · 234 · 70 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aldmere\|Aldmere]], [[Regions/Velmark\|Velmark]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.66 m high × 2 m long × 1.02 m wide; prefab scale 2.5.
- **Physics:** 316.8 kg, gravity ×1.12, poise 140, knockback resistance 0.31, death style `flip_legs_curl`.
- **Navigation:** speed 6.05 m/s, turn 354°/s, stopping distance 0.68 m.
- **Attack count:** 5; **signature:** forearms shaped like curved scythes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blade Mantis is a **menacing insectoid** encountered at D+ rank, around level 56. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** forearms shaped like curved scythes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Aldmere|Aldmere]], [[Regions/Velmark|Velmark]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids D|loot_insect_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Cavern Blade Mantis|Cavern Blade Mantis]]
- [[Monsters/Insects & Arachnids/Ash Blade Mantis|Ash Blade Mantis]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 3 | C-, C | 65–76 | Day & Night |
| [[Regions/Velmark\|Velmark]] | 2 | D-, C- | 40–65 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 1 | C | 76–76 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 2 | D, D- | 40–48 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | C-, D+, D- | 40–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00663` | Moraveil Blade Mantis Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C- | 65 | 2.2 m | Day & Night | Like a typical Blade Mantis, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00664` | Velmark Blade Mantis Runt | [[Regions/Velmark\|Velmark]] | Runt | D- | 40 | 1.4 m | Day & Night | Like a typical Blade Mantis, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00665` | Aldmere Blade Mantis Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 2.5 m | Day & Night | Like a typical Blade Mantis, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00666` | Strife Marches Blade Mantis Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | D | 48 | 1.7 m | Day & Night | Like a typical Blade Mantis, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00667` | Moraveil Blade Mantis Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C- | 65 | 2 m | Day & Night | Like a typical Blade Mantis, but a rare pale form with white skin or fur and red eyes. |
| `pop_00668` | Iron Hold Blade Mantis Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C- | 65 | 2.2 m | Day & Night | Like a typical Blade Mantis, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00669` | Iron Hold Blade Mantis | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 2 m | Day & Night | A typical adult Blade Mantis of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00670` | Velmark Blade Mantis Albino | [[Regions/Velmark\|Velmark]] | Albino | C- | 65 | 2 m | Day & Night | Like a typical Blade Mantis, but a rare pale form with white skin or fur and red eyes. |
| `pop_00671` | Moraveil Blade Mantis Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C | 76 | 2.5 m | Day & Night | Like a typical Blade Mantis, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00672` | Iron Hold Blade Mantis Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 1.4 m | Day & Night | Like a typical Blade Mantis, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00673` | Strife Marches Blade Mantis Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | D- | 40 | 1.4 m | Day & Night | Like a typical Blade Mantis, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `wind_ribbons` · palette `#3c753d` `#2a4e2b` `#8fe0bd` · triangle-based silhouette, sharp asymmetric spikes
