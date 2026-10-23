---
type: monster
id: mon_shade_kobold_warlord
family: "Kobolds"
rank: "C+"
tier: variant
tags: [monster, kobolds]
---
# Shade Kobold Warlord

> The Shade Kobold Warlord is a person-sized creature with a hunched, wiry humanoid frame, about 1.4 m tall. Its mangy fur is rough, scarred and spiked, colored in ink black with bruised violet. Look for scavenged knight armor hammered to fit. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by shadows that lean toward it. This Dark-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Warlord\|Kobold Warlord]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.4 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6880 · 354 · 283 · 248 · 283 · 135 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Trip-Wire Trap | debuff | 0 | 14 s | None | none |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_kobold_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
