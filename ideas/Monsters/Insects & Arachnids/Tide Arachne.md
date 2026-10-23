---
type: monster
id: mon_tide_arachne
family: "Insects & Arachnids"
rank: "A-"
tier: variant
tags: [monster, insects-arachnids]
---
# Tide Arachne

> The Tide Arachne is a large creature with a squat, many-legged arachnid build, about 3 m long. Its chitin is rough, scarred and spiked, colored in deep blues with a glassy shine. Its most striking feature is a woman's upper body rising from a spider's. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Arachne\|Arachne]] (elemental) |
| Rank · level | A- · 132 (120–146) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 3 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16896 · 538 · 430 · 377 · 430 · 135 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Fang Bite | melee | 1.1 | 0 s | None | blue |
| Web Shot | ranged | 0.5 | 8 s | None | blue |
| Ceiling Drop | dash | 1.7 | 12 s | None | red |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_insect_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
