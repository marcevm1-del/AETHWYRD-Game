---
type: monster
id: mon_vesper_touched_shadow_wisp
family: "Shadows"
rank: "D-"
tier: variant
tags: [monster, shadows]
---
# Vesper-Touched Shadow Wisp

> The Vesper-Touched Shadow Wisp is a tiny creature with a floating, cloth-like shape, about 0.4 m tall. Its smoke-like body is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Its most striking feature is a flickering smudge of darkness. It has eyes that never blink. A distinctive marking runs along its back. It glides without moving its legs, surrounded by shadows that lean toward it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Variant of | [[Monsters/Shadows/Shadow Wisp\|Shadow Wisp]] (corrupted) |
| Rank · level | D- · 40 (32–48) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 0.4 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 1437 · 102 · 119 · 238 · 221 · 90 |
| XP · gold | 1106 · 265 |
| Ring | 3 |
| Habitats | [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Umbravel\|Umbravel]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Chill Touch | melee | 0.9 | 0 s | None | blue |
| Phase Lunge | dash | 1.3 | 7 s | None | red |
| Wail | aoe | 1.2 | 12 s | None | red |
| Shade Step Strike | dash | 1.4 | 7 s | None | red |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_shadow_d`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/D-Rank Monster Core\|D-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_floating` · mesh `floating_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
