---
type: monster
id: mon_briar_gargoyle
family: "Demons"
rank: "C+"
tier: variant
tags: [monster, demons]
---
# Briar Gargoyle

> The Briar Gargoyle is a person-sized creature with a lean, wing-armed drake frame, about 2 m long. Its hide is rough, scarred and spiked, colored in leaf greens over bark brown. Survivors describe a stone body that cracks when it moves. It has burning slit pupils. Battle-worn plates and trophies hang from its body. It circles its prey, surrounded by drifting pollen and tiny blossoms. This Nature-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Demons|Demons]] · Demon |
| Variant of | [[Monsters/Demons/Gargoyle\|Gargoyle]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 3 · Menacing |
| Element · weakness | Nature · Fire |
| Size | 2 m |
| Behaviour | Aggressive (aggressive_chase) |
| HP · ATK · DEF · MATK · MDEF · SPD | 10057 · 425 · 354 · 283 · 319 · 100 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Lumbaya\|Lumbaya]], [[Regions/Strife Marches\|Strife Marches]] |
| Genre | Abyssal |
| Trope | Demons as a people of the Abyss, not just evil (Frieren, Maoyuu) |

**Field note:** Weak to Fire. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Talon Rake | melee | 1.2 | 0 s | None | blue |
| Dive Bomb | dash | 1.9 | 10 s | None | red |
| Tail Whip | aoe | 1.3 | 6 s | None | red |
| Hellfire Brand | magic | 1.4 | 10 s | None | red |
| Thorn Volley | magic | 1.5 | 10 s | Nature | red |

## Loot (`loot_demon_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Demon Core\|Demon Core]] | 60% | 1–3 |
| [[Items/Horn Shard\|Horn Shard]] | 30% | 1–1 |
| [[Items/Brimstone\|Brimstone]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_wyvern` · mesh `wyvern_base` · material `demon_hide_emissive` · VFX `pollen_petals` · palette `#4caf50` `#a5d66f` `#3e2723` · triangle-based silhouette, sharp asymmetric spikes
