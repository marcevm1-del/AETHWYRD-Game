---
type: monster
id: mon_kobold_miner
family: "Kobolds"
rank: "E"
tier: core
tags: [monster, kobolds]
---
# Kobold Miner

> The Kobold Miner is a small creature with a scrawny biped with long arms and bowed legs, about 0.9 m tall. Its mangy fur is weathered and natural, colored in ochre, clay and mossy stone. Survivors describe a candle-helmet and a pick worn smooth from use. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It stalks low to the ground, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.9 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1030 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.9 m high × 0.27 m long × 0.36 m wide; prefab scale 0.818.
- **Physics:** 15.2 kg, gravity ×1.65, poise 31, knockback resistance 0.33, death style `ragdoll_crumple`.
- **Navigation:** speed 4.42 m/s, turn 443°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** a candle-helmet and a pick worn smooth from use.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Kobold Miner is a **wild humanoid** encountered at E rank, around level 26. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a candle-helmet and a pick worn smooth from use. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds E|loot_kobold_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Kobolds/Ruin Kobold Miner|Ruin Kobold Miner]]
- [[Monsters/Kobolds/Elite Kobold Miner|Elite Kobold Miner]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | E+, D, D-, E | 26–48 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 6 | E, D-, E+, F+, D | 13–48 | Day & Night |
| [[Regions/Whisperwood\|Whisperwood]] | 1 | E+ | 32–32 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00299` | Great Labyrinth (Floors 1-40) Kobold Miner Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E+ | 32 | 0.9 m | Day & Night | Like a typical Kobold Miner, but a rare pale form with white skin or fur and red eyes. |
| `pop_00300` | Great Labyrinth (Floors 1-40) Kobold Miner Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D | 48 | 1.22 m | Day & Night | Like a typical Kobold Miner, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00301` | Great Labyrinth (Floors 1-40) Kobold Miner Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D- | 40 | 1.13 m | Day & Night | Like a typical Kobold Miner, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00302` | Aldmere Kobold Miner | [[Regions/Aldmere\|Aldmere]] | Adult | E | 26 | 0.9 m | Day & Night | A typical adult Kobold Miner of this region, with dust-grey coloring and old rune scars. |
| `pop_00303` | Aldmere Kobold Miner Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 1.13 m | Day & Night | Like a typical Kobold Miner, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00304` | Aldmere Kobold Miner Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | E+ | 32 | 0.99 m | Day & Night | Like a typical Kobold Miner, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00305` | Great Labyrinth (Floors 1-40) Kobold Miner | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E | 26 | 0.9 m | Day & Night | A typical adult Kobold Miner of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00306` | Aldmere Kobold Miner Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.63 m | Day & Night | Like a typical Kobold Miner, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00307` | Aldmere Kobold Miner Albino | [[Regions/Aldmere\|Aldmere]] | Albino | E+ | 32 | 0.9 m | Day & Night | Like a typical Kobold Miner, but a rare pale form with white skin or fur and red eyes. |
| `pop_00308` | Whisperwood Kobold Miner Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 0.99 m | Day & Night | Like a typical Kobold Miner, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00309` | Aldmere Kobold Miner Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | D | 48 | 1.22 m | Day & Night | Like a typical Kobold Miner, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
