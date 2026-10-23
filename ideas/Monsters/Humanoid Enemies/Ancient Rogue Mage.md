---
type: monster
id: mon_ancient_rogue_mage
family: "Humanoid Enemies"
rank: "B"
tier: variant
tags: [monster, humanoid-enemies]
---
# Ancient Rogue Mage

> The Ancient Rogue Mage is a large creature with a broad-shouldered humanoid build, about 2.7 m tall. Its clothing and gear are rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is burnt academy robes and ink-stained fingers. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Rogue Mage\|Rogue Mage]] (ancient) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.7 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15642 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Feint Strike | counter | 1.2 | 8 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_humanoid_enemy_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
