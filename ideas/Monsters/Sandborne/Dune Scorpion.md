---
type: monster
id: mon_dune_scorpion
family: "Sandborne"
rank: "D"
tier: core
tags: [monster, sandborne]
---
# Dune Scorpion

> The Dune Scorpion is a person-sized creature with a low, wide insectoid build, about 2 m long. Its sand-scoured hide is rough, scarred and spiked, colored in bruise purple with sickly green. Its most striking feature is a glass-like tail stinger. It has eyes that catch torchlight like coins. A distinctive marking runs along its back. It charges without hesitation, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | D · 48 (40–56) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5399 · 202 · 303 · 121 · 202 · 70 |
| XP · gold | 1477 · 342 |
| Ring | 6 |
| Habitats | [[Regions/Dunewhale Drift\|Dunewhale Drift]], [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Mandible Crush | melee | 1.1 | 0 s | None | blue |
| Burrow Ambush | dash | 1.5 | 10 s | None | red |
| Acid Spray | ranged | 1 | 6 s | None | blue |
| Sand Burrow | dash | 1.5 | 10 s | None | red |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_sandborne_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Sandborne/Elder Dune Scorpion|Elder Dune Scorpion]]

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `sand_hide` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
