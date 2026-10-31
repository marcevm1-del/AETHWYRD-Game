---
type: monster
id: mon_reef_crab
family: "Aquatic"
rank: "F+"
tier: variant
tags: [monster, aquatic]
---
# Reef Crab

![[mon_reef_crab_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_reef_crab_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,360 tris · 1.05 × 1 × 0.919 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Reef Crab is a small creature with a segmented six-limbed frame, about 1 m long. Its scales and skin are weathered and natural, colored in teal, with sea-blue markings. Guild sketches always show one claw much bigger than the other. It has amber predator eyes. It has no ornament at all: simple, readable shapes. It prowls, surrounded by fine mist and droplets that orbit it. Adapted to coast lands, it has salt-crusted, barnacle-flecked hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Giant Crab\|Giant Crab]] (regional) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 675 · 62 · 93 · 37 · 62 · 70 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Aldmere\|Aldmere]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.33 m high × 1 m long × 0.51 m wide; prefab scale 1.25.
- **Physics:** 46.2 kg, gravity ×1.4, poise 39, knockback resistance 0.25, death style `flip_legs_curl`.
- **Navigation:** speed 3.77 m/s, turn 500°/s, stopping distance 0.54 m.
- **Attack count:** 5; **signature:** one claw much bigger than the other.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tidal Drag\|Tidal Drag]] | grab | 1.3 | 11 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Tide Lash\|Tide Lash]] | magic | 1.5 | 10 s | Water | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Reef Crab is a **wild aquatic** encountered at F+ rank, around level 13. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Lightning**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** one claw much bigger than the other. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Aquatic F|loot_aquatic_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | E-, F+, E+, F-, F, E | 3–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04800` | Aldmere Reef Crab Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E- | 19 | 1.1 m | Day & Night | Like a typical Reef Crab, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_04801` | Aldmere Reef Crab | [[Regions/Aldmere\|Aldmere]] | Adult | F+ | 13 | 1 m | Day & Night | A typical adult Reef Crab of this region, with mud-slick, algae-streaked skin. |
| `pop_04802` | Aldmere Reef Crab Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E- | 19 | 1 m | Day & Night | Like a typical Reef Crab, but a rare pale form with white skin or fur and red eyes. |
| `pop_04803` | Aldmere Reef Crab Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E+ | 32 | 1.35 m | Day & Night | Like a typical Reef Crab, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |
| `pop_04804` | Aldmere Reef Crab Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.7 m | Day & Night | Like a typical Reef Crab, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_04805` | Aldmere Reef Crab Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F | 8 | 0.85 m | Day & Night | Like a typical Reef Crab, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_04806` | Aldmere Reef Crab Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E | 26 | 1.25 m | Day & Night | Like a typical Reef Crab, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `wet_scale` · VFX `mist_droplets` · palette `#4c9f8e` `#346d61` `#4fa8e8` · real-animal silhouette with one fantasy exaggeration
