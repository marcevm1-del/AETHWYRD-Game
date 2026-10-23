---
type: monster
id: mon_ancient_mandrake
family: "Plants & Fungi"
rank: "E"
tier: variant
tags: [monster, plants-fungi]
---
# Ancient Mandrake

> The Ancient Mandrake is a tiny creature with a walking body of bark and root, about 0.4 m tall. Its bark and leaves are weathered and natural, colored in leaf greens over bark brown. Look for a screaming root with a leafy tuft. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by drifting pollen and tiny blossoms. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Variant of | [[Monsters/Plants & Fungi/Mandrake\|Mandrake]] (ancient) |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Nature · Fire |
| Size | 0.4 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 963 · 143 · 103 · 103 · 103 · 100 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Branch Sweep | melee | 1.1 | 0 s | None | blue |
| Root Slam | aoe | 1.5 | 9 s | None | red |
| Regrow | heal | 0 | 20 s | None | none |
| Root Bind | grab | 1 | 11 s | None | gold |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_plant_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_plant_walker` · mesh `plant_walker_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · real-animal silhouette with one fantasy exaggeration
