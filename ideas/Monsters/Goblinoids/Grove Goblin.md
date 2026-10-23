---
type: monster
id: mon_grove_goblin
family: "Goblinoids"
rank: "F"
tier: variant
tags: [monster, goblinoids]
---
# Grove Goblin

> The Grove Goblin is a small creature with a small, compact humanoid body, about 1 m tall. Its skin is rough, scarred and spiked, colored in leaf greens over bark brown. Survivors describe a grin of needle teeth under a stolen tin helmet. It has narrow glowing eyes. It has no ornament at all: simple, readable shapes. It charges without hesitation, surrounded by drifting pollen and tiny blossoms. Adapted to forest lands, it has moss-green coloring that blends with the undergrowth.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin\|Goblin]] (regional) |
| Rank · level | F · 8 (3–13) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 1 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 224 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_goblinoid_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
