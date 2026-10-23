---
type: monster
id: mon_zombie
family: "Undead"
rank: "F"
tier: core
tags: [monster, undead]
---
# Zombie

> The Zombie is a person-sized creature with an upright humanoid build, about 1.7 m tall. Its flesh and bone are rough, scarred and spiked, colored in ink black with bruised violet. Guild sketches always show grey skin, burial clothes and a slack jaw. It has eyes that catch torchlight like coins. It has no ornament at all: simple, readable shapes. It strides with heavy steps, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | F · 8 (3–13) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 347 · 50 · 42 · 34 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
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
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_undead_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Vesper-Touched Zombie|Vesper-Touched Zombie]]
- [[Monsters/Undead/Dawn Zombie|Dawn Zombie]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
