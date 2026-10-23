---
type: monster
id: mon_the_hollow_abbot_choir_of_silence
family: "Undead"
rank: "C+"
tier: core
tags: [monster, undead, tyrant, unique]
---
# The Hollow Abbot, Choir of Silence

> The The Hollow Abbot, Choir of Silence is a person-sized creature with a bodiless, glowing form, about 2.2 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Look for a monk with no face beneath his cowl who erases the names of the dead. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 2.2 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7557 · 212 · 248 · 496 · 460 · 90 |
| XP · gold | 74865 · 769 |
| Ring | 2 |
| Habitats | [[Regions/Greymoor\|Greymoor]] |
| Tyrant | Yes |
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

## Loot (`loot_undead_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
