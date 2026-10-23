---
type: monster
id: mon_thornvine
family: "Plants & Fungi"
rank: "E"
tier: core
tags: [monster, plants-fungi]
---
# Thornvine

> The Thornvine is a large creature with a huge bulbous flower on a thick stalk, about 3 m tall. Its bark and leaves are rough, scarred and spiked, colored in leaf greens over bark brown. Guild sketches always show vines covered in hooked thorns. It has burning slit pupils. Small scars and rough edges mark it as a survivor. It strides with heavy steps, surrounded by drifting pollen and tiny blossoms.

| Field | Value |
|---|---|
| Family · type | [[Families/Plants & Fungi|Plants & Fungi]] · Plant |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 3 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1454 · 68 · 80 · 160 · 148 · 90 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Sylvaran\|Sylvaran]], [[Regions/Mossdeep\|Mossdeep]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Fairy-tale Forest |
| Trope | Screaming mandrakes, walking mushrooms and ancient treants |

**Field note:** Weak to Fire. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Vine Lash | melee | 1.1 | 0 s | None | blue |
| Snap Jaw | grab | 1.7 | 9 s | None | gold |
| Spore Burst | aoe | 1 | 10 s | None | blue |
| Root Bind | grab | 1 | 11 s | None | gold |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_plant_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Sap\|Sap]] | 60% | 1–3 |
| [[Items/Seed\|Seed]] | 30% | 1–1 |
| [[Items/Spore Cap\|Spore Cap]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Plants & Fungi/Vesper-Touched Thornvine|Vesper-Touched Thornvine]]

## Design recipe

Rig `rig_plant_rooted` · mesh `plant_rooted_base` · material `bark_leaf` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
