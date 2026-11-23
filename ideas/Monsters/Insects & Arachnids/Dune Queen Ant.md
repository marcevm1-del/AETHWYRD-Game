---
type: monster
id: mon_dune_queen_ant
family: "Insects & Arachnids"
rank: "C+"
tier: variant
tags: [monster, insects-arachnids]
---
# Dune Queen Ant

![[mon_dune_queen_ant_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_dune_queen_ant_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 20,000 tris · 3.13 × 3.5 × 1.825 m · local file `Game/Assets/_Game/Art/Models/Monsters/Insects & Arachnids/mon_dune_queen_ant.fbx`

> The Dune Queen Ant is a large creature with a six-legged armored body, about 3.5 m long. Its chitin is rough, scarred and spiked, colored in glossy brown, with ochre markings. Survivors describe a swollen abdomen pulsing with eggs. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by pebbles that tremble and float near it. Adapted to desert lands, it has sun-bleached, sand-scoured coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Queen Ant\|Queen Ant]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 3.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15468 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/hexapod\|hexapod]] · `anim_hexapod` |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Dunewhale Drift\|Dunewhale Drift]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/hexapod|hexapod]] (rigId); animation set `anim_hexapod`.
- **Dimensions:** 1.16 m high × 3.5 m long × 1.78 m wide; prefab scale 4.375.
- **Physics:** 2452.5 kg, gravity ×1.54, poise 425, knockback resistance 0.49, death style `flip_legs_curl`.
- **Navigation:** speed 6.82 m/s, turn 267°/s, stopping distance 0.89 m.
- **Attack count:** 5; **signature:** a swollen abdomen pulsing with eggs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Mandible Crush\|Mandible Crush]] | melee | 1.1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Burrow Ambush\|Burrow Ambush]] | dash | 1.5 | 10 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Acid Spray\|Acid Spray]] | ranged | 1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Silk Snare\|Silk Snare]] | ranged | 0.4 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Dune Queen Ant is a **menacing insectoid** encountered at C+ rank, around level 86. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a swollen abdomen pulsing with eggs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Zaruma|Zaruma]], [[Regions/Dunewhale Drift|Dunewhale Drift]], [[Regions/Zarvan|Zarvan]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_hexapod`, animation set `anim_hexapod`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Insects & Arachnids C|loot_insect_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Zarvan\|Zarvan]] | 4 | B-, B, C+ | 86–108 | Day & Night |
| [[Regions/Zaruma\|Zaruma]] | 4 | C-, B+, B-, C+ | 65–120 | Day & Night |
| [[Regions/Dunewhale Drift\|Dunewhale Drift]] | 3 | B+, C, C+ | 76–120 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03573` | Zarvan Dune Queen Ant Scarred | [[Regions/Zarvan\|Zarvan]] | Scarred | B- | 96 | 3.85 m | Day & Night | Like a typical Dune Queen Ant, but covered in old battle scars, with sun-bleached, sand-scoured coloring. |
| `pop_03574` | Zarvan Dune Queen Ant Albino | [[Regions/Zarvan\|Zarvan]] | Albino | B- | 96 | 3.5 m | Day & Night | Like a typical Dune Queen Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_03575` | Zaruma Dune Queen Ant Runt | [[Regions/Zaruma\|Zaruma]] | Runt | C- | 65 | 2.45 m | Day & Night | Like a typical Dune Queen Ant, but smaller and scrappier than usual, with golden, grass-toned coloring. |
| `pop_03576` | Dunewhale Drift Dune Queen Ant Elderborn | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Elderborn | B+ | 120 | 4.73 m | Day & Night | Like a typical Dune Queen Ant, but old and wise, with greying features and a cautious hunting style, with sun-bleached, sand-scoured coloring. |
| `pop_03577` | Zarvan Dune Queen Ant Alpha | [[Regions/Zarvan\|Zarvan]] | Alpha | B | 108 | 4.38 m | Day & Night | Like a typical Dune Queen Ant, but larger and scarred, and others of its kind follow it, with sun-bleached, sand-scoured coloring. |
| `pop_03578` | Zaruma Dune Queen Ant Elderborn | [[Regions/Zaruma\|Zaruma]] | Elderborn | B+ | 120 | 4.73 m | Day & Night | Like a typical Dune Queen Ant, but old and wise, with greying features and a cautious hunting style, with golden, grass-toned coloring. |
| `pop_03579` | Dunewhale Drift Dune Queen Ant Juvenile | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Juvenile | C | 76 | 2.98 m | Day & Night | Like a typical Dune Queen Ant, but young, with brighter colors and unworn features, with sun-bleached, sand-scoured coloring. |
| `pop_03580` | Zaruma Dune Queen Ant Albino | [[Regions/Zaruma\|Zaruma]] | Albino | B- | 96 | 3.5 m | Day & Night | Like a typical Dune Queen Ant, but a rare pale form with white skin or fur and red eyes. |
| `pop_03581` | Zarvan Dune Queen Ant | [[Regions/Zarvan\|Zarvan]] | Adult | C+ | 86 | 3.5 m | Day & Night | A typical adult Dune Queen Ant of this region, with sun-bleached, sand-scoured coloring. |
| `pop_03582` | Zaruma Dune Queen Ant | [[Regions/Zaruma\|Zaruma]] | Adult | C+ | 86 | 3.5 m | Day & Night | A typical adult Dune Queen Ant of this region, with golden, grass-toned coloring. |
| `pop_03583` | Dunewhale Drift Dune Queen Ant | [[Regions/Dunewhale Drift\|Dunewhale Drift]] | Adult | C+ | 86 | 3.5 m | Day & Night | A typical adult Dune Queen Ant of this region, with sun-bleached, sand-scoured coloring. |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#834834` `#542f22` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
