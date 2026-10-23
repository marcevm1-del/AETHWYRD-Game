---
type: monster
id: mon_ruin_ooze
family: "Slimes"
rank: "C+"
tier: variant
tags: [monster, slimes]
---
# Ruin Ooze

> The Ruin Ooze is a person-sized creature with a dome-shaped gelatinous body, about 1.5 m tall. Its gel is rough, scarred and spiked, colored in ink black with bruised violet. Survivors describe molten trails that harden into glass behind it. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Ember Ooze\|Ember Ooze]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.5 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5800 · 283 · 212 · 212 · 212 · 110 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
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

## Loot (`loot_slime_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
