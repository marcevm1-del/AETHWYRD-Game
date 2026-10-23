---
type: monster
id: mon_phantom_glowfin_angler
family: "Aquatic"
rank: "C+"
tier: variant
tags: [monster, aquatic]
---
# Phantom Glowfin Angler

> The Phantom Glowfin Angler is a large creature with a heavy-jawed fish frame, about 3 m long. Its scales and skin are stretched, stitched and constantly shifting, colored in warm gold and pearl white. Survivors describe a lure of light dangling over a mouth of glass teeth. It has too many eyes, opening one after another. Battle-worn plates and trophies hang from its body. It unfolds into something larger, surrounded by soft radiance and floating motes of light. Its body is translucent blue, half in the spirit world; weapons pass through it unless they are blessed or enchanted.

| Field | Value |
|---|---|
| Family · type | [[Families/Aquatic|Aquatic]] · Aquatic |
| Variant of | [[Monsters/Aquatic/Glowfin Angler\|Glowfin Angler]] (spirit) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 5 · Horror |
| Element · weakness | Light · Dark |
| Size | 3 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10495 · 443 · 319 · 319 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 5 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Kitsune Isles\|Kitsune Isles]], [[Regions/Goldmere Coast\|Goldmere Coast]] |
| Genre | Seafaring |
| Trope | Sea kings and krakens (One Piece), sirens and merfolk |

**Field note:** Weak to Dark. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Breach Lunge | dash | 1.7 | 9 s | None | red |
| Thrash | aoe | 1.3 | 8 s | None | red |
| Tidal Drag | grab | 1.3 | 11 s | None | gold |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_aquatic_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Fish Scale\|Fish Scale]] | 60% | 1–3 |
| [[Items/Pearl\|Pearl]] | 30% | 1–1 |
| [[Items/Ink Sac\|Ink Sac]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_fish` · mesh `fish_base` · material `wet_scale` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · broken symmetry, mimicry, audio-first reveal
