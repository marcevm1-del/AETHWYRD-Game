---
type: monster
id: mon_ancient_goblin_king
family: "Goblinoids"
rank: "A"
tier: variant
tags: [monster, goblinoids]
---
# Ancient Goblin King

> The Ancient Goblin King is a large creature with a giant, barrel-chested humanoid body, about 4.2 m tall. Its skin is rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe throne-backed armor and a crown of hammered coins. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It charges without hesitation, surrounded by pebbles that tremble and float near it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin King\|Goblin King]] (ancient) |
| Rank · level | A · 146 (132–159) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 4.2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 36153 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Quaking Lands\|Quaking Lands]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Wind. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_goblinoid_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `rough_skin_leather` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
