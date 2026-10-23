---
type: monster
id: mon_vesper_touched_will_o_wisp
family: "Elementals & Spirits"
rank: "D-"
tier: variant
tags: [monster, elementals-spirits]
---
# Vesper-Touched Will-o'-Wisp

> The Vesper-Touched Will-o'-Wisp is a tiny creature with a bodiless, glowing form, about 0.3 m tall. Its body is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Its most striking feature is a pale flame that leads travelers into bogs. It has too many eyes, opening one after another. A distinctive marking runs along its back. It copies the walk of whatever it hunts, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Variant of | [[Monsters/Elementals & Spirits/Will-o'-Wisp\|Will-o'-Wisp]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 0.3 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1347 · 102 · 119 · 238 · 221 · 90 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Habitats | [[Regions/Iron Hold\|Iron Hold]], [[Regions/Hoshizora\|Hoshizora]], [[Regions/Aldmere\|Aldmere]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Elemental Burst | magic | 1.4 | 9 s | None | red |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_elemental_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
