---
type: monster
id: mon_goblin
family: "Goblinoids"
rank: "F-"
tier: core
tags: [monster, goblinoids]
---
# Goblin

> The Goblin is a small creature with a hunched, wiry humanoid frame, about 1 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Guild sketches always show a grin of needle teeth under a stolen tin helmet. It has burning slit pupils. It has no ornament at all: simple, readable shapes. It circles its prey. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | F- · 3 (2–6) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 91 · 22 · 18 · 11 · 18 · 135 |
| XP · gold | 25 · 10 |
| Ring | 0 |
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

## Loot (`loot_goblinoid_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Grove Goblin|Grove Goblin]]
- [[Monsters/Goblinoids/Meadow Goblin|Meadow Goblin]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
