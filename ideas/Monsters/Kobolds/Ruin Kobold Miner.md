---
type: monster
id: mon_ruin_kobold_miner
family: "Kobolds"
rank: "E+"
tier: variant
tags: [monster, kobolds]
---
# Ruin Kobold Miner

> The Ruin Kobold Miner is a small creature with a scrawny biped with long arms and bowed legs, about 0.9 m tall. Its mangy fur is weathered and natural, colored in ink black with bruised violet. Survivors describe a candle-helmet and a pick worn smooth from use. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It stalks low to the ground, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Miner\|Kobold Miner]] (regional) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 2 · Wild |
| Element · weakness | Dark · Light |
| Size | 0.9 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1388 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Trip-Wire Trap | debuff | 0 | 14 s | None | none |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_kobold_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · real-animal silhouette with one fantasy exaggeration
