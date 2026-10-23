---
type: monster
id: mon_glass_wraith
family: "Sandborne"
rank: "C"
tier: core
tags: [monster, sandborne]
---
# Glass Wraith

> The Glass Wraith is a person-sized creature with a bodiless, glowing form, about 2 m tall. Its sand-scoured hide is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Guild sketches always show a figure of fused desert glass, humming with old magic. It has pale, pupil-less eyes. Battle-worn plates and trophies hang from its body. It glides without moving its legs, surrounded by soft radiance and floating motes of light.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Rank · level | C · 76 (65–86) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 2 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 6087 · 188 · 220 · 440 · 408 · 90 |
| XP · gold | 3073 · 648 |
| Ring | 6 |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Dunewhale Drift\|Dunewhale Drift]], [[Regions/Zaruma\|Zaruma]] |
| Genre | Desert Epic |
| Trope | Desert giants and sandworms (Dune, Children of the Whales) |

**Field note:** Weak to Dark. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Sand Burrow | dash | 1.5 | 10 s | None | red |
| Radiant Pulse | magic | 1.5 | 10 s | Light | red |

## Loot (`loot_sandborne_c`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/C-Rank Monster Core\|C-Rank Monster Core]] | 100% | 1–1 |

## Variants

- [[Monsters/Sandborne/Elder Glass Wraith|Elder Glass Wraith]]

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `sand_hide` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
