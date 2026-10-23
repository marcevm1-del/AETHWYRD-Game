---
type: monster
id: mon_thorn_killer_ant
family: "Killer Insects"
rank: "E+"
tier: variant
tags: [monster, killer-insects]
---
# Thorn Killer Ant

> The Thorn Killer Ant is a small creature with a six-legged armored body, about 1 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in leaf greens over bark brown. Survivors describe a pale soldier ant with a jaw that never stops working. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It glides without moving its legs, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Killer Ant\|Killer Ant]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 4 · Dread |
| Element · weakness | Nature · Fire |
| Size | 1 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2365 · 138 · 207 · 83 · 138 · 70 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
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
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_killer_insect_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_matte` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · elongated, irregular silhouette; still-then-sudden timing
