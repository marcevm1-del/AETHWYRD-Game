---
type: monster
id: mon_sandworm
family: "Sandborne"
rank: "B"
tier: core
tags: [monster, sandborne]
---
# Sandworm

> The Sandworm is a colossal creature with a massive snake-like frame, about 40 m long. Its sand-scoured hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe a round mouth ringed with crystal teeth. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It circles its prey, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 40 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 25574 · 442 · 354 · 309 · 354 · 135 |
| XP · gold | 5386 · 1057 |
| Ring | 6 |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]], [[Regions/Zaruma\|Zaruma]], [[Regions/Dunewhale Drift\|Dunewhale Drift]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Sand Burrow | dash | 1.5 | 10 s | None | red |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_sandborne_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Sandborne/Elder Sandworm|Elder Sandworm]]

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `sand_hide` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
