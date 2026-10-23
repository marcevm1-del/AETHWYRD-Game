---
type: monster
id: mon_elder_vampire
family: "Undead"
rank: "A+"
tier: variant
tags: [monster, undead]
---
# Elder Vampire

> The Elder Vampire is a large creature with an upright humanoid build, about 2.9 m tall. Its flesh and bone are rough, scarred and spiked, colored in arterial crimson and dried-blood brown. Look for aristocratic clothes and eyes like garnets. It has narrow glowing eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It circles its prey, surrounded by a faint red mist that smells of iron. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Vampire\|Vampire]] (elder) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 3 · Menacing |
| Element · weakness | Blood · Light |
| Size | 2.9 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 28549 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Lumbaya\|Lumbaya]] |
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
| Blood Lance | magic | 1.5 | 10 s | Blood | red |

## Loot (`loot_undead_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · triangle-based silhouette, sharp asymmetric spikes
