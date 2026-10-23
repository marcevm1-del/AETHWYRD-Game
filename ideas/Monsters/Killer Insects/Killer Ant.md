---
type: monster
id: mon_killer_ant
family: "Killer Insects"
rank: "E"
tier: core
tags: [monster, killer-insects]
---
# Killer Ant

> The Killer Ant is a small creature with a segmented six-limbed frame, about 1 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in muted greys and dusty browns. Its most striking feature is a pale soldier ant with a jaw that never stops working. It has pale, pupil-less eyes. Small scars and rough edges mark it as a survivor. It moves in jerky stop-motion bursts. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | None · Fire |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1754 · 114 · 171 · 48 · 114 · 70 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Fire. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Mandible Crush | melee | 1.1 | 0 s | None | blue |
| Burrow Ambush | dash | 1.5 | 10 s | None | red |
| Acid Spray | ranged | 1 | 6 s | None | blue |
| Swarm Bite | aoe | 0.9 | 6 s | None | red |

## Loot (`loot_killer_insect_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Thorn Killer Ant|Thorn Killer Ant]]
- [[Monsters/Killer Insects/Radiant Killer Ant|Radiant Killer Ant]]

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · elongated, irregular silhouette; still-then-sudden timing
