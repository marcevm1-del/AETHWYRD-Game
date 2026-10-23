---
type: monster
id: mon_blight_king_slime
family: "Slimes"
rank: "C+"
tier: variant
tags: [monster, slimes]
---
# Blight King Slime

> The Blight King Slime is a large creature with a dome-shaped gelatinous body, about 3 m tall. Its gel is weathered and natural, colored in bruise purple with sickly green. Guild sketches always show a crown made of smaller slimes fused together. It has alert animal eyes. Battle-worn plates and trophies hang from its body. It stalks low to the ground, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/King Slime\|King Slime]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 2 · Wild |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7346 · 283 · 212 · 212 · 212 · 110 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_slime_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · real-animal silhouette with one fantasy exaggeration
