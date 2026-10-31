---
type: monster
id: mon_greater_core_sentinel
family: "Floor-born"
rank: "B"
tier: variant
tags: [monster, floor-born]
---
# Greater Core Sentinel

![[mon_greater_core_sentinel_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_core_sentinel_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (946 tris · 3.963 × 2.71 × 4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Core Sentinel is a large creature with a blocky construct body, about 4 m tall. Its stone-like hide is rough, scarred and spiked, colored in dungeon stone, with gold markings. Look for a dungeon-core crystal for a heart. It has narrow glowing eyes. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by soft radiance and floating motes of light. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Core Sentinel\|Core Sentinel]] (elder) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 4 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22688 · 442 · 663 · 265 · 442 · 70 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 4 m high × 1.2 m long × 1.68 m wide; prefab scale 1.333.
- **Physics:** 2918.4 kg, gravity ×1.08, poise 370, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 4.19 m/s, turn 100°/s, stopping distance 1.28 m.
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

Greater Core Sentinel is a **menacing dungeon-born** encountered at B rank, around level 108. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dungeon-core crystal for a heart. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aurumdeep|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Floor-born B|loot_floorborn_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | A-, A, B+ | 120–146 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 3 | A-, B+, C+ | 86–132 | Day & Night |
| [[Regions/Aurumdeep\|Aurumdeep]] | 4 | B, A, B+ | 108–146 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_05443` | Great Labyrinth (Floors 41-90) Greater Core Sentinel Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A- | 132 | 5 m | Day & Night | Like a typical Greater Core Sentinel, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_05444` | Umbravel Greater Core Sentinel Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | A- | 132 | 5 m | Day & Night | Like a typical Greater Core Sentinel, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_05445` | Aurumdeep Greater Core Sentinel | [[Regions/Aurumdeep\|Aurumdeep]] | Adult | B | 108 | 4 m | Day & Night | A typical adult Greater Core Sentinel of this region, with bioluminescent spots along its body. |
| `pop_05446` | Great Labyrinth (Floors 41-90) Greater Core Sentinel Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A | 146 | 5.4 m | Day & Night | Like a typical Greater Core Sentinel, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_05447` | Umbravel Greater Core Sentinel Albino | [[Regions/Umbravel\|Umbravel]] | Albino | B+ | 120 | 4 m | Day & Night | Like a typical Greater Core Sentinel, but a rare pale form with white skin or fur and red eyes. |
| `pop_05448` | Aurumdeep Greater Core Sentinel Elderborn | [[Regions/Aurumdeep\|Aurumdeep]] | Elderborn | A | 146 | 5.4 m | Day & Night | Like a typical Greater Core Sentinel, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_05449` | Umbravel Greater Core Sentinel Runt | [[Regions/Umbravel\|Umbravel]] | Runt | C+ | 86 | 2.8 m | Day & Night | Like a typical Greater Core Sentinel, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_05450` | Great Labyrinth (Floors 41-90) Greater Core Sentinel Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B+ | 120 | 4.4 m | Day & Night | Like a typical Greater Core Sentinel, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_05451` | Great Labyrinth (Floors 41-90) Greater Core Sentinel Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B+ | 120 | 4 m | Day & Night | Like a typical Greater Core Sentinel, but a rare pale form with white skin or fur and red eyes. |
| `pop_05452` | Aurumdeep Greater Core Sentinel Scarred | [[Regions/Aurumdeep\|Aurumdeep]] | Scarred | B+ | 120 | 4.4 m | Day & Night | Like a typical Greater Core Sentinel, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_05453` | Aurumdeep Greater Core Sentinel Albino | [[Regions/Aurumdeep\|Aurumdeep]] | Albino | B+ | 120 | 4 m | Day & Night | Like a typical Greater Core Sentinel, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `dungeon_stone` · VFX `holy_motes` · palette `#767b86` `#4f535b` `#ffd166` · triangle-based silhouette, sharp asymmetric spikes
