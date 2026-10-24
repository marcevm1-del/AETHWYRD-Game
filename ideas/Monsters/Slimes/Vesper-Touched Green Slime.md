---
type: monster
id: mon_vesper_touched_green_slime
family: "Slimes"
rank: "E-"
tier: variant
tags: [monster, slimes]
---
# Vesper-Touched Green Slime

![[mon_vesper_touched_green_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_green_slime_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Green Slime is a tiny creature with a teardrop-shaped jelly body, about 0.4 m tall. Its gel is weathered and natural, colored in leaf greens over bark brown. Its most striking feature is fallen leaves suspended inside its jelly. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It lopes in long strides, surrounded by drifting pollen and tiny blossoms. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Green Slime\|Green Slime]] (corrupted) |
| Rank · level | E- · 19 (13–26) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 0.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 433 · 69 · 52 · 52 · 52 · 110 |
| XP · gold | 342 · 96 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (override (base species)); animation set `anim_blob`.
- **Dimensions:** 0.4 m high × 0.37 m long × 0.36 m wide; prefab scale 0.8.
- **Physics:** 33.6 kg, gravity ×1.6, poise 26, knockback resistance 0.13, death style `splat_dissolve`.
- **Navigation:** speed 3.43 m/s, turn 569°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** fallen leaves suspended inside its jelly.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Green Slime is a **wild ooze** encountered at E- rank, around level 19. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** fallen leaves suspended inside its jelly. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes E|loot_slime_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | E, D-, E+, E- | 19–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | E, D-, E+, F+, E- | 13–40 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 2 | F+, D- | 13–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02917` | Great Labyrinth (Floors 1-40) Vesper-Touched Green Slime Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E | 26 | 0.44 m | Day & Night | Like a typical Vesper-Touched Green Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_02918` | Aldmere Vesper-Touched Green Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E | 26 | 0.44 m | Day & Night | Like a typical Vesper-Touched Green Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_02919` | Great Labyrinth (Floors 1-40) Vesper-Touched Green Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D- | 40 | 0.54 m | Day & Night | Like a typical Vesper-Touched Green Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_02920` | Whisperwood Vesper-Touched Green Slime Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F+ | 13 | 0.34 m | Day & Night | Like a typical Vesper-Touched Green Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_02921` | Great Labyrinth (Floors 1-40) Vesper-Touched Green Slime Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E+ | 32 | 0.5 m | Day & Night | Like a typical Vesper-Touched Green Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_02922` | Aldmere Vesper-Touched Green Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D- | 40 | 0.54 m | Day & Night | Like a typical Vesper-Touched Green Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_02923` | Great Labyrinth (Floors 1-40) Vesper-Touched Green Slime | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E- | 19 | 0.4 m | Day & Night | A typical adult Vesper-Touched Green Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_02924` | Whisperwood Vesper-Touched Green Slime Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D- | 40 | 0.54 m | Day & Night | Like a typical Vesper-Touched Green Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_02925` | Aldmere Vesper-Touched Green Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E+ | 32 | 0.5 m | Day & Night | Like a typical Vesper-Touched Green Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02926` | Aldmere Vesper-Touched Green Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F+ | 13 | 0.34 m | Day & Night | Like a typical Vesper-Touched Green Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_02927` | Aldmere Vesper-Touched Green Slime | [[Regions/Aldmere\|Aldmere]] | Adult | E- | 19 | 0.4 m | Day & Night | A typical adult Vesper-Touched Green Slime of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · real-animal silhouette with one fantasy exaggeration
