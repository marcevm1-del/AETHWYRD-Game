---
type: monster
id: mon_king_slime
family: "Slimes"
rank: "C"
tier: core
tags: [monster, slimes]
---
# King Slime

> The King Slime is a large creature with a wobbling mound of translucent gel, about 3 m tall. Its gel is weathered and natural, colored in deep blues with a glassy shine. Survivors describe a crown made of smaller slimes fused together. It has amber predator eyes. Battle-worn plates and trophies hang from its body. It prowls, surrounded by fine mist and droplets that orbit it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 3 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6113 · 251 · 188 · 188 · 188 · 110 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_slime_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Deep King Slime|Deep King Slime]]
- [[Monsters/Slimes/Blight King Slime|Blight King Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
