---
type: monster
id: mon_oni
family: "Yokai-Inspired Spirits"
rank: "B+"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Oni

> The Oni is a large creature with a giant, barrel-chested humanoid body, about 3.5 m tall. Its form is rough, scarred and spiked, colored in ember reds fading to soot black. Survivors describe horns, a tiger-skin wrap and an iron club. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 3.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25411 · 490 · 735 · 294 · 490 · 70 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Habitats | [[Regions/Everdusk\|Everdusk]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Haneul\|Haneul]], [[Regions/Hoshizora\|Hoshizora]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| Spirit Flame | magic | 1.2 | 8 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_yokai_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Vesper-Touched Oni|Vesper-Touched Oni]]

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `paper_ink_spirit` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
