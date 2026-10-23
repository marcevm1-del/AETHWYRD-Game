---
type: monster
id: mon_hollow_mourner
family: "Undead"
rank: "F"
tier: core
tags: [monster, undead]
---
# Hollow Mourner

> The Hollow Mourner is a person-sized creature with a lean humanoid frame, about 1.7 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Guild sketches always show a weeping figure that moves only when you look away. It has pale, pupil-less eyes. It has no ornament at all: simple, readable shapes. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | F · 8 (3–13) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 347 · 50 · 42 · 34 · 38 · 100 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

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

- [[Monsters/Undead/Greater Hollow Mourner|Greater Hollow Mourner]]
- [[Monsters/Undead/Vesper-Touched Hollow Mourner|Vesper-Touched Hollow Mourner]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
