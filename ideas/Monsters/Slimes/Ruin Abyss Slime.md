---
type: monster
id: mon_ruin_abyss_slime
family: "Slimes"
rank: "S+"
tier: variant
tags: [monster, slimes]
---
# Ruin Abyss Slime

![[mon_ruin_abyss_slime_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_ruin_abyss_slime_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (1,220 tris · 4.726 × 4.779 × 4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Ruin Abyss Slime is a large creature with a teardrop-shaped jelly body, about 4 m tall. Its gel is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Survivors describe starless black jelly that swallows all light. It has too many eyes, opening one after another. Its regal silhouette is crowned by a halo-like ring of aura. It unfolds into something larger, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Abyss Slime\|Abyss Slime]] (regional) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 4 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 29128 · 658 · 493 · 493 · 493 · 110 |
| XP · gold | 14769 · 2553 |
| Ring | 7 |
| Rig · animation | [[Systems/Rigs/blob\|blob]] · `anim_blob` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Motion implementation

- **Rig:** [[Systems/Rigs/blob|blob]] (rigId); animation set `anim_blob`.
- **Dimensions:** 4 m high × 3.72 m long × 3.6 m wide; prefab scale 8.
- **Physics:** 33600 kg, gravity ×1.6, poise 134, knockback resistance 0.28, death style `splat_dissolve`.
- **Navigation:** speed 12.56 m/s, turn 180°/s, stopping distance 2.2 m.
- **Attack count:** 5; **signature:** starless black jelly that swallows all light.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Body Slam\|Body Slam]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Engulf\|Engulf]] | grab | 1.4 | 8 s | None | gold | Grab cue; create distance or dodge before contact. |
| [[Attacks/Split\|Split]] | summon | 0 | 20 s | None | none | Interrupt or reposition; watch for added enemies. |
| [[Attacks/Acid Splash\|Acid Splash]] | ranged | 1.1 | 6 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Ruin Abyss Slime is a **horror ooze** encountered at S+ rank, around level 203. Its documented behaviour is *Swarm* and its AI pattern is *swarm_surround+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

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

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 7 | SS, SS-, SS+, S-, S, S+ | 173–253 | Night |
| [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | 4 | S-, SS, S+, SS- | 173–236 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03038` | Great Labyrinth (Floors 41-90) Ruin Abyss Slime Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | SS | 236 | 5 m | Night | Like a typical Ruin Abyss Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03039` | Great Labyrinth (Floors 41-90) Ruin Abyss Slime Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | SS- | 218 | 4 m | Night | Like a typical Ruin Abyss Slime, but a rare pale form with white skin or fur and red eyes. |
| `pop_03040` | Great Labyrinth (Floors 91-120) Ruin Abyss Slime Runt | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Runt | S- | 173 | 2.8 m | Night | Like a typical Ruin Abyss Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03041` | Great Labyrinth (Floors 41-90) Ruin Abyss Slime Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | SS+ | 253 | 5.4 m | Night | Like a typical Ruin Abyss Slime, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03042` | Great Labyrinth (Floors 41-90) Ruin Abyss Slime Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | S- | 173 | 2.8 m | Night | Like a typical Ruin Abyss Slime, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03043` | Great Labyrinth (Floors 41-90) Ruin Abyss Slime Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | S | 188 | 3.4 m | Night | Like a typical Ruin Abyss Slime, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03044` | Great Labyrinth (Floors 91-120) Ruin Abyss Slime Alpha | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Alpha | SS | 236 | 5 m | Night | Like a typical Ruin Abyss Slime, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03045` | Great Labyrinth (Floors 41-90) Ruin Abyss Slime | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | S+ | 203 | 4 m | Night | A typical adult Ruin Abyss Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03046` | Great Labyrinth (Floors 91-120) Ruin Abyss Slime | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Adult | S+ | 203 | 4 m | Night | A typical adult Ruin Abyss Slime of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03047` | Great Labyrinth (Floors 91-120) Ruin Abyss Slime Scarred | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] | Scarred | SS- | 218 | 4.4 m | Night | Like a typical Ruin Abyss Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03048` | Great Labyrinth (Floors 41-90) Ruin Abyss Slime Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | SS- | 218 | 4.4 m | Night | Like a typical Ruin Abyss Slime, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#292940` · broken symmetry, mimicry, audio-first reveal
