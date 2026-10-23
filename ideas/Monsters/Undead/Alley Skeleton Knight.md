---
type: monster
id: mon_alley_skeleton_knight
family: "Undead"
rank: "C-"
tier: variant
tags: [monster, undead]
---
# Alley Skeleton Knight

> The Alley Skeleton Knight is a person-sized creature with an upright humanoid build, about 2 m tall. Its flesh and bone are rough, scarred and spiked, colored in muted greys and dusty browns. Its most striking feature is rusted plate armor and a shield it still keeps polished. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It charges without hesitation. It has no visible aura; you hear its breathing before you see it. Adapted to city lands, it has soot-stained hide and scavenged scraps.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Skeleton Knight\|Skeleton Knight]] (regional) |
| Rank · level | C- · 65 (56–76) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6637 · 324 · 270 · 151 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |

## Loot (`loot_undead_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
