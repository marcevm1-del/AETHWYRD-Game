---
type: monster
id: mon_rime_ogre
family: "Orcs, Ogres & Giants"
rank: "C+"
tier: variant
tags: [monster, orcs-ogres-giants]
---
# Rime Ogre

> The Rime Ogre is a large creature with a giant, barrel-chested humanoid body, about 3.5 m tall. Its hide is rough, scarred and spiked, colored in pale blues and frost-white. Survivors describe a sagging belly, a tree-trunk club and a toll sack. It has eyes that catch torchlight like coins. Battle-worn plates and trophies hang from its body. It charges without hesitation, surrounded by falling snow motes and frosted ground where it steps. Adapted to tundra lands, it has a thick, frost-rimed coat.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Variant of | [[Monsters/Orcs, Ogres & Giants/Ogre\|Ogre]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Ice · Fire |
| Size | 3.5 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15468 · 354 · 531 · 212 · 354 · 70 |
| XP · gold | 3743 · 769 |
| Ring | 5 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Vharlen\|Vharlen]], [[Regions/Frostveil\|Frostveil]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| War Cry | buff | 0 | 18 s | None | none |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_orc_giant_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `thick_skin` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · triangle-based silhouette, sharp asymmetric spikes
