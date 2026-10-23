---
type: monster
id: mon_oni_warlord
family: "Goblinoids"
rank: "S"
tier: core
tags: [monster, goblinoids]
---
# Oni Warlord

> The Oni Warlord is a large creature with a giant, barrel-chested humanoid body, about 4.5 m tall. Its skin is rough, scarred and spiked, colored in ember reds fading to soot black. Look for a towering horned silhouette carrying an iron club wrapped in prayer chains. It has narrow glowing eyes. Its regal silhouette is crowned by a halo-like ring of aura. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Rank · level | S · 188 (173–203) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 4.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 53949 · 762 · 1143 · 457 · 762 · 70 |
| XP · gold | 13063 · 2293 |
| Ring | 4 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Dragon Spine\|Dragon Spine]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_goblinoid_s`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/S-Rank Monster Core\|S-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Goblinoids/Radiant Oni Warlord|Radiant Oni Warlord]]
- [[Monsters/Goblinoids/Blight Oni Warlord|Blight Oni Warlord]]

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
