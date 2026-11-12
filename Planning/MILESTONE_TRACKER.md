# Milestone tracker

Progress against milestones, with evidence. A milestone is done only when its "done when" line has evidence in the last column. Updated at the end of each weekly cycle.

## Roadmap milestones

| ID | Milestone | Phase | Done when | State on 2026-11-12 | Evidence |
|---|---|---|---|---|---|
| MS-0 | Management system in place | 0 | Planning folder reviewed; agents seated; audits filed | **Done** | `DECISION_LOG.md` D-003 to D-012 |
| MS-1 | Build verified | 1 | A PlayMode count for the current commit is recorded | Not started (needs the owner's PC) | - |
| MS-2 | Core loop judged | 1 | Every testable fun-test box is pass or fail | Not started | - |
| MS-3 | First performance number | 1 | Frame time, allocations and draw calls recorded for the Ring 0 fight | Not started | - |
| MS-4 | Slice rules wired | 2 | Phase 2 deliverables meet their acceptance criteria | Not started | - |
| MS-5 | Slice loop complete | 3 | Slice gate criteria 1 to 6 | Not started | - |
| MS-6 | Slice presentable | 4 | Slice gate criteria 7 and 8 | Blocked on the owner (character, art route, audio) | - |
| MS-7 | Slice gate decision | 5 | Go, fix or rethink recorded | Not started | - |
| MS-8 | Ring 1 complete | 6 | Defined at MS-7 | Not planned | - |

## The earlier milestones (from `13_Production/roadmap_after_upgrade_waves.md`), mapped

| Old | Name | Where it went | State |
|---|---|---|---|
| M0 | Integrate and clean | Mostly done: agent batches 1 and 2 merged (progress log 2026-11-09 and 2026-11-11). Remaining: the baseline verify run (MS-1) and pruning PC worktrees (owner) | Partly done |
| M1 | Ring 0 shippable | MS-1 to MS-3, plus the player character (MS-6) | Open |
| M2 | Systems playable in the field | Companion bonds and presets are in the save (verified in `SaveGame.cs`). The rest is MS-4 | Partly done |
| M3 | Look and sound pass | MS-6 | Blocked on the owner |
| M4 | Ring 1 content | Split: the slice part is MS-5; the rest is MS-8 | Open |
| M5 | Vertical slice for outsiders | MS-7 | Open |

## Ring 0 plan (`13_Production/ring0_plan.md`)

| Week | Milestone | State | Note |
|---|---|---|---|
| 1, 2, 4 to 9 | Boot, run, swing, dodge, monsters, air, skills, status | Built, PlayMode tested 2026-11-08 | Not re-verified since |
| 3 | Your face in the game | Waiting on the owner's character | UPG-031 |
| 10 | Polish and the fun test | Build exists; fun test never run | UPG-001 |

## Rule

No percentage is shown. A milestone is done or it is not, and the evidence column says why.
