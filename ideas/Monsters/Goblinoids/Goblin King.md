---
type: monster
id: mon_goblin_king
family: "Goblinoids"
rank: "B"
tier: core
tags: [monster, goblinoids]
---
# Goblin King

> The Goblin King is a large creature with a massive hunched brute frame, about 2.8 m tall. Its skin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Look for throne-backed armor and a crown of hammered coins. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2.8 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20154 · 442 · 663 · 265 · 442 · 70 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_goblinoid_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Zephyr Goblin King|Zephyr Goblin King]]
- [[Monsters/Goblinoids/Ancient Goblin King|Ancient Goblin King]]

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `rough_skin_leather` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
