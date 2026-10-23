---
type: monster
id: mon_blight_ghost
family: "Undead"
rank: "E+"
tier: variant
tags: [monster, undead]
---
# Blight Ghost

> The Blight Ghost is a person-sized creature with a floating, cloth-like shape, about 1.7 m tall. Its flesh and bone are rough, scarred and spiked, colored in bruise purple with sickly green. Its most striking feature is a translucent figure frozen in its last moment. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It charges without hesitation, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like crystal spikes, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Ghost\|Ghost]] (elemental) |
| Rank · level | E+ · 32 (26–40) |
| Menace | 3 · Menacing |
| Element · weakness | Poison · Light |
| Size | 1.7 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1615 · 83 · 97 · 193 · 179 · 90 |
| XP · gold | 776 · 195 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]] |
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

## Loot (`loot_undead_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `rot_bone` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · triangle-based silhouette, sharp asymmetric spikes
