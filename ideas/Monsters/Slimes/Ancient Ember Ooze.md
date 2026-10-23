---
type: monster
id: mon_ancient_ember_ooze
family: "Slimes"
rank: "B"
tier: variant
tags: [monster, slimes]
---
# Ancient Ember Ooze

> The Ancient Ember Ooze is a person-sized creature with a dome-shaped gelatinous body, about 2.3 m tall. Its gel is rough, scarred and spiked, colored in ember reds fading to soot black. Its most striking feature is molten trails that harden into glass behind it. It has narrow glowing eyes. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by heat-shimmer and drifting sparks. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Variant of | [[Monsters/Slimes/Ember Ooze\|Ember Ooze]] (ancient) |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Fire · Water |
| Size | 2.3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9425 · 354 · 265 · 265 · 265 · 110 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Water. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_slime_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · triangle-based silhouette, sharp asymmetric spikes
