---
type: monster
id: mon_siren
family: "Aquatic"
rank: "C+"
tier: core
tags: [monster, aquatic]
---
# Siren

> The Siren is a person-sized creature with a humanoid upper body on a long serpent tail, about 2 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Look for a fish tail and a voice that sounds like home. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10057 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 6 |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Stormreach\|Stormreach]], [[Regions/Hollow Sea\|Hollow Sea]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Coil Strike | melee | 1.1 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Hypnotic Gaze | debuff | 0 | 14 s | None | none |
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

- [[Monsters/Aquatic/Ancient Siren|Ancient Siren]]

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
