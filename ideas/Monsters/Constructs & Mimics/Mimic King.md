---
type: monster
id: mon_mimic_king
family: "Constructs & Mimics"
rank: "A"
tier: core
tags: [monster, constructs-mimics]
---
# Mimic King

![[mon_mimic_king_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_mimic_king_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 6.582 × 7.597 × 6 m · local file `Game/Assets/_Game/Art/Models/Monsters/Constructs & Mimics/mon_mimic_king.fbx`

> The Mimic King is a huge creature with a disguised body pretending to be furniture, about 6 m tall. Its surface is stretched, stitched and constantly shifting, colored in riveted iron. Its most striking feature is a treasure vault that walks on a hundred stolen legs. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It crawls across ceilings. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | A · 146 (132–159) |
| Menace | 5 · Horror |
| Element · weakness | None · Fire |
| Size | 6 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 28899 · 743 · 535 · 374 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/amorphous\|amorphous]] · `anim_mimic` |
| Habitats | [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Sunscar\|Sunscar]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/amorphous|amorphous]] (rigId); animation set `anim_mimic`.
- **Dimensions:** 6 m high × 6.43 m long × 6.3 m wide; prefab scale 3.
- **Physics:** 6480 kg, gravity ×1.2, poise 597, knockback resistance 0.75, death style `collapse_and_melt`.
- **Navigation:** speed 10.25 m/s, turn 204°/s, stopping distance 2.2 m.
- **Attack count:** 4; **signature:** a treasure vault that walks on a hundred stolen legs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Chomp\|Chomp]] | melee | 1.6 | 0 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Tongue Lash\|Tongue Lash]] | grab | 1.4 | 6 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Disguise\|Disguise]] | stealth | 0 | 20 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Rune Pulse\|Rune Pulse]] | magic | 1.3 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Mimic King is a **horror construct** encountered at A rank, around level 146. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a treasure vault that walks on a hundred stolen legs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Aurumdeep|Aurumdeep]], [[Regions/Sunscar|Sunscar]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Sky Archipelago|Sky Archipelago]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_mimic`, animation set `anim_mimic`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Constructs & Mimics A|loot_construct_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Elder Mimic King|Elder Mimic King]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Sky Archipelago\|Sky Archipelago]] | 3 | A, A-, A+ | 132–159 | Night |
| [[Regions/Sunscar\|Sunscar]] | 2 | A-, B+ | 120–132 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | B+, S-, S | 120–188 | Night |
| [[Regions/Zarvan\|Zarvan]] | 3 | S-, A+, S | 159–188 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01539` | Sky Archipelago Mimic King | [[Regions/Sky Archipelago\|Sky Archipelago]] | Adult | A | 146 | 6 m | Night | A typical adult Mimic King of this region, with cloud-pale coloring and lighter bones. |
| `pop_01540` | Sunscar Mimic King Juvenile | [[Regions/Sunscar\|Sunscar]] | Juvenile | A- | 132 | 5.1 m | Night | Like a typical Mimic King, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_01541` | Sky Archipelago Mimic King Juvenile | [[Regions/Sky Archipelago\|Sky Archipelago]] | Juvenile | A- | 132 | 5.1 m | Night | Like a typical Mimic King, but young, with brighter colors and unworn features, with cloud-pale coloring and lighter bones. |
| `pop_01542` | Sky Archipelago Mimic King Albino | [[Regions/Sky Archipelago\|Sky Archipelago]] | Albino | A+ | 159 | 6 m | Night | Like a typical Mimic King, but a rare pale form with white skin or fur and red eyes. |
| `pop_01543` | Great Labyrinth (Floors 41-90) Mimic King Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | B+ | 120 | 4.2 m | Night | Like a typical Mimic King, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_01544` | Zarvan Mimic King Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | S- | 173 | 7.5 m | Night | Like a typical Mimic King, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_01545` | Zarvan Mimic King Albino | [[Regions/Zarvan\|Zarvan]] | Albino | A+ | 159 | 6 m | Night | Like a typical Mimic King, but a rare pale form with white skin or fur and red eyes. |
| `pop_01546` | Great Labyrinth (Floors 41-90) Mimic King Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | S- | 173 | 7.5 m | Night | Like a typical Mimic King, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_01547` | Great Labyrinth (Floors 41-90) Mimic King Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | S | 188 | 8.1 m | Night | Like a typical Mimic King, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_01548` | Sunscar Mimic King Runt | [[Regions/Sunscar\|Sunscar]] | Runt | B+ | 120 | 4.2 m | Night | Like a typical Mimic King, but smaller and scrappier than usual, with sun-bleached, sand-scoured coloring. |
| `pop_01549` | Zarvan Mimic King Elderborn | [[Regions/Zarvan\|Zarvan]] | Elderborn | S | 188 | 8.1 m | Night | Like a typical Mimic King, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#737a82` `#50565d` `#9aa2ae` · broken symmetry, mimicry, audio-first reveal
