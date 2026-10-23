---
type: monster
id: mon_lich
family: "Undead"
rank: "A"
tier: core
tags: [monster, undead]
---
# Lich

> The Lich is a person-sized creature with a bodiless, glowing form, about 2.2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in pale blues and frost-white. Look for a crowned skull with a phylactery chained to its chest. It has eyes set slightly too far apart. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by falling snow motes and frosted ground where it steps.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Ice · Fire |
| Size | 2.2 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 16640 · 356 · 416 · 832 · 772 · 90 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Gearholm\|Gearholm]], [[Regions/Sunscar\|Sunscar]], [[Regions/Haneul\|Haneul]], [[Regions/Vharlen\|Vharlen]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Fire. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Frost Breath | magic | 1.5 | 10 s | Ice | red |

## Loot (`loot_undead_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Undead/Bog Lich|Bog Lich]]
- [[Monsters/Undead/Ancient Lich|Ancient Lich]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `frost_trail_snow` · palette `#bfe9ff` `#5fa8d3` `#f4fbff` · elongated, irregular silhouette; still-then-sudden timing
