---
type: monster
id: mon_venom_blood_vesper_alpha
family: "Lycanthropes"
rank: "B+"
tier: variant
tags: [monster, lycanthropes]
---
# Venom Blood Vesper Alpha

> The Venom Blood Vesper Alpha is a large creature with a broad-shouldered humanoid build, about 3.2 m tall. Its fur is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Look for red-veined fur that only appears under the red moon. It has pale, pupil-less eyes. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by a low toxic haze that clings to the ground. This Poison-attuned variant carries one extra elemental feature, like a crest of elemental energy, in its element's colors.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Blood Vesper Alpha\|Blood Vesper Alpha]] (elemental) |
| Rank · level | B+ · 120 (108–132) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 3.2 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 19380 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 5 |
| Habitats | [[Regions/Xochitl Mire\|Xochitl Mire]], [[Regions/Moraveil\|Moraveil]], [[Regions/Hoshizora\|Hoshizora]] |
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

## Loot (`loot_lycan_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
