---
type: monster
id: mon_greater_stone_golem
family: "Constructs & Mimics"
rank: "C"
tier: variant
tags: [monster, constructs-mimics]
---
# Greater Stone Golem

![[mon_greater_stone_golem_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_greater_stone_golem_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Greater Stone Golem is a large creature with a blocky construct body, about 4.8 m tall. Its surface is weathered and natural, colored in ochre, clay and mossy stone. Its most striking feature is a rune glowing on its back. It has dark, wary eyes. Battle-worn plates and trophies hang from its body. It stalks low to the ground, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Stone Golem\|Stone Golem]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 4.8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 14261 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/golem\|golem]] · `anim_golem` |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Motion implementation

- **Rig:** [[Systems/Rigs/golem|golem]] (rigId); animation set `anim_golem`.
- **Dimensions:** 4.8 m high × 1.44 m long × 2.02 m wide; prefab scale 1.6.
- **Physics:** 6900.9 kg, gravity ×1.32, poise 367, knockback resistance 1, death style `crumble_into_rubble`.
- **Navigation:** speed 3.66 m/s, turn 91°/s, stopping distance 1.46 m.
- **Attack count:** 5; **signature:** a rune glowing on its back.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Slam\|Slam]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ground Pound\|Ground Pound]] | aoe | 1.8 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Guard Stance\|Guard Stance]] | buff | 0 | 15 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Greater Stone Golem is a **wild construct** encountered at C rank, around level 76. Its documented behaviour is *Territorial* and its AI pattern is *territorial_guard*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a rune glowing on its back. Watch for its tell and leave a response window before committing to a long combo.

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
| [[Regions/Sunscar\|Sunscar]] | 6 | B-, D+, C+, B, C, C- | 56–108 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | C, B, C+, D+, B- | 56–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04363` | Sunscar Greater Stone Golem Alpha | [[Regions/Sunscar\|Sunscar]] | Alpha | B- | 96 | 6 m | Day & Night | Like a typical Greater Stone Golem, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_04364` | Great Labyrinth (Floors 1-40) Greater Stone Golem | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C | 76 | 4.8 m | Day & Night | A typical adult Greater Stone Golem of this region, with dust-grey coloring and old rune scars. |
| `pop_04365` | Sunscar Greater Stone Golem Runt | [[Regions/Sunscar\|Sunscar]] | Runt | D+ | 56 | 3.36 m | Day & Night | Like a typical Greater Stone Golem, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_04366` | Great Labyrinth (Floors 1-40) Greater Stone Golem Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B | 108 | 6.48 m | Day & Night | Like a typical Greater Stone Golem, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_04367` | Great Labyrinth (Floors 1-40) Greater Stone Golem Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C+ | 86 | 4.8 m | Day & Night | Like a typical Greater Stone Golem, but a rare pale form with white skin or fur and red eyes. |
| `pop_04368` | Sunscar Greater Stone Golem Scarred | [[Regions/Sunscar\|Sunscar]] | Scarred | C+ | 86 | 5.28 m | Day & Night | Like a typical Greater Stone Golem, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_04369` | Great Labyrinth (Floors 1-40) Greater Stone Golem Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D+ | 56 | 3.36 m | Day & Night | Like a typical Greater Stone Golem, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_04370` | Sunscar Greater Stone Golem Elderborn | [[Regions/Sunscar\|Sunscar]] | Elderborn | B | 108 | 6.48 m | Day & Night | Like a typical Greater Stone Golem, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_04371` | Sunscar Greater Stone Golem | [[Regions/Sunscar\|Sunscar]] | Adult | C | 76 | 4.8 m | Day & Night | A typical adult Greater Stone Golem of this region, with sun-bleached, sand-scoured coloring. |
| `pop_04372` | Great Labyrinth (Floors 1-40) Greater Stone Golem Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B- | 96 | 6 m | Day & Night | Like a typical Greater Stone Golem, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_04373` | Sunscar Greater Stone Golem Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | C- | 65 | 4.08 m | Day & Night | Like a typical Greater Stone Golem, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
