---
type: monster
id: mon_firefly_swarm
family: "Insects & Arachnids"
rank: "E"
tier: core
tags: [monster, insects-arachnids]
---
# Firefly Swarm

> The Firefly Swarm is a tiny creature with a cloud of tiny creatures, each one is about 0.05 m long, but the swarm covers several meters. Its chitin is smooth and clean, colored in warm gold and pearl white. Guild sketches always show hundreds of soft lantern lights moving together. It has wide curious eyes with star-shaped highlights. Small scars and rough edges mark it as a survivor. It bounces happily, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.05 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 526 · 91 · 68 · 68 · 68 · 110 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]], [[Regions/Fanghold\|Fanghold]], [[Regions/Mossdeep\|Mossdeep]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Dark. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nibble | melee | 0.6 | 0 s | None | none |
| Engulf | grab | 1.4 | 8 s | None | gold |
| Scatter | evade | 0 | 10 s | None | none |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_insect_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Insects & Arachnids/Phantom Firefly Swarm|Phantom Firefly Swarm]]
- [[Monsters/Insects & Arachnids/Blight Firefly Swarm|Blight Firefly Swarm]]

## Design recipe

Rig `rig_swarm` · mesh `swarm_base` · material `chitin_gloss` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
