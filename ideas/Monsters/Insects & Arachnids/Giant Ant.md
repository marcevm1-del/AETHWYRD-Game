---
type: monster
id: mon_giant_ant
family: "Insects & Arachnids"
rank: "F"
tier: core
tags: [monster, insects-arachnids]
---
# Giant Ant

> The Giant Ant is a small creature with a low, wide insectoid build, about 0.6 m long. Its chitin is weathered and natural, colored in ochre, clay and mossy stone. Its most striking feature is red-brown chitin and mandibles like pliers. It has dark, wary eyes. It has no ornament at all: simple, readable shapes. It stalks low to the ground, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.6 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 316 · 42 · 63 · 25 · 42 · 70 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
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

## Loot (`loot_insect_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Ancient Giant Ant|Ancient Giant Ant]]
- [[Monsters/Insects & Arachnids/Greater Giant Ant|Greater Giant Ant]]

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
