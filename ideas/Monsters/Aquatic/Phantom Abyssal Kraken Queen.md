---
type: monster
id: mon_phantom_abyssal_kraken_queen
family: "Aquatic"
rank: "SSS+"
tier: variant
tags: [monster, aquatic]
---
# Phantom Abyssal Kraken Queen

> The Phantom Abyssal Kraken Queen is a colossal creature with a bulbous body with writhing arms, about 200 m long. Its scales and skin are stretched, stitched and constantly shifting, colored in warm gold and pearl white. Its most striking feature is tentacles that can wrap around whole islands. It has too many eyes, opening one after another. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It unfolds into something larger, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Abyssal Kraken Queen\|Abyssal Kraken Queen]] (spirit) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 200 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 159003 · 1483 · 1067 · 1067 · 1067 · 100 |
| XP · gold | 26706 · 4286 |
| Ring | 6 |
| Habitats | [[Regions/Goldmere Coast\|Goldmere Coast]], [[Regions/Whitewater Reach\|Whitewater Reach]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Tentacle Slap | melee | 1.1 | 0 s | None | blue |
| Drag Under | grab | 1.8 | 12 s | None | gold |
| Ink Cloud | debuff | 0 | 14 s | None | none |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_aquatic_sss`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_cephalopod` · mesh `cephalopod_base` · material `wet_scale` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · broken symmetry, mimicry, audio-first reveal
