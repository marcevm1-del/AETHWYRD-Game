---
type: monster
id: mon_vesper_touched_frost_slime
family: "Slimes"
rank: "C-"
tier: variant
tags: [monster, slimes]
---
# Vesper-Touched Frost Slime

> The Vesper-Touched Frost Slime is a small creature with a teardrop-shaped jelly body, about 0.5 m tall. Its gel is rough, scarred and spiked, colored in pale blues and frost-white. Survivors describe frost crystals growing from its crown. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by falling snow motes and frosted ground where it steps. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Frost Slime\|Frost Slime]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 0.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2719 · 216 · 162 · 162 · 162 · 110 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
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

## Loot (`loot_slime_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
