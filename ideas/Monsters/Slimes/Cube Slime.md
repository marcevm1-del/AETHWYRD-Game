---
type: monster
id: mon_cube_slime
family: "Slimes"
rank: "D"
tier: core
tags: [monster, slimes]
---
# Cube Slime

![[mon_cube_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cube_slime_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.9 × 0.864 × 0.8 m · local file `Game/Assets/_Game/Art/Models/Monsters/Slimes/mon_cube_slime.fbx`

> The Cube Slime is a small creature with a wobbling mound of translucent gel, about 0.8 m tall. Its gel is weathered and natural, colored in ochre, clay and mossy stone. Guild sketches always show a perfectly cubic body with swallowed debris visible inside. It has amber predator eyes. A distinctive marking runs along its back. It prowls, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.8 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1991 · 162 · 121 · 121 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil\|Moraveil]], [[Regions/Aldmere\|Aldmere]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Wind. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.8 m high × 0.74 m long × 0.72 m wide; prefab scale 1.6.
- **Physics:** 349.4 kg, gravity ×1.76, poise 41, knockback resistance 0.31, death style `splat_dissolve`.
- **Navigation:** speed 4.69 m/s, turn 402°/s, stopping distance 0.76 m.
- **Attack count:** 5; **signature:** a perfectly cubic body with swallowed debris visible inside.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cube Slime is a **wild ooze** encountered at D rank, around level 48. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a perfectly cubic body with swallowed debris visible inside. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil|Moraveil]], [[Regions/Aldmere|Aldmere]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes D|loot_slime_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Phantom Cube Slime|Phantom Cube Slime]]
- [[Monsters/Slimes/Glacier Cube Slime|Glacier Cube Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | D+, D- | 40–56 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 3 | D+, C-, E+ | 32–65 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 4 | E+, D-, C-, D+ | 32–65 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | D+, C | 56–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00089` | Great Labyrinth (Floors 1-40) Cube Slime Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D+ | 56 | 0.88 m | Day & Night | Like a typical Cube Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00090` | Moraveil Cube Slime Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D+ | 56 | 0.8 m | Day & Night | Like a typical Cube Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00091` | Moraveil Cube Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C- | 65 | 1 m | Day & Night | Like a typical Cube Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_00092` | Umbravel Cube Slime Runt | [[Regions/Umbravel\|Umbravel]] | Runt | E+ | 32 | 0.56 m | Day & Night | Like a typical Cube Slime, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_00093` | Umbravel Cube Slime Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D- | 40 | 0.68 m | Day & Night | Like a typical Cube Slime, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_00094` | Aldmere Cube Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D+ | 56 | 0.88 m | Day & Night | Like a typical Cube Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_00095` | Umbravel Cube Slime Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | C- | 65 | 1 m | Day & Night | Like a typical Cube Slime, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_00096` | Moraveil Cube Slime Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 0.56 m | Day & Night | Like a typical Cube Slime, but smaller and scrappier than usual, with moss-green coloring that blends with the undergrowth. |
| `pop_00097` | Aldmere Cube Slime Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | C | 76 | 1.08 m | Day & Night | Like a typical Cube Slime, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_00098` | Umbravel Cube Slime Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | D+ | 56 | 0.88 m | Day & Night | Like a typical Cube Slime, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_00099` | Great Labyrinth (Floors 1-40) Cube Slime Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D- | 40 | 0.68 m | Day & Night | Like a typical Cube Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
