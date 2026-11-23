---
type: monster
id: mon_glowfin_angler
family: "Aquatic"
rank: "C"
tier: core
tags: [monster, aquatic]
---
# Glowfin Angler

![[mon_glowfin_angler_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_glowfin_angler_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 0.948 × 3 × 1.324 m · local file `Game/Assets/_Game/Art/Models/Monsters/Aquatic/mon_glowfin_angler.fbx`

> The Glowfin Angler is a large creature with a streamlined aquatic body, about 3 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in silver, with violet markings. Survivors describe a lure of light dangling over a mouth of glass teeth. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8733 · 393 · 283 · 283 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/aquatic\|aquatic]] · `anim_fish` |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Hollow Sea\|Hollow Sea]], [[Regions/Aldmere\|Aldmere]], [[Regions/True-Name Isles\|True-Name Isles]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/aquatic|aquatic]] (rigId); animation set `anim_fish`.
- **Dimensions:** 1.2 m high × 3 m long × 1.08 m wide; prefab scale 2.
- **Physics:** 621 kg, gravity ×1, poise 178, knockback resistance 0.39, death style `float_belly_up`.
- **Navigation:** speed 7.64 m/s, turn 231°/s, stopping distance 0.76 m.
- **Attack count:** 5; **signature:** a lure of light dangling over a mouth of glass teeth.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breach Lunge\|Breach Lunge]] | dash | 1.7 | 9 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thrash\|Thrash]] | aoe | 1.3 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Glowfin Angler is a **dread aquatic** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a lure of light dangling over a mouth of glass teeth. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lumbaya|Lumbaya]], [[Regions/Hollow Sea|Hollow Sea]], [[Regions/Aldmere|Aldmere]], [[Regions/True-Name Isles|True-Name Isles]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_fish`, animation set `anim_fish`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic C|loot_aquatic_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aquatic/Phantom Glowfin Angler|Phantom Glowfin Angler]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/True-Name Isles\|True-Name Isles]] | 3 | D+, C+, B | 56–108 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 3 | C-, B, C+ | 65–108 | Night |
| [[Regions/Aldmere\|Aldmere]] | 4 | C, D+, B-, C+ | 56–96 | Night |
| [[Regions/Hollow Sea\|Hollow Sea]] | 1 | B | 108–108 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01963` | True-Name Isles Glowfin Angler Runt | [[Regions/True-Name Isles\|True-Name Isles]] | Runt | D+ | 56 | 2.1 m | Night | Like a typical Glowfin Angler, but smaller and scrappier than usual, with salt-crusted, barnacle-flecked hide. |
| `pop_01964` | True-Name Isles Glowfin Angler Scarred | [[Regions/True-Name Isles\|True-Name Isles]] | Scarred | C+ | 86 | 3.3 m | Night | Like a typical Glowfin Angler, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01965` | Lumbaya Glowfin Angler Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | C- | 65 | 2.55 m | Night | Like a typical Glowfin Angler, but young, with brighter colors and unworn features, with salt-crusted, barnacle-flecked hide. |
| `pop_01966` | Aldmere Glowfin Angler | [[Regions/Aldmere\|Aldmere]] | Adult | C | 76 | 3 m | Night | A typical adult Glowfin Angler of this region, with mud-slick, algae-streaked skin. |
| `pop_01967` | Hollow Sea Glowfin Angler Elderborn | [[Regions/Hollow Sea\|Hollow Sea]] | Elderborn | B | 108 | 4.05 m | Night | Like a typical Glowfin Angler, but old and wise, with greying features and a cautious hunting style, with deep-water coloring and glowing lures. |
| `pop_01968` | Lumbaya Glowfin Angler Elderborn | [[Regions/Lumbaya\|Lumbaya]] | Elderborn | B | 108 | 4.05 m | Night | Like a typical Glowfin Angler, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01969` | Aldmere Glowfin Angler Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D+ | 56 | 2.1 m | Night | Like a typical Glowfin Angler, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_01970` | Lumbaya Glowfin Angler Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | C+ | 86 | 3.3 m | Night | Like a typical Glowfin Angler, but covered in old battle scars, with salt-crusted, barnacle-flecked hide. |
| `pop_01971` | True-Name Isles Glowfin Angler Elderborn | [[Regions/True-Name Isles\|True-Name Isles]] | Elderborn | B | 108 | 4.05 m | Night | Like a typical Glowfin Angler, but old and wise, with greying features and a cautious hunting style, with salt-crusted, barnacle-flecked hide. |
| `pop_01972` | Aldmere Glowfin Angler Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | B- | 96 | 3.75 m | Night | Like a typical Glowfin Angler, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_01973` | Aldmere Glowfin Angler Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | C+ | 86 | 3.3 m | Night | Like a typical Glowfin Angler, but covered in old battle scars, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `wet_scale` · VFX `shadow_wisps` · palette `#a2b0b9` `#697680` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
