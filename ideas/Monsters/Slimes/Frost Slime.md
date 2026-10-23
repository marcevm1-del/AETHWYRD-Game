---
type: monster
id: mon_frost_slime
family: "Slimes"
rank: "D"
tier: core
tags: [monster, slimes]
---
# Frost Slime

> The Frost Slime is a small creature with a wobbling mound of translucent gel, about 0.5 m tall. Its gel is weathered and natural, colored in pale blues and frost-white. Guild sketches always show frost crystals growing from its crown. It has alert animal eyes. A distinctive marking runs along its back. It prowls, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Ice · Fire |
| Size | 0.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1738 · 162 · 121 · 121 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_slime_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Elder Frost Slime|Elder Frost Slime]]
- [[Monsters/Slimes/Vesper-Touched Frost Slime|Vesper-Touched Frost Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · real-animal silhouette with one fantasy exaggeration
