---
type: monster
id: mon_greater_needle_wasp
family: "Killer Insects"
rank: "D+"
tier: variant
tags: [monster, killer-insects]
---
# Greater Needle Wasp

> The Greater Needle Wasp is a small creature with a small winged body, about 0.5 m tall. Its chitin is rough, scarred and spiked, colored in bruise purple with sickly green. Guild sketches always show a stinger as long as its body. It has burning slit pupils. A distinctive marking runs along its back. It circles its prey, surrounded by a low toxic haze that clings to the ground. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Killer Insects|Killer Insects]] · Insectoid |
| Variant of | [[Monsters/Killer Insects/Needle Wasp\|Needle Wasp]] (elder) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 0.5 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2649 · 234 · 187 · 164 · 187 · 135 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | The rookie-killing ants of the early dungeon floors (DanMachi) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nip | melee | 0.9 | 0 s | None | blue |
| Dart | dash | 1.1 | 4 s | None | blue |
| Swarm Call | summon | 0 | 20 s | None | none |
| Swarm Bite | aoe | 0.9 | 6 s | None | red |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_killer_insect_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Killer Mandible\|Killer Mandible]] | 60% | 1–3 |
| [[Items/Stinger\|Stinger]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `chitin_matte` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
