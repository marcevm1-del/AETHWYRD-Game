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
| 1 | The ten steps in §2 can be played in order in the standalone build by someone who has not seen the game | A playtest note by the owner and, if possible, one outsider |
| 2 | The fun test (`combat.md` §12) passes on every item kept in it | The dated record sheet |
| 3 | Every quest offered can be completed | The extended scene test passes |
| 4 | Save and load preserve every state in §2 | PlayMode save round-trip tests |
| 5 | 60 fps in the field on the target PC with the pack fighting | A profiler capture |
| 6 | `npm run build` and PlayMode both green on the commit that is built | A `QUALITY_GATES.md` §3 row |
| 7 | No capsule creatures in view on the slice path; a player character on screen | Screenshots; director review |
| 8 | The game can be heard | Listening pass |

Criteria 7 and 8 depend on the owner (character, creature art route, audio licences). If those are not available, the gate can be taken as **"systems proven, presentation pending"** on criteria 1 to 6, and the decision to widen content waits for 7 and 8.

## 6. The decision at the gate

- **Go:** plan Ring 1 completion, then Ring 2, with canon counts cut to what the measured production rate supports.
- **Fix:** specific criteria failed; they become P0 tasks and the gate is retaken.
- **Rethink:** the loop is not fun or not coherent. The owner decides what changes before anything is added.

## 7. Size of the work

By the auditors' estimates, in usage windows (not dates): phase 2 wiring is about six small-to-medium jobs; phase 3 content about six medium jobs; most need Unity, which means the owner's PC and one slot a week. At one Unity slot a week the slice is a matter of months, not weeks, and the real limit is the owner's hours for playtests and decisions. No date is given because the production rate has not been measured; the weekly telemetry row will supply it.
