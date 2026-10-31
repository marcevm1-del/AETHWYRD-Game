---
type: monster
id: mon_ruin_wall_stalker
family: "Floor-born"
rank: "E+"
tier: variant
tags: [monster, floor-born]
---
# Ruin Wall Stalker

![[mon_ruin_wall_stalker_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ruin_wall_stalker_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,632 tris · 1.402 × 1.501 × 2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ruin Wall Stalker is a person-sized creature with an asymmetric body with too many limbs, about 2 m tall. Its stone-like hide is patchy and subtly wrong, as if assembled from memory, colored in rusted iron, with violet markings. It peels itself out of the wall. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Wall Stalker\|Wall Stalker]] (regional) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2134 · 173 · 124 · 124 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_aberrant` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_aberrant`.
- **Dimensions:** 2 m high × 2.14 m long × 2.1 m wide; prefab scale 1.
- **Physics:** 240 kg, gravity ×1.2, poise 71, knockback resistance 0.63, death style `collapse_and_melt`.
- **Navigation:** speed 5.92 m/s, turn 354°/s, stopping distance 1 m.
- **Attack count:** 5; **signature:** it peels itself out of the wall.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Grasp\|Grasp]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Unfold\|Unfold]] | aoe | 1.8 | 12 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Mimic Voice\|Mimic Voice]] | debuff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wall Ambush\|Wall Ambush]] | dash | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ruin Wall Stalker is a **dread dungeon-born** encountered at E+ rank, around level 32. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** it peels itself out of the wall. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_aberrant`, animation set `anim_aberrant`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Floor-born E|loot_floorborn_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 7 | D, E-, E, E+, D-, D+ | 19–56 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05429` | Great Labyrinth (Floors 1-40) Ruin Wall Stalker Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D | 48 | 2.5 m | Night | Like a typical Ruin Wall Stalker, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05430` | Great Labyrinth (Floors 1-40) Ruin Wall Stalker Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E- | 19 | 1.4 m | Night | Like a typical Ruin Wall Stalker, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_05431` | Great Labyrinth (Floors 1-40) Ruin Wall Stalker Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E | 26 | 1.7 m | Night | Like a typical Ruin Wall Stalker, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_05432` | Great Labyrinth (Floors 1-40) Ruin Wall Stalker | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E+ | 32 | 2 m | Night | A typical adult Ruin Wall Stalker of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_05433` | Great Labyrinth (Floors 1-40) Ruin Wall Stalker Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D- | 40 | 2.2 m | Night | Like a typical Ruin Wall Stalker, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05434` | Great Labyrinth (Floors 1-40) Ruin Wall Stalker Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D- | 40 | 2 m | Night | Like a typical Ruin Wall Stalker, but a rare pale form with white skin or fur and red eyes. |
| `pop_05435` | Great Labyrinth (Floors 1-40) Ruin Wall Stalker Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | D+ | 56 | 2.7 m | Night | Like a typical Ruin Wall Stalker, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `dungeon_stone` · VFX `shadow_wisps` · palette `#7d6443` `#53422d` `#9a86d8` · elongated, irregular silhouette; still-then-sudden timing
