---
type: monster
id: mon_kobold_trapmaster
family: "Kobolds"
rank: "D"
tier: core
tags: [monster, kobolds]
---
# Kobold Trapmaster

> The Kobold Trapmaster is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its mangy fur is rough, scarred and spiked, colored in muted greys and dusty browns. Survivors describe a harness of gears, springs and tripwires. It has narrow glowing eyes. A distinctive marking runs along its back. It circles its prey. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2595 · 202 · 162 · 99 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Trip-Wire Trap | debuff | 0 | 14 s | None | none |

## Loot (`loot_kobold_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Kobolds/Vesper-Touched Kobold Trapmaster|Vesper-Touched Kobold Trapmaster]]
- [[Monsters/Kobolds/Crag Kobold Trapmaster|Crag Kobold Trapmaster]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
