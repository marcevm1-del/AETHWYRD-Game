---
type: monster
id: mon_greater_bubble_slime
family: "Slimes"
rank: "D"
tier: variant
tags: [monster, slimes]
---
# Greater Bubble Slime

> The Greater Bubble Slime is a small creature with a teardrop-shaped jelly body, about 0.5 m tall. Its gel is smooth and clean, colored in deep blues with a glassy shine. Look for a cluster of soap-bright spheres that split apart when hit. It has big round glossy eyes. A distinctive marking runs along its back. It waddles, surrounded by fine mist and droplets that orbit it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Bubble Slime\|Bubble Slime]] (elder) |
| Rank · level | D · 48 (40–56) |
| Menace | 1 · Charming |
| Element · weakness | Water · Lightning |
| Size | 0.5 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1738 · 162 · 121 · 121 · 121 · 110 |
| XP · gold | 1477 · 342 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
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

## Loot (`loot_slime_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · circle-based, soft silhouette
