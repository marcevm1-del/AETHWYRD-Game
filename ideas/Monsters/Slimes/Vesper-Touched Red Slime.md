---
type: monster
id: mon_vesper_touched_red_slime
family: "Slimes"
rank: "D-"
tier: variant
tags: [monster, slimes]
---
# Vesper-Touched Red Slime

> The Vesper-Touched Red Slime is a small creature with a teardrop-shaped jelly body, about 0.5 m tall. Its gel is rough, scarred and spiked, colored in ember reds fading to soot black. Guild sketches always show a faint ember core pulsing like a heartbeat. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Red Slime\|Red Slime]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1330 · 136 · 102 · 102 · 102 · 110 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_slime_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
