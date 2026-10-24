---
type: monster
id: mon_meadow_slime
family: "Slimes"
rank: "F"
tier: variant
tags: [monster, slimes]
---
# Meadow Slime

![[mon_meadow_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_meadow_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,928 tris · 0.483 × 0.483 × 0.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Meadow Slime is a tiny creature with a teardrop-shaped jelly body, about 0.4 m tall. Its gel is smooth and clean, colored in pale jade and cloud white. Survivors describe a teardrop body with a glossy highlight and two dot eyes. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It waddles, surrounded by swirling leaves and a constant breeze. Adapted to plains lands, it has golden, grass-toned coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Blue Slime\|Blue Slime]] (regional) |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 0.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 142 · 34 · 25 · 25 · 25 · 110 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (override (base species)); animation set `anim_blob`.
- **Dimensions:** 0.4 m high × 0.37 m long × 0.36 m wide; prefab scale 0.8.
- **Physics:** 30.2 kg, gravity ×1.28, poise 22, knockback resistance 0.1, death style `splat_dissolve`.
- **Navigation:** speed 3.33 m/s, turn 569°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** a teardrop body with a glossy highlight and two dot eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Meadow Slime is a **charming ooze** encountered at F rank, around level 8. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a teardrop body with a glossy highlight and two dot eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes F|loot_slime_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 3 | F-, F, F+ | 3–13 | Day |
| [[Regions/Whisperwood\|Whisperwood]] | 4 | E-, F+, F-, F | 3–19 | Day |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | F+, E, F | 8–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02906` | Aldmere Meadow Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.34 m | Day | Like a typical Meadow Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02907` | Whisperwood Meadow Slime Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.5 m | Day | Like a typical Meadow Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_02908` | Great Labyrinth (Floors 1-40) Meadow Slime Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | F+ | 13 | 0.4 m | Day | Like a typical Meadow Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02909` | Great Labyrinth (Floors 1-40) Meadow Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E | 26 | 0.54 m | Day | Like a typical Meadow Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_02910` | Great Labyrinth (Floors 1-40) Meadow Slime Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | F+ | 13 | 0.44 m | Day | Like a typical Meadow Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_02911` | Great Labyrinth (Floors 1-40) Meadow Slime | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F | 8 | 0.4 m | Day | A typical adult Meadow Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_02912` | Whisperwood Meadow Slime Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 0.4 m | Day | Like a typical Meadow Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02913` | Aldmere Meadow Slime | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.4 m | Day | A typical adult Meadow Slime of this region, with golden, grass-toned coloring. |
| `pop_02914` | Aldmere Meadow Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.44 m | Day | Like a typical Meadow Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02915` | Whisperwood Meadow Slime Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.28 m | Day | Like a typical Meadow Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_02916` | Whisperwood Meadow Slime | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.4 m | Day | A typical adult Meadow Slime of this region, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
