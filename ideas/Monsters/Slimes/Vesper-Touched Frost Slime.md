---
type: monster
id: mon_vesper_touched_frost_slime
family: "Slimes"
rank: "C-"
tier: variant
tags: [monster, slimes]
---
# Vesper-Touched Frost Slime

![[mon_vesper_touched_frost_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_frost_slime_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 6,000 tris · 0.602 × 0.525 × 0.5 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_vesper_touched_frost_slime.fbx`

> The Vesper-Touched Frost Slime is a small creature with a teardrop-shaped jelly body, about 0.5 m tall. Its gel is rough, scarred and spiked, colored in pale blues and frost-white. Survivors describe frost crystals growing from its crown. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by falling snow motes and frosted ground where it steps. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Frost Slime\|Frost Slime]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 0.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2719 · 216 · 162 · 162 · 162 · 110 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.5 m high × 0.47 m long × 0.45 m wide; prefab scale 1.
- **Physics:** 72.2 kg, gravity ×1.68, poise 36, knockback resistance 0.19, death style `splat_dissolve`.
- **Navigation:** speed 3.71 m/s, turn 509°/s, stopping distance 0.63 m.
- **Attack count:** 5; **signature:** frost crystals growing from its crown.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frost Breath\|Frost Breath]] | magic | 1.5 | 10 s | Ice | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Frost Slime is a **menacing ooze** encountered at C- rank, around level 65. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** frost crystals growing from its crown. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes C|loot_slime_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | C-, C, B-, C+ | 65–96 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | D+, C, D, C-, C+, B- | 48–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05824` | Great Labyrinth (Floors 1-40) Vesper-Touched Frost Slime | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C- | 65 | 0.5 m | Day & Night | A typical adult Vesper-Touched Frost Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05825` | Great Labyrinth (Floors 1-40) Vesper-Touched Frost Slime Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C | 76 | 0.5 m | Day & Night | Like a typical Vesper-Touched Frost Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05826` | Aldmere Vesper-Touched Frost Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D+ | 56 | 0.42 m | Day & Night | Like a typical Vesper-Touched Frost Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05827` | Aldmere Vesper-Touched Frost Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C | 76 | 0.55 m | Day & Night | Like a typical Vesper-Touched Frost Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05828` | Great Labyrinth (Floors 1-40) Vesper-Touched Frost Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B- | 96 | 0.68 m | Day & Night | Like a typical Vesper-Touched Frost Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05829` | Great Labyrinth (Floors 1-40) Vesper-Touched Frost Slime Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C | 76 | 0.55 m | Day & Night | Like a typical Vesper-Touched Frost Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05830` | Aldmere Vesper-Touched Frost Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D | 48 | 0.35 m | Day & Night | Like a typical Vesper-Touched Frost Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_05831` | Aldmere Vesper-Touched Frost Slime | [[Regions/Aldmere\|Aldmere]] | Adult | C- | 65 | 0.5 m | Day & Night | A typical adult Vesper-Touched Frost Slime of this region, with golden, grass-toned coloring. |
| `pop_05832` | Aldmere Vesper-Touched Frost Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C+ | 86 | 0.63 m | Day & Night | Like a typical Vesper-Touched Frost Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05833` | Aldmere Vesper-Touched Frost Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B- | 96 | 0.68 m | Day & Night | Like a typical Vesper-Touched Frost Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05834` | Great Labyrinth (Floors 1-40) Vesper-Touched Frost Slime Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C+ | 86 | 0.63 m | Day & Night | Like a typical Vesper-Touched Frost Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
