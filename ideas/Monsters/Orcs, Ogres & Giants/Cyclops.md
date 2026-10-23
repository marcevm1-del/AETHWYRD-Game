---
type: monster
id: mon_cyclops
family: "Orcs, Ogres & Giants"
rank: "B+"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Cyclops

> The Cyclops is a huge creature with a giant, barrel-chested humanoid body, about 6 m tall. Its hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Survivors describe a single huge eye and a hammer made from a millstone. It has burning slit pupils. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 6 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 30186 · 490 · 735 · 294 · 490 · 70 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Habitats | [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Frostveil\|Frostveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Wind. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| War Cry | buff | 0 | 18 s | None | none |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_orc_giant_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Vesper-Touched Cyclops|Vesper-Touched Cyclops]]

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
