---
type: monster
id: mon_kobold_scavenger_veteran
family: "Kobolds"
rank: "E"
tier: variant
tags: [monster, kobolds]
---
# Kobold Scavenger Veteran

![[mon_kobold_scavenger_veteran_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kobold_scavenger_veteran_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 11,994 tris · 0.973 × 1.779 × 1.4 m · local file `Game/Assets/_Game/Art/Models/Monsters/Kobolds/mon_kobold_scavenger_veteran.fbx`

> The Kobold Scavenger Veteran is a person-sized creature with a scrawny biped with long arms and bowed legs, about 1.4 m tall. Its mangy fur is rough, scarred and spiked, colored in slate-blue. Survivors describe a dog-like head with a chipped snout and a sack of stolen tools. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It circles its prey. It has no visible aura; you hear its breathing before you see it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Scavenger\|Kobold Scavenger]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.4 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1191 · 114 · 91 · 56 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.4 m high × 0.42 m long × 0.56 m wide; prefab scale 1.273.
- **Physics:** 43.9 kg, gravity ×1.5, poise 39, knockback resistance 0.18, death style `ragdoll_crumple`.
- **Navigation:** speed 6.87 m/s, turn 355°/s, stopping distance 0.68 m.
- **Attack count:** 4; **signature:** a dog-like head with a chipped snout and a sack of stolen tools.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Kobold Scavenger Veteran is a **menacing humanoid** encountered at E rank, around level 26. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a dog-like head with a chipped snout and a sack of stolen tools. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood|Whisperwood]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds E|loot_kobold_e]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Whisperwood\|Whisperwood]] | 5 | E-, E+, F+, D-, E | 13–40 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 6 | E, E+, E-, D-, F+ | 13–40 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03192` | Whisperwood Kobold Scavenger Veteran Juvenile | [[Regions/Whisperwood\|Whisperwood]] | Juvenile | E- | 19 | 1.19 m | Day & Night | Like a typical Kobold Scavenger Veteran, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03193` | Great Labyrinth (Floors 1-40) Kobold Scavenger Veteran | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | E | 26 | 1.4 m | Day & Night | A typical adult Kobold Scavenger Veteran of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03194` | Whisperwood Kobold Scavenger Veteran Scarred | [[Regions/Whisperwood\|Whisperwood]] | Scarred | E+ | 32 | 1.54 m | Day & Night | Like a typical Kobold Scavenger Veteran, but covered in old battle scars, with dust-grey coloring and old rune scars. |
| `pop_03195` | Great Labyrinth (Floors 1-40) Kobold Scavenger Veteran Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | E+ | 32 | 1.54 m | Day & Night | Like a typical Kobold Scavenger Veteran, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03196` | Whisperwood Kobold Scavenger Veteran Runt | [[Regions/Whisperwood\|Whisperwood]] | Runt | F+ | 13 | 0.98 m | Day & Night | Like a typical Kobold Scavenger Veteran, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |
| `pop_03197` | Great Labyrinth (Floors 1-40) Kobold Scavenger Veteran Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | E- | 19 | 1.19 m | Day & Night | Like a typical Kobold Scavenger Veteran, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03198` | Whisperwood Kobold Scavenger Veteran Alpha | [[Regions/Whisperwood\|Whisperwood]] | Alpha | D- | 40 | 1.75 m | Day & Night | Like a typical Kobold Scavenger Veteran, but larger and scarred, and others of its kind follow it, with dust-grey coloring and old rune scars. |
| `pop_03199` | Whisperwood Kobold Scavenger Veteran | [[Regions/Whisperwood\|Whisperwood]] | Adult | E | 26 | 1.4 m | Day & Night | A typical adult Kobold Scavenger Veteran of this region, with dust-grey coloring and old rune scars. |
| `pop_03200` | Great Labyrinth (Floors 1-40) Kobold Scavenger Veteran Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | E+ | 32 | 1.4 m | Day & Night | Like a typical Kobold Scavenger Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_03201` | Great Labyrinth (Floors 1-40) Kobold Scavenger Veteran Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | D- | 40 | 1.75 m | Day & Night | Like a typical Kobold Scavenger Veteran, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03202` | Great Labyrinth (Floors 1-40) Kobold Scavenger Veteran Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | F+ | 13 | 0.98 m | Day & Night | Like a typical Kobold Scavenger Veteran, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `dust_puffs` · palette `#576f8c` `#39485d` `#8ab1de` · triangle-based silhouette, sharp asymmetric spikes
