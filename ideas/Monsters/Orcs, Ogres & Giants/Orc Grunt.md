---
type: monster
id: mon_orc_grunt
family: "Orcs, Ogres & Giants"
rank: "E"
tier: core
tags: [monster, orcs-ogres-giants]
---
# Orc Grunt

> The Orc Grunt is a person-sized creature with a lean humanoid frame, about 2 m tall. Its hide is rough, scarred and spiked, colored in muted greys and dusty browns. Survivors describe tusks, war paint and a dented iron axe. It has eyes that catch torchlight like coins. Small scars and rough edges mark it as a survivor. It charges without hesitation. It has no visible aura; you hear its breathing before you see it.

| Field | Value |
|---|---|
| Family · type | [[Families/Orcs, Ogres & Giants|Orcs, Ogres & Giants]] · Giant |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 2 m |
| Behaviour | Pack (pack_flank) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1741 · 137 · 114 · 64 · 103 · 100 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Fanghold\|Fanghold]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Classic Fantasy |
| Trope | Orc warbands and the Orc Disaster that devours its way to power (Tensura) |

**Field note:** Weak to Fire. Never alone. Kill the leader first and the rest may scatter.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| War Cry | buff | 0 | 18 s | None | none |

## Loot (`loot_orc_giant_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Tusk\|Tusk]] | 60% | 1–3 |
| [[Items/Giant's Hide\|Giant's Hide]] | 30% | 1–1 |
| [[Items/Crude Iron\|Crude Iron]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Orcs, Ogres & Giants/Meadow Orc Grunt|Meadow Orc Grunt]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `thick_skin` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
