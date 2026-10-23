---
type: monster
id: mon_dune_skeleton_knight
family: "Undead"
rank: "C-"
tier: variant
tags: [monster, undead]
---
# Dune Skeleton Knight

> The Dune Skeleton Knight is a person-sized creature with a lean humanoid frame, about 2 m tall. Its flesh and bone are rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe rusted plate armor and a shield it still keeps polished. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by pebbles that tremble and float near it. Adapted to desert lands, it has sun-bleached, sand-scoured coloring.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Skeleton Knight\|Skeleton Knight]] (regional) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6637 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 6 |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Wind. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_undead_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
