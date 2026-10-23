---
type: monster
id: mon_crag_djinn
family: "Elementals & Spirits"
rank: "A-"
tier: variant
tags: [monster, elementals-spirits]
---
# Crag Djinn

> The Crag Djinn is a large creature with a floating, cloth-like shape, about 4 m tall. Its body is rough, scarred and spiked, colored in ochre, clay and mossy stone. Its most striking feature is a cloud body with lightning tattoos. It has burning slit pupils. An elegant crest and glowing veins of mana mark it as a champion of its kind. It strides with heavy steps, surrounded by pebbles that tremble and float near it. Adapted to mountain lands, it has slate-grey coloring and hardened hide.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Storm Djinn\|Storm Djinn]] (regional) |
| Rank · level | A- · 132 (120–146) |
| Menace | 3 · Menacing |
| Element · weakness | Earth · Wind |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17491 · 323 · 377 · 753 · 699 · 90 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Elemental Burst | magic | 1.4 | 9 s | None | red |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_elemental_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · triangle-based silhouette, sharp asymmetric spikes
