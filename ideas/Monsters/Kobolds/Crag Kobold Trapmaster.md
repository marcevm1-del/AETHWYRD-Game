---
type: monster
id: mon_crag_kobold_trapmaster
family: "Kobolds"
rank: "D+"
tier: variant
tags: [monster, kobolds]
---
# Crag Kobold Trapmaster

> The Crag Kobold Trapmaster is a small creature with a small, compact humanoid body, about 1 m tall. Its mangy fur is rough, scarred and spiked, colored in ochre, clay and mossy stone. Guild sketches always show a harness of gears, springs and tripwires. It has burning slit pupils. A distinctive marking runs along its back. It circles its prey, surrounded by pebbles that tremble and float near it. Adapted to mountain lands, it has slate-grey coloring and hardened hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Trapmaster\|Kobold Trapmaster]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3257 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Trip-Wire Trap | debuff | 0 | 14 s | None | none |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_kobold_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
