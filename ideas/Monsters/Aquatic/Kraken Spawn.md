---
type: monster
id: mon_kraken_spawn
family: "Aquatic"
rank: "B+"
tier: core
tags: [monster, aquatic]
---
# Kraken Spawn

> The Kraken Spawn is a colossal creature with a huge many-armed sea body, about 25 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Look for a galleon-sized body with hooked tentacles. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 25 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 31691 · 613 · 441 · 441 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 3 |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Whitewater Reach\|Whitewater Reach]], [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Lirian\|Lirian]] |
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

## Variants

- [[Monsters/Aquatic/Vesper-Touched Kraken Spawn|Vesper-Touched Kraken Spawn]]

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
