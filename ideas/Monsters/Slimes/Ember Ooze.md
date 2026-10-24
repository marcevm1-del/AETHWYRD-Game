---
type: monster
id: mon_ember_ooze
family: "Slimes"
rank: "C"
tier: core
tags: [monster, slimes]
---
# Ember Ooze

![[mon_ember_ooze_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ember_ooze_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ember Ooze is a person-sized creature with a wobbling mound of translucent gel, about 1.5 m tall. Its gel is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is molten trails that harden into glass behind it. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4827 · 251 · 188 · 188 · 188 · 110 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 1.5 m high × 1.4 m long × 1.35 m wide; prefab scale 3.
- **Physics:** 1771.9 kg, gravity ×1.6, poise 63, knockback resistance 0.19, death style `splat_dissolve`.
- **Navigation:** speed 6.96 m/s, turn 294°/s, stopping distance 1.08 m.
- **Attack count:** 5; **signature:** molten trails that harden into glass behind it.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ember Ooze is a **menacing ooze** encountered at C rank, around level 76. Its documented behaviour is *Passive* and its AI pattern is *passive_wander*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** molten trails that harden into glass behind it. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Moraveil|Moraveil]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes C|loot_slime_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Ruin Ooze|Ruin Ooze]]
- [[Monsters/Slimes/Ancient Ember Ooze|Ancient Ember Ooze]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Strife Marches\|Strife Marches]] | 3 | C-, C, C+ | 65–86 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 1 | C- | 65–65 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 2 | C+ | 86–86 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 2 | D+, B- | 56–96 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | C, D+, C+ | 56–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00111` | Strife Marches Ember Ooze Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | C- | 65 | 1.27 m | Day & Night | Like a typical Ember Ooze, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00112` | Strife Marches Ember Ooze | [[Regions/Strife Marches\|Strife Marches]] | Adult | C | 76 | 1.5 m | Day & Night | A typical adult Ember Ooze of this region, with golden, grass-toned coloring. |
| `pop_00113` | Great Labyrinth (Floors 1-40) Ember Ooze Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C- | 65 | 1.27 m | Day & Night | Like a typical Ember Ooze, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00114` | Strife Marches Ember Ooze Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | C+ | 86 | 1.5 m | Day & Night | Like a typical Ember Ooze, but a rare pale form with white skin or fur and red eyes. |
| `pop_00115` | Great Labyrinth (Floors 41-90) Ember Ooze Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | C+ | 86 | 1.5 m | Day & Night | Like a typical Ember Ooze, but a rare pale form with white skin or fur and red eyes. |
| `pop_00116` | Moraveil Ember Ooze Runt | [[Regions/Moraveil\|Moraveil]] | Runt | D+ | 56 | 1.05 m | Day & Night | Like a typical Ember Ooze, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00117` | Aldmere Ember Ooze | [[Regions/Aldmere\|Aldmere]] | Adult | C | 76 | 1.5 m | Day & Night | A typical adult Ember Ooze of this region, with golden, grass-toned coloring. |
| `pop_00118` | Great Labyrinth (Floors 41-90) Ember Ooze Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C+ | 86 | 1.65 m | Day & Night | Like a typical Ember Ooze, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00119` | Aldmere Ember Ooze Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 1.05 m | Day & Night | Like a typical Ember Ooze, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00120` | Moraveil Ember Ooze Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | B- | 96 | 1.88 m | Day & Night | Like a typical Ember Ooze, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00121` | Aldmere Ember Ooze Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 1.65 m | Day & Night | Like a typical Ember Ooze, but covered in old battle scars, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
