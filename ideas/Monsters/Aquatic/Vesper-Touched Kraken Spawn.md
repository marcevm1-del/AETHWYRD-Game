---
type: monster
id: mon_vesper_touched_kraken_spawn
family: "Aquatic"
rank: "A"
tier: variant
tags: [monster, aquatic]
---
# Vesper-Touched Kraken Spawn

> The Vesper-Touched Kraken Spawn is a colossal creature with a huge many-armed sea body, about 25 m long. Its scales and skin are stretched, stitched and constantly shifting, colored in deep blues with a glassy shine. Its most striking feature is a galleon-sized body with hooked tentacles. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It copies the walk of whatever it hunts, surrounded by fine mist and droplets that orbit it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Kraken Spawn\|Kraken Spawn]] (corrupted) |
| Rank · level | A · 146 (132–159) |
| Menace | 5 · Horror |
| Element · weakness | Water · Lightning |
| Size | 25 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 42476 · 743 · 535 · 535 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/True-Name Isles\|True-Name Isles]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Tentacle Slap | melee | 1.1 | 0 s | None | blue |
| Drag Under | grab | 1.8 | 12 s | None | gold |
| Ink Cloud | debuff | 0 | 14 s | None | none |
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

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · broken symmetry, mimicry, audio-first reveal
