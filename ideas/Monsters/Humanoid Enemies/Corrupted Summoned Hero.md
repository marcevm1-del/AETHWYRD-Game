---
type: monster
id: mon_corrupted_summoned_hero
family: "Humanoid Enemies"
rank: "EX"
tier: core
tags: [monster, humanoid-enemies, unique]
---
# Corrupted Summoned Hero

> The Corrupted Summoned Hero is a person-sized creature with an upright humanoid build, about 1.9 m tall. Its clothing and gear are patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Guild sketches always show a Veilborn swallowed by the red moon. It has eyes set slightly too far apart. Its presence is world-scale; the sky changes color when it appears. It moves in jerky stop-motion bursts, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | EX · 300 (300–300) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 1.9 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 63933 · 1452 · 1210 · 968 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 8 |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Feint Strike | counter | 1.2 | 8 s | None | blue |
| Blood Lance | magic | 1.5 | 10 s | Blood | red |

## Loot (`loot_humanoid_enemy_ex`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
