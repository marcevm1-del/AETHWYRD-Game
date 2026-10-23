---
type: monster
id: mon_kobold_scavenger
family: "Kobolds"
rank: "F"
tier: core
tags: [monster, kobolds]
---
# Kobold Scavenger

> The Kobold Scavenger is a small creature with a hunched, wiry humanoid frame, about 0.9 m tall. Its mangy fur is rough, scarred and spiked, colored in muted greys and dusty browns. Guild sketches always show a dog-like head with a chipped snout and a sack of stolen tools. It has eyes that catch torchlight like coins. It has no ornament at all: simple, readable shapes. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | F · 8 (3–13) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 0.9 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 217 · 42 · 34 · 21 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Aldmere\|Aldmere]] |
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

## Loot (`loot_kobold_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Kobolds/Kobold Scavenger Veteran|Kobold Scavenger Veteran]]
- [[Monsters/Kobolds/Phantom Kobold Scavenger|Phantom Kobold Scavenger]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
