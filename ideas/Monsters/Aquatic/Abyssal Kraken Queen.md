---
type: monster
id: mon_abyssal_kraken_queen
family: "Aquatic"
rank: "SSS"
tier: core
tags: [monster, aquatic]
---
# Abyssal Kraken Queen

> The Abyssal Kraken Queen is a colossal creature with a tentacled, soft-bodied form, about 200 m long. Its scales and skin are patchy and subtly wrong, as if assembled from memory, colored in starless black with faint violet edges. Guild sketches always show tentacles that can wrap around whole islands. It has pale, pupil-less eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It glides without moving its legs, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Rank · level | SSS · 281 (267–294) |
| Menace | 4 · Dread |
| Element · weakness | Void · Light |
| Size | 200 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 148588 · 1418 · 1021 · 1021 · 1021 · 100 |
| XP · gold | 24842 · 4024 |
| Ring | 5 |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Whitewater Reach\|Whitewater Reach]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Tentacle Slap | melee | 1.1 | 0 s | None | blue |
| Drag Under | grab | 1.8 | 12 s | None | gold |
| Ink Cloud | debuff | 0 | 14 s | None | none |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Null Rift | magic | 1.5 | 10 s | Void | red |

## Loot (`loot_aquatic_sss`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Aquatic/Phantom Abyssal Kraken Queen|Phantom Abyssal Kraken Queen]]

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · elongated, irregular silhouette; still-then-sudden timing
