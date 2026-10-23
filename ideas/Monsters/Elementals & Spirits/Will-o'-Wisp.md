---
type: monster
id: mon_will_o_wisp
family: "Elementals & Spirits"
rank: "E"
tier: core
tags: [monster, elementals-spirits]
---
# Will-o'-Wisp

> The Will-o'-Wisp is a tiny creature with a drifting, half-formed body, about 0.3 m tall. Its body is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a pale flame that leads travelers into bogs. It has pale, pupil-less eyes. Small scars and rough edges mark it as a survivor. It glides without moving its legs, surrounded by shadows that lean toward it.

| Field | Value |
|---|---|
| Family · type | [[Families/Elementals & Spirits|Elementals & Spirits]] · Elemental |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 0.3 m |
| Behaviour | Guardian (guardian_hold+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 722 · 68 · 80 · 160 · 148 · 90 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Whisperwood\|Whisperwood]], [[Regions/Aldmere\|Aldmere]], [[Regions/Mossdeep\|Mossdeep]], [[Regions/Sylvaran\|Sylvaran]] |
| Genre | Spirit Realm |
| Trope | Spirits you can contract with; elemental kings |

**Field note:** Weak to Light. Protects something nearby: a nest, a treasure, or a place.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Elemental Burst | magic | 1.4 | 9 s | None | red |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_elemental_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Elemental Essence\|Elemental Essence]] | 60% | 1–3 |
| [[Items/Spirit Mote\|Spirit Mote]] | 30% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Elementals & Spirits/Vesper-Touched Will-o'-Wisp|Vesper-Touched Will-o'-Wisp]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `elemental_emissive` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
