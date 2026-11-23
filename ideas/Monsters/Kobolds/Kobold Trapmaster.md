---
type: monster
id: mon_kobold_trapmaster
family: "Kobolds"
rank: "D"
tier: core
tags: [monster, kobolds]
---
# Kobold Trapmaster

![[mon_kobold_trapmaster_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kobold_trapmaster_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.608 × 1.364 × 1 m · local file `Game/Assets/_Game/Art/Models/Monsters/Kobolds/mon_kobold_trapmaster.fbx`

> The Kobold Trapmaster is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its mangy fur is rough, scarred and spiked, colored in rust-red. Survivors describe a harness of gears, springs and tripwires. It has narrow glowing eyes. A distinctive marking runs along its back. It circles its prey. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2595 · 202 · 162 · 99 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 16 kg, gravity ×1.5, poise 37, knockback resistance 0.21, death style `ragdoll_crumple`.
- **Navigation:** speed 5.8 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 4; **signature:** a harness of gears, springs and tripwires.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |

## Field guide

Kobold Trapmaster is a **menacing humanoid** encountered at D rank, around level 48. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Fire**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a harness of gears, springs and tripwires. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel|Umbravel]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Moraveil|Moraveil]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds D|loot_kobold_d]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Kobolds/Vesper-Touched Kobold Trapmaster|Vesper-Touched Kobold Trapmaster]]
- [[Monsters/Kobolds/Crag Kobold Trapmaster|Crag Kobold Trapmaster]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Umbravel\|Umbravel]] | 1 | D- | 40–40 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | E+, D, C- | 32–65 | Day & Night |
| [[Regions/Moraveil\|Moraveil]] | 3 | D+, D | 48–56 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 4 | D+, C, D, D- | 40–76 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00332` | Umbravel Kobold Trapmaster Juvenile | [[Regions/Umbravel\|Umbravel]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Kobold Trapmaster, but young, with brighter colors and unworn features, with bioluminescent spots along its body. |
| `pop_00333` | Iron Hold Kobold Trapmaster Runt | [[Regions/Iron Hold\|Iron Hold]] | Runt | E+ | 32 | 0.7 m | Day & Night | Like a typical Kobold Trapmaster, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00334` | Iron Hold Kobold Trapmaster | [[Regions/Iron Hold\|Iron Hold]] | Adult | D | 48 | 1 m | Day & Night | A typical adult Kobold Trapmaster of this region, with slate-grey coloring and hardened hide. |
| `pop_00335` | Moraveil Kobold Trapmaster Albino | [[Regions/Moraveil\|Moraveil]] | Albino | D+ | 56 | 1 m | Day & Night | Like a typical Kobold Trapmaster, but a rare pale form with white skin or fur and red eyes. |
| `pop_00336` | Iron Hold Kobold Trapmaster Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | C- | 65 | 1.25 m | Day & Night | Like a typical Kobold Trapmaster, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00337` | Great Labyrinth (Floors 1-40) Kobold Trapmaster Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | D+ | 56 | 1 m | Day & Night | Like a typical Kobold Trapmaster, but a rare pale form with white skin or fur and red eyes. |
| `pop_00338` | Great Labyrinth (Floors 1-40) Kobold Trapmaster Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | C | 76 | 1.35 m | Day & Night | Like a typical Kobold Trapmaster, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00339` | Moraveil Kobold Trapmaster | [[Regions/Moraveil\|Moraveil]] | Adult | D | 48 | 1 m | Day & Night | A typical adult Kobold Trapmaster of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00340` | Great Labyrinth (Floors 1-40) Kobold Trapmaster | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | D | 48 | 1 m | Day & Night | A typical adult Kobold Trapmaster of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_00341` | Moraveil Kobold Trapmaster Scarred | [[Regions/Moraveil\|Moraveil]] | Scarred | D+ | 56 | 1.1 m | Day & Night | Like a typical Kobold Trapmaster, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00342` | Great Labyrinth (Floors 1-40) Kobold Trapmaster Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D- | 40 | 0.85 m | Day & Night | Like a typical Kobold Trapmaster, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Contracts and story encounters

- [[Quests/Weigh the Way Down|Weigh the Way Down]] — rank E, in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]

These links show where the species already matters to authored play. A contract target is not a claim that every local population is hostile; check the quest objective and the creature’s behavior before engaging.

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `dust_puffs` · palette `#b4533a` `#6e3024` `#ff8e52` · triangle-based silhouette, sharp asymmetric spikes
