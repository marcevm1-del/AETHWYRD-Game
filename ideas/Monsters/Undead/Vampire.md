---
type: monster
id: mon_vampire
family: "Undead"
rank: "B+"
tier: core
tags: [monster, undead]
---
# Vampire

> The Vampire is a person-sized creature with a lean humanoid frame, about 1.8 m tall. Its flesh and bone are rough, scarred and spiked, colored in arterial crimson and dried-blood brown. Guild sketches always show aristocratic clothes and eyes like garnets. It has narrow glowing eyes. Faint runes glow along its body when it fights. It circles its prey, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | B+ · 120 (108–132) |
| Menace | 3 · Menacing |
| Element · weakness | Blood · Light |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 15937 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Habitats | [[Regions/Sunscar\|Sunscar]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Blood Lance | magic | 1.5 | 10 s | Blood | red |

## Loot (`loot_undead_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Undead/Elder Vampire|Elder Vampire]]
- [[Monsters/Undead/Rot Vampire|Rot Vampire]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · triangle-based silhouette, sharp asymmetric spikes
