---
type: monster
id: mon_phantom_cube_slime
family: "Slimes"
rank: "D+"
tier: variant
tags: [monster, slimes]
---
# Phantom Cube Slime

> The Phantom Cube Slime is a small creature with a teardrop-shaped jelly body, about 0.8 m tall. Its gel is rough, scarred and spiked, colored in warm gold and pearl white. Guild sketches always show a perfectly cubic body with swallowed debris visible inside. It has burning slit pupils. A distinctive marking runs along its back. It circles its prey, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Cube Slime\|Cube Slime]] (spirit) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 0.8 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2499 · 187 · 140 · 140 · 140 · 110 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Dark. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 0.8 m high × 0.74 m long × 0.72 m wide; prefab scale 1.6.
- **Physics:** 255.4 kg, gravity ×1.44, poise 41, knockback resistance 0.16, death style `splat_dissolve`.
- **Navigation:** speed 5.35 m/s, turn 402°/s, stopping distance 0.76 m.
- **Attack count:** 5; **signature:** a perfectly cubic body with swallowed debris visible inside.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Phantom Cube Slime is a **menacing ooze** encountered at D+ rank, around level 56. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a perfectly cubic body with swallowed debris visible inside. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Moraveil|Moraveil]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | C+, D+, D | 48–86 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | C, D-, C-, D+ | 40–76 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 3 | C-, C+, C | 65–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02994` | Great Labyrinth (Floors 1-40) Phantom Cube Slime Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 1.08 m | Day & Night | Like a typical Phantom Cube Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_02995` | Aldmere Phantom Cube Slime Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | C | 76 | 1 m | Day & Night | Like a typical Phantom Cube Slime, but larger and scarred, and others of its kind follow it, with golden, grass-toned coloring. |
| `pop_02996` | Moraveil Phantom Cube Slime Albino | [[Regions/Moraveil\|Moraveil]] | Albino | C- | 65 | 0.8 m | Day & Night | Like a typical Phantom Cube Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_02997` | Great Labyrinth (Floors 1-40) Phantom Cube Slime | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D+ | 56 | 0.8 m | Day & Night | A typical adult Phantom Cube Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_02998` | Aldmere Phantom Cube Slime Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D- | 40 | 0.56 m | Day & Night | Like a typical Phantom Cube Slime, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_02999` | Aldmere Phantom Cube Slime Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C- | 65 | 0.88 m | Day & Night | Like a typical Phantom Cube Slime, but covered in old battle scars, with golden, grass-toned coloring. |
| `pop_03000` | Great Labyrinth (Floors 1-40) Phantom Cube Slime Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D | 48 | 0.68 m | Day & Night | Like a typical Phantom Cube Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03001` | Aldmere Phantom Cube Slime Albino | [[Regions/Aldmere\|Aldmere]] | Albino | C- | 65 | 0.8 m | Day & Night | Like a typical Phantom Cube Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_03002` | Moraveil Phantom Cube Slime Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | C+ | 86 | 1.08 m | Day & Night | Like a typical Phantom Cube Slime, but old and wise, with greying features and a cautious hunting style, with moss-green coloring that blends with the undergrowth. |
| `pop_03003` | Moraveil Phantom Cube Slime Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | C | 76 | 1 m | Day & Night | Like a typical Phantom Cube Slime, but larger and scarred, and others of its kind follow it, with moss-green coloring that blends with the undergrowth. |
| `pop_03004` | Aldmere Phantom Cube Slime | [[Regions/Aldmere\|Aldmere]] | Adult | D+ | 56 | 0.8 m | Day & Night | A typical adult Phantom Cube Slime of this region, with golden, grass-toned coloring. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
