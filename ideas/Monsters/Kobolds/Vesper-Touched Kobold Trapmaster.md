---
type: monster
id: mon_vesper_touched_kobold_trapmaster
family: "Kobolds"
rank: "C-"
tier: variant
tags: [monster, kobolds]
---
# Vesper-Touched Kobold Trapmaster

![[mon_vesper_touched_kobold_trapmaster_sheet.jpg]]
*Blockout turnaround: front, side, back (views: `mon_vesper_touched_kobold_trapmaster_front/side/back.jpg`).*

> [!note] 3D model: not generated yet (blockout only). Prompt in `Art/Generation/monster_model_prompts.json`.

> The Vesper-Touched Kobold Trapmaster is a small creature with a small, compact humanoid body, about 1 m tall. Its mangy fur is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Its most striking feature is a harness of gears, springs and tripwires. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Trapmaster\|Kobold Trapmaster]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 1 m |
| Behaviour | Skittish (skittish_flee+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4060 · 270 · 216 · 189 · 216 · 135 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Light. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1 m high × 0.3 m long × 0.4 m wide; prefab scale 0.909.
- **Physics:** 17.6 kg, gravity ×1.5, poise 41, knockback resistance 0.24, death style `ragdoll_crumple`.
- **Navigation:** speed 5.53 m/s, turn 420°/s, stopping distance 0.6 m.
- **Attack count:** 5; **signature:** a harness of gears, springs and tripwires.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Kobold Trapmaster is a **dread humanoid** encountered at C- rank, around level 65. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a harness of gears, springs and tripwires. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Aldmere|Aldmere]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | C, C-, C+, D+ | 56–86 | Night |
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 3 | C-, C+, C | 65–86 | Night |
| [[Regions/Aldmere\|Aldmere]] | 3 | D+, B-, D | 48–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03236` | Great Labyrinth (Floors 1-40) Vesper-Touched Kobold Trapmaster Albino | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Albino | C | 76 | 1 m | Night | Like a typical Vesper-Touched Kobold Trapmaster, but a rare pale form with white skin or fur and red eyes. |
| `pop_03237` | Great Labyrinth (Floors 1-40) Vesper-Touched Kobold Trapmaster | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C- | 65 | 1 m | Night | A typical adult Vesper-Touched Kobold Trapmaster of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03238` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Trapmaster | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C- | 65 | 1 m | Night | A typical adult Vesper-Touched Kobold Trapmaster of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03239` | Aldmere Vesper-Touched Kobold Trapmaster Juvenile | [[Regions/Aldmere\|Aldmere]] | Juvenile | D+ | 56 | 0.85 m | Night | Like a typical Vesper-Touched Kobold Trapmaster, but young, with brighter colors and unworn features, with dust-grey coloring and old rune scars. |
| `pop_03240` | Great Labyrinth (Floors 1-40) Vesper-Touched Kobold Trapmaster Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | C+ | 86 | 1.25 m | Night | Like a typical Vesper-Touched Kobold Trapmaster, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03241` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Trapmaster Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | C+ | 86 | 1.25 m | Night | Like a typical Vesper-Touched Kobold Trapmaster, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03242` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Trapmaster Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C | 76 | 1.1 m | Night | Like a typical Vesper-Touched Kobold Trapmaster, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03243` | Great Labyrinth (Floors 1-40) Vesper-Touched Kobold Trapmaster Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C | 76 | 1.1 m | Night | Like a typical Vesper-Touched Kobold Trapmaster, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03244` | Great Labyrinth (Floors 1-40) Vesper-Touched Kobold Trapmaster Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | D+ | 56 | 0.85 m | Night | Like a typical Vesper-Touched Kobold Trapmaster, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03245` | Aldmere Vesper-Touched Kobold Trapmaster Elderborn | [[Regions/Aldmere\|Aldmere]] | Elderborn | B- | 96 | 1.35 m | Night | Like a typical Vesper-Touched Kobold Trapmaster, but old and wise, with greying features and a cautious hunting style, with dust-grey coloring and old rune scars. |
| `pop_03246` | Aldmere Vesper-Touched Kobold Trapmaster Runt | [[Regions/Aldmere\|Aldmere]] | Runt | D | 48 | 0.7 m | Night | Like a typical Vesper-Touched Kobold Trapmaster, but smaller and scrappier than usual, with dust-grey coloring and old rune scars. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
