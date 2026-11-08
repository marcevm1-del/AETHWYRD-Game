# Housing and farming (AETHWYRD)

An optional personal home with four tiers, a storage chest and a few crop plots. Code: `Code/Ascend.Core/Housing.cs` (`Home`). Data: `Data/World/housing.json` and `Data/Items/crops.json` (schemas `housing.schema.json`, `crops.schema.json`). Design source: `systems.md` §6 "Housing → Territory"; this builds the Housing half only. Audit: `13_Production/housing_v6b_audit.md`.

## Principles (Canon wins)
- **Optional, no upkeep.** Nothing in the home is required. No rent, taxes, repairs, cleaning, watering or daily check-ins.
- **Crops never wither and absence is never punished.** A crop is ready after its grow time in in-game hours and then waits for as long as you like. Waiting gives no bonus and no loss. You can pull a growing crop and get the seed back.
- **Personal home, not an organisation.** The player cannot own a guild (Canon). No staff, no shop front, no residents, no territory in this wave; the Village stage (S rank) and Free City patronage stay in `systems.md` for a later design.
- **Quality is deterministic.** Harvest quality comes only from the Farming life rank.

## Tiers
| Tier | Guild rank | Price | Storage stacks | Plots | Notable features |
|---|---|---|---|---|---|
| Inn Room | F | free | 20 | 0 | bed, storage chest (the Sleeping Griffon room everyone starts in) |
| Rented Room | C | 800c | 60 | 1 | mailbox, kitchen, workshop, mirror, window planter |
| Home and Garden | B | 6,000c | 120 | 4 | garden, barn, guest rooms, trophy hall, expedition board |
| Manor | A | 40,000c | 200 | 6 | a study (the manor staff and shop front of §6 are not built) |

Tiers are taken in order, one at a time, for the guild rank and a one-time price. A tier never takes anything away (the validator checks features, storage and plots only rise). Feature ids such as `barn` and `guest_rooms` are flags for later waves (stables use `barn`); they have no behaviour here. Window planter and garden both use the plot count.

## Storage
A chest holds a number of distinct stacks (`storageStacks`). A stack is one inventory key, so `itm_x` and `itm_x@fine` are two stacks. Existing stacks always accept more. Deposit and withdraw conserve every item. Crafting does not yet pull from the chest (a later wiring step).

## Farming
Crops (`crops.json`): Turnip (24 h), Healing Herb (24 h), Wheat (36 h), Mandrake (72 h, rank E). A game day is 24 hours, which is 90 real minutes (`world_tuning.json`). Planting uses one seed. Harvest gives the yield plus the seed back, pays Farming XP like a gather node, and frees the plot. Seeds are sold at Fennick Reed's remedies stall, and the first upgrade to a tier with plots gives three each of herb, wheat and turnip seeds once.

Farming is now a **gather** life skill (it was "deferred"). Harvest quality by Farming rank: F and E Normal, D and C Fine, B and A Superior, S and above Masterwork.

### Feeding cooking and brewing
Turnip, Wheat and Healing Herb feed Wave B recipes: Turnip Mash (campfire), Garden Stew (hearth), Harvest Ale (brewery). Healing Herb already fed alchemy. The validator requires every crop's yield to feed a cooking, brewing or alchemy recipe and every seed to be sold somewhere.

## Saves
`SaveGame.Home` (`HomeSave`: tier id, plots with crop and planted hour, storage, a flag for the one-time seeds). Null in old saves; `SaveRules.Upgrade` fills it and the home starts as the Inn Room. `Home.Load` drops unknown tiers and crops, bad numbers and bad stacks without throwing. Time is the absolute in-game hour (day × 24 + hour), the same clock as gathering nodes.

## Not built here
Furniture, comfort, decorating, home visitors and events, guest rooms with companions living in them, the expedition board, barn and ranch behaviour (see `stables.md`), animal husbandry, staff and shop front (Manor), the Village/Territory stage, seasonal crops and the optional soil planning mini-game, crafting from the chest, and Unity wiring (loading the new JSON, a home screen, plot interaction, saving `Home`).
