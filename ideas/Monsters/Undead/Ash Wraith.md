---
type: monster
id: mon_ash_wraith
family: "Undead"
rank: "D+"
tier: variant
tags: [monster, undead]
---
# Ash Wraith

> The Ash Wraith is a person-sized creature with a drifting, half-formed body, about 2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ember reds fading to soot black. Survivors describe a hooded shape of smoke with cold blue eyes. It has pale, pupil-less eyes. A distinctive marking runs along its back. It freezes whenever it is looked at, surrounded by heat-shimmer and drifting sparks. This Fire-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Wraith\|Wraith]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 4 · Dread |
| Element · weakness | Fire · Water |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3872 · 140 · 164 · 328 · 304 · 90 |
| XP · gold | 1888 · 423 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Water. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Ember Burst | magic | 1.5 | 10 s | Fire | red |

## Loot (`loot_undead_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `embers_heat_haze` · palette `#e2502b` `#ffb347` `#3a1a12` · elongated, irregular silhouette; still-then-sudden timing
