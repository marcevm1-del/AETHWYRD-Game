# Vertical slice plan

The first small, complete, playable experience. It exists to prove that AETHWYRD's core systems work **together** before any more content footprint is added. Proposed 2026-11-12; awaits the owner's approval (`MASTER_PROJECT_PLAN.md` §8).

## 1. Where it comes from

Canon already defines the slice: Ring 1, "The Wooden Card" (`13_Production/production.md` §5): Brindlewick and Whisperwood, ranks F to E, four base classes, Lyra and Mochi, the Goblin Chief trial, one dungeon, the guild board, twenty monsters. This plan does not replace it. It splits it in two:

- **Slice A, "One Card, One Wood"**: the smallest cut that proves the loop. This document.
- **Ring 1 complete**: everything else in Canon's Ring 1 (three more classes, the dungeon, Mochi, terrain). Roadmap phase 6, started only if slice A passes its gate.

## 2. The loop the slice must prove

One sitting of 30 to 45 minutes, no developer help:

1. **Arrive** in Brindlewick as a rank-F adventurer; the Status Window shows one line the System will not tell you.
2. **Take a job** at the guild board.
3. **Walk into Whisperwood** and **notice something off the path**: a sign, tracks, a marking. Follow it to a second clue. The journal records both.
4. **Meet the creature you tracked**, already knowing something about it. Its bestiary entry grows by what you observed, not only by what you killed.
5. **Fight a goblin pack** that comes from several sides and breaks when it is losing.
6. **Loot, craft or buy** something better; **rest** at the inn.
7. **Make a choice** in a quest and see the board remember it.
8. **Take the F to E trial**: Grukk, whose phases ask different things of you.
9. **Free Whisperwood** and see the wood change: a new route, different creatures, a notice on the board, one discovery that was not there before.
10. **Save, quit, load**: everything above is still true.

## 3. What is in, and what each part needs

