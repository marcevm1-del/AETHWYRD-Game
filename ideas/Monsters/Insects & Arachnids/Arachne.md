---
type: monster
id: mon_arachne
family: "Insects & Arachnids"
rank: "B+"
tier: core
tags: [monster, insects-arachnids]
---
# Arachne

> The Arachne is a large creature with a bulbous spider frame on long jointed legs, about 3 m long. Its chitin is rough, scarred and spiked, colored in ink black with bruised violet. Its most striking feature is a woman's upper body rising from a spider's. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 14655 · 490 · 392 · 343 · 392 · 135 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Fang Bite | melee | 1.1 | 0 s | None | blue |
| Web Shot | ranged | 0.5 | 8 s | None | blue |
| Ceiling Drop | dash | 1.7 | 12 s | None | red |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_insect_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Tide Arachne|Tide Arachne]]
- [[Monsters/Insects & Arachnids/Frost Arachne|Frost Arachne]]

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
