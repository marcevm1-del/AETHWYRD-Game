---
type: monster
id: mon_greater_core_sentinel
family: "Floor-born"
rank: "B"
tier: variant
tags: [monster, floor-born]
---
# Greater Core Sentinel

> The Greater Core Sentinel is a large creature with a blocky construct body, about 4 m tall. Its stone-like hide is rough, scarred and spiked, colored in warm gold and pearl white. Look for a dungeon-core crystal for a heart. It has narrow glowing eyes. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by soft radiance and floating motes of light. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Floor-born|Floor-born]] · Dungeon-born |
| Variant of | [[Monsters/Floor-born/Core Sentinel\|Core Sentinel]] (elder) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 4 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22688 · 442 · 663 · 265 · 442 · 70 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Habitats | [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Monsters born directly from dungeon walls (DanMachi); dungeon as ecosystem (Dungeon Meshi) |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slam | melee | 1.4 | 0 s | None | blue |
| Ground Pound | aoe | 1.8 | 10 s | None | red |
| Guard Stance | buff | 0 | 15 s | None | none |
| Wall Ambush | dash | 1.4 | 10 s | None | red |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_floorborn_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dungeon Core Shard\|Dungeon Core Shard]] | 60% | 1–3 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `dungeon_stone` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
