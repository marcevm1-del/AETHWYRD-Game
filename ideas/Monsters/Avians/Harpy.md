---
type: monster
id: mon_harpy
family: "Avians"
rank: "D"
tier: core
tags: [monster, avians]
---
# Harpy

> The Harpy is a person-sized creature with a broad-winged bird frame, about 1.6 m tall. Its plumage is rough, scarred and spiked, colored in pale jade and cloud white. Its most striking feature is a bird body with a shrieking human-like face. It has narrow glowing eyes. A distinctive marking runs along its back. It charges without hesitation, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 1.6 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3037 · 202 · 162 · 141 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 4 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Fanghold\|Fanghold]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Velmark\|Velmark]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Peck | melee | 1 | 0 s | None | blue |
| Swoop | dash | 1.4 | 6 s | None | blue |
| Screech | debuff | 0 | 14 s | None | none |
| Feather Volley | ranged | 1 | 6 s | None | blue |
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_avian_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Avians/Phantom Harpy|Phantom Harpy]]

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
