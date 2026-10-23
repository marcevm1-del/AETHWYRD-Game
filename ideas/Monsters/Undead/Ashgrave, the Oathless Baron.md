---
type: monster
id: mon_ashgrave_the_oathless_baron
family: "Undead"
rank: "C+"
tier: core
tags: [monster, undead, tyrant, unique]
---
# Ashgrave, the Oathless Baron

> The Ashgrave, the Oathless Baron is a person-sized creature with a broad-shouldered humanoid build, about 2.4 m tall. Its flesh and bone are rough, scarred and spiked, colored in ink black with bruised violet. Its most striking feature is a Death Knight in rusted baronial plate, still issuing orders to a dead garrison. It has narrow glowing eyes. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Dark · Light |
| Size | 2.4 m |
| Behaviour | Ambush (ambush_strike) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10704 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 74865 · 769 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]] |
| Tyrant | Yes |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
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

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `rot_bone` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · triangle-based silhouette, sharp asymmetric spikes
