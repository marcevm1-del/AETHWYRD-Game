---
type: monster
id: mon_tunnel_centipede
family: "Killer Insects"
rank: "D+"
tier: core
tags: [monster, killer-insects]
---
# Tunnel Centipede

> The Tunnel Centipede is a huge creature with a coiling, legless body, about 6 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe a hundred legs and a head like a split mask. It has eyes that never blink. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 6 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5906 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 2 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]], [[Regions/Moraveil\|Moraveil]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Swarm Bite | aoe | 0.9 | 6 s | None | red |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_killer_insect_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Killer Insects/Iron Centipede|Iron Centipede]]
- [[Monsters/Killer Insects/Radiant Centipede|Radiant Centipede]]

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
