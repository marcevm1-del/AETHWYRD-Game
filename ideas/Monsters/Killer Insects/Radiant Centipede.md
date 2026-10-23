---
type: monster
id: mon_radiant_centipede
family: "Killer Insects"
rank: "C-"
tier: variant
tags: [monster, killer-insects]
---
# Radiant Centipede

> The Radiant Centipede is a huge creature with a long, sinuous serpentine body, about 6 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Guild sketches always show a hundred legs and a head like a split mask. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by soft radiance and floating motes of light. This Light-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Tunnel Centipede\|Tunnel Centipede]] (elemental) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 6 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7362 · 270 · 216 · 189 · 216 · 135 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Dark. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Swarm Bite | aoe | 0.9 | 6 s | None | red |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_killer_insect_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `chitin_matte` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
