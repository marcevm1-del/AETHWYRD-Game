---
type: progression-rules
source: Data/Classes/progression.json
tags: [system, progression, player-stats]
---
# Player Progression and Stats

This note summarizes the shared progression data used by the player rules and monster XP generator. Data/Classes/progression.json is authoritative; C# applies documented rounding.

- **Base primary stat:** 10
- **Free points:** 5 each level after level 1, allocated by the player’s build
- **Level cap:** 300 (Canon)

## Derived stats

| Stat | Formula | Cap |
|---|---|---:|
| ATK | 10 + 2 × STR + 0.5 × DEX | — |
| MATK | 10 + 2 × INT + 0.5 × WIS | — |
| DEF | 5 + 1.2 × VIT | — |
| MDEF | 5 + 1.2 × WIS + 0.3 × INT | — |
| HP | 60 + 8 × VIT + 6 × level | — |
| MP | 30 + 4 × INT + 2 × WIS | — |
| SP | 80 + 1 × AGI + 0.5 × VIT | — |
| SPD | 100 + 0.1 × AGI | 200 |
| CRITCHANCE | 0.05 + 0.001 × DEX | 0.6 |

Primary stats are built from base value + class growth × level + free points allocated to the stat. Gear bonuses are applied to supported combat stats.

## Experience curve

- **Monster XP:** round(8 + level^1.6 × 3); unique multiplier ×20.
- **XP to next level:** same-level monster XP × (10 + 0.25 × level).
- Quests, discovery and crafting add progress, so the kill count is a baseline, not a required grind target.
- At the level cap, XP to next level is zero; post-cap growth follows the separate Transcendence rules in the design bible.
