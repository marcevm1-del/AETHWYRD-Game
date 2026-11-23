---
type: monster
id: mon_iron_golem
family: "Constructs & Mimics"
rank: "B"
tier: core
tags: [monster, constructs-mimics]
---
# Iron Golem

![[mon_iron_golem_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_iron_golem_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 3.824 × 1.585 × 4 m · local file `Game/Assets/_Game/Art/Models/Monsters/Constructs & Mimics/mon_iron_golem.fbx`

> The Iron Golem is a large creature with a towering machine-like frame, about 4 m tall. Its surface is weathered and natural, colored in riveted iron, with ochre markings. Look for riveted iron and a furnace heart. It has amber predator eyes. Faint runes glow along its body when it fights. It stalks low to the ground, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | B · 108 (96–120) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 4 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22688 · 442 · 663 · 265 · 442 · 70 |
| XP · gold | 5386 · 1057 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Zarvan\|Zarvan]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 4 m high × 1.2 m long × 1.68 m wide; prefab scale 1.333.
- **Physics:** 3993.6 kg, gravity ×1.32, poise 370, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 3.67 m/s, turn 100°/s, stopping distance 1.28 m.
- **Attack count:** 5; **signature:** riveted iron and a furnace heart.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Iron Golem is a **wild construct** encountered at B rank, around level 108. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** riveted iron and a furnace heart. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Zarvan|Zarvan]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics B|loot_construct_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Greater Iron Golem|Greater Iron Golem]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 5 | A, B+, B-, C+ | 86–146 | Day & Night |
| [[Regions/Sunscar\|Sunscar]] | 2 | A, B- | 96–146 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | A-, B+, B- | 96–132 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01517` | Zarvan Iron Golem Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | A | 146 | 5.4 m | Day & Night | Like a typical Iron Golem, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_01518` | Sunscar Iron Golem Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | A | 146 | 5.4 m | Day & Night | Like a typical Iron Golem, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_01519` | Zarvan Iron Golem Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | B+ | 120 | 4.4 m | Day & Night | Like a typical Iron Golem, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_01520` | Great Labyrinth (Floors 41-90) Iron Golem Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A- | 132 | 5 m | Day & Night | Like a typical Iron Golem, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01521` | Great Labyrinth (Floors 41-90) Iron Golem Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B+ | 120 | 4 m | Day & Night | Like a typical Iron Golem, but a rare pale form with white skin or fur and red eyes. |
| `pop_01522` | Sunscar Iron Golem Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | B- | 96 | 3.4 m | Day & Night | Like a typical Iron Golem, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_01523` | Zarvan Iron Golem Juvenile | [[Regions/Zarvan\|Zarvan]] | Juvenile | B- | 96 | 3.4 m | Day & Night | Like a typical Iron Golem, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_01524` | Zarvan Iron Golem Albino | [[Regions/Zarvan\|Zarvan]] | Albino | B+ | 120 | 4 m | Day & Night | Like a typical Iron Golem, but a rare pale form with white skin or fur and red eyes. |
| `pop_01525` | Great Labyrinth (Floors 41-90) Iron Golem Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B- | 96 | 3.4 m | Day & Night | Like a typical Iron Golem, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01526` | Great Labyrinth (Floors 41-90) Iron Golem Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B+ | 120 | 4.4 m | Day & Night | Like a typical Iron Golem, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01527` | Zarvan Iron Golem Runt | [[Regions/Zarvan\|Zarvan]] | Runt | C+ | 86 | 2.8 m | Day & Night | Like a typical Iron Golem, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `rock_debris` · palette `#6c717a` `#4b4f58` `#d1a15a` · real-animal silhouette with one fantasy exaggeration
