---
type: monster
id: mon_blue_slime
family: "Slimes"
rank: "F-"
tier: core
tags: [monster, slimes]
---
# Blue Slime

![[mon_blue_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blue_slime_front/side/back.jpg`).*

> [!note] 3D model: hand-built Ring 0 model, or not exported yet.

> The Blue Slime is a tiny creature with a dome-shaped gelatinous body, about 0.4 m tall. Its gel is smooth and clean, colored in deep blues with a glassy shine. Survivors describe a teardrop body with a glossy highlight and two dot eyes. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | F- · 3 (1–4) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 57 · 18 · 13 · 13 · 13 · 110 |
| XP · gold | 25 · 10 |
| Ring | 0 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (override); animation set `anim_blob`.
- **Dimensions:** 0.4 m high × 0.37 m long × 0.36 m wide; prefab scale 0.8.
- **Physics:** 35.3 kg, gravity ×1.6, poise 22, knockback resistance 0.1, death style `splat_dissolve`.
- **Navigation:** speed 3.09 m/s, turn 569°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** [object Object].

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blue Slime is a **charming ooze** encountered at F- rank, around level 3. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a teardrop body with a glossy highlight and two dot eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes F|loot_slime_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Meadow Slime|Meadow Slime]]
- [[Monsters/Slimes/Night Slime|Night Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 6 | F, F-, E- | 3–19 | Day |
| [[Regions/Aldmere\|Aldmere]] | 5 | F-, F, F+ | 3–13 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00001` | Whisperwood Blue Slime Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F | 8 | 0.44 m | Day | Like a typical Blue Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00002` | Aldmere Blue Slime | [[Regions/Aldmere\|Aldmere]] | Adult | F- | 3 | 0.4 m | Day | A typical adult Blue Slime of this region, with golden, grass-toned coloring. |
| `pop_00003` | Whisperwood Blue Slime Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.34 m | Day | Like a typical Blue Slime, but young, with brighter colors and unworn features, with moss-green coloring that blends with the undergrowth. |
| `pop_00004` | Aldmere Blue Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F | 8 | 0.44 m | Day | Like a typical Blue Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00005` | Whisperwood Blue Slime Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | F | 8 | 0.4 m | Day | Like a typical Blue Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00006` | Whisperwood Blue Slime | [[Regions/Whisperwood\|Whisperwood]] | Adult | F- | 3 | 0.4 m | Day | A typical adult Blue Slime of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00007` | Aldmere Blue Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.34 m | Day | Like a typical Blue Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00008` | Whisperwood Blue Slime Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F- | 3 | 0.28 m | Day | Like a typical Blue Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00009` | Whisperwood Blue Slime Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E- | 19 | 0.54 m | Day | Like a typical Blue Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_00010` | Aldmere Blue Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.28 m | Day | Like a typical Blue Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_00011` | Aldmere Blue Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | F+ | 13 | 0.5 m | Day | Like a typical Blue Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |

## Contracts and story encounters

- [[Quests/Slime in the Well|Slime in the Well]] — rank F, in [[Regions/Aldmere|Aldmere]]
- [[Quests/The Last Contract of the Silver Ladle|The Last Contract of the Silver Ladle]] — rank E, in [[Regions/Whisperwood|Whisperwood]]
- [[Quests/Weekly Board/Slime Patrol|Slime Patrol]] — rank undefined, in [[Regions/Aldmere|Aldmere]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
