# Weekly development cycle

One cycle is one calendar week. The owner has about 4 to 5 hours in it; agent time is limited by the 5-hour usage windows (`13_Production/risk_register_and_usage_budget.md`). The cycle exists so that those hours go to the highest-value work and every week ends with the record matching the repo.

## The limits every cycle works inside

| Limit | Value | Source |
|---|---|---|
| Agents working at once | 2; 3 when one only reads | Risk register §1 |
| Worktrees checked out | 4 | Risk register §2 |
| Unity processes on `Game/` | 1, on the owner's PC, only when the brief says "UNITY OK" | Risk register §1 |
| Blender GPU jobs | 1, in the background, counts as a working agent | Risk register §1 |
| Helper subagents inside an agent | 0 normally | Risk register §1 |
| Stop starting new work | at about 70% of a window | Risk register §3 |

## Start of the cycle (orchestrator, about 15 minutes of reading)

1. Read `DASHBOARD.md` and the newest handover in `13_Production/handover/`.
2. Read unfinished tasks in `FEATURE_BACKLOG.md` (IN PROGRESS, BLOCKED, IN REVIEW).
3. Check `DEPENDENCY_MAP.md`: what became unblocked, what is still waiting on the owner.
4. List blockers. An owner decision that blocks a P0 or P1 task goes to the top of the dashboard's decision list.
5. Pick the tasks: P0 first, then P1 for the current milestone, then at most one P2. Never more than the windows can hold (about four jobs per window: one heavy, the rest small).
6. Give each task one owning agent, one reviewer and a model tier (§ "Model tiers" below).
7. Write a brief per task (`TASK_TEMPLATES.md` §4) with deliverable and acceptance criteria.
8. Group briefs into waves of at most two agents whose files do not overlap.
9. Record the plan under "This cycle" at the bottom of this file.

## During the cycle

1. Run one wave at a time. The next wave starts when the previous one is committed and merged or parked.
2. Read each agent report against its brief. A report that only recommends is not a finished task.
3. A scope change found mid-task stops the task and becomes an UPGRADE or IDEA entry; it is not absorbed silently.
4. Disagreements follow `CHANGE_CONTROL.md` §7.
5. Finished work goes to `qa-tester` and `code-reviewer` before merge; art, world, character and UI work also to the `anime-fantasy-director`.
6. One Unity slot per week on the owner's PC: `Tools/pc/update_and_verify.cmd` first, then any Unity work. Record the result in `QUALITY_GATES.md` §3.

## End of the cycle

1. Mark tasks DONE only with their acceptance evidence.
2. Record test results (`QUALITY_GATES.md` §3 and §5 wording).
3. Update statuses in `SYSTEM_INVENTORY.md` for systems that moved.
4. Update `UPGRADE.md` and `IDEAS.md`: statuses, decision history, new entries from the week's reports.
5. Update `FEATURE_BACKLOG.md`, `MILESTONE_TRACKER.md`, and `MASTER_ROADMAP.md` if a phase gate moved.
6. Record decisions in `DECISION_LOG.md`.
7. Refresh `DASHBOARD.md`.
8. Repo rules (CLAUDE.md): a row in `13_Production/progress_log.md`, the dated note at the repo root, `node Tools/vault/build_vault.js`.
9. Write the weekly digest (`13_Production/digest_<date>.md`), including the usage telemetry row: windows used, agents run, whether the limit hit, which job was running.
10. Name the next cycle's first three tasks.

## Model tiers

| Tier | Use for | Agents pinned to it |
|---|---|---|
| Haiku | Bounded, repetitive, checkable work: inventories, ID and link checks, schema-list checks, formatting | `documentation-auditor` (pass `model: sonnet` for a deep audit) |
| Sonnet | The default for specialist work: implementation, system and content design, tests, investigations | Most seats; see `13_Production/agent_team.md` |
| Opus | Decisions where a mistake is expensive: architecture, cross-system design, red-team review, milestone reviews, final synthesis | `producer`, `technical-director`, `creative-director`, `red-team-reviewer` |

Escalate Haiku to Sonnet when the task needs judgement; Sonnet to Opus when the result commits architecture or strategy. A model passed in the invocation overrides the agent's pin for that one run. Never run several Opus agents on the same simple question.

## Team size by task

| Task | Team |
|---|---|
| Simple audit or check | 1 Haiku agent |
| Small feature or fix | 1 Sonnet agent, then reviewer |
| Medium system improvement | 2 to 3 agents over two waves |
| Major system redesign | 3 to 5 agents over several waves, with a red-team review |
| Full project audit | 5 to 6 audits, one or two agents at a time (three at once hit the usage limit on 2026-11-12) |
| Milestone review | `qa-tester`, `technical-director`, `documentation-auditor`, `red-team-reviewer` |

Do not use several agents when the task is simple, when the steps depend on each other, or when they would edit the same files.

## This cycle

### 2026-11-12 (cycle 0: set up the management system)

| Task | Owner | Tier | Result |
|---|---|---|---|
| Repository audit and baseline run | Orchestrator | session | Done: see `PROJECT_STATUS.md` |
| Agent seats, six new definitions, tier pins | Orchestrator | session | Done: see `13_Production/agent_team.md` |
| Five audits | combat-designer, bestiary-designer (as creature-ecology-designer), quest-designer (as exploration-designer), systems-designer, all on sonnet; the technical, production and QA audit was written by the orchestrator after the usage limit stopped three agents | sonnet / session | `Planning/audits/` (five reports) |
| Planning documents | Orchestrator | session | This folder |
| Review of the planning system | red-team-reviewer, documentation-auditor (two passes in place of five reviewers) | opus / haiku | `Planning/reviews/`, `DECISION_LOG.md` D-012 |

Next cycle's first tasks are listed in `DASHBOARD.md` under "Next actions".
