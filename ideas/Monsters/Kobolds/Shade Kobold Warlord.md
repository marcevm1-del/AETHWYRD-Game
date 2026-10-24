---
type: monster
id: mon_shade_kobold_warlord
family: "Kobolds"
rank: "C+"
tier: variant
tags: [monster, kobolds]
---
# Shade Kobold Warlord

![[mon_shade_kobold_warlord_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_shade_kobold_warlord_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Shade Kobold Warlord is a person-sized creature with a hunched, wiry humanoid frame, about 1.4 m tall. Its mangy fur is rough, scarred and spiked, colored in ink black with bruised violet. Look for scavenged knight armor hammered to fit. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by shadows that lean toward it. This Dark-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Warlord\|Kobold Warlord]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.4 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6880 · 354 · 283 · 248 · 283 · 135 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.4 m high × 0.42 m long × 0.56 m wide; prefab scale 1.273.
- **Physics:** 43.9 kg, gravity ×1.5, poise 49, knockback resistance 0.24, death style `ragdoll_crumple`.
- **Navigation:** speed 6.31 m/s, turn 355°/s, stopping distance 0.68 m.
- **Attack count:** 5; **signature:** scavenged knight armor hammered to fit.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Shadow Grasp\|Shadow Grasp]] | magic | 1.5 | 10 s | Dark | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Shade Kobold Warlord is a **menacing humanoid** encountered at C+ rank, around level 86. Its documented behaviour is *Pack* and its AI pattern is *pack_flank*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** scavenged knight armor hammered to fit. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold|Iron Hold]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

**Production note:** rig `rig_small_biped`, animation set `anim_small_biped`; keep silhouette, movement and signature attack legible at gameplay camera distance.

## Loot ([[Loot Tables/Kobolds C|loot_kobold_c]])

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Regional populations (11)

These are presentation and spawn variants of this species, not separate core combat kits. Region and spawn timing carry the variation; keep the base family’s combat identity intact unless a data-backed modifier says otherwise.

| Region | Forms | Rank span | Level span | Spawn windows |
|---|---:|---|---|---|
| [[Regions/Iron Hold\|Iron Hold]] | 3 | B-, C, B | 76–108 | Day & Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 5 | C+, B+, B-, B, C- | 65–120 | Day & Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 3 | B-, C+, C- | 65–96 | Day & Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_06099` | Iron Hold Shade Kobold Warlord Scarred | [[Regions/Iron Hold\|Iron Hold]] | Scarred | B- | 96 | 1.54 m | Day & Night | Like a typical Shade Kobold Warlord, but covered in old battle scars, with slate-grey coloring and hardened hide. |
| `pop_06100` | Great Labyrinth (Floors 41-90) Shade Kobold Warlord | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C+ | 86 | 1.4 m | Day & Night | A typical adult Shade Kobold Warlord of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06101` | Great Labyrinth (Floors 41-90) Shade Kobold Warlord Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B+ | 120 | 1.89 m | Day & Night | Like a typical Shade Kobold Warlord, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_06102` | Iron Hold Shade Kobold Warlord Juvenile | [[Regions/Iron Hold\|Iron Hold]] | Juvenile | C | 76 | 1.19 m | Day & Night | Like a typical Shade Kobold Warlord, but young, with brighter colors and unworn features, with slate-grey coloring and hardened hide. |
| `pop_06103` | Great Labyrinth (Floors 41-90) Shade Kobold Warlord Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | B- | 96 | 1.54 m | Day & Night | Like a typical Shade Kobold Warlord, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_06104` | Great Labyrinth (Floors 41-90) Shade Kobold Warlord Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B | 108 | 1.75 m | Day & Night | Like a typical Shade Kobold Warlord, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_06105` | Iron Hold Shade Kobold Warlord Alpha | [[Regions/Iron Hold\|Iron Hold]] | Alpha | B | 108 | 1.75 m | Day & Night | Like a typical Shade Kobold Warlord, but larger and scarred, and others of its kind follow it, with slate-grey coloring and hardened hide. |
| `pop_06106` | Great Labyrinth (Floors 1-40) Shade Kobold Warlord Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | B- | 96 | 1.4 m | Day & Night | Like a typical Shade Kobold Warlord, but a rare pale form with white skin or fur and red eyes. |
| `pop_06107` | Great Labyrinth (Floors 1-40) Shade Kobold Warlord | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C+ | 86 | 1.4 m | Day & Night | A typical adult Shade Kobold Warlord of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_06108` | Great Labyrinth (Floors 41-90) Shade Kobold Warlord Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | C- | 65 | 0.98 m | Day & Night | Like a typical Shade Kobold Warlord, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_06109` | Great Labyrinth (Floors 1-40) Shade Kobold Warlord Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | C- | 65 | 0.98 m | Day & Night | Like a typical Shade Kobold Warlord, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
