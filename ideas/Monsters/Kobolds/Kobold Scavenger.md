---
type: monster
id: mon_kobold_scavenger
family: "Kobolds"
rank: "F"
tier: core
tags: [monster, kobolds]
---
# Kobold Scavenger

![[mon_kobold_scavenger_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kobold_scavenger_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.551 × 1.226 × 0.9 m · local file `Game/Assets/_Game/Art/Models/Monsters/Kobolds/mon_kobold_scavenger.fbx`

> The Kobold Scavenger is a small creature with a hunched, wiry humanoid frame, about 0.9 m tall. Its mangy fur is rough, scarred and spiked, colored in slate-blue. Guild sketches always show a dog-like head with a chipped snout and a sack of stolen tools. It has eyes that catch torchlight like coins. It has no ornament at all: simple, readable shapes. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | F · 8 (3–13) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 0.9 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 217 · 42 · 34 · 21 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.9 m high × 0.27 m long × 0.36 m wide; prefab scale 0.818.
- **Physics:** 11.7 kg, gravity ×1.5, poise 27, knockback resistance 0.15, death style `ragdoll_crumple`.
- **Navigation:** speed 5.51 m/s, turn 443°/s, stopping distance 0.58 m.
- **Attack count:** 4; **signature:** a dog-like head with a chipped snout and a sack of stolen tools.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Kobold Scavenger is a **menacing humanoid** encountered at F rank, around level 8. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dog-like head with a chipped snout and a sack of stolen tools. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds F|loot_kobold_f]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Kobolds/Kobold Scavenger Veteran|Kobold Scavenger Veteran]]
- [[Monsters/Kobolds/Phantom Kobold Scavenger|Phantom Kobold Scavenger]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E-, E, F, F-, F+ | 3–26 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | F-, F+, E, E- | 3–26 | Day & Night |
| [[Regions/Aldmere\|Aldmere]] | 2 | F+, F- | 3–13 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00288` | Whisperwood Kobold Scavenger Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | E- | 19 | 1.13 m | Day & Night | Like a typical Kobold Scavenger, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_00289` | Great Labyrinth (Floors 1-40) Kobold Scavenger Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F- | 3 | 0.63 m | Day & Night | Like a typical Kobold Scavenger, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00290` | Whisperwood Kobold Scavenger Elderborn | [[Regions/Whisperwood\|Whisperwood]] | Elderborn | E | 26 | 1.22 m | Day & Night | Like a typical Kobold Scavenger, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_00291` | Whisperwood Kobold Scavenger | [[Regions/Whisperwood\|Whisperwood]] | Adult | F | 8 | 0.9 m | Day & Night | A typical adult Kobold Scavenger of this region, with dust-grey coloring and old rune scars. |
| `pop_00292` | Great Labyrinth (Floors 1-40) Kobold Scavenger Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | F+ | 13 | 0.9 m | Day & Night | Like a typical Kobold Scavenger, but a rare pale form with white skin or fur and red eyes. |
| `pop_00293` | Aldmere Kobold Scavenger Scarred | [[Regions/Aldmere\|Aldmere]] | Scarred | F+ | 13 | 0.99 m | Day & Night | Like a typical Kobold Scavenger, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_00294` | Great Labyrinth (Floors 1-40) Kobold Scavenger Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | E | 26 | 1.22 m | Day & Night | Like a typical Kobold Scavenger, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00295` | Great Labyrinth (Floors 1-40) Kobold Scavenger Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | E- | 19 | 1.13 m | Day & Night | Like a typical Kobold Scavenger, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00296` | Whisperwood Kobold Scavenger Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | F- | 3 | 0.77 m | Day & Night | Like a typical Kobold Scavenger, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00297` | Aldmere Kobold Scavenger Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | F- | 3 | 0.77 m | Day & Night | Like a typical Kobold Scavenger, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_00298` | Whisperwood Kobold Scavenger Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | F+ | 13 | 0.99 m | Day & Night | Like a typical Kobold Scavenger, but covered in old battle scars, with dust-grey coloring and old rune scars. |

## Contracts and story encounters

- [[Quests/The Tally of the Lost|The Tally of the Lost]] — rank E, in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]
- [[Quests/Weekly Board/Warren Salvage Run|Warren Salvage Run]] — rank undefined, in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `dust_puffs` · palette `#57728c` `#394a5d` `#8ab1de` · triangle-based silhouette, sharp asymmetric spikes
