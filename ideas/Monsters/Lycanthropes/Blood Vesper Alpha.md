---
type: monster
id: mon_blood_vesper_alpha
family: "Lycanthropes"
rank: "B"
tier: core
tags: [monster, lycanthropes]
---
# Blood Vesper Alpha

> The Blood Vesper Alpha is a large creature with an upright humanoid build, about 3.2 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in arterial crimson and dried-blood brown. Survivors describe red-veined fur that only appears under the red moon. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It glides without moving its legs, surrounded by a faint red mist that smells of iron.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Blood · Light |
| Size | 3.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16561 · 530 · 442 · 354 · 398 · 100 |
| XP · gold | 5386 · 1057 |
| Ring | 4 |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Apu Highlands\|Apu Highlands]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Moon Frenzy | buff | 0 | 20 s | None | none |
| Blood Lance | magic | 1.5 | 10 s | Blood | red |

## Loot (`loot_lycan_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Venom Blood Vesper Alpha|Venom Blood Vesper Alpha]]
- [[Monsters/Lycanthropes/Ancient Blood Vesper Alpha|Ancient Blood Vesper Alpha]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `blood_mist` · palette `#8b0000` `#d7263d` `#1a0505` · elongated, irregular silhouette; still-then-sudden timing
