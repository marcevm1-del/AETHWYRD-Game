---
type: monster
id: mon_storm_slime
family: "Slimes"
rank: "B"
tier: core
tags: [monster, slimes]
---
# Storm Slime

![[mon_storm_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_storm_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,604 tris · 1.276 × 1.276 × 1.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Storm Slime is a person-sized creature with a wobbling mound of translucent gel, about 1.2 m tall. Its gel is weathered and natural, colored in storm violet shot through with electric yellow. Guild sketches always show a storm-cloud interior that flashes with tiny lightning. It has amber predator eyes. Faint runes glow along its body when it fights. It prowls, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | B · 108 (96–120) |
| Menace | 2 · Wild |
| Element · weakness | Lightning · Earth |
| Size | 1.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7553 · 354 · 265 · 265 · 265 · 110 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Earth. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 1.2 m high × 1.12 m long × 1.08 m wide; prefab scale 2.4.
- **Physics:** 907.2 kg, gravity ×1.6, poise 62, knockback resistance 0.22, death style `splat_dissolve`.
- **Navigation:** speed 6.74 m/s, turn 329°/s, stopping distance 0.94 m.
- **Attack count:** 5; **signature:** a storm-cloud interior that flashes with tiny lightning.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Storm Slime is a **wild ooze** encountered at B rank, around level 108. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a storm-cloud interior that flashes with tiny lightning. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Vharlen|Vharlen]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes B|loot_slime_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Slimes/Cinder Slime|Cinder Slime]]
- [[Monsters/Slimes/Elder Storm Slime|Elder Storm Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Moraveil\|Moraveil]] | 4 | A-, C+, A, B+ | 86–146 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 5 | B+, A, C+, A- | 86–146 | Day & Night |
| [[Regions/Vharlen\|Vharlen]] | 1 | A- | 132–132 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 1 | A- | 132–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00122` | Moraveil Storm Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | A- | 132 | 1.5 m | Day & Night | Like a typical Storm Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00123` | Moraveil Storm Slime Runt | [[Regions/Moraveil\|Moraveil]] | Runt | C+ | 86 | 0.84 m | Day & Night | Like a typical Storm Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00124` | Moraveil Storm Slime Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | A | 146 | 1.62 m | Day & Night | Like a typical Storm Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00125` | Strife Marches Storm Slime Albino | [[Regions/Strife Marches\|Strife Marches]] | Albino | B+ | 120 | 1.2 m | Day & Night | Like a typical Storm Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00126` | Vharlen Storm Slime Alpha | [[Regions/Vharlen\|Vharlen]] | Alpha | A- | 132 | 1.5 m | Day & Night | Like a typical Storm Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00127` | Moraveil Storm Slime Albino | [[Regions/Moraveil\|Moraveil]] | Albino | B+ | 120 | 1.2 m | Day & Night | Like a typical Storm Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00128` | Great Labyrinth (Floors 41-90) Storm Slime Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A- | 132 | 1.5 m | Day & Night | Like a typical Storm Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00129` | Strife Marches Storm Slime Elderborn | [[Regions/Strife Marches\|Strife Marches]] | Elderborn | A | 146 | 1.62 m | Day & Night | Like a typical Storm Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00130` | Strife Marches Storm Slime Runt | [[Regions/Strife Marches\|Strife Marches]] | Runt | C+ | 86 | 0.84 m | Day & Night | Like a typical Storm Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00131` | Strife Marches Storm Slime Alpha | [[Regions/Strife Marches\|Strife Marches]] | Alpha | A- | 132 | 1.5 m | Day & Night | Like a typical Storm Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_00132` | Strife Marches Storm Slime Scarred | [[Regions/Strife Marches\|Strife Marches]] | Scarred | B+ | 120 | 1.32 m | Day & Night | Like a typical Storm Slime, but covered in old battle scars, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1e1e40` · real-animal silhouette with one fantasy exaggeration
