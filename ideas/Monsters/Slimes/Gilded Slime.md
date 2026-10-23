---
type: monster
id: mon_gilded_slime
family: "Slimes"
rank: "D+"
tier: variant
tags: [monster, slimes]
---
# Gilded Slime

> The Gilded Slime is a tiny creature with a teardrop-shaped jelly body, about 0.3 m tall. Its gel is smooth and clean, colored in warm gold and pearl white. Its most striking feature is mirror-chrome skin that reflects the world around it. It has wide curious eyes with star-shaped highlights. A distinctive marking runs along its back. It waddles, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Metal Slime\|Metal Slime]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.3 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1932 · 187 · 140 · 140 · 140 · 110 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_slime_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
