---
type: monster
id: mon_greater_sand_skink
family: "Sandborne"
rank: "E"
tier: variant
tags: [monster, sandborne]
---
# Greater Sand Skink

> The Greater Sand Skink is a small creature with a compact quadruped frame, about 0.8 m long. Its sand-scoured hide is weathered and natural, colored in ochre, clay and mossy stone. Look for sand-colored scales and a tongue that tastes for water. It has alert animal eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by pebbles that tremble and float near it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Variant of | [[Monsters/Sandborne/Sand Skink\|Sand Skink]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.8 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 992 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 7 |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Charge | dash | 1.3 | 5 s | None | blue |
| Leap | dash | 1.2 | 6 s | None | blue |
| Sand Burrow | dash | 1.5 | 10 s | None | red |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_sandborne_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `sand_hide` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
