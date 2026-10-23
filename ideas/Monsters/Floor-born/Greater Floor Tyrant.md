---
type: monster
id: mon_greater_floor_tyrant
family: "Floor-born"
rank: "S"
tier: variant
tags: [monster, floor-born]
---
# Greater Floor Tyrant

> The Greater Floor Tyrant is a huge creature with a giant, barrel-chested humanoid body, about 12.8 m tall. Its stone-like hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Look for a crown of stalactites. It has eyes that catch torchlight like coins. Its regal silhouette is crowned by a halo-like ring of aura. It strides with heavy steps, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Floor Tyrant\|Floor Tyrant]] (elder) |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 12.8 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 73397 · 762 · 1143 · 457 · 762 · 70 |
| XP · gold | 13063 · 2293 |
| Ring | 7 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Wind. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| Wall Ambush | dash | 1.4 | 10 s | None | red |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_floorborn_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `dungeon_stone` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
