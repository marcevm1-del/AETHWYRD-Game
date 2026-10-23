---
type: monster
id: mon_primordial_ooze
family: "Slimes"
rank: "EX"
tier: core
tags: [monster, slimes, unique]
---
# Primordial Ooze

> The Primordial Ooze is a colossal creature with a dome-shaped gelatinous body, about 40 m tall. Its gel is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Its most striking feature is an ocean-sized mass that shows the faces of everything it has eaten. It has no eyes at all, only a wide and patient mouth. Its presence is world-scale; the sky changes color when it appears. It unfolds into something larger, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | EX · 300 (300–300) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 40 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 97052 · 968 · 726 · 726 · 726 · 110 |
| XP · gold | 551660 · 4409 |
| Ring | 8 |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
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
| Null Rift | magic | 1.5 | 10 s | Void | red |

## Loot (`loot_slime_ex`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
