---
type: monster
id: mon_kobold_packleader
family: "Kobolds"
rank: "D+"
tier: core
tags: [monster, kobolds]
---
# Kobold Packleader

![[mon_kobold_packleader_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kobold_packleader_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,910 tris · 0.593 × 0.478 × 1.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Kobold Packleader is a person-sized creature with a small, compact humanoid body, about 1.2 m tall. Its mangy fur is rough, scarred and spiked, colored in muted greys and dusty browns. Survivors describe a collar of teeth from rival packs. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It circles its prey. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.2 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3458 · 234 · 187 · 115 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.2 m high × 0.36 m long × 0.48 m wide; prefab scale 1.091.
- **Physics:** 27.6 kg, gravity ×1.5, poise 41, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 6.36 m/s, turn 383°/s, stopping distance 0.64 m.
- **Attack count:** 4; **signature:** a collar of teeth from rival packs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Kobold Packleader is a **menacing humanoid** encountered at D+ rank, around level 56. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a collar of teeth from rival packs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds D|loot_kobold_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Kobolds/Vesper-Touched Kobold Packleader|Vesper-Touched Kobold Packleader]]
- [[Monsters/Kobolds/Ancient Kobold Packleader|Ancient Kobold Packleader]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 4 | C+, C-, D-, D+ | 40–86 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 4 | C, C-, C+ | 65–86 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | D-, D+, C- | 40–65 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00343` | Iron Hold Kobold Packleader Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | C+ | 86 | 1.62 m | Day & Night | Like a typical Kobold Packleader, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_00344` | Umbravel Kobold Packleader Alpha | [[Regions/Umbravel\|Umbravel]] | Alpha | C | 76 | 1.5 m | Day & Night | Like a typical Kobold Packleader, but larger and scarred, and others of its kind follow it, with bioluminescent spots along its body. |
| `pop_00345` | Umbravel Kobold Packleader Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | C- | 65 | 1.32 m | Day & Night | Like a typical Kobold Packleader, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_00346` | Great Labyrinth (Floors 1-40) Kobold Packleader Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D- | 40 | 0.84 m | Day & Night | Like a typical Kobold Packleader, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00347` | Iron Hold Kobold Packleader Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | C- | 65 | 1.2 m | Day & Night | Like a typical Kobold Packleader, but a rare pale form with white skin or fur and red eyes. |
| `pop_00348` | Great Labyrinth (Floors 1-40) Kobold Packleader | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D+ | 56 | 1.2 m | Day & Night | A typical adult Kobold Packleader of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00349` | Iron Hold Kobold Packleader Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | D- | 40 | 0.84 m | Day & Night | Like a typical Kobold Packleader, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00350` | Iron Hold Kobold Packleader | [[Regions/Iron Hold\|Iron Hold]] | Adult | D+ | 56 | 1.2 m | Day & Night | A typical adult Kobold Packleader of this region, with slate-grey coloring and hardened hide. |
| `pop_00351` | Great Labyrinth (Floors 1-40) Kobold Packleader Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C- | 65 | 1.32 m | Day & Night | Like a typical Kobold Packleader, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00352` | Umbravel Kobold Packleader Albino | [[Regions/Umbravel\|Umbravel]] | Albino | C- | 65 | 1.2 m | Day & Night | Like a typical Kobold Packleader, but a rare pale form with white skin or fur and red eyes. |
| `pop_00353` | Umbravel Kobold Packleader Elderborn | [[Regions/Umbravel\|Umbravel]] | Elderborn | C+ | 86 | 1.62 m | Day & Night | Like a typical Kobold Packleader, but old and wise, with greying features and a cautious hunting style, with bioluminescent spots along its body. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
