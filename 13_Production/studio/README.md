# Studio — executive overseer records

The executive overseer's records live here. That role is a Claude session coordinating the specialist agents for the owner. The owner chose this folder on 2026-11-23, in place of the directive's root-level docs and `Documentation/AI/`.

This folder adds to the existing production records and does not replace them:
- Progress and push history: `13_Production/progress_log.md`
- Agent roster and file ownership: `13_Production/agent_team.md`
- Handovers with agent briefs: `13_Production/handover/`
- Rules: `Canon.md` wins, then `CLAUDE.md`

| File | What it holds | Status |
|---|---|---|
| [M1_AUDIT_2026-11-23.md](M1_AUDIT_2026-11-23.md) | Milestone 1 technical audit: design figures vs data, the implementation matrix, 10 conflicting recommendations, the roadmap and open decisions | Final for `main @ 8e6bc72c` |
| [AGENT_REGISTRY.md](AGENT_REGISTRY.md) | Directive roles mapped to existing agents, with requested model and effort, and the runtime facts | Proposed, awaiting owner |
| [DECISION_LOG.md](DECISION_LOG.md) | Owner decisions with date and source | Live |
| [NEXT_ACTIONS.md](NEXT_ACTIONS.md) | What waits on the owner, what agents may start, and the session handoff | Live |

## Rules for the overseer
- Never present a design figure, concept or self-reported result as built or tested. Use the status words from the audit: Designed, Data-only, Code, Tested, In-build.
- Audits run as read-only subagents. Take a `git status` snapshot before and after.
- Work that changes files goes on a branch or worktree with one owner per file set (see `agent_team.md`). Nothing goes to `main` without the owner's review.
- Every session updates `NEXT_ACTIONS.md` before it ends.
