---
type: monster
id: mon_kobold_warlord_veteran
family: "Kobolds"
rank: "B"
tier: variant
tags: [monster, kobolds]
---
# Kobold Warlord Veteran

![[mon_kobold_warlord_veteran_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kobold_warlord_veteran_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,154 tris · 1.09 × 1.282 × 2.2 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Kobold Warlord Veteran is a person-sized creature with a small, compact humanoid body, about 2.2 m tall. Its mangy fur is rough, scarred and spiked, colored in rust-red, with ochre markings. Its most striking feature is scavenged knight armor hammered to fit. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Warlord\|Kobold Warlord]] (elder) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2.2 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11273 · 442 · 354 · 309 · 354 · 135 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 2.2 m high × 0.66 m long × 0.88 m wide; prefab scale 2.
- **Physics:** 221.5 kg, gravity ×1.65, poise 68, knockback resistance 0.42, death style `ragdoll_crumple`.
- **Navigation:** speed 7.92 m/s, turn 283°/s, stopping distance 0.84 m.
- **Attack count:** 5; **signature:** scavenged knight armor hammered to fit.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Stone Spike\|Stone Spike]] | magic | 1.5 | 10 s | Earth | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Kobold Warlord Veteran is a **menacing humanoid** encountered at B rank, around level 108. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** scavenged knight armor hammered to fit. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Umbravel|Umbravel]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds B|loot_kobold_b]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 5 | B-, B, A, B+ | 96–146 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 4 | B+, A-, B-, A | 96–146 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 2 | C+, B | 86–108 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03258` | Iron Hold Kobold Warlord Veteran Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | B- | 96 | 1.87 m | Day & Night | Like a typical Kobold Warlord Veteran, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_03259` | Great Labyrinth (Floors 41-90) Kobold Warlord Veteran Albino | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Albino | B+ | 120 | 2.2 m | Day & Night | Like a typical Kobold Warlord Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_03260` | Iron Hold Kobold Warlord Veteran | [[Regions/Iron Hold\|Iron Hold]] | Adult | B | 108 | 2.2 m | Day & Night | A typical adult Kobold Warlord Veteran of this region, with slate-grey coloring and hardened hide. |
| `pop_03261` | Iron Hold Kobold Warlord Veteran Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | A | 146 | 2.97 m | Day & Night | Like a typical Kobold Warlord Veteran, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |
| `pop_03262` | Umbravel Kobold Warlord Veteran Runt | [[Regions/Umbravel\|Umbravel]] | Runt | C+ | 86 | 1.54 m | Day & Night | Like a typical Kobold Warlord Veteran, but smaller and scrappier than usual, with bioluminescent spots along its body. |
| `pop_03263` | Umbravel Kobold Warlord Veteran | [[Regions/Umbravel\|Umbravel]] | Adult | B | 108 | 2.2 m | Day & Night | A typical adult Kobold Warlord Veteran of this region, with bioluminescent spots along its body. |
| `pop_03264` | Iron Hold Kobold Warlord Veteran Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B+ | 120 | 2.42 m | Day & Night | Like a typical Kobold Warlord Veteran, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_03265` | Great Labyrinth (Floors 41-90) Kobold Warlord Veteran Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | A- | 132 | 2.75 m | Day & Night | Like a typical Kobold Warlord Veteran, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03266` | Great Labyrinth (Floors 41-90) Kobold Warlord Veteran Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | B- | 96 | 1.87 m | Day & Night | Like a typical Kobold Warlord Veteran, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03267` | Iron Hold Kobold Warlord Veteran Albino | [[Regions/Iron Hold\|Iron Hold]] | Albino | B+ | 120 | 2.2 m | Day & Night | Like a typical Kobold Warlord Veteran, but a rare pale form with white skin or fur and red eyes. |
| `pop_03268` | Great Labyrinth (Floors 41-90) Kobold Warlord Veteran Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | A | 146 | 2.97 m | Day & Night | Like a typical Kobold Warlord Veteran, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#ba4f3c` `#712e25` `#d1a15a` · triangle-based silhouette, sharp asymmetric spikes
