---
type: monster
id: mon_greater_hive_tyrant
family: "Killer Insects"
rank: "S"
tier: variant
tags: [monster, killer-insects]
---
# Greater Hive Tyrant

![[mon_greater_hive_tyrant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_hive_tyrant_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,224 tris · 15.686 × 11.2 × 15.72 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Hive Tyrant is a huge creature with a sleek flying build, about 11.2 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Guild sketches always show a winged queen-killer with a crown of stingers. It has pale, pupil-less eyes. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Hive Tyrant\|Hive Tyrant]] (elder) |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 11.2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 55622 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 5.6 m high × 11.2 m long × 17.09 m wide; prefab scale 1.867.
- **Physics:** 6462.7 kg, gravity ×1, poise 511, knockback resistance 0.98, death style `crash_slide`.
- **Navigation:** speed 8.22 m/s, turn 179°/s, stopping distance 1.3 m.
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

Greater Hive Tyrant is a **dread insectoid** encountered at S rank, around level 188. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a winged queen-killer with a crown of stingers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects S|loot_killer_insect_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | SS, S+, SS-, A+, S | 159–236 | Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 5 | S-, SS-, S, S+, SS | 173–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06539` | Great Labyrinth (Floors 41-90) Greater Hive Tyrant Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | SS | 236 | 15.12 m | Night | Like a typical Greater Hive Tyrant, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06540` | Great Labyrinth (Floors 91-120) Greater Hive Tyrant Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | S- | 173 | 9.52 m | Night | Like a typical Greater Hive Tyrant, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_06541` | Great Labyrinth (Floors 91-120) Greater Hive Tyrant Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SS- | 218 | 14 m | Night | Like a typical Greater Hive Tyrant, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06542` | Great Labyrinth (Floors 91-120) Greater Hive Tyrant | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | S | 188 | 11.2 m | Night | A typical adult Greater Hive Tyrant of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06543` | Great Labyrinth (Floors 41-90) Greater Hive Tyrant Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | S+ | 203 | 11.2 m | Night | Like a typical Greater Hive Tyrant, but a rare pale form with white skin or fur and red eyes. |
| `pop_06544` | Great Labyrinth (Floors 41-90) Greater Hive Tyrant Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS- | 218 | 14 m | Night | Like a typical Greater Hive Tyrant, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06545` | Great Labyrinth (Floors 91-120) Greater Hive Tyrant Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | S+ | 203 | 11.2 m | Night | Like a typical Greater Hive Tyrant, but a rare pale form with white skin or fur and red eyes. |
| `pop_06546` | Great Labyrinth (Floors 91-120) Greater Hive Tyrant Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | SS | 236 | 15.12 m | Night | Like a typical Greater Hive Tyrant, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06547` | Great Labyrinth (Floors 41-90) Greater Hive Tyrant Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | S+ | 203 | 12.32 m | Night | Like a typical Greater Hive Tyrant, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06548` | Great Labyrinth (Floors 41-90) Greater Hive Tyrant Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | A+ | 159 | 7.84 m | Night | Like a typical Greater Hive Tyrant, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06549` | Great Labyrinth (Floors 41-90) Greater Hive Tyrant | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S | 188 | 11.2 m | Night | A typical adult Greater Hive Tyrant of this region, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
