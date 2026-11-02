---
type: monster
id: mon_labyrinth_hound
family: "Floor-born"
rank: "D"
tier: core
tags: [monster, floor-born]
---
# Labyrinth Hound

![[mon_labyrinth_hound_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_labyrinth_hound_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,294 tris · 0.482 × 1.4 × 0.94 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Labyrinth Hound is a person-sized creature with a heavy, muscular quadruped frame, about 1.4 m long. Its stone-like hide is rough, scarred and spiked, colored in rusted iron, with ochre markings. Survivors describe a brick-patterned hide. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1.4 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3756 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/quad_large\|quad_large]] · `anim_quad_large` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/quad_large|quad_large]] (rigId); animation set `anim_quad_large`.
- **Dimensions:** 0.91 m high × 1.4 m long × 0.22 m wide; prefab scale 0.35.
- **Physics:** 71.3 kg, gravity ×1.32, poise 54, knockback resistance 1, death style `heavy_fall_dust`.
- **Navigation:** speed 4.62 m/s, turn 270°/s, stopping distance 0.68 m.
- **Attack count:** 5; **signature:** a brick-patterned hide.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Maul\|Maul]] | melee | 1.2 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Pounce\|Pounce]] | dash | 1.6 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Howl\|Howl]] | buff | 0 | 18 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Wall Ambush\|Wall Ambush]] | dash | 1.4 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Labyrinth Hound is a **menacing dungeon-born** encountered at D rank, around level 48. Its documented behaviour is *Aggressive* and its AI pattern is *aggressive_chase*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a brick-patterned hide. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_quad_large`, animation set `anim_quad_large`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Floor-born D|loot_floorborn_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Floor-born/Ruin Hound|Ruin Hound]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | D+, C-, D-, C, E+ | 32–76 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 6 | D-, D+, D, C, C- | 40–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_02585` | Great Labyrinth (Floors 1-40) Labyrinth Hound Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D+ | 56 | 1.4 m | Day & Night | Like a typical Labyrinth Hound, but a rare pale form with white skin or fur and red eyes. |
| `pop_02586` | Great Labyrinth (Floors 1-40) Labyrinth Hound Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C- | 65 | 1.75 m | Day & Night | Like a typical Labyrinth Hound, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_02587` | Umbravel Labyrinth Hound Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D- | 40 | 1.19 m | Day & Night | Like a typical Labyrinth Hound, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_02588` | Umbravel Labyrinth Hound Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | D+ | 56 | 1.54 m | Day & Night | Like a typical Labyrinth Hound, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_02589` | Umbravel Labyrinth Hound | [[Regions/Umbravel\|Umbravel]] | Adult | D | 48 | 1.4 m | Day & Night | A typical adult Labyrinth Hound of this region, with bioluminescent spots along its body. |
| `pop_02590` | Great Labyrinth (Floors 1-40) Labyrinth Hound Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D- | 40 | 1.19 m | Day & Night | Like a typical Labyrinth Hound, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_02591` | Great Labyrinth (Floors 1-40) Labyrinth Hound Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C | 76 | 1.89 m | Day & Night | Like a typical Labyrinth Hound, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_02592` | Umbravel Labyrinth Hound Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C | 76 | 1.89 m | Day & Night | Like a typical Labyrinth Hound, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_02593` | Great Labyrinth (Floors 1-40) Labyrinth Hound Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E+ | 32 | 0.98 m | Day & Night | Like a typical Labyrinth Hound, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_02594` | Umbravel Labyrinth Hound Albino | [[Regions/Umbravel\|Umbravel]] | Albino | D+ | 56 | 1.4 m | Day & Night | Like a typical Labyrinth Hound, but a rare pale form with white skin or fur and red eyes. |
| `pop_02595` | Umbravel Labyrinth Hound Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | C- | 65 | 1.75 m | Day & Night | Like a typical Labyrinth Hound, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `dungeon_stone` · VFX `rock_debris` · palette `#8c784b` `#5d4f33` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
