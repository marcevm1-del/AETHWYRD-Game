---
type: monster
id: mon_green_slime
family: "Slimes"
rank: "F"
tier: core
tags: [monster, slimes]
---
# Green Slime

> The Green Slime is a tiny creature with a wobbling mound of translucent gel, about 0.4 m tall. Its gel is smooth and clean, colored in leaf greens over bark brown. Its most striking feature is fallen leaves suspended inside its jelly. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It waddles, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Nature · Fire |
| Size | 0.4 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 142 · 34 · 25 · 25 · 25 · 110 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_slime_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Vesper-Touched Green Slime|Vesper-Touched Green Slime]]
- [[Monsters/Slimes/Gale Slime|Gale Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · circle-based, soft silhouette
