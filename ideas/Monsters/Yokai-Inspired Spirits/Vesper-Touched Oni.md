---
type: monster
id: mon_vesper_touched_oni
family: "Yokai-Inspired Spirits"
rank: "A"
tier: variant
tags: [monster, yokai-inspired-spirits]
---
# Vesper-Touched Oni

> The Vesper-Touched Oni is a large creature with a massive hunched brute frame, about 3.5 m tall. Its form is patchy and subtly wrong, as if assembled from memory, colored in ember reds fading to soot black. Look for horns, a tiger-skin wrap and an iron club. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It freezes whenever it is looked at, surrounded by heat-shimmer and drifting sparks. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Variant of | [[Monsters/Yokai-Inspired Spirits/Oni\|Oni]] (corrupted) |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 3.5 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 34058 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Habitats | [[Regions/Haneul\|Haneul]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| Spirit Flame | magic | 1.2 | 8 s | None | blue |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_yokai_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `paper_ink_spirit` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · elongated, irregular silhouette; still-then-sudden timing
