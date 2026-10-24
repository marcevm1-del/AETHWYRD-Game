---
type: monster
id: mon_ruin_kobold_miner
family: "Kobolds"
rank: "E+"
tier: variant
tags: [monster, kobolds]
---
# Ruin Kobold Miner

![[mon_ruin_kobold_miner_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ruin_kobold_miner_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ruin Kobold Miner is a small creature with a scrawny biped with long arms and bowed legs, about 0.9 m tall. Its mangy fur is weathered and natural, colored in ink black with bruised violet. Survivors describe a candle-helmet and a pick worn smooth from use. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It stalks low to the ground, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Miner\|Kobold Miner]] (regional) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | Dark · Light |
| Size | 0.9 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1388 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.9 m high × 0.27 m long × 0.36 m wide; prefab scale 0.818.
- **Physics:** 11.7 kg, gravity ×1.5, poise 31, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 4.82 m/s, turn 443°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** a candle-helmet and a pick worn smooth from use.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ruin Kobold Miner is a **wild humanoid** encountered at E+ rank, around level 32. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a candle-helmet and a pick worn smooth from use. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds E|loot_kobold_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | E, E-, E+, D+, D, D- | 19–56 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 5 | E, D-, D, E- | 19–48 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03203` | Great Labyrinth (Floors 1-40) Ruin Kobold Miner Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 0.77 m | Day & Night | Like a typical Ruin Kobold Miner, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03204` | Aldmere Ruin Kobold Miner Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | E | 26 | 0.77 m | Day & Night | Like a typical Ruin Kobold Miner, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03205` | Great Labyrinth (Floors 1-40) Ruin Kobold Miner Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E- | 19 | 0.63 m | Day & Night | Like a typical Ruin Kobold Miner, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03206` | Aldmere Ruin Kobold Miner Albino | [[Regions/Aldmere\|Aldmere]] | Albino | D- | 40 | 0.9 m | Day & Night | Like a typical Ruin Kobold Miner, but a rare pale form with white skin or fur and red eyes. |
| `pop_03207` | Great Labyrinth (Floors 1-40) Ruin Kobold Miner | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E+ | 32 | 0.9 m | Day & Night | A typical adult Ruin Kobold Miner of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03208` | Great Labyrinth (Floors 1-40) Ruin Kobold Miner Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D+ | 56 | 1.22 m | Day & Night | Like a typical Ruin Kobold Miner, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03209` | Great Labyrinth (Floors 1-40) Ruin Kobold Miner Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D | 48 | 1.13 m | Day & Night | Like a typical Ruin Kobold Miner, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03210` | Great Labyrinth (Floors 1-40) Ruin Kobold Miner Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D- | 40 | 0.9 m | Day & Night | Like a typical Ruin Kobold Miner, but a rare pale form with white skin or fur and red eyes. |
| `pop_03211` | Aldmere Ruin Kobold Miner Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D | 48 | 1.13 m | Day & Night | Like a typical Ruin Kobold Miner, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03212` | Aldmere Ruin Kobold Miner Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | D- | 40 | 0.99 m | Day & Night | Like a typical Ruin Kobold Miner, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03213` | Aldmere Ruin Kobold Miner Runt | [[Regions/Aldmere\|Aldmere]] | Runt | E- | 19 | 0.63 m | Day & Night | Like a typical Ruin Kobold Miner, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · real-animal silhouette with one fantasy exaggeration
