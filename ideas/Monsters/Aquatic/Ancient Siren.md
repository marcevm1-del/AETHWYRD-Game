---
type: monster
id: mon_ancient_siren
family: "Aquatic"
rank: "B+"
tier: variant
tags: [monster, aquatic]
---
# Ancient Siren

![[mon_ancient_siren_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ancient_siren_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (6,104 tris · 1.37 × 3 × 2.509 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ancient Siren is a large creature with an elegant serpentfolk build, about 3 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in silver, with sea-blue markings. Look for a fish tail and a voice that sounds like home. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It freezes whenever it is looked at, surrounded by fine mist and droplets that orbit it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Siren\|Siren]] (ancient) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 3 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18966 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Whitewater Reach\|Whitewater Reach]], [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 1.38 m high × 3 m long × 0.48 m wide; prefab scale 0.75.
- **Physics:** 97.8 kg, gravity ×1.3, poise 62, knockback resistance 0.52, death style `limp_chain`.
- **Navigation:** speed 3.43 m/s, turn 202°/s, stopping distance 0.55 m.
- **Attack count:** 5; **signature:** a fish tail and a voice that sounds like home.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ancient Siren is a **dread aquatic** encountered at B+ rank, around level 120. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a fish tail and a voice that sounds like home. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/True-Name Isles|True-Name Isles]], [[Regions/Whitewater Reach|Whitewater Reach]], [[Regions/Goldmere Coast|Goldmere Coast]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic B|loot_aquatic_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/True-Name Isles\|True-Name Isles]] | 4 | B, B+, A-, A+ | 108–159 | Night |
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 5 | B, B+, A, A-, A+ | 108–159 | Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 2 | B+, A- | 120–132 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04851` | True-Name Isles Ancient Siren Juvenile | [[Regions/True-Name Isles\|True-Name Isles]] | Juvenile | B | 108 | 2.55 m | Night | Like a typical Ancient Siren, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04852` | Whitewater Reach Ancient Siren Juvenile | [[Regions/Whitewater Reach\|Whitewater Reach]] | Juvenile | B | 108 | 2.55 m | Night | Like a typical Ancient Siren, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04853` | True-Name Isles Ancient Siren | [[Regions/True-Name Isles\|True-Name Isles]] | Adult | B+ | 120 | 3 m | Night | A typical adult Ancient Siren of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04854` | Goldmere Coast Ancient Siren | [[Regions/Goldmere Coast\|Goldmere Coast]] | Adult | B+ | 120 | 3 m | Night | A typical adult Ancient Siren of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04855` | Whitewater Reach Ancient Siren | [[Regions/Whitewater Reach\|Whitewater Reach]] | Adult | B+ | 120 | 3 m | Night | A typical adult Ancient Siren of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04856` | True-Name Isles Ancient Siren Albino | [[Regions/True-Name Isles\|True-Name Isles]] | Albino | A- | 132 | 3 m | Night | Like a typical Ancient Siren, but a rare pale form with white skin or fur and red eyes. |
| `pop_04857` | Whitewater Reach Ancient Siren Alpha | [[Regions/Whitewater Reach\|Whitewater Reach]] | Alpha | A | 146 | 3.75 m | Night | Like a typical Ancient Siren, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04858` | Goldmere Coast Ancient Siren Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | A- | 132 | 3.3 m | Night | Like a typical Ancient Siren, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04859` | True-Name Isles Ancient Siren Elderborn | [[Regions/True-Name Isles\|True-Name Isles]] | Elderborn | A+ | 159 | 4.05 m | Night | Like a typical Ancient Siren, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04860` | Whitewater Reach Ancient Siren Albino | [[Regions/Whitewater Reach\|Whitewater Reach]] | Albino | A- | 132 | 3 m | Night | Like a typical Ancient Siren, but a rare pale form with white skin or fur and red eyes. |
| `pop_04861` | Whitewater Reach Ancient Siren Elderborn | [[Regions/Whitewater Reach\|Whitewater Reach]] | Elderborn | A+ | 159 | 4.05 m | Night | Like a typical Ancient Siren, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `wet_scale` · VFX `mist_droplets` · palette `#98a4ad` `#636d78` `#4fa8e8` · elongated, irregular silhouette; still-then-sudden timing
