---
type: monster
id: mon_piranha_swarm
family: "Aquatic"
rank: "E"
tier: core
tags: [monster, aquatic]
---
# Piranha Swarm

> The Piranha Swarm is a tiny creature with a cloud of tiny creatures, each one is about 0.2 m long, but the swarm covers several meters. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Its most striking feature is silver flashes and red teeth. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It strides with heavy steps, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 0.2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 586 · 91 · 68 · 68 · 68 · 110 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]], [[Regions/Lirian\|Lirian]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nibble | melee | 0.6 | 0 s | None | none |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Scatter | evade | 0 | 10 s | None | none |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_aquatic_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aquatic/Bog Piranha Swarm|Bog Piranha Swarm]]

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
