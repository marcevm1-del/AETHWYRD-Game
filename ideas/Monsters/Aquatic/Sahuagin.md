---
type: monster
id: mon_sahuagin
family: "Aquatic"
rank: "D"
tier: core
tags: [monster, aquatic]
---
# Sahuagin

> The Sahuagin is a person-sized creature with a lean humanoid frame, about 1.9 m tall. Its scales and skin are rough, scarred and spiked, colored in deep blues with a glassy shine. Guild sketches always show a shark-like head and webbed hands. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 1.9 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4168 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Greymoor\|Greymoor]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_aquatic_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Aquatic/Vesper-Touched Sahuagin|Vesper-Touched Sahuagin]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
