---
type: monster
id: mon_ruin_goblin_bomber
family: "Goblinoids"
rank: "D+"
tier: variant
tags: [monster, goblinoids]
---
# Ruin Goblin Bomber

> The Ruin Goblin Bomber is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is rough, scarred and spiked, colored in ink black with bruised violet. Look for a barrel of black powder strapped to its back and a lit fuse in its teeth. It has burning slit pupils. A distinctive marking runs along its back. It charges without hesitation, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Bomber\|Goblin Bomber]] (regional) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3257 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_goblinoid_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
