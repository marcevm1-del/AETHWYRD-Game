---
type: monster
id: mon_tide_banshee
family: "Undead"
rank: "C+"
tier: variant
tags: [monster, undead]
---
# Tide Banshee

> The Tide Banshee is a person-sized creature with a drifting, half-formed body, about 1.8 m tall. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Guild sketches always show long white hair and a mouth that opens far too wide. It has eyes set slightly too far apart. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by fine mist and droplets that orbit it. This Water-attuned variant carries one extra elemental feature, like glowing vein-lines, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Banshee\|Banshee]] (elemental) |
| Rank · level | C+ · 86 (76–96) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 1.8 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7055 · 212 · 248 · 496 · 460 · 90 |
| XP · gold | 3743 · 769 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Lumbaya\|Lumbaya]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Lightning. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_undead_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
