---
type: monster
id: mon_vine_hive_tyrant
family: "Killer Insects"
rank: "A+"
tier: variant
tags: [monster, killer-insects]
---
# Vine Hive Tyrant

> The Vine Hive Tyrant is a huge creature with a sleek flying build, about 7 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in leaf greens over bark brown. Its most striking feature is a winged queen-killer with a crown of stingers. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It glides without moving its legs, surrounded by drifting pollen and tiny blossoms. Adapted to jungle lands, it has vivid tropical markings.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Hive Tyrant\|Hive Tyrant]] (regional) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Nature · Fire |
| Size | 7 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 37838 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/wyvern\|wyvern]] · `anim_wyvern` |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/wyvern|wyvern]] (rigId); animation set `anim_wyvern`.
- **Dimensions:** 3.5 m high × 7 m long × 10.68 m wide; prefab scale 1.167.
- **Physics:** 1577.8 kg, gravity ×1, poise 227, knockback resistance 0.95, death style `crash_slide`.
- **Navigation:** speed 6.39 m/s, turn 227°/s, stopping distance 0.96 m.
- **Attack count:** 5; **signature:** a winged queen-killer with a crown of stingers.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Talon Rake\|Talon Rake]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dive Bomb\|Dive Bomb]] | dash | 1.9 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tail Whip\|Tail Whip]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Thorn Volley\|Thorn Volley]] | magic | 1.5 | 10 s | Nature | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vine Hive Tyrant is a **dread insectoid** encountered at A+ rank, around level 159. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a winged queen-killer with a crown of stingers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Lumbaya|Lumbaya]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_wyvern`, animation set `anim_wyvern`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects A|loot_killer_insect_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | S, A, A-, S-, A+ | 132–188 | Night |
| [[Regions/Lumbaya\|Lumbaya]] | 6 | A+, S, S-, A, A- | 132–188 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03694` | Great Labyrinth (Floors 41-90) Vine Hive Tyrant Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S | 188 | 8.75 m | Night | Like a typical Vine Hive Tyrant, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03695` | Great Labyrinth (Floors 41-90) Vine Hive Tyrant Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | A | 146 | 5.95 m | Night | Like a typical Vine Hive Tyrant, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03696` | Great Labyrinth (Floors 41-90) Vine Hive Tyrant Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | A- | 132 | 4.9 m | Night | Like a typical Vine Hive Tyrant, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03697` | Lumbaya Vine Hive Tyrant | [[Regions/Lumbaya\|Lumbaya]] | Adult | A+ | 159 | 7 m | Night | A typical adult Vine Hive Tyrant of this region, with vivid tropical markings. |
| `pop_03698` | Lumbaya Vine Hive Tyrant Alpha | [[Regions/Lumbaya\|Lumbaya]] | Alpha | S | 188 | 8.75 m | Night | Like a typical Vine Hive Tyrant, but larger and scarred, and others of its kind follow it, with vivid tropical markings. |
| `pop_03699` | Lumbaya Vine Hive Tyrant Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | S- | 173 | 7 m | Night | Like a typical Vine Hive Tyrant, but a rare pale form with white skin or fur and red eyes. |
| `pop_03700` | Lumbaya Vine Hive Tyrant Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | S- | 173 | 7.7 m | Night | Like a typical Vine Hive Tyrant, but covered in old battle scars, with vivid tropical markings. |
| `pop_03701` | Great Labyrinth (Floors 41-90) Vine Hive Tyrant Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | S- | 173 | 7.7 m | Night | Like a typical Vine Hive Tyrant, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03702` | Lumbaya Vine Hive Tyrant Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | A | 146 | 5.95 m | Night | Like a typical Vine Hive Tyrant, but young, with brighter colors and unworn features, with vivid tropical markings. |
| `pop_03703` | Lumbaya Vine Hive Tyrant Runt | [[Regions/Lumbaya\|Lumbaya]] | Runt | A- | 132 | 4.9 m | Night | Like a typical Vine Hive Tyrant, but smaller and scrappier than usual, with vivid tropical markings. |
| `pop_03704` | Great Labyrinth (Floors 41-90) Vine Hive Tyrant | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | A+ | 159 | 7 m | Night | A typical adult Vine Hive Tyrant of this region, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `chitin_matte` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · elongated, irregular silhouette; still-then-sudden timing
