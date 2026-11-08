# Housing v6b audit: home, storage and farming

Source: `upgrade v6` sections 8 to 10 (housing, farming, player economy) and `systems.md` §6 "Housing → Territory". Wave B left these out (`crafting_v6_audit.md`). This is part 2, step 2. Docs: `12_Systems/housing_and_farming.md`.

## What was asked and what was built

| Ask | Decision |
|---|---|
| A home with a few upgrade tiers | **Built.** Four tiers from Canon's table (Inn Room, Rented Room, Home and Garden, Manor) |
| Storage | **Built** as a stack-count chest per tier |
| A small plot with crops that grow in in-game time, never wither or punish absence | **Built.** Ready crops wait forever; no bonus, no loss; pulling a crop returns the seed |
| Crop items feeding Wave B cooking and brewing | **Built.** 3 new recipes (Turnip Mash, Garden Stew, Harvest Ale), herb also feeds alchemy; validator enforces it |
| Farming life skill | Moved from "deferred" to a gather skill with XP per harvest and quality by rank |
| Survival and daily chores, decay | **Rejected** (Canon Slow-Life); validator rejects upkeep, decay, wither, watering keys |
| Staff, shop front, residents, territory, defence, festivals | **Not built** (Manor staff, Village at S rank are a separate design; the player cannot own a guild) |
| Decorating, comfort, style sets, home events | **Not built** (furnishing wave) |
| Player marketplace, multiplayer trade | **Rejected** (single player; `item_and_economy_design.md` §15) |
| Weather, seasons for crops | **Not built** |

## Build summary
- New: `Housing.cs` (`Home`, data classes, saves), `housing.json`, `crops.json`, two schemas, 6 material items, 3 meals, 3 recipes, seeds in Fennick's stall, `HousingTests.cs` (12 tests).
- Changed: `SaveGame.Home`, `GameDatabase.Housing/Crops`, validator, farming skill kind.
- Old saves: `Home` is null, `Upgrade` fills it, a test covers it.

## Decisions (delegated creative control; the user may overrule)
1. Tier ranks follow `systems.md` §6 (Inn F, rented room C, home B, manor A). Prices 800c, 6,000c, 40,000c are my calibration against the money sinks list (housing is a big optional sink).
2. The Rented Room already has one window planter plot, so farming is not locked until rank B.
3. Harvest returns exactly the planted seed back (self-sustaining, not multiplying); more seed is sold at Fennick's stall for pennies.
4. Harvest quality is a table by Farming rank, no luck.
5. Storage counts distinct stacks (quality keys separate), not weight.
6. The `barn` feature flag appears at Home and Garden and later; the stables step ties boarding to it.

## Skipped and why
Everything under "Not built" in the doc; none of it is needed for a first playable home and several parts conflict with Canon or need a lore pass. No Unity work in this part.
