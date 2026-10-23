---
type: monster
id: mon_lich_emperor
family: "Undead"
rank: "SSS"
tier: core
tags: [monster, undead]
---
# Lich Emperor

> The Lich Emperor is a large creature with a bodiless, glowing form, about 3 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in pale blues and frost-white. Survivors describe a crown of frozen souls and a phylactery the size of a castle tower. It has eyes set slightly too far apart. Its outline is crowned by slowly turning rings of light; lesser monsters flee from it. It freezes whenever it is looked at, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | SSS · 281 (267–294) |
| Menace | 4 · Dread |
| Element · weakness | Ice · Fire |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 49246 · 680 · 794 · 1588 · 1474 · 90 |
| XP · gold | 24842 · 4024 |
| Ring | 8 |
| Habitats | [[Regions/Nox Dominion\|Nox Dominion]], [[Regions/Vesper\|Vesper]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Fire. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_undead_sss`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/SSS-Rank Monster Core\|SSS-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Undead/Bog Lich Emperor|Bog Lich Emperor]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · elongated, irregular silhouette; still-then-sudden timing
