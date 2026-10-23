---
type: monster
id: mon_goblin_archer
family: "Goblinoids"
rank: "F+"
tier: core
tags: [monster, goblinoids]
---
# Goblin Archer

> The Goblin Archer is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Survivors describe a crooked bow strung with gut and a quiver of bone-tipped arrows. It has narrow glowing eyes. It has no ornament at all: simple, readable shapes. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | F+ · 13 (8–19) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 410 · 62 · 50 · 30 · 50 · 135 |
| XP · gold | 190 · 57 |
| Ring | 1 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

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

- [[Monsters/Goblinoids/Phantom Goblin Archer|Phantom Goblin Archer]]
- [[Monsters/Goblinoids/Ancient Goblin Archer|Ancient Goblin Archer]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
