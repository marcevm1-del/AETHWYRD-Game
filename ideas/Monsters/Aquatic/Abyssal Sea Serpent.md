---
type: monster
id: mon_abyssal_sea_serpent
family: "Aquatic"
rank: "C+"
tier: variant
tags: [monster, aquatic]
---
# Abyssal Sea Serpent

> The Abyssal Sea Serpent is a colossal creature with a massive snake-like frame, about 20 m long. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Guild sketches always show a long fin running down its spine. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by fine mist and droplets that orbit it. Adapted to sea lands, it has deep-water coloring and glowing lures.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Sea Serpent\|Sea Serpent]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 20 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15544 · 354 · 283 · 248 · 283 · 135 |
| XP · gold | 3743 · 769 |
| Ring | 6 |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Goldmere Coast\|Goldmere Coast]] |
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

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
