---
type: monster
id: mon_alley_slaver
family: "Humanoid Enemies"
rank: "D+"
tier: variant
tags: [monster, humanoid-enemies]
---
# Alley Slaver

> The Alley Slaver is a person-sized creature with an upright humanoid build, about 1.9 m tall. Its clothing and gear are rough, scarred and spiked, colored in muted greys and dusty browns. Guild sketches always show chains on its belt and a cruel smile. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It circles its prey. It has no visible aura; you hear its breathing before you see it. Adapted to city lands, it has soot-stained hide and scavenged scraps.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Slaver\|Slaver]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5231 · 281 · 234 · 131 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Velmark\|Velmark]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Feint Strike | counter | 1.2 | 8 s | None | blue |

## Loot (`loot_humanoid_enemy_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
