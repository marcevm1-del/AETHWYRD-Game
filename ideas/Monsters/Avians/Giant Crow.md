---
type: monster
id: mon_giant_crow
family: "Avians"
rank: "F"
tier: core
tags: [monster, avians]
---
# Giant Crow

> The Giant Crow is a small creature with a feathered avian body, about 0.6 m tall. Its plumage is weathered and natural, colored in ink black with bruised violet. Guild sketches always show a beak full of stolen shiny things. It has amber predator eyes. It has no ornament at all: simple, readable shapes. It stalks low to the ground, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Avians|Avians]] · Avian |
| Rank · level | F · 8 (3–13) |
| Menace | 2 · Wild |
| Element · weakness | Dark · Light |
| Size | 0.6 m |
| Behaviour | Territorial (territorial_guard) |
| HP · ATK · DEF · MATK · MDEF · SPD | 192 · 42 · 34 · 29 · 34 · 135 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | High Fantasy |
| Trope | Griffons, harpies and phoenixes of classic fantasy |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Peck | melee | 1 | 0 s | None | blue |
| Swoop | dash | 1.4 | 6 s | None | blue |
| Screech | debuff | 0 | 14 s | None | none |
| Feather Volley | ranged | 1 | 6 s | None | blue |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_avian_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Feather\|Feather]] | 60% | 1–3 |
| [[Items/Talon\|Talon]] | 30% | 1–1 |
| [[Items/Egg\|Egg]] | 15% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Avians/Brine Crow|Brine Crow]]

## Design recipe

Rig `rig_avian` · mesh `avian_base` · material `feather_groom` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · real-animal silhouette with one fantasy exaggeration
