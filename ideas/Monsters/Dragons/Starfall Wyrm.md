---
type: monster
id: mon_starfall_wyrm
family: "Dragons"
rank: "SSS"
tier: core
tags: [monster, dragons]
---
# Starfall Wyrm

![[mon_starfall_wyrm_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_starfall_wyrm_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (3,178 tris · 58.484 × 60 × 36.641 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Starfall Wyrm is a colossal creature with a four-legged, two-winged dragon body, about 60 m long. Its scales are rough, scarred and spiked, colored in emerald, with gold markings. Look for scales flecked with fallen starmetal that glitter like a night sky. It has narrow glowing eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It strides with heavy steps, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Rank · level | SSS · 281 (267–294) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 60 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 204977 · 1474 · 1361 · 1474 · 1361 · 100 |
| XP · gold | 24842 · 4024 |
| Ring | 8 |
| Rig · animation | [[Systems/Rigs/dragon\|dragon]] · `anim_dragon` |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Dark. Protects something nearby: a nest, a treasure, or a place.

## Motion implementation

- **Rig:** [[Systems/Rigs/dragon|dragon]] (rigId); animation set `anim_dragon`.
- **Dimensions:** 33.6 m high × 60 m long × 84.6 m wide; prefab scale 5.
- **Physics:** 1415880 kg, gravity ×0.9, poise 1968, knockback resistance 1, death style `cinematic_collapse`.
- **Navigation:** speed 14.86 m/s, turn 77°/s, stopping distance 5.2 m.
- **Attack count:** 6; **signature:** scales flecked with fallen starmetal that glitter like a night sky.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Claw\|Claw]] | melee | 1.4 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Breath\|Breath]] | aoe | 2.2 | 14 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Gust\|Wing Gust]] | aoe | 1 | 10 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Tail Blade\|Tail Blade]] | melee | 1.8 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Wing Buffet\|Wing Buffet]] | aoe | 1.1 | 9 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Radiant Pulse\|Radiant Pulse]] | magic | 1.5 | 10 s | Light | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Starfall Wyrm is a **menacing dragon** encountered at SSS rank, around level 281. Its documented behaviour is *Guardian* and its AI pattern is *guardian_hold*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Dark**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** scales flecked with fallen starmetal that glitter like a night sky. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Nox Dominion|Nox Dominion]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_dragon`, animation set `anim_dragon`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Dragons SSS|loot_draconic_sss]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Dragons/Greater Starfall Wyrm|Greater Starfall Wyrm]]

## Regional populations (7)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Nox Dominion\|Nox Dominion]] | 7 | EX, EX-, SSS+, SSS-, SSS, SS+ | 253–300 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_01425` | Nox Dominion Starfall Wyrm Elderborn | [[Regions/Nox Dominion\|Nox Dominion]] | Elderborn | EX | 300 | 81 m | Day & Night | Like a typical Starfall Wyrm, but old and wise, with greying features and a cautious hunting style, with ash-dark coloring with glowing cracks. |
| `pop_01426` | Nox Dominion Starfall Wyrm Alpha | [[Regions/Nox Dominion\|Nox Dominion]] | Alpha | EX- | 300 | 75 m | Day & Night | Like a typical Starfall Wyrm, but larger and scarred, and others of its kind follow it, with ash-dark coloring with glowing cracks. |
| `pop_01427` | Nox Dominion Starfall Wyrm Albino | [[Regions/Nox Dominion\|Nox Dominion]] | Albino | SSS+ | 294 | 60 m | Day & Night | Like a typical Starfall Wyrm, but a rare pale form with white skin or fur and red eyes. |
| `pop_01428` | Nox Dominion Starfall Wyrm Juvenile | [[Regions/Nox Dominion\|Nox Dominion]] | Juvenile | SSS- | 267 | 51 m | Day & Night | Like a typical Starfall Wyrm, but young, with brighter colors and unworn features, with ash-dark coloring with glowing cracks. |
| `pop_01429` | Nox Dominion Starfall Wyrm | [[Regions/Nox Dominion\|Nox Dominion]] | Adult | SSS | 281 | 60 m | Day & Night | A typical adult Starfall Wyrm of this region, with ash-dark coloring with glowing cracks. |
| `pop_01430` | Nox Dominion Starfall Wyrm Runt | [[Regions/Nox Dominion\|Nox Dominion]] | Runt | SS+ | 253 | 42 m | Day & Night | Like a typical Starfall Wyrm, but smaller and scrappier than usual, with ash-dark coloring with glowing cracks. |
| `pop_01431` | Nox Dominion Starfall Wyrm Scarred | [[Regions/Nox Dominion\|Nox Dominion]] | Scarred | SSS+ | 294 | 66 m | Day & Night | Like a typical Starfall Wyrm, but covered in old battle scars, with ash-dark coloring with glowing cracks. |

## Design recipe

Rig `rig_dragon` · mesh `dragon_base` · material `dragon_scale` · VFX `holy_motes` · palette `#3f7d3b` `#2d5429` `#ffd166` · triangle-based silhouette, sharp asymmetric spikes
