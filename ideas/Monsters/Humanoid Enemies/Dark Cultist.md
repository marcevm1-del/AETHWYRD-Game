---
type: monster
id: mon_dark_cultist
family: "Humanoid Enemies"
rank: "C"
tier: core
tags: [monster, humanoid-enemies]
---
# Dark Cultist

> The Dark Cultist is a person-sized creature with a broad-shouldered humanoid build, about 1.8 m tall. Its clothing and gear are patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Survivors describe red robes and a mask shaped like a crescent moon. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Humanoid Enemies|Humanoid Enemies]] · Humanoid |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 8073 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Low Fantasy |
| Trope | Bandits, cultists and fallen heroes |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Feint Strike | counter | 1.2 | 8 s | None | blue |
| Blood Lance | magic | 1.5 | 10 s | Blood | red |

## Loot (`loot_humanoid_enemy_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Coin Purse\|Coin Purse]] | 60% | 1–3 |
| [[Items/Weapon\|Weapon]] | 30% | 1–1 |
| [[Items/Bounty Proof\|Bounty Proof]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Humanoid Enemies/Dark Cultist Veteran|Dark Cultist Veteran]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `cloth_leather_metal` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
