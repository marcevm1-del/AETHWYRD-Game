---
type: monster
id: mon_clockwork_sentinel
family: "Constructs & Mimics"
rank: "C"
tier: core
tags: [monster, constructs-mimics]
---
# Clockwork Sentinel

![[mon_clockwork_sentinel_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_clockwork_sentinel_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Clockwork Sentinel is a large creature with a heavy, hand-built humanoid shell, about 2.5 m tall. Its surface is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Guild sketches always show brass gears visible through its ribs. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 2.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11496 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Lirian\|Lirian]], [[Regions/Gearholm\|Gearholm]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Haneul\|Haneul]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 2.5 m high × 0.75 m long × 1.05 m wide; prefab scale 0.833.
- **Physics:** 750 kg, gravity ×1.2, poise 265, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 3.26 m/s, turn 126°/s, stopping distance 0.95 m.
- **Attack count:** 5; **signature:** brass gears visible through its ribs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Static Arc\|Static Arc]] | magic | 1.5 | 10 s | Lightning | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Clockwork Sentinel is a **menacing construct** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Earth**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** brass gears visible through its ribs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zarvan|Zarvan]], [[Regions/Lirian|Lirian]], [[Regions/Gearholm|Gearholm]], [[Regions/Lumbaya|Lumbaya]], [[Regions/Haneul|Haneul]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics C|loot_construct_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Dusk Clockwork Sentinel|Dusk Clockwork Sentinel]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Lumbaya\|Lumbaya]] | 3 | C-, C+ | 65–86 | Day & Night |
| [[Regions/Gearholm\|Gearholm]] | 2 | D+, C | 56–76 | Day & Night |
| [[Regions/Lirian\|Lirian]] | 3 | C-, B-, D+ | 56–96 | Day & Night |
| [[Regions/Haneul\|Haneul]] | 3 | D+, C+, B | 56–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01506` | Lumbaya Clockwork Sentinel Juvenile | [[Regions/Lumbaya\|Lumbaya]] | Juvenile | C- | 65 | 2.13 m | Day & Night | Like a typical Clockwork Sentinel, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_01507` | Gearholm Clockwork Sentinel Runt | [[Regions/Gearholm\|Gearholm]] | Runt | D+ | 56 | 1.75 m | Day & Night | Like a typical Clockwork Sentinel, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_01508` | Lumbaya Clockwork Sentinel Scarred | [[Regions/Lumbaya\|Lumbaya]] | Scarred | C+ | 86 | 2.75 m | Day & Night | Like a typical Clockwork Sentinel, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_01509` | Lirian Clockwork Sentinel Juvenile | [[Regions/Lirian\|Lirian]] | Juvenile | C- | 65 | 2.13 m | Day & Night | Like a typical Clockwork Sentinel, but young, with brighter colors and unworn features, with soot-stained hide and scavenged scraps. |
| `pop_01510` | Gearholm Clockwork Sentinel | [[Regions/Gearholm\|Gearholm]] | Adult | C | 76 | 2.5 m | Day & Night | A typical adult Clockwork Sentinel of this region, with soot-stained hide and scavenged scraps. |
| `pop_01511` | Lirian Clockwork Sentinel Alpha | [[Regions/Lirian\|Lirian]] | Alpha | B- | 96 | 3.13 m | Day & Night | Like a typical Clockwork Sentinel, but larger and scarred, and others of its kind follow it, with soot-stained hide and scavenged scraps. |
| `pop_01512` | Haneul Clockwork Sentinel Runt | [[Regions/Haneul\|Haneul]] | Runt | D+ | 56 | 1.75 m | Day & Night | Like a typical Clockwork Sentinel, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_01513` | Lirian Clockwork Sentinel Runt | [[Regions/Lirian\|Lirian]] | Runt | D+ | 56 | 1.75 m | Day & Night | Like a typical Clockwork Sentinel, but smaller and scrappier than usual, with soot-stained hide and scavenged scraps. |
| `pop_01514` | Lumbaya Clockwork Sentinel Albino | [[Regions/Lumbaya\|Lumbaya]] | Albino | C+ | 86 | 2.5 m | Day & Night | Like a typical Clockwork Sentinel, but a rare pale form with white skin or fur and red eyes. |
| `pop_01515` | Haneul Clockwork Sentinel Scarred | [[Regions/Haneul\|Haneul]] | Scarred | C+ | 86 | 2.75 m | Day & Night | Like a typical Clockwork Sentinel, but covered in old battle scars, with soot-stained hide and scavenged scraps. |
| `pop_01516` | Haneul Clockwork Sentinel Elderborn | [[Regions/Haneul\|Haneul]] | Elderborn | B | 108 | 3.38 m | Day & Night | Like a typical Clockwork Sentinel, but old and wise, with greying features and a cautious hunting style, with soot-stained hide and scavenged scraps. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
