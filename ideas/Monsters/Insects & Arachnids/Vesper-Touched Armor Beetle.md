---
type: monster
id: mon_vesper_touched_armor_beetle
family: "Insects & Arachnids"
rank: "D"
tier: variant
tags: [monster, insects-arachnids]
---
# Vesper-Touched Armor Beetle

> The Vesper-Touched Armor Beetle is a person-sized creature with a segmented six-limbed frame, about 1.2 m long. Its chitin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Look for a shell like polished bronze. It has narrow glowing eyes. A distinctive marking runs along its back. It circles its prey, surrounded by pebbles that tremble and float near it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Armor Beetle\|Armor Beetle]] (corrupted) |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 1.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4539 · 202 · 303 · 121 · 202 · 70 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Mandible Crush | melee | 1.1 | 0 s | None | blue |
| Burrow Ambush | dash | 1.5 | 10 s | None | red |
| Acid Spray | ranged | 1 | 6 s | None | blue |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_insect_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
