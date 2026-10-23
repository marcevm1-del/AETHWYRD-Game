---
type: monster
id: mon_wererat
family: "Lycanthropes"
rank: "D-"
tier: core
tags: [monster, lycanthropes]
---
# Wererat

> The Wererat is a person-sized creature with an upright humanoid build, about 1.5 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe a hunched rodent body with human hands. It has eyes set slightly too far apart. A distinctive marking runs along its back. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 1.5 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 2943 · 204 · 170 · 136 · 153 · 100 |
| XP · gold | 1106 · 265 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Moraveil\|Moraveil]] |
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

## Loot (`loot_lycan_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Elder Wererat|Elder Wererat]]
- [[Monsters/Lycanthropes/Greater Wererat|Greater Wererat]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
