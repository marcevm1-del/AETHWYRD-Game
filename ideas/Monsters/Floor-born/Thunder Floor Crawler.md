---
type: monster
id: mon_thunder_floor_crawler
family: "Floor-born"
rank: "F+"
tier: variant
tags: [monster, floor-born]
---
# Thunder Floor Crawler

> The Thunder Floor Crawler is a small creature with a low, springy quadruped build, about 0.8 m long. Its stone-like hide is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Survivors describe stone-colored skin that matches the walls it was born from. It has narrow glowing eyes. It has no ornament at all: simple, readable shapes. It charges without hesitation, surrounded by crackling arcs that jump across its body. This Lightning-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Floor Crawler\|Floor Crawler]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 0.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 382 · 62 · 50 · 43 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/quad_small\|quad_small]] · `anim_quad_small` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Earth. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_small|quad_small]] (rigId); animation set `anim_quad_small`.
- **Dimensions:** 0.54 m high × 0.8 m long × 0.11 m wide; prefab scale 1.6.
- **Physics:** 15.4 kg, gravity ×1.6, poise 25, knockback resistance 0.05, death style `ragdoll_tumble`.
- **Navigation:** speed 9.42 m/s, turn 604°/s, stopping distance 0.53 m.
- **Attack count:** 5; **signature:** stone-colored skin that matches the walls it was born from.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Bite\|Bite]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Charge\|Charge]] | dash | 1.3 | 5 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Leap\|Leap]] | dash | 1.2 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Wall Ambush\|Wall Ambush]] | dash | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Thunder Floor Crawler is a **menacing dungeon-born** encountered at F+ rank, around level 13. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** stone-colored skin that matches the walls it was born from. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_small`, animation set `anim_quad_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Floor-born F|loot_floorborn_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 7 | F+, E-, E, E+, F-, F | 3–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05422` | Great Labyrinth (Floors 1-40) Thunder Floor Crawler | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | F+ | 13 | 0.8 m | Day & Night | A typical adult Thunder Floor Crawler of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05423` | Great Labyrinth (Floors 1-40) Thunder Floor Crawler Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E- | 19 | 0.8 m | Day & Night | Like a typical Thunder Floor Crawler, but a rare pale form with white skin or fur and red eyes. |
| `pop_05424` | Great Labyrinth (Floors 1-40) Thunder Floor Crawler Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E- | 19 | 0.88 m | Day & Night | Like a typical Thunder Floor Crawler, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05425` | Great Labyrinth (Floors 1-40) Thunder Floor Crawler Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E | 26 | 1 m | Day & Night | Like a typical Thunder Floor Crawler, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05426` | Great Labyrinth (Floors 1-40) Thunder Floor Crawler Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E+ | 32 | 1.08 m | Day & Night | Like a typical Thunder Floor Crawler, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05427` | Great Labyrinth (Floors 1-40) Thunder Floor Crawler Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 0.56 m | Day & Night | Like a typical Thunder Floor Crawler, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05428` | Great Labyrinth (Floors 1-40) Thunder Floor Crawler Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | F | 8 | 0.68 m | Day & Night | Like a typical Thunder Floor Crawler, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `dungeon_stone` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
