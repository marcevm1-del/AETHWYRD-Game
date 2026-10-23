---
type: monster
id: mon_vesper_touched_cave_spider
family: "Insects & Arachnids"
rank: "E"
tier: variant
tags: [monster, insects-arachnids]
---
# Vesper-Touched Cave Spider

> The Vesper-Touched Cave Spider is a small creature with a squat, many-legged arachnid build, about 0.7 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in bruise purple with sickly green. Survivors describe a pale body that glows faintly in the dark. It has eyes that never blink. Small scars and rough edges mark it as a survivor. It freezes whenever it is looked at, surrounded by a low toxic haze that clings to the ground. Red veins of Vesper light crawl under its skin, its eyes glow crimson, and it grows bolder under the red moon.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Cave Spider\|Cave Spider]] (corrupted) |
| Rank · level | E · 26 (19–32) |
| Menace | 4 · Dread |
| Element · weakness | Poison · Light |
| Size | 0.7 m |
| Behaviour | Territorial (territorial_guard+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 953 · 114 · 91 · 80 · 91 · 135 |
| XP · gold | 559 · 147 |
| Ring | 2 |
| Habitats | [[Regions/Aldmere\|Aldmere]], [[Regions/Great Labyrinth (Floors 1-40)\|Great Labyrinth (Floors 1-40)]], [[Regions/Whisperwood\|Whisperwood]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Attacks only if you come close to its home; back away to avoid a fight.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Fang Bite | melee | 1.1 | 0 s | None | blue |
| Web Shot | ranged | 0.5 | 8 s | None | blue |
| Ceiling Drop | dash | 1.7 | 12 s | None | red |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Venom Spit | magic | 1.5 | 10 s | Poison | red |

## Loot (`loot_insect_e`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/E-Rank Monster Core\|E-Rank Monster Core]] | 100% | 1–1 |

## Design recipe

Rig `rig_octopod` · mesh `octopod_base` · material `chitin_gloss` · VFX `toxic_fog` · palette `#8e44ad` `#b8e986` `#2d1b3d` · elongated, irregular silhouette; still-then-sudden timing
