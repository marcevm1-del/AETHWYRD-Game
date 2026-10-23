---
type: monster
id: mon_elder_lantern_moth
family: "Familiars & Gentle Creatures"
rank: "E"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Elder Lantern Moth

> The Elder Lantern Moth is a small creature with a bat-like flying frame, about 0.5 m tall. Its coat is smooth and clean, colored in warm gold and pearl white. Survivors describe wings that glow like paper lanterns. It has big round glossy eyes. Small scars and rough edges mark it as a survivor. It waddles, surrounded by soft radiance and floating motes of light. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Lantern Moth\|Lantern Moth]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.5 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 866 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Dark. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Nip | melee | 0.9 | 0 s | None | blue |
| Dart | dash | 1.1 | 4 s | None | blue |
| Swarm Call | summon | 0 | 20 s | None | none |
| Playful Nudge | melee | 0.5 | 6 s | None | none |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_familiar_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_flyer_small` · mesh `flyer_small_base` · material `fur_soft` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
