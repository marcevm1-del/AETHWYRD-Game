---
type: monster
id: mon_wisp
family: "Elementals & Spirits"
rank: "F"
tier: core
tags: [monster, elementals-spirits]
---
# Wisp

> The Wisp is a tiny creature with a floating, cloth-like shape, about 0.3 m tall. Its body is smooth and clean, colored in warm gold and pearl white. Its most striking feature is a floating ball of soft light. It has two bright dot eyes. It has no ornament at all: simple, readable shapes. It hops in little bursts, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | F · 8 (3–13) |
| Menace | 1 · Charming |
| Element · weakness | Light · Dark |
| Size | 0.3 m |
| Behaviour | Guardian (guardian_hold) |
| HP · ATK · DEF · MATK · MDEF · SPD | 152 · 25 · 29 · 59 · 55 · 90 |
| XP · gold | 92 · 31 |
| Ring | 1 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Dark. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Elemental Burst | magic | 1.4 | 9 s | None | red |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_elemental_f`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/F-Rank Monster Core\|F-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Storm Wisp|Storm Wisp]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · circle-based, soft silhouette
