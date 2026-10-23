---
type: monster
id: mon_ancient_cave_spider
family: "Insects & Arachnids"
rank: "E+"
tier: variant
tags: [monster, insects-arachnids]
---
# Ancient Cave Spider

> The Ancient Cave Spider is a small creature with an eight-legged arachnid body, about 1 m long. Its chitin is rough, scarred and spiked, colored in bruise purple with sickly green. Guild sketches always show a pale body that glows faintly in the dark. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by a low toxic haze that clings to the ground. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Cave Spider\|Cave Spider]] (ancient) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1436 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
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
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_insect_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
