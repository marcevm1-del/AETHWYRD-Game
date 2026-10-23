---
type: monster
id: mon_lantern_leech
family: "Undead"
rank: "F"
tier: core
tags: [monster, undead]
---
# Lantern Leech

> The Lantern Leech is a small creature with a massive snake-like frame, about 0.6 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Survivors describe a glow on its back like a lost traveler's lantern. It has eyes that never blink. It has no ornament at all: simple, readable shapes. It freezes whenever it is looked at, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | F · 8 (3–13) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 0.6 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 192 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Lightning. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_undead_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Ancient Lantern Leech|Ancient Lantern Leech]]
- [[Monsters/Undead/Greater Lantern Leech|Greater Lantern Leech]]

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `rot_bone` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
