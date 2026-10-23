---
type: monster
id: mon_naga_warrior
family: "Serpentfolk"
rank: "C+"
tier: core
tags: [monster, serpentfolk]
---
# Naga Warrior

> The Naga Warrior is a large creature with a coiling half-serpent frame, about 4 m long. Its scales are rough, scarred and spiked, colored in deep blues with a glassy shine. Look for four arms holding four blades. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Serpentfolk|Serpentfolk]] · Serpentfolk |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 4 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12698 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Jungle Temple |
| Trope | Lamia and naga temple guardians |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Coil Strike | melee | 1.1 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Hypnotic Gaze | debuff | 0 | 14 s | None | none |
| Venom Coil | grab | 1.3 | 11 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_serpentfolk_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Serpent Scale\|Serpent Scale]] | 60% | 1–3 |
| [[Items/Temple Gold\|Temple Gold]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Serpentfolk/Blaze Naga Warrior|Blaze Naga Warrior]]

## Design recipe

Rig `rig_naga` · mesh `naga_base` · material `scale_gloss` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
