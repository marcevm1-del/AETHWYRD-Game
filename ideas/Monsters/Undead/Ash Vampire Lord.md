---
type: monster
id: mon_ash_vampire_lord
family: "Undead"
rank: "S+"
tier: variant
tags: [monster, undead]
---
# Ash Vampire Lord

> The Ash Vampire Lord is a person-sized creature with a broad-shouldered humanoid build, about 2.2 m tall. Its flesh and bone are rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is a cape that dissolves into bats. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It circles its prey, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Vampire Lord\|Vampire Lord]] (elemental) |
| Rank · level | S+ · 203 (188–218) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 37457 · 986 · 822 · 658 · 740 · 100 |
| XP · gold | 14769 · 2553 |
| Ring | 9 |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_undead_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
