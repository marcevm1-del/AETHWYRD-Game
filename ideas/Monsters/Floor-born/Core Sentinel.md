---
type: monster
id: mon_core_sentinel
family: "Floor-born"
rank: "C"
tier: core
tags: [monster, floor-born]
---
# Core Sentinel

![[mon_core_sentinel_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_core_sentinel_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,046 tris · 2.449 × 1.513 × 2.5 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Core Sentinel is a large creature with a blocky construct body, about 2.5 m tall. Its stone-like hide is rough, scarred and spiked, colored in dungeon stone, with gold markings. Survivors describe a dungeon-core crystal for a heart. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 2.5 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11496 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Umbravel\|Umbravel]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Dark. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 2.5 m high × 0.75 m long × 1.05 m wide; prefab scale 0.833.
- **Physics:** 712.5 kg, gravity ×1.08, poise 265, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 3.16 m/s, turn 126°/s, stopping distance 0.95 m.
- **Attack count:** 5; **signature:** a dungeon-core crystal for a heart.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wall Ambush\|Wall Ambush]] | dash | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Core Sentinel is a **menacing dungeon-born** encountered at C rank, around level 76. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dungeon-core crystal for a heart. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Umbravel|Umbravel]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Floor-born C|loot_floorborn_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Floor-born/Greater Core Sentinel|Greater Core Sentinel]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 2 | D+, C | 56–76 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | C+, D+, B-, B, C- | 56–108 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D+, C-, C+ | 56–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02596` | Umbravel Core Sentinel Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D+ | 56 | 1.75 m | Day & Night | Like a typical Core Sentinel, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_02597` | Great Labyrinth (Floors 41-90) Core Sentinel Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C+ | 86 | 2.75 m | Day & Night | Like a typical Core Sentinel, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_02598` | Great Labyrinth (Floors 41-90) Core Sentinel Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D+ | 56 | 1.75 m | Day & Night | Like a typical Core Sentinel, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_02599` | Great Labyrinth (Floors 1-40) Core Sentinel Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D+ | 56 | 1.75 m | Day & Night | Like a typical Core Sentinel, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_02600` | Great Labyrinth (Floors 1-40) Core Sentinel Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C- | 65 | 2.13 m | Day & Night | Like a typical Core Sentinel, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_02601` | Great Labyrinth (Floors 41-90) Core Sentinel Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B- | 96 | 3.13 m | Day & Night | Like a typical Core Sentinel, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_02602` | Great Labyrinth (Floors 41-90) Core Sentinel Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B | 108 | 3.38 m | Day & Night | Like a typical Core Sentinel, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_02603` | Great Labyrinth (Floors 41-90) Core Sentinel Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C- | 65 | 2.13 m | Day & Night | Like a typical Core Sentinel, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_02604` | Umbravel Core Sentinel | [[Regions/Umbravel\|Umbravel]] | Adult | C | 76 | 2.5 m | Day & Night | A typical adult Core Sentinel of this region, with bioluminescent spots along its body. |
| `pop_02605` | Great Labyrinth (Floors 1-40) Core Sentinel Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C+ | 86 | 2.5 m | Day & Night | Like a typical Core Sentinel, but a rare pale form with white skin or fur and red eyes. |
| `pop_02606` | Great Labyrinth (Floors 41-90) Core Sentinel Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | C+ | 86 | 2.5 m | Day & Night | Like a typical Core Sentinel, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `dungeon_stone` · VFX `holy_motes` · palette `#798088` `#51575d` `#ffd166` · triangle-based silhouette, sharp asymmetric spikes
