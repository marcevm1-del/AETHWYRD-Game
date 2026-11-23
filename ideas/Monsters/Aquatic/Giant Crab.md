---
type: monster
id: mon_giant_crab
family: "Aquatic"
rank: "F"
tier: core
tags: [monster, aquatic]
---
# Giant Crab

![[mon_giant_crab_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_giant_crab_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.895 × 1.001 × 0.502 m · local file `Game/Assets/_Game/Art/Models/Monsters/Aquatic/mon_giant_crab.fbx`

> The Giant Crab is a small creature with a low, wide insectoid build, about 1 m long. Its scales and skin are weathered and natural, colored in teal, with sea-blue markings. Guild sketches always show one claw much bigger than the other. It has dark, wary eyes. It has no ornament at all: simple, readable shapes. It lopes in long strides, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 1 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 369 · 42 · 63 · 25 · 42 · 70 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Aldmere\|Aldmere]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.33 m high × 1 m long × 0.51 m wide; prefab scale 1.25.
- **Physics:** 46.2 kg, gravity ×1.4, poise 39, knockback resistance 0.25, death style `flip_legs_curl`.
- **Navigation:** speed 3.43 m/s, turn 500°/s, stopping distance 0.54 m.
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

Giant Crab is a **wild aquatic** encountered at F rank, around level 8. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

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

## Variants

- [[Monsters/Aquatic/Reef Crab|Reef Crab]]

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aldmere\|Aldmere]] | 7 | F+, F-, F, E-, E | 3–26 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01934` | Aldmere Giant Crab Albino | [[Regions/Aldmere\|Aldmere]] | Albino | F+ | 13 | 1 m | Day & Night | Like a typical Giant Crab, but a rare pale form with white skin or fur and red eyes. |
| `pop_01935` | Aldmere Giant Crab Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F- | 3 | 0.7 m | Day & Night | Like a typical Giant Crab, but smaller and scrappier than usual, with mud-slick, algae-streaked skin. |
| `pop_01936` | Aldmere Giant Crab Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 1.1 m | Day & Night | Like a typical Giant Crab, but covered in old battle scars, with mud-slick, algae-streaked skin. |
| `pop_01937` | Aldmere Giant Crab | [[Regions/Aldmere\|Aldmere]] | Adult | F | 8 | 1 m | Day & Night | A typical adult Giant Crab of this region, with mud-slick, algae-streaked skin. |
| `pop_01938` | Aldmere Giant Crab Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | E- | 19 | 1.25 m | Day & Night | Like a typical Giant Crab, but larger and scarred, and others of its kind follow it, with mud-slick, algae-streaked skin. |
| `pop_01939` | Aldmere Giant Crab Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.85 m | Day & Night | Like a typical Giant Crab, but young, with brighter colors and unworn features, with mud-slick, algae-streaked skin. |
| `pop_01940` | Aldmere Giant Crab Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | E | 26 | 1.35 m | Day & Night | Like a typical Giant Crab, but old and wise, with greying features and a cautious hunting style, with mud-slick, algae-streaked skin. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `wet_scale` · VFX `mist_droplets` · palette `#46918d` `#2f6460` `#4fa8e8` · real-animal silhouette with one fantasy exaggeration
