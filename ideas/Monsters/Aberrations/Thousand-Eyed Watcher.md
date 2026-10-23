---
type: monster
id: mon_thousand_eyed_watcher
family: "Aberrations"
rank: "A"
tier: core
tags: [monster, aberrations]
---
# Thousand-Eyed Watcher

> The Thousand-Eyed Watcher is a huge creature with a bodiless, glowing form, about 6 m tall. Its skin is stretched, stitched and constantly shifting, colored in starless black with faint violet edges. Its most striking feature is a cloud of eyes that blink in sequence. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It crawls across ceilings, surrounded by warped air, as if space bends around it.

| Field | Value |
|---|---|
| Family · type | [[Families/Aberrations|Aberrations]] · Aberration |
| Rank · level | A · 146 (132–159) |
| Menace | 5 · Horror |
| Element · weakness | Void · Light |
| Size | 6 m |
| Behaviour | Aggressive (aggressive_chase+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 23119 · 356 · 416 · 832 · 772 · 90 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Habitats | [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Sky Archipelago\|Sky Archipelago]], [[Regions/The Maw\|The Maw]] |
| Genre | Cosmic Horror |
| Trope | Mimicking things in the dark |

**Field note:** Weak to Light. Attacks on sight. Expect a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Mimic Lure | debuff | 0 | 16 s | None | none |
| Null Rift | magic | 1.5 | 10 s | Void | red |

## Loot (`loot_aberration_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Unreal Fragment\|Unreal Fragment]] | 60% | 1–3 |
| [[Items/Eye of Nothing\|Eye of Nothing]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Variants

- [[Monsters/Aberrations/Deep Thousand-Eyed Watcher|Deep Thousand-Eyed Watcher]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `wet_flesh_unsettling` · VFX `void_distortion` · palette `#0b0b1a` `#3d2c8d` `#c9c9ff` · broken symmetry, mimicry, audio-first reveal
