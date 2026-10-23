---
type: monster
id: mon_wraith
family: "Undead"
rank: "D"
tier: core
tags: [monster, undead]
---
# Wraith

> The Wraith is a person-sized creature with a bodiless, glowing form, about 2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Look for a hooded shape of smoke with cold blue eyes. It has eyes that never blink. A distinctive marking runs along its back. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | D · 48 (40–56) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3085 · 121 · 141 · 283 · 263 · 90 |
| XP · gold | 1477 · 342 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Strife Marches\|Strife Marches]] |
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
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_undead_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Undead/Ash Wraith|Ash Wraith]]
- [[Monsters/Undead/Vesper-Touched Wraith|Vesper-Touched Wraith]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
