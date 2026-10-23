---
type: monster
id: mon_vesper_touched_headless_rider
family: "The Headless"
rank: "B-"
tier: variant
tags: [monster, the-headless]
---
# Vesper-Touched Headless Rider

> The Vesper-Touched Headless Rider is a large creature with a tall, headless knightly build, about 2.6 m tall. Its armor is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Survivors describe a lantern burning where its head should be. It has no eyes at all, only a wide and patient mouth. Faint runes glow along its body when it fights. It crawls across ceilings, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/The Headless|The Headless]] · Undead |
| Variant of | [[Monsters/The Headless/Headless Rider\|Headless Rider]] (corrupted) |
| Rank · level | B- · 96 (86–108) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 2.6 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16490 · 394 · 591 · 236 · 394 · 70 |
| XP · gold | 4462 · 897 |
| Ring | 4 |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Sunscar\|Sunscar]] |
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

## Loot (`loot_headless_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Rider's Lantern\|Rider's Lantern]] | 60% | 1–3 |
| [[Items/Cursed Iron\|Cursed Iron]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_headless` · mesh `headless_base` · material `old_iron` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
