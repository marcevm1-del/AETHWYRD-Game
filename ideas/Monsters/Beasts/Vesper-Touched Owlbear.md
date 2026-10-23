---
type: monster
id: mon_vesper_touched_owlbear
family: "Beasts"
rank: "C"
tier: variant
tags: [monster, beasts]
---
# Vesper-Touched Owlbear

> The Vesper-Touched Owlbear is a large creature with a long-legged predatory quadruped build, about 2.6 m long. Its coat is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Guild sketches always show an owl's feathered face on a bear's muscled body. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by a faint red mist that smells of iron. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Beasts|Beasts]] · Beast |
| Variant of | [[Monsters/Beasts/Owlbear\|Owlbear]] (corrupted) |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 2.6 m |
| Behaviour | Skittish (skittish_flee+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9153 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 5 |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Aldmere\|Aldmere]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Classic Fantasy |
| Trope | The horned rabbit "rookie killer" and wolf packs of every isekai starter forest |

**Field note:** Weak to Light. Flees when hurt. Snares or ranged attacks work best.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Maul | melee | 1.2 | 0 s | None | blue |
| Pounce | dash | 1.6 | 6 s | None | red |
| Howl | buff | 0 | 18 s | None | none |
| Rending Bite | melee | 1.3 | 5 s | None | blue |
| Blood Lance | magic | 1.5 | 10 s | Blood | red |

## Loot (`loot_beast_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Pelt\|Pelt]] | 60% | 1–3 |
| [[Items/Fang\|Fang]] | 30% | 1–1 |
| [[Items/Prime Meat\|Prime Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `fur_groom` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
