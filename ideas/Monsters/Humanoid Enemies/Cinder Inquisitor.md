---
type: monster
id: mon_cinder_inquisitor
family: "Humanoid Enemies"
rank: "B+"
tier: variant
tags: [monster, humanoid-enemies]
---
# Cinder Inquisitor

> The Cinder Inquisitor is a person-sized creature with a lean humanoid frame, about 1.9 m tall. Its clothing and gear are rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe silver anti-magic chains and a sun-shaped mask. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Inquisitor\|Inquisitor]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1.9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16235 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 6 |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

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
