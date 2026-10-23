---
type: monster
id: mon_vesper_touched_hollow_mourner
family: "Undead"
rank: "E-"
tier: variant
tags: [monster, undead]
---
# Vesper-Touched Hollow Mourner

> The Vesper-Touched Hollow Mourner is a person-sized creature with an upright humanoid build, about 1.7 m tall. Its flesh and bone are stretched, stitched and constantly shifting, colored in ink black with bruised violet. Its most striking feature is a weeping figure that moves only when you look away. It has no eyes at all, only a wide and patient mouth. Small scars and rough edges mark it as a survivor. It crawls across ceilings, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Hollow Mourner\|Hollow Mourner]] (corrupted) |
| Rank · level | E- · 19 (13–26) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1059 · 103 · 86 · 69 · 77 · 100 |
| XP · gold | 342 · 96 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
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

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