| Slice element (from the owner's list) | In the slice as | Exists today | Missing piece | Entry |
|---|---|---|---|---|
| A small playable area | Brindlewick, Millbrook's edge, the Whisperwood field | Yes: `Ring0_Graybox.unity` | - | - |
| Meaningful exploration | 4 to 6 hand-placed discoveries, one two-clue chain | No content; the journal rules exist | Discovery registry and pickups | UPG-009 |
| One interesting creature ecosystem | The 21 Ring 0 and Ring 1 species with role tags; day and night differences; signs for the tracked creature | 19 species hand-placed; 18 over rank band | Rank-band fix; encounter tables as spawn source; (tags optional) | UPG-019, UPG-020; UPG-021 optional |
| A complete combat encounter | The goblin pack with group tactics; Grukk with phase attack sets | Combat is built; tactics and boss verbs are not wired | Wiring | UPG-002, UPG-003, UPG-005, UPG-007 |
| A discovery or appraisal interaction | Bestiary tier grows by observation; weakness shown after a hit | Kill-count tiers only | One vocabulary, a non-kill route | UPG-011, UPG-008 |
| A Field Journal interaction | Journal pages for discoveries and quests, written by the world | Pages for dungeon clues and archive, with no writers | Two pages, pickups | UPG-009, UPG-010 |
| A progression or reward loop | Level, gear, crafting, guild rank F to E | Yes | - | - |
| A quest or objective | The board jobs and the Act I quests that can be completed; one choice with a consequence | 19 of 32 completable; choices ignored | Park or place; choice outcomes | UPG-014, UPG-013 |
| A working save and load path | One slot, everything above persists | Yes, tested | Version rule | UPG-028 |
| Coherent player feedback | Hit feel, telegraphs, HUD, sound | Visual feedback yes; **no sound**; placeholder UI | Audio is blocked on licences | UPG-030 (phase 4) |
| The game's signature | The redacted Status line reacts to one story flag | A fixed string | A flag hook | UPG-016 (needs CD-002) |
| The place answers | Liberation delta | Raids stop; numbers change | Visible changes | UPG-018 |

## 3a. The core cut (recommended) and the stretch

The red-team review judged the table above too large for one Unity slot a week: it needs two new data types, a save change and three canon decisions before the loop can close. The same loop can be proven with less. **The core cut is the recommended slice; everything else in §3 is stretch**, added only after the core passes.

| Step of the loop | Core cut | Why it is enough | Entry |
|---|---|---|---|
| Fight with a partner without losing credit | Ally kills count | Without it the trial can be lost (R31) | UPG-040 |
| Discover and record | 3 or 4 discoveries written through the **existing** discovery journal (its landmark, creature and secret categories exist in `Data/World/living_world.json` and are already saved), plus the journal page that shows them | No new data type and no new save field. Unverified: whether those categories can express a two-clue chain; if not, the chain is stretch | UPG-009 (reduced), UPG-010 |
| The pack fight | Goblin pack with group tactics, on today's hand-placed camps | Encounter tables are not needed to prove the fight | UPG-002, UPG-003, UPG-005 |
| The trial | Grukk with one attack that only his second phase uses | Armour and weak points are stretch | UPG-007 (reduced) |
| The place answers | Three visible changes after liberation | A delta of three proves the idea | UPG-018 (reduced) |
| The signature | The redacted Status line changes when Whisperwood is freed | One flag that already exists | UPG-016 (needs CD-002) |
| Persistence | Save, quit, load | Already tested | - |

Stretch, in this order once the core passes: encounter tables as the spawn source (UPG-020, with UPG-019), the bestiary vocabulary and research tasks (UPG-011), weakness readout (UPG-008), quest choice outcomes (UPG-013), Grukk's armour and weak point, the save version rule and product identity (UPG-028, required before any build leaves the PC).

Day and night differences are not part of the test: an in-game day is 90 minutes and a sitting is 30 to 45, so night is reached only by sleeping at the inn.

## 4. Explicitly out of the slice

Stated so that nothing slides in:

- Any second region, terrain tiles, streaming, the world map beyond what exists.
- Classes other than Swordsman. (A second class is a Ring 1 item and needs UPG-004 first.)
- Magic and chants; weapon families beyond the sword; weapon mastery.
- The dungeon (Salvage Warren) and its five quests; puzzles; the Labyrinth.
- Housing, farming, runes and enchanting, stables management, mount riding.
- Companions other than Lyra; romance; companion arcs beyond what is placed.
- The ecology simulation beyond role tags; seasons; weather.
- Lying Interface stages beyond the first hook; appraisal of people and items.
- Acts II to VI; reputation and factions; NPC schedules.
- A status-effect framework; wounds; environmental material classes.
- Steam, localisation, achievements.

Each of these has an entry in `UPGRADE.md` or `IDEAS.md`, so being out of the slice loses nothing.

## 5. The slice gate (roadmap phase 5)

The slice passes when all of these hold, each with its evidence filed:

| # | Criterion | Evidence |
|---|---|---|
| 1 | One person who has not seen the game plays the loop in §2 in the standalone build without help. The owner's own run does not satisfy this | A playtest note naming the tester, plus three answers: would you play another hour; what did you notice that nobody told you; where were you lost |
| 2 | The fun test passes on the list frozen in T-002. Items are not removed after a fail | The dated record sheet |
| 3 | Every quest the board or an NPC offers is completed in a played run or by a PlayMode test that finishes it (presence of the giver is not enough) | Test results and the run note |
| 4 | After save, quit and load these are unchanged: level and XP, guild rank, inventory and equipment, quest states and flags, bestiary tiers, discovery journal entries, partners and bond, Whisperwood's liberated state and its changes, the redacted line's state | PlayMode save round-trip tests, one per item |
| 5 | 60 fps at 1080p on the owner's PC with the goblin pack fighting (the PC's GPU is recorded with the capture; `art_budgets.md` names a GTX 1650 as the floor) | A profiler capture |
| 6 | Core green and PlayMode with 0 failures on the commit that is built | A `QUALITY_GATES.md` §3 row |
| 7 | No capsule creatures in view on the slice path; a player character on screen | Screenshots of normal play; director review |
| 8 | The game can be heard | Listening pass |

Criteria 7 and 8 depend on the owner (character, creature art route, audio licences). If those are not available, the gate can be taken as **"systems proven, presentation pending"** on criteria 1 to 6, and the decision to widen content waits for 7 and 8.

## 6. The decision at the gate

- **Go:** plan Ring 1 completion, then Ring 2, with canon counts cut to what the measured production rate supports.
- **Fix:** specific criteria failed; they become P0 tasks and the gate is retaken.
- **Rethink:** the loop is not fun or not coherent. The owner decides what changes before anything is added.

## 7. Size of the work

By the auditors' estimates, in usage windows (not dates): phase 2 wiring is about six small-to-medium jobs; phase 3 content about six medium jobs; most need Unity, which means the owner's PC and one slot a week. Counting the slots the roadmap gives phases 2 and 3 (8 to 11) at one Unity slot a week, with owner decisions in between, the full slice is **at least three to four months if nothing goes wrong**, before presentation work. The core cut in §3a is roughly half of that. The real limit is the owner's hours for playtests and decisions. No date is given because the production rate has not been measured; the weekly telemetry row will supply it.
