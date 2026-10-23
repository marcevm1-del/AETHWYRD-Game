---
type: monster
id: mon_bog_lich_emperor
family: "Undead"
rank: "SSS+"
tier: variant
tags: [monster, undead]
---
# Bog Lich Emperor

> The Bog Lich Emperor is a large creature with a drifting, half-formed body, about 3 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Its most striking feature is a crown of frozen souls and a phylactery the size of a castle tower. It has pale, pupil-less eyes. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Lich Emperor\|Lich Emperor]] (regional) |
| Rank · level | SSS+ · 294 (281–300) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 3 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 52698 · 712 · 830 · 1660 · 1542 · 90 |
| XP · gold | 26706 · 4286 |
| Ring | 9 |
| Habitats | [[Regions/Great Labyrinth (Floors 91-120)\|Great Labyrinth (Floors 91-120)]], [[Regions/Nox Dominion\|Nox Dominion]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_undead_sss`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
