---
type: monster
id: mon_dusk_clockwork_sentinel
family: "Constructs & Mimics"
rank: "C+"
tier: variant
tags: [monster, constructs-mimics]
---
# Dusk Clockwork Sentinel

> The Dusk Clockwork Sentinel is a large creature with a heavy, hand-built humanoid shell, about 2.5 m tall. Its surface is rough, scarred and spiked, colored in ink black with bruised violet. Look for brass gears visible through its ribs. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by shadows that lean toward it. This Dark-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Constructs & Mimics|Constructs & Mimics]] · Construct |
| Variant of | [[Monsters/Constructs & Mimics/Clockwork Sentinel\|Clockwork Sentinel]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2.5 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13814 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 4 |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Ancient Ruins |
| Trope | Treasure-chest mimics and ancient guardian golems |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slam | melee | 1.4 | 0 s | None | blue |
| Ground Pound | aoe | 1.8 | 10 s | None | red |
| Guard Stance | buff | 0 | 15 s | None | none |
| Rune Pulse | magic | 1.3 | 10 s | None | red |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_construct_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Golem Core\|Golem Core]] | 60% | 1–3 |
| [[Items/Rune Plate\|Rune Plate]] | 30% | 1–1 |
| [[Items/Gear\|Gear]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_golem` · mesh `golem_base` · material `stone_metal_runes` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
