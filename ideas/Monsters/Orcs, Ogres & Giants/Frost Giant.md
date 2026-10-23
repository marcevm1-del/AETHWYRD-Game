---
type: monster
id: mon_frost_giant
family: "Orcs, Ogres & Giants"
rank: "A"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Frost Giant

> The Frost Giant is a huge creature with a massive hunched brute frame, about 9 m tall. Its hide is rough, scarred and spiked, colored in pale blues and frost-white. Survivors describe a beard of icicles and armor of glacier ice. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 45625 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Frostveil\|Frostveil]], [[Regions/Quaking Lands\|Quaking Lands]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| War Cry | buff | 0 | 18 s | None | none |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_orc_giant_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Frost Giant|Vesper-Touched Frost Giant]]

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
