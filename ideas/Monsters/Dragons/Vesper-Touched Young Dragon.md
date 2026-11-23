---
type: monster
id: mon_vesper_touched_young_dragon
family: "Dragons"
rank: "S-"
tier: variant
tags: [monster, dragons]
---
# Vesper-Touched Young Dragon

![[mon_vesper_touched_young_dragon_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_young_dragon_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 30,000 tris · 19.201 × 12 × 8.561 m · local file `Game/Assets/_Game/Art/Models/Monsters/Dragons/mon_vesper_touched_young_dragon.fbx`

> The Vesper-Touched Young Dragon is a huge creature with a vast quadruped dragon frame with cathedral wings, about 12 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in bronze, with ember-orange markings. Guild sketches always show a proud crest and scales that shine like new coins. It has pale, pupil-less eyes. Its regal silhouette is crowned by a halo-like ring of aura. It glides without moving its legs, surrounded by heat-shimmer and drifting sparks. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Young Dragon\|Young Dragon]] (corrupted) |
| Rank · level | S- · 173 (159–188) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 12 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 68247 · 913 · 842 · 913 · 842 · 100 |
| XP · gold | 11437 · 2042 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Water. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 6.72 m high × 12 m long × 16.92 m wide; prefab scale 1.
- **Physics:** 11923.2 kg, gravity ×1, poise 760, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 6.64 m/s, turn 173°/s, stopping distance 1.36 m.
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

Vesper-Touched Young Dragon is a **dread dragon** encountered at S- rank, around level 173. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a proud crest and scales that shine like new coins. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Dragon Spine|Dragon Spine]], [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons S|loot_draconic_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Dragon Spine\|Dragon Spine]] | 5 | S+, S, SS-, A+ | 159–218 | Night |
| [[Regions/Nox Dominion\|Nox Dominion]] | 6 | SS-, A+, S, A, S+ | 146–218 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_04285` | Dragon Spine Vesper-Touched Young Dragon Alpha | [[Regions/Dragon Spine\|Dragon Spine]] | Alpha | S+ | 203 | 15 m | Night | Like a typical Vesper-Touched Young Dragon, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_04286` | Nox Dominion Vesper-Touched Young Dragon Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | SS- | 218 | 16.2 m | Night | Like a typical Vesper-Touched Young Dragon, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |
| `pop_04287` | Nox Dominion Vesper-Touched Young Dragon Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | A+ | 159 | 10.2 m | Night | Like a typical Vesper-Touched Young Dragon, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |
| `pop_04288` | Dragon Spine Vesper-Touched Young Dragon Albino | [[Regions/Dragon Spine\|Dragon Spine]] | Albino | S | 188 | 12 m | Night | Like a typical Vesper-Touched Young Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_04289` | Dragon Spine Vesper-Touched Young Dragon Elderborn | [[Regions/Dragon Spine\|Dragon Spine]] | Elderborn | SS- | 218 | 16.2 m | Night | Like a typical Vesper-Touched Young Dragon, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_04290` | Nox Dominion Vesper-Touched Young Dragon Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | S | 188 | 12 m | Night | Like a typical Vesper-Touched Young Dragon, but a rare pale form with white skin or fur and red eyes. |
| `pop_04291` | Nox Dominion Vesper-Touched Young Dragon Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | A | 146 | 8.4 m | Night | Like a typical Vesper-Touched Young Dragon, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_04292` | Dragon Spine Vesper-Touched Young Dragon Juvenile | [[Regions/Dragon Spine\|Dragon Spine]] | Juvenile | A+ | 159 | 10.2 m | Night | Like a typical Vesper-Touched Young Dragon, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_04293` | Dragon Spine Vesper-Touched Young Dragon Scarred | [[Regions/Dragon Spine\|Dragon Spine]] | Scarred | S | 188 | 13.2 m | Night | Like a typical Vesper-Touched Young Dragon, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_04294` | Nox Dominion Vesper-Touched Young Dragon Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | S | 188 | 13.2 m | Night | Like a typical Vesper-Touched Young Dragon, but covered in old battle scars, with ash-dark coloring with glowing cracks. |
| `pop_04295` | Nox Dominion Vesper-Touched Young Dragon Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | S+ | 203 | 15 m | Night | Like a typical Vesper-Touched Young Dragon, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `embers_heat_haze` · palette `#c5913f` `#7c5a27` `#ff7a3d` · elongated, irregular silhouette; still-then-sudden timing
