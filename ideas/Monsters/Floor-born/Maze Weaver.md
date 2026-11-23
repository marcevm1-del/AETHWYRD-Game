---
type: monster
id: mon_maze_weaver
family: "Floor-born"
rank: "B"
tier: core
tags: [monster, floor-born]
---
# Maze Weaver

![[mon_maze_weaver_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_maze_weaver_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 3.383 × 2.999 × 1.696 m · local file `Game/Assets/_Game/Art/Models/Monsters/Floor-born/mon_maze_weaver.fbx`

> The Maze Weaver is a large creature with a squat, many-legged arachnid build, about 3 m long. Its stone-like hide is patchy and subtly wrong, as if assembled from memory, colored in dungeon stone, with violet markings. It rebuilds corridors behind you. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 3 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12524 · 442 · 354 · 309 · 354 · 135 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Aurumdeep\|Aurumdeep]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 0.84 m high × 3 m long × 2.05 m wide; prefab scale 3.
- **Physics:** 891 kg, gravity ×1.4, poise 272, knockback resistance 0.32, death style `flip_legs_curl`.
- **Navigation:** speed 9.27 m/s, turn 346°/s, stopping distance 1.15 m.
- **Attack count:** 5; **signature:** it rebuilds corridors behind you.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Fang Bite\|Fang Bite]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Web Shot\|Web Shot]] | ranged | 0.5 | 8 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ceiling Drop\|Ceiling Drop]] | dash | 1.7 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wall Ambush\|Wall Ambush]] | dash | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Maze Weaver is a **dread dungeon-born** encountered at B rank, around level 108. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** it rebuilds corridors behind you. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]], [[Regions/Aurumdeep|Aurumdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Floor-born B|loot_floorborn_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Floor-born/Elder Maze Weaver|Elder Maze Weaver]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Aurumdeep\|Aurumdeep]] | 4 | A-, B, C+, B+ | 86–132 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | C+, B-, B | 86–108 | Night |
| [[Regions/Umbravel\|Umbravel]] | 4 | C+, A-, B+, A | 86–146 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02607` | Aurumdeep Maze Weaver Alpha | [[Regions/Aurumdeep\|Aurumdeep]] | Alpha | A- | 132 | 3.75 m | Night | Like a typical Maze Weaver, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_02608` | Great Labyrinth (Floors 41-90) Maze Weaver Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C+ | 86 | 2.1 m | Night | Like a typical Maze Weaver, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_02609` | Umbravel Maze Weaver Runt | [[Regions/Umbravel\|Umbravel]] | Runt | C+ | 86 | 2.1 m | Night | Like a typical Maze Weaver, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_02610` | Great Labyrinth (Floors 41-90) Maze Weaver Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B- | 96 | 2.55 m | Night | Like a typical Maze Weaver, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_02611` | Umbravel Maze Weaver Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | A- | 132 | 3.75 m | Night | Like a typical Maze Weaver, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_02612` | Aurumdeep Maze Weaver | [[Regions/Aurumdeep\|Aurumdeep]] | Adult | B | 108 | 3 m | Night | A typical adult Maze Weaver of this region, with bioluminescent spots along its body. |
| `pop_02613` | Umbravel Maze Weaver Albino | [[Regions/Umbravel\|Umbravel]] | Albino | B+ | 120 | 3 m | Night | Like a typical Maze Weaver, but a rare pale form with white skin or fur and red eyes. |
| `pop_02614` | Umbravel Maze Weaver Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | A | 146 | 4.05 m | Night | Like a typical Maze Weaver, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_02615` | Aurumdeep Maze Weaver Runt | [[Regions/Aurumdeep\|Aurumdeep]] | Runt | C+ | 86 | 2.1 m | Night | Like a typical Maze Weaver, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_02616` | Aurumdeep Maze Weaver Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | B+ | 120 | 3.3 m | Night | Like a typical Maze Weaver, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_02617` | Great Labyrinth (Floors 41-90) Maze Weaver | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | B | 108 | 3 m | Night | A typical adult Maze Weaver of this region, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `dungeon_stone` · VFX `shadow_wisps` · palette `#787e87` `#50555c` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
