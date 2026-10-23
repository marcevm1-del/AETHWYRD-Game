---
type: monster
id: mon_storm_grin_in_the_walls
family: "Aberrations"
rank: "D+"
tier: variant
tags: [monster, aberrations]
---
# Storm Grin in the Walls

> The Storm Grin in the Walls is a small creature with an object-shaped body that hides its true form, about 1 m tall. Its skin is stretched, stitched and constantly shifting, colored in storm violet shot through with electric yellow. Only its smile is ever visible. It has too many eyes, opening one after another. A distinctive marking runs along its back. It copies the walk of whatever it hunts, surrounded by crackling arcs that jump across its body. This Lightning-attuned variant carries one extra elemental feature, like element-scarred hide, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Variant of | [[Monsters/Aberrations/Grin in the Walls\|Grin in the Walls]] (elemental) |
| Rank · level | D+ · 56 (48–65) |
| Menace | 5 · Horror |
| Element · weakness | Lightning · Earth |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 3832 · 293 · 211 · 211 · 211 · 100 |
| XP · gold | 1888 · 423 |
| Ring | 4 |
| Habitats | [[Regions/Hoshizora\|Hoshizora]], [[Regions/Strife Marches\|Strife Marches]], [[Regions/Kitsune Isles\|Kitsune Isles]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Earth. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chomp | melee | 1.6 | 0 s | None | red |
| Tongue Lash | grab | 1.4 | 6 s | None | gold |
| Disguise | stealth | 0 | 20 s | None | none |
| Mimic Lure | debuff | 0 | 16 s | None | none |
| Static Arc | magic | 1.5 | 10 s | Lightning | red |

## Loot (`loot_aberration_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_mimic` · mesh `mimic_base` · material `wet_flesh_unsettling` · VFX `arc_sparks` · palette `#ffe14d` `#6c5ce7` `#1b1b3a` · broken symmetry, mimicry, audio-first reveal
