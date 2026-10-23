---
type: monster
id: mon_sky_mimic_slime
family: "Slimes"
rank: "D+"
tier: variant
tags: [monster, slimes]
---
# Sky Mimic Slime

> The Sky Mimic Slime is a small creature with a dome-shaped gelatinous body, about 1 m tall. Its gel is patchy and subtly wrong, as if assembled from memory, colored in pale jade and cloud white. Guild sketches always show a surface that ripples into the shape of whatever it last ate. It has pale, pupil-less eyes. A distinctive marking runs along its back. It freezes whenever it is looked at, surrounded by swirling leaves and a constant breeze. This Wind-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Mimic Slime\|Mimic Slime]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Wind · Fire |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2682 · 187 · 140 · 140 · 140 · 110 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]], [[Regions/Strife Marches\|Strife Marches]] |
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
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_slime_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · elongated, irregular silhouette; still-then-sudden timing
