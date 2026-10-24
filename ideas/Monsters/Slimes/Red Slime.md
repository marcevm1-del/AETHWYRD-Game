---
type: monster
id: mon_red_slime
family: "Slimes"
rank: "E"
tier: core
tags: [monster, slimes]
---
# Red Slime

![[mon_red_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_red_slime_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Red Slime is a small creature with a dome-shaped gelatinous body, about 0.5 m tall. Its gel is weathered and natural, colored in ember reds fading to soot black. Its most striking feature is a faint ember core pulsing like a heartbeat. It has alert animal eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 0.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 713 · 91 · 68 · 68 · 68 · 110 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.5 m high × 0.47 m long × 0.45 m wide; prefab scale 1.
- **Physics:** 65.6 kg, gravity ×1.6, poise 29, knockback resistance 0.13, death style `splat_dissolve`.
- **Navigation:** speed 4.03 m/s, turn 509°/s, stopping distance 0.63 m.
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

Red Slime is a **wild ooze** encountered at E rank, around level 26. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a faint ember core pulsing like a heartbeat. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Sylvaran|Sylvaran]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes E|loot_slime_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Moss Slime|Moss Slime]]
- [[Monsters/Slimes/Vesper-Touched Red Slime|Vesper-Touched Red Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sylvaran\|Sylvaran]] | 3 | E, D-, F+ | 13–40 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 1 | E | 26–26 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | E+, D, F+, E- | 13–48 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D-, E+, F+ | 13–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00023` | Sylvaran Red Slime | [[Regions/Sylvaran\|Sylvaran]] | Adult | E | 26 | 0.5 m | Day & Night | A typical adult Red Slime of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00024` | Whisperwood Red Slime | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 0.5 m | Day & Night | A typical adult Red Slime of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00025` | Sylvaran Red Slime Alpha | [[Regions/Sylvaran\|Sylvaran]] | Alpha | D- | 40 | 0.63 m | Day & Night | Like a typical Red Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00026` | Aldmere Red Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.55 m | Day & Night | Like a typical Red Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00027` | Aldmere Red Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 0.68 m | Day & Night | Like a typical Red Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00028` | Great Labyrinth (Floors 1-40) Red Slime Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D- | 40 | 0.63 m | Day & Night | Like a typical Red Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00029` | Aldmere Red Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.35 m | Day & Night | Like a typical Red Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00030` | Great Labyrinth (Floors 1-40) Red Slime Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E+ | 32 | 0.55 m | Day & Night | Like a typical Red Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00031` | Great Labyrinth (Floors 1-40) Red Slime Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F+ | 13 | 0.35 m | Day & Night | Like a typical Red Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00032` | Aldmere Red Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E- | 19 | 0.42 m | Day & Night | Like a typical Red Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00033` | Sylvaran Red Slime Runt | [[Regions/Sylvaran\|Sylvaran]] | Runt | F+ | 13 | 0.35 m | Day & Night | Like a typical Red Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · real-animal silhouette with one fantasy exaggeration
