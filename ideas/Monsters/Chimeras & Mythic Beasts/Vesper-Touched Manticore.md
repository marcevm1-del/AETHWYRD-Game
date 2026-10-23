---
type: monster
id: mon_vesper_touched_manticore
family: "Chimeras & Mythic Beasts"
rank: "A-"
tier: variant
tags: [monster, chimeras-mythic-beasts]
---
# Vesper-Touched Manticore

> The Vesper-Touched Manticore is a large creature with a long-legged predatory quadruped build, about 3 m long. Its hide is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Its most striking feature is a lion's body, a scorpion tail and a too-human smile. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Chimeras & Mythic Beasts|Chimeras & Mythic Beasts]] · Mythic Beast |
| Variant of | [[Monsters/Chimeras & Mythic Beasts/Manticore\|Manticore]] (corrupted) |
| Rank · level | A- · 132 (120–146) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 21866 · 646 · 538 · 430 · 484 · 100 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | World Myth |
| Trope | Greek, Persian and East Asian mythic beasts |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Maul | melee | 1.2 | 0 s | None | blue |
| Pounce | dash | 1.6 | 6 s | None | red |
| Howl | buff | 0 | 18 s | None | none |
| Many-Headed Bite | melee | 1.5 | 7 s | None | red |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_chimera_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Chimera Heart\|Chimera Heart]] | 60% | 1–3 |
| [[Items/Mythic Horn\|Mythic Horn]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `mixed_hide` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
