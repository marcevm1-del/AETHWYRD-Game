---
type: monster
id: mon_red_slime
family: "Slimes"
rank: "E"
tier: core
tags: [monster, slimes]
---
# Red Slime

> The Red Slime is a small creature with a dome-shaped gelatinous body, about 0.5 m tall. Its gel is weathered and natural, colored in ember reds fading to soot black. Its most striking feature is a faint ember core pulsing like a heartbeat. It has alert animal eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 0.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 713 · 91 · 68 · 68 · 68 · 110 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_slime_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Moss Slime|Moss Slime]]
- [[Monsters/Slimes/Vesper-Touched Red Slime|Vesper-Touched Red Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · real-animal silhouette with one fantasy exaggeration
