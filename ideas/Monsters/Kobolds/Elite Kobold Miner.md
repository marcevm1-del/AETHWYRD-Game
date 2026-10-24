---
type: monster
id: mon_elite_kobold_miner
family: "Kobolds"
rank: "D"
tier: variant
tags: [monster, kobolds]
---
# Elite Kobold Miner

![[mon_elite_kobold_miner_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_elite_kobold_miner_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Elite Kobold Miner is a person-sized creature with a small, compact humanoid body, about 1.4 m tall. Its mangy fur is weathered and natural, colored in ochre, clay and mossy stone. Its most striking feature is a candle-helmet and a pick worn smooth from use. It has alert animal eyes. A distinctive marking runs along its back. It prowls, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Miner\|Kobold Miner]] (elder) |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 1.4 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2902 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.4 m high × 0.42 m long × 0.56 m wide; prefab scale 1.273.
- **Physics:** 57.1 kg, gravity ×1.65, poise 44, knockback resistance 0.36, death style `ragdoll_crumple`.
- **Navigation:** speed 5.52 m/s, turn 355°/s, stopping distance 0.68 m.
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

Elite Kobold Miner is a **wild humanoid** encountered at D rank, around level 48. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a candle-helmet and a pick worn smooth from use. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds D|loot_kobold_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | E+, D+, C-, D, D- | 32–65 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 5 | C, C-, D, E+, D+ | 32–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06044` | Great Labyrinth (Floors 1-40) Elite Kobold Miner Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E+ | 32 | 0.98 m | Day & Night | Like a typical Elite Kobold Miner, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06045` | Umbravel Elite Kobold Miner Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C | 76 | 1.89 m | Day & Night | Like a typical Elite Kobold Miner, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_06046` | Umbravel Elite Kobold Miner Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | C- | 65 | 1.75 m | Day & Night | Like a typical Elite Kobold Miner, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_06047` | Great Labyrinth (Floors 1-40) Elite Kobold Miner Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D+ | 56 | 1.4 m | Day & Night | Like a typical Elite Kobold Miner, but a rare pale form with white skin or fur and red eyes. |
| `pop_06048` | Great Labyrinth (Floors 1-40) Elite Kobold Miner Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C- | 65 | 1.75 m | Day & Night | Like a typical Elite Kobold Miner, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06049` | Umbravel Elite Kobold Miner | [[Regions/Umbravel\|Umbravel]] | Adult | D | 48 | 1.4 m | Day & Night | A typical adult Elite Kobold Miner of this region, with bioluminescent spots along its body. |
| `pop_06050` | Umbravel Elite Kobold Miner Runt | [[Regions/Umbravel\|Umbravel]] | Runt | E+ | 32 | 0.98 m | Day & Night | Like a typical Elite Kobold Miner, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_06051` | Umbravel Elite Kobold Miner Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | D+ | 56 | 1.54 m | Day & Night | Like a typical Elite Kobold Miner, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_06052` | Great Labyrinth (Floors 1-40) Elite Kobold Miner | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 1.4 m | Day & Night | A typical adult Elite Kobold Miner of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06053` | Great Labyrinth (Floors 1-40) Elite Kobold Miner Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D+ | 56 | 1.54 m | Day & Night | Like a typical Elite Kobold Miner, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06054` | Great Labyrinth (Floors 1-40) Elite Kobold Miner Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D- | 40 | 1.19 m | Day & Night | Like a typical Elite Kobold Miner, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
