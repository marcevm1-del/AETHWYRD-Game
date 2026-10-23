---
type: monster
id: mon_ancient_lantern_leech
family: "Undead"
rank: "E"
tier: variant
tags: [monster, undead]
---
# Ancient Lantern Leech

> The Ancient Lantern Leech is a small creature with a long, sinuous serpentine body, about 0.9 m long. Its flesh and bone are patchy and subtly wrong, as if assembled from memory, colored in deep blues with a glassy shine. Its most striking feature is a glow on its back like a lost traveler's lantern. It has pale, pupil-less eyes. Small scars and rough edges mark it as a survivor. It moves in jerky stop-motion bursts, surrounded by fine mist and droplets that orbit it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Undead|Undead]] · Undead |
| Variant of | [[Monsters/Undead/Lantern Leech\|Lantern Leech]] (ancient) |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Water · Lightning |
| Size | 0.9 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1030 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]], [[Regions/Lirian\|Lirian]] |
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
