---
type: monster
id: mon_green_slime
family: "Slimes"
rank: "F"
tier: core
tags: [monster, slimes]
---
# Green Slime

![[mon_green_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_green_slime_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 6,000 tris · 0.455 × 0.438 × 0.4 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_green_slime.fbx`

> The Green Slime is a tiny creature with a wobbling mound of translucent gel, about 0.4 m tall. Its gel is smooth and clean, colored in leaf greens over bark brown. Its most striking feature is fallen leaves suspended inside its jelly. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It waddles, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Nature · Fire |
| Size | 0.4 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 142 · 34 · 25 · 25 · 25 · 110 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (override); animation set `anim_blob`.
- **Dimensions:** 0.4 m high × 0.37 m long × 0.36 m wide; prefab scale 0.8.
- **Physics:** 33.6 kg, gravity ×1.6, poise 22, knockback resistance 0.1, death style `splat_dissolve`.
- **Navigation:** speed 3.24 m/s, turn 569°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Green Slime is a **charming ooze** encountered at F rank, around level 8. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** fallen leaves suspended inside its jelly. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes F|loot_slime_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Vesper-Touched Green Slime|Vesper-Touched Green Slime]]
- [[Monsters/Slimes/Gale Slime|Gale Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 6 | F+, E, F, E-, F- | 3–26 | Day |
| [[Regions/Aldmere\|Aldmere]] | 5 | E, F+, F, F-, E- | 3–26 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00012` | Whisperwood Green Slime Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 0.44 m | Day | Like a typical Green Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00013` | Aldmere Green Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 0.54 m | Day | Like a typical Green Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00014` | Aldmere Green Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.44 m | Day | Like a typical Green Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00015` | Whisperwood Green Slime Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 0.54 m | Day | Like a typical Green Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00016` | Aldmere Green Slime | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 0.4 m | Day | A typical adult Green Slime of this region, with golden, grass-toned coloring. |
| `pop_00017` | Aldmere Green Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.28 m | Day | Like a typical Green Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00018` | Whisperwood Green Slime | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.4 m | Day | A typical adult Green Slime of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00019` | Whisperwood Green Slime Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F+ | 13 | 0.4 m | Day | Like a typical Green Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00020` | Whisperwood Green Slime Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 0.5 m | Day | Like a typical Green Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00021` | Whisperwood Green Slime Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.28 m | Day | Like a typical Green Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00022` | Aldmere Green Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 0.5 m | Day | Like a typical Green Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Contracts and story encounters

- [[Quests/Weekly Board/Slime Patrol|Slime Patrol]] — rank undefined, in [[Regions/Aldmere|Aldmere]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#402824` · circle-based, soft silhouette
