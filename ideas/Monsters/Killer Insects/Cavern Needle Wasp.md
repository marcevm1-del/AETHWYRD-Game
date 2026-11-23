---
type: monster
id: mon_cavern_needle_wasp
family: "Killer Insects"
rank: "D-"
tier: variant
tags: [monster, killer-insects]
---
# Cavern Needle Wasp

![[mon_cavern_needle_wasp_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cavern_needle_wasp_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 6,000 tris · 0.63 × 0.335 × 0.3 m · local file `Game/Assets/_Game/Art/Models/Monsters/Killer Insects/mon_cavern_needle_wasp.fbx`

> The Cavern Needle Wasp is a tiny creature with a small winged body, about 0.3 m tall. Its chitin is rough, scarred and spiked, colored in black, with ochre markings. Look for a stinger as long as its body. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by pebbles that tremble and float near it. Adapted to cave lands, it has pale, light-starved coloring and oversized eyes.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Needle Wasp\|Needle Wasp]] (regional) |
| Rank · level | D- · 40 (32–48) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 0.3 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1431 · 170 · 136 · 119 · 136 · 135 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_flyer_small` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Wind. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (override (base species)); animation set `anim_flyer_small`.
- **Dimensions:** 0.1 m high × 0.3 m long × 0.15 m wide; prefab scale 0.375.
- **Physics:** 1.5 kg, gravity ×1.54, poise 9, knockback resistance 0.46, death style `flip_legs_curl`.
- **Navigation:** speed 1.91 m/s, turn 900°/s, stopping distance 0.5 m.
- **Attack count:** 5; **signature:** a stinger as long as its body.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Nip\|Nip]] | melee | 0.9 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Dart\|Dart]] | dash | 1.1 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Call\|Swarm Call]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cavern Needle Wasp is a **menacing insectoid** encountered at D- rank, around level 40. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a stinger as long as its body. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_flyer_small`, animation set `anim_flyer_small`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects D|loot_killer_insect_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D+, C-, D | 48–65 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | C-, E, D, D+ | 26–65 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 4 | D, D-, D+, E | 26–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03639` | Great Labyrinth (Floors 1-40) Cavern Needle Wasp Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D+ | 56 | 0.38 m | Day & Night | Like a typical Cavern Needle Wasp, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03640` | Iron Hold Cavern Needle Wasp Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C- | 65 | 0.41 m | Day & Night | Like a typical Cavern Needle Wasp, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03641` | Iron Hold Cavern Needle Wasp Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | E | 26 | 0.21 m | Day & Night | Like a typical Cavern Needle Wasp, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03642` | Umbravel Cavern Needle Wasp Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | D | 48 | 0.33 m | Day & Night | Like a typical Cavern Needle Wasp, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_03643` | Great Labyrinth (Floors 1-40) Cavern Needle Wasp Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C- | 65 | 0.41 m | Day & Night | Like a typical Cavern Needle Wasp, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03644` | Umbravel Cavern Needle Wasp | [[Regions/Umbravel\|Umbravel]] | Adult | D- | 40 | 0.3 m | Day & Night | A typical adult Cavern Needle Wasp of this region, with bioluminescent spots along its body. |
| `pop_03645` | Great Labyrinth (Floors 1-40) Cavern Needle Wasp Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | D | 48 | 0.33 m | Day & Night | Like a typical Cavern Needle Wasp, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03646` | Iron Hold Cavern Needle Wasp Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | D | 48 | 0.3 m | Day & Night | Like a typical Cavern Needle Wasp, but a rare pale form with white skin or fur and red eyes. |
| `pop_03647` | Umbravel Cavern Needle Wasp Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | D+ | 56 | 0.38 m | Day & Night | Like a typical Cavern Needle Wasp, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_03648` | Iron Hold Cavern Needle Wasp Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | D+ | 56 | 0.38 m | Day & Night | Like a typical Cavern Needle Wasp, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03649` | Umbravel Cavern Needle Wasp Runt | [[Regions/Umbravel\|Umbravel]] | Runt | E | 26 | 0.21 m | Day & Night | Like a typical Cavern Needle Wasp, but smaller and scrappier than usual, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `chitin_matte` · VFX `rock_debris` · palette `#4f4f58` `#3c3a43` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
