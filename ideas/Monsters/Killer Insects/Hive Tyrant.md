---
type: monster
id: mon_hive_tyrant
family: "Killer Insects"
rank: "A"
tier: core
tags: [monster, killer-insects]
---
# Hive Tyrant

![[mon_hive_tyrant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_hive_tyrant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,680 tris · 9.804 × 7 × 9.825 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Hive Tyrant is a huge creature with a bipedal winged body with wing-arms, about 7 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in lacquer-red, with sickly green markings. Survivors describe a winged queen-killer with a crown of stingers. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 7 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 33309 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/The Maw\|The Maw]], [[Regions/Moraveil\|Moraveil]], [[Regions/Cinderhole\|Cinderhole]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 3.5 m high × 7 m long × 10.68 m wide; prefab scale 1.167.
- **Physics:** 1577.8 kg, gravity ×1, poise 227, knockback resistance 0.95, death style `crash_slide`.
- **Navigation:** speed 6.2 m/s, turn 227°/s, stopping distance 0.96 m.
- **Attack count:** 5; **signature:** a winged queen-killer with a crown of stingers.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Venom Spit\|Venom Spit]] | magic | 1.5 | 10 s | Poison | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Hive Tyrant is a **dread insectoid** encountered at A rank, around level 146. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a winged queen-killer with a crown of stingers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Lumbaya|Lumbaya]], [[Regions/The Maw|The Maw]], [[Regions/Moraveil|Moraveil]], [[Regions/Cinderhole|Cinderhole]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects A|loot_killer_insect_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Vine Hive Tyrant|Vine Hive Tyrant]]
- [[Monsters/Killer Insects/Greater Hive Tyrant|Greater Hive Tyrant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/The Maw\|The Maw]] | 4 | S-, S, B+, A- | 120–188 | Night |
| [[Regions/Cinderhole\|Cinderhole]] | 2 | B+, A | 120–146 | Night |
| [[Regions/Moraveil\|Moraveil]] | 3 | S, B+, S- | 120–188 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 2 | B+, A- | 120–132 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00796` | The Maw Hive Tyrant Alpha | [[Regions/The Maw\|The Maw]] | Alpha | S- | 173 | 8.75 m | Night | Like a typical Hive Tyrant, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_00797` | The Maw Hive Tyrant Elderborn | [[Regions/The Maw\|The Maw]] | Elderborn | S | 188 | 9.45 m | Night | Like a typical Hive Tyrant, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_00798` | The Maw Hive Tyrant Runt | [[Regions/The Maw\|The Maw]] | Runt | B+ | 120 | 4.9 m | Night | Like a typical Hive Tyrant, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_00799` | Cinderhole Hive Tyrant Runt | [[Regions/Cinderhole\|Cinderhole]] | Runt | B+ | 120 | 4.9 m | Night | Like a typical Hive Tyrant, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00800` | The Maw Hive Tyrant Juvenile | [[Regions/The Maw\|The Maw]] | Juvenile | A- | 132 | 5.95 m | Night | Like a typical Hive Tyrant, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_00801` | Moraveil Hive Tyrant Elderborn | [[Regions/Moraveil\|Moraveil]] | Elderborn | S | 188 | 9.45 m | Night | Like a typical Hive Tyrant, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00802` | Cinderhole Hive Tyrant | [[Regions/Cinderhole\|Cinderhole]] | Adult | A | 146 | 7 m | Night | A typical adult Hive Tyrant of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00803` | Moraveil Hive Tyrant Runt | [[Regions/Moraveil\|Moraveil]] | Runt | B+ | 120 | 4.9 m | Night | Like a typical Hive Tyrant, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00804` | Great Labyrinth (Floors 41-90) Hive Tyrant Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | B+ | 120 | 4.9 m | Night | Like a typical Hive Tyrant, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00805` | Moraveil Hive Tyrant Alpha | [[Regions/Moraveil\|Moraveil]] | Alpha | S- | 173 | 8.75 m | Night | Like a typical Hive Tyrant, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00806` | Great Labyrinth (Floors 41-90) Hive Tyrant Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | A- | 132 | 5.95 m | Night | Like a typical Hive Tyrant, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#ac2c32` `#60292d` `#b8e986` · elongated, irregular silhouette; still-then-sudden timing
