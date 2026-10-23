---
type: monster
id: mon_elder_skinchanger
family: "Lycanthropes"
rank: "A+"
tier: variant
tags: [monster, lycanthropes]
---
# Elder Skinchanger

> The Elder Skinchanger is a large creature with a broad-shouldered humanoid build, about 3.8 m tall. Its fur is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Guild sketches always show half its body stuck mid-transformation, forever. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It unfolds into something larger, surrounded by shadows that lean toward it. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Lycanthropes|Lycanthropes]] · Cursed Beast |
| Variant of | [[Monsters/Lycanthropes/Skinchanger\|Skinchanger]] (elder) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 3.8 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 31233 · 775 · 646 · 517 · 581 · 100 |
| XP · gold | 9993 · 1815 |
| Ring | 5 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]], [[Regions/Shen-Lu\|Shen-Lu]] |
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
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_lycan_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Cursed Fur\|Cursed Fur]] | 60% | 1–3 |
| [[Items/Silver-Bane Claw\|Silver-Bane Claw]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `fur_rough` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
