---
type: monster
id: mon_gale_slime
family: "Slimes"
rank: "F+"
tier: variant
tags: [monster, slimes]
---
# Gale Slime

![[mon_gale_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_gale_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,556 tris · 0.508 × 0.508 × 0.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Gale Slime is a tiny creature with a wobbling mound of translucent gel, about 0.4 m tall. Its gel is smooth and clean, colored in pale jade and cloud white. Its most striking feature is fallen leaves suspended inside its jelly. It has big round glossy eyes. It has no ornament at all: simple, readable shapes. It waddles, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Green Slime\|Green Slime]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 1 · Charming |
| Element · weakness | Wind · Fire |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 259 · 50 · 37 · 37 · 37 · 110 |
| XP · gold | 190 · 57 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (override (base species)); animation set `anim_blob`.
- **Dimensions:** 0.4 m high × 0.37 m long × 0.36 m wide; prefab scale 0.8.
- **Physics:** 30.2 kg, gravity ×1.28, poise 22, knockback resistance 0.1, death style `splat_dissolve`.
- **Navigation:** speed 3.17 m/s, turn 569°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** fallen leaves suspended inside its jelly.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Gale Cutter\|Gale Cutter]] | magic | 1.5 | 10 s | Wind | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Gale Slime is a **charming ooze** encountered at F+ rank, around level 13. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** fallen leaves suspended inside its jelly. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Aldmere\|Aldmere]] | 7 | E-, F, F+, E+, F-, E | 3–32 | Day |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | E+, E, E-, F- | 3–32 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05758` | Aldmere Gale Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E- | 19 | 0.44 m | Day | Like a typical Gale Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05759` | Aldmere Gale Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 0.4 m | Day | Like a typical Gale Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05760` | Aldmere Gale Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 0.34 m | Day | Like a typical Gale Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05761` | Aldmere Gale Slime | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 0.4 m | Day | A typical adult Gale Slime of this region, with golden, grass-toned coloring. |
| `pop_05762` | Great Labyrinth (Floors 1-40) Gale Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E+ | 32 | 0.54 m | Day | Like a typical Gale Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05763` | Aldmere Gale Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 0.54 m | Day | Like a typical Gale Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05764` | Great Labyrinth (Floors 1-40) Gale Slime Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E | 26 | 0.5 m | Day | Like a typical Gale Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05765` | Aldmere Gale Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.28 m | Day | Like a typical Gale Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05766` | Aldmere Gale Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 0.5 m | Day | Like a typical Gale Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05767` | Great Labyrinth (Floors 1-40) Gale Slime Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E- | 19 | 0.4 m | Day | Like a typical Gale Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05768` | Great Labyrinth (Floors 1-40) Gale Slime Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 0.28 m | Day | Like a typical Gale Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · circle-based, soft silhouette
