---
type: monster
id: mon_goblin_wolf_rider
family: "Goblinoids"
rank: "D"
tier: core
tags: [monster, goblinoids]
---
# Goblin Wolf Rider

> The Goblin Wolf Rider is a small creature with a small, compact humanoid body, about 1 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Look for a bone saddle on a snarling war-wolf mount. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It circles its prey. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2595 · 202 · 162 · 99 · 162 · 135 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]], [[Regions/Aldmere\|Aldmere]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]] |
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

## Loot (`loot_goblinoid_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Ancient Goblin Wolf Rider|Ancient Goblin Wolf Rider]]
- [[Monsters/Goblinoids/Phantom Goblin Wolf Rider|Phantom Goblin Wolf Rider]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
