---
type: monster
id: mon_vine_lamia
family: "Serpentfolk"
rank: "C+"
tier: variant
tags: [monster, serpentfolk]
---
# Vine Lamia

> The Vine Lamia is a large creature with an elegant serpentfolk build, about 3.5 m long. Its scales are rough, scarred and spiked, colored in leaf greens over bark brown. Guild sketches always show a coiling tail and hypnotic golden eyes. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by drifting pollen and tiny blossoms. Adapted to jungle lands, it has vivid tropical markings.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Variant of | [[Monsters/Serpentfolk/Lamia\|Lamia]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 3.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12153 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 6 |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Coil Strike | melee | 1.1 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Hypnotic Gaze | debuff | 0 | 14 s | None | none |
| Venom Coil | grab | 1.3 | 11 s | None | gold |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_serpentfolk_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Serpent Scale\|Serpent Scale]] | 60% | 1–3 |
| [[Items/Temple Gold\|Temple Gold]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
