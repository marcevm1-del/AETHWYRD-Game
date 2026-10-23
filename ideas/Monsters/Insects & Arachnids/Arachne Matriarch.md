---
type: monster
id: mon_arachne_matriarch
family: "Insects & Arachnids"
rank: "S"
tier: core
tags: [monster, insects-arachnids]
---
# Arachne Matriarch

> The Arachne Matriarch is a huge creature with a squat, many-legged arachnid build, about 8 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Survivors describe a crown of silk and eight eyes like jewels. It has pale, pupil-less eyes. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | S · 188 (173–203) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 8 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 39076 · 762 · 610 · 533 · 610 · 135 |
| XP · gold | 13063 · 2293 |
| Ring | 4 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/The Maw\|The Maw]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Fang Bite | melee | 1.1 | 0 s | None | blue |
| Web Shot | ranged | 0.5 | 8 s | None | blue |
| Ceiling Drop | dash | 1.7 | 12 s | None | red |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_insect_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Greater Arachne Matriarch|Greater Arachne Matriarch]]
- [[Monsters/Insects & Arachnids/Sky Arachne Matriarch|Sky Arachne Matriarch]]

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
