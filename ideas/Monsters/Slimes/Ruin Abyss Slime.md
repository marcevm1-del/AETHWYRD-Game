---
type: monster
id: mon_ruin_abyss_slime
family: "Slimes"
rank: "S+"
tier: variant
tags: [monster, slimes]
---
# Ruin Abyss Slime

> The Ruin Abyss Slime is a large creature with a teardrop-shaped jelly body, about 4 m tall. Its gel is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Survivors describe starless black jelly that swallows all light. It has too many eyes, opening one after another. Its regal silhouette is crowned by a halo-like ring of aura. It unfolds into something larger, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Abyss Slime\|Abyss Slime]] (regional) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 4 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 29128 · 658 · 493 · 493 · 493 · 110 |
| XP · gold | 14769 · 2553 |
| Ring | 7 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_slime_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
