---
type: monster
id: mon_vesper_touched_kobold_packleader
family: "Kobolds"
rank: "C"
tier: variant
tags: [monster, kobolds]
---
# Vesper-Touched Kobold Packleader

> The Vesper-Touched Kobold Packleader is a person-sized creature with a small, compact humanoid body, about 1.2 m tall. Its mangy fur is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Survivors describe a collar of teeth from rival packs. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Packleader\|Kobold Packleader]] (corrupted) |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 1.2 m |
| Behaviour | Skittish (skittish_flee+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5436 · 314 · 251 · 220 · 251 · 135 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Rig · animation | [[Systems/Rigs/small_biped\|small_biped]] · `anim_small_biped` |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Light. Flees when hurt. Snares or ranged attacks work best.

## Motion implementation

- **Rig:** [[Systems/Rigs/small_biped|small_biped]] (rigId); animation set `anim_small_biped`.
- **Dimensions:** 1.2 m high × 0.36 m long × 0.48 m wide; prefab scale 1.091.
- **Physics:** 30.4 kg, gravity ×1.5, poise 45, knockback resistance 0.24, death style `ragdoll_crumple`.
- **Navigation:** speed 6.06 m/s, turn 383°/s, stopping distance 0.64 m.
- **Attack count:** 5; **signature:** a collar of teeth from rival packs.

## Attacks and responses

| Attack | Kind | Power | Cooldown | Element | Telegraph | Player read |
|---|---|---|---|---|---|---|
| [[Attacks/Stab\|Stab]] | melee | 1 | 0 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Thrown Junk\|Thrown Junk]] | ranged | 0.8 | 4 s | None | blue | Readable standard attack; guard, dodge or use a practiced parry. |
| [[Attacks/Frenzied Lunge\|Frenzied Lunge]] | melee | 1.5 | 8 s | None | red | Treat as unblockable; dodge clear of the line or area. |
| [[Attacks/Trip-Wire Trap\|Trip-Wire Trap]] | debuff | 0 | 14 s | None | none | Keep moving and read the animation; do not assume a safe block. |
| [[Attacks/Blood Lance\|Blood Lance]] | magic | 1.5 | 10 s | Blood | red | Treat as unblockable; dodge clear of the line or area. |

## Field guide

Vesper-Touched Kobold Packleader is a **dread humanoid** encountered at C rank, around level 76. Its documented behaviour is *Skittish* and its AI pattern is *skittish_flee+stalker*. Treat these as combat promises: observe its opening, learn the tell, then punish the recovery instead of trading blindly.

**Hunt preparation:** the recorded weakness is **Light**. It is an advantage to exploit, not a mandatory loadout check; positioning, defense and direct damage remain valid ways to win.

**Signature read:** a collar of teeth from rival packs. Watch for its tell and leave a response window before committing to a long combo.

**Where it fits:** recorded in [[Regions/Great Labyrinth (Floors 41-90)|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)|Great Labyrinth (Floors 1-40)]]. Presence should reflect those regions’ climate, terrain and food web; sightings beyond them are migration or a deliberate encounter, not a default spawn.

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
| [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | 6 | B-, C, C-, B, C+, D+ | 56–108 | Night |
| [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | 5 | C-, C, B-, D+, C+ | 56–96 | Night |

### Complete population register

| ID | Named form | Region | Tier | Rank | Level | Size | Spawn | Appearance / field distinction |
|---|---|---|---|---|---:|---:|---|---|
| `pop_03247` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Packleader Alpha | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Alpha | B- | 96 | 1.5 m | Night | Like a typical Vesper-Touched Kobold Packleader, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03248` | Great Labyrinth (Floors 1-40) Vesper-Touched Kobold Packleader Juvenile | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Juvenile | C- | 65 | 1.02 m | Night | Like a typical Vesper-Touched Kobold Packleader, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03249` | Great Labyrinth (Floors 1-40) Vesper-Touched Kobold Packleader | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Adult | C | 76 | 1.2 m | Night | A typical adult Vesper-Touched Kobold Packleader of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03250` | Great Labyrinth (Floors 1-40) Vesper-Touched Kobold Packleader Alpha | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Alpha | B- | 96 | 1.5 m | Night | Like a typical Vesper-Touched Kobold Packleader, but larger and scarred, and others of its kind follow it, with pale, light-starved coloring and oversized eyes. |
| `pop_03251` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Packleader | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Adult | C | 76 | 1.2 m | Night | A typical adult Vesper-Touched Kobold Packleader of this region, with pale, light-starved coloring and oversized eyes. |
| `pop_03252` | Great Labyrinth (Floors 1-40) Vesper-Touched Kobold Packleader Runt | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Runt | D+ | 56 | 0.84 m | Night | Like a typical Vesper-Touched Kobold Packleader, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |
| `pop_03253` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Packleader Juvenile | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Juvenile | C- | 65 | 1.02 m | Night | Like a typical Vesper-Touched Kobold Packleader, but young, with brighter colors and unworn features, with pale, light-starved coloring and oversized eyes. |
| `pop_03254` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Packleader Elderborn | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Elderborn | B | 108 | 1.62 m | Night | Like a typical Vesper-Touched Kobold Packleader, but old and wise, with greying features and a cautious hunting style, with pale, light-starved coloring and oversized eyes. |
| `pop_03255` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Packleader Scarred | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Scarred | C+ | 86 | 1.32 m | Night | Like a typical Vesper-Touched Kobold Packleader, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03256` | Great Labyrinth (Floors 1-40) Vesper-Touched Kobold Packleader Scarred | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] | Scarred | C+ | 86 | 1.32 m | Night | Like a typical Vesper-Touched Kobold Packleader, but covered in old battle scars, with pale, light-starved coloring and oversized eyes. |
| `pop_03257` | Great Labyrinth (Floors 41-90) Vesper-Touched Kobold Packleader Runt | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] | Runt | D+ | 56 | 0.84 m | Night | Like a typical Vesper-Touched Kobold Packleader, but smaller and scrappier than usual, with pale, light-starved coloring and oversized eyes. |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
