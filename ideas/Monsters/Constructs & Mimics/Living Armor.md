---
type: monster
id: mon_living_armor
family: "Constructs & Mimics"
rank: "E+"
tier: core
tags: [monster, constructs-mimics]
---
# Living Armor

> The Living Armor is a person-sized creature with an upright humanoid build, about 1.9 m tall. Its surface is rough, scarred and spiked, colored in muted greys and dusty browns. Survivors describe an empty suit of plate that walks. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It strides with heavy steps. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.9 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2306 · 166 · 138 · 77 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Lirian\|Lirian]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Rune Pulse | magic | 1.3 | 10 s | None | red |

## Loot (`loot_construct_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Greater Living Armor|Greater Living Armor]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
