---
type: monster
id: mon_kobold_shaman
family: "Kobolds"
rank: "D"
tier: core
tags: [monster, kobolds]
---
# Kobold Shaman

![[mon_kobold_shaman_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kobold_shaman_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,906 tris · 0.453 × 0.533 × 0.9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Kobold Shaman is a small creature with a small, compact humanoid body, about 0.9 m tall. Its mangy fur is rough, scarred and spiked, colored in ember reds fading to soot black. Look for tin-can wind chimes and singed whiskers. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 0.9 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2509 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Water. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.9 m high × 0.27 m long × 0.36 m wide; prefab scale 0.818.
- **Physics:** 11.7 kg, gravity ×1.5, poise 35, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 5.78 m/s, turn 443°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** tin-can wind chimes and singed whiskers.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Ember Burst\|Ember Burst]] | magic | 1.5 | 10 s | Fire | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Kobold Shaman is a **menacing humanoid** encountered at D rank, around level 48. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Water**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tin-can wind chimes and singed whiskers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Iron Hold|Iron Hold]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Moraveil|Moraveil]], [[Regions/Strife Marches|Strife Marches]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds D|loot_kobold_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Kobolds/Cavern Kobold Shaman|Cavern Kobold Shaman]]
- [[Monsters/Kobolds/Frost Kobold Shaman|Frost Kobold Shaman]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 3 | D+, C, C- | 56–76 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 3 | E+, D+ | 32–56 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 2 | D+, D | 48–56 | Day & Night |
| [[Regions/Strife Marches\|Strife Marches]] | 1 | D | 48–48 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | D+, E+ | 32–56 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00321` | Umbravel Kobold Shaman Albino | [[Regions/Umbravel\|Umbravel]] | Albino | D+ | 56 | 0.9 m | Day & Night | Like a typical Kobold Shaman, but a rare pale form with white skin or fur and red eyes. |
| `pop_00322` | Moraveil Kobold Shaman Runt | [[Regions/Moraveil\|Moraveil]] | Runt | E+ | 32 | 0.63 m | Day & Night | Like a typical Kobold Shaman, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00323` | Umbravel Kobold Shaman Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C | 76 | 1.22 m | Day & Night | Like a typical Kobold Shaman, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_00324` | Iron Hold Kobold Shaman Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | D+ | 56 | 0.9 m | Day & Night | Like a typical Kobold Shaman, but a rare pale form with white skin or fur and red eyes. |
| `pop_00325` | Strife Marches Kobold Shaman | [[Regions/Strife Marches\|Strife Marches]] | Adult | D | 48 | 0.9 m | Day & Night | A typical adult Kobold Shaman of this region, with dust-grey coloring and old rune scars. |
| `pop_00326` | Moraveil Kobold Shaman Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D+ | 56 | 0.9 m | Day & Night | Like a typical Kobold Shaman, but a rare pale form with white skin or fur and red eyes. |
| `pop_00327` | Iron Hold Kobold Shaman | [[Regions/Iron Hold\|Iron Hold]] | Adult | D | 48 | 0.9 m | Day & Night | A typical adult Kobold Shaman of this region, with slate-grey coloring and hardened hide. |
| `pop_00328` | Great Labyrinth (Floors 1-40) Kobold Shaman Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D+ | 56 | 0.9 m | Day & Night | Like a typical Kobold Shaman, but a rare pale form with white skin or fur and red eyes. |
| `pop_00329` | Great Labyrinth (Floors 1-40) Kobold Shaman Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | E+ | 32 | 0.63 m | Day & Night | Like a typical Kobold Shaman, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00330` | Umbravel Kobold Shaman Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | C- | 65 | 1.13 m | Day & Night | Like a typical Kobold Shaman, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_00331` | Moraveil Kobold Shaman Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 0.99 m | Day & Night | Like a typical Kobold Shaman, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
