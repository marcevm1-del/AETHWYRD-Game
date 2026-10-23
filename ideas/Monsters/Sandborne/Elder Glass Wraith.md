---
type: monster
id: mon_elder_glass_wraith
family: "Sandborne"
rank: "B"
tier: variant
tags: [monster, sandborne]
---
# Elder Glass Wraith

> The Elder Glass Wraith is a large creature with a floating, cloth-like shape, about 3.2 m tall. Its sand-scoured hide is patchy and subtly wrong, as if assembled from memory, colored in warm gold and pearl white. Look for a figure of fused desert glass, humming with old magic. It has eyes set slightly too far apart. Faint runes glow along its body when it fights. It moves in jerky stop-motion bursts, surrounded by soft radiance and floating motes of light. It is far larger than its kin, with a battle-scarred silhouette and a commanding presence; others of its kind follow it.

| Field | Value |
|---|---|
| Family · type | [[Families/Sandborne|Sandborne]] · Desert Beast |
| Variant of | [[Monsters/Sandborne/Glass Wraith\|Glass Wraith]] (elder) |
| Rank · level | B · 108 (96–120) |
| Menace | 4 · Dread |
| Element · weakness | Light · Dark |
| Size | 3.2 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 12045 · 265 · 309 · 619 · 575 · 90 |
| XP · gold | 5386 · 1057 |
| Ring | 7 |
| Habitats | [[Regions/Zarvan\|Zarvan]], [[Regions/Sunscar\|Sunscar]] |
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

## Loot (`loot_sandborne_b`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Desert Glass\|Desert Glass]] | 60% | 1–3 |
| [[Items/Sand Pearl\|Sand Pearl]] | 30% | 1–1 |
| [[Items/B-Rank Monster Core\|B-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `sand_hide` · VFX `holy_motes` · palette `#fff3b0` `#ffd166` `#ffffff` · elongated, irregular silhouette; still-then-sudden timing
