# Stables and the sanctuary (AETHWYRD)

Where tamed partners and ground mounts live between adventures. Code: `Code/Ascend.Core/Stables.cs` (`Stables`) plus `Partner` fields in `Taming.cs`. Data: `Data/Companions/stables.json` (schema `stables.schema.json`). Builds on the home tiers in `housing_and_farming.md`, the partner roster in `Taming.cs` and the ground mounts in `companions_and_mounts.md`. Audit: `13_Production/stables_v8_audit.md`.

## Principles (Canon wins)
- **Three travelling partners, always.** The rest wait on the ranch, and the ranch grows with home upgrades (`systems.md` Taming Roster).
- **Taming is never refused.** Partners that do not fit the home stable wait in the **guild kennel**, which has no limit. Nobody is released, lost or sent away by a full stable, a smaller home or a long absence.
- **Optional care, no needs.** No hunger, sickness, escape, decay or upkeep. A treat is a small shared moment, never a duty.
- **Ground mounts only.** Mount choices come from `mounts.json`, which the validator already keeps free of flying, dragon and aquatic species. No flying or aquatic mounts.
- **Breeding and egg nests follow the Canon rows exactly** (see below); nothing else about animal husbandry is invented.

## Where a partner is
| Place | Limit | Notes |
|---|---|---|
| Travelling (`Active`) | 3 | Existing rule |
| Home stable (`AtHome`) | by home tier | Needs the `barn` feature: 6 at Home and Garden, 12 at the Manor, none before |
| Guild kennel | none | Everyone else |

`Board`, `Kenneled` and `Activate` move a partner between the three places and never leave one in two at once. `Reconcile` (also run on load) moves boarders above the capacity into the kennel. Load the home before the stables.

## Feeding (optional)
Each species family has a favourite food (`world_tuning.json` taming). Feeding it once a day (24 in-game hours) counts as one shared moment toward Bond, exactly like an assist in a fight. Other items are not taken; a treat given too soon, or at max Bond, is not used up. Nothing happens if you never feed anyone.

## Ground mounts
`SetMount(partner, guildRank)` picks one tamed partner as your mount if its species is in a `mounts.json` family and your rank meets that family's unlock rank. Speed, stamina and mounted combat stay in `Mounts.cs`. Releasing the mount clears the choice.

## Sanctuary
The sanctuary has four looks (Paddock, Meadow Run, Grove Sanctuary, Living Sanctuary) that depend on how many different species you have cared for (owned, boarded, hatched or released). It costs nothing and never shrinks.

## Breeding and egg nests (as Canon defines them)
Canon sources: `the_big_upgrade.md` §27 (ranch breeding passes on population-variant traits; rare cross-element hatchlings; a marking collection) and `borrowed_features.md` §12 (eggs from dens hatch at the ranch; hatchlings start at Bond 3 and can roll rare markings).
- **Breeding**: two boarded partners of one family tree (a species and its variants), not unique or Tyrant, each at Bond 3 or more, with a free egg place. A pair rests 72 in-game hours. The egg is ready 48 hours later and waits for you forever.
- **Markings**: Albino and Alpha (population tiers) are inherited from a parent about half the time. They are cosmetic and collectable; the marking collection counts "species:marking" pairs.
- **Cross-element hatchlings**: when the parents differ in element, the egg may be the base species or a third elemental variant of the same tree (never above the parents' rank). 15% chance per breeding, and guaranteed after 4 eligible breedings without one.
- **Egg nests**: `AddNestEgg` takes a den egg (10% marking, guaranteed on the 5th plain egg). If you hold too many eggs the egg stays in the nest. Eggs held: at least 2, or half the boarding capacity.
- **Hatching**: Bond 3, never joins the party by itself, boarded if there is room, else in the kennel.
- All rolls come from `DeterministicRandom` with the seed and counters, so tests and saves are exact.

## Saves
`SaveGame.Stables` (eggs, feeding times, pair rest times, species seen, marking collection, pity counters, mount id). `PartnerData` gained `Id`, `AtHome` and `Marking`; old partners get an id on load and keep everything else. `Stables.Load` drops only invalid numbers and entries and never an egg or partner.

## Not built here
Training grounds, cosmetics and saddles, creature recovery, monster workers and jobs (`borrowed_features.md` 22), visual sanctuary scenes, legendary creatures, hatching UI, an egg-carry weight rule, and Unity wiring (loading `stables.json`, a stable screen, mounting, nest placement in dens).
