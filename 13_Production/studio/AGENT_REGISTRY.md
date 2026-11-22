# Agent registry

**Status: PROPOSED.** The owner has not yet chosen between mapping the directive's eight roles onto existing agents (this file) and creating eight new definitions. See DECISION_LOG D-02.

## Runtime facts (checked 2026-11-23, Claude Code 2.1.316, desktop app)
| Capability | State | Source |
|---|---|---|
| Subagents with their own model and effort (`model:` / `effort:` frontmatter, or per spawn) | Available | code.claude.com/docs/en/sub-agents |
| Worktree isolation (`isolation: worktree`) | Available. It branches from the **local default branch**, so it is stale if local `main` is behind | sub-agents doc |
| Agent teams | Experimental and **off**. Needs `CLAUDE_CODE_EXPERIMENTAL_AGENT_TEAMS=1`. Desktop-app support is undocumented. Not enabled | code.claude.com/docs/en/agent-teams |
| Parallel sessions (desktop app) | Available | app |
| `gh` CLI | **Not installed**, so no PRs, issues or branch-protection checks yet | `gh` not found |

A model or effort level listed below is what the overseer **requested**. The runtime did not confirm it.

## Roles
| ID | Role | Leads these existing agents (`.claude/agents/`) | Requested model / effort | Current task | Status |
|---|---|---|---|---|---|
| 00 | Executive Overseer | this session; `producer` | Opus / high–xhigh | Waiting on owner decisions | Active |
| 01 | Technical Architect | `technical-director`, `lead-programmer`, `core-rules-engineer`, `save-platform-engineer`, `tools-pipeline-engineer` | Opus / xhigh | M1 audit done | Idle |
| 02 | Art Director | `anime-fantasy-director`, `art-director`, `technical-artist`, `creature-artist`, `environment-artist`, `animator-rigger` | Sonnet / high | M1 audit done | Idle |
| 03 | Gameplay Engineer | `gameplay-engineer`, `combat-designer` | Sonnet / high | M1 audit done | Idle |
| 04 | World & Level Designer | `world-designer`, `world-builder-engineer`, `level-designer` | Sonnet / high | M1 audit done | Idle |
| 05 | AI & Creature Engineer | `ai-engineer`, `bestiary-designer` | Sonnet / high | M1 audit done | Idle |
| 06 | RPG Systems Engineer | `systems-designer`, `class-skill-designer`, `items-designer`, `economy-designer`, `quest-designer` | Sonnet / high | M1 audit done | Idle |
| 07 | QA & Performance | `qa-lead`, `qa-tester`, `code-reviewer`, `performance-analyst` | Sonnet / high–xhigh | Not started | Idle |
| 08 | Research & Docs | `canon-keeper`, `youtube-beta` | Haiku–Sonnet / medium | Not started | Idle |

File ownership is unchanged. It stays as written in `13_Production/agent_team.md`.

## History
| Date | Event |
|---|---|
| 2026-11-23 | Agents 01–06 ran the M1 read-only audits in parallel (Plan-type subagents, so no Edit or Write tools). `git status` of both checkouts was identical before and after. One auditor created an empty `/tmp/x.js` outside the repo by mistake. Escalations: none. |
