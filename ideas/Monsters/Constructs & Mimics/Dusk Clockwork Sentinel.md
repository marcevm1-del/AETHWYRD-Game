---
type: monster
id: mon_dusk_clockwork_sentinel
family: "Constructs & Mimics"
rank: "C+"
tier: variant
tags: [monster, constructs-mimics]
---
# Dusk Clockwork Sentinel

![[mon_dusk_clockwork_sentinel_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dusk_clockwork_sentinel_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Dusk Clockwork Sentinel is a large creature with a heavy, hand-built humanoid shell, about 2.5 m tall. Its surface is rough, scarred and spiked, colored in ink black with bruised violet. Look for brass gears visible through its ribs. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by shadows that lean toward it. This Dark-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Clockwork Sentinel\|Clockwork Sentinel]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13814 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 2.5 m high × 0.75 m long × 1.05 m wide; prefab scale 0.833.
- **Physics:** 750 kg, gravity ×1.2, poise 265, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 3.48 m/s, turn 126°/s, stopping distance 0.95 m.
- **Attack count:** 5; **signature:** brass gears visible through its ribs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dusk Clockwork Sentinel is a **menacing construct** encountered at C+ rank, around level 86. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** brass gears visible through its ribs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Sunscar|Sunscar]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_golem`, animation set `anim_golem`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics C|loot_construct_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sunscar\|Sunscar]] | 5 | C, B, B-, B+ | 76–120 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | C, B+, B, C-, B-, C+ | 65–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04385` | Sunscar Dusk Clockwork Sentinel Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | C | 76 | 2.13 m | Day & Night | Like a typical Dusk Clockwork Sentinel, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_04386` | Sunscar Dusk Clockwork Sentinel Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | B | 108 | 3.13 m | Day & Night | Like a typical Dusk Clockwork Sentinel, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_04387` | Great Labyrinth (Floors 1-40) Dusk Clockwork Sentinel Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C | 76 | 2.13 m | Day & Night | Like a typical Dusk Clockwork Sentinel, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_04388` | Great Labyrinth (Floors 1-40) Dusk Clockwork Sentinel Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B+ | 120 | 3.38 m | Day & Night | Like a typical Dusk Clockwork Sentinel, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04389` | Sunscar Dusk Clockwork Sentinel Albino | [[Regions/Sunscar\|Sunscar]] | Albino | B- | 96 | 2.5 m | Day & Night | Like a typical Dusk Clockwork Sentinel, but a rare pale form with white skin or fur and red eyes. |
| `pop_04390` | Great Labyrinth (Floors 1-40) Dusk Clockwork Sentinel Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B | 108 | 3.13 m | Day & Night | Like a typical Dusk Clockwork Sentinel, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04391` | Great Labyrinth (Floors 1-40) Dusk Clockwork Sentinel Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | C- | 65 | 1.75 m | Day & Night | Like a typical Dusk Clockwork Sentinel, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04392` | Sunscar Dusk Clockwork Sentinel Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | B- | 96 | 2.75 m | Day & Night | Like a typical Dusk Clockwork Sentinel, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_04393` | Sunscar Dusk Clockwork Sentinel Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | B+ | 120 | 3.38 m | Day & Night | Like a typical Dusk Clockwork Sentinel, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_04394` | Great Labyrinth (Floors 1-40) Dusk Clockwork Sentinel Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | B- | 96 | 2.75 m | Day & Night | Like a typical Dusk Clockwork Sentinel, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_04395` | Great Labyrinth (Floors 1-40) Dusk Clockwork Sentinel | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C+ | 86 | 2.5 m | Day & Night | A typical adult Dusk Clockwork Sentinel of this region, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
