---
type: monster
id: mon_giant_crab
family: "Aquatic"
rank: "F"
tier: core
tags: [monster, aquatic]
---
# Giant Crab

> The Giant Crab is a small creature with a low, wide insectoid build, about 1 m long. Its scales and skin are weathered and natural, colored in deep blues with a glassy shine. Guild sketches always show one claw much bigger than the other. It has dark, wary eyes. It has no ornament at all: simple, readable shapes. It lopes in long strides, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 1 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 369 · 42 · 63 · 25 · 42 · 70 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Mandible Crush | melee | 1.1 | 0 s | None | blue |
| Burrow Ambush | dash | 1.5 | 10 s | None | red |
| Acid Spray | ranged | 1 | 6 s | None | blue |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_aquatic_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aquatic/Reef Crab|Reef Crab]]

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
