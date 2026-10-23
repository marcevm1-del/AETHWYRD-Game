---
type: monster
id: mon_imp
family: "Demons"
rank: "E"
tier: core
tags: [monster, demons]
---
# Imp

> The Imp is a small creature with a tiny, darting winged build, about 0.6 m tall. Its hide is weathered and natural, colored in ember reds fading to soot black. Guild sketches always show bat wings, a pointed tail and a cheeky grin. It has dark, wary eyes. Small scars and rough edges mark it as a survivor. It prowls, surrounded by heat-shimmer and drifting sparks.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Rank · level | E · 26 (19–32) |
| Menace | 2 · Wild |
| Element · weakness | Fire · Water |
| Size | 0.6 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 911 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Lirian\|Lirian]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Water. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nip | melee | 0.9 | 0 s | None | blue |
| Dart | dash | 1.1 | 4 s | None | blue |
| Swarm Call | summon | 0 | 20 s | None | none |
| Hellfire Brand | magic | 1.4 | 10 s | None | red |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_demon_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Demons/Thorn Imp|Thorn Imp]]

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `demon_hide_emissive` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · real-animal silhouette with one fantasy exaggeration
