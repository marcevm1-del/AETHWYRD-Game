---
type: monster
id: mon_merfolk_warden
family: "Aquatic"
rank: "A"
tier: core
tags: [monster, aquatic]
---
# Merfolk Warden

![[mon_merfolk_warden_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_merfolk_warden_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.369 × 2.2 × 2.393 m · local file `Game/Assets/_Game/Art/Models/Monsters/Aquatic/mon_merfolk_warden.fbx`

> The Merfolk Warden is a person-sized creature with a humanoid upper body on a long serpent tail, about 2.2 m long. Its scales and skin are weathered and natural, colored in sea-blue. Guild sketches always show coral armor and a trident. It has amber predator eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It prowls, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | A · 146 (132–159) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 2.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22880 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Whitewater Reach\|Whitewater Reach]], [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Stormreach\|Stormreach]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 1.01 m high × 2.2 m long × 0.35 m wide; prefab scale 0.55.
- **Physics:** 38.6 kg, gravity ×1.3, poise 43, knockback resistance 0.55, death style `limp_chain`.
- **Navigation:** speed 2.94 m/s, turn 236°/s, stopping distance 0.51 m.
- **Attack count:** 5; **signature:** coral armor and a trident.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Merfolk Warden is a **wild aquatic** encountered at A rank, around level 146. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** coral armor and a trident. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/True-Name Isles|True-Name Isles]], [[Regions/Whitewater Reach|Whitewater Reach]], [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/Lumbaya|Lumbaya]], [[Regions/Stormreach|Stormreach]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic A|loot_aquatic_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Aquatic/Bog Merfolk Warden|Bog Merfolk Warden]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Stormreach\|Stormreach]] | 4 | S, A-, S-, A+ | 132–188 | Day & Night |
| [[Regions/Whitewater Reach\|Whitewater Reach]] | 2 | A-, A+ | 132–159 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 2 | A+, A- | 132–159 | Day & Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 1 | S | 188–188 | Day & Night |
| [[Regions/True-Name Isles\|True-Name Isles]] | 2 | A, A- | 132–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02018` | Stormreach Merfolk Warden Elderborn | [[Regions/Stormreach\|Stormreach]] | Elderborn | S | 188 | 2.97 m | Day & Night | Like a typical Merfolk Warden, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02019` | Whitewater Reach Merfolk Warden Juvenile | [[Regions/Whitewater Reach\|Whitewater Reach]] | Juvenile | A- | 132 | 1.87 m | Day & Night | Like a typical Merfolk Warden, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02020` | Stormreach Merfolk Warden Juvenile | [[Regions/Stormreach\|Stormreach]] | Juvenile | A- | 132 | 1.87 m | Day & Night | Like a typical Merfolk Warden, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02021` | Lumbaya Merfolk Warden Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | A+ | 159 | 2.42 m | Day & Night | Like a typical Merfolk Warden, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02022` | Goldmere Coast Merfolk Warden Elderborn | [[Regions/Goldmere Coast\|Goldmere Coast]] | Elderborn | S | 188 | 2.97 m | Day & Night | Like a typical Merfolk Warden, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_02023` | Lumbaya Merfolk Warden Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | A- | 132 | 1.87 m | Day & Night | Like a typical Merfolk Warden, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02024` | Whitewater Reach Merfolk Warden Scarred | [[Regions/Whitewater Reach\|Whitewater Reach]] | Scarred | A+ | 159 | 2.42 m | Day & Night | Like a typical Merfolk Warden, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_02025` | True-Name Isles Merfolk Warden | [[Regions/True-Name Isles\|True-Name Isles]] | Adult | A | 146 | 2.2 m | Day & Night | A typical adult Merfolk Warden of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_02026` | True-Name Isles Merfolk Warden Juvenile | [[Regions/True-Name Isles\|True-Name Isles]] | Juvenile | A- | 132 | 1.87 m | Day & Night | Like a typical Merfolk Warden, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_02027` | Stormreach Merfolk Warden Alpha | [[Regions/Stormreach\|Stormreach]] | Alpha | S- | 173 | 2.75 m | Day & Night | Like a typical Merfolk Warden, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_02028` | Stormreach Merfolk Warden Albino | [[Regions/Stormreach\|Stormreach]] | Albino | A+ | 159 | 2.2 m | Day & Night | Like a typical Merfolk Warden, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `wet_scale` · VFX `mist_droplets` · palette `#4072a5` `#2b4c74` `#4fa8e8` · real-animal silhouette with one fantasy exaggeration
