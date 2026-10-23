---
type: monster
id: mon_skeleton_knight
family: "Undead"
rank: "D+"
tier: core
tags: [monster, undead]
---
# Skeleton Knight

> The Skeleton Knight is a person-sized creature with a lean humanoid frame, about 2 m tall. Its flesh and bone are rough, scarred and spiked, colored in ink black with bruised violet. Look for rusted plate armor and a shield it still keeps polished. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It strides with heavy steps, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5324 · 281 · 234 · 187 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Greymoor\|Greymoor]], [[Regions/Xochitl Mire\|Xochitl Mire]] |
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

## Loot (`loot_undead_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Alley Skeleton Knight|Alley Skeleton Knight]]
- [[Monsters/Undead/Dune Skeleton Knight|Dune Skeleton Knight]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
