---
type: monster
id: mon_queen_ant
family: "Insects & Arachnids"
rank: "C"
tier: core
tags: [monster, insects-arachnids]
---
# Queen Ant

> The Queen Ant is a large creature with a low, wide insectoid build, about 3.5 m long. Its chitin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Look for a swollen abdomen pulsing with eggs. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 3.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12871 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 4 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Zaruma\|Zaruma]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Mandible Crush | melee | 1.1 | 0 s | None | blue |
| Burrow Ambush | dash | 1.5 | 10 s | None | red |
| Acid Spray | ranged | 1 | 6 s | None | blue |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_insect_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Dune Queen Ant|Dune Queen Ant]]
- [[Monsters/Insects & Arachnids/Elder Queen Ant|Elder Queen Ant]]

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
