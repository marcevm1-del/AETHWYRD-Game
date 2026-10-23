---
type: monster
id: mon_wall_stalker
family: "Floor-born"
rank: "E"
tier: core
tags: [monster, floor-born]
---
# Wall Stalker

> The Wall Stalker is a person-sized creature with a shape that keeps rearranging itself, about 2 m tall. Its stone-like hide is patchy and subtly wrong, as if assembled from memory, colored in ochre, clay and mossy stone. It peels itself out of the wall. It has eyes set slightly too far apart. Small scars and rough edges mark it as a survivor. It glides without moving its legs, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1583 · 143 · 103 · 103 · 103 · 100 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Grasp | melee | 1.2 | 0 s | None | blue |
| Unfold | aoe | 1.8 | 12 s | None | red |
| Mimic Voice | debuff | 0 | 18 s | None | none |
| Wall Ambush | dash | 1.4 | 10 s | None | red |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_floorborn_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Floor-born/Ruin Wall Stalker|Ruin Wall Stalker]]

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `dungeon_stone` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · elongated, irregular silhouette; still-then-sudden timing
