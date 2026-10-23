---
type: monster
id: mon_werewolf
family: "Lycanthropes"
rank: "D"
tier: core
tags: [monster, lycanthropes]
---
# Werewolf

> The Werewolf is a person-sized creature with a broad-shouldered humanoid build, about 2.2 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Survivors describe a wolf's head on a twisted human body, torn clothing still clinging. It has eyes set slightly too far apart. A distinctive marking runs along its back. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | D · 48 (40–56) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4383 · 242 · 202 · 162 · 182 · 100 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Moon Frenzy | buff | 0 | 20 s | None | none |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_lycan_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Bog Werewolf|Bog Werewolf]]
- [[Monsters/Lycanthropes/Grove Werewolf|Grove Werewolf]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
