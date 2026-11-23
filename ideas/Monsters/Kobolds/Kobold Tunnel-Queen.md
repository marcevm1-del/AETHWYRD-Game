---
type: monster
id: mon_kobold_tunnel_queen
family: "Kobolds"
rank: "B"
tier: core
tags: [monster, kobolds]
---
# Kobold Tunnel-Queen

![[mon_kobold_tunnel_queen_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kobold_tunnel_queen_front/side/back.jpg`).*

> [!success] 3D model: generated 2026-11-22 with ascend_creatures · 12,000 tris · 0.984 × 2.186 × 1.6 m · local file `Game/Assets/_Game/Art/Models/Monsters/Kobolds/mon_kobold_tunnel_queen.fbx`

> The Kobold Tunnel-Queen is a person-sized creature with a small, compact humanoid body, about 1.6 m tall. Its mangy fur is rough, scarred and spiked, colored in slate-blue, with ochre markings. Survivors describe a bloated, jewel-encrusted body carried on a litter. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1.6 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10108 · 442 · 354 · 309 · 354 · 135 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Apu Highlands\|Apu Highlands]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.6 m high × 0.48 m long × 0.64 m wide; prefab scale 1.455.
- **Physics:** 85.2 kg, gravity ×1.65, poise 58, knockback resistance 0.42, death style `ragdoll_crumple`.
- **Navigation:** speed 6.75 m/s, turn 332°/s, stopping distance 0.72 m.
- **Attack count:** 5; **signature:** a bloated, jewel-encrusted body carried on a litter.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Kobold Tunnel-Queen is a **menacing humanoid** encountered at B rank, around level 108. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a bloated, jewel-encrusted body carried on a litter. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Apu Highlands|Apu Highlands]], [[Regions/Hoshizora|Hoshizora]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds B|loot_kobold_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Kobolds/Vesper-Touched Kobold Tunnel-Queen|Vesper-Touched Kobold Tunnel-Queen]]
- [[Monsters/Kobolds/Kobold Tunnel-Queen Veteran|Kobold Tunnel-Queen Veteran]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 2 | B, A- | 108–132 | Day & Night |
| [[Regions/Hoshizora\|Hoshizora]] | 3 | B, A, A- | 108–146 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | A, B+, A-, B- | 96–146 | Day & Night |
| [[Regions/Apu Highlands\|Apu Highlands]] | 1 | B- | 96–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00365` | Iron Hold Kobold Tunnel-Queen | [[Regions/Iron Hold\|Iron Hold]] | Adult | B | 108 | 1.6 m | Day & Night | A typical adult Kobold Tunnel-Queen of this region, with slate-grey coloring and hardened hide. |
| `pop_00366` | Hoshizora Kobold Tunnel-Queen | [[Regions/Hoshizora\|Hoshizora]] | Adult | B | 108 | 1.6 m | Day & Night | A typical adult Kobold Tunnel-Queen of this region, with slate-grey coloring and hardened hide. |
| `pop_00367` | Great Labyrinth (Floors 41-90) Kobold Tunnel-Queen Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A | 146 | 2.16 m | Day & Night | Like a typical Kobold Tunnel-Queen, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00368` | Hoshizora Kobold Tunnel-Queen Elderborn | [[Regions/Hoshizora\|Hoshizora]] | Elderborn | A | 146 | 2.16 m | Day & Night | Like a typical Kobold Tunnel-Queen, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_00369` | Great Labyrinth (Floors 41-90) Kobold Tunnel-Queen Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B+ | 120 | 1.76 m | Day & Night | Like a typical Kobold Tunnel-Queen, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_00370` | Hoshizora Kobold Tunnel-Queen Alpha | [[Regions/Hoshizora\|Hoshizora]] | Alpha | A- | 132 | 2 m | Day & Night | Like a typical Kobold Tunnel-Queen, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00371` | Iron Hold Kobold Tunnel-Queen Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | A- | 132 | 2 m | Day & Night | Like a typical Kobold Tunnel-Queen, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00372` | Great Labyrinth (Floors 41-90) Kobold Tunnel-Queen Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B+ | 120 | 1.6 m | Day & Night | Like a typical Kobold Tunnel-Queen, but a rare pale form with white skin or fur and red eyes. |
| `pop_00373` | Apu Highlands Kobold Tunnel-Queen Juvenile | [[Regions/Apu Highlands\|Apu Highlands]] | Juvenile | B- | 96 | 1.36 m | Day & Night | Like a typical Kobold Tunnel-Queen, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00374` | Great Labyrinth (Floors 41-90) Kobold Tunnel-Queen Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A- | 132 | 2 m | Day & Night | Like a typical Kobold Tunnel-Queen, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_00375` | Great Labyrinth (Floors 41-90) Kobold Tunnel-Queen Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B- | 96 | 1.36 m | Day & Night | Like a typical Kobold Tunnel-Queen, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#5a7891` `#3b4e61` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
