---
type: monster
id: mon_poison_slime
family: "Slimes"
rank: "E"
tier: core
tags: [monster, slimes]
---
# Poison Slime

> The Poison Slime is a small creature with a wobbling mound of translucent gel, about 0.6 m tall. Its gel is rough, scarred and spiked, colored in bruise purple with sickly green. Survivors describe purple bubbles that hiss when they pop. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Slimes|Slimes]] · Ooze |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 0.6 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 750 · 91 · 68 · 68 · 68 · 110 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Greymoor\|Greymoor]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | The cute first enemy (Dragon Quest) and the evolving hero (Tensura) |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Body Slam | melee | 1 | 0 s | None | blue |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Split | summon | 0 | 20 s | None | none |
| Acid Splash | ranged | 1.1 | 6 s | None | blue |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_slime_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Slime Jelly\|Slime Jelly]] | 60% | 1–3 |
| [[Items/Gel Core\|Gel Core]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Slimes/Vesper-Touched Poison Slime|Vesper-Touched Poison Slime]]
- [[Monsters/Slimes/Greater Poison Slime|Greater Poison Slime]]

## Design recipe

Rig `rig_blob` · mesh `blob_base` · material `translucent_gel_sss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
