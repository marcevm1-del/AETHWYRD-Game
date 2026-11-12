# Dashboard

Read this first. One page, refreshed at the end of every weekly cycle. Last refresh: **2026-11-12** (cycle 0). Everything here points to its evidence; no percentages are given because none could be defended.

## Where the project is

| | |
|---|---|
| Overall | A large validated design, a broad tested rules library, a small playable game (one field, one class). See `PROJECT_STATUS.md` |
| Phase | **0 to 1**: the audit and this management system are built and reviewed and await your approval; phase 1 (verify and judge) can start with the two tasks already approved |
| Milestone in progress | MS-1 build verified · MS-2 core loop judged · MS-3 first performance number |
| Plan state | Master plan, slice scope and first backlog are **proposed, awaiting the owner** |

## Evidence in hand

| Check | Result | Date |
|---|---|---|
| Data validation | Valid; 28 map warnings; 0 graph findings | 2026-11-12 |
| Core rules tests | 755 passed | 2026-11-12 |
| Unity PlayMode | 183 passed | 2026-11-08, **not re-run** |
| Fun test | Never run | - |
| Performance | Never measured | - |

## Systems (150 inventory rows; `SYSTEM_INVENTORY.md`)

| In the game | Rows | Examples |
|---|---|---|
| Tested (PlayMode, last run 2026-11-08) | 22 | Attack chain, dodge and parry, monster AI, quests, weekly board, sieges, save and load, gathering, map knowledge, photo mode |
| Implemented, no automated test found | 41 | Style Rank, shops, crafting, equipment, inns, taming, day clock, boss phases |
| Partial or prototype | 39 | Reactions (Firestorm only), classes (1 of 12), companions (1 of 14), journals (no writers), living world (no effects), quest data (19 of 32 completable) |
| Not wired, not started, not run | 18 | Group tactics, boss armour and weak points, weapon movesets, encounter tables, region graph, puzzles, meal buffs, runes, housing and farming, audio, terrain, the fun test |
| Documented only, or nothing | 17 | Magic, races and origins, Field Journal evidence, appraisal of people and items, reputation, wounds, ecology relationships |
| Uncertain (3) or not applicable (10) | 13 | Banter playback, Style Rank bonus, party synergy wiring; tool-only rows |
| Verified or complete | **0** | No playthrough on record; no agreed acceptance criteria yet |

## Tasks (`FEATURE_BACKLOG.md`)

| State | Count | Which |
|---|---|---|
| Ready | 3 | T-001 PC verify run · T-002 split the fun test · T-003 play it |
| Awaiting approval, no Unity needed | 5 | T-013 and T-020 can start on approval; T-008 and T-021 also need one answer each (decisions 14 and 25); T-005 is not needed for the slice |
| Awaiting approval, needs a Unity slot | 11 | **T-024 first (ally kill credit, P0)**, then T-004, T-006, T-007, T-009 (also needs decision 16), T-010, T-012, T-014, T-018; T-019 and T-023 are not needed for the slice |
| Awaiting a named owner decision | 5 | T-011, T-015, T-016, T-017, T-022 |
| In progress / blocked / done | 0 | - |

## Critical risks (`TECHNICAL_RISK_REGISTER.md`)

| ID | Risk |
|---|---|
| R31 | A kill landed by a companion or partner gives no credit; on the Tyrant it can lose the region's liberation. Confirmed by reading the code, not yet reproduced |
| R16 | The design is about two orders of magnitude larger than the build |
| R17 | Tested rules and finished data that the game does not use |
| R18 | The core loop has never been judged by a person |
| R3, R23 | Unity unverified since 2026-11-08 and outside every automated gate |
| R27 | Hand-authored content (NPCs, quests, dialogue) has no generator and no budget |
| R15 | Agent orchestration itself hit the usage limit today |

## Registers

| Register | Count | Detail |
|---|---|---|
| Upgrades | 40 | 2 approved (UPG-001, UPG-026) · 36 proposed · 2 blocked on the owner (UPG-030 audio, UPG-031 character) |
| Ideas | 27 | 16 new · 2 ready for review (IDEA-001 Lying Interface, IDEA-014 returner recap) · 2 need research · 7 deferred |
| Canon-level discrepancies | 15 | 14 open, 1 resolved |
| Documentation discrepancies | 20 | 14 open, 6 resolved |
| Risks | 31 | R1 to R14 carried, R15 to R31 new |

