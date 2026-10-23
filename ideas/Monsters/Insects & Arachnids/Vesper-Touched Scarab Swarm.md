---
type: monster
id: mon_vesper_touched_scarab_swarm
family: "Insects & Arachnids"
rank: "S-"
tier: variant
tags: [monster, insects-arachnids]
---
# Vesper-Touched Scarab Swarm

> The Vesper-Touched Scarab Swarm is a tiny creature with a cloud of tiny creatures, each one is about 0.05 m long, but the swarm covers several meters. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is golden beetles that flow like spilled coins. It has eyes that never blink. Its regal silhouette is crowned by a halo-like ring of aura. It freezes whenever it is looked at, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Scarab Swarm\|Scarab Swarm]] (corrupted) |
| Rank · level | S- · 173 (159–188) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 0.05 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8626 · 562 · 421 · 421 · 421 · 110 |
| XP · gold | 11437 · 2042 |
| Ring | 5 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/The Maw\|The Maw]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nibble | melee | 0.6 | 0 s | None | none |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Scatter | evade | 0 | 10 s | None | none |
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

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
