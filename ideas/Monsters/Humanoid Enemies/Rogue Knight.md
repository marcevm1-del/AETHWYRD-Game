---
type: monster
id: mon_rogue_knight
family: "Humanoid Enemies"
rank: "A"
tier: core
tags: [monster, humanoid-enemies]
---
# Rogue Knight

> The Rogue Knight is a person-sized creature with a lean humanoid frame, about 2 m tall. Its clothing and gear are rough, scarred and spiked, colored in muted greys and dusty browns. Look for a broken oath engraved on its blade. It has eyes that catch torchlight like coins. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 22146 · 713 · 594 · 333 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Quaking Lands\|Quaking Lands]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Gearholm\|Gearholm]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Feint Strike | counter | 1.2 | 8 s | None | blue |

## Loot (`loot_humanoid_enemy_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Zephyr Rogue Knight|Zephyr Rogue Knight]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
