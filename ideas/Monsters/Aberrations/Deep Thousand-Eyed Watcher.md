---
type: monster
id: mon_deep_thousand_eyed_watcher
family: "Aberrations"
rank: "A+"
tier: variant
tags: [monster, aberrations]
---
# Deep Thousand-Eyed Watcher

> The Deep Thousand-Eyed Watcher is a huge creature with a floating, cloth-like shape, about 6 m tall. Its skin is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Survivors describe a cloud of eyes that blink in sequence. It has too many eyes, opening one after another. An elegant crest and glowing veins of mana mark it as a champion of its kind. It copies the walk of whatever it hunts, surrounded by shadows that lean toward it. Adapted to underworld lands, it has bioluminescent spots along its body.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Variant of | [[Monsters/Aberrations/Thousand-Eyed Watcher\|Thousand-Eyed Watcher]] (regional) |
| Rank · level | A+ · 159 (146–173) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 6 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 26263 · 388 · 452 · 904 · 840 · 90 |
| XP · gold | 9993 · 1815 |
| Ring | 7 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep\|Aurumdeep]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Mimic Lure | debuff | 0 | 16 s | None | none |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_aberration_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `wet_flesh_unsettling` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
