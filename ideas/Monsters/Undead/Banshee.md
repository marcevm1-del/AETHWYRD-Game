---
type: monster
id: mon_banshee
family: "Undead"
rank: "C"
tier: core
tags: [monster, undead]
---
# Banshee

> The Banshee is a person-sized creature with a bodiless, glowing form, about 1.8 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in pale jade and cloud white. Look for long white hair and a mouth that opens far too wide. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by swirling leaves and a constant breeze.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Wind · Fire |
| Size | 1.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 5871 · 188 · 220 · 440 · 408 · 90 |
| XP · gold | 3073 · 648 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Zarvan\|Zarvan]], [[Regions/Vharlen\|Vharlen]] |
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
| Gale Cutter | magic | 1.5 | 10 s | Wind | red |

## Loot (`loot_undead_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Tide Banshee|Tide Banshee]]
- [[Monsters/Undead/Gilded Banshee|Gilded Banshee]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `wind_ribbons` · palette `#a8e6cf` `#dcedc1` `#5b8c85` · elongated, irregular silhouette; still-then-sudden timing
