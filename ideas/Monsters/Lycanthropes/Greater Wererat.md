---
type: monster
id: mon_greater_wererat
family: "Lycanthropes"
rank: "C-"
tier: variant
tags: [monster, lycanthropes]
---
# Greater Wererat

> The Greater Wererat is a person-sized creature with a lean humanoid frame, about 2.4 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Look for a hunched rodent body with human hands. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Wererat\|Wererat]] (elder) |
| Rank · level | C- · 65 (56–76) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 2.4 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 7064 · 324 · 270 · 216 · 243 · 100 |
| XP · gold | 2395 · 521 |
| Ring | 3 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Greymoor\|Greymoor]] |
| Genre | Gothic Horror |
| Trope | Moon-cursed transformation horror |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Moon Frenzy | buff | 0 | 20 s | None | none |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_lycan_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
