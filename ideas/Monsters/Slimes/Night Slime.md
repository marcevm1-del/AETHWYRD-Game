---
type: monster
id: mon_night_slime
family: "Slimes"
rank: "F"
tier: variant
tags: [monster, slimes]
---
# Night Slime

![[mon_night_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_night_slime_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 6,000 tris · 0.455 × 0.526 × 0.4 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_night_slime.fbx`

> The Night Slime is a tiny creature with a teardrop-shaped jelly body, about 0.4 m tall. Its gel is smooth and clean, colored in ink black with bruised violet. Guild sketches always show a teardrop body with a glossy highlight and two dot eyes. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by shadows that lean toward it. This Dark-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Blue Slime\|Blue Slime]] (elemental) |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Dark · Light |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 142 · 34 · 25 · 25 · 25 · 110 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (override (base species)); animation set `anim_blob`.
- **Dimensions:** 0.4 m high × 0.37 m long × 0.36 m wide; prefab scale 0.8.
- **Physics:** 33.6 kg, gravity ×1.6, poise 22, knockback resistance 0.1, death style `splat_dissolve`.
- **Navigation:** speed 3.08 m/s, turn 569°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** a teardrop body with a glossy highlight and two dot eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Night Slime is a **charming ooze** encountered at F rank, around level 8. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a teardrop body with a glossy highlight and two dot eyes. Watch for its tell and leave a response window before committing to a long combo.

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
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | F+, F-, F | 3–13 | Day |
| [[Regions/Aldmere\|Aldmere]] | 6 | E, E-, F+, F- | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05747` | Great Labyrinth (Floors 1-40) Night Slime Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | F+ | 13 | 0.4 m | Day | Like a typical Night Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05748` | Great Labyrinth (Floors 1-40) Night Slime Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 0.28 m | Day | Like a typical Night Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05749` | Great Labyrinth (Floors 1-40) Night Slime Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | F- | 3 | 0.34 m | Day | Like a typical Night Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05750` | Great Labyrinth (Floors 1-40) Night Slime Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | F+ | 13 | 0.44 m | Day | Like a typical Night Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05751` | Aldmere Night Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 0.54 m | Day | Like a typical Night Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05752` | Great Labyrinth (Floors 1-40) Night Slime | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F | 8 | 0.4 m | Day | A typical adult Night Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05753` | Aldmere Night Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.5 m | Day | Like a typical Night Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05754` | Aldmere Night Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.44 m | Day | Like a typical Night Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05755` | Aldmere Night Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.28 m | Day | Like a typical Night Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05756` | Aldmere Night Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 0.4 m | Day | Like a typical Night Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05757` | Aldmere Night Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.34 m | Day | Like a typical Night Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#292940` · circle-based, soft silhouette
