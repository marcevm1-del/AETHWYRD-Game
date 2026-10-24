---
type: monster
id: mon_kobold_warlord
family: "Kobolds"
rank: "C"
tier: core
tags: [monster, kobolds]
---
# Kobold Warlord

![[mon_kobold_warlord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_kobold_warlord_front/side/back.jpg`).*

> [!note] 3D model: procedural blockout in Unity (2,348 tris · 0.694 × 0.816 × 1.4 m) until the AI model is generated. Prompt in `Art/Generation/monster_model_prompts.json`.

> The Kobold Warlord is a person-sized creature with a small, compact humanoid body, about 1.4 m tall. Its mangy fur is rough, scarred and spiked, colored in ochre, clay and mossy stone. Its most striking feature is scavenged knight armor hammered to fit. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1.4 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5726 · 314 · 251 · 220 · 251 · 135 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.4 m high × 0.42 m long × 0.56 m wide; prefab scale 1.273.
- **Physics:** 57.1 kg, gravity ×1.65, poise 49, knockback resistance 0.39, death style `ragdoll_crumple`.
- **Navigation:** speed 5.79 m/s, turn 355°/s, stopping distance 0.68 m.
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

Kobold Warlord is a **menacing humanoid** encountered at C rank, around level 76. Its documented behaviour is *Ambush* and its AI pattern is *ambush_strike*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Wind**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** scavenged knight armor hammered to fit. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel|Umbravel]], [[Regions/Iron Hold|Iron Hold]], [[Regions/Shen-Lu|Shen-Lu]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds C|loot_kobold_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Kobolds/Kobold Warlord Veteran|Kobold Warlord Veteran]]
- [[Monsters/Kobolds/Shade Kobold Warlord|Shade Kobold Warlord]]

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 2 | C-, B | 65–108 | Day & Night |
| [[Regions/Shen-Lu\|Shen-Lu]] | 3 | D+, C-, C+ | 56–86 | Day & Night |
| [[Regions/Iron Hold\|Iron Hold]] | 3 | B-, C+, B | 86–108 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 2 | D+, B | 56–108 | Day & Night |
| [[Regions/Umbravel\|Umbravel]] | 1 | C+ | 86–86 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_00354` | Great Labyrinth (Floors 1-40) Kobold Warlord Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C- | 65 | 1.19 m | Day & Night | Like a typical Kobold Warlord, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_00355` | Shen-Lu Kobold Warlord Runt | [[Regions/Shen-Lu\|Shen-Lu]] | Runt | D+ | 56 | 0.98 m | Day & Night | Like a typical Kobold Warlord, but smaller and scrappier than usual, with slate-grey coloring and hardened hide. |
| `pop_00356` | Iron Hold Kobold Warlord Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | B- | 96 | 1.75 m | Day & Night | Like a typical Kobold Warlord, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_00357` | Great Labyrinth (Floors 41-90) Kobold Warlord Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D+ | 56 | 0.98 m | Day & Night | Like a typical Kobold Warlord, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_00358` | Great Labyrinth (Floors 41-90) Kobold Warlord Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B | 108 | 1.89 m | Day & Night | Like a typical Kobold Warlord, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00359` | Shen-Lu Kobold Warlord Juvenile | [[Regions/Shen-Lu\|Shen-Lu]] | Juvenile | C- | 65 | 1.19 m | Day & Night | Like a typical Kobold Warlord, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_00360` | Shen-Lu Kobold Warlord Albino | [[Regions/Shen-Lu\|Shen-Lu]] | Albino | C+ | 86 | 1.4 m | Day & Night | Like a typical Kobold Warlord, but a rare pale form with white skin or fur and red eyes. |
| `pop_00361` | Umbravel Kobold Warlord Scarred | [[Regions/Umbravel\|Umbravel]] | Scarred | C+ | 86 | 1.54 m | Day & Night | Like a typical Kobold Warlord, but covered in old battle scars, with bioluminescent spots along its body. |
| `pop_00362` | Iron Hold Kobold Warlord Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | C+ | 86 | 1.54 m | Day & Night | Like a typical Kobold Warlord, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_00363` | Great Labyrinth (Floors 1-40) Kobold Warlord Elderborn | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Elderborn | B | 108 | 1.89 m | Day & Night | Like a typical Kobold Warlord, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_00364` | Iron Hold Kobold Warlord Elderborn | [[Regions/Iron Hold\|Iron Hold]] | Elderborn | B | 108 | 1.89 m | Day & Night | Like a typical Kobold Warlord, but old and wise, with greying features and a cautious hunting style, with slate-grey coloring and hardened hide. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
