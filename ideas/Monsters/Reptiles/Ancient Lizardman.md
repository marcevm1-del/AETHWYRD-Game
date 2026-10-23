---
type: monster
id: mon_ancient_lizardman
family: "Reptiles"
rank: "C"
tier: variant
tags: [monster, reptiles]
---
# Ancient Lizardman

> The Ancient Lizardman is a large creature with a broad-shouldered humanoid build, about 3 m tall. Its scales are weathered and natural, colored in deep blues with a glassy shine. Guild sketches always show a proud crest and a coral-tipped spear. It has amber predator eyes. Battle-worn plates and trophies hang from its body. It stalks low to the ground, surrounded by fine mist and droplets that orbit it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Reptiles|Reptiles]] · Reptile |
| Variant of | [[Monsters/Reptiles/Lizardman\|Lizardman]] (ancient) |
| Rank · level | C · 76 (65–86) |
| Menace | 2 · Wild |
| Element · weakness | Water · Lightning |
| Size | 3 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 9607 · 377 · 314 · 251 · 283 · 100 |
| XP · gold | 3073 · 648 |
| Ring | 3 |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Classic Fantasy |
| Trope | Lizardmen as a proud people; the petrifying basilisk |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Tail Lash | aoe | 1.2 | 7 s | None | blue |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_reptile_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Scale\|Scale]] | 60% | 1–3 |
| [[Items/Reptile Eye\|Reptile Eye]] | 30% | 1–1 |
| [[Items/Tail Meat\|Tail Meat]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `scale_matte` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · real-animal silhouette with one fantasy exaggeration
