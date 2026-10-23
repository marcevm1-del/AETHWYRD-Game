---
type: monster
id: mon_vesper_touched_kobold_tunnel_queen
family: "Kobolds"
rank: "A-"
tier: variant
tags: [monster, kobolds]
---
# Vesper-Touched Kobold Tunnel-Queen

> The Vesper-Touched Kobold Tunnel-Queen is a person-sized creature with a small, compact humanoid body, about 1.6 m tall. Its mangy fur is patchy and subtly wrong, as if assembled from memory, colored in ochre, clay and mossy stone. Its most striking feature is a bloated, jewel-encrusted body carried on a litter. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It freezes whenever it is looked at, surrounded by pebbles that tremble and float near it. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Kobolds|Kobolds]] · Humanoid |
| Variant of | [[Monsters/Kobolds/Kobold Tunnel-Queen\|Kobold Tunnel-Queen]] (corrupted) |
| Rank · level | A- · 132 (120–146) |
| Menace | 4 · Dread |
| Element · weakness | Earth · Wind |
| Size | 1.6 m |
| Behaviour | Ambush (ambush_strike+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 13638 · 538 · 430 · 377 · 430 · 135 |
| XP · gold | 7422 · 1399 |
| Ring | 6 |
| Habitats | [[Regions/Great Labyrinth (Floors 41-90)\|Great Labyrinth (Floors 41-90)]], [[Regions/The Maw\|The Maw]] |
| Genre | Dungeon Crawl |
| Trope | Dog-headed first-floor monsters (DanMachi), trap-builders (classic tabletop) |

**Field note:** Weak to Wind. Waits in hiding. Perception skills and light sources reveal it.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Stab | melee | 1 | 0 s | None | blue |
| Thrown Junk | ranged | 0.8 | 4 s | None | blue |
| Frenzied Lunge | melee | 1.5 | 8 s | None | red |
| Trip-Wire Trap | debuff | 0 | 14 s | None | none |
| Stone Spike | magic | 1.5 | 10 s | Earth | red |

## Loot (`loot_kobold_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Kobold Fang\|Kobold Fang]] | 60% | 1–3 |
| [[Items/Scrap Metal\|Scrap Metal]] | 30% | 1–1 |
| [[Items/Candle Stub\|Candle Stub]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_small_biped` · mesh `small_biped_base` · material `fur_short` · VFX `rock_debris` · palette `#8b5a2b` `#c2a878` `#4a4a3a` · elongated, irregular silhouette; still-then-sudden timing
