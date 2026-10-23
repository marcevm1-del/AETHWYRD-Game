---
type: monster
id: mon_ogre
family: "Orcs, Ogres & Giants"
rank: "C"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Ogre

> The Ogre is a large creature with a towering, heavy-limbed body, about 3.5 m tall. Its hide is rough, scarred and spiked, colored in ochre, clay and mossy stone. Look for a sagging belly, a tree-trunk club and a toll sack. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | C · 76 (65–86) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 3.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12871 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 4 |
| Habitats | [[Regions/Vharlen\|Vharlen]], [[Regions/Frostveil\|Frostveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| War Cry | buff | 0 | 18 s | None | none |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_orc_giant_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Rime Ogre|Rime Ogre]]

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
