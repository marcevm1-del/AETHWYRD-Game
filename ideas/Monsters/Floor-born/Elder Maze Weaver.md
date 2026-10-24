---
type: monster
id: mon_elder_maze_weaver
family: "Floor-born"
rank: "A"
tier: variant
tags: [monster, floor-born]
---
# Elder Maze Weaver

![[mon_elder_maze_weaver_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elder_maze_weaver_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (4,154 tris · 3.895 × 4.8 × 5.957 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elder Maze Weaver is a large creature with a squat, many-legged arachnid build, about 4.8 m long. Its stone-like hide is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. It rebuilds corridors behind you. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Maze Weaver\|Maze Weaver]] (elder) |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 4.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22910 · 594 · 475 · 416 · 475 · 135 |
| XP · gold | 8719 · 1611 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/arachnid\|arachnid]] · `anim_octopod` |
| Habitats | [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/The Maw\|The Maw]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/arachnid|arachnid]] (rigId); animation set `anim_octopod`.
- **Dimensions:** 1.34 m high × 4.8 m long × 3.28 m wide; prefab scale 4.8.
- **Physics:** 3649.5 kg, gravity ×1.4, poise 617, knockback resistance 0.35, death style `flip_legs_curl`.
- **Navigation:** speed 12.28 m/s, turn 274°/s, stopping distance 1.6 m.
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

Elder Maze Weaver is a **dread dungeon-born** encountered at A rank, around level 146. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** it rebuilds corridors behind you. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aurumdeep|Aurumdeep]], [[Regions/The Maw|The Maw]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_octopod`, animation set `anim_octopod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Floor-born A|loot_floorborn_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/The Maw\|The Maw]] | 4 | A+, S-, B+, A | 120–173 | Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 7 | A+, S, B+, A, A-, S- | 120–188 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05454` | The Maw Elder Maze Weaver Scarred | [[Regions/The Maw\|The Maw]] | Scarred | A+ | 159 | 5.28 m | Night | Like a typical Elder Maze Weaver, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_05455` | The Maw Elder Maze Weaver Alpha | [[Regions/The Maw\|The Maw]] | Alpha | S- | 173 | 6 m | Night | Like a typical Elder Maze Weaver, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_05456` | Aurumdeep Elder Maze Weaver Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | A+ | 159 | 5.28 m | Night | Like a typical Elder Maze Weaver, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_05457` | Aurumdeep Elder Maze Weaver Elderborn | [[Regions/Aurumdeep\|Aurumdeep]] | Elderborn | S | 188 | 6.48 m | Night | Like a typical Elder Maze Weaver, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_05458` | Aurumdeep Elder Maze Weaver Runt | [[Regions/Aurumdeep\|Aurumdeep]] | Runt | B+ | 120 | 3.36 m | Night | Like a typical Elder Maze Weaver, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_05459` | The Maw Elder Maze Weaver Runt | [[Regions/The Maw\|The Maw]] | Runt | B+ | 120 | 3.36 m | Night | Like a typical Elder Maze Weaver, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_05460` | Aurumdeep Elder Maze Weaver Albino | [[Regions/Aurumdeep\|Aurumdeep]] | Albino | A+ | 159 | 4.8 m | Night | Like a typical Elder Maze Weaver, but a rare pale form with white skin or fur and red eyes. |
| `pop_05461` | Aurumdeep Elder Maze Weaver | [[Regions/Aurumdeep\|Aurumdeep]] | Adult | A | 146 | 4.8 m | Night | A typical adult Elder Maze Weaver of this region, with bioluminescent spots along its body. |
| `pop_05462` | Aurumdeep Elder Maze Weaver Juvenile | [[Regions/Aurumdeep\|Aurumdeep]] | Juvenile | A- | 132 | 4.08 m | Night | Like a typical Elder Maze Weaver, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_05463` | Aurumdeep Elder Maze Weaver Alpha | [[Regions/Aurumdeep\|Aurumdeep]] | Alpha | S- | 173 | 6 m | Night | Like a typical Elder Maze Weaver, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_05464` | The Maw Elder Maze Weaver | [[Regions/The Maw\|The Maw]] | Adult | A | 146 | 4.8 m | Night | A typical adult Elder Maze Weaver of this region, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `dungeon_stone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
