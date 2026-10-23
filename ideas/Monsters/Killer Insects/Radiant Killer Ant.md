---
type: monster
id: mon_radiant_killer_ant
family: "Killer Insects"
rank: "E+"
tier: variant
tags: [monster, killer-insects]
---
# Radiant Killer Ant

> The Radiant Killer Ant is a small creature with a segmented six-limbed frame, about 1 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Look for a pale soldier ant with a jaw that never stops working. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Killer Ant\|Killer Ant]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2365 · 138 · 207 · 83 · 138 · 70 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Dark. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Mandible Crush | melee | 1.1 | 0 s | None | blue |
| Burrow Ambush | dash | 1.5 | 10 s | None | red |
| Acid Spray | ranged | 1 | 6 s | None | blue |
| Swarm Bite | aoe | 0.9 | 6 s | None | red |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_killer_insect_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
