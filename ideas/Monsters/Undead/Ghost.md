---
type: monster
id: mon_ghost
family: "Undead"
rank: "E"
tier: core
tags: [monster, undead]
---
# Ghost

> The Ghost is a person-sized creature with a bodiless, glowing form, about 1.7 m tall. Its flesh and bone are rough, scarred and spiked, colored in ink black with bruised violet. Look for a translucent figure frozen in its last moment. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.7 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1198 · 68 · 80 · 160 · 148 · 90 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor\|Greymoor]], [[Regions/Lirian\|Lirian]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_undead_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Vesper-Touched Ghost|Vesper-Touched Ghost]]
- [[Monsters/Undead/Blight Ghost|Blight Ghost]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
