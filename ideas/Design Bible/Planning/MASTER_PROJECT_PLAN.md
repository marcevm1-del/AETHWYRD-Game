# Master project plan

The development strategy for AETHWYRD and the index of the management system. Proposed by the orchestrator on 2026-11-12 from the repository audit; **it takes effect when the owner approves it** (see §8). Canon and the owner's decisions outrank this file (`CHANGE_CONTROL.md` §1).

## 1. The situation this plan answers

The project has a design sized for a large studio, a rules library that is broad and well tested, and a game that is one field with one playable class (`PROJECT_STATUS.md`). The gap between what is written and what runs is the main fact. Two things widen it: new proposal documents arrive faster than features are finished, and work has been reported as done when the rules were written, before the game used them.

The team is the owner, with four to five hours a week, and Claude agents limited by five-hour usage windows. Unity runs only on the owner's PC.

## 2. Objective

Make AETHWYRD developable and deliverable: prove the core experience in one small, complete, playable slice, then grow by rings, never widening the content footprint faster than the proven systems can carry.

## 3. Strategy: six rules

1. **Prove before adding.** No new system is started before the vertical slice gate (`VERTICAL_SLICE_PLAN.md`). Until then the backlog only verifies, wires, fixes or fills what already exists (decision D-010).
2. **The game is the measure.** A system counts when the player can reach it in the build and a test or a playthrough shows it. Rules and data alone are reported as rules and data (`QUALITY_GATES.md`).
3. **Smallest thing that does the job.** Where a proposal asks for a network, a director or a framework, the plan takes the smallest connected piece first: tags before simulation, one boss before five, one weapon family before fourteen.
4. **Ideas are kept, not built.** Every proposal lands in `UPGRADE.md` or `IDEAS.md` with its cost. Nothing moves from there to the backlog without approval.
5. **No planning for its own sake.** Under rule 1 agents have little to build while Unity slots are scarce, and the easy output is more documents. No new planning document is created, and no register entry is added, unless a task or a decision needs it.
6. **The owner's hours go to what only the owner can do.** Playing and judging, the character, licences, canon decisions. Everything else is prepared so those hours are short.

## 4. What the game is, so the plan protects it

From `Canon.md` and `01_Core_Concept/game_brief.md`: a single-player, offline, anime-styled isekai adventurer RPG. You climb from rank F, fight with fluid readable action combat, tame and travel with partners, and explore a world that answers what you do. The distinctive parts, as the audits found them:

- A Status System whose interface cannot be fully trusted (the Lying Interface), and Appraisal as detective work. Designed, almost unbuilt, approval unclear (CD-002).
- Discovery over markers: knowledge as Unknown, Heard, Visited across map, dungeons and bestiary. Partly built.
- Combat that is already real in the game and is the strongest built asset.
- Partners and companions as characters. One companion and the taming loop are built.
- Regions that can be freed and then change. Liberation is built for one region; the change is thin.

The plan favours work that makes these visible over work that adds breadth.

## 5. Phases

Detail, gates and evidence are in `MASTER_ROADMAP.md`. In short:

| Phase | Name | Proves |
|---|---|---|
| 0 | Audit and management system | What exists (done 2026-11-12) |
| 1 | Verify and judge | The build still works and the core loop is fun |
| 2 | Connect what exists | The tested rules the slice needs are used by the game |
| 3 | Fill the slice | One region is a complete loop: explore, discover, fight, record, progress, change the place |
| 4 | Look and sound | It can be shown: character, creatures, sound, one styled screen |
| 5 | Slice gate | An outsider can play it; go or no-go on widening |
| 6 | Ring 1 complete | Canon's "The Wooden Card" in full |
| 7+ | Rings 2 to 9 | Content production by ring; planned only after phase 5 |

## 6. How work flows

`CHANGE_CONTROL.md` (stages A to H) → `FEATURE_BACKLOG.md` (approved tasks) → `WEEKLY_DEVELOPMENT_PLAN.md` (the cycle) → `QUALITY_GATES.md` (what done means) → `DASHBOARD.md` (the state at a glance).

The agent team, its seats, model tiers and file ownership are in `13_Production/agent_team.md`. The orchestrating session acts as executive producer: it assigns, reviews, integrates and records, and it does not accept an agent's report without checking it against the brief.

## 7. The documents and what each is for

| Document | Purpose | Authority |
|---|---|---|
| `MASTER_PROJECT_PLAN.md` | Strategy and index | Development strategy |
| `PROJECT_STATUS.md` | What exists today | Facts, with evidence |
| `SYSTEM_INVENTORY.md` | Every system and its two statuses | Status of record |
| `MASTER_ROADMAP.md` | Phases with entry and exit criteria | Sequence |
| `MILESTONE_TRACKER.md` | Progress against milestones | Progress |
| `VERTICAL_SLICE_PLAN.md` | The first complete playable experience | Slice scope |
| `FEATURE_BACKLOG.md` | Approved, actionable tasks | The only list agents implement from |
| `DEPENDENCY_MAP.md` | What relies on what | Ordering |
| `UPGRADE.md` | Improvements to existing systems | Proposal store |
| `IDEAS.md` | New possibilities | Proposal store |
| `DECISION_LOG.md` | Approved decisions | Decisions |
| `CANON_DISCREPANCIES.md` | Where sources disagree | Open conflicts |
| `TECHNICAL_RISK_REGISTER.md` | Risks and defects | Risks |
| `QUALITY_GATES.md` | What each status requires; recorded test baselines | Definition of done |
| `CHANGE_CONTROL.md` | How a change is approved | Procedure |
| `CONTENT_PRODUCTION_PIPELINE.md` | How content reaches the game | Pipeline map |
| `WEEKLY_DEVELOPMENT_PLAN.md` | The weekly cycle and tier rules | Operating rhythm |
| `RELEASE_READINESS.md` | What a release needs | Release criteria |
| `TASK_TEMPLATES.md` | Templates | Formats |
| `DASHBOARD.md` | One-page view | Read first |
| `audits/` | The evidence behind the status | Source reports |

Older documents in `13_Production/` that these replace as the live plan keep their content and carry a pointer here: `roadmap_after_upgrade_waves.md` (now `MASTER_ROADMAP.md` and `MILESTONE_TRACKER.md`), `unity_integration_dependency_map.md` (now `DEPENDENCY_MAP.md`), the risk table in `risk_register_and_usage_budget.md` (now `TECHNICAL_RISK_REGISTER.md`; its usage-budget rules stay in force). `production.md`, `ring0_plan.md`, `progress_log.md`, `agent_team.md` and `tech_debt_register.md` stay live where they are.

## 8. Approval

This plan, the roadmap, the slice definition and the first backlog are **proposed**. The owner's approval is asked for, in this order:

1. The strategy in §3, especially rule 1 (nothing new before the slice gate).
2. The slice scope in `VERTICAL_SLICE_PLAN.md`.
3. The first-wave tasks in `FEATURE_BACKLOG.md`.
4. The decisions listed in `DASHBOARD.md`.

Two items are already approved by earlier owner-accepted plans and can start at once: the PC verify run (T-001) and the fun test (T-002, T-003).

## 9. How this plan changes

Through `CHANGE_CONTROL.md`. A change of strategy is a row in `DECISION_LOG.md` before it is an edit here.
