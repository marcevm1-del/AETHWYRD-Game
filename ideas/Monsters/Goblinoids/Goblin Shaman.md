---
type: monster
id: mon_goblin_shaman
family: "Goblinoids"
rank: "E"
tier: core
tags: [monster, goblinoids]
---
# Goblin Shaman

> The Goblin Shaman is a small creature with a small, compact humanoid body, about 1 m tall. Its skin is rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe a skull headdress and a staff hung with smoking charms. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1065 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 1 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_goblinoid_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Dawn Goblin Shaman|Dawn Goblin Shaman]]
- [[Monsters/Goblinoids/Ruin Goblin Shaman|Ruin Goblin Shaman]]

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
