---
type: monster
id: mon_moss_kitten
family: "Familiars & Gentle Creatures"
rank: "E+"
tier: variant
tags: [monster, familiars-gentle-creatures]
---
# Moss Kitten

> The Moss Kitten is a tiny creature with a compact quadruped frame, about 0.4 m long. Its coat is smooth and clean, colored in leaf greens over bark brown. Look for fur that flickers like candle flame. It has wide curious eyes with star-shaped highlights. Small scars and rough edges mark it as a survivor. It hops in little bursts, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Familiars & Gentle Creatures|Familiars & Gentle Creatures]] · Familiar |
| Variant of | [[Monsters/Familiars & Gentle Creatures/Ember Kitten\|Ember Kitten]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 1 · Charming |
| Element · weakness | Nature · Fire |
| Size | 0.4 m |
| Behaviour | Passive (passive_wander) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1103 · 138 · 110 · 97 · 110 · 135 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Sylvaran\|Sylvaran]], [[Regions/Mossdeep\|Mossdeep]] |
| Genre | Cozy Fantasy |
| Trope | Cozy companion creatures |

**Field note:** Weak to Fire. Leaves you alone unless attacked.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Bite | melee | 1 | 0 s | None | blue |
| Charge | dash | 1.3 | 5 s | None | blue |
| Leap | dash | 1.2 | 6 s | None | blue |
| Playful Nudge | melee | 0.5 | 6 s | None | none |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_familiar_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Soft Fur\|Soft Fur]] | 60% | 1–3 |
| [[Items/Shed Scale\|Shed Scale]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_quad_small` · mesh `quad_small_base` · material `fur_soft` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · circle-based, soft silhouette
