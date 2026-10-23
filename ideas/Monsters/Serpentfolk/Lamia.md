---
type: monster
id: mon_lamia
family: "Serpentfolk"
rank: "C"
tier: core
tags: [monster, serpentfolk]
---
# Lamia

> The Lamia is a large creature with an elegant serpentfolk build, about 3.5 m long. Its scales are rough, scarred and spiked, colored in bruise purple with sickly green. Survivors describe a coiling tail and hypnotic golden eyes. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 3.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10113 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Coil Strike | melee | 1.1 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Hypnotic Gaze | debuff | 0 | 14 s | None | none |
| Venom Coil | grab | 1.3 | 11 s | None | gold |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_serpentfolk_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Serpent Scale\|Serpent Scale]] | 60% | 1–3 |
| [[Items/Temple Gold\|Temple Gold]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Serpentfolk/Vine Lamia|Vine Lamia]]

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
