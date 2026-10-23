---
type: monster
id: mon_scarab_swarm
family: "Insects & Arachnids"
rank: "A"
tier: core
tags: [monster, insects-arachnids]
---
# Scarab Swarm

> The Scarab Swarm is a tiny creature with a swarm of many small bodies moving as one, each one is about 0.05 m long, but the swarm covers several meters. Its chitin is rough, scarred and spiked, colored in ink black with bruised violet. Look for golden beetles that flow like spilled coins. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 0.05 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6694 · 475 · 356 · 356 · 356 · 110 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Sunscar\|Sunscar]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nibble | melee | 0.6 | 0 s | None | none |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Scatter | evade | 0 | 10 s | None | none |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_insect_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Vesper-Touched Scarab Swarm|Vesper-Touched Scarab Swarm]]
- [[Monsters/Insects & Arachnids/Elder Scarab Swarm|Elder Scarab Swarm]]

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
