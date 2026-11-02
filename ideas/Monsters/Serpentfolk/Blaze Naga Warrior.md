---
type: monster
id: mon_blaze_naga_warrior
family: "Serpentfolk"
rank: "B-"
tier: variant
tags: [monster, serpentfolk]
---
# Blaze Naga Warrior

![[mon_blaze_naga_warrior_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_blaze_naga_warrior_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (5,514 tris · 2.023 × 4 × 2.625 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Blaze Naga Warrior is a large creature with a humanoid upper body on a long serpent tail, about 4 m long. Its scales are rough, scarred and spiked, colored in violet, with ember-orange markings. Look for four arms holding four blades. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Variant of | [[Monsters/Serpentfolk/Naga Warrior\|Naga Warrior]] (elemental) |
| Rank · level | B- · 96 (86–108) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 4 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 14957 · 473 · 394 · 315 · 355 · 100 |
| XP · gold | 4462 · 897 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Zaruma\|Zaruma]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 1.84 m high × 4 m long × 0.64 m wide; prefab scale 1.
- **Physics:** 220.8 kg, gravity ×1.3, poise 96, knockback resistance 0.52, death style `limp_chain`.
- **Navigation:** speed 4.58 m/s, turn 175°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** four arms holding four blades.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Venom Coil\|Venom Coil]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Blaze Naga Warrior is a **menacing serpentfolk** encountered at B- rank, around level 96. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** four arms holding four blades. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Zaruma|Zaruma]], [[Regions/Lumbaya|Lumbaya]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Sunscar\|Sunscar]] | 3 | A-, B-, B+ | 96–132 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 4 | B+, C, B, B- | 76–120 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 4 | B+, C+, C, B- | 76–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05103` | Sunscar Blaze Naga Warrior Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A- | 132 | 5.4 m | Day & Night | Like a typical Blaze Naga Warrior, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_05104` | Zaruma Blaze Naga Warrior Alpha | [[Regions/Zaruma\|Zaruma]] | Alpha | B+ | 120 | 5 m | Day & Night | Like a typical Blaze Naga Warrior, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_05105` | Zaruma Blaze Naga Warrior Runt | [[Regions/Zaruma\|Zaruma]] | Runt | C | 76 | 2.8 m | Day & Night | Like a typical Blaze Naga Warrior, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_05106` | Lumbaya Blaze Naga Warrior Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | B+ | 120 | 5 m | Day & Night | Like a typical Blaze Naga Warrior, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_05107` | Lumbaya Blaze Naga Warrior Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | C+ | 86 | 3.4 m | Day & Night | Like a typical Blaze Naga Warrior, but young, with brighter colors and unworn features, with vivid tropical markings. |
| `pop_05108` | Zaruma Blaze Naga Warrior Scarred | [[Regions/Zaruma\|Zaruma]] | Scarred | B | 108 | 4.4 m | Day & Night | Like a typical Blaze Naga Warrior, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_05109` | Lumbaya Blaze Naga Warrior Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | C | 76 | 2.8 m | Day & Night | Like a typical Blaze Naga Warrior, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_05110` | Sunscar Blaze Naga Warrior | [[Regions/Sunscar\|Sunscar]] | Adult | B- | 96 | 4 m | Day & Night | A typical adult Blaze Naga Warrior of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05111` | Zaruma Blaze Naga Warrior | [[Regions/Zaruma\|Zaruma]] | Adult | B- | 96 | 4 m | Day & Night | A typical adult Blaze Naga Warrior of this region, with sun-bleached, sand-scoured coloring. |
| `pop_05112` | Lumbaya Blaze Naga Warrior | [[Regions/Lumbaya\|Lumbaya]] | Adult | B- | 96 | 4 m | Day & Night | A typical adult Blaze Naga Warrior of this region, with vivid tropical markings. |
| `pop_05113` | Sunscar Blaze Naga Warrior Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | B+ | 120 | 5 m | Day & Night | Like a typical Blaze Naga Warrior, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `embers_heat_haze` · palette `#9974a8` `#644d74` `#ff7a3d` · triangle-based silhouette, sharp asymmetric spikes
