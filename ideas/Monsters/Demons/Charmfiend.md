---
type: monster
id: mon_charmfiend
family: "Demons"
rank: "C+"
tier: core
tags: [monster, demons]
---
# Charmfiend

> The Charmfiend is a person-sized creature with a lean humanoid frame, about 1.8 m tall. Its hide is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a beautiful porcelain mask hiding a hollow face. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9701 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Hellfire Brand | magic | 1.4 | 10 s | None | red |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_demon_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Demons/Hellmarch Charmfiend|Hellmarch Charmfiend]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `demon_hide_emissive` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
