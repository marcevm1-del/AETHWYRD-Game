---
type: monster
id: mon_moon_beast
family: "Lycanthropes"
rank: "C+"
tier: core
tags: [monster, lycanthropes]
---
# Moon Beast

> The Moon Beast is a large creature with a lean humanoid frame, about 2.8 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is fur that ripples like oil under moonlight. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11279 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Moon Frenzy | buff | 0 | 20 s | None | none |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_lycan_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Phantom Moon Beast|Phantom Moon Beast]]
- [[Monsters/Lycanthropes/Bramble Beast|Bramble Beast]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
