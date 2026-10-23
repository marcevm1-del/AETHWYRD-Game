---
type: monster
id: mon_zephyr_rogue_knight
family: "Humanoid Enemies"
rank: "A+"
tier: variant
tags: [monster, humanoid-enemies]
---
# Zephyr Rogue Knight

> The Zephyr Rogue Knight is a person-sized creature with a lean humanoid frame, about 2 m tall. Its clothing and gear are rough, scarred and spiked, colored in pale jade and cloud white. Its most striking feature is a broken oath engraved on its blade. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Rogue Knight\|Rogue Knight]] (elemental) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Wind · Fire |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25157 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Gearholm\|Gearholm]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Feint Strike | counter | 1.2 | 8 s | None | blue |
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_humanoid_enemy_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · triangle-based silhouette, sharp asymmetric spikes
