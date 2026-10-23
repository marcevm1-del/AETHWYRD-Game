---
type: monster
id: mon_ancient_death_mantis
family: "Insects & Arachnids"
rank: "A"
tier: variant
tags: [monster, insects-arachnids]
---
# Ancient Death Mantis

> The Ancient Death Mantis is a large creature with a low, wide insectoid build, about 4.5 m long. Its chitin is patchy and subtly wrong, as if assembled from memory, colored in ink black with bruised violet. Guild sketches always show black chitin and a skull-like head. It has pale, pupil-less eyes. An elegant crest and glowing veins of mana mark it as a champion of its kind. It moves in jerky stop-motion bursts, surrounded by shadows that lean toward it. Moss, crystals and centuries-old scars cover its body; it has outlived every hunter sent after it.

| Field | Value |
|---|---|
| Family · type | [[Families/Insects & Arachnids|Insects & Arachnids]] · Insectoid |
| Variant of | [[Monsters/Insects & Arachnids/Death Mantis\|Death Mantis]] (ancient) |
| Rank · level | A · 146 (132–159) |
| Menace | 4 · Dread |
| Element · weakness | Dark · Light |
| Size | 4.5 m |
| Behaviour | Swarm (swarm_surround+stalker) |
| HP · ATK · DEF · MATK · MDEF · SPD | 36965 · 594 · 891 · 356 · 594 · 70 |
| XP · gold | 8719 · 1611 |
| Ring | 5 |
| Habitats | [[Regions/Moraveil\|Moraveil]], [[Regions/Iron Hold\|Iron Hold]] |
| Genre | Classic Fantasy |
| Trope | Giant insects as low-floor threats; the arachne as an intelligent monster race |

**Field note:** Weak to Light. Dangerous in numbers. Area attacks and chokepoints help.

## Attacks

| Attack | Kind | Power | Cooldown | Element | Telegraph |
|---|---|---|---|---|---|
| Mandible Crush | melee | 1.1 | 0 s | None | blue |
| Burrow Ambush | dash | 1.5 | 10 s | None | red |
| Acid Spray | ranged | 1 | 6 s | None | blue |
| Silk Snare | ranged | 0.4 | 10 s | None | blue |
| Shadow Grasp | magic | 1.5 | 10 s | Dark | red |

## Loot (`loot_insect_a`)

| Item | Chance | Amount |
|---|---|---|
| [[Items/Carapace Shard\|Carapace Shard]] | 60% | 1–3 |
| [[Items/Silk\|Silk]] | 30% | 1–1 |
| [[Items/Venom Sac\|Venom Sac]] | 15% | 1–1 |
| [[Items/A-Rank Monster Core\|A-Rank Monster Core]] | 100% | 1–1 |
| [[Items/Relic Shard\|Relic Shard]] | 0% | 1–1 |

## Design recipe

Rig `rig_hexapod` · mesh `hexapod_base` · material `chitin_gloss` · VFX `shadow_wisps` · palette `#2d2a4a` `#6b5b95` `#0d0d14` · elongated, irregular silhouette; still-then-sudden timing
