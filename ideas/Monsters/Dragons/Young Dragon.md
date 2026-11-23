---
type: monster
id: mon_young_dragon
family: "Dragons"
rank: "A"
tier: core
tags: [monster, dragons]
---
# Young Dragon

![[mon_young_dragon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_young_dragon_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 19.196 × 11.999 × 8.56 m · local file `Game/Assets/_Game/Art/Models/Monsters/Dragons/mon_young_dragon.fbx`

> The Young Dragon is a huge creature with a four-legged, two-winged dragon body, about 12 m long. Its scales are rough, scarred and spiked, colored in bronze, with ember-orange markings. Survivors describe a proud crest and scales that shine like new coins. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 12 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 52956 · 772 · 713 · 772 · 713 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 6.72 m high × 12 m long × 16.92 m wide; prefab scale 1.
- **Physics:** 11923.2 kg, gravity ×1, poise 700, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 6.98 m/s, turn 173°/s, stopping distance 1.36 m.
- **Attack count:** 6; **signature:** a proud crest and scales that shine like new coins.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Young Dragon is a **menacing dragon** encountered at A rank, around level 146. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a proud crest and scales that shine like new coins. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons A|loot_draconic_a]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Dragons/Vesper-Touched Young Dragon|Vesper-Touched Young Dragon]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dragon Spine\|Dragon Spine]] | 3 | A+, S- | 159–173 | Day & Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 4 | B+, A+, A, A- | 120–159 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 4 | A+, A, B+, A- | 120–159 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01392` | Dragon Spine Young Dragon Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | A+ | 159 | 12 m | Day & Night | Like a typical Young Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_01393` | Nox Dominion Young Dragon Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | B+ | 120 | 8.4 m | Day & Night | Like a typical Young Dragon, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_01394` | Dragon Spine Young Dragon Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | A+ | 159 | 13.2 m | Day & Night | Like a typical Young Dragon, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01395` | Nox Dominion Young Dragon Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | A+ | 159 | 13.2 m | Day & Night | Like a typical Young Dragon, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_01396` | Iron Hold Young Dragon Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | A+ | 159 | 13.2 m | Day & Night | Like a typical Young Dragon, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_01397` | Nox Dominion Young Dragon | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | A | 146 | 12 m | Day & Night | A typical adult Young Dragon of this region, with ash-dark coloring with glowing cracks. |
| `pop_01398` | Iron Hold Young Dragon | [[Regions/Iron Hold\|Iron Hold]] | Adult | A | 146 | 12 m | Day & Night | A typical adult Young Dragon of this region, with slate-grey coloring and hardened hide. |
| `pop_01399` | Iron Hold Young Dragon Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | B+ | 120 | 8.4 m | Day & Night | Like a typical Young Dragon, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_01400` | Iron Hold Young Dragon Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | A- | 132 | 10.2 m | Day & Night | Like a typical Young Dragon, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_01401` | Dragon Spine Young Dragon Alpha | [[Regions/Dragon Spine\|Dragon Spine]] | Alpha | S- | 173 | 15 m | Day & Night | Like a typical Young Dragon, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_01402` | Nox Dominion Young Dragon Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | A- | 132 | 10.2 m | Day & Night | Like a typical Young Dragon, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#c79d40` `#7d6228` `#ff7a3d` · triangle-based silhouette, sharp asymmetric spikes
