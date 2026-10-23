---
type: monster
id: mon_elemental_primarch
family: "Elementals & Spirits"
rank: "EX"
tier: core
tags: [monster, elementals-spirits, unique]
---
# Elemental Primarch

> The Elemental Primarch is a colossal creature with a bodiless, glowing form, about 40 m tall. Its body is rough, scarred and spiked, colored in starless black with faint violet edges. Its most striking feature is four elements orbiting a void core. It has burning slit pupils. Its presence is world-scale; the sky changes color when it appears. It circles its prey, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | EX · 300 (300–300) |
| Menace | 3 · Menacing |
| Element · weakness | Void · Light |
| Size | 40 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 110916 · 726 · 847 · 1694 · 1573 · 90 |
| XP · gold | 551660 · 4409 |
| Ring | 8 |
| Habitats | [[Regions/Root of the World\|Root of the World]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Elemental Burst | magic | 1.4 | 9 s | None | red |
| Null Rift | magic | 1.5 | 10 s | Void | red |

## Loot (`loot_elemental_ex`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · triangle-based silhouette, sharp asymmetric spikes
