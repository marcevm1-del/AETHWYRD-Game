---
type: monster
id: mon_tide_bandit
family: "Humanoid Enemies"
rank: "F+"
tier: variant
tags: [monster, humanoid-enemies]
---
# Tide Bandit

> The Tide Bandit is a person-sized creature with an upright humanoid build, about 1.8 m tall. Its clothing and gear are rough, scarred and spiked, colored in deep blues with a glassy shine. Look for a patched cloak and a mismatched sword. It has burning slit pupils. It has no ornament at all: simple, readable shapes. It strides with heavy steps, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Variant of | [[Monsters/Humanoid Enemies/Bandit\|Bandit]] (elemental) |
| Rank · level | F+ · 13 (8–19) |
| Menace | 3 · Menacing |
| Element · weakness | Water · Lightning |
| Size | 1.8 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 646 · 74 · 62 · 50 · 56 · 100 |
| XP · gold | 190 · 57 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Lightning. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Feint Strike | counter | 1.2 | 8 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_humanoid_enemy_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · triangle-based silhouette, sharp asymmetric spikes
