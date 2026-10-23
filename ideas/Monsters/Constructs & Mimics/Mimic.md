---
type: monster
id: mon_mimic
family: "Constructs & Mimics"
rank: "D"
tier: core
tags: [monster, constructs-mimics]
---
# Mimic

> The Mimic is a small creature with an object-shaped body that hides its true form, about 1 m tall. Its surface is stretched, stitched and constantly shifting, colored in muted greys and dusty browns. Look for a treasure chest with a tongue and a ring of teeth. It has no eyes at all, only a wide and patient mouth. A distinctive marking runs along its back. It crawls across ceilings. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Rank · level | D · 48 (40–56) |
| Menace | 5 · Horror |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3053 · 253 · 182 · 127 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Velmark\|Velmark]], [[Regions/Umbravel\|Umbravel]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chomp | melee | 1.6 | 0 s | None | red |
| Tongue Lash | grab | 1.4 | 6 s | None | gold |
| Disguise | stealth | 0 | 20 s | None | none |
| Rune Pulse | magic | 1.3 | 10 s | None | red |

## Loot (`loot_construct_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Constructs & Mimics/Cloud Mimic|Cloud Mimic]]

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `stone_metal_runes` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · broken symmetry, mimicry, audio-first reveal
