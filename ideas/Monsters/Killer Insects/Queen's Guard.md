---
type: monster
id: mon_queen_s_guard
family: "Killer Insects"
rank: "C"
tier: core
tags: [monster, killer-insects]
---
# Queen's Guard

> The Queen's Guard is a person-sized creature with a segmented six-limbed frame, about 2 m long. Its chitin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Look for a shield-shaped head plate. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10652 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Wind. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 0.66 m high × 2 m long × 1.02 m wide; prefab scale 2.5.
- **Physics:** 457.6 kg, gravity ×1.54, poise 179, knockback resistance 0.49, death style `flip_legs_curl`.
- **Navigation:** speed 4.92 m/s, turn 354°/s, stopping distance 0.68 m.
- **Attack count:** 5; **signature:** a shield-shaped head plate.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Swarm Bite\|Swarm Bite]] | aoe | 0.9 | 6 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Queen's Guard is a **menacing insectoid** encountered at C rank, around level 76. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a shield-shaped head plate. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Killer Insects C|loot_killer_insect_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Ancient Queen's Guard|Ancient Queen's Guard]]
- [[Monsters/Killer Insects/Deep Queen's Guard|Deep Queen's Guard]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | B, C-, D+, C, C+ | 56–108 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | C-, C+ | 65–86 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 3 | B-, C-, B | 65–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00774` | Great Labyrinth (Floors 1-40) Queen's Guard Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B | 108 | 2.7 m | Day & Night | Like a typical Queen's Guard, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00775` | Great Labyrinth (Floors 41-90) Queen's Guard Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C- | 65 | 1.7 m | Day & Night | Like a typical Queen's Guard, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00776` | Great Labyrinth (Floors 1-40) Queen's Guard Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C- | 65 | 1.7 m | Day & Night | Like a typical Queen's Guard, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00777` | Great Labyrinth (Floors 41-90) Queen's Guard Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C+ | 86 | 2.2 m | Day & Night | Like a typical Queen's Guard, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00778` | Umbravel Queen's Guard Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | B- | 96 | 2.5 m | Day & Night | Like a typical Queen's Guard, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_00779` | Great Labyrinth (Floors 1-40) Queen's Guard Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D+ | 56 | 1.4 m | Day & Night | Like a typical Queen's Guard, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00780` | Great Labyrinth (Floors 41-90) Queen's Guard Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | C+ | 86 | 2 m | Day & Night | Like a typical Queen's Guard, but a rare pale form with white skin or fur and red eyes. |
| `pop_00781` | Umbravel Queen's Guard Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | C- | 65 | 1.7 m | Day & Night | Like a typical Queen's Guard, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_00782` | Great Labyrinth (Floors 1-40) Queen's Guard | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C | 76 | 2 m | Day & Night | A typical adult Queen's Guard of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00783` | Umbravel Queen's Guard Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | B | 108 | 2.7 m | Day & Night | Like a typical Queen's Guard, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_00784` | Great Labyrinth (Floors 1-40) Queen's Guard Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C+ | 86 | 2 m | Day & Night | Like a typical Queen's Guard, but a rare pale form with white skin or fur and red eyes. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
