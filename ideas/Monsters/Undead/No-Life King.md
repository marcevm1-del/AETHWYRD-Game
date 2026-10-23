---
type: monster
id: mon_no_life_king
family: "Undead"
rank: "EX"
tier: core
tags: [monster, undead, unique]
---
# No-Life King

> The No-Life King is a large creature with a broad-shouldered humanoid build, about 3 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Guild sketches always show a king of bone on a throne of a thousand skulls. It has eyes that never blink. Its presence is world-scale; the sky changes color when it appears. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | EX · 300 (300–300) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 3 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 74686 · 1452 · 1210 · 968 · 1089 · 100 |
| XP · gold | 551660 · 4409 |
| Ring | 6 |
| Habitats | [[Regions/Sunscar\|Sunscar]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_undead_ex`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/EX-Rank Monster Core\|EX-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
