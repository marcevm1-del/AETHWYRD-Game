---
type: monster
id: mon_lamia
family: "Serpentfolk"
rank: "C"
tier: core
tags: [monster, serpentfolk]
---
# Lamia

![[mon_lamia_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_lamia_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 2.487 × 3.5 × 4.515 m · local file `Game/Assets/_Game/Art/Models/Monsters/Serpentfolk/mon_lamia.fbx`

> The Lamia is a large creature with an elegant serpentfolk build, about 3.5 m long. Its scales are rough, scarred and spiked, colored in green. Survivors describe a coiling tail and hypnotic golden eyes. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 3.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10113 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 1.61 m high × 3.5 m long × 0.56 m wide; prefab scale 0.875.
- **Physics:** 147.9 kg, gravity ×1.3, poise 71, knockback resistance 0.49, death style `limp_chain`.
- **Navigation:** speed 3.96 m/s, turn 187°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** a coiling tail and hypnotic golden eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Coil\|Venom Coil]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Lamia is a **menacing serpentfolk** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a coiling tail and hypnotic golden eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Serpentfolk C|loot_serpentfolk_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Serpent Scale\|Serpent Scale]] | 60% | 1–3 |
| [[Items/Temple Gold\|Temple Gold]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Serpentfolk/Vine Lamia|Vine Lamia]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lumbaya\|Lumbaya]] | 4 | D+, C+, B- | 56–96 | Day & Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 3 | C+, B, C | 76–108 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | C+, B-, C-, D+ | 56–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02241` | Lumbaya Lamia Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | D+ | 56 | 2.45 m | Day & Night | Like a typical Lamia, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_02242` | Xochitl Mire Lamia Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | C+ | 86 | 3.5 m | Day & Night | Like a typical Lamia, but a rare pale form with white skin or fur and red eyes. |
| `pop_02243` | Aldmere Lamia Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 3.85 m | Day & Night | Like a typical Lamia, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_02244` | Aldmere Lamia Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 4.38 m | Day & Night | Like a typical Lamia, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_02245` | Lumbaya Lamia Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | C+ | 86 | 3.85 m | Day & Night | Like a typical Lamia, but covered in old battle scars, with vivid tropical markings. |
| `pop_02246` | Lumbaya Lamia Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | B- | 96 | 4.38 m | Day & Night | Like a typical Lamia, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_02247` | Xochitl Mire Lamia Elderborn | [[Regions/Xochitl Mire\|Xochitl Mire]] | Elderborn | B | 108 | 4.73 m | Day & Night | Like a typical Lamia, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_02248` | Aldmere Lamia Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C- | 65 | 2.98 m | Day & Night | Like a typical Lamia, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_02249` | Aldmere Lamia Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 2.45 m | Day & Night | Like a typical Lamia, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_02250` | Xochitl Mire Lamia | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | C | 76 | 3.5 m | Day & Night | A typical adult Lamia of this region, with mud-slick, algae-streaked skin. |
| `pop_02251` | Lumbaya Lamia Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | C+ | 86 | 3.5 m | Day & Night | Like a typical Lamia, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `toxic_fog` · palette `#5c8948` `#3c5c31` `#b8e986` · triangle-based silhouette, sharp asymmetric spikes
