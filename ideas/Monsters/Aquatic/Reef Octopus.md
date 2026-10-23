---
type: monster
id: mon_reef_octopus
family: "Aquatic"
rank: "B+"
tier: variant
tags: [monster, aquatic]
---
# Reef Octopus

> The Reef Octopus is a huge creature with a bulbous body with writhing arms, about 10 m long. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Guild sketches always show skin that changes color to match the rocks. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by fine mist and droplets that orbit it. Adapted to coast lands, it has salt-crusted, barnacle-flecked hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Giant Octopus\|Giant Octopus]] (regional) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 10 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25051 · 613 · 441 · 441 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Whitewater Reach\|Whitewater Reach]], [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Tentacle Slap | melee | 1.1 | 0 s | None | blue |
| Drag Under | grab | 1.8 | 12 s | None | gold |
| Ink Cloud | debuff | 0 | 14 s | None | none |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_aquatic_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
