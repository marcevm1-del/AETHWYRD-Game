---
type: monster
id: mon_hunger_colossus
family: "Yokai-Inspired Spirits"
rank: "A"
tier: core
tags: [monster, yokai-inspired-spirits]
---
# Hunger Colossus

> The Hunger Colossus is a colossal creature with a giant, barrel-chested humanoid body, about 30 m tall. Its form is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Look for a skeleton giant built from the bones of the starved. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Yokai-Inspired Spirits|Yokai-Inspired Spirits]] · Spirit |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 30 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 62014 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Shen-Lu\|Shen-Lu]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Haneul\|Haneul]], [[Regions/Everdusk\|Everdusk]] |
| Genre | Japanese Folklore |
| Trope | Gentle and terrifying spirits (Natsume's Book of Friends, Mushishi, Inuyasha) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stomp | aoe | 1.3 | 6 s | None | red |
| Club Slam | melee | 1.8 | 8 s | None | red |
| Grab and Throw | grab | 2 | 14 s | None | gold |
| Spirit Flame | magic | 1.2 | 8 s | None | blue |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_yokai_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Spirit Paper\|Spirit Paper]] | 60% | 1–3 |
| [[Items/Fox Fire\|Fox Fire]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Yokai-Inspired Spirits/Rain Hunger Colossus|Rain Hunger Colossus]]

## Design recipe

Rig `rig_large_biped` · mesh `large_biped_base` · material `paper_ink_spirit` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
