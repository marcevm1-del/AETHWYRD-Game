---
type: monster
id: mon_vesper_touched_bone_crawler
family: "Undead"
rank: "E-"
tier: variant
tags: [monster, undead]
---
# Vesper-Touched Bone Crawler

> The Vesper-Touched Bone Crawler is a person-sized creature with an asymmetric body with too many limbs, about 1.4 m tall. Its flesh and bone are stretched, stitched and constantly shifting, colored in ink black with bruised violet. Survivors describe a skeleton reassembled wrong, crawling on its hands. It has no eyes at all, only a wide and patient mouth. Small scars and rough edges mark it as a survivor. It unfolds into something larger, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Bone Crawler\|Bone Crawler]] (corrupted) |
| Rank · level | E- · 19 (13–26) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 1.4 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 901 · 108 · 77 · 77 · 77 · 100 |
| XP · gold | 342 · 96 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Grasp | melee | 1.2 | 0 s | None | blue |
| Unfold | aoe | 1.8 | 12 s | None | red |
| Mimic Voice | debuff | 0 | 18 s | None | none |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_undead_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_aberrant` · mesh `aberrant_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
