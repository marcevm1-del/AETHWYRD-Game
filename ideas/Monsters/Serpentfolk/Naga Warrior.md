---
type: monster
id: mon_naga_warrior
family: "Serpentfolk"
rank: "C+"
tier: core
tags: [monster, serpentfolk]
---
# Naga Warrior

![[mon_naga_warrior_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_naga_warrior_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (5,570 tris · 2.023 × 4 × 2.554 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Naga Warrior is a large creature with a coiling half-serpent frame, about 4 m long. Its scales are rough, scarred and spiked, colored in violet, with sea-blue markings. Look for four arms holding four blades. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 4 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12698 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 1.84 m high × 4 m long × 0.64 m wide; prefab scale 1.
- **Physics:** 231.8 kg, gravity ×1.3, poise 88, knockback resistance 0.49, death style `limp_chain`.
- **Navigation:** speed 4.36 m/s, turn 175°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** four arms holding four blades.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Coil\|Venom Coil]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Naga Warrior is a **menacing serpentfolk** encountered at C+ rank, around level 86. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** four arms holding four blades. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]], [[Regions/Xochitl Mire|Xochitl Mire]], [[Regions/Lumbaya|Lumbaya]], [[Regions/Greymoor|Greymoor]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Serpentfolk C|loot_serpentfolk_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Serpent Scale\|Serpent Scale]] | 60% | 1–3 |
| [[Items/Temple Gold\|Temple Gold]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Serpentfolk/Blaze Naga Warrior|Blaze Naga Warrior]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Xochitl Mire\|Xochitl Mire]] | 3 | B, C+, B+ | 86–120 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 3 | B, C+, C | 76–108 | Day & Night |
| [[Regions/Greymoor\|Greymoor]] | 3 | C, B-, B+ | 76–120 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | C, B- | 76–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02252` | Xochitl Mire Naga Warrior Alpha | [[Regions/Xochitl Mire\|Xochitl Mire]] | Alpha | B | 108 | 5 m | Day & Night | Like a typical Naga Warrior, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_02253` | Lumbaya Naga Warrior Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | B | 108 | 5 m | Day & Night | Like a typical Naga Warrior, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_02254` | Xochitl Mire Naga Warrior | [[Regions/Xochitl Mire\|Xochitl Mire]] | Adult | C+ | 86 | 4 m | Day & Night | A typical adult Naga Warrior of this region, with mud-slick, algae-streaked skin. |
| `pop_02255` | Greymoor Naga Warrior Juvenile | [[Regions/Greymoor\|Greymoor]] | Juvenile | C | 76 | 3.4 m | Day & Night | Like a typical Naga Warrior, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_02256` | Lumbaya Naga Warrior | [[Regions/Lumbaya\|Lumbaya]] | Adult | C+ | 86 | 4 m | Day & Night | A typical adult Naga Warrior of this region, with vivid tropical markings. |
| `pop_02257` | Xochitl Mire Naga Warrior Elderborn | [[Regions/Xochitl Mire\|Xochitl Mire]] | Elderborn | B+ | 120 | 5.4 m | Day & Night | Like a typical Naga Warrior, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_02258` | Lumbaya Naga Warrior Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | C | 76 | 3.4 m | Day & Night | Like a typical Naga Warrior, but young, with brighter colors and unworn features, with vivid tropical markings. |
| `pop_02259` | Aldmere Naga Warrior Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | C | 76 | 3.4 m | Day & Night | Like a typical Naga Warrior, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_02260` | Aldmere Naga Warrior Albino | [[Regions/Aldmere\|Aldmere]] | Albino | B- | 96 | 4 m | Day & Night | Like a typical Naga Warrior, but a rare pale form with white skin or fur and red eyes. |
| `pop_02261` | Greymoor Naga Warrior Scarred | [[Regions/Greymoor\|Greymoor]] | Scarred | B- | 96 | 4.4 m | Day & Night | Like a typical Naga Warrior, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_02262` | Greymoor Naga Warrior Elderborn | [[Regions/Greymoor\|Greymoor]] | Elderborn | B+ | 120 | 5.4 m | Day & Night | Like a typical Naga Warrior, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `mist_droplets` · palette `#8d6694` `#5d4366` `#4fa8e8` · triangle-based silhouette, sharp asymmetric spikes
