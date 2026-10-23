---
type: monster
id: mon_hive_mother_of_the_abyss
family: "Insects & Arachnids"
rank: "EX"
tier: core
tags: [monster, insects-arachnids, unique]
---
# Hive Mother of the Abyss

> The Hive Mother of the Abyss is a colossal creature with an asymmetric body with too many limbs, about 60 m tall. Its chitin is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Look for a living hive-mountain that sings. It has a human-like face in the wrong place. Its presence is world-scale; the sky changes color when it appears. It crawls across ceilings, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | EX · 300 (300–300) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 60 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 150723 · 1513 · 1089 · 1089 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 8 |
| Habitats | [[Regions/The Maw\|The Maw]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Grasp | melee | 1.2 | 0 s | None | blue |
| Unfold | aoe | 1.8 | 12 s | None | red |
| Mimic Voice | debuff | 0 | 18 s | None | none |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Null Rift | magic | 1.5 | 10 s | Void | red |

## Loot (`loot_insect_ex`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `chitin_gloss` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
