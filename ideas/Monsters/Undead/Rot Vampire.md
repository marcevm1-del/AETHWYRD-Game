---
type: monster
id: mon_rot_vampire
family: "Undead"
rank: "A-"
tier: variant
tags: [monster, undead]
---
# Rot Vampire

> The Rot Vampire is a person-sized creature with a lean humanoid frame, about 1.8 m tall. Its flesh and bone are rough, scarred and spiked, colored in bruise purple with sickly green. Its most striking feature is aristocratic clothes and eyes like garnets. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Vampire\|Vampire]] (elemental) |
| Rank · level | A- · 132 (120–146) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18374 · 646 · 538 · 430 · 484 · 100 |
| XP · gold | 7422 · 1399 |
| Ring | 6 |
| Habitats | [[Regions/Cinderhole\|Cinderhole]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_undead_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
