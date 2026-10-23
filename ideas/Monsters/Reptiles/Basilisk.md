---
type: monster
id: mon_basilisk
family: "Reptiles"
rank: "C"
tier: core
tags: [monster, reptiles]
---
# Basilisk

> The Basilisk is a large creature with a powerful four-legged hunter's body, about 4 m long. Its scales are patchy and subtly wrong, as if assembled from memory, colored in ochre, clay and mossy stone. Its most striking feature is a crown of horns and eyes that petrify. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by pebbles that tremble and float near it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 4 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10566 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 5 |
| Habitats | [[Regions/Zaruma\|Zaruma]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Stormreach\|Stormreach]], [[Regions/Sunscar\|Sunscar]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Wind. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Maul | melee | 1.2 | 0 s | None | blue |
| Pounce | dash | 1.6 | 6 s | None | red |
| Howl | buff | 0 | 18 s | None | none |
| Tail Lash | aoe | 1.2 | 7 s | None | blue |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_reptile_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Reptiles/Greater Basilisk|Greater Basilisk]]

## Design recipe

Rig `rig_quad_large` · mesh `quad_large_base` · material `scale_matte` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · elongated, irregular silhouette; still-then-sudden timing
