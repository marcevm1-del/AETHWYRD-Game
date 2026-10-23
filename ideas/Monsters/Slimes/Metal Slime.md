---
type: monster
id: mon_metal_slime
family: "Slimes"
rank: "D"
tier: core
tags: [monster, slimes]
---
# Metal Slime

> The Metal Slime is a tiny creature with a dome-shaped gelatinous body, about 0.3 m tall. Its gel is smooth and clean, colored in ochre, clay and mossy stone. Look for mirror-chrome skin that reflects the world around it. It has big round glossy eyes. A distinctive marking runs along its back. It hops in little bursts, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | D · 48 (40–56) |
| Menace | 1 · Charming |
| Element · weakness | Earth · Wind |
| Size | 0.3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1539 · 162 · 121 · 121 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_slime_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Gilded Slime|Gilded Slime]]
- [[Monsters/Slimes/Vesper-Touched Metal Slime|Vesper-Touched Metal Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · circle-based, soft silhouette
