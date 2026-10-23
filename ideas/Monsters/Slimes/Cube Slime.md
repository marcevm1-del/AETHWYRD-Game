---
type: monster
id: mon_cube_slime
family: "Slimes"
rank: "D"
tier: core
tags: [monster, slimes]
---
# Cube Slime

> The Cube Slime is a small creature with a wobbling mound of translucent gel, about 0.8 m tall. Its gel is weathered and natural, colored in ochre, clay and mossy stone. Guild sketches always show a perfectly cubic body with swallowed debris visible inside. It has amber predator eyes. A distinctive marking runs along its back. It prowls, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | D · 48 (40–56) |
| Menace | 2 · Wild |
| Element · weakness | Earth · Wind |
| Size | 0.8 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1991 · 162 · 121 · 121 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil\|Moraveil]], [[Regions/Aldmere\|Aldmere]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Wind. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_slime_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Phantom Cube Slime|Phantom Cube Slime]]
- [[Monsters/Slimes/Glacier Cube Slime|Glacier Cube Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · real-animal silhouette with one fantasy exaggeration
