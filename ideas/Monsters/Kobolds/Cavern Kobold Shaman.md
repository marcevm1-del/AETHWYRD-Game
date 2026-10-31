---
type: monster
id: mon_cavern_kobold_shaman
family: "Kobolds"
rank: "D+"
tier: variant
tags: [monster, kobolds]
---
# Cavern Kobold Shaman

![[mon_cavern_kobold_shaman_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_cavern_kobold_shaman_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,522 tris · 0.453 × 0.533 × 0.9 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Cavern Kobold Shaman is a small creature with a hunched, wiry humanoid frame, about 0.9 m tall. Its mangy fur is rough, scarred and spiked, colored in slate-blue, with ochre markings. Its most striking feature is tin-can wind chimes and singed whiskers. It has burning slit pupils. A distinctive marking runs along its back. It circles its prey, surrounded by pebbles that tremble and float near it. Adapted to cave lands, it has pale, light-starved coloring and oversized eyes.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Shaman\|Kobold Shaman]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 0.9 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3148 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 0.9 m high × 0.27 m long × 0.36 m wide; prefab scale 0.818.
- **Physics:** 15.2 kg, gravity ×1.65, poise 35, knockback resistance 0.36, death style `ragdoll_crumple`.
- **Navigation:** speed 5.07 m/s, turn 443°/s, stopping distance 0.58 m.
- **Attack count:** 5; **signature:** tin-can wind chimes and singed whiskers.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Cavern Kobold Shaman is a **menacing humanoid** encountered at D+ rank, around level 56. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** tin-can wind chimes and singed whiskers. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds D|loot_kobold_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | D+, D, C+, C-, C | 48–86 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 1 | C+ | 86–86 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 5 | C-, D, C+, D+, D- | 40–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03225` | Great Labyrinth (Floors 1-40) Cavern Kobold Shaman | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D+ | 56 | 0.9 m | Day & Night | A typical adult Cavern Kobold Shaman of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03226` | Iron Hold Cavern Kobold Shaman Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 1.22 m | Day & Night | Like a typical Cavern Kobold Shaman, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_03227` | Great Labyrinth (Floors 1-40) Cavern Kobold Shaman Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D | 48 | 0.77 m | Day & Night | Like a typical Cavern Kobold Shaman, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03228` | Great Labyrinth (Floors 1-40) Cavern Kobold Shaman Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C+ | 86 | 1.22 m | Day & Night | Like a typical Cavern Kobold Shaman, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03229` | Umbravel Cavern Kobold Shaman Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | C- | 65 | 0.99 m | Day & Night | Like a typical Cavern Kobold Shaman, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_03230` | Great Labyrinth (Floors 1-40) Cavern Kobold Shaman Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C- | 65 | 0.99 m | Day & Night | Like a typical Cavern Kobold Shaman, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03231` | Great Labyrinth (Floors 1-40) Cavern Kobold Shaman Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C | 76 | 1.13 m | Day & Night | Like a typical Cavern Kobold Shaman, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03232` | Umbravel Cavern Kobold Shaman Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D | 48 | 0.77 m | Day & Night | Like a typical Cavern Kobold Shaman, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_03233` | Umbravel Cavern Kobold Shaman Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C+ | 86 | 1.22 m | Day & Night | Like a typical Cavern Kobold Shaman, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |
| `pop_03234` | Umbravel Cavern Kobold Shaman | [[Regions/Umbravel\|Umbravel]] | Adult | D+ | 56 | 0.9 m | Day & Night | A typical adult Cavern Kobold Shaman of this region, with bioluminescent spots along its body. |
| `pop_03235` | Umbravel Cavern Kobold Shaman Runt | [[Regions/Umbravel\|Umbravel]] | Runt | D- | 40 | 0.63 m | Day & Night | Like a typical Cavern Kobold Shaman, but smaller and scrappier than usual, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#57788c` `#394e5d` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
