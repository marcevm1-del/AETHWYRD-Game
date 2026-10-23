---
type: monster
id: mon_kijin_warrior
family: "Goblinoids"
rank: "A"
tier: core
tags: [monster, goblinoids]
---
# Kijin Warrior

> The Kijin Warrior is a person-sized creature with a broad-shouldered humanoid build, about 2.4 m tall. Its skin is rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe twin horns, a disciplined stance and a lacquered blade. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.4 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 23570 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 4 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Moraveil\|Moraveil]], [[Regions/Zarvan\|Zarvan]], [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_goblinoid_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Elite Kijin Warrior|Elite Kijin Warrior]]
- [[Monsters/Goblinoids/Briar Kijin Warrior|Briar Kijin Warrior]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
