---
type: monster
id: mon_dune_naga_priestess
family: "Serpentfolk"
rank: "B+"
tier: variant
tags: [monster, serpentfolk]
---
# Dune Naga Priestess

![[mon_dune_naga_priestess_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dune_naga_priestess_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 2.843 × 4 × 5.16 m · local file `Game/Assets/_Game/Art/Models/Monsters/Serpentfolk/mon_dune_naga_priestess.fbx`

> The Dune Naga Priestess is a large creature with a humanoid upper body on a long serpent tail, about 4 m long. Its scales are rough, scarred and spiked, colored in green, with ochre markings. Guild sketches always show a hood of jeweled scales and temple tattoos. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by pebbles that tremble and float near it. Adapted to desert lands, it has sun-bleached, sand-scoured coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Variant of | [[Monsters/Serpentfolk/Naga Priestess\|Naga Priestess]] (regional) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 4 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20861 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Zaruma\|Zaruma]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Wind. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 1.84 m high × 4 m long × 0.64 m wide; prefab scale 1.
- **Physics:** 287 kg, gravity ×1.43, poise 106, knockback resistance 0.67, death style `limp_chain`.
- **Navigation:** speed 3.28 m/s, turn 175°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a hood of jeweled scales and temple tattoos.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Coil\|Venom Coil]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dune Naga Priestess is a **menacing serpentfolk** encountered at B+ rank, around level 120. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hood of jeweled scales and temple tattoos. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Zaruma|Zaruma]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Serpentfolk B|loot_serpentfolk_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Serpent Scale\|Serpent Scale]] | 60% | 1–3 |
| [[Items/Temple Gold\|Temple Gold]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 4 | B+, A+, B, A- | 108–159 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 3 | A-, B+, B- | 96–132 | Day & Night |
| [[Regions/Zarvan\|Zarvan]] | 4 | B, A, A-, B- | 96–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05114` | Sunscar Dune Naga Priestess | [[Regions/Sunscar\|Sunscar]] | Adult | B+ | 120 | 4 m | Day & Night | A typical adult Dune Naga Priestess of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05115` | Zaruma Dune Naga Priestess Albino | [[Regions/Zaruma\|Zaruma]] | Albino | A- | 132 | 4 m | Day & Night | Like a typical Dune Naga Priestess, but a rare pale form with white skin or fur and red eyes. |
| `pop_05116` | Zaruma Dune Naga Priestess | [[Regions/Zaruma\|Zaruma]] | Adult | B+ | 120 | 4 m | Day & Night | A typical adult Dune Naga Priestess of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05117` | Zarvan Dune Naga Priestess Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | B | 108 | 3.4 m | Day & Night | Like a typical Dune Naga Priestess, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05118` | Zarvan Dune Naga Priestess Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | A | 146 | 5 m | Day & Night | Like a typical Dune Naga Priestess, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05119` | Sunscar Dune Naga Priestess Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A+ | 159 | 5.4 m | Day & Night | Like a typical Dune Naga Priestess, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05120` | Zarvan Dune Naga Priestess Albino | [[Regions/Zarvan\|Zarvan]] | Albino | A- | 132 | 4 m | Day & Night | Like a typical Dune Naga Priestess, but a rare pale form with white skin or fur and red eyes. |
| `pop_05121` | Zarvan Dune Naga Priestess Runt | [[Regions/Zarvan\|Zarvan]] | Runt | B- | 96 | 2.8 m | Day & Night | Like a typical Dune Naga Priestess, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05122` | Sunscar Dune Naga Priestess Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | B | 108 | 3.4 m | Day & Night | Like a typical Dune Naga Priestess, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_05123` | Sunscar Dune Naga Priestess Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | A- | 132 | 4.4 m | Day & Night | Like a typical Dune Naga Priestess, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05124` | Zaruma Dune Naga Priestess Runt | [[Regions/Zaruma\|Zaruma]] | Runt | B- | 96 | 2.8 m | Day & Night | Like a typical Dune Naga Priestess, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `rock_debris` · palette `#4a8044` `#31562e` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
