# Pricing pass, 2026-11-09 (items-designer)

Checked every item value against the economy design (`09_Equipment/item_and_economy_design.md` section 3, `monster_core_pricing.md`). Values are copper. Decided under delegated creative control; the user may overrule. Canon was not touched.

## Rules applied
1. **Crafting never loses money.** A recipe output is worth at least 1.2 times the value of its inputs. Twelve items were below that (three potions, five meals and drinks, three weapon parts, one dye); each was raised to ceil(1.2 x inputs). The table is below.
2. **Cores stay on the posted curve** (2 c at F doubling per rank). No change.
3. **Shop retail is never below any shop's buy-back** (existing validator rule): still green, no shop price changed.
4. **No hidden rank multiplier.** Crafted gear is worth far more than its raw materials by design (materials are cheap drops, craft skill adds the value), so the ratio of 15x to 35x at C and B is intended. What matters is that contract pay outpaces it: a rank C contract pays 4,500 c against C gear at 650-900 c, and an F contract pays 40-70 c against F gear at 18-40 c, so no price needs a cap.
5. **New items (rune and scroll set, Salvage Warren)** follow the existing rune and scroll bands: E rune 55-58, D rune 120-125, E scroll 72-76, ratio to inputs 3.6x to 6.7x, the same band as the older F and E runes (3.3x to 5.4x).

## Rank bands for crafted gear (after this pass)
| Rank | Crafted gear (n) | Lowest | Median | Highest |
|---|---|---:|---:|---:|
| F | 8 | 18 | 35 | 40 |
| E | 4 | 90 | 95 | 110 |
| D | 3 | 200 | 230 | 260 |
| C | 3 | 650 | 700 | 900 |
| B | 1 | 3000 | 3000 | 3000 |

| Item | Rank | Old value | New value | Input cost |
|---|---|---:|---:|---:|
| itm_minor_hp_potion | F | 10 | 12 | 10 |
| itm_healing_potion | E | 40 | 52 | 43 |
| itm_greater_healing_potion | D | 90 | 96 | 80 |
| itm_inkwell_dye | F | 12 | 15 | 12 |
| itm_mushroom_skewer | F | 10 | 14 | 11 |
| itm_hearth_loaf | F | 14 | 20 | 16 |
| itm_hearth_ale | F | 12 | 20 | 16 |
| itm_brimstone_bitters | E | 35 | 58 | 48 |
| itm_part_scrap_blade | F | 8 | 15 | 12 |
| itm_part_pelt_hilt | F | 6 | 10 | 8 |
| itm_part_fang_hilt | F | 9 | 15 | 12 |
| itm_harvest_ale | F | 14 | 18 | 15 |

## Open points (not changed, for the economy owner)
- **B rank gear is a single data point** (Mythic Horn Lance, 3,000 c, a 3.3x jump over the top C item). Tune it when more B recipes exist; one item cannot set a band.
- **E-rank healing potions** are now valued at 52 c and 96 c, but the only potion for sale is the minor one (14 c at Reed's Remedies); the larger potions are craft-only. Add shop stock for them with a service premium (retail at or above 1.4 x value) when Reed's stock is next reviewed.
- The new rune and scroll items have no shop stock, deliberately: they are crafted at the rune anvil and enchanting table or found in the Salvage Warren pay-chest.
