---
type: monster
id: mon_fire_giant
family: "Orcs, Ogres & Giants"
rank: "A+"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Fire Giant

> The Fire Giant is a huge creature with a giant, barrel-chested humanoid body, about 9 m tall. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Look for skin like cooling lava and a forge-hammer. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 51829 · 646 · 969 · 388 · 646 · 70 |
| XP · gold | 9993 · 1815 |
| Ring | 4 |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Zaruma\|Zaruma]], [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| War Cry | buff | 0 | 18 s | None | none |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_orc_giant_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Cinder Giant|Cinder Giant]]

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
