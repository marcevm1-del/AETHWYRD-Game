---
type: monster
id: mon_ruin_gremlin_king
family: "Gremlins"
rank: "C+"
tier: variant
tags: [monster, gremlins]
---
# Ruin Gremlin King

> The Ruin Gremlin King is a person-sized creature with a hunched, wiry humanoid frame, about 1.2 m tall. Its skin is rough, scarred and spiked, colored in ink black with bruised violet. Guild sketches always show a throne bolted onto a walking boiler. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It strides with heavy steps, surrounded by shadows that lean toward it. Adapted to ruins lands, it has dust-grey coloring and old rune scars.

| Field | Value |
|---|---|
| Family · type | [[Families/Gremlins|Gremlins]] · Fey Pest |
| Variant of | [[Monsters/Gremlins/Gremlin King\|Gremlin King]] (regional) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 1.2 m |
| Behaviour | Swarm (swarm_surround) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6533 · 354 · 283 · 248 · 283 · 135 |
| XP · gold | 3743 · 769 |
| Ring | 4 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Steampunk Mischief |
| Trope | Machine-breaking pests |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Wrench Sabotage | debuff | 0 | 14 s | None | none |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_gremlin_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Stolen Bolt\|Stolen Bolt]] | 60% | 1–3 |
| [[Items/Gremlin Ear\|Gremlin Ear]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rubbery_skin` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
