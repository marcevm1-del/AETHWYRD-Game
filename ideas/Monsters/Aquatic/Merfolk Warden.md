---
type: monster
id: mon_merfolk_warden
family: "Aquatic"
rank: "A"
tier: core
tags: [monster, aquatic]
---
# Merfolk Warden

> The Merfolk Warden is a person-sized creature with a humanoid upper body on a long serpent tail, about 2.2 m long. Its scales and skin are weathered and natural, colored in deep blues with a glassy shine. Guild sketches always show coral armor and a trident. It has amber predator eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It prowls, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | A · 146 (132–159) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 2.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22880 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Whitewater Reach\|Whitewater Reach]], [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Stormreach\|Stormreach]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Coil Strike | melee | 1.1 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Hypnotic Gaze | debuff | 0 | 14 s | None | none |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_aquatic_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Aquatic/Bog Merfolk Warden|Bog Merfolk Warden]]

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
