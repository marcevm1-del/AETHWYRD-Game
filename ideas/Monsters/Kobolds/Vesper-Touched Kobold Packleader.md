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
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Light. Flees when hurt. Snares or ranged attacks work best.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Trip-Wire Trap | debuff | 0 | 14 s | None | none |
| Blood Lance | magic | 1.5 | 10 s | Blood | red |

## Loot (`loot_kobold_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
