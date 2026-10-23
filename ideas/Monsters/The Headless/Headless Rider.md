---
type: monster
id: mon_headless_rider
family: "The Headless"
rank: "C"
tier: core
tags: [monster, the-headless]
---
# Headless Rider

> The Headless Rider is a large creature with a headless rider frame, about 2.6 m tall. Its armor is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Guild sketches always show a lantern burning where its head should be. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/The Headless|The Headless]] · Undead |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.6 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 11650 · 314 · 471 · 188 · 314 · 70 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Celtic Gothic |
| Trope | The dullahan of Irish folklore |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Sweep | melee | 1.3 | 0 s | None | blue |
| Charge | dash | 1.3 | 5 s | None | blue |
| Head Throw | ranged | 1.4 | 10 s | None | red |
| Lantern Hurl | ranged | 1.3 | 8 s | None | blue |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_headless_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Rider's Lantern\|Rider's Lantern]] | 60% | 1–3 |
| [[Items/Cursed Iron\|Cursed Iron]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/The Headless/Vesper-Touched Headless Rider|Vesper-Touched Headless Rider]]

## Design recipe

Rig `rig_headless` · mesh `headless_base` · material `old_iron` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
