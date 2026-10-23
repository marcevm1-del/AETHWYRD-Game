---
type: monster
id: mon_frost_hydra
family: "Reptiles"
rank: "A-"
tier: variant
tags: [monster, reptiles]
---
# Frost Hydra

> The Frost Hydra is a huge creature with a long, sinuous serpentine body, about 9 m long. Its scales are rough, scarred and spiked, colored in pale blues and frost-white. Guild sketches always show five heads on long necks, each with its own temper. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by falling snow motes and frosted ground where it steps. This Ice-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Hydra\|Hydra]] (elemental) |
| Rank · level | A- · 132 (120–146) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 9 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 23828 · 538 · 430 · 377 · 430 · 135 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Stormreach\|Stormreach]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Tail Lash | aoe | 1.2 | 7 s | None | blue |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_reptile_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `scale_matte` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
