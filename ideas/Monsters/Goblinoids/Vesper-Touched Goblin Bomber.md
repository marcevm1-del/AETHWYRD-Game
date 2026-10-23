---
type: monster
id: mon_vesper_touched_goblin_bomber
family: "Goblinoids"
rank: "C-"
tier: variant
tags: [monster, goblinoids]
---
# Vesper-Touched Goblin Bomber

> The Vesper-Touched Goblin Bomber is a small creature with a scrawny biped with long arms and bowed legs, about 1 m tall. Its skin is patchy and subtly wrong, as if assembled from memory, colored in ember reds fading to soot black. Its most striking feature is a barrel of black powder strapped to its back and a lit fuse in its teeth. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by heat-shimmer and drifting sparks. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Goblinoids|Goblinoids]] · Humanoid |
| Variant of | [[Monsters/Goblinoids/Goblin Bomber\|Goblin Bomber]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 1 m |
| Behaviour | Pack (pack_flank+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 4060 · 270 · 216 · 189 · 216 · 135 |
| XP · gold | 2395 · 521 |
| Ring | 4 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Dark Fantasy |
| Trope | Goblins as horror in numbers (Goblin Slayer); hobgoblin → champion → king evolution |

**Field note:** Weak to Water. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Sand Toss | debuff | 0 | 12 s | None | none |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_goblinoid_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Goblin Ear\|Goblin Ear]] | 60% | 1–3 |
| [[Items/Crude Blade\|Crude Blade]] | 30% | 1–1 |
| [[Items/Stolen Trinket\|Stolen Trinket]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `rough_skin_leather` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · elongated, irregular silhouette; still-then-sudden timing
