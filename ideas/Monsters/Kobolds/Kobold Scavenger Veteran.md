---
type: monster
id: mon_kobold_scavenger_veteran
family: "Kobolds"
rank: "E"
tier: variant
tags: [monster, kobolds]
---
# Kobold Scavenger Veteran

> The Kobold Scavenger Veteran is a person-sized creature with a scrawny biped with long arms and bowed legs, about 1.4 m tall. Its mangy fur is rough, scarred and spiked, colored in muted greys and dusty browns. Survivors describe a dog-like head with a chipped snout and a sack of stolen tools. It has narrow glowing eyes. Small scars and rough edges mark it as a survivor. It circles its prey. It has no visible aura; you hear its breathing before you see it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Scavenger\|Kobold Scavenger]] (elder) |
| Rank · level | E · 26 (19–32) |
| Menace | 3 · Menacing |
| Element · weakness | None · Fire |
| Size | 1.4 m |
| Behaviour | Skittish (skittish_flee) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1191 · 114 · 91 · 56 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Fire. Flees when hurt. Snares or ranged attacks work best.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Trip-Wire Trap | debuff | 0 | 14 s | None | none |

## Loot (`loot_kobold_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `dust_puffs` · palette `#8a8f98` `#5b5f66` `#c9c2b5` · triangle-based silhouette, sharp asymmetric spikes
