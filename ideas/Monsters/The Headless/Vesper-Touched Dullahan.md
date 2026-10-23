---
type: monster
id: mon_vesper_touched_dullahan
family: "The Headless"
rank: "A-"
tier: variant
tags: [monster, the-headless]
---
# Vesper-Touched Dullahan

> The Vesper-Touched Dullahan is a large creature with an armored humanoid body without a head, about 2.8 m tall. Its armor is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Its own laughing head carried under one arm. It has too many eyes, opening one after another. An elegant crest and glowing veins of mana mark it as a champion of its kind. It unfolds into something larger, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/The Headless|The Headless]] · Undead |
| Variant of | [[Monsters/The Headless/Dullahan\|Dullahan]] (corrupted) |
| Rank · level | A- · 132 (120–146) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 2.8 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 27190 · 538 · 807 · 323 · 538 · 70 |
| XP · gold | 7422 · 1399 |
| Ring | 7 |
| Habitats | [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/Aurumdeep\|Aurumdeep]] |
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

## Loot (`loot_headless_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Rider's Lantern\|Rider's Lantern]] | 60% | 1–3 |
| [[Items/Cursed Iron\|Cursed Iron]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_headless` · mesh `headless_base` · material `old_iron` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
