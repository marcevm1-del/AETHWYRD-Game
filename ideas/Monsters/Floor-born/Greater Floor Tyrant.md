---
type: monster
id: mon_greater_floor_tyrant
family: "Floor-born"
rank: "S"
tier: variant
tags: [monster, floor-born]
---
# Greater Floor Tyrant

![[mon_greater_floor_tyrant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_floor_tyrant_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Floor Tyrant is a huge creature with a giant, barrel-chested humanoid body, about 12.8 m tall. Its stone-like hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Look for a crown of stalactites. It has eyes that catch torchlight like coins. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Floor Tyrant\|Floor Tyrant]] (elder) |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 12.8 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 73397 · 762 · 1143 · 457 · 762 · 70 |
| XP · gold | 13063 · 2293 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/large_biped\|large_biped]] · `anim_large_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Wind. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/large_biped|large_biped]] (rigId); animation set `anim_large_biped`.
- **Dimensions:** 12.8 m high × 3.84 m long × 5.38 m wide; prefab scale 3.657.
- **Physics:** 49073.4 kg, gravity ×1.43, poise 509, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 9.96 m/s, turn 106°/s, stopping distance 2.96 m.
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

Greater Floor Tyrant is a **menacing dungeon-born** encountered at S rank, around level 188. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a crown of stalactites. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_large_biped`, animation set `anim_large_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Floor-born S|loot_floorborn_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | S+, S-, SS-, A+, SS | 159–236 | Day & Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 5 | S+, S-, S, A+ | 159–203 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05465` | Great Labyrinth (Floors 41-90) Greater Floor Tyrant Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | S+ | 203 | 12.8 m | Day & Night | Like a typical Greater Floor Tyrant, but a rare pale form with white skin or fur and red eyes. |
| `pop_05466` | Great Labyrinth (Floors 41-90) Greater Floor Tyrant Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S- | 173 | 10.88 m | Day & Night | Like a typical Greater Floor Tyrant, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05467` | Great Labyrinth (Floors 91-120) Greater Floor Tyrant Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | S+ | 203 | 14.08 m | Day & Night | Like a typical Greater Floor Tyrant, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05468` | Great Labyrinth (Floors 41-90) Greater Floor Tyrant Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS- | 218 | 16 m | Day & Night | Like a typical Greater Floor Tyrant, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05469` | Great Labyrinth (Floors 41-90) Greater Floor Tyrant Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | A+ | 159 | 8.96 m | Day & Night | Like a typical Greater Floor Tyrant, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05470` | Great Labyrinth (Floors 91-120) Greater Floor Tyrant Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | S+ | 203 | 12.8 m | Day & Night | Like a typical Greater Floor Tyrant, but a rare pale form with white skin or fur and red eyes. |
| `pop_05471` | Great Labyrinth (Floors 91-120) Greater Floor Tyrant Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | S- | 173 | 10.88 m | Day & Night | Like a typical Greater Floor Tyrant, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05472` | Great Labyrinth (Floors 91-120) Greater Floor Tyrant | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | S | 188 | 12.8 m | Day & Night | A typical adult Greater Floor Tyrant of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05473` | Great Labyrinth (Floors 41-90) Greater Floor Tyrant Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | SS | 236 | 17.28 m | Day & Night | Like a typical Greater Floor Tyrant, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05474` | Great Labyrinth (Floors 41-90) Greater Floor Tyrant Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | S+ | 203 | 14.08 m | Day & Night | Like a typical Greater Floor Tyrant, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05475` | Great Labyrinth (Floors 91-120) Greater Floor Tyrant Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | A+ | 159 | 8.96 m | Day & Night | Like a typical Greater Floor Tyrant, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `dungeon_stone` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
