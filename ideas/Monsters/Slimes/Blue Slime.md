---
type: monster
id: mon_blue_slime
family: "Slimes"
rank: "F-"
tier: core
tags: [monster, slimes]
---
# Blue Slime

> The Blue Slime is a tiny creature with a dome-shaped gelatinous body, about 0.4 m tall. Its gel is smooth and clean, colored in deep blues with a glassy shine. Survivors describe a teardrop body with a glossy highlight and two dot eyes. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | F- · 3 (1–4) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 57 · 18 · 13 · 13 · 13 · 110 |
| XP · gold | 25 · 10 |
| Ring | 0 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Lightning. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_slime_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Meadow Slime|Meadow Slime]]
- [[Monsters/Slimes/Night Slime|Night Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
