---
type: monster
id: mon_goblin_champion_veteran
family: "Goblinoids"
rank: "C+"
tier: variant
tags: [monster, goblinoids]
---
# Goblin Champion Veteran

> The Goblin Champion Veteran is a large creature with a lean humanoid frame, about 3.2 m tall. Its skin is rough, scarred and spiked, colored in muted greys and dusty browns. Its most striking feature is a trophy cloak stitched from adventurers' capes. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey. It has no visible aura; you hear its breathing before you see it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Champion\|Goblin Champion]] (elder) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 3.2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11796 · 425 · 354 · 198 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 4 |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]] |
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

## Loot (`loot_goblinoid_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rough_skin_leather` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
