---
type: monster
id: mon_lantern_ghost
family: "Yokai-Inspired Spirits"
rank: "E"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Lantern Ghost

> The Lantern Ghost is a small creature with a floating, cloth-like shape, about 0.6 m tall. Its form is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is a paper lantern with a torn mouth. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It circles its prey, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 0.6 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 857 · 68 · 80 · 160 · 148 · 90 |
| XP · gold | 559 · 147 |
| Ring | 5 |
| Habitats | [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Water. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Spirit Flame | magic | 1.2 | 8 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_yokai_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Phantom Lantern Ghost|Phantom Lantern Ghost]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `paper_ink_spirit` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
