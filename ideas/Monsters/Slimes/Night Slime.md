---
type: monster
id: mon_night_slime
family: "Slimes"
rank: "F"
tier: variant
tags: [monster, slimes]
---
# Night Slime

> The Night Slime is a tiny creature with a teardrop-shaped jelly body, about 0.4 m tall. Its gel is smooth and clean, colored in ink black with bruised violet. Guild sketches always show a teardrop body with a glossy highlight and two dot eyes. It has wide curious eyes with star-shaped highlights. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by shadows that lean toward it. This Dark-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Blue Slime\|Blue Slime]] (elemental) |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Dark · Light |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 142 · 34 · 25 · 25 · 25 · 110 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_slime_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · circle-based, soft silhouette
