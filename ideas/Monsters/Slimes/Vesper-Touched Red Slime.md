---
type: monster
id: mon_vesper_touched_red_slime
family: "Slimes"
rank: "D-"
tier: variant
tags: [monster, slimes]
---
# Vesper-Touched Red Slime

![[mon_vesper_touched_red_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_red_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,894 tris · 0.51 × 0.51 × 0.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Red Slime is a small creature with a teardrop-shaped jelly body, about 0.5 m tall. Its gel is rough, scarred and spiked, colored in ember reds fading to soot black. Guild sketches always show a faint ember core pulsing like a heartbeat. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Red Slime\|Red Slime]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1330 · 136 · 102 · 102 · 102 · 110 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.5 m high × 0.47 m long × 0.45 m wide; prefab scale 1.
- **Physics:** 65.6 kg, gravity ×1.6, poise 33, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 4.02 m/s, turn 509°/s, stopping distance 0.63 m.
- **Attack count:** 5; **signature:** a faint ember core pulsing like a heartbeat.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Red Slime is a **menacing ooze** encountered at D- rank, around level 40. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a faint ember core pulsing like a heartbeat. Watch for its tell and leave a response window before committing to a long combo.

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
| [[Regions/Aldmere\|Aldmere]] | 5 | D, E+, D+, C- | 32–65 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D, D-, C- | 40–65 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 3 | E+, D | 32–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05769` | Aldmere Vesper-Touched Red Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D | 48 | 0.55 m | Day & Night | Like a typical Vesper-Touched Red Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_05770` | Great Labyrinth (Floors 1-40) Vesper-Touched Red Slime Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D | 48 | 0.55 m | Day & Night | Like a typical Vesper-Touched Red Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05771` | Aldmere Vesper-Touched Red Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E+ | 32 | 0.42 m | Day & Night | Like a typical Vesper-Touched Red Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_05772` | Aldmere Vesper-Touched Red Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D+ | 56 | 0.63 m | Day & Night | Like a typical Vesper-Touched Red Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_05773` | Aldmere Vesper-Touched Red Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C- | 65 | 0.68 m | Day & Night | Like a typical Vesper-Touched Red Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_05774` | Great Labyrinth (Floors 1-40) Vesper-Touched Red Slime | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D- | 40 | 0.5 m | Day & Night | A typical adult Vesper-Touched Red Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05775` | Moraveil Vesper-Touched Red Slime Juvenile | [[Regions/Moraveil\|Moraveil]] | Juvenile | E+ | 32 | 0.42 m | Day & Night | Like a typical Vesper-Touched Red Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_05776` | Moraveil Vesper-Touched Red Slime Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D | 48 | 0.55 m | Day & Night | Like a typical Vesper-Touched Red Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_05777` | Aldmere Vesper-Touched Red Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D | 48 | 0.5 m | Day & Night | Like a typical Vesper-Touched Red Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05778` | Moraveil Vesper-Touched Red Slime Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D | 48 | 0.5 m | Day & Night | Like a typical Vesper-Touched Red Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_05779` | Great Labyrinth (Floors 1-40) Vesper-Touched Red Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C- | 65 | 0.68 m | Day & Night | Like a typical Vesper-Touched Red Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#401d14` · triangle-based silhouette, sharp asymmetric spikes
