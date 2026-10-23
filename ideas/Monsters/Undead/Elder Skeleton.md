---
type: monster
id: mon_elder_skeleton
family: "Undead"
rank: "E+"
tier: variant
tags: [monster, undead]
---
# Elder Skeleton

> The Elder Skeleton is a large creature with a lean humanoid frame, about 2.7 m tall. Its flesh and bone are rough, scarred and spiked, colored in ink black with bruised violet. Guild sketches always show yellowed bones held together by blue grave-light. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It strides with heavy steps, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Skeleton\|Skeleton]] (elder) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2.7 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2600 · 166 · 138 · 110 · 124 · 100 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
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

## Loot (`loot_undead_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
