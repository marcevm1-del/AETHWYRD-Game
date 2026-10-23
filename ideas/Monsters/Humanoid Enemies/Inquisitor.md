---
type: monster
id: mon_inquisitor
family: "Humanoid Enemies"
rank: "B"
tier: core
tags: [monster, humanoid-enemies]
---
# Inquisitor

> The Inquisitor is a person-sized creature with an upright humanoid build, about 1.9 m tall. Its clothing and gear are rough, scarred and spiked, colored in warm gold and pearl white. Guild sketches always show silver anti-magic chains and a sun-shaped mask. It has burning slit pupils. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Light · Dark |
| Size | 1.9 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13874 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 5 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Dark. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Feint Strike | counter | 1.2 | 8 s | None | blue |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_humanoid_enemy_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Cinder Inquisitor|Cinder Inquisitor]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · triangle-based silhouette, sharp asymmetric spikes
