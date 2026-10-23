---
type: monster
id: mon_nameless_abomination
family: "Chimeras & Mythic Beasts"
rank: "EX"
tier: core
tags: [monster, chimeras-mythic-beasts, unique]
---
# Nameless Abomination

> The Nameless Abomination is a colossal creature with a tall, impossibly thin frame, about 50 m tall. Its hide is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Guild sketches always show a blank page given teeth. It has too many eyes, opening one after another. Its presence is world-scale; the sky changes color when it appears. It unfolds into something larger, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Rank · level | EX · 300 (300–300) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 50 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 145280 · 1513 · 1089 · 1089 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 8 |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Grasp | melee | 1.2 | 0 s | None | blue |
| Unfold | aoe | 1.8 | 12 s | None | red |
| Mimic Voice | debuff | 0 | 18 s | None | none |
| Many-Headed Bite | melee | 1.5 | 7 s | None | red |
| Null Rift | magic | 1.5 | 10 s | Void | red |

## Loot (`loot_chimera_ex`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `mixed_hide` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
