---
type: monster
id: mon_bog_merfolk_warden
family: "Aquatic"
rank: "A+"
tier: variant
tags: [monster, aquatic]
---
# Bog Merfolk Warden

![[mon_bog_merfolk_warden_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_bog_merfolk_warden_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 1.369 × 2.2 × 2.393 m · local file `Game/Assets/_Game/Art/Models/Monsters/Aquatic/mon_bog_merfolk_warden.fbx`

> The Bog Merfolk Warden is a person-sized creature with an elegant serpentfolk build, about 2.2 m long. Its scales and skin are weathered and natural, colored in sea-blue, with sickly green markings. Survivors describe coral armor and a trident. It has alert animal eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It stalks low to the ground, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Merfolk Warden\|Merfolk Warden]] (regional) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 2 · Wild |
| Element · weakness | Poison · Light |
| Size | 2.2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25991 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/naga\|naga]] · `anim_naga` |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/True-Name Isles\|True-Name Isles]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/naga|naga]] (rigId); animation set `anim_naga`.
- **Dimensions:** 1.01 m high × 2.2 m long × 0.35 m wide; prefab scale 0.55.
- **Physics:** 36.7 kg, gravity ×1.3, poise 42, knockback resistance 0.55, death style `limp_chain`.
- **Navigation:** speed 2.72 m/s, turn 236°/s, stopping distance 0.51 m.
- **Attack count:** 5; **signature:** coral armor and a trident.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Coil Strike\|Coil Strike]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Constrict\|Constrict]] | grab | 1.8 | 12 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Hypnotic Gaze\|Hypnotic Gaze]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Bog Merfolk Warden is a **wild aquatic** encountered at A+ rank, around level 159. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** coral armor and a trident. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Goldmere Coast|Goldmere Coast]], [[Regions/Lumbaya|Lumbaya]], [[Regions/True-Name Isles|True-Name Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_naga`, animation set `anim_naga`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic A|loot_aquatic_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/True-Name Isles\|True-Name Isles]] | 4 | A, S, S- | 146–188 | Day & Night |
| [[Regions/Goldmere Coast\|Goldmere Coast]] | 5 | S+, A+, S, S- | 159–203 | Day & Night |
| [[Regions/Lumbaya\|Lumbaya]] | 2 | S, A | 146–188 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04884` | True-Name Isles Bog Merfolk Warden Juvenile | [[Regions/True-Name Isles\|True-Name Isles]] | Juvenile | A | 146 | 1.87 m | Day & Night | Like a typical Bog Merfolk Warden, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04885` | Goldmere Coast Bog Merfolk Warden Elderborn | [[Regions/Goldmere Coast\|Goldmere Coast]] | Elderborn | S+ | 203 | 2.97 m | Day & Night | Like a typical Bog Merfolk Warden, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_04886` | True-Name Isles Bog Merfolk Warden Alpha | [[Regions/True-Name Isles\|True-Name Isles]] | Alpha | S | 188 | 2.75 m | Day & Night | Like a typical Bog Merfolk Warden, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04887` | Goldmere Coast Bog Merfolk Warden | [[Regions/Goldmere Coast\|Goldmere Coast]] | Adult | A+ | 159 | 2.2 m | Day & Night | A typical adult Bog Merfolk Warden of this region, with salt-crusted, barnacle-flecked hide. |
| `pop_04888` | True-Name Isles Bog Merfolk Warden Scarred | [[Regions/True-Name Isles\|True-Name Isles]] | Scarred | S- | 173 | 2.42 m | Day & Night | Like a typical Bog Merfolk Warden, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_04889` | Goldmere Coast Bog Merfolk Warden Alpha | [[Regions/Goldmere Coast\|Goldmere Coast]] | Alpha | S | 188 | 2.75 m | Day & Night | Like a typical Bog Merfolk Warden, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04890` | Lumbaya Bog Merfolk Warden Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | S | 188 | 2.75 m | Day & Night | Like a typical Bog Merfolk Warden, but larger and scarred, and others of its kind follow it, with salt-crusted, barnacle-flecked hide. |
| `pop_04891` | Lumbaya Bog Merfolk Warden Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | A | 146 | 1.87 m | Day & Night | Like a typical Bog Merfolk Warden, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_04892` | Goldmere Coast Bog Merfolk Warden Albino | [[Regions/Goldmere Coast\|Goldmere Coast]] | Albino | S- | 173 | 2.2 m | Day & Night | Like a typical Bog Merfolk Warden, but a rare pale form with white skin or fur and red eyes. |
| `pop_04893` | True-Name Isles Bog Merfolk Warden Albino | [[Regions/True-Name Isles\|True-Name Isles]] | Albino | S- | 173 | 2.2 m | Day & Night | Like a typical Bog Merfolk Warden, but a rare pale form with white skin or fur and red eyes. |
| `pop_04894` | Goldmere Coast Bog Merfolk Warden Scarred | [[Regions/Goldmere Coast\|Goldmere Coast]] | Scarred | S- | 173 | 2.42 m | Day & Night | Like a typical Bog Merfolk Warden, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `wet_scale` · VFX `toxic_fog` · palette `#387891` `#265165` `#b8e986` · real-animal silhouette with one fantasy exaggeration
