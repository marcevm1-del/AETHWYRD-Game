# Change control

How a change to AETHWYRD gets proposed, challenged, approved and recorded. Strategy lives in `MASTER_PROJECT_PLAN.md`; this file is only the procedure.

## 1. Order of authority

When two sources disagree, the higher one wins and the lower one is a bug to fix.

| # | Source | Where |
|---|---|---|
| 1 | Decisions the owner made explicitly | `DECISION_LOG.md` (decider = owner), locked rows of `Canon.md` |
| 2 | Canon | `Canon.md` §1 to §5. `Data/` is canonical for numbers |
| 3 | Approved system designs | `00_Questions` … `12_Systems`, and `Canon.md` §6 rows marked decided |
| 4 | Approved technical architecture | `13_Production/phase1_api.md`, `production.md` §2 to §4, `docs/engine-reference/unity/` |
| 5 | Master project plan | `Planning/MASTER_PROJECT_PLAN.md` |
| 6 | Approved backlog | `Planning/FEATURE_BACKLOG.md` |
| 7 | Upgrade register | `Planning/UPGRADE.md` |
| 8 | Ideas register | `Planning/IDEAS.md` |
| 9 | Proposals, audits, agent suggestions | `Planning/audits/`, `Canon.md` §6 open rows, `upgrade v*`, the owner's prompt documents |

Two standing cautions:

- `Canon.md` §6 rows decided "by Claude under delegated creative control" (46 rows, see `13_Production/canon_decision_index_2026-11-08.md`) rank at level 3, below anything the owner decided personally. The owner may overrule any of them, so code that depends on them stays driven by `Data/`.
- The 48 open §6 rows rank at level 9. Nothing may be built on them as if they were approved.

## 2. What counts as a major change

A change is **major** when it does any of these. Major changes go through every stage in §3.

- Edits or contradicts a `Canon.md` row, or a number `Canon.md` §2 states.
- Removes or replaces an existing system or mechanic.
- Changes a core loop: combat, progression (levels, ranks, classes), the save format, the day clock.
- Adds a new system, a new data file type, a new Unity package or a third-party asset.
- Adds content scope: regions, species, classes, companions, endings.
- Changes anything written to the save file.
- Costs more than about one working window of agent time (see `13_Production/risk_register_and_usage_budget.md` §3).

- Changes what the player experiences in the running game, however small the code change.

Everything else is **minor** (a doc correction, a test, a tool fix, tuning inside existing ranges that is not yet read by the game) and needs only stages F to H.

## 3. Stages

| Stage | What happens | Who | Output |
|---|---|---|---|
| A. Assign | Objective, systems, files, dependencies, specialist, model tier, deliverable, acceptance criteria, whether parallel work is safe | Orchestrator | A brief (`TASK_TEMPLATES.md` §4) |
| B. Investigate | Read the real files. Report what exists, what is missing, what is wrong, what is uncertain | Specialist | Findings with evidence |
| C. Design | Proposal: current state, problem, solution, player benefit, technical impact, dependencies, risks, complexity, acceptance criteria | Specialist | An UPGRADE or IDEA entry, status PROPOSED / NEW |
| D. Challenge | Major changes only. Weak assumptions, conflicts, missing dependencies, exploits, scope, alternatives | `red-team-reviewer`, plus `canon-keeper` when canon is touched | Review findings |
| E. Approve | Reject, defer, investigate, keep as IDEA, keep as UPGRADE, approve for backlog | Orchestrator; **the owner** for canon, scope, purchases, licences and anything in §4 | A row in `DECISION_LOG.md`; a task in `FEATURE_BACKLOG.md` if approved |
| F. Implement | Only tasks in the backlog with status READY | The owning engineer or designer | Commits on a branch |
| G. Test | The implementer is never the only reviewer of a critical change | `qa-tester`, `code-reviewer` | Recorded results (`QUALITY_GATES.md`) |
| H. Integrate | Docs, backlog status, dependency map, UPGRADE / IDEA entries, decision history, test record updated; canon check clean | Orchestrator | Merge, progress-log row, daily note, vault rebuild |

## 4. Reserved for the owner

No agent, including the orchestrator, decides these:

- Locking, unlocking or editing a `Canon.md` row; ratifying or overruling the delegated §6 batch.
- Adding or cutting content scope (regions, species, classes, companions, endings, rings).
- Anything that costs money, needs an account, a key or a licence, or adds a third-party asset.
- The player character (VRM or humans-base), voice amount, title and release decisions.
- Installing hooks, `settings.json` or MCP bridges.
- Deleting branches, worktrees or files that hold unmerged work.
- A new data file type or schema, and any change to what the save file holds.
- Any standing claim on the owner's own time (a weekly run, a playtest).
- The strategy, the slice scope and the first backlog (`MASTER_PROJECT_PLAN.md` §8).

## 5. What no agent may do silently

Delete an established system · replace a major mechanic · rewrite canon · expand scope · change a fundamental loop · change progression assumptions · mark a proposal approved · mark anything TESTED or VERIFIED without the evidence `QUALITY_GATES.md` asks for · delete an UPGRADE or IDEA entry (set it to REJECTED or DEFERRED with the reason instead).

## 6. Contradictions

A contradiction between documents, or between a document and `Data/` or code, is recorded in `CANON_DISCREPANCIES.md` before anyone fixes it. The fix follows §1. If §1 does not settle it, the entry waits for the owner.

## 7. Agent disagreement

1. Record both positions in the task's report.
2. Name the assumption each rests on.
3. Ask each for evidence from the repo.
4. Weigh the consequence for the player and for the schedule.
5. Use the `red-team-reviewer` when the stakes are major.
6. The orchestrator decides, or takes it to the owner when §4 applies.
7. Record the decision in `DECISION_LOG.md`.
