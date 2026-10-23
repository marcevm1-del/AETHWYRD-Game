---
type: monster
id: mon_sand_skink
family: "Sandborne"
rank: "F"
tier: core
tags: [monster, sandborne]
---
# Sand Skink

> The Sand Skink is a small creature with a small, quick four-legged body, about 0.5 m long. Its sand-scoured hide is weathered and natural, colored in ochre, clay and mossy stone. Its most striking feature is sand-colored scales and a tongue that tastes for water. It has alert animal eyes. It has no ornament at all: simple, readable shapes. It lopes in long strides, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 182 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 6 |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Dunewhale Drift\|Dunewhale Drift]], [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Charge | dash | 1.3 | 5 s | None | blue |
| Leap | dash | 1.2 | 6 s | None | blue |
| Sand Burrow | dash | 1.5 | 10 s | None | red |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_sandborne_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Sandborne/Greater Sand Skink|Greater Sand Skink]]

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `sand_hide` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
