---
type: monster
id: mon_mimic_king
family: "Constructs & Mimics"
rank: "A"
tier: core
tags: [monster, constructs-mimics]
---
# Mimic King

> The Mimic King is a huge creature with a disguised body pretending to be furniture, about 6 m tall. Its surface is stretched, stitched and constantly shifting, colored in muted greys and dusty browns. Its most striking feature is a treasure vault that walks on a hundred stolen legs. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It crawls across ceilings. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | A · 146 (132–159) |
| Menace | 5 · Horror |
| Element · weakness | None · Fire |
| Size | 6 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 28899 · 743 · 535 · 374 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Habitats | [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Sunscar\|Sunscar]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Zarvan\|Zarvan]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chomp | melee | 1.6 | 0 s | None | red |
| Tongue Lash | grab | 1.4 | 6 s | None | gold |
| Disguise | stealth | 0 | 20 s | None | none |
| Rune Pulse | magic | 1.3 | 10 s | None | red |

## Loot (`loot_construct_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Elder Mimic King|Elder Mimic King]]

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · broken symmetry, mimicry, audio-first reveal
