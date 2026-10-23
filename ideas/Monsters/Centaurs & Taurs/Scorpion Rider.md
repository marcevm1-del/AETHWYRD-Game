---
type: monster
id: mon_scorpion_rider
family: "Centaurs & Taurs"
rank: "B"
tier: core
tags: [monster, centaurs-taurs]
---
# Scorpion Rider

> The Scorpion Rider is a large creature with a centauroid body with a humanoid torso on a four-legged base, about 3 m tall. Its coat is rough, scarred and spiked, colored in bruise purple with sickly green. Guild sketches always show a humanoid torso on a giant scorpion body. It has eyes that catch torchlight like coins. Faint runes glow along its body when it fights. It charges without hesitation, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Centaurs & Taurs|Centaurs & Taurs]] · Beastfolk |
| Rank · level | B · 108 (96–120) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16207 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Zaruma\|Zaruma]], [[Regions/Fanghold\|Fanghold]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Ashira Vale\|Ashira Vale]] |
| Genre | Steppe Epic |
| Trope | Proud nomadic centaur tribes |

**Field note:** Weak to Light. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Spear Thrust | melee | 1.2 | 0 s | None | blue |
| Trample | dash | 1.7 | 8 s | None | red |
| Volley | ranged | 1 | 6 s | None | blue |
| Lance Charge | dash | 1.7 | 8 s | None | red |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_centaur_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Horsehair\|Horsehair]] | 60% | 1–3 |
| [[Items/Painted Barding\|Painted Barding]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Centaurs & Taurs/Ancient Scorpion Rider|Ancient Scorpion Rider]]

## Design recipe

Rig `rig_taur` · mesh `taur_base` · material `horse_coat` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
