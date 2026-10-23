---
type: monster
id: mon_hellhound
family: "Demons"
rank: "D"
tier: core
tags: [monster, demons]
---
# Hellhound

> The Hellhound is a person-sized creature with a heavy, muscular quadruped frame, about 1.5 m long. Its hide is rough, scarred and spiked, colored in ember reds fading to soot black. Guild sketches always show a dog with a furnace glow inside its ribs. It has narrow glowing eyes. A distinctive marking runs along its back. It strides with heavy steps, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 1.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3845 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Velmark\|Velmark]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Maul | melee | 1.2 | 0 s | None | blue |
| Pounce | dash | 1.6 | 6 s | None | red |
| Howl | buff | 0 | 18 s | None | none |
| Hellfire Brand | magic | 1.4 | 10 s | None | red |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_demon_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Demons/Mud Hellhound|Mud Hellhound]]

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `demon_hide_emissive` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
