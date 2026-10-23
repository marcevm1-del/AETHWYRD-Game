---
type: monster
id: mon_kobold_sneak
family: "Kobolds"
rank: "E"
tier: core
tags: [monster, kobolds]
---
# Kobold Sneak

> The Kobold Sneak is a small creature with a small, compact humanoid body, about 0.8 m tall. Its mangy fur is rough, scarred and spiked, colored in ink black with bruised violet. Survivors describe soot-blackened fur for hiding in tunnels. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 0.8 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 992 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Light. Flees when hurt. Snares or ranged attacks work best.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Trip-Wire Trap | debuff | 0 | 14 s | None | none |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_kobold_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Kobolds/Snow Kobold Sneak|Snow Kobold Sneak]]
- [[Monsters/Kobolds/Phantom Kobold Sneak|Phantom Kobold Sneak]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
