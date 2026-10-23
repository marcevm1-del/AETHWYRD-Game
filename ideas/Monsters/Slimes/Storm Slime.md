---
type: monster
id: mon_storm_slime
family: "Slimes"
rank: "B"
tier: core
tags: [monster, slimes]
---
# Storm Slime

> The Storm Slime is a person-sized creature with a wobbling mound of translucent gel, about 1.2 m tall. Its gel is weathered and natural, colored in storm violet shot through with electric yellow. Guild sketches always show a storm-cloud interior that flashes with tiny lightning. It has amber predator eyes. Faint runes glow along its body when it fights. It prowls, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | B · 108 (96–120) |
| Menace | 2 · Wild |
| Element · weakness | Lightning · Earth |
| Size | 1.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7553 · 354 · 265 · 265 · 265 · 110 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Earth. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Static Arc | magic | 1.5 | 10 s | Lightning | red |

## Loot (`loot_slime_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Slimes/Cinder Slime|Cinder Slime]]
- [[Monsters/Slimes/Elder Storm Slime|Elder Storm Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · real-animal silhouette with one fantasy exaggeration
