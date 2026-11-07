# Living world (upgrade v4, Canon-safe subset)

> **Status:** rules, data and tests are built in `Code/Ascend.Core` (`LivingWorld.cs`); nothing is wired into Unity yet. Data: `Data/World/living_world.json` (schema `living_world`, checks in `Tools/validate/living_checks.js`). Audit of what was taken and left from upgrade v4: `13_Production/living_world_v4_audit.md`.

The world feels inhabited through three small, optional systems. All of them run on **in-game days** only. None of them gates anything, changes a settlement, moves an owner, starts a war or simulates the world in the background (Canon §4d, §5 and the offline-first rows in §6).

## 1. NPC daily schedules (optional)

`NpcData.Schedule` already existed in `Data/NPCs/npcs.json` (6 NPCs have one). `NpcScheduleResolver.Resolve(npc, calendar, tuning, day, hour, schedulesEnabled)` answers "where are they now?":

1. The entry for the current day part (morning, day, dusk, night) and weekday, if schedules are on.
2. Otherwise the **home post**: the NPC's `day` entry.
3. Otherwise the NPC's **settlement**.

Rules that keep it harmless:
- **Never gating.** `Reachable` is always true and `Place` is never empty; the player can always find an NPC in their settlement.
- **Essential tiers** (`core`, `major`) are always `Available`. Ordinary townsfolk rest at night (`Available` false) and talk in the morning.
- **Schedules can be turned off** (`schedulesEnabled`; default from `living_world.json`). Then everyone stands at their home post.
- `Available` is advisory. One shopkeeper (`townsfolk` tier) would be asleep at night, so the Unity side must keep every shop and inn usable (night service at the inn, or the shop simply closed by day-part text) and never block a quest giver. Add the NPC to an essential tier if that ever matters.
- The validator checks day parts, weekdays and that a scheduled NPC has a settlement.

## 2. Event director (caravans and small wandering encounters)

`EventDirector.Advance(save, today, regionAllows)` rolls each in-game day once, in order, with `DeterministicRandom` seeded from the world seed, the event id and the day. So the same save always gives the same events.

| Rule | Value (`living_world.json`) |
|---|---|
| Events at once | 2 in the world, 1 per region |
| Cooldown | per event, at least its duration |
| Duration | 1 to 7 in-game days, then it is gone |
| Weekdays | optional list; empty means any day |
| Catch-up | after a long gap (sleeping, loading) only the last 7 days roll, so there is no storm |
| Fresh save | starts quietly: the first call rolls only that day |
| Besieged regions | the caller's `regionAllows` returns false and nothing spawns there |

An event may do only four things (schema enum; today these are **data only**, Unity applies them later): `shop_stock` (a few extra items on an existing shop's shelf for the event's days), `rumour` (a line for the rumour board), `small_encounter` (an ordinary, non-unique, non-Tyrant species that lives in that region) and `board_note` (an optional small errand note). Not allowed, and checked by the validator: settlement destruction, faction wars, ownership changes, succession, real-time deadlines, anything open-ended.

The pool ships with 3 caravans (Grain, Herb peddlers, Ore wagons) and 3 wanderers (Lost peddler, Boar crossing, Jackalope pack). Add more rows in the JSON; no code change.

## 3. Discovery journal

`DiscoveryJournal` uses the project's one vocabulary: **Unknown / Heard / Visited** (`MapStatus`). A rumour pencils an entry (Heard); finding it in place inks it (Visited); hearing never downgrades a visit. Entries are `category:id` with categories `region`, `landmark`, `creature`, `secret` (data). Unknown categories and empty ids are refused. `Count(category, status)` feeds a journal screen. There is no fourth state (Canon §6 WF1).

## Save

`SaveGame.LivingWorld` (`Events`: last rolled day, last start day per event, active events; `Journal`: entries). It is **null in older saves**; `SaveRules.Upgrade` null-coalesces it to a fresh director and an empty journal, and the test `OldSavesLoadWithoutLivingWorld` loads a save written without the key. No save version bump is needed because nothing changed meaning.

## Not built (on purpose)

Faction war, politics and succession; a dynamic economy; world-state simulation; procedural quest generation; settlement change; anything in `Game/`. The Unity side (calling `Advance` when the day changes, showing the extra stock, the journal screen) is a later, separate task for the gameplay and UI engineers.
