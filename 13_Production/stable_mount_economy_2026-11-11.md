# Stable and mount economy review (systems-designer, 2026-11-11)

Scope: `Data/Companions/stables.json`, `Data/Companions/mounts.json`, `Data/World/housing.json` (boarding follows tiers), `Data/World/world_tuning.json` (taming). Decided by Claude under delegated creative control; the user may overrule any row. Slow-Life rules hold: no hunger, no fees, no upkeep, nothing lost or punished by absence.

## 1. There is no coin economy here, on purpose

Boarding, the guild kennel, feeding and the sanctuary all cost nothing (a favourite-food treat costs only the food). Canon's Slow-Life rows rule out upkeep, so the "economy" of this system is **capacity, pacing and unlock ranks**, not prices. Decision: **no stable fees, ever** (no boarding rent, no kennel fee, no mount upkeep, no saddle repair). The only coin sink on this path is the one-time home upgrade (Home and Garden 6,000c brings the barn and 6 places; the Manor 40,000c brings 12). Numbers below check that those capacities, rates and mounts are paced sensibly.

## 2. Findings and decisions

| # | Area | Finding (computed from data) | Decision |
|---|---|---|---|
| S1 | Mount stamina | Sprint-cycle average speed per family (sprint x1.4615 of run while stamina lasts, then a walk at 0.3385 until `recoverTo`): horse 12.1 m/s, wolf 12.0, desert beast 11.3, bear 9.9, **large ground monster 8.7 (1.02x its run speed)**. The B-rank mount was barely faster than a plain run; its sprint bar bought nothing. | **Changed** `large_ground_monster` stamina: `regenPerSec` 6 to 8 and `recoverTo` 45 to 40. Recovery from exhausted drops from 6.2 s to 4.0 s; the cycle average becomes 9.6 m/s (1.13x run), in line with the bear and its higher carry bonus (40) and rank gate (B). Other families unchanged. |
| S2 | Mount unlock ranks | Horse F, wolf E, bear and desert beast D, large ground monster B. On-foot run is 6.5 m/s; the base mount is 10 m/s (1.54x run). Longest road is 26 km (road_09): about 67 min on foot, about 36 min mounted. | No change. Mounts are a convenience, not a gate, and the ladder is smooth. |
| S3 | Boarding capacity | 0 / 0 / 6 / 12 by tier, kennel unlimited. 469 of 680 species are tameable (not unique, Tyrant or in an untameable family). Capacity is not meant to hold everyone; the kennel is unlimited so taming is never refused. | No change. |
| S4 | Sanctuary levels | The four looks stop at 40 species (8.5% of the 469 tameable species), so a collector hits the last look early and the 4 levels carry no further reward. | **Added** two cosmetic levels: **Wild Haven** at 100 species (21%) and **Ark Grove** at 250 species (53%). They cost nothing and never shrink; the validator keeps `minSpecies` strictly rising. |
| S5 | Breeding pace | One pair rests 72 in-game hours, then the egg takes 48 more: about one egg per 3 game days = 4.5 real hours per pair. Cross-element hatchling: 15% per breeding with a pity at 4, expected 3.2 breedings (about 14 real hours). Marking: 10% per nest egg with pity at 5, expected 4.1 eggs. | No change. Rare outcomes land within a long evening, never a grind, and pity makes them deterministic. |
| S6 | Bond by feeding | One treat a day (24 h cooldown) gives one assist; `bondPerAssists` 3 and `maxBond` 10, so bond 3 by feeding alone takes 9 game days (about 13.5 real hours) and bond 10 about 30 game days. Feeding is optional and fights give faster bond. | No change. Optional care should be slow, not a chore. |

## 3. Checks and test ideas (for qa-tester)

1. The large ground monster's recovery from exhausted takes (`recoverTo` - `exhaustedBelow`) / `regenPerSec` = 4.0 s of regen, and exhaustion still has hysteresis (clears only at `recoverTo`). The real-data stamina test (`MountTests`) reads the family numbers, so it should keep passing.
2. Sanctuary names are `Paddock`, `Meadow Run`, `Grove Sanctuary`, `Living Sanctuary`, `Wild Haven`, `Ark Grove` as species known pass 0, 5, 15, 40, 100, 250 (the existing test covers the first four).
3. No mount family's sprint-cycle average falls below 1.05x its run speed.
4. No key in `stables.json` or `mounts.json` matches fee, rent, upkeep, hunger or decay (the validator already enforces this on stables).

## 4. Method

Per family: sprint seconds = (`max` - `exhaustedBelow`) / `sprintDrainPerSec`; exhausted seconds = (`recoverTo` - `exhaustedBelow`) / `regenPerSec`; cycle average speed = (sprint s x run x 1.4615 + exhausted s x run x 0.3385) / (sprint s + exhausted s), with run = 10 x `speedMult`. Foot run 6.5 m/s and the sprint ratio come from `Data/Player/locomotion.json`; road lengths from `Data/World/physical_map.json`; tameable counts from `species.json` and `world_tuning.json` (`taming.untameableFamilies`).
