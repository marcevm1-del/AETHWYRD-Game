---
type: monster
id: mon_vampire_lord
family: "Undead"
rank: "S"
tier: core
tags: [monster, undead]
---
# Vampire Lord

> The Vampire Lord is a person-sized creature with a broad-shouldered humanoid build, about 2.2 m tall. Its flesh and bone are rough, scarred and spiked, colored in arterial crimson and dried-blood brown. Look for a cape that dissolves into bats. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It charges without hesitation, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Blood · Light |
| Size | 2.2 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 33392 · 914 · 762 · 610 · 686 · 100 |
| XP · gold | 13063 · 2293 |
| Ring | 8 |
| Habitats | [[Regions/Vesper\|Vesper]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Blood Lance | magic | 1.5 | 10 s | Blood | red |

## Loot (`loot_undead_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Undead/Ash Vampire Lord|Ash Vampire Lord]]
- [[Monsters/Undead/Rot Vampire Lord|Rot Vampire Lord]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · triangle-based silhouette, sharp asymmetric spikes
