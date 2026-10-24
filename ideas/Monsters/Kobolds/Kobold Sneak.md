---
type: monster
id: mon_kobold_sneak
family: "Kobolds"
rank: "E"
tier: core
tags: [monster, kobolds]
---
# Kobold Sneak

![[mon_kobold_sneak_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kobold_sneak_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,730 tris · 0.396 × 0.466 × 0.8 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Kobold Sneak is a small creature with a small, compact humanoid body, about 0.8 m tall. Its mangy fur is rough, scarred and spiked, colored in ink black with bruised violet. Survivors describe soot-blackened fur for hiding in tunnels. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 0.8 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 992 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Light. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.8 m high × 0.24 m long × 0.32 m wide; prefab scale 0.727.
- **Physics:** 8.2 kg, gravity ×1.5, poise 29, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 5.45 m/s, turn 470°/s, stopping distance 0.56 m.
- **Attack count:** 5; **signature:** soot-blackened fur for hiding in tunnels.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Kobold Sneak is a **menacing humanoid** encountered at E rank, around level 26. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** soot-blackened fur for hiding in tunnels. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds E|loot_kobold_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Kobolds/Snow Kobold Sneak|Snow Kobold Sneak]]
- [[Monsters/Kobolds/Phantom Kobold Sneak|Phantom Kobold Sneak]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | D-, E+, E, D, E- | 19–48 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | E, E+, D- | 26–40 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | F+, D- | 13–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00310` | Whisperwood Kobold Sneak Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 1 m | Day & Night | Like a typical Kobold Sneak, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00311` | Whisperwood Kobold Sneak Albino | [[Regions/Whisperwood\|Whisperwood]] | Albino | E+ | 32 | 0.8 m | Day & Night | Like a typical Kobold Sneak, but a rare pale form with white skin or fur and red eyes. |
| `pop_00312` | Whisperwood Kobold Sneak | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 0.8 m | Day & Night | A typical adult Kobold Sneak of this region, with dust-grey coloring and old rune scars. |
| `pop_00313` | Great Labyrinth (Floors 1-40) Kobold Sneak | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E | 26 | 0.8 m | Day & Night | A typical adult Kobold Sneak of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00314` | Whisperwood Kobold Sneak Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | D | 48 | 1.08 m | Day & Night | Like a typical Kobold Sneak, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00315` | Great Labyrinth (Floors 1-40) Kobold Sneak Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E+ | 32 | 0.8 m | Day & Night | Like a typical Kobold Sneak, but a rare pale form with white skin or fur and red eyes. |
| `pop_00316` | Great Labyrinth (Floors 1-40) Kobold Sneak Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E+ | 32 | 0.88 m | Day & Night | Like a typical Kobold Sneak, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00317` | Aldmere Kobold Sneak Runt | [[Regions/Aldmere\|Aldmere]] | Runt | F+ | 13 | 0.56 m | Day & Night | Like a typical Kobold Sneak, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_00318` | Whisperwood Kobold Sneak Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 0.68 m | Day & Night | Like a typical Kobold Sneak, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00319` | Great Labyrinth (Floors 1-40) Kobold Sneak Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D- | 40 | 1 m | Day & Night | Like a typical Kobold Sneak, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00320` | Aldmere Kobold Sneak Alpha | [[Regions/Aldmere\|Aldmere]] | Alpha | D- | 40 | 1 m | Day & Night | Like a typical Kobold Sneak, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
