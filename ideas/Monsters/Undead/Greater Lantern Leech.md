---
type: monster
id: mon_greater_lantern_leech
family: "Undead"
rank: "E"
tier: variant
tags: [monster, undead]
---
# Greater Lantern Leech

> The Greater Lantern Leech is a small creature with a massive snake-like frame, about 1 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Look for a glow on its back like a lost traveler's lantern. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It glides without moving its legs, surrounded by fine mist and droplets that orbit it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Lantern Leech\|Lantern Leech]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 1 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1065 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Lirian\|Lirian]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Gothic Horror |
| Trope | Graveyard night threats; the lich and its phylactery; the vampire noble |

**Field note:** Weak to Lightning. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Strike | melee | 1.2 | 0 s | None | blue |
| Constrict | grab | 1.8 | 12 s | None | gold |
| Tail Sweep | aoe | 1.2 | 7 s | None | red |
| Grave Grasp | grab | 1.2 | 10 s | None | gold |
| Tide Lash | magic | 1.5 | 10 s | Water | red |

## Loot (`loot_undead_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Bone Dust\|Bone Dust]] | 60% | 1–3 |
| [[Items/Grave Cloth\|Grave Cloth]] | 30% | 1–1 |
| [[Items/Soul Ember\|Soul Ember]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_serpent` · mesh `serpent_base` · material `rot_bone` · VFX `mist_droplets` · palette `#2f7fd1` `#9ad7ff` `#123a5c` · elongated, irregular silhouette; still-then-sudden timing
