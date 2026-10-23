---
type: monster
id: mon_glassmaw_worm_of_the_endless_dune
family: "Sandborne"
rank: "A+"
tier: core
tags: [monster, sandborne, tyrant, unique]
---
# Glassmaw, Worm of the Endless Dune

> The Glassmaw, Worm of the Endless Dune is a colossal creature with a massive snake-like frame, about 70 m long. Its sand-scoured hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Its most striking feature is a round mouth ringed with teeth of desert glass. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 70 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 51050 · 646 · 517 · 452 · 517 · 135 |
| XP · gold | 199864 · 1815 |
| Ring | 6 |
| Habitats | [[Regions/Dunewhale Drift\|Dunewhale Drift]] |
| Tyrant | Yes |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Sand Burrow | dash | 1.5 | 10 s | None | red |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_sandborne_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `sand_hide` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