## Decisions waiting on you

Grouped so each can be answered in a word. Details are in the row cited.

**To start work**

1. Approve the strategy, especially "nothing new before the slice gate" (`MASTER_PROJECT_PLAN.md` §3).
2. Approve the slice scope: the **core cut** (`VERTICAL_SLICE_PLAN.md` §3a, recommended) or the full table in §3.
3. Approve the first wave of the backlog: T-013 and T-020 in the cloud; T-024 as the first Unity task after the verify run.
3a. Merge this branch (`claude/magical-clarke-remja3`) into `main`. Until then the PC verify script, which checks out `main`, and the vault on the PC do not see `Planning/`.
3b. Confirm three additions to what only you may approve: new data types, save-format changes, and standing claims on your time (`CHANGE_CONTROL.md` §4).
3c. The management system is 20 documents. The reviewer recommends cutting to about 12 (merge the milestone tracker into the roadmap, the dependency graph into the backlog, change control with quality gates; drop release readiness while release is parked). They were all built because the command lists them; say the word and they are merged.

**Canon and design (each blocks named work)**

4. Is the Big Upgrade approved, in particular the Lying Interface and Appraisal as detective work? (CD-002; blocks UPG-016, IDEA-001, IDEA-002)
5. Ratify or overrule the 46 decisions made under delegation, in one pass. (CD-001)
6. Enemies that "adapt": accept the stateless, one-fight-only form, or leave adaptation out? (CD-003, IDEA-007)
7. Weapon mastery: yes or no. Recommended: no trees. (CD-005)
8. Bestiary knowledge: the five named tiers with a route that needs no killing? (CD-011, UPG-011)
9. What "Appraisal" means for Ring 0. Recommended: the bestiary tier only. (CD-012)
10. One journal vocabulary: Unknown / Heard / Visited plus a source label? (CD-013)
11. Does Brindlewick belong to Whisperwood? (CD-009; blocks T-016, T-018)
12. Seasons and gameplay weather: do they exist? (CD-014)
13. Ecology scope for now: role tags and a four-state region cycle, not the full network? (CD-008, UPG-021)
14. Over-rank species in Whisperwood: widen the band, drop the habitat, or mark "rare, deep only"? (T-008)

**Scope for Ring 0 and the slice**

15. Class line-up: Swordsman only for the slice? (UPG-034)
16. The 13 unreachable quests: park the five dungeon quests and place NPCs for the rest? (T-009)
17. Boss Break gauge: build it for Grukk or strike it from the Ring 0 text? (CD-032)
18. Approve two new data types: discoveries and quest-choice outcomes. (T-011, T-017)

**Only you can do**

19. Run the PC verify script and the fun test (T-001, T-003).
20. The player character: VRM export or the humans-base route. (UPG-031)
21. The creature art route, and a backup of the local model folders. (CD-035, R22)
22. Audio sources and licences. (UPG-030)
23. Product, company and executable names. (T-022)
24. Prune or push the local branches and worktrees on the PC. (R13)
25. Install hooks and `settings.json`, or not; where architecture decision records live. (T-021)

## Agent assignments

None running. The team, seats and tiers: `13_Production/agent_team.md`. Six agents were added today; all are invocable by name.

## Next actions

1. **You:** run `Tools/pc/update_and_verify.cmd` and send back the summary line (T-001).
2. **combat-designer:** split the fun test and prepare the sheet (T-002), so that your next session is ten minutes of play (T-003).
3. **On your approval of the first wave:** T-013 (dead-data report) and T-020 (documentation sweep) in the cloud, one or two agents at a time; T-024 (ally kill credit) in the first Unity slot after the verify run.

## Said plainly

- By the plan's own slot counts the full slice is at least three to four months away at one Unity session a week; the core cut is about half.
- About 28 decisions wait on you. Ratifying the 46 delegated canon rows alone is likely a full session of reading.
- The fun test will be played on a silent game with a capsule for a hero. Judge the feel of the controls and the fights, not the look.
- Renaming the product moves the save folder. Back up your own save before the first run of a renamed build.
- The ally-kill defect was found only when a reviewer read the Unity code line by line. The Unity side has had far less review than the rules library, and more defects of that kind should be expected.
