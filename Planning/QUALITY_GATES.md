# Quality gates

Written code is not a finished feature. A feature moves up the status ladder only when the gate's evidence exists and is cited.

## 1. Status ladder

| Status | Meaning | Evidence needed |
|---|---|---|
| DOCUMENTED | Described somewhere | The doc and section |
| DESIGNED | Detailed enough that an engineer could build it without inventing rules | The design doc, with data fields or numbers |
| PLANNED | Approved and in `FEATURE_BACKLOG.md`, not started | The task ID |
| PROTOTYPE | Experimental code, not meant to ship as is | Source file |
| PARTIAL | Some of the designed behaviour exists | Source files, and what is absent |
| IMPLEMENTED | The designed behaviour exists in code | Source files |
| TESTED | Automated tests cover it and pass in a recorded run | Test file and the run (date, command, counts) |
| VERIFIED | Seen working in the running game | A PlayMode run, a screenshot, or the owner's playtest note, with date |
| COMPLETE | Meets the acceptance criteria agreed in its task | The task's criteria, each ticked with evidence |

Every system carries **two** statuses where they differ: the rules layer (`Code/Ascend.Core`) and the game (`Game/Assets/_Game/Runtime`). "Core TESTED, game not wired" is a normal, honest state here. It is never shortened to "implemented".

## 2. The ten gates

| # | Gate | Passes when | Checked by |
|---|---|---|---|
| 1 | Design approval | The change has an UPGRADE or IDEA entry; a canon check found no conflict with a locked row; major changes have a red-team review; the decision is in `DECISION_LOG.md` | Orchestrator, `canon-keeper`, owner where `CHANGE_CONTROL.md` §4 applies |
| 2 | Technical approval | Affected files and owners named; no new package or asset without the owner's OK; save impact stated; rules go in Core, not Unity, where they can | `technical-director` for major changes, otherwise the owning engineer |
| 3 | Implementation | Code and data on a branch; tuning numbers read from `Data/`, not hard-coded; new data fields have schema entries; Core stays free of `UnityEngine` | The implementer |
| 4 | Integration | Merged without behaviour change to finished features; anything unfinished sits behind a flag; `npm run build` green after the merge | Orchestrator |
| 5 | Functional test | New rules have Core tests; new in-game behaviour has a PlayMode test or a written manual check | `qa-tester` |
| 6 | Regression test | `npm run build`: data valid, Core tests not fewer than the last recorded count, map warnings not above 28, graph findings 0. Unity: PlayMode not fewer passing than the last recorded count | `qa-tester` |
| 7 | Performance | Only when the change touches per-frame code, spawning, streaming or load. A measurement (Unity Profiler or a timed test) against the 60 fps field target, or a written reason why none is needed | `performance-analyst` |
| 8 | Documentation | Design doc matches what was built; `SYSTEM_INVENTORY.md`, the UPGRADE / IDEA entry and the backlog task updated; progress-log row written | Orchestrator, `documentation-auditor` |
| 9 | Acceptance | Each acceptance criterion in the task is ticked with its evidence | Someone other than the implementer |
| 10 | Verification | The feature was seen working in the running game and the evidence is filed (run log under `Game/Logs/verify_*`, screenshot, or the owner's playtest note) | `qa-tester` or the owner |

A minor change (see `CHANGE_CONTROL.md` §2) needs gates 3, 5, 6 and 8.

## 3. Recorded baselines

The regression gate compares against the newest row here. Add a row whenever a full run is made; never edit an old row.

| Date | Where | Command | Result | Source |
|---|---|---|---|---|
| 2026-11-08 | Owner's PC | Unity PlayMode | 183 passed | `13_Production/progress_log.md` (phase 1, commit 18963dd8) |
| 2026-11-08 | Owner's PC | `npm run build` | 746 Core tests passed, data valid, 28 map warnings, 0 graph findings | same |
| 2026-11-12 | Cloud session | `npm run build` (.NET SDK 8.0.428) | **755 Core tests passed**, data valid (49 regions, 680 species, 6,754 population rows, 32 quests, 58 recipes), 28 map warnings, 0 graph findings | Run by the orchestrator for this audit |
| 2026-11-12 | Cloud session | Unity PlayMode | **Not run**: no Unity in the cloud container | - |

## 4. What a cloud session can and cannot verify

| Check | Cloud | Owner's PC |
|---|---|---|
| Data validation, generators, Core rules tests (`npm run build`) | Yes, after installing a .NET 8 SDK | Yes |
| Unity compile, PlayMode tests, scene build, player build, screenshots | **No** | Yes: `Tools/pc/update_and_verify.cmd` |
| Blender pipelines | Only if Blender is installed in the session | Yes |
| Playtest and fun test (`12_Systems/combat.md` §12) | No | Owner only |

So no feature can pass gates 6 (Unity half), 7 or 10 from the cloud. Work done in the cloud that touches Unity is reported as "not compiled in Unity" until a PC verify run says otherwise.

## 5. Words for test results

Use exactly one of: **Passed** (ran, green, evidence cited) · **Failed** (ran, red, output cited) · **Not tested** · **Blocked** (could not run, with the reason) · **Tested elsewhere** (cite the earlier run and its date). "Should pass" is not a result.
