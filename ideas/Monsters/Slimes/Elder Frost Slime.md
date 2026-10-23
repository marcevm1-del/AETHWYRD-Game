---
type: monster
id: mon_elder_frost_slime
family: "Slimes"
rank: "C"
tier: variant
tags: [monster, slimes]
---
# Elder Frost Slime

> The Elder Frost Slime is a small creature with a wobbling mound of translucent gel, about 0.8 m tall. Its gel is weathered and natural, colored in pale blues and frost-white. Guild sketches always show frost crystals growing from its crown. It has dark, wary eyes. Battle-worn plates and trophies hang from its body. It lopes in long strides, surrounded by falling snow motes and frosted ground where it steps. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Frost Slime\|Frost Slime]] (elder) |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Ice · Fire |
| Size | 0.8 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3928 · 251 · 188 · 188 · 188 · 110 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_slime_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · real-animal silhouette with one fantasy exaggeration
