---
type: monster
id: mon_vine_lamia
family: "Serpentfolk"
rank: "C+"
tier: variant
tags: [monster, serpentfolk]
---
# Vine Lamia

![[mon_vine_lamia_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vine_lamia_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vine Lamia is a large creature with an elegant serpentfolk build, about 3.5 m long. Its scales are rough, scarred and spiked, colored in leaf greens over bark brown. Guild sketches always show a coiling tail and hypnotic golden eyes. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by drifting pollen and tiny blossoms. Adapted to jungle lands, it has vivid tropical markings.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Variant of | [[Monsters/Serpentfolk/Lamia\|Lamia]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 3.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12153 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 1.61 m high × 3.5 m long × 0.56 m wide; prefab scale 0.875.
- **Physics:** 147.9 kg, gravity ×1.3, poise 71, knockback resistance 0.49, death style `limp_chain`.
- **Navigation:** speed 4.08 m/s, turn 187°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** a coiling tail and hypnotic golden eyes.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Coil\|Venom Coil]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vine Lamia is a **menacing serpentfolk** encountered at C+ rank, around level 86. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a coiling tail and hypnotic golden eyes. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Serpentfolk C|loot_serpentfolk_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Serpent Scale\|Serpent Scale]] | 60% | 1–3 |
| [[Items/Temple Gold\|Temple Gold]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lumbaya\|Lumbaya]] | 6 | B, C-, B-, C+, B+ | 65–120 | Day & Night |
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 5 | C+, C, C-, B-, B | 65–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05092` | Lumbaya Vine Lamia Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | B | 108 | 4.38 m | Day & Night | Like a typical Vine Lamia, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_05093` | Xochitl Mire Vine Lamia | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | C+ | 86 | 3.5 m | Day & Night | A typical adult Vine Lamia of this region, with mud-slick, algae-streaked skin. |
| `pop_05094` | Xochitl Mire Vine Lamia Juvenile | [[Regions/Xochitl Mire\|Xochitl Mire]] | Juvenile | C | 76 | 2.98 m | Day & Night | Like a typical Vine Lamia, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_05095` | Xochitl Mire Vine Lamia Runt | [[Regions/Xochitl Mire\|Xochitl Mire]] | Runt | C- | 65 | 2.45 m | Day & Night | Like a typical Vine Lamia, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_05096` | Lumbaya Vine Lamia Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | C- | 65 | 2.45 m | Day & Night | Like a typical Vine Lamia, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_05097` | Xochitl Mire Vine Lamia Albino | [[Regions/Xochitl Mire\|Xochitl Mire]] | Albino | B- | 96 | 3.5 m | Day & Night | Like a typical Vine Lamia, but a rare pale form with white skin or fur and red eyes. |
| `pop_05098` | Lumbaya Vine Lamia Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | B- | 96 | 3.85 m | Day & Night | Like a typical Vine Lamia, but covered in old battle scars, with vivid tropical markings. |
| `pop_05099` | Lumbaya Vine Lamia | [[Regions/Lumbaya\|Lumbaya]] | Adult | C+ | 86 | 3.5 m | Day & Night | A typical adult Vine Lamia of this region, with vivid tropical markings. |
| `pop_05100` | Lumbaya Vine Lamia Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | B+ | 120 | 4.73 m | Day & Night | Like a typical Vine Lamia, but old and wise, with greying features and a cautious hunting style, with vivid tropical markings. |
| `pop_05101` | Xochitl Mire Vine Lamia Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | B | 108 | 4.38 m | Day & Night | Like a typical Vine Lamia, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_05102` | Lumbaya Vine Lamia Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | B- | 96 | 3.5 m | Day & Night | Like a typical Vine Lamia, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
