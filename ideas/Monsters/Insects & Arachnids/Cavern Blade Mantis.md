---
type: monster
id: mon_cavern_blade_mantis
family: "Insects & Arachnids"
rank: "C-"
tier: variant
tags: [monster, insects-arachnids]
---
# Cavern Blade Mantis

> The Cavern Blade Mantis is a person-sized creature with a segmented six-limbed frame, about 2 m long. Its chitin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Guild sketches always show forearms shaped like curved scythes. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by pebbles that tremble and float near it. Adapted to cave lands, it has pale, light-starved coloring and oversized eyes.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Blade Mantis\|Blade Mantis]] (regional) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8447 · 270 · 405 · 162 · 270 · 70 |
| XP · gold | 2395 · 521 |
| Ring | 4 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Umbravel\|Umbravel]] |
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

## Loot (`loot_insect_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
