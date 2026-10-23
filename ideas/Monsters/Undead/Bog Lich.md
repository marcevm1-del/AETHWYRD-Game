---
type: monster
id: mon_bog_lich
family: "Undead"
rank: "A+"
tier: variant
tags: [monster, undead]
---
# Bog Lich

> The Bog Lich is a person-sized creature with a floating, cloth-like shape, about 2.2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Its most striking feature is a crowned skull with a phylactery chained to its chest. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It glides without moving its legs, surrounded by a low toxic haze that clings to the ground. Adapted to swamp lands, it has mud-slick, algae-streaked skin.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Lich\|Lich]] (regional) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 2.2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 18903 · 388 · 452 · 904 · 840 · 90 |
| XP · gold | 9993 · 1815 |
| Ring | 6 |
| Habitats | [[Regions/Lumbaya\|Lumbaya]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_undead_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
