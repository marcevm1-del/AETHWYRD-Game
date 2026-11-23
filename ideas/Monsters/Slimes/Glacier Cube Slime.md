---
type: monster
id: mon_glacier_cube_slime
family: "Slimes"
rank: "D+"
tier: variant
tags: [monster, slimes]
---
# Glacier Cube Slime

![[mon_glacier_cube_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_glacier_cube_slime_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.87 × 0.817 × 0.8 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_glacier_cube_slime.fbx`

> The Glacier Cube Slime is a small creature with a dome-shaped gelatinous body, about 0.8 m tall. Its gel is weathered and natural, colored in pale blues and frost-white. Survivors describe a perfectly cubic body with swallowed debris visible inside. It has amber predator eyes. A distinctive marking runs along its back. It stalks low to the ground, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Cube Slime\|Cube Slime]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 2 · Wild |
| Element · weakness | Ice · Fire |
| Size | 0.8 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2499 · 187 · 140 · 140 · 140 · 110 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.8 m high × 0.74 m long × 0.72 m wide; prefab scale 1.6.
- **Physics:** 295.7 kg, gravity ×1.68, poise 41, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 4.24 m/s, turn 402°/s, stopping distance 0.76 m.
- **Attack count:** 5; **signature:** a perfectly cubic body with swallowed debris visible inside.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Glacier Cube Slime is a **wild ooze** encountered at D+ rank, around level 56. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a perfectly cubic body with swallowed debris visible inside. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes D|loot_slime_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | C-, C, D- | 40–76 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | D, D+, C+ | 48–86 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 5 | D+, C, D, C-, C+ | 48–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05835` | Great Labyrinth (Floors 1-40) Glacier Cube Slime Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C- | 65 | 0.8 m | Day & Night | Like a typical Glacier Cube Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05836` | Aldmere Glacier Cube Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D | 48 | 0.68 m | Day & Night | Like a typical Glacier Cube Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05837` | Great Labyrinth (Floors 1-40) Glacier Cube Slime Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C | 76 | 1 m | Day & Night | Like a typical Glacier Cube Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05838` | Moraveil Glacier Cube Slime | [[Regions/Moraveil\|Moraveil]] | Adult | D+ | 56 | 0.8 m | Day & Night | A typical adult Glacier Cube Slime of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_05839` | Aldmere Glacier Cube Slime | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 0.8 m | Day & Night | A typical adult Glacier Cube Slime of this region, with golden, grass-toned coloring. |
| `pop_05840` | Moraveil Glacier Cube Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C | 76 | 1 m | Day & Night | Like a typical Glacier Cube Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_05841` | Moraveil Glacier Cube Slime Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | D | 48 | 0.68 m | Day & Night | Like a typical Glacier Cube Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05842` | Moraveil Glacier Cube Slime Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | C- | 65 | 0.88 m | Day & Night | Like a typical Glacier Cube Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05843` | Aldmere Glacier Cube Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C+ | 86 | 1.08 m | Day & Night | Like a typical Glacier Cube Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05844` | Great Labyrinth (Floors 1-40) Glacier Cube Slime Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D- | 40 | 0.56 m | Day & Night | Like a typical Glacier Cube Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05845` | Moraveil Glacier Cube Slime Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C+ | 86 | 1.08 m | Day & Night | Like a typical Glacier Cube Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · real-animal silhouette with one fantasy exaggeration
