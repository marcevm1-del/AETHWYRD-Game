---
type: monster
id: mon_ruin_hound
family: "Floor-born"
rank: "D+"
tier: variant
tags: [monster, floor-born]
---
# Ruin Hound

![[mon_ruin_hound_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ruin_hound_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,994 tris · 0.373 × 1.4 × 0.887 m · local file `Game/Assets/_Game/Art/Models/Monsters/Floor-born/mon_ruin_hound.fbx`

> The Ruin Hound is a person-sized creature with a long-legged predatory quadruped build, about 1.4 m long. Its stone-like hide is rough, scarred and spiked, colored in rusted iron, with violet markings. Look for a brick-patterned hide. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Labyrinth Hound\|Labyrinth Hound]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.4 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4714 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 0.91 m high × 1.4 m long × 0.22 m wide; prefab scale 0.35.
- **Physics:** 54.9 kg, gravity ×1.2, poise 54, knockback resistance 0.91, death style `heavy_fall_dust`.
- **Navigation:** speed 4.32 m/s, turn 270°/s, stopping distance 0.68 m.
- **Attack count:** 5; **signature:** a brick-patterned hide.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wall Ambush\|Wall Ambush]] | dash | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ruin Hound is a **menacing dungeon-born** encountered at D+ rank, around level 56. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a brick-patterned hide. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Floor-born D|loot_floorborn_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 7 | C-, D+, D, D-, C+, C | 40–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05436` | Great Labyrinth (Floors 1-40) Ruin Hound Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C- | 65 | 1.54 m | Day & Night | Like a typical Ruin Hound, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05437` | Great Labyrinth (Floors 1-40) Ruin Hound | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D+ | 56 | 1.4 m | Day & Night | A typical adult Ruin Hound of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05438` | Great Labyrinth (Floors 1-40) Ruin Hound Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C- | 65 | 1.4 m | Day & Night | Like a typical Ruin Hound, but a rare pale form with white skin or fur and red eyes. |
| `pop_05439` | Great Labyrinth (Floors 1-40) Ruin Hound Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D | 48 | 1.19 m | Day & Night | Like a typical Ruin Hound, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05440` | Great Labyrinth (Floors 1-40) Ruin Hound Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D- | 40 | 0.98 m | Day & Night | Like a typical Ruin Hound, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05441` | Great Labyrinth (Floors 1-40) Ruin Hound Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 1.89 m | Day & Night | Like a typical Ruin Hound, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05442` | Great Labyrinth (Floors 1-40) Ruin Hound Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C | 76 | 1.75 m | Day & Night | Like a typical Ruin Hound, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dungeon_stone` · VFX `shadow_wisps` · palette `#876d48` `#5a4831` `#9a86d8` · triangle-based silhouette, sharp asymmetric spikes
