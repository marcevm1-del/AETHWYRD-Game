# Housing and farming balance review (systems-designer, 2026-11-09)

Scope: `Data/World/housing.json`, `Data/Items/crops.json`, the Farming life skill in `Data/Items/life_skills.json`. Decided by Claude under delegated creative control; the user may overrule any row. Slow-Life rules hold throughout: no decay, no upkeep, no chores, nothing punishes absence (a ripe crop waits forever).

## 1. Findings

| # | Finding | Evidence |
|---|---|---|
| F1 | **Farming cannot be ranked past about D.** Harvest XP is `gatherXpPerNode[crop rank]` and a crop 2+ ranks below the skill pays 25% (min 1). The best crop is Mandrake (rank E), so from C on every harvest pays 2 XP. | Computed from `life_skills.json` xp table: C to B needs 4,000 XP = 2,000 harvests (about 2,250 real hours with 4 plots). A to S, S to SS and SS to SSS are worse. |
| F2 | The harvest-quality table (Superior at B/A, Masterwork at S+) is therefore unreachable. | Same calculation. |
| F3 | **Tier prices are sane as one-time sinks** and stay unchanged: Rented Room 800c (about 4 E-rank quests at 180 to 300c), Home and Garden 6,000c, Manor 40,000c. Only F/E/C quest rewards exist in data (F 20 to 70c, E 90 to 300c, C 4,500c), so B and A are not yet checkable. | `Data/Quests/quests.json`. |
| F4 | Current crop income is small: about 9 to 11c per plot per game day (Turnip 9c/24h, Herb 9c/24h, Wheat 16c/36h, Mandrake 30c/72h). Six Manor plots earn about 60c a game day (1.5 real hours), so farming is never the economy. Good. | `crops.json` x `items.json` values. |
| F5 | Storage (20/60/120/200 stacks) and plots (0/1/4/6) rise monotonically and match the validator rules. No change. | `housing.json`. |

## 2. Decision: a crop ladder, not an XP multiplier

Raising gather XP for farming alone would break the shared ladder. Instead the missing crops are added, one new crop per rank D to SSS. Grow time rises with rank and batch value rises slower than rank income, so farming stays a quiet side pillar and never an income plan.

| Crop rank | growHours | yieldCount | Target batch value (c) | Value per plot-day (c) | Quality at skill rank |
|---|---|---|---|---|---|
| F (exists) | 24 to 36 | 3 to 4 | 9 to 16 | 9 to 11 | Normal |
| E (Mandrake, exists) | 72 | 1 | 30 | 10 | Normal |
| D | 72 | 2 | 40 | 13 | Fine |
| C | 96 | 2 | 70 | 17 | Fine |
| B | 120 | 2 | 120 | 24 | Superior |
| A | 144 | 3 | 200 | 33 | Superior |
| S | 168 | 3 | 320 | 46 | Masterwork |
| SS | 192 | 3 | 480 | 60 | Masterwork |
| SSS | 240 | 4 | 700 | 70 | Masterwork |

Passive-income guard (`item_and_economy_design.md` 9.2): income is capped by visits, not by waiting. A plot yields once per planting however long it sits ripe. Six Manor plots of A-rank crops come to about 200c per game day at best (about 133c per real hour), so the 40,000c Manor takes about 300 game days to repay from farming alone.

## 3. Time to rank (4 plots, skill at the crop's own rank, ripe crops harvested on time)

| Step | XP | Now: XP per harvest | Now: real hours | Proposed: XP per harvest | Proposed: real hours |
|---|---|---|---|---|---|
| F to E | 250 | 5 | 19 | 5 | 19 |
| E to D | 550 | 7 | 88 | 7 | 88 |
| D to C | 1,800 | 7 (trivial gap, 2 below) | 289 | 10 | 202 |
| C to B | 4,000 | 2 | 2,250 | 14 | 429 |
| B to A | 9,000 | 2 | 5,062 | 20 | 844 |
| A to S | 20,000 | 2 | 11,250 | 28 | 1,607 |
| S to SS | 40,000 | 2 | 22,500 | 40 | 2,625 |
| SS to SSS | 70,000 | 2 | 39,375 | 55 | 3,818 |

Farming is a background skill (visits are batches, and sleeping and travel advance the clock), and 6 Manor plots cut these figures by a third. The top steps stay a long-haul completionist goal, like the other gather skills. Calculation script: `13_Production/housing_farming_balance_2026-11-09.md` section 5.

## 4. What was and was not changed here

- **No data changed.** New crops need new items (seed and yield), a seed on a shop shelf and a cooking, brewing or alchemy recipe that eats the yield (the validator requires all three). Those files belong to **items-designer** (`items.json`, `recipes.json`, `shops.json`) and a recipe pass.
- **Hand-off to items-designer:** add one crop per rank D to SSS using the table in section 2 (ids `crop_<name>`, yield item per crop, a shop seed price near 1/5 of the batch value, a recipe consumer each). Then append the rows to `Data/Items/crops.json` (that file is the data half of this job; the rows follow the table). Until then Farming keeps working but stalls at about D, as today.
- **Test ideas for qa-tester:** (1) every crop rank D to SSS exists and `growHours` rises with rank; (2) batch value per plot-day never exceeds 80c; (3) a skill at rank r harvesting a rank-r crop never gets the trivial multiplier; (4) an old save with the existing four crops still loads.

## 5. Method

Per rank step: `harvests = (xpToReach[next] - xpToReach[this]) / xpPerHarvest`, where `xpPerHarvest = gatherXpPerNode[cropRank]` times 0.25 if the skill is 2 or more ranks above the crop (`trivialRankGap` 2, minimum 1). `game days = harvests / plots x growHours / 24`; one game day is 90 real minutes (`world_tuning.json`).
