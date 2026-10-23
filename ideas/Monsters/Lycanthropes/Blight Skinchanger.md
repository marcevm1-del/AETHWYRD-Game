---
type: monster
id: mon_blight_skinchanger
family: "Lycanthropes"
rank: "A-"
tier: variant
tags: [monster, lycanthropes]
---
# Blight Skinchanger

> The Blight Skinchanger is a person-sized creature with an upright humanoid build, about 2.4 m tall. Its fur is stretched, stitched and constantly shifting, colored in bruise purple with sickly green. Look for half its body stuck mid-transformation, forever. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It crawls across ceilings, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Skinchanger\|Skinchanger]] (elemental) |
| Rank · level | A- · 132 (120–146) |
| Menace | 5 · Horror |
| Element · weakness | Poison · Light |
| Size | 2.4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 20275 · 646 · 538 · 430 · 484 · 100 |
| XP · gold | 7422 · 1399 |
| Ring | 5 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Moraveil\|Moraveil]], [[Regions/Shen-Lu\|Shen-Lu]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Moon Frenzy | buff | 0 | 20 s | None | none |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_lycan_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · broken symmetry, mimicry, audio-first reveal
