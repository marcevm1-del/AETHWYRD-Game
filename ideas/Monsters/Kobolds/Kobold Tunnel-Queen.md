---
type: monster
id: mon_kobold_tunnel_queen
family: "Kobolds"
rank: "B"
tier: core
tags: [monster, kobolds]
---
# Kobold Tunnel-Queen

> The Kobold Tunnel-Queen is a person-sized creature with a small, compact humanoid body, about 1.6 m tall. Its mangy fur is rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe a bloated, jewel-encrusted body carried on a litter. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1.6 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10108 · 442 · 354 · 309 · 354 · 135 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Apu Highlands\|Apu Highlands]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Flees when hurt. Snares or ranged attacks work best.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Trip-Wire Trap | debuff | 0 | 14 s | None | none |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_kobold_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Kobolds/Vesper-Touched Kobold Tunnel-Queen|Vesper-Touched Kobold Tunnel-Queen]]
- [[Monsters/Kobolds/Kobold Tunnel-Queen Veteran|Kobold Tunnel-Queen Veteran]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
