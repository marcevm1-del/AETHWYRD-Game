---
type: monster
id: mon_vesper_touched_sahuagin
family: "Aquatic"
rank: "C-"
tier: variant
tags: [monster, aquatic]
---
# Vesper-Touched Sahuagin

> The Vesper-Touched Sahuagin is a person-sized creature with a lean humanoid frame, about 1.9 m tall. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Survivors describe a shark-like head and webbed hands. It has eyes that never blink. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by fine mist and droplets that orbit it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Sahuagin\|Sahuagin]] (corrupted) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 1.9 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6521 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 6 |
| Habitats | [[Regions/True-Name Isles\|True-Name Isles]], [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Lightning. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_aquatic_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `wet_scale` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
