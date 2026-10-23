---
type: monster
id: mon_ruin_wall_stalker
family: "Floor-born"
rank: "E+"
tier: variant
tags: [monster, floor-born]
---
# Ruin Wall Stalker

> The Ruin Wall Stalker is a person-sized creature with an asymmetric body with too many limbs, about 2 m tall. Its stone-like hide is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. It peels itself out of the wall. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Wall Stalker\|Wall Stalker]] (regional) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2134 · 173 · 124 · 124 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Grasp | melee | 1.2 | 0 s | None | blue |
| Unfold | aoe | 1.8 | 12 s | None | red |
| Mimic Voice | debuff | 0 | 18 s | None | none |
| Wall Ambush | dash | 1.4 | 10 s | None | red |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_floorborn_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `dungeon_stone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
