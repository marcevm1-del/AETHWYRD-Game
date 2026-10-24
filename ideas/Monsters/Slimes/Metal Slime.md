---
type: monster
id: mon_metal_slime
family: "Slimes"
rank: "D"
tier: core
tags: [monster, slimes]
---
# Metal Slime

![[mon_metal_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_metal_slime_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Metal Slime is a tiny creature with a dome-shaped gelatinous body, about 0.3 m tall. Its gel is smooth and clean, colored in ochre, clay and mossy stone. Look for mirror-chrome skin that reflects the world around it. It has big round glossy eyes. A distinctive marking runs along its back. It hops in little bursts, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | D · 48 (40–56) |
| Menace | 1 · Charming |
| Element · weakness | Earth · Wind |
| Size | 0.3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1539 · 162 · 121 · 121 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.3 m high × 0.28 m long × 0.27 m wide; prefab scale 0.6.
- **Physics:** 18.4 kg, gravity ×1.76, poise 25, knockback resistance 0.31, death style `splat_dissolve`.
- **Navigation:** speed 2.46 m/s, turn 657°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** mirror-chrome skin that reflects the world around it.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Metal Slime is a **charming ooze** encountered at D rank, around level 48. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** mirror-chrome skin that reflects the world around it. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Moraveil|Moraveil]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes D|loot_slime_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Gilded Slime|Gilded Slime]]
- [[Monsters/Slimes/Vesper-Touched Metal Slime|Vesper-Touched Metal Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 3 | D+, D- | 40–56 | Day |
| [[Regions/Moraveil\|Moraveil]] | 4 | D+, D, E+, C- | 32–65 | Day |
| [[Regions/Umbravel\|Umbravel]] | 2 | C-, C | 65–76 | Day |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C-, C | 65–76 | Day |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00056` | Aldmere Metal Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D+ | 56 | 0.3 m | Day | Like a typical Metal Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00057` | Aldmere Metal Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 0.33 m | Day | Like a typical Metal Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00058` | Moraveil Metal Slime Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 0.33 m | Day | Like a typical Metal Slime, but covered in old battle scars, with moss-green coloring that blends with the undergrowth. |
| `pop_00059` | Moraveil Metal Slime | [[Regions/Moraveil\|Moraveil]] | Adult | D | 48 | 0.3 m | Day | A typical adult Metal Slime of this region, with moss-green coloring that blends with the undergrowth. |
| `pop_00060` | Aldmere Metal Slime Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D- | 40 | 0.26 m | Day | Like a typical Metal Slime, but young, with brighter colors and unworn features, with golden, grass-toned coloring. |
| `pop_00061` | Umbravel Metal Slime Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | C- | 65 | 0.38 m | Day | Like a typical Metal Slime, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_00062` | Moraveil Metal Slime Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 0.21 m | Day | Like a typical Metal Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00063` | Umbravel Metal Slime Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C | 76 | 0.41 m | Day | Like a typical Metal Slime, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_00064` | Great Labyrinth (Floors 1-40) Metal Slime Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C- | 65 | 0.38 m | Day | Like a typical Metal Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00065` | Moraveil Metal Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C- | 65 | 0.38 m | Day | Like a typical Metal Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00066` | Great Labyrinth (Floors 1-40) Metal Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C | 76 | 0.41 m | Day | Like a typical Metal Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · circle-based, soft silhouette
