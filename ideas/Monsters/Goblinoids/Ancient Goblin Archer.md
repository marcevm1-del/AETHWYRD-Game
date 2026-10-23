---
type: monster
id: mon_ancient_goblin_archer
family: "Goblinoids"
rank: "E+"
tier: variant
tags: [monster, goblinoids]
---
# Ancient Goblin Archer

> The Ancient Goblin Archer is a person-sized creature with a small, compact humanoid body, about 1.5 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Guild sketches always show a crooked bow strung with gut and a quiver of bone-tipped arrows. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It charges without hesitation. It has no visible aura; you hear its breathing before you see it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Archer\|Goblin Archer]] (ancient) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1644 · 138 · 110 · 68 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
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

## Loot (`loot_goblinoid_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
