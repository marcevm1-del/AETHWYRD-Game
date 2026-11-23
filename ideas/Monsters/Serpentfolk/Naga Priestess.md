---
type: monster
id: mon_naga_priestess
family: "Serpentfolk"
rank: "B"
tier: core
tags: [monster, serpentfolk]
---
# Naga Priestess

![[mon_naga_priestess_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_naga_priestess_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 2.843 × 4 × 5.16 m · local file `Game/Assets/_Game/Art/Models/Monsters/Serpentfolk/mon_naga_priestess.fbx`

> The Naga Priestess is a large creature with a coiling half-serpent frame, about 4 m long. Its scales are rough, scarred and spiked, colored in green, with violet markings. Look for a hood of jeweled scales and temple tattoos. It has narrow glowing eyes. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 4 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17827 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 1.84 m high × 4 m long × 0.64 m wide; prefab scale 1.
- **Physics:** 220.8 kg, gravity ×1.3, poise 96, knockback resistance 0.52, death style `limp_chain`.
- **Navigation:** speed 3.74 m/s, turn 175°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a hood of jeweled scales and temple tattoos.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Coil\|Venom Coil]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Naga Priestess is a **menacing serpentfolk** encountered at B rank, around level 108. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a hood of jeweled scales and temple tattoos. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Lumbaya|Lumbaya]], [[Regions/Strife Marches|Strife Marches]], [[Regions/Aurumdeep|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Serpentfolk B|loot_serpentfolk_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Serpent Scale\|Serpent Scale]] | 60% | 1–3 |
| [[Items/Temple Gold\|Temple Gold]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Serpentfolk/Dune Naga Priestess|Dune Naga Priestess]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 4 | C+, B, A, B+ | 86–146 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 4 | B+, B, A | 108–146 | Day & Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 1 | B+ | 120–120 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 1 | B- | 96–96 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 1 | B- | 96–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02263` | Sunscar Naga Priestess Runt | [[Regions/Sunscar\|Sunscar]] | Runt | C+ | 86 | 2.8 m | Day & Night | Like a typical Naga Priestess, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_02264` | Lumbaya Naga Priestess Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | B+ | 120 | 4.4 m | Day & Night | Like a typical Naga Priestess, but covered in old battle scars, with vivid tropical markings. |
| `pop_02265` | Aurumdeep Naga Priestess Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | B+ | 120 | 4.4 m | Day & Night | Like a typical Naga Priestess, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_02266` | Sunscar Naga Priestess | [[Regions/Sunscar\|Sunscar]] | Adult | B | 108 | 4 m | Day & Night | A typical adult Naga Priestess of this region, with sun-bleached, sand-scoured coloring. |
| `pop_02267` | Lumbaya Naga Priestess | [[Regions/Lumbaya\|Lumbaya]] | Adult | B | 108 | 4 m | Day & Night | A typical adult Naga Priestess of this region, with vivid tropical markings. |
| `pop_02268` | Sunscar Naga Priestess Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A | 146 | 5.4 m | Day & Night | Like a typical Naga Priestess, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_02269` | Lumbaya Naga Priestess Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | A | 146 | 5.4 m | Day & Night | Like a typical Naga Priestess, but old and wise, with greying features and a cautious hunting style, with vivid tropical markings. |
| `pop_02270` | Strife Marches Naga Priestess Juvenile | [[Regions/Strife Marches\|Strife Marches]] | Juvenile | B- | 96 | 3.4 m | Day & Night | Like a typical Naga Priestess, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_02271` | Lumbaya Naga Priestess Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | B+ | 120 | 4 m | Day & Night | Like a typical Naga Priestess, but a rare pale form with white skin or fur and red eyes. |
| `pop_02272` | Sunscar Naga Priestess Albino | [[Regions/Sunscar\|Sunscar]] | Albino | B+ | 120 | 4 m | Day & Night | Like a typical Naga Priestess, but a rare pale form with white skin or fur and red eyes. |
| `pop_02273` | Great Labyrinth (Floors 41-90) Naga Priestess Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B- | 96 | 3.4 m | Day & Night | Like a typical Naga Priestess, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `shadow_wisps` · palette `#508446` `#35592f` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
