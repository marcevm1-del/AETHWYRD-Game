---
type: monster
id: mon_abyss_slime
family: "Slimes"
rank: "S"
tier: core
tags: [monster, slimes]
---
# Abyss Slime

> The Abyss Slime is a large creature with a teardrop-shaped jelly body, about 4 m tall. Its gel is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Look for starless black jelly that swallows all light. It has no eyes at all, only a wide and patient mouth. Its regal silhouette is crowned by a halo-like ring of aura. It crawls across ceilings, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | S · 188 (173–203) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 4 m |
| Behaviour | Passive (passive_wander+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25967 · 610 · 457 · 457 · 457 · 110 |
| XP · gold | 13063 · 2293 |
| Ring | 6 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
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

## Loot (`loot_slime_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Slimes/Ruin Abyss Slime|Ruin Abyss Slime]]
- [[Monsters/Slimes/Phantom Abyss Slime|Phantom Abyss Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
