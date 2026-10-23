---
type: monster
id: mon_skinchanger
family: "Lycanthropes"
rank: "B+"
tier: core
tags: [monster, lycanthropes]
---
# Skinchanger

> The Skinchanger is a person-sized creature with a broad-shouldered humanoid build, about 2.4 m tall. Its fur is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Its most striking feature is half its body stuck mid-transformation, forever. It has too many eyes, opening one after another. Faint runes glow along its body when it fights. It unfolds into something larger, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Rank · level | B+ · 120 (108–132) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 2.4 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 17586 · 588 · 490 · 392 · 441 · 100 |
| XP · gold | 6373 · 1225 |
| Ring | 4 |
| Habitats | [[Regions/Strife Marches\|Strife Marches]], [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Shen-Lu\|Shen-Lu]] |
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
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_lycan_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Lycanthropes/Elder Skinchanger|Elder Skinchanger]]
- [[Monsters/Lycanthropes/Blight Skinchanger|Blight Skinchanger]]

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
