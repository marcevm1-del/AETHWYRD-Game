# Stables v8 audit: stables, sanctuary, mounts and breeding

Source: `upgrade v8` section 10 ("Stables and creature sanctuaries") and the deferred row in `companions_v8_audit.md`. This is part 2, step 3. Docs: `12_Systems/stables.md`.

## What was asked and what was built

| v8 feature | Decision |
|---|---|
| Personal stables, creature housing, creature storage | **Built.** Home stable with capacity by home tier plus an unlimited guild kennel |
| Mount selection | **Built** (ground families from `mounts.json` only) |
| Feeding areas | **Built** as an optional daily treat; no hunger or punishment |
| Training grounds | **Not built** (no Canon design) |
| Cosmetic customisation | **Not built** |
| Breeding, if appropriate | **Built exactly as Canon defines it** (Big Upgrade 27 and egg nests); nothing extra |
| Creature recovery | **Not built** (knocked-out partners already recover; no injuries exist) |
| Sanctuary upgrades that evolve visually | **Built** as four levels from the number of species cared for; visuals are a later art job |
| Stable Manager NPC, expeditions, monster jobs | **Not built** |
| Flying or aquatic mounts | **Rejected** (Canon; the validator also blocks them) |
| Hunger, sickness, escape | **Rejected** (Slow-Life) |

## Canon checks
- Taming Roster: 3 active partners; the ranch holds the rest with capacity that grows with home upgrades. Followed; a full stable falls back to the kennel.
- Ranch breeding (Big Upgrade 27): passes on markings (Albino, Alpha), cross-element hatchlings, marking collection. Egg nests (borrowed features 12): hatch at the ranch, Bond 3, rare markings. Both followed. These rows sit in the "Big Upgrade" and "Borrowed features" proposals in Canon section 6; they were adopted in the 2026-11-07 decisions, and nothing here goes past what they say.
- Rare outcomes have pity counters so no collection depends on a 0.5% roll.

## Build summary
- New: `Stables.cs`, `stables.json`, schema, validator block, `StablesTests.cs` (14 tests).
- Changed: `PartnerData` (`Id`, `AtHome`, `Marking`), `PartnerRoster` (ids, `ById`, load copies the new fields), `SaveGame.Stables`, `GameDatabase.Stables`.
- Old saves: partners without ids get one on load; `Stables` is null and `Upgrade` fills it.

## Decisions (delegated creative control; the user may overrule)
1. Capacity 6 at Home and Garden, 12 at the Manor, none earlier (the barn flag from the housing step).
2. Overflow goes to an unlimited guild kennel, so the roster never refuses a tame.
3. Feeding accepts only the favourite food, once per in-game day, one assist each.
4. Breeding needs Bond 3 and a shared family tree, 72 hour pair rest, 48 hour incubation; uniques and Tyrants never breed.
5. Cross-element: 15% plus a guarantee on the 4th eligible breeding; the pool is the base species and its elemental variants at or below the parents' rank.
6. Markings are cosmetic only; the collection is a set of species and marking pairs.
7. Egg capacity is max(2, boarding / 2); a full hand leaves the nest egg in the nest.

## Skipped and why
Everything under "Not built" in the doc. None is needed for a first playable stable and several have no Canon design. No Unity work.
