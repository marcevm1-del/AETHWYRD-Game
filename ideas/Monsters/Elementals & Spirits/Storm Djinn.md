---
type: monster
id: mon_storm_djinn
family: "Elementals & Spirits"
rank: "B+"
tier: core
tags: [monster, elementals-spirits]
---
# Storm Djinn

> The Storm Djinn is a large creature with a drifting, half-formed body, about 4 m tall. Its body is rough, scarred and spiked, colored in storm violet shot through with electric yellow. Its most striking feature is a cloud body with lightning tattoos. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It strides with heavy steps, surrounded by crackling arcs that jump across its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Lightning · Earth |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15171 · 294 · 343 · 686 · 637 · 90 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Dragon Spine\|Dragon Spine]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Earth. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Elemental Burst | magic | 1.4 | 9 s | None | red |
| Static Arc | magic | 1.5 | 10 s | Lightning | red |

## Loot (`loot_elemental_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Crag Djinn|Crag Djinn]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · triangle-based silhouette, sharp asymmetric spikes
