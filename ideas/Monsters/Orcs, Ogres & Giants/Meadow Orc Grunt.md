---
type: monster
id: mon_meadow_orc_grunt
family: "Orcs, Ogres & Giants"
rank: "E+"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Meadow Orc Grunt

![[mon_meadow_orc_grunt_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_meadow_orc_grunt_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,508 tris · 1.178 × 1.266 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Meadow Orc Grunt is a person-sized creature with a lean humanoid frame, about 2 m tall. Its hide is rough, scarred and spiked, colored in olive-green, with pale jade markings. Survivors describe tusks, war paint and a dented iron sword. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by swirling leaves and a constant breeze. Adapted to plains lands, it has golden, grass-toned coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Orc Grunt\|Orc Grunt]] (regional) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2347 · 166 · 138 · 110 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/medium_biped\|medium_biped]] · `anim_medium_biped` |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/medium_biped|medium_biped]] (rigId); animation set `anim_medium_biped`.
- **Dimensions:** 2 m high × 0.6 m long × 0.64 m wide; prefab scale 1.111.
- **Physics:** 93.6 kg, gravity ×1.2, poise 61, knockback resistance 0.33, death style `ragdoll`.
- **Navigation:** speed 5.9 m/s, turn 283°/s, stopping distance 0.74 m.
- **Attack count:** 5; **signature:** tusks, war paint and a dented iron sword.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slash\|Slash]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Heavy Swing\|Heavy Swing]] | melee | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Counter\|Guard Counter]] | counter | 1.3 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/War Cry\|War Cry]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Meadow Orc Grunt is a **menacing giant** encountered at E+ rank, around level 32. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tusks, war paint and a dented iron sword. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Fanghold|Fanghold]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_medium_biped`, animation set `anim_medium_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Orcs, Ogres & Giants E|loot_orc_giant_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 6 | E, D-, D, E+, E- | 19–48 | Day & Night |
| [[Regions/Fanghold\|Fanghold]] | 5 | D+, D, D-, E, E+ | 26–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03958` | Aldmere Meadow Orc Grunt Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 1.7 m | Day & Night | Like a typical Meadow Orc Grunt, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03959` | Fanghold Meadow Orc Grunt Elderborn | [[Regions/Fanghold\|Fanghold]] | Elderborn | D+ | 56 | 2.7 m | Day & Night | Like a typical Meadow Orc Grunt, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03960` | Fanghold Meadow Orc Grunt Alpha | [[Regions/Fanghold\|Fanghold]] | Alpha | D | 48 | 2.5 m | Day & Night | Like a typical Meadow Orc Grunt, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03961` | Fanghold Meadow Orc Grunt Scarred | [[Regions/Fanghold\|Fanghold]] | Scarred | D- | 40 | 2.2 m | Day & Night | Like a typical Meadow Orc Grunt, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03962` | Fanghold Meadow Orc Grunt Juvenile | [[Regions/Fanghold\|Fanghold]] | Juvenile | E | 26 | 1.7 m | Day & Night | Like a typical Meadow Orc Grunt, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_03963` | Aldmere Meadow Orc Grunt Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 2 m | Day & Night | Like a typical Meadow Orc Grunt, but a rare pale form with white skin or fur and red eyes. |
| `pop_03964` | Aldmere Meadow Orc Grunt Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 2.5 m | Day & Night | Like a typical Meadow Orc Grunt, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_03965` | Fanghold Meadow Orc Grunt | [[Regions/Fanghold\|Fanghold]] | Adult | E+ | 32 | 2 m | Day & Night | A typical adult Meadow Orc Grunt of this region, with golden, grass-toned coloring. |
| `pop_03966` | Aldmere Meadow Orc Grunt Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 2.2 m | Day & Night | Like a typical Meadow Orc Grunt, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03967` | Aldmere Meadow Orc Grunt | [[Regions/Aldmere\|Aldmere]] | Adult | E+ | 32 | 2 m | Day & Night | A typical adult Meadow Orc Grunt of this region, with golden, grass-toned coloring. |
| `pop_03968` | Aldmere Meadow Orc Grunt Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 1.4 m | Day & Night | Like a typical Meadow Orc Grunt, but smaller and scrappier than usual, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `thick_skin` · VFX `wind_ribbons` · palette `#7b8f4c` `#536033` `#8fe0bd` · triangle-based silhouette, sharp asymmetric spikes
