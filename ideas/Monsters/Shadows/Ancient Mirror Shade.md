---
type: monster
id: mon_ancient_mirror_shade
family: "Shadows"
rank: "A"
tier: variant
tags: [monster, shadows]
---
# Ancient Mirror Shade

> The Ancient Mirror Shade is a large creature with a broad-shouldered humanoid build, about 2.7 m tall. Its smoke-like body is stretched, stitched and constantly shifting, colored in ink black with bruised violet. Look for your own silhouette, a heartbeat behind you. It has no eyes at all, only a wide and patient mouth. An elegant crest and glowing veins of mana mark it as a champion of its kind. It crawls across ceilings, surrounded by shadows that lean toward it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Shadows|Shadows]] · Spirit |
| Variant of | [[Monsters/Shadows/Mirror Shade\|Mirror Shade]] (ancient) |
| Rank · level | A · 146 (132–159) |
| Menace | 5 · Horror |
| Element · weakness | Dark · Light |
| Size | 2.7 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 24532 · 713 · 594 · 475 · 535 · 100 |
| XP · gold | 8719 · 1611 |
| Ring | 6 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/Aurumdeep\|Aurumdeep]], [[Regions/The Maw\|The Maw]] |
| Genre | Dungeon Crawl |
| Trope | Dungeon-born shadow warriors (DanMachi War Shadows) |

**Field note:** Weak to Light. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Slash | melee | 1 | 0 s | None | blue |
| Heavy Swing | melee | 1.6 | 6 s | None | red |
| Guard Counter | counter | 1.3 | 10 s | None | blue |
| Shade Step Strike | dash | 1.4 | 7 s | None | red |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_shadow_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Shade Essence\|Shade Essence]] | 60% | 1–3 |
| [[Items/Night Shard\|Night Shard]] | 30% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_medium_biped` · mesh `medium_biped_base` · material `shadow_smoke` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · broken symmetry, mimicry, audio-first reveal
