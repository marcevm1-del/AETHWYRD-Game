---
type: monster
id: mon_floor_tyrant
family: "Floor-born"
rank: "A"
tier: core
tags: [monster, floor-born]
---
# Floor Tyrant

> The Floor Tyrant is a huge creature with a giant, barrel-chested humanoid body, about 8 m tall. Its stone-like hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe a crown of stalactites. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 8 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 44099 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/The Maw\|The Maw]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep\|Aurumdeep]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Wind. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 8 m high × 2.4 m long × 3.36 m wide; prefab scale 2.286.
- **Physics:** 11980.8 kg, gravity ×1.43, poise 370, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 7.87 m/s, turn 134°/s, stopping distance 2 m.
- **Attack count:** 5; **signature:** a crown of stalactites.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stomp\|Stomp]] | aoe | 1.3 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Club Slam\|Club Slam]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Grab and Throw\|Grab and Throw]] | grab | 2 | 14 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Wall Ambush\|Wall Ambush]] | dash | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Floor Tyrant is a **menacing dungeon-born** encountered at A rank, around level 146. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of stalactites. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/The Maw|The Maw]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep|Aurumdeep]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Floor-born A|loot_floorborn_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Floor-born/Greater Floor Tyrant|Greater Floor Tyrant]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | B+, S, A+, A- | 120–188 | Day & Night |
| [[Regions/The Maw\|The Maw]] | 2 | A-, A+ | 132–159 | Day & Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 5 | A+, A, A-, B+ | 120–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02618` | Great Labyrinth (Floors 41-90) Floor Tyrant Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | B+ | 120 | 5.6 m | Day & Night | Like a typical Floor Tyrant, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_02619` | The Maw Floor Tyrant Juvenile | [[Regions/The Maw\|The Maw]] | Juvenile | A- | 132 | 6.8 m | Day & Night | Like a typical Floor Tyrant, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_02620` | Great Labyrinth (Floors 41-90) Floor Tyrant Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S | 188 | 10.8 m | Day & Night | Like a typical Floor Tyrant, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_02621` | Aurumdeep Floor Tyrant Albino | [[Regions/Aurumdeep\|Aurumdeep]] | Albino | A+ | 159 | 8 m | Day & Night | Like a typical Floor Tyrant, but a rare pale form with white skin or fur and red eyes. |
| `pop_02622` | Aurumdeep Floor Tyrant | [[Regions/Aurumdeep\|Aurumdeep]] | Adult | A | 146 | 8 m | Day & Night | A typical adult Floor Tyrant of this region, with bioluminescent spots along its body. |
| `pop_02623` | Aurumdeep Floor Tyrant Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | A+ | 159 | 8.8 m | Day & Night | Like a typical Floor Tyrant, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_02624` | Great Labyrinth (Floors 41-90) Floor Tyrant Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | A+ | 159 | 8 m | Day & Night | Like a typical Floor Tyrant, but a rare pale form with white skin or fur and red eyes. |
| `pop_02625` | The Maw Floor Tyrant Scarred | [[Regions/The Maw\|The Maw]] | Scarred | A+ | 159 | 8.8 m | Day & Night | Like a typical Floor Tyrant, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_02626` | Great Labyrinth (Floors 41-90) Floor Tyrant Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | A- | 132 | 6.8 m | Day & Night | Like a typical Floor Tyrant, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_02627` | Aurumdeep Floor Tyrant Juvenile | [[Regions/Aurumdeep\|Aurumdeep]] | Juvenile | A- | 132 | 6.8 m | Day & Night | Like a typical Floor Tyrant, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_02628` | Aurumdeep Floor Tyrant Runt | [[Regions/Aurumdeep\|Aurumdeep]] | Runt | B+ | 120 | 5.6 m | Day & Night | Like a typical Floor Tyrant, but smaller and scrappier than usual, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `dungeon_stone` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
