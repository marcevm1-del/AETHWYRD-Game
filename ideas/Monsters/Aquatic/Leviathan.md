---
type: monster
id: mon_leviathan
family: "Aquatic"
rank: "EX"
tier: core
tags: [monster, aquatic, unique]
---
# Leviathan

> The Leviathan is a colossal creature with a heavy-jawed fish frame, about 600 m long. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Look for a body so vast it moves the horizon. It has eyes that catch torchlight like coins. Its presence is world-scale; the sky changes color when it appears. It strides with heavy steps, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | EX · 300 (300–300) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 600 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 163889 · 1513 · 1089 · 1089 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 6 |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Breach Lunge | dash | 1.7 | 9 s | None | red |
| Thrash | aoe | 1.3 | 8 s | None | red |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_aquatic_ex`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
