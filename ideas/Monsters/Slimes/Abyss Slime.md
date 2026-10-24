---
type: monster
id: mon_abyss_slime
family: "Slimes"
rank: "S"
tier: core
tags: [monster, slimes]
---
# Abyss Slime

![[mon_abyss_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_abyss_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,676 tris · 4.117 × 4.163 × 4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Abyss Slime is a large creature with a teardrop-shaped jelly body, about 4 m tall. Its gel is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Look for starless black jelly that swallows all light. It has no eyes at all, only a wide and patient mouth. Its regal silhouette is crowned by a halo-like ring of aura. It crawls across ceilings, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | S · 188 (173–203) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 4 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25967 · 610 · 457 · 457 · 457 · 110 |
| XP · gold | 13063 · 2293 |
| Ring | 6 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 4 m high × 3.72 m long × 3.6 m wide; prefab scale 8.
- **Physics:** 33600 kg, gravity ×1.12, poise 134, knockback resistance 0.28, death style `splat_dissolve`.
- **Navigation:** speed 10.82 m/s, turn 180°/s, stopping distance 2.2 m.
- **Attack count:** 5; **signature:** starless black jelly that swallows all light.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Null Rift\|Null Rift]] | magic | 1.5 | 10 s | Void | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Abyss Slime is a **horror ooze** encountered at S rank, around level 188. Its documented behaviour is *Passive* and its AI pattern is *passive_wander+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** starless black jelly that swallows all light. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)|Great Labyrinth (Floors 91-120)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_blob`, animation set `anim_blob`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Slimes S|loot_slime_s]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Slimes/Ruin Abyss Slime|Ruin Abyss Slime]]
- [[Monsters/Slimes/Phantom Abyss Slime|Phantom Abyss Slime]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 6 | S+, A+, SS, S-, SS- | 159–236 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | S+, S, S-, A+ | 159–203 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00133` | Great Labyrinth (Floors 91-120) Abyss Slime Albino | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Albino | S+ | 203 | 4 m | Night | Like a typical Abyss Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00134` | Great Labyrinth (Floors 91-120) Abyss Slime Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | S+ | 203 | 4.4 m | Night | Like a typical Abyss Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00135` | Great Labyrinth (Floors 41-90) Abyss Slime Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | S+ | 203 | 4 m | Night | Like a typical Abyss Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_00136` | Great Labyrinth (Floors 91-120) Abyss Slime Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | A+ | 159 | 2.8 m | Night | Like a typical Abyss Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00137` | Great Labyrinth (Floors 91-120) Abyss Slime Elderborn | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Elderborn | SS | 236 | 5.4 m | Night | Like a typical Abyss Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00138` | Great Labyrinth (Floors 41-90) Abyss Slime | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S | 188 | 4 m | Night | A typical adult Abyss Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00139` | Great Labyrinth (Floors 91-120) Abyss Slime Juvenile | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Juvenile | S- | 173 | 3.4 m | Night | Like a typical Abyss Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00140` | Great Labyrinth (Floors 41-90) Abyss Slime Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S- | 173 | 3.4 m | Night | Like a typical Abyss Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00141` | Great Labyrinth (Floors 41-90) Abyss Slime Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | A+ | 159 | 2.8 m | Night | Like a typical Abyss Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00142` | Great Labyrinth (Floors 41-90) Abyss Slime Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | S+ | 203 | 4.4 m | Night | Like a typical Abyss Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00143` | Great Labyrinth (Floors 91-120) Abyss Slime Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SS- | 218 | 5 m | Night | Like a typical Abyss Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
