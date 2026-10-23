---
type: monster
id: mon_rime_wyvern
family: "Dragons"
rank: "B+"
tier: variant
tags: [monster, dragons]
---
# Rime Wyvern

> The Rime Wyvern is a huge creature with a sleek flying build, about 8 m long. Its scales are rough, scarred and spiked, colored in pale blues and frost-white. Its most striking feature is tattered wings and a venom-tipped tail. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It circles its prey, surrounded by falling snow motes and frosted ground where it steps. Adapted to tundra lands, it has a thick, frost-rimed coat.

| Field | Value |
|---|---|
| Family · type | [[Families/Dragons|Dragons]] · Dragon |
| Variant of | [[Monsters/Dragons/Wyvern\|Wyvern]] (regional) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 8 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25852 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Habitats | [[Regions/Whitewater Reach\|Whitewater Reach]], [[Regions/Frostveil\|Frostveil]] |
| Genre | High Fantasy |
| Trope | Dragons as proud, intelligent apex beings; wyverns as their lesser kin |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Talon Rake | melee | 1.2 | 0 s | None | blue |
| Dive Bomb | dash | 1.9 | 10 s | None | red |
| Tail Whip | aoe | 1.3 | 6 s | None | red |
| Wing Buffet | aoe | 1.1 | 9 s | None | blue |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_draconic_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Dragon Scale\|Dragon Scale]] | 60% | 1–3 |
| [[Items/Dragon Blood\|Dragon Blood]] | 30% | 1–1 |
| [[Items/Dragon Heart\|Dragon Heart]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `dragon_scale` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
