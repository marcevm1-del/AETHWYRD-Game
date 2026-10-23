---
type: monster
id: mon_sea_serpent
family: "Aquatic"
rank: "C"
tier: core
tags: [monster, aquatic]
---
# Sea Serpent

> The Sea Serpent is a colossal creature with a long, sinuous serpentine body, about 20 m long. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Look for a long fin running down its spine. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 20 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12935 · 314 · 251 · 220 · 251 · 135 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Lirian\|Lirian]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_aquatic_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aquatic/Abyssal Sea Serpent|Abyssal Sea Serpent]]

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
