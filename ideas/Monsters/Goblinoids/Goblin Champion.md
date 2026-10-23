---
type: monster
id: mon_goblin_champion
family: "Goblinoids"
rank: "D+"
tier: core
tags: [monster, goblinoids]
---
# Goblin Champion

> The Goblin Champion is a person-sized creature with an upright humanoid build, about 2 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Its most striking feature is a trophy cloak stitched from adventurers' capes. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5324 · 281 · 234 · 131 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Sand Toss | debuff | 0 | 12 s | None | none |

## Loot (`loot_goblinoid_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Vesper-Touched Goblin Champion|Vesper-Touched Goblin Champion]]
- [[Monsters/Goblinoids/Goblin Champion Veteran|Goblin Champion Veteran]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
